Public Class abLast_Word
Inherits AbilityBase
  Public debuffduration As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True 'FixFixFix
    PiercesSpellImmunity = False

    Notes = "" 'FixFixFix"

    mDisplayName = "Last Word"
    mName = eAbilityName.abLast_Word
    Me.EntityName = eEntity.abLast_Word

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSilencer

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/silencer_last_word_hp2.png"

    Description = "Enchants a target damaging and silencing them if they cast a spell. If the enchantment expires the target will be disarmed in addition to being damaged and silenced."

    ManaCost = New ValueWrapper(115, 115, 115, 115)

    Cooldown = New ValueWrapper(36, 28, 20, 12)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical

    debuffduration = New ValueWrapper(5, 5, 5, 5)

    Damage = New ValueWrapper(150, 200, 250, 300)
    Duration = New ValueWrapper(3, 4, 5, 6)
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

    Dim silval As New modValue(Duration, eModifierType.Silence, occurencetime, aghstime)
    silval.mValueDuration = Duration

    Dim silmod As New Modifier(silval, unittargetenemy)
    outmods.Add(silmod)



    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, unittargetenemy)
    outmods.Add(dammod)



    Dim disval As New modValue(Duration, eModifierType.Disarm, occurencetime, aghstime)
    disval.mValueDuration = Duration

    Dim dismod As New Modifier(disval, unittargetenemy)
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
