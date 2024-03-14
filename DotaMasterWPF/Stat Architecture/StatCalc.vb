Public Class StatCalc
  Private mStattype As eStattype
  Private mOwner As iGameEntity
  Private mGame As dGame
  Private dbMods As Modifier_Database
  Private mFormula As Formula
  Private mMods As List(Of Modifier)
  Private mModsByType As Dictionary(Of eModifierType, ModifierList)

  Private mStats As List(Of Stat)
  Private mStatsByType As Dictionary(Of eStattype, List(Of Stat))

  Private mBaseValue 'Base movespeed, base attackspeed, base damage, etc
  Private mPrePercentValue As Double? = Nothing
  Private mValues As ValueList
  Private mTimepoints As DDFrame_List

  Public mIsDirty As Boolean = True

  Private dbNames As FriendlyName_Database

  ' Private mMaxValue As Double?
  Public Sub New(thestattype As eStattype, theowner As iGameEntity, thegame As dGame) ' themods As ModifierList,  thestats As List(Of Stat), _
    ' theformula As List(Of FormulaElement),  thetimepoints As DDFrame_List)
    If thestattype = eStattype.HitPoints Then
      Dim x = 2
    End If
    mStattype = thestattype
    mOwner = theowner
    mGame = thegame
    dbMods = mGame.dbModifiers
    dbNames = mGame.dbNames
    If theowner.EntityName = eEntity.Hero_Instance Then
      Dim hero As HeroInstance = DirectCast(theowner, HeroInstance)
      mFormula = mGame.dbFormulas.GetFormula(thestattype, hero.GetHero.PrimaryStat)
    Else
      mFormula = mGame.dbFormulas.GetFormula(thestattype, ePrimaryStat.None)
    End If

    mTimepoints = mGame.TimeKeeper.TimePoints

  End Sub

  Public Sub Load()
    If mStattype = eStattype.HitPoints Then
      Dim x = 2
    End If
    LoadModsAndStats()
    ArrangeMods()
    ArrangeStats()
    Calc()
    mIsDirty = False

  End Sub

  Public ReadOnly Property MaxValue As Double?
    Get
      If mIsDirty Then
        Load()
      End If
      Return mValues.values.Max
    End Get
  End Property

  Public ReadOnly Property MyModsbytype As Dictionary(Of eModifierType, ModifierList)
    Get
      If mIsDirty Then
        Load()
      End If
      Return mModsByType
    End Get
  End Property
  Public ReadOnly Property MyStats As List(Of Stat)
    Get
      If mIsDirty Then
        Load()
      End If
      Return mStats
    End Get
  End Property

  Private Sub LoadModsAndStats()
    Dim modtypes = mFormula.GetModTypes
    Dim stattypes = mFormula.GetStatTypes


    'get all parent ID's, Source ID's and Target ID's
    Dim parents = GetGameEntitiesFromEStatSources(mFormula.Parents)
    Dim sources = GetGameEntitiesFromEStatSources(mFormula.Sources)
    Dim targets = GetGameEntitiesFromEStatSources(mFormula.Targets)
    mMods = New List(Of Modifier)
    'Go thru all modtypes and pull out mods with matching parents, sources, or targets. eliminate duplicates
    For i = 0 To modtypes.Count - 1
      Dim pmods = mGame.dbModifiers.GetModsByParentsAndType(parents, modtypes.Item(i))
      Helpers.AddlisttoList(Of Modifier)(mMods, pmods)
      Dim smods = mGame.dbModifiers.GetModsBySourcesAndType(sources, modtypes.Item(i))
      Helpers.AddlisttoList(Of Modifier)(mMods, smods)
      Dim tmods = mGame.dbModifiers.GetModsByTargetsAndType(targets, modtypes.Item(i))
      Helpers.AddlisttoList(Of Modifier)(mMods, tmods)

    Next

    'Go thru all stattypes and pull out stats with matching parent IDs
    mStats = New List(Of Stat)
    For i = 0 To stattypes.Count - 1
      For p = 0 To parents.Count - 1
        Dim curstat = mGame.dbModifiers.GetStatByParentandType(parents.Item(p), stattypes.Item(i))
        If curstat IsNot Nothing Then
          If Not mStats.Contains(curstat) Then mStats.Add(curstat)
        End If
      Next
    Next


  End Sub

  Private Function GetGameEntitiesFromEStatSources(thesources As List(Of eStatSource)) As List(Of iGameEntity)
    Dim outlist As New List(Of iGameEntity)
    For i = 0 To thesources.Count - 1
      Dim curlist = GetGameEntitiesFromEStatSource(thesources.Item(i))
      For x = 0 To curlist.Count - 1
        If Not outlist.Contains(curlist.Item(x)) Then
          outlist.Add(curlist.Item(x))
        End If
      Next
    Next
    Return outlist
  End Function
  Private Function GetGameEntitiesFromEStatSource(thesource As eStatSource) As List(Of iGameEntity)
    Dim outlist As New List(Of iGameEntity)
    Select Case thesource
      Case eStatSource.Self
        outlist.Add(mOwner)
      Case eStatSource.TeamMembers
        outlist = mGame.GetTeamFromGameEntity(mOwner).GetAllGameEntitiesIncludingTeamGameEntity

      Case eStatSource.EnemyTeamMembers
        outlist = mGame.GetEnemyTeam(mOwner).GetAllGameEntitiesIncludingTeamGameEntity

    End Select
    Return outlist
  End Function

  Public ReadOnly Property Valuelist As ValueList
    Get
      If mValues Is Nothing Then
        mValues = New ValueList(mTimepoints.TheFrames)
        Me.Load()

      End If

      Return mValues
    End Get
  End Property
  'Public ReadOnly Property ParentID As dvID
  '  Get
  '    Select Case mOwner.type
  '      Case eEntity.Hero_Instance
  '        Dim p As HeroInstance = mOwner.obj
  '        Return p.ID
  '      Case eEntity.Creep_Info
  '        Dim c As Creep_Info = mOwner.obj
  '        Return c.ID
  '      Case Else
  '        Dim x = 2
  '        PageHandler.theLog.WriteLog("StatCalc.ParentID unhandled type: " & mOwner.type.ToString)
  '        Return Nothing
  '    End Select
  '  End Get
  'End Property
  Private Sub ArrangeMods()
    mModsByType = New Dictionary(Of eModifierType, ModifierList)

    For i As Integer = 0 To mMods.Count - 1
      Dim curmod = mMods.Item(i)
      If Not mModsByType.ContainsKey(curmod.ModifierType) Then
        Dim newmod As New ModifierList()
        newmod.Add(curmod)
        mModsByType.Add(curmod.ModifierType, newmod)
      Else
        Dim curmods = mModsByType.Item(curmod.ModifierType)
        curmods.Add(curmod)
      End If

    Next

  End Sub

  Private Sub ArrangeStats()
    mStatsByType = New Dictionary(Of eStattype, List(Of Stat))

    For i As Integer = 0 To mStats.Count - 1

      Dim curstat = mStats.Item(i)
      If curstat.StatType = eStattype.Kills Then
        Dim x = 2
      End If
      If Not mStatsByType.ContainsKey(curstat.StatType) Then
        Dim newlist As New List(Of Stat)
        newlist.Add(curstat)
        mStatsByType.Add(curstat.StatType, newlist)
      Else
        Dim curlist = mStatsByType.Item(curstat.StatType)
        If Not curlist.Contains(curstat) Then
          curlist.Add(curstat)
        End If
      End If

    Next
  End Sub


  Private Sub Calc()

    If mStattype = eStattype.HitPoints Then
      Dim x = 2
    End If
    Dim mvallist = New List(Of Double?)
    For x As Integer = 0 To mTimepoints.TheFrames.Count - 1
      Dim curtime As ddFrame = mTimepoints.TheFrames.Item(x)
      Dim curval As Double? = Nothing

      For i As Integer = 0 To mFormula.Count - 1
        Dim mathact = mFormula.Item(i).MathAction
        If mathact = eMathAction.InputMinusPercetageofPrePercValue Or _
          mathact = eMathAction.InputPlusPercentageOfPrePercValue Then
          mPrePercentValue = curval
        End If
        Dim theelement = mFormula.Item(i)

        If theelement.ModType = eModifierType.StrIncrementAdded AndAlso x = 120 Then
          Dim y = 2
        End If

        curval = CalcFormulaElement(curval, theelement, mTimepoints.Item(x))

      Next
      mvallist.Add(curval)
    Next
    mValues = New ValueList(mTimepoints.TheFrames)
    mValues.values = mvallist
    ' PageHandler.theLog.WriteLog(mStattype.ToString & ".Calc completed")
  End Sub

  Public Function GetFriendlyFormula(fortime As ddFrame) As List(Of List(Of String))
    Dim curval As Double? = Nothing
    Dim prevval As Double? = Nothing
    Dim outlist As New List(Of List(Of String))

    For i As Integer = 0 To mFormula.Count - 1
      Dim mathact = mFormula.Item(i).MathAction
      If mathact = eMathAction.InputMinusPercetageofPrePercValue Or _
        mathact = eMathAction.InputPlusPercentageOfPrePercValue Then
        mPrePercentValue = curval
      End If

      curval = CalcFormulaElement(curval, mFormula.Item(i), fortime)
      If i = 0 Then
        prevval = curval
      End If
      outlist.Add(GetFriendlyFormulaElement(fortime, curval, prevval, i, mFormula))
    Next
    ' PageHandler.theLog.writelog(mStattype.ToString & ".Calc T(" & x.ToString & "): " & curval.ToString)

    Return outlist
  End Function
  Private Function GetFriendlyFormulaElement(curtime As ddFrame, _
                                              curval As Double?, prevval As Double?, _
                                              theelementindex As Integer, theformula As Formula) As List(Of String)
    Dim theelement = theformula.Item(theelementindex)
    Dim outstring As New List(Of String) 'prevval.ToString & " " & theelement.MathAction.ToString & " " & prevval.ToString & "|"
    If theelement.IsModifier Then
      If mModsByType.ContainsKey(theelement.ModType) Then
        Dim themods = mModsByType.Item(theelement.ModType)
        For i As Integer = 0 To themods.Count - 1
          Dim curmod = themods.Item(i)
          Dim curvalue As Double?
          If Not theelement.MathAction = eMathAction.InputPlusProductofValueAndStaticVal Then
            curvalue = curmod.Value(curtime)
          Else
            If theelement.StaticValue.HasValue Then
              curvalue = curmod.Value(curtime) * theelement.StaticValue
            Else
              curvalue = Nothing
            End If
          End If
          Dim cursource = curmod.ModGenerator
          Dim curparent = curmod.Parent

          If curvalue.HasValue AndAlso Not curvalue = 0 Then
            If curvalue > 0 Then
              If Not cursource Is curparent Then
                outstring.Add("+" & curvalue.ToString & " from " & curparent.DisplayName & "'s " & cursource.DisplayName)
              Else
                outstring.Add("+" & curvalue.ToString & " from " & cursource.DisplayName & "'s " & dbNames.GetFriendlyModifierName(curmod.ModifierType))
              End If

            Else
              If Not cursource Is curparent Then
                outstring.Add(curvalue.ToString & " from " & curparent.DisplayName & "'s " & cursource.DisplayName)
              Else
                outstring.Add(curvalue.ToString & " from " & cursource.DisplayName & "'s " & dbNames.GetFriendlyModifierName(curmod.ModifierType))
              End If

            End If

          End If

        Next
      Else
        'we're a mod but we don't have any matching mods
        Return Nothing
      End If

    Else
      'We're a Stat
      If mStatsByType.ContainsKey(theelement.StatType) Then
        Dim thestats = mStatsByType.Item(theelement.StatType)

        For i = 0 To thestats.Count - 1
          Dim thestat = thestats.Item(i)

          Dim curvalue As Double?
          If Not theelement.MathAction = eMathAction.InputPlusProductofValueAndStaticVal Then
            curvalue = thestat.Value(curtime)
          Else
            If theelement.StaticValue.HasValue Then
              curvalue = thestat.Value(curtime) * theelement.StaticValue
            Else
              curvalue = Nothing
            End If
          End If
          Dim cursource = thestat.ParentGameEntity
          Dim curparent = thestat.ParentGameEntity

          If curvalue.HasValue AndAlso Not curvalue = 0 Then
            If curvalue > 0 Then
              If Not cursource Is curparent Then
                outstring.Add("+" & curvalue.ToString & " from " & curparent.DisplayName & "'s " & cursource.DisplayName)
              Else
                outstring.Add("+" & curvalue.ToString & " from " & cursource.DisplayName & "'s " & thestat.StatType.ToString)
              End If

            Else
              If Not cursource Is curparent Then
                outstring.Add(curvalue.ToString & " from " & curparent.DisplayName & "'s " & cursource.DisplayName)
              Else
                outstring.Add(curvalue.ToString & " from " & cursource.DisplayName & "'s " & thestat.StatType.ToString)
              End If

            End If

          End If

        Next
      Else
        'we're a stat but we don't have any matching mods
        Return Nothing
      End If
    End If
    Return outstring
  End Function

  Private Function CalcFormulaElement(thecurrentvalue As Double?, _
                                       theelement As FormulaElement, _
                                       thetime As ddFrame) As Double?




    If theelement.IsModifier Then
      'returns nothing but should return baseint of 14
      If mModsByType.ContainsKey(theelement.ModType) Then

        '  Dim themods = mModsByType.Item(theelement.ModType)
        Dim theval = ModFilters.GetSumOfModsForTime(mModsByType.Item(theelement.ModType), thetime)
        Return CalcElement(theelement, thecurrentvalue, theval)
      Else
        Return thecurrentvalue

      End If


    Else

      If mStatsByType.ContainsKey(theelement.StatType) Then
        Dim thevals = mStatsByType.Item(theelement.StatType) '.GetValue(thetime)
        ' Dim outval As Double? = 0
        For i = 0 To thevals.Count - 1
          Dim theval = thevals.Item(i).Value(thetime)
          Dim newval = CalcElement(theelement, thecurrentvalue, theval)
          thecurrentvalue = newval
        Next
      Else
        Return thecurrentvalue
      End If


    End If

    Return thecurrentvalue
  End Function





  Private Function CalcElement(theelement As FormulaElement, _
                                theinput As Double?, thevalue As Double?) As Double?
    'if thevalue is nothing then we don't do anything
    If Not thevalue.HasValue Then Return theinput

    Select Case theelement.MathAction
      Case eMathAction.InputPlusValue
        If theinput.HasValue AndAlso thevalue.HasValue Then
          Return theinput + thevalue
        End If
        If Not theinput.HasValue AndAlso Not thevalue.HasValue Then
          Return theinput
        End If

        If theinput.HasValue Then
          Return theinput
        End If
        If thevalue.HasValue Then
          Return thevalue
        End If
        Return theinput

      Case eMathAction.InputPlusPercentageOfPrePercValue
        If theinput.HasValue AndAlso thevalue.HasValue Then
          Return theinput + (mPrePercentValue * thevalue)
        End If
        If Not theinput.HasValue AndAlso Not thevalue.HasValue Then
          Return theinput
        End If

        If theinput.HasValue Then
          Return theinput
        End If
        If thevalue.HasValue Then
          Return mPrePercentValue * thevalue
        End If
        Return theinput


      Case eMathAction.InputMultipliedByValue
        If theinput.HasValue AndAlso thevalue.HasValue Then
          Return theinput * thevalue
        End If
        If Not theinput.HasValue AndAlso Not thevalue.HasValue Then
          Return theinput
        End If

        If Not thevalue.HasValue Then
          Return theinput
        End If

        Return theinput


      Case eMathAction.InputMinusValue
        If theinput.HasValue AndAlso thevalue.HasValue Then
          Return theinput - thevalue
        End If
        If Not theinput.HasValue AndAlso Not thevalue.HasValue Then
          Return theinput
        End If

        If theinput.HasValue Then
          Return theinput
        End If
        If thevalue.HasValue Then
          Return thevalue * -1
        End If
        Return theinput


      Case eMathAction.InputMinusPercetageofPrePercValue
        If theinput.HasValue AndAlso thevalue.HasValue Then
          Return theinput - (mPrePercentValue * thevalue)
        End If
        If Not theinput.HasValue AndAlso Not thevalue.HasValue Then
          Return theinput
        End If

        If theinput.HasValue Then
          Return theinput
        End If
        If thevalue.HasValue Then
          Return (mPrePercentValue * thevalue) * -1
        End If
        Return theinput


      Case eMathAction.SetToValueIfValueExists
        If thevalue.HasValue Then
          Return thevalue
        Else
          Return theinput
        End If

      Case eMathAction.SetToMaxValueIfValueExists
        Select Case mStattype
          Case Else

            PageHandler.theLog.WriteLog("Statcalc.calcelement eMathAction.SetToMaxValueIfValueExists unhandled for " & mStattype.ToString)
        End Select


      Case eMathAction.SetToMinValueIfValueExists
        Select Case mStattype
          Case eStattype.MovementSpeed
            Return 0
          Case Else
            PageHandler.theLog.WriteLog("Statcalc.calcelement eMathAction.SetToMinValueIfValueExists unhandled for " & mStattype.ToString)
        End Select


      Case eMathAction.SetToValueIfGreaterThanInput
        If thevalue > theinput Then
          Return thevalue
        Else
          Return theinput
        End If

      Case eMathAction.InputPlusProductofValueAndStaticVal
        If thevalue.HasValue Then
          If theelement.StaticValue.HasValue Then
            If theinput.HasValue Then
              Return theinput + (thevalue * theelement.StaticValue)
            Else
              Dim output As Double = thevalue * theelement.StaticValue
              Dim dub As Double = Math.Round(output, 2)
              output = dub
              Return output
            End If

          End If
        Else
          Return theinput
        End If
      Case eMathAction.InputdividedbyAlliedHeroCount
        If theinput.HasValue Then
          Return theinput / mGame.GetTeamHeroCount(mGame.GetTeamNameFromUnit(mOwner))
        End If
      Case Else
        PageHandler.theLog.WriteLog("StatCalc.CalcElement missing eMathAction: " & theelement.MathAction.ToString)
        Throw New NotImplementedException
    End Select

  End Function


  'Public Class ModifierComparer
  '  Implements IEqualityComparer(Of Modifier)


  '  Public Function Equals(x As Modifier, y As Modifier) As Boolean Implements IEqualityComparer(Of Modifier).Equals
  '    If x Is Nothing OrElse y Is Nothing Then
  '      Return False
  '    End If
  '    ' 'A' = 'a' just to demonstrate case-insensitive duplicates
  '    Return x.GuidID.ToString.Equals(y.GuidID.ToString, StringComparison.OrdinalIgnoreCase)
  '  End Function

  '  Public Function GetHashCode(obj As Modifier) As Integer Implements IEqualityComparer(Of Modifier).GetHashCode
  '    If obj Is Nothing Then
  '      Return Integer.MinValue
  '    End If
  '    Return obj.GuidID.ToString.GetHashCode()
  '  End Function
  'End Class



End Class
