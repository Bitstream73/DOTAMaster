Public Class abAvalanche
Inherits AbilityBase
  Public stunduration As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "An enemy under the effects of both Toss and Avalanche will take double damage from Avalanche.|Deals 4 instances of damage, dealing 1/4th the total damage in each instance.|The first instance occurs 0.25 seconds after the cast.|The stun ends exactly 1.25 seconds after the cast (and starts 0.25 seconds after the cast). So if you get hit by the 4th instance, you will be stunned for 0.25 seconds."

    mDisplayName = "Avalanche"
    mName = eAbilityName.abAvalanche
    Me.EntityName = eEntity.abAvalanche

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTiny

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/tiny_avalanche_hp2.png"

    Description = "Bombards an area with rocks, stunning and damaging enemy land units."

    ManaCost = New ValueWrapper(120, 120, 120, 120)

    Cooldown = New ValueWrapper(17, 17, 17, 17)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(100, 180, 260, 300)

    Radius = New ValueWrapper(275, 275, 275, 275)

    stunduration = New ValueWrapper(1, 1, 1, 1)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetenemies = Helpers.GetPointTargetEnemyUnitsInfo(theability_InfoID, _
                                                                  thecaster, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Active)

    Dim valdam As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)
    valdam.mRadius = Radius

    Dim moddam As New Modifier(valdam, pointtargetenemies)
    outmods.Add(moddam)

    Dim valstun As New modValue(stunduration, eModifierType.Stun, occurencetime, aghstime)
    valstun.mRadius = Radius
    valstun.mValueDuration = stunduration

    Dim modstun As New Modifier(valstun, pointtargetenemies)
    outmods.Add(modstun)

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
