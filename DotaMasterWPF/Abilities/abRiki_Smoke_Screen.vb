Public Class abSmoke_Screen
Inherits AbilityBase

  Public missrate As ValueWrapper
  Public moveslow As ValueWrapper
  Public attslow As ValueWrapper
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

    mDisplayName = "Smoke Screen"
    mName = eAbilityName.abSmoke_Screen
    Me.EntityName = eEntity.abSmoke_Screen

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untRiki

    mAbilityPosition = 1

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/riki_smoke_screen_hp2.png"

    Description = "Throws down a smoke bomb, silencing and slowing enemy units in an area while causing them to miss on most attacks. Lasts 6 seconds."

    ManaCost = New ValueWrapper(75, 80, 85, 90)

    Cooldown = New ValueWrapper(11, 11, 11, 11)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    Radius = New ValueWrapper(250, 275, 300, 325)

    missrate = New ValueWrapper(0.4, 0.5, 0.6, 0.7)

    moveslow = New ValueWrapper(0.25, 0.25, 0.25, 0.25)

    attslow = New ValueWrapper(25, 25, 25, 25)


    Duration = New ValueWrapper(6, 6, 6, 6)
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

    'silence
    Dim silenceval As New modValue(Duration, eModifierType.Silence, occurencetime, aghstime)
    silenceval.mValueDuration = Duration

    Dim silencemod As New Modifier(silenceval, pointtargetenemies)
    outmods.Add(silencemod)


    'movement slow
    Dim slowval As New modValue(moveslow, eModifierType.MoveSpeedPercentSubtracted, occurencetime, aghstime)
    slowval.mValueDuration = Duration

    Dim slowmod As New Modifier(slowval, pointtargetenemies)
    outmods.Add(slowmod)

    'attack slow
    Dim attval As New modValue(attslow, eModifierType.AttackspeedSubtracted, occurencetime, aghstime)
    attval.mValueDuration = Duration

    Dim attmod As New Modifier(attval, pointtargetenemies)
    outmods.Add(attmod)





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
