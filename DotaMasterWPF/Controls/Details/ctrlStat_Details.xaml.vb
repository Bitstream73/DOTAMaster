Public Class ctrlStat_Details
  Implements iDetails, iGameEntity, iGraphable



  Private mID As dvID
  Private mGame As dGame
  Private mMyStat As Stat
  Private dbControls As Controls_Database
  Private mcurtime As ddFrame

  Private mSelectedGraphable As iGraphable
  'Private mMods As New List(Of ctrlSwatchModifierLabel)
  'Private mStats As New List(Of ctrlSwatchAttributeLabel)

  Public Event GraphableSelected(sender As iGraphable) Implements iGraphable.GraphableSelected


  Private mTitle As String
  Public Sub New(thestat As Stat, _
                 controlsdb As Controls_Database, game As dGame)

    InitializeComponent()

    Me.mID = New dvID(Guid.NewGuid, "ctrlStat_Details", eEntity.ctrlStat_Details)
    mMyStat = thestat

    mGame = game
    mcurtime = mGame.TimeKeeper.CurrentTime
    dbControls = controlsdb

    mTitle = thestat.ParentGameEntity.DisplayName & "'s " & thestat.DisplayName & " at "
    lblTitle._Content = mTitle & Helpers.GetFriendlyTime(mcurtime)
    lblComponents._Content = "Components"

    Dim dataitems As New List(Of iDataItem)

    dataitems.AddRange(mMyStat.MyStats)

    For Each modlist In mMyStat.MyModsByType
      dataitems.AddRange(modlist.Value)
    Next

    dviewDataItems.LoadMe(dataitems, 1, dbControls, mGame)
    AddHandler dviewDataItems.GraphableSelected, AddressOf ChildControl_GraphableSelected


  End Sub


  Public Sub UpdateTime(curtime As ddFrame) Implements iDetails.UpdateTime
    lblTitle._Content = mTitle & Helpers.GetFriendlyTime(curtime)

    dviewDataItems.UpdateTime(curtime)

  End Sub

  Public Sub calcmods() Implements iGameEntity.calcmods

  End Sub

  Public Property DisplayName As String Implements iGameEntity.DisplayName
    Get
      Return "ctrlStat_Details"
    End Get
    Set(value As String)

    End Set
  End Property

  Public Property EntityName As eEntity Implements iGameEntity.EntityName
    Get
      Return eEntity.ctrlStat_Details
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
      Return mMyStat
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


  Public Sub SetGraphed(isgraphed As Boolean) Implements iGraphable.SetGraphed
    If Not mSelectedGraphable Is Nothing Then
      mSelectedGraphable.SetGraphed(isgraphed)
    End If
  End Sub

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

  Private Sub ChildControl_GraphableSelected(sender As iGraphable)
    mSelectedGraphable = sender
    RaiseEvent GraphableSelected(mSelectedGraphable)
  End Sub

End Class
