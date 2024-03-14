Public Class abStasis_Trap
  Inherits AbilityBase

  Public triggerradius As ValueWrapper
  Public triggerdelay As ValueWrapper
  Public stunduration As ValueWrapper
  Public trapactivationtime As ValueWrapper
  Public trapfadetime As ValueWrapper
  Public trapduration As ValueWrapper
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

    Notes = "Stasis Traps destroy all other Stasis Traps in their area of effect when they detonate.|Stasis Traps are not triggered by invisible units.|Theoretically, you can have 13/18/24/33 stasis traps at the same time before one expires (if you cast one straight away every time it's available).|Has a cast time of 1 second.|Traps have a 400/400 Sight Range.|Stasis Traps have 100 HP and 0 medium armor.|Will take a total of 5 seconds to detonate when placed directly on top of an enemy.|Stasis Traps will block neutral camps from spawning." '"

    mDisplayName = "Stasis Trap"
    mName = eAbilityName.abStasis_Trap
    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTechies

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False '

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/techies_stasis_trap_hp2.png"

    Description = "Plant an invisible trap that stuns nearby enemy units when triggered."

    ManaCost = New ValueWrapper(80, 110, 140, 160)

    Cooldown = New ValueWrapper(20, 16, 13, 10)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    triggerradius = New ValueWrapper(450, 450, 450, 450)

    triggerdelay = New ValueWrapper(2, 2, 2, 2)

    stunduration = New ValueWrapper(2.5, 3, 3.5, 4)

    trapactivationtime = New ValueWrapper(2, 2, 2, 2)
    
    trapfadetime = New ValueWrapper(2, 2, 2, 2)
   
    trapduration = New ValueWrapper(360, 360, 360, 360)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetenemies = Helpers.GetPointTargetEnemyUnitsInfo(theability_InfoID, _
                                                                  thecaster, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Active)

    Dim stunval As New modValue(stunduration, eModifierType.Stun, occurencetime, aghstime)
    stunval.mValueDuration = stunduration

    Dim thestun As New Modifier(stunval, pointtargetenemies)
    outmods.Add(thestun)

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
