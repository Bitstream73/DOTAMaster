Public Class abLaunch_Fire_Spirit
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

mName = eAbilityName.abLaunch_Fire_Spirit
 mFriendlyName = PageHandler.dbAbilities.GetFriendlyName(mName)
mParent = eHeroName.untPhoenix

mAbilityPosition = 1

mIsUltimate = False 'FixFixFix
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/phoenix_launch_fire_spirit_hp2.png"

mDescription = "Each fire spirit can be launched independently at a targeted area of effect. Affected enemy units take damage over time and have their attack speed greatly reduced."

mManaCost.Add(0)
mManaCost.Add(0)
mManaCost.Add(0)
mManaCost.Add(0)

mCooldown.Add(0)

mAbilityTypes.Add(eAbilityType.PointTarget)

mAffects.Add(eUnit.untSelf)

mDamageType = eDamageType.Magical


mRadius.Add(175)
mRadius.Add(175)
mRadius.Add(175)
mRadius.Add(175)

End Sub

Public Function GetModifiers(ByVal theabilitylevel As Integer, ByVal thecaster As Hero, ByVal thetarget As Hero) As ModifierList
If theabilitylevel = 0 Then Return Nothing

Dim outmods As New ModifierList



Return outmods
End Function


End Class
