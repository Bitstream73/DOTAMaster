Public Class abBlinding_Light
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

mName = eAbilityName.abBlinding_Light
 mFriendlyName = PageHandler.dbAbilities.GetFriendlyName(mName)
mParent = eHeroName.untKeeper_Of_The_Light

    mAbilityPosition = 5

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/keeper_of_the_light_blinding_light_hp2.png"

mDescription = "A blinding light flashes over the targeted area, knocking back and blinding the units in the area, causing them to miss attacks."

mManaCost.Add(50)
mManaCost.Add(50)
mManaCost.Add(50)

mCooldown.Add(20)
mCooldown.Add(16)
mCooldown.Add(12)

mAbilityTypes.Add(eAbilityType.PointTarget)

mAffects.Add(eUnit.untSelf)



mDuration.Add(5)
mDuration.Add(4)
mDuration.Add(3)
mRadius.Add(675)
mRadius.Add(675)
mRadius.Add(675)

End Sub

Public Function GetModifiers(ByVal theabilitylevel As Integer, ByVal thecaster As HeroBuild, ByVal thetarget As HeroBuild) As ModifierList
If theabilitylevel = 0 Then Return Nothing

Dim outmods As New ModifierList



Return outmods
End Function


End Class
