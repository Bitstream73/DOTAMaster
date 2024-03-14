Public Class abEarth_Brewmaster_Hurl_Boulder
  Inherits AbilityBase
  Public stunduration As ValueWrapper
  Public Sub New()

    BlockedByMagicImmune = True
    RemovedByMagicImmune = False
    CanBePurged = False
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = True
    BreaksStun = False
    IsUniqueAttackModifier = False
    PiercesSpellImmunity = False

    Notes = "he boulder travels at a speed of 800 and can be disjointed."

    mDisplayName = "Hurl Boulder"
    mName = eAbilityName.abEarth_Brewmaster_Hurl_Boulder

    Me.EntityName = eEntity.abEarth_Brewmaster_Hurl_Boulder

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untEarth_Brewmaster

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False 'Check This
    'mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/1/19/Hurl_Boulder_%28Earth%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Brewmaster"
    Description = "Throws a boulder at a unit, doing damage and stunning it."

    Range = New ValueWrapper(800)
    Damage = New ValueWrapper(50)
    stunduration = New ValueWrapper(2)
    Cooldown = New ValueWrapper(7)
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetenemy = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                                         thecaster, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamagePhysicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, unittargetenemy)
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
