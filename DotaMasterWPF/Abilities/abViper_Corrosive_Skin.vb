Public Class abCorrosive_Skin
Inherits AbilityBase

  Public moveslow As ValueWrapper
  Public attslow As ValueWrapper

  Public magicresist As ValueWrapper
  Public dot As ValueWrapper


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

    mDisplayName = "Corrosive Skin"
    mName = eAbilityName.abCorrosive_Skin
    Me.EntityName = eEntity.abCorrosive_Skin

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untViper

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/viper_corrosive_skin_hp2.png"

    Description = "Viper exudes an infectious toxin that damages and slows any enemy that damages it. The acid exudate also increases Viper's resistance to spells."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical


    Duration = New ValueWrapper(4, 4, 4, 4)

    moveslow = New ValueWrapper(0.1, 0.15, 0.2, 0.25)

    attslow = New ValueWrapper(10, 15, 20, 25)

    magicresist = New ValueWrapper(0.1, 0.15, 0.2, 0.25)

    dot = New ValueWrapper(10, 15, 20, 25)

    Range = New ValueWrapper(1400, 1400, 1400, 1400)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return Nothing
  End Function


  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   theowner As idisplayunit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As modifierlist


    Dim outmods As New ModifierList

    Dim attackingenemey = Helpers.GetNoTargetAttackingEnemyUnitInfo(theability_InfoID, _
                                                                    theowner, _
                                                                    thetarget, _
                                                                    "", eModifierCategory.Active)

    'move slow
    Dim moveval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    moveval.mValueDuration = Duration

    Dim movemod As New Modifier(moveval, attackingenemey)
    outmods.Add(movemod)


    'att slow
    Dim attval As New modValue(attslow, eModifierType.AttackspeedSubtracted, occurencetime, aghstime)
    attval.mValueDuration = Duration

    Dim attmod As New Modifier(attval, attackingenemey)
    outmods.Add(attmod)

    'dot
    Dim dotval As New modValue(dot, eModifierType.DamageMagicalOverTimeInflicted, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)
    dotval.mValueDuration = Duration

    Dim dotmod As New Modifier(dotval, attackingenemey)
    outmods.Add(dotmod)


    'magic resistance
    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                   theowner, _
                                                   thetarget, _
                                                   "", eModifierCategory.Passive)

    Dim magval As New modValue(magicresist, eModifierType.MagicResistancePercentAdded, occurencetime, aghstime)
    magval.mValueDuration = Duration

    Dim magmod As New Modifier(magval, notargetself)
    outmods.Add(magmod)





    Return outmods
  End Function
End Class
