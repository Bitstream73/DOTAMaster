Public Class abSpell_Steal
Inherits AbilityBase
  Public sceptercooldown As New List(Of Double?)
  Public scepterrange As New List(Of Double?)
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

    mDisplayName = "Spell Steal"
    mName = eAbilityName.abSpell_Steal
    Me.EntityName = eEntity.abSpell_Steal

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untRubick

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/rubick_spell_steal_hp2.png"

    Description = "Rubick studies the trace magical essence of one enemy hero, learning the secrets of the last spell the hero cast. Rubick can use this spell as his own for several minutes or until he dies. Upgradable by Aghanim's Scepter."

    ManaCost = New ValueWrapper(25, 25, 25)

    Cooldown = New ValueWrapper(20, 18, 16)
    sceptercooldown.Add(2)
    sceptercooldown.Add(2)
    sceptercooldown.Add(2)
    Cooldown.LoadScepterValues(sceptercooldown)
    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untHeroes)

    Duration = New ValueWrapper(180, 240, 300)

    Range = New ValueWrapper(1000, 1000, 1000)
    scepterrange.Add(1400)
    scepterrange.Add(1400)
    scepterrange.Add(1400)
    Range.LoadScepterValues(scepterrange)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Return Nothing

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
