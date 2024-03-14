Public Class abIllusory_Orb
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

    mDisplayName = "Illusory Orb"
    mName = eAbilityName.abIllusory_Orb

    Me.EntityName = eEntity.abIllusory_Orb

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untPuck

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/puck_illusory_orb_hp2.png"

    Description = "Puck launches magic orb that floats in a straight path, damaging enemy units along the way. At any point, Puck may teleport to the orb's location using Ethereal Jaunt."

    ManaCost = New ValueWrapper(150, 150, 150, 150)


    Cooldown = New ValueWrapper(12, 12, 12, 12)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical


    Damage = New ValueWrapper(70, 140, 210, 280)

    Range = New ValueWrapper(1800, 1800, 1800, 1800)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetlineenemies = Helpers.GetPointTargetLineEnemyUnitsInfo(theability_InfoID, _
                                                                          thecaster, _
                                                                          thetarget, _
                                                                          "", eModifierCategory.Active)

    Dim pointtargetself = Helpers.GetPointTargetSelfInfo(theability_InfoID, _
                                                                          thecaster, _
                                                                          thetarget, _
                                                                          "", eModifierCategory.Active)


    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, pointtargetlineenemies)
    outmods.Add(dammod)


    Dim tpval As New modValue(1, eModifierType.Teleport, occurencetime)

    Dim tpmod As New Modifier(tpval, pointtargetself)
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
