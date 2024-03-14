Public Class abReapers_Scythe
  Inherits AbilityBase

  Public damageperhp As ValueWrapper

  Public sceptermanacost As New List(Of Double?)
  Public sceptercooldown As New List(Of Double?)
  Public scepterdamageperhp As New List(Of Double?)

  Public stunduration As ValueWrapper
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

    Notes = "Damage is calculated and dealt at the end of the stun.|Instant-kill HP threshold, with the base 25% magic resist factored in and without Aghanim's Scepter, can be calculated by multiplying the enemy max health with the constants: 3/13 (23%), 9/29 (31%), or 27/67 (40%) for each respective level of the ultimate. With Scepter, the values change to 9/29 (31%), 27/67 (40%), and 9/19 (47%).|Even if the target is killed by another source before the damage is applied, the kill is credited to Necrophos. He still receives a Sadist buff, and the enemy hero still has extended respawn time." '"

    mDisplayName = "Reaper's Scythe"
    mName = eAbilityName.abReapers_Scythe
    Me.EntityName = eEntity.abReapers_Scythe

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untNecrophos

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/necrolyte_reapers_scythe_hp2.png"

    Description = "Stuns the target enemy hero, then deals damage based on how much life it is missing. Heroes killed by Reaper's Scythe will have 30% more time added to their respawn timer. Any kill under this effect is credited to Necrophos. Upgradable by Aghanim's Scepter."


    ManaCost = New ValueWrapper(175, 340, 500)
    sceptermanacost.Add(150)
    sceptermanacost.Add(340)
    sceptermanacost.Add(500)
    ManaCost.LoadScepterValues(sceptermanacost)

    Cooldown = New ValueWrapper(100, 85, 70)
    sceptercooldown.Add(70)
    sceptercooldown.Add(70)
    sceptercooldown.Add(70)
    Cooldown.LoadScepterValues(sceptercooldown)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyHeroes)

    DamageType = eDamageType.Magical

    damageperhp = New ValueWrapper(0.4, 0.6, 0.9)
    scepterdamageperhp.Add(0.6)
    scepterdamageperhp.Add(0.9)
    scepterdamageperhp.Add(1.2)
    damageperhp.LoadScepterValues(scepterdamageperhp)

    stunduration = New ValueWrapper(1.5, 1.5, 1.5)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemyhero = Helpers.GetUnitTargetEnemyHeroInfo(theability_InfoID, _
                                                                 thecaster, _
                                                                 thetarget, _
                                                                 "", eModifierCategory.Active)



    Dim damval As New modValue(damageperhp, eModifierType.DamageMagicalPerMissingHP, occurencetime, aghstime)

    Dim dampermissinghp As New Modifier(damval, unittargetenemyhero)
    outmods.Add(dampermissinghp)

    Dim thestunval As New modValue(stunduration, eModifierType.Stun, occurencetime, aghstime)
    thestunval.mValueDuration = stunduration

    Dim thestun As New Modifier(thestunval, unittargetenemyhero)
    outmods.Add(thestun)

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
