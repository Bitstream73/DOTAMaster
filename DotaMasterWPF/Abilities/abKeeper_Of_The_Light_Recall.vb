Public Class abRecall
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

mName = eAbilityName.abRecall
 mFriendlyName = PageHandler.dbAbilities.GetFriendlyName(mName)
mParent = eHeroName.untKeeper_Of_The_Light

    mAbilityPosition = 4

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/keeper_of_the_light_recall_hp2.png"

mDescription = "After a short delay, teleports the targeted friendly hero to your location. If the targeted friendly hero takes player based damage during this time, the ability is interrupted."

mManaCost.Add(100)
mManaCost.Add(100)
mManaCost.Add(100)

mCooldown.Add(15)

mAbilityTypes.Add(eAbilityType.NoTarget)
mAbilityTypes.Add(eAbilityType.Channeled)
mAbilityTypes.Add(eAbilityType.UnitTarget)
mAbilityTypes.Add(eAbilityType.PointTarget)

    mAffects.Add(eUnit.untAlliedHero)




End Sub

Public Function GetModifiers(ByVal theabilitylevel As Integer, ByVal thecaster As HeroBuild, ByVal thetarget As HeroBuild) As ModifierList
If theabilitylevel = 0 Then Return Nothing

Dim outmods As New ModifierList



Return outmods
End Function


End Class
