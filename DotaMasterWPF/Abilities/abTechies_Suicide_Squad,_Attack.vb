Public Class abSuicide_Squad_Attack
  Inherits AbilityBase
  Dim fulldamageradius As ValueWrapper
  Dim partialdamageradius As ValueWrapper
  Dim fulldamage As ValueWrapper
  Dim partialdamage As ValueWrapper
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

    Notes = "Using this ability counts as suicide, and does not award gold or experience to the enemy team.|Techies still earn gold and experience for kills made with this ability.|This ability destroys trees.|The Bloodstone respawn decrease takes effect after the halving, decreasing the death time still further." '"

    mDisplayName = "Suicide Squad Attack!"
    mName = eAbilityName.abSuicide_Squad_Attack
    Me.EntityName = eEntity.abSuicide_Squad_Attack

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTechies

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False '

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/techies_suicide_hp2.png"

    Description = "Techies sacrifice themselves for the greater good, dealing massive area of effect damage. More damage is dealt to units closer to Techies when they explode. Techies' respawn time is reduced by 50% when killed by this ability."

    ManaCost = New ValueWrapper(100, 125, 150, 175)
    
    Cooldown = New ValueWrapper(180, 170, 160, 150)

    AbilityTypes.Add(eAbilityType.UnitTarget)
    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Physical

    fulldamageradius = New ValueWrapper(200, 200, 200, 200)
    
    partialdamageradius = New ValueWrapper(500, 500, 500, 500)
    
    fulldamage = New ValueWrapper(500, 650, 850, 1150)
    
    partialdamage = New ValueWrapper(260, 300, 340, 380)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemies = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active)


    Dim damval As New modValue(fulldamage, eModifierType.DamagePhysicalInflicted, occurencetime, aghstime)

    Dim thedamage As New Modifier(damval, unittargetenemies)
    outmods.Add(thedamage)




    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active)

    Dim deathval As New modValue(1, eModifierType.DestroysHero, occurencetime)

    Dim thedeath As New Modifier(deathval, notargetself)
    outmods.Add(thedeath)


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
