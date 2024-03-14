Public Class abShadow_Shaman_Hex
  Inherits AbilityBase
  Public hexmovespeed As ValueWrapper

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

    mDisplayName = "Hex"
    mName = eAbilityName.abShadow_Shaman_Hex
    Me.EntityName = eEntity.abShadow_Shaman_Hex

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untShadow_Shaman

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/shadow_shaman_voodoo_hp2.png"

    Description = "Transforms an enemy unit into a harmless creature, disabling their attacks and abilities."

    ManaCost = New ValueWrapper(110, 140, 170, 200)

    Cooldown = New ValueWrapper(13, 13, 13, 13)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    Duration = New ValueWrapper(1.25, 2, 2.75, 3.5)

    hexmovespeed = New ValueWrapper(100, 100, 100, 100)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittaretenemy = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                              thecaster, _
                                                              thetarget, _
                                                              "", eModifierCategory.Active)

    Dim hexval As New modValue(1, eModifierType.Hex, occurencetime)
    hexval.mValueDuration = Duration

    Dim hexmod As New Modifier(hexval, unittaretenemy)
    outmods.Add(hexmod)

    'movespeed set
    Dim moveval As New modValue(hexmovespeed, eModifierType.MoveSpeedSet, occurencetime, aghstime)
    moveval.mValueDuration = Duration

    Dim movemod As New Modifier(moveval, unittaretenemy)
    outmods.Add(movemod)

    'evasion removed
    Dim evval As New modValue(Duration, eModifierType.EvasionRemoved, occurencetime, aghstime)
    evval.mValueDuration = Duration

    Dim evmod As New Modifier(evval, unittaretenemy)
    outmods.Add(evmod)

    'damageblock removed
    Dim blockval As New modValue(Duration, eModifierType.DamageBlockRemoved, occurencetime, aghstime)
    blockval.mValueDuration = Duration

    Dim blockmod As New Modifier(blockval, unittaretenemy)
    outmods.Add(blockmod)

    'ability mute
    Dim abval As New modValue(Duration, eModifierType.MuteAbilities, occurencetime, aghstime)
    abval.mValueDuration = Duration

    Dim abmod As New Modifier(abval, unittaretenemy)
    outmods.Add(abmod)

    'itemmute
    Dim itval As New modValue(Duration, eModifierType.MuteItems, occurencetime, aghstime)
    itval.mValueDuration = Duration

    Dim itmod As New Modifier(itval, unittaretenemy)
    outmods.Add(itmod)

    'rightclick mute
    Dim rval As New modValue(Duration, eModifierType.MuteAttacks, occurencetime, aghstime)
    rval.mValueDuration = Duration

    Dim rmod As New Modifier(rval, unittaretenemy)
    outmods.Add(rmod)

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
