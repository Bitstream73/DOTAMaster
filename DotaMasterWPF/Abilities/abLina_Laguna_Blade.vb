Public Class abLaguna_Blade
Inherits AbilityBase
  Public scepterrange As New List(Of Double?)

  Public magicaldamage As ValueWrapper
  Public sceptermagicaldamage As New List(Of Double?)

  Public puredamage As ValueWrapper
  Public scepterpuredamage As New List(Of Double?)

Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "" 'FixFixFix"

    mDisplayName = "Laguna Blade"
    mName = eAbilityName.abLaguna_Blade
    Me.EntityName = eEntity.abLaguna_Blade

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untLina

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/lina_laguna_blade_hp2.png"

    Description = "Fires off a bolt of lightning at a single enemy unit, dealing massive damage. Upgradable with Aghanim's Scepter."


    ManaCost = New ValueWrapper(280, 420, 680)


    Cooldown = New ValueWrapper(70, 60, 50)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical


    Damage = New ValueWrapper(450, 675, 950)

    Range = New ValueWrapper(600, 600, 600)
    scepterrange.Add(900)
    scepterrange.Add(900)
    scepterrange.Add(900)
    Range.LoadScepterValues(scepterrange)

    magicaldamage = New ValueWrapper(450, 675, 950)
    sceptermagicaldamage.Add(0)
    sceptermagicaldamage.Add(0)
    sceptermagicaldamage.Add(0)
    magicaldamage.LoadScepterValues(sceptermagicaldamage)

    puredamage = New ValueWrapper(-1, -1, -1)
    scepterpuredamage.Add(450)
    scepterpuredamage.Add(675)
    scepterpuredamage.Add(950)
    puredamage.LoadScepterValues(scepterpuredamage)


End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemy = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active)

    Dim magval As New modValue(magicaldamage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim magmod As New Modifier(magval, unittargetenemy)
    outmods.Add(magmod)


    Dim pureval As New modValue(puredamage, eModifierType.DamagePureInflicted, occurencetime, aghstime)

    Dim puremod As New Modifier(pureval, unittargetenemy)
    outmods.Add(puremod)



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
