Public Class abReplicate
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
mAbilityLevelCount = 4 'FixFixFix

  mNotes = "" 'FixFixFix"

mName = eAbilityName.abReplicate
 mFriendlyName = PageHandler.dbAbilities.GetFriendlyName(mName)
mParent = eHeroName.untMorphling

mAbilityPosition = 1

mIsUltimate = False 'FixFixFix
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/morphling_replicate_hp2.png"

mDescription = "Morphling replicates any hero, friend or foe, dealing 50% of the original Hero's outgoing damage while taking 100% of any incoming damage. At any time, Morphling can instantly take the position of the Replicate for 150 mana."

mManaCost.Add(25)
mManaCost.Add(25)
mManaCost.Add(25)

mCooldown.Add(80)

mAbilityTypes.Add(eAbilityType.UnitTarget)

mAffects.Add(eUnit.untSelf)



mDuration.Add(60)
mDuration.Add(45)
mDuration.Add(30)

End Sub

Public Function GetModifiers(ByVal theabilitylevel As Integer, ByVal thecaster As Hero, ByVal thetarget As Hero) As ModifierList
If theabilitylevel = 0 Then Return Nothing

Dim outmods As New ModifierList



Return outmods
End Function


End Class
