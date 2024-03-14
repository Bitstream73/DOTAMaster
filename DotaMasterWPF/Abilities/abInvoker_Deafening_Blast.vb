Public Class abDeafening_Blast
Inherits AbilityBase

  Public traveldistance As ValueWrapper
  Public startingradius As ValueWrapper
  Public endradius As ValueWrapper

  Public exortdamage As ValueWrapper
  Public quasknockbackdistance As ValueWrapper
  Public quasknockbackduration As ValueWrapper

  Public wexdisarmduration As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False
    CanBePurged = False
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False
    PiercesSpellImmunity = False

    Notes = "Deafening Blast icon.png Deafening Blast travels at a speed of 1100 and always travels the full distance, which takes 0.91 seconds.|The blast can hit units up to 1225 range away (1000 travel distance + 225 end radius).|The complete area is shaped like a cone.|This is how the knock back works:|Affected units are moved in 0.03 second intervals.|The units are moved Level of Quas*25/3 times, so they are moved 8/16/25/33/41/50/58 times.|The first 1/3 times, units are moved linearly, by a distance of 6 per interval. 1/3 of the intervals is 2/5/8/11/13/16/19 times, which results in a distance of 12/30/48/66/78/96/114.|For the remaining 6/11/17/22/28/34/39 intervals, the units are moved quadratically with 0.98 times the speed of the previous interval.|So the remaining intervals together (on each level) move the units by a distance of (sum 6*0.98^1 to 6*0.98^t =) 33.56/58.58/85.46/105.5/127.02/146.08/160.29.|Summed up, the total distance on each level is 45.56/88.58/133.46/171.5/205.02/242.08/274.29.|As conclusion, the knockback starts at a speed of 200 and decreases quadratically.|Affected units are disabled during the knockback. Can knock units over impassable terrain.|During the knockback, all trees the units collide with get destroyed.|The disarm is applied right after the knockback.|Does not affect ancient creeps, Roshan, Warlock's Golem and Storm and Fire from Primal Split."

    mDisplayName = "Deafening Blask"
    mName = eAbilityName.abDeafening_Blast

    Me.EntityName = eEntity.abDeafening_Blast

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untInvoker

    mAbilityPosition = -1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/invoker_deafening_blast_hp2.png"

    Description = "Invoker unleashes a mighty sonic wave in front of him, dealing damage to any enemy unit it collides with based on the level of Exort. The sheer impact from the blast is enough to knock those enemy units back for a duration based on the level of Quas, then disarm their attacks for a duration based on the level of Wex."

    ManaCost = New ValueWrapper(200, 200, 200, 200, 200, 200, 200)


    Cooldown = New ValueWrapper(40, 40, 40, 40, 40, 40, 40)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Range = New ValueWrapper(1000, 1000, 1000, 1000, 1000, 1000, 1000)
    startingradius = New ValueWrapper(175, 175, 175, 175, 175, 175, 175)
    traveldistance = Range
    endradius = New ValueWrapper(225, 225, 225, 225, 225, 225, 225)
    exortdamage = New ValueWrapper(40, 80, 120, 160, 200, 240, 280)
    quasknockbackdistance = New ValueWrapper(45.6, 88.6, 133.5, 171.5, 205, 242.1, 274.3)
    quasknockbackduration = New ValueWrapper(0.25, 0.5, 0.75, 1, 1.25, 1.5, 1.75)
    wexdisarmduration = New ValueWrapper(1, 1.5, 2, 2.5, 3, 3.5, 4)

End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                             thecaster As iDisplayUnit, _
                                                             thetarget As iDisplayUnit, _
                                                             ftarget As iDisplayUnit, _
                                                             isfriendbias As Boolean, _
                                                             occurencetime As Lifetime, aghstime As Lifetime) As ModifierList




    Dim outmods As New ModifierList

    Dim pointtargetenemies = Helpers.GetPointTargetEnemyUnitsInfo(theability_InfoID, _
                                                                  thecaster, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Active)

    Dim damval As New modValue(exortdamage, eModifierType.ExortDamageMagicalInflictedoT, occurencetime, aghstime)
    damval.mAreaOfAffected = Helpers.GetConeArea(startingradius.Value(0), endradius.Value(0), traveldistance.Value(0))

    Dim dammod As New Modifier(damval, pointtargetenemies)
    outmods.Add(dammod)


    Dim knockval As New modValue(quasknockbackduration, eModifierType.QuasKnockback, occurencetime, aghstime)
    knockval.mValueDuration = quasknockbackduration
    knockval.mAreaOfAffected = damval.mAreaOfAffected

    Dim knockmod As New Modifier(knockval, pointtargetenemies)
    outmods.Add(knockmod)


    Dim disval As New modValue(wexdisarmduration, eModifierType.WexDisarm, occurencetime, aghstime)
    disval.mValueDuration = wexdisarmduration
    disval.mAreaOfAffected = damval.mAreaOfAffected

    Dim dismod As New Modifier(disval, pointtargetenemies)
    outmods.Add(dismod)


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
