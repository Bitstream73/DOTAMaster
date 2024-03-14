Public Class itmBlade_Mail
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmBLADE_MAIL
    Me.EntityName = eEntity.itmBLADE_MAIL

    mDisplayName = "Blade Mail"
    'mDescription = "A razor-sharp coat of mail, it is the choice of selfless martyrs in combat. "
    mGoldCost = New ValueWrapper(2200)
    mMadeFromItems.Add(eItemname.itmBROADSWORD)
    mMadeFromItems.Add(eItemname.itmCHAINMAIL)
    mMadeFromItems.Add(eItemname.itmROBE_OF_THE_MAGI)

    mCategory = eItemCategory.ARMOR
    mSoldFrom.Add(eShopTypes.Fountain)

    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/blade_mail_lg.png"
    mTier = 2
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(17)
    'mRadius = 
    'mCharges =
    Duration = New ValueWrapper(4.5)
    ManaCost = New ValueWrapper(25)

    Description = "Active: Damage Return - Returns any damage you take to the unit that dealt the damage. Lasts 4.5 seconds. "
    Notes = "Interupts the owner's channeling spells upon cast.|Returns incoming damage after all reductions. So when damage is fully blocked, it won't return any damage.|Does not return damage from other Blade Mails, Spiked Carapace, Heartstopper Aura, Dispersion, Poison Sting, Corrosive Skin, Fatal Bonds.|Fully ignores HP removal and self afflicted damage.|Returns damage back to the source. This means it won't return damage from any summons to the hero, but to the summons instead.|Does not work against wards, buildings and allied units." '
    ColorText = "A razor-sharp coat of mail, it is the choice of selfless martyrs in combat."
  End Sub
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As iUnitUpgrade, _
                                                   theownerid As idisplayunit, _
                                                   thetarget As idisplayunit, _
                                                   ftarget As idisplayunit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim unittargetenemytargetinfo = Helpers.GetUnitTargetEnemyTargetInfo(theitem_InfoID, _
                                                     theownerid, _
                                                     thetarget, _
                                                     "", eModifierCategory.Passive)

    Dim damval As New modValue(22, eModifierType.DamagePhysicalAdded, occurencetime)

    Dim damage As New Modifier(damval, unittargetenemytargetinfo)

    outmods.Add(damage)



    Dim passiveselfinfo = Helpers.GetPassiveSelfInfo(theitem_InfoID, _
                                                     theownerid, _
                                                     thetarget, _
                                                     "", eModifierCategory.Passive)

    Dim armorval As New modValue(6, eModifierType.ArmorAdded, occurencetime)

    Dim armor As New Modifier(armorval, passiveselfinfo)

    outmods.Add(armor)


    Dim intval As New modValue(10, eModifierType.IntAdded, occurencetime)

    Dim intmod As New Modifier(intval, passiveselfinfo)

    outmods.Add(intmod)

    Return outmods

  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Returns any damage you take to the unit that dealt the damage. Lasts 4.5 seconds."
    End Get
    Set(value As String)

    End Set

  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Damage Return"
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

    Dim passiveattackingenemyinfo = Helpers.GetPassiveAttackingEnemyInfo(theitem_InfoID, _
                                                                         thecaster, _
                                                                         thetarget, _
                                                                         "", eModifierCategory.Active)

    Dim damagereturndurationval As New modValue(270, eModifierType.DamageReturnDuration, occurencetime)
    damagereturndurationval.mValueDuration = New ValueWrapper(270) 'TimeSpan(0, 4, 30)

    Dim returndamage As New Modifier(damagereturndurationval, passiveattackingenemyinfo)

    outmods.Add(returndamage)

    Return outmods
  End Function
End Class
