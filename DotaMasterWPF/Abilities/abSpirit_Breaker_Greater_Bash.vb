Public Class abGreater_Bash
Inherits AbilityBase

  Public movespeedasdamage As ValueWrapper
  Public bashchance As ValueWrapper
  Public stunduration As ValueWrapper
  Public knockbackduration As ValueWrapper
  Public bonusmovespeed As ValueWrapper
  Public speedduration As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = True

    Notes = "Does not stack with Skull Basher or Abyssal Blade. In fact, this items disallowed for purchase by Spirit Breaker.|Knockback distance is 143/152/158/162. So the knockback speed is 286/304/316/324.|Since the movement speed limits are at 100 and 522, minimum possible damage is 22/28/34/40, while the maximum is at 114.84/146.16/177.48/208.8 (before all reductions).|Affects siege creeps. Can proc on Roshan, putting it on cooldown and giving the move speed boost, but Roshan is neither knocked back nor stunned.|Unlike most chance-based passive abilities, Greater Bash is not governed by pseudo-random distribution.|Disabled by Doom ability icon.png Doom (with Aghanim's Scepter icon.png Aghanim's Scepter upgrade)." '"

    mDisplayName = "Greater Bash"
    mName = eAbilityName.abGreater_Bash
    Me.EntityName = eEntity.abGreater_Bash

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSpirit_Breaker

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/spirit_breaker_greater_bash_hp2.png"

    Description = "Gives a chance to stun and knockback an enemy unit on an attack, as well as gaining bonus movement speed after a bash occurs. Deals a percentage of movement speed as damage."



    Cooldown = New ValueWrapper(1.5, 1.5, 1.5, 1.5)

    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    bashchance = New ValueWrapper(0.17, 0.17, 0.17, 0.17)

    movespeedasdamage = New ValueWrapper(0.22, 0.28, 0.34, 0.4)

    stunduration = New ValueWrapper(1, 1.2, 1.4, 1.6)

    knockbackduration = New ValueWrapper(0.5, 0.5, 0.5, 0.5)

    bonusmovespeed = New ValueWrapper(0.15, 0.15, 0.15, 0.15)

    speedduration = New ValueWrapper(3, 3, 3, 3)
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

    'Dim thechance = bashchance.Item(theabilitylevel - 1)

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                   theowner, _
                                                   thetarget, _
                                                   "", eModifierCategory.Passive)


    Dim moveval As New modValue(bonusmovespeed, eModifierType.MoveSpeedPercent, occurencetime, aghstime)
    moveval.mValueDuration = speedduration
    moveval.mPercentChance = bashchance

    Dim themove As New Modifier(moveval, notargetself)
    outmods.Add(themove)






    Dim autocastenemy = Helpers.GetAutoCastEnemyTargetInfo(theability_InfoID, _
                                                           theowner, _
                                                           thetarget, _
                                                           "", eModifierCategory.Passive)





    Dim stunval As New modValue(stunduration, eModifierType.Stun, occurencetime, aghstime)
    stunval.mValueDuration = stunduration
    stunval.mPercentChance = bashchance

    Dim thestun As New Modifier(stunval, autocastenemy)
    outmods.Add(thestun)



    Dim knockval As New modValue(knockbackduration, eModifierType.Knockback, occurencetime, aghstime)
    knockval.mValueDuration = knockbackduration

    Dim knockmod As New Modifier(knockval, autocastenemy)
    outmods.Add(knockmod)





    Return outmods
  End Function
End Class
