﻿Public Class itmNecronomicon_1
  Inherits ItemBase



  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmNECRONOMICON_1
    Me.EntityName = eEntity.itmNECRONOMICON_1

    mDisplayName = "Necronomicon (1)"
    'mDescription = "Considered the holy grail of necromancy and demonology, a powerful malefic force is locked within its pages. "
    mGoldCost = New ValueWrapper(2700)

    mMadeFromItems.Add(eItemname.itmRECIPE_NECRONOMICON_1)
    mMadeFromItems.Add(eItemname.itmSTAFF_OF_WIZARDRY)
    mMadeFromItems.Add(eItemname.itmBELT_OF_STRENGTH)

    mBuildsToNames.Add(eItemname.itmNECRONOMICON_2)

    mCategory = eItemCategory.CASTER

    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/necronomicon_lg.png"
    mTier = 2
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    ' mCooldown = 
    'mRadius = 
    'mCharges =
    'mDuration =
    'mManacost = 

    Description = "Active: Demonic Summoning - Summons a Necronomicon Warrior and a Necronomicon Archer to fight for you. Their strength and abilities increase as Necronomicon increases in level. Lasts 40 seconds. Upgradable."
    Notes = "Interupts the user's channeling spells upon cast.|The summons are always summoned infront of the caster.|All 3 levels of Necronomicon share cooldown.|Recasting this with the same Necronomicon replaces the summmons from the previous cast, no matter under whom control they are.|However, recasting it with a second Necronomicon creates 2 new summons.|The summons can not be targeted by Helm of the Dominator and Hand of Midas.|However, they can be targeted by other converting or instantly killing spells like Holy Persuasion or Devour." '
    ColorText = "Considered the holy grail of necromancy and demonology, a powerful malefic force is locked within its pages."
  End Sub
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As iUnitUpgrade, _
                                                    theownerid As idisplayunit, _
                                                    thetarget As idisplayunit, _
                                                    ftarget As idisplayunit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim passiveselfinfo = Helpers.GetPassiveSelfInfo(theitem_InfoID, _
                                                     theownerid, _
                                                     thetarget, _
                                                     "", eModifierCategory.Passive)

    Dim intval As New modValue(15, eModifierType.IntAdded, occurencetime)

    Dim int As New Modifier(intval, passiveselfinfo)

    outmods.Add(int)


    Dim strval As New modValue(8, eModifierType.StrAdded, occurencetime)

    Dim str As New Modifier(strval, passiveselfinfo)

    outmods.Add(str)


    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Summons a Necronomicon Warrior and a Necronomicon Archer to fight for you. Their strength and abilities increase as Necronomicon increases in level. Lasts 40 seconds. "
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Demonic Summoning"
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As iUnitUpgrade, _
                                 thecaster As idisplayunit, _
                                 thetarget As idisplayunit, _
                                 ftarget As idisplayunit, _
                                 isfriendbias As Boolean, _
                                 occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                                         thecaster, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Active)

    Dim damval1 As New modValue(25, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim warriordamage As New Modifier(damval1, unittargetenemytargetinfo)

    outmods.Add(warriordamage)


    Dim unittargetenemytargetinfo2 = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                                         thecaster, _
                                                                         thetarget, _
                                                                         "Archer damage", eModifierCategory.Passive)

    Dim damval2 As New modValue(40, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim archerdamage As New Modifier(damval2, unittargetenemytargetinfo2)

    outmods.Add(archerdamage)

    Return outmods
  End Function
End Class