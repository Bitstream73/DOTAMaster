Public Class abFirefly
  Inherits AbilityBase
  Public damageovertime As ValueWrapper

  Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "During this Batrider can fly above units, trees and impassable terrain.|Has an instant cast time.|If duration ends when above impassable terrain, Batrider can get stuck.|The fire destroys trees when flying above them.|Grants Batrider unobstructed vision, allowing him to see past trees and other obstacles.|Can stack with itself.|The trail persists through Batrider's death.|Batrider neither triggers, nor takes damage from Land Mines during Firefly." '"
    mDisplayName = "Firefly"
    mName = eAbilityName.abFirefly
    Me.EntityName = eEntity.abFirefly

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untBatrider

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/batrider_firefly_hp2.png"

    Description = "Batrider takes to the skies, laying down a trail of flames from the air. The fire damages any enemies it touches, and destroys trees below Batrider. While flying, Batrider gains unobstructed movement and vision."

    ManaCost = New ValueWrapper(100, 100, 100, 100)

    Cooldown = New ValueWrapper(40, 40, 40, 40)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    damageovertime = New ValueWrapper(20, 40, 60, 80)

    Radius = New ValueWrapper(200, 200, 200, 200)

    Duration = New ValueWrapper(18, 18, 18, 18)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    'enemy damage
    Dim notargettrailenemies = Helpers.GetNoTargetEnemyUnitsInfo(theability_InfoID, _
                                                                 thecaster, _
                                                                 thetarget, _
                                                                 "", eModifierCategory.Active)


    'Dim theduration = mDuration ' New TimeSpan(mDuration.Item(thelevel) * TimeSpan.TicksPerSecond)



    Dim valdot As New modValue(damageovertime, eModifierType.DamageoTMagicalInflicted, occurencetime, aghstime)
    valdot.mValueDuration = Duration

    Dim moddot As New Modifier(valdot, notargettrailenemies)
    outmods.Add(moddot)


    'vision and movement
    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                        thecaster, _
                                                        thetarget, _
                                                        "", eModifierCategory.Active)

    Dim valfreemove As New modValue(1, eModifierType.UnobstructedMovementandVision, occurencetime)
    valfreemove.mValueDuration = Duration


    Dim modfreemove As New Modifier(valfreemove, notargetself)
    outmods.Add(modfreemove)


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
