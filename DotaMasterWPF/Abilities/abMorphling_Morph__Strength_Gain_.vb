Public Class abMorph_Strength_Gain
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

    mName = eAbilityName.abMorph_Strength_Gain
    mFriendlyName = PageHandler.dbAbilities.GetFriendlyName(mName)
    mParent = eHeroName.untMorphling

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/morphling_morph_str_hp2.png"

    mDescription = "Morphling shifts its form, pulling points from Agility and pouring them into Strength. The process is reversible. Additional points in Morph increase the rate of stat change. Passively grants bonus Strength."


    mCooldown.Add(0)

    mAbilityTypes.Add(eAbilityType.NoTarget)
    mAbilityTypes.Add(eAbilityType.PointTarget)

    mAffects.Add(eUnit.untSelf)




  End Sub

  Public Function GetModifiers(ByVal theabilitylevel As Integer, ByVal thecaster As HeroBuild, ByVal thetarget As HeroBuild) As ModifierList
    If theabilitylevel = 0 Then Return Nothing

    Dim outmods As New ModifierList



    Return outmods
  End Function


End Class
