Public Class abCulling_Blade
  Inherits AbilityBase

  Private mkillthreshold As ValueWrapper
  Private agskillthreshold As New List(Of Double?)

  Private agscooldown As New List(Of Double?)

  Private attspeedbonus As ValueWrapper ' = 0.4
  Private bonusmovespeed As ValueWrapper ' = 0.4

  Private speedduration As ValueWrapper ' = 6
  Private agsspeedduration As New List(Of Double?) ' = 10


  Public Sub New()
    BlockedByMagicImmune = True
    RemovedByMagicImmune = True
    CanBePurged = True
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False

    PiercesSpellImmunity = True
    mDisplayName = "Culling Blade"
    Notes = "Does not go on cooldown if it successfully kills a hero.|If the target is under the HP threshold, Culling Blade does exactly the target's remaining health in unmitigable damage.|The killing blow goes through magic immunity.|The killing blow removes all buffs from the target unit before killing it. This includes any hero that is under the effects of Dazzle's Shallow Grave.|Roshan can be killed by Culling Blade.|Can be used on enemy couriers"

    mName = eAbilityName.abCulling_Blade

    Me.EntityName = eEntity.abCulling_Blade

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untAxe

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = True 'Check This
    'mHasAghs = False

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/axe_culling_blade_hp2.png"
    WebpageLink = ""
    Description = "Axe spots a weakness and strikes, instantly killing an enemy unit with low health, or dealing moderate damage otherwise. When an enemy hero is killed with Culling Blade, its cooldown is reset, and Axe and nearby allied units gain bonus movement speed. Upgradable by Aghanim's Scepter."

    ManaCost = New ValueWrapper(60, 120, 180)


    Cooldown = New ValueWrapper(75, 65, 55)
    agscooldown.Add(6)
    agscooldown.Add(6)
    agscooldown.Add(6)
    Cooldown.LoadScepterValues(agscooldown)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    mkillthreshold = New ValueWrapper(250, 350, 450)
    agskillthreshold.Add(300)
    agskillthreshold.Add(450)
    agskillthreshold.Add(625)
    mkillthreshold.LoadScepterValues(agskillthreshold)

    Damage = New ValueWrapper(150, 250, 300)

    attspeedbonus = New ValueWrapper(40, 40, 40, 40)
    bonusmovespeed = New ValueWrapper(0.4, 0.4, 0.4, 0.4)

    Duration = New ValueWrapper(6, 6, 6, 6)
    agsspeedduration.Add(10)
    agsspeedduration.Add(10)
    agsspeedduration.Add(10)
    agsspeedduration.Add(10)
    Duration.LoadScepterValues(agsspeedduration)



    Radius = New ValueWrapper(900, 900, 900)
  End Sub

  Public Function KillThreshold(hasaghs As Boolean, abilitylevel As Integer) As Integer
    If hasaghs Then
      Return mkillthreshold.ScepterValue(abilitylevel)
    Else
      Return mkillthreshold.Value(abilitylevel)
    End If

  End Function
  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList



    Dim outmods As New ModifierList

    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                                         thecaster, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Active)

    'insta kill
    Dim killval As New modValue(mkillthreshold, eModifierType.DestroysHeroBelowThreshold, occurencetime, aghstime)

    Dim instantkill As New Modifier(killval, unittargetenemytargetinfo)

    outmods.Add(instantkill)

    'damage if instakill didn't proc
    Dim damval As New modValue(Damage, eModifierType.DamageMagicalAdded, occurencetime, aghstime)

    Dim moderatedamage As New Modifier(damval, unittargetenemytargetinfo)

    outmods.Add(moderatedamage)

    'movespeed and attspeed buff self
    Dim notargetselfinfo = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                       thecaster, _
                                                       thetarget, _
                                                       "", eModifierCategory.Active)

    Dim moveval As New modValue(bonusmovespeed, eModifierType.MoveSpeedPercent, occurencetime, aghstime)

    Dim selfmovespeed As New Modifier(moveval, notargetselfinfo)

    outmods.Add(selfmovespeed)

    Dim attspeedval As New modValue(attspeedbonus, eModifierType.AttackSpeedPercentAdded, occurencetime, aghstime)

    Dim selfattspeed As New Modifier(attspeedval, notargetselfinfo)

    outmods.Add(selfattspeed)


    'movespeed and attspeed allies
    Dim auraallisinfo = Helpers.GetActiveAuraAlliedHeroesInfo(theability_InfoID, _
                                                       thecaster, _
                                                       thetarget, _
                                                       "", eModifierCategory.Active)

    Dim allymovespeed As New Modifier(moveval, auraallisinfo)

    outmods.Add(allymovespeed)


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
