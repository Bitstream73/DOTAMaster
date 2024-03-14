Public Class abSpirit_Lance
  Inherits AbilityBase
  Public moveslow As ValueWrapper
  Public slowduration As ValueWrapper
  Public illduration As ValueWrapper
  Public illdamage As ValueWrapper
  Public illdamagetaken As ValueWrapper

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

    mDisplayName = "Spirit Lance"
    mName = eAbilityName.abSpirit_Lance

    Me.EntityName = eEntity.abSpirit_Lance

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untPhantom_Lancer

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/phantom_lancer_doppelwalk_hp2.png"

    Description = "Renders Phantom Lancer invisible, while generating a duplicate image to confuse enemies."

    ManaCost = New ValueWrapper(125, 130, 135, 140)
    Cooldown = New ValueWrapper(7, 7, 7, 7)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untEnemyUnit)

    DamageType = eDamageType.Magical

    Range = New ValueWrapper(750, 750, 750, 750)

    Damage = New ValueWrapper(100, 150, 200, 250)

    mUniqueStats = New List(Of ValueWrapper)

    moveslow = New ValueWrapper(10, 20, 30, 40)
    moveslow.Description = "Movement Slow"
    mUniqueStats.Add(moveslow)

    slowduration = New ValueWrapper(3.25, 3.25, 3.25, 3.25)
    slowduration.Description = "Slow Duration"
    mUniqueStats.Add(slowduration)

    illduration = New ValueWrapper(2, 4, 6, 8)
    illduration.Description = "Illusion Duration"
    mUniqueStats.Add(illduration)

    illdamage = New ValueWrapper(0.2, 0.2, 0.2, 0.2)
    illdamage.Description = "Illusion Damage"
    mUniqueStats.Add(illdamage)

    illdamagetaken = New ValueWrapper(4, 4, 4, 4)
    illdamage.Description = "Illusion Damage Taken"
    mUniqueStats.Add(illdamage)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList


    Dim unittargetenemy = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, unittargetenemy)
    outmods.Add(dammod)


    Dim slowval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    slowval.mValueDuration = slowduration

    Dim slowmod As New Modifier(slowval, unittargetenemy)
    outmods.Add(slowmod)


    Dim illdamval As New modValue(illdamage, eModifierType.RightClickDamagePercentInflicted, occurencetime, aghstime)
    illdamval.mValueDuration = illduration

    Dim illmod As New Modifier(illdamval, unittargetenemy)
    outmods.Add(illmod)

    ' Dim pa As HeroPet_Info
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
