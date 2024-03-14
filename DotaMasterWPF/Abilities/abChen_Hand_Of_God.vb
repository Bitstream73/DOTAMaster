Public Class abHand_Of_God
Inherits AbilityBase


  Public sceptercooldown As New List(Of Double?)
  Public heal As ValueWrapper

  'the number of ancients contrallable by holy pursuasion is determined by scepter and hand of god level
  Public ancientcount As ValueWrapper
  Public scepterancientcount As New List(Of Double?)
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
    mDisplayName = "Hand of God"
    mName = eAbilityName.abHand_Of_God
    Me.EntityName = eEntity.abHand_Of_God


    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untChen

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/chen_hand_of_god_hp2.png"

    Description = "Fully regenerates any creeps under Chen's control and heals all allied heroes on the map. Upgradable by Aghanim's Scepter."


    ManaCost = New ValueWrapper(200, 300, 400)

    Cooldown = New ValueWrapper(160, 140, 120)
    sceptercooldown.Add(30)
    sceptercooldown.Add(30)
    sceptercooldown.Add(30)
    Cooldown.LoadScepterValues(sceptercooldown)



    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untAlliedTeam)


    heal = New ValueWrapper(200, 300, 400)

    ancientcount = New ValueWrapper(-1, -1, -1)
    scepterancientcount.Add(1)
    scepterancientcount.Add(2)
    scepterancientcount.Add(3)
    ancientcount.LoadScepterValues(scepterancientcount)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                  thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                  ftarget As iDisplayUnit, _
                                                  isfriendbias As Boolean, _
                                                  occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                                              thecaster, _
                                                                              thetarget, _
                                                                              "", eModifierCategory.Active)

    Dim notargetalliedheroes = Helpers.GetNoTargetAlliedHeroesInfo(theability_InfoID, _
                                                                              thecaster, _
                                                                              thetarget, _
                                                                              "", eModifierCategory.Active)

    'creep heal
    Dim creepval As New modValue(1, eModifierType.ChenCreepFullHeal, occurencetime)

    Dim creepmod As New Modifier(creepval, notargetself)
    outmods.Add(creepmod)


    ' hero heal
    Dim healval As New modValue(heal, eModifierType.HealAdded, occurencetime, aghstime)

    Dim selfheal As New Modifier(healval, notargetself)
    outmods.Add(selfheal)

    Dim heroesheal As New Modifier(healval, notargetalliedheroes)
    outmods.Add(heroesheal)



    Return outmods
  End Function

  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                theowner As iDisplayUnit, _
                                                thetarget As iDisplayUnit, _
                                                ftarget As iDisplayUnit, _
                                                isfriendbias As Boolean, _
                                                occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                                              theowner, _
                                                                              thetarget, _
                                                                              "", eModifierCategory.Active)

    'ancients
    Dim ancval As New modValue(ancientcount, eModifierType.ChenAncientCount, occurencetime, aghstime)

    Dim ancmod As New Modifier(ancval, notargetself)
    outmods.Add(ancmod)


    Return outmods
  End Function
End Class
