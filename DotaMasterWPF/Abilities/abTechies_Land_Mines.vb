Public Class abLand_Mines
  Inherits AbilityBase
  Public fulldamageradius As ValueWrapper
  Public halfdamageradius As ValueWrapper
  Public mineactivationtime As ValueWrapper
  Public minelimit As ValueWrapper
  Public minefadetime As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = True

    Notes = "If destroyed by attacks, the mines will still explode.|Mines last until they explode.|Mines are triggered by invisible units.|Mines have no collision, and can be set over other mines.|Mines have a small amount of vision (64/64 Sight Range)|Mines have 100 HP and 0 medium armor.|Land Mines will block neutral camps from spawning.|Damage from mines does not come from Techies themselves, and thus does not trigger abilities and items like Corrosive Skin, Spiked Carapace, or Blade Mail. This also applies to Remote Mines.|Land Mines aren't triggered by flying units, and can't damage them." '"

    mDisplayName = "Land Mines"
    mName = eAbilityName.abLand_Mines
    Me.EntityName = eEntity.abLand_Mines

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTechies

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False '

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/techies_land_mines_hp2.png"

    Description = "Plant an invisible mine that explodes when an enemy steps near. The explosion will deal less damage if the enemy is farther away from the mine when it explodes. Mines explode 0.3 seconds after being triggered. If the number of mines planted exceeds the mine limit, the oldest mine will explode. Damages buildings."

    ManaCost = New ValueWrapper(125, 150, 175, 205)
    
    Cooldown = New ValueWrapper(19, 16, 13, 10)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Physical

    Damage = New ValueWrapper(300, 375, 450, 525)

    fulldamageradius = New ValueWrapper(200, 200, 200, 200)

    halfdamageradius = New ValueWrapper(500, 500, 500, 500)

    mineactivationtime = New ValueWrapper(1.75, 1.75, 1.75, 1.75)

    minelimit = New ValueWrapper(20, 20, 20, 20)

    minefadetime = New ValueWrapper(2, 2, 2, 2)
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

    Dim damval As New modValue(Damage, eModifierType.DamagePhysicalInflicted, occurencetime, aghstime)
    damval.Charges = minelimit


    Dim thedamage As New Modifier(damval, pointtargetenemies)
    outmods.Add(thedamage)

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
