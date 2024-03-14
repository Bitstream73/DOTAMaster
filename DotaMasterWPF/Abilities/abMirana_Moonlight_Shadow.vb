Public Class abMoonlight_Shadow
Inherits AbilityBase
  Public fadedelay As ValueWrapper
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

    Notes = "Places a buff on all allied heroes. As long as this buff stays on them, they will keep turning invisible.|Buff places on allied heroes even when they are invulnerable or hidden. They also can turn invisible while invulnerable or hidden.|Attacking, casting spells or using items during the fade time resets it.|Getting silenced during the fade time prevents affected heroes from getting invisible. However, once the silence fades, they instantly turn invisible.|Silence does not reveal heroes who fully turned invisible.|Doom will always fully reveal the target, no matter if during the fade time, or the invisibility." '"

    mDisplayName = "Moonlight Shadow"
    mName = eAbilityName.abMoonlight_Shadow
    Me.EntityName = eEntity.abMoonlight_Shadow

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untMirana

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = False '

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/mirana_invis_hp2.png"

    Description = "Turns Mirana and all allied heroes invisible. If a hero is revealed, invisibility will restore after the fade delay as long as Moonlight Shadow's duration has not expired. Silence will prevent revealed units from becomming invisible."

    ManaCost = New ValueWrapper(75, 75, 75)

    Cooldown = New ValueWrapper(140, 120, 100)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    fadedelay = New ValueWrapper(2.5, 2, 1.5)

    Duration = New ValueWrapper(15, 15, 15)




  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Active)


    Dim tinvisval As New modValue(Duration, eModifierType.Invisibility, occurencetime, aghstime)
    tinvisval.mValueDuration = Duration

    Dim theinvis As New Modifier(tinvisval, notargetself)
    outmods.Add(theinvis)



    Dim alliesmapwide = Helpers.GetMapwideAuraAlliedHeroesInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Active)

    Dim theallyinvis As New Modifier(tinvisval, alliesmapwide)
    outmods.Add(theallyinvis)


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
