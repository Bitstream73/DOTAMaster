Public Class abPhantom_Edge
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

mName = eAbilityName.abPhantom_Edge
 mFriendlyName = PageHandler.dbAbilities.GetFriendlyName(mName)
mParent = eHeroName.untPhantom_Lancer

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/phantom_lancer_phantom_edge_hp2.png"

mDescription = "Phantom Lancer hones his abilities. Improves chance of Juxtaposing, and the Juxtapose illusions can now create their own illusions. Phantom Edge also increases Phantom Lancer's magic resistance."



mAbilityTypes.Add(eAbilityType.Passive)

mAffects.Add(eUnit.untSelf)




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
