Public Class ModFilters


  Public Shared Sub RemoveByParentID( parentid As dvID,  themods As ModifierList)

    For i As Integer = themods.Count - 1 To 0
      If themods.Item(i).Parent.Id.GuidID = parentid.GuidID Then themods.Remove(themods.Item(i))
    Next

  End Sub

  Public Shared Sub RemoveBySourceID(sourceid As dvID, themods As ModifierList)
    For i As Integer = themods.Count - 1 To 0
      If themods.Item(i).ModGenerator.Id.GuidID = sourceid.GuidID Then themods.Remove(themods.Item(i))
    Next


  End Sub

  Public Shared Sub RemoveBySourceType(sourcetype As eUnittype, themods As ModifierList)
    For i As Integer = themods.Count - 1 To 0
      If themods.Item(i).TheModInfo.ModGenerator.MyType = sourcetype Then themods.Remove(themods.Item(i))
    Next


  End Sub

  Public Shared Sub RemoveByParentGameEntityType(parentgameentiytype As eUnittype, themods As ModifierList)

    For i As Integer = themods.Count - 1 To 0
      If themods.Item(i).TheModInfo.Parent.MyType = parentgameentiytype Then themods.Remove(themods.Item(i))
    Next
  End Sub

  Public Shared Function GetByParentID(parentid As dvID, themods As ModifierList) As ModifierList
    Dim outlist As New ModifierList

    For i As Integer = themods.Count - 1 To 0
      If themods.Item(i).TheModInfo.Parent.Id.GuidID = parentid.GuidID Then outlist.Add(themods.Item(i))
    Next
    Return outlist
  End Function

  Public Shared Function GetBySourceID(sourceid As dvID, themods As ModifierList) As ModifierList
    Dim outlist As New ModifierList

    For i As Integer = themods.Count - 1 To 0
      If themods.Item(i).TheModInfo.ModGenerator.Id.GuidID = sourceid.GuidID Then outlist.Add(themods.Item(i))
    Next
    Return outlist

  End Function

  Public Shared Function GetByParentGameEntityType(parentgameentitytype As eUnittype, themods As ModifierList) As ModifierList
    Dim outlist As New ModifierList

    For i As Integer = themods.Count - 1 To 0
      If themods.Item(i).TheModInfo.Parent.MyType = parentgameentitytype Then outlist.Add(themods.Item(i))
    Next
    Return outlist

  End Function

  Public Shared Function GetBySourceType(sourcetype As eUnittype, themods As ModifierList) As ModifierList

    Dim outlist As New ModifierList

    For i As Integer = themods.Count - 1 To 0
      If themods.Item(i).TheModInfo.ModGenerator.MyType = sourcetype Then outlist.Add(themods.Item(i))
    Next
    Return outlist
  End Function

  'Public Shared Function GetByModifierGroup( thegroup As eModifierGroup,  themods As ModifierList) As ModifierList


  'End Function

  Public Shared Function GetSumOfModsForTime(themods As ModifierList, thetime As ddFrame) As Double?
    Dim outval As New Double?
    For i As Integer = 0 To themods.Count - 1
      Dim theval = themods.Item(i).Value(thetime)
      If theval.HasValue Then
        If outval.HasValue Then
          outval += theval
        Else
          outval = theval
        End If

      End If
    Next
    Return outval
  End Function
  Public Sub ArrangeByParentID(themods As ModifierList)
    themods.SortListByParentID()
  End Sub

  Public Shared Sub ArrangeBySourceID(themods As ModifierList)
    themods.SortListBySourceID()
  End Sub


  Public Shared Function GetArrangedByTeamof1stTargetId(themods As ModifierList, thegame As dGame) As List(Of ModifierList)
    Dim outrad As New ModifierList
    Dim outdire As New ModifierList
    Dim curtime = thegame.TimeKeeper.CurrentTime
    For i As Integer = 0 To themods.Count - 1
      Dim curmod = themods.Item(i)
      Dim targs = Helpers.GetAffectedUnitsForMod(curmod, thegame) ', curmod.GetLevelAtTime(curtime), thegame, curtime)

      If targs.Count > 0 Then
        Select Case thegame.GetTeamFromGameEntity(targs.Item(0)).TeamName
          Case eTeamName.Radiant
            outrad.Add(curmod)
          Case eTeamName.Dire
            outdire.Add(curmod)
          Case Else
            PageHandler.theLog.WriteLog("ModFilters.GetArrangedByTeamof1stTargetID Target.TeamName: " & thegame.GetTeamFromGameEntity(targs.Item(0)).TeamName.ToString)
            Dim x = 2
        End Select
      End If
    Next

    Dim outlist As New List(Of ModifierList)
    outlist.Add(outrad)
    outlist.Add(outdire)

    Return outlist
  End Function
  Public Shared Function GetModsGroupedByTargetIDs(themods As ModifierList, thegame As dGame) As List(Of ModifierList)
    'quicksort uniqueidstring for each target so they all occur in same order


    ModFilters.SortmodifierListByTargetIds(themods, thegame)

    Dim outmodlists As New List(Of ModifierList)
    Dim curtargstring As String = ""
    Dim curlist As New ModifierList
    'make a key out of this value and use move mods out of list into dictionary(of targetkey, modifierlist)
    For i As Integer = 0 To themods.Count - 1
      Dim curmod = themods.Item(i)

      Dim curlvl As Integer
      If curmod.TheModInfo.ModGenerator.MyType = eSourceType.Ability_Info Then
        Dim theowner = curmod.Parent
        curlvl = Helpers.GetLevelForAbility(curmod.ModGenerator.Id, theowner.Id, thegame)
      Else
        curlvl = 1
      End If

      Dim curtargs = Helpers.GetInGameTargetsStringForMod(themods.Item(i), thegame)
      If Not curtargs = "" Then
        If curtargs = curtargstring Then
          curlist.Add(themods.Item(i))
        Else
          curtargstring = curtargs
          curlist = New ModifierList()
          curlist.Add(themods.Item(i))
          outmodlists.Add(curlist)
        End If
      End If

    Next
    Return outmodlists
  End Function

  Public Shared Function GetModsGroupedBySourceID(themods As ModifierList) As List(Of ModifierList)
    themods.SortListBySourceID()

    Dim outmodlists As New List(Of ModifierList)
    Dim cursourceguid As Guid = Guid.Empty
    Dim curlist As New ModifierList
    'make a key out of this value and use move mods out of list into dictionary(of targetkey, modifierlist)
    For i As Integer = 0 To themods.Count - 1
      Dim SourceguID = themods.Item(i).TheModInfo.ModGenerator.Id.GuidID


      If SourceguID = cursourceguid Then
        curlist.Add(themods.Item(i))
      Else
        cursourceguid = SourceguID
        curlist = New ModifierList()
        curlist.Add(themods.Item(i))
        outmodlists.Add(curlist)
      End If


    Next
    Return outmodlists
  End Function
  Public Shared Function GetModsGroupedBySourceIDAndTargetID(themods As ModifierList, thegame As dGame) As List(Of ModifierList)
    Dim targetgroups As List(Of ModifierList) = GetModsGroupedByTargetIDs(themods, thegame)

    Dim outlist As New List(Of ModifierList)
    For i As Integer = 0 To targetgroups.Count - 1
      Dim outgroups = GetModsGroupedBySourceID(targetgroups.Item(i))
      For x As Integer = 0 To outgroups.Count - 1
        outlist.Add(outgroups.Item(x))
      Next
    Next
    Return outlist

  End Function
  Public Shared Sub RemoveParentIDsNotInGame(themods As List(Of Modifier), thegame As dGame)

    For i As Integer = themods.Count - 1 To 0 Step -1
      Dim curmod = themods.Item(i)
      If Not thegame.GameContainsUnit(curmod.Parent) Then
        themods.Remove(curmod)
      End If
    Next


  End Sub

  Public Shared Sub ArrangeByModTypes( themods As ModifierList)
    themods.SortlistByModType()
  End Sub

  ' ''' <summary>
  ' ''' returns all possible pets for the modifier.... not pets at specific time
  ' ''' </summary>
  ' ''' <param name="themod"></param>
  ' ''' <param name="theparent"></param>
  ' ''' <param name="thegame"></param>
  ' ''' <returns></returns>
  ' ''' <remarks></remarks>
  'Public Function GetPetsForModifier( themod As Modifier, _
  '                                    theparent As DDObject,  thegame As dGame) As CreepStack
  '  Dim etarget As dvID
  '  Dim ftarget As dvID
  '  Dim fbias As Boolean
  '  Dim parentid As dvID
  '  Select Case theparent.type
  '    Case eEntity.Hero_Instance
  '      Dim hparent As HeroInstance = theparent.obj
  '      etarget = hparent.EnemyTarget
  '      ftarget = hparent.FriendTarget
  '      fbias = hparent.TargetFriendBias
  '      parentid = hparent.ID
  '    Case eEntity.Team
  '      Dim tparent As dTeam = theparent.obj
  '      etarget = tparent.EnemyTargetID
  '      ftarget = tparent.FriendlyTargetID
  '      fbias = tparent.TargetFriendlyBias
  '      parentid = tparent.ID
  '    Case Else
  '      Dim x = 2
  '      PageHandler.theLog.writelog("Modfilters.GetPetsforModifier unhandled case: " & theparent.type.ToString)
  '  End Select
  '  If Not themod.ToString.StartsWith("pet") Then Return Nothing

  '  Dim creepname As eCreepName

  '  Dim outpets As New List(Of Creep_Info)
  '  Select Case themod.ModifierType


  '    Case eModifierType.petHawk
  '      creepname = eCreepName.untHawk

  '    Case eModifierType.petBoar
  '      creepname = eCreepName.untBoar


  '    Case eModifierType.petLycan_Wolf
  '      creepname = eCreepName.untLycan_Wolf

  '    Case eModifierType.petUndying_Zombie
  '      creepname = eCreepName.untUndying_Zombie

  '    Case eModifierType.petSpiderling
  '      creepname = eCreepName.untSpiderling

  '    Case eModifierType.petSpiderite
  '      creepname = eCreepName.untSpiderite

  '    Case eModifierType.petTreant
  '      creepname = eCreepName.untTreant

  '    Case eModifierType.petEidolon
  '      creepname = eCreepName.untEidolon

  '    Case eModifierType.petForged_Spirit
  '      creepname = eCreepName.untForged_Spirit

  '    Case eModifierType.petSkeleton_Warrior
  '      creepname = eCreepName.untSkeleton_Warrior

  '    Case eModifierType.petNecro_Warrior
  '      creepname = eCreepName.untNecro_Warrior

  '    Case eModifierType.petNecro_Archer
  '      creepname = eCreepName.untNecro_Archer

  '    Case eModifierType.petEarth_Brewmaster
  '      creepname = eCreepName.untEarth_Brewmaster

  '    Case eModifierType.petStorm_Brewmaster
  '      creepname = eCreepName.untStorm_Brewmaster

  '    Case eModifierType.petFire_Brewmaster
  '      creepname = eCreepName.untFire_Brewmaster

  '    Case eModifierType.petGolem_Warlock
  '      creepname = eCreepName.untGolem_Warlock

  '    Case eModifierType.petSpirit_Bear
  '      creepname = eCreepName.untSpirit_Bear

  '    Case eModifierType.petFamiliar
  '      creepname = eCreepName.untFamiliar

  '    Case eModifierType.petPlague_Ward
  '      creepname = eCreepName.untPlague_Ward

  '    Case eModifierType.petSerpent_Ward
  '      creepname = eCreepName.untSerpent_Ward

  '    Case eModifierType.petDeath_Ward
  '      creepname = eCreepName.untDeath_Ward

  '    Case eModifierType.petHealing_Ward
  '      creepname = eCreepName.untHealing_Ward

  '    Case eModifierType.petFrozen_Sigil
  '      creepname = eCreepName.untFrozen_Sigil

  '    Case eModifierType.petTornado
  '      creepname = eCreepName.untTornado

  '    Case eModifierType.petPsionic_Trap
  '      creepname = eCreepName.untPsionic_Trap

  '    Case eModifierType.petLand_Mine
  '      creepname = eCreepName.untLand_Mine

  '    Case eModifierType.petStasis_Trap
  '      creepname = eCreepName.untStasis_Trap

  '    Case eModifierType.petRemote_Mine
  '      creepname = eCreepName.untRemote_Mine

  '    Case eModifierType.petNether_Ward
  '      creepname = eCreepName.untNether_Ward

  '    Case eModifierType.petPower_Cog
  '      creepname = eCreepName.untPower_Cog

  '    Case eModifierType.petTombstone
  '      creepname = eCreepName.untTombstone

  '    Case eModifierType.petPhoenix_Sun
  '      creepname = eCreepName.untPhoenix_Sun

  '    Case eModifierType.petObserver_Ward
  '      creepname = eCreepName.untObserver_Ward

  '    Case eModifierType.petSentry_Ward
  '      creepname = eCreepName.untSentry_Ward

  '    Case eModifierType.petMelee_Creep
  '      creepname = eCreepName.untMelee_Creep

  '    Case eModifierType.petSuper_Melee_Creep
  '      creepname = eCreepName.untSuper_Melee_Creep

  '    Case eModifierType.petMega_Melee_Creep
  '      creepname = eCreepName.untMega_Melee_Creep

  '    Case eModifierType.petRanged_Creep
  '      creepname = eCreepName.untRanged_Creep

  '    Case eModifierType.petSuper_Ranged_Creep
  '      creepname = eCreepName.untSuper_Ranged_Creep

  '    Case eModifierType.petMega_Ranged_Creep
  '      creepname = eCreepName.untMega_Ranged_Creep

  '    Case eModifierType.petSiege_Creep
  '      creepname = eCreepName.untSiege_Creep

  '    Case eModifierType.petSiege_Creep_Bonus
  '      creepname = eCreepName.untSiege_Creep_Bonus

  '    Case eModifierType.petSpirit
  '      creepname = eCreepName.untAstral_Spirit

  '    Case eModifierType.petKobold
  '      creepname = eCreepName.untKobold

  '    Case eModifierType.petKobold_Soldier
  '      creepname = eCreepName.untKobold_Soldier

  '    Case eModifierType.petKobold_Foreman
  '      creepname = eCreepName.untKobold_Foreman

  '    Case eModifierType.petHill_Troll_Berserker
  '      creepname = eCreepName.untHill_Troll_Berserker

  '    Case eModifierType.petHill_Troll_Priest
  '      creepname = eCreepName.untHill_Troll_Priest

  '    Case eModifierType.petVhoul_Assassin
  '      creepname = eCreepName.untVhoul_Assassin

  '    Case eModifierType.petFell_Spirit
  '      creepname = eCreepName.untFell_Spirit

  '    Case eModifierType.petGhost
  '      creepname = eCreepName.untGhost

  '    Case eModifierType.petHarpy_Scout
  '      creepname = eCreepName.untHarpy_Scout

  '    Case eModifierType.petHarpy_Stormcrafter
  '      creepname = eCreepName.untHarpy_Stormcrafter

  '    Case eModifierType.petCentaur_Conqueror
  '      creepname = eCreepName.untCentaur_Conqueror

  '    Case eModifierType.petCentaur_Courser
  '      creepname = eCreepName.untCentaur_Courser

  '    Case eModifierType.petGiant_Wolf
  '      creepname = eCreepName.untGiant_Wolf

  '    Case eModifierType.petAlpha_Wolf
  '      creepname = eCreepName.untAlpha_Wolf

  '    Case eModifierType.petSatyr_Banisher
  '      creepname = eCreepName.untSatyr_Banisher

  '    Case eModifierType.petSatyr_Mindstealer
  '      creepname = eCreepName.untSatyr_Mindstealer

  '    Case eModifierType.petOgre_Bruiser
  '      creepname = eCreepName.untOgre_Bruiser

  '    Case eModifierType.petOgre_Frostmage
  '      creepname = eCreepName.untOgre_Frostmage

  '    Case eModifierType.petMud_Golem
  '      creepname = eCreepName.untMud_Golem

  '    Case eModifierType.petSatyr_Tormentor
  '      creepname = eCreepName.untSatyr_Tormentor

  '    Case eModifierType.petHellbear
  '      creepname = eCreepName.untHellbear

  '    Case eModifierType.petHellbear_Smasher
  '      creepname = eCreepName.untHellbear_Smasher

  '    Case eModifierType.petWildwing
  '      creepname = eCreepName.untWildwing

  '    Case eModifierType.petWildwing_Ripper
  '      creepname = eCreepName.untWildwing_Ripper

  '    Case eModifierType.petDark_Troll_Summoner
  '      creepname = eCreepName.untDark_Troll_Summoner

  '    Case eModifierType.petHill_Trll
  '      creepname = eCreepName.untHill_Trll

  '    Case eModifierType.petAncient_Black_Dragon
  '      creepname = eCreepName.untAncient_Black_Dragon

  '    Case eModifierType.petAncient_Black_Drake
  '      creepname = eCreepName.untAncient_Black_Drake

  '    Case eModifierType.petAncient_Granite_Golem
  '      creepname = eCreepName.untAncient_Granite_Golem

  '    Case eModifierType.petAncient_Rock_Golem
  '      creepname = eCreepName.untAncient_Rock_Golem

  '    Case eModifierType.petAncient_Thunderhide
  '      creepname = eCreepName.untAncient_Thunderhide

  '    Case eModifierType.petAncient_Rumblehide
  '      creepname = eCreepName.untAncient_Rumblehide

  '    Case eModifierType.petHoming_Missile
  '      creepname = eCreepName.untHoming_Missile

  '    Case eModifierType.petPhantomLancer
  '      creepname = eCreepName.untPet_Phantom_Lancer

  '  End Select

  '  For i As Integer = 0 To themod.TheModValue.Value(thegame.mTimeKeeper.GameEnd)
  '    Dim sp = thegame.dbCreeps.GetNewCreepInfo(creepname, 0, parentid, themod.Lifetime, Nothing, Nothing, _
  '                                               etarget, ftarget, fbias, thegame)
  '    outpets.Add(sp)
  '  Next


  'End Function


  Public Function GetCreepStackForAbility(theability As Ability_Info) As CreepStack
    Throw New NotImplementedException

    Select Case theability.AbilityName
      Case eAbilityName.abCall_Of_The_Wild

      Case eAbilityName.abSummon_Wolves

      Case eAbilityName.abTombstone

      Case eAbilityName.abSpawn_Spiderlings

      Case eAbilityName.abSpiderling_Spawn_Spiderite

      Case eAbilityName.abNatures_Call

      Case eAbilityName.abDemonic_Conversion

      Case eAbilityName.abForge_Spirit

      Case eAbilityName.abDark_Troll_Summoner_Raise_Dead

      Case eAbilityName.abPrimal_Split

      Case eAbilityName.abChaotic_Offering

      Case eAbilityName.abSummon_Spirit_Bear

      Case eAbilityName.abSummon_Familiars

      Case eAbilityName.abPlague_Ward

      Case eAbilityName.abMass_Serpent_Ward

      Case eAbilityName.abDeath_Ward

      Case eAbilityName.abHealing_Ward

      Case eAbilityName.abFrozen_Sigil

      Case eAbilityName.abTornado

      Case eAbilityName.abPsionic_Trap

      Case eAbilityName.abLand_Mines

      Case eAbilityName.abStasis_Trap

      Case eAbilityName.abRemote_Mines

      Case eAbilityName.abNether_Ward

      Case eAbilityName.abPower_Cogs

      Case eAbilityName.abTombstone

      Case eAbilityName.abSupernova

      Case eAbilityName.abCrypt_Swarm

      Case eAbilityName.abHoming_Missile

      Case eAbilityName.abAstral_Spirit

      Case eAbilityName.abSpin_Web

      Case Else
        Return Nothing

    End Select

  End Function

  Public Function GetCreepStackForItem(theitem As Item_Info) As CreepStack
    Throw New NotImplementedException
    Select Case theitem.ItemName
      Case eItemname.itmNECRONOMICON_1

      Case eItemname.itmNECRONOMICON_2

      Case eItemname.itmNECRONOMICON_3

      Case eItemname.itmOBSERVER_WARD

      Case eItemname.itmSENTRY_WARD

      Case Else
        Return Nothing


    End Select

  End Function
  Public Function IsPetModifier( themodtype As eModifierType) As Boolean

    If themodtype.ToString.StartsWith("pet") Then Return True
    Return False

  End Function

  ''' <summary>
  ''' takes care of special case mods that need info at runtime to determine their value
  ''' </summary>
  ''' <param name="themod"></param>
  ''' <param name="thetime"></param>
  ''' <param name="theownerid"></param>
  ''' <param name="thegame"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function GetModifierValueAtTime( themod As Modifier,  thetime As ddFrame,  theownerid As dvID,  thegame As dGame)
    Select Case themod.ModifierType
      Case eModifierType.AbilityEffectiveHp '= 87 
        Return themod.Value(thetime)

      Case eModifierType.AbilitySteal 'Doom Devour 


      Case eModifierType.AdaptiveStrikeDamageMagicalInflicted 'Morphling Adaptive Strike. Used Agility to calc damage inflicted 
        Return themod.Value(thetime)

      Case eModifierType.AdaptiveStrikeStun 'Morphling Adaptive Strike. Calculated using current strength and agility 
        Return themod.Value(thetime)

      Case eModifierType.AgiAdded '= 15 
        Return themod.Value(thetime)

      Case eModifierType.AgioT '= 17 
        Return themod.Value(thetime)

      Case eModifierType.AgiPercent '= 16 
        Return themod.Value(thetime)

      Case eModifierType.AgiSubtracted ' Slark Essence Shift 
        Return themod.Value(thetime)

      Case eModifierType.ArcaneOrb '= 50 'OD 'http://dota2.gamepedia.com/Unique_Attack_Modifier
        Return themod.Value(thetime)

      Case eModifierType.ArmorAdded
        Return themod.Value(thetime)

      Case eModifierType.ArmorAddedPerSec '= 9 
        Return themod.Value(thetime)

      Case eModifierType.ArmoroT '= 11 
        Return themod.Value(thetime)

      Case eModifierType.ArmorPercentage '= 10 
        Return themod.Value(thetime)

      Case eModifierType.ArmorStackSubtracted 'Bristlebakc Nasal Goo 
        Return themod.Value(thetime)

      Case eModifierType.ArmorSubtracted
        Return themod.Value(thetime)

      Case eModifierType.ArmorSubtractedoT 'Forged Spirit Melting Strike 
        Return themod.Value(thetime)

      Case eModifierType.AstralSpiritDamageMagicalAdded 'Elder Titan, will have to determine how many units were hit for this to be accurate 
        Return themod.Value(thetime)

      Case eModifierType.AstralSpiritMoveSpeedPercentAdded 'Elder Titan, have to determine how many creeps hit 
        Return themod.Value(thetime)

      Case eModifierType.AstrlImpIntStolen 'OD Astral Imprisonment. Only steals int if target is enemy hero 
        Return themod.Value(thetime)

      Case eModifierType.AttackSpeedAdded '= 25 
        Return themod.Value(thetime)

      Case eModifierType.AttackSpeedAddedPerHeroPerMissHP 'Bloodseeker Thirst 
        Return themod.Value(thetime)

      Case eModifierType.AttackSpeedAddedtoXAttacks 'Ursa Overpower. Attack speed only added to a certain number of rightclick attacks 
        Return themod.Value(thetime)

      Case eModifierType.AttackSpeedMaxed 'Windranger Focus Fire 
        Return themod.Value(thetime)

      Case eModifierType.AttackSpeedoT '= 27 
        Return themod.Value(thetime)

      Case eModifierType.AttackSpeedPercentAdded '= 26 
        Return themod.Value(thetime)

      Case eModifierType.AttackSpeedPercentofTargetAdded 'Visage Grave Chill 
        Return themod.Value(thetime)

      Case eModifierType.AttackSpeedPercentSubtracted 'Medusa Stone Gaze 
        Return themod.Value(thetime)

      Case eModifierType.AttackSpeedStackAdded 'Lina Fiery Soul 
        Return themod.Value(thetime)

      Case eModifierType.AttackspeedSubtracted 'AA Chilling Touch 
        Return themod.Value(thetime)

      Case eModifierType.BackstabRightclickDamageAddedAsPercofAgi 'Riki Backstab. only occurs when attacking from rear 
        Return themod.Value(thetime)

      Case eModifierType.BallLightDamMagicalInflicted 'Storm Spirit Ball Lightning 
        Return themod.Value(thetime)

      Case eModifierType.BallLightPushForward 'SS Ball Lightning charge 
        Return themod.Value(thetime)

      Case eModifierType.Barrier 'earthsaker wall, tusk iceshards... 
        Return themod.Value(thetime)


      Case eModifierType.BaseAgi '= 89 
        Return themod.Value(thetime)

      Case eModifierType.BaseandBonusDamageReduction 'Windranger Focus Fire 
        Return themod.Value(thetime)

      Case eModifierType.BaseArmorPercentSubtracted 'Elder Titan Natural Order 
        Return themod.Value(thetime)

      Case eModifierType.BaseAttackTime '= 24 
        Return themod.Value(thetime)
      Case eModifierType.BaseAttackTimeChangedTo ' Alchemist Chemical Rage 
        Return themod.Value(thetime)

        'Case eModifierType.BaseEffectiveHP '= 1 
        '  Return themod.Value(thetime)

        'Case eModifierType.BaseHP '= 0 
        '  Return themod.Value(thetime)

      Case eModifierType.BaseInt '= 90 
        Return themod.Value(thetime)

      Case eModifierType.BaseMagicResistance '= 29 
        Return themod.Value(thetime)

      Case eModifierType.BaseMagicResistancePercentSubtracted 'Elder Titan Natural Order 
        Return themod.Value(thetime)

      Case eModifierType.BaseMana '= 5 
        Return themod.Value(thetime)

      Case eModifierType.BaseStr '= 88 
        Return themod.Value(thetime)

      Case eModifierType.Bash '= 35 'http://dota2.gamepedia.com/Bash 
        Return themod.Value(thetime)

      Case eModifierType.BearBonusDamage 'Lone Druid Synergy 
        Return themod.Value(thetime)

      Case eModifierType.BearMoveSpeedAdded 'Lone Druid Synergy 
        Return themod.Value(thetime)

      Case eModifierType.BerserkersBonusAttackSpeed 'Huskar Berserker's Blood. Oy 
        Return themod.Value(thetime)

      Case eModifierType.BerserkersBonusMagicResistance 'Huskar Berserker's Blood 
        Return themod.Value(thetime)

      Case eModifierType.BlindChance '= 57 'http://dota2.gamepedia.com/Blind 
        Return themod.Value(thetime)

      Case eModifierType.BlindDuration '= 58 
        Return themod.Value(thetime)

      Case eModifierType.BonusDamage
        Return themod.Value(thetime)

      Case eModifierType.BonusDamageoT
        Return themod.Value(thetime)

      Case eModifierType.BonusDamagePercent 'Lycan Feral Impulse 
        Return themod.Value(thetime)

      Case eModifierType.BonusGold
        Return themod.Value(thetime)

      Case eModifierType.BountyGold
        Return themod.Value(thetime)

      Case eModifierType.BuildingAttackSpeedPercentAdded 'Spirit Bear Demolish. If attacking a building then attspeed is applied 
        Return themod.Value(thetime)

      Case eModifierType.CausticFinale '= 45 'SandKing 'http://dota2.gamepedia.com/Unique_Attack_Modifier
        Return themod.Value(thetime)

      Case eModifierType.ChainLightning '= 54 'Maelstrom, Mjolnir 'http://dota2.gamepedia.com/Unique_Attack_Modifier
        Return themod.Value(thetime)

      Case eModifierType.ChenAncientCount 'count of potential ancients that can be holy pursuasioned 
        Return themod.Value(thetime)

      Case eModifierType.ChenCreepFullHeal 'Chen Hand of God 
        Return themod.Value(thetime)

      Case eModifierType.CleavePercentage '= 36 'http://dota2.gamepedia.com/Cleave , http://dota2.gamepedia.com/Mechanics#Cleave_Damage 
        Return themod.Value(thetime)

      Case eModifierType.ColdAttack '= 53 'Skadi 'http://dota2.gamepedia.com/Unique_Attack_Modifier
        Return themod.Value(thetime)

      Case eModifierType.ConjuredImage 'Terrorblade Conjure Image. Takes stats from TB's current stats 
        Return themod.Value(thetime)

      Case eModifierType.Consumption 'Doom Devour 
        Return themod.Value(thetime)

      Case eModifierType.ControlledCreepHealthBonus 'Chen Holy Pursuasion 
        Return themod.Value(thetime)

      Case eModifierType.Corruption '= 52 'Desolator 'http://dota2.gamepedia.com/Unique_Attack_Modifier
        Return themod.Value(thetime)

      Case eModifierType.CreepControlled 'Chen Holy Pursuasion 
        Return themod.Value(thetime)

      Case eModifierType.CripplingFearMissChance 'NightStalker. Values change if day or night 
        Return themod.Value(thetime)

      Case eModifierType.CritChance '= 37 'http://dota2.gamepedia.com/Critical_strike 
        Return themod.Value(thetime)

      Case eModifierType.CritDamage 'Jinada 
        Return themod.Value(thetime)

      Case eModifierType.CritMultiplier '= 38 
        Return themod.Value(thetime)

      Case eModifierType.Cyclone '= 59 'http://dota2.gamepedia.com/Cyclone 
        Return themod.Value(thetime)

      Case eModifierType.DamageAbsorbedForMana 'Medusa Mana Shield .absorbs damage in exchange for mana 
        Return themod.Value(thetime)

      Case eModifierType.DamageAllTypesIncomingIncreasesPercent 'Slardar Sprint 
        Return themod.Value(thetime)

      Case eModifierType.DamageAllTypesPercentAdded 'Clinkz DeathPact 
        Return themod.Value(thetime)

      Case eModifierType.DamageAllTypesStackAdded 'Bristleback Warpath adds damage to spells and abilitys of all damage types 
        Return themod.Value(thetime)

      Case eModifierType.DamageAmplification '= 31 'http://dota2.gamepedia.com/Damage_amplification 
        Return themod.Value(thetime)

      Case eModifierType.DamageBlock
        Return themod.Value(thetime)

      Case eModifierType.DamageBlockRemoved 'SS Hex 
        Return themod.Value(thetime)

      Case eModifierType.DamageBothBlockAdded
        Return themod.Value(thetime)

      Case eModifierType.DamageChainMagicalInflicted 'WitchDoctor Paralyzing cask 
        Return themod.Value(thetime)

      Case eModifierType.DamageChainPhysicalInflicted 'Mjolnir 
        Return themod.Value(thetime)

      Case eModifierType.DamageDelay 'Kunka Ghost Ship 
        Return themod.Value(thetime)

      Case eModifierType.DamageIncreasePercent 'Chen Penitence 
        Return themod.Value(thetime)

      Case eModifierType.DamageInstanceBlock 'treant Living Armor 
        Return themod.Value(thetime)

      Case eModifierType.DamageLost 'due to LC Duel, Razor static link 
        Return themod.Value(thetime)

      Case eModifierType.DamageMagicalAbsorbed 'Ember Spirit Flameguard 
        Return themod.Value(thetime)

      Case eModifierType.DamageMagicalAdded 'for passaive abilities 
        Return themod.Value(thetime)

      Case eModifierType.DamageMagicalAddedToPhysicalAttacks ' AA Chilling Touch 
        Return themod.Value(thetime)

      Case eModifierType.DamageMagicalBouncesInflicted 'Lich ulti 
        Return themod.Value(thetime)

      Case eModifierType.DamageMagicalChain 'Invoker Cold Snap 
        Return themod.Value(thetime)

      Case eModifierType.DamageMagicalEarthSplitterAdded 'Elder Titan. Based on unit being attacked's max HP 
        Return themod.Value(thetime)

      Case eModifierType.DamageMagicalImmunity 'OmniKnight Repel 
        Return themod.Value(thetime)

      Case eModifierType.DamageMagicalInflicted 'for active abilities 
        Return themod.Value(thetime)

      Case eModifierType.DamageMagicalInflictedOnSpellCast 'SS Overload 
        Return themod.Value(thetime)

      Case eModifierType.DamageMagicalInflictedPerAlly ' Tusk Snowball 
        Return themod.Value(thetime)

      Case eModifierType.DamageMagicalInflictedPerTarget 'SS Ether Shock, for abilities that hit x num of targets, each only once 
        Return themod.Value(thetime)

      Case eModifierType.DamageMagicalInflictedPerUnit 'Undying Soul Rip 
        Return themod.Value(thetime)

      Case eModifierType.DamageMagicalInflictedUntilSpellcast 'Silencer Curse of the Silent 
        Return themod.Value(thetime)

      Case eModifierType.DamageMagicalMinMaxInflicted 'value has a min and max value 
        Return themod.Value(thetime)

      Case eModifierType.DamageMagicaloTAsMultofStr 'Pudge Dismemeber 
        Return themod.Value(thetime)

      Case eModifierType.DamageMagicalOverTimeInflicted 'LeechSeed pulse 
        Return themod.Value(thetime)

      Case eModifierType.DamageMagicalPercent
        Return themod.Value(thetime)

      Case eModifierType.DamageMagicalPerCreep 'LC Overwhelming Odds 
        Return themod.Value(thetime)

      Case eModifierType.DamageMagicalPerHero 'LC Overwhelming Odds 
        Return themod.Value(thetime)

      Case eModifierType.DamageMagicalPerMissingHP 'Necro Reaper's Scythe 
        Return themod.Value(thetime)

      Case eModifierType.DamageMagicalPerMissingMana 'Anti Mage Mana Void 
        Return themod.Value(thetime)

      Case eModifierType.DamageMagicalPerSec ''axe battle hunger 
        Return themod.Value(thetime)

      Case eModifierType.DamageMagicalRandomInflicted 'uses maxval and minval in modvalue for range of random value 
        Return themod.Value(thetime)

      Case eModifierType.DamageMagicalTimesInt ' Skywrath Arcane Bolt 
        Return themod.Value(thetime)

      Case eModifierType.DamageMeleeAdded
        Return themod.Value(thetime)

      Case eModifierType.DamageMeleeBlockAdded '= 32 'http://dota2.gamepedia.com/Damage_Block 
        Return themod.Value(thetime)

      Case eModifierType.DamageMeleemultiplier
        Return themod.Value(thetime)

      Case eModifierType.DamageoTMagicalInflicted

        Return themod.Value(thetime)
      Case eModifierType.damagePerSecond 'Radiance burn 
        Return themod.Value(thetime)

      Case eModifierType.DamagePhysicalAdded 'passive abilites 
        Return themod.Value(thetime)

      Case eModifierType.DamagePhysicalBouncesInflicted 'Witch doc Death Ward 
        Return themod.Value(thetime)

      Case eModifierType.DamagePhysicalEarthSplitterAdded 'Elder Titan. Based on unit being attacked's max HP 
        Return themod.Value(thetime)

      Case eModifierType.DamagePhysicalImmunity 'OmniKnight Guardian Angel 
        Return themod.Value(thetime)

      Case eModifierType.DamagePhysicalIncomingIncreasedPercent 'Medusa Stone Gaze 
        Return themod.Value(thetime)

      Case eModifierType.DamagePhysicalInflicted 'active abilities 
        Return themod.Value(thetime)

      Case eModifierType.DamagePhysicaloT
        Return themod.Value(thetime)

      Case eModifierType.DamagePhysicalPercent
        Return themod.Value(thetime)

      Case eModifierType.DamagePhysicalPerSec
        Return themod.Value(thetime)

      Case eModifierType.DamagePhysicalStackingInflicted 'Bristelback Quillspray 
        Return themod.Value(thetime)

      Case eModifierType.DamagePhysicalSubtracted 'Enfeeble 
        Return themod.Value(thetime)

      Case eModifierType.DamagePierceAdded
        Return themod.Value(thetime)

      Case eModifierType.DamagePierceChancePercent
        Return themod.Value(thetime)

      Case eModifierType.DamagePureAdded
        Return themod.Value(thetime)

      Case eModifierType.DamagePureAsPercentofManaPool 'OD Arcane Orb 
        Return themod.Value(thetime)

      Case eModifierType.DamagePureAsPercentofMaxHP 'Enigma Midnight pulse 
        Return themod.Value(thetime)

      Case eModifierType.HPRemovalAsPercentofMoveDist 'Bloodseeker Rupture 
        Return themod.Value(thetime)

      Case eModifierType.DamagePureInflicted
        Return themod.Value(thetime)


      Case eModifierType.DamagePureoTasPercofMaxHP 'Phoenix Sun Ray 
        Return themod.Value(thetime)


      Case eModifierType.DamagePureoTInflicted 'Phoenix Sun Ray 
        Return themod.Value(thetime)

      Case eModifierType.DamagePurePercent
        Return themod.Value(thetime)

      Case eModifierType.DamagePureRandomInflicted 'Chen Test of Faith. uses maxval and minval in modvalue for range of random value 
        Return themod.Value(thetime)

      Case eModifierType.DamageRangeAdded
        Return themod.Value(thetime)

      Case eModifierType.DamageRangeBlockAdded '= 33 
        Return themod.Value(thetime)

      Case eModifierType.DamageRangemultiplier
        Return themod.Value(thetime)

      Case eModifierType.DamageReduction 'Tide Anchor smash 
        Return themod.Value(thetime)

      Case eModifierType.DamageReturnDuration 'Blademail 
        Return themod.Value(thetime)

      Case eModifierType.HPRemovalSharedWithBoundUnits 'Warlock Fatal Bonds 
        Return themod.Value(thetime)

      Case eModifierType.DamagetoHealPercent 'abadon ulti 
        Return themod.Value(thetime)

      Case eModifierType.DamageTransferedToCaster 'abaddon borrowed time 
        Return themod.Value(thetime)

      Case eModifierType.DarknessNight 'NightStalker. Artificial night induced. max vis for all enemies 675 
        Return themod.Value(thetime)

      Case eModifierType.DeathlustAttackSpeedAdded 'Undying Zombie Deathlust. Attspead added when target is below threshold 
        Return themod.Value(thetime)
      Case eModifierType.DeathlustMoveSpeedPercentAdded 'Undying Zombie movement speed added when target below threshold 

        Return themod.Value(thetime)
      Case eModifierType.DestroysCreep 'Lich Sacrifice 

        Return themod.Value(thetime)
      Case eModifierType.DestroysHero 'Techies Suicide 
        Return themod.Value(thetime)

      Case eModifierType.DestroysHeroBelowThreshold 'Axe Culling Blade 
        Return themod.Value(thetime)


      Case eModifierType.DestroysTree 'Quellingblade 
        Return themod.Value(thetime)

      Case eModifierType.Disarm
        Return themod.Value(thetime)

      Case eModifierType.DisarmMelee '= 69 'http://dota2.gamepedia.com/Disarm 
        Return themod.Value(thetime)

      Case eModifierType.DisarmRange ' Heaven's Halberd 
        Return themod.Value(thetime)

      Case eModifierType.DisjointRange '= 70 'http://dota2.gamepedia.com/Disjoint 
        Return themod.Value(thetime)

      Case eModifierType.Dispel '= 71 'http://dota2.gamepedia.com/Dispel 
        Return themod.Value(thetime)

      Case eModifierType.DisruptionIllusion 'ShadowDemon Illusion 
        Return themod.Value(thetime)

      Case eModifierType.Dominate 'Helm of the dominator 

        Return themod.Value(thetime)
      Case eModifierType.DuelBonusDamage 'lc duel, seperate item so we can do a buff icon for it 

        Return themod.Value(thetime)
      Case eModifierType.ElderDragonForm 'Dragon Knight 

        Return themod.Value(thetime)
      Case eModifierType.Ensnare '= 67 'http://dota2.gamepedia.com/Ensnare 

        Return themod.Value(thetime)
      Case eModifierType.Entangle '= 68 'http://dota2.gamepedia.com/Entangle 
        Return themod.Value(thetime)

      Case eModifierType.EssenceAuraManaRestored 'instances of this determined by amount of enemies in range? 
        Return themod.Value(thetime)

      Case eModifierType.Ethereal_Time '= 77 'http://dota2.gamepedia.com/Ethereal 
        Return themod.Value(thetime)

      Case eModifierType.EvasionPercent
        Return themod.Value(thetime)

      Case eModifierType.EvasionRemoved ' SS Hex removes all evasion 
        Return themod.Value(thetime)

      Case eModifierType.EvilSpirits 'special modtype since spirit count is affected by witchcraft, so has to be calced from inside the mod itself 
        Return themod.Value(thetime)

      Case eModifierType.ExortDamageMagicalInflicted 'Invoker Deafening Blast 
        Return themod.Value(thetime)

      Case eModifierType.ExortDamageMagicalInflictedoT 'Invoker Chaos Meteor 
        Return themod.Value(thetime)

      Case eModifierType.ExortRightClickBonusDamageAdded 'Invoker Alacrity 
        Return themod.Value(thetime)

      Case eModifierType.FadeBoltDamageMagicalBounces 'Rubick, Fade Bolt. bounces diminish the damage, thus the unique modifier. also has no bounce limit but cant hit same target twice 
        Return themod.Value(thetime)

      Case eModifierType.Feedback '= 55 'Diffusal Blade 'http://dota2.gamepedia.com/Unique_Attack_Modifier
        Return themod.Value(thetime)

      Case eModifierType.FrostArrows '= 48 'Drow 'http://dota2.gamepedia.com/Unique_Attack_Modifier
        Return themod.Value(thetime)

      Case eModifierType.Ghost_Form_Time 'Ghost scepter, ethereal blade 
        Return themod.Value(thetime)

      Case eModifierType.GlaivesWisdom '= 51 'Silencer 'http://dota2.gamepedia.com/Unique_Attack_Modifier
        Return themod.Value(thetime)

      Case eModifierType.GreaterBashofCurrentLevel 'Spirit Breaker Nether Strike 
        Return themod.Value(thetime)

      Case eModifierType.Haunt 'Spectre haunt. Takes attributes of Spectre at time of cast 
        Return themod.Value(thetime)

      Case eModifierType.HealAdded
        Return themod.Value(thetime)

      Case eModifierType.HealAddedAsPercOfTargetCurrHP 'Lifestealer Feast 
        Return themod.Value(thetime)

      Case eModifierType.HealAddedoT 'Treant Leach Seed 
        Return themod.Value(thetime)

      Case eModifierType.HealAddedoTAsPercofMaxHP 'Phoenix Sun Ray 
        Return themod.Value(thetime)

      Case eModifierType.HealAddedPerDeadCreep 'Undying Flesh Golem 
        Return themod.Value(thetime)

      Case eModifierType.HealAddedPerDeadHero 'Undying Flesh Golem 
        Return themod.Value(thetime)

      Case eModifierType.HealAddedPerUnit 'Undying Soul Rip 
        Return themod.Value(thetime)

      Case eModifierType.HealAsPercentofHP
        Return themod.Value(thetime)

      Case eModifierType.HealFriendlyorDamageEnemy
        Return themod.Value(thetime)

      Case eModifierType.HealFriendlyorMagicDamEnemyoT 'Warlock Shadow Word 
        Return themod.Value(thetime)

      Case eModifierType.HealMinMaxAdded 'Value has a min and max range 
        Return themod.Value(thetime)

      Case eModifierType.HealoTSetTo 'Backdoor Protection 
        Return themod.Value(thetime)

      Case eModifierType.HealPercent
        Return themod.Value(thetime)

      Case eModifierType.HealthFullyRestored 'Phoenix Supernova 
        Return themod.Value(thetime)

      Case eModifierType.HealthPercentAdded 'Ancient Granite Golem Granite Aura. Increases the health capacity of nearby units. 
        Return themod.Value(thetime)


      Case eModifierType.HealthRegenAdded 'Alchemist Chemical Rage 
        Return themod.Value(thetime)

      Case eModifierType.HealthvalueFrozen 'AA Ice Blast 
        Return themod.Value(thetime)

      Case eModifierType.HeroDamageReducedTo 'Backdoor Protection 
        Return themod.Value(thetime)

      Case eModifierType.HeroReflection 'Terrorblade Reflection. Takes stats from targetted hero 
        Return themod.Value(thetime)

      Case eModifierType.Hex '= 62 'http://dota2.gamepedia.com/Hex 
        Return themod.Value(thetime)

      Case eModifierType.HPAdded '= 2 ' amount (pos or neg representing heal of damage) Damage type (puredamagesingletarget, magicdamageAOE, etc) 
        Return themod.Value(thetime)

      Case eModifierType.HPoT '= 4 'amount as total amount, damagetype(for negative numbers, otherwise none) 
        Return themod.Value(thetime)

      Case eModifierType.HPPercent '= 3 ' amount as decimal 
        Return themod.Value(thetime)

      Case eModifierType.HPRegenAdded
        Return themod.Value(thetime)

      Case eModifierType.HPRegenPercent
        Return themod.Value(thetime)

      Case eModifierType.HPRegenPercentofCasters 'io Tether 
        Return themod.Value(thetime)

      Case eModifierType.HPRegenPerUnitKilledAdded 'necro sadist 
        Return themod.Value(thetime)

      Case eModifierType.HPSubtracted
        Return themod.Value(thetime)

      Case eModifierType.IllusionDamageReducedTo 'Backdoor protection 
        Return themod.Value(thetime)

      Case eModifierType.Impetus '= 43 'Enchantress 'http://dota2.gamepedia.com/Unique_Attack_Modifier
        Return themod.Value(thetime)

      Case eModifierType.ImpetusDamagePureInflicted 'Enchantress Impetus. damage as function of distance 
        Return themod.Value(thetime)

      Case eModifierType.IncapBite '= 47 'Broodmother 'http://dota2.gamepedia.com/Unique_Attack_Modifier
        Return themod.Value(thetime)

      Case eModifierType.InfestCreepHeal 'Lifestealer Infest. If infest in creep then creep hp as heal on consume 
        Return themod.Value(thetime)

      Case eModifierType.InnerVitalityPercentHealAdded 'Huskar Inner Vitality. Will have to check target's health to see which healpercentage to use 
        Return themod.Value(thetime)

      Case eModifierType.IntAdded '= 18 
        Return themod.Value(thetime)

      Case eModifierType.IntoT '= 20 
        Return themod.Value(thetime)


      Case eModifierType.IntPercent '= 19 
        Return themod.Value(thetime)

      Case eModifierType.IntSubtracted 'slark Essence Shift 
        Return themod.Value(thetime)

      Case eModifierType.Invisibility '= 72 'http://dota2.gamepedia.com/Invisibility 
        Return themod.Value(thetime)

      Case eModifierType.InvokeASpell 'Invoker Invoke 'http://dota2.gamepedia.com/Unique_Attack_Modifier
        Return themod.Value(thetime)


      Case eModifierType.InvokeSpellCount 'Invoker Invoke MaxSpells 'http://dota2.gamepedia.com/Unique_Attack_Modifier
        Return themod.Value(thetime)

      Case eModifierType.Invulnerability '= 73 'http://dota2.gamepedia.com/Invulnerability 
        Return themod.Value(thetime)

      Case eModifierType.ItemEffectiveHP '= 86 
        Return themod.Value(thetime)

      Case eModifierType.Knockback 'batrider firefly and many others 
        Return themod.Value(thetime)

      Case eModifierType.KotLSpiritForm 'Kotl 
        Return themod.Value(thetime)

      Case eModifierType.LastHitGoldAdded 'Alchemist Greevil's Greed 
        Return themod.Value(thetime)

      Case eModifierType.LastHitGoldBonusPerStack 'Alchemist Greevil's Greed 


      Case eModifierType.Leap 'slark spiritbreaker 
        Return themod.Value(thetime)

      Case eModifierType.LifeDrainDrainfromTarget 'Pugna Life Drain. Different effects depending if target is friend or foe 'http://dota2.gamepedia.com/Unique_Attack_Modifier
        Return themod.Value(thetime)

      Case eModifierType.LifeDrainPercent 'DP Exorcism 
        Return themod.Value(thetime)

      Case eModifierType.LifeDrainSelfEffect 'Pugna Life Drain. Different effect to pugna depending on whether targeting friend or foe 'http://dota2.gamepedia.com/Unique_Attack_Modifier
        Return themod.Value(thetime)

      Case eModifierType.LifeStealAdded '= 56 'Helm of the Dominator, mask of madness, satanic 'http://dota2.gamepedia.com/Lifesteal 'http://dota2.gamepedia.com/Unique_Attack_Modifier

        Return themod.Value(thetime)
      Case eModifierType.LifestealAddedtoAllAttackers 'Lifestealer Open Wounds. Allied Heroes get healtch when attacking enemy unit with this debuff 'http://dota2.gamepedia.com/Unique_Attack_Modifier
        Return themod.Value(thetime)

      Case eModifierType.LifeStealPercent 'http://dota2.gamepedia.com/Unique_Attack_Modifier
        Return themod.Value(thetime)

      Case eModifierType.LiquidFire '= 44 'Jakiro 'http://dota2.gamepedia.com/Unique_Attack_Modifier
        Return themod.Value(thetime)

      Case eModifierType.LostHealthDamagePercent 'Witch Doc Maledict 
        Return themod.Value(thetime)

      Case eModifierType.LucentBeamHits 'Luna Eclipse 
        Return themod.Value(thetime)

      Case eModifierType.LvlDeathDamageMagicalInflicted 'Doom Lvl? Death. has to be calced at time using attacked hero level and abdoom_lvl_death.herolevelmultiplier 
        Return themod.Value(thetime)

      Case eModifierType.MagicDamageReceivedMultiplier ' ghost scepter 
        Return themod.Value(thetime)
      Case eModifierType.MagicImmunity '= 30 'http://dota2.gamepedia.com/Magic_immunity 

        Return themod.Value(thetime)
      Case eModifierType.MagicResistanceAdded
        Return themod.Value(thetime)

      Case eModifierType.MagicResistanceCapped 'Lifestealer Rage. Gives 100% Magic Resistance 
        Return themod.Value(thetime)

      Case eModifierType.MagicResistancePercentAdded
        Return themod.Value(thetime)
      Case eModifierType.MagicResistancePercentSubtracted 'Pugna Decrepify 
        Return themod.Value(thetime)

      Case eModifierType.MagicResistanceSet 'Medusa Stone Gaze. Set Magic Resistance at a value 
        Return themod.Value(thetime)

      Case eModifierType.MagicResistanceSubtracted 'AA Ice Vortex 
        Return themod.Value(thetime)

      Case eModifierType.MagnatizeDamageOverTime 'will have to make concession for num enemyheroes and numboulders 
        Return themod.Value(thetime)

      Case eModifierType.MaimChance 'sange 
        Return themod.Value(thetime)

      Case eModifierType.ManaAdded '= 6 
        Return themod.Value(thetime)

      Case eModifierType.ManaBreak '= 41 'Anti-Mage 'http://dota2.gamepedia.com/Unique_Attack_Modifier
        Return themod.Value(thetime)

      Case eModifierType.ManaBurnDamage 'Nyx Mana Burn. uses target's intelligence to calc damage 
        Return themod.Value(thetime)

      Case eModifierType.ManaBurnManaremoved 'Nyx Mana Burn. Uses target's intelligence to calc mana removed. 
        Return themod.Value(thetime)

      Case eModifierType.ManaDrained ' antimage manaburn, it damage to mana inflicted. 
        Return themod.Value(thetime)

      Case eModifierType.ManaDrainedUntilSpellcast 'Silencer Curse of the Silent. Darinas mana until duration end or target casts spell 
        Return themod.Value(thetime)

      Case eModifierType.ManaoT '= 8 
        Return themod.Value(thetime)

      Case eModifierType.ManaPercent '= 7 
        Return themod.Value(thetime)

      Case eModifierType.ManaPercentDrained 'Bane Fiend's Grip, percent is based off of targets max mana 
        Return themod.Value(thetime)

      Case eModifierType.ManaRegenAdded
        Return themod.Value(thetime)

      Case eModifierType.ManaRegenPercent
        Return themod.Value(thetime)

      Case eModifierType.ManaRegenPercentofCasters 'IO tether 
        Return themod.Value(thetime)

      Case eModifierType.ManaRegenPerUnitKillAdded 'Necro Sadist 
        Return themod.Value(thetime)

      Case eModifierType.ManaRemoved 'Invoker EMP 
        Return themod.Value(thetime)

      Case eModifierType.ManaRemovedoT 'Morphling Morph 
        Return themod.Value(thetime)

      Case eModifierType.ManaRemovedPercentoT 'KotL Mana Leak 
        Return themod.Value(thetime)

      Case eModifierType.ManaRestored
        Return themod.Value(thetime)

      Case eModifierType.ManaRestoredAsPercentOfHP 'Lich Sacrifice 
        Return themod.Value(thetime)

      Case eModifierType.ManaRestoredPercent
        Return themod.Value(thetime)

      Case eModifierType.MantaMeleeIllusionDamagePercentage 'Manta style 
        Return themod.Value(thetime)

      Case eModifierType.MantaRangeIllusionDamagePercentage
        Return themod.Value(thetime)

      Case eModifierType.MeepoClone 'Meepo Divided We Stand 
        Return themod.Value(thetime)

      Case eModifierType.MeleeSlow 'orb of venom 
        Return themod.Value(thetime)

      Case eModifierType.MeleeStun ' Abyssal Blade 
        Return themod.Value(thetime)

      Case eModifierType.MeltingStrike '= 49 'Invoker's forged Spirit 'http://dota2.gamepedia.com/Unique_Attack_Modifier
        Return themod.Value(thetime)

      Case eModifierType.MidnightPulsePureDamageAdded 'Black hole scepter upgrade adds midnight pulse damage at current level 
        Return themod.Value(thetime)

      Case eModifierType.Minibash_Damage
        Return themod.Value(thetime)

      Case eModifierType.MiniMapInvisibility 'Phantom Ass, Blur 
        Return themod.Value(thetime)

      Case eModifierType.MiniStun
        Return themod.Value(thetime)

      Case eModifierType.MirrorImage 'Naga Siren Mirror Image. Takes props from hero's stats at time 
        Return themod.Value(thetime)

      Case eModifierType.MissChance 'Broodmother incapacitating Bite 
        Return themod.Value(thetime)

      Case eModifierType.MoveSpeedAdded '= 21 ''http://dota2.gamepedia.com/Slow 
        Return themod.Value(thetime)

      Case eModifierType.MoveSpeedMinimum 'for haste, sets minimum movespeed at time for unit, used for Centaur stampede, etc 
        Return themod.Value(thetime)

      Case eModifierType.MoveSpeedoT '= 23 
        Return themod.Value(thetime)

      Case eModifierType.MoveSpeedPercent
        Return themod.Value(thetime)

      Case eModifierType.MoveSpeedPercentAdded 'Slardar Sprint 
        Return themod.Value(thetime)

      Case eModifierType.MoveSpeedPercentAddedPerHeroPerMissHP 'Bloodseeker Thirst 
        Return themod.Value(thetime)

      Case eModifierType.MoveSpeedPercentAsDamage 'Spiritbreaker greater bash 
        Return themod.Value(thetime)

      Case eModifierType.MoveSpeedPercentofTargetAdded 'Visage Grave Chill 
        Return themod.Value(thetime)

      Case eModifierType.MoveSpeedPercentStackSubtracted 'Bristleback Nasal Goo 
        Return themod.Value(thetime)

      Case eModifierType.MoveSpeedPercentSubtracted 'Bristleback Nasal Goo 
        Return themod.Value(thetime)

      Case eModifierType.MoveSpeedSet 'Lycan Shapeshift 
        Return themod.Value(thetime)

      Case eModifierType.MoveSpeedStackAdded 'Lina Fiery Soul 
        Return themod.Value(thetime)
      Case eModifierType.MoveSpeedSubtracted 'boar moveslow 

        Return themod.Value(thetime)
      Case eModifierType.MulticastBloodlustCoolReduction
        Return themod.Value(thetime)

      Case eModifierType.MulticastBloodlustRadiusAdded
        Return themod.Value(thetime)

      Case eModifierType.MulticastFireblastCoolReduction
        Return themod.Value(thetime)

      Case eModifierType.MulticastFireblastManaAdded
        Return themod.Value(thetime)

      Case eModifierType.MulticastFourXChance
        Return themod.Value(thetime)

      Case eModifierType.MulticastIgniteCastRangeAdded
        Return themod.Value(thetime)
      Case eModifierType.MulticastIgniteRadius
        Return themod.Value(thetime)

      Case eModifierType.MulticastThreeXChance
        Return themod.Value(thetime)

      Case eModifierType.MulticastTwoXChance
        Return themod.Value(thetime)

      Case eModifierType.MuteAbilities '= 79 'unable to cast abilities 
        Return themod.Value(thetime)
      Case eModifierType.MuteAllOnTarget 'stops eveything on target (items, move, abilities, etc.) Bane Nightmare 

        Return themod.Value(thetime)
      Case eModifierType.MuteAttacks 'Flaming Lasso Batrider 

        Return themod.Value(thetime)
      Case eModifierType.MuteBlink '= 81 'unable to blink 

        Return themod.Value(thetime)
      Case eModifierType.MuteInvisibility 'treant overgrowth 

        Return themod.Value(thetime)
      Case eModifierType.MuteItems '= 80 'unable to cast items 
        Return themod.Value(thetime)
      Case eModifierType.MuteMove '= 82 'unable to move 
        Return themod.Value(thetime)

      Case eModifierType.MuteRightClick '= 84 'unable to rightclick 
        Return themod.Value(thetime)

      Case eModifierType.MuteTargetability '= 85 'unable to be targetted 
        Return themod.Value(thetime)

      Case eModifierType.MuteTeleport 'Blink (Queen of Pain) , Blink, Teleportation, Charge of Darkness, Phase Shift and Blink Dagger. 
        Return themod.Value(thetime)

      Case eModifierType.MuteTurn '= 83 'unable to turn 
        Return themod.Value(thetime)

      Case eModifierType.MysticSnakeDamageAdded 'Medusa Mystic Snake. ability bounces between enemies, inflicting more damage the more it jumps 
        Return themod.Value(thetime)

      Case eModifierType.MysticSnakeManaAdded 'Medusa Mystic Snake. ability bounces between enemies, grabbing more mana the more it jumps 
        Return themod.Value(thetime)
      Case eModifierType.MysticSnakeManaSubtracted 'enemy units hit by mystic snake lose mana 
        Return themod.Value(thetime)

      Case eModifierType.BaseGold
        Return themod.Value(thetime)

      Case eModifierType.NightAttackSpeedAdded 'Nightstalker Hunter in the Night 
        Return themod.Value(thetime)
      Case eModifierType.NightAttackSpeedSubtracted 'Nightstalker Void. Duration differs for day and night 
        Return themod.Value(thetime)

      Case eModifierType.NightMoveSpeedAdded 'NightStalker Hunter in the Night 
        Return themod.Value(thetime)

      Case eModifierType.OpenWoundsSlowInflicted 'Lifestealer Open Wounds. Will have to call list for slow values for each interval 
        Return themod.Value(thetime)

      Case eModifierType.PackleaderRClickDamageAsPercofBaseDamandPrimaryStat 'Alpha Wolf Packleader's Aura 
        Return themod.Value(thetime)

      Case eModifierType.PauseTime '= 63 'http://dota2.gamepedia.com/Pause 
        Return themod.Value(thetime)

      Case eModifierType.PercentofCreepHealthGained 'Clinks DeathPact 
        Return themod.Value(thetime)

      Case eModifierType.petAlpha_Wolf
        Return themod.Value(thetime)

      Case eModifierType.petAncient_Black_Dragon
        Return themod.Value(thetime)

      Case eModifierType.petAncient_Black_Drake
        Return themod.Value(thetime)

      Case eModifierType.petAncient_Granite_Golem
        Return themod.Value(thetime)

      Case eModifierType.petAncient_Rock_Golem
        Return themod.Value(thetime)

      Case eModifierType.petAncient_Rumblehide
        Return themod.Value(thetime)

      Case eModifierType.petAncient_Thunderhide
        Return themod.Value(thetime)

      Case eModifierType.petBoar
        Return themod.Value(thetime)

      Case eModifierType.petCentaur_Conqueror
        Return themod.Value(thetime)

      Case eModifierType.petCentaur_Courser
        Return themod.Value(thetime)

      Case eModifierType.petDark_Troll_Summoner
        Return themod.Value(thetime)

      Case eModifierType.petDeath_Ward
        Return themod.Value(thetime)

      Case eModifierType.petEarth_Brewmaster
        Return themod.Value(thetime)

      Case eModifierType.petEidolon
        Return themod.Value(thetime)

      Case eModifierType.petFamiliar
        Return themod.Value(thetime)

      Case eModifierType.petFell_Spirit
        Return themod.Value(thetime)

      Case eModifierType.petFire_Brewmaster
        Return themod.Value(thetime)

      Case eModifierType.petForged_Spirit
        Return themod.Value(thetime)

      Case eModifierType.petFrozen_Sigil
        Return themod.Value(thetime)

      Case eModifierType.petGhost
        Return themod.Value(thetime)

      Case eModifierType.petGiant_Wolf
        Return themod.Value(thetime)

      Case eModifierType.petGolem_Warlock
        Return themod.Value(thetime)

      Case eModifierType.petHarpy_Scout
        Return themod.Value(thetime)

      Case eModifierType.petHarpy_Stormcrafter
        Return themod.Value(thetime)
      Case eModifierType.petHawk
        Return themod.Value(thetime)

      Case eModifierType.petHealing_Ward
        Return themod.Value(thetime)

      Case eModifierType.petHellbear
        Return themod.Value(thetime)

      Case eModifierType.petHellbear_Smasher
        Return themod.Value(thetime)

      Case eModifierType.petHill_Trll
        Return themod.Value(thetime)

      Case eModifierType.petHill_Troll_Berserker
        Return themod.Value(thetime)

      Case eModifierType.petHill_Troll_Priest
        Return themod.Value(thetime)

      Case eModifierType.petHoming_Missile
        Return themod.Value(thetime)

      Case eModifierType.petKobold
        Return themod.Value(thetime)

      Case eModifierType.petKobold_Foreman
        Return themod.Value(thetime)

      Case eModifierType.petKobold_Soldier
        Return themod.Value(thetime)

      Case eModifierType.petLand_Mine
        Return themod.Value(thetime)

      Case eModifierType.petLycan_Wolf
        Return themod.Value(thetime)

      Case eModifierType.petMega_Melee_Creep
        Return themod.Value(thetime)

      Case eModifierType.petMega_Ranged_Creep
        Return themod.Value(thetime)

      Case eModifierType.petMelee_Creep
        Return themod.Value(thetime)

      Case eModifierType.petMud_Golem
        Return themod.Value(thetime)

      Case eModifierType.petNecro_Archer
        Return themod.Value(thetime)

      Case eModifierType.petNecro_Warrior
        Return themod.Value(thetime)

      Case eModifierType.petNether_Ward
        Return themod.Value(thetime)

      Case eModifierType.petObserver_Ward
        Return themod.Value(thetime)

      Case eModifierType.petOgre_Bruiser
        Return themod.Value(thetime)

      Case eModifierType.petOgre_Frostmage
        Return themod.Value(thetime)

      Case eModifierType.petPhantomLancer
        Return themod.Value(thetime)

      Case eModifierType.petPhoenix_Sun
        Return themod.Value(thetime)

      Case eModifierType.petPlague_Ward
        Return themod.Value(thetime)

      Case eModifierType.petPower_Cog
        Return themod.Value(thetime)

      Case eModifierType.petPsionic_Trap
        Return themod.Value(thetime)

      Case eModifierType.petRanged_Creep
        Return themod.Value(thetime)

      Case eModifierType.petRemote_Mine
        Return themod.Value(thetime)

      Case eModifierType.petSatyr_Banisher
        Return themod.Value(thetime)

      Case eModifierType.petSatyr_Mindstealer
        Return themod.Value(thetime)

      Case eModifierType.petSatyr_Tormentor
        Return themod.Value(thetime)

      Case eModifierType.petSentry_Ward
        Return themod.Value(thetime)

      Case eModifierType.petSerpent_Ward
        Return themod.Value(thetime)

      Case eModifierType.petSiege_Creep
        Return themod.Value(thetime)

      Case eModifierType.petSiege_Creep_Bonus
        Return themod.Value(thetime)

      Case eModifierType.petSkeleton_Warrior
        Return themod.Value(thetime)

      Case eModifierType.petSpiderite
        Return themod.Value(thetime)

      Case eModifierType.petSpiderling
        Return themod.Value(thetime)

      Case eModifierType.petSpirit
        Return themod.Value(thetime)

      Case eModifierType.petSpirit_Bear
        Return themod.Value(thetime)

      Case eModifierType.petStasis_Trap
        Return themod.Value(thetime)

      Case eModifierType.petStorm_Brewmaster
        Return themod.Value(thetime)

      Case eModifierType.petSuper_Melee_Creep
        Return themod.Value(thetime)

      Case eModifierType.petSuper_Ranged_Creep
        Return themod.Value(thetime)

      Case eModifierType.petTombstone
        Return themod.Value(thetime)

      Case eModifierType.petTornado
        Return themod.Value(thetime)

      Case eModifierType.petTreant
        Return themod.Value(thetime)

      Case eModifierType.petUndying_Zombie
        Return themod.Value(thetime)

      Case eModifierType.petVhoul_Assassin
        Return themod.Value(thetime)

      Case eModifierType.petWildwing
        Return themod.Value(thetime)

      Case eModifierType.petWildwing_Ripper
        Return themod.Value(thetime)

      Case eModifierType.Phantasms 'Chaoes night ulti, receiver will have to get current chaos knight build to calc phant stats 
        Return themod.Value(thetime)

      Case eModifierType.PhantomStrikeAttSpeedAdded 'Phantom Ass, Phantom Strike. If target is enemy hero the att speed added for mCharge count of rightclick attacks 
        Return themod.Value(thetime)

      Case eModifierType.Phase_Form 'phase boots 
        Return themod.Value(thetime)

      Case eModifierType.PoisonAttack '= 46 'Viper, Orb of Venom 'http://dota2.gamepedia.com/Unique_Attack_Modifier
        Return themod.Value(thetime)

      Case eModifierType.PrimaryStatDamageAdded 'Ethereal Blade 
        Return themod.Value(thetime)

      Case eModifierType.PrimaryStatLossPercent 'timeber whirling death 
        Return themod.Value(thetime)

      Case eModifierType.Pullback ' x marks, pudgehook 
        Return themod.Value(thetime)

      Case eModifierType.PullForward
        Return themod.Value(thetime)

      Case eModifierType.Purge '= 74 'http://dota2.gamepedia.com/Purge 
        Return themod.Value(thetime)

      Case eModifierType.PurgeFrequency '= 75 
        Return themod.Value(thetime)

      Case eModifierType.PushForward 'force staff 
        Return themod.Value(thetime)

      Case eModifierType.PushSideways 'Beastmaster Primal Roar 
        Return themod.Value(thetime)

      Case eModifierType.QuasCyclone 'Invoker Tornado 
        Return themod.Value(thetime)

      Case eModifierType.QuasKnockback 'Invoker Deafening Blas. Duration as distance determined byQuas level 
        Return themod.Value(thetime)

      Case eModifierType.QuasMoveSpeedPercentChange 'Invoker Ghost Walk 
        Return themod.Value(thetime)

      Case eModifierType.QuillSprayCast 'Bristleback Bristleback ability 
        Return themod.Value(thetime)

      Case eModifierType.RabidAttackSpeedAdded 'Lone Druid Rabid. Has to apply to both druid and bear 
        Return themod.Value(thetime)

      Case eModifierType.RabidDurationBonus 'Lone Druid 
        Return themod.Value(thetime)

      Case eModifierType.RabidMoveSpeedAdded 'Lone Druid Rabid. Needs to add to both druid and bear 
        Return themod.Value(thetime)

      Case eModifierType.RandomTargetHealAdded 'Enchantress nature's attendants 
        Return themod.Value(thetime)

      Case eModifierType.RangeSlow
        Return themod.Value(thetime)

      Case eModifierType.RangeStun 'Abyssal blade 
        Return themod.Value(thetime)

      Case eModifierType.ReflectedDamageInflicted 'Nyx Spiked Carapace. damage component of spell. inlficted on attacker 
        Return themod.Value(thetime)

      Case eModifierType.Reincarnate 'Aegis 
        Return themod.Value(thetime)

      Case eModifierType.RemoveBuffs 'Diffusal Blade 
        Return themod.Value(thetime)

      Case eModifierType.RemoveDebuffs ' abaddon ulti 
        Return themod.Value(thetime)

      Case eModifierType.RemoveDisables 'LC Press the attack 
        Return themod.Value(thetime)

      Case eModifierType.ReplacedByPets 'Brew Primal Split 
        Return themod.Value(thetime)


      Case eModifierType.Replicant 'Morphling Replicate. Need to know which hero is targeted at the time 
        Return themod.Value(thetime)

      Case eModifierType.RequiemDamageMagicalInflicted 'Shadow Fiend Reqiem of Souls. Damage is per line. Line count is 1 for each 2 soulds in Necromastery 
        Return themod.Value(thetime)

      Case eModifierType.Reset_Cooldowns 'Refresher 
        Return themod.Value(thetime)

      Case eModifierType.RightClickAttackAttackSlowInflicted 'Right click attack also adds an attack speed debuff to target 
        Return themod.Value(thetime)

      Case eModifierType.RightClickAttackDamage 'Ember's Sleight of Fist, represents the damge from one instance of rightclick damage 
        Return themod.Value(thetime)

      Case eModifierType.RightClickBonusDamageAdded 'TB Metamorphosis 
        Return themod.Value(thetime)

      Case eModifierType.RightClickBonusDamageInflicted 'Faceless Void Time Lock 
        Return themod.Value(thetime)

      Case eModifierType.RightClickBonusPureDamageInflicted 'Spectre Desolate 
        Return themod.Value(thetime)

      Case eModifierType.RightClickBurnedMana 'Necro Warrior Mana Break 
        Return themod.Value(thetime)

      Case eModifierType.RightClickCausticFinale 'Sand King Caustic Finale added 

      Case eModifierType.RightClickCounterAttack 'Axw counter helix, LC MomentofCOurage 
        Return themod.Value(thetime)

      Case eModifierType.RightClickDamageAdded 'LC Duel 
        Return themod.Value(thetime)

      Case eModifierType.RightClickDamageAsLine 'TA Psi blades. RightClick damage now emanates in line away from TA so multitargets 
        Return themod.Value(thetime)

      Case eModifierType.RightClickDamageAsPercOfTargetCurrHP 'lifestealer Feast 
        Return themod.Value(thetime)

      Case eModifierType.RightClickDamageInflicted 'Windranger Focus Fire 
        Return themod.Value(thetime)

      Case eModifierType.RightClickDamageInstanceAvoided 'Faceless BackTrack 
        Return themod.Value(thetime)

      Case eModifierType.RightClickDamageMultipleInflicted 'Phantom Ass, Coup de Grace 
        Return themod.Value(thetime)

      Case eModifierType.RightClickDamageMultiplier 'weaver germinate 
        Return themod.Value(thetime)

      Case eModifierType.RightClickDamageoT 'Right Click attack also puts a DoT on target 
        Return themod.Value(thetime)

      Case eModifierType.RightClickDamagePercentageInflicted
        Return themod.Value(thetime)

      Case eModifierType.RightClickDamagePercentInflicted 'Phantom Lancer Spirit Lance Illusion damage 
        Return themod.Value(thetime)

      Case eModifierType.RightClickDamagePercentSubtracted 'SF Requiem of Souls 
        Return themod.Value(thetime)

      Case eModifierType.RightClickDamageWithBuffs 'gyro flak cannon 
        Return themod.Value(thetime)

      Case eModifierType.RightClickDamageWithoutBuffs 'gyro flak cannon 
        Return themod.Value(thetime)

      Case eModifierType.RightClickDamPhysStackingInflicted 'Ursa furry swipes 
        Return themod.Value(thetime)

      Case eModifierType.RightClickHealthasDamagePercInflicted 'Ursa Enrage 
        Return themod.Value(thetime)

      Case eModifierType.RightClickInttoPureDamage 'Silencer Glaives of Wisdom. deals a percentage of silencer's int as pure damage 
        Return themod.Value(thetime)

      Case eModifierType.RightClickMoonGlaiveBounces 'Luna moon glaive 
        Return themod.Value(thetime)

      Case eModifierType.RightClickMoveSpeedPercSubtracted 'Meepo Geostrike 
        Return themod.Value(thetime)

      Case eModifierType.RightClickNetherToxinDamage 'Viper Nethertoxin does damage for each 20% of health missing in target 
        Return themod.Value(thetime)
      Case eModifierType.RightClickPureDamageInflicted 'Warlock Golem Flaming Fists 
        Return themod.Value(thetime)

      Case eModifierType.RightClickStun 'Faceless TimeLock 
        Return themod.Value(thetime)

      Case eModifierType.RoshanArmorAddedPer4Min 'Strength of the Immortal 
        Return themod.Value(thetime)

      Case eModifierType.RoshanHealthPer4MinAdded 'Strength of the Immortal 
        Return themod.Value(thetime)


      Case eModifierType.RoshanRClickAttackDamPer4MinAdded 'Strength of the Immortal 
        Return themod.Value(thetime)

      Case eModifierType.RoshanSlamDamageTimeIncrease 'Roshan Slam increases in damage every 4 minutes 
        Return themod.Value(thetime)

      Case eModifierType.SanitysDamageMagicalInflictedAsMultofIntDiff 'OD Sanity's Eclipse. Damage is a multiple of the difference between OD's int and affected enemy's int. if difference is negative, then no effect 
        Return themod.Value(thetime)

      Case eModifierType.SanitysManaPercentRemovedwithThreshold 'OD Sanity's Eclipse. If the diff of int between OD and affected enemy is less than threshold then mana removed 
        Return themod.Value(thetime)

      Case eModifierType.SearingArrows '= 42 'Clinkz 'http://dota2.gamepedia.com/Unique_Attack_Modifier

        Return themod.Value(thetime)
      Case eModifierType.SelfDeny 'Bloodstone Pocket Suicide 

        Return themod.Value(thetime)
      Case eModifierType.ShackleTime '= 61 'http://dota2.gamepedia.com/Disable like lasso 
        Return themod.Value(thetime)
      Case eModifierType.ShadowPoisonStackDamage 'Shadow Demon Shadow Poison, Each staup up to 5 increases damage, after that it's 50 each addl stack 
        Return themod.Value(thetime)

      Case eModifierType.ShallowGrave 'Dazzle 
        Return themod.Value(thetime)
      Case eModifierType.Shatter 'AA IceBlast 
        Return themod.Value(thetime)

      Case eModifierType.Silence '= 76 'http://dota2.gamepedia.com/Silence 
        Return themod.Value(thetime)

      Case eModifierType.Sleep '= 66 'http://dota2.gamepedia.com/Sleep 
        Return themod.Value(thetime)

      Case eModifierType.SpawnSpiderite 'Spiderling Spawn Spiderite 
        Return themod.Value(thetime)

      Case eModifierType.SpellBlock ' Linken's blocks n spells 
        Return themod.Value(thetime)

      Case eModifierType.SpellBlockDuration ' Blocks all spells for n seconds 
        Return themod.Value(thetime)

      Case eModifierType.StaticFieldHealthReduction 'Zeus Static Field 
        Return themod.Value(thetime)

      Case eModifierType.StaticLinkBonusDamage 'Razer 
        Return themod.Value(thetime)

      Case eModifierType.StaticStormDamageMagicalInflicted 'Disruptor Static Storm. Will have to call list for pulse values and calc with or without aghs 
        Return themod.Value(thetime)

      Case eModifierType.StationaryInvisibility 'TA Meld. Invis until TA moves 
        Return themod.Value(thetime)

      Case eModifierType.StealthVisibility 'dust of appearance, sentry wards 
        Return themod.Value(thetime)

      Case eModifierType.StrAdded '= 12 
        Return themod.Value(thetime)

      Case eModifierType.StrAddedPerKill 'pudge FleshHeap 
        Return themod.Value(thetime)

      Case eModifierType.StrengthPercentageAsAllDamage 'Centaur stampede 
        Return themod.Value(thetime)

      Case eModifierType.StrengthPercentageCounterAttack 'Centaur Warrunner Return 
        Return themod.Value(thetime)

      Case eModifierType.StroT '= 14 
        Return themod.Value(thetime)

        'Case eModifierType.StrPercent '= 13 
        '  Return themod.Value(thetime)

      Case eModifierType.StrSubtracted 'Slark Essence Shift 
        Return themod.Value(thetime)

      Case eModifierType.Stun '= 60 'http://dota2.gamepedia.com/Stun 'Does NOT include MiniStuns 
        Return themod.Value(thetime)
      Case eModifierType.StunChain 'Witch doc Paralyzing Cask 
        Return themod.Value(thetime)

      Case eModifierType.StunRandom 'ChaosKnight Chaos Bolt 
        Return themod.Value(thetime)

      Case eModifierType.Sunder 'TB Sunder. Swaps health with target 
        Return themod.Value(thetime)

      Case eModifierType.SunStrikePureInflicted 'Invoker SunStrike. Damage is divided among enemy targets 
        Return themod.Value(thetime)

      Case eModifierType.TargetedDamageReflected 'nyx Spiked Carapace. Only reflects damage targetted directly at nyx 
        Return themod.Value(thetime)

      Case eModifierType.TargetsCurrentHealthAsDamageMagicalInfliced 'Huskar Life Break Damage Dealt 
        Return themod.Value(thetime)

      Case eModifierType.Taunt '= 65 'http://dota2.gamepedia.com/Taunt 
        Return themod.Value(thetime)
      Case eModifierType.Teleport '= 78 
        Return themod.Value(thetime)

      Case eModifierType.TeleportRandom 'Chaosknight Reality Rift 
        Return themod.Value(thetime)
      Case eModifierType.TimeLapse 'weaver ulti 
        Return themod.Value(thetime)

      Case eModifierType.TinyTossBonusDamage 'Tiny Grow 
        Return themod.Value(thetime)

      Case eModifierType.TinyTossDamageInflicted 'seperate type to enable check for TinyTossBonusDamage 
        Return themod.Value(thetime)

      Case eModifierType.Traptime '= 64 'http://dota2.gamepedia.com/Trap clockwork cogs 
        Return themod.Value(thetime)

      Case eModifierType.TrueFormHPAdded 'Lone Druid 
        Return themod.Value(thetime)

      Case eModifierType.Truesight '= 39 'http://dota2.gamepedia.com/Invisibility 
        Return themod.Value(thetime)

      Case eModifierType.TruesightofTarget 'bounty hunter track 
        Return themod.Value(thetime)

      Case eModifierType.TruesightRadius '= 40 
        Return themod.Value(thetime)

      Case eModifierType.TurnRateSubtracted 'Batrider Sticky Napalm 
        Return themod.Value(thetime)

      Case eModifierType.UnobstructedMovementandVision 'batrider firefly 
        Return themod.Value(thetime)

      Case eModifierType.UnobstructedVision 'Nightstalker Darkness 
        Return themod.Value(thetime)

      Case eModifierType.VanguardMeleeBlockAdded 'block dependant on whether you are melee or ranged 
        Return themod.Value(thetime)

      Case eModifierType.VanguardRangeblockAdded 'Vanguard: 
        Return themod.Value(thetime)

      Case eModifierType.Vision 'observerward 
        Return themod.Value(thetime)

      Case eModifierType.VisionDay 'beast hawk 
        Return themod.Value(thetime)

      Case eModifierType.VisionNight 'beast hawk 
        Return themod.Value(thetime)

      Case eModifierType.VisionNightAdded 'Lycan Shapeshift 
        Return themod.Value(thetime)

      Case eModifierType.VoidMoveSpeedPercentSubtracted 'Nightstalker void. Duration changes depending on day or night 
        Return themod.Value(thetime)

      Case eModifierType.WallHeroReplica 'Dark Seer Wall of Replica 
        Return themod.Value(thetime)

      Case eModifierType.Web 'Broodmother Spin Web 
        Return themod.Value(thetime)

      Case eModifierType.WexAttackSpeedAdded 'Invoker Alacitry 
        Return themod.Value(thetime)

      Case eModifierType.WexDamageMagicalInflicted 'Invoker Tornado 
        Return themod.Value(thetime)

      Case eModifierType.WexDamagePureInflicted ' 
        Return themod.Value(thetime)

      Case eModifierType.WexDisarm 'Invoker Deafening Blast. Duration determined by wex level 

        Return themod.Value(thetime)
      Case eModifierType.WexManaRestored 'Invoker EMP. Restores have of mana burn from heroes ONLY 

        Return themod.Value(thetime)
      Case eModifierType.WexMoveSpeedPercentChangeSubtracted 'Invoker Ghost Walk 
        Return themod.Value(thetime)

      Case eModifierType.WexVision 'Invoker Tornado 
        Return themod.Value(thetime)

      Case eModifierType.WitchcraftCooldownDecrease
        Return themod.Value(thetime)

      Case eModifierType.WitchcraftManaCostDecrease 'DP Witchcraft 
        Return themod.Value(thetime)

      Case eModifierType.WitchcraftSpiritIncrease
        Return themod.Value(thetime)

      Case eModifierType.WrathofNatureMagicDamageBounceInflicted 'Nature's Proph damage increases with each bounce 

        Return themod.Value(thetime)
      Case eModifierType.XPAdded 'Lich Sacrifice 
        Return themod.Value(thetime)

      Case eModifierType.ZombiesPerUnit 'Undying Tombstone Zombies 
        Return themod.Value(thetime)


      Case Else


        PageHandler.theLog.writelog("case not handled in modfilters.GetModifierValuesAtTime: " & themod.ModifierType.ToString)
        Throw New NotImplementedException
    End Select

    Return Nothing
  End Function

  Public Shared Sub SortmodifierListByTargetIds(thelist As ModifierList, thegame As dGame)
    ' curComparer = eComparerType.TargetIDs
    'curComparer = eComparerType.ParentType


    'Me.Sort(AddressOf CompareItemsByString)

    'This crappy sort is here cuz me.sort by target ID's throws
    'error argumentoutofrangeexception

    Dim curtargs As String = ""
    Dim targlists As New Dictionary(Of String, List(Of Modifier))
    For i As Integer = 0 To thelist.Count - 1
      If i = 33 Then
        Dim x = 2
      End If
      curtargs = Helpers.GetInGameTargetsStringForMod(thelist.Item(i), thegame) 'Me.Item(i).GetInGameTargetsString
      If Not targlists.ContainsKey(curtargs) Then
        Dim newlist As New List(Of Modifier)
        newlist.Add(thelist.Item(i))
        targlists.Add(curtargs, newlist)
      Else
        Dim curlist = targlists.Item(curtargs)
        curlist.Add(thelist.Item(i))
      End If
    Next



    thelist.Clear()
    For Each kv As KeyValuePair(Of String, List(Of Modifier)) In targlists
      Dim curlist = kv.Value

      For i As Integer = 0 To curlist.Count - 1
        thelist.Add(curlist.Item(i))
      Next

    Next

  End Sub
End Class
