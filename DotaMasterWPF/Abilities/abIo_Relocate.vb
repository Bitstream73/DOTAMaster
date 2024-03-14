Public Class abRelocate
  Inherits AbilityBase
  Public returntime As ValueWrapper
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

    Notes = "If Io is interrupted during the casting delay, Relocate will be cancelled.|Can be casted while Io is ensnared, but the teleport won't happen when still ensnared after the delay.|Disabling the tethered ally of Io won't prevent the ally from getting teleported if Io successfully teleports.|The returning teleportation cannot be prevented.|Indicators:|Enemies get a notification on their minimap during the teleport delay, showing them where Relocate was targeted.|Creates a visual effect at the targeted point during the teleport delay, which is visible to everyone. Also provides small vision at that point for Io during the delay.|Creates a visual effect at Io's position before the teleport happens, which also is visible to everyone. This one does not provide vision though.|Relocate interrupts channeling spells and every current order of Io and the tethered ally both on initial teleport, and when going back.|If Io is Tethered to a unit, the Tether's duration will be refreshed before and after the delay before teleport.|Io may sever its Tether at any time to prevent bringing an ally back.|Can only teleport heroes, illusions, the Spirit Bear, Warlock's Golem and the Storm and Fire spirits from Brewmaster's Primal Split.|Destroys trees within 300 aoe around Io upon both teleports." '"

    mDisplayName = "Relocate"
    mName = eAbilityName.abRelocate
    Me.EntityName = eEntity.abRelocate

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untIo

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/wisp_relocate_hp2.png"

    Description = "Teleport yourself and any tethered ally to any location on the map. After the spell expires you and any tethered ally will return to where you teleported from."


    ManaCost = New ValueWrapper(100, 100, 100)


    Cooldown = New ValueWrapper(90, 75, 60)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    returntime = New ValueWrapper(12, 12, 12)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim unittargetally = Helpers.GetUnitTargetAlliedUnitInfo(theability_InfoID, _
                                                             thecaster, _
                                                             thetarget, _
                                                             "Io and tethered ally return after " & returntime.ToString & " seconds", eModifierCategory.Active)




    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                             thecaster, _
                                                             thetarget, _
                                                             "Io and tethered ally return after " & returntime.ToString & " seconds", eModifierCategory.Active)


    Dim tpval As New modValue(1, eModifierType.Teleport, occurencetime)


    Dim tpself As New Modifier(tpval, notargetself)
    outmods.Add(tpself)



    Dim tpally As New Modifier(tpval, unittargetally)
    outmods.Add(tpally)


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
