Public Class abDoppelwalk
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
    mPiercesSpellImmunity = False

  mNotes = "" 'FixFixFix"

mName = eAbilityName.abDoppelwalk
 mFriendlyName = PageHandler.dbAbilities.GetFriendlyName(mName)
mParent = eHeroName.untPhantom_Lancer

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/phantom_lancer_doppelwalk_hp2.png"

mDescription = "Renders Phantom Lancer invisible, while generating a duplicate image to confuse enemies."

    mManaCost = New ValueWrapper(150, 120, 90, 60)

    mCooldown = New ValueWrapper(30, 25, 20, 15)

    mAbilityTypes.Add(eAbilityType.NoTarget)

mAffects.Add(eUnit.untSelf)

    mDuration = New ValueWrapper(8, 8, 8, 8)
End Sub

  Public Overrides Function GetActiveModifiers(ByRef theability_InfoID As dvID, _
                                       ByRef thecaster As dvID, ByRef thecastertype As eUnittype, _
                                       ByRef thetarget As dvID, ByRef thetargettype As eUnittype, _
                                       ByRef occurencetime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Return Nothing

    Return outmods
  End Function


End Class
