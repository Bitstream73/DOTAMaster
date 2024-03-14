Public Class abSpiked_Carapace
  Inherits AbilityBase


  Public reflectduration As ValueWrapper
  Public stunduration As ValueWrapper
  Public damagepercreflected As ValueWrapper

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

    mDisplayName = "Spiked Carapace"
    mName = eAbilityName.abSpiked_Carapace
    Me.EntityName = eEntity.abSpiked_Carapace

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untNyx_Assassin

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/nyx_assassin_spiked_carapace_hp2.png"

    Description = "When activated, Spiked Carapace reflects and negates damage dealt to Nyx Assassin (max once from each source), as well as stunning the source of the damage."

    ManaCost = New ValueWrapper(40, 40, 40, 40)

    Cooldown = New ValueWrapper(23, 20, 17, 14)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Pure

    reflectduration = New ValueWrapper(2.25, 2.25, 2.25, 2.25)

    stunduration = New ValueWrapper(0.6, 1.2, 1.8, 2.4)

    damagepercreflected = New ValueWrapper(1, 1, 1, 1)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return Nothing
  End Function


  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                    theowner As idisplayunit, _
                                                   thetarget As iDisplayUnit, _
                                                    ftarget As iDisplayUnit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As modifierlist

    Dim outmods As New ModifierList

    Dim notargetattackingenemy = Helpers.GetNoTargetAttackingEnemyUnitInfo(theability_InfoID, _
                                                                           theowner, _
                                                                           thetarget, _
                                                                           "", eModifierCategory.Passive)

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                                           theowner, _
                                                                           thetarget, _
                                                                           "", eModifierCategory.Passive)

    Dim damval As New modValue(damagepercreflected, eModifierType.ReflectedDamageInflicted, occurencetime, aghstime)
    damval.mValueDuration = reflectduration
    damval.mCooldown = Cooldown

    Dim dammod As New Modifier(damval, notargetself)
    outmods.Add(dammod)



    Dim reflectval As New modValue(damagepercreflected, eModifierType.TargetedDamageReflected, occurencetime, aghstime)
    reflectval.mValueDuration = reflectduration
    reflectval.mCooldown = Cooldown

    Dim refmod As New Modifier(reflectval, notargetattackingenemy)
    outmods.Add(refmod)



    Dim stunval As New modValue(stunduration, eModifierType.Stun, occurencetime, aghstime)

    Dim stunmod As New Modifier(stunval, notargetattackingenemy)
    outmods.Add(stunmod)

    Return outmods
  End Function
End Class
