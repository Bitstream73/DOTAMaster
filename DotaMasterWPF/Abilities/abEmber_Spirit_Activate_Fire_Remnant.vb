Public Class abActivate_Fire_Remnant
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

mName = eAbilityName.abActivate_Fire_Remnant
 mFriendlyName = PageHandler.dbAbilities.GetFriendlyName(mName)
mParent = eHeroName.untEmber_Spirit

mAbilityPosition = 1

mIsUltimate = False 'FixFixFix
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/ember_spirit_activate_fire_remnant_hp2.png"

mDescription = "Select the Fire Remnant to arrive at."

mManaCost.Add(150)

mCooldown.Add(0)

mAbilityTypes.Add(eAbilityType.PointTarget)

mAffects.Add(eUnit.untSelf)

mDamageType = eDamageType.Magical



End Sub

Public Function GetModifiers(ByVal theabilitylevel As Integer, ByVal thecaster As Hero, ByVal thetarget As Hero) As ModifierList
If theabilitylevel = 0 Then Return Nothing

Dim outmods As New ModifierList



Return outmods
End Function


End Class
