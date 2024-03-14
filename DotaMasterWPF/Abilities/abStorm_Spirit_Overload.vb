Public Class abOverload
  Inherits AbilityBase


  Public moveslow As ValueWrapper
  Public attslow As ValueWrapper

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

    mDisplayName = "Overload"
    mName = eAbilityName.abOverload
    Me.EntityName = eEntity.abOverload

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untStorm_Spirit

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/storm_spirit_overload_hp2.png"

    Description = "Casting a spell creates an electrical charge, which is released in a burst on his next attack, dealing damage and slowing nearby enemies."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(30, 50, 70, 90)

    moveslow = New ValueWrapper(0.8, 0.8, 0.8, 0.8)

    attslow = New ValueWrapper(50, 50, 50, 50)

    Duration = New ValueWrapper(0.6, 0.6, 0.6, 0.6)
  End Sub




  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                 theowner As idisplayunit, _
                                                thetarget As iDisplayUnit, _
                                                 ftarget As iDisplayUnit, _
                                                 isfriendbias As Boolean, _
                                                 occurencetime As Lifetime, aghstime As Lifetime) As modifierlist
    Dim outmods As New ModifierList

    Dim unittargetenemy = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                               theowner, _
                                                               thetarget, _
                                                               "", eModifierCategory.Passive)

    'damage
    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflictedOnSpellCast, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, unittargetenemy)
    outmods.Add(dammod)


    'moveslow
    Dim moveval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    moveval.mValueDuration = Duration

    Dim movemod As New Modifier(moveval, unittargetenemy)
    outmods.Add(movemod)


    'attack slow
    Dim attval As New modValue(attslow, eModifierType.AttackspeedSubtracted, occurencetime, aghstime)
    attval.mValueDuration = Duration

    Dim attmod As New Modifier(attval, unittargetenemy)
    outmods.Add(attmod)





    Return outmods
  End Function
End Class
