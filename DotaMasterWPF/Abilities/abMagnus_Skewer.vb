Public Class abSkewer
Inherits AbilityBase
  Public speed As ValueWrapper
  Public distance As ValueWrapper
  Public moveslow As ValueWrapper
  Public slowduration As ValueWrapper

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

    mDisplayName = "Skewer"
    mName = eAbilityName.abSkewer
    Me.EntityName = eEntity.abSkewer

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untMagnus

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/magnataur_skewer_hp2.png"

    Description = "Magnus rushes forward, goring enemy units on his massive tusk. Heroes hit on the way will be dragged to the destination, then damaged and slowed."


    ManaCost = New ValueWrapper(80, 80, 80, 80)

    Cooldown = New ValueWrapper(30, 30, 30, 30)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical


    Damage = New ValueWrapper(70, 140, 210, 280)

    speed = New ValueWrapper(950)
    distance = New ValueWrapper(900, 1000, 1100, 1200)
    moveslow = New ValueWrapper(0.25, 0.3, 0.35, 0.4)
    slowduration = New ValueWrapper(2.5, 2.75, 3, 3.25)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetlineenemies = Helpers.GetPointTargetLineEnemyUnitsInfo(theability_InfoID, _
                                                                       thecaster, _
                                                                       thetarget, _
                                                                       "", eModifierCategory.Active)

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                                       thecaster, _
                                                                       thetarget, _
                                                                       "", eModifierCategory.Active)

    Dim pushval As New modValue(1, eModifierType.PullForward, occurencetime)

    Dim pusmod As New Modifier(pushval, notargetself)
    outmods.Add(pusmod)

    Dim pushen As New Modifier(pushval, notargetlineenemies)
    outmods.Add(pushen)


    Dim slowval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    slowval.mValueDuration = slowduration

    Dim slowmo As New Modifier(slowval, notargetlineenemies)
    outmods.Add(slowmo)


    Dim damval As New modValue(Damage, eModifierType.DamageMagicalAdded, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, notargetlineenemies)
    outmods.Add(dammod)



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
