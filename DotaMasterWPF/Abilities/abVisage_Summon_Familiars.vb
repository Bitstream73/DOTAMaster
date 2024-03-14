Public Class abSummon_Familiars
Inherits AbilityBase
  Public familiarhp As ValueWrapper
  Public familiararmor As ValueWrapper
  Public familiarspeed As ValueWrapper
  Public familiarmaxdamage As ValueWrapper
  Public familiarcount As ValueWrapper

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

    mDisplayName = "Summon Familiars"
    mName = eAbilityName.abSummon_Familiars
    Me.EntityName = eEntity.abSummon_Familiars

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untVisage

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/visage_summon_familiars_hp2.png"

    Description = "Conjures up two blind Familiars to fight for Visage. Familiars have high attack power, but each attack drains a charge of damage that recharges slowly over time. Familiars possess the Stone Form ability, that allows them to turn into stone, stunning enemies upon landing. While in Stone Form, Familiars are invulnerable, and rapidly regenerate their health and damage. Familiars grant high bounty when killed. Upgradable by Aghanim's Scepter."

    ManaCost = New ValueWrapper(150, 150, 150)

    Cooldown = New ValueWrapper(180, 160, 140)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    familiarhp = New ValueWrapper(300, 450, 600)
    familiararmor = New ValueWrapper(0, 1, 2)
    familiarspeed = New ValueWrapper(380, 390, 400)
    familiarmaxdamage = New ValueWrapper(56, 98, 154)
    familiarcount = New ValueWrapper(2, 2, 2)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                  thecaster As iDisplayUnit, _
                                                 thetarget As iDisplayUnit, _
                                                  ftarget As iDisplayUnit, _
                                                  isfriendbias As Boolean, _
                                                  occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Active)

    'Dim familiar As New HeroPet_Info()

    'familiar.hitpoints = familiarhp
    'familiar.HealthRegen = New ValueWrapper(0, 0, 0, 0)
    'familiar.DamageHigh = familiarmaxdamage
    'familiar.DamageLow = familiarmaxdamage

    'familiararmor = familiararmor

    'familiar.movementspeed = New ValueWrapper(380, 390, 400)

    'familiar.SightRange.Add(New ValueWrapper(390, 390, 390))
    'familiar.SightRange.Add(New ValueWrapper(390, 390, 390))

    'familiar.BaseAttackSpeed = New ValueWrapper(0.4, 0.4, 0.4)

    'familiar.bounty = New ValueWrapper(100, 100, 100)

    'familiar.xpvalue = New ValueWrapper(41, 41, 41)


    Dim petval As New modValue(familiarcount, eModifierType.petFamiliar, occurencetime, aghstime)
    petval.mCooldown = Cooldown

    Dim petmod As New Modifier(petval, notargetself)
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
