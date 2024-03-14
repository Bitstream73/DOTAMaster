Public Class abPrecision_Aura
Inherits AbilityBase


  Dim mrangedamagebonus As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = False
    RemovedByMagicImmune = False
    CanBePurged = False
    CanBeUsedByIllusions = True
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False
    PiercesSpellImmunity = False

    Notes = "Only affects ranged units.|Can be cast manually to affect creeps globally for 30 seconds, with a 120 seconds cooldown.|Because its activation grants an active buff to creeps instead of an aura effect, bonus damage from creeps will persist until the end of the duration even if Drow Ranger dies.|Creeps that spawn after the activation will not gain the bonus damage.|Bonus damage is NOT considered base damage "

    mDisplayName = "Precision Aura"
    mName = eAbilityName.abPrecision_Aura
    Me.EntityName = eEntity.abPrecision_Aura

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untDrow_Ranger

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'Check This
    ' mHasAghs = False

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/drow_ranger_trueshot_hp2.png"
    WebpageLink = ""
    Description = "Adds bonus damage to the physical attack of allied, ranged Hero units on the map based on a percentage of Drow's agility. Affects creeps for 30 seconds when cast."


    Cooldown = New ValueWrapper(120, 120, 120, 120)
    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untAlliedUnits)

    Radius = New ValueWrapper(Constants.cMapWideArea, Constants.cMapWideArea, Constants.cMapWideArea, Constants.cMapWideArea) 'global

    mrangedamagebonus = New ValueWrapper(0.18, 0.24, 0.3, 0.36)
  End Sub




  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                     theowner As idisplayunit, _
                                                     thetarget As iDisplayUnit, _
                                                     ftarget As iDisplayUnit, _
                                                     isfriendbias As Boolean, _
                                                     occurencetime As Lifetime, aghstime As Lifetime) As modifierlist
    Dim outmods As New ModifierList

    Dim passiveselfinfo = Helpers.GetPassiveSelfInfo(theability_InfoID, _
                                                     theowner, _
                                                     thetarget, _
                                                     "", eModifierCategory.Passive)

    Dim damval As New modValue(mrangedamagebonus, eModifierType.DamagePhysicalPercent, occurencetime, aghstime)

    Dim precisionself As New Modifier(damval, passiveselfinfo)
    outmods.Add(precisionself)

    Dim globaltangederoesinfo = Helpers.GetMapwideAuraAlliedRangedHeroesInfo(theability_InfoID, _
                                                     theowner, _
                                                     thetarget, _
                                                     "", eModifierCategory.Passive)


    Dim precisionallies As New Modifier(damval, globaltangederoesinfo)
    outmods.Add(precisionallies)

    Return outmods
  End Function

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Return Nothing


  End Function
End Class
