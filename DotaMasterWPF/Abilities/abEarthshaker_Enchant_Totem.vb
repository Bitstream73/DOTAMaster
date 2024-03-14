Public Class abEnchant_Totem
Inherits AbilityBase
  Public bonus As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = True '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Only increases base damage and additional damage given by the primary attribute.|Bonus damage buff is used on successful landed attack." '"

    mDisplayName = "Enchant Totem"
    mName = eAbilityName.abEnchant_Totem
    Me.EntityName = eEntity.abEnchant_Totem

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untEarthshaker

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/earthshaker_enchant_totem_hp2.png"

    Description = "Empowers Earthshaker's totem, causing it to deal extra damage on the next attack."

    ManaCost = New ValueWrapper(20, 30, 40, 50)

    Cooldown = New ValueWrapper(5, 5, 5, 5)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    bonus = New ValueWrapper(1, 2, 3, 4)


    Duration = New ValueWrapper(14, 14, 14, 14)



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


    Dim bonusval As New modValue(bonus, eModifierType.RightClickDamageMultiplier, occurencetime, aghstime)
    bonusval.mValueDuration = Duration
    bonusval.Charges = New ValueWrapper(1, 1, 1, 1)

    Dim bonusdamage As New Modifier(bonusval, notargetself)
    outmods.Add(bonusdamage)



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
