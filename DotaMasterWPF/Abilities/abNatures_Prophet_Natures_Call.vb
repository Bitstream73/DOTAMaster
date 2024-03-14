Public Class abNatures_Call
Inherits AbilityBase
  Public treantcount As ValueWrapper

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

    mDisplayName = "Nature's Call"
    mName = eAbilityName.abNatures_Call
    Me.EntityName = eEntity.abNatures_Call

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untNatures_Prophet

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/furion_force_of_nature_hp2.png"

    Description = "Converts an area of trees into Treants. Treants have 550 hit points and deal 21-23 damage."


    ManaCost = New ValueWrapper(160, 160, 160, 160)

    Cooldown = New ValueWrapper(37, 37, 37, 37)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)


    Duration = New ValueWrapper(60, 60, 60, 60)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargettree = Helpers.GetPointTargetSelfInfo(theability_InfoID, _
                                                         thecaster, _
                                                         thetarget, _
                                                         "", eModifierCategory.Active)


    'Dim treant As New HeroPet_Info

    'treant.hitpoints = New ValueWrapper(550, 550, 550, 550)

    'treant.HealthRegen = New ValueWrapper(0.5, 0.5, 0.5, 0.5)

    'treant.DamageHigh = New ValueWrapper(23, 23, 23, 23)
    'treant.DamageLow = New ValueWrapper(21, 21, 21, 21)

    'treant.movementspeed = New ValueWrapper(300, 300, 300, 300)

    'treant.SightRange.Add(New ValueWrapper(1200, 1200, 1200, 1200))
    'treant.SightRange.Add(New ValueWrapper(800, 800, 800, 800))

    'treant.BaseAttackSpeed = New ValueWrapper(1.75, 1.75, 1.75, 1.75)

    'treant.bounty = New ValueWrapper(20, 20, 20, 20)

    'treant.xpvalue = New ValueWrapper(30, 30, 30, 30)


    Dim treantval As New modValue(treantcount, eModifierType.petTreant, occurencetime, aghstime)
    treantval.mValueDuration = Duration

    Dim treantmod As New Modifier(treantval, unittargettree)
    outmods.Add(treantmod)


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
