Public Class CreepBundles
  Inherits Dictionary(Of eCreepName, CreepBundle)

  Public Sub New()





   



    Dim bdlSkeleton_Warrior As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Skeleton Warrior
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlSkeleton_Warrior.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Skeleton Warrior", eEntity.Creepbundle)

    bdlSkeleton_Warrior.mName = eCreepName.untSkeleton_Warrior
    bdlSkeleton_Warrior.mUnitType = eUnittype.RegularSummons
    bdlSkeleton_Warrior.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/5/54/Troll%27s_Skeleton_Warrior_Icon.jpeg/200px-Troll%27s_Skeleton_Warrior_Icon.jpeg.png?version=57bb35b8372927d5c93d14c3127f4701"


    bdlSkeleton_Warrior.mDuration = New ValueWrapper(40) '- 1 for permanent
    'bdlSkeleton_Warrior.mLevel = New ValueWrapper()

    bdlSkeleton_Warrior.mHealth = New ValueWrapper(250)
    'bdlSkeleton_Warrior.mHealthIncrement = New ValueWrapper()
    bdlSkeleton_Warrior.mHealthRegen = New ValueWrapper(0)

    'bdlSkeleton_Warrior.mMana = New ValueWrapper()
    'bdlSkeleton_Warrior.mManaRegen = New ValueWrapper()

    bdlSkeleton_Warrior.mDamage.Add(New ValueWrapper(24))
    bdlSkeleton_Warrior.mDamage.Add(New ValueWrapper(25))

    'bdlSkeleton_Warrior.mDamageIncrement = New ValueWrapper()

    'bdlSkeleton_Warrior.mMagicResistance = New ValueWrapper()

    bdlSkeleton_Warrior.mArmor = New ValueWrapper(1)
    bdlSkeleton_Warrior.mArmorType = eArmorType.Heavy

    bdlSkeleton_Warrior.mMoveSpeed = New ValueWrapper(270)
    bdlSkeleton_Warrior.mCOllisionSize = New ValueWrapper(16)
    bdlSkeleton_Warrior.mSightrange.Add(New ValueWrapper(800))
    bdlSkeleton_Warrior.mSightrange.Add(New ValueWrapper(600))

    bdlSkeleton_Warrior.mAttackType = eAttackType.Melee
    bdlSkeleton_Warrior.mAttackSubType = eAttackSubType.Normal

    bdlSkeleton_Warrior.mAttackDuration.Add(New ValueWrapper(0.56))
    bdlSkeleton_Warrior.mAttackDuration.Add(New ValueWrapper(0.44))

    'bdlSkeleton_Warrior.mMissileSpeed = New ValueWrapper()
    bdlSkeleton_Warrior.mBaseAttacktime = New ValueWrapper(1)

    bdlSkeleton_Warrior.mBounty.Add(New ValueWrapper(6))
    bdlSkeleton_Warrior.mBounty.Add(New ValueWrapper(12))
    bdlSkeleton_Warrior.mXp = New ValueWrapper(12)


    'bdlSkeleton_Warrior.mAbilityNames.Add(eAbilityName)

    Me.Add(eCreepName.untSkeleton_Warrior, bdlSkeleton_Warrior)
    '--------------------------------------------------------------



    Dim bdlNecro_Warrior As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Necro Warrior
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlNecro_Warrior.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Necro Warrior", eEntity.Creepbundle)

    bdlNecro_Warrior.mName = eCreepName.untNecro_Warrior
    bdlNecro_Warrior.mUnitType = eUnittype.RegularSummons
    bdlNecro_Warrior.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/c/c4/Necronomicon_warrior.png/200px-Necronomicon_warrior.png?version=a0539bcb71127eb0f99024c7d5d78a41"


    bdlNecro_Warrior.mDuration = New ValueWrapper(40, 40, 40) '- 1 for permanent
    'bdlNecro_Warrior.mLevel = New ValueWrapper()

    bdlNecro_Warrior.mHealth = New ValueWrapper(400, 600, 800)
    'bdlNecro_Warrior.mHealthIncrement = New ValueWrapper()
    bdlNecro_Warrior.mHealthRegen = New ValueWrapper(5, 5, 5)

    'bdlNecro_Warrior.mMana = New ValueWrapper()
    'bdlNecro_Warrior.mManaRegen = New ValueWrapper()

    bdlNecro_Warrior.mDamage.Add(New ValueWrapper(25, 50, 75))
    bdlNecro_Warrior.mDamage.Add(New ValueWrapper(25, 50, 75))

    'bdlNecro_Warrior.mDamageIncrement = New ValueWrapper()

    bdlNecro_Warrior.mMagicResistance = New ValueWrapper(0.4, 0.4, 0.4)

    bdlNecro_Warrior.mArmor = New ValueWrapper(4, 4, 4)
    bdlNecro_Warrior.mArmorType = eArmorType.Hero

    bdlNecro_Warrior.mMoveSpeed = New ValueWrapper(350, 350, 350)
    bdlNecro_Warrior.mCOllisionSize = New ValueWrapper(16, 16, 16)
    bdlNecro_Warrior.mSightrange.Add(New ValueWrapper(1300, 1400, 1500))
    bdlNecro_Warrior.mSightrange.Add(New ValueWrapper(800, 800, 800))

    bdlNecro_Warrior.mAttackType = eAttackType.Melee
    bdlNecro_Warrior.mAttackSubType = eAttackSubType.Normal

    bdlNecro_Warrior.mAttackDuration.Add(New ValueWrapper(0.56, 0.56, 0.56))
    bdlNecro_Warrior.mAttackDuration.Add(New ValueWrapper(0.44, 0.44, 0.44))

    bdlNecro_Warrior.mCastDuration = New List(Of ValueWrapper)
    bdlNecro_Warrior.mCastDuration.Add(New ValueWrapper(0.5, 0.5, 0.5))
    bdlNecro_Warrior.mCastDuration.Add(New ValueWrapper(0.51, 0.51, 0.51))

    'bdlNecro_Warrior.mMissileSpeed = New ValueWrapper()
    bdlNecro_Warrior.mBaseAttacktime = New ValueWrapper(0.75, 0.75, 0.75)

    bdlNecro_Warrior.mBounty.Add(New ValueWrapper(100, 150, 200))
    bdlNecro_Warrior.mBounty.Add(New ValueWrapper(100, 150, 200))
    bdlNecro_Warrior.mXp = New ValueWrapper(100, 150, 200)


    bdlNecro_Warrior.mAbilityNames.Add(eAbilityName.abNecro_Warrior_Mana_Break)
    bdlNecro_Warrior.mAbilityNames.Add(eAbilityName.abNecro_Warrior_Last_Will)
    bdlNecro_Warrior.mAbilityNames.Add(eAbilityName.abNecro_Warrior_True_Sight)

    Me.Add(eCreepName.untNecro_Warrior, bdlNecro_Warrior)
    '--------------------------------------------------------------



    Dim bdlNecro_Archer As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Necro Archer
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlNecro_Archer.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Necro Archer", eEntity.Creepbundle)

    bdlNecro_Archer.mName = eCreepName.untNecro_Archer
    bdlNecro_Archer.mUnitType = eUnittype.RegularSummons
    bdlNecro_Archer.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/c/c8/Necronomicon_archer.png/200px-Necronomicon_archer.png?version=f29ec574248a23b79c2a47e5b75baeb2"


    bdlNecro_Archer.mDuration = New ValueWrapper(40) '- 1 for permanent
    'bdlNecro_Archer.mLevel = New ValueWrapper()

    bdlNecro_Archer.mHealth = New ValueWrapper(400, 600, 800)
    'bdlNecro_Archer.mHealthIncrement = New ValueWrapper()
    bdlNecro_Archer.mHealthRegen = New ValueWrapper(5)

    'bdlNecro_Archer.mMana = New ValueWrapper()
    'bdlNecro_Archer.mManaRegen = New ValueWrapper()

    bdlNecro_Archer.mDamage.Add(New ValueWrapper(40, 80, 120))
    bdlNecro_Archer.mDamage.Add(New ValueWrapper(40, 80, 120))

    'bdlNecro_Archer.mDamageIncrement = New ValueWrapper()

    bdlNecro_Archer.mMagicResistance = New ValueWrapper(0.4, 0.4, 0.4)

    bdlNecro_Archer.mArmor = New ValueWrapper(4, 4, 4)
    bdlNecro_Archer.mArmorType = eArmorType.Hero

    bdlNecro_Archer.mMoveSpeed = New ValueWrapper(330, 360, 390)
    bdlNecro_Archer.mCOllisionSize = New ValueWrapper(16, 16, 16)
    bdlNecro_Archer.mSightrange.Add(New ValueWrapper(1300, 1400, 1500))
    bdlNecro_Archer.mSightrange.Add(New ValueWrapper(800, 800, 800))

    bdlNecro_Archer.mAttackRange = New ValueWrapper(350, 450, 550)
    bdlNecro_Archer.mAttackType = eAttackType.Ranged
    bdlNecro_Archer.mAttackSubType = eAttackSubType.Piercing

    bdlNecro_Archer.mAttackDuration.Add(New ValueWrapper(0.7))
    bdlNecro_Archer.mAttackDuration.Add(New ValueWrapper(0.3))

    bdlNecro_Archer.mMissileSpeed = New ValueWrapper(900)
    bdlNecro_Archer.mBaseAttacktime = New ValueWrapper(1)

    bdlNecro_Archer.mBounty.Add(New ValueWrapper(100, 150, 200))
    bdlNecro_Archer.mBounty.Add(New ValueWrapper(100, 150, 200))
    bdlNecro_Archer.mXp = New ValueWrapper(100, 150, 200)


    bdlNecro_Archer.mAbilityNames.Add(eAbilityName.abNecro_Archer_Mana_Burn)
    bdlNecro_Archer.mAbilityNames.Add(eAbilityName.abNecro_Archer_Archer_Aura)

    Me.Add(eCreepName.untNecro_Archer, bdlNecro_Archer)
    '--------------------------------------------------------------



  


  






    Dim bdlMelee_Creep As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Melee Creep
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlMelee_Creep.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Melee Creep", eEntity.Creepbundle)

    bdlMelee_Creep.mName = eCreepName.untMelee_Creep
    bdlMelee_Creep.mUnitType = eUnittype.LaneCreep
    bdlMelee_Creep.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/d/db/Melee_creeps.png/130px-Melee_creeps.png?version=26f8aeb0f07819069c8fc3eed7e17250"


    bdlMelee_Creep.mDuration = New ValueWrapper(-1) '- 1 for permanent
    'bdlMelee_Creep.mLevel = New ValueWrapper()

    bdlMelee_Creep.mHealth = New ValueWrapper(550)
    bdlMelee_Creep.mHealthIncrement = New ValueWrapper(10)
    bdlMelee_Creep.mHealthRegen = New ValueWrapper(0.5)

    bdlMelee_Creep.mMana = New ValueWrapper(0)
    bdlMelee_Creep.mManaRegen = New ValueWrapper(0)

    bdlMelee_Creep.mDamage.Add(New ValueWrapper(19))
    bdlMelee_Creep.mDamage.Add(New ValueWrapper(23))

    bdlMelee_Creep.mDamageIncrement = New ValueWrapper(1)

    bdlMelee_Creep.mMagicResistance = New ValueWrapper(0)

    bdlMelee_Creep.mArmor = New ValueWrapper(2)
    bdlMelee_Creep.mArmorType = eArmorType.Unarmored

    bdlMelee_Creep.mMoveSpeed = New ValueWrapper(325)
    bdlMelee_Creep.mCOllisionSize = New ValueWrapper(16)
    bdlMelee_Creep.mSightrange.Add(New ValueWrapper(850))
    bdlMelee_Creep.mSightrange.Add(New ValueWrapper(800))

    bdlMelee_Creep.mAttackType = eAttackType.Melee
    bdlMelee_Creep.mAttackSubType = eAttackSubType.Normal

    'bdlMelee_Creep.mAttackDuration.Add(New ValueWrapper())
    'bdlMelee_Creep.mAttackDuration.Add(New ValueWrapper())

    'bdlMelee_Creep.mMissileSpeed = New ValueWrapper()
    bdlMelee_Creep.mBaseAttacktime = New ValueWrapper(1)

    bdlMelee_Creep.mBounty.Add(New ValueWrapper(38))
    bdlMelee_Creep.mBounty.Add(New ValueWrapper(48))
    bdlMelee_Creep.mXp = New ValueWrapper(62)


    'bdlMelee_Creep.mAbilityNames.Add(eAbilityName.)

    Me.Add(eCreepName.untMelee_Creep, bdlMelee_Creep)
    '--------------------------------------------------------------



    Dim bdlSuper_Melee_Creep As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Super Melee Creep
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlSuper_Melee_Creep.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Super Melee Creep", eEntity.Creepbundle)

    bdlSuper_Melee_Creep.mName = eCreepName.untSuper_Melee_Creep
    bdlSuper_Melee_Creep.mUnitType = eUnittype.LaneCreep
    bdlSuper_Melee_Creep.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/d/db/Melee_creeps.png/130px-Melee_creeps.png?version=26f8aeb0f07819069c8fc3eed7e17250"


    bdlSuper_Melee_Creep.mDuration = New ValueWrapper(-1) '- 1 for permanent
    'bdlSuper_Melee_Creep.mLevel = New ValueWrapper()

    bdlSuper_Melee_Creep.mHealth = New ValueWrapper(700)
    bdlSuper_Melee_Creep.mHealthIncrement = New ValueWrapper(19)
    bdlSuper_Melee_Creep.mHealthRegen = New ValueWrapper(0.5)

    'bdlSuper_Melee_Creep.mMana = New ValueWrapper()
    'bdlSuper_Melee_Creep.mManaRegen = New ValueWrapper()

    bdlSuper_Melee_Creep.mDamage.Add(New ValueWrapper(19))
    bdlSuper_Melee_Creep.mDamage.Add(New ValueWrapper(23))

    bdlSuper_Melee_Creep.mDamageIncrement = New ValueWrapper(2)

    bdlSuper_Melee_Creep.mMagicResistance = New ValueWrapper(0)

    bdlSuper_Melee_Creep.mArmor = New ValueWrapper(3)
    bdlSuper_Melee_Creep.mArmorType = eArmorType.Unarmored

    bdlSuper_Melee_Creep.mMoveSpeed = New ValueWrapper(325)
    bdlSuper_Melee_Creep.mCOllisionSize = New ValueWrapper(16)
    bdlSuper_Melee_Creep.mSightrange.Add(New ValueWrapper(850))
    bdlSuper_Melee_Creep.mSightrange.Add(New ValueWrapper(800))

    bdlSuper_Melee_Creep.mAttackType = eAttackType.Melee
    bdlSuper_Melee_Creep.mAttackSubType = eAttackSubType.None

    'bdlSuper_Melee_Creep.mAttackDuration.Add(New ValueWrapper())
    'bdlSuper_Melee_Creep.mAttackDuration.Add(New ValueWrapper())

    'bdlSuper_Melee_Creep.mMissileSpeed = New ValueWrapper()
    bdlSuper_Melee_Creep.mBaseAttacktime = New ValueWrapper(1)

    bdlSuper_Melee_Creep.mBounty.Add(New ValueWrapper(18))
    bdlSuper_Melee_Creep.mBounty.Add(New ValueWrapper(26))
    bdlSuper_Melee_Creep.mXp = New ValueWrapper(25)


    'bdlSuper_Melee_Creep.mAbilityNames.Add(eAbilityName)

    Me.Add(eCreepName.untSuper_Melee_Creep, bdlSuper_Melee_Creep)
    '--------------------------------------------------------------



    Dim bdlMega_Melee_Creep As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Mega Melee Creep
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlMega_Melee_Creep.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Mega Melee Creep", eEntity.Creepbundle)

    bdlMega_Melee_Creep.mName = eCreepName.untMega_Melee_Creep
    bdlMega_Melee_Creep.mUnitType = eUnittype.LaneCreep
    bdlMega_Melee_Creep.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/5/5f/Mega_Melee_creeps.png/130px-Mega_Melee_creeps.png?version=0016791e0d4f58fa955b3f1f90958673"


    bdlMega_Melee_Creep.mDuration = New ValueWrapper(-1) '- 1 for permanent
    'bdlMega_Melee_Creep.mLevel = New ValueWrapper()

    bdlMega_Melee_Creep.mHealth = New ValueWrapper(1270)
    bdlMega_Melee_Creep.mHealthIncrement = New ValueWrapper(0)
    bdlMega_Melee_Creep.mHealthRegen = New ValueWrapper(0.5)

    'bdlMega_Melee_Creep.mMana = New ValueWrapper()
    'bdlMega_Melee_Creep.mManaRegen = New ValueWrapper()

    bdlMega_Melee_Creep.mDamage.Add(New ValueWrapper(96))
    bdlMega_Melee_Creep.mDamage.Add(New ValueWrapper(104))

    bdlMega_Melee_Creep.mDamageIncrement = New ValueWrapper(0)

    bdlMega_Melee_Creep.mMagicResistance = New ValueWrapper(0)

    bdlMega_Melee_Creep.mArmor = New ValueWrapper(3)
    bdlMega_Melee_Creep.mArmorType = eArmorType.Unarmored

    bdlMega_Melee_Creep.mMoveSpeed = New ValueWrapper(325)
    bdlMega_Melee_Creep.mCOllisionSize = New ValueWrapper(16)
    bdlMega_Melee_Creep.mSightrange.Add(New ValueWrapper(850))
    bdlMega_Melee_Creep.mSightrange.Add(New ValueWrapper(800))

    bdlMega_Melee_Creep.mAttackType = eAttackType.Melee
    bdlMega_Melee_Creep.mAttackSubType = eAttackSubType.None

    'bdlMega_Melee_Creep.mAttackDuration.Add(New ValueWrapper())
    'bdlMega_Melee_Creep.mAttackDuration.Add(New ValueWrapper())

    'bdlMega_Melee_Creep.mMissileSpeed = New ValueWrapper()
    bdlMega_Melee_Creep.mBaseAttacktime = New ValueWrapper(1)

    bdlMega_Melee_Creep.mBounty.Add(New ValueWrapper(18))
    bdlMega_Melee_Creep.mBounty.Add(New ValueWrapper(26))
    bdlMega_Melee_Creep.mXp = New ValueWrapper(25)


    'bdlMega_Melee_Creep.mAbilityNames.Add(eAbilityName.)

    Me.Add(eCreepName.untMega_Melee_Creep, bdlMega_Melee_Creep)
    '--------------------------------------------------------------



    Dim bdlRanged_Creep As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Ranged Creep
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlRanged_Creep.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Ranged Creep", eEntity.Creepbundle)

    bdlRanged_Creep.mName = eCreepName.untRanged_Creep
    bdlRanged_Creep.mUnitType = eUnittype.LaneCreep
    bdlRanged_Creep.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/c/c2/Ranged_creeps.png/130px-Ranged_creeps.png?version=6a259f85c755ad96995246fc9e0c2a5a"


    bdlRanged_Creep.mDuration = New ValueWrapper(-1) '- 1 for permanent
    'bdlRanged_Creep.mLevel = New ValueWrapper()

    bdlRanged_Creep.mHealth = New ValueWrapper(1270)
    bdlRanged_Creep.mHealthIncrement = New ValueWrapper(10)
    bdlRanged_Creep.mHealthRegen = New ValueWrapper(0.5)

    bdlRanged_Creep.mMana = New ValueWrapper(500)
    bdlRanged_Creep.mManaRegen = New ValueWrapper(0.75)

    bdlRanged_Creep.mDamage.Add(New ValueWrapper(96))
    bdlRanged_Creep.mDamage.Add(New ValueWrapper(104))

    bdlRanged_Creep.mDamageIncrement = New ValueWrapper(0)

    bdlRanged_Creep.mMagicResistance = New ValueWrapper(0)

    bdlRanged_Creep.mArmor = New ValueWrapper(3)
    bdlRanged_Creep.mArmorType = eArmorType.Unarmored

    bdlRanged_Creep.mMoveSpeed = New ValueWrapper(325)
    bdlRanged_Creep.mCOllisionSize = New ValueWrapper(16)
    bdlRanged_Creep.mSightrange.Add(New ValueWrapper(850))
    bdlRanged_Creep.mSightrange.Add(New ValueWrapper(800))

    bdlRanged_Creep.mAttackType = eAttackType.Ranged
    bdlRanged_Creep.mAttackSubType = eAttackSubType.Piercing

    'bdlRanged_Creep.mAttackDuration.Add(New ValueWrapper())
    'bdlRanged_Creep.mAttackDuration.Add(New ValueWrapper())

    'bdlRanged_Creep.mMissileSpeed = New ValueWrapper()
    bdlRanged_Creep.mBaseAttacktime = New ValueWrapper(1)

    bdlRanged_Creep.mBounty.Add(New ValueWrapper(43))
    bdlRanged_Creep.mBounty.Add(New ValueWrapper(53))
    bdlRanged_Creep.mXp = New ValueWrapper(41)


    'bdlRanged_Creep.mAbilityNames.Add(eAbilityName)

    Me.Add(eCreepName.untRanged_Creep, bdlRanged_Creep)
    '--------------------------------------------------------------



    Dim bdlSuper_Ranged_Creep As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Super Ranged Creep
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlSuper_Ranged_Creep.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Super Ranged Creep", eEntity.Creepbundle)

    bdlSuper_Ranged_Creep.mName = eCreepName.untSuper_Ranged_Creep
    bdlSuper_Ranged_Creep.mUnitType = eUnittype.LaneCreep
    bdlSuper_Ranged_Creep.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/c/c2/Ranged_creeps.png/130px-Ranged_creeps.png?version=6a259f85c755ad96995246fc9e0c2a5a"


    bdlSuper_Ranged_Creep.mDuration = New ValueWrapper(-1) '- 1 for permanent
    'bdlSuper_Ranged_Creep.mLevel = New ValueWrapper()

    bdlSuper_Ranged_Creep.mHealth = New ValueWrapper(300)
    bdlSuper_Ranged_Creep.mHealthIncrement = New ValueWrapper(10)
    bdlSuper_Ranged_Creep.mHealthRegen = New ValueWrapper(2)

    bdlSuper_Ranged_Creep.mMana = New ValueWrapper(500)
    bdlSuper_Ranged_Creep.mManaRegen = New ValueWrapper(0.75)

    bdlSuper_Ranged_Creep.mDamage.Add(New ValueWrapper(41))
    bdlSuper_Ranged_Creep.mDamage.Add(New ValueWrapper(46))

    bdlSuper_Ranged_Creep.mDamageIncrement = New ValueWrapper(3)

    bdlSuper_Ranged_Creep.mMagicResistance = New ValueWrapper(0)

    bdlSuper_Ranged_Creep.mArmor = New ValueWrapper(1)
    bdlSuper_Ranged_Creep.mArmorType = eArmorType.Unarmored

    bdlSuper_Ranged_Creep.mMoveSpeed = New ValueWrapper(325)
    bdlSuper_Ranged_Creep.mCOllisionSize = New ValueWrapper(16)
    bdlSuper_Ranged_Creep.mSightrange.Add(New ValueWrapper(850))
    bdlSuper_Ranged_Creep.mSightrange.Add(New ValueWrapper(800))

    bdlSuper_Ranged_Creep.mAttackType = eAttackType.Ranged
    bdlSuper_Ranged_Creep.mAttackSubType = eAttackSubType.Piercing

    'bdlSuper_Ranged_Creep.mAttackDuration.Add(New ValueWrapper())
    'bdlSuper_Ranged_Creep.mAttackDuration.Add(New ValueWrapper())

    'bdlSuper_Ranged_Creep.mMissileSpeed = New ValueWrapper()
    bdlSuper_Ranged_Creep.mBaseAttacktime = New ValueWrapper(1)

    bdlSuper_Ranged_Creep.mBounty.Add(New ValueWrapper(18))
    bdlSuper_Ranged_Creep.mBounty.Add(New ValueWrapper(26))
    bdlSuper_Ranged_Creep.mXp = New ValueWrapper(25)


    'bdlSuper_Ranged_Creep.mAbilityNames.Add(eAbilityName)

    Me.Add(eCreepName.untSuper_Ranged_Creep, bdlSuper_Ranged_Creep)
    '--------------------------------------------------------------



    Dim bdlMega_Ranged_Creep As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Mega Ranged Creep
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '

    bdlMega_Ranged_Creep.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Mega Ranged Creep", eEntity.Creepbundle)

    bdlMega_Ranged_Creep.mName = eCreepName.untMega_Ranged_Creep
    bdlMega_Ranged_Creep.mUnitType = eUnittype.LaneCreep
    bdlMega_Ranged_Creep.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/f/f2/Mega_Ranged_creeps.png/130px-Mega_Ranged_creeps.png?version=270ebd3c48e08c1cf655dfe865ad17ff"


    bdlMega_Ranged_Creep.mDuration = New ValueWrapper(-1) '- 1 for permanent
    'bdlMega_Ranged_Creep.mLevel = New ValueWrapper()

    bdlMega_Ranged_Creep.mHealth = New ValueWrapper(1015)
    bdlMega_Ranged_Creep.mHealthIncrement = New ValueWrapper(0)
    bdlMega_Ranged_Creep.mHealthRegen = New ValueWrapper(2)

    bdlMega_Ranged_Creep.mMana = New ValueWrapper(500)
    bdlMega_Ranged_Creep.mManaRegen = New ValueWrapper(0.75)

    bdlMega_Ranged_Creep.mDamage.Add(New ValueWrapper(131))
    bdlMega_Ranged_Creep.mDamage.Add(New ValueWrapper(136))

    bdlMega_Ranged_Creep.mDamageIncrement = New ValueWrapper(0)

    bdlMega_Ranged_Creep.mMagicResistance = New ValueWrapper(0)

    bdlMega_Ranged_Creep.mArmor = New ValueWrapper(1)
    bdlMega_Ranged_Creep.mArmorType = eArmorType.Unarmored

    bdlMega_Ranged_Creep.mMoveSpeed = New ValueWrapper(325)
    bdlMega_Ranged_Creep.mCOllisionSize = New ValueWrapper(16)
    bdlMega_Ranged_Creep.mSightrange.Add(New ValueWrapper(850))
    bdlMega_Ranged_Creep.mSightrange.Add(New ValueWrapper(800))

    bdlMega_Ranged_Creep.mAttackType = eAttackType.Ranged
    bdlMega_Ranged_Creep.mAttackSubType = eAttackSubType.Piercing

    'bdlMega_Ranged_Creep.mAttackDuration.Add(New ValueWrapper())
    'bdlMega_Ranged_Creep.mAttackDuration.Add(New ValueWrapper())

    'bdlMega_Ranged_Creep.mMissileSpeed = New ValueWrapper()
    bdlMega_Ranged_Creep.mBaseAttacktime = New ValueWrapper(1)

    bdlMega_Ranged_Creep.mBounty.Add(New ValueWrapper(18))
    bdlMega_Ranged_Creep.mBounty.Add(New ValueWrapper(26))
    bdlMega_Ranged_Creep.mXp = New ValueWrapper(25)


    'bdlMega_Ranged_Creep.mAbilityNames.Add(eAbilityName)

    Me.Add(eCreepName.untMega_Ranged_Creep, bdlMega_Ranged_Creep)
    '--------------------------------------------------------------


    Dim bdlSiege_Creep As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Siege Creep
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlSiege_Creep.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Siege Creep", eEntity.Creepbundle)

    bdlSiege_Creep.mName = eCreepName.untSiege_Creep
    bdlSiege_Creep.mUnitType = eUnittype.LaneCreep
    bdlSiege_Creep.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/2/28/Siege_creeps.png/130px-Siege_creeps.png?version=fc843dc983234861069289ed126ae548"


    bdlSiege_Creep.mDuration = New ValueWrapper(-1) '- 1 for permanent
    'bdlSiege_Creep.mLevel = New ValueWrapper()

    bdlSiege_Creep.mHealth = New ValueWrapper(550)
    bdlSiege_Creep.mHealthIncrement = New ValueWrapper(0)
    bdlSiege_Creep.mHealthRegen = New ValueWrapper(0)

    'bdlSiege_Creep.mMana = New ValueWrapper()
    'bdlSiege_Creep.mManaRegen = New ValueWrapper()

    bdlSiege_Creep.mDamage.Add(New ValueWrapper(66))
    bdlSiege_Creep.mDamage.Add(New ValueWrapper(80))

    bdlSiege_Creep.mDamageIncrement = New ValueWrapper(0)

    bdlSiege_Creep.mMagicResistance = New ValueWrapper(0)

    bdlSiege_Creep.mArmor = New ValueWrapper(0)
    bdlSiege_Creep.mArmorType = eArmorType.Fortified

    bdlSiege_Creep.mMoveSpeed = New ValueWrapper(325)
    bdlSiege_Creep.mCOllisionSize = New ValueWrapper(16)
    bdlSiege_Creep.mSightrange.Add(New ValueWrapper(850))
    bdlSiege_Creep.mSightrange.Add(New ValueWrapper(800))

    bdlSiege_Creep.mAttackType = eAttackType.Ranged
    bdlSiege_Creep.mAttackSubType = eAttackSubType.Siege

    'bdlSiege_Creep.mAttackDuration.Add(New ValueWrapper())
    'bdlSiege_Creep.mAttackDuration.Add(New ValueWrapper())

    'bdlSiege_Creep.mMissileSpeed = New ValueWrapper()
    bdlSiege_Creep.mBaseAttacktime = New ValueWrapper(2.7)

    bdlSiege_Creep.mBounty.Add(New ValueWrapper(66))
    bdlSiege_Creep.mBounty.Add(New ValueWrapper(80))
    bdlSiege_Creep.mXp = New ValueWrapper(88)


    'bdlSiege_Creep.mAbilityNames.Add(eAbilityName)

    Me.Add(eCreepName.untSiege_Creep, bdlSiege_Creep)
    '--------------------------------------------------------------



    Dim bdlSiege_Creep_Bonus As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Siege Creep Bonus
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlSiege_Creep_Bonus.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Siege Creep Bonus", eEntity.Creepbundle)

    bdlSiege_Creep_Bonus.mName = eCreepName.untSiege_Creep_Bonus
    bdlSiege_Creep_Bonus.mUnitType = eUnittype.LaneCreep
    bdlSiege_Creep_Bonus.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/2/28/Siege_creeps.png/130px-Siege_creeps.png?version=fc843dc983234861069289ed126ae548"


    bdlSiege_Creep_Bonus.mDuration = New ValueWrapper(-1) '- 1 for permanent
    'bdlSiege_Creep_Bonus.mLevel = New ValueWrapper()

    bdlSiege_Creep_Bonus.mHealth = New ValueWrapper(550)
    bdlSiege_Creep_Bonus.mHealthIncrement = New ValueWrapper(0)
    bdlSiege_Creep_Bonus.mHealthRegen = New ValueWrapper(0)

    'bdlSiege_Creep_Bonus.mMana = New ValueWrapper()
    'bdlSiege_Creep_Bonus.mManaRegen = New ValueWrapper()

    bdlSiege_Creep_Bonus.mDamage.Add(New ValueWrapper(51))
    bdlSiege_Creep_Bonus.mDamage.Add(New ValueWrapper(62))

    bdlSiege_Creep_Bonus.mDamageIncrement = New ValueWrapper(0)

    bdlSiege_Creep_Bonus.mMagicResistance = New ValueWrapper(0)

    bdlSiege_Creep_Bonus.mArmor = New ValueWrapper(0)
    bdlSiege_Creep_Bonus.mArmorType = eArmorType.Fortified

    bdlSiege_Creep_Bonus.mMoveSpeed = New ValueWrapper(325)
    bdlSiege_Creep_Bonus.mCOllisionSize = New ValueWrapper(16)
    bdlSiege_Creep_Bonus.mSightrange.Add(New ValueWrapper(850))
    bdlSiege_Creep_Bonus.mSightrange.Add(New ValueWrapper(800))

    bdlSiege_Creep_Bonus.mAttackType = eAttackType.Ranged
    bdlSiege_Creep_Bonus.mAttackSubType = eAttackSubType.Piercing

    'bdlSiege_Creep_Bonus.mAttackDuration.Add(New ValueWrapper())
    'bdlSiege_Creep_Bonus.mAttackDuration.Add(New ValueWrapper())

    'bdlSiege_Creep_Bonus.mMissileSpeed = New ValueWrapper()
    bdlSiege_Creep_Bonus.mBaseAttacktime = New ValueWrapper(2.7)

    bdlSiege_Creep_Bonus.mBounty.Add(New ValueWrapper(66))
    bdlSiege_Creep_Bonus.mBounty.Add(New ValueWrapper(80))
    bdlSiege_Creep_Bonus.mXp = New ValueWrapper(88)


    'bdlSiege_Creep_Bonus.mAbilityNames.Add(eAbilityName)

    Me.Add(eCreepName.untSiege_Creep_Bonus, bdlSiege_Creep_Bonus)
    '--------------------------------------------------------------



    Dim bdlKobold As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Kobold
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlKobold.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Kobold", eEntity.Creepbundle)

    bdlKobold.mName = eCreepName.untKobold
    bdlKobold.mUnitType = eUnittype.JungleCreep
    bdlKobold.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/e/ec/Kobold.jpg/200px-Kobold.jpg.png?version=0215db0ddc095f5f81258cab8c120bda"


    bdlKobold.mDuration = New ValueWrapper(-1) '- 1 for permanent
    bdlKobold.mLevel = New ValueWrapper(1)

    bdlKobold.mHealth = New ValueWrapper(240)
    'bdlKobold.mHealthIncrement = New ValueWrapper()
    bdlKobold.mHealthRegen = New ValueWrapper(0.5)

    'bdlKobold.mMana = New ValueWrapper()
    'bdlKobold.mManaRegen = New ValueWrapper()

    bdlKobold.mDamage.Add(New ValueWrapper(10))
    bdlKobold.mDamage.Add(New ValueWrapper(10))

    'bdlKobold.mDamageIncrement = New ValueWrapper()

    bdlKobold.mMagicResistance = New ValueWrapper(0)

    bdlKobold.mArmor = New ValueWrapper(0)
    bdlKobold.mArmorType = eArmorType.Heavy

    bdlKobold.mMoveSpeed = New ValueWrapper(270)
    bdlKobold.mCOllisionSize = New ValueWrapper(16)
    bdlKobold.mSightrange.Add(New ValueWrapper(1400))
    bdlKobold.mSightrange.Add(New ValueWrapper(800))

    bdlKobold.mAttackType = eAttackType.Melee
    bdlKobold.mAttackSubType = eAttackSubType.Normal

    bdlKobold.mAttackDuration.Add(New ValueWrapper(0.38))
    bdlKobold.mAttackDuration.Add(New ValueWrapper(0.6))

    bdlKobold.mCastDuration = New List(Of ValueWrapper)
    bdlKobold.mCastDuration.Add(New ValueWrapper(0.5))
    bdlKobold.mCastDuration.Add(New ValueWrapper(0.51))

    'bdlKobold.mMissileSpeed = New ValueWrapper()
    bdlKobold.mBaseAttacktime = New ValueWrapper(1.35)

    bdlKobold.mBounty.Add(New ValueWrapper(7))
    bdlKobold.mBounty.Add(New ValueWrapper(9))
    bdlKobold.mXp = New ValueWrapper(25)


    'bdlKobold.mAbilityNames.Add(eAbilityName)

    Me.Add(eCreepName.untKobold, bdlKobold)
    '--------------------------------------------------------------



    Dim bdlKobold_Soldier As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Kobold Soldier
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlKobold_Soldier.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Kobold Soldier", eEntity.Creepbundle)

    bdlKobold_Soldier.mName = eCreepName.untKobold_Soldier
    bdlKobold_Soldier.mUnitType = eUnittype.JungleCreep
    bdlKobold_Soldier.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/3/32/Koboldtunneler.jpg/200px-Koboldtunneler.jpg.png?version=dff98bede6e11e44fa20017324eae9e6"


    bdlKobold_Soldier.mDuration = New ValueWrapper(-1) '- 1 for permanent
    bdlKobold_Soldier.mLevel = New ValueWrapper(1)

    bdlKobold_Soldier.mHealth = New ValueWrapper(325)
    'bdlKobold_Soldier.mHealthIncrement = New ValueWrapper()
    bdlKobold_Soldier.mHealthRegen = New ValueWrapper(0.5)

    'bdlKobold_Soldier.mMana = New ValueWrapper()
    'bdlKobold_Soldier.mManaRegen = New ValueWrapper()

    bdlKobold_Soldier.mDamage.Add(New ValueWrapper(14))
    bdlKobold_Soldier.mDamage.Add(New ValueWrapper(14))

    'bdlKobold_Soldier.mDamageIncrement = New ValueWrapper()

    bdlKobold_Soldier.mMagicResistance = New ValueWrapper(0)

    bdlKobold_Soldier.mArmor = New ValueWrapper(1)
    bdlKobold_Soldier.mArmorType = eArmorType.Heavy

    bdlKobold_Soldier.mMoveSpeed = New ValueWrapper(270)
    bdlKobold_Soldier.mCOllisionSize = New ValueWrapper(16)
    bdlKobold_Soldier.mSightrange.Add(New ValueWrapper(800))
    bdlKobold_Soldier.mSightrange.Add(New ValueWrapper(800))

    bdlKobold_Soldier.mAttackType = eAttackType.Ranged
    bdlKobold_Soldier.mAttackSubType = eAttackSubType.Normal

    bdlKobold_Soldier.mCastDuration = New List(Of ValueWrapper)
    bdlKobold.mCastDuration.Add(New ValueWrapper(0.5))
    bdlKobold.mCastDuration.Add(New ValueWrapper(0.51))

    bdlKobold.mAttackRange = New ValueWrapper(100)

    'bdlKobold_Soldier.mAttackDuration.Add(New ValueWrapper())
    'bdlKobold_Soldier.mAttackDuration.Add(New ValueWrapper())

    'bdlKobold_Soldier.mMissileSpeed = New ValueWrapper()
    bdlKobold_Soldier.mBaseAttacktime = New ValueWrapper(1.35)

    bdlKobold_Soldier.mBounty.Add(New ValueWrapper(17))
    bdlKobold_Soldier.mBounty.Add(New ValueWrapper(19))
    bdlKobold_Soldier.mXp = New ValueWrapper(25)


    'bdlKobold_Soldier.mAbilityNames.Add(eAbilityName)

    Me.Add(eCreepName.untKobold_Soldier, bdlKobold_Soldier)
    '--------------------------------------------------------------



    Dim bdlKobold_Foreman As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Kobold Foreman
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlKobold_Foreman.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Kobold Foreman", eEntity.Creepbundle)

    bdlKobold_Foreman.mName = eCreepName.untKobold_Foreman
    bdlKobold_Foreman.mUnitType = eUnittype.JungleCreep
    bdlKobold_Foreman.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/b/b7/Koboldtaskmaster.jpg/200px-Koboldtaskmaster.jpg.png?version=14038fbccab16ec64c2d5af3d599d46c"


    bdlKobold_Foreman.mDuration = New ValueWrapper(-1) '- 1 for permanent
    bdlKobold_Foreman.mLevel = New ValueWrapper(2)

    bdlKobold_Foreman.mHealth = New ValueWrapper(400)
    'bdlKobold_Foreman.mHealthIncrement = New ValueWrapper()
    bdlKobold_Foreman.mHealthRegen = New ValueWrapper(0.5)

    'bdlKobold_Foreman.mMana = New ValueWrapper()
    'bdlKobold_Foreman.mManaRegen = New ValueWrapper()

    bdlKobold_Foreman.mDamage.Add(New ValueWrapper(14))
    bdlKobold_Foreman.mDamage.Add(New ValueWrapper(14))

    'bdlKobold_Foreman.mDamageIncrement = New ValueWrapper()

    bdlKobold_Foreman.mMagicResistance = New ValueWrapper(0)

    bdlKobold_Foreman.mArmor = New ValueWrapper(0)
    bdlKobold_Foreman.mArmorType = eArmorType.Heavy

    bdlKobold_Foreman.mMoveSpeed = New ValueWrapper(330)
    bdlKobold_Foreman.mCOllisionSize = New ValueWrapper(16)
    bdlKobold_Foreman.mSightrange.Add(New ValueWrapper(800))
    bdlKobold_Foreman.mSightrange.Add(New ValueWrapper(800))

    bdlKobold_Foreman.mAttackType = eAttackType.Ranged
    bdlKobold_Foreman.mAttackSubType = eAttackSubType.Normal

    bdlKobold_Foreman.mAttackDuration.Add(New ValueWrapper(0.38))
    bdlKobold_Foreman.mAttackDuration.Add(New ValueWrapper(0.6))

    'bdlKobold_Foreman.mMissileSpeed = New ValueWrapper()
    bdlKobold_Foreman.mBaseAttacktime = New ValueWrapper(1.35)

    bdlKobold_Foreman.mBounty.Add(New ValueWrapper(800))
    bdlKobold_Foreman.mBounty.Add(New ValueWrapper(800))
    bdlKobold_Foreman.mXp = New ValueWrapper(41)


    bdlKobold_Foreman.mAbilityNames.Add(eAbilityName.abKobold_Foreman_Speed_Aura)

    Me.Add(eCreepName.untKobold_Foreman, bdlKobold_Foreman)
    '--------------------------------------------------------------



    Dim bdlHill_Troll_Berserker As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Hill Trol
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlHill_Troll_Berserker.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Hill Troll Berserker", eEntity.Creepbundle)

    bdlHill_Troll_Berserker.mName = eCreepName.untHill_Troll_Berserker
    bdlHill_Troll_Berserker.mUnitType = eUnittype.JungleCreep
    bdlHill_Troll_Berserker.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/8/8e/Foresttrollberserker.jpg/200px-Foresttrollberserker.jpg.png?version=8ae3d0d90b62a11c5e948398126eb647"


    bdlHill_Troll_Berserker.mDuration = New ValueWrapper(-1) '- 1 for permanent
    bdlHill_Troll_Berserker.mLevel = New ValueWrapper(2)

    bdlHill_Troll_Berserker.mHealth = New ValueWrapper(500)
    'bdlHill_Troll_Berserker.mHealthIncrement = New ValueWrapper()
    bdlHill_Troll_Berserker.mHealthRegen = New ValueWrapper(0.5)

    'bdlHill_Troll_Berserker.mMana = New ValueWrapper()
    'bdlHill_Troll_Berserker.mManaRegen = New ValueWrapper()

    bdlHill_Troll_Berserker.mDamage.Add(New ValueWrapper(32))
    bdlHill_Troll_Berserker.mDamage.Add(New ValueWrapper(32))

    'bdlHill_Troll_Berserker.mDamageIncrement = New ValueWrapper()

    bdlHill_Troll_Berserker.mMagicResistance = New ValueWrapper(0)

    bdlHill_Troll_Berserker.mArmor = New ValueWrapper(1)
    bdlHill_Troll_Berserker.mArmorType = eArmorType.Medium

    bdlHill_Troll_Berserker.mMoveSpeed = New ValueWrapper(270)
    bdlHill_Troll_Berserker.mCOllisionSize = New ValueWrapper(16)
    bdlHill_Troll_Berserker.mSightrange.Add(New ValueWrapper(800))
    bdlHill_Troll_Berserker.mSightrange.Add(New ValueWrapper(800))

    bdlHill_Troll_Berserker.mAttackType = eAttackType.Melee
    bdlHill_Troll_Berserker.mAttackSubType = eAttackSubType.Piercing

    bdlHill_Troll_Berserker.mAttackDuration.Add(New ValueWrapper(0.3))
    bdlHill_Troll_Berserker.mAttackDuration.Add(New ValueWrapper(0.3))

    bdlHill_Troll_Berserker.mCastDuration = New List(Of ValueWrapper)
    bdlHill_Troll_Berserker.mCastDuration.Add(New ValueWrapper(0.5))
        bdlHill_Troll_Berserker.mCastDuration.Add(New ValueWrapper(0.51))

    bdlHill_Troll_Berserker.mMissileSpeed = New ValueWrapper(1200)
    bdlHill_Troll_Berserker.mBaseAttacktime = New ValueWrapper(1.6)


    bdlHill_Troll_Berserker.mBounty.Add(New ValueWrapper(22))
    bdlHill_Troll_Berserker.mBounty.Add(New ValueWrapper(26))
    bdlHill_Troll_Berserker.mXp = New ValueWrapper(41)


    'bdlHill_Troll_Berserker.mAbilityNames.Add(eAbilityName)

    Me.Add(eCreepName.untHill_Troll_Berserker, bdlHill_Troll_Berserker)
    '--------------------------------------------------------------



    Dim bdlHill_Troll_Priest As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Hill Troll Priest
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlHill_Troll_Priest.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Hill Troll Priest", eEntity.Creepbundle)

    bdlHill_Troll_Priest.mName = eCreepName.untHill_Troll_Priest
    bdlHill_Troll_Priest.mUnitType = eUnittype.JungleCreep
    bdlHill_Troll_Priest.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/8/8e/Foresttrollberserker.jpg/200px-Foresttrollberserker.jpg.png?version=8ae3d0d90b62a11c5e948398126eb647"


    bdlHill_Troll_Priest.mDuration = New ValueWrapper(-1) '- 1 for permanent
    bdlHill_Troll_Priest.mLevel = New ValueWrapper(2)

    bdlHill_Troll_Priest.mHealth = New ValueWrapper(450)
    'bdlHill_Troll_Berserker.mHealthIncrement = New ValueWrapper(0.5)
    bdlHill_Troll_Priest.mHealthRegen = New ValueWrapper(0.5)

    bdlHill_Troll_Priest.mMana = New ValueWrapper(500)
    bdlHill_Troll_Priest.mManaRegen = New ValueWrapper(0.75)

    bdlHill_Troll_Priest.mDamage.Add(New ValueWrapper(28))
    bdlHill_Troll_Priest.mDamage.Add(New ValueWrapper(28))

    'bdlHill_Troll_Berserker.mDamageIncrement = New ValueWrapper()

    bdlHill_Troll_Priest.mMagicResistance = New ValueWrapper(0)

    bdlHill_Troll_Priest.mArmor = New ValueWrapper(0)
    bdlHill_Troll_Priest.mArmorType = eArmorType.Medium

    bdlHill_Troll_Priest.mMoveSpeed = New ValueWrapper(290)
    bdlHill_Troll_Priest.mCOllisionSize = New ValueWrapper(16)
    bdlHill_Troll_Priest.mSightrange.Add(New ValueWrapper(1400))
    bdlHill_Troll_Priest.mSightrange.Add(New ValueWrapper(800))

    bdlHill_Troll_Priest.mAttackType = eAttackType.Ranged
    bdlHill_Troll_Priest.mAttackSubType = eAttackSubType.Piercing

    bdlHill_Troll_Priest.mAttackDuration.Add(New ValueWrapper(0.3))
    bdlHill_Troll_Priest.mAttackDuration.Add(New ValueWrapper(0.3))

    bdlHill_Troll_Priest.mCastDuration = New List(Of ValueWrapper)
    bdlHill_Troll_Priest.mCastDuration.Add(New ValueWrapper(0.5))
    bdlHill_Troll_Priest.mCastDuration.Add(New ValueWrapper(0.5))

    bdlHill_Troll_Priest.mMissileSpeed = New ValueWrapper(900)
    bdlHill_Troll_Priest.mBaseAttacktime = New ValueWrapper(1.8)

    bdlHill_Troll_Priest.mBounty.Add(New ValueWrapper(21))
    bdlHill_Troll_Priest.mBounty.Add(New ValueWrapper(25))
    bdlHill_Troll_Priest.mXp = New ValueWrapper(41)


    bdlHill_Troll_Priest.mAbilityNames.Add(eAbilityName.abHill_Troll_Priest_Heal)

    Me.Add(eCreepName.untHill_Troll_Priest, bdlHill_Troll_Priest)
    '--------------------------------------------------------------



    Dim bdlVhoul_Assassin As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Vhoul Assassin
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlVhoul_Assassin.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Vhoul Assassin", eEntity.Creepbundle)

    bdlVhoul_Assassin.mName = eCreepName.untVhoul_Assassin
    bdlVhoul_Assassin.mUnitType = eUnittype.JungleCreep
    bdlVhoul_Assassin.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/a/ab/Gnollassassin.jpg/200px-Gnollassassin.jpg.png?version=087c7567c645c55883468ac69534c475"


    bdlVhoul_Assassin.mDuration = New ValueWrapper(-1) '- 1 for permanent
    bdlVhoul_Assassin.mLevel = New ValueWrapper(2)

    bdlVhoul_Assassin.mHealth = New ValueWrapper(370)
    'bdlVhoul_Assassin.mHealthIncrement = New ValueWrapper()
    bdlVhoul_Assassin.mHealthRegen = New ValueWrapper(0.5)

    'bdlVhoul_Assassin.mMana = New ValueWrapper()
    'bdlVhoul_Assassin.mManaRegen = New ValueWrapper()

    bdlVhoul_Assassin.mDamage.Add(New ValueWrapper(33))
    bdlVhoul_Assassin.mDamage.Add(New ValueWrapper(33))

    'bdlVhoul_Assassin.mDamageIncrement = New ValueWrapper()

    bdlVhoul_Assassin.mMagicResistance = New ValueWrapper(0)

    bdlVhoul_Assassin.mArmor = New ValueWrapper(1)
    bdlVhoul_Assassin.mArmorType = eArmorType.Medium

    bdlVhoul_Assassin.mMoveSpeed = New ValueWrapper(270)
    bdlVhoul_Assassin.mCOllisionSize = New ValueWrapper(16)
    bdlVhoul_Assassin.mSightrange.Add(New ValueWrapper(400))
    bdlVhoul_Assassin.mSightrange.Add(New ValueWrapper(400))

    bdlVhoul_Assassin.mAttackType = eAttackType.Ranged
    bdlVhoul_Assassin.mAttackSubType = eAttackSubType.Piercing

    bdlVhoul_Assassin.mAttackDuration.Add(New ValueWrapper(0.4))
    bdlVhoul_Assassin.mAttackDuration.Add(New ValueWrapper(0.3))

    bdlVhoul_Assassin.mCastDuration = New List(Of ValueWrapper)
    bdlVhoul_Assassin.mCastDuration.Add(New ValueWrapper(0.5))
    bdlVhoul_Assassin.mCastDuration.Add(New ValueWrapper(0.51))

    bdlVhoul_Assassin.mMissileSpeed = New ValueWrapper(1500)
    bdlVhoul_Assassin.mBaseAttacktime = New ValueWrapper(1.6)

    bdlVhoul_Assassin.mBounty.Add(New ValueWrapper(21))
    bdlVhoul_Assassin.mBounty.Add(New ValueWrapper(29))
    bdlVhoul_Assassin.mXp = New ValueWrapper(41)


    bdlVhoul_Assassin.mAbilityNames.Add(eAbilityName.abVhoul_Assassin_Envenomed_Weapon)

    Me.Add(eCreepName.untVhoul_Assassin, bdlVhoul_Assassin)
    '--------------------------------------------------------------



    Dim bdlFell_Spirit As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Fell Spirit
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlFell_Spirit.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Fell Spirit", eEntity.Creepbundle)

    bdlFell_Spirit.mName = eCreepName.untFell_Spirit
    bdlFell_Spirit.mUnitType = eUnittype.JungleCreep
    bdlFell_Spirit.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/e/e9/Felbeast.jpg/200px-Felbeast.jpg.png?version=0052f43c095ec85fea20f575e7451f30"


    bdlFell_Spirit.mDuration = New ValueWrapper(-1) '- 1 for permanent
    bdlFell_Spirit.mLevel = New ValueWrapper(2)

    bdlFell_Spirit.mHealth = New ValueWrapper(400)
    'bdlFell_Spirit.mHealthIncrement = New ValueWrapper()
    bdlFell_Spirit.mHealthRegen = New ValueWrapper(0.5)

    'bdlFell_Spirit.mMana = New ValueWrapper()
    'bdlFell_Spirit.mManaRegen = New ValueWrapper()

    bdlFell_Spirit.mDamage.Add(New ValueWrapper(14))
    bdlFell_Spirit.mDamage.Add(New ValueWrapper(14))

    'bdlFell_Spirit.mDamageIncrement = New ValueWrapper()

    bdlFell_Spirit.mMagicResistance = New ValueWrapper(0)

    bdlFell_Spirit.mArmor = New ValueWrapper(1)
    bdlFell_Spirit.mArmorType = eArmorType.Heavy

    bdlFell_Spirit.mMoveSpeed = New ValueWrapper(350)
    bdlFell_Spirit.mCOllisionSize = New ValueWrapper(16)
    bdlFell_Spirit.mSightrange.Add(New ValueWrapper(800))
    bdlFell_Spirit.mSightrange.Add(New ValueWrapper(800))

    bdlFell_Spirit.mAttackType = eAttackType.Melee
    bdlFell_Spirit.mAttackSubType = eAttackSubType.Normal

    bdlFell_Spirit.mAttackDuration.Add(New ValueWrapper(0.4))
    bdlFell_Spirit.mAttackDuration.Add(New ValueWrapper(0.3))

    bdlFell_Spirit.mCastDuration = New List(Of ValueWrapper)
    bdlFell_Spirit.mCastDuration.Add(New ValueWrapper(0.4))
    bdlFell_Spirit.mCastDuration.Add(New ValueWrapper(0.5))

    'bdlFell_Spirit.mMissileSpeed = New ValueWrapper()
    bdlFell_Spirit.mBaseAttacktime = New ValueWrapper(1.5)

    bdlFell_Spirit.mBounty.Add(New ValueWrapper(20))
    bdlFell_Spirit.mBounty.Add(New ValueWrapper(23))
    bdlFell_Spirit.mXp = New ValueWrapper(41)


    'bdlFell_Spirit.mAbilityNames.Add(eAbilityName)

    Me.Add(eCreepName.untFell_Spirit, bdlFell_Spirit)
    '--------------------------------------------------------------



   



    Dim bdlHarpy_Scout As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Harpy Scout
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlHarpy_Scout.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Harpy Scout", eEntity.Creepbundle)

    bdlHarpy_Scout.mName = eCreepName.untHarpy_Scout
    bdlHarpy_Scout.mUnitType = eUnittype.JungleCreep
    bdlHarpy_Scout.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/0/02/Harpyscout.jpg/200px-Harpyscout.jpg.png?version=e728932189ba1eb803e288a3699bcc28"


    bdlHarpy_Scout.mDuration = New ValueWrapper(-1) '- 1 for permanent
    bdlHarpy_Scout.mLevel = New ValueWrapper(2)

    bdlHarpy_Scout.mHealth = New ValueWrapper(400)
    'bdlHarpy_Scout.mHealthIncrement = New ValueWrapper()
    bdlHarpy_Scout.mHealthRegen = New ValueWrapper(0.5)

    'bdlHarpy_Scout.mMana = New ValueWrapper()
    'bdlHarpy_Scout.mManaRegen = New ValueWrapper()

    bdlHarpy_Scout.mDamage.Add(New ValueWrapper(24))
    bdlHarpy_Scout.mDamage.Add(New ValueWrapper(27))

    'bdlHarpy_Scout.mDamageIncrement = New ValueWrapper()

    bdlHarpy_Scout.mMagicResistance = New ValueWrapper(0)

    bdlHarpy_Scout.mArmor = New ValueWrapper(1)
    bdlHarpy_Scout.mArmorType = eArmorType.Medium

    bdlHarpy_Scout.mMoveSpeed = New ValueWrapper(280)
    bdlHarpy_Scout.mCOllisionSize = New ValueWrapper(16)
    bdlHarpy_Scout.mSightrange.Add(New ValueWrapper(1800))
    bdlHarpy_Scout.mSightrange.Add(New ValueWrapper(1800))

    bdlHarpy_Scout.mAttackType = eAttackType.Ranged
    bdlHarpy_Scout.mAttackSubType = eAttackSubType.Piercing

    bdlHarpy_Scout.mAttackDuration.Add(New ValueWrapper(0.3))
    bdlHarpy_Scout.mAttackDuration.Add(New ValueWrapper(0.3))

    bdlHarpy_Scout.mCastDuration = New List(Of ValueWrapper)
    bdlHarpy_Scout.mCastDuration.Add(New ValueWrapper(0.5))
    bdlHarpy_Scout.mCastDuration.Add(New ValueWrapper(0.51))


    bdlHarpy_Scout.mMissileSpeed = New ValueWrapper(1200)
    bdlHarpy_Scout.mBaseAttacktime = New ValueWrapper(1.6)

    bdlHarpy_Scout.mBounty.Add(New ValueWrapper(24))
    bdlHarpy_Scout.mBounty.Add(New ValueWrapper(27))
    bdlHarpy_Scout.mXp = New ValueWrapper(41)


    'bdlHarpy_Scout.mAbilityNames.Add(eAbilityName)

    Me.Add(eCreepName.untHarpy_Scout, bdlHarpy_Scout)
    '--------------------------------------------------------------



    Dim bdlHarpy_Stormcrafter As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Harpy Stormcrafter
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlHarpy_Stormcrafter.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Harpy Stormcrafter", eEntity.Creepbundle)

    bdlHarpy_Stormcrafter.mName = eCreepName.untHarpy_Stormcrafter
    bdlHarpy_Stormcrafter.mUnitType = eUnittype.JungleCreep
    bdlHarpy_Stormcrafter.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/3/30/Harpystorm.jpg/200px-Harpystorm.jpg.png?version=f690290571a8838cfca3cda00b828f13"


    bdlHarpy_Stormcrafter.mDuration = New ValueWrapper(-1) '- 1 for permanent
    bdlHarpy_Stormcrafter.mLevel = New ValueWrapper(3)

    bdlHarpy_Stormcrafter.mHealth = New ValueWrapper(550)
    'bdlHarpy_Stormcrafter.mHealthIncrement = New ValueWrapper(550)
    bdlHarpy_Stormcrafter.mHealthRegen = New ValueWrapper(0.5)

    bdlHarpy_Stormcrafter.mMana = New ValueWrapper(540)
    bdlHarpy_Stormcrafter.mManaRegen = New ValueWrapper(0)

    bdlHarpy_Stormcrafter.mDamage.Add(New ValueWrapper(33))
    bdlHarpy_Stormcrafter.mDamage.Add(New ValueWrapper(33))

    'bdlHarpy_Stormcrafter.mDamageIncrement = New ValueWrapper()

    bdlHarpy_Stormcrafter.mMagicResistance = New ValueWrapper(0)

    bdlHarpy_Stormcrafter.mArmor = New ValueWrapper(2)
    bdlHarpy_Stormcrafter.mArmorType = eArmorType.Medium

    bdlHarpy_Stormcrafter.mMoveSpeed = New ValueWrapper(310)
    bdlHarpy_Stormcrafter.mCOllisionSize = New ValueWrapper(16)
    bdlHarpy_Stormcrafter.mSightrange.Add(New ValueWrapper(1800))
    bdlHarpy_Stormcrafter.mSightrange.Add(New ValueWrapper(1800))

    bdlHarpy_Stormcrafter.mAttackType = eAttackType.Ranged
    bdlHarpy_Stormcrafter.mAttackSubType = eAttackSubType.Piercing

    bdlHarpy_Stormcrafter.mAttackDuration.Add(New ValueWrapper(0.3))
    bdlHarpy_Stormcrafter.mAttackDuration.Add(New ValueWrapper(0.3))

    bdlHarpy_Stormcrafter.mCastDuration = New List(Of ValueWrapper)
    bdlHarpy_Stormcrafter.mCastDuration.Add(New ValueWrapper(0.5))
    bdlHarpy_Stormcrafter.mCastDuration.Add(New ValueWrapper(0.51))

    bdlHarpy_Stormcrafter.mMissileSpeed = New ValueWrapper(1200)
    bdlHarpy_Stormcrafter.mBaseAttacktime = New ValueWrapper(1.6)

    bdlHarpy_Stormcrafter.mBounty.Add(New ValueWrapper(33))
    bdlHarpy_Stormcrafter.mBounty.Add(New ValueWrapper(37))
    bdlHarpy_Stormcrafter.mXp = New ValueWrapper(62)


    bdlHarpy_Stormcrafter.mAbilityNames.Add(eAbilityName.abHarpy_Stormcrafter_Chain_Lightning)

    Me.Add(eCreepName.untHarpy_Stormcrafter, bdlHarpy_Stormcrafter)
    '--------------------------------------------------------------



    Dim bdlCentaur_Conqueror As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Centaur Conqueror
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlCentaur_Conqueror.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Centaur Conqueror", eEntity.Creepbundle)

    bdlCentaur_Conqueror.mName = eCreepName.untCentaur_Conqueror
    bdlCentaur_Conqueror.mUnitType = eUnittype.JungleCreep
    bdlCentaur_Conqueror.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/f/f3/Centaur_Khan.jpg/200px-Centaur_Khan.jpg.png?version=b009fae934cb83ef3385749d101241e3"


    bdlCentaur_Conqueror.mDuration = New ValueWrapper(-1) '- 1 for permanent
    bdlCentaur_Conqueror.mLevel = New ValueWrapper(5)

    bdlCentaur_Conqueror.mHealth = New ValueWrapper(1100)
    'bdlCentaur_Conqueror.mHealthIncrement = New ValueWrapper()
    bdlCentaur_Conqueror.mHealthRegen = New ValueWrapper(1)

    bdlCentaur_Conqueror.mMana = New ValueWrapper(200)
    bdlCentaur_Conqueror.mManaRegen = New ValueWrapper(0)

    bdlCentaur_Conqueror.mDamage.Add(New ValueWrapper(49))
    bdlCentaur_Conqueror.mDamage.Add(New ValueWrapper(55))

    'bdlCentaur_Conqueror.mDamageIncrement = New ValueWrapper()

    bdlCentaur_Conqueror.mMagicResistance = New ValueWrapper(0)

    bdlCentaur_Conqueror.mArmor = New ValueWrapper(4)
    bdlCentaur_Conqueror.mArmorType = eArmorType.Heavy

    bdlCentaur_Conqueror.mMoveSpeed = New ValueWrapper(320)
    bdlCentaur_Conqueror.mCOllisionSize = New ValueWrapper(16)
    bdlCentaur_Conqueror.mSightrange.Add(New ValueWrapper(800))
    bdlCentaur_Conqueror.mSightrange.Add(New ValueWrapper(800))

    bdlCentaur_Conqueror.mAttackType = eAttackType.Melee
    bdlCentaur_Conqueror.mAttackSubType = eAttackSubType.Chaos

    bdlCentaur_Conqueror.mAttackDuration.Add(New ValueWrapper(0.3))
    bdlCentaur_Conqueror.mAttackDuration.Add(New ValueWrapper(0.3))

    bdlCentaur_Conqueror.mCastDuration = New List(Of ValueWrapper)
    bdlCentaur_Conqueror.mCastDuration.Add(New ValueWrapper(0.5))
    bdlCentaur_Conqueror.mCastDuration.Add(New ValueWrapper(0.51))

    'bdlCentaur_Conqueror.mMissileSpeed = New ValueWrapper()
    bdlCentaur_Conqueror.mBaseAttacktime = New ValueWrapper(1.5)

    bdlCentaur_Conqueror.mBounty.Add(New ValueWrapper(66))
    bdlCentaur_Conqueror.mBounty.Add(New ValueWrapper(78))
    bdlCentaur_Conqueror.mXp = New ValueWrapper(119)


    bdlCentaur_Conqueror.mAbilityNames.Add(eAbilityName.abCentaur_Congeror_War_Stomp)

    Me.Add(eCreepName.untCentaur_Conqueror, bdlCentaur_Conqueror)
    '--------------------------------------------------------------



    Dim bdlCentaur_Courser As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Centaur Courser
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlCentaur_Courser.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Centaur Courser", eEntity.Creepbundle)

    bdlCentaur_Courser.mName = eCreepName.untCentaur_Courser
    bdlCentaur_Courser.mUnitType = eUnittype.JungleCreep
    bdlCentaur_Courser.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/8/8e/Centaur_Outrunner.jpg?version=a4f3d45688c0ab3f8ed8d34cec5a9092"


    bdlCentaur_Courser.mDuration = New ValueWrapper(-1) '- 1 for permanent
    bdlCentaur_Courser.mLevel = New ValueWrapper(2)

    bdlCentaur_Courser.mHealth = New ValueWrapper(550)
    'bdlCentaur_Courser.mHealthIncrement = New ValueWrapper(0.5)
    bdlCentaur_Courser.mHealthRegen = New ValueWrapper(0.5)

    'bdlCentaur_Courser.mMana = New ValueWrapper()
    'bdlCentaur_Courser.mManaRegen = New ValueWrapper()

    bdlCentaur_Courser.mDamage.Add(New ValueWrapper(18))
    bdlCentaur_Courser.mDamage.Add(New ValueWrapper(21))

    'bdlCentaur_Courser.mDamageIncrement = New ValueWrapper()

    bdlCentaur_Courser.mMagicResistance = New ValueWrapper(0)

    bdlCentaur_Courser.mArmor = New ValueWrapper(2)
    bdlCentaur_Courser.mArmorType = eArmorType.Heavy

    bdlCentaur_Courser.mMoveSpeed = New ValueWrapper(350)
    bdlCentaur_Courser.mCOllisionSize = New ValueWrapper(16)
    bdlCentaur_Courser.mSightrange.Add(New ValueWrapper(800))
    bdlCentaur_Courser.mSightrange.Add(New ValueWrapper(800))

    bdlCentaur_Courser.mAttackType = eAttackType.Melee
    bdlCentaur_Courser.mAttackSubType = eAttackSubType.Chaos

    bdlCentaur_Courser.mAttackDuration.Add(New ValueWrapper(0.3))
    bdlCentaur_Courser.mAttackDuration.Add(New ValueWrapper(0.3))

    bdlCentaur_Courser.mCastDuration = New List(Of ValueWrapper)
    bdlCentaur_Courser.mCastDuration.Add(New ValueWrapper(0.5))
    bdlCentaur_Courser.mCastDuration.Add(New ValueWrapper(0.51))

    'bdlCentaur_Courser.mMissileSpeed = New ValueWrapper()
    bdlCentaur_Courser.mBaseAttacktime = New ValueWrapper(1.3)

    bdlCentaur_Courser.mBounty.Add(New ValueWrapper(20))
    bdlCentaur_Courser.mBounty.Add(New ValueWrapper(24))
    bdlCentaur_Courser.mXp = New ValueWrapper(41)


    'bdlCentaur_Courser.mAbilityNames.Add(eAbilityName)

    Me.Add(eCreepName.untCentaur_Courser, bdlCentaur_Courser)
    '--------------------------------------------------------------



    Dim bdlGiant_Wolf As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Giant Wolf
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlGiant_Wolf.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Giant Wolf", eEntity.Creepbundle)

    bdlGiant_Wolf.mName = eCreepName.untGiant_Wolf
    bdlGiant_Wolf.mUnitType = eUnittype.JungleCreep
    bdlGiant_Wolf.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/0/0b/Giant_Wolf.jpg?version=2ff8e3e9007f871a355190030f94b63c"



    bdlGiant_Wolf.mDuration = New ValueWrapper(-1) '- 1 for permanent
    bdlGiant_Wolf.mLevel = New ValueWrapper(3)

    bdlGiant_Wolf.mHealth = New ValueWrapper(500)
    'bdlGiant_Wolf.mHealthIncrement = New ValueWrapper()
    bdlGiant_Wolf.mHealthRegen = New ValueWrapper(0.5)

    'bdlGiant_Wolf.mMana = New ValueWrapper()
    'bdlGiant_Wolf.mManaRegen = New ValueWrapper()

    bdlGiant_Wolf.mDamage.Add(New ValueWrapper(21))
    bdlGiant_Wolf.mDamage.Add(New ValueWrapper(24))

    'bdlGiant_Wolf.mDamageIncrement = New ValueWrapper()

    bdlGiant_Wolf.mMagicResistance = New ValueWrapper(0)

    bdlGiant_Wolf.mArmor = New ValueWrapper(1)
    bdlGiant_Wolf.mArmorType = eArmorType.Heavy

    bdlGiant_Wolf.mMoveSpeed = New ValueWrapper(350)
    bdlGiant_Wolf.mCOllisionSize = New ValueWrapper(16)
    bdlGiant_Wolf.mSightrange.Add(New ValueWrapper(800))
    bdlGiant_Wolf.mSightrange.Add(New ValueWrapper(800))

    bdlGiant_Wolf.mAttackType = eAttackType.Melee
    bdlGiant_Wolf.mAttackSubType = eAttackSubType.Piercing

    bdlGiant_Wolf.mAttackDuration.Add(New ValueWrapper(0.33))
    bdlGiant_Wolf.mAttackDuration.Add(New ValueWrapper(0.64))

    bdlGiant_Wolf.mCastDuration = New List(Of ValueWrapper)
    bdlGiant_Wolf.mCastDuration.Add(New ValueWrapper(0.5))
    bdlGiant_Wolf.mCastDuration.Add(New ValueWrapper(0.51))

    'bdlGiant_Wolf.mMissileSpeed = New ValueWrapper()
    bdlGiant_Wolf.mBaseAttacktime = New ValueWrapper(1.45)

    bdlGiant_Wolf.mBounty.Add(New ValueWrapper(22))
    bdlGiant_Wolf.mBounty.Add(New ValueWrapper(26))
    bdlGiant_Wolf.mXp = New ValueWrapper(62)


    bdlGiant_Wolf.mAbilityNames.Add(eAbilityName.abGiant_Wolf_Critical_Strike)

    Me.Add(eCreepName.untGiant_Wolf, bdlGiant_Wolf)
    '--------------------------------------------------------------



    Dim bdlAlpha_Wolf As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Alpha Wolf
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlAlpha_Wolf.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Alpha Wolf", eEntity.Creepbundle)

    bdlAlpha_Wolf.mName = eCreepName.untAlpha_Wolf
    bdlAlpha_Wolf.mUnitType = eUnittype.JungleCreep
    bdlAlpha_Wolf.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/8/81/Alpha_Wolf.jpg?version=94264f8fb3e0599c70a58f89c69d40cc"



    bdlAlpha_Wolf.mDuration = New ValueWrapper(-1) '- 1 for permanent
    bdlAlpha_Wolf.mLevel = New ValueWrapper(4)

    bdlAlpha_Wolf.mHealth = New ValueWrapper(600)
    'bdlAlpha_Wolf.mHealthIncrement = New ValueWrapper()
    bdlAlpha_Wolf.mHealthRegen = New ValueWrapper(0.5)

    'bdlAlpha_Wolf.mMana = New ValueWrapper()
    'bdlAlpha_Wolf.mManaRegen = New ValueWrapper()

    bdlAlpha_Wolf.mDamage.Add(New ValueWrapper(30))
    bdlAlpha_Wolf.mDamage.Add(New ValueWrapper(33))

    'bdlAlpha_Wolf.mDamageIncrement = New ValueWrapper()

    bdlAlpha_Wolf.mMagicResistance = New ValueWrapper(0)

    bdlAlpha_Wolf.mArmor = New ValueWrapper(3)
    bdlAlpha_Wolf.mArmorType = eArmorType.Heavy

    bdlAlpha_Wolf.mMoveSpeed = New ValueWrapper(350)
    bdlAlpha_Wolf.mCOllisionSize = New ValueWrapper(16)
    bdlAlpha_Wolf.mSightrange.Add(New ValueWrapper(800))
    bdlAlpha_Wolf.mSightrange.Add(New ValueWrapper(800))

    bdlAlpha_Wolf.mAttackType = eAttackType.Melee
    bdlAlpha_Wolf.mAttackSubType = eAttackSubType.Normal

    bdlAlpha_Wolf.mAttackDuration.Add(New ValueWrapper(0.33))
    bdlAlpha_Wolf.mAttackDuration.Add(New ValueWrapper(0.64))

    bdlAlpha_Wolf.mCastDuration = New List(Of ValueWrapper)
    bdlAlpha_Wolf.mCastDuration.Add(New ValueWrapper(0.5))
    bdlAlpha_Wolf.mCastDuration.Add(New ValueWrapper(0.51))


    'bdlAlpha_Wolf.mMissileSpeed = New ValueWrapper()
    bdlAlpha_Wolf.mBaseAttacktime = New ValueWrapper(1.35)

    bdlAlpha_Wolf.mBounty.Add(New ValueWrapper(37))
    bdlAlpha_Wolf.mBounty.Add(New ValueWrapper(45))
    bdlAlpha_Wolf.mXp = New ValueWrapper(88)


    bdlAlpha_Wolf.mAbilityNames.Add(eAbilityName.abAlpha_Wolf_Critical_Strike)

    Me.Add(eCreepName.untAlpha_Wolf, bdlAlpha_Wolf)
    '--------------------------------------------------------------



    Dim bdlSatyr_Banisher As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Satyr Banisher
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlSatyr_Banisher.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Satyr Banisher", eEntity.Creepbundle)

    bdlSatyr_Banisher.mName = eCreepName.untSatyr_Banisher
    bdlSatyr_Banisher.mUnitType = eUnittype.JungleCreep
    bdlSatyr_Banisher.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/f/f3/Satyr_Banisher.png"


    bdlSatyr_Banisher.mDuration = New ValueWrapper(-1) '- 1 for permanent
    bdlSatyr_Banisher.mLevel = New ValueWrapper(2)

    bdlSatyr_Banisher.mHealth = New ValueWrapper(300)
    'bdlSatyr_Banisher.mHealthIncrement = New ValueWrapper()
    bdlSatyr_Banisher.mHealthRegen = New ValueWrapper(0.5)

    bdlSatyr_Banisher.mMana = New ValueWrapper(500)
    bdlSatyr_Banisher.mManaRegen = New ValueWrapper(0)

    bdlSatyr_Banisher.mDamage.Add(New ValueWrapper(7))
    bdlSatyr_Banisher.mDamage.Add(New ValueWrapper(10))

    'bdlSatyr_Banisher.mDamageIncrement = New ValueWrapper()

    bdlSatyr_Banisher.mMagicResistance = New ValueWrapper(0)

    bdlSatyr_Banisher.mArmor = New ValueWrapper(0)
    bdlSatyr_Banisher.mArmorType = eArmorType.Heavy

    bdlSatyr_Banisher.mMoveSpeed = New ValueWrapper(330)
    bdlSatyr_Banisher.mCOllisionSize = New ValueWrapper(16)
    bdlSatyr_Banisher.mSightrange.Add(New ValueWrapper(800))
    bdlSatyr_Banisher.mSightrange.Add(New ValueWrapper(800))

    bdlSatyr_Banisher.mAttackType = eAttackType.Ranged
    bdlSatyr_Banisher.mAttackSubType = eAttackSubType.Piercing

    bdlSatyr_Banisher.mAttackDuration.Add(New ValueWrapper(0.3))
    bdlSatyr_Banisher.mAttackDuration.Add(New ValueWrapper(0.3))

    bdlSatyr_Banisher.mCastDuration = New List(Of ValueWrapper)
    bdlSatyr_Banisher.mCastDuration.Add(New ValueWrapper(0.2))
    bdlSatyr_Banisher.mCastDuration.Add(New ValueWrapper(0.51))

    bdlSatyr_Banisher.mMissileSpeed = New ValueWrapper(1500)
    bdlSatyr_Banisher.mBaseAttacktime = New ValueWrapper(1.7)

    bdlSatyr_Banisher.mBounty.Add(New ValueWrapper(15))
    bdlSatyr_Banisher.mBounty.Add(New ValueWrapper(17))
    bdlSatyr_Banisher.mXp = New ValueWrapper(41)


    bdlSatyr_Banisher.mAbilityNames.Add(eAbilityName.abSatyr_Banisher_Purge)

    Me.Add(eCreepName.untSatyr_Banisher, bdlSatyr_Banisher)
    '--------------------------------------------------------------



    Dim bdlSatyr_Mindstealer As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Satyr Mindstealer
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlSatyr_Mindstealer.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Satyr Midstealer", eEntity.Creepbundle)

    bdlSatyr_Mindstealer.mName = eCreepName.untSatyr_Mindstealer
    bdlSatyr_Mindstealer.mUnitType = eUnittype.JungleCreep
    bdlSatyr_Mindstealer.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/3/3f/Satyr_Mindstealer.png?version=9938029f677145aa2b821ae0489525e8"


    bdlSatyr_Mindstealer.mDuration = New ValueWrapper(-1) '- 1 for permanent
    bdlSatyr_Mindstealer.mLevel = New ValueWrapper(4)

    bdlSatyr_Mindstealer.mHealth = New ValueWrapper(600)
    'bdlSatyr_Mindstealer.mHealthIncrement = New ValueWrapper()
    bdlSatyr_Mindstealer.mHealthRegen = New ValueWrapper(0.5)

    bdlSatyr_Mindstealer.mMana = New ValueWrapper(600)
    bdlSatyr_Mindstealer.mManaRegen = New ValueWrapper(0)

    bdlSatyr_Mindstealer.mDamage.Add(New ValueWrapper(24))
    bdlSatyr_Mindstealer.mDamage.Add(New ValueWrapper(27))

    'bdlSatyr_Mindstealer.mDamageIncrement = New ValueWrapper()

    bdlSatyr_Mindstealer.mMagicResistance = New ValueWrapper(0)

    bdlSatyr_Mindstealer.mArmor = New ValueWrapper(1)
    bdlSatyr_Mindstealer.mArmorType = eArmorType.Heavy

    bdlSatyr_Mindstealer.mMoveSpeed = New ValueWrapper(270)
    bdlSatyr_Mindstealer.mCOllisionSize = New ValueWrapper(16)
    bdlSatyr_Mindstealer.mSightrange.Add(New ValueWrapper(800))
    bdlSatyr_Mindstealer.mSightrange.Add(New ValueWrapper(800))

    bdlSatyr_Mindstealer.mAttackType = eAttackType.Ranged
    bdlSatyr_Mindstealer.mAttackSubType = eAttackSubType.Normal

    bdlSatyr_Mindstealer.mAttackDuration.Add(New ValueWrapper(0.3))
    bdlSatyr_Mindstealer.mAttackDuration.Add(New ValueWrapper(0.3))

    bdlSatyr_Mindstealer.mCastDuration = New List(Of ValueWrapper)
    bdlSatyr_Mindstealer.mCastDuration.Add(New ValueWrapper(0.5))
    bdlSatyr_Mindstealer.mCastDuration.Add(New ValueWrapper(1.2))

    'bdlSatyr_Mindstealer.mMissileSpeed = New ValueWrapper()
    bdlSatyr_Mindstealer.mBaseAttacktime = New ValueWrapper(1.35)

    bdlSatyr_Mindstealer.mBounty.Add(New ValueWrapper(27))
    bdlSatyr_Mindstealer.mBounty.Add(New ValueWrapper(33))
    bdlSatyr_Mindstealer.mXp = New ValueWrapper(62)


    bdlSatyr_Mindstealer.mAbilityNames.Add(eAbilityName.abSatyr_Mindstealer_Mana_Burn)

    Me.Add(eCreepName.untSatyr_Mindstealer, bdlSatyr_Mindstealer)
    '--------------------------------------------------------------



    Dim bdlOgre_Bruiser As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Ogre Bruiser
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlOgre_Bruiser.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Ogre Bruiser", eEntity.Creepbundle)

    bdlOgre_Bruiser.mName = eCreepName.untOgre_Bruiser
    bdlOgre_Bruiser.mUnitType = eUnittype.JungleCreep
    bdlOgre_Bruiser.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/c/cd/Ogre_Mauler.jpg?version=31ef178550f80e5c55a154d429ae49e5"


    bdlOgre_Bruiser.mDuration = New ValueWrapper(-1) '- 1 for permanent
    bdlOgre_Bruiser.mLevel = New ValueWrapper(2)

    bdlOgre_Bruiser.mHealth = New ValueWrapper(850)
    'bdlOgre_Bruiser.mHealthIncrement = New ValueWrapper()
    bdlOgre_Bruiser.mHealthRegen = New ValueWrapper(0.5)

    'bdlOgre_Bruiser.mMana = New ValueWrapper()
    'bdlOgre_Bruiser.mManaRegen = New ValueWrapper()

    bdlOgre_Bruiser.mDamage.Add(New ValueWrapper(24))
    bdlOgre_Bruiser.mDamage.Add(New ValueWrapper(27))

    'bdlOgre_Bruiser.mDamageIncrement = New ValueWrapper()

    bdlOgre_Bruiser.mMagicResistance = New ValueWrapper(0)

    bdlOgre_Bruiser.mArmor = New ValueWrapper(1)
    bdlOgre_Bruiser.mArmorType = eArmorType.Heavy

    bdlOgre_Bruiser.mMoveSpeed = New ValueWrapper(270)
    bdlOgre_Bruiser.mCOllisionSize = New ValueWrapper(16)
    bdlOgre_Bruiser.mSightrange.Add(New ValueWrapper(800))
    bdlOgre_Bruiser.mSightrange.Add(New ValueWrapper(800))

    bdlOgre_Bruiser.mAttackType = eAttackType.Melee
    bdlOgre_Bruiser.mAttackSubType = eAttackSubType.Normal

    bdlOgre_Bruiser.mAttackDuration.Add(New ValueWrapper(0.3))
    bdlOgre_Bruiser.mAttackDuration.Add(New ValueWrapper(0.3))

    bdlOgre_Bruiser.mCastDuration = New List(Of ValueWrapper)
    bdlOgre_Bruiser.mCastDuration.Add(New ValueWrapper(0.527))
    bdlOgre_Bruiser.mCastDuration.Add(New ValueWrapper(0.673))


    'bdlOgre_Bruiser.mMissileSpeed = New ValueWrapper()
    bdlOgre_Bruiser.mBaseAttacktime = New ValueWrapper(1.35)

    bdlOgre_Bruiser.mBounty.Add(New ValueWrapper(24))
    bdlOgre_Bruiser.mBounty.Add(New ValueWrapper(27))
    bdlOgre_Bruiser.mXp = New ValueWrapper(41)


    'bdlOgre_Bruiser.mAbilityNames.Add(eAbilityName)

    Me.Add(eCreepName.untOgre_Bruiser, bdlOgre_Bruiser)
    '--------------------------------------------------------------



    Dim bdlOgre_Frostmage As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Ogre Frostmage
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlOgre_Frostmage.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Ogre Frostmage", eEntity.Creepbundle)

    bdlOgre_Frostmage.mName = eCreepName.untOgre_Frostmage
    bdlOgre_Frostmage.mUnitType = eUnittype.JungleCreep
    bdlOgre_Frostmage.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/1/1f/Ogre_Magi.jpg/200px-Ogre_Magi.jpg.png?version=8f881f7a1e307f0c79da82930b85603e"


    bdlOgre_Frostmage.mDuration = New ValueWrapper(-1) '- 1 for permanent
    bdlOgre_Frostmage.mLevel = New ValueWrapper(3)

    bdlOgre_Frostmage.mHealth = New ValueWrapper(600)
    'bdlOgre_Frostmage.mHealthIncrement = New ValueWrapper()
    bdlOgre_Frostmage.mHealthRegen = New ValueWrapper(0.5)

    bdlOgre_Frostmage.mMana = New ValueWrapper(400)
    bdlOgre_Frostmage.mManaRegen = New ValueWrapper(0)

    bdlOgre_Frostmage.mDamage.Add(New ValueWrapper(24))
    bdlOgre_Frostmage.mDamage.Add(New ValueWrapper(27))

    'bdlOgre_Frostmage.mDamageIncrement = New ValueWrapper()

    bdlOgre_Frostmage.mMagicResistance = New ValueWrapper(0)

    bdlOgre_Frostmage.mArmor = New ValueWrapper(0)
    bdlOgre_Frostmage.mArmorType = eArmorType.Heavy

    bdlOgre_Frostmage.mMoveSpeed = New ValueWrapper(270)
    bdlOgre_Frostmage.mCOllisionSize = New ValueWrapper(16)
    bdlOgre_Frostmage.mSightrange.Add(New ValueWrapper(800))
    bdlOgre_Frostmage.mSightrange.Add(New ValueWrapper(800))

    bdlOgre_Frostmage.mAttackType = eAttackType.Ranged
    bdlOgre_Frostmage.mAttackSubType = eAttackSubType.Normal

    bdlOgre_Frostmage.mAttackDuration.Add(New ValueWrapper(0.3))
    bdlOgre_Frostmage.mAttackDuration.Add(New ValueWrapper(0.3))

    bdlOgre_Frostmage.mCastDuration = New List(Of ValueWrapper)
    bdlOgre_Frostmage.mCastDuration.Add(New ValueWrapper(0.56))
    bdlOgre_Frostmage.mCastDuration.Add(New ValueWrapper(0.51))

    'bdlOgre_Frostmage.mMissileSpeed = New ValueWrapper()
    bdlOgre_Frostmage.mBaseAttacktime = New ValueWrapper(1.35)

    bdlOgre_Frostmage.mBounty.Add(New ValueWrapper(43))
    bdlOgre_Frostmage.mBounty.Add(New ValueWrapper(61))
    bdlOgre_Frostmage.mXp = New ValueWrapper(62)


    bdlOgre_Frostmage.mAbilityNames.Add(eAbilityName.abIce_Armor)

    Me.Add(eCreepName.untOgre_Frostmage, bdlOgre_Frostmage)
    '--------------------------------------------------------------



    Dim bdlMud_Golem As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Mud Golem
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlMud_Golem.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Mud Golem", eEntity.Creepbundle)

    bdlMud_Golem.mName = eCreepName.untMud_Golem
    bdlMud_Golem.mUnitType = eUnittype.JungleCreep
    bdlMud_Golem.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/b/bd/Mud_Golem.jpg?version=a1c6c03caecaf5e2ff8e936df5cd1c9d"


    bdlMud_Golem.mDuration = New ValueWrapper(-1) '- 1 for permanent
    bdlMud_Golem.mLevel = New ValueWrapper(5)

    bdlMud_Golem.mHealth = New ValueWrapper(800)
    'bdlMud_Golem.mHealthIncrement = New ValueWrapper()
    bdlMud_Golem.mHealthRegen = New ValueWrapper(0.5)

    bdlMud_Golem.mMana = New ValueWrapper(400)
    bdlMud_Golem.mManaRegen = New ValueWrapper(1)

    bdlMud_Golem.mDamage.Add(New ValueWrapper(29))
    bdlMud_Golem.mDamage.Add(New ValueWrapper(33))

    'bdlMud_Golem.mDamageIncrement = New ValueWrapper()

    bdlMud_Golem.mMagicResistance = New ValueWrapper(0)

    bdlMud_Golem.mArmor = New ValueWrapper(2)
    bdlMud_Golem.mArmorType = eArmorType.Heavy

    bdlMud_Golem.mMoveSpeed = New ValueWrapper(270)
    bdlMud_Golem.mCOllisionSize = New ValueWrapper(16)
    bdlMud_Golem.mSightrange.Add(New ValueWrapper(800))
    bdlMud_Golem.mSightrange.Add(New ValueWrapper(800))

    bdlMud_Golem.mAttackType = eAttackType.Melee
    bdlMud_Golem.mAttackSubType = eAttackSubType.Normal

    bdlMud_Golem.mAttackDuration.Add(New ValueWrapper(0.5))
    bdlMud_Golem.mAttackDuration.Add(New ValueWrapper(0.3))

    bdlMud_Golem.mCastDuration = New List(Of ValueWrapper)
    bdlMud_Golem.mCastDuration.Add(New ValueWrapper(0.47))
    bdlMud_Golem.mCastDuration.Add(New ValueWrapper(0.56))

    'bdlMud_Golem.mMissileSpeed = New ValueWrapper()
    bdlMud_Golem.mBaseAttacktime = New ValueWrapper(1.35)

    bdlMud_Golem.mBounty.Add(New ValueWrapper(54))
    bdlMud_Golem.mBounty.Add(New ValueWrapper(62))
    bdlMud_Golem.mXp = New ValueWrapper(88)


    bdlMud_Golem.mAbilityNames.Add(eAbilityName.abMud_Golem_Spell_Immunity)

    Me.Add(eCreepName.untMud_Golem, bdlMud_Golem)
    '--------------------------------------------------------------



    Dim bdlSatyr_Tormentor As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Satyr Tormentor
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlSatyr_Tormentor.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Satyr Tormentor", eEntity.Creepbundle)

    bdlSatyr_Tormentor.mName = eCreepName.untSatyr_Tormentor
    bdlSatyr_Tormentor.mUnitType = eUnittype.JungleCreep
    bdlSatyr_Tormentor.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/8/8a/Satyr_Tormenter.png/200px-Satyr_Tormenter.png?version=e8ef0ffeb61ca26d3e4a86d0df81dc25"


    bdlSatyr_Tormentor.mDuration = New ValueWrapper(-1) '- 1 for permanent
    bdlSatyr_Tormentor.mLevel = New ValueWrapper(6)

    bdlSatyr_Tormentor.mHealth = New ValueWrapper(1100)
    'bdlSatyr_Tormentor.mHealthIncrement = New ValueWrapper()
    bdlSatyr_Tormentor.mHealthRegen = New ValueWrapper(1)

    bdlSatyr_Tormentor.mMana = New ValueWrapper(600)
    bdlSatyr_Tormentor.mManaRegen = New ValueWrapper(0)

    bdlSatyr_Tormentor.mDamage.Add(New ValueWrapper(49))
    bdlSatyr_Tormentor.mDamage.Add(New ValueWrapper(55))

    'bdlSatyr_Tormentor.mDamageIncrement = New ValueWrapper()

    bdlSatyr_Tormentor.mMagicResistance = New ValueWrapper(0)

    bdlSatyr_Tormentor.mArmor = New ValueWrapper(0)
    bdlSatyr_Tormentor.mArmorType = eArmorType.Heavy

    bdlSatyr_Tormentor.mMoveSpeed = New ValueWrapper(290)
    bdlSatyr_Tormentor.mCOllisionSize = New ValueWrapper(16)
    bdlSatyr_Tormentor.mSightrange.Add(New ValueWrapper(800))
    bdlSatyr_Tormentor.mSightrange.Add(New ValueWrapper(800))

    bdlSatyr_Tormentor.mAttackType = eAttackType.Melee
    bdlSatyr_Tormentor.mAttackSubType = eAttackSubType.Chaos

    bdlSatyr_Tormentor.mAttackDuration.Add(New ValueWrapper(97))
    bdlSatyr_Tormentor.mAttackDuration.Add(New ValueWrapper(111))

    'bdlSatyr_Tormentor.mMissileSpeed = New ValueWrapper()
    bdlSatyr_Tormentor.mBaseAttacktime = New ValueWrapper(1.35)

    bdlSatyr_Tormentor.mBounty.Add(New ValueWrapper(97))
    bdlSatyr_Tormentor.mBounty.Add(New ValueWrapper(111))
    bdlSatyr_Tormentor.mXp = New ValueWrapper(119)


    bdlSatyr_Tormentor.mAbilityNames.Add(eAbilityName.abSatyr_Tormentor_Shockwave)

    Me.Add(eCreepName.untSatyr_Tormentor, bdlSatyr_Tormentor)
    '--------------------------------------------------------------



    Dim bdlHellbear As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Hellbear
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlHellbear.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Hellbear", eEntity.Creepbundle)

    bdlHellbear.mName = eCreepName.untHellbear
    bdlHellbear.mUnitType = eUnittype.JungleCreep
    bdlHellbear.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/3/3c/Furbolg_Champion.jpg?version=6011ad6c2f85531192a547586b2e1737"


    bdlHellbear.mDuration = New ValueWrapper(-1) '- 1 for permanent
    bdlHellbear.mLevel = New ValueWrapper(4)

    bdlHellbear.mHealth = New ValueWrapper(950)
    'bdlHellbear.mHealthIncrement = New ValueWrapper()
    bdlHellbear.mHealthRegen = New ValueWrapper(0.5)

    'bdlHellbear.mMana = New ValueWrapper()
    'bdlHellbear.mManaRegen = New ValueWrapper()

    bdlHellbear.mDamage.Add(New ValueWrapper(39))
    bdlHellbear.mDamage.Add(New ValueWrapper(44))

    'bdlHellbear.mDamageIncrement = New ValueWrapper()

    bdlHellbear.mMagicResistance = New ValueWrapper(0)

    bdlHellbear.mArmor = New ValueWrapper(3)
    bdlHellbear.mArmorType = eArmorType.Heavy

    bdlHellbear.mMoveSpeed = New ValueWrapper(320)
    bdlHellbear.mCOllisionSize = New ValueWrapper(16)
    bdlHellbear.mSightrange.Add(New ValueWrapper(800))
    bdlHellbear.mSightrange.Add(New ValueWrapper(800))

    bdlHellbear.mAttackType = eAttackType.Melee
    bdlHellbear.mAttackSubType = eAttackSubType.Chaos

    bdlHellbear.mAttackDuration.Add(New ValueWrapper(0.3))
    bdlHellbear.mAttackDuration.Add(New ValueWrapper(0.3))

    bdlHellbear.mCastDuration = New List(Of ValueWrapper)
    bdlHellbear.mCastDuration.Add(New ValueWrapper(0.5))
    bdlHellbear.mCastDuration.Add(New ValueWrapper(0.51))

    'bdlHellbear.mMissileSpeed = New ValueWrapper()
    bdlHellbear.mBaseAttacktime = New ValueWrapper(1.5)

    bdlHellbear.mBounty.Add(New ValueWrapper(60))
    bdlHellbear.mBounty.Add(New ValueWrapper(70))
    bdlHellbear.mXp = New ValueWrapper(88)


    'bdlHellbear.mAbilityNames.Add(eAbilityName)

    Me.Add(eCreepName.untHellbear, bdlHellbear)
    '--------------------------------------------------------------



    Dim bdlHellbear_Smasher As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Hellbear Smasher
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlHellbear_Smasher.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Hellbear Smasher", eEntity.Creepbundle)

    bdlHellbear_Smasher.mName = eCreepName.untHellbear_Smasher
    bdlHellbear_Smasher.mUnitType = eUnittype.JungleCreep
    bdlHellbear_Smasher.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/9/99/Furbolg_Ursa_Warrior.jpg?version=62829a5e20b4ffb4c918aa205a45c87f"


    bdlHellbear_Smasher.mDuration = New ValueWrapper(-1) '- 1 for permanent
    bdlHellbear_Smasher.mLevel = New ValueWrapper(5)

    bdlHellbear_Smasher.mHealth = New ValueWrapper(950)
    'bdlHellbear_Smasher.mHealthIncrement = New ValueWrapper()
    bdlHellbear_Smasher.mHealthRegen = New ValueWrapper(1)

    bdlHellbear_Smasher.mMana = New ValueWrapper(300)
    bdlHellbear_Smasher.mManaRegen = New ValueWrapper(0)

    bdlHellbear_Smasher.mDamage.Add(New ValueWrapper(76))
    bdlHellbear_Smasher.mDamage.Add(New ValueWrapper(88))

    'bdlHellbear_Smasher.mDamageIncrement = New ValueWrapper()

    bdlHellbear_Smasher.mMagicResistance = New ValueWrapper(0)

    bdlHellbear_Smasher.mArmor = New ValueWrapper(4)
    bdlHellbear_Smasher.mArmorType = eArmorType.Heavy

    bdlHellbear_Smasher.mMoveSpeed = New ValueWrapper(320)
    bdlHellbear_Smasher.mCOllisionSize = New ValueWrapper(16)
    bdlHellbear_Smasher.mSightrange.Add(New ValueWrapper(800))
    bdlHellbear_Smasher.mSightrange.Add(New ValueWrapper(800))

    bdlHellbear_Smasher.mAttackType = eAttackType.Melee
    bdlHellbear_Smasher.mAttackSubType = eAttackSubType.Chaos

    bdlHellbear_Smasher.mAttackDuration.Add(New ValueWrapper(0.3))
    bdlHellbear_Smasher.mAttackDuration.Add(New ValueWrapper(0.3))

    bdlHellbear_Smasher.mCastDuration = New List(Of ValueWrapper)
    bdlHellbear_Smasher.mCastDuration.Add(New ValueWrapper(0.5))
    bdlHellbear_Smasher.mCastDuration.Add(New ValueWrapper(0.51))

    'bdlHellbear_Smasher.mMissileSpeed = New ValueWrapper()
    bdlHellbear_Smasher.mBaseAttacktime = New ValueWrapper(1.55)

    bdlHellbear_Smasher.mBounty.Add(New ValueWrapper(76))
    bdlHellbear_Smasher.mBounty.Add(New ValueWrapper(88))
    bdlHellbear_Smasher.mXp = New ValueWrapper(119)


    bdlHellbear_Smasher.mAbilityNames.Add(eAbilityName.abHellbear_Smasher_Thunder_Clap)
    bdlHellbear_Smasher.mAbilityNames.Add(eAbilityName.abHellbear_Smasher_Swiftness_Aura)

    Me.Add(eCreepName.untHellbear_Smasher, bdlHellbear_Smasher)
    '--------------------------------------------------------------



    Dim bdlWildwing As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Wildwing
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlWildwing.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Wildwing", eEntity.Creepbundle)

    bdlWildwing.mName = eCreepName.untWildwing
    bdlWildwing.mUnitType = eUnittype.JungleCreep
    bdlWildwing.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/3/3e/Wildkin.jpg?version=adba6eac4fe721a95bbf7dad1739ff5d"


    bdlWildwing.mDuration = New ValueWrapper(-1) '- 1 for permanent
    bdlWildwing.mLevel = New ValueWrapper(1)

    bdlWildwing.mHealth = New ValueWrapper(350)
    'bdlWildwing.mHealthIncrement = New ValueWrapper()
    bdlWildwing.mHealthRegen = New ValueWrapper(0.5)

    'bdlWildwing.mMana = New ValueWrapper()
    'bdlWildwing.mManaRegen = New ValueWrapper()

    bdlWildwing.mDamage.Add(New ValueWrapper(20))
    bdlWildwing.mDamage.Add(New ValueWrapper(25))

    'bdlWildwing.mDamageIncrement = New ValueWrapper()

    bdlWildwing.mMagicResistance = New ValueWrapper(0)

    bdlWildwing.mArmor = New ValueWrapper(2)
    bdlWildwing.mArmorType = eArmorType.Heavy

    bdlWildwing.mMoveSpeed = New ValueWrapper(300)
    bdlWildwing.mCOllisionSize = New ValueWrapper(16)
    bdlWildwing.mSightrange.Add(New ValueWrapper(800))
    bdlWildwing.mSightrange.Add(New ValueWrapper(800))

    bdlWildwing.mAttackType = eAttackType.Melee
    bdlWildwing.mAttackSubType = eAttackSubType.Normal

    bdlWildwing.mAttackDuration.Add(New ValueWrapper(0.3))
    bdlWildwing.mAttackDuration.Add(New ValueWrapper(0.3))

    bdlWildwing.mCastDuration = New List(Of ValueWrapper)
    bdlWildwing.mCastDuration.Add(New ValueWrapper(0))
    bdlWildwing.mCastDuration.Add(New ValueWrapper(0.51))
    'bdlWildwing.mMissileSpeed = New ValueWrapper()
    bdlWildwing.mBaseAttacktime = New ValueWrapper(1.35)

    bdlWildwing.mBounty.Add(New ValueWrapper(15))
    bdlWildwing.mBounty.Add(New ValueWrapper(20))
    bdlWildwing.mXp = New ValueWrapper(25)


    'bdlWildwing.mAbilityNames.Add(eAbilityName.)

    Me.Add(eCreepName.untWildwing, bdlWildwing)
    '--------------------------------------------------------------



    Dim bdlWildwing_Ripper As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Wildwing Ripper
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlWildwing_Ripper.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Wildwing Ripper", eEntity.Creepbundle)

    bdlWildwing_Ripper.mName = eCreepName.untWildwing_Ripper
    bdlWildwing_Ripper.mUnitType = eUnittype.JungleCreep
    bdlWildwing_Ripper.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/1/15/Enraged_Wildkin.jpg?version=eb331117f21f7f1b9524956257f494b3"


    bdlWildwing_Ripper.mDuration = New ValueWrapper(-1) '- 1 for permanent
    bdlWildwing_Ripper.mLevel = New ValueWrapper(5)

    bdlWildwing_Ripper.mHealth = New ValueWrapper(950)
    'bdlWildwing_Ripper.mHealthIncrement = New ValueWrapper(0.5)
    bdlWildwing_Ripper.mHealthRegen = New ValueWrapper(0.5)

    bdlWildwing_Ripper.mMana = New ValueWrapper(400)
    bdlWildwing_Ripper.mManaRegen = New ValueWrapper(0)

    bdlWildwing_Ripper.mDamage.Add(New ValueWrapper(50))
    bdlWildwing_Ripper.mDamage.Add(New ValueWrapper(56))

    'bdlWildwing_Ripper.mDamageIncrement = New ValueWrapper()

    bdlWildwing_Ripper.mMagicResistance = New ValueWrapper(0)

    bdlWildwing_Ripper.mArmor = New ValueWrapper(4)
    bdlWildwing_Ripper.mArmorType = eArmorType.Heavy

    bdlWildwing_Ripper.mMoveSpeed = New ValueWrapper(320)
    bdlWildwing_Ripper.mCOllisionSize = New ValueWrapper(16)
    bdlWildwing_Ripper.mSightrange.Add(New ValueWrapper(800))
    bdlWildwing_Ripper.mSightrange.Add(New ValueWrapper(800))

    bdlWildwing_Ripper.mAttackType = eAttackType.Melee
    bdlWildwing_Ripper.mAttackSubType = eAttackSubType.Chaos

    bdlWildwing_Ripper.mAttackDuration.Add(New ValueWrapper(0.3))
    bdlWildwing_Ripper.mAttackDuration.Add(New ValueWrapper(0.3))

    bdlWildwing_Ripper.mCastDuration = New List(Of ValueWrapper)
    bdlWildwing_Ripper.mCastDuration.Add(New ValueWrapper(0.75))
    bdlWildwing_Ripper.mCastDuration.Add(New ValueWrapper(0.51))

    'bdlWildwing_Ripper.mMissileSpeed = New ValueWrapper()
    bdlWildwing_Ripper.mBaseAttacktime = New ValueWrapper(1.35)

    bdlWildwing_Ripper.mBounty.Add(New ValueWrapper(67))
    bdlWildwing_Ripper.mBounty.Add(New ValueWrapper(87))
    bdlWildwing_Ripper.mXp = New ValueWrapper(119)


    bdlWildwing_Ripper.mAbilityNames.Add(eAbilityName.abWildwing_Ripper_Tornado)
    bdlWildwing_Ripper.mAbilityNames.Add(eAbilityName.abWildwing_Ripper_Toughness_Aua)

    Me.Add(eCreepName.untWildwing_Ripper, bdlWildwing_Ripper)
    '--------------------------------------------------------------



    Dim bdlDark_Troll_Summoner As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Dark Troll Summoner
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlDark_Troll_Summoner.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Dark Troll Summoner", eEntity.Creepbundle)

    bdlDark_Troll_Summoner.mName = eCreepName.untDark_Troll_Summoner
    bdlDark_Troll_Summoner.mUnitType = eUnittype.JungleCreep
    bdlDark_Troll_Summoner.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/1/15/Dark_Troll_Warlord.jpg?version=050f372c596224372aa2f9d7ad54f39c"


    bdlDark_Troll_Summoner.mDuration = New ValueWrapper(-1) '- 1 for permanent
    bdlDark_Troll_Summoner.mLevel = New ValueWrapper(6)

    bdlDark_Troll_Summoner.mHealth = New ValueWrapper(1100)
    'bdlDark_Troll_Summoner.mHealthIncrement = New ValueWrapper()
    bdlDark_Troll_Summoner.mHealthRegen = New ValueWrapper(0.5)

    bdlDark_Troll_Summoner.mMana = New ValueWrapper(550)
    bdlDark_Troll_Summoner.mManaRegen = New ValueWrapper(0)

    bdlDark_Troll_Summoner.mDamage.Add(New ValueWrapper(49))
    bdlDark_Troll_Summoner.mDamage.Add(New ValueWrapper(54))

    'bdlDark_Troll_Summoner.mDamageIncrement = New ValueWrapper()

    bdlDark_Troll_Summoner.mMagicResistance = New ValueWrapper(0)

    bdlDark_Troll_Summoner.mArmor = New ValueWrapper(1)
    bdlDark_Troll_Summoner.mArmorType = eArmorType.Heavy

    bdlDark_Troll_Summoner.mMoveSpeed = New ValueWrapper(320)
    bdlDark_Troll_Summoner.mCOllisionSize = New ValueWrapper(16)
    bdlDark_Troll_Summoner.mSightrange.Add(New ValueWrapper(800))
    bdlDark_Troll_Summoner.mSightrange.Add(New ValueWrapper(800))

    bdlDark_Troll_Summoner.mAttackType = eAttackType.Ranged
    bdlDark_Troll_Summoner.mAttackSubType = eAttackSubType.Piercing

    bdlDark_Troll_Summoner.mAttackDuration.Add(New ValueWrapper(0.3))
    bdlDark_Troll_Summoner.mAttackDuration.Add(New ValueWrapper(0.3))

    bdlDark_Troll_Summoner.mCastDuration = New List(Of ValueWrapper)
    bdlDark_Troll_Summoner.mCastDuration.Add(New ValueWrapper(0.5))
    bdlDark_Troll_Summoner.mCastDuration.Add(New ValueWrapper(0.51))

    bdlDark_Troll_Summoner.mMissileSpeed = New ValueWrapper(1200)
    bdlDark_Troll_Summoner.mBaseAttacktime = New ValueWrapper(1.35)

    bdlDark_Troll_Summoner.mBounty.Add(New ValueWrapper(54))
    bdlDark_Troll_Summoner.mBounty.Add(New ValueWrapper(62))
    bdlDark_Troll_Summoner.mXp = New ValueWrapper(119)


    bdlDark_Troll_Summoner.mAbilityNames.Add(eAbilityName.abDark_Troll_Summoner_Ensnare)
    bdlDark_Troll_Summoner.mAbilityNames.Add(eAbilityName.abDark_Troll_Summoner_Raise_Dead)

    Me.Add(eCreepName.untDark_Troll_Summoner, bdlDark_Troll_Summoner)
    '--------------------------------------------------------------



    Dim bdlHill_Trll As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Hill Troll
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlHill_Trll.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: hill Troll", eEntity.Creepbundle)

    bdlHill_Trll.mName = eCreepName.untHill_Trll
    bdlHill_Trll.mUnitType = eUnittype.JungleCreep
    bdlHill_Trll.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/6/60/Dark_Troll.jpg?version=9333da8872d4cf7a92ef61302529a28b"


    bdlHill_Trll.mDuration = New ValueWrapper(-1) '- 1 for permanent
    bdlHill_Trll.mLevel = New ValueWrapper(3)

    bdlHill_Trll.mHealth = New ValueWrapper(500)
    'bdlHill_Trll.mHealthIncrement = New ValueWrapper()
    bdlHill_Trll.mHealthRegen = New ValueWrapper(0.5)

    'bdlHill_Trll.mMana = New ValueWrapper()
    'bdlHill_Trll.mManaRegen = New ValueWrapper()

    bdlHill_Trll.mDamage.Add(New ValueWrapper(24))
    bdlHill_Trll.mDamage.Add(New ValueWrapper(27))

    'bdlHill_Trll.mDamageIncrement = New ValueWrapper()

    bdlHill_Trll.mMagicResistance = New ValueWrapper(0)

    bdlHill_Trll.mArmor = New ValueWrapper(0)
    bdlHill_Trll.mArmorType = eArmorType.Medium

    bdlHill_Trll.mMoveSpeed = New ValueWrapper(270)
    bdlHill_Trll.mCOllisionSize = New ValueWrapper(16)
    bdlHill_Trll.mSightrange.Add(New ValueWrapper(800))
    bdlHill_Trll.mSightrange.Add(New ValueWrapper(800))

    bdlHill_Trll.mAttackType = eAttackType.Melee
    bdlHill_Trll.mAttackSubType = eAttackSubType.Piercing

    bdlHill_Trll.mAttackDuration.Add(New ValueWrapper(0.3))
    bdlHill_Trll.mAttackDuration.Add(New ValueWrapper(0.3))

    bdlHill_Trll.mCastDuration = New List(Of ValueWrapper)
    bdlHill_Trll.mCastDuration.Add(New ValueWrapper(0))
    bdlHill_Trll.mCastDuration.Add(New ValueWrapper(0.51))

    'bdlHill_Trll.mMissileSpeed = New ValueWrapper()
    bdlHill_Trll.mBaseAttacktime = New ValueWrapper(1.35)

    bdlHill_Trll.mBounty.Add(New ValueWrapper(26))
    bdlHill_Trll.mBounty.Add(New ValueWrapper(33))
    bdlHill_Trll.mXp = New ValueWrapper(62)


    'bdlHill_Trll.mAbilityNames.Add(eAbilityName)

    Me.Add(eCreepName.untHill_Trll, bdlHill_Trll)
    '--------------------------------------------------------------



    Dim bdlAncient_Black_Dragon As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Ancient Black Dragon
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlAncient_Black_Dragon.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Ancient Black Dragon", eEntity.Creepbundle)

    bdlAncient_Black_Dragon.mName = eCreepName.untAncient_Black_Dragon
    bdlAncient_Black_Dragon.mUnitType = eUnittype.AncientCreep
    bdlAncient_Black_Dragon.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/7/72/Black_Dragon.jpg?version=c7930a73c12854b2c40577fd5e36eb0f"


    bdlAncient_Black_Dragon.mDuration = New ValueWrapper(-1) '- 1 for permanent
    bdlAncient_Black_Dragon.mLevel = New ValueWrapper(6)

    bdlAncient_Black_Dragon.mHealth = New ValueWrapper(2000)
    'bdlAncient_Black_Dragon.mHealthIncrement = New ValueWrapper()
    bdlAncient_Black_Dragon.mHealthRegen = New ValueWrapper(2)

    'bdlAncient_Black_Dragon.mMana = New ValueWrapper()
    'bdlAncient_Black_Dragon.mManaRegen = New ValueWrapper()

    bdlAncient_Black_Dragon.mDamage.Add(New ValueWrapper(48))
    bdlAncient_Black_Dragon.mDamage.Add(New ValueWrapper(81))

    'bdlAncient_Black_Dragon.mDamageIncrement = New ValueWrapper()

    bdlAncient_Black_Dragon.mMagicResistance = New ValueWrapper(0)

    bdlAncient_Black_Dragon.mArmor = New ValueWrapper(6)
    bdlAncient_Black_Dragon.mArmorType = eArmorType.Heavy

    bdlAncient_Black_Dragon.mMoveSpeed = New ValueWrapper(300)
    bdlAncient_Black_Dragon.mCOllisionSize = New ValueWrapper(16)
    bdlAncient_Black_Dragon.mSightrange.Add(New ValueWrapper(800))
    bdlAncient_Black_Dragon.mSightrange.Add(New ValueWrapper(800))

    bdlAncient_Black_Dragon.mAttackType = eAttackType.Melee
    bdlAncient_Black_Dragon.mAttackSubType = eAttackSubType.Chaos

    bdlAncient_Black_Dragon.mAttackDuration.Add(New ValueWrapper(0.94))
    bdlAncient_Black_Dragon.mAttackDuration.Add(New ValueWrapper(0.56))

    bdlAncient_Black_Dragon.mCastDuration = New List(Of ValueWrapper)
    bdlAncient_Black_Dragon.mCastDuration.Add(New ValueWrapper(1))
    bdlAncient_Black_Dragon.mCastDuration.Add(New ValueWrapper(0.51))

    bdlAncient_Black_Dragon.mMissileSpeed = New ValueWrapper(1500)
    bdlAncient_Black_Dragon.mBaseAttacktime = New ValueWrapper(1.5)

    bdlAncient_Black_Dragon.mBounty.Add(New ValueWrapper(164))
    bdlAncient_Black_Dragon.mBounty.Add(New ValueWrapper(234))
    bdlAncient_Black_Dragon.mXp = New ValueWrapper(155)


    bdlAncient_Black_Dragon.mAbilityNames.Add(eAbilityName.abAncient_Black_Dragon_Splash_Attack)
    bdlAncient_Black_Dragon.mAbilityNames.Add(eAbilityName.abAncient_Black_Dragon_Spell_Immunity)

    Me.Add(eCreepName.untAncient_Black_Dragon, bdlAncient_Black_Dragon)
    '--------------------------------------------------------------



    Dim bdlAncient_Black_Drake As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Ancient Black Drake
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlAncient_Black_Drake.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Ancient Black Drake", eEntity.Creepbundle)

    bdlAncient_Black_Drake.mName = eCreepName.untAncient_Black_Drake
    bdlAncient_Black_Drake.mUnitType = eUnittype.AncientCreep
    bdlAncient_Black_Drake.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/c/cb/Black_Drake.jpg?version=b9003b254dc5190103d4dc4502950be0"


    bdlAncient_Black_Drake.mDuration = New ValueWrapper(-1) '- 1 for permanent
    bdlAncient_Black_Drake.mLevel = New ValueWrapper(3)

    bdlAncient_Black_Drake.mHealth = New ValueWrapper(950)
    'bdlAncient_Black_Drake.mHealthIncrement = New ValueWrapper(0.5)
    bdlAncient_Black_Drake.mHealthRegen = New ValueWrapper(0.5)

    'bdlAncient_Black_Drake.mMana = New ValueWrapper()
    'bdlAncient_Black_Drake.mManaRegen = New ValueWrapper()

    bdlAncient_Black_Drake.mDamage.Add(New ValueWrapper(34))
    bdlAncient_Black_Drake.mDamage.Add(New ValueWrapper(45))

    'bdlAncient_Black_Drake.mDamageIncrement = New ValueWrapper()

    bdlAncient_Black_Drake.mMagicResistance = New ValueWrapper(0)

    bdlAncient_Black_Drake.mArmor = New ValueWrapper(2)
    bdlAncient_Black_Drake.mArmorType = eArmorType.Heavy

    bdlAncient_Black_Drake.mMoveSpeed = New ValueWrapper(350)
    bdlAncient_Black_Drake.mCOllisionSize = New ValueWrapper(16)
    bdlAncient_Black_Drake.mSightrange.Add(New ValueWrapper(800))
    bdlAncient_Black_Drake.mSightrange.Add(New ValueWrapper(800))

    bdlAncient_Black_Drake.mAttackType = eAttackType.Ranged
    bdlAncient_Black_Drake.mAttackSubType = eAttackSubType.Piercing

    bdlAncient_Black_Drake.mAttackDuration.Add(New ValueWrapper(0.94))
    bdlAncient_Black_Drake.mAttackDuration.Add(New ValueWrapper(0.56))

    bdlAncient_Black_Drake.mCastDuration = New List(Of ValueWrapper)
    bdlAncient_Black_Drake.mCastDuration.Add(New ValueWrapper(1))
    bdlAncient_Black_Drake.mCastDuration.Add(New ValueWrapper(0.51))

    bdlAncient_Black_Drake.mMissileSpeed = New ValueWrapper(900)
    bdlAncient_Black_Drake.mBaseAttacktime = New ValueWrapper(1.8)

    bdlAncient_Black_Drake.mBounty.Add(New ValueWrapper(44))
    bdlAncient_Black_Drake.mBounty.Add(New ValueWrapper(56))
    bdlAncient_Black_Drake.mXp = New ValueWrapper(62)


    'bdlAncient_Black_Drake.mAbilityNames.Add(eAbilityName)

    Me.Add(eCreepName.untAncient_Black_Drake, bdlAncient_Black_Drake)
    '--------------------------------------------------------------



    Dim bdlAncient_Granite_Golem As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Ancient Granite Golem
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlAncient_Granite_Golem.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Ancient Granite Golem", eEntity.Creepbundle)

    bdlAncient_Granite_Golem.mName = eCreepName.untAncient_Granite_Golem
    bdlAncient_Granite_Golem.mUnitType = eUnittype.AncientCreep
    bdlAncient_Granite_Golem.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/5/56/Granite_Golem.jpg?version=902d66f4e9e70452d8c21d5c3e74d62d"


    bdlAncient_Granite_Golem.mDuration = New ValueWrapper(-1) '- 1 for permanent
    bdlAncient_Granite_Golem.mLevel = New ValueWrapper(6)

    bdlAncient_Granite_Golem.mHealth = New ValueWrapper(1700)
    'bdlAncient_Granite_Golem.mHealthIncrement = New ValueWrapper()
    bdlAncient_Granite_Golem.mHealthRegen = New ValueWrapper(1.5)

    bdlAncient_Granite_Golem.mMana = New ValueWrapper(600)
    bdlAncient_Granite_Golem.mManaRegen = New ValueWrapper(1.5)

    bdlAncient_Granite_Golem.mDamage.Add(New ValueWrapper(77))
    bdlAncient_Granite_Golem.mDamage.Add(New ValueWrapper(87))

    'bdlAncient_Granite_Golem.mDamageIncrement = New ValueWrapper()

    bdlAncient_Granite_Golem.mMagicResistance = New ValueWrapper(0)

    bdlAncient_Granite_Golem.mArmor = New ValueWrapper(8)
    bdlAncient_Granite_Golem.mArmorType = eArmorType.Heavy

    bdlAncient_Granite_Golem.mMoveSpeed = New ValueWrapper(270)
    bdlAncient_Granite_Golem.mCOllisionSize = New ValueWrapper(16)
    bdlAncient_Granite_Golem.mSightrange.Add(New ValueWrapper(800))
    bdlAncient_Granite_Golem.mSightrange.Add(New ValueWrapper(800))

    bdlAncient_Granite_Golem.mAttackType = eAttackType.Melee
    bdlAncient_Granite_Golem.mAttackSubType = eAttackSubType.Chaos

    bdlAncient_Granite_Golem.mAttackDuration.Add(New ValueWrapper(0.3))
    bdlAncient_Granite_Golem.mAttackDuration.Add(New ValueWrapper(0.5))

    bdlAncient_Granite_Golem.mCastDuration = New List(Of ValueWrapper)
    bdlAncient_Granite_Golem.mCastDuration.Add(New ValueWrapper(0.47))
    bdlAncient_Granite_Golem.mCastDuration.Add(New ValueWrapper(0.56))

    'bdlAncient_Granite_Golem.mMissileSpeed = New ValueWrapper()
    bdlAncient_Granite_Golem.mBaseAttacktime = New ValueWrapper(1.35)

    bdlAncient_Granite_Golem.mBounty.Add(New ValueWrapper(102))
    bdlAncient_Granite_Golem.mBounty.Add(New ValueWrapper(121))
    bdlAncient_Granite_Golem.mXp = New ValueWrapper(155)


    bdlAncient_Granite_Golem.mAbilityNames.Add(eAbilityName.abAncient_Granite_Golem_Granite_Aura)
    bdlAncient_Granite_Golem.mAbilityNames.Add(eAbilityName.abAncient_Granite_Golem_Spell_Immunity)

    Me.Add(eCreepName.untAncient_Granite_Golem, bdlAncient_Granite_Golem)
    '--------------------------------------------------------------



    Dim bdlAncient_Rock_Golem As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Ancient Rock Golem
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlAncient_Rock_Golem.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Ancient Rock Golem", eEntity.Creepbundle)

    bdlAncient_Rock_Golem.mName = eCreepName.untAncient_Rock_Golem
    bdlAncient_Rock_Golem.mUnitType = eUnittype.AncientCreep
    bdlAncient_Rock_Golem.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/4/4a/Rock_Golem.jpg?version=7b35c4dfa578f272ad68f9ee43e244f7"


    bdlAncient_Rock_Golem.mDuration = New ValueWrapper(-1) '- 1 for permanent
    bdlAncient_Rock_Golem.mLevel = New ValueWrapper(5)

    bdlAncient_Rock_Golem.mHealth = New ValueWrapper(800)
    'bdlAncient_Rock_Golem.mHealthIncrement = New ValueWrapper()
    bdlAncient_Rock_Golem.mHealthRegen = New ValueWrapper(0.5)

    bdlAncient_Rock_Golem.mMana = New ValueWrapper(400)
    bdlAncient_Rock_Golem.mManaRegen = New ValueWrapper(1)

    bdlAncient_Rock_Golem.mDamage.Add(New ValueWrapper(29))
    bdlAncient_Rock_Golem.mDamage.Add(New ValueWrapper(33))

    'bdlAncient_Rock_Golem.mDamageIncrement = New ValueWrapper()

    bdlAncient_Rock_Golem.mMagicResistance = New ValueWrapper(0)

    bdlAncient_Rock_Golem.mArmor = New ValueWrapper(4)
    bdlAncient_Rock_Golem.mArmorType = eArmorType.Heavy

    bdlAncient_Rock_Golem.mMoveSpeed = New ValueWrapper(270)
    bdlAncient_Rock_Golem.mCOllisionSize = New ValueWrapper(16)
    bdlAncient_Rock_Golem.mSightrange.Add(New ValueWrapper(800))
    bdlAncient_Rock_Golem.mSightrange.Add(New ValueWrapper(800))

    bdlAncient_Rock_Golem.mAttackType = eAttackType.Melee
    bdlAncient_Rock_Golem.mAttackSubType = eAttackSubType.Normal

    bdlAncient_Rock_Golem.mAttackDuration.Add(New ValueWrapper(0.3))
    bdlAncient_Rock_Golem.mAttackDuration.Add(New ValueWrapper(0.3))

    bdlAncient_Rock_Golem.mCastDuration = New List(Of ValueWrapper)
    bdlAncient_Rock_Golem.mCastDuration.Add(New ValueWrapper(0.47))
    bdlAncient_Rock_Golem.mCastDuration.Add(New ValueWrapper(0.56))

    'bdlAncient_Rock_Golem.mMissileSpeed = New ValueWrapper()
    bdlAncient_Rock_Golem.mBaseAttacktime = New ValueWrapper(1.35)

    bdlAncient_Rock_Golem.mBounty.Add(New ValueWrapper(54))
    bdlAncient_Rock_Golem.mBounty.Add(New ValueWrapper(62))
    bdlAncient_Rock_Golem.mXp = New ValueWrapper(119)


    bdlAncient_Rock_Golem.mAbilityNames.Add(eAbilityName.abAncient_Rock_Golem_Spell_Immunity)

    Me.Add(eCreepName.untAncient_Rock_Golem, bdlAncient_Rock_Golem)
    '--------------------------------------------------------------



    Dim bdlAncient_Thunderhide As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Ancient Thunderhide
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlAncient_Thunderhide.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Ancient Thunderhide", eEntity.Creepbundle)

    bdlAncient_Thunderhide.mName = eCreepName.untAncient_Thunderhide
    bdlAncient_Thunderhide.mUnitType = eUnittype.AncientCreep
    bdlAncient_Thunderhide.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/a/a4/Thunder_Lizard_big.jpg/200px-Thunder_Lizard_big.jpg.png?version=585a63357cd6ca552c29913428f5365d"


    bdlAncient_Thunderhide.mDuration = New ValueWrapper(-1) '- 1 for permanent
    bdlAncient_Thunderhide.mLevel = New ValueWrapper(6)

    bdlAncient_Thunderhide.mHealth = New ValueWrapper(1400)
    'bdlAncient_Thunderhide.mHealthIncrement = New ValueWrapper()
    bdlAncient_Thunderhide.mHealthRegen = New ValueWrapper(0.5)

    bdlAncient_Thunderhide.mMana = New ValueWrapper(400)
    bdlAncient_Thunderhide.mManaRegen = New ValueWrapper(1)

    bdlAncient_Thunderhide.mDamage.Add(New ValueWrapper(89))
    bdlAncient_Thunderhide.mDamage.Add(New ValueWrapper(97))

    'bdlAncient_Thunderhide.mDamageIncrement = New ValueWrapper(71)

    bdlAncient_Thunderhide.mMagicResistance = New ValueWrapper(0)

    bdlAncient_Thunderhide.mArmor = New ValueWrapper(2)
    bdlAncient_Thunderhide.mArmorType = eArmorType.Heavy

    bdlAncient_Thunderhide.mMoveSpeed = New ValueWrapper(270)
    bdlAncient_Thunderhide.mCOllisionSize = New ValueWrapper(16)
    bdlAncient_Thunderhide.mSightrange.Add(New ValueWrapper(1400))
    bdlAncient_Thunderhide.mSightrange.Add(New ValueWrapper(800))

    bdlAncient_Thunderhide.mAttackType = eAttackType.Melee
    bdlAncient_Thunderhide.mAttackSubType = eAttackSubType.Normal

    bdlAncient_Thunderhide.mAttackDuration.Add(New ValueWrapper(0.5))
    bdlAncient_Thunderhide.mAttackDuration.Add(New ValueWrapper(0.56))

    bdlAncient_Thunderhide.mCastDuration = New List(Of ValueWrapper)
    bdlAncient_Thunderhide.mCastDuration.Add(New ValueWrapper(0))
    bdlAncient_Thunderhide.mCastDuration.Add(New ValueWrapper(0.5))
    'bdlAncient_Thunderhide.mMissileSpeed = New ValueWrapper()
    bdlAncient_Thunderhide.mBaseAttacktime = New ValueWrapper(1.8)

    bdlAncient_Thunderhide.mBounty.Add(New ValueWrapper(89))
    bdlAncient_Thunderhide.mBounty.Add(New ValueWrapper(97))
    bdlAncient_Thunderhide.mXp = New ValueWrapper(155)


    bdlAncient_Thunderhide.mAbilityNames.Add(eAbilityName.abAncient_Thunderhide_Slam)
    bdlAncient_Thunderhide.mAbilityNames.Add(eAbilityName.abAncient_Thunderhide_Frenzy)
    bdlAncient_Thunderhide.mAbilityNames.Add(eAbilityName.abAncient_Thunderhide_Spell_Immunity)

    Me.Add(eCreepName.untAncient_Thunderhide, bdlAncient_Thunderhide)
    '--------------------------------------------------------------



    Dim bdlAncient_Rumblehide As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Ancient Rumblehide
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlAncient_Rumblehide.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Ancient Rumblehide", eEntity.Creepbundle)

    bdlAncient_Rumblehide.mName = eCreepName.untAncient_Rumblehide
    bdlAncient_Rumblehide.mUnitType = eUnittype.AncientCreep
    bdlAncient_Rumblehide.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/e/e0/Thunder_Lizard_small.jpg/200px-Thunder_Lizard_small.jpg?version=fc080e05ef7d43a3c21cd8a86409955f"


    bdlAncient_Rumblehide.mDuration = New ValueWrapper(-1) '- 1 for permanent
    bdlAncient_Rumblehide.mLevel = New ValueWrapper(5)

    bdlAncient_Rumblehide.mHealth = New ValueWrapper(800)
    'bdlAncient_Rumblehide.mHealthIncrement = New ValueWrapper()
    bdlAncient_Rumblehide.mHealthRegen = New ValueWrapper(0.5)

    bdlAncient_Rumblehide.mMana = New ValueWrapper(400)
    bdlAncient_Rumblehide.mManaRegen = New ValueWrapper(1)

    bdlAncient_Rumblehide.mDamage.Add(New ValueWrapper(79))
    bdlAncient_Rumblehide.mDamage.Add(New ValueWrapper(87))

    'bdlAncient_Rumblehide.mDamageIncrement = New ValueWrapper()

    bdlAncient_Rumblehide.mMagicResistance = New ValueWrapper(0)

    bdlAncient_Rumblehide.mArmor = New ValueWrapper(2)
    bdlAncient_Rumblehide.mArmorType = eArmorType.Heavy

    bdlAncient_Rumblehide.mMoveSpeed = New ValueWrapper(270)
    bdlAncient_Rumblehide.mCOllisionSize = New ValueWrapper(16)
    bdlAncient_Rumblehide.mSightrange.Add(New ValueWrapper(1400))
    bdlAncient_Rumblehide.mSightrange.Add(New ValueWrapper(800))

    bdlAncient_Rumblehide.mAttackType = eAttackType.Melee
    bdlAncient_Rumblehide.mAttackSubType = eAttackSubType.Normal

    bdlAncient_Rumblehide.mAttackDuration.Add(New ValueWrapper(0.5))
    bdlAncient_Rumblehide.mAttackDuration.Add(New ValueWrapper(0.56))

    bdlAncient_Rumblehide.mCastDuration = New List(Of ValueWrapper)
    bdlAncient_Rumblehide.mCastDuration.Add(New ValueWrapper(0.5))
    bdlAncient_Rumblehide.mCastDuration.Add(New ValueWrapper(0.5))

    'bdlAncient_Rumblehide.mMissileSpeed = New ValueWrapper()
    bdlAncient_Rumblehide.mBaseAttacktime = New ValueWrapper(1.8)

    bdlAncient_Rumblehide.mBounty.Add(New ValueWrapper(79))
    bdlAncient_Rumblehide.mBounty.Add(New ValueWrapper(87))
    bdlAncient_Rumblehide.mXp = New ValueWrapper(119)


    bdlAncient_Rumblehide.mAbilityNames.Add(eAbilityName.abAncient_Rumblehide_Spell_Immunity)

    Me.Add(eCreepName.untAncient_Rumblehide, bdlAncient_Rumblehide)
    '--------------------------------------------------------------



    Dim bdlRoshan As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Roshan
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlRoshan.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Roshan", eEntity.Creepbundle)

    bdlRoshan.mName = eCreepName.untRoshan
    bdlRoshan.mUnitType = eUnittype.AncientCreep
    bdlRoshan.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/5/5a/Roshan_Portrait.png?version=77c043bd1385759e636ab62f3dcc0eb8"


    bdlRoshan.mDuration = New ValueWrapper(-1) '- 1 for permanent
    bdlRoshan.mLevel = New ValueWrapper(30)

    bdlRoshan.mHealth = New ValueWrapper(7500)
    'bdlRoshan.mHealthIncrement = New ValueWrapper()
    bdlRoshan.mHealthRegen = New ValueWrapper(20)

    bdlRoshan.mMana = New ValueWrapper(0)
    bdlRoshan.mManaRegen = New ValueWrapper(0)

    bdlRoshan.mDamage.Add(New ValueWrapper(65))
    bdlRoshan.mDamage.Add(New ValueWrapper(65))

    'bdlRoshan.mDamageIncrement = New ValueWrapper()

    bdlRoshan.mMagicResistance = New ValueWrapper(0)

    bdlRoshan.mArmor = New ValueWrapper(4)
    bdlRoshan.mArmorType = eArmorType.Heavy

    bdlRoshan.mMoveSpeed = New ValueWrapper(270)
    bdlRoshan.mCOllisionSize = New ValueWrapper(32)
    bdlRoshan.mSightrange.Add(New ValueWrapper(1400))
    bdlRoshan.mSightrange.Add(New ValueWrapper(1400))

    bdlRoshan.mAttackType = eAttackType.Melee
    bdlRoshan.mAttackSubType = eAttackSubType.Chaos

    bdlRoshan.mAttackDuration.Add(New ValueWrapper(0.3))
    bdlRoshan.mAttackDuration.Add(New ValueWrapper(0.3))

    bdlRoshan.mCastDuration = New List(Of ValueWrapper)
    bdlRoshan.mCastDuration.Add(New ValueWrapper(0.47))
    bdlRoshan.mCastDuration.Add(New ValueWrapper(0.56))

    bdlRoshan.mMissileSpeed = New ValueWrapper(-1) 'instant
    bdlRoshan.mBaseAttacktime = New ValueWrapper(1)

    bdlRoshan.mBounty.Add(New ValueWrapper(150))
    bdlRoshan.mBounty.Add(New ValueWrapper(400))
    bdlRoshan.mXp = New ValueWrapper(1789)


    bdlRoshan.mAbilityNames.Add(eAbilityName.abRoshan_Spell_Block)
    bdlRoshan.mAbilityNames.Add(eAbilityName.abRoshan_Bash)
    bdlRoshan.mAbilityNames.Add(eAbilityName.abRoshan_Slam)
    bdlRoshan.mAbilityNames.Add(eAbilityName.abRoshan_Strength_Of_The_Immortal)

    Me.Add(eCreepName.untRoshan, bdlRoshan)
    '--------------------------------------------------------------



    Dim bdlTower_Tier_1 As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Tower Tier 1
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlTower_Tier_1.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Tower Tier 1", eEntity.Creepbundle)

    bdlTower_Tier_1.mName = eCreepName.untTower_Tier_1
    bdlTower_Tier_1.mUnitType = eUnittype.Tower
    bdlTower_Tier_1.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/2/22/Towers.jpg/350px-Towers.jpg.png?version=ef50e44c07550f06b0bf0964ec92fa29"


    bdlTower_Tier_1.mDuration = New ValueWrapper(-1) '- 1 for permanent
    'bdlTower_Tier_1.mLevel = New ValueWrapper()

    bdlTower_Tier_1.mHealth = New ValueWrapper(1300)
    'bdlTower_Tier_1.mHealthIncrement = New ValueWrapper()
    'bdlTower_Tier_1.mHealthRegen = New ValueWrapper()

    'bdlTower_Tier_1.mMana = New ValueWrapper()
    'bdlTower_Tier_1.mManaRegen = New ValueWrapper()

    bdlTower_Tier_1.mDamage.Add(New ValueWrapper(100))
    bdlTower_Tier_1.mDamage.Add(New ValueWrapper(120))

    'bdlTower_Tier_1.mDamageIncrement = New ValueWrapper()

    bdlTower_Tier_1.mMagicResistance = New ValueWrapper(0)

    bdlTower_Tier_1.mArmor = New ValueWrapper(20)
    bdlTower_Tier_1.mArmorType = eArmorType.Fortified

    bdlTower_Tier_1.mMoveSpeed = New ValueWrapper(0)
    bdlTower_Tier_1.mCOllisionSize = New ValueWrapper(24)
    bdlTower_Tier_1.mSightrange.Add(New ValueWrapper(1800))
    bdlTower_Tier_1.mSightrange.Add(New ValueWrapper(800))

    bdlTower_Tier_1.mAttackType = eAttackType.Ranged
    bdlTower_Tier_1.mAttackSubType = eAttackSubType.Siege

    'bdlTower_Tier_1.mAttackDuration.Add(New ValueWrapper())
    'bdlTower_Tier_1.mAttackDuration.Add(New ValueWrapper())

    'bdlTower_Tier_1.mMissileSpeed = New ValueWrapper()
    bdlTower_Tier_1.mBaseAttacktime = New ValueWrapper(1)

    bdlTower_Tier_1.mBounty.Add(New ValueWrapper(160))
    bdlTower_Tier_1.mBounty.Add(New ValueWrapper(80))
    bdlTower_Tier_1.mXp = New ValueWrapper(25)


    'bdlTower_Tier_1.mAbilityNames.Add(eAbilityName)

    Me.Add(eCreepName.untTower_Tier_1, bdlTower_Tier_1)
    '--------------------------------------------------------------



    Dim bdlTower_Tier_2 As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Tower Tier 2
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlTower_Tier_2.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Tower Tier 2", eEntity.Creepbundle)

    bdlTower_Tier_2.mName = eCreepName.untTower_Tier_2
    bdlTower_Tier_2.mUnitType = eUnittype.Tower
    bdlTower_Tier_2.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/2/22/Towers.jpg/350px-Towers.jpg.png?version=ef50e44c07550f06b0bf0964ec92fa29"


    bdlTower_Tier_2.mDuration = New ValueWrapper(-1) '- 1 for permanent
    'bdlTower_Tier_2.mLevel = New ValueWrapper()

    bdlTower_Tier_2.mHealth = New ValueWrapper(1600)
    'bdlTower_Tier_2.mHealthIncrement = New ValueWrapper()
    'bdlTower_Tier_2.mHealthRegen = New ValueWrapper()

    'bdlTower_Tier_2.mMana = New ValueWrapper()
    'bdlTower_Tier_2.mManaRegen = New ValueWrapper()

    bdlTower_Tier_2.mDamage.Add(New ValueWrapper(120))
    bdlTower_Tier_2.mDamage.Add(New ValueWrapper(140))

    'bdlTower_Tier_2.mDamageIncrement = New ValueWrapper()

    bdlTower_Tier_2.mMagicResistance = New ValueWrapper(0)

    bdlTower_Tier_2.mArmor = New ValueWrapper(25)
    bdlTower_Tier_2.mArmorType = eArmorType.Fortified

    bdlTower_Tier_2.mMoveSpeed = New ValueWrapper(0)
    bdlTower_Tier_2.mCOllisionSize = New ValueWrapper(24)
    bdlTower_Tier_2.mSightrange.Add(New ValueWrapper(1800))
    bdlTower_Tier_2.mSightrange.Add(New ValueWrapper(800))

    bdlTower_Tier_2.mAttackType = eAttackType.Ranged
    bdlTower_Tier_2.mAttackSubType = eAttackSubType.Siege

    'bdlTower_Tier_2.mAttackDuration.Add(New ValueWrapper())
    'bdlTower_Tier_2.mAttackDuration.Add(New ValueWrapper())

    'bdlTower_Tier_2.mMissileSpeed = New ValueWrapper()
    bdlTower_Tier_2.mBaseAttacktime = New ValueWrapper(0.95)

    bdlTower_Tier_2.mBounty.Add(New ValueWrapper(200))
    bdlTower_Tier_2.mBounty.Add(New ValueWrapper(100))
    bdlTower_Tier_2.mXp = New ValueWrapper(25)


    'bdlTower_Tier_2.mAbilityNames.Add(eAbilityName)

    Me.Add(eCreepName.untTower_Tier_2, bdlTower_Tier_2)
    '--------------------------------------------------------------



    Dim bdlTower_Tier_3 As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Tower Tier 3
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlTower_Tier_3.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Tower Tier 3", eEntity.Creepbundle)

    bdlTower_Tier_3.mName = eCreepName.untTower_Tier_3
    bdlTower_Tier_3.mUnitType = eUnittype.Tower
    bdlTower_Tier_3.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/2/22/Towers.jpg/350px-Towers.jpg.png?version=ef50e44c07550f06b0bf0964ec92fa29"


    bdlTower_Tier_3.mDuration = New ValueWrapper(-1) '- 1 for permanent
    'bdlTower_Tier_3.mLevel = New ValueWrapper()

    bdlTower_Tier_3.mHealth = New ValueWrapper(1600)
    'bdlTower_Tier_3.mHealthIncrement = New ValueWrapper()
    'bdlTower_Tier_3.mHealthRegen = New ValueWrapper()

    'bdlTower_Tier_3.mMana = New ValueWrapper()
    'bdlTower_Tier_3.mManaRegen = New ValueWrapper()

    bdlTower_Tier_3.mDamage.Add(New ValueWrapper(122))
    bdlTower_Tier_3.mDamage.Add(New ValueWrapper(182))

    'bdlTower_Tier_3.mDamageIncrement = New ValueWrapper()

    bdlTower_Tier_3.mMagicResistance = New ValueWrapper(0)

    bdlTower_Tier_3.mArmor = New ValueWrapper(25)
    bdlTower_Tier_3.mArmorType = eArmorType.Fortified

    bdlTower_Tier_3.mMoveSpeed = New ValueWrapper(0)
    bdlTower_Tier_3.mCOllisionSize = New ValueWrapper(24)
    bdlTower_Tier_3.mSightrange.Add(New ValueWrapper(1800))
    bdlTower_Tier_3.mSightrange.Add(New ValueWrapper(800))

    bdlTower_Tier_3.mAttackType = eAttackType.Ranged
    bdlTower_Tier_3.mAttackSubType = eAttackSubType.Siege

    'bdlTower_Tier_3.mAttackDuration.Add(New ValueWrapper())
    'bdlTower_Tier_3.mAttackDuration.Add(New ValueWrapper())

    'bdlTower_Tier_3.mMissileSpeed = New ValueWrapper()
    bdlTower_Tier_3.mBaseAttacktime = New ValueWrapper(0.95)

    bdlTower_Tier_3.mBounty.Add(New ValueWrapper(240))
    bdlTower_Tier_3.mBounty.Add(New ValueWrapper(120))
    bdlTower_Tier_3.mXp = New ValueWrapper(25)


    'bdlTower_Tier_3.mAbilityNames.Add(eAbilityName)

    Me.Add(eCreepName.untTower_Tier_3, bdlTower_Tier_3)
    '--------------------------------------------------------------



    Dim bdlTower_Tier_4 As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Tower Tier 4
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlTower_Tier_4.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Tower Tier 4", eEntity.Creepbundle)

    bdlTower_Tier_4.mName = eCreepName.untTower_Tier_4
    bdlTower_Tier_4.mUnitType = eUnittype.Tower
    bdlTower_Tier_4.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/2/22/Towers.jpg/350px-Towers.jpg.png?version=ef50e44c07550f06b0bf0964ec92fa29"


    bdlTower_Tier_4.mDuration = New ValueWrapper(-1) '- 1 for permanent
    'bdlTower_Tier_4.mLevel = New ValueWrapper()

    bdlTower_Tier_4.mHealth = New ValueWrapper(1600)
    'bdlTower_Tier_4.mHealthIncrement = New ValueWrapper()
    'bdlTower_Tier_4.mHealthRegen = New ValueWrapper()

    'bdlTower_Tier_4.mMana = New ValueWrapper()
    'bdlTower_Tier_4.mManaRegen = New ValueWrapper()

    bdlTower_Tier_4.mDamage.Add(New ValueWrapper(122))
    bdlTower_Tier_4.mDamage.Add(New ValueWrapper(182))

    'bdlTower_Tier_4.mDamageIncrement = New ValueWrapper()

    bdlTower_Tier_4.mMagicResistance = New ValueWrapper(0)

    bdlTower_Tier_4.mArmor = New ValueWrapper(30)
    bdlTower_Tier_4.mArmorType = eArmorType.Fortified

    bdlTower_Tier_4.mMoveSpeed = New ValueWrapper(0)
    bdlTower_Tier_4.mCOllisionSize = New ValueWrapper(24)
    bdlTower_Tier_4.mSightrange.Add(New ValueWrapper(1800))
    bdlTower_Tier_4.mSightrange.Add(New ValueWrapper(800))

    bdlTower_Tier_4.mAttackType = eAttackType.Ranged
    bdlTower_Tier_4.mAttackSubType = eAttackSubType.Siege

    'bdlTower_Tier_4.mAttackDuration.Add(New ValueWrapper())
    'bdlTower_Tier_4.mAttackDuration.Add(New ValueWrapper())

    'bdlTower_Tier_4.mMissileSpeed = New ValueWrapper()
    bdlTower_Tier_4.mBaseAttacktime = New ValueWrapper(0.95)

    bdlTower_Tier_4.mBounty.Add(New ValueWrapper(280))
    bdlTower_Tier_4.mBounty.Add(New ValueWrapper(140))
    bdlTower_Tier_4.mXp = New ValueWrapper(25)


    'bdlTower_Tier_4.mAbilityNames.Add(eAbilityName)

    Me.Add(eCreepName.untTower_Tier_4, bdlTower_Tier_4)
    '--------------------------------------------------------------



    Dim bdlAncient As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Ancient
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlAncient.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Ancient", eEntity.Creepbundle)

    bdlAncient.mName = eCreepName.untAncient
    bdlAncient.mUnitType = eUnittype.Ancient
    bdlAncient.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/1/1d/Ancients.jpg/350px-Ancients.jpg.png?version=85846d5664badd1de27a589591099851"


    bdlAncient.mDuration = New ValueWrapper(-1) '- 1 for permanent
    'bdlAncient.mLevel = New ValueWrapper()

    bdlAncient.mHealth = New ValueWrapper(4250)
    'bdlAncient.mHealthIncrement = New ValueWrapper()
    bdlAncient.mHealthRegen = New ValueWrapper(3)

    'bdlAncient.mMana = New ValueWrapper()
    'bdlAncient.mManaRegen = New ValueWrapper()

    'bdlAncient.mDamage.Add(New ValueWrapper())
    'bdlAncient.mDamage.Add(New ValueWrapper())

    'bdlAncient.mDamageIncrement = New ValueWrapper()

    bdlAncient.mMagicResistance = New ValueWrapper(0)

    bdlAncient.mArmor = New ValueWrapper(15)
    bdlAncient.mArmorType = eArmorType.Fortified

    bdlAncient.mMoveSpeed = New ValueWrapper(0)
    bdlAncient.mCOllisionSize = New ValueWrapper(64)
    bdlAncient.mSightrange.Add(New ValueWrapper(1800))
    bdlAncient.mSightrange.Add(New ValueWrapper(1800))

    bdlAncient.mAttackType = eAttackType.None
    bdlAncient.mAttackSubType = eAttackSubType.None

    'bdlAncient.mAttackDuration.Add(New ValueWrapper())
    'bdlAncient.mAttackDuration.Add(New ValueWrapper())

    'bdlAncient.mMissileSpeed = New ValueWrapper()
    'bdlAncient.mBaseAttacktime = New ValueWrapper()

    'bdlAncient.mBounty.Add(New ValueWrapper())
    'bdlAncient.mBounty.Add(New ValueWrapper())
    'bdlAncient.mXp = New ValueWrapper()


    'bdlAncient.mAbilityNames.Add(eAbilityName)

    Me.Add(eCreepName.untAncient, bdlAncient)
    '--------------------------------------------------------------



    Dim bdlMelee_Barracks As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Melee Barracks
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlMelee_Barracks.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Melee Barracks", eEntity.Creepbundle)

    bdlMelee_Barracks.mName = eCreepName.untMelee_Barracks
    bdlMelee_Barracks.mUnitType = eUnittype.MeleeRax
    bdlMelee_Barracks.mUnitImage = "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcSx9D6nqS7UQsLHHCz_eBS7ZecVO4CwqzT1MR60VCMRCLXTtPCh"


    bdlMelee_Barracks.mDuration = New ValueWrapper(-1) '- 1 for permanent
    'bdlMelee_Barracks.mLevel = New ValueWrapper()

    bdlMelee_Barracks.mHealth = New ValueWrapper(1500)
    'bdlMelee_Barracks.mHealthIncrement = New ValueWrapper()
    bdlMelee_Barracks.mHealthRegen = New ValueWrapper(5)

    'bdlMelee_Barracks.mMana = New ValueWrapper()
    'bdlMelee_Barracks.mManaRegen = New ValueWrapper()

    'bdlMelee_Barracks.mDamage.Add(New ValueWrapper())
    'bdlMelee_Barracks.mDamage.Add(New ValueWrapper())

    'bdlMelee_Barracks.mDamageIncrement = New ValueWrapper()

    bdlMelee_Barracks.mMagicResistance = New ValueWrapper(0)

    bdlMelee_Barracks.mArmor = New ValueWrapper(15)
    bdlMelee_Barracks.mArmorType = eArmorType.Fortified

    bdlMelee_Barracks.mMoveSpeed = New ValueWrapper(0)
    bdlMelee_Barracks.mCOllisionSize = New ValueWrapper(48)
    bdlMelee_Barracks.mSightrange.Add(New ValueWrapper(900))
    bdlMelee_Barracks.mSightrange.Add(New ValueWrapper(600))

    bdlMelee_Barracks.mAttackType = eAttackType.None
    bdlMelee_Barracks.mAttackSubType = eAttackSubType.None

    'bdlMelee_Barracks.mAttackDuration.Add(New ValueWrapper())
    'bdlMelee_Barracks.mAttackDuration.Add(New ValueWrapper())

    'bdlMelee_Barracks.mMissileSpeed = New ValueWrapper()
    'bdlMelee_Barracks.mBaseAttacktime = New ValueWrapper()

    bdlMelee_Barracks.mBounty.Add(New ValueWrapper(100))
    bdlMelee_Barracks.mBounty.Add(New ValueWrapper(150))
    bdlMelee_Barracks.mXp = New ValueWrapper(25)


    'bdlMelee_Barracks.mAbilityNames.Add(eAbilityName)

    Me.Add(eCreepName.untMelee_Barracks, bdlMelee_Barracks)
    '--------------------------------------------------------------



    Dim bdlRanged_Barracks As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Ranged Barracks
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlRanged_Barracks.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Ranged Barracks", eEntity.Creepbundle)

    bdlRanged_Barracks.mName = eCreepName.untRanged_Barracks
    bdlRanged_Barracks.mUnitType = eUnittype.RangeRax
    bdlRanged_Barracks.mUnitImage = "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcSx9D6nqS7UQsLHHCz_eBS7ZecVO4CwqzT1MR60VCMRCLXTtPCh"


    bdlRanged_Barracks.mDuration = New ValueWrapper(-1) '- 1 for permanent
    'bdlRanged_Barracks.mLevel = New ValueWrapper()

    bdlRanged_Barracks.mHealth = New ValueWrapper(1200)
    'bdlRanged_Barracks.mHealthIncrement = New ValueWrapper()
    bdlRanged_Barracks.mHealthRegen = New ValueWrapper(0)

    'bdlRanged_Barracks.mMana = New ValueWrapper()
    'bdlRanged_Barracks.mManaRegen = New ValueWrapper()

    'bdlRanged_Barracks.mDamage.Add(New ValueWrapper())
    'bdlRanged_Barracks.mDamage.Add(New ValueWrapper())

    'bdlRanged_Barracks.mDamageIncrement = New ValueWrapper()

    bdlRanged_Barracks.mMagicResistance = New ValueWrapper(0)

    bdlRanged_Barracks.mArmor = New ValueWrapper(10)
    bdlRanged_Barracks.mArmorType = eArmorType.Fortified

    bdlRanged_Barracks.mMoveSpeed = New ValueWrapper(0)
    bdlRanged_Barracks.mCOllisionSize = New ValueWrapper(48)
    bdlRanged_Barracks.mSightrange.Add(New ValueWrapper(900))
    bdlRanged_Barracks.mSightrange.Add(New ValueWrapper(600))

    bdlRanged_Barracks.mAttackType = eAttackType.None
    bdlRanged_Barracks.mAttackSubType = eAttackSubType.None

    'bdlRanged_Barracks.mAttackDuration.Add(New ValueWrapper())
    'bdlRanged_Barracks.mAttackDuration.Add(New ValueWrapper())

    'bdlRanged_Barracks.mMissileSpeed = New ValueWrapper()
    'bdlRanged_Barracks.mBaseAttacktime = New ValueWrapper()

    bdlRanged_Barracks.mBounty.Add(New ValueWrapper(100))
    bdlRanged_Barracks.mBounty.Add(New ValueWrapper(150))
    bdlRanged_Barracks.mXp = New ValueWrapper(25)


    'bdlRanged_Barracks.mAbilityNames.Add(eAbilityName)

    Me.Add(eCreepName.untRanged_Barracks, bdlRanged_Barracks)
    '--------------------------------------------------------------



    Dim bdlFountain As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Fountain
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlFountain.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Fountain", eEntity.Creepbundle)

    bdlFountain.mName = eCreepName.untFountain
    bdlFountain.mUnitType = eUnittype.Fountain
    bdlFountain.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/8/89/Fountain.png/180px-Fountain.png?version=7054e88bdd287e317761076ce4e31485"


    bdlFountain.mDuration = New ValueWrapper(-1) '- 1 for permanent
    'bdlFountain.mLevel = New ValueWrapper()

    'bdlFountain.mHealth = New ValueWrapper()
    'bdlFountain.mHealthIncrement = New ValueWrapper()
    'bdlFountain.mHealthRegen = New ValueWrapper()

    'bdlFountain.mMana = New ValueWrapper()
    'bdlFountain.mManaRegen = New ValueWrapper()

    bdlFountain.mDamage.Add(New ValueWrapper(190))
    bdlFountain.mDamage.Add(New ValueWrapper(199))

    'bdlFountain.mDamageIncrement = New ValueWrapper()

    'bdlFountain.mMagicResistance = New ValueWrapper()

    'bdlFountain.mArmor = New ValueWrapper()
    'bdlFountain.mArmorType = eArmorType.Fortified

    bdlFountain.mMoveSpeed = New ValueWrapper(0)
    'bdlFountain.mCOllisionSize = New ValueWrapper()
    bdlFountain.mSightrange.Add(New ValueWrapper(800))
    bdlFountain.mSightrange.Add(New ValueWrapper(800))

    bdlFountain.mAttackType = eAttackType.Ranged
    bdlFountain.mAttackSubType = eAttackSubType.None

    'bdlFountain.mAttackDuration.Add(New ValueWrapper())
    'bdlFountain.mAttackDuration.Add(New ValueWrapper())

    'bdlFountain.mMissileSpeed = New ValueWrapper()
    bdlFountain.mBaseAttacktime = New ValueWrapper(1)

    'bdlFountain.mBounty.Add(New ValueWrapper())
    'bdlFountain.mBounty.Add(New ValueWrapper())
    'bdlFountain.mXp = New ValueWrapper()


    'bdlFountain.mAbilityNames.Add(eAbilityName)

    Me.Add(eCreepName.untFountain, bdlFountain)
    '--------------------------------------------------------------



    Dim bdlBuffer_Building As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Buffer Building
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlBuffer_Building.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Buffer Building", eEntity.Creepbundle)

    bdlBuffer_Building.mName = eCreepName.untBuffer_Building
    bdlBuffer_Building.mUnitType = eUnittype.BufferBuilding
    bdlBuffer_Building.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/9/91/Pillar_buildings.jpg/180px-Pillar_buildings.jpg.png?version=9b58384654a952848bcc29efe0647273"


    bdlBuffer_Building.mDuration = New ValueWrapper(-1) '- 1 for permanent
    'bdlBuffer_Building.mLevel = New ValueWrapper()

    bdlBuffer_Building.mHealth = New ValueWrapper(500)
    'bdlBuffer_Building.mHealthIncrement = New ValueWrapper()
    'bdlBuffer_Building.mHealthRegen = New ValueWrapper()

    'bdlBuffer_Building.mMana = New ValueWrapper()
    'bdlBuffer_Building.mManaRegen = New ValueWrapper()

    'bdlBuffer_Building.mDamage.Add(New ValueWrapper())
    'bdlBuffer_Building.mDamage.Add(New ValueWrapper())

    'bdlBuffer_Building.mDamageIncrement = New ValueWrapper()

    bdlBuffer_Building.mMagicResistance = New ValueWrapper(0)

    bdlBuffer_Building.mArmor = New ValueWrapper(10)
    bdlBuffer_Building.mArmorType = eArmorType.Fortified

    bdlBuffer_Building.mMoveSpeed = New ValueWrapper(0)
    bdlBuffer_Building.mCOllisionSize = New ValueWrapper(24)
    bdlBuffer_Building.mSightrange.Add(New ValueWrapper(600))
    bdlBuffer_Building.mSightrange.Add(New ValueWrapper(600))

    bdlBuffer_Building.mAttackType = eAttackType.None
    bdlBuffer_Building.mAttackSubType = eAttackSubType.None

    'bdlBuffer_Building.mAttackDuration.Add(New ValueWrapper())
    'bdlBuffer_Building.mAttackDuration.Add(New ValueWrapper())

    'bdlBuffer_Building.mMissileSpeed = New ValueWrapper()
    'bdlBuffer_Building.mBaseAttacktime = New ValueWrapper()

    bdlBuffer_Building.mBounty.Add(New ValueWrapper(102))
    bdlBuffer_Building.mBounty.Add(New ValueWrapper(120))
    bdlBuffer_Building.mXp = New ValueWrapper(25)


    'bdlBuffer_Building.mAbilityNames.Add(eAbilityName)

    Me.Add(eCreepName.untBuffer_Building, bdlBuffer_Building)
    '--------------------------------------------------------------




    Dim bdlGhost As New CreepBundle
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''Ghost
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''

    bdlGhost.mIDItem = New dvID(Guid.NewGuid, "CreepBundle: Ghost", eEntity.Creepbundle)

    bdlGhost.mName = eCreepName.untGhost
    bdlGhost.mUnitType = eUnittype.JungleCreep
    bdlGhost.mUnitImage = "http://hydra-media.cursecdn.com/dota2.gamepedia.com/thumb/4/4d/Ghost.jpg/200px-Ghost.jpg.png?version=1e5e3a042ac3977f5d72a8fac14b3e5b"


    bdlGhost.mDuration = New ValueWrapper(-1) '- 1 for permanent
    bdlGhost.mLevel = New ValueWrapper(3)

    bdlGhost.mHealth = New ValueWrapper(500)
    'bdlGhost.mHealthIncrement = New ValueWrapper()
    bdlGhost.mHealthRegen = New ValueWrapper(0.5)

    bdlGhost.mMana = New ValueWrapper(400)
    bdlGhost.mManaRegen = New ValueWrapper(0.75)

    bdlGhost.mDamage.Add(New ValueWrapper(47))
    bdlGhost.mDamage.Add(New ValueWrapper(47))

    'bdlGhost.mDamageIncrement = New ValueWrapper()

    bdlGhost.mMagicResistance = New ValueWrapper(0)

    bdlGhost.mArmor = New ValueWrapper(1)
    bdlGhost.mArmorType = eArmorType.Medium

    bdlGhost.mMoveSpeed = New ValueWrapper(320)
    bdlGhost.mCOllisionSize = New ValueWrapper(16)
    bdlGhost.mSightrange.Add(New ValueWrapper(800))
    bdlGhost.mSightrange.Add(New ValueWrapper(800))

    bdlGhost.mAttackType = eAttackType.Ranged
    bdlGhost.mAttackSubType = eAttackSubType.Piercing

    bdlGhost.mAttackDuration.Add(New ValueWrapper(0.3))
    bdlGhost.mAttackDuration.Add(New ValueWrapper(0.3))

    bdlGhost.mCastDuration = New List(Of ValueWrapper)
    bdlGhost.mCastDuration.Add(New ValueWrapper(0.5))
    bdlGhost.mCastDuration.Add(New ValueWrapper(0.83))

    bdlGhost.mMissileSpeed = New ValueWrapper(900)
    bdlGhost.mBaseAttacktime = New ValueWrapper(1)

    bdlGhost.mBounty.Add(New ValueWrapper(30))
    bdlGhost.mBounty.Add(New ValueWrapper(40))
    bdlGhost.mXp = New ValueWrapper(62)


    bdlGhost.mAbilityNames.Add(eAbilityName.abGhost_Frost_Attack)

    Me.Add(eCreepName.untGhost, bdlGhost)
    '--------------------------------------------------------------

  End Sub

 
End Class
