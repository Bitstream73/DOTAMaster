Public Class Stat
  Implements iDataItem





  Private mID As dvID
  Private mGame As dGame
  Private mParent As iGameEntity
  Private mStatType As eStattype

  Private mFriendlyName As String

  Private curownerlvl As Integer
  Private gametimepoints As DDFrame_List
  Private modtypes As List(Of eModifierType)
  Private stattypes As List(Of eStattype)

  Private mStatCalc As StatCalc

  Private dbMods As Modifier_Database

  Private mValueFormat As eValueFormat
  Public Sub New(thestattype As eStattype, theowner As iGameEntity, thegame As dGame) ', friendlyname As String)


    mID = New dvID(Guid.NewGuid, "Stat.New with " & thestattype.ToString, eEntity.Stat)
    mStatType = thestattype
    mParent = theowner
    mGame = thegame
    dbMods = thegame.dbModifiers

    mStatCalc = New StatCalc(mStatType, mParent, mGame)
    mStatCalc.mIsDirty = True
  End Sub

#Region "Info"
  Public ReadOnly Property ValueFormat As eValueFormat
    Get
      If mValueFormat = Nothing Then
        mValueFormat = PageHandler.dbFriendlyNames.GetFriendlyValueFormat(Me.StatType)
      End If
      Return mValueFormat
    End Get
  End Property
  Public ReadOnly Property MyModsByType As Dictionary(Of eModifierType, ModifierList)
    Get
      Return mStatCalc.MyModsbytype
    End Get
  End Property

  Public ReadOnly Property MyStats As List(Of Stat)
    Get
      Return mStatCalc.MyStats
    End Get
  End Property

  Public Property IsDirty As Boolean
    Get
      Return mStatCalc.mIsDirty
    End Get
    Set(value As Boolean)
      mStatCalc.mIsDirty = value
    End Set
  End Property

  Public ReadOnly Property StatType As eStattype
    Get
      Return mStatType
    End Get
  End Property

  Public Property DisplayName As String Implements iGameEntity.DisplayName
    Get
      If mFriendlyName = "" Or mFriendlyName Is Nothing Then
        mFriendlyName = PageHandler.dbFriendlyNames.GetFriendlyStatName(mStatType)
      End If
      Return mFriendlyName
    End Get
    Set(value As String)

    End Set
  End Property

  Public Property EntityName As eEntity Implements iGameEntity.EntityName
    Get
      Return eEntity.Stat
    End Get
    Set(value As eEntity)

    End Set
  End Property

  Public Property Id As dvID Implements iGameEntity.Id
    Get
      Return mID
    End Get
    Set(value As dvID)

    End Set
  End Property

  Public Property MyType As eSourceType Implements iGameEntity.MyType
    Get
      Return eSourceType.Stat
    End Get
    Set(value As eSourceType)

    End Set
  End Property

  Public Property ParentGameEntity As iGameEntity Implements iGameEntity.ParentGameEntity
    Get
      Return mParent
    End Get
    Set(value As iGameEntity)

    End Set
  End Property

  Public Property ParentGameEntityType As eSourceType Implements iGameEntity.ParentGameEntityType
    Get
      Return mParent.MyType
    End Get
    Set(value As eSourceType)

    End Set
  End Property
#End Region

#Region "Gets"

  Public Function GetFriendlyFormula(time As ddFrame) As List(Of List(Of String))
    Return mStatCalc.GetFriendlyFormula(time)
  End Function
  Public Function Value(thetime As ddFrame) As Double? Implements iDataItem.Value
    If Me.IsDirty Then
      mStatCalc.Load()

    End If
    If thetime.count = 0 Then
      If StatType = eStattype.MovementSpeed Or _
        StatType = eStattype.AttackDamageHigh Or _
        StatType = eStattype.PhysicalArmor Then
        Dim x = 2
      End If

    End If

    If mStatCalc.Valuelist.ContainsKey(thetime) Then
      Return mStatCalc.Valuelist.Item(thetime)
    Else
      Return Nothing
    End If

  End Function

  Public Function ValueWithFormatting(thetime As ddFrame) As String Implements iDataItem.ValueWithFormatting
    Dim formattype = Me.ValueFormat
    Dim val = Me.Value(thetime)
    If Not val.HasValue Then Return ""
    Dim outval As Decimal = val

    Select Case formattype
      Case eValueFormat.DecimalNumber

        outval = Math.Round(outval, 2)
        Return outval.ToString

      Case eValueFormat.DurationInSeconds
        outval = Math.Round(outval, 2)
        Return outval.ToString & " sec's"

      Case eValueFormat.None
        Return outval.ToString

      Case eValueFormat.NotForDisplay
        Return ""

      Case eValueFormat.Percent
        outval = outval * 100
        Return outval & "%"

      Case eValueFormat.TrueFalse
        If val > 0 Then
          Return "True"
        Else
          Return "False"
        End If

      Case eValueFormat.ValuePerSecond
        outval = Math.Round(outval, 2)
        Return outval.ToString & "/sec"

      Case eValueFormat.WholeNumber
        outval = Math.Round(outval, System.MidpointRounding.AwayFromZero)
        Return outval.ToString

      Case Else
        Throw New NotImplementedException
    End Select
  End Function

  Property DataItemType As eDataItemType Implements iDataItem.DataItemType
    Get
      Return eDataItemType.Stat
    End Get
    Set(value As eDataItemType)

    End Set
  End Property

  Public Function GetValueList() As ValueList
    If Me.IsDirty Then
      mStatCalc.Load()
      'PageHandler.theLog.Writelog(Me.ToString)
    End If

    Return mStatCalc.Valuelist


  End Function

  Public Function GetPrimaryAttribute() As ePrimaryStat
    Select Case mParent.EntityName
      Case eEntity.Hero_Instance
        Dim hero As HeroInstance = DirectCast(mParent, HeroInstance)
        Return hero.GetHero.PrimaryStat
      Case eEntity.Creep_Info
        Dim creep As Creep_Info = DirectCast(mParent, Creep_Info)
        Return ePrimaryStat.None
      Case Else
        PageHandler.theLog.Writelog("Stat.Calcvalue passed unhandled mownerobj.type: " & mParent.ToString)
        Throw New NotImplementedException
    End Select
  End Function
  Private Function GetOwnerLevelAtTime(thetime As ddFrame) As Integer
    Select Case mParent.EntityName
      Case eEntity.Hero_Instance
        Dim hero = DirectCast(mParent, HeroInstance)
        Return hero.GetLevelForTime(thetime)
      Case eEntity.Creep_Info
        Dim creep = DirectCast(mParent, Creep_Info)
        Return creep.GetLevelForTime(thetime)
      Case Else
        PageHandler.theLog.Writelog("Stat.Calcvalue passed unhandled mownerobj.type: " & mParent.EntityName.ToString)
        Throw New NotImplementedException
    End Select

  End Function
#End Region


  Public Sub ReCalcStat()
    If Me.StatType = eStattype.HitPoints Then
      Dim x = 2
    End If
    mStatCalc.mIsDirty = True
    ' PageHandler.theLog.Writelog(Me.ToString & "Marked Dirty")
  End Sub


  Public Overrides Function ToString() As String
    ' Return Me.StatType.ToString

    Dim thetype = mStatType.ToString

    Dim theval = Me.Value(New ddFrame(0)).ToString

    Dim endframe = Me.mStatCalc.Valuelist.DateList.Item(Me.mStatCalc.Valuelist.DateList.Count - 1)
    Dim endval = Me.mStatCalc.Valuelist.Item(endframe)

    Return ParentGameEntity.Id.FriendlyGuid & ": Stattype." & thetype & " Start val(0): " & theval & " End val(" & endframe.count.ToString & "): " & endval
  End Function

  Public Sub calcmods() Implements iGameEntity.calcmods

  End Sub


  Public Property MyColor As Color Implements iGameEntity.MyColor
    Get
      Return PageHandler.dbColors.GetColor(Me.StatType)
    End Get
    Set(value As Color)

    End Set
  End Property

  Public Property DataGenerator As iGameEntity Implements iDataItem.DataGenerator
    Get
      Return Me.ParentGameEntity
    End Get
    Set(value As iGameEntity)

    End Set
  End Property

  Public Property MaxValue As Double? Implements iDataItem.MaxValue
    Get
      Return mStatCalc.MaxValue
    End Get
    Set(value As Double?)

    End Set
  End Property
End Class
