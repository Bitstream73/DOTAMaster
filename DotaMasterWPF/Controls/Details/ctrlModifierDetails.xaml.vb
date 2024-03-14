Public Class ctrlModifierDetails
  Implements iDetails, iGameEntity, iGraphable



  Private mID As dvID
  Private mMyMod As Modifier
  Private mGame As dGame
  Private dbControls As Controls_Database
  Private mcurtime As ddFrame
  Private mTitle As String
  Private mModCtrl As ctrlSwatchDataItemLabel
  Public Sub New(themod As Modifier, _
                  controlsdb As Controls_Database, game As dGame)
    InitializeComponent()

    mMyMod = themod
    Me.mID = New dvID(Guid.NewGuid, "ctrlModifierDetails", eEntity.ctrlModifier_Details)

    mGame = game
    mcurtime = mGame.TimeKeeper.CurrentTime
    dbControls = controlsdb


    SetTitle()

    lblTitle._Content = mTitle & Helpers.GetFriendlyTime(mcurtime)

    LoadMod()
  End Sub


  Private Sub SetTitle()
    Dim parent = mMyMod.Parent.DisplayName
    Dim source = mMyMod.ModGenerator.DisplayName

    If parent = source Then
      mTitle = mMyMod.Parent.DisplayName & "'s " & mMyMod.DisplayName & " at "

    Else
      mTitle = mMyMod.Parent.DisplayName & "'s " & mMyMod.ModGenerator.DisplayName & " " & _
        PageHandler.dbFriendlyNames.GetFriendlySourceName(mMyMod.ModGenerator.MyType) _
        & "'s " & mMyMod.DisplayName & " at "

    End If
  End Sub
  Private Sub LoadMod()


    mModCtrl = dbControls.GetctrlSwatchDataItemLabel(mcurtime, _
                                               mMyMod, mMyMod.DisplayName, "")



    spnlMod.Children.Add(mModCtrl)



  End Sub





  Public Sub UpdateTime(curtime As ddFrame) Implements iDetails.UpdateTime
    lblTitle.Content = mTitle & Helpers.GetFriendlyTime(mGame.TimeKeeper.CurrentTime)

    mModCtrl.UpdateValue(curtime)
  End Sub

  Public Sub calcmods() Implements iGameEntity.calcmods

  End Sub

  Public Property DisplayName As String Implements iGameEntity.DisplayName
    Get
      Return "ctrlModifier_Details"
    End Get
    Set(value As String)

    End Set
  End Property

  Public Property EntityName As eEntity Implements iGameEntity.EntityName
    Get
      Return eEntity.ctrlModifier_Details
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
      Return mMyMod
    End Get
    Set(value As iGameEntity)

    End Set
  End Property

  Public Event GraphableSelected(sender As iGraphable) Implements iGraphable.GraphableSelected

  Public Property GraphDataItems As List(Of List(Of iDataItem)) Implements iGraphable.GraphDataItems

  Public Property GraphPreferences As Graph_Preferences Implements iGraphable.GraphPreferences

  Public Sub SetGraphed(isgraphed As Boolean) Implements iGraphable.SetGraphed

  End Sub
End Class
