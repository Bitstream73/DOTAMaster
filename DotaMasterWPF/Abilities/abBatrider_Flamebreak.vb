Public Class abFlamebreak
  Inherits AbilityBase
  Public stunduration As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "The targets will be knocked back a varying distance, based on the distance to the center of the explosion (10-400 units)." '"
    mDisplayName = "Flamebreak"
    mName = eAbilityName.abFlamebreak

    Me.EntityName = eEntity.abFlamebreak

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untBatrider

    mAbilityPosition = 2

    mIsUltimate = False '
    mIsAghsUpgradable = False '

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/batrider_flamebreak_hp2.png"

    Description = "Hurls an explosive cocktail that explodes when it reaches the target location, knocking back and dealing damage to enemies in the area."

    ManaCost = New ValueWrapper(140, 140, 140, 140)

    Cooldown = New ValueWrapper(14, 14, 14, 14)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(75, 150, 225, 300)

    Radius = New ValueWrapper(375, 375, 375, 375)

    stunduration = New ValueWrapper(0.5, 0.5, 0.5, 0.5)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim pointtargetenemies = Helpers.GetPointTargetEnemyUnitsInfo(theability_InfoID, _
                                                                  thecaster, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Active)



    'damage
    Dim valdam As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim moddam As New Modifier(valdam, pointtargetenemies)
    outmods.Add(moddam)


    'stun
    Dim valstun As New modValue(stunduration, eModifierType.Stun, occurencetime, aghstime)
    valstun.mValueDuration = stunduration

    Dim modstun As New Modifier(valstun, pointtargetenemies)
    outmods.Add(modstun)

    'knockback
    Dim knockval As New modValue(1, eModifierType.Knockback, occurencetime)

    Dim knockmod As New Modifier(knockval, pointtargetenemies)
    outmods.Add(knockmod)

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
