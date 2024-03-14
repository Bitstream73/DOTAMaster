Public Class abOvercharge
  Inherits AbilityBase
  Public attackspeed As ValueWrapper
  Public incomingdamagereductiona As ValueWrapper
  Public healthmanadrain As ValueWrapper
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

    Notes = "Io cannot deny itself with this ability.|A tethered ally benifits from the incoming damage reduction and attack speed, but only Io pays the drain in hp and mana.|Drains 0.9% of current hp and mana in 0.2 second intervals.|Io and the tethered ally's effective health will be increased by 5.26%/11.11%/17.65%/25% (This will quickly diminish for Io because of the health loss).|Will drain 4.5% of CURRENT health and mana. With this in mind, by building enough HP and mana regeneration, it will arrive at a certain percentage where it can not further drain any HP or mana." '"

    mDisplayName = "Overcharge"
    mName = eAbilityName.abOvercharge
    Me.EntityName = eEntity.abOvercharge

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untIo

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/wisp_overcharge_hp2.png"

    Description = "Io gains bonus attack speed and damage reduction, at the cost of draining HP and mana per second. If Io is Tethered to an ally, that unit also gains the bonuses."



    Cooldown = New ValueWrapper(2, 2, 2, 2)

    AbilityTypes.Add(eAbilityType.NoTarget)
    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)
    attackspeed = New ValueWrapper(40, 50, 60, 70)

    incomingdamagereductiona = New ValueWrapper(0.05, 0.1, 0.15, 0.2)

    healthmanadrain = New ValueWrapper(0.045, 0.045, 0.045, 0.045)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargettoggleself = Helpers.GetToggleSelfInfo(theability_InfoID, _
                                                       thecaster, _
                                                       thetarget, _
                                                       "", eModifierCategory.Active)

    Dim unittargetalliedunit = Helpers.GetUnitTargetAlliedUnitInfo(theability_InfoID, _
                                                       thecaster, _
                                                       thetarget, _
                                                       "", eModifierCategory.Active)


    'att speed and damage reduction for ally and self
    Dim attval As New modValue(attackspeed, eModifierType.AttackSpeedAdded, occurencetime, aghstime)

    Dim theattackspeedself As New Modifier(attval, notargettoggleself)
    outmods.Add(theattackspeedself)

    Dim theattspeedally As New Modifier(attval, unittargetalliedunit)
    outmods.Add(theattspeedally)


    Dim damval As New modValue(incomingdamagereductiona, eModifierType.DamageReduction, occurencetime, aghstime)

    Dim thedamagereductself As New Modifier(damval, notargettoggleself)
    outmods.Add(thedamagereductself)

    Dim damreductally As New Modifier(damval, unittargetalliedunit)
    outmods.Add(damreductally)




    'self mana and health drain
    Dim healthvalself As New modValue(healthmanadrain, eModifierType.HPRegenSubtracted, occurencetime, aghstime)

    Dim thehealthdrain As New Modifier(healthvalself, notargettoggleself)
    outmods.Add(thehealthdrain)



    Dim manaval As New modValue(healthmanadrain, eModifierType.ManaRegenSubtracted, occurencetime, aghstime)

    Dim themanadrain As New Modifier(manaval, notargettoggleself)
    outmods.Add(themanadrain)




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
