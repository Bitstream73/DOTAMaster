Public Class abFlaming_Lasso
  Inherits AbilityBase

  Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = True '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = True

    Notes = "Killing Batrider or the target will break the lasso before its expiration.|If Batrider moves more than 400 units in 0.05s the lasso breaks.|Batrider cannot attack while using Flaming Lasso.|Target can be freed with Aphotic Shield, Press The Attack or Dark Pact's self-purge." '"
    mDisplayName = "Flaming Lasso"
    mName = eAbilityName.abFlaming_Lasso
    Me.EntityName = eEntity.abFlaming_Lasso

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untBatrider

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = False '

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/batrider_flaming_lasso_hp2.png"

    Description = "Lassoes an enemy and drags them in Batrider's wake. Victims cannot be dragged over impassable terrain. Dragged units cannot move, attack, or use abilities. Teleporting or blinking will break the lasso."

    ManaCost = New ValueWrapper(225, 225, 225)

    Cooldown = New ValueWrapper(90, 70, 50)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    Duration = New ValueWrapper(3, 3.5, 4)
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

    'Dim thelevel = theabilitylevel - 1
    'Dim theduration = New TimeSpan(mDuration.Item(thelevel) * TimeSpan.TicksPerSecond)

    'pullback
    Dim valmove As New modValue(Duration, eModifierType.Pullback, occurencetime, aghstime)
    valmove.mValueDuration = Duration

    Dim modmove As New Modifier(valmove, unittargetenemy)
    outmods.Add(modmove)


    'targetted enemy
    Dim valmovemute As New modValue(Duration, eModifierType.MuteMove, occurencetime, aghstime)
    valmovemute.mValueDuration = Duration

    Dim modmovemute As New Modifier(valmovemute, unittargetenemy)
    outmods.Add(modmovemute)


    Dim valattmute As New modValue(Duration, eModifierType.MuteAttacks, occurencetime, aghstime)
    valattmute.mValueDuration = Duration

    Dim modattmute As New Modifier(valattmute, unittargetenemy)
    outmods.Add(modattmute)



    Dim valabmute As New modValue(Duration, eModifierType.MuteAbilities, occurencetime, aghstime)
    valabmute.mValueDuration = Duration

    Dim modabmute As New Modifier(valabmute, unittargetenemy)
    outmods.Add(modabmute)



    Return outmods
  End Function
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                               caster As iDisplayUnit, _
                                               target As iDisplayUnit, _
                                               ftarget As iDisplayUnit, _
                                               isfriendbias As Boolean, _
                                               occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return New ModifierList
  End Function
End Class

