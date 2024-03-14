Public Class abGreevils_Greed
  Inherits AbilityBase


  Public recentkillwindow As ValueWrapper
  Public basebonusgold As ValueWrapper
  Public extrabonusgold As ValueWrapper
  Public maxbonusgoldperkill As ValueWrapper
  Public stackduration As ValueWrapper

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
    mDisplayName = "Greevil's Greed"
    mName = eAbilityName.abGreevils_Greed
    Me.EntityName = eEntity.abGreevils_Greed

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untAlchemist

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/alchemist_goblins_greed_hp2.png"

    Description = "Alchemist synthesizes additional gold from his enemies. With each kill, Alchemist earns base bonus gold and extra bonus gold. If Alchemist kills another unit which yields gold within the next 25 seconds, an additional instance of Extra Bonus Gold is added to the total. The maximum total bonus gold is 30 per kill."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)




  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return New ModifierList
  End Function


  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                  theowner As idisplayunit, _
                                                  thetarget As iDisplayUnit, _
                                                  ftarget As iDisplayUnit, _
                                                  isfriendbias As Boolean, _
                                                  occurencetime As Lifetime, aghstime As Lifetime) As modifierlist


    Dim outmods As New ModifierList

    Dim theaffected As New List(Of eUnit)
    theaffected.Add(eUnit.untAlliedCreep)
    theaffected.Add(eUnit.untAlliedHero)
    theaffected.Add(eUnit.untEnemyCreep)
    theaffected.Add(eUnit.untEnemyHero)

    Dim unittargetheroesandcreeps = Helpers.GetUnitTargetMultiAffectsInfo(theability_InfoID, _
                                                                          theowner, _
                                                                           thetarget, _
                                                                           "", eModifierCategory.Passive, theaffected)


    Dim basegoldval As New modValue(basebonusgold, eModifierType.LastHitGoldAdded, occurencetime, aghstime)

    Dim basegoldmod As New Modifier(basegoldval, unittargetheroesandcreeps)
    outmods.Add(basegoldmod)

    Dim extragoldval As New modValue(extrabonusgold, eModifierType.LastHitGoldBonusPerStack, occurencetime, aghstime)
    extragoldval.mValueDuration = stackduration

    'will have to call this class for maxbonusgoldperkill to calc potential gold value
    Dim extramod As New Modifier(extragoldval, unittargetheroesandcreeps)
    outmods.Add(extramod)
    Return outmods
  End Function
End Class
