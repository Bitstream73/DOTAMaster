Public Class abSummon_Spirit_Bear
Inherits AbilityBase

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

    mDisplayName = "Summon Spirit Bear"
    mName = eAbilityName.abSummon_Spirit_Bear
    Me.EntityName = eEntity.abSummon_Spirit_Bear

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untLone_Druid

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/lone_druid_spirit_bear_hp2.png"

    Description = "Summons a powerful Spirit Bear companion that can equip items. If the bear moves 1100 distance away from the Lone Druid, it cannot attack. If the Spirit Bear dies, the Lone Druid suffers composite damage as backlash. As the bear increases in levels, it can learn the Return, Entangling Claws, and Demolish abilities. Spirit Bear does not benefit from attributes."


    ManaCost = New ValueWrapper(75, 75, 75, 75)

    Cooldown = New ValueWrapper(180, 160, 140, 120)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)




End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Active)


    'Dim bear As New HeroPet_Info

    'bear.hitpoints = New ValueWrapper(1400, 1800, 2300, 2700)

    'bear.HealthRegen = New ValueWrapper(2, 3, 4, 5)

    'bear.mana = New ValueWrapper(300, 300, 300, 300)

    'bear.DamageHigh = New ValueWrapper(38, 38, 38, 38)
    'bear.DamageLow = New ValueWrapper(28, 28, 28, 28)

    'bear.movementspeed = New ValueWrapper(320, 320, 320, 320)

    'bear.SightRange.Add(New ValueWrapper(1400, 1400, 1400, 1400))
    'bear.SightRange.Add(New ValueWrapper(800, 800, 800, 800))

    'bear.BaseAttackSpeed = New ValueWrapper(1.75, 1.65, 1.55, 1.45)

    'bear.bounty = New ValueWrapper(300, 300, 300, 300)

    'bear.xpvalue = New ValueWrapper(300, 300, 300, 300)


    Dim petval As New modValue(1, eModifierType.petSpirit_Bear, occurencetime)
    ' petval.mPet = bear

    Dim petmod As New Modifier(petval, notargetself)
    outmods.Add(petmod)

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
