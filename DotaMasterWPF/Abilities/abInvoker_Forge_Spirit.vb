Public Class abForge_Spirit
Inherits AbilityBase
  Public QuasExortSpiritCount As ValueWrapper
  Public ExortSpiritDamage As ValueWrapper
  Public QuasSpiritAttackRange As ValueWrapper
  Public ExortSpiritHealth As ValueWrapper
  Public QuasSpiritMana As ValueWrapper
  Public ExortSpiritArmor As ValueWrapper
  Public QuasSpiritDuration As ValueWrapper

Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True 'FixFixFix
    'mAbilityLevelCount = 4 'FixFixFix

    Notes = "" 'FixFixFix"

    mDisplayName = "Forge Spirit"
    mName = eAbilityName.abForge_Spirit
    Me.EntityName = eEntity.abForge_Spirit

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untInvoker

    mAbilityPosition = -1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/invoker_forge_spirit_hp2.png"

    Description = "Invoker forges a spirit embodying the strength of fire and fortitude of ice. Damage, health, and armor are based on the level of Exort while attack range, mana, and duration are based on the level of Quas. The elemental's scorching attack is capable of melting the armor of enemy heroes. If both Quas and Exort are level 4 or higher, Invoker will create two spirits instead of one."

    ManaCost = New ValueWrapper(75, 75, 75, 75, 75, 75, 75)

    Cooldown = New ValueWrapper(30, 30, 30, 30, 30, 30, 30)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    QuasExortSpiritCount = New ValueWrapper(1, 1, 1, 2, 2, 2, 2)
    ExortSpiritDamage = New ValueWrapper(29, 38, 47, 56, 65, 74, 83)
    QuasSpiritAttackRange = New ValueWrapper(300, 365, 430, 495, 560, 625, 690)
    ExortSpiritHealth = New ValueWrapper(300, 400, 500, 600, 700, 800, 900)
    QuasSpiritMana = New ValueWrapper(100, 150, 200, 250, 300, 350, 400)
    ExortSpiritArmor = New ValueWrapper(0, 1, 2, 3, 4, 5, 6)
    QuasSpiritDuration = New ValueWrapper(20, 30, 40, 50, 60, 70, 80)
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

    'Dim spirit As New HeroPet_Info()
    'spirit.Duration = QuasSpiritDuration
    'spirit.hitpoints = ExortSpiritHealth
    'spirit.HealthRegen = New ValueWrapper(0.25, 0.25, 0.25, 0.25, 0.25, 0.25, 0.25)
    'spirit.mana = QuasSpiritMana
    'spirit.DamageHigh = ExortSpiritDamage
    'spirit.DamageLow = ExortSpiritDamage
    'spirit.armor = ExortSpiritArmor
    'spirit.movementspeed = New ValueWrapper(320, 320, 320, 320, 320, 320, 320)
    'spirit.SightRange.Add(New ValueWrapper(1200, 1200, 1200, 1200, 1200, 1200, 1200))
    'spirit.SightRange.Add(New ValueWrapper(800, 800, 800, 800, 800, 800, 800))
    'spirit.BaseAttackSpeed = New ValueWrapper(1.5, 1.5, 1.5, 1.5, 1.5, 1.5, 1.5)
    'spirit.bounty = New ValueWrapper(46, 46, 46, 46, 46, 46, 46)
    'spirit.xpvalue = New ValueWrapper(31, 31, 31, 31, 31, 31, 31)


    Dim spiritval As New modValue(QuasExortSpiritCount, eModifierType.petForged_Spirit, occurencetime, aghstime)
    'spiritval.mPet = spirit
    spiritval.mValueDuration = QuasSpiritDuration

    Dim spiritmod As New Modifier(spiritval, notargetself)
    outmods.Add(spiritmod)

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
