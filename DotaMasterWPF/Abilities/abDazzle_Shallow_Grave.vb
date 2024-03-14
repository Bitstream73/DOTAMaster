Public Class abShallow_Grave
Inherits AbilityBase

Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = True

    Notes = "HP cannot go below 1 while under the effects of Shallow Grave.|Axe's Culling Blade ignores the effect of Shallow Grave, but the shatter damage of Ice Blast will not kill a hero affected by this ability.|Does not prevent dying via Techies' Suicide Squad, Attack! or Bloodstone's Pocket Suicide."

mName = eAbilityName.abShallow_Grave
    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untDazzle
    Me.EntityName = eEntity.abShallow_Grave


    mDisplayName = "Shallow Grave"
    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/dazzle_shallow_grave_hp2.png"

    Description = "An ally blessed with Shallow Grave, no matter how close to death, cannot die while under its protection."

    ManaCost = New ValueWrapper(140, 130, 120, 110)

    Cooldown = New ValueWrapper(60, 45, 30, 15)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untHeroes)

    Duration = New ValueWrapper(5, 5, 5, 5)

    Range = New ValueWrapper(550, 700, 850, 1000)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetally = Helpers.GetUnitTargetAlliedUnitInfo(theability_InfoID, _
                                                             thecaster, _
                                                             thetarget, _
                                                             "", eModifierCategory.Active)


    Dim graveval As New modValue(Duration, eModifierType.ShallowGrave, occurencetime, occurencetime)
    graveval.mValueDuration = Duration


    Dim thegrave As New Modifier(graveval, unittargetally)
    outmods.Add(thegrave)

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
