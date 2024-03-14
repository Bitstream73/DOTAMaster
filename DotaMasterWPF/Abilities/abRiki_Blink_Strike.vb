Public Class abBlink_Strike
Inherits AbilityBase
  Public bonusdamage As ValueWrapper
  Public maxcharges As ValueWrapper

  Public chargerestoretime As ValueWrapper
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

    mDisplayName = "Blink Strike"
    mName = eAbilityName.abBlink_Strike
    Me.EntityName = eEntity.abBlink_Strike

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untRiki

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/riki_blink_strike_hp2.png"

    Description = "Teleports behind the target unit, striking for bonus damage if it is an enemy."

    ManaCost = New ValueWrapper(40, 40, 40, 40)

    Cooldown = New ValueWrapper(35, 35, 35, 35)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    bonusdamage = New ValueWrapper(40, 70, 100)

    maxcharges = New ValueWrapper(4, 5, 6)

    chargerestoretime = New ValueWrapper(35, 35, 35, 35)

    Range = New ValueWrapper(800, 800, 800, 800)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemy = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active)

    Dim unittargetself = Helpers.GetUnitTargetSelfInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active)


    Dim tpval As New modValue(1, eModifierType.Teleport, occurencetime)
    tpval.mRange = Range

    Dim tpmod As New Modifier(tpval, unittargetself)
    outmods.Add(tpmod)



    Dim damval As New modValue(bonusdamage, eModifierType.RightClickBonusDamageInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, unittargetenemy)
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
