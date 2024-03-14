Public Class abDispersion
  Inherits AbilityBase


  Dim damreflected As ValueWrapper
  Dim minradius As ValueWrapper
  Dim maxradius As ValueWrapper

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

    mDisplayName = "Dispersion"
    mName = eAbilityName.abDispersion
    Me.EntityName = eEntity.abDispersion

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSpectre

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/spectre_dispersion_hp2.png"

    Description = "Damage done to Spectre is reflected on her enemies, leaving her unharmed. The effect lessens with distance."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Pure

    damreflected = New ValueWrapper(0.1, 0.14, 0.18, 0.22)

    maxradius = New ValueWrapper(1000, 1000, 1000, 1000)

    minradius = New ValueWrapper(300, 300, 300, 300)


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

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                   theowner, _
                                                   thetarget, _
                                                   "", eModifierCategory.Passive)

    Dim notargetattacker = Helpers.GetNoTargetAttackingEnemyUnitInfo(theability_InfoID, _
                                                   theowner, _
                                                   thetarget, _
                                                   "", eModifierCategory.Passive)


    Dim damreductval As New modValue(damreflected, eModifierType.TargetedDamageReflected, occurencetime, aghstime)

    Dim damredmod As New Modifier(damreductval, notargetself)
    outmods.Add(damredmod)


    Dim damreflectval As New modValue(damreflected, eModifierType.ReflectedDamageInflicted, occurencetime, aghstime)

    Dim damrefectmod As New Modifier(damreflectval, notargetattacker)
    outmods.Add(damrefectmod)


    Return outmods
  End Function
End Class
