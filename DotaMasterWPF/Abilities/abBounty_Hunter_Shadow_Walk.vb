Public Class abShadow_Walk
Inherits AbilityBase

  Public fadetime As ValueWrapper
  Public bonusdamage As ValueWrapper

Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Has an instant cast time and does not interrupt channeling.|The bonus damage is not added to Bounty Hunter's attack damage. This means that its damage is unaffected by e.g. Enfeeble or Empower.|This also means that Bounty Hunter can't lifesteal of it and the damage can't crit or cleave.|During the fade time, Bounty Hunter can cast spells, use items and perform attacks without breaking the invisibility. Those attacks will apply the Shadow Walk damage.|Invisibility is broken upon reaching the cast point of spells or items, or upon landing an attack. Missed attacks will not break it.|Shadow Walk allows Bounty Hunter to path through other units, including wards, but not through buildings.|Bounty Hunter can pick up, drop or attack items without breaking the invisibility." '"
    mDisplayName = "Shadow Walk"
    mName = eAbilityName.abShadow_Walk
    Me.EntityName = eEntity.abShadow_Walk

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untBounty_Hunter

    mAbilityPosition = 3

mIsUltimate = False 'FixFixFix
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/bounty_hunter_wind_walk_hp2.png"

    Description = "Bounty Hunter becomes invisible and gains the ability to move through other units until he attacks or uses an ability. If he breaks the invisibility with an attack, that attack will deal bonus damage."

    ManaCost = New ValueWrapper(50, 50, 50, 50)

    Cooldown = New ValueWrapper(15, 15, 15, 15)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Physical


    Duration = New ValueWrapper(20, 25, 30, 35)

    fadetime = New ValueWrapper(1, 0.75, 0.5, 0.25)

    bonusdamage = New ValueWrapper(30, 60, 90, 120)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Active)



    'phase
    Dim phaseval As New modValue(Duration, eModifierType.Phase_Form, occurencetime, aghstime)
    phaseval.mValueDuration = Duration

    Dim thephase As New Modifier(phaseval, notargetself)
    outmods.Add(thephase)



    'invis
    Dim invisval As New modValue(Duration, eModifierType.Invisibility, occurencetime, aghstime)
    invisval.mValueDuration = Duration
    Dim theinvs As New Modifier(invisval, notargetself)
    outmods.Add(theinvs)


    Dim damval As New modValue(bonusdamage, eModifierType.BonusDamage, occurencetime, aghstime)
    damval.Charges = New ValueWrapper(1, 1, 1, 1)

    Dim thedamage As New Modifier(damval, notargetself)
    outmods.Add(thedamage)

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
