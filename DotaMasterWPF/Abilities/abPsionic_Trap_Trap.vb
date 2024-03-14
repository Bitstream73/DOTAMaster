Public Class abPsionic_Trap_Trap
  Inherits AbilityBase


  Public Sub New()
    mBlockedByMagicImmune = False
    mRemovedByMagicImmune = False
    mCanBePurged = False
    mCanBeUsedByIllusions = False
    mCanSelfDeny = False
    mBlockedByLinkens = False
    mBreaksStun = False
    mIsUniqueAttackModifier = False

    mPiercesSpellImmunity = False

    mName = eAbilityName
    mFriendlyName = PageHandler.dbAbilities.GetFriendlyName(mName)
    mParent = eHeroName

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False
    mHasAghs = False

    mAbilityImage = 
    mWebpageLink = 
    mDescription = 
    mNotes = 

    mManaCost = New ValueWrapper()

    mCooldown = New ValueWrapper()

    mAbilityTypes.Add(eAbilityType)

    mAffects.Add(eUnit)
    mAffects.Add(eUnit)

    mDuration = New ValueWrapper()


  End Sub

  Public Overrides Function GetActiveModifiers(ByVal thestateindex As Integer, ByRef thegame As dGame, ByRef theability_InfoID As dvID, _
                                                  ByRef thecaster As dvID, ByRef thecastertype As eUnittype, _
                                                  ByRef thetarget As dvID, ByRef thetargettype As eUnittype, _
                                                  ByRef ftarget As dvID, ByRef ftargettype As eUnittype, _
                                                  ByRef isfriendbias As Boolean, _
                                                  ByRef occurencetime As Lifetime, ByRef aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

= Helpers.(theability_InfoID, eSourceType.Ability_Info, _
                                                                             thecaster, thecastertype, _
                                                                             thetarget, thetargettype, _
                                                                             "", eModifierCategory.Active, _
                                                                             theaffects)

    Return outmods
  End Function
End Class
