Public Class itmMagic_Stick
  Inherits ItemBase


  Public Sub New(theparent As idisplayunit, parentorbuildname As String)
    MyBase.New(theparent, parentorbuildname)
    mName = eItemname.itmMAGIC_STICK
    Me.EntityName = eEntity.itmMAGIC_STICK

    mDisplayName = "Magic Stick" ' PageHandler.dbItems.GetFriendlyName(mName)
    'mDescription = "A simple wand used to channel magic energies, it is favored by apprentice wizards and great warlocks alike. "
    mGoldCost = New ValueWrapper(200)

    mBuildsToNames.Add(eItemname.itmMAGIC_WAND)

    mCategory = eItemCategory.ARCANE
    mSoldFrom.Add(eShopTypes.Fountain)
    mSoldFrom.Add(eShopTypes.Side)
    ImageURL = "http://cdn.dota2.com/apps/dota2/images/items/magic_stick_lg.png"
    mTier = 0
    mIsRecipe = False
    mCanDisassemble = False
    mIsConsumable = False
    mIsCourier = False
    'ability
    Cooldown = New ValueWrapper(13)
    'mRadius = 
    Charges = New ValueWrapper(10)

    Description = "Active: Energy Charge - Gains charges (max 10) based on enemies using abilities in a nearby area. When activated, it restores health and mana based on the number of charges stored. "
    Notes = "Interupts the user's channeling spells upon cast.|Shares cooldown with Magic Wand icon.png Magic Wand.|Gains 1 charge whenever a visible enemy unit, including neutral creeps within the radius use an ability.|The following spells don't add charges when cast: Stone Remnant, Nightmare End, Return Astral Spirit, Ice Armor, Heal, Quas, Wex, Exort, Release Illuminate, Pulse Nova, Split Shot, Mana Shield, Morph, Stop Icarus Dive, Launch Fire Spirit, Stop Sun Ray, Toggle Movement, Break Tether, Spirits In, Spirits Out, Overcharge, Suicide Squad, Attack!, Focused Detonate, Minefield Sign, Phase Shift, Ethereal Jaunt, Rot, Telekinesis Land, Shadow Poison Release, Reality, Trap, Return Chakram, Voodoo Restoration and Berserker's Rage and all abilities of couriers.|Passively triggered spells (e.g. Quill Spray, Borrowed Time, Multicast, Reincarnation) do not add charges.|Active attack modifier and active items do not add charges.|All not listed spells will grant charges, including all not listed sub-spells.|When an enemy casts a spell out of the invisibility of Rune of Invisibility, Shadow Walk, Sandstorm, Moonlight Shadow, Nature's Guise or Spin Web, it does not give a charge.|When having multiple Magic Sticks or Magic Wands in the inventory, the oldest one will gain charges first. If it is full, the second oldest one starts to gain charges.|Can restore up to 150 health and mana when having the maximum amount of charges." '
    ColorText = "A simple wand used to channel magic energies, it is favored by apprentice wizards and great warlocks alike. "
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
      Return "Energy Charge - Gains charges (max 10) based on enemies using abilities in a nearby area. When activated, it restores health and mana based on the number of charges stored. "
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Property AbilityName As String
    Get
      Return "Active"
    End Get
    Set(value As String)

    End Set
  End Property

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As IUnitUpgrade, _
                                 thecaster As iDisplayUnit, _
                                 thetarget As iDisplayUnit, _
                                 ftarget As iDisplayUnit, _
                                 isfriendbias As Boolean, _
                                 occurencetime As Lifetime, aghstime As Lifetime) As ModifierList




    Dim outmods As New ModifierList

    Dim notargetselfinfo = Helpers.GetNoTargetSelfInfo(theitem_InfoID, _
                                                       thecaster, _
                                                       thetarget, _
                                                       "", eModifierCategory.Active)


    Dim manaval As New modValue(15, eModifierType.ManaAdded, occurencetime)
    manaval.Charges = New ValueWrapper(10)
    Dim manamod As New Modifier(manaval, notargetselfinfo)

    outmods.Add(manamod)


    Dim hpval As New modValue(15, eModifierType.HealAdded, occurencetime)
    hpval.Charges = manaval.Charges
    Dim hpmod As New Modifier(hpval, notargetselfinfo)

    outmods.Add(hpmod)

    Return outmods
  End Function
End Class
