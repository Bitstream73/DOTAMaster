Public Class itmBloodstone
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmBLOODSTONE
    Me.EntityName = eEntity.itmBLOODSTONE

    mDisplayName = "Bloodstone"
    'mDescription = "The Bloodstone's bright ruby color is unmistakable on the battlefield, as the owner seems to have infinite vitality and spirit.|Passive: Bloodpact - Starts with 8 charges. Gains 1 charge each time an enemy hero dies within 1675 range. Each charge bestows 1 mana regeneration per second, reduces gold lost from death by 25, and reduces respawn time by 4 seconds. When the bearer dies, restores 500 HP + 30 HP per charge to allied units within 1675 units, then loses a third of its charges. While dead, the bearer continues to receive experience at the death location and gives 1800 unit vision there.  "
    mGoldCost = New ValueWrapper(5050)
    mMadeFromItems.Add(eItemname.itmPERSEVERANCE)
    mMadeFromItems.Add(eItemname.itmSOUL_BOOSTER)

    mCategory = eItemCategory.ARMOR
    mSoldFrom.Add(eShopTypes.Fountain)
    'MSoldFrom.Add(eShopTypes.Side)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/bloodstone_lg.png"
    mTier = 2
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(300)
    'mRadius = 
    Charges = New ValueWrapper(8)
    'mDuration =
    'mManaCost = 
    Description = "Active: Pocket Deny - Instantly causes you to die.|Passive: Bloodpact - Begins with 8 charges, and gains a charge each time an enemy hero dies within 1675 range. Each charge grants 1 mana regeneration per second, reduces the gold lost from death by 25, and reduces respawn time by 4 seconds. If the bearer dies, 500 + 30 health per charge is restored to all allies within a 1675 radius, while the Bloodstone loses a third of its charges. A bloodmark is then placed where the bearer died, granting vision over a 1800 radius and allowing the bearer to gain nearby experience while dead. "
    Notes = "Pockeet Deny deals damage in form of HP removal equal to the owner's unit to the owner upon cast.|Dying this way counts as a deny.|Pockeet Deny cannot kill the user while invulnerable. Attempting to do so wastes the cooldown.|When having multiple Bloodstones, the one in the higher inventory slot gains charges.|The top left inventory slot has the highest priority, the bottom left one the lowest.|The effects of Bloodstone charges from all Bloodstones a hero owns fully stack.|When multiple heroes in a team have Bloodstones, each hero can gain a charge from the same enemy death.|Gains a charge whenever an enemy hero dies within the radius, or whenever the owner makes a kill from any distance.|The number of charges lost on death is rounded up.|Despite the visual effects, the area heal is applied instantly in the entire radius.|While dead, the bearer has 1800 radius ground vision at the death location, regardless of whether it is day or night.|While dead, the bearer earns experience in a 1200 radius at the death location.|When the charges reduce the owner's death time to 0, it instantly respawns.|This can cause still ongoing spells to affect the owner still (e.g. Timber Chain)." '
    ColorText = "The Bloodstone's bright ruby color is unmistakable on the battlefield, as the owner seems to have infinite vitality and spirit."
  End Sub
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As IUnitUpgrade, _
                                                    owner As iDisplayUnit, _
                                                    target As iDisplayUnit, _
                                                    ftarget As iDisplayUnit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim passiveselfinfo = Helpers.GetPassiveSelfInfo(theitem_InfoID, _
                                                     owner, _
                                                     target, _
                                                     "", eModifierCategory.Passive)

    Dim healthvalue As New modValue(500, eModifierType.HPAdded, occurencetime)

    Dim health As New Modifier(healthvalue, passiveselfinfo)

    outmods.Add(health)



    Dim manavalue As New modValue(400, eModifierType.ManaAdded, occurencetime)

    Dim mana As New Modifier(manavalue, passiveselfinfo)

    outmods.Add(mana)



    Dim hpregenvalue As New modValue(9, eModifierType.HPRegenAdded, occurencetime)

    Dim hpregen As New Modifier(hpregenvalue, passiveselfinfo)

    outmods.Add(hpregen)


    Dim manaregenvalue As New modValue(2, eModifierType.ManaRegenPercent, occurencetime)

    Dim manaregen As New Modifier(manaregenvalue, passiveselfinfo)

    outmods.Add(manaregen)

    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Instantly commits suicide."
    End Get
    Set(value As String)

    End Set

  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Pocket Suicide"
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

    Dim notargetselfinfo = Helpers.GetNoTargetSelfInfo(theitem_InfoID, _
                                                     thecaster, _
                                                     thetarget, _
                                                     "", eModifierCategory.Active)

    Dim suicideval As New modValue(1, eModifierType.SelfDeny, occurencetime)

    Dim pocketsuicide As New Modifier(suicideval, notargetselfinfo)

    outmods.Add(pocketsuicide)

    Return outmods
  End Function
End Class
