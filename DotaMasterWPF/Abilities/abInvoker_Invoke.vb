Public Class abInvoke
  Inherits AbilityBase


  Public sceptercooldowns As New List(Of Double?)
  Public sceptermanacost As New List(Of Double?)
  Public maxspells As ValueWrapper
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

    mDisplayName = "Invoke"
    mName = eAbilityName.abInvoke
    Me.EntityName = eEntity.abInvoke

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untInvoker

    mAbilityPosition = 4

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/invoker_invoke_hp2.png"

    Description = "Combines the properties of the elements currently being manipulated, creating a new spell at the Invoker's disposal. Click the help button to see the list of possible spells. Upgradable by Aghanim's Scepter."

    ManaCost = New ValueWrapper(20, 40, 60, 80)
    sceptermanacost.Add(0)
    sceptermanacost.Add(0)
    sceptermanacost.Add(0)
    sceptermanacost.Add(0)
    ManaCost.LoadScepterValues(sceptercooldowns)

    Cooldown = New ValueWrapper(22, 17, 12, 5)
    sceptercooldowns.Add(16)
    sceptercooldowns.Add(8)
    sceptercooldowns.Add(4)
    sceptercooldowns.Add(2)
    Cooldown.LoadScepterValues(sceptercooldowns)

    maxspells = New ValueWrapper(2, 2, 2, 2)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)




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
                                                 "", eModifierCategory.Passive)

    Dim invval As New modValue(maxspells, eModifierType.InvokeASpell, occurencetime, aghstime)
    invval.mCooldown = Cooldown

    Dim invmod As New Modifier(invval, notargetself)
    outmods.Add(invmod)

    Return outmods
  End Function


  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, caster As iDisplayUnit, target As iDisplayUnit, ftarget As iDisplayUnit, isfriendbias As Boolean, occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim passiveself = Helpers.GetPassiveSelfInfo(theability_InfoID, _
                                                 caster, _
                                                 target, _
                                                 "", eModifierCategory.Passive)

    Dim spellval As New modValue(maxspells, eModifierType.InvokeSpellCount, occurencetime, aghstime)

    Dim spellmod As New Modifier(spellval, passiveself)
    outmods.Add(spellmod)

    Return outmods
  End Function

End Class
