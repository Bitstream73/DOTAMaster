Public Class abTimber_Chain
  Inherits AbilityBase

  Private mSpeed As ValueWrapper
  Public latchrange As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False ''
    PiercesSpellImmunity = False

    Notes = "The chain's tip searches for a tree in a 90 unit radius around it.|Destroys the target tree once Timbersaw arrives.|Can be used to pull Timbersaw across impassable terrain.|The hook always travels to its maximum range or until it connects with a tree.|Timbersaw will stop being pulled if he is disabled at any point during Timber Chain.|If Timbersaw is disabled before the chain starts pulling, the chain will pull him for a very short distance, enough to still cause damage around him to nearby units.|Timbersaw can cast spells and items during the pull, but cannot attack.|The chain provides small vision around itself while traveling, and a bit larger vision once reaching max distance or connecting with a tree.|When Timbersaw get's cycloned before the hook starts pulling him, the cyclone gets canceled once the hook starts pulling. However, if he gets cycloned during the pull, the hook gets canceled instead." '

    mDisplayName = "Timber Chain"
    mName = eAbilityName.abTimber_Chain
    Me.EntityName = eEntity.abTimber_Chain

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTimbersaw

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False '

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/shredder_timber_chain_hp2.png"

    Description = "Timbersaw fires a chain that embeds itself in the first tree it hits, pulling him towards it. Any enemy in the path takes damage."

    ManaCost = New ValueWrapper(60, 70, 80, 90)

    Cooldown = New ValueWrapper(4, 4, 4, 4)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Pure


    latchrange = New ValueWrapper(850, 1050, 1250, 1450)

    Radius = New ValueWrapper(225, 225, 225, 225)

    mSpeed = New ValueWrapper(1600, 2000, 2400, 2800)

    Damage = New ValueWrapper(100, 140, 180, 220)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim lineenemyunits = Helpers.GetPointTargetLineEnemyUnitsInfo(theability_InfoID, _
                                                              thecaster, _
                                                              thetarget, _
                                                              "", eModifierCategory.Active)

    Dim damval As New modValue(Me.Damage, eModifierType.DamagePureAdded, occurencetime, aghstime)

    Dim damage As New Modifier(damval, lineenemyunits)
    outmods.Add(damage)




    Dim unittargetnothingself = Helpers.GetUnitTreeSelfInfo(theability_InfoID, _
                                                              thecaster, _
                                                              thetarget, _
                                                              "", eModifierCategory.Active)


    Dim valpull As New modValue(1, eModifierType.PullForward, occurencetime)
    valpull.mRange = latchrange

    Dim modpull As New Modifier(valpull, unittargetnothingself)
    outmods.Add(modpull)

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
