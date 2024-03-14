Public Class abDemonic_Conversion
Inherits AbilityBase
  Public attackstomultiply As ValueWrapper
  Public eidolonHP As ValueWrapper

  Public eidolondamagehigh As ValueWrapper
  Public eidolondamagelow As ValueWrapper

  Public eidolonduration As ValueWrapper
  Public eidoloncountfromcreepconversion As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True 'FixFixFix
    PiercesSpellImmunity = False

    Notes = "" 'FixFixFix"

    mDisplayName = "Demonic Conversion"
    mName = eAbilityName.abDemonic_Conversion
    Me.EntityName = eEntity.abDemonic_Conversion

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untEnigma

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/enigma_demonic_conversion_hp2.png"

    Description = "Transforms a creep into three fragments of Enigma himself. These eidolons are all under Enigma's control, and repeated successful attacks cause them to multiply. When this happens, the eidolons have their health restored."

    ManaCost = New ValueWrapper(170, 170, 170, 170)

    Cooldown = New ValueWrapper(35, 35, 35, 35)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untCreep)

    attackstomultiply = New ValueWrapper(6, 6, 6, 6)

    eidolonHP = New ValueWrapper(180, 200, 220, 240)

    eidolondamagehigh = New ValueWrapper(20, 28, 38, 47)
    eidolondamagelow = New ValueWrapper(16, 24, 34, 43)

    Duration = New ValueWrapper(35, 35, 35, 35)

    eidolonduration = Duration

    eidoloncountfromcreepconversion = New ValueWrapper(3, 3, 3, 3)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemycreep = Helpers.GetUnitTargetEnemyCreepInfo(theability_InfoID, _
                                                                   thecaster, _
                                                                   thetarget, _
                                                                   "", eModifierCategory.Active)

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                                   thecaster, _
                                                                   thetarget, _
                                                                   "", eModifierCategory.Active)


    'Dim eidolon As New HeroPet_Info()
    'eidolon.hitpoints = eidolonHP

    'eidolon.HealthRegen = New ValueWrapper(0.25, 0.25, 0.25, 0.25)

    'eidolon.DamageHigh = eidolondamagehigh
    'eidolon.DamageLow = eidolondamagelow

    'eidolon.armor = New ValueWrapper(2, 3, 4, 5)

    'eidolon.movementspeed = New ValueWrapper(250, 250, 260, 260)

    'eidolon.SightRange.Add(New ValueWrapper(1200, 1200, 1200, 1200))
    'eidolon.SightRange.Add(New ValueWrapper(800, 800, 800, 800))

    'eidolon.BaseAttackSpeed = New ValueWrapper(1.5, 1.5, 1.5, 1.5)

    'eidolon.bounty = New ValueWrapper(36, 36, 36, 36)

    'eidolon.xpvalue = New ValueWrapper(12, 12, 12, 12)

    'eidolon.magicresistance = New ValueWrapper(0.5, 0.5, 0.5, 0.5)

    'eidolon.Duration = eidolonduration


    Dim edval As New modValue(eidoloncountfromcreepconversion, eModifierType.petEidolon, occurencetime, aghstime)
    'edval.mPet = eidolon
    edval.mValueDuration = Duration

    Dim edmod As New Modifier(edval, notargetself)
    outmods.Add(edmod)


    'creep kill
    Dim creepval As New modValue(1, eModifierType.ReplacedByPets, occurencetime)

    Dim creepmod As New Modifier(creepval, unittargetenemycreep)
    outmods.Add(creepmod)



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
