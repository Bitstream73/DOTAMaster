Public Class abChakra_Magic
Inherits AbilityBase
  Public manarestored As ValueWrapper
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

    mDisplayName = "Chakra Magic"
    mName = eAbilityName.abChakra_Magic
    Me.EntityName = eEntity.abChakra_Magic

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untKeeper_of_the_Light

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/keeper_of_the_light_chakra_magic_hp2.png"

    Description = "Restores mana to the target unit."

    ManaCost = New ValueWrapper(25, 35, 45, 55)

    Cooldown = New ValueWrapper(19, 18, 17, 16)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untAlliedUnit)

    manarestored = New ValueWrapper(75, 150, 225, 300)




End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim theaffects As New List(Of eUnit)
    theaffects.Add(eUnit.untSelf)
    theaffects.Add(eUnit.untAlliedUnit)
    theaffects.Add(eUnit.untEnemyUnit)

    Dim unittargetmulti = Helpers.GetUnitTargetMultiAffectsInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active, theaffects)

    Dim manaval As New modValue(manarestored, eModifierType.ManaRestored, occurencetime, aghstime)

    Dim manamod As New Modifier(manaval, unittargetmulti)
    outmods.Add(manamod)


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
