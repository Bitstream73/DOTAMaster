Public Class abEcho_Stomp
Inherits AbilityBase
  Public casttime As ValueWrapper
  Public sleepduration As ValueWrapper

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

    mDisplayName = "Echo Stomp"
    mName = eAbilityName.abEcho_Stomp
    Me.EntityName = eEntity.abEcho_Stomp

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untElder_Titan

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/elder_titan_echo_stomp_hp2.png"

    Description = "Elder Titan and his Astral Spirit both stomp the ground, damaging and knocking nearby enemy units unconscious around their locations. The Elder Titan stomp deals physical damage, while the Spirit stomp deals magical damage. Unconscious enemies will wake if they take damage."

    ManaCost = New ValueWrapper(100, 100, 100, 100)

    Cooldown = New ValueWrapper(15, 15, 15, 15)

    AbilityTypes.Add(eAbilityType.NoTarget)
    AbilityTypes.Add(eAbilityType.Channeled)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Physical

    casttime = New ValueWrapper(1.8, 1.8, 1.8, 1.8)

    Radius = New ValueWrapper(475, 475, 475, 475)

    sleepduration = New ValueWrapper(2, 3, 4, 5)

    Damage = New ValueWrapper(80, 90, 100, 110)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim chenneledauraenemies = Helpers.GetChanneledEnemyUnitsInfo(theability_InfoID, _
                                                                  thecaster, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Active)

    'Titan damage
    Dim damval As New modValue(Damage, eModifierType.DamagePhysicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, chenneledauraenemies)
    outmods.Add(dammod)

    'spirit damage
    Dim damspival As New modValue(Damage, eModifierType.DamageMagicalAdded, occurencetime, aghstime)

    Dim damspimod As New Modifier(damspival, chenneledauraenemies)
    outmods.Add(damspimod)


    Dim sleepval As New modValue(sleepduration, eModifierType.Sleep, occurencetime, aghstime)
    sleepval.mValueDuration = sleepduration

    Dim sleepmod As New Modifier(sleepval, chenneledauraenemies)
    outmods.Add(sleepmod)

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
