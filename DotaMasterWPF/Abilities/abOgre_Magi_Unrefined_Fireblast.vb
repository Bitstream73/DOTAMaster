Public Class abUnrefined_Fireblast
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

mName = eAbilityName.abUnrefined_Fireblast
 mFriendlyName = PageHandler.dbAbilities.GetFriendlyName(mName)
mParent = eHeroName.untOgre_Magi

    mAbilityPosition = 4

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/ogre_magi_unrefined_fireblast_hp2.png"

mDescription = "Blasts an enemy unit with a wave of fire, dealing damage and stunning the target."

mManaCost.Add(400)

mCooldown.Add(6)

mAbilityTypes.Add(eAbilityType.UnitTarget)

mAffects.Add(eUnit.untEnemyUnits)

mDamageType = eDamageType.Magical

mDamage.Add(275)


End Sub

Public Function GetModifiers(ByVal theabilitylevel As Integer, ByVal thecaster As HeroBuild, ByVal thetarget As HeroBuild) As ModifierList
If theabilitylevel = 0 Then Return Nothing

Dim outmods As New ModifierList



Return outmods
End Function


End Class
