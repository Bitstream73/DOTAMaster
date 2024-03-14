Public Class ctrlDetailsHandler
  Implements iDetails, iGraphable



  Private mGame As dGame
  Private dbControls As Controls_Database
  Private mDetailsPages As New Dictionary(Of iGameEntity, iDetails)

  Private mCurrentlySelectedDetailsPage As iDetails

  Private mSelectedGraphable As iGraphable

  Public Event GraphableSelected(sender As iGraphable) Implements iGraphable.GraphableSelected

  Public Sub New(game As dGame, controlsdb As Controls_Database)
    InitializeComponent()

    mGame = game
    dbControls = controlsdb
  End Sub

  Public Sub AddDetails(detailsitem As iGameEntity)

    LayoutRoot.Children.Clear()
    'need to add functionality to save pages as idetails and then directcast them back to it's ctrl
    'If mDetailsPages.ContainsKey(detailsitem) Then

    '  LayoutRoot.Children.Add(mDetailsPages.Item(detailsitem))
    'End If


    Dim detailsitemtype As eSourceType = detailsitem.MyType
    Dim gameent = detailsitem
    If detailsitemtype = eSourceType.Control Then
      gameent = GetGameEntityFromControl(detailsitem)
    End If

    Select Case gameent.MyType

      Case eSourceType.Control

      Case eSourceType.GameEntity_Tuple
        AddTuple(gameent)

      Case eSourceType.Team
        Dim team As dTeam = gameent
        Dim teamdetails As New ctrlTeam_Details(mGame.TimeKeeper.CurrentTime, team, dbControls, mGame)
        AddHandler teamdetails.GraphableSelected, AddressOf ChildControl_GraphableSelected
        Me.LayoutRoot.Children.Add(teamdetails)
        mCurrentlySelectedDetailsPage = DirectCast(teamdetails, iDetails)

      Case eSourceType.Hero_Instance
        Dim hero As HeroInstance = gameent
        Dim herodetails As New ctrlHero_Details(mGame.TimeKeeper.CurrentTime, gameent, dbControls, mGame)
        AddHandler herodetails.GraphableSelected, AddressOf ChildControl_GraphableSelected
        Me.LayoutRoot.Children.Add(herodetails)
        mCurrentlySelectedDetailsPage = DirectCast(herodetails, iDetails)

      Case eSourceType.Item_Info
        Dim item As Item_Info = gameent
        Dim itemdetails As New ctrlItem_Details(mGame.TimeKeeper.CurrentTime, item, dbControls, mGame)
        AddHandler itemdetails.GraphableSelected, AddressOf ChildControl_GraphableSelected
        Me.LayoutRoot.Children.Add(itemdetails)
        mCurrentlySelectedDetailsPage = DirectCast(itemdetails, iDetails)

      Case eSourceType.Ability_Info
        Dim ability As Ability_Info = gameent
        Dim abilitydetails As New ctrlAbility_Details(mGame.TimeKeeper.CurrentTime, ability, dbControls, mGame)
        AddHandler abilitydetails.GraphableSelected, AddressOf ChildControl_GraphableSelected
        Me.LayoutRoot.Children.Add(abilitydetails)
        mCurrentlySelectedDetailsPage = DirectCast(abilitydetails, iDetails)

      Case eSourceType.Modifier
        '        Dim themod As Modifier = gameent
        Dim modifier As Modifier = gameent
        Dim moddetails As New ctrlModifierDetails(modifier, dbControls, mGame)
        AddHandler moddetails.GraphableSelected, AddressOf ChildControl_GraphableSelected
        Me.LayoutRoot.Children.Add(moddetails)
        mCurrentlySelectedDetailsPage = DirectCast(moddetails, iDetails)

      Case eSourceType.Stat
        Dim statdetails As New ctrlStat_Details(gameent, dbControls, mGame)
        AddHandler statdetails.GraphableSelected, AddressOf ChildControl_GraphableSelected
        Me.LayoutRoot.Children.Add(statdetails)
        mCurrentlySelectedDetailsPage = DirectCast(statdetails, iDetails)

      Case Else
        Throw New NotImplementedException

    End Select
    If mCurrentlySelectedDetailsPage Is Nothing Then
      Dim x = 2
    End If
  End Sub

  Private Function GetGameEntityFromControl(control As iGameEntity) As iGameEntity
    Select Case control.EntityName
      Case eEntity.ctrlAbilityThumb
        Dim abctrl As ctrlAblityThumb = control

        Return abctrl.MyAbility

      Case eEntity.ctrlHero_Badge
        Dim heroctrl As ctrlHero_Badge = control
        Return heroctrl.mHeroInstState

      Case eEntity.ctrlItem_Thumb
        Dim itemctrl As ctrlItem_Thumb = control
        Return itemctrl.MyItem

      Case eEntity.ctrlIconStatLabel
        Dim statctrl As ctrlIconStatLabel = control
        Return statctrl.mStat

      Case Else
        Throw New NotImplementedException

    End Select
  End Function
  Private Sub AddTuple(thetuple As GameEntity_Tuple)
    Select Case thetuple.ItemOne.MyType
      Case eSourceType.Hero_Instance
        Dim hero1 As HeroInstance = thetuple.ItemOne

        Dim hero2 As HeroInstance = thetuple.ItemTwo

        Dim hvh As New ctrlHerovHeroDetails(mGame.TimeKeeper.CurrentTime, hero1, hero2, dbControls, mGame)
        AddHandler hvh.GraphableSelected, AddressOf ChildControl_GraphableSelected
        LayoutRoot.Children.Add(hvh)
        mCurrentlySelectedDetailsPage = DirectCast(hvh, iDetails)

      Case eSourceType.Team
        Dim team1 As dTeam = thetuple.ItemOne

        Dim team2 As dTeam = thetuple.ItemTwo

        Dim tvt As New ctrlTeamvTeamDetails(mGame.TimeKeeper.CurrentTime, team1, team2, dbControls, mGame)
        AddHandler tvt.GraphableSelected, AddressOf ChildControl_GraphableSelected
        LayoutRoot.Children.Add(tvt)
        mCurrentlySelectedDetailsPage = DirectCast(tvt, iDetails)
      Case Else
        Throw New NotImplementedException

    End Select

  End Sub

  Public Sub UpdateTime(curtime As ddFrame) Implements iDetails.UpdateTime
    If Not mCurrentlySelectedDetailsPage Is Nothing Then
      mCurrentlySelectedDetailsPage.UpdateTime(curtime)
    End If

  End Sub

  Public Property MyDetailsGameEntity As iGameEntity Implements iDetails.MyDetailsGameEntity
    Get
      Return mCurrentlySelectedDetailsPage.MyDetailsGameEntity
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
