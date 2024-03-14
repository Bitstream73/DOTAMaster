Public Class abGods_Strength
Inherits AbilityBase
  Public bonusdamage As ValueWrapper

  Public allyauraradius As ValueWrapper
  Public scepterallyauraeradius As New List(Of Double?)

  Public allybonusdamage As ValueWrapper
  Public scepterallybonusdamage As New List(Of Double?)
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

    Notes = "Only increases base damage and that given by the primary attribute of Sven. Raw bonus damage is not increased.|Aghanim's Scepter's aura bonus damage of 40%/60%/80% based on base damage and primary attribute of those affected.|Sven's and the affected allies' current main damage is periodically checked, and the bonuses adapted instantly.|The buff from the aura for allies lingers for 0.5 seconds." '"

    mDisplayName = "Gods Strength"
    mName = eAbilityName.abGods_Strength
    Me.EntityName = eEntity.abGods_Strength

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSven

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = True '

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/sven_gods_strength_hp2.png"

    Description = "Sven channels his rogue strength, granting bonus damage for 25 seconds."

    ManaCost = New ValueWrapper(100, 150, 200)


    Cooldown = New ValueWrapper(80, 80, 80)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    Duration = New ValueWrapper(25, 25, 25)

    bonusdamage = New ValueWrapper(1, 1.5, 2)

    allyauraradius = New ValueWrapper(-1, -1, -1)
    scepterallyauraeradius.Add(900)
    scepterallyauraeradius.Add(900)
    scepterallyauraeradius.Add(900)
    allyauraradius.LoadScepterValues(scepterallyauraeradius)

    allybonusdamage = New ValueWrapper(-1, -1, -1)
    scepterallybonusdamage.Add(0.5)
    scepterallybonusdamage.Add(0.75)
    scepterallybonusdamage.Add(1)
    allybonusdamage.LoadScepterValues(scepterallybonusdamage)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList



    Dim notargetallies = Helpers.GetNoTargetAlliedHeroesInfo(theability_InfoID, _
                                                             thecaster, _
                                                             thetarget, _
                                                             "", eModifierCategory.Active)

    Dim allybonusval As New modValue(allybonusdamage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)
    allybonusval.mValueDuration = Duration

    Dim theallybonus As New Modifier(allybonusval, notargetallies)
    outmods.Add(theallybonus)




    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                             thecaster, _
                                                             thetarget, _
                                                             "", eModifierCategory.Active)




    Dim svenbonusval As New modValue(bonusdamage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)
    svenbonusval.mValueDuration = Duration

    Dim svenbonus As New Modifier(svenbonusval, notargetself)
    outmods.Add(svenbonus)


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
