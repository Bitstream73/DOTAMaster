Public Class abFocused_Detonate
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

mName = eAbilityName.abFocused_Detonate
 mFriendlyName = PageHandler.dbAbilities.GetFriendlyName(mName)
mParent = eHeroName.untTechies

    mAbilityPosition = 4

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/techies_focused_detonate_hp2.png"

mDescription = "Detonate all remote mines in the target area."


mCooldown.Add(1)

mAbilityTypes.Add(eAbilityType.PointTarget)

mAffects.Add(eUnit.untSelf)

mDamageType = eDamageType.Magical


mRadius.Add(700)

End Sub

Public Function GetModifiers(ByVal theabilitylevel As Integer, ByVal thecaster As HeroBuild, ByVal thetarget As HeroBuild) As ModifierList
If theabilitylevel = 0 Then Return Nothing

Dim outmods As New ModifierList



Return outmods
End Function


End Class
