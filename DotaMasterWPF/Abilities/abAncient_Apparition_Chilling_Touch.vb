Public Class abChilling_Touch
Inherits AbilityBase
  Public maxattacks As ValueWrapper
  Public attackspeed As ValueWrapper
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

    mName = eAbilityName.abChilling_Touch
    Me.EntityName = eEntity.abChilling_Touch

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untAncient_Apparition
    mDisplayName = "Chilling Touch"
    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/ancient_apparition_chilling_touch_hp2.png"

    Description = "A frigid gust enchants allied heroes, granting them bonus magical damage for a given number of physical attacks, while slowing their attack speed slightly. Ancient Apparition always receives the buff. Lasts 30 seconds."

    ManaCost = New ValueWrapper(110, 120, 130, 140)


    Cooldown = New ValueWrapper(50, 42, 34, 26)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical
    Radius = New ValueWrapper(525, 525, 525, 525)
    maxattacks = New ValueWrapper(3, 4, 5, 6)
    Damage = New ValueWrapper(50, 60, 70, 80)
    attackspeed = New ValueWrapper(20, 20, 20, 20)
    Duration = New ValueWrapper(30, 30, 30, 30)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim pointtargetallies = Helpers.GetPointTargetAuraAlliedHeroesInfo(theability_InfoID, _
                                                                       thecaster, _
                                                                       thetarget, _
                                                                       "", eModifierCategory.Active)

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Active)


    'magic damage added to phys attacks
    Dim magaddval = New modValue(Damage, eModifierType.DamageMagicalAddedToPhysicalAttacks, occurencetime, aghstime)
    magaddval.Charges = maxattacks
    magaddval.mValueDuration = Duration

    Dim alliesmagmod As New Modifier(magaddval, pointtargetallies)
    outmods.Add(alliesmagmod)

    Dim selfmagmod As New Modifier(magaddval, notargetself)
    outmods.Add(selfmagmod)


    'attack speed debuff
    Dim attspeedval As New modValue(attackspeed, eModifierType.AttackspeedSubtracted, occurencetime, aghstime)
    attspeedval.Charges = maxattacks
    attspeedval.mValueDuration = Duration

    Dim attmod As New Modifier(attspeedval, pointtargetallies)
    outmods.Add(attmod)

    Dim attmodself As New Modifier(attspeedval, notargetself)
    outmods.Add(attmodself)



    Return outmods
  End Function
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                 caster As iDisplayUnit, _
                                                 target As iDisplayUnit, _
                                                 ftarget As iDisplayUnit, _
                                                 isfriendbias As Boolean, _
                                                 occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return New ModifierList
  End Function

End Class
