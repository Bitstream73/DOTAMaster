Public Class abConcussive_Shot
Inherits AbilityBase
  Public slowduration As ValueWrapper
  Public slowpercentage As ValueWrapper

Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = True '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Does not work when no heroes are in range or heroes are in fog.|Will always target the hero closest to Skywrath Mage.|Damages creeps around the impact area.|Projectile gives 400 flying vision around itself while traveling.|Can be disjointed by blinking, going invisible, etc.|Becoming magic immune will not remove the slow debuff. It cannot be purged.|Upon impact, it reveals the target area for 3.34 seconds.|It will not target illusions." '"

    mDisplayName = "Concussive Shot"
    mName = eAbilityName.abConcussive_Shot
    Me.EntityName = eEntity.abConcussive_Shot

    'mFriendlyName = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSkywrath_Mage

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False '

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/skywrath_mage_concussive_shot_hp2.png"

    Description = "Skywrath Mage sets off a long range shot that hits the closest hero within a long range. Upon impact, it deals damage and slows in an area of effect."

    ManaCost = New ValueWrapper(110, 110, 110, 110)

    Cooldown = New ValueWrapper(20, 18, 16, 14)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyHero)

    DamageType = eDamageType.Magical

    Range = New ValueWrapper(1600, 1600, 1600, 1600)

    Damage = New ValueWrapper(60, 120, 180, 240)

    slowduration = New ValueWrapper(4, 4, 4, 4)

    slowpercentage = New ValueWrapper(0.3, 0.35, 0.4, 0.45)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetnearestenemy = Helpers.GetUnitTargetEnemyHeroInfo(theability_InfoID, _
                                                                           thecaster, _
                                                                           thetarget, _
                                                                           "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim thedamage As New Modifier(damval, unittargetnearestenemy)
    outmods.Add(thedamage)


    Dim slowval As New modValue(slowpercentage, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    slowval.mValueDuration = slowduration

    Dim theslow As New Modifier(slowval, unittargetnearestenemy)
    outmods.Add(theslow)



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
