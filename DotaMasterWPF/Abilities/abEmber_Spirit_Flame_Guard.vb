Public Class abFlame_Guard
Inherits AbilityBase
  Public magicabsorb As ValueWrapper
  Public damagepersec As ValueWrapper
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

    mDisplayName = "Flame Guard"
    mName = eAbilityName.abFlame_Guard

    Me.EntityName = eEntity.abFlame_Guard

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untEmber_Spirit

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/ember_spirit_flame_guard_hp2.png"

    Description = "Ember Spirit surrounds himself with a ring of fire that consumes incoming magic damage, leaving him unharmed. Flame Guard deals damage per second in an area around Ember Spirit while Flame Guard is active. If the shield is broken, the damage is also lost."


    ManaCost = New ValueWrapper(80, 90, 100, 110)


    Cooldown = New ValueWrapper(35, 35, 35, 35)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    magicabsorb = New ValueWrapper(50, 200, 350, 500)

    Duration = New ValueWrapper(8, 12, 16, 20)

    Radius = New ValueWrapper(400, 400, 400, 400)

    damagepersec = New ValueWrapper(30, 40, 50, 60)
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

    Dim magval As New modValue(magicabsorb, eModifierType.DamageMagicalAbsorbed, occurencetime, aghstime)
    magval.mValueDuration = Duration

    Dim magmod As New Modifier(magval, notargetself)
    outmods.Add(magmod)


    Dim notargetenemies = Helpers.GetNoTargetEnemyUnitsInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Active)

    Dim damval As New modValue(damagepersec, eModifierType.DamageMagicalOverTimeInflicted, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)
    damval.mRadius = Radius

    Dim dammod As New Modifier(damval, notargetenemies)
    outmods.Add(dammod)




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
