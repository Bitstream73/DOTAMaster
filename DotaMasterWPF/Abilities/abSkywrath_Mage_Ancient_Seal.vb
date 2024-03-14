Public Class abAncient_Seal
Inherits AbilityBase
  Public increasedmagicdamage As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = True '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "" '"

    mDisplayName = "Ancient Shield"
    mName = eAbilityName.abAncient_Seal
    Me.EntityName = eEntity.abAncient_Seal

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSkywrath_Mage

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False '

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/skywrath_mage_ancient_seal_hp2.png"

    Description = "Skywrath Mage seals the targeted unit with an ancient rune, silencing it and causing it to take additional damage from spells."

    ManaCost = New ValueWrapper(80, 90, 100, 110)

    Cooldown = New ValueWrapper(14, 14, 14, 14)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnit)

    increasedmagicdamage = New ValueWrapper(0.3, 0.35, 0.4, 0.45)

    Duration = New ValueWrapper(3, 4, 5, 6)
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


    Dim magicval As New modValue(increasedmagicdamage, eModifierType.MagicDamageReceivedMultiplier, occurencetime, aghstime)
    magicval.mValueDuration = Duration

    Dim themagic As New Modifier(magicval, unittargetenemy)
    outmods.Add(themagic)


    Dim silenceval As New modValue(Duration, eModifierType.Silence, occurencetime, aghstime)
    silenceval.mValueDuration = Duration

    Dim thesilence As New Modifier(silenceval, unittargetenemy)
    outmods.Add(thesilence)


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
