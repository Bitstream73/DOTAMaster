#Const DEVMODE = True
Public Class Modifier
  Implements iDataItem





  Private mIDItem As dvID
  Private mModValue As modValue
  Private mModInfo As modInfo

  Private mCategory As eModifierCategory

  Private mValueFormat As eValueFormat
  'Private mCurInGameTargets As List(Of dvID)


  Public Sub New(modval As modValue, modinf As modInfo)
    mModValue = modval
    mModInfo = modinf


    If modval.mModType = eModifierType.IntAdded Then
      Dim x = 2
    End If

    Dim thetype As String
    If mModValue Is Nothing Then
      thetype = "Nothing"
    Else
      thetype = mModValue.mModType.ToString

    End If

    mIDItem = New dvID(Guid.NewGuid, Helpers.GetFriendlyGuid(mModInfo.Parent.Id.GuidID) & mModInfo.Parent.MyType.ToString & ": " & " Modifier/New/" & thetype, eEntity.Modifier)

    mCategory = Category


  End Sub

  ''' <summary>
  ''' us attime = nothing for mods that don't contain a valuelist
  ''' </summary>
  ''' <param name="attime">TimeKeerper.Time for valuelist mods, Nothing for all others</param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function Value(attime As ddFrame) As Double? Implements iDataItem.Value
    Dim outvalue = mModValue.Value(attime)

    Return outvalue ', False)


    Return Nothing
  End Function

  Public Function ValueWithFormatting(atttime As ddFrame) As String Implements iDataItem.ValueWithFormatting
    Dim formattype = Me.ValueFormat
    Dim val = Me.Value(atttime)
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
      Return eDataItemType.Modifier
    End Get
    Set(value As eDataItemType)

    End Set
  End Property
  Public Function GetLevelAtTime(thetime As ddFrame) As Integer
    Return mModValue.GetLevelAtTime(thetime)
  End Function


  Public Sub calcmods() Implements iGameEntity.calcmods

  End Sub

#Region "Info"

  Public ReadOnly Property ValueFormat As eValueFormat
    Get
      If mValueFormat = Nothing Then
        mValueFormat = PageHandler.dbFriendlyNames.GetFriendlyValueFormat(Me.ModifierType)
      End If
      Return mValueFormat
    End Get
  End Property
  Public ReadOnly Property Target As iGameEntity
    Get
      Return mModInfo.Target
    End Get
  End Property
  Public ReadOnly Property ModifierType As eModifierType
    Get
      Return mModValue.mModType
    End Get
  End Property
  Public ReadOnly Property Category As eModifierCategory
    Get
      Return mCategory
    End Get
  End Property
  Public ReadOnly Property GuidID As Guid
    Get
      Return mIDItem.GuidID
    End Get
  End Property

  Public ReadOnly Property IDMetaData As String
    Get
      Return mIDItem.ToString
    End Get
  End Property

  Public ReadOnly Property IDItem As dvID
    Get
      Return mIDItem
    End Get
  End Property

  Public ReadOnly Property Type As eModifierType
    Get
      Return mModValue.mModType
    End Get
  End Property

  Public ReadOnly Property Parent As iGameEntity
    Get
      Return mModInfo.Parent
    End Get
  End Property

  Public ReadOnly Property AffectedUnitTypes() As List(Of eUnit)
    Get
      If mModInfo.AffectedUnitTypes Is Nothing Then
        Dim x = 2
      End If
      Return mModInfo.AffectedUnitTypes
    End Get
  End Property

  Public Property TheModValue As modValue
    Get
      Return mModValue
    End Get
    Set(value As modValue)
      If Not mModValue Is value Then
        mModValue = value
        mIDItem.AppendMetaData(Helpers.GetFriendlyGuid(mModInfo.Parent.Id.GuidID) & mModInfo.Parent.MyType.ToString & ": " & " Modifier/TheModValue/Set/" & mModValue.mModType.ToString)

      End If


    End Set
  End Property

  Public ReadOnly Property TheModInfo As modInfo
    Get
      Return mModInfo
    End Get
  End Property




  Public ReadOnly Property Notes() As String
    Get
      Return mModInfo.Notes
    End Get
  End Property

  Public ReadOnly Property ModGenerator As iGameEntity
    Get
      Return mModInfo.ModGenerator
    End Get
  End Property

  Public ReadOnly Property Lifetime As Lifetime
    Get
      Return mModValue._LifeTime
    End Get
  End Property

  Public Property DisplayName As String Implements iGameEntity.DisplayName
    Get
      Return PageHandler.dbFriendlyNames.GetFriendlyModifierName(Me.ModifierType)
    End Get
    Set(value As String)

    End Set
  End Property

  Public Property EntityName As eEntity Implements iGameEntity.EntityName
    Get
      Return eEntity.Modifier
    End Get
    Set(value As eEntity)

    End Set
  End Property

  Public Property Id As dvID Implements iGameEntity.Id
    Get
      Return mIDItem
    End Get
    Set(value As dvID)

    End Set
  End Property

  Public Property MyType As eSourceType Implements iGameEntity.MyType
    Get
      Return eSourceType.Modifier
    End Get
    Set(value As eSourceType)

    End Set
  End Property

  Public Property ParentGameEntity As iGameEntity Implements iGameEntity.ParentGameEntity
    Get
      Return Me.ModGenerator
    End Get
    Set(value As iGameEntity)

    End Set
  End Property

  Public Property ParentGameEntityType As eSourceType Implements iGameEntity.ParentGameEntityType
    Get
      Return mModInfo.Parent.MyType
    End Get
    Set(value As eSourceType)

    End Set
  End Property

#End Region


  Public Overrides Function ToString() As String

    Dim thetype = mModValue.mModType.ToString

    Dim theval = Me.Value(New ddFrame(0)).ToString
    Return Parent.Id.FriendlyGuid & ": Modtype." & thetype & " Start val: " & theval
  End Function




  Public Property MyColor As Color Implements iGameEntity.MyColor
    Get
      Return PageHandler.dbColors.GetColor(Me.ModifierType)
    End Get
    Set(value As Color)

    End Set
  End Property

  Public Property DataGenerator As iGameEntity Implements iDataItem.DataGenerator
    Get
      Return mModInfo.ModGenerator
    End Get
    Set(value As iGameEntity)

    End Set
  End Property

  Public Property MaxValue As Double? Implements iDataItem.MaxValue
    Get
      Return mModValue.MaxValue
    End Get
    Set(value As Double?)

    End Set
  End Property
End Class
