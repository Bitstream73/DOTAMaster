Public Class abRearm
  Inherits AbilityBase
  Public timetorearm As ValueWrapper
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

    Notes = "Rearm works on all items except Black King Bar, Arcane Boots, Helm of the Dominator, Hand of Midas, Refresher Orb, Linken's Sphere, Bottle and Necronomicon.|Manta Style will refresh, however the old illusions will disappear when it is reused.|Since this spell is channeled, activating it will use mana but will not refresh abilities until it finishes casting. Interrupting Rearm (making another action, getting stunned/hexed/silenced/etc) during its channeling will waste mana and not refresh Tinker's abilities." '"

    mDisplayName = "Ream"
    mName = eAbilityName.abRearm
    Me.EntityName = eEntity.abRearm

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTinker

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/tinker_rearm_hp2.png"

    Description = "CHANNELED - Resets the cooldown on most of Tinker's items and abilities."

    ManaCost = New ValueWrapper(150, 250, 350)
    
    AbilityTypes.Add(eAbilityType.NoTarget)
    AbilityTypes.Add(eAbilityType.Channeled)

    Affects.Add(eUnit.untSelf)

    timetorearm = New ValueWrapper(3, 2, 1)

  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim channeledself = Helpers.GetChanneledSelfInfo(theability_InfoID, _
                                                     thecaster, _
                                                     thetarget, _
                                                     "", eModifierCategory.Active)

    Dim resetval As New modValue(1, eModifierType.Reset_Cooldowns, occurencetime)

    Dim thereset As New Modifier(resetval, channeledself)
    outmods.Add(thereset)

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
