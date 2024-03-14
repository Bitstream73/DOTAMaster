Public Class abPhantom_Strike
Inherits AbilityBase

  Public bonusattspeed As ValueWrapper
  Public maxattacks As ValueWrapper

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

    mDisplayName = "Phantom Strike"
    mName = eAbilityName.abPhantom_Strike
    Me.EntityName = eEntity.abPhantom_Strike

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untPhantom_Assassin

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/phantom_assassin_phantom_strike_hp2.png"

    Description = "Teleports to a unit, friendly or enemy, and grants bonus attack speed while attacking if it's an enemy unit."

    ManaCost = New ValueWrapper(50, 50, 50, 50)

    Cooldown = New ValueWrapper(14, 11, 8, 5)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untSelf)

    bonusattspeed = New ValueWrapper(130, 130, 130, 130)

    maxattacks = New ValueWrapper(4, 4, 4, 4)

    Range = New ValueWrapper(1000, 1000, 1000, 1000)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim theaffects As New List(Of eUnit)
    theaffects.Add(eUnit.untAlliedHero)
    theaffects.Add(eUnit.untEnemyHero)

    Dim unittargetmulti = Helpers.GetUnitTargetMultiAffectsInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active, theaffects)

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active)


    Dim tpval As New modValue(1, eModifierType.Teleport, occurencetime)
    tpval.mRange = Range

    Dim tpmod As New Modifier(tpval, unittargetmulti)
    outmods.Add(tpmod)


    Dim attval As New modValue(bonusattspeed, eModifierType.PhantomStrikeAttSpeedAdded, occurencetime, aghstime)
    attval.Charges = maxattacks


    Dim attmod As New Modifier(attval, notargetself)
    outmods.Add(attmod)

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
