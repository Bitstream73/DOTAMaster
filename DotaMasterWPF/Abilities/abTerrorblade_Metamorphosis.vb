Public Class abMetamorphosis
Inherits AbilityBase
  Public transformtime As ValueWrapper
  Public baseattacktime As ValueWrapper
  Public Attackrange As ValueWrapper
  Public BonusDamage As ValueWrapper
  Public movespeedloss As ValueWrapper
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

    mDisplayName = "Metamorphosis"
    mName = eAbilityName.abMetamorphosis
    Me.EntityName = eEntity.abMetamorphosis

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTerrorblade

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/terrorblade_metamorphosis_hp2.png"

    Description = "Terrorblade transforms into a powerful demon with a ranged attack."

    ManaCost = New ValueWrapper(50, 50, 50, 50)

    Cooldown = New ValueWrapper(140, 140, 140, 140)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    Duration = New ValueWrapper(40, 44, 48, 52)

    transformtime = New ValueWrapper(0.35, 0.35, 0.35, 0.35)

    baseattacktime = New ValueWrapper(1.6, 1.6, 1.6, 1.6)

    Attackrange = New ValueWrapper(550, 550, 550, 550)

    BonusDamage = New ValueWrapper(20, 40, 60, 80)

    movespeedloss = New ValueWrapper(25, 25, 25, 25)

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

    'base attack time
    Dim baseval As New modValue(baseattacktime, eModifierType.BaseAttackTimeChangedTo, occurencetime, aghstime)
    baseval.mValueDuration = Duration

    Dim basemod As New Modifier(baseval, notargetself)
    outmods.Add(basemod)

    'bonus damage
    Dim damval As New modValue(BonusDamage, eModifierType.RightClickBonusDamageAdded, occurencetime, aghstime)
    damval.mValueDuration = Duration

    Dim dammod As New Modifier(damval, notargetself)
    outmods.Add(dammod)

    'move speed
    Dim moveval As New modValue(movespeedloss, eModifierType.MoveSpeedSubtracted, occurencetime, aghstime)
    moveval.mValueDuration = Duration

    Dim movemod As New Modifier(moveval, notargetself)
    outmods.Add(movemod)


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
