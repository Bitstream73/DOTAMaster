Public Class abFire_Remnant
Inherits AbilityBase

  Public maxcharges As ValueWrapper
  Public chargerestoretime As ValueWrapper

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

    mDisplayName = "Fire Remnant"
    mName = eAbilityName.abFire_Remnant
    Me.EntityName = eEntity.abFire_Remnant

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untEmber_Spirit

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/ember_spirit_fire_remnant_hp2.png"

    Description = "Ember Spirit generates Fire Remnant charges every 35 seconds, with a max of 3 charges. Releasing a charge sends a Fire Remnant that runs to the target location at 2.5x Ember Spirit's speed. Using Activate Fire Remnant, Ember Spirit can dash out to his Remnants, exploding them for area of effect damage. The targeted Remnant will be arrived at last."



    'mCooldown = New ValueWrapper(0, 0, 0)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)
    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical


    maxcharges = New ValueWrapper(3, 3, 3)

    chargerestoretime = New ValueWrapper(35, 35, 35)

    Damage = New ValueWrapper(100, 150, 200)

    Radius = New ValueWrapper(450, 450, 450)

    Duration = New ValueWrapper(45, 45, 45)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetself = Helpers.GetUnitTargetSelfInfo(theability_InfoID, _
                                                       thecaster, _
                                                       thetarget, _
                                                       "", eModifierCategory.Active)

    Dim unittargetenemies = Helpers.GetUnitTargetEnemyUnitsInfo(theability_InfoID, _
                                                       thecaster, _
                                                       thetarget, _
                                                       "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)
    damval.Charges = maxcharges

    Dim dammod As New Modifier(damval, unittargetenemies)
    outmods.Add(dammod)


    Dim tpval As New modValue(1, eModifierType.Teleport, occurencetime)

    Dim tpmod As New Modifier(tpval, unittargetself)
    outmods.Add(tpmod)

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
