Public Class abRage
  Inherits AbilityBase


  Public attackspeedbonus As ValueWrapper
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

    mDisplayName = "Rage"
    mName = eAbilityName.abRage
    Me.EntityName = eEntity.abRage

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untLifestealer

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/life_stealer_rage_hp2.png"

    Description = "Launch into a maddened rage, becoming immune to magic spells and gaining increased attack speed."

    ManaCost = New ValueWrapper(75, 75, 75, 75)

    Cooldown = New ValueWrapper(19, 19, 19, 19)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    attackspeedbonus = New ValueWrapper(30, 45, 60, 80)

    Duration = New ValueWrapper(3, 4, 5, 6)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return Nothing
  End Function


  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                    theowner As idisplayunit, _
                                                   thetarget As iDisplayUnit, _
                                                    ftarget As iDisplayUnit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As modifierlist

    Dim outmods As New ModifierList

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                  theowner, _
                                                  thetarget, _
                                                  "", eModifierCategory.Passive)

    Dim spellval As New modValue(Duration, eModifierType.SpellBlockDuration, occurencetime, aghstime)
    spellval.mValueDuration = Duration

    Dim spellmod As New Modifier(spellval, notargetself)
    outmods.Add(spellmod)


    Dim magval As New modValue(1, eModifierType.MagicResistanceCapped, occurencetime)
    magval.mValueDuration = Duration

    Dim magmod As New Modifier(magval, notargetself)
    outmods.Add(magmod)


    Dim attval As New modValue(attackspeedbonus, eModifierType.AttackSpeedAdded, occurencetime, aghstime)
    attval.mValueDuration = Duration

    Dim attmod As New Modifier(attval, notargetself)
    outmods.Add(attmod)


    Return outmods
  End Function
End Class
