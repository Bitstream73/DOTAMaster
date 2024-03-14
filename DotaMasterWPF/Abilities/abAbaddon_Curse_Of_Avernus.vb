Public Class abCurse_Of_Avernus
  Inherits AbilityBase


  Private debuffduration As ValueWrapper ' = 2.5
  Private Buffduration As ValueWrapper ' = 4.5
  Private moveslowperc As ValueWrapper
  Private attspeedslowperc As ValueWrapper
  '  Private bonusmovespdperc As ValueWrapper ' = 0.15
  Private bonusattspeed As ValueWrapper
  Private movespeedbonus As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = False
    RemovedByMagicImmune = False
    CanBePurged = True
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False

    PiercesSpellImmunity = True
    mDisplayName = "Curse of Avernus"
    mName = eAbilityName.abCurse_Of_Avernus
    Me.EntityName = eEntity.abCurse_Of_Avernus

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untAbaddon

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'Check This
    'mHasAghs = False

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/abaddon_frostmourne_hp2.png"
    WebpageLink = ""
    Description = "Abaddon strikes an enemy with chilling curse on each attack, causing all units who attack the slowed enemy to gain increased movement speed, along with faster attack speed, for a limited time."
    Notes = "Placed on Abaddon at the start of his attack, so he gets the bonus on his first hit. The debuff is only applied on hit.|Works partially on towers. Abaddon will receive the buff from attacking a tower, however no debuff is applied to the tower so no other targets may benefit from it.|Can affect allies, including creeps being denied. Enemies attacking an ally target affected by the debuff benefit from the Curse of Avernus buff.|Affects magic immune targets."

   

    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    debuffduration = New ValueWrapper(2.5, 2.5, 2.5, 2.5)

    Buffduration = New ValueWrapper(4.5, 4.5, 4.5, 4.5)

    moveslowperc = New ValueWrapper(0.05, 0.1, 0.15, 0.2)

    attspeedslowperc = New ValueWrapper(5, 10, 15, 20)

    movespeedbonus = New ValueWrapper(0.15, 0.15, 0.15, 0.15)

    bonusattspeed = New ValueWrapper(10, 20, 30, 40)


    bonusattspeed = New ValueWrapper(10, 20, 30, 40)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                    thecaster As iDisplayUnit, _
                                                    thetarget As iDisplayUnit, _
                                                    ftarget As iDisplayUnit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    'targetted enemy move slow
    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                        thecaster, _
                                                        thetarget, _
                                                        "", eModifierCategory.Active)

    Dim moveslowval As New modValue(moveslowperc, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)

    Dim enemymoveslow As New Modifier(moveslowval, unittargetenemytargetinfo)

    outmods.Add(enemymoveslow)


    'abaddon movespeed and attackspeed
    Dim notargetselfinfo = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                        thecaster, _
                                                        thetarget, _
                                                        "", eModifierCategory.Active)

    Dim movespeedval As New modValue(movespeedbonus, eModifierType.MoveSpeedPercent, occurencetime, aghstime)

    Dim selfmovespeed As New Modifier(movespeedval, notargetselfinfo)

    outmods.Add(selfmovespeed)


    Dim attspeedval As New modValue(bonusattspeed, eModifierType.AttackSpeedAdded, occurencetime, aghstime)

    Dim selfattspeed As New Modifier(attspeedval, notargetselfinfo)

    outmods.Add(selfattspeed)


    'allies targetting abaddon's target
    Dim unittargetalliestargettingcastertarget = Helpers.GetUnitTargetAlliedHeroesAttackingCastersTarget(theability_InfoID, _
                                                        thecaster, _
                                                        thetarget, _
                                                        "", eModifierCategory.Active)


    Dim allymovespeed As New Modifier(movespeedval, unittargetalliestargettingcastertarget)

    outmods.Add(allymovespeed)




    Dim allyattspeed As New Modifier(attspeedval, unittargetalliestargettingcastertarget)

    outmods.Add(allyattspeed)







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
