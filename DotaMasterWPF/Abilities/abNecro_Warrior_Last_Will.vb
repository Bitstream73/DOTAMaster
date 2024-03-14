Public Class abNecro_Warrior_Last_Will
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

    mDisplayName = "Last Will"
    mName = eAbilityName.abNecro_Warrior_Last_Will
    Me.EntityName = eEntity.abNecro_Warrior_Last_Will

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untNecro_Warrior

    mAbilityPosition = 1

    mIsUltimate = False
    mIsAghsUpgradable = False
    'mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/d/d7/Last_Will_%28Necronomicon_Warrior%29_icon.png?version=53534d4c2826c09e5cf4f85ed4870487"
    WebpageLink = "http://dota2.gamepedia.com/Necronomicon#Necronomicon_Archer"
    Description = "Damage dealt to unit that kills Necronomicon Warrior."
    Notes = "Does not affect allied units, so it can be denied without taking damage.|Does not affect wards and buildings."

    '    mManaCost = New ValueWrapper()

    'mCooldown = New ValueWrapper()

    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untAttackingEnemyUnit)
    'mAffects.Add(eUnit)

    '    mDuration = New ValueWrapper()
    Damage = New ValueWrapper(550, 675, 800)
    DamageType = eDamageType.Magical

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim attackingenemy = Helpers.GetPassiveAttackingEnemyInfo(theability_InfoID, _
                                                                             thecaster, _
                                                                             thetarget, _
                                                                             "", eModifierCategory.Active)

    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, attackingenemy)
    outmods.Add(dammod)



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
