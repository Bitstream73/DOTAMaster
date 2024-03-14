Public Class abGeostrike
Inherits AbilityBase
  Public slow As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True 'FixFixFix
    PiercesSpellImmunity = True

    Notes = "" 'FixFixFix"

    mDisplayName = "Geostrike"
    mName = eAbilityName.abGeostrike
    Me.EntityName = eEntity.abGeostrike

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untMeepo

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/meepo_geostrike_hp2.png"

    Description = "Meepo enchants his weapon to deal damage per second, as well as slow the movement speed of the attacked unit. Geostrikes from multiple Meepos stack."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untEnemyTarget)



    Damage = New ValueWrapper(7, 14, 21, 28)

    slow = New ValueWrapper(0.05, 0.1, 0.15, 0.2)

    Duration = New ValueWrapper(2, 2, 2, 2)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemy = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active)

    Dim dpsval As New modValue(Damage, eModifierType.RightClickDamageoT, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)
    dpsval.mValueDuration = Duration

    Dim dpsmod As New Modifier(dpsval, unittargetenemy)
    outmods.Add(dpsmod)


    Dim slowval As New modValue(slow, eModifierType.RightClickMoveSpeedPercSubtracted, occurencetime, aghstime)
    slowval.mValueDuration = Duration


    Dim slowmod As New Modifier(slowval, unittargetenemy)
    outmods.Add(slowmod)

    Return outmods
  End Function


  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                              theowner As iDisplayUnit, _
                                              thetarget As iDisplayUnit, _
                                              ftarget As iDisplayUnit, _
                                              isfriendbias As Boolean, _
                                              occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return New ModifierList
  End Function
End Class
