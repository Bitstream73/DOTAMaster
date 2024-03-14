Public Class abForged_Spirit_Melting_Strike
  Inherits AbilityBase
  Public armorreduction As ValueWrapper
  Public armorreductcap As ValueWrapper

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

    mDisplayName = "Melting Strike"
    mName = eAbilityName.abForged_Spirit_Melting_Strike
    Me.EntityName = eEntity.abForged_Spirit_Melting_Strike

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untForged_Spirit

    mAbilityPosition = 0

    mIsUltimate = False
    mIsAghsUpgradable = False
    'mHasAghs = False

    mAbilityImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/9/9a/Melting_Strike_%28Forged_Spirit%29_icon.png"
    WebpageLink = "http://dota2.gamepedia.com/Invoker#Forged_Spirit"
    Description = "Melts away the armor of heroes hit by the spirit's attack if the spirit has enough mana. Each successive hit increases the amount of armor melted."
    Notes = "Successive attacks fully refresh the whole stack's duration.|The armor reduction is applied or increased after the attack damage is applied.|Only affects heroes and illusion, and nothing else.|The mana is used when the attack successfully hits the target, not upon projectile launch.|This means that missed or disjointed attacks do not cost any mana."

    ManaCost = New ValueWrapper(40)

    Cooldown = New ValueWrapper(0)

    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untEnemyTarget)


    Duration = New ValueWrapper(5)

    armorreduction = New ValueWrapper(1)

    armorreductcap = New ValueWrapper(10)
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

    Dim armval As New modValue(armorreduction, eModifierType.ArmorSubtractedoT, occurencetime, aghstime)
    armval.Charges = armorreductcap
    armval.mValueDuration = Duration

    Dim armmod As New Modifier(armval, unittargetenemy)
    outmods.Add(armmod)


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
