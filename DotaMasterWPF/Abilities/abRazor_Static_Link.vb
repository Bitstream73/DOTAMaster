Public Class abStatic_Link
Inherits AbilityBase
  Public buffduration As ValueWrapper
  Public Damagedrainrate As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = True '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "The link is broken when either unit dies or the distance between them becomes greater than 700.|Only distance or death can break the link, and nothing else.|Static Link provides shared vision with the target while draining.|Static Link drains damage in 1 second intervals, starting 1 second after linking.|Static Link can steal up to 56/112/168/224 damage when draining for the full duration.|Can be cast on Lone Druid's Spirit Bear, Visage's Familliars, Warlock's Golem and the spirits from Primal Split." '"

    mDisplayName = "Static Link"
    mName = eAbilityName.abStatic_Link
    Me.EntityName = eEntity.abStatic_Link

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untRazor

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False '

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/razor_static_link_hp2.png"

    Description = "Creates a charged link between Razor and an enemy Hero, stealing damage from the target and giving it to Razor."

    ManaCost = New ValueWrapper(20, 30, 40, 50)

    Cooldown = New ValueWrapper(25, 25, 25, 25)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untHeroes)

    Duration = New ValueWrapper(8, 8, 8, 8)

    buffduration = New ValueWrapper(18, 18, 18, 18)

    Damagedrainrate = New ValueWrapper(7, 14, 21, 28)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList




    Dim unittargetenemy = Helpers.GetUnitTargetEnemyHeroInfo(theability_InfoID, _
                                                             thecaster, _
                                                             thetarget, _
                                                             "", eModifierCategory.Active)


    Dim unittargetself = Helpers.GetUnitTargetSelfInfo(theability_InfoID, _
                                                             thecaster, _
                                                             thetarget, _
                                                             "", eModifierCategory.Active)



    Dim dambonus As New modValue(Damagedrainrate, eModifierType.StaticLinkBonusDamage, occurencetime, aghstime)
    dambonus.mValueDuration = buffduration

    Dim thebonus As New Modifier(dambonus, unittargetself)
    outmods.Add(thebonus)




    Dim damdrain As New modValue(Damagedrainrate, eModifierType.DamageLost, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)
    damdrain.mValueDuration = Duration

    Dim thedrain As New Modifier(damdrain, unittargetenemy)
    outmods.Add(thedrain)


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
