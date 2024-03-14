Public Class abCrystal_Nova
Inherits AbilityBase
  Dim movespeedslow As ValueWrapper ' = 
  Dim attackspeedslow As ValueWrapper '=
  Public Sub New()
    BlockedByMagicImmune = True
    RemovedByMagicImmune = True
    CanBePurged = True
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False
    PiercesSpellImmunity = False
    mDisplayName = "Crystal Nova"
    Notes = "Provides vision within the target area."
    mName = eAbilityName.abCrystal_Nova

    Me.EntityName = eEntity.abCrystal_Nova


    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untCrystal_Maiden

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False 'Check This
    'mHasAghs = False

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/crystal_maiden_crystal_nova_hp2.png"
    WebpageLink = ""
    Description = "A burst of damaging frost slows enemy movement and attack rate in the targeted area."

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    ManaCost = New ValueWrapper(100, 120, 140, 160)

    Cooldown = New ValueWrapper(15, 15, 15, 15)



    Damage = New ValueWrapper(100, 150, 200, 250)


    Duration = New ValueWrapper(3.5, 4, 4.5, 5)


    Radius = New ValueWrapper(400, 400, 400, 400)

    movespeedslow = New ValueWrapper(0.3, 0.3, 0.3, 0.3)

    attackspeedslow = New ValueWrapper(30, 30, 30, 30)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetenemiesinfo = Helpers.GetPointTargetEnemyUnitsInfo(theability_InfoID, _
                                                                      thecaster, _
                                                                      thetarget, _
                                                                      "", eModifierCategory.Active)

    Dim damval As New modValue(Me.Damage, eModifierType.DamageMagicalAdded, occurencetime, aghstime)

    Dim damage As New Modifier(damval, pointtargetenemiesinfo)
    outmods.Add(damage)


    Dim moveval As New modValue(movespeedslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)

    Dim moveslow As New Modifier(moveval, pointtargetenemiesinfo)
    outmods.Add(moveslow)


    Dim attval As New modValue(attackspeedslow, eModifierType.AttackSpeedPercentSubtracted, occurencetime, aghstime)

    Dim attslow As New Modifier(attval, pointtargetenemiesinfo)
    outmods.Add(attslow)

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
