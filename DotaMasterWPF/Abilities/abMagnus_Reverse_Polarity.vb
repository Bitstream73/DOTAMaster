Public Class abReverse_Polarity
Inherits AbilityBase
  Public pullradius As ValueWrapper
  Public herostunduration As ValueWrapper
  Public creepstunduration As ValueWrapper
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

    mDisplayName = "Reverse Polarity"
    mName = eAbilityName.abReverse_Polarity
    Me.EntityName = eEntity.abReverse_Polarity

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untMagnus

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/magnataur_reverse_polarity_hp2.png"

    Description = "Magnus changes properties of matter, sucking all nearby enemies in front of him and stunning them with a powerful slam and dealing damage."

    ManaCost = New ValueWrapper(200, 250, 300)

    Cooldown = New ValueWrapper(120, 110, 100)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(50, 125, 200)

    pullradius = New ValueWrapper(410, 410, 410)

    herostunduration = New ValueWrapper(2.25, 3, 3.75)

    creepstunduration = New ValueWrapper(3, 4, 5)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetconeenemies = Helpers.GetNoTargetConeEnemyUnitsInfo(theability_InfoID, _
                                                                    thecaster, _
                                                                    thetarget, _
                                                                    "", eModifierCategory.Active)

    Dim notargetconeEnemyCreeps = Helpers.GetNoTargetConeEnemyCreepsInfo(theability_InfoID, _
                                                                    thecaster, _
                                                                    thetarget, _
                                                                    "", eModifierCategory.Active)



    Dim notargetconeEnemyheroes = Helpers.GetNoTargetConeEnemyHeroesInfo(theability_InfoID, _
                                                                    thecaster, _
                                                                    thetarget, _
                                                                    "", eModifierCategory.Active)


    Dim pullval As New modValue(1, eModifierType.Pullback, occurencetime)
    pullval.mRadius = pullradius

    Dim pullmod As New Modifier(pullval, notargetconeenemies)
    outmods.Add(pullmod)



    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, notargetconeenemies)
    outmods.Add(dammod)



    Dim herostunval As New modValue(herostunduration, eModifierType.Stun, occurencetime, aghstime)
    herostunval.mValueDuration = herostunduration

    Dim hstunmod As New Modifier(herostunval, notargetconeEnemyheroes)
    outmods.Add(hstunmod)



    Dim creepstunval As New modValue(creepstunduration, eModifierType.Stun, occurencetime, aghstime)
    creepstunval.mValueDuration = creepstunduration

    Dim cstunmod As New Modifier(creepstunval, notargetconeEnemyCreeps)
    outmods.Add(cstunmod)


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
