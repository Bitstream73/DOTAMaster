Public Class abEarth_Brewmaster_Pulverize
  Inherits AbilityBase
  Public stunduration As ValueWrapper

  Public procchance As ValueWrapper
  Public closedamageRadius As ValueWrapper
  Public fardamageradius As ValueWrapper
  Public closedamage As ValueWrapper
  Public fardamage As ValueWrapper
  Public Sub New()

    BlockedByMagicImmune = True
    RemovedByMagicImmune = False
    CanBePurged = False
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False
    PiercesSpellImmunity = False

    Notes = "Occurs when Earth attacks an enemy.|Does not trigger on buildings and wards.|The radius is centered around Earth.|The damage hits the attack target aswell, not only nearby units."

    mDisplayName = "Pulverize"
    mName = eAbilityName.abEarth_Brewmaster_Pulverize
    Me.EntityName = eEntity.abEarth_Brewmaster_Pulverize

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untEarth_Brewmaster

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'Check This
    'mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/0/06/Pulverize_%28Earth%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Brewmaster"
    Description = "Provides a chance to do damage in a small radius."

    procchance = New ValueWrapper(0.2)
    closedamageRadius = New ValueWrapper(150)
    fardamageradius = New ValueWrapper(250)
    closedamage = New ValueWrapper(20) '40 but these folks will get far damage as well
    fardamage = New ValueWrapper(20)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemy = Helpers.GetPointTargetAuraEnemyUnitsInfo(theability_InfoID, _
                                                                         thecaster, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Active)

    Dim closedamval As New modValue(closedamage, eModifierType.DamagePhysicalInflicted, occurencetime, aghstime)
    closedamval.mPercentChance = procchance
    closedamval.mRadius = closedamageRadius

    Dim closedammod As New Modifier(closedamval, unittargetenemy)
    outmods.Add(closedammod)

    Dim fardamval As New modValue(fardamage, eModifierType.DamagePhysicalInflicted, occurencetime, aghstime)
    fardamval.mPercentChance = procchance
    closedamval.mRadius = fardamageradius

    Dim fardammod As New Modifier(fardamval, unittargetenemy)
    outmods.Add(fardammod)


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
