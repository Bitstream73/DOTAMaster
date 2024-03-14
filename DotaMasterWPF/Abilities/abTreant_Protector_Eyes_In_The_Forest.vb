Public Class abTreant_Protector_Eyes_In_The_Forest

  Inherits AbilityBase

  Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True 'FixFixFix
    'mAbilityLevelCount = 3

    Notes = "" 'FixFixFix"

    mDisplayName = "Eyes in the Forest"
    mName = eAbilityName.abEyes_In_The_Forest
    Me.EntityName = eEntity.abEyes_In_The_Forest

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTreant_Protector

    mAbilityPosition = 4

    mIsUltimate = False
    mIsAghsUpgradable = False '

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/treant_eyes_in_the_forest_hp2.png"

    Description = "Treant Protector enchants a tree, which grants him unobstructed vision in that location. If Overgrowth is cast, units within a 800 radius of a summoned tree will be entangled and damaged."

    ManaCost = New ValueWrapper(100)


    Cooldown = New ValueWrapper(25)
    

    AbilityTypes.Add(eAbilityType.UnitTarget)

    Affects.Add(eUnit.untTree)




    Radius = New ValueWrapper(800)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    ' If theabilitylevel = 0 Then Return Nothing
    Dim outmods As New ModifierList
    Dim passiveauraalliesinfo As modInfo = Helpers.GetPassiveAuraAlliedHeroesInfo(theability_InfoID, _
                                                                               thecaster, _
                                                                               thetarget, "", eModifierCategory.Active)

    Dim visval As New modValue(Radius, eModifierType.Vision, occurencetime, aghstime)
    visval.mRadius = Radius

    Dim vismod As New Modifier(visval, passiveauraalliesinfo)
    outmods.Add(vismod)

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
