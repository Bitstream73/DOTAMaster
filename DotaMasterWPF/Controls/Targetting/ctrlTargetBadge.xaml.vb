Public Class ctrlTargetBadge
  'Private mbiasisfriend As Boolean 'false = enemy
  Private colorSelected = New SolidColorBrush(Color.FromArgb(255, 129, 129, 129))
  Private colorNotSelected = New SolidColorBrush(Color.FromArgb(0, 0, 0, 0))

  Private mEnemyTarget As ctrlTarget_Menu_Item
  Private mFriendTarget As ctrlTarget_Menu_Item
  Private mTargetFriendBias As Boolean

  Event NewTargetSelected(thectrl As ctrlTargetBadge)

  Private mMyTeamName As eTeamName

  Private mMyTeam As dTeam
  Private mMyTeamMenuItems As List(Of ctrlTarget_Menu_Item)

  Private mEnemyTeam As dTeam
  Private mEnemyTeamMenuItems As List(Of ctrlTarget_Menu_Item)


  Private mHeadingTextBrush As SolidColorBrush
  Private mBodyTextBrush As SolidColorBrush
  Public Sub New()
    InitializeComponent()

    AddHandler lblEnemyBias.MouseLeftButtonDown, AddressOf Bias_LeftMouseButtonDown
    AddHandler lblFriendlyBias.MouseLeftButtonDown, AddressOf Bias_LeftMouseButtonDown


    lblEnemyBias.Background = colorSelected
  End Sub

  Public Property EnemyTarget As iHeroUnit
    Get
      Return mEnemyTarget.Hero
    End Get
    Set(value As iHeroUnit)

    End Set
  End Property

  Public Property FriendlyTarget As iHeroUnit
    Get
      Return mFriendTarget.Hero
    End Get
    Set(value As iHeroUnit)

    End Set
  End Property

  Public Property Bias As Boolean
    Get
      Return mTargetFriendBias
    End Get
    Set(value As Boolean)

    End Set
  End Property

  Public Property Team As dTeam
    Get
      Return mMyTeam
    End Get
    Set(value As dTeam)

    End Set
  End Property

  Public Sub Load(myteam As dTeam, enemyteam As dTeam, _
                  headingtextbrush As SolidColorBrush, bodytextbrush As SolidColorBrush)


    mMyTeam = myteam

    mHeadingTextBrush = headingtextbrush
    mBodyTextBrush = bodytextbrush

    lblEnemy.Foreground = mBodyTextBrush
    lblFriend.Foreground = mBodyTextBrush
    lblBias.Foreground = mBodyTextBrush

    mEnemyTeam = enemyteam
    mMyTeam = myteam




  End Sub

  Private Sub FillDropdowns()
    mMyTeamMenuItems = New List(Of ctrlTarget_Menu_Item)
    For i As Integer = 0 To mMyTeam.GetHeroInstances.Count - 1
      Dim newctrl As New ctrlTarget_Menu_Item(mMyTeam.GetHeroInstances.Item(i))

      mMyTeamMenuItems.Add(newctrl)
    Next
    cmbFriendlyTarget.ItemsSource = Nothing
    cmbFriendlyTarget.ItemsSource = mMyTeamMenuItems



    mEnemyTeamMenuItems = New List(Of ctrlTarget_Menu_Item)
    For i As Integer = 0 To mEnemyTeam.GetHeroInstances.Count - 1

      Dim newctrl As New ctrlTarget_Menu_Item(mEnemyTeam.GetHeroInstances.Item(i))

      mEnemyTeamMenuItems.Add(newctrl)
    Next
    cmbEnemyTarget.ItemsSource = Nothing
    cmbEnemyTarget.ItemsSource = mEnemyTeamMenuItems
  End Sub
  ''' <summary>
  ''' called when we are receiving new targets, so no raiseevent TargetsChanged
  ''' </summary>
  ''' <remarks></remarks>
  Public Sub UpdateTargets(selectedenemyTarget As iGameEntity, selectedfrindlytarget As iGameEntity, friendbias As Boolean)


    RemoveHandler cmbEnemyTarget.SelectionChanged, AddressOf Me_SelectionChanged
    RemoveHandler cmbFriendlyTarget.SelectionChanged, AddressOf Me_SelectionChanged

    FillDropdowns()

    For i = 0 To cmbFriendlyTarget.Items.Count - 1
      Dim curitem As ctrlTarget_Menu_Item = cmbFriendlyTarget.Items.Item(i)

      If curitem.Hero.Id.GuidID = selectedfrindlytarget.Id.GuidID Then
        cmbFriendlyTarget.SelectedItem = curitem
        mFriendTarget = curitem
      End If
    Next



    For i = 0 To cmbEnemyTarget.Items.Count - 1
      Dim curitem As ctrlTarget_Menu_Item = cmbEnemyTarget.Items.Item(i)

      If curitem.Hero.Id.GuidID = selectedenemyTarget.Id.GuidID Then
        cmbEnemyTarget.SelectedItem = curitem
        mEnemyTarget = curitem
      End If

    Next


    SetSelectedBias(friendbias)

    AddHandler cmbEnemyTarget.SelectionChanged, AddressOf Me_SelectionChanged
    AddHandler cmbFriendlyTarget.SelectionChanged, AddressOf Me_SelectionChanged
  End Sub

  Private Sub Bias_LeftMouseButtonDown(sender As Object, e As MouseButtonEventArgs)
    Dim thelabel As Label = sender
    Select Case thelabel.Content.ToString.Trim
      Case "Friend"
        SetSelectedBias(True)

      Case "Enemy"
        SetSelectedBias(False)

      Case Else
        Dim x = 2
    End Select

    RaiseEvent NewTargetSelected(Me)
  End Sub


  Private Sub SetSelectedBias(isfriendly As Boolean) 'false = enemy
    If isfriendly = mTargetFriendBias Then Exit Sub
    mTargetFriendBias = isfriendly

    lblEnemyBias.Background = colorNotSelected
    lblFriendlyBias.Background = colorNotSelected


    'Dim swatchgrid As GridLength
    'Dim valgrid As GridLength

    Select Case mTargetFriendBias
      Case True
        'swatchgrid = New GridLength(1, GridUnitType.Star)
        'valgrid = New GridLength(0)
        lblFriendlyBias.Background = colorSelected

      Case False
        'swatchgrid = New GridLength(0)
        'valgrid = New GridLength(1, GridUnitType.Star)
        lblEnemyBias.Background = colorSelected

      Case Else
        Dim x = 2
    End Select


  End Sub


  Private Sub Me_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
    Dim enemyitem As ctrlTarget_Menu_Item = cmbEnemyTarget.SelectedItem
    If enemyitem Is Nothing Then
      cmbEnemyTarget.SelectedIndex = 0
      enemyitem = cmbEnemyTarget.SelectedItem
    End If
    mEnemyTarget = enemyitem


    Dim frienditem As ctrlTarget_Menu_Item = cmbFriendlyTarget.SelectedItem
    If frienditem Is Nothing Then
      cmbFriendlyTarget.SelectedIndex = 0
      frienditem = cmbEnemyTarget.SelectedItem
    End If
    mFriendTarget = frienditem



    RaiseEvent NewTargetSelected(Me)
  End Sub

  'Private Sub Object_TargetsChanged( gameentity as igameentity)
  '  UpdateTargets(mGame, mMyTeamName)
  'End Sub
End Class
