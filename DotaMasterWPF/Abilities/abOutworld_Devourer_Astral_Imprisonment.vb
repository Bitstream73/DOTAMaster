Public Class abAstral_Imprisonment
Inherits AbilityBase
  Public intsteal As ValueWrapper
  Public stealduration As ValueWrapper

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

    mDisplayName = "Astral Imprisonment"
    mName = eAbilityName.abAstral_Imprisonment
    Me.EntityName = eEntity.abAstral_Imprisonment

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untOutworld_Devourer

    mAbilityPosition = 2

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/obsidian_destroyer_astral_imprisonment_hp2.png"

    Description = "Places a target allied or enemy hero into an astral prison. The hidden hero is invulnerable and disabled. When cast on an enemy Hero, Harbinger temporarily steals intelligence from that hero."

    ManaCost = New ValueWrapper(120, 140, 160, 180)

    Cooldown = New ValueWrapper(18, 16, 14, 12)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untSelf)

    intsteal = New ValueWrapper(4, 7, 10, 13)

    stealduration = New ValueWrapper(50, 50, 50, 50)

    Duration = New ValueWrapper(1, 2, 3, 4)



  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim theaffects As New List(Of eUnit)
    theaffects.Add(eUnit.untEnemyHero)
    theaffects.Add(eUnit.untAlliedHero)

    Dim unittargetmulti = Helpers.GetUnitTargetMultiAffectsInfo(theability_InfoID, _
                                                                 thecaster, _
                                                                 thetarget, _
                                                                 "", eModifierCategory.Active, theaffects)




    Dim intval As New modValue(intsteal, eModifierType.AstrlImpIntStolen, occurencetime, aghstime)
    intval.mValueDuration = stealduration

    Dim intmod As New Modifier(intval, unittargetmulti)
    outmods.Add(intmod)



    Dim invulval As New modValue(Duration, eModifierType.Invulnerability, occurencetime, aghstime)
    invulval.mValueDuration = Duration

    Dim involmod As New Modifier(invulval, unittargetmulti)
    outmods.Add(involmod)


    Dim muteval As New modValue(Duration, eModifierType.MuteAllOnTarget, occurencetime, aghstime)
    muteval.mValueDuration = Duration

    Dim mutemod As New Modifier(muteval, unittargetmulti)
    outmods.Add(mutemod)

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
