Public Class abHookshot
Inherits AbilityBase

  Public stunduration As ValueWrapper
  Public sceptercooldown As New List(Of Double?)
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
    mDisplayName = "Hookshot"
    mName = eAbilityName.abHookshot
    Me.EntityName = eEntity.abHookshot

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untClockwerk

    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/rattletrap_hookshot_hp2.png"

    Description = "Fires a grappling device rapidly at the target location. If the hook hits a non-neutral unit, Clockwerk launches himself into the target, stunning and dealing damage. Any enemies Clockwerk collides with along the way are subject to damage and stunned. Upgradable by Aghanim's Scepter."

    ManaCost = New ValueWrapper(150, 150, 150)

    Cooldown = New ValueWrapper(70, 55, 40)
    sceptercooldown.Add(12)
    sceptercooldown.Add(12)
    sceptercooldown.Add(12)
    Cooldown.LoadScepterValues(sceptercooldown)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(100, 200, 300)

    Range = New ValueWrapper(2000, 2500, 3000)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetline = Helpers.GetPointTargetLineEnemyUnitsInfo(theability_InfoID, _
                                                                   thecaster, _
                                                                    thetarget, _
                                                                    "", eModifierCategory.Active)

    Dim pointtargetself = Helpers.GetPointTargetSelfInfo(theability_InfoID, _
                                                         thecaster, _
                                                         thetarget, _
                                                         "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, pointtargetline)
    outmods.Add(dammod)


    Dim pullval As New modValue(1, eModifierType.PullForward, occurencetime)

    Dim pullmod As New Modifier(pullval, pointtargetself)
    outmods.Add(pullmod)


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
