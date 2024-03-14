#Const devmode = False

Imports DotaMasterWPF.PageHandler
Public Class ctrlPet_Badge
  Implements iControlIO

#Region "Vars"

  ' Private mGame As dGame
  'keeps track of changes to current selected build
  Public mPet As Pet_Instance
  Private mID As dvID

  'Shortcuts to mCreep Objects
  Private mGame As dGame


  Private heroThumb As ctrlHero_Thumb
  'Private TeamPositionColor As SolidColorBrush

  'Mods
  'Private myMods As New ModifierList



  'parent stuff
  ' Public mDDOwner As DDObject
  ' Public mMyHeroOwner As HeroBuild
  ' Public mMyTeamOwner As dTeam
  ' Public mOwnerType As eEntity

  'timestuff
  Private mCurrentTime As ddFrame
  Private mCurrentGold As Integer
  Private mCurrentXp As Integer
  Private mCurrentLevel As Integer


  'tem,p
  Dim counter As Integer = 0

  'Private isNewBuild As Boolean = False

  Private itemList As New Item_List
  Private ctrlItem_Thumbs As New List(Of ctrlItem_Thumb)
  Private item1 As ctrlItem_Thumb
  Private item2 As ctrlItem_Thumb
  Private item3 As ctrlItem_Thumb
  Private item4 As ctrlItem_Thumb
  Private item5 As ctrlItem_Thumb
  Private item6 As ctrlItem_Thumb


  'treant eyes in the forest, invoker spells, doom creep spells
  Private tempabilitylist As New List(Of Ability_Info)
  Private tempCtrlAbility_Thumbs As New List(Of ctrlAblityThumb)

  'permanent abilities. exlcudes treant eyes in the forest, invoker invoked abs etc.
  Private permCtrlAtility_thumbs As New List(Of ctrlAblityThumb)

  'both permanent and temp abilities
  Private allCtrlAbility_thumbs As New List(Of ctrlAblityThumb)


  Private ItemPickerList As New Item_List



  ''team struff
  'Private mTeamname As eTeamName
  'Private mTeamPosition As Integer
  'Private mTeamEnemyTarget As dvID = Nothing
  'Private mTeamFriendlyTarget As dvID = Nothing
  'Private mTargetFriendBias As Boolean

  Private isLoading As Boolean = True


  Public Event DevNotes(thenotes As List(Of String))

  Public Event isDirty(gameentity As iGameEntity) Implements iControlIO.isDirty

  Public Event SelectedChanged(gameentity As iGameEntity) Implements iControlIO.SelectedChanged

  Private mIsSelected As Boolean = False

  'dev controls
  Dim lbl1 As New ctrlBody_Paragraph()
  Dim lbl2 As New ctrlBody_Paragraph()


  'pet stuff
  Private petsLoaded As Boolean = False
  Private petcontrols As List(Of ctrlPetStack)

  'special cases
  Private mIsMeepo As Boolean = False
  Private mIsSpirit_Bear As Boolean = False

  Private mMyMods As List(Of Modifier)
  Private dbNames As FriendlyName_Database

  '  Private mGame As dGame
  Private mLog As Logging
#End Region

  Public Sub New(pet As Pet_Instance)
    InitializeComponent()
    mGame = pet.mGame
    mLog = theLog
    '   dbNames = namesdb
    '   mGame = thegame
    'mID = New dvID(Guid.NewGuid, "Creep Badge Added", eEntity.ctrlCreep_Badge)
    'mDDOwner = theparent
    'SetOwner()
    LoadUI()


    FillBadge(pet)

    SetSelected(False)

#If devmode Then

    'lbl1.Content = "herobuild: " & mHeroBuild.ID.ToString
    spnlDevDetails.Children.Add(lbl1)


    ' lbl2.Content = "Herobuildstate: " & mHeroBuildState.ID.ToString
    spnlDevDetails.Children.Add(lbl2)

#End If
  End Sub


  Public Sub FillBadge(pet As Pet_Instance)
    isLoading = True
    If pet Is Nothing Then Exit Sub

    mPet = pet
    mGame = mPet.mGame
    lblHeroName.Content = mPet.DisplayName




    tempabilitylist.Clear()



    RefreshAbilityBar()
    mCurrentTime = mGame.TimeKeeper.GameStart
    RefreshAll()



    isLoading = False


#If devmode Then
    lbl1.LayoutRoot.Text = "herobuild: " & mHeroBuild.ID.FriendlyGuid
    lbl2.LayoutRoot.Text = "Herobuildstate: " & mHeroBuildState.ID.FriendlyGuid
#End If

  End Sub



  Public Sub SetCurrentTime(thetime As ddFrame)
    ' xxxx()
    mCurrentTime = thetime


    RefreshTime()

    RefreshBadgeUI()
    RefreshCurrentAbilities()
    RefreshCurrentItems()
    RefreshPetSequence()
  End Sub

  Private Sub RefreshTime()
    mCurrentLevel = mPet.GetLevelForTime(mCurrentTime)

    'If mOwnerType = eEntity.Hero_Build Then
    '  If mMyHeroOwner.Name = eHeroName.untLone_Druid Then
    '    mCurrentGold = mCreep.GetCurrentGold(mCurrentTime) + Constants.cStartingGold
    '    mCurrentXp = mCreep.GetCurrentXP(mCurrentTime)
    '  End If
    'End If

  End Sub


  Private Sub RefreshBadgeUI()
    lblGoldTotal.Content = "Gold: " & mCurrentGold.ToString
    lblXPTotal.Content = "Exp: " & mCurrentXp.ToString
    heroThumb.SetHeroLevel(mCurrentLevel)
  End Sub


  'Public Sub SetPriority( theprio As ePriorityGoldXP)
  '  If mCreep Is Nothing Then Exit Sub

  '  mCreep.mBuild.PriorityLevel = theprio
  '  mCreep.TheXPCurve = PageHandler.manEconomy.GetXPCurve(theprio)
  '  mCreep.TheGoldCurve = PageHandler.manEconomy.GetGoldCurve(theprio)
  '  RefreshAll()
  'End Sub

  'Public Sub SetTargets(theenemytarget As dvID, thefriendlytarget As dvID, isfriendbias As Boolean)
  '  If mTeamEnemyTarget Is Nothing Or mTeamFriendlyTarget Is Nothing Then
  '    mTeamEnemyTarget = theenemytarget
  '    mTeamFriendlyTarget = thefriendlytarget
  '    mTargetFriendBias = isfriendbias

  '    mCreep.SetTargets(mTeamEnemyTarget, mTeamFriendlyTarget, mTargetFriendBias)
  '  Else
  '    If mTeamEnemyTarget.GuidID = theenemytarget.GuidID And mTeamFriendlyTarget.GuidID = thefriendlytarget.GuidID And mTargetFriendBias = isfriendbias Then Exit Sub
  '    mTeamEnemyTarget = theenemytarget
  '    mTeamFriendlyTarget = thefriendlytarget
  '    mTargetFriendBias = isfriendbias

  '    mCreep.SetTargets(mTeamEnemyTarget, mTeamFriendlyTarget, mTargetFriendBias)
  '  End If

  'End Sub
  Private Sub LoadUI()
    isLoading = True

    heroThumb = New ctrlHero_Thumb()
    heroThumb.LoadHero(Nothing, Nothing, Nothing)

    heroThumb.VerticalAlignment = Windows.VerticalAlignment.Top

    spnlHeroPortrait.Children.Add(heroThumb)

    AddHandler heroThumb.thumbImage.MouseLeftButtonDown, AddressOf Me_selectedChanged






    'cbxPrioritySelect.Items.Add("Priority 1")
    'cbxPrioritySelect.Items.Add("Priority 2")
    'cbxPrioritySelect.Items.Add("Priority 3")
    'cbxPrioritySelect.Items.Add("Priority 4")
    'cbxPrioritySelect.Items.Add("Priority 5")


    item1 = New ctrlItem_Thumb()
    AddHandler item1.SelectedChanged, AddressOf ChildControl_SelectedChanged
    AddHandler item1.isDirty, AddressOf ChildControl_isDirty
    item1.SetValue(Grid.ColumnProperty, 1)
    Me.spnlCurrItemsRow1.Children.Add(item1)
    ctrlItem_Thumbs.Add(item1)

    item2 = New ctrlItem_Thumb()
    AddHandler item2.SelectedChanged, AddressOf ChildControl_SelectedChanged
    AddHandler item2.isDirty, AddressOf ChildControl_isDirty
    item2.SetValue(Grid.ColumnProperty, 1)
    Me.spnlCurrItemsRow1.Children.Add(item2)
    ctrlItem_Thumbs.Add(item2)

    item3 = New ctrlItem_Thumb()
    AddHandler item3.SelectedChanged, AddressOf ChildControl_SelectedChanged
    AddHandler item3.isDirty, AddressOf ChildControl_isDirty
    item3.SetValue(Grid.ColumnProperty, 1)
    Me.spnlCurrItemsRow1.Children.Add(item3)
    ctrlItem_Thumbs.Add(item3)

    item4 = New ctrlItem_Thumb()
    AddHandler item4.SelectedChanged, AddressOf ChildControl_SelectedChanged
    AddHandler item4.isDirty, AddressOf ChildControl_isDirty
    item4.SetValue(Grid.ColumnProperty, 1)
    Me.spnlCurrItemsRow2.Children.Add(item4)
    ctrlItem_Thumbs.Add(item4)

    item5 = New ctrlItem_Thumb()
    AddHandler item5.SelectedChanged, AddressOf ChildControl_SelectedChanged
    AddHandler item5.isDirty, AddressOf ChildControl_isDirty
    item5.SetValue(Grid.ColumnProperty, 1)
    Me.spnlCurrItemsRow2.Children.Add(item5)
    ctrlItem_Thumbs.Add(item5)

    item6 = New ctrlItem_Thumb()
    AddHandler item6.SelectedChanged, AddressOf ChildControl_SelectedChanged
    AddHandler item6.isDirty, AddressOf ChildControl_isDirty
    item6.SetValue(Grid.ColumnProperty, 1)
    Me.spnlCurrItemsRow2.Children.Add(item6)
    ctrlItem_Thumbs.Add(item6)

    'add ability controls
    For i As Integer = 0 To 14
      CreateAbilityThumb(Nothing, 0, "")
    Next




    AddUIHandlers()

    AddHandler lblPlusMinus.MouseLeftButtonDown, AddressOf lblPlusMinus_MouseLeftButtonDown
    AddHandler lblDetails.MouseLeftButtonDown, AddressOf lblPlusMinus_MouseLeftButtonDown

    lblPlusMinus.Content = "+"
    ' spnlItemBuildHeading.Visibility = Windows.Visibility.Collapsed
    '  wpnlItem_Picker.Visibility = Windows.Visibility.Collapsed
    ' spnlAbilityBuildHeading.Visibility = Windows.Visibility.Collapsed
    ' wpnlAbility_Picker.Visibility = Windows.Visibility.Collapsed
    ' lblAbilityBuild.Visibility = Windows.Visibility.Collapsed
    ' spnlDivider.Visibility = Windows.Visibility.Collapsed
    '  dpnlPriorityTarget.Visibility = Windows.Visibility.Collapsed
    '  spnlBuildHeading.Visibility = Windows.Visibility.Collapsed
    '  spnlHeroBuild.Visibility = Windows.Visibility.Collapsed

    '  tbxNewBuildName.Visibility = Windows.Visibility.Collapsed
    '  btnNewBuildSave.Visibility = Windows.Visibility.Collapsed
    '  btnCancelBuildSave.Visibility = Windows.Visibility.Collapsed

    spnlPetHeading.Visibility = Windows.Visibility.Collapsed
    spnlPets.Visibility = Windows.Visibility.Collapsed

    rectDividerMid.Visibility = Windows.Visibility.Visible

    lblBuildName.Visibility = Windows.Visibility.Collapsed

    If mIsMeepo Or mIsSpirit_Bear Then
      spnlCurrItemsRow1.Visibility = True
      spnlCurrItemsRow1.Visibility = True
    Else
      spnlCurrItemsRow1.Visibility = Windows.Visibility.Collapsed
      spnlCurrItemsRow2.Visibility = Windows.Visibility.Collapsed
    End If

    If mIsSpirit_Bear Then
      lblGoldTotal.Visibility = Windows.Visibility.Visible
      lblXPTotal.Visibility = Windows.Visibility.Visible


    Else
      lblGoldTotal.Visibility = Windows.Visibility.Collapsed
      lblXPTotal.Visibility = Windows.Visibility.Collapsed


    End If

    '  spnlAbilityBuildHeading.Visibility = False
    ' wpnlAbility_Picker.Visibility = False
    ' spnlBuildHeading.Visibility = Windows.Visibility.Collapsed

    If Not mIsMeepo Or Not mIsSpirit_Bear Then
      dpnlPlusMinus.Visibility = Windows.Visibility.Collapsed
      lblPlusMinus.Visibility = Windows.Visibility.Collapsed
      rectDividerMid.Visibility = Windows.Visibility.Collapsed
    End If

    isLoading = False
  End Sub

  Private Sub CreateAbilityThumb(theability As Ability_Info, abilitylevel As Integer, friendlyname As String) 'As ctrlAbilityThumb
    Dim newthumb As New ctrlAblityThumb()
    newthumb.LoadNewAbility(theability, mGame, friendlyname)
    AddHandler newthumb.SelectedChanged, AddressOf ChildControl_SelectedChanged
    AddHandler newthumb.isDirty, AddressOf ChildControl_isDirty



    wpnlAbilities.Children.Add(newthumb)
    allCtrlAbility_thumbs.Add(newthumb)


  End Sub

  Private Function CreateItemThumbPicker(theindex As Integer, theitem As Item_Info) As ctrlItem_Thumb_Picker_3

    Dim buildsfrom = mGame.dbItems.GetItemInfosNoParent(theitem.MadeFromItemNames)
    Dim buildsto = mGame.dbItems.GetItemInfosNoParent(theitem.BuildsToNames)

    Dim newthumb As New ctrlItem_Thumb_Picker_3(theindex, mGame)
    newthumb.LoadItem(theindex, theitem, buildsfrom, buildsto, dbImages, mGame)
    '  AttachItemPickerHandlers(newthumb)



    Return newthumb
  End Function
  Private Sub RefreshHeroThumb()
    'portrait
    Dim creepcol As New SolidColorBrush(mPet.MyColor)
    heroThumb.LoadPet(mPet, creepcol, Nothing)

    heroThumb.SetUnresponsive(69)
    Dim hcolor As SolidColorBrush = creepcol

    Dim dimcolor = Helpers.GetTransparencyBrush(PageHandler.dbColors.TrasparencyGlobalValue, hcolor)
    rectBackColor.Fill = dimcolor

  End Sub

  Private Sub RefreshDevDetails()
#If devmode Then
    spnlDevDetails.Visibility = Windows.Visibility.Visible
    dpnlDevPlusMinus.Visibility = Windows.Visibility.Visible

    spnlDevDetails.Children.Clear()

    Dim pstr As String = "State Parent: " & mHeroBuildState.mBuild.ParentIDItem.FriendlyGuid
    Dim ppara As New ctrlBody_Paragraph
    ppara.LayoutRoot.Text = pstr
    spnlDevDetails.Children.Add(ppara)

    Dim ID As String = "   State ID: " & mHeroBuildState.mBuild.IDItem.FriendlyGuid
    Dim ipara As New ctrlBody_Paragraph
    ipara.LayoutRoot.Text = ID
    spnlDevDetails.Children.Add(ipara)

    Dim chstr As String = "   State Child: " & mHeroBuildState.mBuild.ChildIDItem.FriendlyGuid
    Dim cpara As New ctrlBody_Paragraph
    cpara.LayoutRoot.Text = chstr
    spnlDevDetails.Children.Add(cpara)


    spnlDevDetails.Children.Add(lbl1)

    spnlDevDetails.Children.Add(lbl2)
#Else
    spnlDevDetails.Visibility = Windows.Visibility.Collapsed
    dpnlDevPlusMinus.Visibility = Windows.Visibility.Collapsed
#End If

  End Sub
  Private Sub RefreshCurrentItems()



    'hero specific stuff
    If Not mPet Is Nothing Then

      RemoveUIHandlers()
      spnlStash.Children.Clear()


      itemList = mPet.ItemInventory.GetItemsAtTime(mCurrentTime)
      For i As Integer = 0 To ctrlItem_Thumbs.Count - 1
        If Not itemList Is Nothing Then
          If itemList.Count > i Then
            ctrlItem_Thumbs.Item(i).LoadItem(itemList.Item(i), mGame)
          Else
            ctrlItem_Thumbs.Item(i).LoadItem(Nothing, Nothing)
          End If
        Else
          ctrlItem_Thumbs.Item(i).LoadItem(Nothing, Nothing)
        End If

      Next

      If itemList.Count > 6 Then
        spnlStashContainer.Visibility = Windows.Visibility.Visible

        For i As Integer = 6 To itemList.Count - 1
          Dim stashthumb As New ctrlItem_Thumb_Stash()
          stashthumb.LoadItem(itemList.Item(i))
          spnlStash.Children.Add(stashthumb)
        Next

      Else
        spnlStashContainer.Visibility = Windows.Visibility.Collapsed
      End If

      AddUIHandlers()
    End If



  End Sub

  Private Sub RefreshAbilityBar()
    If mPet.AbilityInventory.AbilitiesListedByUIPosition Is Nothing Then
      wpnlAbilities.Visibility = Windows.Visibility.Collapsed
      Exit Sub
    Else
      wpnlAbilities.Visibility = Windows.Visibility.Visible
    End If
    Dim theabs = mPet.AbilityInventory.AbilitiesListedByUIPosition

    permCtrlAtility_thumbs.Clear()
    tempCtrlAbility_Thumbs.Clear()
    For i As Integer = 0 To theabs.Count - 1
      Dim theab = theabs.Item(i)

      theab.CurrentLevel = mPet.AbilityInventory.GetAbilityLevelAtHeroLevel(theab, 0)
      allCtrlAbility_thumbs.Item(i).LoadNewAbility(theab, mGame, theab.DisplayName) ', ablevel)
      allCtrlAbility_thumbs.Item(i).Visibility = Windows.Visibility.Visible
      permCtrlAtility_thumbs.Add(allCtrlAbility_thumbs.Item(i))
    Next


    'End Select
    For i As Integer = (theabs.Count + tempabilitylist.Count) To allCtrlAbility_thumbs.Count - 1
      allCtrlAbility_thumbs.Item(i).Visibility = Windows.Visibility.Collapsed
    Next
  End Sub
  Private Sub RefreshCurrentAbilities()

    RemoveUIHandlers()
    Dim currabilities As New List(Of Integer)


    'hero specific stuff
    If Not mPet Is Nothing Then


      'abilities
      currabilities = mPet.AbilityInventory.GetActiveAbilitiesByLevel(mCurrentLevel)

      For i As Integer = 0 To currabilities.Count - 1
        'If currabilities.Item(i) > 0 Then
        '  Dim x = 2
        'End If
        allCtrlAbility_thumbs.Item(i).SetLevel(currabilities.Item(i))
      Next
    End If


    AddUIHandlers()
  End Sub


  'Public Sub RefreshItemSequence()
  '  If Not mCreep.mOwnerType = eEntity.Hero_Instance Then
  '    wpnlItem_Picker.Visibility = Windows.Visibility.Collapsed
  '    Exit Sub
  '  End If
  '  If mOwnerType = eEntity.Hero_Build Then
  '    If mMyHeroOwner.Name = eHeroName.untLone_Druid Or mMyHeroOwner.Name = eHeroName.untMeepo Then
  '      If mMyHeroOwner.GetItemsForPet Is Nothing Then Exit Sub
  '      wpnlItem_Picker.Children.Clear()


  '      Dim itemseq = mMyHeroOwner.GetItemsForPet
  '      For i As Integer = 0 To itemseq.Count - 1
  '        Dim curitem = itemseq.Item(i)


  '        If Not curitem.mItemisFromDisassembly Then

  '          Dim newpicker = CreateItemThumbPicker(i, curitem)
  '          wpnlItem_Picker.Children.Add(newpicker)
  '        End If

  '      Next

  '      If itemseq.Count = 0 Then
  '        Dim emptyitem = mGame.dbItems.GetItemInfo(eItemname.None, mCreep.mIDItem, Constants.cDefaultLifetime)
  '        Dim futoo = CreateItemThumbPicker(itemseq.Count, emptyitem)
  '        wpnlItem_Picker.Children.Add(futoo)


  '      End If

  '      counter += 1


  '    End If
  '  End If


  'End Sub

  'Private Sub AttachItemPickerHandlers(thepicker As ctrlItem_Thumb_Picker_3)
  '  AddHandler thepicker.SelectedChanged, AddressOf ChildControl_SelectedChanged
  '  AddHandler thepicker.isDirty, AddressOf ChildControl_isDirty
  '  AddHandler thepicker.isDeleted, AddressOf ItemPicker_isDeleted
  '  AddHandler thepicker.hasInsert, AddressOf ItemPicker_hasInsert

  'End Sub



  Private Sub RefreshPetSequence()

    If mPet.PetsOwned Is Nothing Then Exit Sub

    If Not petsLoaded Then
      spnlPets.Children.Clear()
      petcontrols = New List(Of ctrlPetStack)


      For i As Integer = 0 To mPet.PetsOwned.Count - 1
        Dim curcreepstackctrl As New ctrlPetStack()

        Dim curcreeps = mPet.PetsOwned.Item(i)
        curcreepstackctrl.Load(curcreeps, mPet, mPet.Team, mPet.TeamPosition, mGame, dbNames, PageHandler.theLog)

        petcontrols.Add(curcreepstackctrl)
        spnlPets.Children.Add(curcreepstackctrl)
      Next
    End If


    'set visibility

    If petcontrols.Count > 0 Then
      For i As Integer = 0 To petcontrols.Count - 1
        petcontrols.Item(i).SetTime(mCurrentTime)
      Next
    End If
  End Sub
  Private Sub AddUIHandlers()

#If devmode Then
    AddHandler lblBuildName.MouseLeftButtonDown, AddressOf lblBuildName_MouseLeftButtonDown
#End If
  End Sub

  Private Sub RemoveUIHandlers()

#If devmode Then
    RemoveHandler lblBuildName.MouseLeftButtonDown, AddressOf lblBuildName_MouseLeftButtonDown
#End If

  End Sub
  Private Sub RefreshAll()

    RefreshTime()

    RefreshHeroThumb()


    RefreshDevDetails()


    RefreshCurrentItems()

    RefreshCurrentAbilities()

    ' RefreshItemSequence()


    RefreshPetSequence()

#If devmode Then
    lbl1.LayoutRoot.Text = "herobuild: " & mHeroBuild.ID.FriendlyGuid
    lbl2.LayoutRoot.Text = "Herobuildstate: " & mHeroBuildState.ID.FriendlyGuid
#End If

  End Sub





  Private Sub lblPlusMinus_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs)
    If lblPlusMinus.Content = "+" Then
      lblPlusMinus.Content = "-"
      '  spnlItemBuildHeading.Visibility = Windows.Visibility.Visible
      ' wpnlItem_Picker.Visibility = Windows.Visibility.Visible
      'spnlAbilityBuildHeading.Visibility = Windows.Visibility.Visible
      'wpnlAbility_Picker.Visibility = Windows.Visibility.Visible
      'spnlDivider.Visibility = Windows.Visibility.Visible
      'dpnlPriorityTarget.Visibility = Windows.Visibility.Visible
      'spnlBuildHeading.Visibility = Windows.Visibility.Visible
      'spnlHeroBuild.Visibility = Windows.Visibility.Visible
      spnlPetHeading.Visibility = Windows.Visibility.Visible
      spnlPets.Visibility = Windows.Visibility.Visible


      rectDividerMid.Visibility = Windows.Visibility.Collapsed


      If mIsMeepo Or mIsSpirit_Bear Then
        spnlCurrItemsRow1.Visibility = True
        spnlCurrItemsRow1.Visibility = True
      Else
        spnlCurrItemsRow1.Visibility = Windows.Visibility.Collapsed
        spnlCurrItemsRow2.Visibility = Windows.Visibility.Collapsed
      End If

      If mIsSpirit_Bear Then
        ' lblItemBuild.Visibility = Windows.Visibility.Visible

        'spnlItemBuildHeading.Visibility = True
        'wpnlItem_Picker.Visibility = True
        spnlStashContainer.Visibility = True

      Else
        ' lblItemBuild.Visibility = Windows.Visibility.Collapsed
        'spnlItemBuildHeading.Visibility = False
        ' wpnlItem_Picker.Visibility = False
        spnlStashContainer.Visibility = False

      End If

      ' spnlAbilityBuildHeading.Visibility = False

      ' wpnlAbility_Picker.Visibility = False
      ' spnlBuildHeading.Visibility = Windows.Visibility.Collapsed
    Else
      lblPlusMinus.Content = "+"
      '  spnlItemBuildHeading.Visibility = Windows.Visibility.Collapsed
      'wpnlItem_Picker.Visibility = Windows.Visibility.Collapsed
      'spnlAbilityBuildHeading.Visibility = Windows.Visibility.Collapsed
      'wpnlAbility_Picker.Visibility = Windows.Visibility.Collapsed
      spnlDivider.Visibility = Windows.Visibility.Collapsed
      'dpnlPriorityTarget.Visibility = Windows.Visibility.Collapsed
      'spnlBuildHeading.Visibility = Windows.Visibility.Collapsed
      'spnlHeroBuild.Visibility = Windows.Visibility.Collapsed
      spnlPetHeading.Visibility = Windows.Visibility.Collapsed
      spnlPets.Visibility = Windows.Visibility.Collapsed

      rectDividerMid.Visibility = Windows.Visibility.Visible
      'lblAbilityBuild.Visibility = False
    End If






  End Sub

  Private Sub ChildControl_isDirty(gameentity As iGameEntity)

    If Not isLoading Then
      Select Case gameentity.EntityName


        Case eEntity.ctrlItem_Thumb_Picker_3


          Dim tctrl As ctrlItem_Thumb_Picker_3 = DirectCast(gameentity, ctrlItem_Thumb_Picker_3)
          ' mCreep.ReplaceItemAtIndex(tctrl.mItem, tctrl.mItem.mIndex)

          'RefreshItemSequence()
          RefreshCurrentItems()

        Case eEntity.ctrlItem_Thumb
          'RefreshItemSequence()

        Case eEntity.ctrlAbilityThumb
          RefreshCurrentAbilities()

        Case Else
          Dim x = 2
      End Select


      RaiseEvent isDirty(gameentity)
    End If

  End Sub


  'Private Sub ItemPicker_isDeleted(thectrl As ctrlItem_Thumb_Picker_3)
  '  mCreep.DeleteItemAtIndex(thectrl.mItem.mIndex)

  '  RefreshItemSequence()
  '  RefreshCurrentItems()

  '  RaiseEvent isDirty(New DDObject(Me, eEntity.ctrlHero_Badge, Me.mCreep.mIDItem, dbNames))
  'End Sub

  'Private Sub ItemPicker_hasInsert(thectrl As ctrlItem_Thumb_Picker_3)

  '  Dim empty_item = mGame.dbItems.GetItemInfo(eItemname.None, mCreep.mIDItem, Constants.cDefaultLifetime)
  '  mCreep.InsertItemAtIndex(thectrl.mItem.mIndex + 1, empty_item)

  '  RefreshItemSequence()
  '  RefreshCurrentItems()

  '  RaiseEvent isDirty(New DDObject(Me, eEntity.ctrlHero_Badge))
  'End Sub


  Private Sub ChildControl_SelectedChanged(gameentity As iGameEntity)

    RaiseEvent SelectedChanged(gameentity)
  End Sub



  Public ReadOnly Property IsSelected As Boolean Implements iControlIO.IsSelected
    Get
      Return mIsSelected
    End Get
  End Property

  Public Sub SetSelected(isselected As Boolean) Implements iControlIO.SetSelected
    If isselected Then
      mIsSelected = True
      rectSelected.Visibility = Windows.Visibility.Visible
    Else
      mIsSelected = False
      rectSelected.Visibility = Windows.Visibility.Collapsed
    End If
  End Sub

  Private Sub Me_selectedChanged(sender As Object, e As MouseButtonEventArgs)
    If mIsSelected Then
      SetSelected(False)
    Else
      SetSelected(True)
    End If


    RaiseEvent SelectedChanged(Me)
  End Sub
End Class
