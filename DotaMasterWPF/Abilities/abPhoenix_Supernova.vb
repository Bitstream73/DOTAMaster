Public Class abSupernova
Inherits AbilityBase
  Public dps As ValueWrapper
  Public stunduration As ValueWrapper
  Public attstodestroy As ValueWrapper

  Public healthrestored As ValueWrapper
  Public herohealthrestord As ValueWrapper
  Public scepterherohealthrestored As New List(Of Double?)

  Public debuffsremoved As ValueWrapper
  Public herodebuffsremoved As ValueWrapper
  Public scepterherodebuffsremoved As New List(Of Double?)

  Public cooldownsreset As ValueWrapper
  Public herocooldownsreset As ValueWrapper
  Public scepterherocooldownsreset As New List(Of Double?)

  Public novaduration As ValueWrapper
  Public heronovaduration As ValueWrapper
  Public scepterheronovaduration As New List(Of Double?)

  Public invulduration As ValueWrapper

  Public heroinvulduration As ValueWrapper
  Public scepterheroinvulduration As New List(Of Double?)
Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True 'FixFixFix
    PiercesSpellImmunity = True

    Notes = "" 'FixFixFix"

    mDisplayName = "Supernova"
    mName = eAbilityName.abSupernova
    Me.EntityName = eEntity.abSupernova

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untPhoenix

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/phoenix_supernova_hp2.png"

    Description = "The Phoenix willingly ends its current life for the chance to be reborn. Transforms into a burning sun that scorches enemies in a huge area. The sun can be destroyed by attacks from enemy Heroes. After 6 seconds the sun explodes, stunning all nearby enemies while restoring Phoenix to full health and mana with refreshed abilities."

    ManaCost = New ValueWrapper(200, 200, 200)

    Cooldown = New ValueWrapper(110, 110, 110)
    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)
    Affects.Add(eUnit.untAlliedHero)
    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    Radius = New ValueWrapper(1000, 1000, 1000)

    dps = New ValueWrapper(60, 80, 100)

    stunduration = New ValueWrapper(1.5, 2, 2.5)

    attstodestroy = New ValueWrapper(5, 8, 11)

    invulduration = New ValueWrapper(6, 6, 6)




    healthrestored = New ValueWrapper(1, 1, 1)

    herohealthrestord = New ValueWrapper(-1, -1, -1)
    scepterherohealthrestored.Add(1)
    scepterherohealthrestored.Add(1)
    scepterherohealthrestored.Add(1)
    herohealthrestord.LoadScepterValues(scepterherohealthrestored)


    debuffsremoved = New ValueWrapper(1, 1, 1)

    herodebuffsremoved = New ValueWrapper(-1, -1, -1)
    scepterherodebuffsremoved.Add(1)
    scepterherodebuffsremoved.Add(1)
    scepterherodebuffsremoved.Add(1)
    herodebuffsremoved.LoadScepterValues(scepterherodebuffsremoved)


    cooldownsreset = New ValueWrapper(1, 1, 1, 1)

    herocooldownsreset = New ValueWrapper(-1, -1, -1, -1)
    scepterherocooldownsreset.Add(1)
    scepterherocooldownsreset.Add(1)
    scepterherocooldownsreset.Add(1)
    herocooldownsreset.LoadScepterValues(scepterherocooldownsreset)


    novaduration = New ValueWrapper(6, 6, 6)

    heronovaduration = New ValueWrapper(-1, -1, -1)
    scepterheronovaduration.Add(6)
    scepterheronovaduration.Add(6)
    scepterheronovaduration.Add(6)
    heronovaduration.LoadScepterValues(scepterheronovaduration)

 
    heroinvulduration = New ValueWrapper(-1, -1, -1)
    scepterheroinvulduration.Add(novaduration.Value(0))
    scepterheroinvulduration.Add(novaduration.Value(1))
    scepterheroinvulduration.Add(novaduration.Value(2))
    heroinvulduration.LoadScepterValues(scepterheroinvulduration)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Active)
    Dim unittargethero = Helpers.GetUnitTargetAlliedHeroInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Active)

    'invulnerability Nova duration
    Dim invulvalself As New modValue(invulduration, eModifierType.Invulnerability, occurencetime, aghstime)
    invulvalself.mValueDuration = invulduration

    Dim invulselfmod As New Modifier(invulvalself, notargetself)
    outmods.Add(invulselfmod)


    Dim invulhero As New modValue(heroinvulduration, eModifierType.Invulnerability, occurencetime, aghstime)
    invulhero.mValueDuration = heroinvulduration

    Dim invulheromod As New Modifier(invulhero, unittargethero)
    outmods.Add(invulheromod)


    'health restored
    Dim healthself As New modValue(healthrestored, eModifierType.HealthFullyRestored, occurencetime, aghstime)

    Dim healthselfmod As New Modifier(healthself, notargetself)
    outmods.Add(healthselfmod)


    Dim healthhero As New modValue(herohealthrestord, eModifierType.HealthFullyRestored, occurencetime, aghstime)

    Dim healthheromod As New Modifier(healthhero, unittargethero)
    outmods.Add(healthheromod)


    'debuffs removed
    Dim debuffself As New modValue(debuffsremoved, eModifierType.RemoveDebuffs, occurencetime, aghstime)

    Dim debuffselfmod As New Modifier(debuffself, notargetself)
    outmods.Add(debuffselfmod)

    Dim debuffhero As New modValue(herodebuffsremoved, eModifierType.RemoveDebuffs, occurencetime, aghstime)

    Dim debuffheromod As New Modifier(debuffhero, unittargethero)
    outmods.Add(debuffheromod)


    'cooldowns reset
    Dim coolselfval As New modValue(cooldownsreset, eModifierType.Reset_Cooldowns, occurencetime, aghstime)

    Dim coolselfmod As New Modifier(coolselfval, notargetself)
    outmods.Add(coolselfmod)


    Dim coolheroval As New modValue(herocooldownsreset, eModifierType.Reset_Cooldowns, occurencetime, aghstime)

    Dim coolheromod As New Modifier(coolheroval, unittargethero)
    outmods.Add(coolheromod)




    Return outmods
  End Function

  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                              theowner As iDisplayUnit, _
                                              thetarget As iDisplayUnit, _
                                              ftarget As iDisplayUnit, _
                                              isfriendbias As Boolean, _
                                              occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return New ModifierList
  End Function

End Class
