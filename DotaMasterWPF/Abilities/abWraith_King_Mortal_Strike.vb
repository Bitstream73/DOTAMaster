Public Class abMortal_Strike
Inherits AbilityBase

  Public critdamage As ValueWrapper
  Public critchance As ValueWrapper

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

    mDisplayName = "Mortal Strike"
    mName = eAbilityName.abMortal_Strike
    Me.EntityName = eEntity.abMortal_Strike

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untWraith_King

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/skeleton_king_mortal_strike_hp2.png"

    Description = "Wraith King passively gains a chance to deal bonus damage on an attack."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untEnemyUnit)




  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                  thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                  ftarget As iDisplayUnit, _
                                                  isfriendbias As Boolean, _
                                                  occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return Nothing
  End Function


   Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, caster As iDisplayUnit, target As iDisplayUnit, ftarget As iDisplayUnit, isfriendbias As Boolean, occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                   caster, _
                                                   target, _
                                                   "", eModifierCategory.Passive)

    Dim critval As New modValue(critdamage, eModifierType.CritDamage, occurencetime, aghstime)
    critval.mPercentChance = critchance

    Dim critmod As New Modifier(critval, notargetself)
    outmods.Add(critmod)

    Return outmods

  End Function


End Class
