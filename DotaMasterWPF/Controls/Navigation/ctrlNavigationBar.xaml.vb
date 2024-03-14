Public Class ctrlNavigationBar
  Private mGame As dGame

  Private mMenuDropDowns As New List(Of ComboBox) '0 is root of navigation
  Private mMenuSlashes As New List(Of Label) '0 is first submenu slash
  '  Private mCombo1Items As List(Of ctrlNavigation_Menu_Item)

  Private mCurrentlySelectedMenuItems As New List(Of ctrlNavigation_Menu_Item)

  Private mIsLoading As Boolean = False

  Event GameEntitySelected(gameent As iGameEntity)


  Public Sub New()

    ' This call is required by the designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.
    mMenuDropDowns = New List(Of ComboBox)

    AddHandler cmbRoot.SelectionChanged, AddressOf cmbMenu_SelectionChanged
    mMenuDropDowns.Add(cmbRoot)

    AddHandler cmbLevel1.SelectionChanged, AddressOf cmbMenu_SelectionChanged
    mMenuDropDowns.Add(cmbLevel1)

    AddHandler cmbLevel2.SelectionChanged, AddressOf cmbMenu_SelectionChanged
    mMenuDropDowns.Add(cmbLevel2)

    AddHandler cmbLevel3.SelectionChanged, AddressOf cmbMenu_SelectionChanged
    mMenuDropDowns.Add(cmbLevel3)
  End Sub

  Public Sub Load(game As dGame)
    mGame = game

    For i = 0 To mMenuDropDowns.Count - 1
      mMenuDropDowns.Item(i).ItemsSource = Nothing
    Next

    mCurrentlySelectedMenuItems.Clear()

    mCurrentlySelectedMenuItems = New List(Of ctrlNavigation_Menu_Item)
    mCurrentlySelectedMenuItems.Add(Nothing)
    mCurrentlySelectedMenuItems.Add(Nothing)
    mCurrentlySelectedMenuItems.Add(Nothing)
    mCurrentlySelectedMenuItems.Add(Nothing)

    mMenuSlashes = New List(Of Label)
    mMenuSlashes.Add(lblSlash1)
    mMenuSlashes.Add(lblSlash2)
    mMenuSlashes.Add(lblSlash3)

    InitializeMenues()

  End Sub

  Private Sub InitializeMenues()

    FillRootMenu(mMenuDropDowns.Item(0))
    For i As Integer = 1 To mMenuDropDowns.Count - 1
      If mMenuDropDowns.Item(i - 1).Items.Count > 0 Then

        FillSubMenu(mMenuDropDowns.Item(i - 1).Items.Item(0), mMenuDropDowns.Item(i), i)
      Else
        ShowSubmenu(i, False)
        ShowMenuSlash(i - 1, False)
      End If
    Next
    Dim selectedcomboitem As ctrlNavigation_Menu_Item = mMenuDropDowns.Item(1).Items(0)
    RaiseEvent GameEntitySelected(selectedcomboitem.MyGameEntity)
  End Sub

  Public Sub BackFillMenuItems(selectedgameentity As iGameEntity)
    Dim selectedGameEntitiesFrontToBack As New List(Of iGameEntity)
    Dim rootmenureached As Boolean = False

    Dim curentity = selectedgameentity
    Do Until rootmenureached
      selectedGameEntitiesFrontToBack.Add(curentity)

      rootmenureached = GameEntityIsOnRootMenu(curentity)

      curentity = curentity.ParentGameEntity
      If curentity Is Nothing Then rootmenureached = True
    Loop


    selectedGameEntitiesFrontToBack.Reverse()
    For i = 0 To mMenuDropDowns.Count - 1
      If selectedGameEntitiesFrontToBack.Count > i Then

        If i = 0 Then
          FillRootMenu(mMenuDropDowns.Item(0))
        Else
          FillSubMenu(mMenuDropDowns.Item(i - 1).SelectedItem, mMenuDropDowns.Item(i), i)
        End If

        If i < selectedGameEntitiesFrontToBack.Count Then
          ShowSubmenu(i, True)
          SetSelected(selectedGameEntitiesFrontToBack.Item(i), mMenuDropDowns.Item(i))

        Else
          ShowSubmenu(i, False)
        End If

      End If
    Next
  End Sub

  Private Sub SetSelected(selecteditem As iGameEntity, combo As ComboBox)

    For i As Integer = 0 To combo.Items.Count - 1
      Dim curitem As ctrlNavigation_Menu_Item = combo.Items.Item(i)

      If curitem.MyGameEntity Is selecteditem Then
        RemoveHandler combo.SelectionChanged, AddressOf cmbMenu_SelectionChanged
        combo.SelectedItem = curitem
        AddHandler combo.SelectionChanged, AddressOf cmbMenu_SelectionChanged
      End If
    Next

  End Sub
  Private Function GameEntityIsOnRootMenu(gameent As iGameEntity)
    For i = 0 To cmbRoot.Items.Count - 1
      Dim menuitem As ctrlNavigation_Menu_Item = cmbRoot.Items(i)
      If menuitem.MyGameEntity Is gameent Then Return True

    Next
    Return False
  End Function
  Private Sub FillSubMenu(parent As ctrlNavigation_Menu_Item, submenu As ComboBox, submenuindex As Integer)

    RemoveHandler submenu.SelectionChanged, AddressOf cmbMenu_SelectionChanged
    submenu.ItemsSource = Nothing
    'check to see if this menu should even be visible
    If parent Is Nothing Then
      submenu.SelectedItem = Nothing
      ShowSubmenu(submenuindex, False)
      ShowMenuSlash(submenuindex - 1, False)
      Exit Sub
    End If
    If parent.IsSummary Then
      submenu.SelectedItem = Nothing
      ShowSubmenu(submenuindex, False)
      ShowMenuSlash(submenuindex - 1, False)
      Exit Sub
    End If



    'fill and show the menu


    Dim parentofsubmenu = parent.MyGameEntity
    Dim submenuitems = mGame.GetNavigationItemsForItem(parentofsubmenu)
    Dim submenucombos As New List(Of ctrlNavigation_Menu_Item)

    'add summary item as first item
    Dim summary As New ctrlNavigation_Menu_Item(parentofsubmenu, True)
    submenucombos.Add(summary)
    For i = 0 To submenuitems.Count - 1
      submenucombos.Add(New ctrlNavigation_Menu_Item(submenuitems.Item(i), False))
    Next
    submenu.Items.Clear()
    submenu.ItemsSource = submenucombos
    mCurrentlySelectedMenuItems.RemoveAt(submenuindex)
    mCurrentlySelectedMenuItems.Insert(submenuindex, submenucombos.Item(0))
    submenu.SelectedItem = submenucombos.Item(0)

    ShowSubmenu(submenuindex, True)
    ShowMenuSlash(submenuindex - 1, True)

    AddHandler submenu.SelectionChanged, AddressOf cmbMenu_SelectionChanged
  End Sub
  Private Sub FillRootMenu(rootmenu As ComboBox)
    RemoveHandler rootmenu.SelectionChanged, AddressOf cmbMenu_SelectionChanged
    rootmenu.ItemsSource = Nothing

    Dim gameitemlist = mGame.GetRootNavigationItemsForUI()
    Dim rootmenuites As New List(Of ctrlNavigation_Menu_Item)

    For i = 0 To gameitemlist.Count - 1
      rootmenuites.Add(New ctrlNavigation_Menu_Item(gameitemlist.Item(i), False))
    Next

    Dim root = mMenuDropDowns.Item(0)
    root.Items.Clear()
    root.ItemsSource = rootmenuites
    mCurrentlySelectedMenuItems.RemoveAt(0)
    mCurrentlySelectedMenuItems.Insert(0, rootmenuites.Item(0))
    root.SelectedItem = rootmenuites.Item(0)
    AddHandler rootmenu.SelectionChanged, AddressOf cmbMenu_SelectionChanged
  End Sub

  Private Sub ShowMenuSlash(slashindex As Integer, isvisible As Boolean)
    If slashindex < mMenuSlashes.Count Then
      If isvisible Then
        mMenuSlashes.Item(slashindex).Visibility = Windows.Visibility.Visible
      Else
        mMenuSlashes.Item(slashindex).Visibility = Windows.Visibility.Collapsed
      End If
    End If
  End Sub

  Private Sub ShowSubmenu(submenuindex As Integer, isvisible As Boolean)
    If submenuindex < mMenuDropDowns.Count Then
      If isvisible Then
        mMenuDropDowns.Item(submenuindex).Visibility = Windows.Visibility.Visible
      Else
        mMenuDropDowns.Item(submenuindex).Visibility = Windows.Visibility.Collapsed
      End If
    End If
  End Sub

  Private Function GetIndexForMenu(menu As ComboBox) As Integer
    For i = 0 To mMenuDropDowns.Count - 1
      If mMenuDropDowns.Item(i) Is menu Then Return i
    Next

    Return -1
  End Function

  Private Sub cmbMenu_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
    If mIsLoading Then Exit Sub
    Dim currentmenu As ComboBox = sender
    Dim currentmenuindex = GetIndexForMenu(currentmenu)


    Dim selectedmenuitem As ctrlNavigation_Menu_Item = currentmenu.SelectedItem

    If selectedmenuitem Is Nothing Then Exit Sub
    If Not currentmenu.IsVisible Then Exit Sub
    '   If selectedmenuitem Is mCurrentlySelectedMenuItems.Item(currentmenuindex) Then Exit Sub

    'mIsLoading = True

    If currentmenuindex = 0 Then
      mCurrentlySelectedMenuItems.RemoveAt(0)
      mCurrentlySelectedMenuItems.Insert(0, selectedmenuitem)
    End If

    For i = currentmenuindex + 1 To mMenuDropDowns.Count - 1

      FillSubMenu(mMenuDropDowns.Item(i - 1).SelectedItem, mMenuDropDowns.Item(i), i)
    Next

    'mIsLoading = False

    RaiseEvent GameEntitySelected(selectedmenuitem.MyGameEntity)
  End Sub

End Class
