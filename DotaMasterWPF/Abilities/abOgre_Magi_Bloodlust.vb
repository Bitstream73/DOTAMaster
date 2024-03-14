Public Class abBloodlust
Inherits AbilityBase
  Public movespeed As ValueWrapper
  Public attspeed As ValueWrapper

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

    mDisplayName = "Bloodlust"
    mName = eAbilityName.abBloodlust
    Me.EntityName = eEntity.abBloodlust

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untOgre_Magi

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/ogre_magi_bloodlust_hp2.png"

    Description = "Incites a frenzy in a friendly unit, increasing its movement speed and attack speed."


    ManaCost = New ValueWrapper(75, 75, 75, 75)
    Cooldown = New ValueWrapper(20, 20, 20, 20)

    AbilityTypes.Add(eAbilityType.AutoCast)
    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untAlliedUnit)

    Duration = New ValueWrapper(30, 30, 30, 30)

    movespeed = New ValueWrapper(0.1, 0.12, 0.14, 0.16)

    attspeed = New ValueWrapper(20, 30, 40, 50)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetally = Helpers.GetUnitTargetAlliedUnitInfo(theability_InfoID, _
                                                             thecaster, _
                                                             thetarget, _
                                                             "", eModifierCategory.Passive)


    Dim attval As New modValue(attspeed, eModifierType.AttackSpeedAdded, occurencetime, aghstime)
    attval.mCooldown = Cooldown

    Dim attmod As New Modifier(attval, unittargetally)
    outmods.Add(attmod)


    Dim movemod As New modValue(movespeed, eModifierType.MoveSpeedAdded, occurencetime, aghstime)
    movemod.mCooldown = Cooldown

    Dim move As New Modifier(movemod, unittargetally)
    outmods.Add(move)

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
