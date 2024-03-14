Public Class abMystic_Snake
Inherits AbilityBase
  Public jumpradius As ValueWrapper
  Public jumpcount As ValueWrapper
  Public manasteal As ValueWrapper
  Public increaseperjump As ValueWrapper

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

    mDisplayName = "Mystic Snake"
    mName = eAbilityName.abMystic_Snake
    Me.EntityName = eEntity.abMystic_Snake

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untMedusa

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/medusa_mystic_snake_hp2.png"

    Description = "A mystic snake made of energy jumps from target to target dealing damage and stealing mana. After it reaches its last target, it returns to Medusa to replenish her with mana. The snake deals more damage and steals more mana per jump."

    ManaCost = New ValueWrapper(140, 150, 160, 170)

    Cooldown = New ValueWrapper(11, 11, 11, 11)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    jumpradius = New ValueWrapper(475, 475, 475, 475)

    jumpcount = New ValueWrapper(3, 4, 5, 6)

    Damage = New ValueWrapper(80, 120, 160, 200)

    manasteal = New ValueWrapper(20, 35, 50, 65)

    increaseperjump = New ValueWrapper(0.25, 0.25, 0.25, 0.25)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemies = Helpers.GetUnitTargetEnemyUnitsInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active)

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                                thecaster, _
                                                                thetarget, _
                                                                "", eModifierCategory.Active)

    Dim manaselfval As New modValue(manasteal, eModifierType.MysticSnakeManaAdded, occurencetime, aghstime)
    manaselfval.Charges = jumpcount
    manaselfval.mRadius = Radius

    Dim manamod As New Modifier(manaselfval, notargetself)
    outmods.Add(manamod)



    Dim manaenemiesval As New modValue(manasteal, eModifierType.MysticSnakeManaSubtracted, occurencetime, aghstime)

    Dim manaenmod As New Modifier(manaenemiesval, unittargetenemies)
    outmods.Add(manaenmod)



    Dim damval As New modValue(Damage, eModifierType.MysticSnakeDamageAdded, occurencetime, aghstime)
    damval.Charges = jumpcount
    damval.mRadius = Radius

    Dim dammod As New Modifier(damval, unittargetenemies)
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
