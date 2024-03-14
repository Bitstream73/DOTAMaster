Imports System.Windows.Media.Imaging
Public Class item_Database

  Private mIDItem As dvID

  Private mFriendlyNames As New Dictionary(Of eItemname, String)
  Private mItemInstances As New Dictionary(Of String, Item_Info) 'guid, item_info

  Public mItemsThatDisassemble As New Dictionary(Of eItemname, List(Of eItemname))
  Public mItemsWithIngredients As New Dictionary(Of eItemname, List(Of eItemname))
  Public mItemsthatAreIngredients As New Dictionary(Of eItemname, List(Of eItemname))
  Public mItemsThatAreAssemled As New List(Of eItemname)

  Private mItemsByEItemName As OneToOneDoubleDictionary(Of eItemname, iItem)

#Region "Item Classes"



  Private _itmAbyssal_Blade_1 As itmAbyssal_Blade_1
  Private _itmAghanims_Scepter As itmAghanims_Scepter
  Private _itmAnimalCourier As itmAnimalCourier
  Private _itmArcane_Boots As itmArcane_Boots
  Private _itmArmlet_of_Mordiggian As itmArmlet_of_Mordiggian
  Private _itmAssault_Curass As itmAssault_Curass
  Private _itmBand_of_Elvenskin As itmBand_of_Elvenskin
  Private _itmBattle_Fury As itmBattle_Fury
  Private _itmBelt_of_Strength As itmBelt_of_Strength
  Private _itmBlack_King_Bar As itmBlack_King_Bar
  Private _itmBlade_Mail As itmBlade_Mail
  Private _itmBlade_of_Alacrity As itmBlade_of_Alacrity
  Private _itmBlades_of_Attack As itmBlades_of_Attack
  Private _itmBlinkDagger As itmBlinkDagger
  Private _itmBloodstone As itmBloodstone
  Private _itmBoots_of_Speed As itmBoots_of_Speed
  Private _itmBoots_of_Travel As itmBoots_of_Travel
  Private _itmBottle As itmBottle
  Private _itmBracers As itmBracers
  Private _itmBroadsword As itmBroadsword
  Private _itmBuckler As itmBuckler
  Private _itmButterfly As itmButterfly
  Private _itmChainmail As itmChainmail
  Private _itmCirclet As itmCirclet
  Private _itmClarity As itmClarity
  Private _itmClaymore As itmClaymore
  Private _itmCloak As itmCloak
  Private _itmCrystalys As itmCrystalys
  Private _itmDaedalus As itmDaedalus
  Private _itmDagon_1 As itmDagon_1
  Private _itmDagon_2 As itmDagon_2
  Private _itmDagon_3 As itmDagon_3
  Private _itmDagon_4 As itmDagon_4
  Private _itmDagon_5 As itmDagon_5
  Private _itmDemon_Edge As itmDemon_Edge
  Private _itmDesolator As itmDesolator
  Private _itmDiffusal_Blade_1 As itmDiffusal_Blade_1
  Private _itmDiffusal_Blade_2 As itmDiffusal_Blade_2
  Private _itmDivine_Rapier As itmDivine_Rapier
  Private _itmDrum_of_Endurance As itmDrum_of_Endurance
  Private _itmDust_Of_Appearance As itmDust_Of_Appearance
  Private _itmEaglesong As itmEaglesong
  Private _itmEnergy_Booster As itmEnergy_Booster
  Private _itmEthereal_Blade As itmEthereal_Blade
  Private _itmEuls_Scepter_of_Divinity As itmEuls_Scepter_of_Divinity
  Private _itmEye_of_Skadi As itmEye_of_Skadi
  Private _itmFlyingCourier As itmFlyingCourier
  Private _itmForce_Staff As itmForce_Staff
  Private _itmGauntlets_of_Strength As itmGauntlets_of_Strength
  Private _itmGem_of_Truesight As itmGem_of_Truesight
  Private _itmGhostScepter As itmGhostScepter
  Private _itmGloves_of_Haste As itmGloves_of_Haste
  Private _itmHand_of_Midas As itmHand_of_Midas
  Private _itmHeaddress As itmHeaddress
  Private _itmHeart_of_Tarrasque As itmHeart_of_Tarrasque
  Private _itmHeavens_Halberd As itmHeavens_Halberd
  Private _itmHelm_of_Iron_Will As itmHelm_of_Iron_Will
  Private _itmHelm_of_the_Dominator As itmHelm_of_the_Dominator
  Private _itmHood_of_Defiance As itmHood_of_Defiance
  Private _itmHyperstone As itmHyperstone
  Private _itmIron_Branch As itmIron_Branch
  Private _itmJavelin As itmJavelin
  Private _itmLinkins_Sphere As itmLinkins_Sphere
  Private _itmMaelstrom As itmMaelstrom
  Private _itmMagic_Stick As itmMagic_Stick
  Private _itmMagic_Wand As itmMagic_Wand
  Private _itmManta_Style As itmManta_Style
  Private _itmMantle_of_Intelligence As itmMantle_of_Intelligence
  Private _itmMask_of_Madness As itmMask_of_Madness
  Private _itmMedallion_of_Courage As itmMedallion_of_Courage
  Private _itmMekansm As itmMekansm
  Private _itmMithril_Hammer As itmMithril_Hammer
  Private _itmMjolnir As itmMjolnir
  Private _itmMonkey_King_Bar As itmMonkey_King_Bar
  Private _itmMorbid_Mask As itmMorbid_Mask
  Private _itmMystic_Staff As itmMystic_Staff
  Private _itmNecronomicon_1 As itmNecronomicon_1
  Private _itmNecronomicon_2 As itmNecronomicon_2
  Private _itmNecronomicon_3 As itmNecronomicon_3
  Private _itmNull_Talisman As itmNull_Talisman
  Private _itmOblivion_Staff As itmOblivion_Staff
  Private _itmObserverWard As itmObserverWard
  Private _itmOgre_Club As itmOgre_Club
  Private _itmOrb_of_Venom As itmOrb_of_Venom
  Private _itmOrchid_of_Malevolence As itmOrchid_of_Malevolence
  Private _itmPerseverance As itmPerseverance
  Private _itmPhase_Boots As itmPhase_Boots
  Private _itmPipe_of_Insight As itmPipe_of_Insight
  Private _itmPlatemail As itmPlatemail
  Private _itmPoint_Booster As itmPoint_Booster
  Private _itmPoor_Mans_Shield As itmPoor_Mans_Shield
  Private _itmPower_Treads As itmPower_Treads
  Private _itmQuarterstaff As itmQuarterstaff
  Private _itmQuelling_Blade As itmQuelling_Blade
  Private _itmRadiance As itmRadiance
  Private _itmReaver As itmReaver
  Private _itmRefresher_Orb As itmRefresher_Orb
  Private _itmRing_of_Aquila As itmRing_of_Aquila
  Private _itmRing_of_Basilius As itmRing_of_Basilius
  Private _itmRing_of_Health As itmRing_of_Health
  Private _itmRing_of_Protection As itmRing_of_Protection
  Private _itmRing_of_Regen As itmRing_of_Regen
  Private _itmRobe_of_the_Magi As itmRobe_of_the_Magi
  Private _itmRod_of_Atos As itmRod_of_Atos
  Private _itmSacred_Relic As itmSacred_Relic
  Private _itmSages_Mask As itmSages_Mask
  Private _itmSalve As itmSalve
  Private _itmSange As itmSange
  Private _itmSange_and_Yasha As itmSange_and_Yasha
  Private _itmSatanic As itmSatanic
  Private _itmScythe_of_Vyse As itmScythe_of_Vyse
  Private _itmSentry_Ward As itmSentry_Ward
  Private _itmShadow_Amulet As itmShadow_Amulet
  Private _itmShadow_Blade As itmShadow_Blade
  Private _itmShivas_Guard As itmShivas_Guard
  Private _itmSkull_Basher As itmSkull_Basher
  Private _itmSlippers_of_Agility As itmSlippers_of_Agility
  Private _itmSmoke_of_Deceit As itmSmoke_of_Deceit
  Private _itmSoul_Booster As itmSoul_Booster
  Private _itmSoul_Ring As itmSoul_Ring
  Private _itmStaff_of_Wizardry As itmStaff_of_Wizardry
  Private _itmStout_Shield As itmStout_Shield
  Private _itmTalisman_of_Evasion As itmTalisman_of_Evasion
  Private _itmTango As itmTango
  Private _itmTown_Portal_Scroll As itmTown_Portal_Scroll
  Private _itmTranquil_Boots As itmTranquil_Boots
  Private _itmUltimate_Orb As itmUltimate_Orb
  Private _itmUrn_of_Shadows As itmUrn_of_Shadows
  Private _itmVanguard As itmVanguard
  Private _itmVeil_of_discord As itmVeil_of_discord
  Private _itmVitality_Booster As itmVitality_Booster
  Private _itmVladmirs_Offering As itmVladmirs_Offering
  Private _itmVoid_Stone As itmVoid_Stone
  Private _itmWraith_Band As itmWraith_Band
  Private _itmYasha As itmYasha

  Private _itmRECIPE_WRAITH_BAND As itmRecipe_Wraith_Band
  Private _itmRECIPE_NULL_TALISMAN As itmRecipe_Null_Talisman
  Private _itmRECIPE_MAGIC_WAND As itmRecipe_Magic_Wand
  Private _itmRECIPE_BRACER As itmRecipe_Bracer
  Private _itmRECIPE_SOUL_RING As itmRecipe_Soul_Ring
  Private _itmRECIPE_HAND_OF_MIDAS As itmRecipe_Hand_Of_Midas
  Private _itmRECIPE_BOOTS_OF_TRAVEL As itmRecipe_Boots_Of_Travel
  Private _itmRECIPE_HEADDRESS As itmRecipe_Headdress
  Private _itmRECIPE_BUCKLER As itmRecipe_Buckler
  Private _itmRECIPE_URN_OF_SHADOWS As itmRecipe_Urn_Of_Shadows
  Private _itmRECIPE_MEDALLION_OF_COURAGE As itmRecipe_Medallion_Of_Courage
  Private _itmRECIPE_DRUM_OF_ENDURANCE As itmRecipe_Drum_Of_Endurance
  Private _itmRECIPE_VLADMIRS_OFFERING As itmRecipe_Vladmirs_Offering
  Private _itmRECIPE_MEKANSM As itmRecipe_Mekansm
  Private _itmRECIPE_PIPE_OF_INSIGHT As itmRecipe_Pipe_Of_Insight
  Private _itmRECIPE_FORCE_STAFF As itmRecipe_Force_Staff
  Private _itmRECIPE_NECRONOMICON_1 As itmRecipe_Necronomicon_1
  Private _itmRECIPE_NECRONOMICON_2 As itmRecipe_Necronomicon_2
  Private _itmRECIPE_NECRONOMICON_3 As itmRecipe_Necronomicon_3
  Private _itmRECIPE_EULS_SCEPTER_OF_DIVINITY As itmRecipe_Euls_Scepter_Of_Divinity
  Private _itmRECIPE_DAGON_1 As itmRecipe_Dagon_1
  Private _itmRECIPE_DAGON_2 As itmRecipe_Dagon_2
  Private _itmRECIPE_DAGON_3 As itmRecipe_Dagon_3
  Private _itmRECIPE_DAGON_4 As itmRecipe_Dagon_4
  Private _itmRECIPE_DAGON_5 As itmRecipe_Dagon_5
  Private _itmRECIPE_VEIL_OF_DISCORD As itmRecipe_Veil_Of_Discord
  Private _itmRECIPE_ORCHID_MALEVOLENCE As itmRecipe_Orchid_Of_Malevolence
  Private _itmRECIPE_REFRESHER_ORB As itmRecipe_Refresher_Orb
  Private _itmRECIPE_CRYSTALYS As itmRecipe_Crystalys
  Private _itmRECIPE_ARMLET_OF_MORDIGGIAN As itmRecipe_Armlet_Of_Mordiggian
  Private _itmRECIPE_SKULL_BASHER As itmRecipe_Skull_Basher
  Private _itmRECIPE_RADIANCE As itmRecipe_Radiance
  Private _itmRECIPE_DAEDALUS As itmRecipe_Daedalus
  Private _itmRECIPE_BLACK_KING_BAR As itmRecipe_Black_King_Bar
  Private _itmRECIPE_SHIVAS_GUARD As itmRecipe_Shivas_Guard
  Private _itmRECIPE_MANTA_STYLE As itmRecipe_Manta_Style
  Private _itmRECIPE_LINKENS_SPHERE As itmRecipe_Linkens_Sphere
  Private _itmRECIPE_ASSAULT_CUIRASS As itmRecipe_Assault_Cuirass
  Private _itmRECIPE_HEART_OF_TARRASQUE As itmRecipe_Heart_Of_Tarrasque
  Private _itmRECIPE_MASK_OF_MADNESS As itmRecipe_Mask_Of_Madness
  Private _itmRECIPE_SANGE As itmRecipe_Sange
  Private _itmRECIPE_YASHA As itmRecipe_Yasha
  Private _itmRECIPE_MAELSTROM As itmRecipe_Maelstrom
  Private _itmRECIPE_DIFFUSAL_BLADE_1 As itmRecipe_Diffusal_Blade_1
  Private _itmRECIPE_DIFFUSAL_BLADE_2 As itmRecipe_Diffusal_Blade_2
  Private _itmRECIPE_DESOLATOR As itmRecipe_Desolator
  Private _itmRECIPE_MJOLLNIR As itmRecipe_Mjollnir
  Private _itmRECIPE_SATANIC As itmRecipe_Satanic

  Private _itmAEGIS_OF_THE_IMMORTAL As itmAegis_Of_The_Immortal
  Private _itmCHEESE As itmCheese

  Private _Empty_Item As Empty_Item

#End Region




  Private mPassiveMods As ModifierList
  Private mActiveMods As ModifierList

  Private mItemsList As Item_Listitem_List

  Private EnumItems As Array
  Private BitmapItems As New Dictionary(Of eItemname, BitmapImage)
  Private itemsforlists As New Item_Listitem_List

  Private mLog As iLogging
  Private dbNames As FriendlyName_Database
  Private dbColors As Colors_Database
  Private dbImages As Image_Database
  Public Sub New(log As iLogging, names As FriendlyName_Database, colorsdb As Colors_Database)
    mLog = log
    dbNames = names
    mIDItem = New dvID(New Guid("68a4ff69-a736-46d0-b38d-ee4fd565ca58"), "Item_Database/New", eEntity.ItemDatabase)
    EnumItems = System.Enum.GetValues(GetType(eItemname))
    dbColors = colorsdb
  End Sub

  Private Sub LoadItemLists()
    mItemsThatDisassemble.Clear()
    mItemsWithIngredients.Clear()
    mItemsthatAreIngredients.Clear()



    For Each item In EnumItems
      If item = eItemname.itmBOOTS_OF_TRAVEL Then
        Dim x = 2
      End If

      Dim curitem = Me.GetItemInfoNoParent(item)
      Dim Ingredientlist = curitem.MadeFromItemNames
      Dim complist As New List(Of eItemname)

      If Ingredientlist.Count > 0 Then
        mItemsThatAreAssemled.Add(curitem.ItemName)
      End If

      For i As Integer = 0 To Ingredientlist.Count - 1
        If Not Ingredientlist.Item(i).ToString.ToLower.Contains("recipe") Then
          complist.Add(Ingredientlist.Item(i))
        End If
      Next


      If curitem.CanDisassemble Then

        If Not mItemsThatDisassemble.ContainsKey(curitem.ItemName) Then
          mItemsThatDisassemble.Add(curitem.ItemName, complist)
        End If

      End If


      If curitem.MadeFromItemNames.Count > 1 Then
        If Not mItemsWithIngredients.ContainsKey(curitem.ItemName) Then
          mItemsWithIngredients.Add(curitem.ItemName, Ingredientlist)
        End If
      End If


      If curitem.IsRecipe Then
        If Not mItemsthatAreIngredients.ContainsKey(curitem.ItemName) Then
          Dim outlist As New List(Of eItemname)
          outlist.Add(curitem.BuildsToNames.Item(0))

          mItemsthatAreIngredients.Add(curitem.ItemName, outlist)
        End If
      End If


      For i As Integer = 0 To curitem.MadeFromItemNames.Count - 1

        Dim compitem = Me.GetItemInfoNoParent(curitem.MadeFromItemNames.Item(i))

        If compitem.ItemName = eItemname.itmHEADDRESS Then
          Dim e = 2
        End If
        Dim compbuildstolist As List(Of eItemname) = compitem.BuildsToNames

        If mItemsthatAreIngredients.ContainsKey(compitem.ItemName) Then
          Dim curlist = mItemsthatAreIngredients.Item(compitem.ItemName)


          For x As Integer = 0 To compbuildstolist.Count - 1
            If Not curlist.Contains(compbuildstolist.Item(x)) Then
              curlist.Add(compbuildstolist.Item(x))
            End If
          Next

        Else
          mItemsthatAreIngredients.Add(compitem.ItemName, compbuildstolist)
        End If

      Next


    Next





  End Sub

  Public Sub Load()
    mItemsByEItemName = New OneToOneDoubleDictionary(Of eItemname, iItem)(mLog)
    _itmAbyssal_Blade_1 = New itmAbyssal_Blade_1(Nothing, Nothing)
    _itmAghanims_Scepter = New itmAghanims_Scepter(Nothing, Nothing)
    _itmAnimalCourier = New itmAnimalCourier(Nothing, Nothing)
    _itmArcane_Boots = New itmArcane_Boots(Nothing, Nothing)
    _itmArmlet_of_Mordiggian = New itmArmlet_of_Mordiggian(Nothing, Nothing)
    _itmAssault_Curass = New itmAssault_Curass(Nothing, Nothing)
    _itmBand_of_Elvenskin = New itmBand_of_Elvenskin(Nothing, Nothing)
    _itmBattle_Fury = New itmBattle_Fury(Nothing, Nothing)
    _itmBelt_of_Strength = New itmBelt_of_Strength(Nothing, Nothing)
    _itmBlack_King_Bar = New itmBlack_King_Bar(Nothing, Nothing)
    _itmBlade_Mail = New itmBlade_Mail(Nothing, Nothing)
    _itmBlade_of_Alacrity = New itmBlade_of_Alacrity(Nothing, Nothing)
    _itmBlades_of_Attack = New itmBlades_of_Attack(Nothing, Nothing)
    _itmBlinkDagger = New itmBlinkDagger(Nothing, Nothing)
    _itmBloodstone = New itmBloodstone(Nothing, Nothing)
    _itmBoots_of_Speed = New itmBoots_of_Speed(Nothing, Nothing)
    _itmBoots_of_Travel = New itmBoots_of_Travel(Nothing, Nothing)
    _itmBottle = New itmBottle(Nothing, Nothing)
    _itmBracers = New itmBracers(Nothing, Nothing)
    _itmBroadsword = New itmBroadsword(Nothing, Nothing)
    _itmBuckler = New itmBuckler(Nothing, Nothing)
    _itmButterfly = New itmButterfly(Nothing, Nothing)
    _itmChainmail = New itmChainmail(Nothing, Nothing)
    _itmCirclet = New itmCirclet(Nothing, Nothing)
    _itmClarity = New itmClarity(Nothing, Nothing)
    _itmClaymore = New itmClaymore(Nothing, Nothing)
    _itmCloak = New itmCloak(Nothing, Nothing)
    _itmCrystalys = New itmCrystalys(Nothing, Nothing)
    _itmDaedalus = New itmDaedalus(Nothing, Nothing)
    _itmDagon_1 = New itmDagon_1(Nothing, Nothing)
    _itmDagon_2 = New itmDagon_2(Nothing, Nothing)
    _itmDagon_3 = New itmDagon_3(Nothing, Nothing)
    _itmDagon_4 = New itmDagon_4(Nothing, Nothing)
    _itmDagon_5 = New itmDagon_5(Nothing, Nothing)
    _itmDemon_Edge = New itmDemon_Edge(Nothing, Nothing)
    _itmDesolator = New itmDesolator(Nothing, Nothing)
    _itmDiffusal_Blade_1 = New itmDiffusal_Blade_1(Nothing, Nothing)
    _itmDiffusal_Blade_2 = New itmDiffusal_Blade_2(Nothing, Nothing)
    _itmDivine_Rapier = New itmDivine_Rapier(Nothing, Nothing)
    _itmDrum_of_Endurance = New itmDrum_of_Endurance(Nothing, Nothing)
    _itmDust_Of_Appearance = New itmDust_Of_Appearance(Nothing, Nothing)
    _itmEaglesong = New itmEaglesong(Nothing, Nothing)
    _itmEnergy_Booster = New itmEnergy_Booster(Nothing, Nothing)
    _itmEthereal_Blade = New itmEthereal_Blade(Nothing, Nothing)
    _itmEuls_Scepter_of_Divinity = New itmEuls_Scepter_of_Divinity(Nothing, Nothing)
    _itmEye_of_Skadi = New itmEye_of_Skadi(Nothing, Nothing)
    _itmFlyingCourier = New itmFlyingCourier(Nothing, Nothing)
    _itmForce_Staff = New itmForce_Staff(Nothing, Nothing)
    _itmGauntlets_of_Strength = New itmGauntlets_of_Strength(Nothing, Nothing)
    _itmGem_of_Truesight = New itmGem_of_Truesight(Nothing, Nothing)
    _itmGhostScepter = New itmGhostScepter(Nothing, Nothing)
    _itmGloves_of_Haste = New itmGloves_of_Haste(Nothing, Nothing)
    _itmHand_of_Midas = New itmHand_of_Midas(Nothing, Nothing)
    _itmHeaddress = New itmHeaddress(Nothing, Nothing)
    _itmHeart_of_Tarrasque = New itmHeart_of_Tarrasque(Nothing, Nothing)
    _itmHeavens_Halberd = New itmHeavens_Halberd(Nothing, Nothing)
    _itmHelm_of_Iron_Will = New itmHelm_of_Iron_Will(Nothing, Nothing)
    _itmHelm_of_the_Dominator = New itmHelm_of_the_Dominator(Nothing, Nothing)
    _itmHood_of_Defiance = New itmHood_of_Defiance(Nothing, Nothing)
    _itmHyperstone = New itmHyperstone(Nothing, Nothing)
    _itmIron_Branch = New itmIron_Branch(Nothing, Nothing)
    _itmJavelin = New itmJavelin(Nothing, Nothing)
    _itmLinkins_Sphere = New itmLinkins_Sphere(Nothing, Nothing)
    _itmMaelstrom = New itmMaelstrom(Nothing, Nothing)
    _itmMagic_Stick = New itmMagic_Stick(Nothing, Nothing)
    _itmMagic_Wand = New itmMagic_Wand(Nothing, Nothing)
    _itmManta_Style = New itmManta_Style(Nothing, Nothing)
    _itmMantle_of_Intelligence = New itmMantle_of_Intelligence(Nothing, Nothing)
    _itmMask_of_Madness = New itmMask_of_Madness(Nothing, Nothing)
    _itmMedallion_of_Courage = New itmMedallion_of_Courage(Nothing, Nothing)
    _itmMekansm = New itmMekansm(Nothing, Nothing)
    _itmMithril_Hammer = New itmMithril_Hammer(Nothing, Nothing)
    _itmMjolnir = New itmMjolnir(Nothing, Nothing)
    _itmMonkey_King_Bar = New itmMonkey_King_Bar(Nothing, Nothing)
    _itmMorbid_Mask = New itmMorbid_Mask(Nothing, Nothing)
    _itmMystic_Staff = New itmMystic_Staff(Nothing, Nothing)
    _itmNecronomicon_1 = New itmNecronomicon_1(Nothing, Nothing)
    _itmNecronomicon_2 = New itmNecronomicon_2(Nothing, Nothing)
    _itmNecronomicon_3 = New itmNecronomicon_3(Nothing, Nothing)
    _itmNull_Talisman = New itmNull_Talisman(Nothing, Nothing)
    _itmOblivion_Staff = New itmOblivion_Staff(Nothing, Nothing)
    _itmObserverWard = New itmObserverWard(Nothing, Nothing)
    _itmOgre_Club = New itmOgre_Club(Nothing, Nothing)
    _itmOrb_of_Venom = New itmOrb_of_Venom(Nothing, Nothing)
    _itmOrchid_of_Malevolence = New itmOrchid_of_Malevolence(Nothing, Nothing)
    _itmPerseverance = New itmPerseverance(Nothing, Nothing)
    _itmPhase_Boots = New itmPhase_Boots(Nothing, Nothing)
    _itmPipe_of_Insight = New itmPipe_of_Insight(Nothing, Nothing)
    _itmPlatemail = New itmPlatemail(Nothing, Nothing)
    _itmPoint_Booster = New itmPoint_Booster(Nothing, Nothing)
    _itmPoor_Mans_Shield = New itmPoor_Mans_Shield(Nothing, Nothing)
    _itmPower_Treads = New itmPower_Treads(Nothing, Nothing)
    _itmQuarterstaff = New itmQuarterstaff(Nothing, Nothing)
    _itmQuelling_Blade = New itmQuelling_Blade(Nothing, Nothing)
    _itmRadiance = New itmRadiance(Nothing, Nothing)
    _itmReaver = New itmReaver(Nothing, Nothing)
    _itmRefresher_Orb = New itmRefresher_Orb(Nothing, Nothing)
    _itmRing_of_Aquila = New itmRing_of_Aquila(Nothing, Nothing)
    _itmRing_of_Basilius = New itmRing_of_Basilius(Nothing, Nothing)
    _itmRing_of_Health = New itmRing_of_Health(Nothing, Nothing)
    _itmRing_of_Protection = New itmRing_of_Protection(Nothing, Nothing)
    _itmRing_of_Regen = New itmRing_of_Regen(Nothing, Nothing)
    _itmRobe_of_the_Magi = New itmRobe_of_the_Magi(Nothing, Nothing)
    _itmRod_of_Atos = New itmRod_of_Atos(Nothing, Nothing)
    _itmSacred_Relic = New itmSacred_Relic(Nothing, Nothing)
    _itmSages_Mask = New itmSages_Mask(Nothing, Nothing)
    _itmSalve = New itmSalve(Nothing, Nothing)
    _itmSange = New itmSange(Nothing, Nothing)
    _itmSange_and_Yasha = New itmSange_and_Yasha(Nothing, Nothing)
    _itmSatanic = New itmSatanic(Nothing, Nothing)
    _itmScythe_of_Vyse = New itmScythe_of_Vyse(Nothing, Nothing)
    _itmSentry_Ward = New itmSentry_Ward(Nothing, Nothing)
    _itmShadow_Amulet = New itmShadow_Amulet(Nothing, Nothing)
    _itmShadow_Blade = New itmShadow_Blade(Nothing, Nothing)
    _itmShivas_Guard = New itmShivas_Guard(Nothing, Nothing)
    _itmSkull_Basher = New itmSkull_Basher(Nothing, Nothing)
    _itmSlippers_of_Agility = New itmSlippers_of_Agility(Nothing, Nothing)
    _itmSmoke_of_Deceit = New itmSmoke_of_Deceit(Nothing, Nothing)
    _itmSoul_Booster = New itmSoul_Booster(Nothing, Nothing)
    _itmSoul_Ring = New itmSoul_Ring(Nothing, Nothing)
    _itmStaff_of_Wizardry = New itmStaff_of_Wizardry(Nothing, Nothing)
    _itmStout_Shield = New itmStout_Shield(Nothing, Nothing)
    _itmTalisman_of_Evasion = New itmTalisman_of_Evasion(Nothing, Nothing)
    _itmTango = New itmTango(Nothing, Nothing)
    _itmTown_Portal_Scroll = New itmTown_Portal_Scroll(Nothing, Nothing)
    _itmTranquil_Boots = New itmTranquil_Boots(Nothing, Nothing)
    _itmUltimate_Orb = New itmUltimate_Orb(Nothing, Nothing)
    _itmUrn_of_Shadows = New itmUrn_of_Shadows(Nothing, Nothing)
    _itmVanguard = New itmVanguard(Nothing, Nothing)
    _itmVeil_of_discord = New itmVeil_of_discord(Nothing, Nothing)
    _itmVitality_Booster = New itmVitality_Booster(Nothing, Nothing)
    _itmVladmirs_Offering = New itmVladmirs_Offering(Nothing, Nothing)
    _itmVoid_Stone = New itmVoid_Stone(Nothing, Nothing)
    _itmWraith_Band = New itmWraith_Band(Nothing, Nothing)
    _itmYasha = New itmYasha(Nothing, Nothing)

    _itmRECIPE_WRAITH_BAND = New itmRecipe_Wraith_Band(Nothing, Nothing)
    _itmRECIPE_NULL_TALISMAN = New itmRecipe_Null_Talisman(Nothing, Nothing)
    _itmRECIPE_MAGIC_WAND = New itmRecipe_Magic_Wand(Nothing, Nothing)
    _itmRECIPE_BRACER = New itmRecipe_Bracer(Nothing, Nothing)
    _itmRECIPE_SOUL_RING = New itmRecipe_Soul_Ring(Nothing, Nothing)
    _itmRECIPE_HAND_OF_MIDAS = New itmRecipe_Hand_Of_Midas(Nothing, Nothing)
    _itmRECIPE_BOOTS_OF_TRAVEL = New itmRecipe_Boots_Of_Travel(Nothing, Nothing)
    _itmRECIPE_HEADDRESS = New itmRecipe_Headdress(Nothing, Nothing)
    _itmRECIPE_BUCKLER = New itmRecipe_Buckler(Nothing, Nothing)
    _itmRECIPE_URN_OF_SHADOWS = New itmRecipe_Urn_Of_Shadows(Nothing, Nothing)
    _itmRECIPE_MEDALLION_OF_COURAGE = New itmRecipe_Medallion_Of_Courage(Nothing, Nothing)
    _itmRECIPE_DRUM_OF_ENDURANCE = New itmRecipe_Drum_Of_Endurance(Nothing, Nothing)
    _itmRECIPE_VLADMIRS_OFFERING = New itmRecipe_Vladmirs_Offering(Nothing, Nothing)
    _itmRECIPE_MEKANSM = New itmRecipe_Mekansm(Nothing, Nothing)
    _itmRECIPE_PIPE_OF_INSIGHT = New itmRecipe_Pipe_Of_Insight(Nothing, Nothing)
    _itmRECIPE_FORCE_STAFF = New itmRecipe_Force_Staff(Nothing, Nothing)
    _itmRECIPE_NECRONOMICON_1 = New itmRecipe_Necronomicon_1(Nothing, Nothing)
    _itmRECIPE_NECRONOMICON_2 = New itmRecipe_Necronomicon_2(Nothing, Nothing)
    _itmRECIPE_NECRONOMICON_3 = New itmRecipe_Necronomicon_3(Nothing, Nothing)
    _itmRECIPE_EULS_SCEPTER_OF_DIVINITY = New itmRecipe_Euls_Scepter_Of_Divinity(Nothing, Nothing)
    _itmRECIPE_DAGON_1 = New itmRecipe_Dagon_1(Nothing, Nothing)
    _itmRECIPE_DAGON_2 = New itmRecipe_Dagon_2(Nothing, Nothing)
    _itmRECIPE_DAGON_3 = New itmRecipe_Dagon_3(Nothing, Nothing)
    _itmRECIPE_DAGON_4 = New itmRecipe_Dagon_4(Nothing, Nothing)
    _itmRECIPE_DAGON_5 = New itmRecipe_Dagon_5(Nothing, Nothing)
    _itmRECIPE_VEIL_OF_DISCORD = New itmRecipe_Veil_Of_Discord(Nothing, Nothing)
    _itmRECIPE_ORCHID_MALEVOLENCE = New itmRecipe_Orchid_Of_Malevolence(Nothing, Nothing)
    _itmRECIPE_REFRESHER_ORB = New itmRecipe_Refresher_Orb(Nothing, Nothing)
    _itmRECIPE_CRYSTALYS = New itmRecipe_Crystalys(Nothing, Nothing)
    _itmRECIPE_ARMLET_OF_MORDIGGIAN = New itmRecipe_Armlet_Of_Mordiggian(Nothing, Nothing)
    _itmRECIPE_SKULL_BASHER = New itmRecipe_Skull_Basher(Nothing, Nothing)
    _itmRECIPE_RADIANCE = New itmRecipe_Radiance(Nothing, Nothing)
    _itmRECIPE_DAEDALUS = New itmRecipe_Daedalus(Nothing, Nothing)
    _itmRECIPE_BLACK_KING_BAR = New itmRecipe_Black_King_Bar(Nothing, Nothing)
    _itmRECIPE_SHIVAS_GUARD = New itmRecipe_Shivas_Guard(Nothing, Nothing)
    _itmRECIPE_MANTA_STYLE = New itmRecipe_Manta_Style(Nothing, Nothing)
    _itmRECIPE_LINKENS_SPHERE = New itmRecipe_Linkens_Sphere(Nothing, Nothing)
    _itmRECIPE_ASSAULT_CUIRASS = New itmRecipe_Assault_Cuirass(Nothing, Nothing)
    _itmRECIPE_HEART_OF_TARRASQUE = New itmRecipe_Heart_Of_Tarrasque(Nothing, Nothing)
    _itmRECIPE_MASK_OF_MADNESS = New itmRecipe_Mask_Of_Madness(Nothing, Nothing)
    _itmRECIPE_SANGE = New itmRecipe_Sange(Nothing, Nothing)
    _itmRECIPE_YASHA = New itmRecipe_Yasha(Nothing, Nothing)
    _itmRECIPE_MAELSTROM = New itmRecipe_Maelstrom(Nothing, Nothing)
    _itmRECIPE_DIFFUSAL_BLADE_1 = New itmRecipe_Diffusal_Blade_1(Nothing, Nothing)
    _itmRECIPE_DIFFUSAL_BLADE_2 = New itmRecipe_Diffusal_Blade_2(Nothing, Nothing)
    _itmRECIPE_DESOLATOR = New itmRecipe_Desolator(Nothing, Nothing)
    _itmRECIPE_MJOLLNIR = New itmRecipe_Mjollnir(Nothing, Nothing)
    _itmRECIPE_SATANIC = New itmRecipe_Satanic(Nothing, Nothing)

    _itmAEGIS_OF_THE_IMMORTAL = New itmAegis_Of_The_Immortal(Nothing, Nothing)
    _itmCHEESE = New itmCheese(Nothing, Nothing)

    _Empty_Item = New Empty_Item(Nothing, Nothing)

    mItemsByEItemName.AddorUpdate(eItemname.itmABYSSAL_BLADE, _itmAbyssal_Blade_1)
    mItemsByEItemName.AddorUpdate(eItemname.itmAGHANIMS_SCEPTER, _itmAghanims_Scepter)
    mItemsByEItemName.AddorUpdate(eItemname.itmANIMAL_COURIER, _itmAnimalCourier)
    mItemsByEItemName.AddorUpdate(eItemname.itmARCANE_BOOTS, _itmArcane_Boots)
    mItemsByEItemName.AddorUpdate(eItemname.itmARMLET_OF_MORDIGGIAN, _itmArmlet_of_Mordiggian)
    mItemsByEItemName.AddorUpdate(eItemname.itmASSAULT_CUIRASS, _itmAssault_Curass)
    mItemsByEItemName.AddorUpdate(eItemname.itmBAND_OF_ELVENSKIN, _itmBand_of_Elvenskin)
    mItemsByEItemName.AddorUpdate(eItemname.itmBATTLE_FURY, _itmBattle_Fury)
    mItemsByEItemName.AddorUpdate(eItemname.itmBELT_OF_STRENGTH, _itmBelt_of_Strength)
    mItemsByEItemName.AddorUpdate(eItemname.itmBLACK_KING_BAR, _itmBlack_King_Bar)
    mItemsByEItemName.AddorUpdate(eItemname.itmBLADE_MAIL, _itmBlade_Mail)
    mItemsByEItemName.AddorUpdate(eItemname.itmBLADE_OF_ALACRITY, _itmBlade_of_Alacrity)
    mItemsByEItemName.AddorUpdate(eItemname.itmBLADES_OF_ATTACK, _itmBlades_of_Attack)
    mItemsByEItemName.AddorUpdate(eItemname.itmBLINK_DAGGER, _itmBlinkDagger)
    mItemsByEItemName.AddorUpdate(eItemname.itmBLOODSTONE, _itmBloodstone)
    mItemsByEItemName.AddorUpdate(eItemname.itmBOOTS_OF_SPEED, _itmBoots_of_Speed)
    mItemsByEItemName.AddorUpdate(eItemname.itmBOOTS_OF_TRAVEL, _itmBoots_of_Travel)
    mItemsByEItemName.AddorUpdate(eItemname.itmBOTTLE, _itmBottle)
    mItemsByEItemName.AddorUpdate(eItemname.itmBRACER, _itmBracers)
    mItemsByEItemName.AddorUpdate(eItemname.itmBROADSWORD, _itmBroadsword)
    mItemsByEItemName.AddorUpdate(eItemname.itmBUCKLER, _itmBuckler)
    mItemsByEItemName.AddorUpdate(eItemname.itmBUTTERFLY, _itmButterfly)
    mItemsByEItemName.AddorUpdate(eItemname.itmCHAINMAIL, _itmChainmail)
    mItemsByEItemName.AddorUpdate(eItemname.itmCIRCLET, _itmCirclet)
    mItemsByEItemName.AddorUpdate(eItemname.itmCLARITY, _itmClarity)
    mItemsByEItemName.AddorUpdate(eItemname.itmCLAYMORE, _itmClaymore)
    mItemsByEItemName.AddorUpdate(eItemname.itmCLOAK, _itmCloak)
    mItemsByEItemName.AddorUpdate(eItemname.itmCRYSTALYS, _itmCrystalys)
    mItemsByEItemName.AddorUpdate(eItemname.itmDAEDALUS, _itmDaedalus)
    mItemsByEItemName.AddorUpdate(eItemname.itmDAGON_1, _itmDagon_1)
    mItemsByEItemName.AddorUpdate(eItemname.itmDAGON_2, _itmDagon_2)
    mItemsByEItemName.AddorUpdate(eItemname.itmDAGON_3, _itmDagon_3)
    mItemsByEItemName.AddorUpdate(eItemname.itmDAGON_4, _itmDagon_4)
    mItemsByEItemName.AddorUpdate(eItemname.itmDAGON_5, _itmDagon_5)
    mItemsByEItemName.AddorUpdate(eItemname.itmDEMON_EDGE, _itmDemon_Edge)
    mItemsByEItemName.AddorUpdate(eItemname.itmDESOLATOR, _itmDesolator)
    mItemsByEItemName.AddorUpdate(eItemname.itmDIFFUSAL_BLADE_1, _itmDiffusal_Blade_1)
    mItemsByEItemName.AddorUpdate(eItemname.itmDIFFUSAL_BLADE_2, _itmDiffusal_Blade_2)
    mItemsByEItemName.AddorUpdate(eItemname.itmDIVINE_RAPIER, _itmDivine_Rapier)
    mItemsByEItemName.AddorUpdate(eItemname.itmDRUM_OF_ENDURANCE, _itmDrum_of_Endurance)
    mItemsByEItemName.AddorUpdate(eItemname.itmDUST_OF_APPEARANCE, _itmDust_Of_Appearance)
    mItemsByEItemName.AddorUpdate(eItemname.itmEAGLESONG, _itmEaglesong)
    mItemsByEItemName.AddorUpdate(eItemname.itmENERGY_BOOSTER, _itmEnergy_Booster)
    mItemsByEItemName.AddorUpdate(eItemname.itmETHEREAL_BLADE, _itmEthereal_Blade)
    mItemsByEItemName.AddorUpdate(eItemname.itmEULS_SCEPTER_OF_DIVINITY, _itmEuls_Scepter_of_Divinity)
    mItemsByEItemName.AddorUpdate(eItemname.itmEYE_OF_SKADI, _itmEye_of_Skadi)
    mItemsByEItemName.AddorUpdate(eItemname.itmFLYING_COURIER, _itmFlyingCourier)
    mItemsByEItemName.AddorUpdate(eItemname.itmFORCE_STAFF, _itmForce_Staff)
    mItemsByEItemName.AddorUpdate(eItemname.itmGAUNTLETS_OF_STRENGTH, _itmGauntlets_of_Strength)
    mItemsByEItemName.AddorUpdate(eItemname.itmGEM_OF_TRUE_SIGHT, _itmGem_of_Truesight)
    mItemsByEItemName.AddorUpdate(eItemname.itmGHOST_SCEPTER, _itmGhostScepter)
    mItemsByEItemName.AddorUpdate(eItemname.itmGLOVES_OF_HASTE, _itmGloves_of_Haste)
    mItemsByEItemName.AddorUpdate(eItemname.itmHAND_OF_MIDAS, _itmHand_of_Midas)
    mItemsByEItemName.AddorUpdate(eItemname.itmHEADDRESS, _itmHeaddress)
    mItemsByEItemName.AddorUpdate(eItemname.itmHEART_OF_TARRASQUE, _itmHeart_of_Tarrasque)
    mItemsByEItemName.AddorUpdate(eItemname.itmHEAVENS_HALBERD, _itmHeavens_Halberd)
    mItemsByEItemName.AddorUpdate(eItemname.itmHELM_OF_IRON_WILL, _itmHelm_of_Iron_Will)
    mItemsByEItemName.AddorUpdate(eItemname.itmHELM_OF_THE_DOMINATOR, _itmHelm_of_the_Dominator)
    mItemsByEItemName.AddorUpdate(eItemname.itmHOOD_OF_DEFIANCE, _itmHood_of_Defiance)
    mItemsByEItemName.AddorUpdate(eItemname.itmHYPERSTONE, _itmHyperstone)
    mItemsByEItemName.AddorUpdate(eItemname.itmIRON_BRANCH, _itmIron_Branch)
    mItemsByEItemName.AddorUpdate(eItemname.itmJAVELIN, _itmJavelin)
    mItemsByEItemName.AddorUpdate(eItemname.itmLINKENS_SPHERE, _itmLinkins_Sphere)
    mItemsByEItemName.AddorUpdate(eItemname.itmMAELSTROM, _itmMaelstrom)
    mItemsByEItemName.AddorUpdate(eItemname.itmMAGIC_STICK, _itmMagic_Stick)
    mItemsByEItemName.AddorUpdate(eItemname.itmMAGIC_WAND, _itmMagic_Wand)
    mItemsByEItemName.AddorUpdate(eItemname.itmMANTA_STYLE, _itmManta_Style)
    mItemsByEItemName.AddorUpdate(eItemname.itmMANTLE_OF_INTELLIGENCE, _itmMantle_of_Intelligence)
    mItemsByEItemName.AddorUpdate(eItemname.itmMASK_OF_MADNESS, _itmMask_of_Madness)
    mItemsByEItemName.AddorUpdate(eItemname.itmMEDALLION_OF_COURAGE, _itmMedallion_of_Courage)
    mItemsByEItemName.AddorUpdate(eItemname.itmMEKANSM, _itmMekansm)
    mItemsByEItemName.AddorUpdate(eItemname.itmMITHRIL_HAMMER, _itmMithril_Hammer)
    mItemsByEItemName.AddorUpdate(eItemname.itmMJOLLNIR, _itmMjolnir)
    mItemsByEItemName.AddorUpdate(eItemname.itmMONKEY_KING_BAR, _itmMonkey_King_Bar)
    mItemsByEItemName.AddorUpdate(eItemname.itmMORBID_MASK, _itmMorbid_Mask)
    mItemsByEItemName.AddorUpdate(eItemname.itmMYSTIC_STAFF, _itmMystic_Staff)
    mItemsByEItemName.AddorUpdate(eItemname.itmNECRONOMICON_1, _itmNecronomicon_1)
    mItemsByEItemName.AddorUpdate(eItemname.itmNECRONOMICON_2, _itmNecronomicon_2)
    mItemsByEItemName.AddorUpdate(eItemname.itmNECRONOMICON_3, _itmNecronomicon_3)
    mItemsByEItemName.AddorUpdate(eItemname.itmNULL_TALISMAN, _itmNull_Talisman)
    mItemsByEItemName.AddorUpdate(eItemname.itmOBLIVION_STAFF, _itmOblivion_Staff)
    mItemsByEItemName.AddorUpdate(eItemname.itmOBSERVER_WARD, _itmObserverWard)
    mItemsByEItemName.AddorUpdate(eItemname.itmOGRE_CLUB, _itmOgre_Club)
    mItemsByEItemName.AddorUpdate(eItemname.itmORB_OF_VENOM, _itmOrb_of_Venom)
    mItemsByEItemName.AddorUpdate(eItemname.itmORCHID_MALEVOLENCE, _itmOrchid_of_Malevolence)
    mItemsByEItemName.AddorUpdate(eItemname.itmPERSEVERANCE, _itmPerseverance)
    mItemsByEItemName.AddorUpdate(eItemname.itmPHASE_BOOTS, _itmPhase_Boots)
    mItemsByEItemName.AddorUpdate(eItemname.itmPIPE_OF_INSIGHT, _itmPipe_of_Insight)
    mItemsByEItemName.AddorUpdate(eItemname.itmPLATEMAIL, _itmPlatemail)
    mItemsByEItemName.AddorUpdate(eItemname.itmPOINT_BOOSTER, _itmPoint_Booster)
    mItemsByEItemName.AddorUpdate(eItemname.itmPOOR_MANS_SHIELD, _itmPoor_Mans_Shield)
    mItemsByEItemName.AddorUpdate(eItemname.itmPOWER_TREADS, _itmPower_Treads)
    mItemsByEItemName.AddorUpdate(eItemname.itmQUARTERSTAFF, _itmQuarterstaff)
    mItemsByEItemName.AddorUpdate(eItemname.itmQUELLING_BLADE, _itmQuelling_Blade)
    mItemsByEItemName.AddorUpdate(eItemname.itmRADIANCE, _itmRadiance)
    mItemsByEItemName.AddorUpdate(eItemname.itmREAVER, _itmReaver)
    mItemsByEItemName.AddorUpdate(eItemname.itmREFRESHER_ORB, _itmRefresher_Orb)
    mItemsByEItemName.AddorUpdate(eItemname.itmRING_OF_AQUILA, _itmRing_of_Aquila)
    mItemsByEItemName.AddorUpdate(eItemname.itmRING_OF_BASILIUS, _itmRing_of_Basilius)
    mItemsByEItemName.AddorUpdate(eItemname.itmRING_OF_HEALTH, _itmRing_of_Health)
    mItemsByEItemName.AddorUpdate(eItemname.itmRING_OF_PROTECTION, _itmRing_of_Protection)
    mItemsByEItemName.AddorUpdate(eItemname.itmRING_OF_REGEN, _itmRing_of_Regen)
    mItemsByEItemName.AddorUpdate(eItemname.itmROBE_OF_THE_MAGI, _itmRobe_of_the_Magi)
    mItemsByEItemName.AddorUpdate(eItemname.itmROD_OF_ATOS, _itmRod_of_Atos)
    mItemsByEItemName.AddorUpdate(eItemname.itmSACRED_RELIC, _itmSacred_Relic)
    mItemsByEItemName.AddorUpdate(eItemname.itmSAGES_MASK, _itmSages_Mask)
    mItemsByEItemName.AddorUpdate(eItemname.itmHEALING_SALVE, _itmSalve)
    mItemsByEItemName.AddorUpdate(eItemname.itmSANGE, _itmSange)
    mItemsByEItemName.AddorUpdate(eItemname.itmSANGE_AND_YASHA, _itmSange_and_Yasha)
    mItemsByEItemName.AddorUpdate(eItemname.itmSATANIC, _itmSatanic)
    mItemsByEItemName.AddorUpdate(eItemname.itmSCYTHE_OF_VYSE, _itmScythe_of_Vyse)
    mItemsByEItemName.AddorUpdate(eItemname.itmSENTRY_WARD, _itmSentry_Ward)
    mItemsByEItemName.AddorUpdate(eItemname.itmSHADOW_AMULET, _itmShadow_Amulet)
    mItemsByEItemName.AddorUpdate(eItemname.itmSHADOW_BLADE, _itmShadow_Blade)
    mItemsByEItemName.AddorUpdate(eItemname.itmSHIVAS_GUARD, _itmShivas_Guard)
    mItemsByEItemName.AddorUpdate(eItemname.itmSKULL_BASHER, _itmSkull_Basher)
    mItemsByEItemName.AddorUpdate(eItemname.itmSLIPPERS_OF_AGILITY, _itmSlippers_of_Agility)
    mItemsByEItemName.AddorUpdate(eItemname.itmSMOKE_OF_DECEIT, _itmSmoke_of_Deceit)
    mItemsByEItemName.AddorUpdate(eItemname.itmSOUL_BOOSTER, _itmSoul_Booster)
    mItemsByEItemName.AddorUpdate(eItemname.itmSOUL_RING, _itmSoul_Ring)
    mItemsByEItemName.AddorUpdate(eItemname.itmSTAFF_OF_WIZARDRY, _itmStaff_of_Wizardry)
    mItemsByEItemName.AddorUpdate(eItemname.itmSTOUT_SHIELD, _itmStout_Shield)
    mItemsByEItemName.AddorUpdate(eItemname.itmTALISMAN_OF_EVASION, _itmTalisman_of_Evasion)
    mItemsByEItemName.AddorUpdate(eItemname.itmTANGO, _itmTango)
    mItemsByEItemName.AddorUpdate(eItemname.itmTOWN_PORTAL_SCROLL, _itmTown_Portal_Scroll)
    mItemsByEItemName.AddorUpdate(eItemname.itmTRANQUIL_BOOTS, _itmTranquil_Boots)
    mItemsByEItemName.AddorUpdate(eItemname.itmULTIMATE_ORB, _itmUltimate_Orb)
    mItemsByEItemName.AddorUpdate(eItemname.itmURN_OF_SHADOWS, _itmUrn_of_Shadows)
    mItemsByEItemName.AddorUpdate(eItemname.itmVANGUARD, _itmVanguard)
    mItemsByEItemName.AddorUpdate(eItemname.itmVEIL_OF_DISCORD, _itmVeil_of_discord)
    mItemsByEItemName.AddorUpdate(eItemname.itmVITALITY_BOOSTER, _itmVitality_Booster)
    mItemsByEItemName.AddorUpdate(eItemname.itmVLADMIRS_OFFERING, _itmVladmirs_Offering)
    mItemsByEItemName.AddorUpdate(eItemname.itmVOID_STONE, _itmVoid_Stone)
    mItemsByEItemName.AddorUpdate(eItemname.itmWRAITH_BAND, _itmWraith_Band)
    mItemsByEItemName.AddorUpdate(eItemname.itmYASHA, _itmYasha)

    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_WRAITH_BAND, _itmRECIPE_WRAITH_BAND)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_NULL_TALISMAN, _itmRECIPE_NULL_TALISMAN)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_MAGIC_WAND, _itmRECIPE_MAGIC_WAND)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_BRACER, _itmRECIPE_BRACER)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_SOUL_RING, _itmRECIPE_SOUL_RING)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_HAND_OF_MIDAS, _itmRECIPE_HAND_OF_MIDAS)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_BOOTS_OF_TRAVEL, _itmRECIPE_BOOTS_OF_TRAVEL)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_HEADDRESS, _itmRECIPE_HEADDRESS)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_BUCKLER, _itmRECIPE_BUCKLER)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_URN_OF_SHADOWS, _itmRECIPE_URN_OF_SHADOWS)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_MEDALLION_OF_COURAGE, _itmRECIPE_MEDALLION_OF_COURAGE)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_DRUM_OF_ENDURANCE, _itmRECIPE_DRUM_OF_ENDURANCE)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_VLADMIRS_OFFERING, _itmRECIPE_VLADMIRS_OFFERING)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_MEKANSM, _itmRECIPE_MEKANSM)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_PIPE_OF_INSIGHT, _itmRECIPE_PIPE_OF_INSIGHT)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_FORCE_STAFF, _itmRECIPE_FORCE_STAFF)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_NECRONOMICON_1, _itmRECIPE_NECRONOMICON_1)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_NECRONOMICON_2, _itmRECIPE_NECRONOMICON_2)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_NECRONOMICON_3, _itmRECIPE_NECRONOMICON_3)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_EULS_SCEPTER_OF_DIVINITY, _itmRECIPE_EULS_SCEPTER_OF_DIVINITY)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_DAGON_1, _itmRECIPE_DAGON_1)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_DAGON_2, _itmRECIPE_DAGON_2)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_DAGON_3, _itmRECIPE_DAGON_3)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_DAGON_4, _itmRECIPE_DAGON_4)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_DAGON_5, _itmRECIPE_DAGON_5)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_VEIL_OF_DISCORD, _itmRECIPE_VEIL_OF_DISCORD)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_ORCHID_MALEVOLENCE, _itmRECIPE_ORCHID_MALEVOLENCE)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_REFRESHER_ORB, _itmRECIPE_REFRESHER_ORB)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_CRYSTALYS, _itmRECIPE_CRYSTALYS)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_ARMLET_OF_MORDIGGIAN, _itmRECIPE_ARMLET_OF_MORDIGGIAN)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_SKULL_BASHER, _itmRECIPE_SKULL_BASHER)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_RADIANCE, _itmRECIPE_RADIANCE)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_DAEDALUS, _itmRECIPE_DAEDALUS)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_BLACK_KING_BAR, _itmRECIPE_BLACK_KING_BAR)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_SHIVAS_GUARD, _itmRECIPE_SHIVAS_GUARD)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_MANTA_STYLE, _itmRECIPE_MANTA_STYLE)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_LINKENS_SPHERE, _itmRECIPE_LINKENS_SPHERE)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_ASSAULT_CUIRASS, _itmRECIPE_ASSAULT_CUIRASS)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_HEART_OF_TARRASQUE, _itmRECIPE_HEART_OF_TARRASQUE)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_MASK_OF_MADNESS, _itmRECIPE_MASK_OF_MADNESS)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_SANGE, _itmRECIPE_SANGE)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_YASHA, _itmRECIPE_YASHA)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_MAELSTROM, _itmRECIPE_MAELSTROM)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_DIFFUSAL_BLADE_1, _itmRECIPE_DIFFUSAL_BLADE_1)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_DIFFUSAL_BLADE_2, _itmRECIPE_DIFFUSAL_BLADE_2)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_DESOLATOR, _itmRECIPE_DESOLATOR)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_MJOLLNIR, _itmRECIPE_MJOLLNIR)
    mItemsByEItemName.AddorUpdate(eItemname.itmRECIPE_SATANIC, _itmRECIPE_SATANIC)

    mItemsByEItemName.AddorUpdate(eItemname.itmAEGIS_OF_THE_IMMORTAL, _itmAEGIS_OF_THE_IMMORTAL)
    mItemsByEItemName.AddorUpdate(eItemname.itmCHEESE, _itmCHEESE)

    mItemsByEItemName.AddorUpdate(eItemname.None, _Empty_Item)


    LoadItemLists()


  End Sub

  Public Function GetAllItemInfosNoParent() As List(Of Item_Info)
    Dim EnumItems = System.Enum.GetValues(GetType(eItemname))
    Dim outlist As New List(Of Item_Info)
    For Each item In EnumItems
      outlist.Add(GetItemInfoNoParent(item))
    Next
    Return outlist
  End Function
  Public Function GetItemInfosNoParent(itemnames As List(Of eItemname)) As List(Of Item_Info)

    Dim outlist As New List(Of Item_Info)

    For i As Integer = 0 To itemnames.Count - 1
      outlist.Add(GetItemInfoNoParent(itemnames.Item(i)))
    Next

    Return outlist

  End Function

  Public Function GetItemInfosNoParentAsItemList(itemnames As List(Of eItemname)) As Item_List

    Dim outlist As New Item_List()
    For i As Integer = 0 To itemnames.Count - 1
      outlist.AddItem(GetItemInfoNoParent(itemnames.Item(i)))
    Next

    Return outlist

  End Function



  Public Function GetItemInfoNoParent(itemname As eItemname) As Item_Info
    Dim id As New dvID(Guid.NewGuid, "Item_Info No Parent", eEntity.Item_Info)
    Return GetItem(id, itemname, Nothing, Constants.cDefaultLifetime)

  End Function
  Private Function GetItem(id As dvID,
                           itemname As eItemname, _
                               theparent As iDisplayUnit, _
                               theLifetime As Lifetime) As Item_Info

    Dim outitem As Item_Info
    Dim curitem = mItemsByEItemName.ValueForKey(itemname)
    If Not curitem Is Nothing Then
      outitem = New Item_Info(id, _
                              curitem.ItemName, _
                           theparent, _
                             curitem.DisplayName, _
                             curitem.mDescription, _
                             curitem.mNotes, _
                             curitem.mColorText, _
                             curitem.GoldCost, _
                             curitem.MadeFromItemNames, _
                             curitem.BuildsToNames, _
                             curitem.ItemCategory, _
                             curitem.SoldFrom, _
                             curitem.mImageURL, _
                             curitem.Tier, _
                             curitem.IsRecipe, _
                             curitem.CanDisassemble, _
                             curitem.mCooldown, _
                             curitem.mRadius, _
                             curitem.mCharges, _
                             curitem.mDuration, _
                             curitem.mManaCost, _
                             curitem.IsConsumable, _
                             curitem.IsCourier, _
                             theLifetime)


      'weed out items from menus and details, etc
      If outitem.ParentGameEntity IsNot Nothing Then

        Dim gID = outitem.Id.GuidID.ToString
        If Not mItemInstances.ContainsKey(gID) Then
          mItemInstances.Add(gID, outitem)
        Else
          mLog.WriteLog("Get Item returns nothing for " & itemname.ToString)
        End If

      End If
      Return outitem
    End If

    Return Nothing



  End Function

  Public Function GetItemInstance(theid As dvID) As Item_Info
    If mItemInstances.ContainsKey(theid.GuidID.ToString) Then
      Return mItemInstances.Item(theid.GuidID.ToString)
    Else
      Dim x = 2
    End If
    Return Nothing
  End Function

  Public Function CreateItemInstance(itemname As eItemname, parent As iDisplayUnit, thelife As Lifetime) As Item_Info
    If itemname = eItemname.itmMJOLLNIR Then
      Dim x = 2
    End If
    Dim id As New dvID(Guid.NewGuid, itemname.ToString & " instance in createiteminstance with no ID passed in", eEntity.Item_Info)
    Return GetItem(id, itemname, parent, thelife)
  End Function

  Public Function CreateIteminstance(id As dvID, itemname As eItemname, theparent As iGameEntity, thelife As Lifetime) As Item_Info
    Return GetItem(id, itemname, theparent, thelife)
  End Function

  Public Function CreateItemInstances(theitemnames As List(Of eItemname), theparentid As dvID, thelife As Lifetime) As Item_List
    Dim outlist As New Item_List
    For i As Integer = 0 To theitemnames.Count - 1
      outlist.Add(CreateItemInstance(theitemnames.Item(i), theparentid, thelife))

    Next
    Return outlist
  End Function
  Public Function GetItemModifiers(thestateindex As Integer, thegame As dGame, _
                                    itemname As eItemname, item As iItem, _
                                    thecaster As iDisplayUnit, _
                                   thetarget As iDisplayUnit, _
                                    ftarget As iDisplayUnit, _
                                    isfriendbias As Boolean, _
                                    occurencetime As Lifetime, aghstime As Lifetime) As List(Of ModifierList)


    Dim outmods As New List(Of ModifierList) '0 is actives, 1 is passives
    Dim curitem = mItemsByEItemName.ValueForKey(itemname)

    If curitem IsNot Nothing Then
      outmods.Add(curitem.GetActiveModifiers(thestateindex, thegame, _
                                                                     item, _
                                                                     thecaster, _
                                                                     thetarget, _
                                                                     ftarget, _
                                                                     isfriendbias, _
                                                                     occurencetime, aghstime))

      outmods.Add(curitem.GetPassiveModifiers(thestateindex, thegame, _
                                                                   item, _
                                                                   thecaster, _
                                                                   thetarget, _
                                                                   ftarget, _
                                                                   isfriendbias, _
                                                                   occurencetime, aghstime))

    End If


    Return outmods
  End Function

  Public Function GetItemStateAndUrls(theitemname As eItemname) As List(Of List(Of String))
    Dim curitem = mItemsByEItemName.ValueForKey(theitemname)

    If curitem IsNot Nothing Then Return curitem.StatesAndStateUrls
    Return Nothing

  End Function

  Public Function GetFriendlyName(itemname As eItemname) As String
    Return mFriendlyNames.Item(itemname)
  End Function

  Public Function GetSystemName(friendlyname As String) As eItemname

    For Each name As KeyValuePair(Of eItemname, String) In mFriendlyNames
      If name.Value = friendlyname Then Return name.Key
    Next
    Return Nothing
  End Function
  Public Function GetAbilityInfo(friendlyname As String) As Item_Info
    Return Me.GetAbilityInfo(GetSystemName(friendlyname))
  End Function


End Class
