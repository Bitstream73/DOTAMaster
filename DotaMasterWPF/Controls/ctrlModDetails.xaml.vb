
#Const Devmode = False
Imports DotaMasterWPF.PageHandler
Public Class ctrlModDetails

  Private mMods As ModifierList
  Private mStat As Stat
  Private mGame As dGame
  Private dbNames As FriendlyName_Database




  Private mCurTime As ddFrame
  ' Private mCurVal As Double
  Private mCurType As eStringFormatType
  Private mCurModLevel As Integer

  Private mSecTimeSpan As Double
  'Private mUpdatableTinyDetails As New Dictionary(Of String, ctrlModTinyDetailsLabel)

  Private ownerthumb As ctrlImageThumb
  Private targetthumbs As List(Of ctrlHero_Thumb)

  Private tarurls As List(Of String)
  Private tarcolors As List(Of SolidColorBrush)
  Private tarcolors2 As List(Of SolidColorBrush)

  Private mCtrlModTexts As New List(Of ctrlModText)

  Private mVisibleMods As Integer

  Private mOwnerColor As SolidColorBrush
  Private mSourceColor As SolidColorBrush
  'dev controls
  Dim lbl As New ctrlBody_Paragraph()


  Public Sub New(themods As ModifierList, thecurmodlevel As Integer, thecurrenttime As ddFrame, thegame As dGame)
    InitializeComponent()




    mMods = themods
    mCurTime = thecurrenttime
    mGame = thegame
    mCurModLevel = thecurmodlevel
    dbNames = mGame.dbNames

    If Not mMods Is Nothing Then

      Dim mMod = mMods.Item(0)

      LoadModTargets(mMod, mCurModLevel, mCurTime, mGame)

      LoadModParent(mMods.Item(0), mCurModLevel, mCurTime, mGame)


      If themods.Count > 0 Then
        If Not themods.Item(0).TheModInfo.ModGenerator.Id.GuidID = themods.Item(0).TheModInfo.Parent.Id.GuidID Then
          LoadModSource(mMods.Item(0), mCurModLevel, mCurTime, mGame)
        End If
      End If



      For i As Integer = 0 To themods.Count - 1
        LoadModText(mMods.Item(i), mCurModLevel, mCurTime, mGame, dbNames)
      Next

    End If
    rectNeutralColor.Fill = New SolidColorBrush(dbColors.BackgroundColor)
    UpdateExistingMod(mCurTime)
  End Sub
  Public Sub New(themod As Modifier, thecurmodlevel As Integer, thecurrenttime As ddFrame, thegame As dGame)
    InitializeComponent()

    'Add Flagsfor diff items to be displayed such as back color for owner, owner portrait, duration, etc



    Me.Padding = New Thickness(0)
    mMods = New ModifierList
    mMods.Add(themod)
    mGame = thegame
    dbNames = mGame.dbNames

    mCurTime = thecurrenttime
    mCurModLevel = thecurmodlevel
    '  mCurVal = mMods.Item(0).Value(mCurTime)


    If Not mMods Is Nothing Then
      Dim mMod = mMods.Item(0)
      LoadModTargets(mMod, mCurModLevel, mCurTime, mGame)
      LoadModParent(mMods.Item(0), mCurModLevel, mCurTime, mGame)

      If Not themod.TheModInfo.ModGenerator.Id.GuidID = themod.TheModInfo.Parent.Id.GuidID Then
        LoadModSource(mMods.Item(0).ModGenerator, mCurModLevel, mCurTime, mGame)
      End If

      LoadModText(mMod, mCurModLevel, mCurTime, mGame, dbNames)

    End If
    rectNeutralColor.Fill = New SolidColorBrush(dbColors.BackgroundColor)
    UpdateExistingMod(mCurTime)
  End Sub
  Public Sub New(thestat As Stat, thecurrenttime As ddFrame, thegame As dGame)
    InitializeComponent()

    Me.Padding = New Thickness(0)
    mStat = thestat
    mGame = thegame
    mCurTime = thecurrenttime
    mCurModLevel = 0


    If Not mStat Is Nothing Then
      LoadStatParent(thestat.ParentGameEntity, mStat, mCurTime, mGame)

      LoadStatText(mStat, mCurTime, mGame)
    End If
    rectNeutralColor.Fill = New SolidColorBrush(dbColors.BackgroundColor)
    UpdateExistingMod(mCurTime)
  End Sub
  Private Sub LoadModSource(themod As Modifier, thecurmodlevel As Integer, thecurrenttime As ddFrame, thegame As dGame)
    Dim source = themod.ModGenerator
    Select Case source.EntityName
      Case eEntity.Hero_Instance '.Hero_Instance
        Dim hero As HeroInstance = DirectCast(source, HeroInstance)
        mSourceColor = New SolidColorBrush(PageHandler.dbColors.GetColor(themod.TheModInfo.ModGenerator))
        Dim thethumb As New ctrlImageThumb(hero, 35, 35)

        spnlOwnerPortrait.Children.Add(ownerthumb)
      Case eEntity.Item_Info

        Dim theitem As Item_Info = DirectCast(source, Item_Info)

        Dim itthumb As New ctrlImageThumb(theitem, 35, 35)

        spnlOwnerPortrait.Children.Add(itthumb)

      Case eEntity.Ability_Info

        Dim theability As Ability_Info = DirectCast(source, Ability_Info)

        Dim abthumb As New ctrlImageThumb(theability, 35, 35) ', myAbility.mAbilityLevel)

        spnlOwnerPortrait.Children.Add(abthumb)

      Case Else
        PageHandler.theLog.Writelog("In ctrlModDetails.LoadModSource with unhandled ModGeneratorType: " & themod.TheModInfo.ModGenerator.MyType.ToString)
        Throw New NotImplementedException
    End Select
  End Sub
  Private Sub LoadModParent(themod As Modifier, thecurmodlevel As Integer, thecurrenttime As ddFrame, thegame As dGame)

    If themod.TheModInfo.Parent.EntityName = eEntity.Hero_Instance Then

      mOwnerColor = New SolidColorBrush(PageHandler.dbColors.GetColor(themod.TheModInfo.Parent))
      ownerthumb = New ctrlImageThumb(themod.TheModInfo.Parent, 35, 35)
      rectOwnerSwatch.Fill = mOwnerColor

      spnlOwnerPortrait.Children.Add(ownerthumb)

      rectBackground.Fill = New SolidColorBrush(Color.FromArgb(65, mOwnerColor.Color.R, mOwnerColor.Color.G, mOwnerColor.Color.B))

    Else
      Dim x = 2
    End If

#If Devmode Then

    lbl.LayoutRoot.Text = themod.TheModInfo.mParentID.FriendlyGuid
    spnlOwnerPortrait.Children.Add(lbl)
#End If

  End Sub

  Private Sub LoadStatParent(parent As iGameEntity, thestat As Stat, thecurrenttime As ddFrame, thegame As dGame)
    'Dim owner As HeroInstance = theparent.obj
    mOwnerColor = New SolidColorBrush(PageHandler.dbColors.GetColor(thestat.ParentGameEntity))

    ownerthumb = New ctrlImageThumb(parent, 35, 35)

    rectOwnerSwatch.Fill = mOwnerColor
    spnlOwnerPortrait.Children.Add(ownerthumb)

    rectBackground.Fill = New SolidColorBrush(Color.FromArgb(65, mOwnerColor.Color.R, mOwnerColor.Color.G, mOwnerColor.Color.B))
  End Sub

  Private Sub LoadStatText(thestat As Stat, thecurrenttime As ddFrame, thegame As dGame)
    Dim curval = thestat.GetValue(thecurrenttime)
    setformatvaluetype(thestat)
    Dim str = ""
    If curval.HasValue Then
      str = FormatString(curval, mCurType)
    End If

    Dim col = New SolidColorBrush(dbColors.GetColor(thestat.StatType))
    Dim statstr = dbNames.GetFriendlyStatName(thestat.StatType)
    Dim curmodtext As New ctrlModText(str, _
                                      col, _
                                      statstr)


    spnlModTexts.Children.Add(curmodtext)
    mCtrlModTexts.Add(curmodtext)
  End Sub
  Private Sub LoadModText(themod As Modifier, thecurmodlevel As Integer, thecurrenttime As ddFrame, thegame As dGame, namesdb As FriendlyName_Database)
    dbNames = namesdb

    Dim curval = themod.Value(thecurrenttime)
    setformatvaluetype(themod)
    Dim str = ""
    If curval.HasValue Then
      str = FormatString(curval, mCurType)
    End If

    Dim col = New SolidColorBrush(dbColors.GetColor(themod.ModifierType))
    Dim modstr = dbNames.GetFriendlyModifierName(themod.ModifierType).ToUpper
    Dim curModText As New ctrlModText(str, _
                                      col, _
                                     modstr)






    Dim vals = themod.TheModValue
    Dim curlvl = themod.GetLevelAtTime(thecurrenttime)
    Dim curindex = curlvl - 1
    If curindex < 0 Then
      Dim x = 2
    End If

    Try
      If Not vals.mValueDuration Is Nothing Then
        Dim duration = vals.mValueDuration.Value(curindex)
        Dim outval As String = ""
        If Not duration Then
          outval = Helpers.GetFriendlyTimeSpan(duration)
        End If

        Dim mlittledeets As New ctrlModTinyDetailsLabel("Duration", outval)
        curModText.mUpdatableTinyDetails.Add("Duration", mlittledeets)
        curModText.wpnlModdetails.Children.Add(mlittledeets)
      End If
    Catch ex As Exception
      Dim x = 2
    End Try


    Try
      If Not vals.mValueInterval Is Nothing Then
        Dim secs = themod.TheModValue.mValueInterval.Value(curindex)
        Dim outval As String = ""
        If Not secs Is Nothing Then
          mSecTimeSpan = Helpers.GetTimeSpanAsSeconds(TimeSpan.FromSeconds(secs))
          If curval.HasValue Then
            outval = (curval / mSecTimeSpan).ToString & "/sec"
          End If

        End If

        Dim mlittledeets2 As New ctrlModTinyDetailsLabel("", outval)
        curModText.mUpdatableTinyDetails.Add("persec", mlittledeets2)
        curModText.wpnlModdetails.Children.Add(mlittledeets2)
      End If
    Catch ex As Exception
      Dim x = 2
    End Try

    Try
      If Not vals.mPercentChance Is Nothing Then
        Dim percent = vals.mPercentChance.Value(curindex)
        Dim outval As String = ""
        If Not percent Is Nothing Then
          If percent.HasValue Then
            outval = (percent * 100).ToString & "%"
          End If

        End If

        Dim mlittledeets3 As New ctrlModTinyDetailsLabel("% Chance", outval)
        curModText.wpnlModdetails.Children.Add(mlittledeets3)
      End If
    Catch ex As Exception
      Dim x = 2
    End Try


    Try
      If Not vals.Charges Is Nothing Then

        If Not vals.Charges.Value(curindex) Is Nothing Then
          If vals.Charges.Value(curindex) > 1 Then
            Dim charges = vals.Charges.Value(curindex)
            Dim outval As String = ""
            If Not charges Is Nothing Then
              outval = charges.ToString
            End If
            Dim mlittledeets4 As New ctrlModTinyDetailsLabel("Charges", outval)
            curModText.wpnlModdetails.Children.Add(mlittledeets4)
          End If
        End If
      End If

    Catch ex As Exception
      Dim x = 2
    End Try

    Dim infs = themod.TheModInfo
    Try

      If Not infs.AffectedUnitTypes Is Nothing Then
        If Not infs.AffectedUnitTypes.Count < 1 Then


          Dim units = infs.AffectedUnitTypes
          Dim outunits As String = ""

          For i As Integer = 0 To units.Count - 1
            'If i = 0 Then
            '  outunits = Helpers.GetFriendlyUnitName(units.Item(i))
            'Else
            If Not i = units.Count - 1 Then

              outunits += dbNames.GetFriendlyUnitName(units.Item(i)) & " or "
            Else

              outunits += dbNames.GetFriendlyUnitName(units.Item(i))
            End If
            'End If

          Next

          Dim mlittledeets5 As New ctrlModTinyDetailsLabel("Affects", outunits)
          curModText.wpnlModdetails.Children.Add(mlittledeets5)
        End If
      End If

      If Not infs.Target Is Nothing Then
        Dim targ = infs.Target
        Dim friendlyname As String = ""
        Select Case targ.EntityName
          Case eEntity.Hero_Instance
            Dim h As HeroInstance = DirectCast(targ, HeroInstance)
            friendlyname = h.DisplayName
          Case eEntity.Creep_Info
            Dim c As Creep_Info = DirectCast(targ, Creep_Info)
            friendlyname = c.mName.ToString
          Case Else
            theLog.Writelog("ctrlModDetails.LoadModText Targ.Type unhandled: " & targ.EntityName.ToString)
        End Select
        Dim littedeets6 As New ctrlModTinyDetailsLabel("Target", friendlyname)
        curModText.wpnlModdetails.Children.Add(littedeets6)

      End If
    Catch ex As Exception
      Dim x = 2
    End Try



    Try
      If Not vals.mRadius Is Nothing Then
        Dim rad = vals.mRadius.Value(mCurModLevel - 1)
        If rad.HasValue Then
          Dim littedeets17 As New ctrlModTinyDetailsLabel("Radius", rad)
          curModText.wpnlModdetails.Children.Add(littedeets17)
        End If
      End If

      If Not infs.Notes = "" Then
        Dim littledeets7 As New ctrlModTinyDetailsLabel("", infs.Notes)
        curModText.wpnlModdetails.Children.Add(littledeets7)
      End If
    Catch ex As Exception
      Dim x = 2
    End Try


#If Devmode Then

            Dim dd1 As New ctrlModTinyDetailsLabel("", themod.ModifierType.ToString())
            curModText.wpnlModdetails.Children.Add(dd1)

            Dim dd2 As New ctrlModTinyDetailsLabel("Start", themod.Lifetime.StartTimes.Item(0).count.ToString)
            curModText.wpnlModdetails.Children.Add(dd2)

            Dim dd3 As New ctrlModTinyDetailsLabel("End", themod.Lifetime.EndTime.count.ToString)
            curModText.wpnlModdetails.Children.Add(dd3)



#End If
    Try
      spnlModTexts.Children.Add(curModText)
      mCtrlModTexts.Add(curModText)
    Catch ex As Exception
      Dim x = 2
    End Try

  End Sub

  Private Sub LoadModTargets(themod As Modifier, thecurmodlevel As Integer, thecurrenttime As ddFrame, _
                              thegame As dGame)
    ' themod.mCurInGameTargets =
    If themod.TheModInfo.Parent.EntityName = eEntity.Hero_Instance Then

      Dim thetargs = Helpers.GetAffectedUnitsForMod(themod, thegame)
      targetthumbs = New List(Of ctrlHero_Thumb)
      tarurls = New List(Of String)
      tarcolors = New List(Of SolidColorBrush)
      tarcolors2 = New List(Of SolidColorBrush)

      For i As Integer = 0 To thetargs.Count - 1
        Dim hero = thetargs.Item(i)
        ' tarurls.Add(PageHandler.dbHeroBuilds.GetHeroBuild(curid).UnitImage)
        tarcolors.Add(New SolidColorBrush(PageHandler.dbColors.GetColor(hero)))
        Dim thmb As New ctrlHero_Thumb()

        thmb.LoadHero(hero, tarcolors.Item(i), ePrimaryStat.Agility)

        targetthumbs.Add(thmb)
        targetthumbs.Item(i).SetUnresponsive(35)

        'If thetargs.Count = 1 Then
        '  targetthumbs.Item(i).SwatchVisible(False)
        'Else
        '  targetthumbs.Item(i).SwatchVisible(True)
        'End If

        'Dim lblfu As New Label
        'lblfu.Content = "FUCK OFF " & i
        'lblfu.Background = dbColors.ErrorColor
        'spnlTargetPortrait.Children.Add(lblfu)
        spnlTargetPortrait.Children.Add(targetthumbs.Item(i))




#If Devmode Then
      Dim lbl2 As New ctrlBody_Paragraph()
      lbl2.LayoutRoot.Text = curid.FriendlyGuid
      spnlTargetPortrait.Children.Add(lbl2)
#End If
      Next

      If thetargs.Count > 1 Then
        Dim teamcount = 0
        Dim curteam As eTeamName
        For i As Integer = 0 To thetargs.Count - 1
          Dim theteam As eTeamName = mGame.GetTeamNameFromUnit(thetargs.Item(i))
          If Not theteam = curteam Then
            teamcount += 1
            curteam = theteam
          End If
        Next


        If teamcount = 1 Then
          Select Case curteam
            Case eTeamName.Radiant
              'rectBackground.Fill = PageHandler.dbColors.RadiantColor
              rectTargetSwatch.Fill = New SolidColorBrush(PageHandler.dbColors.RadiantAccentColor)
            Case eTeamName.Dire
              'rectBackground.Fill = PageHandler.dbColors.DireColor
              rectTargetSwatch.Fill = New SolidColorBrush(PageHandler.dbColors.DireAccentColor)
            Case Else
              PageHandler.theLog.Writelog("ctrlModDetails.LoadModText Team is not: " & curteam.ToString)
          End Select
        Else
          'rectBackground.Fill = PageHandler.dbColors.BackgroundColor
          rectTargetSwatch.Fill = New SolidColorBrush(PageHandler.dbColors.BackgroundColor)
        End If





      End If
      If thetargs.Count = 1 Then

        'rectBackground.Fill = New SolidColorBrush(Color.FromArgb(65, tarcolors.Item(0).Color.R, tarcolors.Item(0).Color.G, tarcolors.Item(0).Color.B))
        rectTargetSwatch.Fill = tarcolors.Item(0)
      End If

      If thetargs.Count = 0 Then
        ' rectBackground.Fill = PageHandler.dbColors.BackgroundColor
        rectTargetSwatch.Fill = New SolidColorBrush(PageHandler.dbColors.BackgroundColor)
      End If
    Else
      'source isn't a hero
      Dim x = 2
    End If

  End Sub
  Private Sub setformatvaluetype(thestat As Stat)
    mCurType = eStringFormatType.None

    Select Case thestat.StatType
      Case Else
        mCurType = eStringFormatType.ZeroDecimal
    End Select
  End Sub
  Private Sub SetFormatValueType(themod As Modifier)
    'Dim outval As Double
    'Dim ispercent As Boolean = False
    'Dim outstring As String

    mCurType = eStringFormatType.None

    Select Case themod.ModifierType

      'is a percentage
      Case eModifierType.AgiPercent, eModifierType.ArmorAddedPerSec, eModifierType.ArmorPercentage, _
        eModifierType.AttackSpeedPercentAdded, eModifierType.CleavePercentage, eModifierType.DamageMagicalPercent, _
        eModifierType.DamagePhysicalPercent, eModifierType.DamagePierceChancePercent, eModifierType.DamagePurePercent, _
        eModifierType.DamagetoHealPercent, eModifierType.EvasionPercent, eModifierType.HealAsPercentofHP, _
        eModifierType.HealPercent, eModifierType.HPPercent, eModifierType.HPRegenPercent, eModifierType.IntPercent, _
        eModifierType.LifeDrainPercent, eModifierType.LifeStealPercent, eModifierType.MagicResistancePercentAdded, _
        eModifierType.ManaPercent, eModifierType.ManaRegenPercent, eModifierType.ManaRestoredPercent, _
        eModifierType.MantaMeleeIllusionDamagePercentage, eModifierType.MantaRangeIllusionDamagePercentage, _
        eModifierType.MoveSpeedPercent, eModifierType.PrimaryStatLossPercent, eModifierType.DamageAmplification, _
        eModifierType.TurnRateSubtracted 'eModifierType.StrPercent,

        mCurType = eStringFormatType.Percent

        'outval = theval * 100
        'outval = Math.Round(outval, 2)
        'ispercent = True
      Case Else
        'outval = Math.Round(theval, 2)
        mCurType = eStringFormatType.TwoDecimal
    End Select

    'If outval > 0 Then
    '  outstring = "+" & outval.ToString
    'Else
    '  outstring = outval.ToString
    'End If

    'If ispercent Then
    '  outstring = outstring & "%"
    'End If

  End Sub

  Private Function FormatString(theval As Double?, thetype As eStringFormatType) As String

    If Not theval.HasValue Then
      Return ""
    End If

    Select Case thetype
      Case eStringFormatType.None
        Return theval.ToString


      Case eStringFormatType.Percent
        Dim outval As Double
        outval = theval * 100
        outval = Math.Round(outval, 2)
        If outval > 0 Then
          Return outval.ToString & "%"
        Else
          Return outval.ToString & "%"
        End If


      Case eStringFormatType.TwoDecimal
        Dim outval As Double
        Dim dec As Decimal = theval
        outval = Math.Round(dec, 2).ToString
        If outval > 0 Then
          Return outval.ToString
        Else
          Return outval.ToString
        End If
      Case eStringFormatType.ZeroDecimal
        Dim outval As Double
        Dim dec As Decimal = theval
        outval = Math.Round(dec, 0)

        Return outval.ToString
      Case Else
        Return theval.ToString
    End Select
  End Function
  Public Sub UpdateExistingMod(newtime As ddFrame)
    If mMods Is Nothing Then Exit Sub
    mCurTime = newtime
    Dim mcurval As Double?
    mVisibleMods = mCtrlModTexts.Count

    For i As Integer = 0 To mCtrlModTexts.Count - 1


      Dim mMod = mMods.Item(i)
      mcurval = mMod.Value(mCurTime)

      If mcurval.HasValue Then
        mCtrlModTexts.Item(i).Visibility = Windows.Visibility.Visible

        Dim mModtext = mCtrlModTexts.Item(i)
        Dim updatabletinydetails = mModtext.mUpdatableTinyDetails

        mModtext.UpdateValue(FormatString(mcurval, mCurType)) ' & " "

        Dim curlvl = mMod.GetLevelAtTime(newtime)

        If updatabletinydetails.ContainsKey("Duration") Then
          Dim dur As ctrlModTinyDetailsLabel = updatabletinydetails.Item("Duration")

          dur.UpdateExistingDetail("Duration", Helpers.GetFriendlyTimeSpan(mMod.TheModValue.mValueDuration.Value(curlvl - 1)))

        End If

        If updatabletinydetails.ContainsKey("persec") Then
          Dim per As ctrlModTinyDetailsLabel = updatabletinydetails("persec")
          mSecTimeSpan = Helpers.GetTimeSpanAsSeconds(TimeSpan.FromSeconds(mMod.TheModValue.mValueInterval.Value(curlvl - 1)))
          per.UpdateExistingDetail("", (mcurval / mSecTimeSpan).ToString & "/sec")
        End If
      Else
        mCtrlModTexts.Item(i).Visibility = Windows.Visibility.Collapsed
        mVisibleMods = mVisibleMods - 1
      End If

    Next
    If mVisibleMods = 0 Then
      Me.Visibility = Windows.Visibility.Collapsed
    Else
      Me.Visibility = Windows.Visibility.Visible
    End If
  End Sub
End Class
