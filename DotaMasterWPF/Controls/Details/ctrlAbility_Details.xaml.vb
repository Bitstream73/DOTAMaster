Public Class ctrlAbility_Details
  Implements iDetails, iGameEntity, iGraphable



  Private mID As dvID
  Private mAbility As Ability_Info
  Private mGame As dGame
  Private dbControls As Controls_Database
  Private mCurtime As ddFrame

  Private mMods As New List(Of ctrlSwatchDataItemLabel)

  Private mTitle As String

  Private mSelectedGraphable As iGraphable

  Public Event GraphableSelected(sender As iGraphable) Implements iGraphable.GraphableSelected


  Public Sub New(curtime As ddFrame, _
                 ability As Ability_Info, _
                 controlsdb As Controls_Database, game As dGame)
    InitializeComponent()

    Me.mID = New dvID(Guid.NewGuid, "ctrlAbility_Details|New", eEntity.ctrlAbility_Details)

    mAbility = ability
    mGame = game
    mCurtime = curtime
    dbControls = controlsdb

    mTitle = mAbility.ParentGameEntity.DisplayName & "'s " & mAbility.DisplayName & " Ability at "
    lblTitle._Content = mTitle & Helpers.GetFriendlyTime(mCurtime)

    lblComponentsTitle._Content = "Components"

    LoadMods()

  End Sub


  Private Sub LoadMods()

    Dim ownersteam = mGame.GetTeamFromGameEntity(mAbility.ParentGameEntity)

    Dim mods = mGame.dbModifiers.GetModsBySource(mAbility)

    Dim dataitems As New List(Of iDataItem)
    dataitems.AddRange(mods)

    dviewDataItems.LoadMe(dataitems, 1, dbControls, mGame)
    AddHandler dviewDataItems.GraphableSelected, AddressOf ChildControl_GraphableSelected

    'For i = 0 To mods.Count - 1
    '  Dim curmod = mods.Item(i)

    '  Dim targets = Helpers.GetAffectedUnitsForMod(curmod, mGame)

    '  Dim isoffense = False
    '  For x = 0 To targets.Count - 1
    '    If Not ownersteam.ContainsUnit(targets.Item(x)) Then
    '      isoffense = True
    '      Exit For
    '    End If
    '  Next

    '  If isoffense Then
    '    AddModifierOffenseLabel(curmod, curmod.DisplayName, "", 2)
    '  Else
    '    AddModifierDefenseLabel(curmod, curmod.DisplayName, "", 2)
    '  End If

    'Next


  End Sub
  'Private Sub AddModifierOffenseLabel(themod As Modifier, _
  '                    prefix As String, suffix As String, _
  '                    decimalplaces As Integer)
  '  Dim ctrl = dbControls.GetctrlSwatchModifierLabel(mcurtime, _
  '                                             themod, _
  '                                             prefix, suffix, _
  '                                             decimalplaces)

  '  mMods.Add(ctrl)

  '  spnlOffense.Children.Add(ctrl)
  'End Sub

  'Private Sub AddModifierDefenseLabel(themod As Modifier, _
  '                      prefix As String, suffix As String, _
  '                      decimalplaces As Integer)
  '  Dim ctrl = dbControls.GetctrlSwatchModifierLabel(mcurtime, _
  '                                             themod, _
  '                                             prefix, suffix, _
  '                                             decimalplaces)

  '  mMods.Add(ctrl)

  '  spnlDefense.Children.Add(ctrl)
  'End Sub
  Public Property Ability As Ability_Info
    Get
      Return mAbility
    End Get
    Set(value As Ability_Info)

    End Set
  End Property

  Public Sub UpdateTime(curtime As ddFrame) Implements iDetails.UpdateTime
    lblTitle._Content = mTitle & Helpers.GetFriendlyTime(curtime)


    dviewDataItems.UpdateTime(curtime)
  End Sub

  Public Sub calcmods() Implements iGameEntity.calcmods

  End Sub

  Public Property DisplayName As String Implements iGameEntity.DisplayName
    Get
      Return "ctrlAbility_Details"
    End Get
    Set(value As String)

    End Set
  End Property

  Public Property EntityName As eEntity Implements iGameEntity.EntityName
    Get
      Return eEntity.ctrlAbility_Details
    End Get
    Set(value As eEntity)

    End Set
  End Property

  Public Property Id As dvID Implements iGameEntity.Id
    Get
      Return Me.mID
    End Get
    Set(value As dvID)

    End Set
  End Property
  Public Property MyColor As Color Implements iGameEntity.MyColor
    Get
      Return PageHandler.dbColors.ErrorColor
    End Get
    Set(value As Color)

    End Set
  End Property

  Public Property MyType As eSourceType Implements iGameEntity.MyType
    Get
      Return eSourceType.Control
    End Get
    Set(value As eSourceType)

    End Set
  End Property

  Public Property ParentGameEntity As iGameEntity Implements iGameEntity.ParentGameEntity
    Get
      Return Nothing
    End Get
    Set(value As iGameEntity)

    End Set
  End Property

  Public Property ParentGameEntityType As eSourceType Implements iGameEntity.ParentGameEntityType
    Get
      Return Nothing
    End Get
    Set(value As eSourceType)

    End Set
  End Property

  Public Property MyDetailsGameEntity As iGameEntity Implements iDetails.MyDetailsGameEntity
    Get
      Return mAbility
    End Get
    Set(value As iGameEntity)

    End Set
  End Property


  Public Property GraphDataItems As List(Of List(Of iDataItem)) Implements iGraphable.GraphDataItems
    Get
      If Not mSelectedGraphable Is Nothing Then
        Return mSelectedGraphable.GraphDataItems
      End If
      Return Nothing
    End Get
    Set(value As List(Of List(Of iDataItem)))

    End Set
  End Property

  Public Property GraphPreferences As Graph_Preferences Implements iGraphable.GraphPreferences
    Get
      If Not mSelectedGraphable Is Nothing Then
        Return mSelectedGraphable.GraphPreferences
      End If
      Return Nothing
    End Get
    Set(value As Graph_Preferences)

    End Set
  End Property

  Public Sub SetGraphed(isgraphed As Boolean) Implements iGraphable.SetGraphed
    If Not mSelectedGraphable Is Nothing Then
      mSelectedGraphable.SetGraphed(isgraphed)
    End If
  End Sub

  Private Sub ChildControl_GraphableSelected(sender As iGraphable)
    mSelectedGraphable = sender
    RaiseEvent GraphableSelected(mSelectedGraphable)
  End Sub

End Class
