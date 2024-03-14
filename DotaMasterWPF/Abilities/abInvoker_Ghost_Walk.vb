Public Class abGhost_Walk
Inherits AbilityBase
  Public enmymoveslowperQuas As ValueWrapper
  Public selfmoveslowperwex As ValueWrapper
  Public selfmovespeedperwex As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = False
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Ghost Walk does not interrupt Invoker's channeling spells upon cast.|The movement speed slow on the enemies is provided by an aura. Its debuff lingers for 2 seconds.|The slow debuff places some particles on the affected units, allowing them to know that Invoker is nearby.|Invisibility is broken upon reaching the cast point of spells or items, or upon launching an attack.|Ghost Walk allows Invoker to path through other units, including wards but not buildings.|Invoker can pick up or drop items without breaking the invisibility."

    mDisplayName = "Ghost Walk"
    mName = eAbilityName.abGhost_Walk
    Me.EntityName = eEntity.abGhost_Walk

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untInvoker

    mAbilityPosition = -1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/invoker_ghost_walk_hp2.png"

    Description = "Invoker manipulates the ice and electrical energies around him, rendering his body invisible. The elemental imbalance created as a consequence slows nearby enemies based on the level of Quas, and slows Invoker as well based on the level of Wex."

    ManaCost = New ValueWrapper(200, 200, 200, 200, 200, 200, 200)

    Cooldown = New ValueWrapper(35, 35, 35, 35, 35, 35, 35)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    enmymoveslowperQuas = New ValueWrapper(0.2, 0.25, 0.3, 0.35, 0.4, 0.45, 0.5)
    selfmoveslowperwex = New ValueWrapper(0.3, 0.2, 0.1, -1, -1, -1, -1)
    selfmovespeedperwex = New ValueWrapper(-1, -1, -1, -1, 0.1, 0.2, 0.3)

    Duration = New ValueWrapper(100, 100, 100, 100, 100, 100, 100)
    Radius = New ValueWrapper(400, 400, 400, 400, 400, 400, 400)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                    thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                    ftarget As iDisplayUnit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList



    Dim outmods As New ModifierList

    Dim notargetslef = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Active)

    Dim invisval As New modValue(Duration, eModifierType.Invisibility, occurencetime, aghstime)

    Dim invismod As New Modifier(invisval, notargetslef)
    outmods.Add(invismod)


    Dim enmoveval As New modValue(enmymoveslowperQuas, eModifierType.QuasMoveSpeedPercentChange, occurencetime, aghstime)
    enmoveval.mValueDuration = Duration
    enmoveval.mRadius = Radius

    Dim enmovemod As New Modifier(enmoveval, notargetslef)
    outmods.Add(enmovemod)


    Dim selfmoveval As New modValue(selfmoveslowperwex, eModifierType.WexMoveSpeedPercentChangeSubtracted, occurencetime, aghstime)
    selfmoveval.mValueDuration = Duration
    selfmoveval.mRadius = Radius

    Dim selfmod As New Modifier(selfmoveval, notargetslef)
    outmods.Add(selfmod)


    Dim selfmovespeedval As New modValue(selfmovespeedperwex, eModifierType.WexMoveSpeedPercentChangeAdded, occurencetime, aghstime)
    selfmovespeedval.mValueDuration = Duration
    selfmovespeedval.mRadius = Radius

    Dim selfspmod As New Modifier(selfmovespeedval, notargetslef)
    outmods.Add(selfspmod)

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
