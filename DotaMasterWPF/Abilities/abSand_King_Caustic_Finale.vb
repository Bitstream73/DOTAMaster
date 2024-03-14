Public Class abCaustic_Finale
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
    PiercesSpellImmunity = False

    Notes = "" 'FixFixFix"

    mDisplayName = "Caustic Finale"
    mName = eAbilityName.abCaustic_Finale
    Me.EntityName = eEntity.abCaustic_Finale

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untSand_King

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/sandking_caustic_finale_hp2.png"

    Description = "Sand King's attacks inject a venom that causes enemy units to explode violently upon death, spreading area damage. Caustic Finale is a Unique Attack Modifier, and does not stack with other Unique Attack Modifier."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untEnemyUnit)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(90, 130, 170, 220)

    Duration = New ValueWrapper(8, 8, 8, 8)

    Radius = New ValueWrapper(400, 400, 400, 400)
  End Sub

 

  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                  theowner As idisplayunit, _
                                                 thetarget As iDisplayUnit, _
                                                  ftarget As iDisplayUnit, _
                                                  isfriendbias As Boolean, _
                                                  occurencetime As Lifetime, aghstime As Lifetime) As modifierlist

    Dim outmods As New ModifierList

    Dim unittargetenemy = Helpers.GetUnitTargetEnemyTargetInfo(theability_InfoID, _
                                                               theowner, _
                                                               thetarget, _
                                                               "", eModifierCategory.Passive)

    Dim damval As New modValue(Damage, eModifierType.RightClickCausticFinale, occurencetime, aghstime)
    damval.mValueDuration = Duration

    Dim dammod As New Modifier(damval, unittargetenemy)
    outmods.Add(dammod)

    Return outmods
  End Function
End Class
