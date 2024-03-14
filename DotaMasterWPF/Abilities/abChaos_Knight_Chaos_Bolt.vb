Public Class abChaos_Bolt
Inherits AbilityBase
  Public minstun As ValueWrapper
  Public maxstun As ValueWrapper
  Public mindamage As ValueWrapper
  Public maxdamage As ValueWrapper
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

    mName = eAbilityName.abChaos_Bolt
    Me.EntityName = eEntity.abChaos_Bolt


    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untChaos_Knight
    mDisplayName = "Bolt"
    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/chaos_knight_chaos_bolt_hp2.png"

    Description = "Throws a mysterious bolt of energy at the target unit. It stuns for a random duration and deals random damage."

    ManaCost = New ValueWrapper(140, 140, 140, 140)

    Cooldown = New ValueWrapper(10, 10, 10, 10)

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical



  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemytarget = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                                     thecaster, _
                                                                     thetarget, _
                                                                     "", eModifierCategory.Active)

    Dim damval As New modValue(maxdamage, eModifierType.DamageMagicalRandomInflicted, occurencetime, aghstime)
    damval.mValueMax = maxdamage
    damval.mValueMin = mindamage

    Dim dammod As New Modifier(damval, unittargetenemytarget)
    outmods.Add(dammod)


    Dim stunval As New modValue(maxstun, eModifierType.StunRandom, occurencetime, aghstime)
    stunval.mValueMax = maxstun
    stunval.mValueMin = minstun

    Dim stunmod As New Modifier(stunval, unittargetenemytarget)
    outmods.Add(stunmod)

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
