Public Class abBlood_Bath
Inherits AbilityBase

Public Sub New()
mBlockedByMagicImmune = True 'FixFixFix
mRemovedByMagicImmune = True 'FixFixFix
mCanBePurged = True 'FixFixFix
mCanBeUsedByIllusions = True 'FixFixFix
mCanSelfDeny = True 'FixFixFix
mBlockedByLinkens = True 'FixFixFix
mBreaksStun = True 'FixFixFix
mIsUniqueAttackModifier = True 'FixFixFix
    mPiercesSpellImmunity = False

  mNotes = "" 'FixFixFix"

mName = eAbilityName.abBlood_Bath
 mFriendlyName = PageHandler.dbAbilities.GetFriendlyName(mName)
mParent = eHeroName.untBloodseeker

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/bloodseeker_blood_bath_hp2.png"

mDescription = "Bloodseeker revels in combat, regaining health with every unit he kills or whenever an enemy Hero dies within a 325 radius of Bloodseeker. The health gained is a percentage of the killed unit's maximum HP."



mAbilityTypes.Add(eAbilityType.Passive)

mAffects.Add(eUnit.untSelf)




End Sub

  Public Overrides Function GetActiveModifiers(ByRef theability_InfoID As dvID, _
                                       ByRef thecaster As dvID, ByRef thecastertype As eUnittype, _
                                       ByRef thetarget As dvID, ByRef thetargettype As eUnittype, _
                                       ByRef occurencetime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Return Nothing

    Return outmods
  End Function
End Class
