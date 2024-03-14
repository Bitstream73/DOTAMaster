Public Class abAstral_Spirit
Inherits AbilityBase
  Public buffduration As ValueWrapper

  Public bonusspeedcreeps As ValueWrapper
  Public bonusspeedheroes As ValueWrapper

  Public bonusdamagecreeps As ValueWrapper
  Public bonusdamageheroes As ValueWrapper

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

    mDisplayName = "Astral Spirit"
    mName = eAbilityName.abAstral_Spirit
    Me.EntityName = eEntity.abAstral_Spirit

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untElder_Titan

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/elder_titan_ancestral_spirit_hp2.png"

    Description = "Elder Titan sends forth his Astral Spirit, damaging any units it passes through. When the spirit rejoins the Titan, it grants bonus damage and movement speed for each unit it damaged. The Astral Spirit possesses the Echo Stomp, Return Spirit, and Natural Order abilities."

    ManaCost = New ValueWrapper(110, 110, 110, 110)

    Cooldown = New ValueWrapper(16, 16, 16, 16)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    Radius = New ValueWrapper(275, 275, 275, 275)

    Damage = New ValueWrapper(60, 90, 120, 150)

    Duration = New ValueWrapper(8, 8, 8, 8)

    buffduration = New ValueWrapper(9, 9, 9, 9)



    bonusspeedcreeps = New ValueWrapper(0.01, 0.01, 0.01, 0.01)
    bonusspeedheroes = New ValueWrapper(0.05, 0.05, 0.05, 0.05)

    bonusdamagecreeps = New ValueWrapper(3, 6, 9, 12)
    bonusdamageheroes = New ValueWrapper(10, 20, 30, 40)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetlineenemies = Helpers.GetPointTargetLineEnemyUnitsInfo(theability_InfoID, _
                                                                          thecaster, _
                                                                          thetarget, _
                                                                          "", eModifierCategory.Active)



    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                                          thecaster, _
                                                                          thetarget, _
                                                                          "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, pointtargetlineenemies)
    outmods.Add(dammod)

    'bonus speed
    Dim creepspeedval As New modValue(bonusspeedcreeps, eModifierType.AstralSpiritMoveSpeedPercentAdded, occurencetime, aghstime)
    creepspeedval.mValueDuration = buffduration

    Dim creepspeedmod As New Modifier(creepspeedval, notargetself)
    outmods.Add(creepspeedmod)

    Dim herospeedval As New modValue(bonusspeedheroes, eModifierType.AstralSpiritMoveSpeedPercentAdded, occurencetime, aghstime)
    herospeedval.mValueDuration = buffduration

    Dim herospeedmod As New Modifier(herospeedval, notargetself)
    outmods.Add(herospeedmod)


    'bonus damage
    Dim creepdamval As New modValue(bonusdamagecreeps, eModifierType.AstralSpiritDamageMagicalAdded, occurencetime, aghstime)
    creepdamval.mValueDuration = buffduration

    Dim creepdammod As New Modifier(creepdamval, notargetself)
    outmods.Add(creepdammod)


    Dim herodamval As New modValue(bonusdamageheroes, eModifierType.AstralSpiritDamageMagicalAdded, occurencetime, aghstime)
    herodamval.mValueDuration = buffduration

    Dim herodammod As New Modifier(herodamval, notargetself)
    outmods.Add(herodammod)

    'Option to Cast Natural Order


    'Option to Cast Echo Stomp



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
