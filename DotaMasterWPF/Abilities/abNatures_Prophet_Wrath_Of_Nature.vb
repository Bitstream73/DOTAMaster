Public Class abWrath_Of_Nature
Inherits AbilityBase
  Public maxtargets As ValueWrapper
  Public damageaddperbounce As ValueWrapper
  Public sceptermaxtargets As New List(Of Double?)
  Public scepterdamage As New List(Of Double?)
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

    mDisplayName = "Wrath of Nature"
    mName = eAbilityName.abWrath_Of_Nature
    Me.EntityName = eEntity.abWrath_Of_Nature

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untNatures_Prophet

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/furion_wrath_of_nature_hp2.png"

    Description = "Damaging energy bounces around the map, striking enemies close to the cast point that are in vision. Each enemy hit beyond the first adds damage. Upgradable with Aghanim's Scepter."


    ManaCost = New ValueWrapper(175, 225, 275)

    Cooldown = New ValueWrapper(90, 75, 60)

    AbilityTypes.Add(eAbilityType.UnitTarget)
    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    maxtargets = New ValueWrapper(16, 16, 16)
    sceptermaxtargets.Add(18)
    sceptermaxtargets.Add(18)
    sceptermaxtargets.Add(18)
    maxtargets.LoadScepterValues(sceptermaxtargets)

    Damage = New ValueWrapper(140, 180, 225)
    scepterdamage.Add(155)
    scepterdamage.Add(210)
    scepterdamage.Add(275)
    Damage.LoadScepterValues(scepterdamage)

    Range = New ValueWrapper(Constants.cMapWideArea, Constants.cMapWideArea, Constants.cMapWideArea)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                    thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                    ftarget As iDisplayUnit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetglobalenemies = Helpers.GetPointTargetLineEnemyUnitsInfo(theability_InfoID, _
                                                                            thecaster, _
                                                                            thetarget, _
                                                                            "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.WrathofNatureMagicDamageBounceInflicted, occurencetime, aghstime)
    damval.Charges = maxtargets
    damval.mRange = Range


    Dim dammod As New Modifier(damval, pointtargetglobalenemies)
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
