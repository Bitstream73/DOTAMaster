Public Class abPounce
Inherits AbilityBase
  Public leashduration As ValueWrapper
  Public leashradius As ValueWrapper
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

    mDisplayName = "Pounce"
    mName = eAbilityName.abPounce

    Me.EntityName = eEntity.abPounce

    ' = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSlark

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/slark_pounce_hp2.png"

    Description = "Slark leaps forward, grabbing the first hero he connects with. That unit takes damage and is leashed to Slark, and can only move a limited distance away from Slark's landing position."

    ManaCost = New ValueWrapper(75, 75, 75, 75)


    Cooldown = New ValueWrapper(20, 16, 12, 8)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)
    Affects.Add(eUnit.untEnemyUnit)

    DamageType = eDamageType.Magical

    Range = New ValueWrapper(700, 700, 700, 700)

    Damage = New ValueWrapper(50, 100, 150, 200)

    leashduration = New ValueWrapper(3.5, 3.5, 3.5, 3.5)

    leashradius = New ValueWrapper(325, 325, 325, 325)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetnearestenemy = Helpers.GetNoTargetEnemyHeroNearestInfo(theability_InfoID, _
                                                                       thecaster, _
                                                                       thetarget, _
                                                                       "", eModifierCategory.Active)

    Dim snareval As New modValue(leashduration, eModifierType.MuteMove, occurencetime, aghstime)
    snareval.mValueDuration = leashduration

    Dim snaremod As New Modifier(snareval, notargetnearestenemy)
    outmods.Add(snaremod)


    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, notargetnearestenemy)
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
