Public Class abBall_Lightning
Inherits AbilityBase

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

    mDisplayName = "Ball Lightning"
    mName = eAbilityName.abBall_Lightning
    Me.EntityName = eEntity.abBall_Lightning

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untStorm_Spirit

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/storm_spirit_ball_lightning_hp2.png"

    Description = "Storm Spirit becomes volatile electricity, charging across the battlefield until he depletes his mana or reaches his target. The mana activation cost is 15+7% of his total mana pool, and the cost per 100 units traveled is 10+1% of his total mana pool. Damage is expressed in damage per 100 units traveled."

    ManaCost = New ValueWrapper(15, 15, 15, 15)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(8, 12, 16)

    Radius = New ValueWrapper(275, 200, 125)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetsef = Helpers.GetPointTargetSelfInfo(theability_InfoID, _
                                                        thecaster, _
                                                        thetarget, _
                                                        "", eModifierCategory.Active)

    Dim pointtargetlive = Helpers.GetPointTargetLineEnemyUnitsInfo(theability_InfoID, _
                                                        thecaster, _
                                                        thetarget, _
                                                        "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.BallLightDamMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, pointtargetlive)
    outmods.Add(dammod)


    Dim tpval As New modValue(1, eModifierType.BallLightPushForward, occurencetime)

    Dim tpmod As New Modifier(tpval, pointtargetsef)
    outmods.Add(tpmod)


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
