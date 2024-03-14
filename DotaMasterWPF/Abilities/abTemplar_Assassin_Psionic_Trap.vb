Public Class abPsionic_Trap
Inherits AbilityBase
  Public maxtraps As ValueWrapper
  Public minmoveslow As ValueWrapper
  Public maxmoveslow As ValueWrapper
  Public slowduration As ValueWrapper
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

    mDisplayName = "Psionic Trap"
    mName = eAbilityName.abPsionic_Trap
    Me.EntityName = eEntity.abPsionic_Trap

 'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTemplar_Assassin

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/templar_assassin_psionic_trap_hp2.png"

    Description = "Templar Assassin places mystical traps that invisibly monitor enemy movement. When sprung at her command, they exert a slowing influence of 30% in the area. Traps charge up to slow an additional 5% every second, up to 50%."

    ManaCost = New ValueWrapper(15, 15, 15)

    Cooldown = New ValueWrapper(11, 9, 7)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    maxtraps = New ValueWrapper(5, 8, 11)

    minmoveslow = New ValueWrapper(0.3, 0.3, 0.3)

    maxmoveslow = New ValueWrapper(0.5, 0.5, 0.5)

    slowduration = New ValueWrapper(5, 5, 5)
End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetself = Helpers.GetPointTargetSelfInfo(theability_InfoID, _
                                                                          thecaster, _
                                                                          thetarget, _
                                                                          "", eModifierCategory.Active)

    'Dim psionictrap As HeroPet_Info
    'psionictrap.hitpoints = New ValueWrapper(100, 100, 100, 100)
    'psionictrap.armor = New ValueWrapper(0, 0, 0, 0)

    'psionictrap.SightRange.Add(New ValueWrapper(400, 400, 400, 400))
    'psionictrap.SightRange.Add(New ValueWrapper(400, 400, 400, 400))

    'psionictrap.xpvalue = New ValueWrapper(12, 12, 12, 12)

    Dim traps As New modValue(maxtraps, eModifierType.petPsionic_Trap, occurencetime, aghstime)

    Dim trapmod As New Modifier(traps, pointtargetself)
    outmods.Add(trapmod)


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
