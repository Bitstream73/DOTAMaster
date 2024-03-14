Public Class abIlluminate
Inherits AbilityBase
  Public damagepersec As ValueWrapper

  Public mindamage As ValueWrapper
  Public maxdamage As ValueWrapper

  Public allyminheal As ValueWrapper
  Public scepterallyminheal As New List(Of Double?)

  Public allymaxheal As ValueWrapper
  Public scepterallymaxheal As New List(Of Double?)

  Public maxchanneltime As ValueWrapper
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

    mDisplayName = "Illuminate"
    mName = eAbilityName.abIlluminate

    Me.EntityName = eEntity.abIlluminate

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untKeeper_of_the_Light

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/keeper_of_the_light_illuminate_hp2.png"

    Description = "Channels a ball of light energy, building power the longer it's channeled. Once released, the ball deals damage and gives vision in a line. The longer it is channeled, the more damage is dealt. Upgradable by Aghanim's Scepter, allowing Illuminate to heal allies for 75% of its damage values during daytime."

    ManaCost = New ValueWrapper(150, 160, 170, 180)


    Cooldown = New ValueWrapper(10, 10, 10, 10)

    AbilityTypes.Add(eAbilityType.Channeled)
    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    maxchanneltime = New ValueWrapper(2, 3, 4, 5)

    damagepersec = New ValueWrapper(100, 100, 100, 100)

    mindamage = damagepersec
    maxdamage = New ValueWrapper(damagepersec.Value(0) * maxchanneltime.Value(0), _
                                 damagepersec.Value(1) * maxchanneltime.Value(1), _
                                 damagepersec.Value(2) * maxchanneltime.Value(2), _
                                 damagepersec.Value(3) * maxchanneltime.Value(3))

    allyminheal = New ValueWrapper(-1, -1, -1, -1)
    scepterallyminheal.Add(damagepersec.Value(0) * 0.75)
    scepterallyminheal.Add(damagepersec.Value(1) * 0.75)
    scepterallyminheal.Add(damagepersec.Value(2) * 0.75)
    scepterallyminheal.Add(damagepersec.Value(3) * 0.75)
    allyminheal.LoadScepterValues(scepterallyminheal)


    allymaxheal = New ValueWrapper(-1, -1, -1, -1)
    scepterallymaxheal.Add(maxdamage.Value(0) * 0.75)
    scepterallymaxheal.Add(maxdamage.Value(1) * 0.75)
    scepterallymaxheal.Add(maxdamage.Value(2) * 0.75)
    scepterallymaxheal.Add(maxdamage.Value(3) * 0.75)
    allymaxheal.LoadScepterValues(scepterallymaxheal)

    Radius = New ValueWrapper(350, 350, 350, 350)

    Range = New ValueWrapper(1550, 1550, 1550, 1500)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim coneenemies = Helpers.GetConeEnemyUnitsInfo(theability_InfoID, _
                                                    thecaster, _
                                                    thetarget, _
                                                    "", eModifierCategory.Active)

    Dim coneallies = Helpers.GetConeAlliedUnitsInfo(theability_InfoID, _
                                                    thecaster, _
                                                    thetarget, _
                                                    "", eModifierCategory.Active)


    Dim damval As New modValue(maxdamage, eModifierType.DamageMagicalMinMaxInflicted, occurencetime, aghstime)
    damval.mValueMax = maxdamage
    damval.mValueMin = mindamage

    Dim dammod As New Modifier(damval, coneenemies)
    outmods.Add(dammod)

    'scepter ally heal
    Dim healval As New modValue(allymaxheal, eModifierType.HealMinMaxAdded, occurencetime, aghstime)
    healval.mValueMax = allymaxheal
    healval.mValueMin = allyminheal

    Dim healmod As New Modifier(healval, coneallies)
    outmods.Add(healmod)

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
