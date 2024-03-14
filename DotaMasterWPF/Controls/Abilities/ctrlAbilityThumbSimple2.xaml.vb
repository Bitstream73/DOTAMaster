Imports System.Windows.Media.Imaging

Public Class ctrlAbilityThumbSimple2
  Private mAbility As Ability_Info
  Private mColor As Color
  'Private mGame As dGame
  'Public mTooltip As ToolTip
  'Public misSelected As Boolean
  ' Public mDetails As ctrlAbility_Details
  'Event isSelected( sender As ctrlAbilityThumb)
  'Public mAbilitylevel As Integer

  'Public misResponsive As Boolean = True
  'Public Event isDirty( gameentity as igameentity) Implements iControlIO.isDirty

  'Public Event SelectedChanged( gameentity as igameentity) Implements iControlIO.SelectedChanged
  Public Sub New(theability As Ability_Info, portraitheight As Double, portraitwidth As Double) ',  thegame As dGame) ', theabilitylevel As Integer)
    InitializeComponent()


    LoadNewAbility(theability) ', thegame) ', theabilitylevel)

    SetPortraitSize(portraitheight, portraitwidth)

  End Sub

  Public Sub SetPortraitSize(portraitheight As Double, portralwidth As Double)
    thumbImage.Height = portraitheight
    thumbImage.Width = portralwidth
  End Sub

  'Public Sub SetUnresponsive( height As Double)
  '  ' rectSelected.Fill = Nothing
  '  Dim oldwidth = LayoutRoot.Width - colSwatch.Width.Value
  '  Dim oldheight = LayoutRoot.Height
  '  LayoutRoot.Width = ((height * oldwidth) / oldheight) + colSwatch.Width.Value
  '  LayoutRoot.Height = height
  '  'rectBorder1of2.Visibility = Windows.Visibility.Collapsed
  '  'rectBorder2of2.Visibility = Windows.Visibility.Collapsed
  '  ' rectInactive.Visibility = Windows.Visibility.Collapsed
  '  ' misResponsive = False
  'End Sub

  'Public Sub HideCurrentLevel()
  '  lblAbilityLevel.Visibility = Windows.Visibility.Collapsed
  '  rectAbilityLevel.Visibility = Windows.Visibility.Collapsed
  'End Sub
  Public Sub LoadNewAbility(theability As Ability_Info) ',  thegame As dGame) ',  theabilitylevel As Integer)
    'mGame = thegame
    ' mAbilitylevel = theabilitylevel
    mAbility = theability

    mColor = PageHandler.dbColors.GetColor(mAbility.AbilityName)

    If Not mAbility Is Nothing Then
      Dim parentid = mAbility.ParentGameEntity.Id
      'mAbility.SetTargets(thegame.GetEnemyTarget(parentid), thegame.GetFriendlyTarget(parentid), thegame.GetFriendBias(parentid))
      'mAbility.LoadStates(PageHandler.dbAbilities.GetItemStateAndUrls(mAbility.mName))


      'If Not mAbility.States Is Nothing Then

      '  If mAbility.States.Count > 1 Then

      '    Dim dbcolors = PageHandler.dbColors
      '    btnState.LoadButton(mAbility.States, _
      '                        dbcolors.ButtonColorSelected, dbcolors.ButtonColorNotSelected, _
      '                        dbcolors.HeadingTextColor, Constants.cMinBtnTextSize, Constants.cMinbtnHeight, Constants.cMinBtnMargin)

      '    SetBtnStateVisibility(True)
      '    btnState.SetState(mAbility.CurrentStateIndex)
      '  Else
      '    SetBtnStateVisibility(False)
      '    mAbility.CurrentStateIndex = -1 'default for stateless objects
      '  End If

      'Else
      '  SetBtnStateVisibility(False)
      '  mAbility.CurrentStateIndex = -1 'default for stateless objects
      'End If



      Dim ablvl = mAbility.CurrentLevel

      'mTooltip = New ToolTip()
      'Dim thick As New Thickness(0)
      'mTooltip.BorderThickness = thick
      'ToolTipService.SetToolTip(Me, mTooltip)

      'Dim ctrlTT As New ctrlAbility_Tooltipe(mAbility, ablvl)
      'mTooltip.Content = ctrlTT

      Me.thumbImage.Source = PageHandler.dbImages.GetAbilityImage(mAbility.AbilityName)


      Me.lblAbilityLevel.Content = ablvl.ToString

      Me.swatch.Fill = New SolidColorBrush(mColor)

      'If ablvl = 0 Then
      '  rectInactive.Visibility = Windows.Visibility.Visible
      'Else
      '  rectInactive.Visibility = Windows.Visibility.Collapsed
      'End If


      FormatMe()
    Else
      Me.lblAbilityLevel.Visibility = Windows.Visibility.Collapsed
      Me.thumbImage.Source = Nothing
    End If

    ' SetSelected(False)
    'AddHandler Me.MouseEnter, AddressOf Me_MouseEnter
    'AddHandler Me.MouseLeave, AddressOf Me_MouseLeave
    'AddHandler thumbImage.MouseLeftButtonDown, AddressOf Me_MouseLeftButtonDown
    'AddHandler rectInactive.MouseLeftButtonDown, AddressOf Me_MouseLeftButtonDown
    'AddHandler mGame.TargetsChanged, AddressOf Object_TargetsChanged
  End Sub

  'Private Sub SetBtnStateVisibility( isvisible As Boolean)
  '  If isvisible Then
  '    AddHandler btnState.Click, AddressOf btnState_Click
  '    btnState.Foreground = PageHandler.dbColors.HeadingTextColor
  '    btnState.Visibility = Windows.Visibility.Visible
  '    btnState.SetAsActive(True)
  '  Else
  '    RemoveHandler btnState.Click, AddressOf btnState_Click
  '    'btnState.Foreground = PageHandler.dbColors.Transparent
  '    'btnState.Background = PageHandler.dbColors.Transparent

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
    'mAbilitylevel = thelevel
    mAbility.CurrentLevel = thelevel
    If thelevel > 0 Then

      ' rectInactive.Visibility = Windows.Visibility.Collapsed
      lblAbilityLevel.Content = thelevel
      lblAbilityLevel.Visibility = Windows.Visibility.Visible
    Else

      'rectInactive.Visibility = Windows.Visibility.Visible
      lblAbilityLevel.Visibility = Windows.Visibility.Collapsed
    End If
  End Sub
  'Private Function GetColorFromImageCenter(thebmp As BitmapImage) As Color

  '  'this needs a rewrite

  '  Return PageHandler.dbColors.ErrorColor

  '  'Dim thecolor = PageHandler.dbColors.GetColorFromUri(theimageurl)

  '  'If thecolor Is Nothing Then
  '  '  If theimageurl = "" Then Exit Function
  '  '  Dim fu As New BitmapImage
  '  '  fu.CreateOptions = BitmapCreateOptions.None
  '  '  AddHandler fu.DownloadCompleted, AddressOf fu_imageopened
  '  '  'fu.UriSource = New Uri("http://cdn.dota2.com/apps/dota2/images/heroes/earthshaker_vert.jpg", UriKind.Absolute)
  '  '  fu.UriSource = New Uri(theimageurl, UriKind.Absolute)

  '  'Else
  '  '  Me.swatch.Fill = thecolor

  '  'End If


  'End Function

  Public ReadOnly Property MyAbility As Ability_Info
    Get
      Return mAbility
    End Get
  End Property
  'Private Sub fu_imageopened(sender As Object, e As RoutedEventArgs)

  '  'Dim thebmp As BitmapImage = sender



  '  'Dim trans As New ScaleTransform
  '  'trans.ScaleX = 1
  '  'trans.ScaleY = 1


  '  'Dim img As New Image
  '  'img.Source = thebmp


  '  'Dim wbmp As New WriteableBitmap(1, 1)
  '  'wbmp.Render(img, trans)
  '  'wbmp.Invalidate()

  '  'Dim wbmp As New WriteableBitmap(sender)
  '  'Dim pixel = wbmp.Pixels(wbmp.Pixels.Count / 2)

  '  ''Dim outpixel = pixels(pixels.Count / 2)

  '  'Dim thebytes() = BitConverter.GetBytes(pixel)

  '  'Dim newcolor = New SolidColorBrush(Color.FromArgb(thebytes(3), thebytes(0), thebytes(1), thebytes(2)))
  '  Dim newcolor = Helpers.GetSwatchFromImage(sender)
  '  Me.swatch.Fill = New SolidColorBrush(newcolor)
  '  PageHandler.dbColors.AddColor(mAbility.ImageUrl, newcolor)


  '  ''#If DEVMODE Then
  '  'Dim iditem As New dvID(mAbility.IDItem, "ctrlAbilityThumb/fu_imageopened: " & mAbility.mName.ToString & " Parent: " & Helpers.GetFriendlyGuid(mAbility.mParentID) & " " & mAbility.mParent.ToString)
  '  ''#Else
  '  ''    Dim iditem As New dvID(mAbility.ID, Nothing)

  '  ''#End If

  '  mAbility.IDItem.AppendMetaData("ctrlAbilityThumb/fu_imageopened: " & mAbility.mName.ToString & " Parent: " & Helpers.GetFriendlyGuid(mAbility.mParentID.GuidID) & " " & mAbility.mParent.ToString)
  '  PageHandler.dbColors.AddColor(mAbility.IDItem, newcolor)
  'End Sub

  'Private Sub Me_MouseEnter(sender As Object, e As MouseEventArgs)






  '  'mTooltip.IsOpen = True
  'End Sub

  'Private Sub Me_MouseLeave(sender As Object, e As MouseEventArgs)
  '  'mTooltip.IsOpen = False
  'End Sub

  'Private Sub Me_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs)
  '  mTooltip.IsOpen = False
  '  Select Case misSelected
  '    Case True
  '      SetSelected(False)
  '    Case False
  '      SetSelected(True)
  '      'mDetails = New ctrlAbility_Details(mAbility, mAbility.mAbilityLevel) ' mAbilitylevel)
  '  End Select
  '  e.Handled = True
  '  RaiseEvent SelectedChanged(New DDObject(Me, eEntity.ctrlAbilityThumb, Me.mAbility.IDItem))
  'End Sub

  'Public ReadOnly Property IsSelected As Boolean Implements iControlIO.IsSelected
  '  Get
  '    Return misSelected
  '  End Get
  'End Property

  'Public Sub SetSelected( isselected As Boolean) Implements iControlIO.SetSelected
  '  If Not misResponsive Then Exit Sub
  '  If isselected Then
  '    misSelected = True
  '    rectSelected.Visibility = Windows.Visibility.Visible
  '  Else
  '    misSelected = False
  '    rectSelected.Visibility = Windows.Visibility.Collapsed
  '  End If
  'End Sub

  'Private Sub Object_TargetsChanged( gameentity as igameentity)
  '  If misSelected Then

  '    RaiseEvent isDirty(New DDObject(Me, eEntity.ctrlAbilityThumb))
  '  End If

  'End Sub

  'Private Sub btnState_Click( btn As btnMinimalState)
  '  mAbility.CurrentStateIndex = mAbility.CurrentStateIndex + 1
  '  Helpers.SetImageSource(mAbility.ImageUrl, Me.thumbImage)
  '  RaiseEvent isDirty(New DDObject(Me, eEntity.ctrlAbilityThumb))
  'End Sub
End Class
