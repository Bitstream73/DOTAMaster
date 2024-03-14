Public Class abNecro_Archer_Archer_Aura
  Inherits AbilityBase


  Public movebonus As ValueWrapper
  Public attbonus As ValueWrapper

  Public Sub New()
    BlockedByMagicImmune = False
    RemovedByMagicImmune = False
    CanBePurged = False
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False

    PiercesSpellImmunity = False

    mDisplayName = "Archer Aura"
    mName = eAbilityName.abNecro_Archer_Archer_Aura
    Me.EntityName = eEntity.abNecro_Archer_Archer_Aura

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untNecro_Archer

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False
    'mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/5/50/Archer_Aura_%28Necronomicon_Archer%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Necronomicon#Necronomicon_Archer"
    Description = "Increases movement and attack speed of nearby units."
    Notes = "Fully stacks with other sources of movement and attack speed, except for other Archer Auras.|The aura 's buff lingers for 0.5 seconds."

    'mManaCost = New ValueWrapper()

    'mCooldown = New ValueWrapper()

    AbilityTypes.Add(eAbilityType.PassiveAura)

    Affects.Add(eUnit.untAlliedUnits)
    '    mAffects.Add(eUnit)

    'mDuration = New ValueWrapper()
    Radius = New ValueWrapper(900, 900, 900)

    movebonus = New ValueWrapper(0.03, 0.06, 0.09)
    attbonus = New ValueWrapper(3, 6, 9)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Return Nothing
  End Function

  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, caster As iDisplayUnit, target As iDisplayUnit, ftarget As iDisplayUnit, isfriendbias As Boolean, occurencetime As Lifetime, aghstime As Lifetime) As modifierlist

    Dim outmods As New ModifierList



    Dim notargetallies = Helpers.GetPassiveAuraAlliedUnitsInfo(theability_InfoID, _
                                                                             caster, _
                                                                             target, _
                                                                             "", eModifierCategory.Active)

    Dim moveval As New modValue(movebonus, eModifierType.MoveSpeedPercentAdded, occurencetime, aghstime)
    moveval.mRadius = Radius

    Dim movemod As New Modifier(moveval, notargetallies)
    outmods.Add(movemod)


    Dim attval As New modValue(attbonus, eModifierType.AttackSpeedAdded, occurencetime, aghstime)
    attval.mRadius = Radius

    Dim attmod As New Modifier(attval, notargetallies)

    Return outmods
  End Function
End Class
