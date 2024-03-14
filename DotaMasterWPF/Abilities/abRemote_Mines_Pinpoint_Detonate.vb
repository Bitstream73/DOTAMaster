Public Class abRemote_Mines_Pinpoint_Detonate
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

    mDisplayName = "Pinpoint Detonate"
    mName = eAbilityName.abRemote_Mines_Pinpoint_Detonate

    Me.EntityName = eEntity.abRemote_Mines_Pinpoint_Detonate

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untRemote_Mine

    mAbilityPosition = 0

    mIsUltimate = False
    mIsAghsUpgradable = False
    '    mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/e/e1/Remote_Mines_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Remote_Mines#Remote_Mines"
    Description = "Detonate all selected remote mines."
    Notes = "This is cast from the mine itself. This allows Techies to trigger mines when he can't use his ability, Focused Detonate (e.g., while silenced, stunned, or dead).|Detonates all selected remote mines with a 0.03 second delay from each other.|Pinpoint Detonate has an instant cast time."

    'mManaCost = New ValueWrapper()

    ' mCooldown = New ValueWrapper()

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untEnemyUnits)
    '    mAffects.Add(eUnit)

    ' mDuration = New ValueWrapper()

    Radius = New ValueWrapper(425, 425, 425)
    Damage = New ValueWrapper(300, 450, 600)
    DamageType = eDamageType.Magical
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim activeenemies = Helpers.GetActiveAuraEnemyUnitsInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, activeenemies)
    outmods.Add(dammod)

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
