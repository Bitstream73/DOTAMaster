#Const DEVMODE = True
Imports System.Windows.Media.Imaging
Public Class ctrlAblityThumb
  Implements iControlIO, iGameEntity



  Private mAbility As Ability_Info
  Private mID As dvID
  Private mGame As dGame
  Public mTooltip As ToolTip
  Public misSelected As Boolean

  Private mColor As Color
  Public misResponsive As Boolean = True

  Public mFriendlyName As String

  Public Event isDirty(gameentity As iGameEntity) Implements iControlIO.isDirty

  Public Event SelectedChanged(gameentity As iGameEntity) Implements iControlIO.SelectedChanged
  Public Sub New()
    InitializeComponent()
    mID = New dvID(Guid.NewGuid, "ctrlAbilityThumb/New", eEntity.ctrlAbilityThumb)

  End Sub

  Public Sub calcmods() Implements iGameEntity.calcmods

  End Sub

  Public Sub SetUnresponsive(height As Double)
    rectSelected.Fill = Nothing
    Dim oldwidth = LayoutRoot.Width - colSwatch.Width.Value
    Dim oldheight = LayoutRoot.Height
    LayoutRoot.Width = ((height * oldwidth) / oldheight) + colSwatch.Width.Value
    LayoutRoot.Height = height

    rectInactive.Visibility = Windows.Visibility.Collapsed
    misResponsive = False
  End Sub

  Public Sub HideCurrentLevel()
    lblAbilityLevel.Visibility = Windows.Visibility.Collapsed
    rectAbilityLevel.Visibility = Windows.Visibility.Collapsed
  End Sub
  Public Sub LoadNewAbility(theability As Ability_Info, thegame As dGame, friendlyname As String)
    mFriendlyName = friendlyname
    mGame = thegame

    mAbility = theability



    If Not mAbility Is Nothing Then
      Dim parent = mAbility.ParentGameEntity
      mAbility.SetTargets(thegame.GetEnemyTarget(parent), thegame.GetFriendlyTarget(parent), thegame.GetFriendBias(parent))
      mAbility.LoadStates(mGame.dbAbilities.GetItemStateAndUrls(mAbility.AbilityName))

      mColor = PageHandler.dbColors.GetColor(mAbility.AbilityName)
      If Not mAbility.States Is Nothing Then

        If mAbility.States.Count > 1 Then

          Dim dbcolors = PageHandler.dbColors
          'btnState.LoadButton(mAbility.States, _
          '                    New SolidColorBrush(dbcolors.ButtonColorSelected), New SolidColorBrush(dbcolors.ButtonColorNotSelected), _
          '                    New SolidColorBrush(dbcolors.HeadingTextColor), Constants.cMinBtnTextSize, Constants.cMinbtnHeight, Constants.cMinBtnMargin)

          'SetBtnStateVisibility(True)
          'btnState.SetState(mAbility.CurrentStateIndex)
        Else
          'SetBtnStateVisibility(False)
          mAbility.CurrentStateIndex = -1 'default for stateless objects
        End If

      Else
        ' SetBtnStateVisibility(False)
        mAbility.CurrentStateIndex = -1 'default for stateless objects
      End If



      Dim ablvl = mAbility.CurrentLevel

      mTooltip = New ToolTip()
      Dim thick As New Thickness(0)
      mTooltip.BorderThickness = thick
      ToolTipService.SetToolTip(Me, mTooltip)

      Dim ctrlTT As New ctrlAbility_Tooltipe(mAbility, ablvl, mFriendlyName)
      mTooltip.Content = ctrlTT


      Me.thumbImage.Source = PageHandler.dbImages.GetAbilityImage(mAbility.AbilityName)

      Me.lblAbilityLevel.Content = ablvl.ToString

      Me.swatch.Fill = New SolidColorBrush(Me.MyColor
                                           )


      If ablvl = 0 Then
        rectInactive.Visibility = Windows.Visibility.Visible
      Else
        rectInactive.Visibility = Windows.Visibility.Collapsed
      End If


      FormatMe()
    Else
      Me.lblAbilityLevel.Visibility = Windows.Visibility.Collapsed
      Me.thumbImage.Source = Nothing
    End If

    SetSelected(False)

    AddHandler thumbImage.MouseLeftButtonDown, AddressOf Me_MouseLeftButtonDown
    AddHandler rectInactive.MouseLeftButtonDown, AddressOf Me_MouseLeftButtonDown
    AddHandler mGame.TargetsChanged, AddressOf Object_TargetsChanged
  End Sub

  'Private Sub SetBtnStateVisibility(isvisible As Boolean)
  '  If isvisible Then
  '    AddHandler btnState.Click, AddressOf btnState_Click
  '    btnState.Foreground = New SolidColorBrush(PageHandler.dbColors.HeadingTextColor)
  '    btnState.Visibility = Windows.Visibility.Visible
  '    btnState.SetAsActive(True)
  '  Else
  '    RemoveHandler btnState.Click, AddressOf btnState_Click
  '    btnState.SetAsActive(False)
  '    btnState.Visibility = Windows.Visibility.Collapsed
  '  End If
  'End Sub
  Private Sub FormatMe()
    If mAbility.IsUltimate Then
      lblAbilityLevel.Foreground = New SolidColorBrush(PageHandler.dbColors.UltimateTextColor)
    Else
      lblAbilityLevel.Foreground = New SolidColorBrush(PageHandler.dbColors.HeadingTextColor)
    End If
  End Sub
  Public Sub SetLevel(thelevel As Integer)
    '
    mAbility.CurrentLevel = thelevel
    If thelevel > 0 Then

      rectInactive.Visibility = Windows.Visibility.Collapsed
      lblAbilityLevel.Content = thelevel
      lblAbilityLevel.Visibility = Windows.Visibility.Visible
    Else

      rectInactive.Visibility = Windows.Visibility.Visible
      lblAbilityLevel.Visibility = Windows.Visibility.Collapsed
    End If
  End Sub

  Public Sub SetSelected(isselected As Boolean) Implements iControlIO.SetSelected
    If Not misResponsive Then Exit Sub
    If isselected Then
      misSelected = True
      rectSelected.Visibility = Windows.Visibility.Visible
    Else
      misSelected = False
      rectSelected.Visibility = Windows.Visibility.Collapsed
    End If
  End Sub
#Region "Info"
  Public ReadOnly Property MyAbility As iAbility_Info
    Get
      Return mAbility
    End Get
  End Property

  Public ReadOnly Property IsSelected As Boolean Implements iControlIO.IsSelected
    Get
      Return misSelected
    End Get
  End Property

  Public Property DisplayName As String Implements iGameEntity.DisplayName
    Get
      Return "Ability Thumg"
    End Get
    Set(value As String)

    End Set
  End Property

  Public Property EntityName As eEntity Implements iGameEntity.EntityName
    Get
      Return eEntity.ctrlAbilityThumb
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
#End Region

#Region "Event Handlers"
  Private Sub Me_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs)
    mTooltip.IsOpen = False
    Select Case misSelected
      Case True
        SetSelected(False)
      Case False
        SetSelected(True)

    End Select
    e.Handled = True
    RaiseEvent SelectedChanged(Me)
  End Sub

  Private Sub Object_TargetsChanged(gameentity As iGameEntity)
    If misSelected Then

      RaiseEvent isDirty(Me)
    End If

  End Sub

  Private Sub btnState_Click(btn As btnMinimalState)
    mAbility.CurrentStateIndex = mAbility.CurrentStateIndex + 1
    Me.thumbImage.Source = PageHandler.dbImages.GetAbilityImage(mAbility.AbilityName)
    RaiseEvent isDirty(Me)
  End Sub

#End Region








  Public Property MyColor As Color Implements iGameEntity.MyColor
    Get
      Return mColor
    End Get
    Set(value As Color)

    End Set
  End Property
End Class
