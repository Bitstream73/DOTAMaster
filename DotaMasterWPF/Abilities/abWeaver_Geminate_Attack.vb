Public Class abGeminate_Attack
Inherits AbilityBase


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

    Notes = "Geminate Attack icon.png Geminate Attack is not a unique attack modifier.|Geminate Attack icon.png Geminate Attack can be disjointed.|Geminate Attack icon.png Geminate Attack procs are independent of normal attacks. It has no impact on Weaver's attack speed or attack rate.|Geminate Attack icon.png Geminate Attack is treated like a regular attack, and thus can miss, but also can trigger any attack modifier like crits or unique attack modifier.|Geminate Attack icon.png Geminate Attack is fired instantly when the target is hit. When the leading attack is evaded or disjointed, Geminate Attack does not proc.|Geminate Attack icon.png Geminate Attack triggers as the leading projectile hits. Means even when the projectile was launched during cooldown, it will still trigger when it went off cooldown meanwhile.|Geminate Attack icon.png Geminate Attack has no maximum range. If your attack target moves far away and you don't attack any other unit meanwhile, it still will proc Geminate Attack.|However, if you attack another unit while your projectile flies, the new attack target will get hit when that flying projectile lands, instead of the now far away target." '"

    mDisplayName = "Germinate Attack"
    mName = eAbilityName.abGeminate_Attack
    Me.EntityName = eEntity.abGeminate_Attack

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untWeaver

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/weaver_geminate_attack_hp2.png"

    Description = "Allows Weaver to dispatch two swarms, attacking an enemy twice. The extra attack will not trigger other attack effects (such as critical strike) and overrides Unique Attack Modifiers."

    Cooldown = New ValueWrapper(6, 5, 4, 3)

    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)




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

    Dim autocastself = Helpers.GetAutoCastSelfInfo(theability_InfoID, _
                                                   theowner, _
                                                   thetarget, _
                                                    "", eModifierCategory.Passive)


    Dim rightval As New modValue(2, eModifierType.RightClickDamageMultiplier, Cooldown, occurencetime)

    Dim rightdoubler As New Modifier(rightval, autocastself)
    outmods.Add(rightdoubler)

    Return outmods
  End Function
End Class
