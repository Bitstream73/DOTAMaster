Public Class itmCloak
  Inherits ItemBase
  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmCLOAK
    Me.EntityName = eEntity.itmCLOAK

    mDisplayName = "Cloak"
    'mDescription = "A cloak made of a magical material that works to dispel any magic cast on it. Multiple instances of spell resistance from items do not stack. Stacks multiplicatively with non-itm sources of magic resistance."
    mGoldCost = New ValueWrapper(550)

    mBuildsToNames.Add(eItemname.itmHOOD_OF_DEFIANCE)

    mCategory = eItemCategory.ARCANE
    mSoldFrom.Add(eShopTypes.Fountain)
    mSoldFrom.Add(eShopTypes.Side)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/cloak_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    ' mCooldown = 
    'mRadius = 
    'mCharges =
    Description = ""
    Notes = "" '
    ColorText = "A cloak made of a magical material that works to dispel any magic cast on it."
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

    Dim magval As New modValue(0.15, eModifierType.MagicResistancePercentAdded, occurencetime)

    Dim spellresist As New Modifier(magval, passiveselfinfo)

    outmods.Add(spellresist)

    Return outmods
  End Function
End Class
