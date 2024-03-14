Public Class abThundergods_Wrath
  Inherits AbilityBase
  Dim siteradius As ValueWrapper
  Public scdamage As New List(Of Double?)
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

    mDisplayName = "Thundergod's Wrath"
    mName = eAbilityName.abThundergods_Wrath

    Me.EntityName = eEntity.abThundergods_Wrath

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untZeus

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/zuus_thundergods_wrath_hp2.png"

    Description = "Strikes all enemy heroes with a bolt of lightning, no matter where they may be. Thundergod's Wrath also provides True Sight around each hero struck. If an enemy hero is invisible, it takes no damage, but the True Sight is still created at that hero's location. Upgradable by Aghanim's Scepter."

    ManaCost = New ValueWrapper(225, 325, 450)

    Cooldown = New ValueWrapper(90, 90, 90)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untEnemyHeroes)

    DamageType = eDamageType.Magical

    siteradius = New ValueWrapper(900, 900, 900)

    Damage = New ValueWrapper(225, 350, 475)
    scdamage.Add(440)
    scdamage.Add(540)
    scdamage.Add(640)
    Damage.LoadScepterValues(scdamage)


    Duration = New ValueWrapper(3, 3, 3, 3)

    Range = New ValueWrapper(Constants.cMapWideArea, Constants.cMapWideArea, Constants.cMapWideArea, Constants.cMapWideArea)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetenemyheroes = Helpers.GetNoTargetEnemyHeroesInfo(theability_InfoID, _
                                                                 thecaster, _
                                                                 thetarget, _
                                                                 "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)
    damval.mRange = New ValueWrapper(Constants.cMapWideArea, Constants.cMapWideArea, Constants.cMapWideArea, Constants.cMapWideArea)

    Dim dammod As New Modifier(damval, notargetenemyheroes)
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
