'#Const DEVMODE = False
'Public Class ctrlGeneric_Details
'  Private myItem As Item_Info
'  Private myAbility As Ability_Info
'  Private myHero As HeroInstance
'  Private myMod As Modifier
'  Private myStat As Stat
'  Private myBarMods As List(Of List(Of Modifier))

'  'Private ownItem As Item_Info
'  'Private ownAbility As Ability_Info
'  'Private ownHero As HeroInstance
'  'Private ownCreep As Creep_Instance
'  'Private ownBar As ctrlBar
'  'Private ownMod As Modifier

'  'Private srcItem As Item_Info
'  'Private srcAbility As Ability_Info
'  'Private srcHero As HeroInstance
'  'Private srcBar As ctrlBar
'  'Private srcMod As Modifier


'  Private DetailsItem As iGameEntity 'the anonymous object passed in


'  Private mCurTime As ddFrame
'  Private mCurLifetime As Lifetime

'  'used to get items by ability level like mradius from within a mod
'  'Private curAbilityLevel As Integer = 0

'  Private mDetailstype As eDetailsType


'  Private mTarget As iDisplayUnit

'  Private mUpdatableMods As New List(Of ctrlModDetails)


'  Private mGame As dGame

'  'Private mParent As DDObject
'  'Private mSource As DDObject
'  'Private mHeroes As List(Of HeroInstance)
'  'Private mCreeps As List(Of Creep_Instance)
'  ' Private dbNames As FriendlyName_Database
'  Public Sub New()
'    InitializeComponent()

'  End Sub
'  ''' <summary>
'  ''' only call this if you are displaying a different set of details. Call updateexistingdetails if vars are the same, just different curtime
'  ''' </summary>
'  ''' <param name="thegame"></param>
'  ''' <param name="theobj"></param>
'  ''' <param name="thedetailstype"></param>
'  ''' <param name="theowner"></param>
'  ''' <param name="theownertype"></param>
'  ''' <param name="thecurrenttime"></param>
'  ''' <remarks></remarks>
'  Public Sub LoadDetails(thegame As dGame, _
'                          thedetailsobj As iGameEntity, _
'                          thecurrenttime As ddFrame)

'    If thedetailsobj Is Nothing Then Exit Sub

'    mGame = thegame



'    ' If Not thedetailstype = mDetailstype Then
'    LoadNewDetails(thedetailsobj, thecurrenttime)

'    ' AddHandler mGame.dbModifiers.Modschanged, AddressOf dbMods_Modschanged



'  End Sub

'  Private Sub LoadNewDetails(thedetailsitem As iGameEntity, _
'                          thecurrenttime As ddFrame)
'    ClearAll()
'    DetailsItem = thedetailsitem


'    mCurTime = thecurrenttime

'    'mParent = theowner
'    'mSource = thesource

'    LoadUI(mDetailstype)



'    Select Case DetailsItem.MyType
'      Case eSourceType.Ability_Info
'        myAbility = theobj

'        Dim ownHero = mGame.GetHeroInstanceByID(myAbility.Parent.Id)

'        'srcAbility = myAbility



'        mCurLifetime = ownHero.GetTempAbilityLifetimes(myAbility)
'        mTargetID = myAbility.TeamEnemyTarget
'        mTarget = Helpers.GetUnitForId(mTargetID, mGame)
'        LoadAbility()


'      Case eSourceType.Hero_Instance
'        myHero = theobj

'        'ownHero = myHero
'        'srcHero = myHero


'        mCurLifetime = mGame.mTimeKeeper.GameLifetime
'        mTargetID = myHero.GetEnemyTarget
'        LoadHero()


'      Case eSourceType.Item_Info
'        myItem = theobj

'        Dim ownHero = mGame.GetHeroInstanceByID(myItem.ParentID)
'        '   ownCreep = mGame.GetCreepInstanceByID(myItem.ParentID)

'        '   srcItem = myItem

'        mCurLifetime = ownHero.GetItemLifetime(myItem)
'        mTargetID = myItem.mTeamEnemyTarget
'        If Not myItem.mName = eItemname.None Then
'          LoadItem()
'        End If

'      Case eSourceType.BarGraph
'        ' Dim x = 2
'        myBarMods = theobj
'        'myBarMods = o

'        'If ownBar.mValueColor Is Nothing Then
'        '  Dim x = 2
'        'End If


'        'mCurLifetime = New Lifetime(ownBar.BarsTime, mGame.mTimeKeeper.Framerate)


'        LoadBar()

'      Case eDetailsType.Modifier

'        myMod = theobj
'        mCurLifetime = myMod.Lifetime
'        mTargetID = myMod.TargetID
'        mTarget = Helpers.GetUnitForId(myMod.TheModInfo.TargetID, mGame)
'        LoadModifier()

'      Case eDetailsType.Stat

'        myStat = theobj
'        mCurLifetime = mGame.mTimeKeeper.GameLifetime
'        Dim ownhero = mGame.GetHeroInstanceByID(myStat.ParentID)
'        mTargetID = ownhero.Id
'        LoadStat()


'      Case eDetailsType.None
'        Dim x = 2
'    End Select



'  End Sub


'  Public Sub UpdateExistingDetails(thecurrenttime As ddFrame)
'    PageHandler.theLog.WriteLog("ctrlGenericDetails.UpdateExitingDetails time: " & thecurrenttime.count.ToString)
'    mCurTime = thecurrenttime
'    UpdateHeader()
'    If Not myAbility Is Nothing Then
'      UpdateExistingMods(myAbility.mAbilityLevel)
'    Else
'      UpdateExistingMods(1)
'    End If


'  End Sub

'  Private Sub UpdateHeader()

'  End Sub
'  Private Sub LoadBar()
'    LoadHeader()

'    LoadBarMods()
'  End Sub
'  Private Sub LoadItem()
'    LoadHeader()

'    LoadBuildsToFrom()

'    LoadStaticItemInfo()

'    LoadMods(mCurLifetime)

'  End Sub


'  Private Sub LoadAbility()
'    LoadHeader()
'    LoadStaticAbilityInfo()
'    LoadMods(mCurLifetime)
'  End Sub
'  Private Sub LoadHero()
'    LoadHeader()

'    LoadStaticHeroInfo()
'    LoadMods(mGame.mTimeKeeper.GameLifetime)
'  End Sub

'  Private Sub LoadStaticItemInfo()
'    Dim outcolor = New SolidColorBrush(PageHandler.dbColors.HeadingTextColor)
'    Dim outdarkcolor = New SolidColorBrush(PageHandler.dbColors.BodyTextColor)
'    Dim valuecolor = New SolidColorBrush(PageHandler.dbColors.ValueTextColor)



'    'Desciption
'    If Not myItem.Description = Nothing Then
'      Dim spacer6 As New ctrlVerticalSpacer()
'      spnlStats.Children.Add(spacer6)
'      Dim theDescpars = myItem.Description.Split("|")
'      If theDescpars Is Nothing Then theDescpars(0) = myItem.Description
'      For i As Integer = 0 To theDescpars.Count - 1
'        Dim newpara As New ctrlBody_Paragraph()
'        newpara.SetItalics(True)
'        newpara.LoadText(theDescpars(i), outcolor)
'        spnlStats.Children.Add(newpara)
'      Next
'    End If



'    If Not myItem.mGoldCost < 1 Then
'      Dim outstat As New ctrlStatLabel("Price", myItem.mGoldCost.ToString, valuecolor)
'      spnlHeadText.Children.Add(outstat)
'    End If

'    If Not myItem.mManaCost.Value(0) < 1 Then
'      Dim outstat As New ctrlStatLabel("Mana", myItem.mManaCost.ToString, New SolidColorBrush(PageHandler.dbColors.MagicalColor))
'      spnlStats.Children.Add(outstat)
'    End If

'    If Not myItem.Cooldown.Value(0) Is Nothing Then
'      Dim outstat As New ctrlStatLabel("Cooldown", myItem.Cooldown.ToString, outcolor)
'      spnlStats.Children.Add(outstat)
'    End If

'    If Not myItem.Radius.Value(0) Is Nothing Then
'      Dim outstat As New ctrlStatLabel("Radius", myItem.Radius.ToString, outcolor)
'      spnlStats.Children.Add(outstat)
'    End If

'    If Not myItem.Charges = Nothing Then
'      Dim outstat As New ctrlStatLabel("Charges", myItem.Charges.ToString, outcolor)
'      spnlStats.Children.Add(outstat)
'    End If

'    If Not myItem.Duration.Value(0) Is Nothing Then
'      Dim outstat As New ctrlStatLabel("Duration", myItem.Duration.ToString, outcolor)
'      spnlStats.Children.Add(outstat)
'    End If


'    If myItem.mCanDisassemble Then
'      Dim outstat As New ctrlStatLabel("Can Disassemble", "", outdarkcolor)
'      spnlStats.Children.Add(outstat)
'    End If

'    If Not myItem.mTier = Nothing Then
'      Dim outstat As New ctrlStatLabel("Item Tier", myItem.mTier.ToString, outcolor)
'      spnlStats.Children.Add(outstat)
'    End If


'    'Sold From
'    If Not myItem.mSoldFrom.Count < 1 Then
'      Dim outstr As String = ""
'      Dim shps = myItem.mSoldFrom
'      For i As Integer = 0 To shps.Count - 1
'        If Not i = shps.Count - 1 Then
'          outstr += shps.Item(i).ToString & ", "
'        Else
'          outstr += shps.Item(i).ToString
'        End If
'      Next

'      Dim outstats As New ctrlStatLabel("Sold At", outstr, outcolor)
'      spnlHeadText.Children.Add(outstats)
'    End If

'    If Not myItem.mItemplan = Nothing Then
'      Dim outstat As New ctrlStatLabel(mGame.dbNames.GetFriendlyNameforEItemPlan(myItem.mItemplan), "", outdarkcolor)
'      spnlStats.Children.Add(outstat)
'    End If

'    Dim spacer8 As New ctrlVerticalSpacer()
'    spnlStats.Children.Add(spacer8)


'    'color text
'    If Not myItem.ColorText = Nothing Then
'      Dim spacer4 As New ctrlVerticalSpacer()
'      spnlBodyText.Children.Add(spacer4)
'      Dim thecolorpars = myItem.ColorText.Split("|")
'      For i As Integer = 0 To thecolorpars.Count - 1
'        Dim newpara As New ctrlBody_Paragraph()
'        newpara.LoadText(thecolorpars(i), outdarkcolor)
'        spnlBodyText.Children.Add(newpara)
'      Next
'    End If


'    'notes
'    If Not myItem.Notes = Nothing Then
'      Dim spacer3 As New ctrlVerticalSpacer()
'      spnlBodyText.Children.Add(spacer3)
'      Dim thenotpars = myItem.Notes.Split("|")
'      For i As Integer = 0 To thenotpars.Count - 1
'        Dim newpara As New ctrlBody_Paragraph()
'        newpara.LoadText(thenotpars(i), New SolidColorBrush(PageHandler.dbColors.CommentaryTextColor))
'        spnlBodyText.Children.Add(newpara)
'      Next
'    End If



'  End Sub
'  Private Sub LoadStaticAbilityInfo()
'    Dim outcolor = New SolidColorBrush(PageHandler.dbColors.HeadingTextColor)
'    Dim outdarkcolor = New SolidColorBrush(PageHandler.dbColors.BodyTextColor)
'    Dim valuecolor = New SolidColorBrush(PageHandler.dbColors.ValueTextColor)



'    Dim thedescpars = myAbility.Description.Split("|")
'    For i As Integer = 0 To thedescpars.Count - 1
'      Dim newpara As New ctrlBody_Paragraph()
'      newpara.LoadText(thedescpars(i), outdarkcolor)
'      newpara.SetItalics(True)
'      spnlHeadText.Children.Add(newpara)
'    Next
'    'ManaCost
'    If Not myAbility.ManaCost Is Nothing Then
'      Dim outval As String
'      Dim themanas = myAbility.ManaCost

'      For i As Integer = 0 To themanas.Count - 1
'        If Not i = themanas.Count - 1 Then
'          outval += themanas.Value(i).ToString & " / "
'        Else
'          outval += themanas.Value(i).ToString
'        End If
'      Next

'      Dim outstat As New ctrlStatLabel("Mana Cost", outval, outcolor)
'      spnlStats.Children.Add(outstat)
'    End If

'    'Cooldown
'    If Not myAbility.Cooldown Is Nothing Then
'      Dim outval As String
'      Dim thecools = myAbility.Cooldown

'      For i As Integer = 0 To thecools.Count - 1
'        If Not i = thecools.Count - 1 Then
'          outval += thecools.Value(i).ToString & " / "
'        Else
'          outval += thecools.Value(i).ToString
'        End If
'      Next

'      Dim outstat As New ctrlStatLabel("Cooldown", outval, outcolor)
'      spnlStats.Children.Add(outstat)
'    End If

'    'Ability
'    If Not myAbility.AbilityTypes.Count < 1 Then
'      Dim outval As String
'      Dim thetypes = myAbility.AbilityTypes
'      For i As Integer = 0 To thetypes.Count - 1
'        If Not i = thetypes.Count - 1 Then
'          outval += mGame.dbNames.GetFriendlyAbilityType(thetypes.Item(i)) & ", "
'        Else
'          outval += mGame.dbNames.GetFriendlyAbilityType(thetypes.Item(i))
'        End If


'      Next
'      Dim outstat As New ctrlStatLabel("Ability", outval, outcolor)
'      spnlStats2.Children.Add(outstat)
'    End If

'    'Affects
'    If Not myAbility.Affects.Count < 1 Then
'      Dim outval As String
'      Dim theaffects = myAbility.Affects
'      For i As Integer = 0 To theaffects.Count - 1
'        If Not i = theaffects.Count - 1 Then
'          outval += mGame.dbNames.GetFriendlyUnitName(theaffects.Item(i)) & ", "
'        Else
'          outval += mGame.dbNames.GetFriendlyUnitName(theaffects.Item(i))
'        End If


'      Next
'      Dim outstat As New ctrlStatLabel("Affects", outval, outcolor)
'      spnlStats2.Children.Add(outstat)
'    End If

'    'Pierces Spell Immunity
'    Dim spellstat As New ctrlStatLabel("Pierces Spell Immunity", myAbility.PiercesSpellImmunity.ToString, outcolor)
'    spnlStats2.Children.Add(spellstat)

'    'damage type
'    Dim damtype As New ctrlStatLabel("Damage Type", mGame.dbNames.GetFriendlyDamageType(myAbility.DamageType), New SolidColorBrush(PageHandler.dbColors.GetColorForDamageType(myAbility.DamageType)))
'    spnlStats2.Children.Add(damtype)

'    'Damage
'    'If Not myAbility.mDamage Is Nothing Then
'    '  Dim outval As String
'    '  Dim thedam = myAbility.mDamage
'    '  For i As Integer = 0 To thedam.Count - 1
'    '    If Not i = thedam.Count - 1 Then
'    '      outval += thedam.Value(i).ToString & "/"
'    '    Else
'    '      outval += thedam.Value(i).ToString
'    '    End If


'    '  Next
'    '  Dim outstat As New ctrlStatLabel("Damage", outval, valuecolor)
'    '  spnlStats.Children.Add(outstat)
'    'End If







'    'Duration
'    'If Not myAbility.mDuration Is Nothing Then
'    '  Dim outval As String
'    '  Dim thedurs = myAbility.mDuration
'    '  For i As Integer = 0 To thedurs.Count - 1
'    '    If Not i = thedurs.Count - 1 Then
'    '      outval += thedurs.Value(i).ToString & "/"
'    '    Else
'    '      outval += thedurs.Value(i).ToString
'    '    End If


'    '  Next
'    '  Dim outstat As New ctrlStatLabel("Duration", outval, outcolor)
'    '  spnlStats.Children.Add(outstat)
'    'End If

'    'Radius
'    'If Not myAbility.mRadius Is Nothing Then
'    '  Dim outval As String
'    '  Dim therads = myAbility.mRadius
'    '  For i As Integer = 0 To therads.Count - 1
'    '    If Not i = therads.Count - 1 Then
'    '      outval += therads.Value(i).ToString & "/"
'    '    Else
'    '      outval += therads.Value(i).ToString
'    '    End If


'    '  Next
'    '  Dim outstat As New ctrlStatLabel("Radius", outval, outcolor)
'    '  spnlStats.Children.Add(outstat)
'    'End If


'    'Range
'    'If Not myAbility.mRange Is Nothing Then
'    '  Dim outval As String
'    '  Dim theranges = myAbility.mRange
'    '  For i As Integer = 0 To theranges.Count - 1
'    '    If Not i = theranges.Count - 1 Then
'    '      outval += theranges.Value(i).ToString & "/"
'    '    Else
'    '      outval += theranges.Value(i).ToString
'    '    End If


'    '  Next
'    '  Dim outstat As New ctrlStatLabel("Range", outval, outcolor)
'    '  spnlStats.Children.Add(outstat)
'    'End If


'    'Dim spacer1 As New ctrlVerticalSpacer
'    'spnlStats.Children.Add(spacer1)

'    If myAbility.mIsUltimate = True Then

'      Dim outstat As New ctrlStatLabel("Is Ultimate", "", New SolidColorBrush(PageHandler.dbColors.UltimateTextColor))
'      spnlStats2.Children.Add(outstat)
'    End If


'    If myAbility.mIsAghsUpgradable = True Then
'      Dim outstat As New ctrlStatLabel("Is Agh's Upgradable", "", New SolidColorBrush(PageHandler.dbColors.CommentaryTextColor))
'      spnlStats2.Children.Add(outstat)
'    End If
'    'If myAbility.mBlockedByMagicImmune = True Then
'    '  Dim outstat As New ctrlStatLabel("Blocked by magic immune", "", outdarkcolor, subtextFontSize)
'    '  spnlStats.Children.Add(outstat)
'    'End If

'    'If myAbility.mRemovedByMagicImmune = True Then
'    '  Dim outstat As New ctrlStatLabel("Removed by magic ummune", "", outdarkcolor, subtextFontSize)
'    '  spnlStats.Children.Add(outstat)
'    'End If

'    'If myAbility.mCanBePurged = True Then
'    '  Dim outstat As New ctrlStatLabel("Can be purged", "", outdarkcolor, subtextFontSize)
'    '  spnlStats.Children.Add(outstat)
'    'End If


'    'If myAbility.mCanBeUsedByIllusions = True Then
'    '  Dim outstat As New ctrlStatLabel("Can be used by illusions", "", outdarkcolor, subtextFontSize)
'    '  spnlStats.Children.Add(outstat)
'    'End If

'    'If myAbility.mCanSelfDeny = True Then
'    '  Dim outstat As New ctrlStatLabel("Can self deny", "", outdarkcolor, subtextFontSize)
'    '  spnlStats.Children.Add(outstat)
'    'End If

'    'If myAbility.mBlockedByLinkens = True Then
'    '  Dim outstat As New ctrlStatLabel("Blocked by Linkin's", "", outdarkcolor, subtextFontSize)
'    '  spnlStats.Children.Add(outstat)
'    'End If

'    'If myAbility.mBreaksStun = True Then
'    '  Dim outstat As New ctrlStatLabel("Breaks stun", "", outdarkcolor, subtextFontSize)
'    '  spnlStats.Children.Add(outstat)
'    'End If

'    If myAbility.IsUniqueAttackModifier = True Then
'      Dim outstat As New ctrlStatLabel("Is unique attack modifier", "", outdarkcolor, Constants.cSubtextFontSize)
'      spnlStats2.Children.Add(outstat)
'    End If

'    'Dim spacer8 As New ctrlVerticalSpacer()
'    'spnlStats.Children.Add(spacer8)



'    'Dim spacer3 As New ctrlVerticalSpacer()
'    'spnlBodyText.Children.Add(spacer3)
'    Dim thenotpars = myAbility.Notes.Split("|")
'    For i As Integer = 0 To thenotpars.Count - 1
'      Dim newpara As New ctrlBody_Paragraph()
'      newpara.LoadText(thenotpars(i), New SolidColorBrush(PageHandler.dbColors.CommentaryTextColor))
'      spnlBodyText.Children.Add(newpara)
'    Next

'    'Dim spacer4 As New ctrlVerticalSpacer()
'    'spnlBodyText.Children.Add(spacer4)

'    If myAbility.BlockedByMagicImmune = True Then
'      Dim outstat As New ctrlStatLabel("Blocked by magic immune", "", outdarkcolor, Constants.cSubtextFontSize)
'      spnlStats2.Children.Add(outstat)
'    End If

'    If myAbility.RemovedByMagicImmune = True Then
'      Dim outstat As New ctrlStatLabel("Removed by magic ummune", "", outdarkcolor, Constants.cSubtextFontSize)
'      spnlStats2.Children.Add(outstat)
'    End If

'    If myAbility.CanBePurged = True Then
'      Dim outstat As New ctrlStatLabel("Can be purged", "", outdarkcolor, Constants.cSubtextFontSize)
'      spnlStats2.Children.Add(outstat)
'    End If


'    If myAbility.CanBeUsedByIllusions = True Then
'      Dim outstat As New ctrlStatLabel("Can be used by illusions", "", outdarkcolor, Constants.cSubtextFontSize)
'      spnlStats2.Children.Add(outstat)
'    End If

'    If myAbility.CanSelfDeny = True Then
'      Dim outstat As New ctrlStatLabel("Can self deny", "", outdarkcolor, Constants.cSubtextFontSize)
'      spnlStats2.Children.Add(outstat)
'    End If

'    If myAbility.BlockedByLinkens = True Then
'      Dim outstat As New ctrlStatLabel("Blocked by Linkin's", "", outdarkcolor, Constants.cSubtextFontSize)
'      spnlStats2.Children.Add(outstat)
'    End If

'    If myAbility.BreaksStun = True Then
'      Dim outstat As New ctrlStatLabel("Breaks stun", "", outdarkcolor, Constants.cSubtextFontSize)
'      spnlStats2.Children.Add(outstat)
'    End If
'  End Sub

'  Private Sub LoadStaticHeroInfo()

'    Dim strstat As New ctrlStatLabel("Base Str", _
'                                     myHero.BaseStrength.ToString & " +" & myHero.StrengthIncrement.ToString, _
'                                     New SolidColorBrush(PageHandler.dbColors.StrColor))
'    spnlStats.Children.Add(strstat)


'    Dim intstat As New ctrlStatLabel("Base Int", _
'                                     myHero.BaseIntelligence.ToString & " +" & myHero.IntelligenceIncrement.ToString, _
'                                     New SolidColorBrush(PageHandler.dbColors.IntColor))
'    spnlStats.Children.Add(intstat)


'    Dim agistat As New ctrlStatLabel("Base Agi", _
'                                     myHero.BaseAgility.ToString & " +" & myHero.AgilityIncrement.ToString, _
'                                     New SolidColorBrush(PageHandler.dbColors.AgiColor))
'    spnlStats.Children.Add(agistat)

'  End Sub



'  Private Sub LoadModifier()
'    LoadHeader()
'  End Sub

'  Private Sub LoadStat()
'    LoadStatMods()
'  End Sub
'  Private Sub LoadHeader()
'    LoadOwnerForHeader()

'    'Dim lblslash As New ctrlHeadingLabel
'    'lblslash._Content = "/"

'    'spnlHeading.Children.Add(lblslash)

'    spnlHeadSource.Children.Clear()
'    spnlHeadText.Children.Clear()
'    Select Case mDetailstype
'      Case eDetailsType.Ability

'        Dim abthumb As New ctrlImageThumb(myAbility, 60, 60) ', myAbility.mAbilityLevel)


'        spnlHeadSource.Children.Add(abthumb)
'        Dim thehead = Helpers.MakeHeadingBlock(mGame.dbNames.GetFriendlyAbilityName(myAbility.mName))
'        thehead.Margin = New Thickness(5, 5, 5, 5)
'        spnlHeadText.Children.Add(thehead)

'      Case eDetailsType.Item

'        Dim itthumb As New ctrlImageThumb(myItem, 60, 80)

'        itthumb.Margin = New Thickness(2, 3, 2, 3)
'        spnlHeadSource.Children.Add(itthumb)
'        Dim thehead = Helpers.MakeHeadingBlock(myItem.DisplayName)
'        thehead.Margin = New Thickness(5, 5, 5, 5)
'        spnlHeadText.Children.Add(thehead)


'      Case eDetailsType.Hero
'        spnlHeadPortrait.Children.Clear()
'        ' ownHero = myHero
'        Dim hcolor = New SolidColorBrush(mGame.GetColorforID(myHero.ID))
'        Dim hthumb As New ctrlImageThumb(myHero, hcolor, 60, 52)
'        spnlHeadSource.Children.Add(hthumb)

'        Dim thehead = Helpers.MakeHeadingBlock(myHero.FriendlyName)
'        thehead.Margin = New Thickness(5, 5, 5, 5)
'        spnlHeadText.Children.Add(thehead)

'      Case eDetailsType.GraphBar
'        ' ownBar = objOwner
'        Dim thehead = Helpers.MakeHeadingBlock("Selected Graph Bar")
'        thehead.Margin = New Thickness(5, 5, 5, 5)
'        spnlHeadText.Children.Add(thehead)

'      Case eDetailsType.Modifier

'        'ownMod = objOwner

'        Dim thehead = Helpers.MakeHeadingBlock(mGame.dbNames.GetFriendlyModifierName(myMod.ModifierType))
'        thehead.Margin = New Thickness(5, 5, 5, 5)
'        spnlHeadText.Children.Add(thehead)
'      Case Else
'        Dim x = 2
'    End Select

'    'Dim spacer1 As New ctrlVerticalSpacer(10)
'    'spnlHeading.Children.Add(spacer1)
'  End Sub

'  Private Sub LoadOwnerForHeader()
'    Select Case mDetailstype
'      Case eDetailsType.Ability
'        ' If Not ownAbility Is objOwner Then
'        spnlHeadPortrait.Children.Clear()

'        Dim abthumb As New ctrlImageThumb(myAbility, 60, 60) ', ownAbility.mAbilityLevelCount)
'        abthumb.HidePortrait(True)
'        spnlHeadPortrait.Children.Add(abthumb)
'        '  End If


'        'Dim thename As New ctrlHeadingLabel()
'        'thename._Content = ownAbility.'mFriendlyName =


'      Case eDetailsType.Item
'        ' If Not ownItem Is objOwner Then
'        spnlHeadPortrait.Children.Clear()
'        'ownItem = mParent.obj
'        Dim itthumb As New ctrlImageThumb(myItem, 60, 60)
'        itthumb.HidePortrait(True)


'        spnlHeadPortrait.Children.Add(itthumb)
'        ' End If


'        'Dim thename As New ctrlHeadingLabel()
'        'thename._Content = ownItem.mDisplayname


'      Case eDetailsType.Hero

'        'don() 't need swatch since redundant to source swatch
'        spnlHeadPortrait.Children.Clear()
'        ' ownHero = mParent.obj
'        Dim hcolor = New SolidColorBrush(mGame.GetColorforID(myHero.ID))
'        Dim hthumb As New ctrlImageThumb(myHero, hcolor, 60, 60)

'        hthumb.HidePortrait(True)

'        spnlHeadPortrait.Children.Add(hthumb)

'      Case eDetailsType.GraphBar

'        spnlHeadPortrait.Children.Clear()



'      Case eDetailsType.Modifier

'        'Dim thename As New ctrlHeadingLabel()
'        'thename._Content = ownMod.mModFriendlyName


'      Case Else
'        Dim x = 2
'    End Select


'  End Sub

'  Private Sub LoadBuildsToFrom()
'    If Not myItem.mBuildsFromNames Is Nothing Then

'      If myItem.mBuildsFromNames.Count > 0 Then
'        'Dim lblFrom As New ctrlHeading_2()
'        Dim lblFrom As New ctrlHeadingLabel()
'        lblFrom.LayoutRoot.Content = "Builds From"
'        spnlBuildsFromHead.Children.Add(lblFrom)
'      End If
'      For i As Integer = 0 To myItem.mBuildsFromNames.Count - 1
'        Dim curitem = mGame.dbItems.GetItemInfoNoParent(myItem.mBuildsFromNames.Item(i))
'        Dim themenuitem As New ctrlItem_Thumb() 'curitem, PageHandler.dbItems.GetBitMap(curitem.mName))
'        themenuitem.SetUnresponsive(themenuitem.LayoutRoot.Height)
'        themenuitem.LoadItem(curitem, mGame)
'        'Dim thelabel As New Label
'        'thelabel.Content = curitem.mName


'        spnlBuildsFrom.Children.Add(themenuitem)

'      Next
'    End If



'    If Not myItem.mBuildsToNames Is Nothing Then


'      If myItem.mBuildsToNames.Count > 0 Then
'        'Dim lblTo As New ctrlHeading_2()
'        Dim lblTo As New ctrlHeadingLabel()

'        lblTo.LayoutRoot.Content = "Builds To"
'        spnlBuildsToHead.Children.Add(lblTo)
'      End If

'      For i As Integer = 0 To myItem.mBuildsToNames.Count - 1
'        Dim curitem = mGame.dbItems.GetItemInfoNoParent(myItem.mBuildsToNames.Item(i))
'        '  Dim themenuitem As New ctrlItem_Tooltip_Icon(curitem, PageHandler.dbItems.GetBitMap(curitem.mName))
'        Dim themenuitem As New ctrlItem_Thumb()
'        themenuitem.LoadItem(curitem, mGame)
'        themenuitem.SetUnresponsive(themenuitem.LayoutRoot.Height)
'        spnlBuildsTo.Children.Add(themenuitem)

'      Next
'    End If

'    'Dim spacer1 As New ctrlVerticalSpacer(10)
'    'spnlHeading.Children.Add(spacer1)
'  End Sub

'  Private Sub UpdateExistingMods(abilitylevel As Integer)
'    ' curAbilityLevel = abilitylevel
'    UpdateHeader()
'    For i As Integer = 0 To mUpdatableMods.Count - 1
'      mUpdatableMods.Item(i).UpdateExistingMod(mCurTime)
'    Next
'  End Sub

'  Private Sub LoadStatMods()
'    spnlRadModValues.Children.Clear()
'    spnlDireModValues.Children.Clear()

'    Dim thelife = New Lifetime(mCurTime, mGame.mTimeKeeper.Framerate)

'    Dim themods = myStat.MyModsByType

'    Dim thestats = myStat.MyStats

'    Dim layoutroot As StackPanel
'    'figure out where to put the mods and stats
'    Dim prt = mGame.GetHeroInstanceByID(thestats.Item(0).ParentID)
'    Select Case prt.mTeam
'      Case eTeamName.Radient
'        layoutroot = spnlRadModValues
'      Case eTeamName.Dire
'        layoutroot = spnlDireModValues
'      Case Else
'        layoutroot = spnlRadModValues
'        PageHandler.theLog.WriteLog("Generic_Details.LoadStatMods unhandled team: " & prt.mTeam.ToString)
'    End Select


'    For Each kv As KeyValuePair(Of eModifierType, ModifierList) In themods
'      Dim curlist = kv.Value
'      Dim prt2 = mGame.GetEntityByID(kv.Value.Item(0).ParentID)
'      Dim src = mGame.GetEntityByID(kv.Value.Item(0).ModGeneratorID)
'      Dim themodctrl = New ctrlModDetails(prt2, src, curlist.Item(0), curlist.Item(0).GetLevelAtTime(mCurTime), mCurTime, mGame)
'      layoutroot.Children.Add(themodctrl)
'      mUpdatableMods.Add(themodctrl)
'    Next

'    For i As Integer = thestats.Count - 1 To 0 Step -1
'      Dim prt3 = mGame.GetEntityByID(thestats.Item(i).ParentID)
'      Dim themodctrl = New ctrlModDetails(prt3, prt3, thestats.Item(i), mCurTime, mGame)
'      layoutroot.Children.Add(themodctrl)
'      mUpdatableMods.Add(themodctrl)
'    Next
'  End Sub
'  Private Sub LoadBarMods()
'    spnlRadModValues.Children.Clear()
'    spnlDireModValues.Children.Clear()

'    Dim thelife = New Lifetime(mCurTime, mGame.mTimeKeeper.Framerate)

'    Dim themods = myBarMods

'    If themods.Item(0) Is Nothing Then
'      themods.RemoveAt(0)
'      themods.Insert(0, New ModifierList)

'    End If
'    If themods.Count > 1 Then
'      If themods.Item(1) Is Nothing Then
'        themods.RemoveAt(1)
'        themods.Insert(1, New ModifierList)
'      End If
'    End If

'    If themods.Count < 2 Then
'      themods.Add(New ModifierList)
'    End If

'    Dim rmods = themods.Item(0)
'    Dim dmods = themods.Item(1)


'    For i As Integer = dmods.Count - 1 To 0 Step -1
'      Dim prt = mGame.GetEntityByID(dmods.Item(i).ParentID)
'      Dim src = mGame.GetEntityByID(dmods.Item(i).ModGeneratorID)

'      Dim themodctrl = New ctrlModDetails(prt, src, dmods.Item(i), dmods.Item(i).GetLevelAtTime(mCurTime), mCurTime, mGame)
'      spnlDireModValues.Children.Add(themodctrl)
'      mUpdatableMods.Add(themodctrl)
'    Next



'    For i As Integer = 0 To rmods.Count - 1

'      Dim prt = mGame.GetEntityByID(rmods.Item(i).ParentID)
'      Dim src = mGame.GetEntityByID(rmods.Item(i).ModGeneratorID)
'      Dim themodctrl = New ctrlModDetails(prt, src, rmods.Item(i), rmods.Item(i).GetLevelAtTime(mCurTime), mCurTime, mGame)
'      spnlRadModValues.Children.Add(themodctrl)
'      mUpdatableMods.Add(themodctrl)

'    Next



'#If DEVMODE Then

'    Dim trv = Helpers.MakeTextBlock("mTotalRadientValues: " & ownBar.TotalRadiantValues.ToString)
'    spnlStats.Children.Add(trv)

'    Dim tdv = Helpers.MakeTextBlock("mTotalDireValues: " & ownBar.TotalDireValues.ToString)
'    spnlStats.Children.Add(tdv)








'    Dim vc = Helpers.MakeTextBlock("mValueColor : " & ownBar.mValueColor.Color.R.ToString & ", " & ownBar.mValueColor.Color.G.ToString & ", " & ownBar.mValueColor.Color.B.ToString)
'    spnlStats.Children.Add(vc)

'    Dim bt = Helpers.MakeTextBlock("mBarsTime :" & ownBar.mBarsTime.count.ToString)
'    spnlStats.Children.Add(bt)

'    Dim ind = Helpers.MakeTextBlock("mIndex: " & ownBar.mIndex.ToString)
'    spnlStats.Children.Add(ind)

'    Dim sp2 As New ctrlVerticalSpacer
'    spnlStats.Children.Add(sp2)



'    Dim rhead = Helpers.MakeHeadingBlock("Dire Heroes:")
'    spnlStats.Children.Add(rhead)
'    If Not ownBar.mTeamDire Is Nothing Then
'      For i As Integer = 0 To ownBar.mTeamDire.HeroCount - 1
'        Dim h = ownBar.mTeamDire.GetHeroBadge(i).mHeroBuildState.Name
'        Dim id = ownBar.mTeamDire.GetHeroBadge(i).mHeroBuildState.ID.FriendlyGuid
'        Dim hb = Helpers.MakeTextBlock(h.ToString & ": " & id)
'        spnlStats.Children.Add(hb)
'      Next
'    End If



'    If Not ownBar.mDireMods Is Nothing Then
'      Dim dm = Helpers.MakeTextBlock("mDireMods.count: " & ownBar.mDireMods.Count.ToString)
'      spnlStats.Children.Add(dm)

'      If Not ownBar.DireMods Is Nothing Then
'        For i As Integer = 0 To ownBar.mDireMods.Count - 1
'          Dim curmod = ownBar.mDireMods.Item(i)
'          Dim cm = curmod.IDItem.FriendlyGuid & " " & curmod.Type.ToString & " P: " & curmod.ParentID.FriendlyGuid & " S: " & curmod.ModGeneratorID.FriendlyGuid
'          Dim cmb = Helpers.MakeTextBlock(cm)
'          spnlStats.Children.Add(cmb)

'          For x As Integer = 0 To curmod.IDItem.MetaInfo.Count - 1
'            Dim para = Helpers.MakeTextBlock(curmod.IDItem.MetaInfo.Item(x))
'            spnlStats.Children.Add(para)
'          Next

'        Next
'      End If
'    End If


'    Dim dsr = Helpers.MakeTextBlock("mDireSourceRects.Count: " & ownBar.mDireSourceRects.Count.ToString)
'    spnlStats.Children.Add(dsr)

'    Dim dsrows = Helpers.MakeTextBlock("mDireSourceRows.count :" & ownBar.mDireSourceRows.Count.ToString)
'    spnlStats.Children.Add(dsrows)



'    For i As Integer = 0 To ownBar.mDireSourceRows.Count - 1
'      Dim currow = ownBar.mDireSourceRows.Item(i)
'      Dim r = Helpers.MakeTextBlock("R" & i.ToString & " Height: " & currow.Height.Value.ToString & " " & currow.Height.GridUnitType.ToString)
'      spnlStats.Children.Add(r)
'    Next

'    Dim sp3 As New ctrlVerticalSpacer
'    spnlStats.Children.Add(sp3)

'    Dim hhead = Helpers.MakeHeadingBlock("Radient Heroes:")
'    spnlStats.Children.Add(hhead)
'    If Not ownBar.mTeamRadient Is Nothing Then
'      For i As Integer = 0 To ownBar.mTeamRadient.HeroCount - 1
'        Dim h = ownBar.mTeamRadient.GetHeroBadge(i).mHeroBuildState.Name
'        Dim id = ownBar.mTeamRadient.GetHeroBadge(i).mHeroBuildState.ID.FriendlyGuid
'        Dim hb = Helpers.MakeTextBlock(h.ToString & ": " & id)
'        spnlStats.Children.Add(hb)
'      Next

'    End If

'    If Not ownBar.mRadientMods Is Nothing Then
'      Dim rm = Helpers.MakeTextBlock("mRadientMods.count : " & ownBar.mRadientMods.Count.ToString)
'      spnlStats.Children.Add(rm)
'      If Not ownBar.RadientMods Is Nothing Then
'        For i As Integer = 0 To ownBar.mRadientMods.Count - 1
'          Dim curmod = ownBar.mRadientMods.Item(i)
'          Dim cm = curmod.IDItem.FriendlyGuid & " " & curmod.Type.ToString & " P: " & curmod.ParentID.FriendlyGuid & " S: " & curmod.ModGeneratorID.FriendlyGuid
'          Dim cmb = Helpers.MakeTextBlock(cm)
'          spnlStats.Children.Add(cmb)

'          For x As Integer = 0 To curmod.IDItem.MetaInfo.Count - 1
'            Dim para = Helpers.MakeTextBlock(curmod.IDItem.MetaInfo.Item(x))
'            spnlStats.Children.Add(para)
'          Next
'        Next
'      End If
'    End If







'    Dim rsr = Helpers.MakeTextBlock("mRadientSourceRects.Count: " & ownBar.mRadientSourceRects.Count.ToString)
'    spnlStats.Children.Add(rsr)

'    Dim rsrows = Helpers.MakeTextBlock("mRadientSourceRows.count :" & ownBar.mRadientSourceRows.Count.ToString)
'    spnlStats.Children.Add(rsrows)


'    For i As Integer = 0 To ownBar.mRadientSourceRows.Count - 1
'      Dim currow = ownBar.mRadientSourceRows.Item(i)
'      Dim r = Helpers.MakeTextBlock("R" & i.ToString & " Height: " & currow.Height.Value.ToString & " " & currow.Height.GridUnitType.ToString)
'      spnlStats.Children.Add(r)
'    Next


'    Dim sp As New ctrlVerticalSpacer
'    spnlStats.Children.Add(sp)


'    Dim sp4 As New ctrlVerticalSpacer
'    spnlStats.Children.Add(sp4)

'    Dim mxh = Helpers.MakeTextBlock("mMaxheight : " & ownBar.mMaxheight.ToString)
'    spnlStats.Children.Add(mxh)

'    Dim mth = Helpers.MakeTextBlock("mMaxTeamHeight : " & ownBar.mMaxTeamHeight.ToString)
'    spnlStats.Children.Add(mth)

'    Dim zh = Helpers.MakeTextBlock("ZeroHeight: " & ownBar.zeroheight.Value.ToString)
'    spnlStats.Children.Add(zh)

'    Dim gt = Helpers.MakeTextBlock("Graphtype: " & ownBar.mPaneType.ToString)
'    spnlStats.Children.Add(gt)

'    Dim sp6 As New ctrlVerticalSpacer
'    spnlStats.Children.Add(sp6)

'    Dim cmhead = Helpers.MakeHeadingBlock("Child Mod:")
'    spnlStats.Children.Add(cmhead)
'    If Not ownBar.childSourceColor Is Nothing Then
'      Dim csc = Helpers.MakeTextBlock("ChildSourceColor: " & ownBar.childSourceColor.Color.R.ToString & ", " & _
'                                ownBar.childSourceColor.Color.G.ToString & ", " & _
'                                ownBar.childSourceColor.Color.B.ToString)
'      spnlStats.Children.Add(csc)
'    Else
'      Dim csc2 = Helpers.MakeTextBlock("ChildSourceColor: Nothing")
'      spnlStats.Children.Add(csc2)
'    End If


'    If Not ownBar.childMod Is Nothing Then
'      Dim cm = Helpers.MakeTextBlock(ownBar.childMod.IDItem.FriendlyGuid & " " & ownBar.childMod.TheModValue.mModType.ToString & " P: " & _
'                                  ownBar.childMod.ParentID.FriendlyGuid & " S: " & ownBar.childMod.ModGeneratorID.FriendlyGuid)
'      spnlStats.Children.Add(cm)


'    Else
'      Dim cm = Helpers.MakeTextBlock("ChildMod: Nothing")
'      spnlStats.Children.Add(cm)
'    End If



'    'Dim hsh = Helpers.MakeTextBlock("hScaleHeight: " & ownBar.hScaleHeight.ToString)
'    'spnlStats.Children.Add(hsh)

'    Dim mis = Helpers.MakeTextBlock("mIsSelected: " & ownBar.mIsSelected.ToString)
'    spnlStats.Children.Add(mis)

'#End If
'  End Sub
'  Private Sub LoadMods(themodslifetime As Lifetime)
'    spnlRadModValues.Children.Clear()
'    spnlDireModValues.Children.Clear()

'    Dim themods As List(Of ModifierList)
'    Dim ownhero = mGame.GetHeroInstanceByID(themods.Item(0).Item(0).ParentID)
'    Dim thelife = New Lifetime(mCurTime, mGame.mTimeKeeper.Framerate)
'    Select Case mDetailstype
'      Case eDetailsType.Ability
'        themods = mGame.dbAbilities.GetAbilityModifiers(myAbility.CurrentStateIndex, mGame, _
'                                                              myAbility.AbilityName, myAbility, _
'                                                              ownhero.Id, eSourceType.Hero_Instance, _
'                                                              ownhero.GetEnemyTarget, eSourceType.Hero_Instance, _
'                                                              ownhero.GetFriendlyTarget, eSourceType.Hero_Instance, _
'                                                              ownhero.GetTargetFriendBias, _
'                                                              themodslifetime, ownhero.AghsTime)


'        'curAbilityLevel = myAbility.mAbilityLevel
'      Case eDetailsType.Hero
'        themods = New List(Of ModifierList)
'        themods.Add(New ModifierList)
'        themods.Add(mGame.GetAllModsAffectingHero(myHero.ID))
'        ' curAbilityLevel = 0
'      Case eDetailsType.Item
'        themods = mGame.dbItems.GetItemModifiers(myItem.CurrentStateIndex, mGame, _
'                                                              myItem.ItemName, myItem.Id, _
'                                                              ownhero.Id, eSourceType.Hero_Instance, _
'                                                              ownhero.GetEnemyTarget, eSourceType.Hero_Instance, _
'                                                              ownhero.GetFriendlyTarget, eSourceType.Hero_Instance, _
'                                                              ownhero.GetTargetFriendBias, _
'                                                              themodslifetime, ownhero.AghsTime)



'        'curAbilityLevel = 0
'      Case eDetailsType.Modifier
'        Dim outlist As New ModifierList
'        outlist.Add(myMod)
'        themods = New List(Of ModifierList)
'        themods.Add(outlist)
'        ' curAbilityLevel = 0
'      Case Else
'        Dim x = 2
'    End Select



'    If themods.Item(0) Is Nothing Then
'      themods.RemoveAt(0)
'      themods.Insert(0, New ModifierList)

'    End If
'    If themods.Count > 1 Then
'      If themods.Item(1) Is Nothing Then
'        themods.RemoveAt(1)
'        themods.Insert(1, New ModifierList)
'      End If
'    End If

'    If themods.Count < 2 Then
'      themods.Add(New ModifierList)
'    End If

'    Dim activemodsbyteam = ModFilters.GetArrangedByTeamof1stTargetId(themods.Item(0), mGame)

'    Dim radactives As List(Of ModifierList)
'    Dim direactives As List(Of ModifierList)
'    If Not activemodsbyteam Is Nothing Then
'      If Not activemodsbyteam.Count < 1 Then
'        radactives = ModFilters.GetModsGroupedBySourceIDAndTargetID(activemodsbyteam.Item(0), mGame)
'      End If
'      If Not activemodsbyteam.Count < 2 Then
'        direactives = ModFilters.GetModsGroupedBySourceIDAndTargetID(activemodsbyteam.Item(1), mGame)
'      End If
'    End If



'    Dim passivemodsbyteam = ModFilters.GetArrangedByTeamof1stTargetId(themods.Item(1), mGame)

'    Dim radpassives As List(Of ModifierList)
'    Dim direpassives As List(Of ModifierList)
'    If Not passivemodsbyteam Is Nothing Then
'      If Not passivemodsbyteam.Count < 1 Then
'        radpassives = ModFilters.GetModsGroupedBySourceIDAndTargetID(passivemodsbyteam.Item(0), mGame)
'      End If
'      If Not passivemodsbyteam.Count < 2 Then
'        direpassives = ModFilters.GetModsGroupedBySourceIDAndTargetID(passivemodsbyteam.Item(1), mGame)
'      End If
'    End If




'    If Not radactives Is Nothing Then
'      For i As Integer = 0 To radactives.Count - 1
'        Dim curmods = radactives.Item(i)

'        Dim prt = mGame.GetEntityByID(curmods.Item(0).ParentID)
'        Dim src = mGame.GetEntityByID(curmods.Item(0).ModGeneratorID)
'        Dim themodctrl = New ctrlModDetails(prt, src, curmods, curmods.Item(0).GetLevelAtTime(mCurTime), mCurTime, mGame)
'        spnlRadModValues.Children.Add(themodctrl)
'        mUpdatableMods.Add(themodctrl)
'      Next
'    End If


'    If Not direactives Is Nothing Then
'      For i As Integer = 0 To direactives.Count - 1
'        Dim curmods = direactives.Item(i)

'        Dim prt = mGame.GetEntityByID(curmods.Item(0).ParentID)
'        Dim src = mGame.GetEntityByID(curmods.Item(0).ModGeneratorID)
'        Dim themodctrl = New ctrlModDetails(prt, src, curmods, curmods.Item(0).GetLevelAtTime(mCurTime), mCurTime, mGame)
'        spnlDireModValues.Children.Add(themodctrl)
'        mUpdatableMods.Add(themodctrl)
'      Next
'    End If

'    Dim spacer2 As New ctrlVerticalSpacer
'    spnlRadModValues.Children.Add(spacer2)
'    Dim spacer3 As New ctrlVerticalSpacer
'    spnlDireModValues.Children.Add(spacer3)


'    If Not radpassives Is Nothing Then
'      For i As Integer = 0 To radpassives.Count - 1
'        Dim curmods = radpassives.Item(i)

'        Dim prt = mGame.GetEntityByID(curmods.Item(0).ParentID)
'        Dim src = mGame.GetEntityByID(curmods.Item(0).ModGeneratorID)
'        Dim themodctrl = New ctrlModDetails(prt, src, curmods, curmods.Item(0).GetLevelAtTime(mCurTime), mCurTime, mGame)
'        spnlRadModValues.Children.Add(themodctrl)
'        mUpdatableMods.Add(themodctrl)
'      Next
'    End If

'    If Not direpassives Is Nothing Then
'      For i As Integer = 0 To direpassives.Count - 1
'        Dim curmods = direpassives.Item(i)

'        Dim prt = mGame.GetEntityByID(curmods.Item(0).ParentID)
'        Dim src = mGame.GetEntityByID(curmods.Item(0).ModGeneratorID)


'        Dim themodctrl = New ctrlModDetails(prt, src, curmods, curmods.Item(0).GetLevelAtTime(mCurTime), mCurTime, mGame)
'        spnlDireModValues.Children.Add(themodctrl)
'        mUpdatableMods.Add(themodctrl)
'      Next
'    End If


'  End Sub


'  Private Sub ClearAll()

'    myItem = Nothing
'    myAbility = Nothing
'    myHero = Nothing
'    myMod = Nothing

'    'ownItem = Nothing
'    'ownAbility = Nothing
'    'ownHero = Nothing
'    'ownMod = Nothing

'    mDetailstype = Nothing
'    ' mOwnerType = Nothing

'    mUpdatableMods.Clear()


'    spnlBuildsFromHead.Children.Clear()
'    spnlBuildsFrom.Children.Clear()
'    spnlBuildsToHead.Children.Clear()
'    spnlBuildsTo.Children.Clear()

'    spnlHeadPortrait.Children.Clear()
'    spnlHeadSource.Children.Clear()
'    spnlHeadText.Children.Clear()

'    spnlStats.Children.Clear()
'    spnlStats2.Children.Clear()
'    spnlDescription.Children.Clear()


'    spnlAbilities.Children.Clear()
'    spnlItems.Children.Clear()
'    spnlBodyText.Children.Clear()
'    spnlCommentaryText.Children.Clear()
'    spnlFooter.Children.Clear()
'  End Sub

'  Private Sub LoadUI(thedetailstype As eDetailsType)

'    Select Case thedetailstype
'      Case eDetailsType.Ability

'      Case eDetailsType.Hero

'      Case eDetailsType.Item

'      Case eDetailsType.Modifier

'    End Select


'  End Sub

'  'Private Sub dbMods_Modschanged(theaffected As TypesAndTargets)


'  '  ''if I am a hero, I may no longer be the same hero
'  '  ''so we'll check be regetting hero by his team position
'  '  'If mDetailstype = eDetailsType.Hero Then
'  '  '  Dim heroposition = myHero.mTeamPosition
'  '  '  Dim team = myHero.mTeam
'  '  '  myHero = mGame.GetHerobuildByTeamAndPositionIndex(team, heroposition)
'  '  '  mMyOwnersId = myHero.ID
'  '  'End If


'  '  If theaffected.ContainsKey(mSource.ID.GuidID) Then
'  '    LoadDetails(mGame, objDetailsItem, mDetailstype, mParent, mSource, mCurTime)
'  '  End If
'  'End Sub
'End Class
