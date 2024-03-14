Public Class abHeadshot
  Inherits AbilityBase


  Public extradamagechance As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = True '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Headshot cannot be evaded by evasion, but still can be disjointed.|Sniper can lifeleech the damage dealt by Headshot with Lifesteal. However, it cannot crit.|The damage can be reduced by, for example, Enfeeble or Static Link. However it cannot be amplified by e.g. Empower or the Double Damage rune.|Increases Sniper 's attack damage output on an avarage by 6/16/26/36.|Headshot can proc upon attacking allies." '"

    mDisplayName = "Headshot"
    mName = eAbilityName.abHeadshot
    Me.EntityName = eEntity.abHeadshot

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSniper

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/sniper_headshot_hp2.png"

    Description = "Sniper increases his accuracy, giving a chance to deal extra damage and mini-stun. Headshot procs cannot be evaded."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Physical

    Damage = New ValueWrapper(15, 40, 65, 90)

    extradamagechance = New ValueWrapper(0.4, 0.4, 0.4, 0.4)
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

    Dim passiveunittargetenemy = Helpers.GetPassiveEnemyTargetInfo(theability_InfoID, _
                                                                   theowner, _
                                                                   thetarget, _
                                                                   "", eModifierCategory.Active)

    Dim damval As New modValue(Me.Damage, eModifierType.DamagePhysicalInflicted, occurencetime, aghstime)
    damval.mPercentChance = extradamagechance

    Dim damage As New Modifier(damval, passiveunittargetenemy)
    outmods.Add(damage)

    Dim stunval As New modValue(0.1, eModifierType.MiniStun, occurencetime)
    stunval.mValueDuration = New ValueWrapper(0.1)
    Dim thestun As New Modifier(stunval, passiveunittargetenemy)
    outmods.Add(thestun)

    Return outmods
  End Function
End Class
