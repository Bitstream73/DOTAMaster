Public Class abKunkka_Return
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

    mName = eAbilityName.abKunkka_Return
    mFriendlyName = PageHandler.dbAbilities.GetFriendlyName(mName)
    mParent = eHeroName.untKunkka

    mAbilityPosition = 1

    mIsUltimate = False 'FixFixFix
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/kunkka_return_hp2.png"

    mDescription = "Returns the marked hero to the X."

    mManaCost.Add(50)

    mCooldown.Add(5)

    mAbilityTypes.Add(eAbilityType.NoTarget)

    mAffects.Add(eUnit.untSelf)




  End Sub

  Public Function GetModifiers(ByVal theabilitylevel As Integer, ByVal thecaster As Hero, ByVal thetarget As Hero) As ModifierList
    If theabilitylevel = 0 Then Return Nothing

    Dim outmods As New ModifierList



    Return outmods
  End Function


End Class
