Public Class PetBundles
  Inherits Dictionary(Of ePetName, PetBundle)
  Public Sub New()


    Dim bdlHawk As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Hawk
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlHawk.mIDItem = New dvID(Guid.NewGuid(), "CreepBundle:bdlHawk", eEntity.Creepbundle)

    bdlHawk.mName = ePetName.untHawk
    bdlHawk.mUnitType = eUnittype.RegularSummons
    bdlHawk.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/e/e7/Beastmaster_Hawk_Portrait.png/200px-Beastmaster_Hawk_Portrait.png?version=df33c092666618b981fc3718f7b14c30"


    bdlHawk.mDuration = New ValueWrapper(60, 60, 60, 60) '- 1 for permanent
    'bdlHawk.mLevel = New ValueWrapper()

    bdlHawk.mHealth = New ValueWrapper(40, 60, 80, 100)
    'bdlHawk.mHealthIncrement = New ValueWrapper()
    bdlHawk.mHealthRegen = New ValueWrapper(1.5, 1.5, 1.5, 1.5)

    'bdlHawk.mMana = New ValueWrapper()
    'bdlHawk.mManaRegen = New ValueWrapper()

    'bdlHawk.mDamage.Add(New ValueWrapper())
    'bdlHawk.mDamage.Add(New ValueWrapper())

    'bdlHawk.mDamageIncrement = New ValueWrapper()

    'bdlHawk.mMagicResistance = New ValueWrapper()

    bdlHawk.mArmor = New ValueWrapper(5, 5, 5, 5)
    bdlHawk.mArmorType = eArmorType.Light

    bdlHawk.mMoveSpeed = New ValueWrapper(250, 300, 350, 400)
    bdlHawk.mCOllisionSize = New ValueWrapper(0, 0, 0, 0)
    bdlHawk.mSightrange.Add(New ValueWrapper(700, 1000, 1300, 1600))
    bdlHawk.mSightrange.Add(New ValueWrapper(700, 800, 900, 1000))

    bdlHawk.mAttackType = eAttackType.None
    bdlHawk.mAttackSubType = eAttackSubType.None

    'bdlHawk.mAttackDuration.Add(New ValueWrapper())
    'bdlHawk.mAttackDuration.Add(New ValueWrapper())

    'bdlHawk.mMissileSpeed = New ValueWrapper()
    'bdlHawk.mBaseAttacktime = New ValueWrapper()

    bdlHawk.mBounty.Add(New ValueWrapper(30, 40, 50, 60))
    bdlHawk.mBounty.Add(New ValueWrapper(30, 40, 50, 60))
    bdlHawk.mXp = New ValueWrapper(77, 77, 77, 77)


    bdlHawk.mAbilityNames.Add(eAbilityName.abHawk_Invisibility)

    Me.Add(ePetName.untHawk, bdlHawk)
    '--------------------------------------------------------------



    Dim bdlBoar As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Boar
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlBoar.mIDItem = New dvID(Guid.NewGuid(), "CreepBundle: Beastmaster Boar", eEntity.Creepbundle)

    bdlBoar.mName = ePetName.untBoar
    bdlBoar.mUnitType = eUnittype.RegularSummons
    bdlBoar.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/1/12/Beastmaster_Boar_Portrait.png/200px-Beastmaster_Boar_Portrait.png?version=bbb51a674ca3e984945c55bcd1160dfa"


    bdlBoar.mDuration = New ValueWrapper(60) '- 1 for permanent
    'bdlBoar.mLevel = New ValueWrapper()

    bdlBoar.mHealth = New ValueWrapper(200, 300, 400, 500)
    'bdlBoar.mHealthIncrement = New ValueWrapper()
    bdlBoar.mHealthRegen = New ValueWrapper(1.5, 1.5, 1.5, 1.5)

    'bdlBoar.mMana = New ValueWrapper()
    'bdlBoar.mManaRegen = New ValueWrapper()

    bdlBoar.mDamage.Add(New ValueWrapper(15, 30, 45, 60))
    bdlBoar.mDamage.Add(New ValueWrapper(15, 30, 45, 60))

    'bdlBoar.mDamageIncrement = New ValueWrapper()

    'bdlBoar.mMagicResistance = New ValueWrapper()

    bdlBoar.mArmor = New ValueWrapper(0, 0, 0, 0)
    bdlBoar.mArmorType = eArmorType.Medium

    bdlBoar.mMoveSpeed = New ValueWrapper(350, 350, 350, 350)
    bdlBoar.mCOllisionSize = New ValueWrapper(8, 8, 8, 8)
    bdlBoar.mSightrange.Add(New ValueWrapper(1400, 1400, 1400, 1400))
    bdlBoar.mSightrange.Add(New ValueWrapper(800, 800, 800, 800))

    bdlBoar.mAttackType = eAttackType.Melee
    bdlBoar.mAttackSubType = eAttackSubType.Piercing

    bdlBoar.mAttackDuration.Add(New ValueWrapper(0.633, 0.633, 0.633, 0.633))
    bdlBoar.mAttackDuration.Add(New ValueWrapper(0.337, 0.337, 0.337, 0.337))

    bdlBoar.mMissileSpeed = New ValueWrapper(1500, 1500, 1500, 1500)
    bdlBoar.mBaseAttacktime = New ValueWrapper(1.25, 1.25, 1.25, 1.25)

    bdlBoar.mBounty.Add(New ValueWrapper(38, 38, 38, 38))
    bdlBoar.mBounty.Add(New ValueWrapper(26, 26, 26, 26))
    bdlBoar.mXp = New ValueWrapper(59, 59, 59, 59)


    bdlBoar.mAbilityNames.Add(eAbilityName.abBoar_Poison)

    Me.Add(ePetName.untBoar, bdlBoar)
    '--------------------------------------------------------------



    Dim bdlLycan_Wolf As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Lycan Wolf
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlLycan_Wolf.mIDItem = New dvID(Guid.NewGuid, "CreepBundle:Lycan Wolf", eEntity.Creepbundle)

    bdlLycan_Wolf.mName = ePetName.untLycan_Wolf
    bdlLycan_Wolf.mUnitType = eUnittype.RegularSummons
    bdlLycan_Wolf.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/f/f2/Lycan_Wolf.png/200px-Lycan_Wolf.png?version=c626e4158386987b6748b03f500fb29b"
    bdlLycan_Wolf.mWebpageLink = "http://dota2.gamepedia.com/Lycan#Lycan_Wolf"


    bdlLycan_Wolf.mDuration = New ValueWrapper(55, 55, 55, 55) '- 1 for permanent
    'bdlLycan_Wolf.mLevel = Nothing

    bdlLycan_Wolf.mHealth = New ValueWrapper(200, 240, 280, 320)
    ' bdlLycan_Wolf.mHealthIncrement = New ValueWrapper()
    bdlLycan_Wolf.mHealthRegen = New ValueWrapper(0.5, 0.5, 0.5, 15)

    ' bdlLycan_Wolf.mMana = New ValueWrapper()
    ' bdlLycan_Wolf.mManaRegen = New ValueWrapper()

    bdlLycan_Wolf.mDamage.Add(New ValueWrapper(17, 27, 34, 43))
    bdlLycan_Wolf.mDamage.Add(New ValueWrapper(18, 30, 40, 49))

    'bdlLycan_Wolf.mDamageIncrement = New ValueWrapper()

    ' bdlLycan_Wolf.mMagicResistance = New ValueWrapper()

    bdlLycan_Wolf.mArmor = New ValueWrapper(1, 1, 1, 1)
    bdlLycan_Wolf.mArmorType = eArmorType.Heavy

    bdlLycan_Wolf.mMoveSpeed = New ValueWrapper(400, 420, 440, 460)
    bdlLycan_Wolf.mCOllisionSize = New ValueWrapper(8, 8, 8, 8)
    bdlLycan_Wolf.mSightrange.Add(New ValueWrapper(1200, 1200, 1200, 1200))
    bdlLycan_Wolf.mSightrange.Add(New ValueWrapper(800, 800, 800, 800))

    bdlLycan_Wolf.mAttackType = eAttackType.Melee
    bdlLycan_Wolf.mAttackSubType = eAttackSubType.Normal

    bdlLycan_Wolf.mAttackDuration.Add(New ValueWrapper(0.33, 0.33, 0.33, 0.33))
    bdlLycan_Wolf.mAttackDuration.Add(New ValueWrapper(0.64, 0.64, 0.64, 0.64))

    ' bdlLycan_Wolf.mMissileSpeed = New ValueWrapper()
    bdlLycan_Wolf.mBaseAttacktime = New ValueWrapper(1.25, 1.2, 1.15, 1.1)

    bdlLycan_Wolf.mBounty.Add(New ValueWrapper(21, 26, 36, 41))
    bdlLycan_Wolf.mBounty.Add(New ValueWrapper(21, 26, 36, 41))
    bdlLycan_Wolf.mXp = New ValueWrapper(20, 20, 20, 20)


    bdlLycan_Wolf.mAbilityNames.Add(eAbilityName.abLycan_Wolf_Critical_Strike)
    bdlLycan_Wolf.mAbilityNames.Add(eAbilityName.abLycan_Wolf_Invisibility)

    Me.Add(ePetName.untLycan_Wolf, bdlLycan_Wolf)
    '--------------------------------------------------------------


    Dim bdlUndying_Zombie As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Undying Zombie
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlUndying_Zombie.mIDItem = New dvID(Guid.NewGuid, "CreepBundle:Undying Zombie", eEntity.Creepbundle)

    bdlUndying_Zombie.mName = ePetName.untUndying_Zombie
    bdlUndying_Zombie.mUnitType = eUnittype.RegularSummons
    bdlUndying_Zombie.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/5/5e/Undying_Minion.png/200px-Undying_Minion.png?version=314e4b16121c7559a87e51fb4474cbd9"
    bdlUndying_Zombie.mWebpageLink = "http://dota2.gamepedia.com/Undying#Undying_Zombie"


    bdlUndying_Zombie.mDuration = New ValueWrapper(15, 20, 25, 30) '- 1 for permanent
    'bdlUndying_Zombie.mLevel = Nothing

    bdlUndying_Zombie.mHealth = New ValueWrapper(30, 30, 30, 30)
    ' bdlUndying_Zombie.mHealthIncrement = New ValueWrapper()
    bdlUndying_Zombie.mHealthRegen = New ValueWrapper(0.25, 0.25, 0.25, 0.25)

    ' bdlUndying_Zombie.mMana = New ValueWrapper()
    ' bdlUndying_Zombie.mManaRegen = New ValueWrapper()

    bdlUndying_Zombie.mDamage.Add(New ValueWrapper(37, 37, 37, 37))
    bdlUndying_Zombie.mDamage.Add(New ValueWrapper(45, 45, 45, 45))

    'bdlUndying_Zombie.mDamageIncrement = New ValueWrapper()

    ' bdlUndying_Zombie.mMagicResistance = New ValueWrapper()

    bdlUndying_Zombie.mArmor = New ValueWrapper(0, 0, 0, 0)
    bdlUndying_Zombie.mArmorType = eArmorType.Unarmored

    bdlUndying_Zombie.mMoveSpeed = New ValueWrapper(375)
    bdlUndying_Zombie.mCOllisionSize = New ValueWrapper(8)
    bdlUndying_Zombie.mSightrange.Add(New ValueWrapper(1400, 1400, 1400, 1400))
    bdlUndying_Zombie.mSightrange.Add(New ValueWrapper(1400, 1400, 1400, 1400))

    bdlUndying_Zombie.mAttackType = eAttackType.Melee
    bdlUndying_Zombie.mAttackSubType = eAttackSubType.Piercing

    bdlUndying_Zombie.mAttackDuration.Add(New ValueWrapper(0.3, 0.3, 0.3, 0.3))
    bdlUndying_Zombie.mAttackDuration.Add(New ValueWrapper(0.3, 0.3, 0.3, 0.3))

    ' bdlUndying_Zombie.mMissileSpeed = New ValueWrapper()
    bdlUndying_Zombie.mBaseAttacktime = New ValueWrapper(1.6, 1.6, 1.6, 1.6)

    bdlUndying_Zombie.mBounty.Add(New ValueWrapper(0, 0, 0, 0))
    bdlUndying_Zombie.mBounty.Add(New ValueWrapper(0, 0, 0, 0))
    bdlUndying_Zombie.mXp = New ValueWrapper(0, 0, 0, 0)


    bdlUndying_Zombie.mAbilityNames.Add(eAbilityName.abUndying_Zombie_Deathlust)
    bdlUndying_Zombie.mAbilityNames.Add(eAbilityName.abUndying_Zombie_Spell_Immunity)

    Me.Add(ePetName.untUndying_Zombie, bdlUndying_Zombie)
    '--------------------------------------------------------------


    Dim bdlSpiderling As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Spiderling
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlSpiderling.mIDItem = New dvID(Guid.NewGuid, "CreepBundle:Spiderling", eEntity.Creepbundle)

    bdlSpiderling.mName = ePetName.untSpiderling
    bdlSpiderling.mUnitType = eUnittype.RegularSummons
    bdlSpiderling.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/6/64/Spiderling_Portrait.png/200px-Spiderling_Portrait.png?version=43a7b5de951f046bed6cd9b4f5d5f83d"
    bdlSpiderling.mWebpageLink = "http://dota2.gamepedia.com/Broodmother#Broodmother.27s_Spiders"


    bdlSpiderling.mDuration = New ValueWrapper(60) '- 1 for permanent
    ' bdlSpiderling.mLevel = Nothing

    bdlSpiderling.mHealth = New ValueWrapper(450)
    ' bdlSpiderling.mHealthIncrement = New ValueWrapper()
    bdlSpiderling.mHealthRegen = New ValueWrapper(0.5)

    ' bdlSpiderling.mMana = New ValueWrapper()
    ' bdlSpiderling.mManaRegen = New ValueWrapper()

    bdlSpiderling.mDamage.Add(New ValueWrapper(18))
    bdlSpiderling.mDamage.Add(New ValueWrapper(19))

    'bdlSpiderling.mDamageIncrement = New ValueWrapper()

    ' bdlSpiderling.mMagicResistance = New ValueWrapper()

    bdlSpiderling.mArmor = New ValueWrapper(0)
    bdlSpiderling.mArmorType = eArmorType.Heavy

    bdlSpiderling.mMoveSpeed = New ValueWrapper(350)
    bdlSpiderling.mCOllisionSize = New ValueWrapper(8)
    bdlSpiderling.mSightrange.Add(New ValueWrapper(1100))
    bdlSpiderling.mSightrange.Add(New ValueWrapper(800))

    bdlSpiderling.mAttackType = eAttackType.Melee
    bdlSpiderling.mAttackSubType = eAttackSubType.Chaos

    bdlSpiderling.mAttackDuration.Add(New ValueWrapper(0.5))
    bdlSpiderling.mAttackDuration.Add(New ValueWrapper(0.3))

    ' bdlSpiderling.mMissileSpeed = New ValueWrapper()
    bdlSpiderling.mBaseAttacktime = New ValueWrapper(1.35)

    bdlSpiderling.mBounty.Add(New ValueWrapper(11))
    bdlSpiderling.mBounty.Add(New ValueWrapper(13))
    bdlSpiderling.mXp = New ValueWrapper(31)


    bdlSpiderling.mAbilityNames.Add(eAbilityName.abSpiderling_Poison_Sting)
    bdlSpiderling.mAbilityNames.Add(eAbilityName.abSpiderling_Spawn_Spiderite)

    Me.Add(ePetName.untSpiderling, bdlSpiderling)
    '--------------------------------------------------------------


    Dim bdlSpiderite As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Spiderite
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlSpiderite.mIDItem = New dvID(Guid.NewGuid, "CreepBundle:Spiderite", eEntity.Creepbundle)

    bdlSpiderite.mName = ePetName.untSpiderite
    bdlSpiderite.mUnitType = eUnittype.RegularSummons
    bdlSpiderite.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/6/64/Spiderling_Portrait.png/200px-Spiderling_Portrait.png?version=43a7b5de951f046bed6cd9b4f5d5f83d"
    bdlSpiderite.mWebpageLink = "http://dota2.gamepedia.com/Broodmother#Broodmother.27s_Spiders"


    bdlSpiderite.mDuration = New ValueWrapper(60) '- 1 for permanent
    ' bdlSpiderite.mLevel = Nothing

    bdlSpiderite.mHealth = New ValueWrapper(175)
    ' bdlSpiderite.mHealthIncrement = New ValueWrapper()
    bdlSpiderite.mHealthRegen = New ValueWrapper(0.5)

    ' bdlSpiderite.mMana = New ValueWrapper()
    ' bdlSpiderite.mManaRegen = New ValueWrapper()

    bdlSpiderite.mDamage.Add(New ValueWrapper(9))
    bdlSpiderite.mDamage.Add(New ValueWrapper(10))

    'bdlSpiderite.mDamageIncrement = New ValueWrapper()

    ' bdlSpiderite.mMagicResistance = New ValueWrapper()

    bdlSpiderite.mArmor = New ValueWrapper(0)
    bdlSpiderite.mArmorType = eArmorType.Heavy

    bdlSpiderite.mMoveSpeed = New ValueWrapper(350)
    bdlSpiderite.mCOllisionSize = New ValueWrapper(8)
    bdlSpiderite.mSightrange.Add(New ValueWrapper(1100))
    bdlSpiderite.mSightrange.Add(New ValueWrapper(800))

    bdlSpiderite.mAttackType = eAttackType.Melee
    bdlSpiderite.mAttackSubType = eAttackSubType.Normal

    bdlSpiderite.mAttackDuration.Add(New ValueWrapper(0.5))
    bdlSpiderite.mAttackDuration.Add(New ValueWrapper(0.3))

    ' bdlSpiderite.mMissileSpeed = New ValueWrapper()
    bdlSpiderite.mBaseAttacktime = New ValueWrapper(1.35)

    bdlSpiderite.mBounty.Add(New ValueWrapper(16))
    bdlSpiderite.mBounty.Add(New ValueWrapper(21))
    bdlSpiderite.mXp = New ValueWrapper(20)


    'bdlSpiderite.mAbilityNames.Add(eAbilityName.abAcid_Spray)

    Me.Add(ePetName.untSpiderite, bdlSpiderite)
    '--------------------------------------------------------------



    Dim bdlTreant As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Treant
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlTreant.mIDItem = New dvID(Guid.NewGuid, "CreepBundle:Treant", eEntity.Creepbundle)

    bdlTreant.mName = ePetName.untTreant
    bdlTreant.mUnitType = eUnittype.RegularSummons
    bdlTreant.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/5/51/Prophet_Treant_Portrait.png/200px-Prophet_Treant_Portrait.png?version=f8fbc1e2ac87f4372defded5d3000027"
    bdlTreant.mWebpageLink = "http://dota2.gamepedia.com/Nature%27s_Prophet"


    bdlTreant.mDuration = New ValueWrapper(60) '- 1 for permanent
    bdlTreant.mLevel = Nothing

    bdlTreant.mHealth = New ValueWrapper(550)
    ' bdlTreant.mHealthIncrement = New ValueWrapper()
    bdlTreant.mHealthRegen = New ValueWrapper(0.5)

    ' bdlTreant.mMana = New ValueWrapper()
    ' bdlTreant.mManaRegen = New ValueWrapper()

    bdlTreant.mDamage.Add(New ValueWrapper(21))
    bdlTreant.mDamage.Add(New ValueWrapper(23))

    'bdlTreant.mDamageIncrement = New ValueWrapper()

    ' bdlTreant.mMagicResistance = New ValueWrapper()

    bdlTreant.mArmor = New ValueWrapper(0)
    bdlTreant.mArmorType = eArmorType.Heavy

    bdlTreant.mMoveSpeed = New ValueWrapper(300)
    bdlTreant.mCOllisionSize = New ValueWrapper(16)
    bdlTreant.mSightrange.Add(New ValueWrapper(1200))
    bdlTreant.mSightrange.Add(New ValueWrapper(800))

    bdlTreant.mAttackType = eAttackType.Melee
    bdlTreant.mAttackSubType = eAttackSubType.Normal

    bdlTreant.mAttackDuration.Add(New ValueWrapper(0.467))
    bdlTreant.mAttackDuration.Add(New ValueWrapper(0.533))

    ' bdlTreant.mMissileSpeed = New ValueWrapper()
    bdlTreant.mBaseAttacktime = New ValueWrapper(1.75)

    bdlTreant.mBounty.Add(New ValueWrapper(14))
    bdlTreant.mBounty.Add(New ValueWrapper(20))
    bdlTreant.mXp = New ValueWrapper(30)


    'bdlTreant.mAbilityNames.Add(eAbilityName.abAcid_Spray)

    Me.Add(ePetName.untTreant, bdlTreant)
    '--------------------------------------------------------------


    Dim bdlEidolon As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Eidolon
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlEidolon.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Eidolon", eEntity.Creepbundle)

    bdlEidolon.mName = ePetName.untEidolon
    bdlEidolon.mUnitType = eUnittype.RegularSummons
    bdlEidolon.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/0/00/Eidolon_Portrait.png/200px-Eidolon_Portrait.png?version=e13bcf40b8a4d390d134f4d58c84dbc7"


    bdlEidolon.mDuration = New ValueWrapper(35, 35, 35, 35) '- 1 for permanent
    'bdlEidolon.mLevel = New ValueWrapper()

    bdlEidolon.mHealth = New ValueWrapper(180, 200, 220, 240)
    'bdlEidolon.mHealthIncrement = New ValueWrapper()
    bdlEidolon.mHealthRegen = New ValueWrapper(0.25)

    'bdlEidolon.mMana = New ValueWrapper()
    'bdlEidolon.mManaRegen = New ValueWrapper()

    bdlEidolon.mDamage.Add(New ValueWrapper(16, 24, 34, 43))
    bdlEidolon.mDamage.Add(New ValueWrapper(24, 32, 42, 51))

    'bdlEidolon.mDamageIncrement = New ValueWrapper()

    bdlEidolon.mMagicResistance = New ValueWrapper(0.5, 0.5, 0.5, 0.5)

    bdlEidolon.mArmor = New ValueWrapper(2, 3, 4, 5)
    bdlEidolon.mArmorType = eArmorType.Heavy

    bdlEidolon.mMoveSpeed = New ValueWrapper(250, 250, 260, 260)
    bdlEidolon.mCOllisionSize = New ValueWrapper(8, 8, 8, 8)
    bdlEidolon.mSightrange.Add(New ValueWrapper(1200, 1200, 1200, 1200))
    bdlEidolon.mSightrange.Add(New ValueWrapper(800, 800, 800, 800))

    bdlEidolon.mAttackType = eAttackType.Ranged
    bdlEidolon.mAttackSubType = eAttackSubType.Normal

    bdlEidolon.mAttackDuration.Add(New ValueWrapper(0.3, 0.3, 0.3, 0.3))
    bdlEidolon.mAttackDuration.Add(New ValueWrapper(0.51, 0.51, 0.51, 0.51))

    bdlEidolon.mCastDuration = New List(Of ValueWrapper)
    bdlEidolon.mCastDuration.Add(New ValueWrapper(0.3, 0.3, 0.3, 0.3))
    bdlEidolon.mCastDuration.Add(New ValueWrapper(0.51, 0.51, 0.51, 0.51))

    bdlEidolon.mMissileSpeed = New ValueWrapper(900, 900, 900, 900)
    bdlEidolon.mBaseAttacktime = New ValueWrapper(1.5, 1.5, 1.5, 1.5)

    bdlEidolon.mBounty.Add(New ValueWrapper(22, 22, 22, 22))
    bdlEidolon.mBounty.Add(New ValueWrapper(36, 36, 36, 36))
    bdlEidolon.mXp = New ValueWrapper(12, 12, 12, 12)


    'bdlEidolon.mAbilityNames.Add(eAbilityName)

    Me.Add(ePetName.untEidolon, bdlEidolon)
    '--------------------------------------------------------------



    Dim bdlForged_Spirit As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Forged Spirit
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlForged_Spirit.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Forged Spirit", eEntity.Creepbundle)

    bdlForged_Spirit.mName = ePetName.untForged_Spirit
    bdlForged_Spirit.mUnitType = eUnittype.RegularSummons
    bdlForged_Spirit.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/f/fb/Forged_Spirit_Portrait.png/200px-Forged_Spirit_Portrait.png?version=9da39e7fbc2af0f64dd6dbf6ad2648e6"


    'bdlForged_Spirit.mDuration = New ValueWrapper() '- 1 for permanent
    'bdlForged_Spirit.mLevel = New ValueWrapper()

    'bdlForged_Spirit.mHealth = New ValueWrapper()
    'bdlForged_Spirit.mHealthIncrement = New ValueWrapper()
    bdlForged_Spirit.mHealthRegen = New ValueWrapper(0.25, 0.25, 0.25, 0.25, 0.25, 0.25, 0.25)

    'bdlForged_Spirit.mMana = New ValueWrapper()
    bdlForged_Spirit.mManaRegen = New ValueWrapper(4, 4, 4, 4, 4, 4, 4)

    'bdlForged_Spirit.mDamage.Add(New ValueWrapper())
    'bdlForged_Spirit.mDamage.Add(New ValueWrapper())

    'bdlForged_Spirit.mDamageIncrement = New ValueWrapper()

    'bdlForged_Spirit.mMagicResistance = New ValueWrapper()

    'bdlForged_Spirit.mArmor = New ValueWrapper()
    bdlForged_Spirit.mArmorType = eArmorType.Heavy

    bdlForged_Spirit.mMoveSpeed = New ValueWrapper(320, 320, 320, 320, 320, 320, 320)
    bdlForged_Spirit.mCOllisionSize = New ValueWrapper(8, 8, 8, 8, 8, 8, 8)
    bdlForged_Spirit.mSightrange.Add(New ValueWrapper(1200, 1200, 1200, 1200, 1200, 1200, 1200))
    bdlForged_Spirit.mSightrange.Add(New ValueWrapper(800, 800, 800, 800, 800, 800, 800))

    bdlForged_Spirit.mAttackType = eAttackType.Ranged
    bdlForged_Spirit.mAttackSubType = eAttackSubType.Chaos

    bdlForged_Spirit.mAttackDuration.Add(New ValueWrapper(0.2, 0.2, 0.2, 0.2, 0.2, 0.2, 0.2))
    bdlForged_Spirit.mAttackDuration.Add(New ValueWrapper(0.4, 0.4, 0.4, 0.4, 0.4, 0.4, 0.4))

    bdlForged_Spirit.mMissileSpeed = New ValueWrapper(1000, 1000, 1000, 1000, 1000, 1000, 1000)
    bdlForged_Spirit.mBaseAttacktime = New ValueWrapper(1.5, 1.5, 1.5, 1.5, 1.5, 1.5, 1.5)

    bdlForged_Spirit.mBounty.Add(New ValueWrapper(32, 32, 32, 32, 32, 32, 32))
    bdlForged_Spirit.mBounty.Add(New ValueWrapper(46, 46, 46, 46, 46, 46, 46))
    bdlForged_Spirit.mXp = New ValueWrapper(31, 31, 31, 31, 31, 31, 31)


    bdlForged_Spirit.mAbilityNames.Add(eAbilityName.abForged_Spirit_Melting_Strike)

    Me.Add(ePetName.untForged_Spirit, bdlForged_Spirit)
    '--------------------------------------------------------------


    Dim bdlEarth_Brewmaster As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Earth
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlEarth_Brewmaster.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Earth", eEntity.Creepbundle)

    bdlEarth_Brewmaster.mName = ePetName.untEarth_Brewmaster
    bdlEarth_Brewmaster.mUnitType = eUnittype.CreepHero
    bdlEarth_Brewmaster.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/2/2f/Earth_portrait.png/200px-Earth_portrait.png?version=5fd9684c3263cf2a90dddc456b6652a8"


    bdlEarth_Brewmaster.mDuration = New ValueWrapper(15, 17, 19) '- 1 for permanent
    'bdlEarth_Brewmaster.mLevel = New ValueWrapper()

    bdlEarth_Brewmaster.mHealth = New ValueWrapper(1500, 2250, 3000)
    'bdlEarth_Brewmaster.mHealthIncrement = New ValueWrapper()
    bdlEarth_Brewmaster.mHealthRegen = New ValueWrapper(1, 2, 2)

    bdlEarth_Brewmaster.mMana = New ValueWrapper(400, 500, 600)
    bdlEarth_Brewmaster.mManaRegen = New ValueWrapper(2, 2, 2)

    bdlEarth_Brewmaster.mDamage.Add(New ValueWrapper(37, 75, 159))
    bdlEarth_Brewmaster.mDamage.Add(New ValueWrapper(43, 84, 171))

    'bdlEarth_Brewmaster.mDamageIncrement = New ValueWrapper()

    'bdlEarth_Brewmaster.mMagicResistance = New ValueWrapper()

    bdlEarth_Brewmaster.mArmor = New ValueWrapper(5, 5, 5)
    bdlEarth_Brewmaster.mArmorType = eArmorType.Heavy

    bdlEarth_Brewmaster.mMoveSpeed = New ValueWrapper(325, 325, 325)
    bdlEarth_Brewmaster.mCOllisionSize = New ValueWrapper(8, 8, 8)
    bdlEarth_Brewmaster.mSightrange.Add(New ValueWrapper(1800, 1800, 1800))
    bdlEarth_Brewmaster.mSightrange.Add(New ValueWrapper(800, 800, 800))

    bdlEarth_Brewmaster.mAttackType = eAttackType.Melee
    bdlEarth_Brewmaster.mAttackSubType = eAttackSubType.Piercing

    bdlEarth_Brewmaster.mAttackDuration.Add(New ValueWrapper(0.3, 0.3, 0.3))
    bdlEarth_Brewmaster.mAttackDuration.Add(New ValueWrapper(0.3, 0.3, 0.3))

    bdlEarth_Brewmaster.mCastDuration = New List(Of ValueWrapper)
    bdlEarth_Brewmaster.mCastDuration.Add(New ValueWrapper(0.4, 0.4, 0.4))
    bdlEarth_Brewmaster.mCastDuration.Add(New ValueWrapper(0.5, 0.5, 0.5))
    'bdlEarth_Brewmaster.mMissileSpeed = New ValueWrapper()
    bdlEarth_Brewmaster.mBaseAttacktime = New ValueWrapper(1.35, 1.35, 1.35)

    bdlEarth_Brewmaster.mBounty.Add(New ValueWrapper(11, 11, 31))
    bdlEarth_Brewmaster.mBounty.Add(New ValueWrapper(15, 15, 35))
    bdlEarth_Brewmaster.mXp = New ValueWrapper(196, 242, 242)


    bdlEarth_Brewmaster.mAbilityNames.Add(eAbilityName.abEarth_Brewmaster_Hurl_Boulder)
    bdlEarth_Brewmaster.mAbilityNames.Add(eAbilityName.abEarth_Brewmaster_Spell_Immunity)
    bdlEarth_Brewmaster.mAbilityNames.Add(eAbilityName.abEarth_Brewmaster_Pulverize)
    bdlEarth_Brewmaster.mAbilityNames.Add(eAbilityName.abEarth_Brewmaster_Thunder_Clap)

    Me.Add(ePetName.untEarth_Brewmaster, bdlEarth_Brewmaster)
    '--------------------------------------------------------------



    Dim bdlStorm_Brewmaster As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Storm
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlStorm_Brewmaster.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Storm", eEntity.Creepbundle)

    bdlStorm_Brewmaster.mName = ePetName.untStorm_Brewmaster
    bdlStorm_Brewmaster.mUnitType = eUnittype.CreepHero
    bdlStorm_Brewmaster.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/c/c0/Storm_portrait.png/200px-Storm_portrait.png?version=55ff2945f2daf1f2fed9830efc4c9d41"


    bdlStorm_Brewmaster.mDuration = New ValueWrapper(15, 17, 19) '- 1 for permanent
    'bdlStorm_Brewmaster.mLevel = New ValueWrapper()

    bdlStorm_Brewmaster.mHealth = New ValueWrapper(1000, 1500, 1900)
    'bdlStorm_Brewmaster.mHealthIncrement = New ValueWrapper(1, 2, 2)
    bdlStorm_Brewmaster.mHealthRegen = New ValueWrapper(1, 2, 2)

    bdlStorm_Brewmaster.mMana = New ValueWrapper(500, 750, 750)
    bdlStorm_Brewmaster.mManaRegen = New ValueWrapper(1.5, 1.5, 1.5)

    bdlStorm_Brewmaster.mDamage.Add(New ValueWrapper(37, 75, 159))
    bdlStorm_Brewmaster.mDamage.Add(New ValueWrapper(43, 84, 171))

    'bdlStorm_Brewmaster.mDamageIncrement = New ValueWrapper()

    'bdlStorm_Brewmaster.mMagicResistance = New ValueWrapper()

    bdlStorm_Brewmaster.mArmor = New ValueWrapper(2, 2, 2)
    bdlStorm_Brewmaster.mArmorType = eArmorType.Heavy

    bdlStorm_Brewmaster.mMoveSpeed = New ValueWrapper(350)
    bdlStorm_Brewmaster.mCOllisionSize = New ValueWrapper(8)
    bdlStorm_Brewmaster.mSightrange.Add(New ValueWrapper(1800, 1800, 1800))
    bdlStorm_Brewmaster.mSightrange.Add(New ValueWrapper(800))

    bdlStorm_Brewmaster.mAttackType = eAttackType.Ranged
    bdlStorm_Brewmaster.mAttackSubType = eAttackSubType.Piercing

    bdlStorm_Brewmaster.mAttackDuration.Add(New ValueWrapper(0.4, 0.4, 0.4))
    bdlStorm_Brewmaster.mAttackDuration.Add(New ValueWrapper(0.77, 0.77, 0.77))

    bdlStorm_Brewmaster.mCastDuration = New List(Of ValueWrapper)
    bdlStorm_Brewmaster.mCastDuration.Add(New ValueWrapper(0.4, 0.4, 0.4))
    bdlStorm_Brewmaster.mCastDuration.Add(New ValueWrapper(0.5, 0.5, 0.5))

    bdlStorm_Brewmaster.mMissileSpeed = New ValueWrapper(1200, 1200, 1200)
    bdlStorm_Brewmaster.mBaseAttacktime = New ValueWrapper(1.5, 1.5, 1.5)

    bdlStorm_Brewmaster.mBounty.Add(New ValueWrapper(11, 11, 31))
    bdlStorm_Brewmaster.mBounty.Add(New ValueWrapper(15, 15, 35))
    bdlStorm_Brewmaster.mXp = New ValueWrapper(196, 242, 242)


    bdlStorm_Brewmaster.mAbilityNames.Add(eAbilityName.abStorm_Brewmaster_Dispel_Magic)
    bdlStorm_Brewmaster.mAbilityNames.Add(eAbilityName.abStorm_Brewmaster_Cyclone)
    bdlStorm_Brewmaster.mAbilityNames.Add(eAbilityName.abStorm_Brewmaster_Wind_Walk)
    bdlStorm_Brewmaster.mAbilityNames.Add(eAbilityName.abStorm_Brewmaster_Drunken_Haze)


    Me.Add(ePetName.untStorm_Brewmaster, bdlStorm_Brewmaster)
    '--------------------------------------------------------------



    Dim bdlFire_Brewmaster As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Fire
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlFire_Brewmaster.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Fire", eEntity.Creepbundle)

    bdlFire_Brewmaster.mName = ePetName.untFire_Brewmaster
    bdlFire_Brewmaster.mUnitType = eUnittype.CreepHero
    bdlFire_Brewmaster.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/d/d3/Fire_portrait.png/200px-Fire_portrait.png?version=1e0ee4bd9c4c3ce3aa58432407cce3d0"


    bdlFire_Brewmaster.mDuration = New ValueWrapper(15, 17, 19) '- 1 for permanent
    'bdlFire_Brewmaster.mLevel = New ValueWrapper()

    bdlFire_Brewmaster.mHealth = New ValueWrapper(1200, 1200, 1200)
    'bdlFire_Brewmaster.mHealthIncrement = New ValueWrapper()
    bdlFire_Brewmaster.mHealthRegen = New ValueWrapper(2, 4, 4)

    'bdlFire_Brewmaster.mMana = New ValueWrapper()
    'bdlFire_Brewmaster.mManaRegen = New ValueWrapper()

    bdlFire_Brewmaster.mDamage.Add(New ValueWrapper(72, 115, 144))
    bdlFire_Brewmaster.mDamage.Add(New ValueWrapper(82, 130, 164))

    'bdlFire_Brewmaster.mDamageIncrement = New ValueWrapper()

    'bdlFire_Brewmaster.mMagicResistance = New ValueWrapper()

    bdlFire_Brewmaster.mArmor = New ValueWrapper(0, 0, 0)
    bdlFire_Brewmaster.mArmorType = eArmorType.Heavy

    bdlFire_Brewmaster.mMoveSpeed = New ValueWrapper(522, 522, 522)
    bdlFire_Brewmaster.mCOllisionSize = New ValueWrapper(8, 8, 8)
    bdlFire_Brewmaster.mSightrange.Add(New ValueWrapper(1800, 1800, 1800))
    bdlFire_Brewmaster.mSightrange.Add(New ValueWrapper(800, 800, 800))

    bdlFire_Brewmaster.mAttackType = eAttackType.Melee
    bdlFire_Brewmaster.mAttackSubType = eAttackSubType.Hero

    bdlFire_Brewmaster.mAttackDuration.Add(New ValueWrapper(0.3, 0.3, 0.3))
    bdlFire_Brewmaster.mAttackDuration.Add(New ValueWrapper(0.3, 0.3, 0.3))

    'bdlFire_Brewmaster.mMissileSpeed = New ValueWrapper()
    bdlFire_Brewmaster.mBaseAttacktime = New ValueWrapper(1.35, 1.35, 1.35)

    bdlFire_Brewmaster.mBounty.Add(New ValueWrapper(11, 11, 31))
    bdlFire_Brewmaster.mBounty.Add(New ValueWrapper(15, 15, 35))
    bdlFire_Brewmaster.mXp = New ValueWrapper(196, 242, 242)


    bdlFire_Brewmaster.mAbilityNames.Add(eAbilityName.abFire_Brewmaster_Permanent_Immolation)
    bdlFire_Brewmaster.mAbilityNames.Add(eAbilityName.abFire_Brewmaster_Drunken_Brawler)

    Me.Add(ePetName.untFire_Brewmaster, bdlFire_Brewmaster)
    '--------------------------------------------------------------



    Dim bdlGolem_Warlock As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Golem
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlGolem_Warlock.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Golem", eEntity.Creepbundle)

    bdlGolem_Warlock.mName = ePetName.untGolem_Warlock
    bdlGolem_Warlock.mUnitType = eUnittype.CreepHero
    bdlGolem_Warlock.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/9/92/Warlock_Golem_Portrait.png/200px-Warlock_Golem_Portrait.png?version=2c1bb0c1a976857896e4988acd898292"


    bdlGolem_Warlock.mDuration = New ValueWrapper(60, 60, 60) '- 1 for permanent
    'bdlGolem_Warlock.mLevel = New ValueWrapper()

    bdlGolem_Warlock.mHealth = New ValueWrapper(900, 1200, 1500)
    Dim aghshealth As New List(Of Double?)
    aghshealth.Add(675)
    aghshealth.Add(900)
    aghshealth.Add(1125)
    bdlGolem_Warlock.mHealth.LoadScepterValues(aghshealth)

    'bdlGolem_Warlock.mHealthIncrement = New ValueWrapper()
    bdlGolem_Warlock.mHealthRegen = New ValueWrapper(15, 30, 45)

    'bdlGolem_Warlock.mMana = New ValueWrapper()
    'bdlGolem_Warlock.mManaRegen = New ValueWrapper()

    bdlGolem_Warlock.mDamage.Add(New ValueWrapper(75, 100, 125))
    Dim aghdamage As New List(Of Double?)
    aghdamage.Add(131)
    aghdamage.Add(175)
    aghdamage.Add(219)
    bdlGolem_Warlock.mDamage.Item(0).LoadScepterValues(aghdamage)

    bdlGolem_Warlock.mDamage.Add(New ValueWrapper(75, 100, 125))
    bdlGolem_Warlock.mDamage.Item(1).LoadScepterValues(aghdamage)

    'bdlGolem_Warlock.mDamageIncrement = New ValueWrapper()

    bdlGolem_Warlock.mMagicResistance = New ValueWrapper(0.33, 0.33, 0.33)

    bdlGolem_Warlock.mArmor = New ValueWrapper(6, 9, 12)
    bdlGolem_Warlock.mArmorType = eArmorType.Hero

    bdlGolem_Warlock.mMoveSpeed = New ValueWrapper(320, 340, 360)
    bdlGolem_Warlock.mCOllisionSize = New ValueWrapper(16, 16, 16)
    bdlGolem_Warlock.mSightrange.Add(New ValueWrapper(1800, 1800, 1800))
    bdlGolem_Warlock.mSightrange.Add(New ValueWrapper(1800, 1800, 1800))

    bdlGolem_Warlock.mAttackType = eAttackType.Melee
    bdlGolem_Warlock.mAttackSubType = eAttackSubType.Chaos

    bdlGolem_Warlock.mAttackDuration.Add(New ValueWrapper(0.26, 0.26, 0.26))
    bdlGolem_Warlock.mAttackDuration.Add(New ValueWrapper(0.74, 0.74, 0.74))

    'bdlGolem_Warlock.mMissileSpeed = New ValueWrapper()
    bdlGolem_Warlock.mBaseAttacktime = New ValueWrapper(1.2, 1.2, 1.2)

    bdlGolem_Warlock.mBounty.Add(New ValueWrapper(50, 150, 100))
    Dim aghbounty As New List(Of Double?)
    aghbounty.Add(50)
    aghbounty.Add(75)
    aghbounty.Add(100)
    bdlGolem_Warlock.mBounty.Item(0).LoadScepterValues(aghbounty)

    bdlGolem_Warlock.mBounty.Add(New ValueWrapper(50, 150, 100))
    bdlGolem_Warlock.mBounty.Item(1).LoadScepterValues(aghbounty)

    bdlGolem_Warlock.mXp = New ValueWrapper(98, 98, 98)


    bdlGolem_Warlock.mAbilityNames.Add(eAbilityName.abGolem_Warlock_Flaming_Fists)
    bdlGolem_Warlock.mAbilityNames.Add(eAbilityName.abGolem_Warlock_Permanent_immolation)

    Me.Add(ePetName.untGolem_Warlock, bdlGolem_Warlock)
    '--------------------------------------------------------------



    Dim bdlSpirit_Bear As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Spirit Bear
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlSpirit_Bear.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Spirit Bear", eEntity.Creepbundle)

    bdlSpirit_Bear.mName = ePetName.untSpirit_Bear
    bdlSpirit_Bear.mUnitType = eUnittype.CreepHero
    bdlSpirit_Bear.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/f/f8/Spirit_Bear_Portrait.png/200px-Spirit_Bear_Portrait.png?version=152daf8fdc58ab8e9841fd737eb49c82"


    bdlSpirit_Bear.mDuration = New ValueWrapper(-1, -1, -1, -1) '- 1 for permanent
    'bdlSpirit_Bear.mLevel = New ValueWrapper()

    bdlSpirit_Bear.mHealth = New ValueWrapper(1400, 1800, 2300, 2700)
    'bdlSpirit_Bear.mHealthIncrement = New ValueWrapper()
    bdlSpirit_Bear.mHealthRegen = New ValueWrapper(2, 3, 4, 5)

    bdlSpirit_Bear.mMana = New ValueWrapper(300, 300, 300, 300)
    bdlSpirit_Bear.mManaRegen = New ValueWrapper(0, 0, 0, 0)

    bdlSpirit_Bear.mDamage.Add(New ValueWrapper(28, 28, 28, 28))
    bdlSpirit_Bear.mDamage.Add(New ValueWrapper(38, 38, 38, 38))

    'bdlSpirit_Bear.mDamageIncrement = New ValueWrapper()

    'bdlSpirit_Bear.mMagicResistance = New ValueWrapper()

    bdlSpirit_Bear.mArmor = New ValueWrapper(3, 4, 5, 6)
    bdlSpirit_Bear.mArmorType = eArmorType.Heavy

    bdlSpirit_Bear.mMoveSpeed = New ValueWrapper(320, 320, 320, 320)
    bdlSpirit_Bear.mCOllisionSize = New ValueWrapper(24, 24, 24, 24)
    bdlSpirit_Bear.mSightrange.Add(New ValueWrapper(1400, 1400, 1400, 1400))
    bdlSpirit_Bear.mSightrange.Add(New ValueWrapper(800, 800, 800, 800))

    bdlSpirit_Bear.mAttackType = eAttackType.Melee
    bdlSpirit_Bear.mAttackSubType = eAttackSubType.Normal

    bdlSpirit_Bear.mAttackDuration.Add(New ValueWrapper(0.43, 0.43, 0.43, 0.43))
    bdlSpirit_Bear.mAttackDuration.Add(New ValueWrapper(0.67, 0.67, 0.67, 0.67))

    'bdlSpirit_Bear.mMissileSpeed = New ValueWrapper()
    bdlSpirit_Bear.mBaseAttacktime = New ValueWrapper(1.75, 1.65, 1.55, 1.45)

    bdlSpirit_Bear.mBounty.Add(New ValueWrapper(300, 300, 300, 300))
    bdlSpirit_Bear.mBounty.Add(New ValueWrapper(300, 300, 300, 300))
    bdlSpirit_Bear.mXp = New ValueWrapper(300, 300, 300, 300)


    bdlSpirit_Bear.mAbilityNames.Add(eAbilityName.abSpirit_Bear_Return)
    bdlSpirit_Bear.mAbilityNames.Add(eAbilityName.abSpirit_Bear_Entangling_Claws)
    bdlSpirit_Bear.mAbilityNames.Add(eAbilityName.abSpirit_Bear_Demolish)

    Me.Add(ePetName.untSpirit_Bear, bdlSpirit_Bear)
    '--------------------------------------------------------------



    Dim bdlFamiliar As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Familiar
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlFamiliar.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Familiar", eEntity.Creepbundle)

    bdlFamiliar.mName = ePetName.untFamiliar
    bdlFamiliar.mUnitType = eUnittype.CreepHero
    bdlFamiliar.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/f/f2/Visage_Familiar.jpg/200px-Visage_Familiar.jpg?version=ec9ea45fe18ec2cc859a1a3d891c04a6"


    bdlFamiliar.mDuration = New ValueWrapper(-1, -1, -1) '- 1 for permanent
    'bdlFamiliar.mLevel = New ValueWrapper()

    bdlFamiliar.mHealth = New ValueWrapper(300, 450, 600)
    'bdlFamiliar.mHealthIncrement = New ValueWrapper()
    bdlFamiliar.mHealthRegen = New ValueWrapper(0, 0, 0)

    'bdlFamiliar.mMana = New ValueWrapper()
    'bdlFamiliar.mManaRegen = New ValueWrapper()

    bdlFamiliar.mDamage.Add(New ValueWrapper(10, 10, 10))
    bdlFamiliar.mDamage.Add(New ValueWrapper(10, 10, 10))

    'bdlFamiliar.mDamageIncrement = New ValueWrapper()

    'bdlFamiliar.mMagicResistance = New ValueWrapper()

    bdlFamiliar.mArmor = New ValueWrapper(0, 1, 2)
    bdlFamiliar.mArmorType = eArmorType.Hero

    bdlFamiliar.mMoveSpeed = New ValueWrapper(380, 390, 400)
    bdlFamiliar.mCOllisionSize = New ValueWrapper(32, 32, 32)
    bdlFamiliar.mSightrange.Add(New ValueWrapper(390, 390, 390))
    bdlFamiliar.mSightrange.Add(New ValueWrapper(390, 390, 390))

    bdlFamiliar.mAttackRange = New ValueWrapper(160, 160, 160)
    bdlFamiliar.mAttackType = eAttackType.Ranged
    bdlFamiliar.mAttackSubType = eAttackSubType.Hero

    bdlFamiliar.mAttackDuration.Add(New ValueWrapper(0.33, 0.33, 0.33))
    bdlFamiliar.mAttackDuration.Add(New ValueWrapper(0.2, 0.2, 0.2))

    bdlFamiliar.mMissileSpeed = New ValueWrapper(900, 900, 900)
    bdlFamiliar.mBaseAttacktime = New ValueWrapper(0.4, 0.4, 0.4)

    bdlFamiliar.mBounty.Add(New ValueWrapper(100, 100, 100))
    bdlFamiliar.mBounty.Add(New ValueWrapper(100, 100, 100))
    bdlFamiliar.mXp = New ValueWrapper(41, 41, 41)


    bdlFamiliar.mAbilityNames.Add(eAbilityName.abFamiliar_Stone_Form)

    Me.Add(ePetName.untFamiliar, bdlFamiliar)
    '--------------------------------------------------------------



    Dim bdlPlague_Ward As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Plague Ward
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlPlague_Ward.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Plague Ward", eEntity.Creepbundle)

    bdlPlague_Ward.mName = ePetName.untPlague_Ward
    bdlPlague_Ward.mUnitType = eUnittype.Ward
    bdlPlague_Ward.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/5/5a/Venomancer_Plague_Ward.png/200px-Venomancer_Plague_Ward.png?version=66ef4ce0dd72291da40b4fd461fcb7eb"


    bdlPlague_Ward.mDuration = New ValueWrapper(40, 40, 40, 40) '- 1 for permanent
    'bdlPlague_Ward.mLevel = New ValueWrapper()

    bdlPlague_Ward.mHealth = New ValueWrapper(75, 200, 325, 450)
    'bdlPlague_Ward.mHealthIncrement = New ValueWrapper()
    'bdlPlague_Ward.mHealthRegen = New ValueWrapper()

    'bdlPlague_Ward.mMana = New ValueWrapper()
    'bdlPlague_Ward.mManaRegen = New ValueWrapper()

    bdlPlague_Ward.mDamage.Add(New ValueWrapper(9, 17, 26, 34))
    bdlPlague_Ward.mDamage.Add(New ValueWrapper(11, 21, 32, 42))

    'bdlPlague_Ward.mDamageIncrement = New ValueWrapper()

    'bdlPlague_Ward.mMagicResistance = New ValueWrapper()

    bdlPlague_Ward.mArmor = New ValueWrapper(0, 0, 0, 0)
    bdlPlague_Ward.mArmorType = eArmorType.Heavy

    bdlPlague_Ward.mMoveSpeed = New ValueWrapper(0, 0, 0, 0)
    bdlPlague_Ward.mCOllisionSize = New ValueWrapper(8, 8, 8, 8)
    bdlPlague_Ward.mSightrange.Add(New ValueWrapper(1200, 1200, 1200, 1200))
    bdlPlague_Ward.mSightrange.Add(New ValueWrapper(800, 800, 800, 800))

    bdlPlague_Ward.mAttackRange = New ValueWrapper(600, 600, 600, 600)
    bdlPlague_Ward.mAttackType = eAttackType.Ranged
    bdlPlague_Ward.mAttackSubType = eAttackSubType.Piercing

    bdlPlague_Ward.mAttackDuration.Add(New ValueWrapper(0.3, 0.3, 0.3, 0.3))
    bdlPlague_Ward.mAttackDuration.Add(New ValueWrapper(0.7, 0.7, 0.7, 0.7))

    bdlPlague_Ward.mMissileSpeed = New ValueWrapper(1900)
    bdlPlague_Ward.mBaseAttacktime = New ValueWrapper(1.5, 1.5, 1.5, 1.5)

    bdlPlague_Ward.mBounty.Add(New ValueWrapper(14, 14, 14, 14))
    bdlPlague_Ward.mBounty.Add(New ValueWrapper(17, 17, 17, 17))
    bdlPlague_Ward.mXp = New ValueWrapper(20, 25, 30, 35)


    bdlPlague_Ward.mAbilityNames.Add(eAbilityName.abPlague_Ward_Poison_Sting)

    Me.Add(ePetName.untPlague_Ward, bdlPlague_Ward)
    '--------------------------------------------------------------



    Dim bdlSerpent_Ward As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Serpent Ward
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlSerpent_Ward.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Serpent Ward", eEntity.Creepbundle)

    bdlSerpent_Ward.mName = ePetName.untSerpent_Ward
    bdlSerpent_Ward.mUnitType = eUnittype.Ward
    bdlSerpent_Ward.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/a/a6/Shadow_Shaman_Mass_Serpent_Ward.png/200px-Shadow_Shaman_Mass_Serpent_Ward.png?version=508b439cf6935405b728d192cc5d49d9"


    bdlSerpent_Ward.mDuration = New ValueWrapper(45, 45, 45) '- 1 for permanent
    'bdlSerpent_Ward.mLevel = New ValueWrapper()

    bdlSerpent_Ward.mHealth = New ValueWrapper(135, 150, 150)
    'bdlSerpent_Ward.mHealthIncrement = New ValueWrapper()
    'bdlSerpent_Ward.mHealthRegen = New ValueWrapper()

    'bdlSerpent_Ward.mMana = New ValueWrapper()
    'bdlSerpent_Ward.mManaRegen = New ValueWrapper()

    bdlSerpent_Ward.mDamage.Add(New ValueWrapper(125, 160, 195))
    bdlSerpent_Ward.mDamage.Add(New ValueWrapper(135, 170, 205))

    'bdlSerpent_Ward.mDamageIncrement = New ValueWrapper()

    'bdlSerpent_Ward.mMagicResistance = New ValueWrapper()

    bdlSerpent_Ward.mArmor = New ValueWrapper(0, 0, 0)
    bdlSerpent_Ward.mArmorType = eArmorType.Heavy

    bdlSerpent_Ward.mMoveSpeed = New ValueWrapper(0, 0, 0)
    bdlSerpent_Ward.mCOllisionSize = New ValueWrapper(8, 8, 8)
    bdlSerpent_Ward.mSightrange.Add(New ValueWrapper(1200, 1200, 1200))
    bdlSerpent_Ward.mSightrange.Add(New ValueWrapper(800, 800, 800))

    bdlSerpent_Ward.mAttackType = eAttackType.Ranged
    bdlSerpent_Ward.mAttackSubType = eAttackSubType.Piercing

    bdlSerpent_Ward.mAttackDuration.Add(New ValueWrapper(0.3, 0.3, 0.3))
    bdlSerpent_Ward.mAttackDuration.Add(New ValueWrapper(0.4, 0.4, 0.4))

    bdlSerpent_Ward.mMissileSpeed = New ValueWrapper(900, 900, 900)
    bdlSerpent_Ward.mBaseAttacktime = New ValueWrapper(1.5, 1.5, 1.5)

    bdlSerpent_Ward.mBounty.Add(New ValueWrapper(26, 26, 26))
    bdlSerpent_Ward.mBounty.Add(New ValueWrapper(38, 38, 38))
    bdlSerpent_Ward.mXp = New ValueWrapper(31, 31, 31)


    'bdlSerpent_Ward.mAbilityNames.Add(eAbilityName)

    Me.Add(ePetName.untSerpent_Ward, bdlSerpent_Ward)
    '--------------------------------------------------------------



    Dim bdlDeath_Ward As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Death Ward
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlDeath_Ward.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Death Ward", eEntity.Creepbundle)

    bdlDeath_Ward.mName = ePetName.untDeath_Ward
    bdlDeath_Ward.mUnitType = eUnittype.Ward
    bdlDeath_Ward.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/8/83/Death_Ward_Portrait.png/200px-Death_Ward_Portrait.png?version=7ffe4c9a96c7c254df0f6dcd4c168dcc"


    bdlDeath_Ward.mDuration = New ValueWrapper(8, 8, 8) '- 1 for permanent
    'bdlDeath_Ward.mLevel = New ValueWrapper()

    bdlDeath_Ward.mHealth = New ValueWrapper(135, 135, 135)
    'bdlDeath_Ward.mHealthIncrement = New ValueWrapper()
    'bdlDeath_Ward.mHealthRegen = New ValueWrapper()

    'bdlDeath_Ward.mMana = New ValueWrapper()
    'bdlDeath_Ward.mManaRegen = New ValueWrapper()

    bdlDeath_Ward.mDamage.Add(New ValueWrapper(150, 210, 270))
    bdlDeath_Ward.mDamage.Add(New ValueWrapper(150, 210, 270))

    'bdlDeath_Ward.mDamageIncrement = New ValueWrapper()

    'bdlDeath_Ward.mMagicResistance = New ValueWrapper()

    bdlDeath_Ward.mArmor = New ValueWrapper(0, 0, 0)
    bdlDeath_Ward.mArmorType = eArmorType.None

    bdlDeath_Ward.mMoveSpeed = New ValueWrapper(0, 0, 0)
    bdlDeath_Ward.mCOllisionSize = New ValueWrapper(16, 16, 16)
    bdlDeath_Ward.mSightrange.Add(New ValueWrapper(1200, 1200, 1200))
    bdlDeath_Ward.mSightrange.Add(New ValueWrapper(800, 800, 800))

    bdlDeath_Ward.mAttackType = eAttackType.Ranged
    bdlDeath_Ward.mAttackSubType = eAttackSubType.Chaos

    bdlDeath_Ward.mAttackDuration.Add(New ValueWrapper(0, 0, 0))
    bdlDeath_Ward.mAttackDuration.Add(New ValueWrapper(0, 0, 0))

    bdlDeath_Ward.mMissileSpeed = New ValueWrapper(1000, 1000, 1000)
    bdlDeath_Ward.mBaseAttacktime = New ValueWrapper(0.22, 0.22, 0.22)

    bdlDeath_Ward.mBounty.Add(New ValueWrapper(0, 0, 0))
    bdlDeath_Ward.mBounty.Add(New ValueWrapper(0, 0, 0))
    bdlDeath_Ward.mXp = New ValueWrapper(0, 0, 0)


    'bdlDeath_Ward.mAbilityNames.Add(eAbilityName)

    Me.Add(ePetName.untDeath_Ward, bdlDeath_Ward)
    '--------------------------------------------------------------



    Dim bdlHealing_Ward As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Healing Ward
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlHealing_Ward.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Healing Ward", eEntity.Creepbundle)

    bdlHealing_Ward.mName = ePetName.untHealing_Ward
    bdlHealing_Ward.mUnitType = eUnittype.Ward
    bdlHealing_Ward.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/f/f9/Juggernaut_Healing_Ward.png/200px-Juggernaut_Healing_Ward.png?version=a1c47cc963e22553ade2960c9334abbc"


    bdlHealing_Ward.mDuration = New ValueWrapper(25) '- 1 for permanent
    'bdlHealing_Ward.mLevel = New ValueWrapper()

    bdlHealing_Ward.mHealth = New ValueWrapper(1)
    'bdlHealing_Ward.mHealthIncrement = New ValueWrapper()
    'bdlHealing_Ward.mHealthRegen = New ValueWrapper()

    'bdlHealing_Ward.mMana = New ValueWrapper()
    'bdlHealing_Ward.mManaRegen = New ValueWrapper()

    'bdlHealing_Ward.mDamage.Add(New ValueWrapper())
    'bdlHealing_Ward.mDamage.Add(New ValueWrapper())

    'bdlHealing_Ward.mDamageIncrement = New ValueWrapper()

    'bdlHealing_Ward.mMagicResistance = New ValueWrapper()

    bdlHealing_Ward.mArmor = New ValueWrapper(0)
    bdlHealing_Ward.mArmorType = eArmorType.Medium

    bdlHealing_Ward.mMoveSpeed = New ValueWrapper(450)
    bdlHealing_Ward.mCOllisionSize = New ValueWrapper(8)
    bdlHealing_Ward.mSightrange.Add(New ValueWrapper(500))
    bdlHealing_Ward.mSightrange.Add(New ValueWrapper(500))

    bdlHealing_Ward.mAttackType = eAttackType.None
    bdlHealing_Ward.mAttackSubType = eAttackSubType.None

    'bdlHealing_Ward.mAttackDuration.Add(New ValueWrapper())
    'bdlHealing_Ward.mAttackDuration.Add(New ValueWrapper())

    'bdlHealing_Ward.mMissileSpeed = New ValueWrapper()
    'bdlHealing_Ward.mBaseAttacktime = New ValueWrapper()

    bdlHealing_Ward.mBounty.Add(New ValueWrapper(0))
    bdlHealing_Ward.mBounty.Add(New ValueWrapper(0))
    bdlHealing_Ward.mXp = New ValueWrapper(0)


    'bdlHealing_Ward.mAbilityNames.Add(eAbilityName)

    Me.Add(ePetName.untHealing_Ward, bdlHealing_Ward)
    '--------------------------------------------------------------



    Dim bdlFrozen_Sigil As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Frozen Sigil
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlFrozen_Sigil.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Frozen Sigil", eEntity.Creepbundle)

    bdlFrozen_Sigil.mName = ePetName.untFrozen_Sigil
    bdlFrozen_Sigil.mUnitType = eUnittype.Ward
    bdlFrozen_Sigil.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/6/62/Tusk_Frozen_Sigil_model.png/200px-Tusk_Frozen_Sigil_model.png?version=a9069290b33c435d6f03c49981c8eefa"


    bdlFrozen_Sigil.mDuration = New ValueWrapper(30, 30, 30, 30) '- 1 for permanent
    'bdlFrozen_Sigil.mLevel = New ValueWrapper()

    bdlFrozen_Sigil.mHealth = New ValueWrapper(12, 12, 16, 16)
    'bdlFrozen_Sigil.mHealthIncrement = New ValueWrapper()
    'bdlFrozen_Sigil.mHealthRegen = New ValueWrapper()

    'bdlFrozen_Sigil.mMana = New ValueWrapper()
    'bdlFrozen_Sigil.mManaRegen = New ValueWrapper()

    'bdlFrozen_Sigil.mDamage.Add(New ValueWrapper())
    'bdlFrozen_Sigil.mDamage.Add(New ValueWrapper())

    'bdlFrozen_Sigil.mDamageIncrement = New ValueWrapper()

    'bdlFrozen_Sigil.mMagicResistance = New ValueWrapper()

    bdlFrozen_Sigil.mArmor = New ValueWrapper(0, 0, 0, 0)
    bdlFrozen_Sigil.mArmorType = eArmorType.Medium

    bdlFrozen_Sigil.mMoveSpeed = New ValueWrapper(310, 310, 310, 310)
    bdlFrozen_Sigil.mCOllisionSize = New ValueWrapper(8, 8, 8, 8)
    bdlFrozen_Sigil.mSightrange.Add(New ValueWrapper(400, 400, 400, 400))
    bdlFrozen_Sigil.mSightrange.Add(New ValueWrapper(400, 400, 400, 400))

    'bdlFrozen_Sigil.mAttackType = eAttackType
    'bdlFrozen_Sigil.mAttackSubType = eAttackSubType.None

    'bdlFrozen_Sigil.mAttackDuration.Add(New ValueWrapper())
    'bdlFrozen_Sigil.mAttackDuration.Add(New ValueWrapper())

    'bdlFrozen_Sigil.mMissileSpeed = New ValueWrapper()
    'bdlFrozen_Sigil.mBaseAttacktime = New ValueWrapper()

    bdlFrozen_Sigil.mBounty.Add(New ValueWrapper(90, 100, 110, 120))
    bdlFrozen_Sigil.mBounty.Add(New ValueWrapper(90, 100, 110, 120))
    bdlFrozen_Sigil.mXp = New ValueWrapper(0, 0, 0, 0)


    'bdlFrozen_Sigil.mAbilityNames.Add(eAbilityName)

    Me.Add(ePetName.untFrozen_Sigil, bdlFrozen_Sigil)
    '--------------------------------------------------------------



    Dim bdlTornado As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Tornado
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlTornado.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Tornado", eEntity.Creepbundle)

    bdlTornado.mName = ePetName.untTornado
    bdlTornado.mUnitType = eUnittype.Ward
    bdlTornado.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/e/e2/Cyclone_%28Storm%29_icon.png"


    bdlTornado.mDuration = New ValueWrapper(40) '- 1 for permanent
    'bdlTornado.mLevel = New ValueWrapper()

    bdlTornado.mHealth = New ValueWrapper(500)
    'bdlTornado.mHealthIncrement = New ValueWrapper()
    'bdlTornado.mHealthRegen = New ValueWrapper()

    'bdlTornado.mMana = New ValueWrapper()
    'bdlTornado.mManaRegen = New ValueWrapper()

    'bdlTornado.mDamage.Add(New ValueWrapper())
    'bdlTornado.mDamage.Add(New ValueWrapper())

    'bdlTornado.mDamageIncrement = New ValueWrapper()

    'bdlTornado.mMagicResistance = New ValueWrapper()

    bdlTornado.mArmor = New ValueWrapper(0)
    bdlTornado.mArmorType = eArmorType.None

    bdlTornado.mMoveSpeed = New ValueWrapper(125)
    bdlTornado.mCOllisionSize = New ValueWrapper(16)
    bdlTornado.mSightrange.Add(New ValueWrapper(300))
    bdlTornado.mSightrange.Add(New ValueWrapper(300))

    bdlTornado.mAttackType = eAttackType.None
    bdlTornado.mAttackSubType = eAttackSubType.None

    ' bdlTornado.mAttackDuration.Add(New ValueWrapper())
    'bdlTornado.mAttackDuration.Add(New ValueWrapper())

    'bdlTornado.mMissileSpeed = New ValueWrapper()
    'bdlTornado.mBaseAttacktime = New ValueWrapper()

    bdlTornado.mBounty.Add(New ValueWrapper(0))
    bdlTornado.mBounty.Add(New ValueWrapper(0))
    bdlTornado.mXp = New ValueWrapper(0)


    bdlTornado.mAbilityNames.Add(eAbilityName.abTornado_Tempest)

    Me.Add(ePetName.untTornado, bdlTornado)
    '--------------------------------------------------------------



    Dim bdlPsionic_Trap As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Psionic Trap
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlPsionic_Trap.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Psionic Trap", eEntity.Creepbundle)

    bdlPsionic_Trap.mName = ePetName.untPsionic_Trap
    bdlPsionic_Trap.mUnitType = eUnittype.Ward
    bdlPsionic_Trap.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/a/a7/Psionic_Trap_icon.png?version=9c305f22b44dea3da04e22a3c5eab416"


    bdlPsionic_Trap.mDuration = New ValueWrapper(-1) '- 1 for permanent
    'bdlPsionic_Trap.mLevel = New ValueWrapper()

    bdlPsionic_Trap.mHealth = New ValueWrapper(100)
    'bdlPsionic_Trap.mHealthIncrement = New ValueWrapper()
    'bdlPsionic_Trap.mHealthRegen = New ValueWrapper()

    'bdlPsionic_Trap.mMana = New ValueWrapper()
    'bdlPsionic_Trap.mManaRegen = New ValueWrapper()

    'bdlPsionic_Trap.mDamage.Add(New ValueWrapper())
    'bdlPsionic_Trap.mDamage.Add(New ValueWrapper())

    'bdlPsionic_Trap.mDamageIncrement = New ValueWrapper()

    'bdlPsionic_Trap.mMagicResistance = New ValueWrapper()

    bdlPsionic_Trap.mArmor = New ValueWrapper(0)
    bdlPsionic_Trap.mArmorType = eArmorType.Medium

    bdlPsionic_Trap.mMoveSpeed = New ValueWrapper(0)
    bdlPsionic_Trap.mCOllisionSize = New ValueWrapper(0)
    bdlPsionic_Trap.mSightrange.Add(New ValueWrapper(400))
    bdlPsionic_Trap.mSightrange.Add(New ValueWrapper(400))

    bdlPsionic_Trap.mAttackType = eAttackType.None
    bdlPsionic_Trap.mAttackSubType = eAttackSubType.None

    'bdlPsionic_Trap.mAttackDuration.Add(New ValueWrapper())
    'bdlPsionic_Trap.mAttackDuration.Add(New ValueWrapper())

    'bdlPsionic_Trap.mMissileSpeed = New ValueWrapper()
    'bdlPsionic_Trap.mBaseAttacktime = New ValueWrapper()

    bdlPsionic_Trap.mBounty.Add(New ValueWrapper(1))
    bdlPsionic_Trap.mBounty.Add(New ValueWrapper(1))
    bdlPsionic_Trap.mXp = New ValueWrapper(12)


    bdlPsionic_Trap.mAbilityNames.Add(eAbilityName.abPsionic_Trap_Self_Trap)

    Me.Add(ePetName.untPsionic_Trap, bdlPsionic_Trap)
    '--------------------------------------------------------------



    Dim bdlLand_Mine As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Land Mine
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlLand_Mine.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Land Mine", eEntity.Creepbundle)

    bdlLand_Mine.mName = ePetName.untLand_Mine
    bdlLand_Mine.mUnitType = eUnittype.Ward
    bdlLand_Mine.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/0/07/Techies_Land_Mine.png/200px-Techies_Land_Mine.png?version=6cddca3befcebb5bd4a045627d614ce2"


    bdlLand_Mine.mDuration = New ValueWrapper(-1) '- 1 for permanent
    'bdlLand_Mine.mLevel = New ValueWrapper()

    bdlLand_Mine.mHealth = New ValueWrapper(100)
    'bdlLand_Mine.mHealthIncrement = New ValueWrapper()
    'bdlLand_Mine.mHealthRegen = New ValueWrapper()

    'bdlLand_Mine.mMana = New ValueWrapper()
    'bdlLand_Mine.mManaRegen = New ValueWrapper()

    'bdlLand_Mine.mDamage.Add(New ValueWrapper())
    'bdlLand_Mine.mDamage.Add(New ValueWrapper())

    'bdlLand_Mine.mDamageIncrement = New ValueWrapper()

    'bdlLand_Mine.mMagicResistance = New ValueWrapper()

    bdlLand_Mine.mArmor = New ValueWrapper(0)
    bdlLand_Mine.mArmorType = eArmorType.Medium

    bdlLand_Mine.mMoveSpeed = New ValueWrapper(0)
    bdlLand_Mine.mCOllisionSize = New ValueWrapper(8)
    bdlLand_Mine.mSightrange.Add(New ValueWrapper(64))
    bdlLand_Mine.mSightrange.Add(New ValueWrapper(64))

    bdlLand_Mine.mAttackType = eAttackType.None
    bdlLand_Mine.mAttackSubType = eAttackSubType.None

    'bdlLand_Mine.mAttackDuration.Add(New ValueWrapper())
    'bdlLand_Mine.mAttackDuration.Add(New ValueWrapper())

    'bdlLand_Mine.mMissileSpeed = New ValueWrapper()
    'bdlLand_Mine.mBaseAttacktime = New ValueWrapper()

    bdlLand_Mine.mBounty.Add(New ValueWrapper(0))
    bdlLand_Mine.mBounty.Add(New ValueWrapper(0))
    bdlLand_Mine.mXp = New ValueWrapper(14)


    'bdlLand_Mine.mAbilityNames.Add(eAbilityName.)

    Me.Add(ePetName.untLand_Mine, bdlLand_Mine)
    '--------------------------------------------------------------



    Dim bdlStasis_Trap As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Stasis Trap
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlStasis_Trap.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Stasis Trap", eEntity.Creepbundle)

    bdlStasis_Trap.mName = ePetName.untStasis_Trap
    bdlStasis_Trap.mUnitType = eUnittype.Ward
    bdlStasis_Trap.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/a/a7/Techies_Stasis_Trap.png/200px-Techies_Stasis_Trap.png?version=b5bf7226d88cf14b3992358c62ab3b25"


    bdlStasis_Trap.mDuration = New ValueWrapper(360) '- 1 for permanent
    'bdlStasis_Trap.mLevel = New ValueWrapper()

    bdlStasis_Trap.mHealth = New ValueWrapper(100)
    'bdlStasis_Trap.mHealthIncrement = New ValueWrapper()
    'bdlStasis_Trap.mHealthRegen = New ValueWrapper()

    'bdlStasis_Trap.mMana = New ValueWrapper()
    'bdlStasis_Trap.mManaRegen = New ValueWrapper()

    'bdlStasis_Trap.mDamage.Add(New ValueWrapper())
    'bdlStasis_Trap.mDamage.Add(New ValueWrapper())

    'bdlStasis_Trap.mDamageIncrement = New ValueWrapper()

    'bdlStasis_Trap.mMagicResistance = New ValueWrapper()

    bdlStasis_Trap.mArmor = New ValueWrapper(0)
    bdlStasis_Trap.mArmorType = eArmorType.Medium

    bdlStasis_Trap.mMoveSpeed = New ValueWrapper(0)
    bdlStasis_Trap.mCOllisionSize = New ValueWrapper(8)
    bdlStasis_Trap.mSightrange.Add(New ValueWrapper(600))
    bdlStasis_Trap.mSightrange.Add(New ValueWrapper(600))

    bdlStasis_Trap.mAttackType = eAttackType.None
    bdlStasis_Trap.mAttackSubType = eAttackSubType.None

    'bdlStasis_Trap.mAttackDuration.Add(New ValueWrapper())
    'bdlStasis_Trap.mAttackDuration.Add(New ValueWrapper())

    'bdlStasis_Trap.mMissileSpeed = New ValueWrapper()
    'bdlStasis_Trap.mBaseAttacktime = New ValueWrapper()

    bdlStasis_Trap.mBounty.Add(New ValueWrapper(0))
    bdlStasis_Trap.mBounty.Add(New ValueWrapper(0))
    bdlStasis_Trap.mXp = New ValueWrapper(6)


    'bdlStasis_Trap.mAbilityNames.Add(eAbilityName)

    Me.Add(ePetName.untStasis_Trap, bdlStasis_Trap)
    '--------------------------------------------------------------



    Dim bdlRemote_Mine As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Remote Mine
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlRemote_Mine.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Remote Mine", eEntity.Creepbundle)

    bdlRemote_Mine.mName = ePetName.untRemote_Mine
    bdlRemote_Mine.mUnitType = eUnittype.Ward
    bdlRemote_Mine.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/c/c2/Techies_Remote_Mine.png/200px-Techies_Remote_Mine.png?version=af20aca45569dddbaeacea73f575f545"


    bdlRemote_Mine.mDuration = New ValueWrapper(600) '- 1 for permanent
    'bdlRemote_Mine.mLevel = New ValueWrapper()

    bdlRemote_Mine.mHealth = New ValueWrapper(200)
    'bdlRemote_Mine.mHealthIncrement = New ValueWrapper()
    'bdlRemote_Mine.mHealthRegen = New ValueWrapper()

    'bdlRemote_Mine.mMana = New ValueWrapper()
    'bdlRemote_Mine.mManaRegen = New ValueWrapper()

    'bdlRemote_Mine.mDamage.Add(New ValueWrapper())
    'bdlRemote_Mine.mDamage.Add(New ValueWrapper())

    'bdlRemote_Mine.mDamageIncrement = New ValueWrapper()

    'bdlRemote_Mine.mMagicResistance = New ValueWrapper()

    bdlRemote_Mine.mArmor = New ValueWrapper(0)
    bdlRemote_Mine.mArmorType = eArmorType.Medium

    bdlRemote_Mine.mMoveSpeed = New ValueWrapper(0)
    bdlRemote_Mine.mCOllisionSize = New ValueWrapper(0)
    bdlRemote_Mine.mSightrange.Add(New ValueWrapper(700))
    bdlRemote_Mine.mSightrange.Add(New ValueWrapper(700))

    bdlRemote_Mine.mAttackType = eAttackType.None
    bdlRemote_Mine.mAttackSubType = eAttackSubType.None

    'bdlRemote_Mine.mAttackDuration.Add(New ValueWrapper())
    'bdlRemote_Mine.mAttackDuration.Add(New ValueWrapper())

    'bdlRemote_Mine.mMissileSpeed = New ValueWrapper()
    'bdlRemote_Mine.mBaseAttacktime = New ValueWrapper()

    bdlRemote_Mine.mBounty.Add(New ValueWrapper(0))
    bdlRemote_Mine.mBounty.Add(New ValueWrapper(0))
    bdlRemote_Mine.mXp = New ValueWrapper(6)


    bdlRemote_Mine.mAbilityNames.Add(eAbilityName.abRemote_Mines_Pinpoint_Detonate)

    Me.Add(ePetName.untRemote_Mine, bdlRemote_Mine)
    '--------------------------------------------------------------



    Dim bdlNether_Ward As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Nether Ward
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlNether_Ward.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Nether Ward", eEntity.Creepbundle)

    bdlNether_Ward.mName = ePetName.untNether_Ward
    bdlNether_Ward.mUnitType = eUnittype.Ward
    bdlNether_Ward.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/9/92/Pugna_Nether_ward_model.png/200px-Pugna_Nether_ward_model.png?version=75da288328787faebd219648c7aa690e"


    bdlNether_Ward.mDuration = New ValueWrapper(30) '- 1 for permanent
    'bdlNether_Ward.mLevel = New ValueWrapper()

    bdlNether_Ward.mHealth = New ValueWrapper(12)
    'bdlNether_Ward.mHealthIncrement = New ValueWrapper()
    'bdlNether_Ward.mHealthRegen = New ValueWrapper()

    'bdlNether_Ward.mMana = New ValueWrapper()
    'bdlNether_Ward.mManaRegen = New ValueWrapper()

    'bdlNether_Ward.mDamage.Add(New ValueWrapper())
    'bdlNether_Ward.mDamage.Add(New ValueWrapper())

    'bdlNether_Ward.mDamageIncrement = New ValueWrapper()

    'bdlNether_Ward.mMagicResistance = New ValueWrapper()

    bdlNether_Ward.mArmor = New ValueWrapper(0)
    bdlNether_Ward.mArmorType = eArmorType.Medium

    bdlNether_Ward.mMoveSpeed = New ValueWrapper(0)
    bdlNether_Ward.mCOllisionSize = New ValueWrapper(8)
    bdlNether_Ward.mSightrange.Add(New ValueWrapper(600))
    bdlNether_Ward.mSightrange.Add(New ValueWrapper(600))

    bdlNether_Ward.mAttackType = eAttackType.None
    bdlNether_Ward.mAttackSubType = eAttackSubType.None

    'bdlNether_Ward.mAttackDuration.Add(New ValueWrapper())
    'bdlNether_Ward.mAttackDuration.Add(New ValueWrapper())

    'bdlNether_Ward.mMissileSpeed = New ValueWrapper()
    'bdlNether_Ward.mBaseAttacktime = New ValueWrapper()

    bdlNether_Ward.mBounty.Add(New ValueWrapper(20, 40, 60, 80))
    bdlNether_Ward.mBounty.Add(New ValueWrapper(20, 40, 60, 80))
    bdlNether_Ward.mXp = New ValueWrapper(0, 0, 0, 0)


    'bdlNether_Ward.mAbilityNames.Add(eAbilityName)

    Me.Add(ePetName.untNether_Ward, bdlNether_Ward)
    '--------------------------------------------------------------



    Dim bdlPower_Cog As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Power Cog
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlPower_Cog.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Power Cog", eEntity.Creepbundle)

    bdlPower_Cog.mName = ePetName.untPower_Cog
    bdlPower_Cog.mUnitType = eUnittype.Ward
    bdlPower_Cog.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/a/ab/Clockwerk_Power_Cog_Model.png/200px-Clockwerk_Power_Cog_Model.png?version=5124b805fa7c70b58e9973d10332a6ee"


    bdlPower_Cog.mDuration = New ValueWrapper(5, 6, 7, 8) '- 1 for permanent
    'bdlPower_Cog.mLevel = New ValueWrapper()

    bdlPower_Cog.mHealth = New ValueWrapper(100, 100, 100, 100)
    'bdlPower_Cog.mHealthIncrement = New ValueWrapper()
    'bdlPower_Cog.mHealthRegen = New ValueWrapper()

    'bdlPower_Cog.mMana = New ValueWrapper()
    'bdlPower_Cog.mManaRegen = New ValueWrapper()

    'bdlPower_Cog.mDamage.Add(New ValueWrapper())
    'bdlPower_Cog.mDamage.Add(New ValueWrapper())

    'bdlPower_Cog.mDamageIncrement = New ValueWrapper()

    'bdlPower_Cog.mMagicResistance = New ValueWrapper()

    bdlPower_Cog.mArmor = New ValueWrapper(0, 0, 0, 0)
    bdlPower_Cog.mArmorType = eArmorType.None

    bdlPower_Cog.mMoveSpeed = New ValueWrapper(0, 0, 0, 0)
    bdlPower_Cog.mCOllisionSize = New ValueWrapper(75, 75, 75, 75)
    bdlPower_Cog.mSightrange.Add(New ValueWrapper(1600, 1600, 1600, 1600))
    bdlPower_Cog.mSightrange.Add(New ValueWrapper(600, 600, 600, 600))

    bdlPower_Cog.mAttackType = eAttackType.None
    bdlPower_Cog.mAttackSubType = eAttackSubType.None

    'bdlPower_Cog.mAttackDuration.Add(New ValueWrapper())
    'bdlPower_Cog.mAttackDuration.Add(New ValueWrapper())

    'bdlPower_Cog.mMissileSpeed = New ValueWrapper()
    'bdlPower_Cog.mBaseAttacktime = New ValueWrapper()

    bdlPower_Cog.mBounty.Add(New ValueWrapper(0, 0, 0, 0))
    bdlPower_Cog.mBounty.Add(New ValueWrapper(0, 0, 0, 0))
    bdlPower_Cog.mXp = New ValueWrapper(0, 0, 0, 0)


    'bdlPower_Cog.mAbilityNames.Add(eAbilityName)

    Me.Add(ePetName.untPower_Cog, bdlPower_Cog)
    '--------------------------------------------------------------



    Dim bdlTombstone As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Tombstone
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlTombstone.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Tombstone", eEntity.Creepbundle)

    bdlTombstone.mName = ePetName.untTombstone
    bdlTombstone.mUnitType = eUnittype.Ward
    bdlTombstone.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/9/98/Undying_Tombstone.png/200px-Undying_Tombstone.png?version=8c1151c04c1075276f66faede75d27a6"


    bdlTombstone.mDuration = New ValueWrapper(15, 20, 25, 30) '- 1 for permanent
    'bdlTombstone.mLevel = New ValueWrapper()

    bdlTombstone.mHealth = New ValueWrapper(200, 400, 600, 800)
    'bdlTombstone.mHealthIncrement = New ValueWrapper()
    'bdlTombstone.mHealthRegen = New ValueWrapper()

    'bdlTombstone.mMana = New ValueWrapper()
    'bdlTombstone.mManaRegen = New ValueWrapper()

    'bdlTombstone.mDamage.Add(New ValueWrapper())
    'bdlTombstone.mDamage.Add(New ValueWrapper())

    'bdlTombstone.mDamageIncrement = New ValueWrapper()

    'bdlTombstone.mMagicResistance = New ValueWrapper()

    bdlTombstone.mArmor = New ValueWrapper(0, 0, 0, 0)
    bdlTombstone.mArmorType = eArmorType.Medium

    bdlTombstone.mMoveSpeed = New ValueWrapper(0, 0, 0, 0)
    bdlTombstone.mCOllisionSize = New ValueWrapper(0, 0, 0, 0)
    bdlTombstone.mSightrange.Add(New ValueWrapper(1800, 1800, 1800, 1800))
    bdlTombstone.mSightrange.Add(New ValueWrapper(1800, 1800, 1800, 1800))

    bdlTombstone.mAttackType = eAttackType.None
    bdlTombstone.mAttackSubType = eAttackSubType.None

    'bdlTombstone.mAttackDuration.Add(New ValueWrapper())
    'bdlTombstone.mAttackDuration.Add(New ValueWrapper())

    'bdlTombstone.mMissileSpeed = New ValueWrapper()
    'bdlTombstone.mBaseAttacktime = New ValueWrapper()

    bdlTombstone.mBounty.Add(New ValueWrapper(75, 100, 125, 150))
    bdlTombstone.mBounty.Add(New ValueWrapper(75, 100, 125, 150))
    bdlTombstone.mXp = New ValueWrapper(44, 44, 44, 44)


    'bdlTombstone.mAbilityNames.Add(eAbilityName)

    Me.Add(ePetName.untTombstone, bdlTombstone)
    '--------------------------------------------------------------



    Dim bdlPhoenix_Sun As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Phoenix Sun
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlPhoenix_Sun.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Phoenix Sun", eEntity.Creepbundle)

    bdlPhoenix_Sun.mName = ePetName.untPhoenix_Sun
    bdlPhoenix_Sun.mUnitType = eUnittype.Ward
    bdlPhoenix_Sun.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/1/15/Phoenix_Supernova_model.png/200px-Phoenix_Supernova_model.png?version=060818ed97fa6cfa77fb63bb914ef824"


    bdlPhoenix_Sun.mDuration = New ValueWrapper(6, 6, 6) '- 1 for permanent
    'bdlPhoenix_Sun.mLevel = New ValueWrapper()

    bdlPhoenix_Sun.mHealth = New ValueWrapper(5, 8, 11)
    'bdlPhoenix_Sun.mHealthIncrement = New ValueWrapper()
    'bdlPhoenix_Sun.mHealthRegen = New ValueWrapper()

    'bdlPhoenix_Sun.mMana = New ValueWrapper()
    'bdlPhoenix_Sun.mManaRegen = New ValueWrapper()

    'bdlPhoenix_Sun.mDamage.Add(New ValueWrapper())
    'bdlPhoenix_Sun.mDamage.Add(New ValueWrapper())

    'bdlPhoenix_Sun.mDamageIncrement = New ValueWrapper()

    'bdlPhoenix_Sun.mMagicResistance = New ValueWrapper()

    bdlPhoenix_Sun.mArmor = New ValueWrapper(0)
    bdlPhoenix_Sun.mArmorType = eArmorType.None

    bdlPhoenix_Sun.mMoveSpeed = New ValueWrapper(0, 0, 0)
    bdlPhoenix_Sun.mCOllisionSize = New ValueWrapper(24, 24, 24)
    bdlPhoenix_Sun.mSightrange.Add(New ValueWrapper(1800, 1800, 1800))
    bdlPhoenix_Sun.mSightrange.Add(New ValueWrapper(1800, 1800, 1800))

    bdlPhoenix_Sun.mAttackType = eAttackType.None
    bdlPhoenix_Sun.mAttackSubType = eAttackSubType.None

    'bdlPhoenix_Sun.mAttackDuration.Add(New ValueWrapper())
    'bdlPhoenix_Sun.mAttackDuration.Add(New ValueWrapper())

    'bdlPhoenix_Sun.mMissileSpeed = New ValueWrapper()
    'bdlPhoenix_Sun.mBaseAttacktime = New ValueWrapper()

    bdlPhoenix_Sun.mBounty.Add(New ValueWrapper(20, 20, 20))
    bdlPhoenix_Sun.mBounty.Add(New ValueWrapper(20, 20, 20))
    bdlPhoenix_Sun.mXp = New ValueWrapper(0, 0, 0)


    'bdlPhoenix_Sun.mAbilityNames.Add(eAbilityName)

    Me.Add(ePetName.untPhoenix_Sun, bdlPhoenix_Sun)
    '--------------------------------------------------------------



    Dim bdlObserver_Ward As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Observer Ward
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlObserver_Ward.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Observer Ward", eEntity.Creepbundle)

    bdlObserver_Ward.mName = ePetName.untObserver_Ward
    bdlObserver_Ward.mUnitType = eUnittype.Ward
    bdlObserver_Ward.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/d/d3/Observer_Ward_Model_Topdown.png/200px-Observer_Ward_Model_Topdown.png?version=d49da2a0b672e75a9fc036c8a10e2445"


    bdlObserver_Ward.mDuration = New ValueWrapper(420) '- 1 for permanent
    'bdlObserver_Ward.mLevel = New ValueWrapper()

    bdlObserver_Ward.mHealth = New ValueWrapper(200)
    'bdlObserver_Ward.mHealthIncrement = New ValueWrapper()
    'bdlObserver_Ward.mHealthRegen = New ValueWrapper()

    'bdlObserver_Ward.mMana = New ValueWrapper()
    'bdlObserver_Ward.mManaRegen = New ValueWrapper()

    'bdlObserver_Ward.mDamage.Add(New ValueWrapper())
    'bdlObserver_Ward.mDamage.Add(New ValueWrapper())

    'bdlObserver_Ward.mDamageIncrement = New ValueWrapper()

    'bdlObserver_Ward.mMagicResistance = New ValueWrapper()

    bdlObserver_Ward.mArmor = New ValueWrapper(0)
    bdlObserver_Ward.mArmorType = eArmorType.None

    bdlObserver_Ward.mMoveSpeed = New ValueWrapper(0)
    bdlObserver_Ward.mCOllisionSize = New ValueWrapper(0)
    bdlObserver_Ward.mSightrange.Add(New ValueWrapper(1600))
    bdlObserver_Ward.mSightrange.Add(New ValueWrapper(1600))

    bdlObserver_Ward.mAttackType = eAttackType.None
    bdlObserver_Ward.mAttackSubType = eAttackSubType.None

    'bdlObserver_Ward.mAttackDuration.Add(New ValueWrapper())
    'bdlObserver_Ward.mAttackDuration.Add(New ValueWrapper())

    'bdlObserver_Ward.mMissileSpeed = New ValueWrapper()
    'bdlObserver_Ward.mBaseAttacktime = New ValueWrapper()

    bdlObserver_Ward.mBounty.Add(New ValueWrapper(50))
    bdlObserver_Ward.mBounty.Add(New ValueWrapper(50))
    bdlObserver_Ward.mXp = New ValueWrapper(0)


    'bdlObserver_Ward.mAbilityNames.Add(eAbilityName)

    Me.Add(ePetName.untObserver_Ward, bdlObserver_Ward)
    '--------------------------------------------------------------



    Dim bdlSentry_Ward As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Sentry Ward
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlSentry_Ward.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Sentry Ward", eEntity.Creepbundle)

    bdlSentry_Ward.mName = ePetName.untSentry_Ward
    bdlSentry_Ward.mUnitType = eUnittype.Ward
    bdlSentry_Ward.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/3/3c/Sentry_Ward_Model_Topdown.png/200px-Sentry_Ward_Model_Topdown.png?version=82c029807627f35a5c9c8819425f5094"


    bdlSentry_Ward.mDuration = New ValueWrapper(240) '- 1 for permanent
    'bdlSentry_Ward.mLevel = New ValueWrapper()

    bdlSentry_Ward.mHealth = New ValueWrapper(200)
    'bdlSentry_Ward.mHealthIncrement = New ValueWrapper()
    'bdlSentry_Ward.mHealthRegen = New ValueWrapper()

    'bdlSentry_Ward.mMana = New ValueWrapper()
    'bdlSentry_Ward.mManaRegen = New ValueWrapper()

    'bdlSentry_Ward.mDamage.Add(New ValueWrapper())
    'bdlSentry_Ward.mDamage.Add(New ValueWrapper())

    'bdlSentry_Ward.mDamageIncrement = New ValueWrapper()

    'bdlSentry_Ward.mMagicResistance = New ValueWrapper()

    bdlSentry_Ward.mArmor = New ValueWrapper(0)
    bdlSentry_Ward.mArmorType = eArmorType.None

    bdlSentry_Ward.mMoveSpeed = New ValueWrapper(0)
    bdlSentry_Ward.mCOllisionSize = New ValueWrapper(0)
    bdlSentry_Ward.mSightrange.Add(New ValueWrapper(0))
    bdlSentry_Ward.mSightrange.Add(New ValueWrapper(0))

    bdlSentry_Ward.mAttackType = eAttackType.None
    bdlSentry_Ward.mAttackSubType = eAttackSubType.None

    'bdlSentry_Ward.mAttackDuration.Add(New ValueWrapper())
    'bdlSentry_Ward.mAttackDuration.Add(New ValueWrapper())

    'bdlSentry_Ward.mMissileSpeed = New ValueWrapper()
    'bdlSentry_Ward.mBaseAttacktime = New ValueWrapper()

    bdlSentry_Ward.mBounty.Add(New ValueWrapper(0))
    bdlSentry_Ward.mBounty.Add(New ValueWrapper(0))
    bdlSentry_Ward.mXp = New ValueWrapper(0)


    'bdlSentry_Ward.mAbilityNames.Add(eAbilityName)

    Me.Add(ePetName.untSentry_Ward, bdlSentry_Ward)
    '--------------------------------------------------------------

    Dim bdlBeetle As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''bdlBeetle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlBeetle.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Beetle", eEntity.Creepbundle)

    bdlBeetle.mName = ePetName.untBeetle
    bdlBeetle.mUnitType = eUnittype.Unclassified
    bdlBeetle.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/7/77/Weaver_Swarm.png/200px-Weaver_Swarm.png?version=8d955d5e408f38fdfac78c98835f37bf"


    bdlBeetle.mDuration = New ValueWrapper(14, 16, 18, 20) '- 1 for permanent
    ' bdlBeetle.mLevel = New ValueWrapper()

    bdlBeetle.mHealth = New ValueWrapper(8, 8, 8, 8)
    'bdlBeetle.mHealthIncrement = New ValueWrapper()
    'bdlBeetle.mHealthRegen = New ValueWrapper()

    'bdlBeetle.mMana = New ValueWrapper()
    'bdlBeetle.mManaRegen = New ValueWrapper()

    bdlBeetle.mDamage.Add(New ValueWrapper(15, 20, 25, 30))
    bdlBeetle.mDamage.Add(New ValueWrapper(15, 20, 25, 30))

    'bdlBeetle.mDamageIncrement = New ValueWrapper()

    bdlBeetle.mMagicResistance = New ValueWrapper(1, 1, 1, 1)

    bdlBeetle.mArmor = New ValueWrapper(0, 0, 0, 0)
    bdlBeetle.mArmorType = eArmorType.None

    'bdlBeetle.mMoveSpeed = New ValueWrapper()
    bdlBeetle.mCOllisionSize = New ValueWrapper(8, 8, 8, 8)
    bdlBeetle.mSightrange.Add(New ValueWrapper(321, 321, 321, 321))
    bdlBeetle.mSightrange.Add(New ValueWrapper(321, 321, 321, 321))

    bdlBeetle.mAttackType = eAttackType.None
    bdlBeetle.mAttackSubType = eAttackSubType.None

    'bdlBeetle.mAttackDuration.Add(New ValueWrapper(0, 0, 0, 0))
    'bdlBeetle.mAttackDuration.Add(New ValueWrapper())

    'bdlBeetle.mMissileSpeed = New ValueWrapper()
    bdlBeetle.mBaseAttacktime = New ValueWrapper(1.35, 1.35, 1.35, 1.35)

    bdlBeetle.mBounty.Add(New ValueWrapper(32, 32, 32, 32))
    bdlBeetle.mBounty.Add(New ValueWrapper(34, 34, 34, 34))
    bdlBeetle.mXp = New ValueWrapper(20, 20, 20, 20)


    'bdlBeetle.mAbilityNames.Add(eAbilityName)

    Me.Add(ePetName.untBeetle, bdlBeetle)



    Dim bdlHomingMissile As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Homing Missile
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlHomingMissile.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Homing Missile", eEntity.Creepbundle)

    bdlHomingMissile.mName = ePetName.untHoming_Missile
    bdlHomingMissile.mUnitType = eUnittype.Unclassified
    bdlHomingMissile.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/4/4e/Gyrocopter_Homing_Missile.png/200px-Gyrocopter_Homing_Missile.png?version=2c448f898767244c0614e9c995d34a39"


    bdlHomingMissile.mDuration = New ValueWrapper(-1) '- 1 for permanent
    'bdlHomingMissile.mLevel = New ValueWrapper()

    bdlHomingMissile.mHealth = New ValueWrapper(100, 100, 100, 100)
    'bdlHomingMissile.mHealthIncrement = New ValueWrapper()
    'bdlHomingMissile.mHealthRegen = New ValueWrapper()

    'bdlHomingMissile.mMana = New ValueWrapper()
    'bdlHomingMissile.mManaRegen = New ValueWrapper()

    'bdlHomingMissile.mDamage.Add(New ValueWrapper())
    'bdlHomingMissile.mDamage.Add(New ValueWrapper())

    'bdlHomingMissile.mDamageIncrement = New ValueWrapper()

    'bdlHomingMissile.mMagicResistance = New ValueWrapper()

    bdlHomingMissile.mArmor = New ValueWrapper(0)
    bdlHomingMissile.mArmorType = eArmorType.None

    'bdlHomingMissile.mMoveSpeed = New ValueWrapper()
    bdlHomingMissile.mCOllisionSize = New ValueWrapper(0)
    bdlHomingMissile.mSightrange.Add(New ValueWrapper(400))
    bdlHomingMissile.mSightrange.Add(New ValueWrapper(400))

    bdlHomingMissile.mAttackType = eAttackType.None
    bdlHomingMissile.mAttackSubType = eAttackSubType.None

    'bdlHomingMissile.mAttackDuration.Add(New ValueWrapper())
    'bdlHomingMissile.mAttackDuration.Add(New ValueWrapper())

    'bdlHomingMissile.mMissileSpeed = New ValueWrapper()
    'bdlHomingMissile.mBaseAttacktime = New ValueWrapper()

    bdlHomingMissile.mBounty.Add(New ValueWrapper(20))
    bdlHomingMissile.mBounty.Add(New ValueWrapper(30))
    bdlHomingMissile.mXp = New ValueWrapper(20)


    'bdlHomingMissile.mAbilityNames.Add(eAbilityName)

    Me.Add(ePetName.untHoming_Missile, bdlHomingMissile)



    Dim bdlAstralSpirit As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Astral Spirit
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlAstralSpirit.mIDItem = New dvID(Guid.NewGuid, "CreepBundle:  Astral Spirit", eEntity.Creepbundle)

    bdlAstralSpirit.mName = ePetName.untAstral_Spirit
    bdlAstralSpirit.mUnitType = eUnittype.Unclassified
    bdlAstralSpirit.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/abilities/elder_titan_return_spirit_hp1.png"


    'bdlAstralSpirit.mDuration = New ValueWrapper() '- 1 for permanent
    'bdlAstralSpirit.mLevel = New ValueWrapper()

    'bdlAstralSpirit.mHealth = New ValueWrapper()
    'bdlAstralSpirit.mHealthIncrement = New ValueWrapper()
    'bdlAstralSpirit.mHealthRegen = New ValueWrapper()

    'bdlAstralSpirit.mMana = New ValueWrapper()
    'bdlAstralSpirit.mManaRegen = New ValueWrapper()

    'bdlAstralSpirit.mDamage.Add(New ValueWrapper())
    'bdlAstralSpirit.mDamage.Add(New ValueWrapper())

    'bdlAstralSpirit.mDamageIncrement = New ValueWrapper()

    'bdlAstralSpirit.mMagicResistance = New ValueWrapper()

    bdlAstralSpirit.mArmor = New ValueWrapper(0)
    bdlAstralSpirit.mArmorType = eArmorType.None

    'bdlAstralSpirit.mMoveSpeed = New ValueWrapper()
    bdlAstralSpirit.mCOllisionSize = New ValueWrapper(0)
    'bdlAstralSpirit.mSightrange.Add(New ValueWrapper())
    'bdlAstralSpirit.mSightrange.Add(New ValueWrapper())

    bdlAstralSpirit.mAttackType = eAttackType.None
    bdlAstralSpirit.mAttackSubType = eAttackSubType.None

    'bdlAstralSpirit.mAttackDuration.Add(New ValueWrapper())
    'bdlAstralSpirit.mAttackDuration.Add(New ValueWrapper())

    'bdlAstralSpirit.mMissileSpeed = New ValueWrapper()
    'bdlAstralSpirit.mBaseAttacktime = New ValueWrapper()

    bdlAstralSpirit.mBounty.Add(New ValueWrapper(0))
    bdlAstralSpirit.mBounty.Add(New ValueWrapper(0))
    bdlAstralSpirit.mXp = New ValueWrapper(0)


    'bdlAstralSpirit.mAbilityNames.Add(eAbilityName)

    Me.Add(ePetName.untAstral_Spirit, bdlAstralSpirit)



    Dim bdlSpinWeb As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Spin Web
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlSpinWeb.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Spin Web", eEntity.Creepbundle)

    bdlSpinWeb.mName = ePetName.untSpin_Web
    bdlSpinWeb.mUnitType = eUnittype.Unclassified
    bdlSpinWeb.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/d/df/Spin_Web_icon.png/65px-Spin_Web_icon.png?version=e5cbc8ec59fd3374e92af3f214632e94"


    bdlSpinWeb.mDuration = New ValueWrapper(-1) '- 1 for permanent
    'bdlSpinWeb.mLevel = New ValueWrapper()

    bdlSpinWeb.mHealth = New ValueWrapper(100)
    'bdlSpinWeb.mHealthIncrement = New ValueWrapper()
    'bdlSpinWeb.mHealthRegen = New ValueWrapper()

    'bdlSpinWeb.mMana = New ValueWrapper()
    'bdlSpinWeb.mManaRegen = New ValueWrapper()

    'bdlSpinWeb.mDamage.Add(New ValueWrapper())
    'bdlSpinWeb.mDamage.Add(New ValueWrapper())

    'bdlSpinWeb.mDamageIncrement = New ValueWrapper()

    'bdlSpinWeb.mMagicResistance = New ValueWrapper()

    'bdlSpinWeb.mArmor = New ValueWrapper()
    'bdlSpinWeb.mArmorType = eArmorType

    bdlSpinWeb.mMoveSpeed = New ValueWrapper(0)
    bdlSpinWeb.mCOllisionSize = New ValueWrapper(0)
    'bdlSpinWeb.mSightrange.Add(New ValueWrapper())
    bdlSpinWeb.mSightrange.Add(New ValueWrapper(0))

    bdlSpinWeb.mAttackType = eAttackType.None
    bdlSpinWeb.mAttackSubType = eAttackSubType.None

    'bdlSpinWeb.mAttackDuration.Add(New ValueWrapper())
    'bdlSpinWeb.mAttackDuration.Add(New ValueWrapper())

    'bdlSpinWeb.mMissileSpeed = New ValueWrapper()
    'bdlSpinWeb.mBaseAttacktime = New ValueWrapper()

    bdlSpinWeb.mBounty.Add(New ValueWrapper(0))
    bdlSpinWeb.mBounty.Add(New ValueWrapper(0))
    bdlSpinWeb.mXp = New ValueWrapper(0)


    'bdlSpinWeb.mAbilityNames.Add(eAbilityName)

    Me.Add(ePetName.untSpin_Web, bdlSpinWeb)

    Dim bdlSpirit As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Death Prophet Spirit
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlSpirit.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Spirit", eEntity.Creepbundle)

    bdlSpirit.mName = ePetName.untSpirit
    bdlSpirit.mUnitType = eUnittype.RegularSummons
    bdlSpirit.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/7/71/Exorcism_icon.png?version=0d39ce6ca47f3748180597d2f6afa0b1"


    bdlSpirit.mDuration = New ValueWrapper(30, 30, 30) '- 1 for permanent
    'bdlBuffer_Building.mLevel = New ValueWrapper()

    bdlSpirit.mHealth = New ValueWrapper(-1, -1, -1) 'invulnerable
    'bdlBuffer_Building.mHealthIncrement = New ValueWrapper()
    'bdlBuffer_Building.mHealthRegen = New ValueWrapper()

    'bdlBuffer_Building.mMana = New ValueWrapper()
    'bdlBuffer_Building.mManaRegen = New ValueWrapper()

    bdlSpirit.mDamage.Add(New ValueWrapper(55, 55, 55))
    bdlSpirit.mDamage.Add(New ValueWrapper(55, 55, 55))

    'bdlBuffer_Building.mDamageIncrement = New ValueWrapper()

    bdlSpirit.mMagicResistance = New ValueWrapper(0)

    'bdlBuffer_Building.mArmor = New ValueWrapper(10)
    'bdlBuffer_Building.mArmorType = eArmorType.Fortified

    bdlSpirit.mMoveSpeed = New ValueWrapper(500, 500, 500)
    bdlSpirit.mCOllisionSize = New ValueWrapper(0)
    bdlSpirit.mSightrange.Add(New ValueWrapper(0))
    bdlSpirit.mSightrange.Add(New ValueWrapper(0))

    bdlSpirit.mAttackType = eAttackType.Melee
    bdlSpirit.mAttackSubType = eAttackSubType.Normal

    'bdlBuffer_Building.mAttackDuration.Add(New ValueWrapper())
    'bdlBuffer_Building.mAttackDuration.Add(New ValueWrapper())

    'bdlBuffer_Building.mMissileSpeed = New ValueWrapper()
    'bdlBuffer_Building.mBaseAttacktime = New ValueWrapper()

    'bdlBuffer_Building.mBounty.Add(New ValueWrapper(102))
    'bdlBuffer_Building.mBounty.Add(New ValueWrapper(120))
    'bdlBuffer_Building.mXp = New ValueWrapper(25)


    'bdlBuffer_Building.mAbilityNames.Add(eAbilityName)

    Me.Add(ePetName.untSpirit, bdlSpirit)
    '--------------------------------------------------------------


    Dim bdlPet_Phantom_Lancer As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Phantom Lancer Pet
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlPet_Phantom_Lancer.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Homming Missile", eEntity.Creepbundle)

    bdlPet_Phantom_Lancer.mName = ePetName.untPet_Phantom_Lancer
    bdlPet_Phantom_Lancer.mUnitType = eUnittype.Illusion
    bdlPet_Phantom_Lancer.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/phantom_lancer_full.png?v=3204889?v=3204889"


    bdlPet_Phantom_Lancer.mDuration = New ValueWrapper(8, 8, 8, 8) '- 1 for permanent
    'bdlBuffer_Building.mLevel = New ValueWrapper()

    'bdlSpirit.mHealth = New ValueWrapper(100, 100, 100, 100) 'invulnerable
    'bdlBuffer_Building.mHealthIncrement = New ValueWrapper()
    'bdlBuffer_Building.mHealthRegen = New ValueWrapper()

    'bdlBuffer_Building.mMana = New ValueWrapper()
    'bdlBuffer_Building.mManaRegen = New ValueWrapper()

    'bdlSpirit.mDamage.Add(New ValueWrapper(50, 50, 50, 50))
    'bdlSpirit.mDamage.Add(New ValueWrapper(125, 250, 375, 500))

    'bdlBuffer_Building.mDamageIncrement = New ValueWrapper()

    bdlPet_Phantom_Lancer.mMagicResistance = New ValueWrapper(0)

    'bdlBuffer_Building.mArmor = New ValueWrapper(0, 0, 0, 0)
    'bdlBuffer_Building.mArmorType = eArmorType.None

    'bdlSpirit.mMoveSpeed = New ValueWrapper(500, 500, 500, 500)
    bdlPet_Phantom_Lancer.mCOllisionSize = New ValueWrapper(0, 0, 0, 0)
    bdlPet_Phantom_Lancer.mSightrange.Add(New ValueWrapper(400, 400, 400, 400))
    bdlPet_Phantom_Lancer.mSightrange.Add(New ValueWrapper(400, 400, 400, 400))

    bdlPet_Phantom_Lancer.mAttackType = eAttackType.Melee
    bdlPet_Phantom_Lancer.mAttackSubType = eAttackSubType.Normal

    'bdlBuffer_Building.mAttackDuration.Add(New ValueWrapper())
    'bdlBuffer_Building.mAttackDuration.Add(New ValueWrapper())

    'bdlBuffer_Building.mMissileSpeed = New ValueWrapper()
    'bdlBuffer_Building.mBaseAttacktime = New ValueWrapper()

    'bdlBuffer_Building.mBounty.Add(New ValueWrapper(20, 20, 20, 20))
    'bdlBuffer_Building.mBounty.Add(New ValueWrapper(30, 30, 30, 30))
    'bdlBuffer_Building.mXp = New ValueWrapper(20, 20, 20, 20)


    'bdlBuffer_Building.mAbilityNames.Add(eAbilityName)

    Me.Add(ePetName.untPet_Phantom_Lancer, bdlPet_Phantom_Lancer)
    '--------------------------------------------------------------


    Dim bdlPet_Meepo_Clone As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Meepo Clone
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlPet_Meepo_Clone.mIDItem = New dvID(Guid.NewGuid, "PetBundle: Meepo Clone", eEntity.Pet_Bundle)

    bdlPet_Meepo_Clone.mName = ePetName.untMeepo_Clone
    bdlPet_Meepo_Clone.mUnitType = eUnittype.Pet
    bdlPet_Meepo_Clone.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/meepo_vert.jpg"


    '    bdlPet_Phantom_Lancer.mDuration = New ValueWrapper(8, 8, 8, 8) '- 1 for permanent
    'bdlBuffer_Building.mLevel = New ValueWrapper()

    'bdlSpirit.mHealth = New ValueWrapper(100, 100, 100, 100) 'invulnerable
    'bdlBuffer_Building.mHealthIncrement = New ValueWrapper()
    'bdlBuffer_Building.mHealthRegen = New ValueWrapper()

    'bdlBuffer_Building.mMana = New ValueWrapper()
    'bdlBuffer_Building.mManaRegen = New ValueWrapper()

    'bdlSpirit.mDamage.Add(New ValueWrapper(50, 50, 50, 50))
    'bdlSpirit.mDamage.Add(New ValueWrapper(125, 250, 375, 500))

    'bdlBuffer_Building.mDamageIncrement = New ValueWrapper()

    ' bdlPet_Phantom_Lancer.mMagicResistance = New ValueWrapper(0)

    'bdlBuffer_Building.mArmor = New ValueWrapper(0, 0, 0, 0)
    'bdlBuffer_Building.mArmorType = eArmorType.None

    'bdlSpirit.mMoveSpeed = New ValueWrapper(500, 500, 500, 500)
    bdlPet_Meepo_Clone.mCOllisionSize = New ValueWrapper(24, 24, 24, 24)
    ' bdlPet_Phantom_Lancer.mSightrange.Add(New ValueWrapper(400, 400, 400, 400))
    ' bdlPet_Phantom_Lancer.mSightrange.Add(New ValueWrapper(400, 400, 400, 400))

    bdlPet_Meepo_Clone.mAttackType = eAttackType.Melee
    bdlPet_Meepo_Clone.mAttackSubType = eAttackSubType.Normal

    'bdlBuffer_Building.mAttackDuration.Add(New ValueWrapper())
    'bdlBuffer_Building.mAttackDuration.Add(New ValueWrapper())

    'bdlBuffer_Building.mMissileSpeed = New ValueWrapper()
    'bdlBuffer_Building.mBaseAttacktime = New ValueWrapper()

    'bdlBuffer_Building.mBounty.Add(New ValueWrapper(20, 20, 20, 20))
    'bdlBuffer_Building.mBounty.Add(New ValueWrapper(30, 30, 30, 30))
    'bdlBuffer_Building.mXp = New ValueWrapper(20, 20, 20, 20)


    'bdlBuffer_Building.mAbilityNames.Add(eAbilityName)

    Me.Add(ePetName.untMeepo_Clone, bdlPet_Meepo_Clone)
    '--------------------------------------------------------------



    Dim bdlPet_DragonKnight_Dragon_Form As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Dragon Knight Dragon Form
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlPet_DragonKnight_Dragon_Form.mIDItem = New dvID(Guid.NewGuid, "PetBundle: DragonKnight Dragon Form", eEntity.Pet_Bundle)

    bdlPet_DragonKnight_Dragon_Form.mName = ePetName.untDragonKnight_Elder_Dragon_Form
    bdlPet_DragonKnight_Dragon_Form.mUnitType = eUnittype.Pet
    bdlPet_DragonKnight_Dragon_Form.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/3/33/Elder_Dragon_Form_icon.png"


    bdlPet_DragonKnight_Dragon_Form.mDuration = New ValueWrapper(60, 60, 60) '- 1 for permanent
    'bdlBuffer_Building.mLevel = New ValueWrapper()

    'bdlSpirit.mHealth = New ValueWrapper(100, 100, 100, 100) 'invulnerable
    'bdlBuffer_Building.mHealthIncrement = New ValueWrapper()
    'bdlBuffer_Building.mHealthRegen = New ValueWrapper()

    'bdlBuffer_Building.mMana = New ValueWrapper()
    'bdlBuffer_Building.mManaRegen = New ValueWrapper()

    'bdlSpirit.mDamage.Add(New ValueWrapper(50, 50, 50, 50))
    'bdlSpirit.mDamage.Add(New ValueWrapper(125, 250, 375, 500))

    'bdlBuffer_Building.mDamageIncrement = New ValueWrapper()

    ' bdlPet_Phantom_Lancer.mMagicResistance = New ValueWrapper(0)

    'bdlBuffer_Building.mArmor = New ValueWrapper(0, 0, 0, 0)
    'bdlBuffer_Building.mArmorType = eArmorType.None

    'bdlSpirit.mMoveSpeed = New ValueWrapper(500, 500, 500, 500)
    bdlPet_DragonKnight_Dragon_Form.mCOllisionSize = New ValueWrapper(24, 24, 24)
    bdlPet_DragonKnight_Dragon_Form.mSightrange.Add(New ValueWrapper(1800, 1800, 1800))
    bdlPet_DragonKnight_Dragon_Form.mSightrange.Add(New ValueWrapper(800, 800, 800))

    bdlPet_DragonKnight_Dragon_Form.mAttackType = eAttackType.Ranged
    bdlPet_DragonKnight_Dragon_Form.mAttackSubType = eAttackSubType.Normal

    'bdlBuffer_Building.mAttackDuration.Add(New ValueWrapper())
    'bdlBuffer_Building.mAttackDuration.Add(New ValueWrapper())

    'bdlBuffer_Building.mMissileSpeed = New ValueWrapper()
    'bdlBuffer_Building.mBaseAttacktime = New ValueWrapper()

    'bdlBuffer_Building.mBounty.Add(New ValueWrapper(20, 20, 20, 20))
    'bdlBuffer_Building.mBounty.Add(New ValueWrapper(30, 30, 30, 30))
    'bdlBuffer_Building.mXp = New ValueWrapper(20, 20, 20, 20)


    'bdlBuffer_Building.mAbilityNames.Add(eAbilityName)

    Me.Add(ePetName.untDragonKnight_Elder_Dragon_Form, bdlPet_DragonKnight_Dragon_Form)
    '--------------------------------------------------------------



    Dim bdlMorphling_Replicant As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Morphling Replicant
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlMorphling_Replicant.mIDItem = New dvID(Guid.NewGuid, "PetBundle: Morphling Replicant", eEntity.Pet_Bundle)

    bdlMorphling_Replicant.mName = ePetName.untMorphling_Replicant
    bdlMorphling_Replicant.mUnitType = eUnittype.Pet
    bdlMorphling_Replicant.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/abilities/morphling_hybrid_hp2.png?v=3196642"


    bdlMorphling_Replicant.mDuration = New ValueWrapper(30, 45, 60) '- 1 for permanent
    'bdlBuffer_Building.mLevel = New ValueWrapper()

    'bdlSpirit.mHealth = New ValueWrapper(100, 100, 100, 100) 'invulnerable
    'bdlBuffer_Building.mHealthIncrement = New ValueWrapper()
    'bdlBuffer_Building.mHealthRegen = New ValueWrapper()

    'bdlBuffer_Building.mMana = New ValueWrapper()
    'bdlBuffer_Building.mManaRegen = New ValueWrapper()

    'bdlSpirit.mDamage.Add(New ValueWrapper(50, 50, 50, 50))
    'bdlSpirit.mDamage.Add(New ValueWrapper(125, 250, 375, 500))

    'bdlBuffer_Building.mDamageIncrement = New ValueWrapper()

    ' bdlPet_Phantom_Lancer.mMagicResistance = New ValueWrapper(0)

    'bdlBuffer_Building.mArmor = New ValueWrapper(0, 0, 0, 0)
    'bdlBuffer_Building.mArmorType = eArmorType.None

    'bdlSpirit.mMoveSpeed = New ValueWrapper(500, 500, 500, 500)
    ' bdlPet_DragonKnight_Dragon_Form.mCOllisionSize = New ValueWrapper(24, 24, 24)
    ' bdlPet_DragonKnight_Dragon_Form.mSightrange.Add(New ValueWrapper(1800, 1800, 1800))
    ' bdlPet_DragonKnight_Dragon_Form.mSightrange.Add(New ValueWrapper(800, 800, 800))

    '  bdlPet_DragonKnight_Dragon_Form.mAttackType = eAttackType.Ranged
    ' bdlPet_DragonKnight_Dragon_Form.mAttackSubType = eAttackSubType.Normal

    'bdlBuffer_Building.mAttackDuration.Add(New ValueWrapper())
    'bdlBuffer_Building.mAttackDuration.Add(New ValueWrapper())

    'bdlBuffer_Building.mMissileSpeed = New ValueWrapper()
    'bdlBuffer_Building.mBaseAttacktime = New ValueWrapper()

    'bdlBuffer_Building.mBounty.Add(New ValueWrapper(20, 20, 20, 20))
    'bdlBuffer_Building.mBounty.Add(New ValueWrapper(30, 30, 30, 30))
    'bdlBuffer_Building.mXp = New ValueWrapper(20, 20, 20, 20)


    'bdlBuffer_Building.mAbilityNames.Add(eAbilityName)

    Me.Add(ePetName.untMorphling_Replicant, bdlMorphling_Replicant)
    '--------------------------------------------------------------


    





    Dim bdlNaga_Siren_Illusion As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Lone Druid Spirit Bear
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlNaga_Siren_Illusion.mIDItem = New dvID(Guid.NewGuid, "PetBundle: Naga Siren Illusion", eEntity.Pet_Bundle)

    bdlNaga_Siren_Illusion.mName = ePetName.untNaga_Siren_Illusion
    bdlNaga_Siren_Illusion.mUnitType = eUnittype.Pet
    bdlNaga_Siren_Illusion.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/abilities/naga_siren_mirror_image_hp2.png?v=3196642"


    bdlNaga_Siren_Illusion.mDuration = New ValueWrapper(30, 30, 30, 30) '- 1 for permanent
    'bdlBuffer_Building.mLevel = New ValueWrapper()

    ' bdlLone_Druid_Spirit_Bear.mHealth = New ValueWrapper(1400, 1800, 2300, 2700) 'invulnerable
    'bdlBuffer_Building.mHealthIncrement = New ValueWrapper()
    ' bdlLone_Druid_Spirit_Bear.mHealthRegen = New ValueWrapper(2, 3, 4, 5)

    'bdlBuffer_Building.mMana = New ValueWrapper()
    'bdlBuffer_Building.mManaRegen = New ValueWrapper()

    'bdlSpirit.mDamage.Add(New ValueWrapper(50, 50, 50, 50))
    'bdlSpirit.mDamage.Add(New ValueWrapper(125, 250, 375, 500))

    'bdlBuffer_Building.mDamageIncrement = New ValueWrapper()

    ' bdlPet_Phantom_Lancer.mMagicResistance = New ValueWrapper(0)

    'bdlLone_Druid_Spirit_Bear.mArmor = New ValueWrapper(3, 4, 5, 6)
    'bdlBuffer_Building.mArmorType = eArmorType.None

    'bdlSpirit.mMoveSpeed = New ValueWrapper(500, 500, 500, 500)
    ' bdlPet_DragonKnight_Dragon_Form.mCOllisionSize = New ValueWrapper(24, 24, 24)
    ' bdlPet_DragonKnight_Dragon_Form.mSightrange.Add(New ValueWrapper(1800, 1800, 1800))
    ' bdlPet_DragonKnight_Dragon_Form.mSightrange.Add(New ValueWrapper(800, 800, 800))

    '  bdlPet_DragonKnight_Dragon_Form.mAttackType = eAttackType.Ranged
    ' bdlPet_DragonKnight_Dragon_Form.mAttackSubType = eAttackSubType.Normal

    'bdlBuffer_Building.mAttackDuration.Add(New ValueWrapper())
    'bdlBuffer_Building.mAttackDuration.Add(New ValueWrapper())

    'bdlBuffer_Building.mMissileSpeed = New ValueWrapper()
    '  bdlLone_Druid_Spirit_Bear.mBaseAttacktime = New ValueWrapper(1.75, 1.65, 1.55, 1.45)

    'bdlBuffer_Building.mBounty.Add(New ValueWrapper(20, 20, 20, 20))
    'bdlBuffer_Building.mBounty.Add(New ValueWrapper(30, 30, 30, 30))
    'bdlBuffer_Building.mXp = New ValueWrapper(20, 20, 20, 20)


    'bdlBuffer_Building.mAbilityNames.Add(eAbilityName)

    Me.Add(ePetName.untNaga_Siren_Illusion, bdlNaga_Siren_Illusion)
    '--------------------------------------------------------------


    Dim bdlTerrorblade_Reflection As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Terrorblade reflection
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlTerrorblade_Reflection.mIDItem = New dvID(Guid.NewGuid, "PetBundle: Terrorblade Reflection", eEntity.Pet_Bundle)

    bdlTerrorblade_Reflection.mName = ePetName.untTerrorblade_Reflection
    bdlTerrorblade_Reflection.mUnitType = eUnittype.Pet
    bdlTerrorblade_Reflection.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/abilities/terrorblade_reflection_hp2.png?v=3196642"


    bdlTerrorblade_Reflection.mDuration = New ValueWrapper(2.5, 3.5, 4.5, 5.5) '- 1 for permanent
    'bdlBuffer_Building.mLevel = New ValueWrapper()

    ' bdlLone_Druid_Spirit_Bear.mHealth = New ValueWrapper(1400, 1800, 2300, 2700) 'invulnerable
    'bdlBuffer_Building.mHealthIncrement = New ValueWrapper()
    ' bdlLone_Druid_Spirit_Bear.mHealthRegen = New ValueWrapper(2, 3, 4, 5)

    'bdlBuffer_Building.mMana = New ValueWrapper()
    'bdlBuffer_Building.mManaRegen = New ValueWrapper()

    'bdlSpirit.mDamage.Add(New ValueWrapper(50, 50, 50, 50))
    'bdlSpirit.mDamage.Add(New ValueWrapper(125, 250, 375, 500))

    'bdlBuffer_Building.mDamageIncrement = New ValueWrapper()

    ' bdlPet_Phantom_Lancer.mMagicResistance = New ValueWrapper(0)

    'bdlLone_Druid_Spirit_Bear.mArmor = New ValueWrapper(3, 4, 5, 6)
    'bdlBuffer_Building.mArmorType = eArmorType.None

    'bdlSpirit.mMoveSpeed = New ValueWrapper(500, 500, 500, 500)
    ' bdlPet_DragonKnight_Dragon_Form.mCOllisionSize = New ValueWrapper(24, 24, 24)
    ' bdlPet_DragonKnight_Dragon_Form.mSightrange.Add(New ValueWrapper(1800, 1800, 1800))
    ' bdlPet_DragonKnight_Dragon_Form.mSightrange.Add(New ValueWrapper(800, 800, 800))

    '  bdlPet_DragonKnight_Dragon_Form.mAttackType = eAttackType.Ranged
    ' bdlPet_DragonKnight_Dragon_Form.mAttackSubType = eAttackSubType.Normal

    'bdlBuffer_Building.mAttackDuration.Add(New ValueWrapper())
    'bdlBuffer_Building.mAttackDuration.Add(New ValueWrapper())

    'bdlBuffer_Building.mMissileSpeed = New ValueWrapper()
    '  bdlLone_Druid_Spirit_Bear.mBaseAttacktime = New ValueWrapper(1.75, 1.65, 1.55, 1.45)

    'bdlBuffer_Building.mBounty.Add(New ValueWrapper(20, 20, 20, 20))
    'bdlBuffer_Building.mBounty.Add(New ValueWrapper(30, 30, 30, 30))
    'bdlBuffer_Building.mXp = New ValueWrapper(20, 20, 20, 20)


    'bdlBuffer_Building.mAbilityNames.Add(eAbilityName)

    Me.Add(ePetName.untTerrorblade_Reflection, bdlTerrorblade_Reflection)
    '--------------------------------------------------------------


    Dim bdlTerrorblade_Illusion As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Terrorblade Illusion
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlTerrorblade_Illusion.mIDItem = New dvID(Guid.NewGuid, "PetBundle: Terrorblade Illusion", eEntity.Pet_Bundle)

    bdlTerrorblade_Illusion.mName = ePetName.untTerrorblade_Illusion
    bdlTerrorblade_Illusion.mUnitType = eUnittype.Pet
    bdlTerrorblade_Illusion.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/abilities/terrorblade_conjure_image_hp2.png?v=3196642"


    bdlTerrorblade_Illusion.mDuration = New ValueWrapper(32, 32, 32, 32) '- 1 for permanent
    'bdlBuffer_Building.mLevel = New ValueWrapper()

    ' bdlLone_Druid_Spirit_Bear.mHealth = New ValueWrapper(1400, 1800, 2300, 2700) 'invulnerable
    'bdlBuffer_Building.mHealthIncrement = New ValueWrapper()
    ' bdlLone_Druid_Spirit_Bear.mHealthRegen = New ValueWrapper(2, 3, 4, 5)

    'bdlBuffer_Building.mMana = New ValueWrapper()
    'bdlBuffer_Building.mManaRegen = New ValueWrapper()

    'bdlSpirit.mDamage.Add(New ValueWrapper(50, 50, 50, 50))
    'bdlSpirit.mDamage.Add(New ValueWrapper(125, 250, 375, 500))

    'bdlBuffer_Building.mDamageIncrement = New ValueWrapper()

    ' bdlPet_Phantom_Lancer.mMagicResistance = New ValueWrapper(0)

    'bdlLone_Druid_Spirit_Bear.mArmor = New ValueWrapper(3, 4, 5, 6)
    'bdlBuffer_Building.mArmorType = eArmorType.None

    'bdlSpirit.mMoveSpeed = New ValueWrapper(500, 500, 500, 500)
    ' bdlPet_DragonKnight_Dragon_Form.mCOllisionSize = New ValueWrapper(24, 24, 24)
    ' bdlPet_DragonKnight_Dragon_Form.mSightrange.Add(New ValueWrapper(1800, 1800, 1800))
    ' bdlPet_DragonKnight_Dragon_Form.mSightrange.Add(New ValueWrapper(800, 800, 800))

    '  bdlPet_DragonKnight_Dragon_Form.mAttackType = eAttackType.Ranged
    ' bdlPet_DragonKnight_Dragon_Form.mAttackSubType = eAttackSubType.Normal

    'bdlBuffer_Building.mAttackDuration.Add(New ValueWrapper())
    'bdlBuffer_Building.mAttackDuration.Add(New ValueWrapper())

    'bdlBuffer_Building.mMissileSpeed = New ValueWrapper()
    '  bdlLone_Druid_Spirit_Bear.mBaseAttacktime = New ValueWrapper(1.75, 1.65, 1.55, 1.45)

    'bdlBuffer_Building.mBounty.Add(New ValueWrapper(20, 20, 20, 20))
    'bdlBuffer_Building.mBounty.Add(New ValueWrapper(30, 30, 30, 30))
    'bdlBuffer_Building.mXp = New ValueWrapper(20, 20, 20, 20)


    'bdlBuffer_Building.mAbilityNames.Add(eAbilityName)

    Me.Add(ePetName.untTerrorblade_Illusion, bdlTerrorblade_Illusion)
    '--------------------------------------------------------------


    Dim bdlTerrorblade_Demon As New PetBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Terrorblade Demon
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlTerrorblade_Demon.mIDItem = New dvID(Guid.NewGuid, "PetBundle: Terrorblade Illusion", eEntity.Pet_Bundle)

    bdlTerrorblade_Demon.mName = ePetName.untTerrorblade_Demon
    bdlTerrorblade_Demon.mUnitType = eUnittype.Pet
    bdlTerrorblade_Demon.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/abilities/terrorblade_metamorphosis_hp2.png?v=3196642"


    bdlTerrorblade_Demon.mDuration = New ValueWrapper(40, 44, 48, 52) '- 1 for permanent
    'bdlBuffer_Building.mLevel = New ValueWrapper()

    ' bdlLone_Druid_Spirit_Bear.mHealth = New ValueWrapper(1400, 1800, 2300, 2700) 'invulnerable
    'bdlBuffer_Building.mHealthIncrement = New ValueWrapper()
    ' bdlLone_Druid_Spirit_Bear.mHealthRegen = New ValueWrapper(2, 3, 4, 5)

    'bdlBuffer_Building.mMana = New ValueWrapper()
    'bdlBuffer_Building.mManaRegen = New ValueWrapper()

    'bdlSpirit.mDamage.Add(New ValueWrapper(50, 50, 50, 50))
    'bdlSpirit.mDamage.Add(New ValueWrapper(125, 250, 375, 500))

    'bdlBuffer_Building.mDamageIncrement = New ValueWrapper()

    ' bdlPet_Phantom_Lancer.mMagicResistance = New ValueWrapper(0)

    'bdlLone_Druid_Spirit_Bear.mArmor = New ValueWrapper(3, 4, 5, 6)
    'bdlBuffer_Building.mArmorType = eArmorType.None

    'bdlSpirit.mMoveSpeed = New ValueWrapper(500, 500, 500, 500)
    ' bdlPet_DragonKnight_Dragon_Form.mCOllisionSize = New ValueWrapper(24, 24, 24)
    ' bdlPet_DragonKnight_Dragon_Form.mSightrange.Add(New ValueWrapper(1800, 1800, 1800))
    ' bdlPet_DragonKnight_Dragon_Form.mSightrange.Add(New ValueWrapper(800, 800, 800))

    '  bdlPet_DragonKnight_Dragon_Form.mAttackType = eAttackType.Ranged
    ' bdlPet_DragonKnight_Dragon_Form.mAttackSubType = eAttackSubType.Normal

    'bdlBuffer_Building.mAttackDuration.Add(New ValueWrapper())
    'bdlBuffer_Building.mAttackDuration.Add(New ValueWrapper())

    'bdlBuffer_Building.mMissileSpeed = New ValueWrapper()
    '  bdlLone_Druid_Spirit_Bear.mBaseAttacktime = New ValueWrapper(1.75, 1.65, 1.55, 1.45)

    'bdlBuffer_Building.mBounty.Add(New ValueWrapper(20, 20, 20, 20))
    'bdlBuffer_Building.mBounty.Add(New ValueWrapper(30, 30, 30, 30))
    'bdlBuffer_Building.mXp = New ValueWrapper(20, 20, 20, 20)


    'bdlBuffer_Building.mAbilityNames.Add(eAbilityName)

    Me.Add(ePetName.untTerrorblade_Demon, bdlTerrorblade_Demon)
    '--------------------------------------------------------------
  End Sub
End Class
