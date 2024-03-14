Public Class abInner_Beast
Inherits AbilityBase
  Public bonusattackspeed As ValueWrapper
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
    mDisplayName = "Inner Beast"
    mName = eAbilityName.abInner_Beast
    Me.EntityName = eEntity.abInner_Beast

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untBeastmaster

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/beastmaster_inner_beast_hp2.png"

    Description = "Untaps the inner fury of allies, passively increasing their attack speed."



    AbilityTypes.Add(eAbilityType.Passive)
    AbilityTypes.Add(eAbilityType.PassiveAura)

    Affects.Add(eUnit.untAlliedHeroes)



    Radius = New ValueWrapper(900, 900, 900, 900)

    bonusattackspeed = New ValueWrapper(15, 25, 35, 45)

End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim notargetallies = Helpers.GetNoTargetAlliedUnitsInfo(theability_InfoID, _
                                                            thecaster, _
                                                            thetarget, _
                                                            "", eModifierCategory.Passive)
    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                            thecaster, _
                                                            thetarget, _
                                                            "", eModifierCategory.Passive)
    Dim attspeed As New modValue(bonusattackspeed, eModifierType.AttackSpeedAdded, occurencetime, aghstime)

    Dim attmodself As New Modifier(attspeed, notargetself)
    outmods.Add(attmodself)

    Dim attmodallies As New Modifier(attspeed, notargetallies)
    outmods.Add(attmodallies)

    Return outmods
  End Function

  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                               caster As iDisplayUnit, _
                                               target As iDisplayUnit, _
                                               ftarget As iDisplayUnit, _
                                               isfriendbias As Boolean, _
                                               occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return New ModifierList
  End Function
End Class
