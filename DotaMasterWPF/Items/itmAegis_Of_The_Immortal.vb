Public Class itmAegis_Of_The_Immortal
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)

    mName = eItemname.itmAEGIS_OF_THE_IMMORTAL
    Me.EntityName = eEntity.itmAEGIS_OF_THE_IMMORTAL


    mDisplayName = "Aegis of the Immortal"
    ColorText = "Aegis of the Immortal Recipe"
    Description = "The Immortal was said to own a shield that protected him from death itself."
    mGoldCost = New ValueWrapper(0)

    mCategory = eItemCategory.SPECIAL
    mSoldFrom.Add(eShopTypes.Roshan)
    ImageURL = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/2/20/Aegis_of_the_Immortal_icon.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    ' mCooldown = 
    'mRadius = 
    Charges = New ValueWrapper(1)

    Description = ""
    Notes = "If the wielder is Wraith King icon.png Wraith King, Reincarnation triggers first if it's off cooldown.|Revives with full health and mana. Spells and items are not refreshed.|When expiring, restores in form of health and mana regeneration, so it restores 0.2% of maximum health and mana in 0.01 second intervals.|The hero's max health and mana are checked periodically and the values adapted instantly.|Since it heals for a fixed percentage over a fixed duration, it doesn't always guarantee a full heal.|So if the hero's health or mana drop by a significant amount (health drop through HP removal) during the heal, it may not be at full health or mana once the heal expires.|Is dispelled by any damage greater than 20 (before reductions), including self afflicted damage.|Is not dispelled by health cost of spells, health manipulating spells, negative regeneration, Poison Sting and Dispersion.|Is always dispelled by attacks, even when the attack dealt no damage.|Fully stacks with other health and mana regeneration increasing effects." '

  End Sub
  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As iUnitUpgrade, _
                                                    theownerid As idisplayunit, _
                                                    thetarget As idisplayunit, _
                                                    ftarget As idisplayunit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return Nothing
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Brings you to life with full health and mana 5 seconds after you die, at the location where you died. Reincarnation must be used within 6 minutes or Aegis of the Immortal disappears, healing the hero to full health and mana over 5 seconds (dispels if attacked by towers or heroes)."
    End Get
    Set(value As String)

    End Set

  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Reincarnation"
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

    Dim reincval As New modValue(1, eModifierType.Reincarnate, occurencetime)

    Dim reincarnate As New Modifier(reincval, notargetselfinfo)

    outmods.Add(reincarnate)

    Return outmods
  End Function
End Class
