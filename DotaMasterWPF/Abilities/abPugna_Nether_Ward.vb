Public Class abNether_Ward
Inherits AbilityBase
  Public wardattackradius As ValueWrapper
  Public damagepermana As ValueWrapper
  Public manaleak As ValueWrapper
  Public attackstodestroy As ValueWrapper
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

    mDisplayName = "Nether Ward"
    mName = eAbilityName.abNether_Ward
    Me.EntityName = eEntity.abNether_Ward

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untPugna

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/pugna_nether_ward_hp2.png"

    Description = "Pugna places a nether ward that fires mana flares at enemy heroes who dare to cast spells, while also causing them to lose mana. Nether Ward deals damage equal to the damage multiplier times the mana spent by the enemy hero. Lasts 30 seconds."

    ManaCost = New ValueWrapper(80, 80, 80, 80)

    Cooldown = New ValueWrapper(35, 35, 35, 35)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    wardattackradius = New ValueWrapper(1600, 1600, 1600, 1600)

    damagepermana = New ValueWrapper(1, 1.25, 1.5, 1.75)

    manaleak = New ValueWrapper(1.5, 3, 4.5, 6)

    attackstodestroy = New ValueWrapper(4, 4, 4, 4)
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

    'Dim ward As New HeroPet_Info
    'ward.attackstodestroy = attackstodestroy

    'ward.Duration = New ValueWrapper(30, 30, 30, 30)

    'ward.armor = New ValueWrapper(0, 0, 0, 0)

    'ward.SightRange.Add(New ValueWrapper(600, 600, 600, 600))
    'ward.SightRange.Add(New ValueWrapper(600, 600, 600, 600))

    'ward.bounty = New ValueWrapper(20, 40, 60, 80)

    'ward.xpvalue = New ValueWrapper(0, 0, 0, 0)


    Dim petval As New modValue(1, eModifierType.petNether_Ward, occurencetime)
    'petval.mPet = ward

    Dim petmod As New Modifier(petval, pointtargetenemies)
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
