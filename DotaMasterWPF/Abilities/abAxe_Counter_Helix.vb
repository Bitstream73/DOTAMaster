Public Class abCounter_Helix
  Inherits AbilityBase


  Private ChancetoHelix As ValueWrapper ' = 0.17
  Public Sub New()

    BlockedByMagicImmune = False
    RemovedByMagicImmune = False
    CanBePurged = False
    CanBeUsedByIllusions = True
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False

    PiercesSpellImmunity = True
    mDisplayName = "Counter Helix"
    Notes = "Counter Helix checks for triggering whenever an attack against Axe begins, not when Axe is actually damaged by said attack.|Attacks from mechanical units cannot trigger Counter Helix. This includes Towers, Siege Creeps, Plague Wards, Serpent Wards, the Death Ward, and some others.|Does damage to mechanical units like Siege units.|Counter Helix uses Pseudo Random chance.|Ability is not disabled by Doom."

    mName = eAbilityName.abCounter_Helix
    Me.EntityName = eEntity.abCounter_Helix

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untAxe

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'Check This
    'mHasAghs = False

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/axe_counter_helix_hp2.png"
    WebpageLink = ""
    Description = "When attacked, Axe performs a helix counter attack, dealing damage to all nearby enemies."


    Cooldown = New ValueWrapper(0.45, 0.4, 0.35, 0.3)

    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Physical

    Damage = New ValueWrapper(100, 135, 170, 205)

    Radius = New ValueWrapper(275, 275, 275, 275)

    ChancetoHelix = New ValueWrapper(0.2, 0.2, 0.2, 0.2)
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

    Dim autocastenemyunits = Helpers.GetAutoCastEnemyUnitsInfo(theability_InfoID, _
                                                               theowner, _
                                                               thetarget, _
                                                               "", eModifierCategory.Passive)

    Dim damval As New modValue(Damage, eModifierType.RightClickCounterAttack, occurencetime, aghstime)
    damval.mPercentChance = ChancetoHelix
    Dim counterattack As New Modifier(damval, autocastenemyunits)
    outmods.Add(counterattack)



    Return outmods
  End Function
End Class
