Public Class abCraggy_Exterior
Inherits AbilityBase

  Public chancetostun As ValueWrapper
  Public bonusarmor As ValueWrapper
  Public stunduration As ValueWrapper

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

    Notes = "Works on direct attacks within 300 range of Tiny, thus ranged attackers also can be affected.|The stun and damage occur at the beginning of the attack, not when the attack lands.|Works against invisible units, but they won't be revealed." '"

    mDisplayName = "Craggy Exterior"
    mName = eAbilityName.abCraggy_Exterior
    Me.EntityName = eEntity.abCraggy_Exterior

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTiny

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False '

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/tiny_craggy_exterior_hp2.png"

    Description = "Causes damage to bounce back on Tiny's attackers. Enemies that attack Tiny from within 300 units have a chance of being stunned."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(25, 35, 45, 55)


    chancetostun = New ValueWrapper(0.1, 0.15, 0.2, 0.25)

    stunduration = New ValueWrapper(1, 1.25, 1.5, 1.75)

    bonusarmor = New ValueWrapper(2, 3, 4, 5)

    Range = New ValueWrapper(300, 300, 300, 300)
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

    Dim passiveattacker = Helpers.GetPassiveAttackingEnemyInfo(theability_InfoID, _
                                                               theowner, _
                                                                thetarget, _
                                                                "", eModifierCategory.Passive)


    Dim valdam As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim moddam As New Modifier(valdam, passiveattacker)
    outmods.Add(moddam)


    Dim valstun As New modValue(stunduration, eModifierType.Stun, occurencetime, aghstime)
    valstun.mValueDuration = stunduration
    valstun.mPercentChance = chancetostun

    Dim modstun As New Modifier(valstun, passiveattacker)
    outmods.Add(modstun)

    Return outmods
  End Function
End Class
