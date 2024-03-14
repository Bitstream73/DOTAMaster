Public Class abMulticast
  Inherits AbilityBase



  Public fireblastmanaincrease As ValueWrapper
  Public fireblastcoolreduct As ValueWrapper
  Public igniteradius As ValueWrapper
  Public ignitecastrangeadded As ValueWrapper
  Public bloodlustRadius As ValueWrapper
  Public bloodlustcoolreduct As ValueWrapper
  Public twoxchance As ValueWrapper
  Public threexchance As ValueWrapper
  Public fourxchance As ValueWrapper

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

    mDisplayName = "Multicast"
    mName = eAbilityName.abMulticast
    Me.EntityName = eEntity.abMulticast

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untOgre_Magi

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/ogre_magi_multicast_hp2.png"

    Description = "Enables the Ogre Magi to rapidly cast his spells, giving them greater potency. Gives a chance to cast a spell multiple times in one cast. Increases Fireblast's mana cost and decreases its cooldown, adds an area of effect to Ignite and reduces Bloodlust's cooldown and gives it a chance to cast on random allies around Ogre Magi. Upgradable by Aghanim's Scepter."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    fireblastmanaincrease = New ValueWrapper(20, 40, 60)
    fireblastcoolreduct = New ValueWrapper(2, 4, 6)
    igniteradius = New ValueWrapper(150, 300, 450)
    ignitecastrangeadded = New ValueWrapper(150, 300, 450)

    bloodlustRadius = New ValueWrapper(575, 575, 575)
    bloodlustcoolreduct = New ValueWrapper(5, 10, 15)

    twoxchance = New ValueWrapper(0.4, 0.5, 0.6)
    threexchance = New ValueWrapper(-1, 0.2, 0.25)
    fourxchance = New ValueWrapper(-1, -1, 0.125)



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

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                       theowner, _
                                                       thetarget, _
                                                       "", eModifierCategory.Passive)

    Dim firemanaval As New modValue(fireblastmanaincrease, eModifierType.MulticastFireblastManaAdded, occurencetime, aghstime)

    Dim firemanmod As New Modifier(firemanaval, notargetself)
    outmods.Add(firemanmod)


    Dim firecoolval As New modValue(fireblastcoolreduct, eModifierType.MulticastFireblastCoolReduction, occurencetime, aghstime)

    Dim firecoolmod As New Modifier(firecoolval, notargetself)
    outmods.Add(firecoolmod)


    Dim ingniteradiusval As New modValue(igniteradius, eModifierType.MulticastIgniteRadius, occurencetime, aghstime)

    Dim ingnitradiusmod As New Modifier(ingniteradiusval, notargetself)
    outmods.Add(ingnitradiusmod)


    Dim ignitecastval As New modValue(ignitecastrangeadded, eModifierType.MulticastIgniteCastRangeAdded, occurencetime, aghstime)

    Dim ignitecastmod As New Modifier(ignitecastval, notargetself)
    outmods.Add(ignitecastmod)


    Dim bloodradval As New modValue(bloodlustRadius, eModifierType.MulticastBloodlustRadiusAdded, occurencetime, aghstime)

    Dim bloodradmod As New Modifier(bloodradval, notargetself)
    outmods.Add(bloodradmod)


    Dim bloodcoolval As New modValue(bloodlustcoolreduct, eModifierType.MulticastBloodlustCoolReduction, occurencetime, aghstime)

    Dim bloodcoolmod As New Modifier(bloodcoolval, notargetself)
    outmods.Add(bloodcoolmod)


    Dim twoxval As New modValue(twoxchance, eModifierType.MulticastTwoXChance, occurencetime, aghstime)

    Dim twoxmod As New Modifier(twoxval, notargetself)
    outmods.Add(twoxmod)


    Dim threex As New modValue(threexchance, eModifierType.MulticastThreeXChance, occurencetime, aghstime)

    Dim threexmod As New Modifier(threex, notargetself)
    outmods.Add(threexmod)


    Dim fourxval As New modValue(fourxchance, eModifierType.MulticastFourXChance, occurencetime, aghstime)

    Dim fourxmod As New Modifier(fourxval, notargetself)
    outmods.Add(fourxmod)


    Return outmods
  End Function
End Class
