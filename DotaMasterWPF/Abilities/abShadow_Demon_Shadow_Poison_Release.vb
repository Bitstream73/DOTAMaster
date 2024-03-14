Public Class abShadow_Poison_Release
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

mName = eAbilityName.abShadow_Poison_Release
 mFriendlyName = PageHandler.dbAbilities.GetFriendlyName(mName)
mParent = eHeroName.untShadow_Demon

mAbilityPosition = 1

mIsUltimate = False 'FixFixFix
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/shadow_demon_shadow_poison_release_hp2.png"

mDescription = "Releases the poison to do damage on all affected enemies. Units under the effect of Disruption can still be affected by Shadow Poison."


mCooldown.Add(1)

mAbilityTypes.Add(eAbilityType.NoTarget)

mAffects.Add(eUnit.untSelf)




End Sub

Public Function GetModifiers(ByVal theabilitylevel As Integer, ByVal thecaster As Hero, ByVal thetarget As Hero) As ModifierList
If theabilitylevel = 0 Then Return Nothing

Dim outmods As New ModifierList



Return outmods
End Function


End Class
