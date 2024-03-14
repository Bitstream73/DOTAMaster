Public Class abThunder_Clap
Inherits AbilityBase
  Public heroduration As ValueWrapper
  Public creepduration As ValueWrapper
  Public movementslow As ValueWrapper
  Public attackslow As ValueWrapper

  Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = True '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "" 'FixFixFix"
    mDisplayName = "Thunder Clap"
    mName = eAbilityName.abThunder_Clap
    Me.EntityName = eEntity.abThunder_Clap

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untBrewmaster

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/brewmaster_thunder_clap_hp2.png"

    Description = "Slams the ground, dealing damage and slowing the movement speed and attack rate of nearby enemy land units."

    ManaCost = New ValueWrapper(90, 105, 130, 150)

    Cooldown = New ValueWrapper(13, 13, 13, 13)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Radius = New ValueWrapper(400, 400, 400, 400)


    Damage = New ValueWrapper(100, 175, 250, 300)

    movementslow = New ValueWrapper(0.25, 0.35, 0.45, 0.55)

    attackslow = New ValueWrapper(25, 35, 45, 55)

    heroduration = New ValueWrapper(4, 4, 4, 4)

    creepduration = New ValueWrapper(8, 8, 8, 8)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim auraenemies = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                          thecaster, _
                                                          thetarget, _
                                                          "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim thedamage As New Modifier(damval, auraenemies)
    outmods.Add(thedamage)






    Dim auraenemyheroes = Helpers.GetActiveAuraEnemyHeroesInfo(theability_InfoID, _
                                                          thecaster, _
                                                          thetarget, _
                                                          "", eModifierCategory.Active)



    'hero duration
    Dim heromoveval As New modValue(movementslow, eModifierType.MoveSpeedSubtracted, occurencetime, aghstime)
    heromoveval.mValueDuration = heroduration

    Dim heromove As New Modifier(heromoveval, auraenemyheroes)
    outmods.Add(heromove)


    Dim heroattsloval As New modValue(attackslow, eModifierType.AttackspeedSubtracted, occurencetime, aghstime)
    heroattsloval.mValueDuration = heroduration

    Dim heroattslow As New Modifier(heroattsloval, auraenemyheroes)
    outmods.Add(heroattslow)




    'creep duration
    Dim activeauraenemycreeps = Helpers.GetActiveAuraEnemyCreepsInfo(theability_InfoID, _
                                                      thecaster, _
                                                      thetarget, _
                                                      "", eModifierCategory.Active)

    Dim creepmoveval As New modValue(movementslow, eModifierType.MoveSpeedAdded, occurencetime, aghstime)
    creepmoveval.mValueDuration = creepduration

    Dim creepmove As New Modifier(creepmoveval, activeauraenemycreeps)
    outmods.Add(creepmove)

    Dim creepattslow As New modValue(attackslow, eModifierType.AttackSpeedAdded, occurencetime, aghstime)
    creepattslow.mValueDuration = creepduration

    Dim thecreepattslow As New Modifier(creepattslow, activeauraenemycreeps)
    outmods.Add(thecreepattslow)


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
