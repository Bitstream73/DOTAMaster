Public Class abGreat_Cleave
Inherits AbilityBase

  Public cleavedamage As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Cleave damage is reduced by armor type but not by armor value.|The cleave damages a circular area in front of Sven.|As with all cleave, Great Cleave icon.png Great Cleave stacks with Battle Fury icon.png Battle Fury and Empower.|Despite the visual effect, damage is applied instantly in the whole area." '"

    mDisplayName = "Great Cleave"
    mName = eAbilityName.abGreat_Cleave
    Me.EntityName = eEntity.abGreat_Cleave

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSven

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/sven_great_cleave_hp2.png"

    Description = "Sven strikes with great force, cleaving all nearby enemy units with his attack."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    Radius = New ValueWrapper(300, 300, 300, 300)

    cleavedamage = New ValueWrapper(0.2, 0.35, 0.5, 0.65)



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

    Dim coneenemies = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                          theowner, _
                                                          thetarget, _
                                                          "", eModifierCategory.Passive)


    Dim damval As New modValue(cleavedamage, eModifierType.CleavePercentage, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, coneenemies)
    outmods.Add(dammod)


    Return outmods
  End Function
End Class
