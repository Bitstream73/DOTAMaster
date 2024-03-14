Public Class abAftershock
Inherits AbilityBase

  Private thedamspulses As ValueWrapper
Public Sub New()
    BlockedByMagicImmune = True '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Using items does not trigger Aftershock icon.png Aftershock.|Aftershock icon.png Aftershock's damage and stun is applied before the triggering spell's effects are applied.|The stun does not stack with the stun of Fissure icon.png Fissure. It follows the regular rule of stuns – the longer stun overrides the shorter one." '"

    mDisplayName = "Aftershock"
    mName = eAbilityName.abAftershock
    Me.EntityName = eEntity.abAftershock

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untEarthshaker

    mAbilityPosition = 3

    mIsUltimate = False
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/earthshaker_aftershock_hp2.png"

    Description = "Causes the earth to shake underfoot, adding additional damage and stuns to nearby enemy units when Earthshaker casts his abilities."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(25, 75, 100, 125)


    Duration = New ValueWrapper(0.6, 0.9, 1.2, 1.5)

    Radius = New ValueWrapper(300, 300, 300, 300)

    'thedamspulses = New ValueWrapper(2, 3, 4, 5)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim passiveautocast = Helpers.GetAutoCastEnemyUnitsInfo(theability_InfoID, _
                                                            thecaster, _
                                                            thetarget, _
                                                            "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)
    ' damval.Charges = thedamspulses

    Dim thedamage As New Modifier(damval, passiveautocast)
    outmods.Add(thedamage)

    Dim stunval As New modValue(Duration, eModifierType.Stun, occurencetime, aghstime)
    stunval.mValueDuration = Duration

    Dim thestun As New Modifier(stunval, passiveautocast)
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
