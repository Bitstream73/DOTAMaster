Public Class Controls_Database

  Private mItemMenu As New ctrlItem_Menu
  Private mShopMenu As New ctrlItem_MenuPage
  Private mRecipeMenu As New ctrlItem_MenuPage
  Private mItemMenuItems As New Dictionary(Of eItemname, ctrlItem_MenuItem)


  Private mHeroMenuItems As New Dictionary(Of eHeroName, ctrlHero_Menu_Item)
  Private mHeroMenu As New ctrlHero_Menu
  Private mIDItem As dvID
  Private dbImages As Image_Database
  Private dbColors As Colors_Database
  Private mLog As Logging
  Private mGame As dGame

  Public Sub New(thelog As Logging, thegame As dGame, _
                 imagesdb As Image_Database, _
                 theheroes As List(Of HeroBuild), _
                 theitems As List(Of Item_Info), _
                 colors As Colors_Database)
    mGame = thegame
    mLog = thelog
    dbImages = imagesdb
    dbColors = colors
    mIDItem = New dvID(New Guid("68a4ff69-a736-46d0-b38d-ee4fd565ca58"), "Controls_Database/New", eEntity.ControlsDatabase)
    LoadItemMenu(theitems)
    LoadHeroMenu(theheroes)
  End Sub

  Public ReadOnly Property ItemMenu As ctrlItem_Menu
    Get
      Return mItemMenu
    End Get
  End Property
  Private Sub LoadItemMenu(theitems As List(Of Item_Info))
   
    For i As Integer = 0 To theitems.Count - 1
      Dim theitem = theitems.Item(i)
      'Dim thebmp = Me.PageHandler.dbImages.GetItemImage.Item(itemname)
      Dim buildsfrom = mGame.dbItems.GetItemInfosNoParent(theitem.MadeFromItemNames)
      Dim buildsto = mGame.dbItems.GetItemInfosNoParent(theitem.BuildsToNames)

      Dim thectrl As New ctrlItem_MenuItem(theitem, dbImages.GetItemImage(theitem.ItemName), buildsfrom, buildsto, dbImages)


      If mItemMenuItems.ContainsKey(theitem.ItemName) Then
        Dim otheritem = mItemMenuItems.Item(theitem.ItemName)
        Dim x = 2
      End If

      '  If Not mItemMenuItems.ContainsKey(theitem.mName) Then
      mItemMenuItems.Add(theitem.ItemName, thectrl)
      '   End If


    Next

    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmCLARITY), 0, 0)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmTANGO), 1, 0)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmHEALING_SALVE), 2, 0)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmSMOKE_OF_DECEIT), 3, 0)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmTOWN_PORTAL_SCROLL), 4, 0)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmDUST_OF_APPEARANCE), 5, 0)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmANIMAL_COURIER), 6, 0)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmFLYING_COURIER), 7, 0)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmOBSERVER_WARD), 8, 0)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmSENTRY_WARD), 9, 0)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmBOTTLE), 10, 0)

    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmIRON_BRANCH), 0, 1)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmGAUNTLETS_OF_STRENGTH), 1, 1)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmSLIPPERS_OF_AGILITY), 2, 1)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmMANTLE_OF_INTELLIGENCE), 3, 1)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmCIRCLET), 4, 1)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmBELT_OF_STRENGTH), 5, 1)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmBAND_OF_ELVENSKIN), 6, 1)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmROBE_OF_THE_MAGI), 7, 1)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmOGRE_CLUB), 8, 1)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmBLADE_OF_ALACRITY), 9, 1)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmSTAFF_OF_WIZARDRY), 10, 1)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmULTIMATE_ORB), 11, 1)

    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmRING_OF_PROTECTION), 0, 2)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmQUELLING_BLADE), 1, 2)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmSTOUT_SHIELD), 2, 2)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmBLADES_OF_ATTACK), 3, 2)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmCHAINMAIL), 4, 2)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmHELM_OF_IRON_WILL), 5, 2)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmBROADSWORD), 6, 2)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmQUARTERSTAFF), 7, 2)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmCLAYMORE), 8, 2)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmJAVELIN), 9, 2)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmPLATEMAIL), 10, 2)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmMITHRIL_HAMMER), 11, 2)

    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmMAGIC_STICK), 0, 3)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmSAGES_MASK), 1, 3)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmRING_OF_REGEN), 2, 3)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmBOOTS_OF_SPEED), 3, 3)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmGLOVES_OF_HASTE), 4, 3)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmCLOAK), 5, 3)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmGEM_OF_TRUE_SIGHT), 6, 3)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmMORBID_MASK), 7, 3)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmGHOST_SCEPTER), 8, 3)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmTALISMAN_OF_EVASION), 9, 3)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmBLINK_DAGGER), 10, 3)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmSHADOW_AMULET), 11, 3)

    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmWRAITH_BAND), 0, 4)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmNULL_TALISMAN), 1, 4)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmMAGIC_WAND), 2, 4)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmBRACER), 3, 4)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmPOOR_MANS_SHIELD), 4, 4)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmSOUL_RING), 5, 4)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmPHASE_BOOTS), 6, 4)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmPOWER_TREADS), 7, 4)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmOBLIVION_STAFF), 8, 4)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmPERSEVERANCE), 9, 4)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmHAND_OF_MIDAS), 10, 4)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmBOOTS_OF_TRAVEL), 11, 4)

    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmRING_OF_BASILIUS), 0, 5)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmHEADDRESS), 1, 5)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmBUCKLER), 2, 5)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmURN_OF_SHADOWS), 3, 5)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmRING_OF_AQUILA), 4, 5)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmTRANQUIL_BOOTS), 5, 5)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmMEDALLION_OF_COURAGE), 6, 5)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmARCANE_BOOTS), 7, 5)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmDRUM_OF_ENDURANCE), 8, 5)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmVLADMIRS_OFFERING), 9, 5)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmMEKANSM), 10, 5)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmPIPE_OF_INSIGHT), 11, 5)

    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmFORCE_STAFF), 0, 6)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmNECRONOMICON_1), 1, 6)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmEULS_SCEPTER_OF_DIVINITY), 2, 6)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmDAGON_1), 3, 6)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmVEIL_OF_DISCORD), 4, 6)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmROD_OF_ATOS), 5, 6)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmAGHANIMS_SCEPTER), 6, 6)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmORCHID_MALEVOLENCE), 7, 6)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmREFRESHER_ORB), 8, 6)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmSCYTHE_OF_VYSE), 9, 6)

    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmCRYSTALYS), 0, 7)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmARMLET_OF_MORDIGGIAN), 1, 7)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmSKULL_BASHER), 2, 7)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmSHADOW_BLADE), 3, 7)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmBATTLE_FURY), 4, 7)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmETHEREAL_BLADE), 5, 7)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmRADIANCE), 6, 7)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmMONKEY_KING_BAR), 7, 7)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmDAEDALUS), 8, 7)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmBUTTERFLY), 9, 7)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmDIVINE_RAPIER), 10, 7)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmABYSSAL_BLADE), 11, 7)

    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmHOOD_OF_DEFIANCE), 0, 8)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmBLADE_MAIL), 1, 8)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmVANGUARD), 2, 8)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmSOUL_BOOSTER), 3, 8)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmBLACK_KING_BAR), 4, 8)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmSHIVAS_GUARD), 5, 8)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmMANTA_STYLE), 6, 8)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmBLOODSTONE), 7, 8)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmLINKENS_SPHERE), 8, 8)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmASSAULT_CUIRASS), 9, 8)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmHEART_OF_TARRASQUE), 10, 8)

    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmHELM_OF_THE_DOMINATOR), 0, 9)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmMASK_OF_MADNESS), 1, 9)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmSANGE), 2, 9)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmYASHA), 3, 9)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmMAELSTROM), 4, 9)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmDIFFUSAL_BLADE_1), 5, 9)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmDESOLATOR), 6, 9)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmHEAVENS_HALBERD), 7, 9)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmSANGE_AND_YASHA), 8, 9)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmMJOLLNIR), 9, 9)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmEYE_OF_SKADI), 10, 9)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmSATANIC), 11, 9)

    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmDEMON_EDGE), 0, 10)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmEAGLESONG), 1, 10)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmREAVER), 2, 10)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmSACRED_RELIC), 3, 10)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmHYPERSTONE), 4, 10)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmRING_OF_HEALTH), 5, 10)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmVOID_STONE), 6, 10)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmMYSTIC_STAFF), 7, 10)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmENERGY_BOOSTER), 8, 10)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmPOINT_BOOSTER), 9, 10)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmVITALITY_BOOSTER), 10, 10)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmORB_OF_VENOM), 11, 10)

    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmAEGIS_OF_THE_IMMORTAL), 13, 0)
    mShopMenu.AddItem(mItemMenuItems.Item(eItemname.itmCHEESE), 13, 1)


    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_WRAITH_BAND), 0, 4) ' PageHandler.dbImages.GetItemImage(eItemname.itmWRAITH_BAND), )
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_NULL_TALISMAN), 1, 4) ' PageHandler.dbImages.GetItemImage(eItemname.itmNULL_TALISMAN))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_MAGIC_WAND), 2, 4) ' PageHandler.dbImages.GetItemImage(eItemname.itmMAGIC_WAND))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_BRACER), 3, 4) ' PageHandler.dbImages.GetItemImage(eItemname.itmBRACER))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_SOUL_RING), 5, 4) ' PageHandler.dbImages.GetItemImage(eItemname.itmSOUL_RING))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_HAND_OF_MIDAS), 10, 4) ' PageHandler.dbImages.GetItemImage(eItemname.itmHAND_OF_MIDAS))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_BOOTS_OF_TRAVEL), 11, 4) ' PageHandler.dbImages.GetItemImage(eItemname.itmBOOTS_OF_TRAVEL))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_HEADDRESS), 1, 5) ' PageHandler.dbImages.GetItemImage(eItemname.itmHEADDRESS))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_BUCKLER), 2, 5) ' PageHandler.dbImages.GetItemImage(eItemname.itmBUCKLER))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_URN_OF_SHADOWS), 3, 5) ' PageHandler.dbImages.GetItemImage(eItemname.itmURN_OF_SHADOWS))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_MEDALLION_OF_COURAGE), 6, 5) ' PageHandler.dbImages.GetItemImage(eItemname.itmMEDALLION_OF_COURAGE))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_DRUM_OF_ENDURANCE), 8, 5) ' PageHandler.dbImages.GetItemImage(eItemname.itmDRUM_OF_ENDURANCE))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_VLADMIRS_OFFERING), 9, 5) ' PageHandler.dbImages.GetItemImage(eItemname.itmVLADMIRS_OFFERING))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_MEKANSM), 10, 5) ' PageHandler.dbImages.GetItemImage(eItemname.itmMEKANSM))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_PIPE_OF_INSIGHT), 11, 5) ' PageHandler.dbImages.GetItemImage(eItemname.itmPIPE_OF_INSIGHT))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_FORCE_STAFF), 0, 6) ' PageHandler.dbImages.GetItemImage(eItemname.itmFORCE_STAFF))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_NECRONOMICON_1), 1, 6) ' PageHandler.dbImages.GetItemImage(eItemname.itmNECRONOMICON_1))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_EULS_SCEPTER_OF_DIVINITY), 2, 6) ' PageHandler.dbImages.GetItemImage(eItemname.itmEULS_SCEPTER_OF_DIVINITY))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_DAGON_1), 3, 6) ' PageHandler.dbImages.GetItemImage(eItemname.itmDAGON_1))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_VEIL_OF_DISCORD), 4, 6) ' PageHandler.dbImages.GetItemImage(eItemname.itmVEIL_OF_DISCORD))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_ORCHID_MALEVOLENCE), 7, 6) ' PageHandler.dbImages.GetItemImage(eItemname.itmVEIL_OF_DISCORD))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_REFRESHER_ORB), 8, 6) ' PageHandler.dbImages.GetItemImage(eItemname.itmREFRESHER_ORB))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_CRYSTALYS), 0, 7) ' PageHandler.dbImages.GetItemImage(eItemname.itmCRYSTALYS))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_ARMLET_OF_MORDIGGIAN), 1, 7) ' PageHandler.dbImages.GetItemImage(eItemname.itmARMLET_OF_MORDIGGIAN))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_SKULL_BASHER), 2, 7) ' PageHandler.dbImages.GetItemImage(eItemname.itmSKULL_BASHER))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_RADIANCE), 6, 7) ' PageHandler.dbImages.GetItemImage(eItemname.itmRADIANCE))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_DAEDALUS), 8, 7) ' PageHandler.dbImages.GetItemImage(eItemname.itmDAEDALUS))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_BLACK_KING_BAR), 4, 8) ' PageHandler.dbImages.GetItemImage(eItemname.itmBLACK_KING_BAR))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_SHIVAS_GUARD), 5, 8) ' PageHandler.dbImages.GetItemImage(eItemname.itmSHIVAS_GUARD))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_MANTA_STYLE), 6, 8) ', PageHandler.dbImages.GetItemImage(eItemname.itmMANTA_STYLE))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_LINKENS_SPHERE), 8, 8) ' PageHandler.dbImages.GetItemImage(eItemname.itmLINKENS_SPHERE))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_ASSAULT_CUIRASS), 9, 8) ' PageHandler.dbImages.GetItemImage(eItemname.itmASSAULT_CUIRASS))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_HEART_OF_TARRASQUE), 10, 8) ' PageHandler.dbImages.GetItemImage(eItemname.itmHEART_OF_TARRASQUE))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_MASK_OF_MADNESS), 0, 9) ' PageHandler.dbImages.GetItemImage(eItemname.itmMASK_OF_MADNESS))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_SANGE), 2, 9) ' PageHandler.dbImages.GetItemImage(eItemname.itmSANGE))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_YASHA), 3, 9) ' PageHandler.dbImages.GetItemImage(eItemname.itmYASHA))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_MAELSTROM), 4, 9) ' PageHandler.dbImages.GetItemImage(eItemname.itmMAELSTROM))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_DIFFUSAL_BLADE_1), 5, 9) ' PageHandler.dbImages.GetItemImage(eItemname.itmDIFFUSAL_BLADE_1))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_DESOLATOR), 6, 9) ' PageHandler.dbImages.GetItemImage(eItemname.itmDESOLATOR))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_MJOLLNIR), 9, 9) ' PageHandler.dbImages.GetItemImage(eItemname.itmMJOLLNIR))
    mRecipeMenu.AddItem(mItemMenuItems.Item(eItemname.itmRECIPE_SATANIC), 11, 9) ' PageHandler.dbImages.GetItemImage(eItemname.itmSATANIC))




    mItemMenu.AddTab(mShopMenu, "Shops")
    mItemMenu.AddTab(mRecipeMenu, "Recipes")
  End Sub

  Public ReadOnly Property HeroMenu As ctrlHero_Menu
    Get

      Return mHeroMenu
    End Get
  End Property
  Private Sub LoadHeroMenu(theheroes As List(Of HeroBuild))
    For i As Integer = 0 To theheroes.Count - 1
      Dim curhero = theheroes.Item(i)
      Dim thectrl As New ctrlHero_Menu_Item(curhero, PageHandler.dbImages.GetHeroImage(curhero.mHero.Name))
      mHeroMenuItems.Add(curhero.mHero.Name, thectrl)
    Next

    mHeroMenu.Visibility = Visibility.Collapsed

    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untEarthshaker), 1, 0)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untSven), 1, 1)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untTiny), 1, 2)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untKunkka), 1, 3)

    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untBeastmaster), 2, 0)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untDragon_Knight), 2, 1)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untClockwerk), 2, 2)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untOmniknight), 2, 3)

    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untHuskar), 3, 0)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untAlchemist), 3, 1)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untBrewmaster), 3, 2)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untTreant_Protector), 3, 3)


    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untIo), 4, 0)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untCentaur_Warrunner), 4, 1)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untTimbersaw), 4, 2)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untBristleback), 4, 3)

    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untTusk), 5, 0)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untElder_Titan), 5, 1)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untLegion_Commander), 5, 2)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untEarth_Spirit), 5, 3)

    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untPhoenix), 6, 0)

    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untAnti_Mage), 1, 5)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untDrow_Ranger), 1, 6)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untJuggernaut), 1, 7)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untMirana), 1, 8)

    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untMorphling), 2, 5)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untPhantom_Lancer), 2, 6)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untVengeful_Spirit), 2, 7)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untRiki), 2, 8)

    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untSniper), 3, 5)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untTemplar_Assassin), 3, 6)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untLuna), 3, 7)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untBounty_Hunter), 3, 8)

    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untUrsa), 4, 5)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untGyrocopter), 4, 6)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untLone_Druid), 4, 7)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untNaga_Siren), 4, 8)

    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untTroll_Warlord), 5, 5)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untEmber_Spirit), 5, 6)

    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untCrystal_Maiden), 1, 10)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untPuck), 1, 11)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untStorm_Spirit), 1, 12)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untWindranger), 1, 13)

    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untZeus), 2, 10)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untLina), 2, 11)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untShadow_Shaman), 2, 12)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untTinker), 2, 13)

    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untNatures_Prophet), 3, 10)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untEnchantress), 3, 11)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untJakiro), 3, 12)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untChen), 3, 13)

    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untSilencer), 4, 10)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untOgre_Magi), 4, 11)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untRubick), 4, 12)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untDisruptor), 4, 13)

    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untKeeper_of_the_Light), 5, 10)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untSkywrath_Mage), 5, 11)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untTechies), 5, 12)

    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untAxe), 7, 0)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untPudge), 7, 1)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untSand_King), 7, 2)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untSlardar), 7, 3)

    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untTidehunter), 8, 0)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untWraith_King), 8, 1)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untLifestealer), 8, 2)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untNight_Stalker), 8, 3)

    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untDoom), 9, 0)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untSpirit_Breaker), 9, 1)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untLycan), 9, 2)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untChaos_Knight), 9, 3)

    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untUndying), 10, 0)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untMagnus), 10, 1)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untAbaddon), 10, 2)

    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untBloodseeker), 7, 5)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untShadow_Fiend), 7, 6)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untRazor), 7, 7)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untVenomancer), 7, 8)


    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untFaceless_Void), 8, 5)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untPhantom_Assassin), 8, 6)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untViper), 8, 7)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untClinkz), 8, 8)


    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untBroodmother), 9, 5)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untWeaver), 9, 6)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untSpectre), 9, 7)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untMeepo), 9, 8)

    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untNyx_Assassin), 10, 5)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untSlark), 10, 6)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untMedusa), 10, 7)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untTerrorblade), 10, 8)

    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untBane), 7, 10)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untLich), 7, 11)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untLion), 7, 12)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untWitch_Doctor), 7, 13)

    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untEnigma), 8, 10)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untNecrophos), 8, 11)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untWarlock), 8, 12)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untQueen_of_Pain), 8, 13)

    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untDeath_Prophet), 9, 10)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untPugna), 9, 11)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untDazzle), 9, 12)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untLeshrac), 9, 13)

    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untDark_Seer), 10, 10)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untBatrider), 10, 11)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untAncient_Apparition), 10, 12)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untInvoker), 10, 13)

    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untOutworld_Devourer), 11, 10)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untShadow_Demon), 11, 11)
    mHeroMenu.AddItem(mHeroMenuItems.Item(eHeroName.untVisage), 11, 12)



  End Sub

  Public Function GetHeroBadge(Badgesteam As dTeam, badgesposition As Integer)


    Return New ctrlHero_Badge(Badgesteam, badgesposition, mGame, _
                              New SolidColorBrush(dbColors.HeadingTextColor), New SolidColorBrush(dbColors.BodyTextColor))
  End Function


  Public Function GetctrlAbility_List_itemList(theabilities As List(Of Ability_Info)) As List(Of ctrlAbility_List_Item)

    Dim outlist As New List(Of ctrlAbility_List_Item)

    For i As Integer = 0 To theabilities.Count - 1
      Dim curab = theabilities.Item(i)
      Dim newctrl As New ctrlAbility_List_Item(curab, curab.DisplayName)

      outlist.Add(newctrl)
    Next

    Return outlist
  End Function

  Public Function GetGraph(barcount As Integer, bartimes As List(Of String), _
                           bartype As eBarType, graphtype As eGraphType, _
                 graphdividercolor As Color, selectedbarcolor As Color, _
                 radcolor As Color, radaccent As Color, _
                 direcolor As Color, direaccent As Color, _
                 ctrlbartype As ctrlBar_Type, ctrlcharttype As ctrlChart_Type) As ctrlBargraph_Panes_Fixedwidth

    Return New ctrlBargraph_Panes_Fixedwidth(barcount, bartimes, _
                                             bartype, graphtype, _
                                             graphdividercolor, _
                                             selectedbarcolor, _
                                             radcolor, radaccent, _
                                             direcolor, direaccent, _
                                             ctrlbartype, ctrlcharttype)
  End Function

  Public Function GetctrlSwatchDataitemLabelDual(curtime As ddFrame, _
                                           raddataitem As iDataItem, _
                                           diredataitem As iDataItem, _
                                           prefix As String, suffix As String, _
                                           radiantbrush As SolidColorBrush, direbrush As SolidColorBrush) As ctrlSwatchDataItemLabelDual

    Return New ctrlSwatchDataItemLabelDual(curtime, _
                                     raddataitem, _
                                     diredataitem, _
                                     New SolidColorBrush(dbColors.HeadingTextColor), _
                                     New SolidColorBrush(dbColors.BodyTextColor), _
                                    New SolidColorBrush(raddataitem.MyColor), _
                                     Constants.cBodyFontSize, prefix, suffix, radiantbrush, direbrush)
  End Function

  Public Function GetctrlSwatchDataItemLabel(curtime As ddFrame, _
                                         dataitem As iDataItem, _
                                         prefix As String, suffix As String) As ctrlSwatchDataItemLabel

    Return New ctrlSwatchDataItemLabel(dataitem, _
                                     New SolidColorBrush(dbColors.HeadingTextColor), _
                                     New SolidColorBrush(dbColors.BodyTextColor), _
                                    New SolidColorBrush(dataitem.MyColor), _
                                     Constants.cBodyFontSize, prefix, suffix, False, mGame)
  End Function

  'Public Function GetctrlSwatchModifierLabel(curtime As ddFrame, _
  '                                     themod As Modifier, _
  '                                     prefix As String, suffix As String, decimalplaces As Integer) As ctrlSwatchModifierLabel

  '  Return New ctrlSwatchModifierLabel(curtime, _
  '                                   themod, _
  '                                   New SolidColorBrush(dbColors.HeadingTextColor), _
  '                                   New SolidColorBrush(dbColors.BodyTextColor), _
  '                                  New SolidColorBrush(dbColors.GetColor(themod.ModifierType)), _
  '                                   Constants.cBodyFontSize, prefix, suffix, decimalplaces, _
  '                                   mGame, False)
  'End Function

  Public Function GetctrlIconStatLabel(curtime As ddFrame, iconpath As String, _
                                           thestat As Stat, _
                                           prefix As String, suffix As String, decimalplaces As Integer) As ctrlIconStatLabel



    Return New ctrlIconStatLabel(curtime, iconpath, _
                                     thestat, _
                                     New SolidColorBrush(dbColors.HeadingTextColor), _
                                     New SolidColorBrush(dbColors.BodyTextColor), _
                                    New SolidColorBrush(dbColors.GetColor(thestat.StatType)), _
                                     Constants.cBodyFontSize, prefix, suffix, decimalplaces)
  End Function
  Public Function GetHorizontalLine(leftmarginopercent As Decimal, rightmarginpercent As Decimal, lineheight As Integer) As ctrlHorizontalLine


    Return New ctrlHorizontalLine(leftmarginopercent, rightmarginpercent, lineheight, New SolidColorBrush(dbColors.BodyTextColor))
  End Function
End Class
