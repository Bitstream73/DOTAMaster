Public Class abLunar_Blessing
Inherits AbilityBase

  Public bonusdamage As ValueWrapper
  Public bonusnightvision As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = True '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Increases Luna's night vision to a total of 1800.|Will grant Luna the bonus damage as well, not just her allies.|The damage buff lingers for 0.5 seconds after leaving the area.|Upon learning, Luna emits very faint pulsing particles around her." '"

    mDisplayName = "Lunar Blessing"
    mName = eAbilityName.abLunar_Blessing

    Me.EntityName = eEntity.abLunar_Blessing

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untLuna

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False '

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/luna_lunar_blessing_hp2.png"

    Description = "Grants bonus damage to nearby allied heroes, while blessing Luna with extra night vision."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)



    Radius = New ValueWrapper(900, 900, 900, 900)

    bonusdamage = New ValueWrapper(14, 22, 30, 38)

    bonusnightvision = New ValueWrapper(1000, 1000, 1000, 1000)


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

    Dim passiveauraalliedheroes = Helpers.GetPassiveAuraAlliedHeroesInfo(theability_InfoID, _
                                                                         theowner, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Passive)

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                                         theowner, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Passive)


    Dim visionval As New modValue(bonusnightvision, eModifierType.VisionNight, occurencetime, aghstime)

    Dim visionself As New Modifier(visionval, notargetself)
    outmods.Add(visionself)

    Dim visionallies As New Modifier(visionval, passiveauraalliedheroes)
    outmods.Add(visionallies)




    Dim damval As New modValue(bonusdamage, eModifierType.BonusDamage, occurencetime, aghstime)

    Dim damself As New Modifier(damval, notargetself)
    outmods.Add(damself)

    Dim damallies As New Modifier(damval, passiveauraalliedheroes)
    outmods.Add(damallies)



    Return outmods
  End Function
End Class
