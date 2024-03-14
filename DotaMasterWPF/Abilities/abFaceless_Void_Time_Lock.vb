Public Class abTime_Lock
  Inherits AbilityBase


  Public stundamagechance As ValueWrapper
  Public bonusdamage As ValueWrapper
  Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True 'FixFixFix
    PiercesSpellImmunity = True

    Notes = "" 'FixFixFix"

    mDisplayName = "Time Lock"
    mName = eAbilityName.abTime_Lock

    Me.EntityName = eEntity.abTime_Lock

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untFaceless_Void

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/faceless_void_time_lock_hp2.png"

    Description = "Adds the chance for an attack to lock an enemy unit in time, stunning it and dealing bonus damage."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical


    Duration = New ValueWrapper(1, 1, 1, 1)

    stundamagechance = New ValueWrapper(0.1, 0.15, 0.2, 0.25)

    bonusdamage = New ValueWrapper(40, 50, 60, 70)
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

    Dim unittargetenemytarget = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                                     theowner, _
                                                                     thetarget, _
                                                                     "", eModifierCategory.Passive)

    Dim stunval As New modValue(Duration, eModifierType.RightClickStun, occurencetime, aghstime)
    stunval.mPercentChance = stundamagechance

    Dim stunmod As New Modifier(stunval, unittargetenemytarget)
    outmods.Add(stunmod)



    Dim damval As New modValue(bonusdamage, eModifierType.RightClickBonusDamageInflicted, occurencetime, aghstime)
    damval.mPercentChance = stundamagechance


    Dim dammod As New Modifier(damval, unittargetenemytarget)
    outmods.Add(dammod)

    Return outmods

  End Function
End Class
