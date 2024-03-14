Public Class Creeps_and_Pets_Database
  'Dim mCBundles As CreepBundles
  Private CreepEnumitems As Array
  Private PetEnumItems As Array
  Private mCreeps As Dictionary(Of eCreepName, Creep)

  Private mPets As Dictionary(Of ePetName, Pet)
  Private mCreep_Infos As Dictionary(Of Guid, Creep_Info)
  Private mPet_Infos As Dictionary(Of Guid, Pet_Info)

  Private mLog As iLogging
  Private mtimekeeper As TimeKeeper
  Public Sub New(thelog As iLogging, time As TimeKeeper)
    mtimekeeper = time
    mLog = thelog
    CreepEnumitems = System.Enum.GetValues(GetType(eCreepName))
    PetEnumItems = System.Enum.GetValues(GetType(ePetName))
  End Sub
  'Public Function GetCreep( thecreepname As eCreepName,  thegame As dGame,  theability_InfoID As dvID, _
  '                                                   thecaster As dvID,  thecastertype As eSourcetype, _
  '                                                   thetarget As dvID,  thetargettype As eSourcetype, _
  '                                                   ftarget As dvID,  ftargettype As eSourcetype, _
  '                                                   isfriendbias As Boolean, _
  '                                                   occurencetime As Lifetime,  aghstime As Lifetime)

  'End Function
  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="thecreepname"></param>
  ''' <param name="creeplevel"></param>
  ''' <param name="theparent"></param>
  ''' <param name="thelifetime"></param>
  ''' <param name="thecreepexistsatlvls">sets at what ability/creep/item level(s) that the creep exists at. If Nothing, then exists at all levels</param>
  ''' <returns>sets the additional or different creeps that exist when you have aghs scepter</returns>
  ''' <remarks></remarks>
  Private Function GetNewCreepInfo(thecreepname As eCreepName, creeplevel As Integer, _
                                theparent As iGameEntity, _
                                thelifetime As Lifetime, _
                                thecreepexistsatlvls As ValueWrapper, _
                                thescepterexistsatlvls As ValueWrapper, _
                                theenemytarget As iDisplayUnit, _
                                thefriendtarget As iDisplayUnit, _
                                thefriendbias As Boolean, _
                                thegame As dGame) As Creep_Info
    Dim thecreep As Creep = mCreeps.Item(thecreepname)


    If Not thecreep Is Nothing Then
      Dim outcreep As New Creep_Info(thecreep.IDitem, _
                            thecreep.Name, _
                            theparent, _
                            thecreep.UnitType, _
                            thecreep.UnitImage, _
                            thecreep.WebPageLink, _
                            thecreep.Duration, _
                            thecreep.Level, _
                            thecreep.Health, _
                            thecreep.HealthIncrement, _
                            thecreep.HealthRegen, _
                            thecreep.Mana, _
                            thecreep.ManaRegen, _
                            thecreep.Damage, _
                            thecreep.DamageIncrement, _
                            thecreep.MagicResistance, _
                            thecreep.Armor, _
                            thecreep.ArmorType, _
                            thecreep.MoveSpeed, _
                            thecreep.CollisionSize, _
                            thecreep.SightRange, _
                            thecreep.AttackType, _
                            thecreep.AttackSubType, _
                            thecreep.AttackRange, _
                            thecreep.AttackDuration, _
                            thecreep.CastDuration, _
                            thecreep.MissileSpeed, _
                            thecreep.BaseAttackSpeed, _
                            thecreep.Bounty, _
                            thecreep.XP, _
                            thecreep.AbilityNames, _
                            creeplevel, _
                            thelifetime,
                            thecreepexistsatlvls, _
                            thescepterexistsatlvls, _
                            thegame)

      outcreep.SetTargets(theenemytarget, thefriendtarget, thefriendbias)

      If Not mCreep_Infos.ContainsKey(outcreep.ID.GuidID) Then
        mCreep_Infos.Add(outcreep.ID.GuidID, outcreep)
      End If


      Return outcreep
    Else
      Return Nothing
    End If

  End Function


  Private Function GetNewPetInfo(petname As ePetName, petlevel As Integer, _
                                parent As iGameEntity, _
                                lifetime As Lifetime, _
                                petexistsatlvls As ValueWrapper, _
                                scepterexistsatlvls As ValueWrapper, _
                                nemytarget As iDisplayUnit, _
                                friendtarget As iDisplayUnit, _
                                friendbias As Boolean, _
                                thegame As dGame) As Pet_Info
    Dim pet As Pet = mPets.Item(petname)


    If Not pet Is Nothing Then
      Dim outpet As New Pet_Info(pet.IDitem, _
                            pet.Name, _
                            parent, _
                            pet.UnitType, _
                            pet.UnitImage, _
                            pet.WebPageLink, _
                            pet.Duration, _
                            pet.Level, _
                            pet.Health, _
                            pet.HealthIncrement, _
                            pet.HealthRegen, _
                            pet.Mana, _
                            pet.ManaRegen, _
                            pet.Damage, _
                            pet.DamageIncrement, _
                            pet.MagicResistance, _
                            pet.Armor, _
                            pet.ArmorType, _
                            pet.MoveSpeed, _
                            pet.CollisionSize, _
                            pet.SightRange, _
                            pet.AttackType, _
                            pet.AttackSubType, _
                            pet.AttackRange, _
                            pet.AttackDuration, _
                            pet.CastDuration, _
                            pet.MissileSpeed, _
                            pet.BaseAttackSpeed, _
                            pet.Bounty, _
                            pet.XP, _
                            pet.AbilityNames, _
                            petlevel, _
                            lifetime,
                            petexistsatlvls, _
                            scepterexistsatlvls, _
                            thegame)

      outpet.SetTargets(nemytarget, friendtarget, friendbias)

      If Not mCreep_Infos.ContainsKey(outpet.ID.GuidID) Then
        mPet_Infos.Add(outpet.ID.GuidID, outpet)
      End If


      Return outpet
    Else
      Return Nothing
    End If

  End Function

  Public Function GetCreepInfo(theid As dvID) As Creep_Info

    If mCreep_Infos.ContainsKey(theid.GuidID) Then
      Return mCreep_Infos.Item(theid.GuidID)
    Else
      Return Nothing
    End If

  End Function

  Public Function GetCreepImageURL(thecreep As eCreepName) As String
    If mCreeps.ContainsKey(thecreep) Then
      Return mCreeps.Item(thecreep).UnitImage
    End If
    Return ""
  End Function

  Public Function GetPetImageUrl(thepet As ePetName) As String
    If mPets.ContainsKey(thepet) Then
      Return mPets.Item(thepet).UnitImage
    End If
    Return ""
  End Function
  Public Function ContainsCreepInfo(theid As dvID) As Boolean
    If mCreep_Infos.ContainsKey(theid.GuidID) Then Return True
    Return False
  End Function

  'Public Function GetCreepsSpawnedByCreep(ability As iAbility, game As dGame) As List(Of Creep_Info)
  '  Dim entarget = ability.mTeamEnemyTarget
  '  Dim frtarget = ability.mTeamFriendlyTarget
  '  Dim frbias = ability.mTargetFriendBias


  '  Select Case ability.AbilityName
  '    Case eAbilityName.abDark_Troll_Summoner_Raise_Dead
  '      Dim creeplist As New List(Of Creep_Info)

  '      creeplist.Add(GetNewCreepInfo(ePetName.untSkeleton_Warrior, 0, ability.ParentGameEntity, _
  '                                                      ability.Lifetime, Nothing, Nothing, _
  '                                                      entarget, frtarget, frbias, _
  '                                                      game))

  '      creeplist.Add(GetNewCreepInfo(ePetName.untSkeleton_Warrior, 0, ability.ParentGameEntity, _
  '                                                      ability.Lifetime, Nothing, Nothing, _
  '                                                      entarget, frtarget, frbias, _
  '                                                      game))

  '      Return creeplist
  '  End Select
  'End Function
  Public Function GetPetInfosForUnitUpgrade(upgrade As IUnitUpgrade, game As dGame) As List(Of Pet_Info)
    'Dim targlist = Helpers.GetTargetsandIdforObject(theparent)
    Dim entarget = upgrade.mTeamEnemyTarget
    Dim frtarget = upgrade.mTeamFriendlyTarget
    Dim frbias = upgrade.mTargetFriendBias

    Dim petlist As New List(Of Pet_Info)
    Select Case upgrade.EntityName
      Case eEntity.abCall_Of_The_Wild

        petlist.Add(GetNewPetInfo(ePetName.untBoar, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))
        petlist.Add(GetNewPetInfo(ePetName.untHawk, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        Return petlist


      Case eEntity.abSummon_Wolves

        petlist.Add(GetNewPetInfo(ePetName.untLycan_Wolf, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untLycan_Wolf, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        Return petlist


      Case eEntity.abTombstone

        petlist.Add(GetNewPetInfo(ePetName.untTombstone, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        Return petlist


      Case eEntity.abSpawn_Spiderlings

        petlist.Add(GetNewPetInfo(ePetName.untSpiderling, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, New ValueWrapper(1, 1, 1, 1), Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untSpiderling, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, New ValueWrapper(0, 1, 1, 1), Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untSpiderling, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, New ValueWrapper(0, 0, 1, 1), Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untSpiderling, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, New ValueWrapper(0, 0, 0, 1), Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        Return petlist


      Case eEntity.abSpiderling_Spawn_Spiderite

        petlist.Add(GetNewPetInfo(ePetName.untSpiderite, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        Return petlist


      Case eEntity.abNatures_Call

        petlist.Add(GetNewPetInfo(ePetName.untTreant, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, New ValueWrapper(1, 1, 1, 1), Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untTreant, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, New ValueWrapper(1, 1, 1, 1), Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untTreant, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, New ValueWrapper(0, 1, 1, 1), Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untTreant, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, New ValueWrapper(0, 0, 1, 1), Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untTreant, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, New ValueWrapper(0, 0, 0, 1), Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        Return petlist


      Case eEntity.abDemonic_Conversion

        petlist.Add(GetNewPetInfo(ePetName.untEidolon, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untEidolon, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untEidolon, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        Return petlist


      Case eEntity.abForge_Spirit

        petlist.Add(GetNewPetInfo(ePetName.untForged_Spirit, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, New ValueWrapper(1, 1), Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untForged_Spirit, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, New ValueWrapper(0, 1), Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        Return petlist





      Case eEntity.abPrimal_Split

        petlist.Add(GetNewPetInfo(ePetName.untFire_Brewmaster, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untEarth_Brewmaster, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untStorm_Brewmaster, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        Return petlist


      Case eEntity.abChaotic_Offering

        petlist.Add(GetNewPetInfo(ePetName.untGolem_Warlock, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, New ValueWrapper(1, 1, 1), New ValueWrapper(1, 1, 1), _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untGolem_Warlock, 0, upgrade.ParentGameEntity, upgrade.Lifetime, _
                                                        New ValueWrapper(0, 0, 0), New ValueWrapper(1, 1, 1), _
                                                        entarget, frtarget, frbias, _
                                                        game))

        Return petlist


      Case eEntity.abSummon_Spirit_Bear

        petlist.Add(GetNewPetInfo(ePetName.untSpirit_Bear, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        Return petlist


      Case eEntity.abSummon_Familiars

        petlist.Add(GetNewPetInfo(ePetName.untFamiliar, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untFamiliar, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        Return petlist


      Case eEntity.abPlague_Ward

        petlist.Add(GetNewPetInfo(ePetName.untPlague_Ward, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        Return petlist


      Case eEntity.abMass_Serpent_Ward

        petlist.Add(GetNewPetInfo(ePetName.untSerpent_Ward, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untSerpent_Ward, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untSerpent_Ward, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untSerpent_Ward, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untSerpent_Ward, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untSerpent_Ward, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untSerpent_Ward, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untSerpent_Ward, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untSerpent_Ward, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untSerpent_Ward, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        Return petlist


      Case eEntity.abDeath_Ward

        petlist.Add(GetNewPetInfo(ePetName.untDeath_Ward, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        Return petlist


      Case eEntity.abHealing_Ward

        petlist.Add(GetNewPetInfo(ePetName.untHealing_Ward, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        Return petlist


      Case eEntity.abFrozen_Sigil

        petlist.Add(GetNewPetInfo(ePetName.untFrozen_Sigil, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        Return petlist


      Case eEntity.abTornado

        petlist.Add(GetNewPetInfo(ePetName.untTornado, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        Return petlist


      Case eEntity.abPsionic_Trap

        petlist.Add(GetNewPetInfo(ePetName.untPsionic_Trap, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        Return petlist


      Case eEntity.abLand_Mines

        petlist.Add(GetNewPetInfo(ePetName.untLand_Mine, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        Return petlist


      Case eEntity.abStasis_Trap

        petlist.Add(GetNewPetInfo(ePetName.untStasis_Trap, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        Return petlist


      Case eEntity.abRemote_Mines

        petlist.Add(GetNewPetInfo(ePetName.untRemote_Mine, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        Return petlist


      Case eEntity.abNether_Ward

        petlist.Add(GetNewPetInfo(ePetName.untNether_Ward, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        Return petlist


      Case eEntity.abPower_Cogs

        petlist.Add(GetNewPetInfo(ePetName.untPower_Cog, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untPower_Cog, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untPower_Cog, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untPower_Cog, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untPower_Cog, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untPower_Cog, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untPower_Cog, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untPower_Cog, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        Return petlist


      Case eEntity.abTombstone

        petlist.Add(GetNewPetInfo(ePetName.untTombstone, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        'spawn interval 3, duration 30, 5 heroes = 50 zombies
        Dim ablvl1 As New ValueWrapper(1, 1, 1, 1)
        Dim ablvl2 As New ValueWrapper(0, 1, 1, 1)
        Dim ablvl3 As New ValueWrapper(0, 0, 1, 1)
        Dim ablvl4 As New ValueWrapper(0, 0, 0, 1)

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl1, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl1, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl1, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl1, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl1, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl1, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl1, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl1, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl1, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl1, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))




        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl1, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl1, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl1, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl1, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl1, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl1, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl1, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl1, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl1, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl1, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))




        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl1, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl1, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl1, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl1, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl1, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl2, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl2, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl2, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl2, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl2, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))




        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl3, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl3, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl3, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl3, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl3, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl3, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl3, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl3, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl3, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl3, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))




        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl4, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl4, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl4, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl4, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl4, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl4, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl4, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl4, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl4, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untUndying_Zombie, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, ablvl4, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))


        Return petlist


      Case eEntity.abSupernova

        petlist.Add(GetNewPetInfo(ePetName.untPhoenix_Sun, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        Return petlist


      Case eEntity.abHoming_Missile

        petlist.Add(GetNewPetInfo(ePetName.untHoming_Missile, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        Return petlist


      Case eEntity.abAstral_Spirit

        petlist.Add(GetNewPetInfo(ePetName.untAstral_Spirit, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        Return petlist


      Case eEntity.abSpin_Web

        Dim lvl1ab As New ValueWrapper(1, 1, 1, 1)
        Dim lvl2ab As New ValueWrapper(0, 1, 1, 1)
        Dim lvl3ab As New ValueWrapper(0, 0, 1, 1)
        Dim lvl4ab As New ValueWrapper(0, 0, 0, 1)
        petlist.Add(GetNewPetInfo(ePetName.untSpin_Web, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, lvl1ab, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untSpin_Web, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, lvl1ab, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untSpin_Web, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, lvl2ab, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untSpin_Web, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, lvl2ab, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untSpin_Web, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, lvl3ab, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untSpin_Web, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, lvl3ab, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untSpin_Web, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, lvl4ab, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        petlist.Add(GetNewPetInfo(ePetName.untSpin_Web, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, lvl4ab, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        Return petlist


      Case eEntity.itmOBSERVER_WARD
        Dim thecreep = GetNewPetInfo(ePetName.untObserver_Ward, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game)
        petlist.Add(thecreep)

        Return petlist


      Case eEntity.itmSENTRY_WARD

        petlist.Add(GetNewPetInfo(ePetName.untSentry_Ward, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        Return petlist
      Case Else
        Return Nothing

    End Select
    Return Nothing

  End Function

  Public Function GetCreepInfosForUnitUpgrade(upgrade As IUnitUpgrade, game As dGame) As List(Of Creep_Info)


    Dim entarget = upgrade.mTeamEnemyTarget
    Dim frtarget = upgrade.mTeamFriendlyTarget
    Dim frbias = upgrade.mTargetFriendBias

    Dim creeplist As New List(Of Creep_Info)
    Select Case upgrade.EntityName
      Case eEntity.itmNECRONOMICON_1, eEntity.itmNECRONOMICON_2, eEntity.itmRECIPE_NECRONOMICON_3


        creeplist.Add(GetNewCreepInfo(eCreepName.untNecro_Warrior, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        creeplist.Add(GetNewCreepInfo(eCreepName.untNecro_Archer, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        Return creeplist


      Case eEntity.abDark_Troll_Summoner_Raise_Dead

        creeplist.Add(GetNewCreepInfo(eCreepName.untSkeleton_Warrior, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        creeplist.Add(GetNewCreepInfo(eCreepName.untSkeleton_Warrior, 0, upgrade.ParentGameEntity, _
                                                        upgrade.Lifetime, Nothing, Nothing, _
                                                        entarget, frtarget, frbias, _
                                                        game))

        Return creeplist

      Case Else
        Return Nothing

    End Select
    Return Nothing
  End Function


  Public Sub load()

    'creeps
    Dim CBundles = New CreepBundles
    mCreeps = New Dictionary(Of eCreepName, Creep)
    mCreep_Infos = New Dictionary(Of Guid, Creep_Info)
    For Each item In CreepEnumitems
      Dim outtype As eCreepName = DirectCast([Enum].Parse(GetType(eCreepName), item, True), eCreepName)

      If Not outtype = eCreepName.None Then

        Dim thebundle As CreepBundle = CBundles.Item(outtype)
        Dim thecreep As New Creep(thebundle)
        mCreeps.Add(thecreep.Name, thecreep)

      End If
    Next

    'pets
    Dim pBundles = New PetBundles
    mPets = New Dictionary(Of ePetName, Pet)
    mCreep_Infos = New Dictionary(Of Guid, Creep_Info)
    For Each item In PetEnumItems
      Dim outtype As ePetName = DirectCast([Enum].Parse(GetType(ePetName), item, True), ePetName)

      If Not outtype = ePetName.None Then
        Dim thebundle As PetBundle = pBundles.Item(outtype)
        Dim thepet As New Pet(thebundle)
        mPets.Add(thepet.Name, thepet)

      End If
    Next
  End Sub

End Class
