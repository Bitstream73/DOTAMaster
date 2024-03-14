Public Class abBattle_Cry
Inherits AbilityBase
  Public bonusdamage As ValueWrapper
  Public bonusarmor As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True 'FixFixFix
    PiercesSpellImmunity = False

    Notes = "" 'FixFixFix"

    mDisplayName = "Battle Cry"
    mName = eAbilityName.abBattle_Cry
    Me.EntityName = eEntity.abBattle_Cry

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untLone_Druid

    mAbilityPosition = 4

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/lone_druid_true_form_battle_cry_hp2.png"

    Description = "Adds damage and armor to the Lone Druid and his Spirit Bear."


    ManaCost = New ValueWrapper(50, 50, 50)

    Cooldown = New ValueWrapper(60, 60, 60)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)
    Affects.Add(eUnit.untControlledUnits)

    bonusdamage = New ValueWrapper(50, 75, 100)

    bonusarmor = New ValueWrapper(5, 10, 15)

    Duration = New ValueWrapper(6, 6, 6)

    Radius = New ValueWrapper(1000, 1000, 1000)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Active)

    Dim notargetcontrolledunits = Helpers.GetNoTargetControlledUnitsInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Active)


    Dim damval As New modValue(bonusdamage, eModifierType.RightClickDamageAdded, occurencetime, aghstime)
    damval.mValueDuration = Duration

    Dim dammod As New Modifier(damval, notargetself)
    outmods.Add(dammod)

    Dim dampetsmod As New Modifier(damval, notargetcontrolledunits)
    outmods.Add(dampetsmod)



    Dim armval As New modValue(bonusarmor, eModifierType.ArmorAdded, occurencetime, aghstime)
    armval.mValueDuration = Duration

    Dim armmod As New Modifier(armval, notargetself)
    outmods.Add(armmod)

    Dim armpetsmod As New Modifier(armval, notargetcontrolledunits)
    outmods.Add(armpetsmod)



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
