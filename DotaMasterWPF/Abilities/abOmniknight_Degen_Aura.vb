Public Class abDegen_Aura
Inherits AbilityBase


  Public moveslow As ValueWrapper
  Public attslow As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True 'FixFixFix
    PiercesSpellImmunity = True

    Notes = "" 'FixFixFix"

    mDisplayName = "Regen Aura"
    mName = eAbilityName.abDegen_Aura

    Me.EntityName = eEntity.abDegen_Aura

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untOmniknight

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/omniknight_degen_aura_hp2.png"

    Description = "Greatly degenerates the movement and attack capabilities of enemy units that stray too near, including magic immune enemies."




    AbilityTypes.Add(eAbilityType.PassiveAura)

    Affects.Add(eUnit.untEnemyUnits)

    moveslow = New ValueWrapper(0.1, 0.18, 0.26, 0.34)

    attslow = New ValueWrapper(10, 18, 26, 34)

    Radius = New ValueWrapper(350, 350, 350, 350)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetenemies = Helpers.GetPassiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Passive)

    Dim moveval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    moveval.mRadius = Radius

    Dim movemod As New Modifier(moveval, notargetenemies)
    outmods.Add(movemod)


    Dim addval As New modValue(attslow, eModifierType.AttackspeedSubtracted, occurencetime, aghstime)
    addval.mRadius = Radius

    Dim addmod As New Modifier(addval, notargetenemies)
    outmods.Add(addmod)

    Return outmods
  End Function



End Class
