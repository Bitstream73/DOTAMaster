Public Class abUntouchable
Inherits AbilityBase
  Public attackslow As ValueWrapper
  Public slowduration As ValueWrapper
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

    mDisplayName = "Untouchable"
    mName = eAbilityName.abUntouchable
    Me.EntityName = eEntity.abUntouchable

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untEnchantress

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/enchantress_untouchable_hp2.png"

    Description = "Enchantress beguiles her enemies, slowing their attacks when she is attacked. Lasts 4 seconds."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    attackslow = New ValueWrapper(30, 60, 90, 120)

    slowduration = New ValueWrapper(4, 4, 4, 4)



End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetattackingenemy = Helpers.GetNoTargetAttackingEnemyUnitInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Passive)

    Dim attspeedval As New modValue(attackslow, eModifierType.AttackspeedSubtracted, occurencetime, aghstime)
    attspeedval.mValueDuration = slowduration

    Dim attmod As New Modifier(attspeedval, notargetattackingenemy)
    outmods.Add(attmod)


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
