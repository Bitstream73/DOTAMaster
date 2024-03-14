#Const Devmode = False

Public Class ctrlItem_Thumb_Picker_3
  Implements iControlIO

  Private mIDItem As dvID
  Private mItemList As Item_Listitem_List
  Public mItem As Item_Info
  Private mgame As dGame
  Private dbNames As FriendlyName_Database

  Public mPickerToolTip As ToolTip
  Public itemplanToolTip As ToolTip
  Public mInsertToolTip As ToolTip
  Public mDetails As ctrlItem_Details
  Public misSelected As Boolean = False

  Private mBuildsfrom As List(Of Item_Info)
  Private mBuildsto As List(Of Item_Info)

  Private dbImages As Image_Database
  Event isDeleted(thectrl As ctrlItem_Thumb_Picker_3)
  Event hasInsert(thectrl As ctrlItem_Thumb_Picker_3)

  Public Event isDirty(gameentity as igameentity) Implements iControlIO.isDirty

  Public Event SelectedChanged(gameentity as igameentity) Implements iControlIO.SelectedChanged
  Public Sub New(theitemindex As Integer, thegame As dGame)
    InitializeComponent()
    mgame = thegame
    dbNames = mgame.dbNames

    mIDItem = New dvID(Guid.NewGuid, "ctrlItem_Thumb_Picker_3/New", eEntity.ctrlAbility_Thumb_Picker)
#If Devmode Then

    spnlDevmode.Visibility = Windows.Visibility.Visible
#Else
    spnlDevmode.Visibility = Windows.Visibility.Collapsed

#End If

    spnlComp1.Visibility = Windows.Visibility.Collapsed
    spnlComp2.Visibility = Windows.Visibility.Collapsed
    spnlComp3.Visibility = Windows.Visibility.Collapsed
    spnlComp4.Visibility = Windows.Visibility.Collapsed
    SetSelected(False)
    rectSplitBorder.Visibility = Windows.Visibility.Collapsed

    tbkDelete.Visibility = Windows.Visibility.Collapsed
    dpnalInsert.Visibility = Windows.Visibility.Visible
    'tbkInsert.Name = "tbkInsert"
    'LoadItem(theitemindex, theitem, thegame, dbNames)
    AddHandler Me.MouseLeftButtonDown, AddressOf Me_MouseLeftButtonDown
    AddHandler btnKeepSell.Click, AddressOf btnKeepSell_Click

    AddHandler Me.MouseEnter, AddressOf Me_MouseEnter
    AddHandler Me.MouseLeave, AddressOf Me_MouseLeave

    ' dpnalInsert.Visibility = Windows.Visibility.Collapsed

  End Sub
  'Public Sub New( theitem As Item_Info,  theitemindex As Integer)

  '  Me.New(Nothing, theitemindex, theitem, False)

  'End Sub

  Public ReadOnly Property IsSelected As Boolean Implements iControlIO.IsSelected
    Get
      Return misSelected
    End Get
  End Property
  Public ReadOnly Property ItemIsFromDisassembly2
    Get
      Return mItem.ItemIsFromDisassembly
    End Get
  End Property

  Public Sub LoadItem(theitemindex As Integer, theitem As Item_Info, _
                       buildsfrom As List(Of Item_Info), buildsto As List(Of Item_Info), _
                       imagedb As Image_Database, thegame As dGame)
    If theitem Is mItem Then Exit Sub
    'mItemList = itemlist
    mItem = theitem
    mItem.Index = theitemindex
    mgame = thegame
    dbNames = mgame.dbNames
    dbImages = imagedb
    mBuildsfrom = buildsfrom
    mBuildsto = buildsto

    If mItem.Index = 0 Then
      Dim x = 2
    End If
    Dim thick As New Thickness(0)

    itemplanToolTip = New ToolTip
    itemplanToolTip.Content = "Add a new item"
    itemplanToolTip.BorderThickness = thick
    ToolTipService.SetToolTip(btnKeepSell, itemplanToolTip)

    If Not mItem.ItemName = eItemname.None Then
      Dim myparent = mItem.ParentGameEntity
      mItem.SetTargets(mgame.GetEnemyTarget(myparent), mgame.GetFriendlyTarget(myparent), mgame.GetFriendBias(myparent))
      'Helpers.SetURLImageSource(mItem.ImageUrl, Me.thumbImage)
      Me.thumbImage.Source = PageHandler.dbImages.GetItemImage(mItem.ItemName)

      tbkDelete.Visibility = Windows.Visibility.Visible
      'AddHandler lblDelete.MouseLeftButtonDown, AddressOf lblDelete_MouseLeftButtonDown
      dpnalInsert.Visibility = Windows.Visibility.Visible
      'AddHandler tbkInsert.MouseLeftButtonDown, AddressOf tbkInsert_MouseLeftButtonDown

      mPickerToolTip = New ToolTip()

      mPickerToolTip.BorderThickness = thick
      ToolTipService.SetToolTip(Me, mPickerToolTip)

      Dim ctrlTT As New ctrlItemThumbPicker_Tootip(mItem, mBuildsfrom, mBuildsto, dbImages)
      mPickerToolTip.Content = ctrlTT

      'AddHandler Me.MouseEnter, AddressOf Me_MouseEnter

      lblPurchasePrice.Content = "-" & mItem.GoldCost.ToString
      ' lblBalance.Content = mItem.mGoldBalance.ToString

      btnKeepSell.Content = dbNames.GetFriendlyNameforEItemPlan(ItemPlan)
      itemplanToolTip.Content = GetToolTipforEItemPlan(ItemPlan)

      ' tbkItemname.Text = mItem.mDisplayname

      ''components stuff
      If mItem.CanDisassemble Then
        LoadComponents()
      End If

      If mItem.ItemIsDisassembled Then
        ShowComponents(True)
      End If
      If Not mItem.BoughtAtLevel < 1 Then
        colTimeBeforeBought.Width = New GridLength(mItem.BoughtAtLevel - 1, GridUnitType.Star)
        colTimeOwned.Width = New GridLength(mItem.SoldAtLevel - mItem.BoughtAtLevel, GridUnitType.Star)
        ColTimeAfterOwned.Width = New GridLength(25 - mItem.SoldAtLevel, GridUnitType.Star)
      Else
        colTimeOwned.Width = New GridLength(0, GridUnitType.Star)
      End If


      If ItemIsFromDisassembly Then SetItemPlan(eItemPlan.SellAtOnce)
      ' If mItem.mIsConsumable Then SetItemPlan(eItemPlan.UseFor3Levels)
      If mItem.IsCourier Then SetItemPlan(eItemPlan.UseAtOnce)


    Else
      btnKeepSell.Content = "Pick Item"

      ColTimeAfterOwned.Width = New GridLength(0, GridUnitType.Star)
      lblPurchasePrice.Content = ""
      ' lblSellPrice.Content = ""
      'Helpers.SetURLImageSource(Nothing, Me.thumbImage)
      Me.thumbImage.Source = Nothing
    End If

#If Devmode Then
    If Not mItem.mLifetime Is Nothing Then
      Dim start = New ddFrame(mItem.mLifetime.CreationTime.count)
      Dim _end = New ddFrame(mItem.mLifetime.CreationTime.count + mItem.mLifetime.Lifespan.count)
      lblDevmode1.Content = Helpers.GetFriendlyTime(start) & " - " & Helpers.GetFriendlyTime(_end)
      lblDevmode2.Content = ""
      lblDevmode3.Content = ""
      lblDevmode4.Content = ""
    Else
      lblDevmode1.Content = ""
      lblDevmode2.Content = ""
      lblDevmode3.Content = ""
      lblDevmode4.Content = ""
    End If

#End If



    'Me.cmbItemPicker.ItemsSource = mItemList
    'cmbItemPicker.ItemsSource = PageHandler.dbItems.GetListItems

  End Sub

  Private Function ComponentsContainItem(thename As eItemname) As Boolean
    For i As Integer = 0 To mBuildsfrom.Count - 1
      If mBuildsfrom.Item(i).ItemName = thename Then Return True
    Next
    Return False
  End Function

  'Private Function GetComponentFromName( thename As eItemname) As ctrlItem_Thumb_Picker_3


  '  For i As Integer = 0 To mItem.ComponentList.Count - 1
  '    Dim newpicker As New ctrlItem_Thumb_Picker_3(-1, mgame)

  '    Dim buildsfrom = mgame.dbItems.GetItemInfos(mItem.mBuildsFrom, mItem.ParentID, mItem.mLifetime)
  '    Dim buildsto = mgame.dbItems.GetItemInfos(mItem.mBuildsTo, mItem.ParentID, mItem.mLifetime)

  '    newpicker.LoadItem(-1, mItem, buildsfrom, buildsto, dbImages, mgame)
  '    If mItem.ComponentList.Item(i).mName = thename Then Return newpicker
  '  Next
  '  Return Nothing
  'End Function
  'Public Sub LoadComponent( thecomp As Item_Info)


  '  If ComponentsContainItem(thecomp.mName) Then
  '    Dim _comp = GetComponentFromName(thecomp.mName)
  '    _comp.SetItemPlan(thecomp.itemplan)
  '    _comp.ID = thecomp.ID
  '  End If
  '  ShowComponents(True)
  '  RaiseEvent isDirty(New DDObject(Me, eEntity.ctrlItem_Thumb_Picker_3))
  'End Sub
  Private Sub LoadComponents()

    If Not mItem Is Nothing Then
      If mItem.CanDisassemble Then


        For i As Integer = 0 To mBuildsfrom.Count - 1
          Dim theitem = mBuildsfrom.Item(i)
          theitem.ItemIsFromDisassembly = True
          If Not theitem.IsRecipe Then
            Dim newcomp As New ctrlItem_Thumb_Picker_3(-1, mgame)
            Dim buildsfrom = mgame.dbItems.GetItemInfosNoParent(theitem.MadeFromItemNames)
            Dim buildsto = mgame.dbItems.GetItemInfosNoParent(theitem.BuildsToNames)
            newcomp.LoadItem(-1, theitem, buildsfrom, buildsto, dbImages, mgame)
            newcomp.SetItemPlan(eItemPlan.SellAtOnce)
            newcomp.ItemIsFromDisassembly = True
            newcomp.dpnalInsert.Visibility = Windows.Visibility.Collapsed
            newcomp.rectBorder.Visibility = Windows.Visibility.Collapsed
            newcomp.rectBorderGradient.Visibility = Windows.Visibility.Collapsed
            newcomp.lblPurchasePrice.Visibility = Windows.Visibility.Collapsed
            'newcomp.cmbItemPicker.Visibility = Windows.Visibility.Collapsed
            newcomp.tbkDelete.Visibility = Windows.Visibility.Collapsed
            'newcomp.mItem.mParentID = Me.mID
            'newcomp.mIndexofOwner = mItemIndex

            Select Case i
              Case 0
                spnlComp1.Children.Clear()
                spnlComp1.Children.Add(newcomp)
              Case 1
                spnlComp2.Children.Clear()
                spnlComp2.Children.Add(newcomp)
              Case 2
                spnlComp3.Children.Clear()
                spnlComp3.Children.Add(newcomp)
              Case 3
                spnlComp4.Children.Clear()
                spnlComp4.Children.Add(newcomp)
              Case Else
                Dim x = 2


            End Select
          End If




        Next
      End If
    End If
  End Sub


  Private Sub ShowComponents(setvisible As Boolean)
    If setvisible Then

      spnlComp1.Visibility = Windows.Visibility.Visible
      spnlComp2.Visibility = Windows.Visibility.Visible
      spnlComp3.Visibility = Windows.Visibility.Visible
      spnlComp4.Visibility = Windows.Visibility.Visible
      rectSplitBorder.Visibility = Windows.Visibility.Visible
      '   mItemWillBeDisassembled = True
      mItem.ItemIsDisassembled = True
      'RaiseEvent isDirty(Me)

    Else
      spnlComp1.Visibility = Windows.Visibility.Collapsed
      spnlComp2.Visibility = Windows.Visibility.Collapsed
      spnlComp3.Visibility = Windows.Visibility.Collapsed
      spnlComp4.Visibility = Windows.Visibility.Collapsed
      rectSplitBorder.Visibility = Windows.Visibility.Collapsed
      'ComponentList.Clear()
      ' mItemWillBeDisassembled = False
      mItem.ItemIsDisassembled = False
      'RaiseEvent isDirty(Me)
    End If
  End Sub

  Public Property ItemIsFromDisassembly As Boolean
    Get
      Return mItem.ItemIsFromDisassembly
    End Get
    Set(value As Boolean)
      mItem.ItemIsFromDisassembly = value

      If mItem.ItemIsFromDisassembly Then
        SetAsItemFromDisassembly()

      End If
    End Set
  End Property
  Public Property ID As dvID
    Get
      Return mIDItem
    End Get
    Set(value As dvID)
      mIDItem = value
    End Set
  End Property

  Public Sub SetAsItemFromDisassembly()
    mItem.ItemIsFromDisassembly = True
    Me.thumbImage.Width = 35
    SetItemPlan(eItemPlan.SellAtOnce)
    btnKeepSell.Content = dbNames.GetFriendlyNameforEItemPlan(ItemPlan)
    itemplanToolTip.Content = GetToolTipforEItemPlan(ItemPlan)
  End Sub

  Private Sub lblKeepSell_MouseLeftButtonDown(sender As Object)

    Dim thebutton As Button = sender
    If thebutton.Content = "Pick Item" Then Exit Sub
    Dim curplan As eItemPlan = GetEItemPlanForFriendlyName(thebutton.Content)


    SetNextItemPlan(curplan)

    thebutton.Content = dbNames.GetFriendlyNameforEItemPlan(ItemPlan)
    itemplanToolTip.Content = GetToolTipforEItemPlan(ItemPlan)
    If ItemPlan = eItemPlan.Disassemble Then
      'mItemIsFromDisassembly = True
      'mItemWillBeDisassembled = True
      mItem.ItemIsDisassembled = True
      ShowComponents(True)
    Else
      ShowComponents(False)
      'mItemWillBeDisassembled = False
      mItem.ItemIsDisassembled = False
      ' mItemIsFromDisassembly = False
    End If
    'e.Handled = True
    RaiseEvent isDirty(Me)
    'RaiseEvent componentsDirty(Me)
  End Sub


  Private Sub btnKeepSell_Click(sender As Object, e As RoutedEventArgs)
    If btnKeepSell.Content = "Pick Item" Then
      PageHandler.dbControls.ItemMenu.OpenMenu(Me)
      AddHandler PageHandler.dbControls.ItemMenu.itemPicked, AddressOf ItemMenu_ItemPicked
    Else
      lblKeepSell_MouseLeftButtonDown(sender)
    End If
  End Sub
  Private Sub Me_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs)

    Dim Source As FrameworkElement = TryCast(e.OriginalSource, FrameworkElement)

    Dim thename As String = Source.Name
    e.Handled = True


    Select Case thename
      Case "dpnalInsert", "lblPlusMinus", "lblInsertitem", "rectDividerMid"


        RaiseEvent hasInsert(Me)



      Case "tbkDelete"
        RaiseEvent isDeleted(Me)
      Case Else
        Select Case misSelected
          Case True

            SetSelected(False)

          Case False
            SetSelected(True)
            If Not mItem Is Nothing Then

              Dim buildsto As List(Of Item_Info)
              Dim buildsfrom As List(Of Item_Info)

              If Not mItem.BuildsToNames Is Nothing Then
                buildsto = New List(Of Item_Info)
                For i As Integer = 0 To mItem.BuildsToNames.Count - 1
                  Dim curinfo = mgame.dbItems.GetItemInfoNoParent(mItem.BuildsToNames.Item(i)) 'not sure if lifetime is right here
                  buildsto.Add(curinfo)
                Next


              End If


              buildsfrom = New List(Of Item_Info)
              For i As Integer = 0 To mItem.MadeFromItemNames.Count - 1
                Dim curinfo = mgame.dbItems.GetItemInfoNoParent(mItem.MadeFromItemNames.Item(i)) 'not sure if lifetime is right here
                buildsfrom.Add(curinfo)
              Next



              'temporarily commented out
              '  mDetails = New ctrlItem_Details(mItem, buildsfrom, buildsto)
            End If

        End Select

        RaiseEvent SelectedChanged(Me)
    End Select






  End Sub



  Public Property ItemPlan As eItemPlan
    Get
      Return mItem.ItemPlan
    End Get
    Set(value As eItemPlan)
      mItem.ItemPlan = value
    End Set
  End Property



  Public Function GetToolTipforEItemPlan(theplan As eItemPlan) As String
    Select Case theplan
      Case eItemPlan.UseAtOnce
        Return "Item's charge(s) will be cast immediately"
      Case eItemPlan.Disassemble
        Return "When Components from the item are needed, item will be split into it's component parts"
      Case eItemPlan.KeepForever
        Return "Item will either be kept as is or used to create future items"
      Case eItemPlan.SellAtOnce
        Return "Item will be sold as soon as item is split out from it's parent item"
      Case eItemPlan.SellForSpace
        Return "When your inventory is full, the oldest item will be sold to make space"
      Case eItemPlan.UseFor1Level
        Return "Keep this item for 1 level, then use it's charges and/or sell it"
      Case eItemPlan.UseFor2Levels
        Return "Keep this item for 2 level, then use it's charges and/or sell it"
      Case eItemPlan.UseFor3Levels
        Return "Keep this item for 3 level, then use it's charges and/or sell it"
      Case eItemPlan.UseFor4Levels
        Return "Keep this item for 4 level, then use it's charges and/or sell it"
      Case eItemPlan.UseFor5Levels
        Return "Keep this item for 5 level, then use it's charges and/or sell it"
      Case Else
        Dim x = 2
        Return "Select an item"
    End Select
  End Function
  Public Function GetEItemPlanForFriendlyName(thename As String) As eItemPlan
    Dim items = System.Enum.GetValues(GetType(eItemPlan))

    For Each item In items
      If dbNames.GetFriendlyNameforEItemPlan(item) = thename Then Return item
    Next
    Return Nothing
  End Function

  Private Sub SetItemPlan(theplan As eItemPlan)
    btnKeepSell.Content = dbNames.GetFriendlyNameforEItemPlan(theplan)
    itemplanToolTip.Content = GetToolTipforEItemPlan(theplan)
  End Sub


  Public Function SetNextItemPlan(currentplan As eItemPlan) As eItemPlan
    If mItem Is Nothing Then Return currentplan
    If mItem.IsCourier Then
      mItem.ItemPlan = eItemPlan.UseAtOnce
      Return eItemPlan.UseAtOnce
    End If

    If mItem.IsConsumable Then Return GetNextConsumablePlan(currentplan)
    If mItem.CanDisassemble Then Return GetNextDisassemblePlan(currentplan)
    If mItem.ItemIsFromDisassembly Then Return GetNextComponentPlan(currentplan)

    Select Case currentplan
      Case eItemPlan.KeepForever
        mItem.ItemPlan = eItemPlan.SellForSpace
        Return mItem.ItemPlan
      Case eItemPlan.SellForSpace
        mItem.ItemPlan = eItemPlan.UseFor1Level
        Return mItem.ItemPlan
      Case eItemPlan.UseFor1Level
        mItem.ItemPlan = eItemPlan.UseFor2Levels
        Return mItem.ItemPlan
      Case eItemPlan.UseFor2Levels
        mItem.ItemPlan = eItemPlan.UseFor3Levels
        Return mItem.ItemPlan
      Case eItemPlan.UseFor3Levels
        mItem.ItemPlan = eItemPlan.UseFor4Levels
        Return mItem.ItemPlan
      Case eItemPlan.UseFor4Levels
        mItem.ItemPlan = eItemPlan.UseFor5Levels
        Return mItem.ItemPlan
      Case eItemPlan.UseFor5Levels
        mItem.ItemPlan = eItemPlan.KeepForever
        Return mItem.ItemPlan
      Case Else
        mItem.ItemPlan = eItemPlan.KeepForever
        Return mItem.ItemPlan
    End Select

  End Function

  Private Function GetNextConsumablePlan(currentplan As eItemPlan) As eItemPlan
    Select Case currentplan
      Case eItemPlan.KeepForever 'bottle
        mItem.ItemPlan = eItemPlan.SellForSpace

      Case eItemPlan.SellForSpace
        mItem.ItemPlan = eItemPlan.UseFor1Level

      Case eItemPlan.UseFor1Level
        mItem.ItemPlan = eItemPlan.UseFor2Levels

      Case eItemPlan.UseFor2Levels
        mItem.ItemPlan = eItemPlan.UseFor3Levels

      Case eItemPlan.UseFor3Levels
        mItem.ItemPlan = eItemPlan.UseFor4Levels

      Case eItemPlan.UseFor4Levels
        mItem.ItemPlan = eItemPlan.UseFor5Levels

      Case eItemPlan.UseFor5Levels
        mItem.ItemPlan = eItemPlan.SellForSpace

      Case Else
        mItem.ItemPlan = eItemPlan.SellForSpace

    End Select

    Return mItem.itemplan
  End Function

  Private Function GetNextDisassemblePlan(currentPlan As eItemPlan) As eItemPlan
    Select Case currentPlan
      Case eItemPlan.KeepForever
        mItem.ItemPlan = eItemPlan.SellForSpace

      Case eItemPlan.SellForSpace
        mItem.ItemPlan = eItemPlan.Disassemble

      Case eItemPlan.Disassemble
        mItem.ItemPlan = eItemPlan.UseFor1Level

      Case eItemPlan.UseFor1Level
        mItem.ItemPlan = eItemPlan.UseFor2Levels

      Case eItemPlan.UseFor2Levels
        mItem.ItemPlan = eItemPlan.UseFor3Levels

      Case eItemPlan.UseFor3Levels
        mItem.ItemPlan = eItemPlan.UseFor4Levels

      Case eItemPlan.UseFor4Levels
        mItem.ItemPlan = eItemPlan.UseFor5Levels

      Case eItemPlan.UseFor5Levels
        mItem.ItemPlan = eItemPlan.KeepForever

      Case Else
        mItem.ItemPlan = eItemPlan.KeepForever

    End Select
    Return mItem.ItemPlan
  End Function

  Private Function GetNextComponentPlan(currentplan As eItemPlan) As eItemPlan
    Select Case currentplan
      Case eItemPlan.KeepForever
        mItem.ItemPlan = eItemPlan.SellAtOnce

      Case eItemPlan.SellAtOnce
        mItem.itemplan = eItemPlan.KeepForever
      Case Else
        mItem.itemplan = eItemPlan.SellAtOnce



    End Select
    Return mItem.itemplan
  End Function

  Private Sub ItemMenu_ItemPicked(theitem As Item_Info, owner As ctrlItem_Thumb_Picker_3)

    If theitem Is Nothing Or owner Is Nothing Then
      RemoveHandler PageHandler.dbControls.ItemMenu.itemPicked, AddressOf ItemMenu_ItemPicked
      Exit Sub
    End If


    If owner.ID Is Me.ID Then
      Dim newitem = owner.mgame.dbItems.CreateItemInstance(theitem.ItemName, mItem.ParentGameEntity.Id, Constants.cDefaultLifetime)

      newitem.Index = mItem.Index
      newitem.mTeamEnemyTarget = mItem.mTeamEnemyTarget

      mItem = newitem



      RaiseEvent isDirty(Me)
    End If
  End Sub

  Private Sub Me_MouseEnter(sender As Object, e As MouseEventArgs)

    ' dpnalInsert.Visibility = Windows.Visibility.Visible
  End Sub

  Private Sub Me_MouseLeave(sender As Object, e As MouseEventArgs)
    'dpnalInsert.Visibility = Windows.Visibility.Collapsed
  End Sub





  Public Sub SetSelected( isselected As Boolean) Implements iControlIO.SetSelected
    If isselected Then
      rectSelected.Visibility = Windows.Visibility.Visible
      misSelected = True
    Else
      rectSelected.Visibility = Windows.Visibility.Collapsed
      misSelected = False
    End If
  End Sub
End Class
