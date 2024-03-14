#Const devmode = False

Imports DotaMasterWPF.PageHandler
Public Class ctrlHero_Badge
  Implements iControlIO, iGameEntity


#Region "Vars"
  Private mID As dvID
  'Private mHeroInst As HeroInstance
  Private mGame As dGame

  Private mShares As Integer
  Private mTotalShares As Integer

  'keeps track of changes to current selected build
  Public WithEvents mHeroInstState As HeroInstance

  ' Private mBuilds As Build_List
  Private heroThumb As ctrlHero_Thumb
  Private statbadge As ctrlStatBadge


  'Mods
  ' Private myMods As New ModifierList


  'timestuff
  'Private mCurrentTime As ddFrame
  'Private mCurrentGold As Integer
  'Private mCurrentXp As Integer
  'Private mCurrentLevel As Integer


  'tem,p
  Dim counter As Integer = 0

  Private isNewBuild As Boolean = False

  Private itemList As New Item_List
  Private ctrlItem_Thumbs As New List(Of ctrlItem_Thumb)
  Private item1 As ctrlItem_Thumb
  Private item2 As ctrlItem_Thumb
  Private item3 As ctrlItem_Thumb
  Private item4 As ctrlItem_Thumb
  Private item5 As ctrlItem_Thumb
  Private item6 As ctrlItem_Thumb

  Private mBodyTextBrush As SolidColorBrush
  Private mHeadingTextBrush As SolidColorBrush

  'Private abilitylist As New List(Of Ability_Info)
  'treant eyes in the forest, invoker spells, doom creep spells
  Private tempabilitylist As New List(Of Ability_Info)
  Private tempCtrlAbility_Thumbs As New List(Of ctrlAblityThumb)

  'permanent abilities. exlcudes treant eyes in the forest, invoker invoked abs etc.
  Private permCtrlAtility_thumbs As New List(Of ctrlAblityThumb)

  'both permanent and temp abilities
  Private allCtrlAbility_thumbs As New List(Of ctrlAblityThumb)

  Private isLoading As Boolean = True


  Public Event DevNotes(thenotes As List(Of String))



  Public Event SelectedChanged(gameentity As iGameEntity) Implements iControlIO.SelectedChanged

  Public Event TargetsChanged(gameentity As iGameEntity)

  Public Event NewHeroPicked(newherobuild As HeroBuild, oldhero As HeroInstance, heroteam As dTeam, teamposition As Integer)

  Private mIsSelected As Boolean = False

  'dev controls
  Dim lbl1 As New ctrlBody_Paragraph()
  Dim lbl2 As New ctrlBody_Paragraph()

  'pet stuff
  Private petsLoaded As Boolean = False
  Private creepcontrols As List(Of ctrlPetStack)

  'badgeinfo
  Private mBadgesPosition As Integer
  Private mBadgesTeam As dTeam

  'test vars
  Shared itemseqcount As Integer = 0
  Shared itemtime As Integer

  Shared abilityseqcount As Integer = 0
  Shared abtime As Integer


#End Region

#Region "Delegates"
  Public Event isDirty(gameentity As iGameEntity) Implements iControlIO.isDirty
#End Region

  Public Sub New(Badgesteam As dTeam, badgesposition As Integer, thegame As dGame, _
                 headingtextbrush As SolidColorBrush, bodytextbrush As SolidColorBrush)
    InitializeComponent()

    mGame = thegame
    mID = New dvID(Guid.NewGuid, "HeroBadge Added", eEntity.ctrlHero_Badge)
    LoadUI()
    mBadgesPosition = badgesposition
    mBadgesTeam = Badgesteam

    mBodyTextBrush = bodytextbrush
    mHeadingTextBrush = headingtextbrush

    Select Case mBadgesTeam.TeamName
      Case eTeamName.Radiant
        colDireSwatch.Width = New GridLength(0)
      Case eTeamName.Dire
        colRadSwatch.Width = New GridLength(0)
      Case Else
        Throw New InvalidOperationException
    End Select

    SetSelected(False)

#If devmode Then

    'lbl1.Content = "herobuild: " & mHeroInst.ID.ToString
    spnlDevDetails.Children.Add(lbl1)


    ' lbl2.Content = "Herobuildstate: " & mHeroInstState.ID.ToString
    spnlDevDetails.Children.Add(lbl2)

#End If
  End Sub

  Public Sub FillBadge(thehero As HeroInstance)

    isLoading = True
    If thehero Is Nothing Then Exit Sub

    thehero.mTeam = mBadgesTeam
    thehero.mTeamPosition = mBadgesPosition
    ' mGame = theherobuild.mGame
    mHeroInstState = thehero

    Dim currenttime = mGame.TimeKeeper.CurrentTime
    RefreshAll(mHeroInstState.GetLevelForTime(currenttime), currenttime)

  End Sub

  Public Sub SetCurrentTime(currenttime As ddFrame)
    ' xxxx()
    Dim currentherolevel = mHeroInstState.GetLevelForTime(currenttime)

    RefreshBadgeUI(currentherolevel, currenttime)
    RefreshCurrentAbilities(currentherolevel, currenttime)
    RefreshCurrentItems(currenttime)
    RefreshPetSequence(currenttime)
  End Sub

  Private Sub LoadUI()
    isLoading = True

    heroThumb = New ctrlHero_Thumb()
    heroThumb.LoadHero(Nothing, Nothing, Nothing)
    heroThumb.VerticalAlignment = Windows.VerticalAlignment.Top



    AddHandler heroThumb.btnChangeHero.Click, AddressOf heroThumb_btnChangeHeroClicked
    AddHandler heroThumb.thumbImage.MouseLeftButtonDown, AddressOf Me_selectedChanged

    statbadge = New ctrlStatBadge

    AddHandler statbadge.SelectedChanged, AddressOf ChildControl_SelectedChanged




    item1 = New ctrlItem_Thumb()
    AddHandler item1.SelectedChanged, AddressOf ChildControl_SelectedChanged
    '  AddHandler item1.isDirty, AddressOf ChildControl_isDirty
    item1.SetValue(Grid.ColumnProperty, 1)
    Me.spnlCurrItemsRow1.Children.Add(item1)
    ctrlItem_Thumbs.Add(item1)

    item2 = New ctrlItem_Thumb()
    AddHandler item2.SelectedChanged, AddressOf ChildControl_SelectedChanged
    '  AddHandler item2.isDirty, AddressOf ChildControl_isDirty
    item2.SetValue(Grid.ColumnProperty, 1)
    Me.spnlCurrItemsRow1.Children.Add(item2)
    ctrlItem_Thumbs.Add(item2)

    item3 = New ctrlItem_Thumb()
    AddHandler item3.SelectedChanged, AddressOf ChildControl_SelectedChanged
    ' AddHandler item3.isDirty, AddressOf ChildControl_isDirty
    item3.SetValue(Grid.ColumnProperty, 1)
    Me.spnlCurrItemsRow1.Children.Add(item3)
    ctrlItem_Thumbs.Add(item3)

    item4 = New ctrlItem_Thumb()
    AddHandler item4.SelectedChanged, AddressOf ChildControl_SelectedChanged
    '   AddHandler item4.isDirty, AddressOf ChildControl_isDirty
    item4.SetValue(Grid.ColumnProperty, 1)
    Me.spnlCurrItemsRow2.Children.Add(item4)
    ctrlItem_Thumbs.Add(item4)

    item5 = New ctrlItem_Thumb()
    AddHandler item5.SelectedChanged, AddressOf ChildControl_SelectedChanged
    ' AddHandler item5.isDirty, AddressOf ChildControl_isDirty
    item5.SetValue(Grid.ColumnProperty, 1)
    Me.spnlCurrItemsRow2.Children.Add(item5)
    ctrlItem_Thumbs.Add(item5)

    item6 = New ctrlItem_Thumb()
    AddHandler item6.SelectedChanged, AddressOf ChildControl_SelectedChanged
    ' AddHandler item6.isDirty, AddressOf ChildControl_isDirty
    item6.SetValue(Grid.ColumnProperty, 1)
    Me.spnlCurrItemsRow2.Children.Add(item6)
    ctrlItem_Thumbs.Add(item6)

    'add ability controls
    For i As Integer = 0 To 14
      CreateAbilityThumb(Nothing, 0)
    Next

    AddHandler lblPlusMinus.MouseLeftButtonDown, AddressOf lblPlusMinus_MouseLeftButtonDown
    AddHandler lblDetails.MouseLeftButtonDown, AddressOf lblPlusMinus_MouseLeftButtonDown

    lblPlusMinus.Content = "+"

    spnlPetHeading.Visibility = Windows.Visibility.Collapsed
    spnlPets.Visibility = Windows.Visibility.Collapsed

    rectDividerMid.Visibility = Windows.Visibility.Visible



    isLoading = False
  End Sub

  Private Sub CreateAbilityThumb(theability As Ability_Info, abilitylevel As Integer)
    Dim newthumb As New ctrlAblityThumb()

    AddHandler newthumb.SelectedChanged, AddressOf ChildControl_SelectedChanged
    '   AddHandler newthumb.isDirty, AddressOf ChildControl_isDirty



    wpnlAbilities.Children.Add(newthumb)
    allCtrlAbility_thumbs.Add(newthumb)


  End Sub

  Public Sub ChangeAppearance(appearance As eBadgeAppearance)
    Select Case appearance
      Case eBadgeAppearance.Full
        wpnlAbilities.Visibility = Windows.Visibility.Visible
        wpnlItems.Visibility = Windows.Visibility.Visible
        statbadge.Visibility = Windows.Visibility.Visible
        dpnlPlusMinus.Visibility = Windows.Visibility.Visible
        spnlStashContainer.Visibility = Windows.Visibility.Visible

        'change when buff visualization implemented
        spnlBuffContainer.Visibility = Windows.Visibility.Collapsed

        LayoutRoot.Width = 310
      Case eBadgeAppearance.None
        wpnlAbilities.Visibility = Windows.Visibility.Collapsed
        wpnlItems.Visibility = Windows.Visibility.Collapsed
        statbadge.Visibility = Windows.Visibility.Collapsed
        dpnlPlusMinus.Visibility = Windows.Visibility.Collapsed
        spnlStashContainer.Visibility = Windows.Visibility.Collapsed
        spnlBuffContainer.Visibility = Windows.Visibility.Collapsed
        LayoutRoot.Width = 80
      Case eBadgeAppearance.Stats
        wpnlAbilities.Visibility = Windows.Visibility.Collapsed
        wpnlItems.Visibility = Windows.Visibility.Collapsed
        statbadge.Visibility = Windows.Visibility.Visible
        dpnlPlusMinus.Visibility = Windows.Visibility.Collapsed
        spnlStashContainer.Visibility = Windows.Visibility.Collapsed
        spnlBuffContainer.Visibility = Windows.Visibility.Collapsed
        LayoutRoot.Width = 310
    End Select

  End Sub

  Public Sub SetSelected(isselected As Boolean) Implements iControlIO.SetSelected
    If isselected Then
      mIsSelected = True
      rectSelected.Visibility = Windows.Visibility.Visible
    Else
      mIsSelected = False
      rectSelected.Visibility = Windows.Visibility.Collapsed
    End If
  End Sub

  Public Sub calcmods() Implements iGameEntity.calcmods

  End Sub

#Region "Info"

  Public Property MyColor As Color Implements iGameEntity.MyColor
    Get
      Return mHeroInstState.MyColor
    End Get
    Set(value As Color)

    End Set
  End Property
  Public ReadOnly Property TeamPosition As Integer
    Get
      Return mHeroInstState.mTeamPosition
    End Get
  End Property

  Public ReadOnly Property IsSelected As Boolean Implements iControlIO.IsSelected
    Get
      Return mIsSelected
    End Get
  End Property

  Public Property DisplayName As String Implements iGameEntity.DisplayName
    Get
      Return "Hero Badge"
    End Get
    Set(value As String)

    End Set
  End Property

  Public Property EntityName As eEntity Implements iGameEntity.EntityName
    Get
      Return eEntity.ctrlHero_Badge
    End Get
    Set(value As eEntity)

    End Set
  End Property

  Public Property Id As dvID Implements iGameEntity.Id
    Get
      Return mID
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

#Region "Refreshers"

  Private Sub RefreshAll(currentherolevel As Integer, currenttime As ddFrame)

    spnlHeading.Children.Clear()
    Select Case mHeroInstState.mTeam.TeamName
      Case eTeamName.Radiant
        rectRadOwnerSwatch.Fill = New SolidColorBrush(mHeroInstState.MyColor)
        spnlHeading.Children.Add(heroThumb)
        spnlHeading.Children.Add(statbadge)
      Case eTeamName.Dire
        rectDireOwnerSwatch.Fill = New SolidColorBrush(mHeroInstState.MyColor)
        spnlHeading.Children.Add(statbadge)
        spnlHeading.Children.Add(heroThumb)
      Case Else
        Throw New NotImplementedException
    End Select



    RefreshHeroThumb(currentherolevel)

    RefreshDevDetails()

    RefreshCurrentItems(currenttime)

    RefreshAbilityBar(currentherolevel)

    RefreshCurrentAbilities(currentherolevel, currenttime)

    RefreshStats()

    RefreshPetSequence(currenttime)

#If devmode Then
    lbl1.LayoutRoot.Text = "herobuild: " & mHeroInst.ID.FriendlyGuid
    lbl2.LayoutRoot.Text = "Herobuildstate: " & mHeroInstState.ID.FriendlyGuid
#End If

  End Sub

  Private Sub RefreshStats()
    statbadge.LoadStats(mHeroInstState, mHeadingTextBrush, mBodyTextBrush, mGame.dbModifiers.GetStatsByParent(mHeroInstState), mGame)
  End Sub
  'Private Sub RefreshTime(currenttime As ddFrame)
  '  mCurrentLevel = mHeroInstState.GetLevelForTime(mCurrentTime)
  '  mCurrentGold = mHeroInstState.GetCurrentGold(mCurrentTime) '+ Constants.cStartingGold
  '  ' mCurrentXp = mHeroInstState.GetCurrentXP(mCurrentTime)
  'End Sub
  Private Sub RefreshBadgeUI(currentherolevel As Integer, currenttime As ddFrame)
    'lblResources.Content = "Resources: " & (mHeroInstState.XPCurve.Percentage * 100).ToString & "%"
    'lblGoldTotal.Content = "Gold: " & mCurrentGold.ToString
    'lblXPTotal.Content = "Exp: " & mCurrentXp.ToString
    'lblKills.Content = "Kills: " & mHeroInstState.GetKillsForGold(mGame.mTimeKeeper.CurrentTime, Constants.cGoldPerKill).ToString
    heroThumb.SetHeroLevel(currentherolevel)
    statbadge.SetTime(currenttime)
  End Sub

  Private Sub RefreshHeroThumb(herocurrentlevel As Integer)
    'portrait
    Dim hcolor As SolidColorBrush = New SolidColorBrush(mHeroInstState.MyColor)
    heroThumb.LoadHero(mHeroInstState, hcolor, mHeroInstState.GetHero.PrimaryStat)
    heroThumb.SetHeroLevel(herocurrentlevel)


    Dim dimcolor = Helpers.GetTransparencyBrush(PageHandler.dbColors.TrasparencyGlobalValue, hcolor)
    ' rectBackColor.Fill = dimcolor

  End Sub

  Private Sub RefreshDevDetails()
#If devmode Then
    spnlDevDetails.Visibility = Windows.Visibility.Visible
    dpnlDevPlusMinus.Visibility = Windows.Visibility.Visible

    spnlDevDetails.Children.Clear()

    Dim pstr As String = "State Parent: " & mHeroInstState.mBuild.ParentIDItem.FriendlyGuid
    Dim ppara As New ctrlBody_Paragraph
    ppara.LayoutRoot.Text = pstr
    spnlDevDetails.Children.Add(ppara)

    Dim ID As String = "   State ID: " & mHeroInstState.mBuild.IDItem.FriendlyGuid
    Dim ipara As New ctrlBody_Paragraph
    ipara.LayoutRoot.Text = ID
    spnlDevDetails.Children.Add(ipara)

    Dim chstr As String = "   State Child: " & mHeroInstState.mBuild.ChildIDItem.FriendlyGuid
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

  Private Sub RefreshCurrentItems(currenttime As ddFrame)

    If Not mHeroInstState Is Nothing Then

      spnlStash.Children.Clear()


      itemList = mHeroInstState.ItemInventory.GetItemsAtTime(currenttime)
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

    End If



  End Sub

  Private Sub RefreshAbilityBar(herocurrentlevel As Integer)
    Dim theabs = mHeroInstState.AbilityInventory.AbilitiesListedByUIPosition
    permCtrlAtility_thumbs.Clear()
    tempCtrlAbility_Thumbs.Clear()
    tempabilitylist.Clear()
    For i As Integer = 0 To theabs.Count - 1
      Dim theab = theabs.Item(i)

      theab.CurrentLevel = mHeroInstState.AbilityInventory.GetAbilityLevelAtHeroLevel(theab, mHeroInstState.AbilityInventory.GetAbilityLevelAtHeroLevel(theab, herocurrentlevel))
      allCtrlAbility_thumbs.Item(i).LoadNewAbility(theab, mGame, theab.DisplayName)
      allCtrlAbility_thumbs.Item(i).Visibility = Windows.Visibility.Visible
      permCtrlAtility_thumbs.Add(allCtrlAbility_thumbs.Item(i))
    Next

    'do any extra abilities as needed
    Select Case mHeroInstState.HeroName
      Case eHeroName.untTreant_Protector
        tempabilitylist.Add(mGame.dbAbilities.CreateAbilityInfoInstance(eAbilityName.abEyes_In_The_Forest, 0, mHeroInstState, Nothing))

        allCtrlAbility_thumbs.Item(theabs.Count).LoadNewAbility(tempabilitylist.Item(0), mGame, tempabilitylist.Item(0).DisplayName)
        allCtrlAbility_thumbs.Item(theabs.Count).Visibility = Windows.Visibility.Visible
        tempCtrlAbility_Thumbs.Add(allCtrlAbility_thumbs.Item(theabs.Count))
      Case eHeroName.untInvoker

        'cold snap
        Dim coldsnap = mGame.dbAbilities.CreateAbilityInfoInstance(eAbilityName.abCold_Snap, 0, mHeroInstState, Nothing)
        coldsnap.mLifetime = mHeroInstState.GetTempAbilityLifetimes(coldsnap)
        tempabilitylist.Add(coldsnap)

        allCtrlAbility_thumbs.Item(theabs.Count).LoadNewAbility(tempabilitylist.Item(0), mGame, tempabilitylist.Item(0).DisplayName)
        allCtrlAbility_thumbs.Item(theabs.Count).Visibility = Windows.Visibility.Visible

        tempCtrlAbility_Thumbs.Add(allCtrlAbility_thumbs.Item(theabs.Count))

        'Ghost Walk
        Dim ghostwalk = mGame.dbAbilities.CreateAbilityInfoInstance(eAbilityName.abGhost_Walk, 0, mHeroInstState, Nothing)
        ghostwalk.mLifetime = mHeroInstState.GetTempAbilityLifetimes(ghostwalk)
        tempabilitylist.Add(ghostwalk)

        allCtrlAbility_thumbs.Item(theabs.Count + 1).LoadNewAbility(tempabilitylist.Item(1), mGame, tempabilitylist.Item(0).DisplayName)
        allCtrlAbility_thumbs.Item(theabs.Count + 1).Visibility = Windows.Visibility.Visible

        tempCtrlAbility_Thumbs.Add(allCtrlAbility_thumbs.Item(theabs.Count + 1))


        'tornado
        Dim tornadoe = mGame.dbAbilities.CreateAbilityInfoInstance(eAbilityName.abTornado, 0, mHeroInstState, Nothing)
        tornadoe.mLifetime = mHeroInstState.GetTempAbilityLifetimes(tornadoe)
        tempabilitylist.Add(tornadoe)

        allCtrlAbility_thumbs.Item(theabs.Count + 2).LoadNewAbility(tempabilitylist.Item(2), mGame, tempabilitylist.Item(0).DisplayName)
        allCtrlAbility_thumbs.Item(theabs.Count + 2).Visibility = Windows.Visibility.Visible

        tempCtrlAbility_Thumbs.Add(allCtrlAbility_thumbs.Item(theabs.Count + 2))


        'EMP
        Dim emp = mGame.dbAbilities.CreateAbilityInfoInstance(eAbilityName.abEmp, 0, mHeroInstState, Nothing)
        emp.mLifetime = mHeroInstState.GetTempAbilityLifetimes(emp)
        tempabilitylist.Add(emp)

        allCtrlAbility_thumbs.Item(theabs.Count + 3).LoadNewAbility(tempabilitylist.Item(3), mGame, tempabilitylist.Item(0).DisplayName)
        allCtrlAbility_thumbs.Item(theabs.Count + 3).Visibility = Windows.Visibility.Visible

        tempCtrlAbility_Thumbs.Add(allCtrlAbility_thumbs.Item(theabs.Count + 3))


        'Alacrity
        Dim alacrity = mGame.dbAbilities.CreateAbilityInfoInstance(eAbilityName.abAlacrity, 0, mHeroInstState, Nothing)
        alacrity.mLifetime = mHeroInstState.GetTempAbilityLifetimes(alacrity)
        tempabilitylist.Add(alacrity)

        allCtrlAbility_thumbs.Item(theabs.Count + 4).LoadNewAbility(tempabilitylist.Item(4), mGame, tempabilitylist.Item(0).DisplayName)
        allCtrlAbility_thumbs.Item(theabs.Count + 4).Visibility = Windows.Visibility.Visible

        tempCtrlAbility_Thumbs.Add(allCtrlAbility_thumbs.Item(theabs.Count + 4))


        'Chaos Meteor
        Dim chaosmetoer = mGame.dbAbilities.CreateAbilityInfoInstance(eAbilityName.abChaos_Meteor, 0, mHeroInstState, Nothing)
        chaosmetoer.mLifetime = mHeroInstState.GetTempAbilityLifetimes(chaosmetoer)
        tempabilitylist.Add(chaosmetoer)

        allCtrlAbility_thumbs.Item(theabs.Count + 5).LoadNewAbility(tempabilitylist.Item(5), mGame, tempabilitylist.Item(0).DisplayName)
        allCtrlAbility_thumbs.Item(theabs.Count + 5).Visibility = Windows.Visibility.Visible


        tempCtrlAbility_Thumbs.Add(allCtrlAbility_thumbs.Item(theabs.Count + 5))

        'Sun Strike
        Dim sunstrike = mGame.dbAbilities.CreateAbilityInfoInstance(eAbilityName.abSun_Strike, 0, mHeroInstState, Nothing)
        sunstrike.mLifetime = mHeroInstState.GetTempAbilityLifetimes(sunstrike)
        tempabilitylist.Add(sunstrike)

        allCtrlAbility_thumbs.Item(theabs.Count + 6).LoadNewAbility(tempabilitylist.Item(6), mGame, tempabilitylist.Item(0).DisplayName)
        allCtrlAbility_thumbs.Item(theabs.Count + 6).Visibility = Windows.Visibility.Visible

        tempCtrlAbility_Thumbs.Add(allCtrlAbility_thumbs.Item(theabs.Count + 6))


        'Forge Spirit
        Dim forge = mGame.dbAbilities.CreateAbilityInfoInstance(eAbilityName.abForge_Spirit, 0, mHeroInstState, Nothing)
        forge.mLifetime = mHeroInstState.GetTempAbilityLifetimes(forge)
        tempabilitylist.Add(forge)

        allCtrlAbility_thumbs.Item(theabs.Count + 7).LoadNewAbility(tempabilitylist.Item(7), mGame, tempabilitylist.Item(0).DisplayName)
        allCtrlAbility_thumbs.Item(theabs.Count + 7).Visibility = Windows.Visibility.Visible

        tempCtrlAbility_Thumbs.Add(allCtrlAbility_thumbs.Item(theabs.Count + 7))



        'Ice Wall
        Dim icewall = mGame.dbAbilities.CreateAbilityInfoInstance(eAbilityName.abIce_Wall, 0, mHeroInstState, Nothing)
        icewall.mLifetime = mHeroInstState.GetTempAbilityLifetimes(icewall)
        tempabilitylist.Add(icewall)

        allCtrlAbility_thumbs.Item(theabs.Count + 8).LoadNewAbility(tempabilitylist.Item(8), mGame, tempabilitylist.Item(0).DisplayName)
        allCtrlAbility_thumbs.Item(theabs.Count + 8).Visibility = Windows.Visibility.Visible

        tempCtrlAbility_Thumbs.Add(allCtrlAbility_thumbs.Item(theabs.Count + 8))



        'Deafening Blast
        Dim deaf = mGame.dbAbilities.CreateAbilityInfoInstance(eAbilityName.abDeafening_Blast, 0, mHeroInstState, Nothing)
        deaf.mLifetime = mHeroInstState.GetTempAbilityLifetimes(deaf)
        tempabilitylist.Add(deaf)

        allCtrlAbility_thumbs.Item(theabs.Count + 9).LoadNewAbility(tempabilitylist.Item(9), mGame, tempabilitylist.Item(0).DisplayName)
        allCtrlAbility_thumbs.Item(theabs.Count + 9).Visibility = Windows.Visibility.Visible


        tempCtrlAbility_Thumbs.Add(allCtrlAbility_thumbs.Item(theabs.Count + 9))

    End Select
    For i As Integer = (theabs.Count + tempabilitylist.Count) To allCtrlAbility_thumbs.Count - 1
      allCtrlAbility_thumbs.Item(i).Visibility = Windows.Visibility.Collapsed
    Next
  End Sub



  Private Sub RefreshPetSequence(currenttime As ddFrame)

    If Not petsLoaded Then
      spnlPets.Children.Clear()
      creepcontrols = New List(Of ctrlPetStack)

      For i As Integer = 0 To mHeroInstState.PetsOwned.Count - 1
        Dim curcreepstackctrl As New ctrlPetStack()

        Dim curpets = mHeroInstState.PetsOwned.Item(i)
        curpets.SetTargets(mHeroInstState.GetEnemyTarget, mHeroInstState.GetFriendlyTarget, mHeroInstState.GetTargetFriendBias)
        curcreepstackctrl.Load(curpets, mHeroInstState, mHeroInstState.mTeam, mHeroInstState.mTeamPosition, mGame, mGame.dbNames, PageHandler.theLog)

        creepcontrols.Add(curcreepstackctrl)
        spnlPets.Children.Add(curcreepstackctrl)
      Next
      petsLoaded = True
    End If


    'set visibility
    If creepcontrols.Count > 0 Then
      For i As Integer = 0 To creepcontrols.Count - 1
        creepcontrols.Item(i).SetTime(currenttime)
      Next
    End If
  End Sub
  Private Sub RefreshCurrentAbilities(currentherolevel As Integer, currenttime As ddFrame)

    Dim currabilities As New List(Of Integer)


    'hero specific stuff
    If Not mHeroInstState Is Nothing Then


      'abilities
      currabilities = mHeroInstState.AbilityInventory.GetActiveAbilitiesByLevel(currentherolevel)

      For i As Integer = 0 To currabilities.Count - 1
        Dim ability = mHeroInstState.AbilityInventory.AbilitiesListedByUIPosition.Item(i)
        Dim abilitycurrentlevel = mHeroInstState.AbilityInventory.GetAbilityLevelAtHeroLevel(ability, currentherolevel)
        allCtrlAbility_thumbs.Item(i).LoadNewAbility(ability, mGame, ability.DisplayName)
        allCtrlAbility_thumbs.Item(i).SetLevel(abilitycurrentlevel)
      Next
    End If

    'treant eyes in the forest check
    If mHeroInstState.HeroName = eHeroName.untTreant_Protector And mHeroInstState.ItemInventory.mItemBuildAndAutoGeneratedItems.ContainsName(eItemname.itmAGHANIMS_SCEPTER) Then

      Dim aghs = mHeroInstState.ItemInventory.mItemBuildAndAutoGeneratedItems.GetItemByName(eItemname.itmAGHANIMS_SCEPTER)
      If aghs.Lifetime.LifeTimeContainsTime(currenttime) Then
        allCtrlAbility_thumbs.Item(mHeroInstState.AbilityInventory.AbilitiesListedByUIPosition.Count).SetLevel(1)
      Else
        allCtrlAbility_thumbs.Item(mHeroInstState.AbilityInventory.AbilitiesListedByUIPosition.Count).SetLevel(0)
      End If

    End If

    'invoker check
    If mHeroInstState.HeroName = eHeroName.untInvoker Then
      For i As Integer = 0 To tempabilitylist.Count - 1
        SetInvokerAbilityLevel(tempCtrlAbility_Thumbs.Item(i), currenttime)
      Next
    End If

  End Sub
#End Region


#Region "Edge Cases"
  Private Sub SetInvokerAbilityLevel(theabctrl As ctrlAblityThumb, currenttime As ddFrame)
    If theabctrl.MyAbility.Lifetime Is Nothing Then
      Dim x = 2
    End If
    If theabctrl.MyAbility.Lifetime.LifeTimeContainsTime(currenttime) Then
      theabctrl.SetLevel(1)
    Else
      theabctrl.SetLevel(0)
    End If
  End Sub
#End Region

#Region "Event Handlers"
  Private Sub lblPlusMinus_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs)
    If lblPlusMinus.Content = "+" Then
      lblPlusMinus.Content = "-"

      spnlPetHeading.Visibility = Windows.Visibility.Visible
      spnlPets.Visibility = Windows.Visibility.Visible

      rectDividerMid.Visibility = Windows.Visibility.Collapsed

    Else
      lblPlusMinus.Content = "+"

      spnlPetHeading.Visibility = Windows.Visibility.Collapsed
      spnlPets.Visibility = Windows.Visibility.Collapsed

      rectDividerMid.Visibility = Windows.Visibility.Visible

    End If

  End Sub

  Private Sub ChildControl_isDirty(gameentity As iGameEntity)
    'Dim ctrlisselected As Boolean = False
    'If Not isLoading Then
    '  Select Case thectrl.type
    '    Case eEntity.ctrlAbility_Thumb_Picker
    '      Dim tctrl As ctrlAbility_Thumb_Picker = thectrl.obj
    '      If tctrl.IsSelected Then ctrlisselected = True
    '      mHeroInstState.SetAbility(tctrl.mAbility, tctrl.mindex + 1)
    '      isNewBuild = True

    '      RefreshCurrentAbilities()

    '    Case eEntity.ctrlItem_Thumb_Picker_3
    '      Dim x = mHeroInstState.ItemBuildSequence.Count

    '      Dim tctrl As ctrlItem_Thumb_Picker_3 = thectrl.obj
    '      If tctrl.IsSelected Then ctrlisselected = True
    '      mHeroInstState.ReplaceItemAtIndex(tctrl.mItem, tctrl.mItem.mIndex)
    '      isNewBuild = True

    '      RefreshCurrentItems()

    '    Case eEntity.ctrlItem_Thumb


    '    Case eEntity.ctrlAbilityThumb
    '      RefreshCurrentAbilities()

    '    Case Else
    '      Dim x = 2
    '  End Select

    '  RefreshAll()


    '  If ctrlisselected Then
    '    RaiseEvent SelectedChanged(thectrl)
    '  End If
    'End If

  End Sub

  Private Sub ChildControl_SelectedChanged(sender As iGameEntity)
    RaiseEvent SelectedChanged(sender)
  End Sub

  Private Sub heroThumb_btnChangeHeroClicked(btn As btnMinimalClick) 'As Object
    PageHandler.dbControls.HeroMenu.OpenMenu(Me)
    AddHandler PageHandler.dbControls.HeroMenu.HeroPicked, AddressOf HeroMenu_HeroPicked

  End Sub

  Private Sub HeroMenu_HeroPicked(theherobuild As HeroBuild, owner As ctrlHero_Badge)

    RemoveHandler PageHandler.dbControls.HeroMenu.HeroPicked, AddressOf HeroMenu_HeroPicked
    RaiseEvent NewHeroPicked(theherobuild, mHeroInstState, mHeroInstState.mTeam, mHeroInstState.mTeamPosition)

  End Sub

  Private Sub Me_selectedChanged(sender As Object, e As MouseButtonEventArgs)
    If mIsSelected Then
      SetSelected(False)
    Else
      SetSelected(True)
    End If

    RaiseEvent SelectedChanged(Me)
  End Sub
#End Region


  'Private Sub MyHero_isDirty(thehero As HeroInstance)
  '  If Not isLoading Then
  '    RefreshAll()
  '  End If

  'End Sub


End Class
