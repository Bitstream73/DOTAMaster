Public Class ctrlAbility_Thumb_Picker
  Implements iControlIO

  Public mAbility As Ability_Info
  Public mAvailableAbilities As Ability_Info_List
  Public mindex As Integer

  Public mTooltip As ToolTip

  Public Event isDirty(gameentity As iGameEntity) Implements iControlIO.isDirty

  Public Event SelectedChanged(gameentity As iGameEntity) Implements iControlIO.SelectedChanged

  Private isLoading As Boolean = True

  Private dbNames As FriendlyName_Database
  Private dbcontrols As Controls_Database

  Private mFriendlyName As String
  Public Sub New(ability As Ability_Info, abilitypickerlist As Ability_Info_List, theindex As Integer, namesdb As FriendlyName_Database, thectrls As Controls_Database)
    InitializeComponent()
    dbcontrols = thectrls
    dbNames = namesdb
    isLoading = True
    mFriendlyName = ability.DisplayName
    LoadNewAbility(ability, abilitypickerlist, theindex, mFriendlyName)

    AddHandler cmbAbilityPicker.SelectionChanged, AddressOf cmbAbilityPicker_SelectionChanged
    isLoading = False
  End Sub

  Public Sub LoadNewAbility(ability As Ability_Info, abilitypickerlist As Ability_Info_List, theindex As Integer, friendlyname As String)

    mFriendlyName = friendlyname
    mAbility = ability
    mAvailableAbilities = abilitypickerlist
    mindex = theindex
    lblLevelNumber.Content = (theindex + 1).ToString
    If Not ability Is Nothing Then
      mAbility = ability


      Me.thumbImage.Source = PageHandler.dbImages.GetAbilityImage(mability.AbilityName)

      Me.thumbImage.Visibility = Windows.Visibility.Visible

      mTooltip = New ToolTip()
      Dim thick As New Thickness(0)
      mTooltip.BorderThickness = thick
      ToolTipService.SetToolTip(Me, mTooltip)

      FormatMe()
    Else
      Me.thumbImage.Visibility = Windows.Visibility.Collapsed

    End If

    If Not abilitypickerlist Is Nothing Then
      mAvailableAbilities = abilitypickerlist
      cmbAbilityPicker.ItemsSource = dbcontrols.GetctrlAbility_List_itemList(mAvailableAbilities.GetListItems)

      cmbAbilityPicker.Visibility = Windows.Visibility.Visible
    Else
      If theindex = 5 Then
        Dim x = 2
      End If
      cmbAbilityPicker.Visibility = Windows.Visibility.Collapsed
    End If

    AddHandler Me.MouseEnter, AddressOf Me_MouseEnter

  End Sub

  Private Sub FormatMe()
    If mAbility.IsUltimate Then
      lblLevelNumber.Foreground = New SolidColorBrush(Color.FromArgb(255, 255, 0, 0))
    Else
      lblLevelNumber.Foreground = New SolidColorBrush(Color.FromArgb(255, 255, 255, 255))
    End If
  End Sub

  Private Sub cmbAbilityPicker_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
    'If mIsLoading Then Exit Sub
    Dim thecombo As ComboBox = sender

    Dim thectrl As ctrlAbility_List_item = thecombo.SelectedItem
    If Not thectrl Is Nothing Then
      mAbility = thectrl.mAbility

      RaiseEvent isDirty(Me)
    End If


  End Sub
  Private Sub Me_MouseEnter(sender As Object, e As MouseEventArgs)

    If Not mAbility Is Nothing Then
      Dim ctrlTT As New ctrlAbility_Tooltipe(mAbility, 0, mFriendlyName)
      mTooltip.Content = ctrlTT
    End If

  End Sub



  Public ReadOnly Property IsSelected As Boolean Implements iControlIO.IsSelected
    Get
      Return False
    End Get
  End Property


  Public Sub SetSelected(isselected As Boolean) Implements iControlIO.SetSelected
    Dim x = 2
  End Sub
End Class
