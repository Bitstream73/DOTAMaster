Public Class abPlague_Ward
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
    PiercesSpellImmunity = True

    Notes = "" 'FixFixFix"

    mDisplayName = "Plague Ward"
    mName = eAbilityName.abPlague_Ward
    Me.EntityName = eEntity.abPlague_Ward

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untVenomancer

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/venomancer_plague_ward_hp2.png"

    Description = "Summons a plague ward to attack enemy units and structures. The ward is immune to magic. Wards gain the Poison Sting level from Venomancer, dealing 50% of the full damage."

    ManaCost = New ValueWrapper(20, 20, 20, 20)

    Cooldown = New ValueWrapper(5, 5, 5, 5)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Physical

    Duration = New ValueWrapper(40, 40, 40, 40)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetself = Helpers.GetPointTargetEnemyUnitsInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active)

    'Dim ward As New HeroPet_Info
    'ward.Duration = mDuration
    'ward.hitpoints = New ValueWrapper(75, 200, 325, 450)

    'ward.DamageHigh = New ValueWrapper(11, 21, 32, 42)
    'ward.DamageLow = New ValueWrapper(9, 17, 26, 34)

    'ward.armor = New ValueWrapper(0, 0, 0, 0)

    'ward.SightRange.Add(New ValueWrapper(1200, 1200, 1200, 1200))
    'ward.SightRange.Add(New ValueWrapper(800, 800, 800, 800))

    'ward.AttackRange = New ValueWrapper(600, 600, 600, 600)

    'ward.BaseAttackSpeed = New ValueWrapper(1.5, 1.5, 1.5, 1.5)

    'ward.bounty = New ValueWrapper(17, 17, 17, 17)

    'ward.xpvalue = New ValueWrapper(20, 25, 30, 35)


    Dim wardval As New modValue(1, eModifierType.petPlague_Ward, occurencetime)
    ' wardval.mPet = ward
    wardval.mValueDuration = Duration

    Dim wardmod As New Modifier(wardval, pointtargetself)
    outmods.Add(wardmod)

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
