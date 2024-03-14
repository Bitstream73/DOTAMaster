Public Class abFreezing_Field
Inherits AbilityBase
  Private ExplosionRadius As ValueWrapper
  Private moveslow As ValueWrapper ' 3
  Private attackslow As ValueWrapper ' 

  Private aghsdamage As New List(Of Double?)
  Private aghsmoveslow As New List(Of Double?) ' = -
  Private aghsattackslow As New List(Of Double?) ' = -
  Public Sub New()
    BlockedByMagicImmune = True
    RemovedByMagicImmune = True
    CanBePurged = False
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False
    PiercesSpellImmunity = False

    mDisplayName = "Freezing Field"

    Notes = "The slow is applied on all enemies in the radius, even if they aren't hit by an explosion (lasts 1 second).|Every 0.1 second an explosion occurs, for a total of 70 explosions.|The explosions occur around Crystal Maiden, and aren't based on the place of initial cast. The area of damage of the spell can thus be modified by using Force staff on Crystal Maiden."

    mName = eAbilityName.abFreezing_Field

    Me.EntityName = eEntity.abFreezing_Field

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untCrystal_Maiden

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = True 'Check This
    'mHasAghs = False

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/crystal_maiden_freezing_field_hp2.png"
    WebpageLink = ""
    Description = "CHANNELED - Surrounds Crystal Maiden with random icy explosions that slow enemies and deal massive damage. Lasts 7 seconds. Upgradable by Aghanim's Scepter."

    ManaCost = New ValueWrapper(200, 400, 600)

    Cooldown = New ValueWrapper(150, 120, 90)

    AbilityTypes.Add(eAbilityType.NoTarget)
    AbilityTypes.Add(eAbilityType.Channeled)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    Radius = New ValueWrapper(835, 835, 835)

    ExplosionRadius = New ValueWrapper(300, 300, 300)

    moveslow = New ValueWrapper(0.3, 0.3, 0.3)
    aghsmoveslow.Add(0.5)
    aghsmoveslow.Add(0.5)
    aghsmoveslow.Add(0.5)
    moveslow.LoadScepterValues(aghsmoveslow)

    attackslow = New ValueWrapper(30, 30, 30, 30)
    aghsattackslow.Add(50)
    aghsattackslow.Add(50)
    aghsattackslow.Add(50)
    attackslow.LoadScepterValues(aghsattackslow)

    Damage = New ValueWrapper(105, 170, 250)
    aghsdamage.Add(170)
    aghsdamage.Add(250)
    aghsdamage.Add(310)
    Damage.LoadScepterValues(aghsdamage)



    Duration = New ValueWrapper(10, 10, 10, 10)






  End Sub
  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList




    Dim channelenemiesinfo = Helpers.GetChanneledEnemyUnitsInfo(theability_InfoID, _
                                                                thecaster, _
                                                                 thetarget, _
                                                                 "", eModifierCategory.Active)

    Dim moveval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    moveval.mValueDuration = Duration
    moveval.mRadius = Radius

    Dim mmoveslow As New Modifier(moveval, channelenemiesinfo)
    outmods.Add(mmoveslow)


    Dim attslowval As New modValue(attackslow, eModifierType.AttackspeedSubtracted, occurencetime, aghstime)
    attslowval.mValueDuration = Duration
    attslowval.mRadius = Radius

    Dim attslow As New Modifier(attslowval, channelenemiesinfo)
    outmods.Add(attslow)



    Dim damval As New modValue(Me.Damage, eModifierType.DamageMagicalOverTimeInflicted, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)
    damval.mValueDuration = Duration
    damval.mRadius = Radius

    Dim damage As New Modifier(damval, channelenemiesinfo)
    outmods.Add(damage)



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
