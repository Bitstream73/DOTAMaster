﻿Public Class itmDagon_5
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmDAGON_5
    Me.EntityName = eEntity.itmDAGON_5

    mDisplayName = "Dagon (5)"
    'mDescription = "A lesser wand that grows in power the longer it is used, it brings magic to the fingertips of the user. "
    mGoldCost = New ValueWrapper(6470)
    mMadeFromItems.Add(eItemname.itmRECIPE_DAGON_1)
    mMadeFromItems.Add(eItemname.itmRECIPE_DAGON_2)
    mMadeFromItems.Add(eItemname.itmRECIPE_DAGON_3)
    mMadeFromItems.Add(eItemname.itmRECIPE_DAGON_4)
    mMadeFromItems.Add(eItemname.itmRECIPE_DAGON_5)
    mMadeFromItems.Add(eItemname.itmSTAFF_OF_WIZARDRY)
    mMadeFromItems.Add(eItemname.itmNULL_TALISMAN)

    mCategory = eItemCategory.CASTER

    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/4/43/Dagon_icon.png"
    mTier = 8
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(35)
    Radius = New ValueWrapper(800)
    'mCharges =
    'mDuration =
    ManaCost = New ValueWrapper(100)

    Description = "Active: Energy Burst - Burst of damage to target enemy unit. Upgradable."
    Notes = "The damage is applied instantly, so it cannot be avoided." '
    ColorText = "A lesser wand that grows in power the longer it is used, it brings magic to the fingertips of the user."

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

    Dim intval As New modValue(28, eModifierType.IntAdded, occurencetime)

    Dim intmod As New Modifier(intval, passiveselfinfo)

    outmods.Add(intmod)


    Dim strval As New modValue(3, eModifierType.StrAdded, occurencetime)

    Dim strmod As New Modifier(strval, passiveselfinfo)

    outmods.Add(strmod)

    Dim agival As New modValue(3, eModifierType.AgiAdded, occurencetime)

    Dim agimod As New Modifier(agival, passiveselfinfo)

    outmods.Add(agimod)


    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                     theownerid, _
                                                     thetarget, _
                                                     "", eModifierCategory.Passive)

    Dim damval As New modValue(9, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim damage As New Modifier(damval, unittargetenemytargetinfo)

    outmods.Add(damage)

    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Burst of damage to target enemy unit."
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Energy Burst"
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

    Dim damval As New modValue(800, eModifierType.DamageMagicalAdded, occurencetime)

    Dim damageburst As New Modifier(damval, unittargetenemytargetinfo)

    outmods.Add(damageburst)

    Return outmods
  End Function


End Class


