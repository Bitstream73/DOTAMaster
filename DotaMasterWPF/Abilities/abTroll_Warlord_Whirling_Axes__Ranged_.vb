Public Class abWhirling_Axes__Ranged
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
    ' mAbilityLevelCount = 4 'FixFixFix

    mNotes = "" 'FixFixFix"

    mName = eAbilityName.abWhirling_Axes__Ranged
    mFriendlyName = PageHandler.dbAbilities.GetFriendlyName(mName)
    mParent = eHeroName.untTroll_Warlord

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/troll_warlord_whirling_axes_ranged_hp2.png"

    mDescription = "Troll hurls a fistful of five axes in a cone shape over 900 range, slowing and damaging enemy units."

    mManaCost.Add(50)
    mManaCost.Add(50)
    mManaCost.Add(50)
    mManaCost.Add(50)

    mCooldown.Add(20)

    mAbilityTypes.Add(eAbilityType.UnitTarget)
    mAbilityTypes.Add(eAbilityType.PointTarget)

    mAffects.Add(eUnit.untEnemyUnits)

    mDamageType = eDamageType.Magical



  End Sub

  Public Function GetModifiers(ByVal theabilitylevel As Integer, ByVal thecaster As HeroBuild, ByVal thetarget As HeroBuild) As ModifierList
    If theabilitylevel = 0 Then Return Nothing

    Dim outmods As New ModifierList



    Return outmods
  End Function


End Class
