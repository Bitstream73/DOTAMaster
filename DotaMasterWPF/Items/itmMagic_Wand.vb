Public Class itmMagic_Wand
  Inherits ItemBase

  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmMAGIC_WAND
    Me.EntityName = eEntity.itmMAGIC_WAND

    mDisplayName = "Magic Wand"
    'mDescription = "A simple wand used to channel magic energies, it is favored by apprentice wizards and great warlocks alike. "
    mGoldCost = New ValueWrapper(500)
    mMadeFromItems.Add(eItemname.itmRECIPE_MAGIC_WAND)
    mMadeFromItems.Add(eItemname.itmIRON_BRANCH)
    mMadeFromItems.Add(eItemname.itmIRON_BRANCH)
    mMadeFromItems.Add(eItemname.itmIRON_BRANCH)
    mMadeFromItems.Add(eItemname.itmMAGIC_STICK)
    mCategory = eItemCategory.COMMON
    mSoldFrom.Add(eShopTypes.Fountain)
    mSoldFrom.Add(eShopTypes.Side)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/magic_wand_lg.png"
    mTier = 1
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    ' mCooldown = 
    'mRadius = 
    Charges = New ValueWrapper(15)

    Description = "Active: Energy Charge - Gains charges (max 17) based on enemies using abilities in a nearby area. When activated, it restores health and mana based on the number of charges stored."
    Notes = "Interupts the user's channeling spells upon cast.|Shares cooldown with Magic Stick icon.png Magic Stick.|Gains 1 charge whenever a visible enemy unit, including neutral creeps, uses an ability within the radius.|The following spells don't add charges when cast:|Stone Remnant icon.png Stone Remnant Nightmare End icon.png Nightmare End, Return Astral Spirit icon.png Return Astral Spirit, Ice Armor icon.png Ice Armor, Heal icon.png Heal, Quas icon.png Quas, Wex icon.png Wex, Exort icon.png Exort, Release Illuminate icon.png Release Illuminate, Pulse Nova icon.png Pulse Nova, Split Shot icon.png Split Shot, Mana Shield icon.png Mana Shield, Morph (Agility Gain) icon.png Morph, Stop Icarus Dive icon.png Stop Icarus Dive, Launch Fire Spirit icon.png Launch Fire Spirit, Stop Sun Ray icon.png Stop Sun Ray, Toggle Movement icon.png Toggle Movement, Break Tether icon.png Break Tether, Spirits In icon.png Spirits In, Spirits Out icon.png Spirits Out, Overcharge icon.png Overcharge, Suicide Squad, Attack! icon.png Suicide Squad, Attack!, Focused Detonate icon.png Focused Detonate, Minefield Sign icon.png Minefield Sign, Phase Shift icon.png Phase Shift, Ethereal Jaunt, Rot, Telekinesis Land, Shadow Poison Release, Reality, Trap, Return Chakram, Voodoo Restoration and Berserker's Rage and all abilities of couriers.|Passively triggered spells (e.g. Quill Spray, Borrowed Time, Multicast, Reincarnation) do not add charges.|Active attack modifier and active items do not add charges.|All not listed spells will grant charges, including all not listed sub-spells.|When an enemy casts a spell out of the invisibility of Rune of Invisibility, Shadow Walk, Sandstorm, Moonlight Shadow, Nature's Guise or Spin Web, it does not give a charge.|When having multiple Magic Wands or Magic Sticks in the inventory, the oldest one will gain charges first. If it is full, the second oldest one starts to gain charges.|Upon upgrading an Magic Stick into a Magic Wand, all its current charges are carried over.|Can restore up to 255 health and mana when having the maximum amount of charges." '
    ColorText = "A simple wand used to channel magic energies, it is favored by apprentice wizards and great warlocks alike."

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


    Dim strval As New modValue(3, eModifierType.StrAdded, occurencetime)

    Dim strmod As New Modifier(strval, passiveselfinfo)

    outmods.Add(strmod)


    Dim intval As New modValue(3, eModifierType.IntAdded, occurencetime)

    Dim intmod As New Modifier(intval, passiveselfinfo)

    outmods.Add(intmod)


    Dim agival As New modValue(3, eModifierType.AgiAdded, occurencetime)

    Dim agimod As New Modifier(agival, passiveselfinfo)

    outmods.Add(agimod)

    Return outmods
  End Function

  Public Overrides Property AbilityDescription As String
    Get
      Return "Gains charges (max 15) based on enemies using abilities in a nearby area. When activated, it restores health and mana based on the number of charges stored. "
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Energy Charge"
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

    Dim notargetselfinfo = Helpers.GetPassiveSelfInfo(theitem_InfoID, _
                                                     thecaster, _
                                                     thetarget, _
                                                     "", eModifierCategory.Active)


    Dim manaval As New modValue(15, eModifierType.ManaAdded, occurencetime)
    manaval.Charges = New ValueWrapper(15)
    Dim manamod As New Modifier(manaval, notargetselfinfo)

    outmods.Add(manamod)


    Dim hpval As New modValue(15, eModifierType.HPAdded, occurencetime)
    hpval.Charges = New ValueWrapper(1)
    Dim hpmod As New Modifier(hpval, notargetselfinfo)

    outmods.Add(hpmod)

    Return outmods
  End Function
End Class
