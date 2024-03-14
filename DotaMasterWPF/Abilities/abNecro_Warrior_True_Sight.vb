Public Class abNecro_Warrior_True_Sight
  Inherits AbilityBase



  Public Sub New()
    BlockedByMagicImmune = False
    RemovedByMagicImmune = False
    CanBePurged = False
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False

    PiercesSpellImmunity = False

    mDisplayName = "True Sight"
    mName = eAbilityName.abNecro_Warrior_True_Sight
    Me.EntityName = eEntity.abNecro_Warrior_True_Sight

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untNecro_Warrior

    mAbilityPosition = 2

    mIsUltimate = False
    mIsAghsUpgradable = False
    'mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/c/cb/True_Sight_%28Necronomicon_Warrior%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Necronomicon#Necronomicon_Archer"
    Description = "Reveals invisible units."
    Notes = "Available for level 3 Necronomicon Warriors only.|The True Sight is provided within the whole area, regardless of the warrior's actual vision. It is fully unobstructed.|The True Sight is provided by an aura, its effect lingers for 0.5 seconds.|Can not detect units under the effect of Shadow Dance and Smoke of Deceit."

    ' mManaCost = New ValueWrapper()

    ' mCooldown = New ValueWrapper()

    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untEnemyStealthUnits)
    'mAffects.Add(eUnit)

    Duration = New ValueWrapper(-1, -1, 0) 'none at 1,2. permanent at 3

    Radius = New ValueWrapper(-1, -1, 1000)

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
                                                  caster As iDisplayUnit, _
                                                  target As iDisplayUnit, _
                                                  ftarget As iDisplayUnit, _
                                                  isfriendbias As Boolean, _
                                                  occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim passiveself = Helpers.GetPassiveAuraEnemyStealthUnitsInfo(theability_InfoID, _
                                                                             caster, _
                                                                             target, _
                                                                             "", eModifierCategory.Active)

    Dim invval As New modValue(Duration, eModifierType.Truesight, occurencetime, aghstime)
    invval.mRadius = Radius

    Dim invmod As New Modifier(invval, passiveself)
    outmods.Add(invmod)

    Return outmods
  End Function
End Class
