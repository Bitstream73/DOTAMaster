Public Class abBerserkers_Call
Inherits AbilityBase
  Private Bonus_Armor As ValueWrapper ' = 40
  Public Sub New()
    BlockedByMagicImmune = False
    RemovedByMagicImmune = False
    CanBePurged = False
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False



    Notes = "Berserker's Call affects invisible units, as well as units with magic immunity.|Enemies who are taunted by Berserker's Call will be frozen for the duration if Axe dies or couldn't be attacked.|Does not affect towers."
    mDisplayName = "Berserker's Call"
    mName = eAbilityName.abBerserkers_Call
    Me.EntityName = eEntity.abBerserkers_Call

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untAxe

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False 'Check This
    'mHasAghs = False

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/axe_berserkers_call_hp2.png"
    WebpageLink = ""
    Description = "Axe taunts nearby enemy units, forcing them to attack him, while he gains bonus armor during the duration."

    ManaCost = New ValueWrapper(80, 90, 100, 110)

    Cooldown = New ValueWrapper(16, 14, 12, 10)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    PiercesSpellImmunity = True

    'mDamage = New ValueWrapper(0, 0, 0, 0)



    Radius = New ValueWrapper(300, 300, 300, 300)

    Bonus_Armor = New ValueWrapper(40, 40, 40, 40)

    Duration = New ValueWrapper(2, 2.4, 2.8, 3.2)
  End Sub


  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList



    Dim outmods As New ModifierList

    'bonus armor
    Dim notargetselfinfo = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                       thecaster, _
                                                       thetarget, _
                                                       "", eModifierCategory.Active)

    Dim armorval As New modValue(Bonus_Armor, eModifierType.ArmorAdded, occurencetime, aghstime)

    Dim armor As New Modifier(armorval, notargetselfinfo)

    outmods.Add(armor)


    'taunt
    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                                         thecaster, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Active)

    Dim tauntval As New modValue(Duration, eModifierType.Taunt, occurencetime, aghstime)
    tauntval.mValueDuration = Duration

    Dim taunt As New Modifier(tauntval, unittargetenemytargetinfo)
    outmods.Add(taunt)



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
