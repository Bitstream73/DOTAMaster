Public Class HeroInstance
  Implements iHeroUnit



#Region "Vars"
  Private mID As dvID
  Private mHBuild As HeroBuild
  'shortcuts to mHBuild objects
  Private mGoldCurve As EconomyCurve
  Private mXPCurve As EconomyCurve


  Private mGame As dGame
  'Shortcuts mGame Objects
  ' Private mTimeKeeper As TimeKeeper

  'Private dbImages As Image_Database
  Private dbMods As Modifier_Database
  Private dbcreepsandpets As Creeps_and_Pets_Database
  Private mLog As iLogging


  Private mItemInv As Hero_Item_Inventory
  Private mActiveItemsByLevel As New Item_List


  Private mAbilityInventory As Hero_Ability_Inventory

  Private mColor As Color = Nothing

  Public mTeam As dTeam
  Public mTeamPosition As Integer = -1

  'target stuff
  Private mTeamEnemyTarget As iDisplayUnit
  Private mTeamFriendlyTarget As iDisplayUnit
  Private mTargetFriendBias As Boolean

  'pets, illusions creeps
  Private mPetsOwned As List(Of PetStack)

  ' Private thetimepoints As DDFrame_List
  Private herolevellifetimes As Lifetime

  Private mselfmodinfo As modInfo

  Private mModInfoOffense As modInfo

  Public Event TargetsChanged(gameentity As iGameEntity)
  'testing
  Shared modchangedtime As Integer
  Shared modchangedcount As Integer

  Private ModsCalculated As Boolean = False
  Private mPrimaryStat As Stat
  'accidentally deleted all instances of this in class :/ fuck
  Event isDirty(hero As iPlayerUnit)
#End Region
  Public Sub New(build As HeroBuild, _
                 herocolor As Color, _
                 game As dGame, _
                 moddb As Modifier_Database, _
                 creepdb As Creeps_and_Pets_Database, _
                 log As iLogging)

    mID = New dvID(Guid.NewGuid, "HeroInstance.New" & build.mHero.Name.ToString, eEntity.Hero_Instance)
    mHBuild = build
    mHBuild.mBuild.ItemList.UpdateParent(Me)

    mGame = game
    mLog = log
    dbMods = moddb
    dbcreepsandpets = creepdb


    mGoldCurve = build.GoldCurve
    mXPCurve = build.XPCurve

    mColor = herocolor

    ' GetAbilityInfos(mGame)

    If Not mGoldCurve Is Nothing And Not mXPCurve Is Nothing And Not mGame Is Nothing Then

      Load(mXPCurve, mGoldCurve, mGame)
    End If

    mselfmodinfo = New modInfo(eAbilityType.Passive, _
                         Me, _
                         Me, _
                         Me, eUnit.untSelf, "", eModifierCategory.Passive)

    mModInfoOffense = New modInfo(eAbilityType.UnitTarget, _
                                  Me, _
                                  Me, Me.mTeamEnemyTarget, eUnit.untEnemyUnit, "", eModifierCategory.Active)

  End Sub

  Public Sub SubscribeToModUpdates()
    AddHandler dbMods.Modschanged, AddressOf dmMods_Modschanged
  End Sub

  Public Sub Load(thexpcurve As EconomyCurve, thegoldcurve As EconomyCurve, thegame As dGame)
    mXPCurve = thexpcurve
    mGoldCurve = thegoldcurve
    herolevellifetimes = Me.GetLifeSpansForAllLevels
    mGame = thegame

    mItemInv = New Hero_Item_Inventory(Me, mGoldCurve, mXPCurve, mHBuild.mBuild.ItemList, mGame)
    mAbilityInventory = New Hero_Ability_Inventory(mGame)

    mAbilityInventory.load(Me)

  End Sub

#Region "Info"


  Public Property DisplayName As String Implements iGameEntity.DisplayName
    Get
      Return mHBuild.FriendlyName
    End Get
    Set(value As String)

    End Set
  End Property
  Public Property UnitType As eUnittype Implements iUnit.UnitType
    Get
      Return eUnittype.Hero
    End Get
    Set(value As eUnittype)

    End Set
  End Property




  Public Property UnitName As eUnit Implements iUnit.UnitName
    Get
      Throw New NotImplementedException
    End Get
    Set(value As eUnit)

    End Set
  End Property

  Public Property ImageUrl As Uri Implements iDisplayUnit.ImageUrl
    Get
      Return New Uri(mHBuild.mHero.UnitImage)
    End Get
    Set(value As Uri)

    End Set
  End Property

  Public Property Bio As String Implements iPlayerUnit.Bio
    Get
      Return mHBuild.mHero.Bio
    End Get
    Set(value As String)

    End Set
  End Property

  Public Property WebPageUrl As Uri Implements iDisplayUnit.WebPageUrl
    Get
      Throw New NotImplementedException
    End Get
    Set(value As Uri)

    End Set
  End Property

  Public Property EntityName As eEntity Implements iGameEntity.EntityName
    Get
      Return eEntity.Hero_Instance
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

  Public Property ParentGameEntity As iGameEntity Implements iGameEntity.ParentGameEntity
    Get
      Return Me.Team
    End Get
    Set(value As iGameEntity)

    End Set
  End Property

  Public Property HeroName As eHeroName Implements iHeroUnit.HeroName
    Get
      Return mHBuild.mHero.Name
    End Get
    Set(value As eHeroName)

    End Set
  End Property

  Public Property Team As dTeam Implements iDisplayUnit.Team
    Get
      Return mTeam
    End Get
    Set(value As dTeam)

    End Set
  End Property

  Public Property MyColor As Color Implements iDisplayUnit.MyColor
    Get
      Return mColor
    End Get
    Set(value As Color)

      mColor = value

    End Set
  End Property

  Public Property Roles As List(Of eRole) Implements iHeroUnit.Roles
    Get
      Return mHBuild.mHero.Roles
    End Get
    Set(value As List(Of eRole))

    End Set
  End Property


  Public Function GetLevelForTime(thetime As ddFrame) As Integer Implements iPlayerUnit.GetLevelForTime
    Return mXPCurve.GetLevelForTime(thetime)
  End Function

  Public Property MyType As eSourceType Implements iGameEntity.MyType
    Get
      Return eSourceType.Hero_Instance
    End Get
    Set(value As eSourceType)

    End Set
  End Property

  Public Property ParentGameEntityType As eSourceType Implements iGameEntity.ParentGameEntityType
    Get
      Return eSourceType.Team
    End Get
    Set(value As eSourceType)

    End Set
  End Property
#End Region

#Region "Targeting"

  Public Sub SetTargets(theenemytarget As iDisplayUnit, thefriendlytarget As iDisplayUnit, isfriendbias As Boolean) Implements iDisplayUnit.SetTargets

    If mTeamEnemyTarget Is Nothing Or mTeamFriendlyTarget Is Nothing Then

      mTeamEnemyTarget = theenemytarget
      mTeamFriendlyTarget = thefriendlytarget
      mTargetFriendBias = isfriendbias

      '  mHBuild.mBuild.UpdateTargets(mTeamEnemyTarget, mTeamFriendlyTarget, mTargetFriendBias)
      mItemInv.UpdateAllItemsTargets(mTeamEnemyTarget, mTeamFriendlyTarget, mTargetFriendBias)

      mAbilityInventory.AbilitiesListedByUIPosition.updateTargets(mTeamEnemyTarget, mTeamFriendlyTarget, mTargetFriendBias)

    Else
      If mTeamEnemyTarget.Id.GuidID = theenemytarget.Id.GuidID And mTeamFriendlyTarget.Id.GuidID = thefriendlytarget.Id.GuidID And mTargetFriendBias = isfriendbias Then Exit Sub

      mTeamEnemyTarget = theenemytarget
      mTeamFriendlyTarget = thefriendlytarget
      mTargetFriendBias = isfriendbias

      ' mHBuild.mBuild.UpdateTargets(mTeamEnemyTarget, mTeamFriendlyTarget, mTargetFriendBias)
      mItemInv.UpdateAllItemsTargets(mTeamEnemyTarget, mTeamFriendlyTarget, mTargetFriendBias)

      mAbilityInventory.AbilitiesListedByUIPosition.updateTargets(mTeamEnemyTarget, mTeamFriendlyTarget, mTargetFriendBias)


    End If

  End Sub

  Public Function GetEnemyTarget() As iDisplayUnit Implements iDisplayUnit.GetEnemyTarget
    Return mTeamEnemyTarget
  End Function

  Public Function GetFriendlyTarget() As iDisplayUnit Implements iDisplayUnit.GetFriendlyTarget
    Return mTeamFriendlyTarget
  End Function

  Public Function GetTargetFriendBias() As Boolean Implements iDisplayUnit.GetTargetFriendBias
    Return mTargetFriendBias
  End Function

#End Region

#Region "Stats"

  Public Sub CalcMods() Implements iGameEntity.calcmods
    If ModsCalculated Then Exit Sub


    Dim mymods As New ModifierList
    Dim mystats As New List(Of Stat)

    mymods.Add(CalcNumber1)

    mymods.Add(CalcNumperPoint06)

    mymods.Add(CalcBaseGold())

    mymods.Add(CalcPeriodicGold)

    mymods.Add(CalcBaseXP)


    For i As Integer = 0 To mAbilityInventory.AbilitiesListedByUIPosition.Count - 1
      Dim currentability = mAbilityInventory.AbilitiesListedByUIPosition.Item(i)

      Dim thelists As List(Of ModifierList)
      If Not Me.mTeamEnemyTarget Is Nothing Then
        Dim x = 2
      End If

      thelists = mGame.dbAbilities.GetAbilityModifiers(-1, mGame, _
                                                             currentability, _
                                                             Me, _
                                                             Me.mTeamEnemyTarget, _
                                                             Me.mTeamFriendlyTarget, _
                                                             Me.mTargetFriendBias, _
                                                             currentability.Lifetime, mItemInv.GetAghsLifetime)


      For x As Integer = 0 To thelists.Count - 1
        mymods.AddList(thelists.Item(x))
      Next
    Next


    'load item mods
    mymods.AddList(CalcItemsMods)


    'dayvision
    mymods.Add(CalcDayVision)

    'nightvision
    mymods.Add(CalcNightVision)




    'Dim myddobject As New DDObject(Me, eEntity.Hero_Instance)

    'Strength
    'Base Str
    mymods.Add(CalcBaseStrength)

    'Str increment
    mymods.Add(CalcStrengthIncrement())


    'str
    Dim str As New Stat(eStattype.Strength, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.Strength))
    mystats.Add(str)



    'Agility

    'Base Agi
    mymods.Add(CalcBaseAgility())

    'Agi Increment
    mymods.Add(CalcAgilityIncrement)


    'Agi
    Dim agi As New Stat(eStattype.Agility, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.Agility))
    mystats.Add(agi)


    'Intelligence
    'BaseInd
    mymods.Add(CalcBaseIntelligence())

    'Int Increment
    mymods.Add(CalcIntelIncrement)

    'Int
    Dim int As New Stat(eStattype.Intelligence, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.Intelligence))
    mystats.Add(int)

    'primary attribute
    Dim priattr As New Stat(eStattype.PrimaryAttribute, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.PrimaryAttribute))
    mystats.Add(priattr)


    'base movespeed
    mymods.Add(CalcBaseMoveSpeed())

    'attack speed
    'Base Attspeed
    mymods.Add(CalcBaseAttSpeed)

    'Attspeeed
    Dim attspd As New Stat(eStattype.AttackSpeed, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.AttackSpeed))
    mystats.Add(attspd)

    'Missile speed
    mymods.Add(CalcMissileSpeed)

    'attack range
    mymods.Add(CalcAttackRange())

    'Right-click damage (Attack damage)
    'base attdamage

    Dim dams = CalcRDamageValues()
    mymods.Add(dams.Item(0))

    mymods.Add(dams.Item(1))


    'avg base damage for calc of physical damage
    mymods.Add(dams.Item(2))

    'base armor pos and neg
    Dim armpos As New modValue(mHBuild.mHero.BaseArmor, _
                               eModifierType.BaseArmor, mGame.TimeKeeper.GameLifetime)
    Dim armposmod As New Modifier(armpos, mselfmodinfo)
    mymods.Add(armposmod)


    'kills for gold modifier
    Dim kills As New ValueList(mGame.TimeKeeper.TimePoints.TheFrames)

    For i As Integer = 0 To mGame.TimeKeeper.TimePoints.TheFrames.Count - 1
      Dim curframe = mGame.TimeKeeper.TimePoints.TheFrames.Item(i)
      Dim val = Me.GetKillsForGold(curframe, Constants.cGoldPerKill)
      kills.Add(curframe, val)
    Next
    Dim goldkills As New modValue(kills, eModifierType.KillsPerGoldIncrement, mGame.TimeKeeper.GameLifetime, AghsLifetime)
    Dim goldkillsmod As New Modifier(goldkills, mselfmodinfo)
    mymods.Add(goldkillsmod)

    'resource modifier
    Dim resval As New modValue(mGoldCurve.Percentage, eModifierType.ResourceShare, mGame.TimeKeeper.GameLifetime)

    Dim resmod As New Modifier(resval, mselfmodinfo)
    mymods.Add(resmod)



    'add stats and mods we have so far so they are available for next calcs
    dbMods.RemoveAllHeroModsAndStatsByHero(Me)
    dbMods.ReplaceStats(mystats, Nothing)
    dbMods.ReplaceModifiers(mymods, Nothing)



    'add mod for damage from primary attribute if I am str hero
    mymods.Add(CalcPrimaryStatDamage)


    'net attdamage
    Dim netattlow As New Stat(eStattype.AttackDamageLow, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.AttackDamageLow))
    mystats.Add(netattlow)

    Dim netatthigh As New Stat(eStattype.AttackDamageHigh, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.AttackDamageHigh))
    mystats.Add(netatthigh)

    Dim netattavg As New Stat(eStattype.AttackDamageAverage, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.AttackDamageAverage))
    mystats.Add(netattavg)



    Dim movesp As New Stat(eStattype.MovementSpeed, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.MovementSpeed))
    mystats.Add(movesp)

    'physical armor
    Dim pharm As New Stat(eStattype.PhysicalArmor, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.PhysicalArmor))
    mystats.Add(pharm)

    'magic resistanec
    Dim magresist As New Stat(eStattype.MagicalDamageResistance, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.MagicalDamageResistance))
    mystats.Add(magresist)

    'magic immunity
    Dim magimm As New Stat(eStattype.MagicImmunity, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.MagicImmunity))
    mystats.Add(magimm)

    'HP
    Dim hitp As New Stat(eStattype.HitPoints, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.HitPoints))
    mystats.Add(hitp)

    'HP regen
    Dim hpreg As New Stat(eStattype.HitPointRegen, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.HitPointRegen))
    mystats.Add(hpreg)


    'Mana
    Dim mana As New Stat(eStattype.Mana, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.Mana))
    mystats.Add(mana)

    'Mana regen
    Dim manar As New Stat(eStattype.ManaRegen, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.ManaRegen))
    mystats.Add(manar)



    'TotalGold
    Dim gld As New Stat(eStattype.Networth, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.Networth))
    mystats.Add(gld)


    'periodic gold
    Dim pgld As New Stat(eStattype.PeriodicGold, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.PeriodicGold))
    mystats.Add(pgld)

    'kills stat
    Dim killstat As New Stat(eStattype.Kills, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.Kills))
    mystats.Add(killstat)




    'resource share
    Dim res As New Stat(eStattype.Resources, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.Resources))
    mystats.Add(res)



    'xp stat
    Dim xpstat As New Stat(eStattype.Experience, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.Experience))
    mystats.Add(xpstat)


    'vision
    Dim vis As New Stat(eStattype.VisionDay, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.VisionDay))
    mystats.Add(vis)

    'vision night
    Dim nvis As New Stat(eStattype.VisionNight, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.VisionNight))
    mystats.Add(nvis)

    'TrueSight
    Dim Tru As New Stat(eStattype.TrueSight, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.TrueSight))
    mystats.Add(Tru)

    'stealth
    Dim ste As New Stat(eStattype.Stealth, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.Stealth))
    mystats.Add(ste)

    'Attack range
    Dim attr As New Stat(eStattype.AttackRange, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.AttackRange))
    mystats.Add(attr)

    'stealth
    Dim stlth As New Stat(eStattype.Stealth, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.Stealth))
    mystats.Add(stlth)

    'missilespeed
    Dim missl As New Stat(eStattype.MissileSpeed, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.MissileSpeed))
    mystats.Add(missl)

    'base attack time
    Dim baseatt As New Stat(eStattype.BaseAttackTime, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.BaseAttackTime))
    mystats.Add(baseatt)

    'critchance
    Dim critch As New Stat(eStattype.CritChance, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.CritChance))
    mystats.Add(critch)


    'critdamage
    Dim critd As New Stat(eStattype.CritDamage, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.CritDamage))
    mystats.Add(critd)

    'critmulti
    Dim critm As New Stat(eStattype.CritMultiplier, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.CritMultiplier))
    mystats.Add(critm)

    'physical damage
    Dim physdam As New Stat(eStattype.PhysicalDamage, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.PhysicalDamage))
    mystats.Add(physdam)

    'magic damage
    Dim magdam As New Stat(eStattype.MagicDamage, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.MagicDamage))
    mystats.Add(magdam)

    'pure damage
    Dim puredam As New Stat(eStattype.PureDamage, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.PureDamage))
    mystats.Add(puredam)

    'hp removal
    Dim hpdam As New Stat(eStattype.HPRemoval, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.HPRemoval))
    mystats.Add(hpdam)

    'alldamage
    Dim alldam As New Stat(eStattype.AllDamageBurst, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.AllDamageBurst))
    mystats.Add(alldam)

    ''negative regen
    'Dim neg As New Stat(eStat.ne)

    'effective hitpoint
    Dim effhp As New Stat(eStattype.EffectiveHP, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.EffectiveHP))
    mystats.Add(effhp)

    'spellimmunitycount
    Dim spcount As New Stat(eStattype.SpellImmunityCount, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.SpellImmunityCount))
    mystats.Add(spcount)

    'stun duration
    Dim stundur As New Stat(eStattype.Stun, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.Stun))
    mystats.Add(stundur)

    'hex duration
    Dim hexdur As New Stat(eStattype.Hex, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.Hex))
    mystats.Add(hexdur)




    'helpers
    Dim onen As New Stat(eStattype.Number1, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.Number1))
    mystats.Add(onen)

    Dim p06 As New Stat(eStattype.NumberPoint06, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.NumberPoint06))
    mystats.Add(p06)

    Dim porarm As New Stat(eStattype.ArmorxPoint06, Me, mGame) ', mGame.dbNames.GetFriendlyStatName(eStattype.ArmorxPoint06))
    mystats.Add(porarm)

    dbMods.RemoveAllHeroModsAndStatsByHero(Me)

    dbMods.ReplaceStats(mystats, Nothing)
    dbMods.ReplaceModifiers(mymods, Nothing)


    mHBuild.mBuild.calcmods()
    mHBuild.mHero.calcmods()

    ModsCalculated = True
  End Sub

#Region "ModsIO"

  Private Function CalcBaseGold() As Modifier
    Dim basegld As New ValueList(mGame.TimeKeeper.TimePoints.TheFrames)
    basegld.values = mGoldCurve.Values

    Dim goldval As New modValue(basegld, eModifierType.BaseGold, mGame.TimeKeeper.GameLifetime, Nothing)

    Return New Modifier(goldval, mselfmodinfo)
  End Function

  Private Function CalcPeriodicGold() As Modifier
    Dim pgold As New ValueList(mGame.TimeKeeper.TimePoints.TheFrames)
    pgold.values = Goldcurve.PeriodicGold

    Dim pgval As New modValue(pgold, eModifierType.PeriodicGold, mGame.TimeKeeper.GameLifetime, AghsLifetime)

    Return New Modifier(pgval, mselfmodinfo)
  End Function
  Private Function CalcBaseXP() As Modifier
    Dim basexp As New ValueList(mGame.TimeKeeper.TimePoints.TheFrames)
    basexp.values = mXPCurve.Values

    Dim xpval As New modValue(basexp, eModifierType.BaseXP, mGame.TimeKeeper.GameLifetime, Nothing)

    Return New Modifier(xpval, mselfmodinfo)
  End Function

  Private Function CalcBaseStrength() As Modifier
    Dim mBaseStrval As New modValue(mHBuild.mHero.BaseStrength, eModifierType.BaseStr, mGame.TimeKeeper.GameLifetime)
    Return New Modifier(mBaseStrval, mselfmodinfo)
  End Function

  Private Function CalcBaseAgility() As Modifier
    Dim mBaseAgival As New modValue(mHBuild.mHero.BaseAgility, eModifierType.BaseAgi, mGame.TimeKeeper.GameLifetime)
    Return New Modifier(mBaseAgival, mselfmodinfo)
  End Function

  Private Function CalcBaseIntelligence() As Modifier
    Dim mbaseIntval As New modValue(mHBuild.mHero.BaseIntelligence, eModifierType.BaseInt, mGame.TimeKeeper.GameLifetime)
    Return New Modifier(mbaseIntval, mselfmodinfo)
  End Function

  Private Function CalcStrengthIncrement() As Modifier
    Dim strincval = Me.mHBuild.mHero.StrengthIncrement
    Dim sinc As New ValueWrapper(Nothing, strincval, strincval * 2, strincval * 3, strincval * 4, strincval * 5, _
                                 strincval * 6, strincval * 7, strincval * 8, strincval * 9, strincval * 10, _
                                 strincval * 11, strincval * 12, strincval * 13, strincval * 14, strincval * 15, _
                                 strincval * 16, strincval * 17, strincval * 18, strincval * 19, strincval * 20, _
                                 strincval * 21, strincval * 22, strincval * 23, strincval * 24)
    Dim mStrInc As New modValue(sinc, eModifierType.StrIncrementAdded, herolevellifetimes, AghsLifetime)
    Return New Modifier(mStrInc, mselfmodinfo)
  End Function

  Private Function CalcAgilityIncrement() As Modifier
    Dim agiincval = Me.mHBuild.mHero.AgilityIncrement
    Dim ainc As New ValueWrapper(Nothing, agiincval, agiincval * 2, agiincval * 3, agiincval * 4, agiincval * 5, _
                                 agiincval * 6, agiincval * 7, agiincval * 8, agiincval * 9, agiincval * 10, _
                                 agiincval * 11, agiincval * 12, agiincval * 13, agiincval * 14, agiincval * 15, _
                                 agiincval * 16, agiincval * 17, agiincval * 18, agiincval * 19, agiincval * 20, _
                                 agiincval * 21, agiincval * 22, agiincval * 23, agiincval * 24)
    Dim miaginc As New modValue(ainc, eModifierType.AgiIncrementAdded, herolevellifetimes, AghsLifetime)
    Return New Modifier(miaginc, mselfmodinfo)

  End Function

  Private Function CalcIntelIncrement() As Modifier
    Dim intincval = Me.mHBuild.mHero.IntelligenceIncrement
    Dim iinc As New ValueWrapper(Nothing, intincval, intincval * 2, intincval * 3, intincval * 4, intincval * 5, _
                                 intincval * 6, intincval * 7, intincval * 8, intincval * 9, intincval * 10, _
                                 intincval * 11, intincval * 12, intincval * 13, intincval * 14, intincval * 15, _
                                 intincval * 16, intincval * 17, intincval * 18, intincval * 19, intincval * 20, _
                                 intincval * 21, intincval * 22, intincval * 23, intincval * 24)
    Dim mintinc As New modValue(iinc, eModifierType.IntIncrementAdded, herolevellifetimes, AghsLifetime)
    Return New Modifier(mintinc, mselfmodinfo)
  End Function

  Private Function CalcBaseMoveSpeed() As Modifier
    Dim mbasemovesp As New modValue(mHBuild.mHero.BaseMovementSpeed, eModifierType.BaseMovementSpeed, mGame.TimeKeeper.GameLifetime)
    Return New Modifier(mbasemovesp, mselfmodinfo)
  End Function

  Private Function CalcBaseAttSpeed() As Modifier
    Dim mbaseattspdval As New modValue(mHBuild.mHero.BaseAttackSpeed, eModifierType.BaseAttackTime, mGame.TimeKeeper.GameLifetime, AghsLifetime)
    Return New Modifier(mbaseattspdval, mselfmodinfo)
  End Function

  Private Function CalcDayVision() As Modifier
    Dim val As New modValue(mHBuild.mHero.BaseDayVision, eModifierType.VisionDay, mGame.TimeKeeper.DayLifetime)
    Return New Modifier(val, mselfmodinfo)
  End Function

  Private Function CalcNightVision() As Modifier
    Dim val As New modValue(mHBuild.mHero.BaseNightVision, eModifierType.VisionNight, mGame.TimeKeeper.NightLifetime)
    Return New Modifier(val, mselfmodinfo)
  End Function

  Private Function CalcNumber1() As Modifier
    Dim mone As New modValue(1, eModifierType.Number1, mGame.TimeKeeper.GameLifetime)

    Return New Modifier(mone, mselfmodinfo)
  End Function

  Private Function CalcNumperPoint06() As Modifier
    Dim mp As New modValue(0.06, eModifierType.NumberPoint06, mGame.TimeKeeper.GameLifetime)

    Return New Modifier(mp, mselfmodinfo)
  End Function

  Private Function CalcMissileSpeed() As Modifier
    Dim misspeed As New modValue(mHBuild.mHero.MissileSpeed, eModifierType.MissileSpeed, mGame.TimeKeeper.GameLifetime)
    Return New Modifier(misspeed, mselfmodinfo)
  End Function

  Private Function CalcAttackRange() As Modifier
    Dim rangeval As New modValue(mHBuild.mHero.AttackRange, eModifierType.BaseAttackRange, mGame.TimeKeeper.GameLifetime, AghsLifetime)
    Return New Modifier(rangeval, mselfmodinfo)
  End Function

  Private Function CalcRDamageValues() As List(Of Modifier)
    Dim outlist As New List(Of Modifier)

    Dim primaryattvalue As Double
    Select Case mHBuild.mHero.PrimaryStat
      Case ePrimaryStat.Intelligence
        primaryattvalue = mHBuild.mHero.BaseIntelligence
      Case ePrimaryStat.Agility
        primaryattvalue = mHBuild.mHero.BaseAgility
      Case ePrimaryStat.Strength
        primaryattvalue = mHBuild.mHero.BaseStrength
      Case Else
        primaryattvalue = 0
        Dim x = 2

    End Select

    'need to remove primary attribute value since value scraped from site includes it
    Dim rdamvallow As New modValue(mHBuild.mHero.BaseAttackDamageLow - primaryattvalue, eModifierType.BaseAttackDamageLow, mGame.TimeKeeper.GameLifetime)
    outlist.Add(New Modifier(rdamvallow, mModInfoOffense))

    Dim rdamvalhi As New modValue(mHBuild.mHero.BaseAttackDamageHigh - primaryattvalue, eModifierType.BaseAttackDamageHigh, mGame.TimeKeeper.GameLifetime)
    outlist.Add(New Modifier(rdamvalhi, mModInfoOffense))

    Dim rdamvalavg As New modValue(((mHBuild.mHero.BaseAttackDamageHigh - primaryattvalue) + (mHBuild.mHero.BaseAttackDamageLow - primaryattvalue)) \ 2, _
                                eModifierType.BaseAttackDamageAvg, mGame.TimeKeeper.GameLifetime)
    outlist.Add(New Modifier(rdamvalavg, mModInfoOffense))

    Return outlist
  End Function

  Private Function CalcPrimaryStatDamage() As Modifier


    Dim primarystatdam As modValue
    Select Case Me.mHBuild.mHero.PrimaryStat
      Case ePrimaryStat.Agility

        primarystatdam = New modValue(dbMods.GetStatByParentandType(Me, eStattype.Agility).GetValueList, _
                                      eModifierType.RightClickDamageFromPrimaryAtt, mGame.TimeKeeper.GameLifetime, AghsLifetime)
      Case ePrimaryStat.Intelligence
        primarystatdam = New modValue(dbMods.GetStatByParentandType(Me, eStattype.Intelligence).GetValueList, _
                                      eModifierType.RightClickDamageFromPrimaryAtt, mGame.TimeKeeper.GameLifetime, AghsLifetime)
      Case ePrimaryStat.Strength

        primarystatdam = New modValue(dbMods.GetStatByParentandType(Me, eStattype.Strength).GetValueList, _
                                      eModifierType.RightClickDamageFromPrimaryAtt, mGame.TimeKeeper.GameLifetime, AghsLifetime)
      Case Else
        Throw New NotImplementedException
    End Select

    Return New Modifier(primarystatdam, mModInfoOffense)



  End Function

  Private Function CalcItemsMods() As List(Of Modifier)
    Dim outmods As New ModifierList()
    For i As Integer = 0 To mItemInv.mItemBuildAndAutoGeneratedItems.Count - 1
      If Not mItemInv.mItemBuildAndAutoGeneratedItems.Item(i).ItemName = eItemname.None Then
        Dim thelist As ModifierList
        Dim curinfo As Item_Info = mItemInv.mItemBuildAndAutoGeneratedItems.Item(i)

        thelist = CalcItemMods(curinfo)

        outmods.AddList(thelist)

      End If

    Next

    Return outmods
  End Function

  Private Function CalcItemMods(theitem As Item_Info) As ModifierList

    Dim thelists = mGame.dbItems.GetItemModifiers(theitem.CurrentStateIndex, mGame, _
                                                        theitem.ItemName, theitem, Me, _
                                                        Me.mTeamEnemyTarget, _
                                                        Me.mTeamFriendlyTarget, _
                                                        Me.mTargetFriendBias, theitem.Lifetime, mItemInv.GetAghsLifetime)
    Dim outlist As New ModifierList

    For i As Integer = 0 To thelists.Count - 1

      outlist.AddList(thelists.Item(i))

    Next

    Return outlist
  End Function

  Private Function GetLifeSpansForAllLevels() As Lifetime
    Dim starttimes As New List(Of ddFrame)
    Dim endtimes As New List(Of ddFrame)
    Dim curlifetime As Lifetime
    For i As Integer = 1 To 25

      If i = 22 Then
        Dim x = 2
      End If

      curlifetime = GetLifeSpanForLevel(i)
      If Not curlifetime Is Nothing Then
        Dim newstart = curlifetime.StartTimes.Item(0)
        Dim newend = curlifetime.EndTime

        If newend Is Nothing Then
          Dim x = 2
        End If

        If newstart Is Nothing Or newend Is Nothing Then
          Dim x = 2
        End If

        starttimes.Add(newstart)
        endtimes.Add(newend)


      End If

    Next

    Return New Lifetime(starttimes, endtimes)
  End Function
  Private Function GetLifeSpanForLevel(thelevel As Integer) As Lifetime
    If thelevel > 25 Or thelevel < 1 Then Return Nothing
    If thelevel = 25 Then
      Dim x = 2
    End If


    Dim xpperlevel = mXPCurve.XPNeededPerLevel


    Dim xp = xpperlevel.Item(thelevel - 1)
    Dim starttime = mXPCurve.GetTimeforValue(xp)


    Dim endtime As ddFrame
    If Not thelevel = xpperlevel.Count Then
      endtime = mXPCurve.GetTimeforValue(xpperlevel.Item(thelevel))
    Else
      endtime = mXPCurve.GetTimeforValue(xpperlevel.Item(xpperlevel.Count - 1))
    End If

    If Not starttime Is Nothing Then
      If endtime Is Nothing Then
        endtime = mGame.TimeKeeper.GameEnd
      End If
      Return New Lifetime(starttime, endtime)

    Else
      Return Nothing
    End If



  End Function


  Private Function GetGoldForTime(thetime As ddFrame) As Integer

    Return mGoldCurve.GetValueForTime(thetime) + Constants.cStartingGold

  End Function


  Public Sub CalcItemTimings()
    mItemInv.UpdateItemSequence(Me, mGoldCurve, mXPCurve, mHBuild.mBuild.ItemList, mGame)
  End Sub

  ''' <summary>
  ''' returns a list of all apgradable abilites for a herolevel
  ''' </summary>
  ''' <param name="herolevel"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Private Function GetUpgradableAbilitiesByLevel(herolevel As Integer) As Ability_Info_List
    Return mAbilityInventory.GetUpgradableAbilitiesByLevel(herolevel)
  End Function

  Private Function GetTimeForLevel(thelevel As Integer) As ddFrame
    If thelevel <= 1 Then Return mGame.TimeKeeper.GameStart

    Return mXPCurve.GetTimeforValue(mXPCurve.XPNeededPerLevel(thelevel - 2))


  End Function



  Private Function GetNewAbilityByLevel(herolevel As Integer) As Ability_Info

    Return mAbilityInventory.GetNewAbilityByLevel(herolevel)
  End Function


  Private Sub dmMods_Modschanged(theaffected As TypesAndTargets)
    Try

      Dim ti As New Stopwatch
      ti.Start()
      Dim dirtystats As New List(Of eStattype)
      If theaffected.ModTargetsnTypes.ContainsKey(Me.Id.GuidID) Then

        Dim curmodtypes = theaffected.ModTargetsnTypes.Item(Me.Id.GuidID)

        For i As Integer = 0 To curmodtypes.Count - 1



          Dim curstats = mGame.dbFormulas.GetStatsDependentOnMod(curmodtypes.Item(i))
          If Not curstats Is Nothing Then
            For x As Integer = 0 To curstats.Count - 1
              If Not dirtystats.Contains(curstats.Item(x)) Then
                dirtystats.Add(curstats.Item(x))
              End If

            Next
          End If



        Next
        If theaffected.StatTargetsnTypes.ContainsKey(Me.Id.GuidID) Then


          Dim stats = theaffected.StatTargetsnTypes.Item(Me.Id.GuidID)
          For x As Integer = 0 To stats.Count - 1
            Dim thestats = mGame.dbFormulas.GetStatsDependentonStat(stats.Item(x))
            If Not thestats Is Nothing Then
              For y As Integer = 0 To thestats.Count - 1
                If Not dirtystats.Contains(thestats.Item(y)) Then
                  dirtystats.Add(thestats.Item(y))
                End If
              Next
            End If
          Next

        End If


        RefreshStats(dirtystats)


      End If

      ti.Stop()
      modchangedcount += 1
      modchangedtime += ti.ElapsedMilliseconds
      PageHandler.theLog.WriteTestLog(Me.HeroName.ToString & ".ModsChanged dur: " & ti.ElapsedMilliseconds & " count: " & modchangedcount & " ttl time: " & modchangedtime)
    Catch ex As Exception
      Dim x = 2
    End Try

  End Sub


  Private Sub RefreshStats(thestats As List(Of eStattype))

    For i As Integer = 0 To thestats.Count - 1
      RefreshStat(thestats.Item(i))
    Next

  End Sub
  Private Sub RefreshStat(thestat As eStattype)
    Dim curstat = dbMods.GetStatByParentandType(Id, thestat)

    If Not curstat Is Nothing Then
      curstat.ReCalcStat()
    Else
      mLog.Writelog("HeroBuild.RefreshStat called dbmodifier with no StatType: " & thestat.ToString)
    End If

  End Sub



#End Region

  Private Sub CalcPrimaryStat()
    Select Case mHBuild.mHero.PrimaryStat
      Case ePrimaryStat.Agility
        mPrimaryStat = dbMods.GetStatByParentandType(Me.Id, eStattype.Agility)
      Case ePrimaryStat.Intelligence
        mPrimaryStat = dbMods.GetStatByParentandType(Me.Id, eStattype.Intelligence)
      Case ePrimaryStat.Strength
        mPrimaryStat = dbMods.GetStatByParentandType(Me.Id, eStattype.Strength)
      Case ePrimaryStat.None
        Throw New NotImplementedException
    End Select
  End Sub

  Public Property BaseMagicResistance As Double Implements iPlayerUnit.BaseMagicResistance
    Get
      Throw New NotImplementedException
    End Get
    Set(value As Double)

    End Set
  End Property

  Public Function IsStealthed(currenttime As ddFrame) As Boolean

    Return False
    'can possibly fudge this with searching build for items that would enable stealth and then return true. 
    'wouldn() 't be time specific but since this is called by GetAffectedUnitIDsForMod it won't be updated 
    'when scrolling thru time
  End Function
  'Public Property AbilityInventory As iAbility_Inventory Implements iDisplayUnit.AbilityInventory
  '  Get
  '    Return mAbilityInventory
  '  End Get
  '  Set(value As iAbility_Inventory)

  '  End Set
  'End Property

  Public Property Armor As Stat Implements iDisplayUnit.Armor
    Get
      Return mGame.dbModifiers.GetStatByParentandType(Me, eStattype.PhysicalArmor)
    End Get
    Set(value As Stat)

    End Set
  End Property

  Public Property HitPoints As Stat Implements iDisplayUnit.HitPoints
    Get
      Return mGame.dbModifiers.GetStatByParentandType(Me, eStattype.HitPoints)
    End Get
    Set(value As Stat)

    End Set
  End Property
  Public Property Lifetime As Lifetime Implements iDisplayUnit.Lifetime
    Get
      Return mGame.TimeKeeper.GameLifetime
    End Get
    Set(value As Lifetime)

    End Set
  End Property

  Public Property MovementSpeed As Stat Implements iDisplayUnit.MovementSpeed
    Get
      Return mGame.dbModifiers.GetStatByParentandType(Me, eStattype.MovementSpeed)
    End Get
    Set(value As Stat)

    End Set
  End Property

  Public Function GetBuild() As Build Implements iHeroUnit.GetBuild
    Return Me.mHBuild.mBuild
  End Function

  'Public Function GetCurrentGold(time As ddFrame) As Integer Implements iHeroUnit.GetCurrentGold
  '  Return mGame.dbModifiers.GetStatByParentandType(Me, eStattype.Networth).GetValue(time)
  'End Function

  Public Function GetHero() As Hero Implements iHeroUnit.GetHero
    Return Me.mHBuild.mHero
  End Function

  Public Property Goldcurve As EconomyCurve Implements iHeroUnit.Goldcurve
    Get
      Return mGoldCurve
    End Get
    Set(value As EconomyCurve)

    End Set
  End Property

  Public Property XPCurve As EconomyCurve Implements iHeroUnit.XPCurve
    Get
      Return mXPCurve
    End Get
    Set(value As EconomyCurve)

    End Set
  End Property

  Public Property BaseMovementSpeed As Double Implements iPlayerUnit.BaseMovementSpeed
    Get
      Return Me.mHBuild.mHero.BaseMovementSpeed
    End Get
    Set(value As Double)

    End Set
  End Property

  Public Property ItemInventory As Hero_Item_Inventory Implements iHeroUnit.ItemInventory
    Get
      Return mItemInv
    End Get
    Set(value As Hero_Item_Inventory)

    End Set
  End Property

  Public Property Mana As Stat Implements iPlayerUnit.Mana
    Get
      Return mGame.dbModifiers.GetStatByParentandType(Me, eStattype.Mana)
    End Get
    Set(value As Stat)

    End Set
  End Property

  Public Property TeamPosition As Integer Implements iPlayerUnit.TeamPosition
    Get
      Return mTeamPosition
    End Get
    Set(value As Integer)

    End Set
  End Property

  Public Property AbilityInventory As Hero_Ability_Inventory Implements iHeroUnit.AbilityInventory
    Get
      Return mAbilityInventory
    End Get
    Set(value As Hero_Ability_Inventory)

    End Set
  End Property
#End Region

#Region "Aghs"
  Public Property HasAghs As Boolean Implements iPlayerUnit.HasAghs
    Get
      Return mItemInv.HasAghs
    End Get
    Set(value As Boolean)

    End Set
  End Property

  Public Property AghsLifetime As Lifetime Implements iPlayerUnit.AghsLifetime
    Get
      Return mItemInv.GetAghsLifetime
    End Get
    Set(value As Lifetime)

    End Set
  End Property


  Function HasAghsAtTime(time As ddFrame) As Boolean Implements iPlayerUnit.HasAghsAtTime
    Return mItemInv.HasAghsAtTime(time)
  End Function
#End Region

#Region "Economy"
  Private Function GetKillsForGold(thetime As ddFrame, thegoldincrememnt As Integer) As Integer
    Dim curgold = mGoldCurve.GetValueForTime(thetime)
    Return curgold / thegoldincrememnt
  End Function

  'Public Property Goldcurve As EconomyCurve Implements iPlayerUnit.Goldcurve
  '  Get
  '    Return mGoldCurve
  '  End Get
  '  Set(value As EconomyCurve)
  '    mGoldCurve = value
  '    If Not mXPCurve Is Nothing Then
  '      Load(mXPCurve, mGoldCurve, mGame)
  '    End If
  '  End Set
  'End Property

  'Public Property XPCurve As EconomyCurve Implements iPlayerUnit.XPCurve
  '  Get
  '    Return mXPCurve
  '  End Get
  '  Set(value As EconomyCurve)
  '    mXPCurve = value
  '    If Not mGoldCurve Is Nothing Then
  '      Load(mXPCurve, mGoldCurve, mGame)
  '    End If
  '  End Set
  'End Property

  Public Function GetCurrentGold(time As ddFrame) As Integer Implements iHeroUnit.GetCurrentGold

    Return mGoldCurve.GetValueForTime(time)
  End Function
#End Region

#Region "Items"
  'Public Property ItemBuildAndAutoGeneratedItems As Item_List Implements iHeroUnit.ItemBuildAndAutoGeneratedItems
  '  Get
  '    Return mItemInv.mItemBuildAndAutoGeneratedItems
  '  End Get
  '  Set(value As Item_List)

  '  End Set
  'End Property

  'Public Property ItemBuildSequence As Item_List Implements iHeroUnit.ItemBuildSequence
  '  Get
  '    Return mItemInv.mItemBuildSequence
  '  End Get
  '  Set(value As Item_List)

  '  End Set
  'End Property

  'Public Function GetItemByID(id As dvID) As Item_Info Implements iDisplayUnit.GetItemByID
  '  If ItemBuildAndAutoGeneratedItems.ContainsIDItem(id) Then
  '    Return ItemBuildAndAutoGeneratedItems.GetItemByIdItem(id)
  '  Else
  '    Return Nothing
  '  End If
  'End Function

  'Public Function GetItemsAtTime(time As ddFrame) As Item_List Implements iDisplayUnit.GetItemsAtTime
  '  Return mItemInv.GetItemsAtTime(time)
  'End Function

  'Public Sub DeleteItemAtIndex(theindex As Integer) Implements iPlayerUnit.DeleteItemAtIndex
  '  mItemInv.DeleteItemAtIndex(theindex)
  'End Sub



  'Public Sub InsertItemAtIndex(theindex As Integer, theitem As Item_Info) Implements iDisplayUnit.InsertItemAtIndex
  '  mItemInv.InsertItemAtIndex(theindex, theitem)
  'End Sub

  'Public Sub ReplaceItemAtIndex(item As Item_Info, index As Integer) Implements iDisplayUnit.ReplaceItemAtIndex
  '  mItemInv.ReplaceItemAtIndex(item, index)

  '  If Not item.ItemName = eItemname.None Then

  '    dbMods.ReplaceModifiers(CalcItemMods(item), Nothing)
  '  End If
  'End Sub

  'Public Function GetItemLifetime(item As Item_Info) As Lifetime Implements iDisplayUnit.GetItemLifetime
  '  If Not ItemBuildSequence.ContainsIDItem(item.Id) Then Return Nothing

  '  Return ItemBuildSequence.GetItemByIdItem(item.Id).Lifetime
  'End Function
#End Region

#Region "Abilities"
  'Public Function GetAbilityNames() As List(Of eAbilityName) Implements iDisplayUnit.GetAbilityNames
  '  Return mHBuild.mBuild.AbilityNames
  'End Function


  'Public Property AbilityInfos As List(Of Ability_Info) Implements iDisplayUnit.AbilitiesListedByUIPosition
  '  Get
  '    Return mAbilityInventory.AbilitiesListedByUIPosition
  '  End Get
  '  Set(value As List(Of Ability_Info))
  '    Throw New NotImplementedException
  '  End Set
  'End Property

  'Public Function GetActiveAbilitiesByLevel(herolevel As Integer) As List(Of Integer) Implements iDisplayUnit.GetActiveAbilitiesByLevel

  '  Return mAbilityInventory.GetActiveAbilitiesByLevel(herolevel)
  'End Function

  'Public Function GetAbilityInfos(game As dGame) As List(Of Ability_Info) Implements iDisplayUnit.GetAbilityInfos

  '  Return AbilityInventory.AbilitiesListedByUIPosition
  'End Function

  'Public Property AbilitiesBuildOrderByUIPosition As List(Of Integer) Implements iPlayerUnit.AbilitiesBuildOrderByUIPosition
  '  Get
  '    Return AbilityInventory.AbilitiesBuildOrderByUIPosition
  '  End Get
  '  Set(value As List(Of Integer))

  '  End Set
  'End Property

  'Public Function GetAbilityById(id As dvID) As Ability_Info Implements iDisplayUnit.GetAbilityById
  '  Return mAbilityInventory.GetAbilityById(id)
  'End Function

  'Public Function GetAbilityByPosition(position As Integer) As Ability_Info Implements iDisplayUnit.GetAbilityByPosition
  '  Return mAbilityInventory.AbilitiesListedByUIPosition.Item(position)
  'End Function

  Public Function GetTempAbilityLifetimes(ab As Ability_Info) As Lifetime Implements iPlayerUnit.GetTempAbilityLifetimes
    Select Case ab.AbilityName
      'Treant
      Case eAbilityName.abEyes_In_The_Forest
        If mItemInv.mItemBuildAndAutoGeneratedItems.ContainsName(eItemname.itmAGHANIMS_SCEPTER) Then
          Return mItemInv.mItemBuildAndAutoGeneratedItems.GetItemByName(eItemname.itmAGHANIMS_SCEPTER).Lifetime
        Else
          Return Nothing
        End If

        'invoker
      Case eAbilityName.abCold_Snap, eAbilityName.abGhost_Walk, eAbilityName.abTornado, eAbilityName.abEmp, _
        eAbilityName.abAlacrity, eAbilityName.abChaos_Meteor, eAbilityName.abSun_Strike, _
        eAbilityName.abForge_Spirit, eAbilityName.abIce_Wall, eAbilityName.abDeafening_Blast

        Dim wexabposition As Integer = mGame.dbAbilities.GetAbilityInfoNoParent(eAbilityName.abWex).AbilitysUIPosition
        Dim quasabposition As Integer = mGame.dbAbilities.GetAbilityInfoNoParent(eAbilityName.abQuas).AbilitysUIPosition
        Dim exortabposition As Integer = mGame.dbAbilities.GetAbilityInfoNoParent(eAbilityName.abExort).AbilitysUIPosition

        Dim wexstartlevel As Integer = -1
        Dim quasstartlevel As Integer = -1
        Dim exortlevel As Integer = -1

        Dim absequence = mHBuild.mBuild.mAbilityBuildOrderByUIPosition

        For i As Integer = 0 To absequence.Count - 1
          Dim curab As Integer = absequence.Item(i)
          If curab = wexabposition And wexstartlevel = -1 Then
            wexstartlevel = i + 1
          End If

          If curab = quasabposition And quasstartlevel = -1 Then
            quasstartlevel = i + 1
          End If

          If curab = exortabposition And exortlevel = -1 Then
            exortlevel = i + 1
          End If
        Next

        Dim wexstarttime = Me.GetTimeForLevel(wexstartlevel)
        Dim quasstarttime = Me.GetTimeForLevel(quasstartlevel)
        Dim exortstarttime = Me.GetTimeForLevel(exortlevel)

        Dim wexlife As New Lifetime(wexstarttime, mGame.TimeKeeper.GameEnd)
        Dim quaslife As New Lifetime(quasstarttime, mGame.TimeKeeper.GameEnd)
        Dim exortlife As New Lifetime(exortstarttime, mGame.TimeKeeper.GameEnd)
        Dim framerate = mGame.TimeKeeper.Framerate
        Select Case ab.AbilityName
          Case eAbilityName.abCold_Snap
            Return quaslife


          Case eAbilityName.abGhost_Walk
            Return Helpers.GetCommonLifetimeFromLifetimes(quaslife, wexlife, framerate)

          Case eAbilityName.abTornado
            Return Helpers.GetCommonLifetimeFromLifetimes(wexlife, quaslife, framerate)

          Case eAbilityName.abEmp
            Return wexlife

          Case eAbilityName.abAlacrity
            Return Helpers.GetCommonLifetimeFromLifetimes(wexlife, exortlife, framerate)

          Case eAbilityName.abChaos_Meteor
            Return Helpers.GetCommonLifetimeFromLifetimes(exortlife, wexlife, framerate)

          Case eAbilityName.abSun_Strike
            Return exortlife

          Case eAbilityName.abForge_Spirit
            Return Helpers.GetCommonLifetimeFromLifetimes(exortlife, quaslife, framerate)

          Case eAbilityName.abIce_Wall
            Return Helpers.GetCommonLifetimeFromLifetimes(quaslife, exortlife, framerate)

          Case eAbilityName.abDeafening_Blast
            Dim templife = Helpers.GetCommonLifetimeFromLifetimes(quaslife, wexlife, framerate)

            Return Helpers.GetCommonLifetimeFromLifetimes(templife, exortlife, framerate)

          Case Else
            Throw New NotImplementedException
        End Select

    End Select


    'If Not Me.AbilityInfos.Contains(ab) Then Return Nothing
    'Return mAbilitiesLifetimes.Item(ab.AbilitysUIPosition)
  End Function

  'Public Function GetAbilityLevelAtHeroLevel(theab As Ability_Info, herolevel As Integer) As Integer Implements iDisplayUnit.GetAbilityLevel
  '  Return mAbilityInventory.GetAbilityLevelAtHeroLevel(theab, herolevel)
  'End Function
#End Region

#Region "Pets"
  Private Sub CalcPetTimings()

    'need to add for hero illusions (naga, meepo, etc)

    If mAbilityInventory.AbilitiesListedByUIPosition.Count < 1 Then Exit Sub

    Dim aghstime = AghsLifetime

    'potential ability pets
    mPetsOwned = New List(Of PetStack)


    For i As Integer = 0 To mAbilityInventory.AbilitiesListedByUIPosition.Count - 1

      Dim curability = mAbilityInventory.AbilitiesListedByUIPosition.Item(i)
      Dim infos = dbcreepsandpets.GetPetInfosForUnitUpgrade(curability, mGame)

      If infos IsNot Nothing Then
        Dim curstack As New PetStack(infos, Me, curability, aghstime, _
                                       mTeamPosition, mTeam, mGame, mLog)

        mPetsOwned.Add(curstack)
      End If

    Next


    For i As Integer = 0 To mItemInv.mItemBuildAndAutoGeneratedItems.Count - 1
      Dim curitem = mItemInv.mItemBuildAndAutoGeneratedItems.Item(i)
      Dim infos = dbcreepsandpets.GetPetInfosForUnitUpgrade(curitem, mGame)
      If infos IsNot Nothing Then
        Dim curstack As New PetStack(infos, Me, curitem, aghstime, _
                                       mTeamPosition, mTeam, mGame, mLog)

        If Not curstack Is Nothing Then
          mPetsOwned.Add(curstack)
        End If
      End If
    Next


  End Sub

  Public Property PetsOwned As List(Of PetStack) Implements iHeroUnit.PetsOwned
    Get
      If mPetsOwned Is Nothing Then
        CalcPetTimings()
      End If
      Return mPetsOwned
    End Get
    Set(value As List(Of PetStack))

    End Set
  End Property


#End Region








End Class
