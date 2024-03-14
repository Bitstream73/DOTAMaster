Public Class abStone_Remnant
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
    'mAbilityLevelCount = 4 'FixFixFix

  mNotes = "" 'FixFixFix"

mName = eAbilityName.abStone_Remnant
 mFriendlyName = PageHandler.dbAbilities.GetFriendlyName(mName)
mParent = eHeroName.untEarth_Spirit

    mAbilityPosition = 4

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/earth_spirit_stone_caller_hp2.png"

mDescription = "Call a Stone Remnant at the target location. Stones Remnants have no vision and are invulnerable, and can be used with Earth Spirit's abilities. Calling a Stone Remnant consumes a charge, which recharge over time."


mCooldown.Add(0)

mAbilityTypes.Add(eAbilityType.PointTarget)

mAffects.Add(eUnit.untSelf)



mDuration.Add(120)

End Sub

Public Function GetModifiers(ByVal theabilitylevel As Integer, ByVal thecaster As HeroBuild, ByVal thetarget As HeroBuild) As ModifierList
If theabilitylevel = 0 Then Return Nothing

Dim outmods As New ModifierList



Return outmods
End Function


End Class
