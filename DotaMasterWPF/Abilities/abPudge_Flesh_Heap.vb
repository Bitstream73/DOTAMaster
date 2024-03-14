Public Class abFlesh_Heap
Inherits AbilityBase

  Public magicresistance As ValueWrapper
  Public strengthbonus As ValueWrapper
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

    mDisplayName = "Flesh Heap"
    mName = eAbilityName.abFlesh_Heap
    Me.EntityName = eEntity.abFlesh_Heap

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untPudge

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/pudge_flesh_heap_hp2.png"

    Description = "Gives Pudge resistance to magic damage, as well as bonus strength that increases each time Pudge kills an enemy Hero or it dies in his vicinity. Flesh Heap is retroactive, meaning it can gain charges before it is skilled, which then become active."



    AbilityTypes.Add(eAbilityType.Passive)

    Affects.Add(eUnit.untSelf)


    magicresistance = New ValueWrapper(0.06, 0.08, 0.1, 0.12)

    strengthbonus = New ValueWrapper(1, 1.5, 2, 2.5)

    Range = New ValueWrapper(450, 450, 450, 450)
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

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                               theowner, _
                                               thetarget, _
                                               "", eModifierCategory.Passive)
    Dim outmods As New ModifierList

    Dim magval As New modValue(magicresistance, eModifierType.MagicResistancePercentAdded, occurencetime, aghstime)

    Dim magmod As New Modifier(magval, notargetself)
    outmods.Add(magmod)


    Dim strval As New modValue(strengthbonus, eModifierType.StrAddedPerKill, occurencetime, aghstime)

    Dim strmod As New Modifier(strval, notargetself)
    outmods.Add(strmod)


    Return outmods
  End Function
End Class
