Public Class HeroBundles
  Inherits Dictionary(Of eHeroName, HeroBundle)
  Public Sub New()

    '----------------------------------------------------------
    '-EARTHSHAKER START-----------------------------
    '----------------------------------------------------------
    Dim bundleEarthshaker As New HeroBundle
    'FROM UNITBASE
    bundleEarthshaker.mIDItem = New dvID(New Guid("ac76f615-12ee-448a-860c-01f0a22ed054"), "Herobundle: Earthshaker", eEntity.Herobundle)
    bundleEarthshaker.mName = eHeroName.untEarthshaker
    bundleEarthshaker.DisplayName = "Earthshaker"
    bundleEarthshaker.mArmorType = eArmorType.Hero
    bundleEarthshaker.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/earthshaker_vert.jpg"
    bundleEarthshaker.mWebpageLink = "http://www.dota2.com/hero/Earthshaker/"

    bundleEarthshaker.mAttackType = eAttackType.Melee
    bundleEarthshaker.mBaseHitpoints = 0
    bundleEarthshaker.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleEarthshaker.mBaseAttackDamage = New ValueWrapper(24, 34)

    bundleEarthshaker.mDaySightRange = 1800
    bundleEarthshaker.mNightSightRange = 800

    bundleEarthshaker.mAttackRange = 128
    bundleEarthshaker.mMissileSpeed = Nothing

    bundleEarthshaker.mAbilityNames.Add(eAbilityName.abFissure)
    bundleEarthshaker.mAbilityNames.Add(eAbilityName.abEnchant_Totem)
    bundleEarthshaker.mAbilityNames.Add(eAbilityName.abAftershock)
    bundleEarthshaker.mAbilityNames.Add(eAbilityName.abEcho_Slam)




    'FROM HEROBASE
    'Fixed, immutable stats
    bundleEarthshaker.mDevName = "Earthshaker"

    bundleEarthshaker.mRoles.Add(eRole.Initiator)
    bundleEarthshaker.mRoles.Add(eRole.Disabler)
    bundleEarthshaker.mRoles.Add(eRole.Support)
    bundleEarthshaker.mRoles.Add(eRole.LaneSupport)

    bundleEarthshaker.mPrimaryStat = ePrimaryStat.Strength

    bundleEarthshaker.mBio = "Like a golem or gargoyle, Earthshaker was one with the earth but now walks freely upon it. Unlike those other entities, he created himself through an act of will, and serves no other master. In restless slumbers, encased in a deep seam of stone, he became aware of the life drifting freely above him. He grew curious. During a season of tremors, the peaks of Nishai shook themselves loose of avalanches, shifting the course of rivers and turning shallow valleys into bottomless chasms. When the land finally ceased quaking, Earthshaker stepped from the settling dust, tossing aside massive boulders as if throwing off a light blanket. He had shaped himself in the image of a mortal beast, and named himself Raigor Stonehoof. He bleeds now, and breathes, and therefore he can die. But his spirit is still that of the earth; he carries its power in the magical totem that never leaves him. And on the day he returns to dust, the earth will greet him as a prodigal son. "

    bundleEarthshaker.mBaseStr = 22
    bundleEarthshaker.mStrIncrement = 2.9

    bundleEarthshaker.mBaseInt = 16
    bundleEarthshaker.mIntIncrement = 1.8

    bundleEarthshaker.mBaseAgi = 12
    bundleEarthshaker.mAgiIncrement = 1.4


    bundleEarthshaker.mBaseMoveSpeed = 310
    bundleEarthshaker.mBaseArmor = 1


    bundleEarthshaker.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleEarthshaker.mName, bundleEarthshaker)



    '----------------------------------------------------------
    '-SVEN START-----------------------------
    '----------------------------------------------------------
    Dim bundleSven As New HeroBundle
    'FROM UNITBASE
    bundleSven.mIDItem = New dvID(New Guid("6c7de3a3-bfe8-47db-ad41-e9dd3dcd5a92"), "Herobundle: Sven", eEntity.Herobundle)
    bundleSven.mName = eHeroName.untSven
    bundleSven.DisplayName = "Sven"
    bundleSven.mArmorType = eArmorType.Hero
    bundleSven.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/sven_vert.jpg"
    bundleSven.mWebpageLink = "http://www.dota2.com/hero/Sven/"

    bundleSven.mAttackType = eAttackType.Melee
    bundleSven.mBaseHitpoints = 0
    bundleSven.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleSven.mBaseAttackDamage = New ValueWrapper(37, 39)

    bundleSven.mDaySightRange = 1800
    bundleSven.mNightSightRange = 800

    bundleSven.mAttackRange = 128
    bundleSven.mMissileSpeed = Nothing

    bundleSven.mAbilityNames.Add(eAbilityName.abStorm_Hammer)
    bundleSven.mAbilityNames.Add(eAbilityName.abGreat_Cleave)
    bundleSven.mAbilityNames.Add(eAbilityName.abWarcry)
    bundleSven.mAbilityNames.Add(eAbilityName.abGods_Strength)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleSven.mDevName = "Sven"

    bundleSven.mRoles.Add(eRole.Disabler)
    bundleSven.mRoles.Add(eRole.Initiator)
    bundleSven.mRoles.Add(eRole.Carry)
    bundleSven.mRoles.Add(eRole.Support)

    bundleSven.mPrimaryStat = ePrimaryStat.Strength

    bundleSven.mBio = "Sven is the bastard son of a Vigil Knight, born of a Pallid Meranth, raised in the Shadeshore Ruins. With his father executed for violating the Vigil Codex, and his mother shunned by her wild race, Sven believes that honor is to be found in no social order, but only in himself. After tending his mother through a lingering death, he offered himself as a novice to the Vigil Knights, never revealing his identity. For thirteen years he studied in his father's school, mastering the rigid code that declared his existence an abomination. Then, on the day that should have been his In-Swearing, he seized the Outcast Blade, shattered the Sacred Helm, and burned the Codex in the Vigil's Holy Flame. He strode from Vigil Keep, forever solitary, following his private code to the last strict rune. Still a knight, yes...but a Rogue Knight. He answers only to himself. "

    bundleSven.mBaseStr = 23
    bundleSven.mStrIncrement = 2.7

    bundleSven.mBaseInt = 14
    bundleSven.mIntIncrement = 1.3

    bundleSven.mBaseAgi = 21
    bundleSven.mAgiIncrement = 2


    bundleSven.mBaseMoveSpeed = 295
    bundleSven.mBaseArmor = 2


    bundleSven.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleSven.mName, bundleSven)



    '----------------------------------------------------------
    '-TINY START-----------------------------
    '----------------------------------------------------------
    Dim bundleTiny As New HeroBundle
    'FROM UNITBASE
    bundleTiny.mIDItem = New dvID(New Guid("f4d89be6-5717-405f-9542-11a98f30fd5b"), "Herobundle: Tiny", eEntity.Herobundle)
    bundleTiny.mName = eHeroName.untTiny
    bundleTiny.DisplayName = "Tiny"
    bundleTiny.mArmorType = eArmorType.Hero
    bundleTiny.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/tiny_vert.jpg"
    bundleTiny.mWebpageLink = "http://www.dota2.com/hero/Tiny/"

    bundleTiny.mAttackType = eAttackType.Melee
    bundleTiny.mBaseHitpoints = 0
    bundleTiny.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleTiny.mBaseAttackDamage = New ValueWrapper(37, 43)

    bundleTiny.mDaySightRange = 1800
    bundleTiny.mNightSightRange = 800

    bundleTiny.mAttackRange = 128
    bundleTiny.mMissileSpeed = Nothing


    bundleTiny.mAbilityNames.Add(eAbilityName.abAvalanche)
    bundleTiny.mAbilityNames.Add(eAbilityName.abToss)
    bundleTiny.mAbilityNames.Add(eAbilityName.abCraggy_Exterior)
    bundleTiny.mAbilityNames.Add(eAbilityName.abGrow)



    'FROM HEROBASE
    'Fixed, immutable stats
    bundleTiny.mDevName = "Tiny"

    bundleTiny.mRoles.Add(eRole.Disabler)
    bundleTiny.mRoles.Add(eRole.Nuker)
    bundleTiny.mRoles.Add(eRole.Initiator)
    bundleTiny.mRoles.Add(eRole.Durable)

    bundleTiny.mPrimaryStat = ePrimaryStat.Strength

    bundleTiny.mBio = "Coming to life as a chunk of stone, Tiny's origins are a mystery on which he continually speculates. He is a Stone Giant now, but what did he used to be? A splinter broken from a Golem's heel? A shard swept from a gargoyle-sculptor's workshop? A fragment of the Oracular Visage of Garthos? A deep curiosity drives him, and he travels the world tirelessly seeking his origins, his parentage, his people. As he roams, he gathers weight and size; the forces that weather lesser rocks, instead cause Tiny to grow and ever grow. "

    bundleTiny.mBaseStr = 24
    bundleTiny.mStrIncrement = 3

    bundleTiny.mBaseInt = 14
    bundleTiny.mIntIncrement = 1.6

    bundleTiny.mBaseAgi = 9
    bundleTiny.mAgiIncrement = 0.9


    bundleTiny.mBaseMoveSpeed = 285

    bundleTiny.mBaseArmor = -1

    bundleTiny.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleTiny.mName, bundleTiny)



    '----------------------------------------------------------
    '-KUNKKA START-----------------------------
    '----------------------------------------------------------
    Dim bundleKunkka As New HeroBundle
    'FROM UNITBASE
    bundleKunkka.mIDItem = New dvID(New Guid("aa7fffee-c51b-4e58-9a2e-d99ea68d4e9c"), "Herobundle: Kunkka", eEntity.Herobundle)
    bundleKunkka.mName = eHeroName.untKunkka
    bundleKunkka.DisplayName = "Kunkka"
    bundleKunkka.mArmorType = eArmorType.Hero
    bundleKunkka.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/kunkka_vert.jpg"
    bundleKunkka.mWebpageLink = "http://www.dota2.com/hero/Kunkka/"

    bundleKunkka.mAttackType = eAttackType.Melee
    bundleKunkka.mBaseHitpoints = 0
    bundleKunkka.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleKunkka.mBaseAttackDamage = New ValueWrapper(26, 36)

    bundleKunkka.mDaySightRange = 1800
    bundleKunkka.mNightSightRange = 800

    bundleKunkka.mAttackRange = 128
    bundleKunkka.mMissileSpeed = Nothing

    bundleKunkka.mAbilityNames.Add(eAbilityName.abTorrent)
    bundleKunkka.mAbilityNames.Add(eAbilityName.abTidebringer)
    bundleKunkka.mAbilityNames.Add(eAbilityName.abX_Marks_The_Spot)
    bundleKunkka.mAbilityNames.Add(eAbilityName.abGhostship)
    'bundleKunkka.mAbilityNames.Add(eAbilityName.abKunkka_Return)





    'FROM HEROBASE
    'Fixed, immutable stats
    bundleKunkka.mDevName = "Kunkka"

    bundleKunkka.mRoles.Add(eRole.Disabler)
    bundleKunkka.mRoles.Add(eRole.Initiator)
    bundleKunkka.mRoles.Add(eRole.Carry)
    bundleKunkka.mRoles.Add(eRole.Durable)

    bundleKunkka.mPrimaryStat = ePrimaryStat.Strength

    bundleKunkka.mBio = "As The Admiral of the mighty Claddish Navy, Kunkka was charged with protecting the isles of his homeland when the demons of the Cataract made a concerted grab at the lands of men. After years of small sorties, and increasingly bold and devastating attacks, the demon fleet flung all its carnivorous ships at the Trembling Isle. Desperate, the Suicide-Mages of Cladd committed their ultimate rite, summoning a host of ancestral spirits to protect the fleet. Against the demons, this was just barely enough to turn the tide. As Kunkka watched the demons take his ships down one by one, he had the satisfaction of wearing away their fleet with his ancestral magic. But at the battle's peak, something in the clash of demons, men and atavistic spirits must have stirred a fourth power that had been slumbering in the depths. The waves rose up in towering spouts around the few remaining ships, and Maelrawn the Tentacular appeared amid the fray. His tendrils wove among the ships, drawing demon and human craft together, churning the water and wind into a raging chaos. What happened in the crucible of that storm, none may truly say. The Cataract roars off into the void, deserted by its former denizens. Kunkka is now The Admiral of but one ship, a ghostly rig which endlessly replays the final seconds of its destruction. Whether he died in that crash is anyone's guess. Not even Tidehunter, who summoned Maelrawn, knows for sure. "

    bundleKunkka.mBaseStr = 24
    bundleKunkka.mStrIncrement = 3

    bundleKunkka.mBaseInt = 18
    bundleKunkka.mIntIncrement = 1.5

    bundleKunkka.mBaseAgi = 14
    bundleKunkka.mAgiIncrement = 1.3


    bundleKunkka.mBaseMoveSpeed = 300
    bundleKunkka.mBaseArmor = 0


    bundleKunkka.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleKunkka.mName, bundleKunkka)



    '----------------------------------------------------------
    '-BEASTMASTER START-----------------------------
    '----------------------------------------------------------
    Dim bundleBeastmaster As New HeroBundle
    'FROM UNITBASE
    bundleBeastmaster.mIDItem = New dvID(New Guid("98ecfa70-30f1-4975-b315-adc3036a868e"), "Herobundle: Beastmaster", eEntity.Herobundle)
    bundleBeastmaster.mName = eHeroName.untBeastmaster
    bundleBeastmaster.DisplayName = "Beastmaster"
    bundleBeastmaster.mArmorType = eArmorType.Hero
    bundleBeastmaster.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/beastmaster_vert.jpg"
    bundleBeastmaster.mWebpageLink = "http://www.dota2.com/hero/Beastmaster/"

    bundleBeastmaster.mAttackType = eAttackType.Melee
    bundleBeastmaster.mBaseHitpoints = 0
    bundleBeastmaster.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleBeastmaster.mBaseAttackDamage = New ValueWrapper(41, 45)

    bundleBeastmaster.mDaySightRange = 1800
    bundleBeastmaster.mNightSightRange = 800

    bundleBeastmaster.mAttackRange = 128
    bundleBeastmaster.mMissileSpeed = Nothing

    bundleBeastmaster.mAbilityNames.Add(eAbilityName.abWild_Axes)
    bundleBeastmaster.mAbilityNames.Add(eAbilityName.abCall_Of_The_Wild)
    bundleBeastmaster.mAbilityNames.Add(eAbilityName.abInner_Beast)
    bundleBeastmaster.mAbilityNames.Add(eAbilityName.abPrimal_Roar)



    'FROM HEROBASE
    'Fixed, immutable stats
    bundleBeastmaster.mDevName = "Beastmaster"

    bundleBeastmaster.mRoles.Add(eRole.Initiator)
    bundleBeastmaster.mRoles.Add(eRole.Disabler)
    bundleBeastmaster.mRoles.Add(eRole.Durable)

    bundleBeastmaster.mPrimaryStat = ePrimaryStat.Strength

    bundleBeastmaster.mBio = "Karroch was born a child of the stocks. His mother died in childbirth; his father, a farrier for the Last King of Slom, was trampled to death when he was five. Afterward Karroch was indentured to the king's menagerie, where he grew up among all the beasts of the royal court: lions, apes, fell-deer, and things less known, things barely believed in. When the lad was seven, an explorer brought in a beast like none before seen. Dragged before the King in chains, the beast spoke, though its mouth moved not. Its words: a plea for freedom. The King only laughed and ordered the beast perform for his amusement; and when it refused, struck it with the Mad Scepter and ordered it dragged to the stocks. |Over the coming months, the boy Karroch sneaked food and medicinal draughts to the wounded creature, but only managed to slow its deterioration. Wordlessly, the beast spoke to the boy, and over time their bond strengthened until the boy found he could hold up his end of a conversation. He could, in fact, speak now to all the creatures of the King's menagerie. On the night the beast died, a rage came over the boy. He incited the animals of the court to rebel and threw open their cages to set them amok on the palace grounds. The Last King was mauled in the mayhem. In the chaos, one regal stag bowed to the boy who had freed him; and with Beastmaster astride him, leapt the high walls of the estate, and escaped. Now a man, Karroch the Beastmaster has not lost his ability to converse with wild creatures. He has grown into a warrior at one with nature's savagery. "

    bundleBeastmaster.mBaseStr = 23
    bundleBeastmaster.mStrIncrement = 2.2

    bundleBeastmaster.mBaseInt = 16
    bundleBeastmaster.mIntIncrement = 1.9

    bundleBeastmaster.mBaseAgi = 18
    bundleBeastmaster.mAgiIncrement = 1.6


    bundleBeastmaster.mBaseMoveSpeed = 310
    bundleBeastmaster.mBaseArmor = 2


    bundleBeastmaster.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleBeastmaster.mName, bundleBeastmaster)



    '----------------------------------------------------------
    '-DRAGON KNIGHT START-----------------------------
    '----------------------------------------------------------
    Dim bundleDragon_Knight As New HeroBundle
    'FROM UNITBASE
    bundleDragon_Knight.mIDItem = New dvID(New Guid("81ff459b-201a-48d2-9dfa-9707ffdd5d05"), "Herobundle: Dragon Knight", eEntity.Herobundle)
    bundleDragon_Knight.mName = eHeroName.untDragon_Knight
    bundleDragon_Knight.DisplayName = "Dragon Knight"
    bundleDragon_Knight.mArmorType = eArmorType.Hero
    bundleDragon_Knight.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/dragon_knight_vert.jpg"
    bundleDragon_Knight.mWebpageLink = "http://www.dota2.com/hero/Dragon_Knight/"

    bundleDragon_Knight.mAttackType = eAttackType.Melee
    bundleDragon_Knight.mBaseHitpoints = 0
    bundleDragon_Knight.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleDragon_Knight.mBaseAttackDamage = New ValueWrapper(27, 33)

    bundleDragon_Knight.mDaySightRange = 1800
    bundleDragon_Knight.mNightSightRange = 800

    bundleDragon_Knight.mAttackRange = 128
    bundleDragon_Knight.mMissileSpeed = 900


    bundleDragon_Knight.mAbilityNames.Add(eAbilityName.abBreathe_Fire)
    bundleDragon_Knight.mAbilityNames.Add(eAbilityName.abDragon_Tail)
    bundleDragon_Knight.mAbilityNames.Add(eAbilityName.abDragon_Blood)
    bundleDragon_Knight.mAbilityNames.Add(eAbilityName.abElder_Dragon_Form)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleDragon_Knight.mDevName = "Dragon_Knight"

    bundleDragon_Knight.mRoles.Add(eRole.Carry)
    bundleDragon_Knight.mRoles.Add(eRole.Durable)
    bundleDragon_Knight.mRoles.Add(eRole.Disabler)
    bundleDragon_Knight.mRoles.Add(eRole.Pusher)

    bundleDragon_Knight.mPrimaryStat = ePrimaryStat.Strength

    bundleDragon_Knight.mBio = "After years on the trail of a legendary Eldwurm, the Knight Davion found himself facing a disappointing foe: the dreaded Slyrak had grown ancient and frail, its wings tattered, its few remaining scales stricken with scale-rot, its fangs ground to nubs, and its fire-gouts no more threatening than a pack of wet matchsticks. Seeing no honor to be gained in dragon-murder, Knight Davion prepared to turn away and leave his old foe to die in peace. But a voice crept into his thoughts, and Slyrak gave a whispered plea that Davion might honor him with death in combat. Davion agreed, and found himself rewarded beyond expectation for his act of mercy: As he sank his blade in Slyrak's breast, the dragon pierced Davion's throat with a talon. As their blood mingled, Slyrak sent his power out along the Blood Route, sending all its strength and centuries of wisdom to the knight. The dragon's death sealed their bond and Dragon Knight was born. The ancient power slumbers in the Dragon Knight Davion, waking when he calls it. Or perhaps it is the Dragon that calls the Knight... "

    bundleDragon_Knight.mBaseStr = 19
    bundleDragon_Knight.mStrIncrement = 2.8

    bundleDragon_Knight.mBaseInt = 15
    bundleDragon_Knight.mIntIncrement = 1.7

    bundleDragon_Knight.mBaseAgi = 19
    bundleDragon_Knight.mAgiIncrement = 2.2


    bundleDragon_Knight.mBaseMoveSpeed = 290
    bundleDragon_Knight.mBaseArmor = 1


    bundleDragon_Knight.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleDragon_Knight.mName, bundleDragon_Knight)



    '----------------------------------------------------------
    '-CLOCKWERK START-----------------------------
    '----------------------------------------------------------
    Dim bundleClockwerk As New HeroBundle
    'FROM UNITBASE
    bundleClockwerk.mIDItem = New dvID(New Guid("f2be263b-a241-4c93-a63b-688c0a917a13"), "Herobundle: Clockwerk", eEntity.Herobundle)
    bundleClockwerk.mName = eHeroName.untClockwerk
    bundleClockwerk.DisplayName = "Clockwerk"
    bundleClockwerk.mArmorType = eArmorType.Hero
    bundleClockwerk.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/rattletrap_vert.jpg"
    bundleClockwerk.mWebpageLink = "http://www.dota2.com/hero/Clockwerk/"

    bundleClockwerk.mAttackType = eAttackType.Melee
    bundleClockwerk.mBaseHitpoints = 0
    bundleClockwerk.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleClockwerk.mBaseAttackDamage = New ValueWrapper(31, 33)

    bundleClockwerk.mDaySightRange = 1800
    bundleClockwerk.mNightSightRange = 800

    bundleClockwerk.mAttackRange = 128
    bundleClockwerk.mMissileSpeed = Nothing


    bundleClockwerk.mAbilityNames.Add(eAbilityName.abBattery_Assault)
    bundleClockwerk.mAbilityNames.Add(eAbilityName.abPower_Cogs)
    bundleClockwerk.mAbilityNames.Add(eAbilityName.abRocket_Flare)
    bundleClockwerk.mAbilityNames.Add(eAbilityName.abHookshot)




    'FROM HEROBASE
    'Fixed, immutable stats
    bundleClockwerk.mDevName = "Clockwerk"

    bundleClockwerk.mRoles.Add(eRole.Initiator)
    bundleClockwerk.mRoles.Add(eRole.Durable)

    bundleClockwerk.mPrimaryStat = ePrimaryStat.Strength

    bundleClockwerk.mBio = "Rattletrap descends from the same far-flung kindred as Sniper and Tinker, and like many of the Keen Folk, has offset his diminutive stature through the application of gadgetry and wit. The son of the son of a clockmaker, Rattletrap was many years apprenticed to that trade before war rode down from the mountains and swept the plains villages free of such innocent vocations.""""Your new trade is battle,"""" his dying father told him as the village of their ancestors lay in charred and smoking ruins.|It is a poor tradesman who blames his tools, and Rattletrap was never one to make excuses. After burying his father among the ruins of their village, he set about to transform himself into the greatest tool of warfare that any world had ever seen. He vowed to never again be caught unprepared, instead using his talents to assemble a suit of powered Clockwerk armor to make the knights of other lands look like tin cans by comparison. Now Rattletrap is alive with devices, a small but deadly warrior whose skills at ambush and destruction have risen to near-automated levels of efficiency. An artisan of death, his mechanizations make short work of the unwary, heralding a new dawn in this age of warfare. What time is it? It's Clockwerk time! "

    bundleClockwerk.mBaseStr = 24
    bundleClockwerk.mStrIncrement = 2.7

    bundleClockwerk.mBaseInt = 17
    bundleClockwerk.mIntIncrement = 1.3

    bundleClockwerk.mBaseAgi = 13
    bundleClockwerk.mAgiIncrement = 2.3


    bundleClockwerk.mBaseMoveSpeed = 315
    bundleClockwerk.mBaseArmor = 0


    bundleClockwerk.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleClockwerk.mName, bundleClockwerk)



    '----------------------------------------------------------
    '-OMNIKNIGHT START-----------------------------
    '----------------------------------------------------------
    Dim bundleOmniknight As New HeroBundle
    'FROM UNITBASE
    bundleOmniknight.mIDItem = New dvID(New Guid("1d72f683-c4bf-4f53-8f33-1f8156d6e23c"), "Herobundle: OmniKnight", eEntity.Herobundle)
    bundleOmniknight.mName = eHeroName.untOmniknight
    bundleOmniknight.DisplayName = "Omniknight"
    bundleOmniknight.mArmorType = eArmorType.Hero
    bundleOmniknight.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/omniknight_vert.jpg"
    bundleOmniknight.mWebpageLink = "http://www.dota2.com/hero/Omniknight/"

    bundleOmniknight.mAttackType = eAttackType.Melee
    bundleOmniknight.mBaseHitpoints = 0
    bundleOmniknight.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleOmniknight.mBaseAttackDamage = New ValueWrapper(31, 41)

    bundleOmniknight.mDaySightRange = 1800
    bundleOmniknight.mNightSightRange = 800

    bundleOmniknight.mAttackRange = 128
    bundleOmniknight.mMissileSpeed = Nothing

    bundleOmniknight.mAbilityNames.Add(eAbilityName.abPurification)
    bundleOmniknight.mAbilityNames.Add(eAbilityName.abRepel)
    bundleOmniknight.mAbilityNames.Add(eAbilityName.abDegen_Aura)
    bundleOmniknight.mAbilityNames.Add(eAbilityName.abGuardian_Angel)



    'FROM HEROBASE
    'Fixed, immutable stats
    bundleOmniknight.mDevName = "Omniknight"

    bundleOmniknight.mRoles.Add(eRole.Durable)
    bundleOmniknight.mRoles.Add(eRole.LaneSupport)
    bundleOmniknight.mRoles.Add(eRole.Support)

    bundleOmniknight.mPrimaryStat = ePrimaryStat.Strength

    bundleOmniknight.mBio = "Purist Thunderwrath was a hard-fighting, road-worn, deeply committed knight, sworn to the order in which he had grown up as squire to elder knights of great reputation. He had spent his entire life in the service of the Omniscience, the All Seeing One. Theirs was a holy struggle, and so embedded was he in his duty that he never questioned it so long as he had the strength to fight and the impetuous valor that comes with youth. But over the long years of the crusade, as his elders passed away and were buried in sorry graves at the side of muddy tracks, as his bond-brothers fell in battle to uncouth creatures that refused to bow to the Omniscience, as his own squires were chewed away by ambush and plague and bad water, he began to question the meaning of his vows--the meaning of the whole crusade. After deep meditation, he parted ways with his army and commenced a long trek back to the cave-riddled cliffs of Emauracus, and there he set a challenge to the priests of the Omniscience. No knight had ever questioned them before, and they tried to throw him into the pit of sacrifice, but Purist would not be moved. For as he faced them down, he began to glow with a holy light, and they saw that the Omniscience had chosen to reveal Itself to him. The Elder Hierophant led him on a journey of weeks down into the deepest chamber, the holy of holies, where waited not some abstract concept of wisdom and insight, not some carved relic requiring an injection of imagination to believe in, but the old one itself. It had not merely dwelt in those rocks for billions of aeons; no, It had created them. The Omniscience had formed the immense mineral shell of the planet around itself, as a defense against the numerous terrors of space. Thus the All Seeing One claimed to have created the world, and given the other truths revealed to Purist on that day, the knight had no reason to refute the story. Perhaps the Omniscience is a liar, deep in its prison of stone, and not the world's creator at all, but Omniknight never again questioned his faith. His campaign had meaning at last. And there can be no question that the glorious powers that imbue him, and give his companions such strength in battle, are real beyond any doubt. "

    bundleOmniknight.mBaseStr = 20
    bundleOmniknight.mStrIncrement = 2.65

    bundleOmniknight.mBaseInt = 17
    bundleOmniknight.mIntIncrement = 1.8

    bundleOmniknight.mBaseAgi = 15
    bundleOmniknight.mAgiIncrement = 1.75


    bundleOmniknight.mBaseMoveSpeed = 305
    bundleOmniknight.mBaseArmor = 3


    bundleOmniknight.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleOmniknight.mName, bundleOmniknight)



    '----------------------------------------------------------
    '-HUSKAR START-----------------------------
    '----------------------------------------------------------
    Dim bundleHuskar As New HeroBundle
    'FROM UNITBASE
    bundleHuskar.mIDItem = New dvID(New Guid("c764a829-3da5-4330-8aa3-a9c60168ea69"), "Herobundle: Huskar", eEntity.Herobundle)
    bundleHuskar.mName = eHeroName.untHuskar
    bundleHuskar.DisplayName = "Huskar"
    bundleHuskar.mArmorType = eArmorType.Hero
    bundleHuskar.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/huskar_vert.jpg"
    bundleHuskar.mWebpageLink = "http://www.dota2.com/hero/Huskar/"

    bundleHuskar.mAttackType = eAttackType.Ranged
    bundleHuskar.mBaseHitpoints = 0
    bundleHuskar.mBaseAttackSpeed = 1.6 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleHuskar.mBaseAttackDamage = New ValueWrapper(21, 30)

    bundleHuskar.mDaySightRange = 1800
    bundleHuskar.mNightSightRange = 800

    bundleHuskar.mAttackRange = 400
    bundleHuskar.mMissileSpeed = 1400

    bundleHuskar.mAbilityNames.Add(eAbilityName.abInner_Vitality)
    bundleHuskar.mAbilityNames.Add(eAbilityName.abBurning_Spear)
    bundleHuskar.mAbilityNames.Add(eAbilityName.abBerserkers_Blood)
    bundleHuskar.mAbilityNames.Add(eAbilityName.abLife_Break)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleHuskar.mDevName = "Huskar"

    bundleHuskar.mRoles.Add(eRole.Carry)
    bundleHuskar.mRoles.Add(eRole.Initiator)
    bundleHuskar.mRoles.Add(eRole.Durable)

    bundleHuskar.mPrimaryStat = ePrimaryStat.Strength

    bundleHuskar.mBio = "Emerging from the throes of the sacred Nothl Realm, Huskar opened his eyes to see the prodigal shadow priest Dazzle working a deep incantation over him. Against the ancient rites of the Dezun Order, Huskar's spirit had been saved from eternity, but like all who encounter the Nothl he found himself irrevocably changed. No longer at the mercy of a mortal body, his very lifeblood became a source of incredible power; every drop spilled was returned tenfold with a fierce, burning energy. However this newfound gift infuriated Huskar, for in his rescue from the Nothl, Dazzle had denied him a place among the gods. He had been denied his own holy sacrifice. In time the elders of the order sought to expand their influence and Huskar, they agreed, would be a formidable tool in their campaign. Yet becoming a mere weapon for the order that denied him his birthright only upset him further. As the first embers of war appeared on the horizon, he fled his ancestral home to find new allies, all the while seeking a cause worthy of unleashing the power his total sacrifice could bring. "

    bundleHuskar.mBaseStr = 21
    bundleHuskar.mStrIncrement = 2.4

    bundleHuskar.mBaseInt = 18
    bundleHuskar.mIntIncrement = 1.5

    bundleHuskar.mBaseAgi = 15
    bundleHuskar.mAgiIncrement = 1.4


    bundleHuskar.mBaseMoveSpeed = 300

    bundleHuskar.mBaseArmor = -1

    bundleHuskar.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleHuskar.mName, bundleHuskar)



    '----------------------------------------------------------
    '-ALCHEMIST START-----------------------------
    '----------------------------------------------------------
    Dim bundleAlchemist As New HeroBundle
    'FROM UNITBASE
    bundleAlchemist.mIDItem = New dvID(New Guid("a946c560-e9f7-47eb-b9a0-52dccb70aeed"), "Herobundle: Alchemist", eEntity.Herobundle)
    bundleAlchemist.mName = eHeroName.untAlchemist
    bundleAlchemist.DisplayName = "Alchemist"
    bundleAlchemist.mArmorType = eArmorType.Hero
    bundleAlchemist.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/alchemist_vert.jpg"
    bundleAlchemist.mWebpageLink = "http://www.dota2.com/hero/Alchemist/"

    bundleAlchemist.mAttackType = eAttackType.Melee
    bundleAlchemist.mBaseHitpoints = 0
    bundleAlchemist.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleAlchemist.mBaseAttackDamage = New ValueWrapper(24, 33)

    bundleAlchemist.mDaySightRange = 1800
    bundleAlchemist.mNightSightRange = 800

    bundleAlchemist.mAttackRange = 128
    bundleAlchemist.mMissileSpeed = Nothing


    bundleAlchemist.mAbilityNames.Add(eAbilityName.abAcid_Spray)
    bundleAlchemist.mAbilityNames.Add(eAbilityName.abUnstable_Concoction)
    bundleAlchemist.mAbilityNames.Add(eAbilityName.abGreevils_Greed)
    bundleAlchemist.mAbilityNames.Add(eAbilityName.abChemical_Rage)
    'bundleAlchemist.mAbilityNames.Add(eAbilityName.abUnstable_Concoction_Throw)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleAlchemist.mDevName = "Alchemist"

    bundleAlchemist.mRoles.Add(eRole.Durable)
    bundleAlchemist.mRoles.Add(eRole.Carry)
    bundleAlchemist.mRoles.Add(eRole.Disabler)

    bundleAlchemist.mPrimaryStat = ePrimaryStat.Strength

    bundleAlchemist.mBio = "The sacred science of Chymistry was a Darkbrew family tradition, but no Darkbrew had ever shown the kind of creativity, ambition, and recklessness of young Razzil. However, when adulthood came calling he pushed aside the family trade to try his hand at manufacturing gold through Alchemy. In an act of audacity befitting his reputation, Razzil announced he would transmute an entire mountain into gold. Following two decades of research and spending and preparation, he failed spectacularly, quickly finding himself imprisoned for the widespread destruction his experiment wrought. Yet Razzil was never one to take a setback lightly, and sought escape to continue his research. When his new cellmate turned out to be a fierce ogre, he found just the opportunity he needed. After convincing the ogre not to eat him, Razzil set about carefully concocting a tincture for it to drink, made from the moulds and mosses growing in the prison stone work. In a week's time, it seemed ready. When the ogre drank the potion, it flew into an unstoppable berserker rage, destroying the cell bars and exploding through walls and guards alike. They soon found themselves lost somewhere in the forest surrounding the city with a trail of wreckage in their wake and no signs of pursuit. In the tonic's afterglow, the ogre seemed serene, happy, and even eager. Resolving to work together, the pair set off to collect the materials needed to attempt Razzil's Alchemic transmutation once more. "

    bundleAlchemist.mBaseStr = 25
    bundleAlchemist.mStrIncrement = 1.8

    bundleAlchemist.mBaseInt = 25
    bundleAlchemist.mIntIncrement = 1.8

    bundleAlchemist.mBaseAgi = 11
    bundleAlchemist.mAgiIncrement = 1.2


    bundleAlchemist.mBaseMoveSpeed = 295
    bundleAlchemist.mBaseArmor = 0


    bundleAlchemist.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleAlchemist.mName, bundleAlchemist)



    '----------------------------------------------------------
    '-BREWMASTER START-----------------------------
    '----------------------------------------------------------
    Dim bundleBrewmaster As New HeroBundle
    'FROM UNITBASE
    bundleBrewmaster.mIDItem = New dvID(New Guid("743b0a63-b87b-4483-abb6-659d832383a5"), "Herobundle: Brewmaster", eEntity.Herobundle)
    bundleBrewmaster.mName = eHeroName.untBrewmaster
    bundleBrewmaster.DisplayName = "Brewmaster"
    bundleBrewmaster.mArmorType = eArmorType.Hero
    bundleBrewmaster.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/brewmaster_vert.jpg"
    bundleBrewmaster.mWebpageLink = "http://www.dota2.com/hero/Brewmaster/"

    bundleBrewmaster.mAttackType = eAttackType.Melee
    bundleBrewmaster.mBaseHitpoints = 0
    bundleBrewmaster.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleBrewmaster.mBaseAttackDamage = New ValueWrapper(29, 36)

    bundleBrewmaster.mDaySightRange = 1800
    bundleBrewmaster.mNightSightRange = 800

    bundleBrewmaster.mAttackRange = 128
    bundleBrewmaster.mMissileSpeed = Nothing

    bundleBrewmaster.mAbilityNames.Add(eAbilityName.abThunder_Clap)
    bundleBrewmaster.mAbilityNames.Add(eAbilityName.abDrunken_Haze)
    bundleBrewmaster.mAbilityNames.Add(eAbilityName.abDrunken_Brawler)
    bundleBrewmaster.mAbilityNames.Add(eAbilityName.abPrimal_Split)



    'FROM HEROBASE
    'Fixed, immutable stats
    bundleBrewmaster.mDevName = "Brewmaster"

    bundleBrewmaster.mRoles.Add(eRole.Carry)
    bundleBrewmaster.mRoles.Add(eRole.Durable)
    bundleBrewmaster.mRoles.Add(eRole.Initiator)
    bundleBrewmaster.mRoles.Add(eRole.Pusher)

    bundleBrewmaster.mPrimaryStat = ePrimaryStat.Strength

    bundleBrewmaster.mBio = "Deep in the Wailing Mountains, in a valley beneath the Ruined City, the ancient Order of the Oyo has for centuries practiced its rites of holy reverie, communing with the spirit realm in grand festivals of drink. Born to a mother's flesh by a Celestial father, the youth known as Mangix was the first to grow up with the talents of both lineages. He trained with the greatest aesthetes of the Order, eventually earning, through diligent drunkenness, the right to challenge for the title of Brewmaster, that appellation most honored among the contemplative malt-brewing sect. |As much drinking competition as mortal combat, Mangix for nine days drank and fought the elder master. For nine nights they stumbled and whirled, chugged and struck, until at last the elder warrior collapsed into a drunken stupor, and a new Brewmaster was named. Now the new, young Brewmaster calls upon the strength of his Oyo forebears to speed his staff. When using magic, it is to his spirit ancestors that he turns. Like all Brewmasters before him, he was sent out from his people with a single mission. He wanders the land, striving toward enlightenment through drink, searching for the answer to the ancient spiritual schism-hoping to think the single thought that will unite the spirit and physical planes again. "

    bundleBrewmaster.mBaseStr = 23
    bundleBrewmaster.mStrIncrement = 2.9

    bundleBrewmaster.mBaseInt = 14
    bundleBrewmaster.mIntIncrement = 1.25

    bundleBrewmaster.mBaseAgi = 22
    bundleBrewmaster.mAgiIncrement = 1.95


    bundleBrewmaster.mBaseMoveSpeed = 300
    bundleBrewmaster.mBaseArmor = -1


    bundleBrewmaster.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleBrewmaster.mName, bundleBrewmaster)



    '----------------------------------------------------------
    '-TREANT PROTECTOR START-----------------------------
    '----------------------------------------------------------
    Dim bundleTreant_Protector As New HeroBundle
    'FROM UNITBASE
    bundleTreant_Protector.mIDItem = New dvID(New Guid("9f80aeb4-57db-4dc0-a0a9-505f8ca42e62"), "Herobundle: Treant Protector", eEntity.Herobundle)
    bundleTreant_Protector.mName = eHeroName.untTreant_Protector
    bundleTreant_Protector.DisplayName = "Treant Protector"
    bundleTreant_Protector.mArmorType = eArmorType.Hero
    bundleTreant_Protector.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/treant_vert.jpg"
    bundleTreant_Protector.mWebpageLink = "http://www.dota2.com/hero/Treant_Protector/"

    bundleTreant_Protector.mAttackType = eAttackType.Melee
    bundleTreant_Protector.mBaseHitpoints = 0
    bundleTreant_Protector.mBaseAttackSpeed = 1.9 '  http://dota2.gamepedia.com/Attack_speed

    bundleTreant_Protector.mBaseAttackDamage = New ValueWrapper(56, 64)

    bundleTreant_Protector.mDaySightRange = 1800
    bundleTreant_Protector.mNightSightRange = 800

    bundleTreant_Protector.mAttackRange = 128
    bundleTreant_Protector.mMissileSpeed = Nothing

    bundleTreant_Protector.mAbilityNames.Add(eAbilityName.abNatures_Guise)
    bundleTreant_Protector.mAbilityNames.Add(eAbilityName.abLeech_Seed)
    bundleTreant_Protector.mAbilityNames.Add(eAbilityName.abLiving_Armor)
    bundleTreant_Protector.mAbilityNames.Add(eAbilityName.abOvergrowth)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleTreant_Protector.mDevName = "Treant_Protector"

    bundleTreant_Protector.mRoles.Add(eRole.Durable)
    bundleTreant_Protector.mRoles.Add(eRole.Initiator)
    bundleTreant_Protector.mRoles.Add(eRole.LaneSupport)
    bundleTreant_Protector.mRoles.Add(eRole.Disabler)

    bundleTreant_Protector.mPrimaryStat = ePrimaryStat.Strength

    bundleTreant_Protector.mBio = "Far to the west, in the mountains beyond the Vale of Augury, lie the remains of an ancient power, a fount of eldritch energy nestled deep in the high woods. It is said that the things that grow here, grow strangely. To the forces of nature this is a sacred place, made to stay hidden and unknown. Many are the traps and dangers of this land. There are all-consuming grasses, crossbred fauna and poisonous flowers, but none are so fierce as the mighty Treant Protectors. These ageless, titanic beings, charged with keeping the peace in this dangerous land, ensure that none within encroach without reason, and none without poach their secrets. For time untold they tended to their holy ground, uninterrupted, only dimly aware of the changing world beyond. Yet inevitably the wider world grew aware of this untamed land, and with each passing winter the outsiders grew bolder. Soon they arrived with tools to cut and with flames to burn, and often the Treants would ponder: who are these fragile, industrious creatures? What now had become of the wild, green world? There came and went an age of questions and of doubts, a thousand summers of long traditions set to scrutiny, while more and more the outsiders died and fed their earth. When all that bloomed had finally finished their say, curiosity had overcome caution. It was decided: a lone Protector would be sent into the wider world, and instructed to wander until the glaciers arose once more, to observe the changing land and its creatures, and to discover what unknown dangers could threaten their sacred ground. "

    bundleTreant_Protector.mBaseStr = 25
    bundleTreant_Protector.mStrIncrement = 3.3

    bundleTreant_Protector.mBaseInt = 17
    bundleTreant_Protector.mIntIncrement = 1.8

    bundleTreant_Protector.mBaseAgi = 15
    bundleTreant_Protector.mAgiIncrement = 2


    bundleTreant_Protector.mBaseMoveSpeed = 300

    bundleTreant_Protector.mBaseArmor = -1

    bundleTreant_Protector.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleTreant_Protector.mName, bundleTreant_Protector)



    '----------------------------------------------------------
    '-IO START-----------------------------
    '----------------------------------------------------------
    Dim bundleIo As New HeroBundle
    'FROM UNITBASE
    bundleIo.mIDItem = New dvID(New Guid("5656ee41-f7b9-49ff-af80-ae3b71574b1d"), "Herobundle: IO", eEntity.Herobundle)
    bundleIo.mName = eHeroName.untIo
    bundleIo.DisplayName = "Io"
    bundleIo.mArmorType = eArmorType.Hero
    bundleIo.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/wisp_vert.jpg"
    bundleIo.mWebpageLink = "http://www.dota2.com/hero/Io/"

    bundleIo.mAttackType = eAttackType.Ranged
    bundleIo.mBaseHitpoints = 0
    bundleIo.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleIo.mBaseAttackDamage = New ValueWrapper(26, 35)

    bundleIo.mDaySightRange = 1800
    bundleIo.mNightSightRange = 800

    bundleIo.mAttackRange = 575
    bundleIo.mMissileSpeed = 1200

    bundleIo.mAbilityNames.Add(eAbilityName.abTether)
    'bundleIo.mAbilityNames.Add(eAbilityName.abBreak_Tether)
    bundleIo.mAbilityNames.Add(eAbilityName.abSpirits)
    bundleIo.mAbilityNames.Add(eAbilityName.abOvercharge)
    bundleIo.mAbilityNames.Add(eAbilityName.abRelocate)

    ' bundleIo.mAbilityNames.Add(eAbilityName.abSpirits_In)
    'bundleIo.mAbilityNames.Add(eAbilityName.abSpirits_Out)



    'FROM HEROBASE
    'Fixed, immutable stats
    bundleIo.mDevName = "Io"

    bundleIo.mRoles.Add(eRole.Support)
    bundleIo.mRoles.Add(eRole.LaneSupport)
    bundleIo.mRoles.Add(eRole.Nuker)

    bundleIo.mPrimaryStat = ePrimaryStat.Strength

    bundleIo.mBio = "Io is everywhere, and in all things. Denounced by enemies as the great unmaker, worshiped by scholars as the twinkling of a divine eye, this strange Wisp of life-force occupies all planes at once, the merest fraction of its being crossing into physical existence at any one moment. |Like the great twin riders Dark and Light, and yet another ancient traveler whose true history is lost to the ages, Io the Wisp is a Fundamental of the universe, a force older than time, a wanderer from realms far beyond mortal understanding. Io is nothing less than the sum of all attractive and repulsive forces within the material field, a sentient manifestation of the charge that binds existence together. It is only in the controlled warping of these electrical waylines that Io's presence can be experienced on the physical plane. A benevolent, cooperative force, Io bonds its strange magnetism to others so that the power of allies might be enhanced. Its motives inscrutable, its strength unimaginable, Io moves through the physical plane, the perfect expression of the mysteries of the universe. "

    bundleIo.mBaseStr = 17
    bundleIo.mStrIncrement = 1.9

    bundleIo.mBaseInt = 23
    bundleIo.mIntIncrement = 1.7

    bundleIo.mBaseAgi = 14
    bundleIo.mAgiIncrement = 1.6


    bundleIo.mBaseMoveSpeed = 295

    bundleIo.mBaseArmor = -2


    bundleIo.mBaseArmordebuff = 0.04

    bundleIo.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleIo.mName, bundleIo)



    '----------------------------------------------------------
    '-CENTAUR WARRUNNER START-----------------------------
    '----------------------------------------------------------
    Dim bundleCentaur_Warrunner As New HeroBundle
    'FROM UNITBASE
    bundleCentaur_Warrunner.mIDItem = New dvID(New Guid("8bb5b84f-1a77-4ef1-bf68-389c20661e31"), "Herobundle: Centaur Warrunner", eEntity.Herobundle)
    bundleCentaur_Warrunner.mName = eHeroName.untCentaur_Warrunner
    bundleCentaur_Warrunner.DisplayName = "Centaur Warrunner"
    bundleCentaur_Warrunner.mArmorType = eArmorType.Hero
    bundleCentaur_Warrunner.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/centaur_vert.jpg"
    bundleCentaur_Warrunner.mWebpageLink = "http://www.dota2.com/hero/Centaur_Warrunner/"

    bundleCentaur_Warrunner.mAttackType = eAttackType.Melee
    bundleCentaur_Warrunner.mBaseHitpoints = 0
    bundleCentaur_Warrunner.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleCentaur_Warrunner.mBaseAttackDamage = New ValueWrapper(32, 34)

    bundleCentaur_Warrunner.mDaySightRange = 1800
    bundleCentaur_Warrunner.mNightSightRange = 800

    bundleCentaur_Warrunner.mAttackRange = 128
    bundleCentaur_Warrunner.mMissileSpeed = Nothing

    bundleCentaur_Warrunner.mAbilityNames.Add(eAbilityName.abHoof_Stomp)
    bundleCentaur_Warrunner.mAbilityNames.Add(eAbilityName.abDouble_Edge)

    bundleCentaur_Warrunner.mAbilityNames.Add(eAbilityName.abCentaurReturn)
    bundleCentaur_Warrunner.mAbilityNames.Add(eAbilityName.abStampede)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleCentaur_Warrunner.mDevName = "Centaur_Warrunner"

    bundleCentaur_Warrunner.mRoles.Add(eRole.Durable)
    bundleCentaur_Warrunner.mRoles.Add(eRole.Disabler)
    bundleCentaur_Warrunner.mRoles.Add(eRole.Initiator)

    bundleCentaur_Warrunner.mPrimaryStat = ePrimaryStat.Strength

    bundleCentaur_Warrunner.mBio = "It's said that a centaur's road is paved with the corpses of the fallen. For the one called Warrunner, it has been a long road indeed. To outsiders, the four-legged clans of Druud are often mistaken for simple, brutish creatures. Their language has no written form; their culture lacks pictographic traditions, structured music, formalized religion. For centaurs, combat is the perfect articulation of thought, the highest expression of self. If killing is an art among centaurs, then Bradwarden the Warrunner is their greatest artist. He rose to dominance on the proving grounds of Omexe, an ancient arena where centaur clans have for millennia gathered to perform their gladiatorial rites. As his fame spread, spectators came from far and wide to see the great centaur in action. Always the first to step into the arena, and the last to leave, he composes a masterpiece in each guttering spray, each thrust of blood-slickened blade-length. It is the poetry of blood on steel, flung in complex patterns across the pale sands of the killing floor. |Warrunner defeated warrior after warrior, until the arena boomed with the cheering of his name, and he found himself alone, the uncontested champion of his kind. The great belt of Omexe was bestowed, wrapped around his broad torso, but in his victory, the death-artist found only emptiness. For what is a warrior without a challenge? The great centaur galloped out of Omexe that day with a new goal. To his people, Warrunner is the greatest warrior to ever step into the arena. Now he has set out to prove he is the greatest fighter who has ever lived. "

    bundleCentaur_Warrunner.mBaseStr = 23
    bundleCentaur_Warrunner.mStrIncrement = 3.8

    bundleCentaur_Warrunner.mBaseInt = 15
    bundleCentaur_Warrunner.mIntIncrement = 1.6

    bundleCentaur_Warrunner.mBaseAgi = 15
    bundleCentaur_Warrunner.mAgiIncrement = 2


    bundleCentaur_Warrunner.mBaseMoveSpeed = 300
    bundleCentaur_Warrunner.mBaseArmor = 1


    bundleCentaur_Warrunner.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleCentaur_Warrunner.mName, bundleCentaur_Warrunner)



    '----------------------------------------------------------
    '-TIMBERSAW START-----------------------------
    '----------------------------------------------------------
    Dim bundleTimbersaw As New HeroBundle
    'FROM UNITBASE    
    bundleTimbersaw.mIDItem = New dvID(New Guid("cc3f582b-f296-49b6-afb7-45c2fcb1f530"), "Herobundle: Timbersaw", eEntity.Herobundle)
    bundleTimbersaw.mName = eHeroName.untTimbersaw
    bundleTimbersaw.DisplayName = "Timbersaw"
    bundleTimbersaw.mArmorType = eArmorType.Hero
    bundleTimbersaw.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/shredder_vert.jpg"
    bundleTimbersaw.mWebpageLink = "http://www.dota2.com/hero/Timbersaw/"

    bundleTimbersaw.mAttackType = eAttackType.Melee
    bundleTimbersaw.mBaseHitpoints = 0
    bundleTimbersaw.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleTimbersaw.mBaseAttackDamage = New ValueWrapper(26, 30)

    bundleTimbersaw.mDaySightRange = 1800
    bundleTimbersaw.mNightSightRange = 800

    bundleTimbersaw.mAttackRange = 128
    bundleTimbersaw.mMissileSpeed = Nothing

    bundleTimbersaw.mAbilityNames.Add(eAbilityName.abWhirling_Death)
    bundleTimbersaw.mAbilityNames.Add(eAbilityName.abTimber_Chain)

    bundleTimbersaw.mAbilityNames.Add(eAbilityName.abReactive_Armor)
    bundleTimbersaw.mAbilityNames.Add(eAbilityName.abChakram)
    'bundleTimbersaw.mAbilityNames.Add(eAbilityName.abReturn_Chakram)




    'FROM HEROBASE
    'Fixed, immutable stats
    bundleTimbersaw.mDevName = "Timbersaw"

    bundleTimbersaw.mRoles.Add(eRole.Durable)
    bundleTimbersaw.mRoles.Add(eRole.Nuker)
    bundleTimbersaw.mRoles.Add(eRole.Escape)

    bundleTimbersaw.mPrimaryStat = ePrimaryStat.Strength

    bundleTimbersaw.mBio = "Rizzrack could still hear the screams in his mind. He worked, frantically turning wrenches, twisting screws, building and carving and forging. Sleep eluded him; he only built. Months had passed since he had shut himself in his uncle's workshop, and his deliverance was nearly complete. He rubbed his back as his eyes drifted shut, and saw a blanket of flowers floating on the placid waves of Augury Bay before exploding into a cloud of pollen that silenced lives as it seized the lungs. He woke with a choking start. For hours the rhythmic sound of a whetstone filled the shop as he sharpened a set of massive blades, his mind filled with images of strangling vines garroting neighbors, enwrapping homes. The flooding of Augury Bay had been nothing compared to the violent horrors the waters left to take root beyond the city walls. But the saw-suit would make him strong and safe he thought, allowing himself this sliver of hope before the full might of his fear crashed into his fading mind. Branches and bark and blood. When the city fell, Rizzrack fled trees that walked, and fought, and killed. Trees had shattered the gates and swarmed into the city. Trees had crushed and thrashed and stomped the last that Augury Bay could muster in defense, and stalked the few fleeing refugees. In addled silence Rizzrack unspooled the thick chain from the suit's arm, his hands quaking as he inspected each link and ran a trembling finger along the claw attached at its end. The saw-suit was ready.|With his hand trembling he sparked the bladed machine to life. Terror drove him, terror of what awaited him and of what he would have to face to have any hope of calming his mind. As the saw-suit shuddered to life he knew he must face this fear, and he knew he wouldn't like it one bit. "

    bundleTimbersaw.mBaseStr = 22
    bundleTimbersaw.mStrIncrement = 2.1

    bundleTimbersaw.mBaseInt = 21
    bundleTimbersaw.mIntIncrement = 2.4

    bundleTimbersaw.mBaseAgi = 16
    bundleTimbersaw.mAgiIncrement = 1.3


    bundleTimbersaw.mBaseMoveSpeed = 290

    bundleTimbersaw.mBaseArmor = -2

    bundleTimbersaw.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleTimbersaw.mName, bundleTimbersaw)



    '----------------------------------------------------------
    '-BRISTLEBACK START-----------------------------
    '----------------------------------------------------------
    Dim bundleBristleback As New HeroBundle
    'FROM UNITBASE
    bundleBristleback.mIDItem = New dvID(New Guid("8b939307-4f74-4fce-8654-c0cf68269c98"), "Herobundle: Bristleback", eEntity.Herobundle)
    bundleBristleback.mName = eHeroName.untBristleback
    bundleBristleback.DisplayName = "Bristleback"
    bundleBristleback.mArmorType = eArmorType.Hero
    bundleBristleback.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/bristleback_vert.jpg"
    bundleBristleback.mWebpageLink = "http://www.dota2.com/hero/Bristleback/"

    bundleBristleback.mAttackType = eAttackType.Melee
    bundleBristleback.mBaseHitpoints = 0
    bundleBristleback.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleBristleback.mBaseAttackDamage = New ValueWrapper(26, 36)

    bundleBristleback.mDaySightRange = 1800
    bundleBristleback.mNightSightRange = 800

    bundleBristleback.mAttackRange = 128
    bundleBristleback.mMissileSpeed = Nothing

    bundleBristleback.mAbilityNames.Add(eAbilityName.abViscous_Nasal)
    bundleBristleback.mAbilityNames.Add(eAbilityName.abQuill_Spray)
    bundleBristleback.mAbilityNames.Add(eAbilityName.abBristleback)


    bundleBristleback.mAbilityNames.Add(eAbilityName.abWarpath)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleBristleback.mDevName = "Bristleback"

    bundleBristleback.mRoles.Add(eRole.Durable)
    bundleBristleback.mRoles.Add(eRole.Initiator)
    bundleBristleback.mRoles.Add(eRole.Disabler)

    bundleBristleback.mPrimaryStat = ePrimaryStat.Strength

    bundleBristleback.mBio = "Never one to turn his back on a fight, Rigwarl was known for battling the biggest, meanest scrappers he could get his hands on. Christened Bristleback by the drunken crowds, he waded into backroom brawls in every road tavern between Slom and Elze, until his exploits finally caught the eye of a barkeep in need of an enforcer. For a bit of brew, Bristleback was hired to collect tabs, keep the peace, and break the occasional leg or two (or five, in the case of one unfortunate web-hund). |After indulging in a night of merriment during which bodily harm was meted out in equal parts upon both delinquent patrons and his own liver, Bristleback finally met his match. """"Your tusks offend me, sir,"""" he was heard to drunkenly slur to one particularly large fellow from the northern wastes whose bill had come due. What followed was a fight for the ages. A dozen fighters jumped in. No stool was left unbroken, and in the end, the impossible happened: the tab went unpaid. Over the weeks that followed, Bristleback's wounds healed, and his quills grew back; but an enforcer's honor can be a prickly thing. He paid the tab from his own coin, vowing to track down this northerner and extract redemption. And then he did something he'd never done before: he actually trained, and in so doing made a startling discovery about himself. A smile peeled back from his teeth as he flexed his quills. Turning his back to a fight might be just the thing. "

    bundleBristleback.mBaseStr = 22
    bundleBristleback.mStrIncrement = 2.2

    bundleBristleback.mBaseInt = 14
    bundleBristleback.mIntIncrement = 2.8

    bundleBristleback.mBaseAgi = 17
    bundleBristleback.mAgiIncrement = 1.8


    bundleBristleback.mBaseMoveSpeed = 295
    bundleBristleback.mBaseArmor = 1


    bundleBristleback.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleBristleback.mName, bundleBristleback)



    '----------------------------------------------------------
    '-TUSK START-----------------------------
    '----------------------------------------------------------
    Dim bundleTusk As New HeroBundle
    'FROM UNITBASE
    bundleTusk.mIDItem = New dvID(New Guid("0b88a02f-6f84-4305-8af8-18fdd11239d1"), "Herobundle: Tusk", eEntity.Herobundle)
    bundleTusk.mName = eHeroName.untTusk
    bundleTusk.DisplayName = "Tusk"
    bundleTusk.mArmorType = eArmorType.Hero
    bundleTusk.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/tusk_vert.jpg"
    bundleTusk.mWebpageLink = "http://www.dota2.com/hero/Tusk/"

    bundleTusk.mAttackType = eAttackType.Melee
    bundleTusk.mBaseHitpoints = 0
    bundleTusk.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleTusk.mBaseAttackDamage = New ValueWrapper(27, 31)

    bundleTusk.mDaySightRange = 1800
    bundleTusk.mNightSightRange = 800

    bundleTusk.mAttackRange = 128
    bundleTusk.mMissileSpeed = Nothing

    bundleTusk.mAbilityNames.Add(eAbilityName.abIce_Shards)
    bundleTusk.mAbilityNames.Add(eAbilityName.abSnowball)
    bundleTusk.mAbilityNames.Add(eAbilityName.abFrozen_Sigil)

    ' bundleTusk.mAbilityNames.Add(eAbilityName.abLaunch_Snowball)

    bundleTusk.mAbilityNames.Add(eAbilityName.abWalrus_Punch)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleTusk.mDevName = "Tusk"

    bundleTusk.mRoles.Add(eRole.Initiator)
    bundleTusk.mRoles.Add(eRole.Durable)

    bundleTusk.mPrimaryStat = ePrimaryStat.Strength

    bundleTusk.mBio = "It had been a brawl to remember. There stood Ymir, the Tusk, the Terror from the Barrier, the Snowball from Cobalt, the only fighter to have bested the Bristled Bruiser in a fair fight, and now the last man standing in Wolfsden Tavern. What started as a simple bar bet of supremacy ended with four regulars, a blacksmith, and six of the Frost Brigade's best soldiers writhing against the shards and splinters of almost every bottle, mug, and chair in the building. The Tusk boasted and toasted his victory as he emptied his brew. |No sooner had the defeated regained consciousness than the cries for double-or-nothing rang out. The Tusk was pleased at the prospect, but none could think of a bet bigger than the one he just conquered. Horrified at the damage to his tavern and desperate to avoid another brawl, the barkeep had an idea. As skilled as he was, Ymir had never taken part in a real battle, never tested himself against the indiscriminate death and chaos of war. He proposed a wager to the fighter: seek out the biggest battle he could find, survive, and win it for whichever side he chose. The stakes? The next round of drinks. "

    bundleTusk.mBaseStr = 23
    bundleTusk.mStrIncrement = 2.3

    bundleTusk.mBaseInt = 18
    bundleTusk.mIntIncrement = 1.7

    bundleTusk.mBaseAgi = 23
    bundleTusk.mAgiIncrement = 2.1


    bundleTusk.mBaseMoveSpeed = 305
    bundleTusk.mBaseArmor = 0


    bundleTusk.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleTusk.mName, bundleTusk)



    '----------------------------------------------------------
    '-ELDER TITAN START-----------------------------
    '----------------------------------------------------------
    Dim bundleElder_Titan As New HeroBundle
    'FROM UNITBASE
    bundleElder_Titan.mIDItem = New dvID(New Guid("8f77ecd8-bc7e-412f-bf50-ae36113ace85"), "Herobundle: Elder Titan", eEntity.Herobundle)
    bundleElder_Titan.mName = eHeroName.untElder_Titan
    bundleElder_Titan.DisplayName = "Elder Titan"
    bundleElder_Titan.mArmorType = eArmorType.Hero
    bundleElder_Titan.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/elder_titan_vert.jpg"
    bundleElder_Titan.mWebpageLink = "http://www.dota2.com/hero/Elder_Titan/"

    bundleElder_Titan.mAttackType = eAttackType.Melee
    bundleElder_Titan.mBaseHitpoints = 0
    bundleElder_Titan.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleElder_Titan.mBaseAttackDamage = New ValueWrapper(23, 33)

    bundleElder_Titan.mDaySightRange = 1800
    bundleElder_Titan.mNightSightRange = 800

    bundleElder_Titan.mAttackRange = 128
    bundleElder_Titan.mMissileSpeed = Nothing

    bundleElder_Titan.mAbilityNames.Add(eAbilityName.abEcho_Stomp)
    bundleElder_Titan.mAbilityNames.Add(eAbilityName.abAstral_Spirit)
    bundleElder_Titan.mAbilityNames.Add(eAbilityName.abNatural_Order)
    bundleElder_Titan.mAbilityNames.Add(eAbilityName.abEarth_Splitter)


    'bundleElder_Titan.mAbilityNames.Add(eAbilityName.abReturn_Astral_Spirit)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleElder_Titan.mDevName = "Elder_Titan"

    bundleElder_Titan.mRoles.Add(eRole.Initiator)
    bundleElder_Titan.mRoles.Add(eRole.Durable)

    bundleElder_Titan.mPrimaryStat = ePrimaryStat.Strength

    bundleElder_Titan.mBio = "Well may you ask, """"How did this world take its form?"""" Why of all the worlds in creation, has this one its strange properties, its diverse and motley collection of creatures, cultures and lore? """"The answer,"""" One whispers, """"lies with the Titans.|These original progenitors were there near the Beginning--if not actual witnesses to the creation, then born with it still echoing in their ears. Stamped with the earliest energies of the universe, they wished nothing more than to continue as creators themselves. Thus they bent to the task of shaping matter to their will: hammering and heating, bending and blasting. And when matter proved less challenging than they liked, they turned their tools upon themselves, reshaping their minds and reforging their spirits until they had become beings of great endurance. Reality itself became the ultimate object of their smithing. Yet, along the way, they sometimes erred. In cases of great ambition, mistakes are unavoidable.|The one we know as the Elder Titan was a great innovator, one who studied at the forge of creation. In honing his skills, he shattered something that could never be repaired, only thrown aside. He fell into his own broken world, a shattered soul himself. There he dwelt among the jagged shards and fissured planes, along with other lost fragments that had sifted down through the cracks in the early universe. And this is why the world we know resembles an isle of castaways, survivors of a wreck now long forgotten. Forgotten, that is, by all but the One who blames himself. He spends his time forever seeking a way to accomplish the repairs, that he might rejoin the parts of his broken soul, that we and the world alike might all be mended. This is the One we know as Elder Titan. "

    bundleElder_Titan.mBaseStr = 24
    bundleElder_Titan.mStrIncrement = 2.3

    bundleElder_Titan.mBaseInt = 23
    bundleElder_Titan.mIntIncrement = 1.6

    bundleElder_Titan.mBaseAgi = 14
    bundleElder_Titan.mAgiIncrement = 1.5


    bundleElder_Titan.mBaseMoveSpeed = 315
    bundleElder_Titan.mBaseArmor = 1


    bundleElder_Titan.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleElder_Titan.mName, bundleElder_Titan)



    '----------------------------------------------------------
    '-LEGION COMMANDER START-----------------------------
    '----------------------------------------------------------
    Dim bundleLegion_Commander As New HeroBundle
    'FROM UNITBASE
    bundleLegion_Commander.mIDItem = New dvID(New Guid("881a0fdd-87d6-4431-ac36-bbf47cdeede2"), "Herobundle: Legion Commander", eEntity.Herobundle)
    bundleLegion_Commander.mName = eHeroName.untLegion_Commander
    bundleLegion_Commander.DisplayName = "Legion Commander"
    bundleLegion_Commander.mArmorType = eArmorType.Hero
    bundleLegion_Commander.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/legion_commander_vert.jpg"
    bundleLegion_Commander.mWebpageLink = "http://www.dota2.com/hero/Legion_Commander/"

    bundleLegion_Commander.mAttackType = eAttackType.Melee
    bundleLegion_Commander.mBaseHitpoints = 0
    bundleLegion_Commander.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleLegion_Commander.mBaseAttackDamage = New ValueWrapper(31, 35)

    bundleLegion_Commander.mDaySightRange = 1800
    bundleLegion_Commander.mNightSightRange = 800

    bundleLegion_Commander.mAttackRange = 128
    bundleLegion_Commander.mMissileSpeed = Nothing

    bundleLegion_Commander.mAbilityNames.Add(eAbilityName.abOverwhelming_Odds)
    bundleLegion_Commander.mAbilityNames.Add(eAbilityName.abPress_The_Attack)
    bundleLegion_Commander.mAbilityNames.Add(eAbilityName.abMoment_Of_Courage)

    bundleLegion_Commander.mAbilityNames.Add(eAbilityName.abDuel)




    'FROM HEROBASE
    'Fixed, immutable stats
    bundleLegion_Commander.mDevName = "Legion_Commander"

    bundleLegion_Commander.mRoles.Add(eRole.Carry)
    bundleLegion_Commander.mRoles.Add(eRole.Durable)

    bundleLegion_Commander.mPrimaryStat = ePrimaryStat.Strength

    bundleLegion_Commander.mBio = "They came without warning. Within the city walls of Stonehall there came a rumble and a terrible sound, and from blackness unknown came a force of beasts numbering beyond count, wielding flame and foul sorcery, slaying and snatching mothers and sons to dark purpose. Of once-mighty Stonehall's military strength only the Bronze Legion, led by the indomitable Commander Tresdin, was near enough to answer the call of battle. They rode into their city, fighting through bloodstained alleyways and burning markets, cutting their way through the monstrous throng to the source of the sudden invasion: an ethereal rift within the city square, and at its precipice thundered their dreaded champion.|Enwrapped in a corrosive shimmer, the leader of the abyssal horde swung its massive blade, cleaving a legionnaire in two as his flesh began to spoil. Tresdin lifted her blood-stained sword and settled her sights on the beast. It turned, smiling at her through a maze of teeth. Heedless of the battle raging around them, they charged one another.|Deflecting blow after blow, the pair danced their deadly duel as the Bronze Legion met its end around them. Tresdin leapt forward as her foe swung its sword to meet her. The odds turned. The attack smashed into Tresdin suddenly, a brutal thrust from the side, but even as her balance slipped she rallied her strength for another stroke. Blade scraped on blade, beyond the hilt to the gnarled paw below, carving it in two in a fearsome spray of sparks and blood. The vile audience looked on in astonishment as she pressed the attack, driving her blade through her foe's flesh into the stampeding heart within. With a scream that split the clouds above, the beast erupted in a torrent of gore and anguish. The stygian portal wavered, the power sustaining the chasm beyond vanishing as suddenly as it had appeared. The remaining invaders fell quickly to Stonehall steel.|Though victorious, the survivors saw little to celebrate: the city lay in ruins, and survivors were few. Fires continued to spread. Unfurling her banners of war, Tresdin gathered what allies she could. Her anger smoldered as she pledged brutal vengeance upon the forces of the abyss, and damned be any who would dare stand in her way. "

    bundleLegion_Commander.mBaseStr = 26
    bundleLegion_Commander.mStrIncrement = 2.6

    bundleLegion_Commander.mBaseInt = 20
    bundleLegion_Commander.mIntIncrement = 2.2

    bundleLegion_Commander.mBaseAgi = 18
    bundleLegion_Commander.mAgiIncrement = 1.7


    bundleLegion_Commander.mBaseMoveSpeed = 320
    bundleLegion_Commander.mBaseArmor = 0


    bundleLegion_Commander.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleLegion_Commander.mName, bundleLegion_Commander)



    '----------------------------------------------------------
    '-EARTH SPIRIT START-----------------------------
    '----------------------------------------------------------
    Dim bundleEarth_Spirit As New HeroBundle
    'FROM UNITBASE
    bundleEarth_Spirit.mIDItem = New dvID(New Guid("ccace15f-ea58-47f7-8602-9db44d6eca81"), "Herobundle: Earth Spirit", eEntity.Herobundle)
    bundleEarth_Spirit.mName = eHeroName.untEarth_Spirit
    bundleEarth_Spirit.DisplayName = "Earth Spirit"
    bundleEarth_Spirit.mArmorType = eArmorType.Hero
    bundleEarth_Spirit.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/earth_spirit_vert.jpg"
    bundleEarth_Spirit.mWebpageLink = "http://www.dota2.com/hero/Earth_Spirit/"

    bundleEarth_Spirit.mAttackType = eAttackType.Melee
    bundleEarth_Spirit.mBaseHitpoints = 0
    bundleEarth_Spirit.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleEarth_Spirit.mBaseAttackDamage = New ValueWrapper(25, 35)

    bundleEarth_Spirit.mDaySightRange = 1800
    bundleEarth_Spirit.mNightSightRange = 800

    bundleEarth_Spirit.mAttackRange = 128
    bundleEarth_Spirit.mMissileSpeed = Nothing


    bundleEarth_Spirit.mAbilityNames.Add(eAbilityName.abBoulder_Smash)
    bundleEarth_Spirit.mAbilityNames.Add(eAbilityName.abRolling_Boulder)
    bundleEarth_Spirit.mAbilityNames.Add(eAbilityName.abGeomagnetic_Grip)
    'bundleEarth_Spirit.mAbilityNames.Add(eAbilityName.abStone_Remnant)
    bundleEarth_Spirit.mAbilityNames.Add(eAbilityName.abMagnetize)




    'FROM HEROBASE
    'Fixed, immutable stats
    bundleEarth_Spirit.mDevName = "Earth_Spirit"

    bundleEarth_Spirit.mRoles.Add(eRole.Carry)
    bundleEarth_Spirit.mRoles.Add(eRole.Nuker)

    bundleEarth_Spirit.mPrimaryStat = ePrimaryStat.Strength

    bundleEarth_Spirit.mBio = "Deep amid the Upland crags and cliffs there runs a seam of sacred jade long foresworn by highland miners. From this rare material, the likeness of the great general Kaolin was carved and buried at the head of a stone funerary army ten thousand strong--a force of soldiers and holy men, jesters and acrobats, carved by crafstmen and entombed for millennia in the dark embrace of the Earth.|What the craftsmen had not known was that within the strange seam of jade flowed the spirit of the Earth itself--an elemental force at one with the planet. When the force within the carved jade found itself cut off from the life's blood of the world, it gathered its strength over the course of a thousand years and dug itself free and into the light. Now the great Kaolin Earth Spirit strides the Upland roads, fighting for the spirit of the Earth; and in times of need calls forth remnants of his buried army still locked in the loving embrace of the soil. "

    bundleEarth_Spirit.mBaseStr = 21
    bundleEarth_Spirit.mStrIncrement = 2.9

    bundleEarth_Spirit.mBaseInt = 18
    bundleEarth_Spirit.mIntIncrement = 2.4

    bundleEarth_Spirit.mBaseAgi = 17
    bundleEarth_Spirit.mAgiIncrement = 1.5


    bundleEarth_Spirit.mBaseMoveSpeed = 305
    bundleEarth_Spirit.mBaseArmor = 1


    bundleEarth_Spirit.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleEarth_Spirit.mName, bundleEarth_Spirit)



    '----------------------------------------------------------
    '-PHOENIX START-----------------------------
    '----------------------------------------------------------
    Dim bundlePhoenix As New HeroBundle
    'FROM UNITBASE
    bundlePhoenix.mIDItem = New dvID(New Guid("47dd2404-188d-4e22-bbf2-ee0d06ae0247"), "Herobundle: Phoenix", eEntity.Herobundle)
    bundlePhoenix.mName = eHeroName.untPhoenix
    bundlePhoenix.DisplayName = "Phoenix"
    bundlePhoenix.mArmorType = eArmorType.Hero
    bundlePhoenix.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/phoenix_vert.jpg"
    bundlePhoenix.mWebpageLink = "http://www.dota2.com/hero/Phoenix/"

    bundlePhoenix.mAttackType = eAttackType.Ranged
    bundlePhoenix.mBaseHitpoints = 0
    bundlePhoenix.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundlePhoenix.mBaseAttackDamage = New ValueWrapper(26, 36)

    bundlePhoenix.mDaySightRange = 1800
    bundlePhoenix.mNightSightRange = 800

    bundlePhoenix.mAttackRange = 500
    bundlePhoenix.mMissileSpeed = 1100

    bundlePhoenix.mAbilityNames.Add(eAbilityName.abIcarus_Dive)
    bundlePhoenix.mAbilityNames.Add(eAbilityName.abFire_Spirits)
    bundlePhoenix.mAbilityNames.Add(eAbilityName.abSun_Ray)
    bundlePhoenix.mAbilityNames.Add(eAbilityName.abSupernova)
    'bundlePhoenix.mAbilityNames.Add(eAbilityName.abToggle_Movement)

    'bundlePhoenix.mAbilityNames.Add(eAbilityName.abLaunch_Fire_Spirit)
    'bundlePhoenix.mAbilityNames.Add(eAbilityName.abStop_Icarus_Dive)
    'bundlePhoenix.mAbilityNames.Add(eAbilityName.abStop_Sun_Ray)
    'FROM HEROBASE
    'Fixed, immutable stats
    bundlePhoenix.mDevName = "Phoenix"

    bundlePhoenix.mRoles.Add(eRole.Initiator)
    bundlePhoenix.mRoles.Add(eRole.Disabler)
    bundlePhoenix.mRoles.Add(eRole.Nuker)

    bundlePhoenix.mPrimaryStat = ePrimaryStat.Strength

    bundlePhoenix.mBio = "Alone across an untouched darkness gleamed the Keeper's first sun, a singular point of conscious light fated to spread warmth into the empty void. Through aeons beyond count, this blinding beacon set to coalescing its incalculable energy before bursting forth the cataclysmic flare of supernova. From this inferno raced new beacons, star progeny identical to its parent, who journeyed an unlit ocean and settled in constellatory array. In time, they too would be made to propagate through supernova flame. So would this dazzling cycle of birth and rebirth repeat until all skies hewn of Titan toil deigned to twinkle and shine.|By this ageless crucible the star that mortals would come to call Phoenix collapsed into being, and like its ancestors was thrust into an endless cosmos to find a place among its stellar brethren. Yet curiosity toward that which the dimming elders comfort in the darkness consumed the fledgling, and so over long cycles it inquired and studied. It learned that among worlds both whole and broken would soon stir a nexus of remarkable variety locked in an enduring conflict of cosmic consequence, a plane which would find itself in need of more influence than a dying sun's distant rays could provide. Thus this infant son of suns took terrestrial form, eagerly travelling to shine its warmth upon those who may need it most, and perhaps seize upon its solar destiny. "

    bundlePhoenix.mBaseStr = 17
    bundlePhoenix.mStrIncrement = 2.9

    bundlePhoenix.mBaseInt = 18
    bundlePhoenix.mIntIncrement = 1.8

    bundlePhoenix.mBaseAgi = 12
    bundlePhoenix.mAgiIncrement = 1.3


    bundlePhoenix.mBaseMoveSpeed = 285

    bundlePhoenix.mBaseArmor = -2

    bundlePhoenix.mBaseArmordebuff = 0.32

    bundlePhoenix.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundlePhoenix.mName, bundlePhoenix)



    '----------------------------------------------------------
    '-ANTI-MAGE START-----------------------------
    '----------------------------------------------------------
    Dim bundleAntiMage As New HeroBundle
    'FROM UNITBASE
    bundleAntiMage.mIDItem = New dvID(New Guid("dfe0b60b-1933-4abd-90d6-b3ff93dc9ff4"), "Herobundle: AntiMage", eEntity.Herobundle)
    bundleAntiMage.mName = eHeroName.untAnti_Mage
    bundleAntiMage.DisplayName = "Anti-Mage"
    bundleAntiMage.mArmorType = eArmorType.Hero
    bundleAntiMage.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/antimage_vert.jpg"
    bundleAntiMage.mWebpageLink = "http://www.dota2.com/hero/Anti-Mage/"

    bundleAntiMage.mAttackType = eAttackType.Melee
    bundleAntiMage.mBaseHitpoints = 0
    bundleAntiMage.mBaseAttackSpeed = 1.45 '  http://dota2.gamepedia.com/Attack_speed

    bundleAntiMage.mBaseAttackDamage = New ValueWrapper(27, 31)

    bundleAntiMage.mDaySightRange = 1800
    bundleAntiMage.mNightSightRange = 800

    bundleAntiMage.mAttackRange = 128
    bundleAntiMage.mMissileSpeed = Nothing

    bundleAntiMage.mAbilityNames.Add(eAbilityName.abMana_Break)
    bundleAntiMage.mAbilityNames.Add(eAbilityName.abAnti_Mage_Blink)
    bundleAntiMage.mAbilityNames.Add(eAbilityName.abSpell_Shield)
    bundleAntiMage.mAbilityNames.Add(eAbilityName.abMana_Void)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleAntiMage.mDevName = "Anti-Mage"

    bundleAntiMage.mRoles.Add(eRole.Carry)
    bundleAntiMage.mRoles.Add(eRole.Escape)

    bundleAntiMage.mPrimaryStat = ePrimaryStat.Agility

    bundleAntiMage.mBio = "The monks of Turstarkuri watched the rugged valleys below their mountain monastery as wave after wave of invaders swept through the lower kingdoms. Ascetic and pragmatic, in their remote monastic eyrie they remained aloof from mundane strife, wrapped in meditation that knew no gods or elements of magic. Then came the Legion of the Dead God, crusaders with a sinister mandate to replace all local worship with their Unliving Lord's poisonous nihilosophy. From a landscape that had known nothing but blood and battle for a thousand years, they tore the souls and bones of countless fallen legions and pitched them against Turstarkuri. The monastery stood scarcely a fortnight against the assault, and the few monks who bothered to surface from their meditations believed the invaders were but demonic visions sent to distract them from meditation. They died where they sat on their silken cushions. Only one youth survived--a pilgrim who had come as an acolyte, seeking wisdom, but had yet to be admitted to the monastery. He watched in horror as the monks to whom he had served tea and nettles were first slaughtered, then raised to join the ranks of the Dead God's priesthood. With nothing but a few of Turstarkuri's prized dogmatic scrolls, he crept away to the comparative safety of other lands, swearing to obliterate not only the Dead God's magic users--but to put an end to magic altogether. "

    bundleAntiMage.mBaseStr = 20
    bundleAntiMage.mStrIncrement = 1.2

    bundleAntiMage.mBaseInt = 15
    bundleAntiMage.mIntIncrement = 1.8

    bundleAntiMage.mBaseAgi = 22
    bundleAntiMage.mAgiIncrement = 2.8


    bundleAntiMage.mBaseMoveSpeed = 315

    bundleAntiMage.mBaseArmor = -1

    bundleAntiMage.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleAntiMage.mName, bundleAntiMage)



    '----------------------------------------------------------
    '-DROW RANGER START-----------------------------
    '----------------------------------------------------------
    Dim bundleDrow_Ranger As New HeroBundle
    'FROM UNITBASE
    bundleDrow_Ranger.mIDItem = New dvID(New Guid("1f0205a6-34c9-4c81-b016-018f993071dc"), "Herobundle: Drow Ranger", eEntity.Herobundle)
    bundleDrow_Ranger.mName = eHeroName.untDrow_Ranger
    bundleDrow_Ranger.DisplayName = "Drow Ranger"
    bundleDrow_Ranger.mArmorType = eArmorType.Hero
    bundleDrow_Ranger.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/drow_ranger_vert.jpg"
    bundleDrow_Ranger.mWebpageLink = "http://www.dota2.com/hero/Drow_Ranger/"

    bundleDrow_Ranger.mAttackType = eAttackType.Ranged
    bundleDrow_Ranger.mBaseHitpoints = 0
    bundleDrow_Ranger.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleDrow_Ranger.mBaseAttackDamage = New ValueWrapper(18, 29)

    bundleDrow_Ranger.mDaySightRange = 1800
    bundleDrow_Ranger.mNightSightRange = 800

    bundleDrow_Ranger.mAttackRange = 625
    bundleDrow_Ranger.mMissileSpeed = 1250


    bundleDrow_Ranger.mAbilityNames.Add(eAbilityName.abFrost_Arrows)
    bundleDrow_Ranger.mAbilityNames.Add(eAbilityName.abGust)
    bundleDrow_Ranger.mAbilityNames.Add(eAbilityName.abPrecision_Aura)
    bundleDrow_Ranger.mAbilityNames.Add(eAbilityName.abMarksmanship)



    'FROM HEROBASE
    'Fixed, immutable stats
    bundleDrow_Ranger.mDevName = "Drow_Ranger"

    bundleDrow_Ranger.mRoles.Add(eRole.Carry)

    bundleDrow_Ranger.mPrimaryStat = ePrimaryStat.Agility

    bundleDrow_Ranger.mBio = "Drow Ranger's given name is Traxex-a name well suited to the short, trollish, rather repulsive Drow people. But Traxex herself is not a Drow. Her parents were travelers in a caravan set upon by bandits, whose noisy slaughter of innocents roused the ire of the quiet Drow people. After the battle settled, the Drow discovered a small girl-child hiding in the ruined wagons, and agreed she could not be abandoned. Even as child, Traxex showed herself naturally adept at the arts they prized: Stealth, silence, subtlety. In spirit, if not in physique, she might have been a Drow changeling, returned to her proper home. But as she grew, she towered above her family and came to think of herself as ugly. After all, her features were smooth and symmetrical, entirely devoid of warts and coarse whiskers. Estranged from her adopted tribe, she withdrew to live alone in the woods. Lost travelers who find their way from the forest sometimes speak of an impossibly beautiful Ranger who peered at them from deep among the trees, then vanished like a dream before they could approach. Lithe and stealthy, icy hot, she moves like mist in silence. That whispering you hear is her frozen arrows finding an enemy's heart. "

    bundleDrow_Ranger.mBaseStr = 17
    bundleDrow_Ranger.mStrIncrement = 1.9

    bundleDrow_Ranger.mBaseInt = 15
    bundleDrow_Ranger.mIntIncrement = 1.4

    bundleDrow_Ranger.mBaseAgi = 26
    bundleDrow_Ranger.mAgiIncrement = 1.9


    bundleDrow_Ranger.mBaseMoveSpeed = 300

    bundleDrow_Ranger.mBaseArmor = -3

    bundleDrow_Ranger.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleDrow_Ranger.mName, bundleDrow_Ranger)



    '----------------------------------------------------------
    '-JUGGERNAUT START-----------------------------
    '----------------------------------------------------------
    Dim bundleJuggernaut As New HeroBundle
    'FROM UNITBASE
    bundleJuggernaut.mIDItem = New dvID(New Guid("bb786bcc-c06b-4802-b2ef-deb2ff1de7b2"), "Herobundle: Juggernaut", eEntity.Herobundle)
    bundleJuggernaut.mName = eHeroName.untJuggernaut
    bundleJuggernaut.DisplayName = "Juggernaut"
    bundleJuggernaut.mArmorType = eArmorType.Hero
    bundleJuggernaut.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/juggernaut_vert.jpg"
    bundleJuggernaut.mWebpageLink = "http://www.dota2.com/hero/Juggernaut/"

    bundleJuggernaut.mAttackType = eAttackType.Melee
    bundleJuggernaut.mBaseHitpoints = 0
    bundleJuggernaut.mBaseAttackSpeed = 1.4  'http://dota2.gamepedia.com/Attack_speed

    bundleJuggernaut.mBaseAttackDamage = New ValueWrapper(24, 28)

    bundleJuggernaut.mDaySightRange = 1800
    bundleJuggernaut.mNightSightRange = 800

    bundleJuggernaut.mAttackRange = 128
    bundleJuggernaut.mMissileSpeed = Nothing

    bundleJuggernaut.mAbilityNames.Add(eAbilityName.abBlade_Fury)

    bundleJuggernaut.mAbilityNames.Add(eAbilityName.abHealing_Ward)
    bundleJuggernaut.mAbilityNames.Add(eAbilityName.abBlade_Dance)

    bundleJuggernaut.mAbilityNames.Add(eAbilityName.abOmnislash)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleJuggernaut.mDevName = "Juggernaut"

    bundleJuggernaut.mRoles.Add(eRole.Carry)
    bundleJuggernaut.mRoles.Add(eRole.Pusher)

    bundleJuggernaut.mPrimaryStat = ePrimaryStat.Agility

    bundleJuggernaut.mBio = "No one has ever seen the face hidden beneath the mask of Yurnero the Juggernaut. It is only speculation that he even has one. For defying a corrupt lord, Yurnero was exiled from the ancient Isle of Masks--a punishment that saved his life. The isle soon after vanished beneath the waves in a night of vengeful magic. He alone remains to carry on the Isle's long Juggernaut tradition, one of ritual and swordplay. The last practitioner of the art, Yurnero's confidence and courage are the result of endless practice; his inventive bladework proves that he has never stopped challenging himself. Still, his motives are as unreadable as his expression. For a hero who has lost everything twice over, he fights as if victory is a foregone conclusion. "

    bundleJuggernaut.mBaseStr = 20
    bundleJuggernaut.mStrIncrement = 1.9

    bundleJuggernaut.mBaseInt = 14
    bundleJuggernaut.mIntIncrement = 1.4

    bundleJuggernaut.mBaseAgi = 20
    bundleJuggernaut.mAgiIncrement = 2.85


    bundleJuggernaut.mBaseMoveSpeed = 305

    bundleJuggernaut.mBaseArmor = 0

    bundleJuggernaut.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleJuggernaut.mName, bundleJuggernaut)



    '----------------------------------------------------------
    '-MIRANA START-----------------------------
    '----------------------------------------------------------
    Dim bundleMirana As New HeroBundle
    'FROM UNITBASE
    bundleMirana.mIDItem = New dvID(New Guid("55b42256-11ba-4fab-abdb-15684fb49a58"), "Herobundle: Mirana", eEntity.Herobundle)
    bundleMirana.mName = eHeroName.untMirana
    bundleMirana.DisplayName = "Mirana"
    bundleMirana.mArmorType = eArmorType.Hero
    bundleMirana.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/mirana_vert.jpg"
    bundleMirana.mWebpageLink = "http://www.dota2.com/hero/Mirana/"

    bundleMirana.mAttackType = eAttackType.Ranged
    bundleMirana.mBaseHitpoints = 0
    bundleMirana.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleMirana.mBaseAttackDamage = New ValueWrapper(18, 29)

    bundleMirana.mDaySightRange = 1800
    bundleMirana.mNightSightRange = 800

    bundleMirana.mAttackRange = 600
    bundleMirana.mMissileSpeed = 900

    bundleMirana.mAbilityNames.Add(eAbilityName.abStarstorm)
    bundleMirana.mAbilityNames.Add(eAbilityName.abSacred_Arrow)
    bundleMirana.mAbilityNames.Add(eAbilityName.abLeap)
    bundleMirana.mAbilityNames.Add(eAbilityName.abMoonlight_Shadow)




    'FROM HEROBASE
    'Fixed, immutable stats
    bundleMirana.mDevName = "Mirana"

    bundleMirana.mRoles.Add(eRole.Carry)
    bundleMirana.mRoles.Add(eRole.Nuker)
    bundleMirana.mRoles.Add(eRole.Disabler)
    bundleMirana.mRoles.Add(eRole.Escape)

    bundleMirana.mPrimaryStat = ePrimaryStat.Agility

    bundleMirana.mBio = "Born to a royal family, a blood princess next in line for the Solar Throne, Mirana willingly surrendered any claim to mundane land or titles when she dedicated herself completely to the service of Selemene, Goddess of the Moon. Known ever since as Princess of the Moon, Mirana prowls the sacred Nightsilver Woods searching for any who would dare poach the sacred luminous lotus from the silvery pools of the Goddess's preserve. Riding on her enormous feline familiar, she is poised, proud and fearless, attuned to the phases of the moon and the wheeling of the greater constellations. Her bow, tipped with sharp shards of lunar ore, draws on the moon's power to charge its arrows of light. "

    bundleMirana.mBaseStr = 17
    bundleMirana.mStrIncrement = 1.85

    bundleMirana.mBaseInt = 17
    bundleMirana.mIntIncrement = 1.65

    bundleMirana.mBaseAgi = 20
    bundleMirana.mAgiIncrement = 2.75


    bundleMirana.mBaseMoveSpeed = 300

    bundleMirana.mBaseArmor = -1

    bundleMirana.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleMirana.mName, bundleMirana)



    '----------------------------------------------------------
    '-MORPHLING START-----------------------------
    '----------------------------------------------------------
    Dim bundleMorphling As New HeroBundle
    'FROM UNITBASE
    bundleMorphling.mIDItem = New dvID(New Guid("96519dee-c64d-42ee-b03b-df27992ec25b"), "Herobundle: Morphling", eEntity.Herobundle)
    bundleMorphling.mName = eHeroName.untMorphling
    bundleMorphling.DisplayName = "Morphling"
    bundleMorphling.mArmorType = eArmorType.Hero
    bundleMorphling.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/morphling_vert.jpg"
    bundleMorphling.mWebpageLink = "http://www.dota2.com/hero/Morphling/"

    bundleMorphling.mAttackType = eAttackType.Ranged
    bundleMorphling.mBaseHitpoints = 0
    bundleMorphling.mBaseAttackSpeed = 1.6 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleMorphling.mBaseAttackDamage = New ValueWrapper(13, 22)

    bundleMorphling.mDaySightRange = 1800
    bundleMorphling.mNightSightRange = 800

    bundleMorphling.mAttackRange = 350
    bundleMorphling.mMissileSpeed = 1300

    bundleMorphling.mAbilityNames.Add(eAbilityName.abWaveform)
    bundleMorphling.mAbilityNames.Add(eAbilityName.abAdaptive_Strike)
    bundleMorphling.mAbilityNames.Add(eAbilityName.abMorph_Agility_Gain)
    'bundleMorphling.mAbilityNames.Add(eAbilityName.abMorph_Strength_Gain)

    'bundleMorphling.mAbilityNames.Add(eAbilityName.abReplicate)
    bundleMorphling.mAbilityNames.Add(eAbilityName.abMorph_Replicate)



    'FROM HEROBASE
    'Fixed, immutable stats
    bundleMorphling.mDevName = "Morphling"

    bundleMorphling.mRoles.Add(eRole.Carry)
    bundleMorphling.mRoles.Add(eRole.Escape)
    bundleMorphling.mRoles.Add(eRole.Initiator)
    bundleMorphling.mRoles.Add(eRole.Nuker)

    bundleMorphling.mPrimaryStat = ePrimaryStat.Agility

    bundleMorphling.mBio = "For dark eons the comet circled. Held in thrall to a distant sun, bound by gravity's inexorable pull, the massive ball of ice careened through the blackness between worlds, made strange by its dark journey. On the eve of the ancient war of the Vloy, it punched down through the sky and lit a glowing trail across the night, a sign both armies took for an omen. The frozen ball melted in a flash of boiling heat, as below two forces enjoined in battle across the border of a narrow river. Thus freed from its icy stasis, the Morphling was born into conflict, an elemental power at one with the tides of the ocean, capricious and unconstrained. He entered the fight, instinctively taking the form of the first general who dared set foot across the water, and then struck him dead. As the motley warriors clashed, he shifted from form to form throughout the battle, instantly absorbing the ways of these strange creatures--now a footsoldier, now an archer, now the cavalryman--until, by the time the last soldier fell, Morphling had played every part. The battle's end was his beginning. "

    bundleMorphling.mBaseStr = 19
    bundleMorphling.mStrIncrement = 2

    bundleMorphling.mBaseInt = 17
    bundleMorphling.mIntIncrement = 1.5

    bundleMorphling.mBaseAgi = 24
    bundleMorphling.mAgiIncrement = 3


    bundleMorphling.mBaseMoveSpeed = 285

    bundleMorphling.mBaseArmor = -2

    bundleMorphling.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleMorphling.mName, bundleMorphling)



    '----------------------------------------------------------
    '-PHANTOM LANCER START-----------------------------
    '----------------------------------------------------------
    Dim bundlePhantom_Lancer As New HeroBundle
    'FROM UNITBASE
    bundlePhantom_Lancer.mIDItem = New dvID(New Guid("e3942f67-597f-4b0d-8d74-b9cc474bbd59"), "Herobundle: Phantom Lancer", eEntity.Herobundle)
    bundlePhantom_Lancer.mName = eHeroName.untPhantom_Lancer
    bundlePhantom_Lancer.DisplayName = "Phantom Lancer"
    bundlePhantom_Lancer.mArmorType = eArmorType.Hero
    bundlePhantom_Lancer.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/phantom_lancer_vert.jpg"
    bundlePhantom_Lancer.mWebpageLink = "http://www.dota2.com/hero/Phantom_Lancer/"

    bundlePhantom_Lancer.mAttackType = eAttackType.Melee
    bundlePhantom_Lancer.mBaseHitpoints = 0
    bundlePhantom_Lancer.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundlePhantom_Lancer.mBaseAttackDamage = New ValueWrapper(22, 44)

    bundlePhantom_Lancer.mDaySightRange = 1800
    bundlePhantom_Lancer.mNightSightRange = 800

    bundlePhantom_Lancer.mAttackRange = 128
    bundlePhantom_Lancer.mMissileSpeed = Nothing

    bundlePhantom_Lancer.mAbilityNames.Add(eAbilityName.abSpirit_Lance)
    bundlePhantom_Lancer.mAbilityNames.Add(eAbilityName.abDoppelganger)
    bundlePhantom_Lancer.mAbilityNames.Add(eAbilityName.abPhantom_Rush)
    bundlePhantom_Lancer.mAbilityNames.Add(eAbilityName.abJuxtapose)




    'FROM HEROBASE
    'Fixed, immutable stats
    bundlePhantom_Lancer.mDevName = "Phantom_Lancer"

    bundlePhantom_Lancer.mRoles.Add(eRole.Carry)
    bundlePhantom_Lancer.mRoles.Add(eRole.Escape)
    bundlePhantom_Lancer.mRoles.Add(eRole.Pusher)

    bundlePhantom_Lancer.mPrimaryStat = ePrimaryStat.Agility

    bundlePhantom_Lancer.mBio = "The remote village of Pole had no knowledge of the wars raging in the heart of the kingdom. For them, the quiet of spear fishing, and a family meal were all that a full life required. Yet war came for them nonetheless. Joining the able-bodied conscripts as they filed passed their homes, the humble lancer Azwraith vowed to bring peace to his kingdom, and in so doing, his people. Placed with his kin in the vanguard of the final assault against the Dread Magus Vorn, the cost to his fellows was absolute. As the charging force battled toward the fortress, Azwraith alone among his kind remained standing, and he alone was able to infiltrate the keep. Focused and infuriated by the slaughter of his brothers, Azwraith bested each of the wizard's deadly traps and conjured guardians. Soon the simple fisherman arrived at Vorn's tower sanctum. The pair dueled through the night, pike to staff, as chaos raged below, and with a deafening cry Azwraith pierced his enemy. But the wizard did not simply expire; he exploded into uncountable shards of light, penetrating his killer with power. As the dust settled and the smoke of combat began to clear, Azwraith found himself standing among a throng of his kin. Each seemed to be dressed as he was, each seemed armed as he was, and he could sense that each thought as he did. Aware that his allies were approaching, he willed these phantoms to hide themselves, and one by one they began to vanish into nothingness. As the soldiers came upon the sanctum, they found the warrior that had bested the wizard. When they approached their champion, the lancer vanished. The pikeman who had stood before them was no more than another phantom. "

    bundlePhantom_Lancer.mBaseStr = 18
    bundlePhantom_Lancer.mStrIncrement = 1.7

    bundlePhantom_Lancer.mBaseInt = 21
    bundlePhantom_Lancer.mIntIncrement = 2

    bundlePhantom_Lancer.mBaseAgi = 23
    bundlePhantom_Lancer.mAgiIncrement = 4.2


    bundlePhantom_Lancer.mBaseMoveSpeed = 290

    bundlePhantom_Lancer.mBaseArmor = 0

    bundlePhantom_Lancer.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundlePhantom_Lancer.mName, bundlePhantom_Lancer)



    '----------------------------------------------------------
    '-VENGEFUL SPIRIT START-----------------------------
    '----------------------------------------------------------
    Dim bundleVengeful_Spirit As New HeroBundle
    'FROM UNITBASE
    bundleVengeful_Spirit.mIDItem = New dvID(New Guid("6f3adae7-24b3-4b44-b218-5b5b5e561468"), "Herobundle: Vengeful Spirit", eEntity.Herobundle)
    bundleVengeful_Spirit.mName = eHeroName.untVengeful_Spirit
    bundleVengeful_Spirit.DisplayName = "Vengeful Spirit"
    bundleVengeful_Spirit.mArmorType = eArmorType.Hero
    bundleVengeful_Spirit.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/vengefulspirit_vert.jpg"
    bundleVengeful_Spirit.mWebpageLink = "http://www.dota2.com/hero/Vengeful_Spirit/"

    bundleVengeful_Spirit.mAttackType = eAttackType.Ranged
    bundleVengeful_Spirit.mBaseHitpoints = 0
    bundleVengeful_Spirit.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleVengeful_Spirit.mBaseAttackDamage = New ValueWrapper(12, 26)

    bundleVengeful_Spirit.mDaySightRange = 1800
    bundleVengeful_Spirit.mNightSightRange = 800

    bundleVengeful_Spirit.mAttackRange = 400
    bundleVengeful_Spirit.mMissileSpeed = 1500


    bundleVengeful_Spirit.mAbilityNames.Add(eAbilityName.abMagic_Missile)
    bundleVengeful_Spirit.mAbilityNames.Add(eAbilityName.abVengeance_Aura)
    bundleVengeful_Spirit.mAbilityNames.Add(eAbilityName.abWave_Of_Terror)
    bundleVengeful_Spirit.mAbilityNames.Add(eAbilityName.abNether_Swap)




    'FROM HEROBASE
    'Fixed, immutable stats
    bundleVengeful_Spirit.mDevName = "Vengeful_Spirit"

    bundleVengeful_Spirit.mRoles.Add(eRole.Support)
    bundleVengeful_Spirit.mRoles.Add(eRole.Disabler)
    bundleVengeful_Spirit.mRoles.Add(eRole.LaneSupport)
    bundleVengeful_Spirit.mRoles.Add(eRole.Initiator)

    bundleVengeful_Spirit.mPrimaryStat = ePrimaryStat.Agility

    bundleVengeful_Spirit.mBio = "Even the most contented Skywrath is an ill-tempered creature, naturally inclined to seek revenge for the slightest insult. But Vengeful Spirit is the essence of vengeance. Once a proud and savage Skywrath scion, Shendelzare was first in succession for the Ghastly Eyrie until a sister's treachery robbed her of her birthright. Snared in an assassin's net, Shendelzare tore free only at the cost of her wings, limping away in the ultimate humiliation: On foot. With her wings broken, she knew the Skywrath would never accept her as ruler; and in the highest roost of the Eyrie, inaccessible except by winged flight, her sister was untouchable. Unwilling to live as a flightless cripple, and desiring revenge far more than earthly power, the fallen princess drove a bargain with the goddess Scree'auk: She surrendered her broken body for an imperishable form of spirit energy, driven by vengeance, capable of doing great damage in the material plane. She may spend eternity flightless, but she will have her revenge. "

    bundleVengeful_Spirit.mBaseStr = 18
    bundleVengeful_Spirit.mStrIncrement = 2.6

    bundleVengeful_Spirit.mBaseInt = 15
    bundleVengeful_Spirit.mIntIncrement = 1.75

    bundleVengeful_Spirit.mBaseAgi = 27
    bundleVengeful_Spirit.mAgiIncrement = 2.8


    bundleVengeful_Spirit.mBaseMoveSpeed = 295
    bundleVengeful_Spirit.mBaseArmor = -2


    bundleVengeful_Spirit.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleVengeful_Spirit.mName, bundleVengeful_Spirit)



    '----------------------------------------------------------
    '-RIKI START-----------------------------
    '----------------------------------------------------------
    Dim bundleRiki As New HeroBundle
    'FROM UNITBASE
    bundleRiki.mIDItem = New dvID(New Guid("ee73fb9a-5e5a-414b-b6d6-0b35723a8795"), "Herobundle: Riki", eEntity.Herobundle)
    bundleRiki.mName = eHeroName.untRiki
    bundleRiki.DisplayName = "Riki"
    bundleRiki.mArmorType = eArmorType.Hero
    bundleRiki.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/riki_vert.jpg"
    bundleRiki.mWebpageLink = "http://www.dota2.com/hero/Riki/"

    bundleRiki.mAttackType = eAttackType.Melee
    bundleRiki.mBaseHitpoints = 0
    bundleRiki.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleRiki.mBaseAttackDamage = New ValueWrapper(4, 8)

    bundleRiki.mDaySightRange = 1800
    bundleRiki.mNightSightRange = 800

    bundleRiki.mAttackRange = 128
    bundleRiki.mMissileSpeed = Nothing

    bundleRiki.mAbilityNames.Add(eAbilityName.abSmoke_Screen)
    bundleRiki.mAbilityNames.Add(eAbilityName.abBlink_Strike)
    bundleRiki.mAbilityNames.Add(eAbilityName.abBackstab)
    bundleRiki.mAbilityNames.Add(eAbilityName.abPermanent_Invisibility)



    'FROM HEROBASE
    'Fixed, immutable stats
    bundleRiki.mDevName = "Riki"

    bundleRiki.mRoles.Add(eRole.Carry)
    bundleRiki.mRoles.Add(eRole.Escape)

    bundleRiki.mPrimaryStat = ePrimaryStat.Agility

    bundleRiki.mBio = "Riki was born middle child to the great dynasty of Tahlin. With an older brother groomed for the throne, and a younger brother coddled and kept, Riki, the small middle son, seemed born for the art of invisibility. It was an art he cultivated, and one which ultimately saved his life on the night that his people were betrayed and his family slaughtered. Of all the royal line, he alone escaped, small and agile, unassuming, using smoke as cover. He cut his way out of the royal grounds, using the advantage of surprise, quietly slitting the throats of one enemy warrior after another. Now free of his royal responsibilities, Riki uses his talents in service to a new trade: Stealth Assassin. He silences his enemies, sharpening his skills, hoping to one day take revenge on those who killed his family and robbed him of his birthright. "

    bundleRiki.mBaseStr = 17
    bundleRiki.mStrIncrement = 2

    bundleRiki.mBaseInt = 14
    bundleRiki.mIntIncrement = 1.3

    bundleRiki.mBaseAgi = 34
    bundleRiki.mAgiIncrement = 2.9


    bundleRiki.mBaseMoveSpeed = 300
    bundleRiki.mBaseArmor = 1


    bundleRiki.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleRiki.mName, bundleRiki)



    '----------------------------------------------------------
    '-SNIPER START-----------------------------
    '----------------------------------------------------------
    Dim bundleSniper As New HeroBundle
    'FROM UNITBASE
    bundleSniper.mIDItem = New dvID(New Guid("767512fc-cb96-46ed-ae05-ef35400a5004"), "Herobundle: Sniper", eEntity.Herobundle)
    bundleSniper.mName = eHeroName.untSniper
    bundleSniper.DisplayName = "Sniper"
    bundleSniper.mArmorType = eArmorType.Hero
    bundleSniper.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/sniper_vert.jpg"
    bundleSniper.mWebpageLink = "http://www.dota2.com/hero/Sniper/"

    bundleSniper.mAttackType = eAttackType.Ranged
    bundleSniper.mBaseHitpoints = 0
    bundleSniper.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleSniper.mBaseAttackDamage = New ValueWrapper(15, 21)

    bundleSniper.mDaySightRange = 1800
    bundleSniper.mNightSightRange = 1000

    bundleSniper.mAttackRange = 550
    bundleSniper.mMissileSpeed = 3000

    bundleSniper.mAbilityNames.Add(eAbilityName.abShrapnel)

    bundleSniper.mAbilityNames.Add(eAbilityName.abHeadshot)

    bundleSniper.mAbilityNames.Add(eAbilityName.abTake_Aim)
    bundleSniper.mAbilityNames.Add(eAbilityName.abAssassinate)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleSniper.mDevName = "Sniper"

    bundleSniper.mRoles.Add(eRole.Carry)

    bundleSniper.mPrimaryStat = ePrimaryStat.Agility

    bundleSniper.mBio = "Kardel Sharpeye was born deep in the mountains of Knollen where, since time immemorial, Keen Folk have survived by hunting the strange, cliff-dwelling steepstalkers above their village, shooting them from a distance and collecting the carcasses where they fell. Sharpeye was among the best of these strange mountain keens for whom projectile weapons are but another appendage, and to shoot is as natural as to touch.|On his day of summoning, when he was to gain full standing in his village, Sharpeye took the ancient test: a single shot from the valley floor to strike a beast down from the cliffs. To miss was to be dishonored. With his entire village standing vigil, Sharpeye took his shot. A steepstalker fell; the crowd cheered. But when the carcass was collected, the village grew silent, for the elders found that the bullet had pierced its glittering central eye then fallen to be clenched in the steepstalker's mandibles. This ominous sign was the literal opening of a dark prophecy, foretelling both greatness and exile for the gunman who made such a shot. Sharpeye the Sniper was thus, by his own skill, condemned to make his way apart from his people-and unwelcome back among them until he has fulfilled the remainder of the prophecy by attaining legendary stature on a field of battle. "

    bundleSniper.mBaseStr = 16
    bundleSniper.mStrIncrement = 1.7

    bundleSniper.mBaseInt = 15
    bundleSniper.mIntIncrement = 2.6

    bundleSniper.mBaseAgi = 21
    bundleSniper.mAgiIncrement = 2.9


    bundleSniper.mBaseMoveSpeed = 290

    bundleSniper.mBaseArmor = -1

    bundleSniper.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleSniper.mName, bundleSniper)



    '----------------------------------------------------------
    '-TEMPLAR ASSASSIN START-----------------------------
    '----------------------------------------------------------
    Dim bundleTemplar_Assassin As New HeroBundle
    'FROM UNITBASE
    bundleTemplar_Assassin.mIDItem = New dvID(New Guid("5aebf1d5-8289-4a60-b974-40b063dd3e60"), "Herobundle: Templar Assassin", eEntity.Herobundle)
    bundleTemplar_Assassin.mName = eHeroName.untTemplar_Assassin
    bundleTemplar_Assassin.DisplayName = "Templar Assassin"
    bundleTemplar_Assassin.mArmorType = eArmorType.Hero
    bundleTemplar_Assassin.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/templar_assassin_vert.jpg"
    bundleTemplar_Assassin.mWebpageLink = "http://www.dota2.com/hero/Templar_Assassin/"

    bundleTemplar_Assassin.mAttackType = eAttackType.Ranged
    bundleTemplar_Assassin.mBaseHitpoints = 0
    bundleTemplar_Assassin.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleTemplar_Assassin.mBaseAttackDamage = New ValueWrapper(30, 36)

    bundleTemplar_Assassin.mDaySightRange = 1800
    bundleTemplar_Assassin.mNightSightRange = 800

    bundleTemplar_Assassin.mAttackRange = 140
    bundleTemplar_Assassin.mMissileSpeed = 900

    bundleTemplar_Assassin.mAbilityNames.Add(eAbilityName.abRefraction)
    bundleTemplar_Assassin.mAbilityNames.Add(eAbilityName.abMeld)
    bundleTemplar_Assassin.mAbilityNames.Add(eAbilityName.abPsi_Blades)
    bundleTemplar_Assassin.mAbilityNames.Add(eAbilityName.abPsionic_Trap)

    'bundleTemplar_Assassin.mAbilityNames.Add(eAbilityName.abTrap)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleTemplar_Assassin.mDevName = "Templar_Assassin"

    bundleTemplar_Assassin.mRoles.Add(eRole.Carry)
    bundleTemplar_Assassin.mRoles.Add(eRole.Escape)

    bundleTemplar_Assassin.mPrimaryStat = ePrimaryStat.Agility

    bundleTemplar_Assassin.mBio = "Lanaya, the Templar Assassin, came to her calling by a path of curious inquiry. Possessed of a scientific bent, she spent her early years engaged in meticulous study of nature's laws--peering into grimoires of magic and alchemy, recreating experiments from charred fragments of the Violet Archives, and memorizing observations of the Keen recordkeepers. Already quiet and secretive by nature, the difficulty of acquiring these objects further reinforced her skills of stealth. Had she been less retiring, she might have become notorious among the guilds as a thief-scholar. Instead her investigations led her into far more obscure corners. As she devoted her furtive talents to unlocking the secrets of the universe, she instead unlocked a secret door that exists in nature itself: the entryway to the most Hidden Temple. The intelligences that waited beyond that portal, proved to be expecting her, and whatever mysteries they revealed in the moment of their discovery was nothing compared to the answers they held out to Lanaya should she continue in their service. She swore to protect the mysteries, but more to the point, in service to the Hidden Temple she satisfies her endless craving for understanding. In the eyes of each foe she expunges, a bit more of the mystery is revealed. "

    bundleTemplar_Assassin.mBaseStr = 18
    bundleTemplar_Assassin.mStrIncrement = 2.1

    bundleTemplar_Assassin.mBaseInt = 20
    bundleTemplar_Assassin.mIntIncrement = 2

    bundleTemplar_Assassin.mBaseAgi = 23
    bundleTemplar_Assassin.mAgiIncrement = 2.7


    bundleTemplar_Assassin.mBaseMoveSpeed = 305
    bundleTemplar_Assassin.mBaseArmor = 1


    bundleTemplar_Assassin.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleTemplar_Assassin.mName, bundleTemplar_Assassin)



    '----------------------------------------------------------
    '-LUNA START-----------------------------
    '----------------------------------------------------------
    Dim bundleLuna As New HeroBundle
    'FROM UNITBASE
    bundleLuna.mIDItem = New dvID(New Guid("5fdd0ce3-fb4e-4ef0-b4b6-882272527bd0"), "Herobundle: Luna", eEntity.Herobundle)
    bundleLuna.mName = eHeroName.untLuna
    bundleLuna.DisplayName = "Luna"
    bundleLuna.mArmorType = eArmorType.Hero
    bundleLuna.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/luna_vert.jpg"
    bundleLuna.mWebpageLink = "http://www.dota2.com/hero/Luna/"

    bundleLuna.mAttackType = eAttackType.Ranged
    bundleLuna.mBaseHitpoints = 0
    bundleLuna.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleLuna.mBaseAttackDamage = New ValueWrapper(26, 32)

    bundleLuna.mDaySightRange = 1800
    bundleLuna.mNightSightRange = 800

    bundleLuna.mAttackRange = 330
    bundleLuna.mMissileSpeed = 900

    bundleLuna.mAbilityNames.Add(eAbilityName.abLucent_Beam)
    bundleLuna.mAbilityNames.Add(eAbilityName.abMoon_Glaive)


    bundleLuna.mAbilityNames.Add(eAbilityName.abLunar_Blessing)
    bundleLuna.mAbilityNames.Add(eAbilityName.abEclipse)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleLuna.mDevName = "Luna"

    bundleLuna.mRoles.Add(eRole.Carry)
    bundleLuna.mRoles.Add(eRole.Nuker)

    bundleLuna.mPrimaryStat = ePrimaryStat.Agility

    bundleLuna.mBio = "How had she been reduced to this? She was once the Scourge of the Plains, a merciless leader of men and beasts, and able to sow terror wherever she dared. Now she was far from her homeland, driven half mad from starvation and months of wandering, her army long dead or worse. As she stood at the edge of an ancient forest, a pair of glowing eyes spied on from an elder branch. Something beautiful and deadly sought a meal in the wilting dusk. Without a sound, it turned and left. Fury overtook her. Clutching a rust-eaten dagger, she charged after the beast determined to reclaim even a shred of her past glory, but her quarry would not be caught. Three times she cornered the creature among the rocks and trees, and three times she pounced only to witness its fading shadow darting further into the woods. Yet the full moon shone brightly, and the creature's trail was easy to follow. Arriving in a clearing atop a high hill, the beast's massive feline form sat in the open, attentive and waiting. When the woman brandished her dagger, the creature reared and roared and charged. Death, it seemed, had come for her at long last in this strange place. She stood, calm and ready. A flash of movement, and the beast snatched the dagger from her hand before vanishing into the forest. Stillness. Hooded figures approached. In reverent tones they revealed that Selemene, Goddess of the Moon, had chosen her, had guided her, had tested her. Unwittingly she had endured the sacred rites of the Dark Moon, warriors of the Nightsilver Woods.|She was offered a choice: join the Dark Moon and pledge herself to the service of Selemene, or leave and never return. She did not hesitate. Embracing her absolution, she renounced her bloody past, and took up a new mantle as Luna of the Dark Moon, the dreaded Moon Rider, ruthless and ever-loyal guardian of the Nightsilver Woods. "

    bundleLuna.mBaseStr = 15
    bundleLuna.mStrIncrement = 1.9

    bundleLuna.mBaseInt = 16
    bundleLuna.mIntIncrement = 1.85

    bundleLuna.mBaseAgi = 18
    bundleLuna.mAgiIncrement = 2.8


    bundleLuna.mBaseMoveSpeed = 330
    bundleLuna.mBaseArmor = 1


    bundleLuna.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleLuna.mName, bundleLuna)



    '----------------------------------------------------------
    '-BOUNTY HUNTER START-----------------------------
    '----------------------------------------------------------
    Dim bundleBounty_Hunter As New HeroBundle
    'FROM UNITBASE
    bundleBounty_Hunter.mIDItem = New dvID(New Guid("9ca66d7b-feeb-43db-acf0-dfbbb2703b08"), "Herobundle: Bounty Hunter", eEntity.Herobundle)
    bundleBounty_Hunter.mName = eHeroName.untBounty_Hunter
    bundleBounty_Hunter.DisplayName = "Bounty Hunter"
    bundleBounty_Hunter.mArmorType = eArmorType.Hero
    bundleBounty_Hunter.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/bounty_hunter_vert.jpg"
    bundleBounty_Hunter.mWebpageLink = "http://www.dota2.com/hero/Bounty_Hunter/"

    bundleBounty_Hunter.mAttackType = eAttackType.Melee
    bundleBounty_Hunter.mBaseHitpoints = 0
    bundleBounty_Hunter.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleBounty_Hunter.mBaseAttackDamage = New ValueWrapper(24, 38)

    bundleBounty_Hunter.mDaySightRange = 1800
    bundleBounty_Hunter.mNightSightRange = 1000

    bundleBounty_Hunter.mAttackRange = 128
    bundleBounty_Hunter.mMissileSpeed = Nothing

    bundleBounty_Hunter.mAbilityNames.Add(eAbilityName.abShuriken_Toss)
    bundleBounty_Hunter.mAbilityNames.Add(eAbilityName.abJinada)
    bundleBounty_Hunter.mAbilityNames.Add(eAbilityName.abShadow_Walk)

    bundleBounty_Hunter.mAbilityNames.Add(eAbilityName.abTrack)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleBounty_Hunter.mDevName = "Bounty_Hunter"

    bundleBounty_Hunter.mRoles.Add(eRole.Carry)
    bundleBounty_Hunter.mRoles.Add(eRole.Escape)
    bundleBounty_Hunter.mRoles.Add(eRole.Nuker)

    bundleBounty_Hunter.mPrimaryStat = ePrimaryStat.Agility

    bundleBounty_Hunter.mBio = "When the hunted tell tales of Gondar the Bounty Hunter, none are sure of which are true. In whispered tones they say he was abandoned as a kit, learning his skill in tracking as a matter of simple survival. Others hear he was an orphan of war, taken in by the great Soruq the Hunter to learn the master's skill with a blade as they plumbed the dark forests for big game. Still others believe he was a lowly street urchin raised among a guild of cutpurses and thieves, trained in the arts of stealth and misdirection. Around campfires in the wild countryside his quarry speaks the rumors of Gondar's work, growing ever more fearful: they say it was he who tracked down the tyrant King Goff years after the mad regent went into hiding, delivering his head and scepter as proof. That it was he who infiltrated the rebel camps at Highseat, finally bringing the legendary thief White Cape to be judged for his crimes. And that it was he who ended the career of Soruq the Hunter, condemned as a criminal for killing the Prince's prized hellkite. The tales of Gondar's incredible skill stretch on, with each daring feat more unbelievable than the last, each target more elusive. For the right price, the hunted know, anyone can be found. For the right price, even the mightiest may find fear in the shadows. "

    bundleBounty_Hunter.mBaseStr = 17
    bundleBounty_Hunter.mStrIncrement = 1.8

    bundleBounty_Hunter.mBaseInt = 19
    bundleBounty_Hunter.mIntIncrement = 1.4

    bundleBounty_Hunter.mBaseAgi = 21
    bundleBounty_Hunter.mAgiIncrement = 3


    bundleBounty_Hunter.mBaseMoveSpeed = 315
    bundleBounty_Hunter.mBaseArmor = 3


    bundleBounty_Hunter.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleBounty_Hunter.mName, bundleBounty_Hunter)



    '----------------------------------------------------------
    '-URSA START-----------------------------
    '----------------------------------------------------------
    Dim bundleUrsa As New HeroBundle
    'FROM UNITBASE
    bundleUrsa.mIDItem = New dvID(New Guid("545b5653-2ee9-4881-bf98-b37dbadb8fce"), "Herobundle: Ursa", eEntity.Herobundle)
    bundleUrsa.mName = eHeroName.untUrsa
    bundleUrsa.DisplayName = "Ursa"
    bundleUrsa.mArmorType = eArmorType.Hero
    bundleUrsa.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/ursa_vert.jpg"
    bundleUrsa.mWebpageLink = "http://www.dota2.com/hero/Ursa/"

    bundleUrsa.mAttackType = eAttackType.Melee
    bundleUrsa.mBaseHitpoints = 0
    bundleUrsa.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleUrsa.mBaseAttackDamage = New ValueWrapper(27, 31)

    bundleUrsa.mDaySightRange = 1800
    bundleUrsa.mNightSightRange = 800

    bundleUrsa.mAttackRange = 128
    bundleUrsa.mMissileSpeed = Nothing


    bundleUrsa.mAbilityNames.Add(eAbilityName.abEarthshock)
    bundleUrsa.mAbilityNames.Add(eAbilityName.abOverpower)
    bundleUrsa.mAbilityNames.Add(eAbilityName.abFury_Swipes)
    bundleUrsa.mAbilityNames.Add(eAbilityName.abEnrage)




    'FROM HEROBASE
    'Fixed, immutable stats
    bundleUrsa.mDevName = "Ursa"

    bundleUrsa.mRoles.Add(eRole.Carry)
    bundleUrsa.mRoles.Add(eRole.Jungler)
    bundleUrsa.mRoles.Add(eRole.Durable)

    bundleUrsa.mPrimaryStat = ePrimaryStat.Agility

    bundleUrsa.mBio = "Ulfsaar the Warrior is the fiercest member of an ursine tribe, protective of his land and his people. During the long winters, while the mothers sleep and nurse their cubs, the males patrol the lands above as tireless, vigilant defenders of their ancient ways. Hearing dim but growing rumors of a spreading evil, Ulfsaar headed out beyond the boundaries of his wild wooded homeland, intending to track down and destroy the threat at its source, before it could endanger his people. He is a proud creature with a bright strong spirit, utterly trustworthy, a staunch ally and defender. "

    bundleUrsa.mBaseStr = 23
    bundleUrsa.mStrIncrement = 2.9

    bundleUrsa.mBaseInt = 16
    bundleUrsa.mIntIncrement = 1.5

    bundleUrsa.mBaseAgi = 18
    bundleUrsa.mAgiIncrement = 2.1


    bundleUrsa.mBaseMoveSpeed = 310
    bundleUrsa.mBaseArmor = 3


    bundleUrsa.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleUrsa.mName, bundleUrsa)



    '----------------------------------------------------------
    '-GYROCOPTER START-----------------------------
    '----------------------------------------------------------
    Dim bundleGyrocopter As New HeroBundle
    'FROM UNITBASE
    bundleGyrocopter.mIDItem = New dvID(New Guid("7b476a30-e5e1-407e-a494-83fba861b33c"), "Herobundle: Gyrocopter", eEntity.Herobundle)
    bundleGyrocopter.mName = eHeroName.untGyrocopter
    bundleGyrocopter.DisplayName = "Gyrocopter"
    bundleGyrocopter.mArmorType = eArmorType.Hero
    bundleGyrocopter.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/gyrocopter_vert.jpg"
    bundleGyrocopter.mWebpageLink = "http://www.dota2.com/hero/Gyrocopter/"

    bundleGyrocopter.mAttackType = eAttackType.Ranged
    bundleGyrocopter.mBaseHitpoints = 0
    bundleGyrocopter.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleGyrocopter.mBaseAttackDamage = New ValueWrapper(17, 27)

    bundleGyrocopter.mDaySightRange = 1800
    bundleGyrocopter.mNightSightRange = 800

    bundleGyrocopter.mAttackRange = 365
    bundleGyrocopter.mMissileSpeed = 3000

    bundleGyrocopter.mAbilityNames.Add(eAbilityName.abRocket_Barrage)
    bundleGyrocopter.mAbilityNames.Add(eAbilityName.abHoming_Missile)

    bundleGyrocopter.mAbilityNames.Add(eAbilityName.abFlak_Cannon)
    bundleGyrocopter.mAbilityNames.Add(eAbilityName.abCall_Down)



    'FROM HEROBASE
    'Fixed, immutable stats
    bundleGyrocopter.mDevName = "Gyrocopter"

    bundleGyrocopter.mRoles.Add(eRole.Disabler)
    bundleGyrocopter.mRoles.Add(eRole.Initiator)
    bundleGyrocopter.mRoles.Add(eRole.Nuker)

    bundleGyrocopter.mPrimaryStat = ePrimaryStat.Agility

    bundleGyrocopter.mBio = "After serving through a lifetime of wars, upheaval, riots, and revolutions, the brass figured Aurel had seen enough. But in addition to a few trinkets and his considerable pension, the erstwhile engineer left with something far more interesting: a long-forgotten, incomplete schematic for a Gyrocopter, the world's first manned, non-magical flying device. Retiring to the tropical obscurity of the Ash Archipelago with little else but time and money, he set to work building the device. As the years wore on and the remains of failed prototypes began to pile up, he began to wonder if mechanical flight was even possible. A decade and a day after his retirement, on a sunny afternoon with a southerly breeze, Aurel sat in his latest attempt bristling with indignation and expectant failure. With a grunt of effort he pulled the ignition cord and covered his head, waiting for the inevitable explosion. However to his great surprise he began to lift and, following a few panicked adjustments, stabilize. Within an hour, he was ducking and weaving with the breeze, level with the gulls, and Aurel found himself filled with the breathless wonder of flight. As dusk settled in he set a course back to his workshop, but no sooner had he turned his craft when a cannonball tore through his tailfin. Disentangling himself from the wreckage, he swam toward the nearest piece of land in sight, and cursed to see the ship responsible for the cannonball collecting the debris. Days later, when Aurel returned to his workshop, he set to work on yet another gyrocopter, this one capable of carrying a much heavier, more dangerous payload. "

    bundleGyrocopter.mBaseStr = 18
    bundleGyrocopter.mStrIncrement = 1.8

    bundleGyrocopter.mBaseInt = 23
    bundleGyrocopter.mIntIncrement = 2.1

    bundleGyrocopter.mBaseAgi = 24
    bundleGyrocopter.mAgiIncrement = 2.8


    bundleGyrocopter.mBaseMoveSpeed = 315
    bundleGyrocopter.mBaseArmor = 1


    bundleGyrocopter.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleGyrocopter.mName, bundleGyrocopter)



    '----------------------------------------------------------
    '-LONE DRUID START-----------------------------
    '----------------------------------------------------------
    Dim bundleLone_Druid As New HeroBundle
    'FROM UNITBASE
    bundleLone_Druid.mIDItem = New dvID(New Guid("5c5cdbf9-47c2-42ba-8f73-39dcffeb668a"), "Herobundle: Lone Druid", eEntity.Herobundle)
    bundleLone_Druid.mName = eHeroName.untLone_Druid
    bundleLone_Druid.DisplayName = "Lone Druid"
    bundleLone_Druid.mArmorType = eArmorType.Hero
    bundleLone_Druid.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/lone_druid_vert.jpg"
    bundleLone_Druid.mWebpageLink = "http://www.dota2.com/hero/Lone_Druid/"

    bundleLone_Druid.mAttackType = eAttackType.Ranged
    bundleLone_Druid.mBaseHitpoints = 0
    bundleLone_Druid.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleLone_Druid.mBaseAttackDamage = New ValueWrapper(22, 26)

    bundleLone_Druid.mDaySightRange = 1800
    bundleLone_Druid.mNightSightRange = 800

    bundleLone_Druid.mAttackRange = 550
    bundleLone_Druid.mMissileSpeed = 900

    bundleLone_Druid.mAbilityNames.Add(eAbilityName.abSummon_Spirit_Bear)
    bundleLone_Druid.mAbilityNames.Add(eAbilityName.abRabid)
    bundleLone_Druid.mAbilityNames.Add(eAbilityName.abSynergy)
    bundleLone_Druid.mAbilityNames.Add(eAbilityName.abBattle_Cry)
    'bundleLone_Druid.mAbilityNames.Add(eAbilityName.abDruid_Form)



    bundleLone_Druid.mAbilityNames.Add(eAbilityName.abTrue_Form)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleLone_Druid.mDevName = "Lone_Druid"

    bundleLone_Druid.mRoles.Add(eRole.Carry)
    bundleLone_Druid.mRoles.Add(eRole.Durable)
    bundleLone_Druid.mRoles.Add(eRole.Pusher)
    bundleLone_Druid.mRoles.Add(eRole.Jungler)

    bundleLone_Druid.mPrimaryStat = ePrimaryStat.Agility

    bundleLone_Druid.mBio = "Long before the first words of the first histories there rose the druidic Bear Clan. Wise and just they were, and focused in their ways to seek an understanding of the natural order. The arch forces of nature saw this, and so sought the most learned among them. Wise old Sylla, clan justiciar and seer, stepped forward for his kin, and to him was given the Seed with these words: 'When all of the world has dimmed, when civilization has left these lands, when the world is slain and wracked by the endless deserts at the end of ages, plant the Seed.' As he grasped his trust, Sylla felt his years recede and his vitality returned. Vast knowledge burst into his mind. He found himself able to project his very will into reality and, with some concentration, alter his own physical form as well. Yet subtle whispers and cruel ears brought word of the Seed and its power to other peoples, and a terrible war crashed upon the Bear Clan. As his ancestral home burned, Sylla took his burden and fled to the wild places. Ages passed, and time and myth forgot the Bear Clan, forgot Sylla and the Seed, forgot wondrous civilizations that rose and fell in Bear Clan's wake. For millenia Sylla has waited, waited for word from his deities, waited for peace to come to the ever warring realms, waited in exile and in secret for the end of all things and for the conclusion of his sacred commitment, preparing himself always to face and destroy whatever would dare threaten his purpose. "

    bundleLone_Druid.mBaseStr = 17
    bundleLone_Druid.mStrIncrement = 2.1

    bundleLone_Druid.mBaseInt = 13
    bundleLone_Druid.mIntIncrement = 1.4

    bundleLone_Druid.mBaseAgi = 24
    bundleLone_Druid.mAgiIncrement = 2.7


    bundleLone_Druid.mBaseMoveSpeed = 325
    bundleLone_Druid.mBaseArmor = 0


    bundleLone_Druid.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleLone_Druid.mName, bundleLone_Druid)



    '----------------------------------------------------------
    '-NAGA SIREN START-----------------------------
    '----------------------------------------------------------
    Dim bundleNaga_Siren As New HeroBundle
    'FROM UNITBASE
    bundleNaga_Siren.mIDItem = New dvID(New Guid("869d78dc-3975-4fb7-a26f-7fabc2bbbf8a"), "Herobundle: Naga Siren", eEntity.Herobundle)
    bundleNaga_Siren.mName = eHeroName.untNaga_Siren
    bundleNaga_Siren.DisplayName = "Naga Siren"
    bundleNaga_Siren.mArmorType = eArmorType.Hero
    bundleNaga_Siren.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/naga_siren_vert.jpg"
    bundleNaga_Siren.mWebpageLink = "http://www.dota2.com/hero/Naga_Siren/"

    bundleNaga_Siren.mAttackType = eAttackType.Melee
    bundleNaga_Siren.mBaseHitpoints = 0
    bundleNaga_Siren.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleNaga_Siren.mBaseAttackDamage = New ValueWrapper(23, 25)

    bundleNaga_Siren.mDaySightRange = 1800
    bundleNaga_Siren.mNightSightRange = 800

    bundleNaga_Siren.mAttackRange = 128
    bundleNaga_Siren.mMissileSpeed = Nothing

    bundleNaga_Siren.mAbilityNames.Add(eAbilityName.abMirror_Image)
    bundleNaga_Siren.mAbilityNames.Add(eAbilityName.abEnsnare)

    bundleNaga_Siren.mAbilityNames.Add(eAbilityName.abRip_Tide)
    bundleNaga_Siren.mAbilityNames.Add(eAbilityName.abSong_Of_The_Siren)
    'bundleNaga_Siren.mAbilityNames.Add(eAbilityName.abSong_Of_The_Siren_Cancel)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleNaga_Siren.mDevName = "Naga_Siren"

    bundleNaga_Siren.mRoles.Add(eRole.Carry)
    bundleNaga_Siren.mRoles.Add(eRole.Disabler)
    bundleNaga_Siren.mRoles.Add(eRole.Pusher)
    bundleNaga_Siren.mRoles.Add(eRole.Escape)

    bundleNaga_Siren.mPrimaryStat = ePrimaryStat.Agility

    bundleNaga_Siren.mBio = "Among the high-sworn of the Slithereen Guard there is a solemn vow oft repeated before battle: No Slithereen may fail. In truth, these words are equal parts oath and enforceable covenant, for those who fall short of their duty are banished from the order. To fail is to be other than Slithereen.|Once most highly esteemed of her race, Slithice for many years commanded a battalion of her fellows, using her formidable voice as her greatest weapon. Powerful, sinuous, serpentine, she led her deadly Guard in defense of the Deep Ones, and the great wealth of the sunken cities. But in the final battle of Crey, her forces were driven back by a marauding army of levianths intent on finding tribute for their god Maelrawn. After the long and bloody onslaught, as the bodies were cleared from the sunken halls, a single jeweled chalice was found missing from the trove. Of her hundred Guard, only a handful survived, but their bravery and sacrifice were of little consequence. What mattered was that treasure was taken. Honor destroyed. And so Naga Siren was cast out. Banished to search for the stolen chalice. Though she might add a hundred times her weight to the golden trove, she is doomed to live apart until that day she returns that which was taken. For no amount of gold is equal in honor to the honor she lost. "

    bundleNaga_Siren.mBaseStr = 21
    bundleNaga_Siren.mStrIncrement = 2.3

    bundleNaga_Siren.mBaseInt = 18
    bundleNaga_Siren.mIntIncrement = 1.95

    bundleNaga_Siren.mBaseAgi = 21
    bundleNaga_Siren.mAgiIncrement = 2.75


    bundleNaga_Siren.mBaseMoveSpeed = 320
    bundleNaga_Siren.mBaseArmor = 3


    bundleNaga_Siren.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleNaga_Siren.mName, bundleNaga_Siren)



    '----------------------------------------------------------
    '-TROLL WARLORD START-----------------------------
    '----------------------------------------------------------
    Dim bundleTroll_Warlord As New HeroBundle
    'FROM UNITBASE
    bundleTroll_Warlord.mIDItem = New dvID(New Guid("67c21bd6-389e-4d04-bbeb-351ad2667d3d"), "Herobundle: Troll Warlord", eEntity.Herobundle)
    bundleTroll_Warlord.mName = eHeroName.untTroll_Warlord
    bundleTroll_Warlord.DisplayName = "Troll Warlord"
    bundleTroll_Warlord.mArmorType = eArmorType.Hero
    bundleTroll_Warlord.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/troll_warlord_vert.jpg"
    bundleTroll_Warlord.mWebpageLink = "http://www.dota2.com/hero/Troll_Warlord/"

    bundleTroll_Warlord.mAttackType = eAttackType.Ranged
    bundleTroll_Warlord.mBaseHitpoints = 0
    bundleTroll_Warlord.mBaseAttackSpeed = 1.55 ' http://dota2.gamepedia.com/Attack_speed

    bundleTroll_Warlord.mBaseAttackDamage = New ValueWrapper(17, 35)

    bundleTroll_Warlord.mDaySightRange = 1800
    bundleTroll_Warlord.mNightSightRange = 800

    bundleTroll_Warlord.mAttackRange = 500
    bundleTroll_Warlord.mMissileSpeed = 1200

    bundleTroll_Warlord.mAbilityNames.Add(eAbilityName.abBerserkers_Rage)

    bundleTroll_Warlord.mAbilityNames.Add(eAbilityName.abWhirling_Axes__Melee)
    'bundleTroll_Warlord.mAbilityNames.Add(eAbilityName.abWhirling_Axes__Ranged)
    bundleTroll_Warlord.mAbilityNames.Add(eAbilityName.abFervor)

    bundleTroll_Warlord.mAbilityNames.Add(eAbilityName.abBattle_Trance)

    'FROM HEROBASE
    'Fixed, immutable stats
    bundleTroll_Warlord.mDevName = "Troll_Warlord"

    bundleTroll_Warlord.mRoles.Add(eRole.Carry)

    bundleTroll_Warlord.mPrimaryStat = ePrimaryStat.Agility

    bundleTroll_Warlord.mBio = "It's an easy thing to offend a troll. A prickly and contentious race, trolls thrive on argument and strife, missing no excuse to raise their voices in dispute. Males grow to maturity in subterranean chambers beneath their matriarch's domicile, feeding and amusing themselves while contributing nothing. Often they stay for years beyond the age of maturity, while the matriarch provides them with sustenance. When young trolls are finally pushed from their sub-chamber, they gather with others of their kind, forming roving gangs of malcontents who complain loudly about all manner of vexation. |As much as trolls love to argue, imagine how rare it is for a troll to be driven from his own kind for being too difficult to get along with. Such was Jah'rakal's fate, a monger troll from deep in the Hoven. So deluded was he, so bitter and abrasive, that even other trolls found his company intolerable. After one particularly vitriolic outburst in which he claimed the lion's share of loot from their latest raid, his cohorts finally snapped. They turned on him, beat him with clubs, and drove him from the encampment. Enraged at his banishment, he returned the next day, armed with steel, and slew them all, one by one. He then swore a blood oath: he would ever after be a fighting force unto himself. Now he roams the world as the Troll Warlord, bitter and angry, the Imperial high commander of an army of one. "

    bundleTroll_Warlord.mBaseStr = 17
    bundleTroll_Warlord.mStrIncrement = 2.2

    bundleTroll_Warlord.mBaseInt = 13
    bundleTroll_Warlord.mIntIncrement = 1

    bundleTroll_Warlord.mBaseAgi = 21
    bundleTroll_Warlord.mAgiIncrement = 2.75


    bundleTroll_Warlord.mBaseMoveSpeed = 300

    bundleTroll_Warlord.mBaseArmor = -1

    bundleTroll_Warlord.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleTroll_Warlord.mName, bundleTroll_Warlord)



    '----------------------------------------------------------
    '-EMBER SPIRIT START-----------------------------
    '----------------------------------------------------------
    Dim bundleEmber_Spirit As New HeroBundle
    'FROM UNITBASE
    bundleEmber_Spirit.mIDItem = New dvID(New Guid("cc58d93f-ceb8-4150-bca6-d2f123e7d2b0"), "Herobundle: Ember Spirit", eEntity.Herobundle)
    bundleEmber_Spirit.mName = eHeroName.untEmber_Spirit
    bundleEmber_Spirit.DisplayName = "Ember Spirit"
    bundleEmber_Spirit.mArmorType = eArmorType.Hero
    bundleEmber_Spirit.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/ember_spirit_vert.jpg"
    bundleEmber_Spirit.mWebpageLink = "http://www.dota2.com/hero/Ember_Spirit/"

    bundleEmber_Spirit.mAttackType = eAttackType.Melee
    bundleEmber_Spirit.mBaseHitpoints = 0
    bundleEmber_Spirit.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleEmber_Spirit.mBaseAttackDamage = New ValueWrapper(30, 34)

    bundleEmber_Spirit.mDaySightRange = 1800
    bundleEmber_Spirit.mNightSightRange = 800

    bundleEmber_Spirit.mAttackRange = 128
    bundleEmber_Spirit.mMissileSpeed = Nothing

    bundleEmber_Spirit.mAbilityNames.Add(eAbilityName.abSearing_Chains)
    bundleEmber_Spirit.mAbilityNames.Add(eAbilityName.abSleight_Of_Fist)
    bundleEmber_Spirit.mAbilityNames.Add(eAbilityName.abFlame_Guard)
    '  bundleEmber_Spirit.mAbilityNames.Add(eAbilityName.abActivate_Fire_Remnant)
    bundleEmber_Spirit.mAbilityNames.Add(eAbilityName.abFire_Remnant)





    'FROM HEROBASE
    'Fixed, immutable stats
    bundleEmber_Spirit.mDevName = "Ember_Spirit"

    bundleEmber_Spirit.mRoles.Add(eRole.Carry)
    bundleEmber_Spirit.mRoles.Add(eRole.Nuker)

    bundleEmber_Spirit.mPrimaryStat = ePrimaryStat.Agility

    bundleEmber_Spirit.mBio = "Lost within the Wailing Mountains, the Fortress of Flares lay abandoned, its training halls empty, its courtyard covered in leaves and dust. Upon a dais in its sealed temple rests a topaz cauldron filled with ancient ash, remnants of a pyre for the warrior-poet Xin. For three generations, Xin taught his acolytes the Bonds of the Guardian Flame, a series of mantras to train the mind and body for the harsh realities beyond the fortress walls. However, in teaching a warrior's way he earned a warrior's rivals, and in his autumn Xin was bested and slain. His followers spread to the wind. Yet as years turned to centuries and followers to descendants, his teachings endured by subtle whisper and deed. Touched by the teacher's lasting legacy, the Burning Celestial, inquisitive aspect of fire, cast himself to the Fortress of Flares and reignited the pyre ash. From these glowing embers emerged an image of Xin, wreathed in flame, his thoughtful countenance prepared to train and to teach, and to spread the fires of knowledge to all who seek guidance. "

    bundleEmber_Spirit.mBaseStr = 19
    bundleEmber_Spirit.mStrIncrement = 2

    bundleEmber_Spirit.mBaseInt = 20
    bundleEmber_Spirit.mIntIncrement = 1.8

    bundleEmber_Spirit.mBaseAgi = 22
    bundleEmber_Spirit.mAgiIncrement = 1.8


    bundleEmber_Spirit.mBaseMoveSpeed = 310
    bundleEmber_Spirit.mBaseArmor = 1


    bundleEmber_Spirit.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleEmber_Spirit.mName, bundleEmber_Spirit)



    '----------------------------------------------------------
    '-CRYSTAL MAIDEN START-----------------------------
    '----------------------------------------------------------
    Dim bundleCrystal_Maiden As New HeroBundle
    'FROM UNITBASE
    bundleCrystal_Maiden.mIDItem = New dvID(New Guid("12bf39df-d603-4400-badc-7419db94d77a"), "Herobundle: Crystal Maiden", eEntity.Herobundle)
    bundleCrystal_Maiden.mName = eHeroName.untCrystal_Maiden
    bundleCrystal_Maiden.DisplayName = "Crystal Maiden"
    bundleCrystal_Maiden.mArmorType = eArmorType.Hero
    bundleCrystal_Maiden.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/crystal_maiden_vert.jpg"
    bundleCrystal_Maiden.mWebpageLink = "http://www.dota2.com/hero/Crystal_Maiden/"

    bundleCrystal_Maiden.mAttackType = eAttackType.Ranged
    bundleCrystal_Maiden.mBaseHitpoints = 0
    bundleCrystal_Maiden.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleCrystal_Maiden.mBaseAttackDamage = New ValueWrapper(19, 25)

    bundleCrystal_Maiden.mDaySightRange = 1800
    bundleCrystal_Maiden.mNightSightRange = 800

    bundleCrystal_Maiden.mAttackRange = 600
    bundleCrystal_Maiden.mMissileSpeed = 900

    bundleCrystal_Maiden.mAbilityNames.Add(eAbilityName.abCrystal_Nova)
    bundleCrystal_Maiden.mAbilityNames.Add(eAbilityName.abFrostbite)
    bundleCrystal_Maiden.mAbilityNames.Add(eAbilityName.abArcane_Aura)

    bundleCrystal_Maiden.mAbilityNames.Add(eAbilityName.abFreezing_Field)



    'FROM HEROBASE
    'Fixed, immutable stats
    bundleCrystal_Maiden.mDevName = "Crystal_Maiden"

    bundleCrystal_Maiden.mRoles.Add(eRole.Support)
    bundleCrystal_Maiden.mRoles.Add(eRole.Disabler)
    bundleCrystal_Maiden.mRoles.Add(eRole.Nuker)
    bundleCrystal_Maiden.mRoles.Add(eRole.LaneSupport)

    bundleCrystal_Maiden.mPrimaryStat = ePrimaryStat.Intelligence

    bundleCrystal_Maiden.mBio = "Born in a temperate realm, raised with her fiery older sister Lina, Rylai the Crystal Maiden soon found that her innate elemental affinity to ice created trouble for all those around her. Wellsprings and mountain rivers froze in moments if she stopped to rest nearby; ripening crops were bitten by frost, and fruiting orchards turned to mazes of ice and came crashing down, spoiled. When their exasperated parents packed Lina off to the equator, Rylai found herself banished to the cold northern realm of Icewrack, where she was taken in by an Ice Wizard who had carved himself a hermitage at the crown of the Blueheart Glacier. After long study, the wizard pronounced her ready for solitary practice and left her to take his place, descending into the glacier to hibernate for a thousand years. Her mastery of the Frozen Arts has only deepened since that time, and now her skills are unmatched. "

    bundleCrystal_Maiden.mBaseStr = 16
    bundleCrystal_Maiden.mStrIncrement = 1.7

    bundleCrystal_Maiden.mBaseInt = 16
    bundleCrystal_Maiden.mIntIncrement = 2.9

    bundleCrystal_Maiden.mBaseAgi = 16
    bundleCrystal_Maiden.mAgiIncrement = 1.6


    bundleCrystal_Maiden.mBaseMoveSpeed = 280

    bundleCrystal_Maiden.mBaseArmor = -1

    bundleCrystal_Maiden.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleCrystal_Maiden.mName, bundleCrystal_Maiden)



    '----------------------------------------------------------
    '-PUCK START-----------------------------
    '----------------------------------------------------------
    Dim bundlePuck As New HeroBundle
    'FROM UNITBASE
    bundlePuck.mIDItem = New dvID(New Guid("bab78847-7a68-49a0-b18b-4cc6c2edfc1c"), "Herobundle: Puck", eEntity.Herobundle)
    bundlePuck.mName = eHeroName.untPuck
    bundlePuck.DisplayName = "Puck"
    bundlePuck.mArmorType = eArmorType.Hero
    bundlePuck.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/puck_vert.jpg"
    bundlePuck.mWebpageLink = "http://www.dota2.com/hero/Puck/"

    bundlePuck.mAttackType = eAttackType.Ranged
    bundlePuck.mBaseHitpoints = 0
    bundlePuck.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundlePuck.mBaseAttackDamage = New ValueWrapper(22, 33)

    bundlePuck.mDaySightRange = 1800
    bundlePuck.mNightSightRange = 800

    bundlePuck.mAttackRange = 550
    bundlePuck.mMissileSpeed = 900

    bundlePuck.mAbilityNames.Add(eAbilityName.abIllusory_Orb)
    bundlePuck.mAbilityNames.Add(eAbilityName.abWaning_Rift)
    bundlePuck.mAbilityNames.Add(eAbilityName.abPhase_Shift)
    'bundlePuck.mAbilityNames.Add(eAbilityName.abEthereal_Jaunt)
    bundlePuck.mAbilityNames.Add(eAbilityName.abDream_Coil)






    'FROM HEROBASE
    'Fixed, immutable stats
    bundlePuck.mDevName = "Puck"

    bundlePuck.mRoles.Add(eRole.Initiator)
    bundlePuck.mRoles.Add(eRole.Nuker)
    bundlePuck.mRoles.Add(eRole.Disabler)
    bundlePuck.mRoles.Add(eRole.Escape)

    bundlePuck.mPrimaryStat = ePrimaryStat.Intelligence

    bundlePuck.mBio = "While Puck seems at first glance a mischievous, childish character, this quality masks an alien personality. The juvenile form of a Faerie Dragon, a creature that lives for eons, Puck spends countless millennia in its childish form. So while it is technically true that Puck is juvenile, it will continue to be so when the cities of the present age have sloughed away into dust. Its motives are therefore inscrutable, and what appears to be play may in fact hide a darker purpose. Its endless fondness for mischief is the true indicator of Puck's true nature. "

    bundlePuck.mBaseStr = 15
    bundlePuck.mStrIncrement = 1.7

    bundlePuck.mBaseInt = 25
    bundlePuck.mIntIncrement = 2.4

    bundlePuck.mBaseAgi = 22
    bundlePuck.mAgiIncrement = 1.7


    bundlePuck.mBaseMoveSpeed = 295

    bundlePuck.mBaseArmor = -1

    bundlePuck.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundlePuck.mName, bundlePuck)



    '----------------------------------------------------------
    '-STORM SPIRIT START-----------------------------
    '----------------------------------------------------------
    Dim bundleStorm_Spirit As New HeroBundle
    'FROM UNITBASE
    bundleStorm_Spirit.mIDItem = New dvID(New Guid("9fe34b37-5e15-4aa1-ac40-4f9f4b043540"), "Herobundle: Storm Spirit", eEntity.Herobundle)
    bundleStorm_Spirit.mName = eHeroName.untStorm_Spirit
    bundleStorm_Spirit.DisplayName = "Storm Spirit"
    bundleStorm_Spirit.mArmorType = eArmorType.Hero
    bundleStorm_Spirit.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/storm_spirit_vert.jpg"
    bundleStorm_Spirit.mWebpageLink = "http://www.dota2.com/hero/Storm_Spirit/"

    bundleStorm_Spirit.mAttackType = eAttackType.Ranged
    bundleStorm_Spirit.mBaseHitpoints = 0
    bundleStorm_Spirit.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleStorm_Spirit.mBaseAttackDamage = New ValueWrapper(22, 32)

    bundleStorm_Spirit.mDaySightRange = 1800
    bundleStorm_Spirit.mNightSightRange = 800

    bundleStorm_Spirit.mAttackRange = 480
    bundleStorm_Spirit.mMissileSpeed = 1100

    bundleStorm_Spirit.mAbilityNames.Add(eAbilityName.abStatic_Remnant)
    bundleStorm_Spirit.mAbilityNames.Add(eAbilityName.abElectric_Vortex)
    bundleStorm_Spirit.mAbilityNames.Add(eAbilityName.abOverload)
    bundleStorm_Spirit.mAbilityNames.Add(eAbilityName.abBall_Lightning)





    'FROM HEROBASE
    'Fixed, immutable stats
    bundleStorm_Spirit.mDevName = "Storm_Spirit"

    bundleStorm_Spirit.mRoles.Add(eRole.Carry)
    bundleStorm_Spirit.mRoles.Add(eRole.Initiator)
    bundleStorm_Spirit.mRoles.Add(eRole.Escape)
    bundleStorm_Spirit.mRoles.Add(eRole.Disabler)

    bundleStorm_Spirit.mPrimaryStat = ePrimaryStat.Intelligence

    bundleStorm_Spirit.mBio = "Storm Spirit is literally a force of nature--the wild power of wind and weather, bottled in human form. And a boisterous, jovial, irrepressible form it is! As jolly as a favorite uncle, he injects every scene with crackling energy. But it was not always thus, and there was tragedy in his creation. Generations ago, in the plains beyond the Wailing Mountains, a good people lay starving in drought and famine. A simple elementalist, Thunderkeg by name, used a forbidden spell to summon the spirit of the storm, asking for rain. Enraged at this mortal's presumption, the Storm Celestial known as Raijin lay waste to the land, scouring it bare with winds and flood. Thunderkeg was no match for the Celestial--at least until he cast a suicidal spell that forged their fates into one: he captured the Celestial in the cage of his own body. Trapped together, Thunderkeg's boundless good humor fused with Raijin's crazed energy, creating the jovial Raijin Thunderkeg, a Celestial who walks the world in physical form. "

    bundleStorm_Spirit.mBaseStr = 19
    bundleStorm_Spirit.mStrIncrement = 1.5

    bundleStorm_Spirit.mBaseInt = 23
    bundleStorm_Spirit.mIntIncrement = 2.6

    bundleStorm_Spirit.mBaseAgi = 22
    bundleStorm_Spirit.mAgiIncrement = 1.8


    bundleStorm_Spirit.mBaseMoveSpeed = 290
    bundleStorm_Spirit.mBaseArmor = 2


    bundleStorm_Spirit.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleStorm_Spirit.mName, bundleStorm_Spirit)



    '----------------------------------------------------------
    '-WINDRANGER START-----------------------------
    '----------------------------------------------------------
    Dim bundleWindranger As New HeroBundle
    'FROM UNITBASE
    bundleWindranger.mIDItem = New dvID(New Guid("b1838a32-299a-4907-98c5-7ddbacce72cf"), "Herobundle: Windranger", eEntity.Herobundle)
    bundleWindranger.mName = eHeroName.untWindranger
    bundleWindranger.DisplayName = "Windranger"
    bundleWindranger.mArmorType = eArmorType.Hero
    bundleWindranger.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/windrunner_vert.jpg"
    bundleWindranger.mWebpageLink = "http://www.dota2.com/hero/Windranger/"

    bundleWindranger.mAttackType = eAttackType.Ranged
    bundleWindranger.mBaseHitpoints = 0
    bundleWindranger.mBaseAttackSpeed = 1.5 '  http://dota2.gamepedia.com/Attack_speed

    bundleWindranger.mBaseAttackDamage = New ValueWrapper(22, 34)

    bundleWindranger.mDaySightRange = 1800
    bundleWindranger.mNightSightRange = 800

    bundleWindranger.mAttackRange = 600
    bundleWindranger.mMissileSpeed = 1250

    bundleWindranger.mAbilityNames.Add(eAbilityName.abShackleshot)
    bundleWindranger.mAbilityNames.Add(eAbilityName.abPowershot)
    bundleWindranger.mAbilityNames.Add(eAbilityName.abWindrun)
    bundleWindranger.mAbilityNames.Add(eAbilityName.abFocus_Fire)





    'FROM HEROBASE
    'Fixed, immutable stats
    bundleWindranger.mDevName = "Windranger"

    bundleWindranger.mRoles.Add(eRole.Disabler)
    bundleWindranger.mRoles.Add(eRole.Nuker)
    bundleWindranger.mRoles.Add(eRole.Support)
    bundleWindranger.mRoles.Add(eRole.Escape)

    bundleWindranger.mPrimaryStat = ePrimaryStat.Intelligence

    bundleWindranger.mBio = "The western forests guard their secrets well. One of these is Lyralei, master archer of the wood, and favored godchild of the wind. Known now as Windranger, Lyralei's family was killed in a storm on the night of her birth--their house blown down by the gale, contents scattered to the winds. Only the newborn survived among the debris field of death and destruction. In the quiet after the storm, the wind itself took notice of the lucky infant crying in the grass. The wind pitied the child and so lifted her into the sky and deposited her on a doorstep in a neighboring village. In the years that followed, the wind returned occasionally to the child's life, watching from a distance while she honed her skills. Now, after many years of training, Windranger fires her arrows true to their targets. She moves with blinding speed, as if hastened by a wind ever at her back. With a flurry of arrows, she slaughters her enemies, having become, nearly, a force of nature herself. "

    bundleWindranger.mBaseStr = 15
    bundleWindranger.mStrIncrement = 2.5

    bundleWindranger.mBaseInt = 22
    bundleWindranger.mIntIncrement = 2.6

    bundleWindranger.mBaseAgi = 17
    bundleWindranger.mAgiIncrement = 1.4


    bundleWindranger.mBaseMoveSpeed = 295

    bundleWindranger.mBaseArmor = -1

    bundleWindranger.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleWindranger.mName, bundleWindranger)



    '----------------------------------------------------------
    '-ZEUS START-----------------------------
    '----------------------------------------------------------
    Dim bundleZeus As New HeroBundle
    'FROM UNITBASE
    bundleZeus.mIDItem = New dvID(New Guid("fdccb1ef-661f-4e4b-a6ff-d6f1f7bba30b"), "Herobundle: Zeus", eEntity.Herobundle)
    bundleZeus.mName = eHeroName.untZeus
    bundleZeus.DisplayName = "Zeus"
    bundleZeus.mArmorType = eArmorType.Hero
    bundleZeus.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/zuus_vert.jpg"
    bundleZeus.mWebpageLink = "http://www.dota2.com/hero/Zeus/"

    bundleZeus.mAttackType = eAttackType.Ranged
    bundleZeus.mBaseHitpoints = 0
    bundleZeus.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleZeus.mBaseAttackDamage = New ValueWrapper(21, 29)

    bundleZeus.mDaySightRange = 1800
    bundleZeus.mNightSightRange = 800

    bundleZeus.mAttackRange = 350
    bundleZeus.mMissileSpeed = 1100


    bundleZeus.mAbilityNames.Add(eAbilityName.abArc_Lightning)
    bundleZeus.mAbilityNames.Add(eAbilityName.abLightning_Bolt)
    bundleZeus.mAbilityNames.Add(eAbilityName.abStatic_Field)
    bundleZeus.mAbilityNames.Add(eAbilityName.abThundergods_Wrath)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleZeus.mDevName = "Zeus"

    bundleZeus.mRoles.Add(eRole.Nuker)
    bundleZeus.mRoles.Add(eRole.Support)

    bundleZeus.mPrimaryStat = ePrimaryStat.Intelligence

    bundleZeus.mBio = "Lord of Heaven, father of gods, Zeus treats all the Heroes as if they are his rambunctious, rebellious children. After being caught unnumbered times in the midst of trysts with countless mortal women, his divine wife finally gave him an ultimatum: 'If you love mortals so much, go and become one. If you can prove yourself faithful, then return to me as my immortal husband. Otherwise, go and die among your creatures.' Zeus found her logic (and her magic) irrefutable, and agreed to her plan. He has been on his best behavior ever since, being somewhat fonder of immortality than he is of mortals. But to prove himself worthy of his eternal spouse, he must continue to pursue victory on the field of battle. "

    bundleZeus.mBaseStr = 19
    bundleZeus.mStrIncrement = 2.3

    bundleZeus.mBaseInt = 20
    bundleZeus.mIntIncrement = 2.7

    bundleZeus.mBaseAgi = 11
    bundleZeus.mAgiIncrement = 1.2


    bundleZeus.mBaseMoveSpeed = 295
    bundleZeus.mBaseArmor = 0


    bundleZeus.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleZeus.mName, bundleZeus)



    '----------------------------------------------------------
    '-LINA START-----------------------------
    '----------------------------------------------------------
    Dim bundleLina As New HeroBundle
    'FROM UNITBASE
    bundleLina.mIDItem = New dvID(New Guid("b227869c-1988-4549-bd8b-0b15d3541c31"), "Herobundle: Lina", eEntity.Herobundle)
    bundleLina.mName = eHeroName.untLina
    bundleLina.DisplayName = "Lina"
    bundleLina.mArmorType = eArmorType.Hero
    bundleLina.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/lina_vert.jpg"
    bundleLina.mWebpageLink = "http://www.dota2.com/hero/Lina/"

    bundleLina.mAttackType = eAttackType.Ranged
    bundleLina.mBaseHitpoints = 0
    bundleLina.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleLina.mBaseAttackDamage = New ValueWrapper(13, 31)

    bundleLina.mDaySightRange = 1800
    bundleLina.mNightSightRange = 800

    bundleLina.mAttackRange = 670
    bundleLina.mMissileSpeed = 900


    bundleLina.mAbilityNames.Add(eAbilityName.abDragon_Slave)
    bundleLina.mAbilityNames.Add(eAbilityName.abLight_Strike_Array)
    bundleLina.mAbilityNames.Add(eAbilityName.abFiery_Soul)
    bundleLina.mAbilityNames.Add(eAbilityName.abLaguna_Blade)



    'FROM HEROBASE
    'Fixed, immutable stats
    bundleLina.mDevName = "Lina"

    bundleLina.mRoles.Add(eRole.Nuker)
    bundleLina.mRoles.Add(eRole.Disabler)
    bundleLina.mRoles.Add(eRole.Support)

    bundleLina.mPrimaryStat = ePrimaryStat.Intelligence

    bundleLina.mBio = "The sibling rivalries between Lina the Slayer, and her younger sister Rylai, the Crystal Maiden, were the stuff of legend in the temperate region where they spent their quarrelsome childhoods together. Lina always had the advantage, however, for while Crystal was guileless and naive, Lina's fiery ardor was tempered by cleverness and conniving. The exasperated parents of these incompatible offspring went through half a dozen homesteads, losing one to fire, the next to ice, before they realized life would be simpler if the children were separated. As the oldest, Lina was sent far south to live with a patient aunt in the blazing Desert of Misrule, a climate that proved more than comfortable for the fiery Slayer. Her arrival made quite an impression on the somnolent locals, and more than one would-be suitor scorched his fingers or went away with singed eyebrows, his advances spurned. Lina is proud and confident, and nothing can dampen her flame. "

    bundleLina.mBaseStr = 18
    bundleLina.mStrIncrement = 1.5

    bundleLina.mBaseInt = 27
    bundleLina.mIntIncrement = 3.2

    bundleLina.mBaseAgi = 16
    bundleLina.mAgiIncrement = 1.5


    bundleLina.mBaseMoveSpeed = 295

    bundleLina.mBaseArmor = -1

    bundleLina.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleLina.mName, bundleLina)



    '----------------------------------------------------------
    '-SHADOW SHAMAN START-----------------------------
    '----------------------------------------------------------
    Dim bundleShadow_Shaman As New HeroBundle
    'FROM UNITBASE
    bundleShadow_Shaman.mIDItem = New dvID(New Guid("ddd31672-5f57-48f0-b9a4-45c1a9898b01"), "Herobundle: Shadow Shaman", eEntity.Herobundle)
    bundleShadow_Shaman.mName = eHeroName.untShadow_Shaman
    bundleShadow_Shaman.DisplayName = "Shadow Shaman"
    bundleShadow_Shaman.mArmorType = eArmorType.Hero
    bundleShadow_Shaman.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/shadow_shaman_vert.jpg"
    bundleShadow_Shaman.mWebpageLink = "http://www.dota2.com/hero/Shadow_Shaman/"

    bundleShadow_Shaman.mAttackType = eAttackType.Ranged
    bundleShadow_Shaman.mBaseHitpoints = 0
    bundleShadow_Shaman.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleShadow_Shaman.mBaseAttackDamage = New ValueWrapper(26, 33)

    bundleShadow_Shaman.mDaySightRange = 1800
    bundleShadow_Shaman.mNightSightRange = 800

    bundleShadow_Shaman.mAttackRange = 500
    bundleShadow_Shaman.mMissileSpeed = 900


    bundleShadow_Shaman.mAbilityNames.Add(eAbilityName.abEther_Shock)
    bundleShadow_Shaman.mAbilityNames.Add(eAbilityName.abShadow_Shaman_Hex)

    bundleShadow_Shaman.mAbilityNames.Add(eAbilityName.abShackles)
    bundleShadow_Shaman.mAbilityNames.Add(eAbilityName.abMass_Serpent_Ward)

    'FROM HEROBASE
    'Fixed, immutable stats
    bundleShadow_Shaman.mDevName = "Shadow_Shaman"

    bundleShadow_Shaman.mRoles.Add(eRole.Pusher)
    bundleShadow_Shaman.mRoles.Add(eRole.Disabler)
    bundleShadow_Shaman.mRoles.Add(eRole.Nuker)
    bundleShadow_Shaman.mRoles.Add(eRole.Support)

    bundleShadow_Shaman.mPrimaryStat = ePrimaryStat.Intelligence

    bundleShadow_Shaman.mBio = "Born in the Bleeding Hills, Rhasta was just a starving youngling when picked up by a travelling con-man. For two pins of copper, the old con-man would tell your fortune. For three, he'd castrate your pig, for five, he'd circumcise your sons. For a good meal, he'd don his shaman garb, read from his ancient books, and lay a curse upon your enemies. His strange new youngling, part hill troll, part...something else, worked as assistant and lent an air of the exotic to the con-man's trade.|Always one step ahead of cheated customers, one town ahead of a pursuing patronage, the two trekked across the blighted lands until one day the con-man realized that the little youngling could actually do what he only pretended at. His ward had a gift - a gift that customers valued. And so the youngling Rhasta was thrust before the crowds, and the trade-name Shadow Shaman was born. The two continued from town to town, conjuring for money as Shadow Shaman's reputation grew. Eventually, the pair's duplicitous past caught up with them, and they were ambushed by a mob of swindled ex-clients. The con-man was slain, and for the first time, Rhasta used his powers for darkness, massacring the attackers. He buried his beloved master, and now uses his powers to destroy any who would seek to do him harm. "

    bundleShadow_Shaman.mBaseStr = 19
    bundleShadow_Shaman.mStrIncrement = 1.6

    bundleShadow_Shaman.mBaseInt = 21
    bundleShadow_Shaman.mIntIncrement = 3

    bundleShadow_Shaman.mBaseAgi = 16
    bundleShadow_Shaman.mAgiIncrement = 1.6


    bundleShadow_Shaman.mBaseMoveSpeed = 285

    bundleShadow_Shaman.mBaseArmor = -1

    bundleShadow_Shaman.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleShadow_Shaman.mName, bundleShadow_Shaman)



    '----------------------------------------------------------
    '-TINKER START-----------------------------
    '----------------------------------------------------------
    Dim bundleTinker As New HeroBundle
    'FROM UNITBASE
    bundleTinker.mIDItem = New dvID(New Guid("7fd47adc-cdb3-4ca5-b6ac-11007b1fbb68"), "Herobundle: Tinker", eEntity.Herobundle)
    bundleTinker.mName = eHeroName.untTinker
    bundleTinker.DisplayName = "Tinker"
    bundleTinker.mArmorType = eArmorType.Hero
    bundleTinker.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/tinker_vert.jpg"
    bundleTinker.mWebpageLink = "http://www.dota2.com/hero/Tinker/"

    bundleTinker.mAttackType = eAttackType.Ranged
    bundleTinker.mBaseHitpoints = 0
    bundleTinker.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleTinker.mBaseAttackDamage = New ValueWrapper(22, 28)

    bundleTinker.mDaySightRange = 1800
    bundleTinker.mNightSightRange = 800

    bundleTinker.mAttackRange = 500
    bundleTinker.mMissileSpeed = 900

    bundleTinker.mAbilityNames.Add(eAbilityName.abLaser)
    bundleTinker.mAbilityNames.Add(eAbilityName.abHeatSeeking_Missile)

    bundleTinker.mAbilityNames.Add(eAbilityName.abMarch_Of_The_Machines)
    bundleTinker.mAbilityNames.Add(eAbilityName.abRearm)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleTinker.mDevName = "Tinker"

    bundleTinker.mRoles.Add(eRole.Nuker)
    bundleTinker.mRoles.Add(eRole.Pusher)

    bundleTinker.mPrimaryStat = ePrimaryStat.Intelligence

    bundleTinker.mBio = "Boush the Tinker's diminutive race is known for its intelligence, its cunning, and its prickly relationship with magic. As a matter of pride, they survive by their wits, and use only those powers of nature that may be unlocked through rational methodologies. Even this forbearance has led to a great deal of trouble, as Boush can attest. Once a key investigator of natural law, Boush the Tinker led a vast intellectual investigation into the workings of nature, founding a subterranean laboratory in the rumored, mist-wreathed wastes of the Violet Plateau. While scorning mages for the dangers they visit upon the world, Boush and his Tinker associates haughtily wrenched open a portal to some realm beyond comprehension and ushered in some nightmares of their own. A black mist rose from the cavernous interior of the Violet Plateau, shrouding it in permanent darkness from which sounds of horror perpetually emanate. Boush escaped with only his wits and the contraptions he carried, the sole Tinker to survive the Violet Plateau Incident. "

    bundleTinker.mBaseStr = 17
    bundleTinker.mStrIncrement = 2

    bundleTinker.mBaseInt = 27
    bundleTinker.mIntIncrement = 2.2

    bundleTinker.mBaseAgi = 13
    bundleTinker.mAgiIncrement = 1.2


    bundleTinker.mBaseMoveSpeed = 305
    bundleTinker.mBaseArmor = 2


    bundleTinker.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleTinker.mName, bundleTinker)



    '----------------------------------------------------------
    '-NATURE'S PROPHET START-----------------------------
    '----------------------------------------------------------
    Dim bundleNatures_Prophet As New HeroBundle
    'FROM UNITBASE
    bundleNatures_Prophet.mIDItem = New dvID(New Guid("47a3a83a-ef1f-439c-a664-d086f2a0b68b"), "Herobundle: Natures Prophet", eEntity.Herobundle)
    bundleNatures_Prophet.mName = eHeroName.untNatures_Prophet
    bundleNatures_Prophet.DisplayName = "Nature's Prophet"
    bundleNatures_Prophet.mArmorType = eArmorType.Hero
    bundleNatures_Prophet.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/furion_vert.jpg"
    bundleNatures_Prophet.mWebpageLink = "http://www.dota2.com/hero/Natures_Prophet/"

    bundleNatures_Prophet.mAttackType = eAttackType.Ranged
    bundleNatures_Prophet.mBaseHitpoints = 0
    bundleNatures_Prophet.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleNatures_Prophet.mBaseAttackDamage = New ValueWrapper(24, 38)

    bundleNatures_Prophet.mDaySightRange = 1800
    bundleNatures_Prophet.mNightSightRange = 800

    bundleNatures_Prophet.mAttackRange = 600
    bundleNatures_Prophet.mMissileSpeed = 1125

    bundleNatures_Prophet.mAbilityNames.Add(eAbilityName.abSprout)
    bundleNatures_Prophet.mAbilityNames.Add(eAbilityName.abTeleportation)
    bundleNatures_Prophet.mAbilityNames.Add(eAbilityName.abNatures_Call)
    bundleNatures_Prophet.mAbilityNames.Add(eAbilityName.abWrath_Of_Nature)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleNatures_Prophet.mDevName = "Natures_Prophet"

    bundleNatures_Prophet.mRoles.Add(eRole.Jungler)
    bundleNatures_Prophet.mRoles.Add(eRole.Pusher)
    bundleNatures_Prophet.mRoles.Add(eRole.Carry)
    bundleNatures_Prophet.mRoles.Add(eRole.Escape)

    bundleNatures_Prophet.mPrimaryStat = ePrimaryStat.Intelligence

    bundleNatures_Prophet.mBio = "When Verodicia, Goddess of the Woods, had finished filling in the green places, having planted the coiled-up spirit in the seed, having lured the twining waters from deep within the rock, having sworn the sun its full attention to the growing things, she realized that her own time had reached its end, and like one of the leaves whose fate she had imprinted in the seed, she would fall without seeing the fruiting of her dream. It pained her to leave the world bereft, for the sprouts had not yet broken through the soil--and they would be tender and vulnerable to every sort of harm. She found in her seed pouch one last seed that she had missed in the sowing. She spoke a single word into the seed and swallowed it as she fell. Her vast body decomposed throughout the long winter, becoming the humus that would feed the seedlings in the spring. And on the morning of the vernal equinox, before the rest of the forest had begun to wake, that last seed ripened and burst in an instant. From it stepped Nature's Prophet, in full leaf, strong and wise, possessing Verodicia's power to foresee where he would be needed most in defense of the green places--and any who might be fortunate enough to call him an ally. "

    bundleNatures_Prophet.mBaseStr = 19
    bundleNatures_Prophet.mStrIncrement = 1.8

    bundleNatures_Prophet.mBaseInt = 21
    bundleNatures_Prophet.mIntIncrement = 2.9

    bundleNatures_Prophet.mBaseAgi = 18
    bundleNatures_Prophet.mAgiIncrement = 1.9


    bundleNatures_Prophet.mBaseMoveSpeed = 295
    bundleNatures_Prophet.mBaseArmor = 1


    bundleNatures_Prophet.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleNatures_Prophet.mName, bundleNatures_Prophet)



    '----------------------------------------------------------
    '-ENCHANTRESS START-----------------------------
    '----------------------------------------------------------
    Dim bundleEnchantress As New HeroBundle
    'FROM UNITBASE
    bundleEnchantress.mIDItem = New dvID(New Guid("d4416b17-148f-4883-845f-0ae823e35781"), "Herobundle: Enchantress", eEntity.Herobundle)
    bundleEnchantress.mName = eHeroName.untEnchantress
    bundleEnchantress.DisplayName = "Enchantress"
    bundleEnchantress.mArmorType = eArmorType.Hero
    bundleEnchantress.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/enchantress_vert.jpg"
    bundleEnchantress.mWebpageLink = "http://www.dota2.com/hero/Enchantress/"

    bundleEnchantress.mAttackType = eAttackType.Ranged
    bundleEnchantress.mBaseHitpoints = 0
    bundleEnchantress.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleEnchantress.mBaseAttackDamage = New ValueWrapper(31, 41)

    bundleEnchantress.mDaySightRange = 1800
    bundleEnchantress.mNightSightRange = 800

    bundleEnchantress.mAttackRange = 550
    bundleEnchantress.mMissileSpeed = 900

    bundleEnchantress.mAbilityNames.Add(eAbilityName.abUntouchable)
    bundleEnchantress.mAbilityNames.Add(eAbilityName.abEnchant)

    bundleEnchantress.mAbilityNames.Add(eAbilityName.abNatures_Attendants)
    bundleEnchantress.mAbilityNames.Add(eAbilityName.abImpetus)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleEnchantress.mDevName = "Enchantress"

    bundleEnchantress.mRoles.Add(eRole.Support)
    bundleEnchantress.mRoles.Add(eRole.Pusher)
    bundleEnchantress.mRoles.Add(eRole.Durable)
    bundleEnchantress.mRoles.Add(eRole.Jungler)

    bundleEnchantress.mPrimaryStat = ePrimaryStat.Intelligence

    bundleEnchantress.mBio = "Aiushtha appears to be an innocent, carefree creature of the woods, and while this is certainly true, it is hardly the sum of her story. She well understands the suffering of the natural world. She has wandered far, and fared through forests bright and drear, in every clime and every season, gathering friends, sharing news, bringing laughter and healing wherever she goes. For in worlds wracked by war, forests are leveled for the building of ships and siege engines; and even in places of peace, the woods are stripped for the building of homes, and as fuel for countless hearths. Aiushtha hears the pleas of the small creatures, the furtive folk who need green shade and a leafy canopy to thrive. She lends her ears to those who have no other listeners. She carries their stories from the wood to the world, believing that her own good cheer is a kind of Enchantment, that can itself fulfill the promise of a verdant future. "

    bundleEnchantress.mBaseStr = 16
    bundleEnchantress.mStrIncrement = 1

    bundleEnchantress.mBaseInt = 16
    bundleEnchantress.mIntIncrement = 2.8

    bundleEnchantress.mBaseAgi = 19
    bundleEnchantress.mAgiIncrement = 1.8


    bundleEnchantress.mBaseMoveSpeed = 310

    bundleEnchantress.mBaseArmor = -2

    bundleEnchantress.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleEnchantress.mName, bundleEnchantress)



    '----------------------------------------------------------
    '-JAKIRO START-----------------------------
    '----------------------------------------------------------
    Dim bundleJakiro As New HeroBundle
    'FROM UNITBASE
    bundleJakiro.mIDItem = New dvID(New Guid("5cbb55c0-3b45-498e-8c8f-c8e2cb2bde99"), "Herobundle: Jakiro", eEntity.Herobundle)
    bundleJakiro.mName = eHeroName.untJakiro
    bundleJakiro.DisplayName = "Jakiro"
    bundleJakiro.mArmorType = eArmorType.Hero
    bundleJakiro.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/jakiro_vert.jpg"
    bundleJakiro.mWebpageLink = "http://www.dota2.com/hero/Jakiro/"

    bundleJakiro.mAttackType = eAttackType.Ranged
    bundleJakiro.mBaseHitpoints = 0
    bundleJakiro.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleJakiro.mBaseAttackDamage = New ValueWrapper(18, 26)

    bundleJakiro.mDaySightRange = 1800
    bundleJakiro.mNightSightRange = 800

    bundleJakiro.mAttackRange = 400
    bundleJakiro.mMissileSpeed = 1100


    bundleJakiro.mAbilityNames.Add(eAbilityName.abDual_Breath)
    bundleJakiro.mAbilityNames.Add(eAbilityName.abIce_Path)
    bundleJakiro.mAbilityNames.Add(eAbilityName.abLiquid_Fire)
    bundleJakiro.mAbilityNames.Add(eAbilityName.abMacropyre)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleJakiro.mDevName = "Jakiro"

    bundleJakiro.mRoles.Add(eRole.Nuker)
    bundleJakiro.mRoles.Add(eRole.Pusher)
    bundleJakiro.mRoles.Add(eRole.LaneSupport)
    bundleJakiro.mRoles.Add(eRole.Disabler)

    bundleJakiro.mPrimaryStat = ePrimaryStat.Intelligence

    bundleJakiro.mBio = "Even among magical beasts, a twin-headed dragon is a freak. Equal parts ice and fire, cunning and rage, the creature known as Jakiro glides over charred and ice-bound battlefields, laying waste to any who would bear arms against it. Pyrexae dragon clutches always contain two fledglings. Famous for their viciousness even from the first moments of life, newly hatched dragons of this species will try to kill their sibling while still in the nest. Only the strongest survive. In this way is the strength of the Pyrexae line ensured. By some accident of nature, the freak Jakiro hatched from a single egg, combining in a single individual the full range of abilities found within the diverse Pyrexae species. Trapped within the armature of its monstrous body, the powers of ice and fire combine, and now no enemy is safe. "

    bundleJakiro.mBaseStr = 24
    bundleJakiro.mStrIncrement = 2.3

    bundleJakiro.mBaseInt = 28
    bundleJakiro.mIntIncrement = 2.8

    bundleJakiro.mBaseAgi = 10
    bundleJakiro.mAgiIncrement = 1.2


    bundleJakiro.mBaseMoveSpeed = 290
    bundleJakiro.mBaseArmor = 1


    bundleJakiro.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleJakiro.mName, bundleJakiro)



    '----------------------------------------------------------
    '-CHEN START-----------------------------
    '----------------------------------------------------------
    Dim bundleChen As New HeroBundle
    'FROM UNITBASE
    bundleChen.mIDItem = New dvID(New Guid("98cb3384-cca2-4e32-b97d-b1a533ddd7ac"), "Herobundle: Chen", eEntity.Herobundle)
    bundleChen.mName = eHeroName.untChen
    bundleChen.DisplayName = "Chen"
    bundleChen.mArmorType = eArmorType.Hero
    bundleChen.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/chen_vert.jpg"
    bundleChen.mWebpageLink = "http://www.dota2.com/hero/Chen/"

    bundleChen.mAttackType = eAttackType.Ranged
    bundleChen.mBaseHitpoints = 0
    bundleChen.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleChen.mBaseAttackDamage = New ValueWrapper(22, 32)

    bundleChen.mDaySightRange = 1800
    bundleChen.mNightSightRange = 800

    bundleChen.mAttackRange = 600
    bundleChen.mMissileSpeed = 1100

    bundleChen.mAbilityNames.Add(eAbilityName.abPenitence)
    bundleChen.mAbilityNames.Add(eAbilityName.abTest_Of_Faith)
    bundleChen.mAbilityNames.Add(eAbilityName.abHoly_Persuasion)
    bundleChen.mAbilityNames.Add(eAbilityName.abHand_Of_God)





    'FROM HEROBASE
    'Fixed, immutable stats
    bundleChen.mDevName = "Chen"

    bundleChen.mRoles.Add(eRole.Support)
    bundleChen.mRoles.Add(eRole.Jungler)
    bundleChen.mRoles.Add(eRole.Pusher)

    bundleChen.mPrimaryStat = ePrimaryStat.Intelligence

    bundleChen.mBio = "Born in the godless Hazhadal Barrens, Chen came of age among the outlaw tribes who eked out an existence in the shimmering heat of the desert. Using an ancient form of animal enthrallment, Chen's people husbanded the hardy desert locuthi, a stunted species of burrowing dragon that melted desert sands into tubes of glass where twice-a-year rains collected. Always on the edge of starvation and thirst, fighting amongst their neighbors and each other, Chen's clan made the mistake, one fateful day, of ambushing the wrong caravan. |In the vicious battle that followed, Chen's clan was outmatched. The armored Knights of the Fold made short work of the enthralled locuthi, who attacked and died in waves. With their dragons dead, the tribesmen followed. Chen struggled, and slashed, and clawed, and perished-or would have. Defeated, on his knees, he faced his execution with humility, offering his neck to the blade. Moved by Chen's obvious courage, the executioner halted his sword. Instead of the blade, Chen was given a choice: death or conversion. Chen took to the faith with a ferocity. He joined the Fold and earned his armor one bloody conversion at a time. Now, with the fanaticism of a convert, and with his powers of animal enthrallment at their peak, he seeks out unbelievers and introduces them to their final reward. "

    bundleChen.mBaseStr = 20
    bundleChen.mStrIncrement = 1.5

    bundleChen.mBaseInt = 21
    bundleChen.mIntIncrement = 2.8

    bundleChen.mBaseAgi = 15
    bundleChen.mAgiIncrement = 2.1


    bundleChen.mBaseMoveSpeed = 300

    bundleChen.mBaseArmor = -1

    bundleChen.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleChen.mName, bundleChen)



    '----------------------------------------------------------
    '-SILENCER START-----------------------------
    '----------------------------------------------------------
    Dim bundleSilencer As New HeroBundle
    'FROM UNITBASE
    bundleSilencer.mIDItem = New dvID(New Guid("d64d2fbb-3893-4431-b3cc-f8a6936a982d"), "Herobundle: Silencer", eEntity.Herobundle)
    bundleSilencer.mName = eHeroName.untSilencer
    bundleSilencer.DisplayName = "Silencer"
    bundleSilencer.mArmorType = eArmorType.Hero
    bundleSilencer.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/silencer_vert.jpg"
    bundleSilencer.mWebpageLink = "http://www.dota2.com/hero/Silencer/"

    bundleSilencer.mAttackType = eAttackType.Ranged
    bundleSilencer.mBaseHitpoints = 0
    bundleSilencer.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleSilencer.mBaseAttackDamage = New ValueWrapper(16, 30)

    bundleSilencer.mDaySightRange = 1800
    bundleSilencer.mNightSightRange = 800

    bundleSilencer.mAttackRange = 600
    bundleSilencer.mMissileSpeed = 1000


    bundleSilencer.mAbilityNames.Add(eAbilityName.abCurse_Of_The_Silent)
    bundleSilencer.mAbilityNames.Add(eAbilityName.abGlaives_Of_Wisdom)
    bundleSilencer.mAbilityNames.Add(eAbilityName.abLast_Word)
    bundleSilencer.mAbilityNames.Add(eAbilityName.abGlobal_Silence)



    'FROM HEROBASE
    'Fixed, immutable stats
    bundleSilencer.mDevName = "Silencer"

    bundleSilencer.mRoles.Add(eRole.Support)
    bundleSilencer.mRoles.Add(eRole.Carry)
    bundleSilencer.mRoles.Add(eRole.Initiator)

    bundleSilencer.mPrimaryStat = ePrimaryStat.Intelligence

    bundleSilencer.mBio = "Part of the seventh and final generation of a carefully designed pedigree, Nortrom was bred by the ancient order of the Aeol Drias to be the greatest magic user the world had ever seen. He was the prophesied one, the culmination of two-hundred years of careful pairings, a war-mage who would bring glory to the order, and destruction to their sworn enemies, The Knights of the Fold.|Raised with other young mages in a hidden cantonment among the hills of the Hazhadal barrens, the order's preceptors waited for Nortrom's abilities to manifest. While the other students honed their talents with fire, or ice, or incantatory spells, Nortrom sat silent and talentless, unable to cast so much as a hex. As the day of final testing approached, he still hadn't found his magic. In disgust, the preceptors berated him, while the children laughed. """"You are no mage,"""" the head of the order declared. Still, Nortrom did not slink away. He entered the day of testing and faced down the young mages who had mocked him. And then his preceptors learned a valuable lesson: a lack of magic can be the greatest magic of all. Nortrom silenced the young mages one by one and defeated them in single combat, until he alone stood as champion of the Aeol Drias, in fulfillment of the prophecy. "

    bundleSilencer.mBaseStr = 17
    bundleSilencer.mStrIncrement = 2.2

    bundleSilencer.mBaseInt = 27
    bundleSilencer.mIntIncrement = 2.5

    bundleSilencer.mBaseAgi = 16
    bundleSilencer.mAgiIncrement = 3


    bundleSilencer.mBaseMoveSpeed = 300

    bundleSilencer.mBaseArmor = -1

    bundleSilencer.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleSilencer.mName, bundleSilencer)



    '----------------------------------------------------------
    '-OGRE MAGI START-----------------------------
    '----------------------------------------------------------
    Dim bundleOgre_Magi As New HeroBundle
    'FROM UNITBASE
    bundleOgre_Magi.mIDItem = New dvID(New Guid("4df39371-6764-4bf5-b59b-a630b3ff5a41"), "Herobundle: Ogre Magi", eEntity.Herobundle)
    bundleOgre_Magi.mName = eHeroName.untOgre_Magi
    bundleOgre_Magi.DisplayName = "Ogre Magi"
    bundleOgre_Magi.mArmorType = eArmorType.Hero
    bundleOgre_Magi.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/ogre_magi_vert.jpg"
    bundleOgre_Magi.mWebpageLink = "http://www.dota2.com/hero/Ogre_Magi/"

    bundleOgre_Magi.mAttackType = eAttackType.Melee
    bundleOgre_Magi.mBaseHitpoints = 0
    bundleOgre_Magi.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleOgre_Magi.mBaseAttackDamage = New ValueWrapper(41, 47)

    bundleOgre_Magi.mDaySightRange = 1800
    bundleOgre_Magi.mNightSightRange = 800

    bundleOgre_Magi.mAttackRange = 128
    bundleOgre_Magi.mMissileSpeed = Nothing

    bundleOgre_Magi.mAbilityNames.Add(eAbilityName.abFireblast)
    bundleOgre_Magi.mAbilityNames.Add(eAbilityName.abIgnite)
    bundleOgre_Magi.mAbilityNames.Add(eAbilityName.abBloodlust)

    'bundleOgre_Magi.mAbilityNames.Add(eAbilityName.abUnrefined_Fireblast)
    bundleOgre_Magi.mAbilityNames.Add(eAbilityName.abMulticast)



    'FROM HEROBASE
    'Fixed, immutable stats
    bundleOgre_Magi.mDevName = "Ogre_Magi"

    bundleOgre_Magi.mRoles.Add(eRole.Nuker)
    bundleOgre_Magi.mRoles.Add(eRole.Disabler)
    bundleOgre_Magi.mRoles.Add(eRole.Durable)

    bundleOgre_Magi.mPrimaryStat = ePrimaryStat.Intelligence

    bundleOgre_Magi.mBio = "The ordinary ogre is the creature for whom the phrase 'As dumb as a bag of rock hammers' was coined. In his natural state, an ogre is supremely incapable of doing or deciding anything. Clothed in dirt, he sometimes finds himself accidentally draped in animal skins after eating lanekill. Not an especially social creature, he is most often found affectionately consorting with the boulders or tree-stumps he has mistaken for kin (a factor that may explain the ogre's low rate of reproduction). However, once every generation or so, the ogre race is blessed with the birth of a two-headed Ogre Magi, who is immediately given the traditional name of Aggron Stonebreak, the name of the first and perhaps only wise ogre in their line's history. With two heads, Ogre Magi finds it possible to function at a level most other creatures manage with one. And while the Ogre Magi will win no debates (even with itself), it is graced with a divine quality known as Dumb Luck--a propensity for serendipitous strokes of fortune which have allowed the ogre race to flourish in spite of enemies, harsh weather, and an inability to feed itself. It's as if the Goddess of Luck, filled with pity for the sadly inept species, has taken Ogre Magi under her wing. And who could blame her? Poor things. "

    bundleOgre_Magi.mBaseStr = 23
    bundleOgre_Magi.mStrIncrement = 3.2

    bundleOgre_Magi.mBaseInt = 17
    bundleOgre_Magi.mIntIncrement = 2.4

    bundleOgre_Magi.mBaseAgi = 14
    bundleOgre_Magi.mAgiIncrement = 1.55


    bundleOgre_Magi.mBaseMoveSpeed = 295
    bundleOgre_Magi.mBaseArmor = 5


    bundleOgre_Magi.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleOgre_Magi.mName, bundleOgre_Magi)



    '----------------------------------------------------------
    '-RUBICK START-----------------------------
    '----------------------------------------------------------
    Dim bundleRubick As New HeroBundle
    'FROM UNITBASE
    bundleRubick.mIDItem = New dvID(New Guid("b073cad8-bbbb-4ff9-a124-3e7ef6c308e9"), "Herobundle: Rubick", eEntity.Herobundle)
    bundleRubick.mName = eHeroName.untRubick
    bundleRubick.DisplayName = "Rubick"
    bundleRubick.mArmorType = eArmorType.Hero
    bundleRubick.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/rubick_vert.jpg"
    bundleRubick.mWebpageLink = "http://www.dota2.com/hero/Rubick/"

    bundleRubick.mAttackType = eAttackType.Ranged
    bundleRubick.mBaseHitpoints = 0
    bundleRubick.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleRubick.mBaseAttackDamage = New ValueWrapper(17, 27)

    bundleRubick.mDaySightRange = 1800
    bundleRubick.mNightSightRange = 800

    bundleRubick.mAttackRange = 600
    bundleRubick.mMissileSpeed = 1125

    bundleRubick.mAbilityNames.Add(eAbilityName.abTelekinesis)
    bundleRubick.mAbilityNames.Add(eAbilityName.abFade_Bolt)
    bundleRubick.mAbilityNames.Add(eAbilityName.abNull_Field)
    bundleRubick.mAbilityNames.Add(eAbilityName.abSpell_Steal)

    ' bundleRubick.mAbilityNames.Add(eAbilityName.abTelekinesis_Land)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleRubick.mDevName = "Rubick"

    bundleRubick.mRoles.Add(eRole.Disabler)
    bundleRubick.mRoles.Add(eRole.Nuker)

    bundleRubick.mPrimaryStat = ePrimaryStat.Intelligence

    bundleRubick.mBio = "Any mage can cast a spell or two, and a few may even study long enough to become a wizard, but only the most talented are allowed to be recognized as a Magus. Yet as with any sorcerer's circle, a sense of community has never guaranteed competitive courtesy.|Already a renowned duelist and scholar of the grander world of sorcery, it had never occurred to Rubick that he might perhaps be Magus material until he was in the midst of his seventh assassination attempt. As he casually tossed the twelfth of a string of would-be killers from a high balcony, it dawned on him how utterly unimaginative the attempts on his life had become. Where once the interruption of a fingersnap or firehand might have put a cheerful spring in his step, it had all become so very predictable. He craved greater competition. Therefore, donning his combat mask, he did what any wizard seeking to ascend the ranks would do: he announced his intention to kill a Magus.|Rubick quickly discovered that to threaten one Magus is to threaten them all, and they fell upon him in force. Each antagonist's spell was an unstoppable torrent of energy, and every attack a calculated killing blow. But very soon something occurred that Rubick's foes found unexpected: their arts appeared to turn against them. Inside the magic maelstrom, Rubick chuckled, subtly reading and replicating the powers of one in order to cast it against another, sowing chaos among those who had allied against him. Accusations of betrayal began to fly, and soon the sorcerers turned one upon another without suspecting who was behind their undoing.|When the battle finally drew to a close, all were singed and frozen, soaked and cut and pierced. More than one lay dead by an ally's craft. Rubick stood apart, sore but delighted in the week's festivities. None had the strength to argue when he presented his petition of assumption to the Hidden Council, and the Insubstantial Eleven agreed as one to grant him the title of Grand Magus. "

    bundleRubick.mBaseStr = 19
    bundleRubick.mStrIncrement = 1.5

    bundleRubick.mBaseInt = 27
    bundleRubick.mIntIncrement = 2.4

    bundleRubick.mBaseAgi = 14
    bundleRubick.mAgiIncrement = 1.6


    bundleRubick.mBaseMoveSpeed = 290

    bundleRubick.mBaseArmor = -1

    bundleRubick.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleRubick.mName, bundleRubick)



    '----------------------------------------------------------
    '-DISRUPTOR START-----------------------------
    '----------------------------------------------------------
    Dim bundleDisruptor As New HeroBundle
    'FROM UNITBASE
    bundleDisruptor.mIDItem = New dvID(New Guid("675de4d7-d61e-4cd7-a4a7-380f151ea697"), "Herobundle: Disruptor", eEntity.Herobundle)
    bundleDisruptor.mName = eHeroName.untDisruptor
    bundleDisruptor.DisplayName = "Disruptor"
    bundleDisruptor.mArmorType = eArmorType.Hero
    bundleDisruptor.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/disruptor_vert.jpg"
    bundleDisruptor.mWebpageLink = "http://www.dota2.com/hero/Disruptor/"

    bundleDisruptor.mAttackType = eAttackType.Ranged
    bundleDisruptor.mBaseHitpoints = 0
    bundleDisruptor.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleDisruptor.mBaseAttackDamage = New ValueWrapper(27, 31)

    bundleDisruptor.mDaySightRange = 1800
    bundleDisruptor.mNightSightRange = 800

    bundleDisruptor.mAttackRange = 600
    bundleDisruptor.mMissileSpeed = 1200

    bundleDisruptor.mAbilityNames.Add(eAbilityName.abThunder_Strike)
    bundleDisruptor.mAbilityNames.Add(eAbilityName.abGlimpse)
    bundleDisruptor.mAbilityNames.Add(eAbilityName.abKinetic_Field)
    bundleDisruptor.mAbilityNames.Add(eAbilityName.abStatic_Storm)



    'FROM HEROBASE
    'Fixed, immutable stats
    bundleDisruptor.mDevName = "Disruptor"

    bundleDisruptor.mRoles.Add(eRole.Nuker)
    bundleDisruptor.mRoles.Add(eRole.Support)
    bundleDisruptor.mRoles.Add(eRole.Initiator)
    bundleDisruptor.mRoles.Add(eRole.Disabler)

    bundleDisruptor.mPrimaryStat = ePrimaryStat.Intelligence

    bundleDisruptor.mBio = "High on the wind-ravaged steppes of Druud, a gifted young stormcrafter called Disruptor was the first to unlock the secrets of the summer squalls. Constantly under assault from both seasonal storms and encroachment from civilized kingdoms to the South, the upland Oglodi have for centuries struggled to subsist atop the endless tablelands. They are the fractured remnant of a once-great civilization, a fallen tribe, their stormcraft strange and inscrutable, cobbled together from scraps of lost knowledge which even they no longer fully understand. For those on the high plain, weather has become a kind of religion, worshiped as both the giver and taker of life. But the electrical storms that bring life-sustaining rains arrive at a cost, and many are the charred and smoking corpses left in their wake.|Although small for his kind, Disruptor is fearless, and driven by an insatiable curiosity. As a youth, while still unblooded and without a stryder, he explored the ruins of the ancestral cities--searching through collapsed and long-moldering libraries, rummaging through rusting manufactories. He took what he needed and returned to his tribe. Adapting a coil of ancient design, he harnessed the power of electrical differential and now calls down the thunder whenever he wishes. Part magic, part craftsmanship, his coils hold in their glowing plates the power of life and death--a power wielded with precision against the landed castes to the South, and any interlopers who cross into ancient Oglodi lands. "

    bundleDisruptor.mBaseStr = 19
    bundleDisruptor.mStrIncrement = 1.9

    bundleDisruptor.mBaseInt = 22
    bundleDisruptor.mIntIncrement = 2.5

    bundleDisruptor.mBaseAgi = 15
    bundleDisruptor.mAgiIncrement = 1.4


    bundleDisruptor.mBaseMoveSpeed = 300

    bundleDisruptor.mBaseArmor = -1

    bundleDisruptor.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleDisruptor.mName, bundleDisruptor)



    '----------------------------------------------------------
    '-KEEPER OF THE LIGHT START-----------------------------
    '----------------------------------------------------------
    Dim bundleKeeper_Of_The_Light As New HeroBundle
    'FROM UNITBASE
    bundleKeeper_Of_The_Light.mIDItem = New dvID(New Guid("ecac4c57-7ce6-470a-a049-62cc89c38bc0"), "Herobundle: Keeper Of The Light", eEntity.Herobundle)
    bundleKeeper_Of_The_Light.mName = eHeroName.untKeeper_of_the_Light
    bundleKeeper_Of_The_Light.DisplayName = "Keeper of the Light"
    bundleKeeper_Of_The_Light.mArmorType = eArmorType.Hero
    bundleKeeper_Of_The_Light.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/keeper_of_the_light_vert.jpg"
    bundleKeeper_Of_The_Light.mWebpageLink = "http://www.dota2.com/hero/Keeper_of_the_Light/"

    bundleKeeper_Of_The_Light.mAttackType = eAttackType.Ranged
    bundleKeeper_Of_The_Light.mBaseHitpoints = 0
    bundleKeeper_Of_The_Light.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleKeeper_Of_The_Light.mBaseAttackDamage = New ValueWrapper(18, 32)

    bundleKeeper_Of_The_Light.mDaySightRange = 1800
    bundleKeeper_Of_The_Light.mNightSightRange = 800

    bundleKeeper_Of_The_Light.mAttackRange = 600
    bundleKeeper_Of_The_Light.mMissileSpeed = 900

    bundleKeeper_Of_The_Light.mAbilityNames.Add(eAbilityName.abIlluminate)
    bundleKeeper_Of_The_Light.mAbilityNames.Add(eAbilityName.abMana_Leak)
    bundleKeeper_Of_The_Light.mAbilityNames.Add(eAbilityName.abChakra_Magic)
    'bundleKeeper_Of_The_Light.mAbilityNames.Add(eAbilityName.abRecall)
    'bundleKeeper_Of_The_Light.mAbilityNames.Add(eAbilityName.abBlinding_Light)
    bundleKeeper_Of_The_Light.mAbilityNames.Add(eAbilityName.abSpirit_Form)



    ' bundleKeeper_Of_The_Light.mAbilityNames.Add(eAbilityName.abRelease_Illuminate)



    'FROM HEROBASE
    'Fixed, immutable stats
    bundleKeeper_Of_The_Light.mDevName = "Keeper_of_the_Light"

    bundleKeeper_Of_The_Light.mRoles.Add(eRole.Nuker)
    bundleKeeper_Of_The_Light.mRoles.Add(eRole.Support)
    bundleKeeper_Of_The_Light.mRoles.Add(eRole.LaneSupport)

    bundleKeeper_Of_The_Light.mPrimaryStat = ePrimaryStat.Intelligence

    bundleKeeper_Of_The_Light.mBio = "Upon a pale horse he rides, this spark of endless suns, this Keeper of the Light. Ezalor long ago escaped the Fundamental plane, separating from the other ancient forces to which he was bound within the great Primordial harmony. He is a power grown sentient in the dawn of the universe, and now rides forth in all planes at once, one step ahead of pursuing chaos, bearing his gift with him at the end of a radiant staff. His majestic truth lies hidden beneath the outward appearance of a slightly doddering old man who barely stays in the saddle. However, when faced with the challenge of chaos, or the forces of darkness, his primordial light bursts forth, and his full power is revealed, transforming him once again into a force to be reckoned with. "

    bundleKeeper_Of_The_Light.mBaseStr = 14
    bundleKeeper_Of_The_Light.mStrIncrement = 1.8

    bundleKeeper_Of_The_Light.mBaseInt = 22
    bundleKeeper_Of_The_Light.mIntIncrement = 2.8

    bundleKeeper_Of_The_Light.mBaseAgi = 15
    bundleKeeper_Of_The_Light.mAgiIncrement = 1.6


    bundleKeeper_Of_The_Light.mBaseMoveSpeed = 315

    bundleKeeper_Of_The_Light.mBaseArmor = -1

    bundleKeeper_Of_The_Light.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleKeeper_Of_The_Light.mName, bundleKeeper_Of_The_Light)



    '----------------------------------------------------------
    '-SKYWRATH MAGE START-----------------------------
    '----------------------------------------------------------
    Dim bundleSkywrath_Mage As New HeroBundle
    'FROM UNITBASE
    bundleSkywrath_Mage.mIDItem = New dvID(New Guid("20c0f302-8069-4ae5-908d-e39258069f74"), "Herobundle: Skywrath Mage", eEntity.Herobundle)
    bundleSkywrath_Mage.mName = eHeroName.untSkywrath_Mage
    bundleSkywrath_Mage.DisplayName = "Skywrath Mage"
    bundleSkywrath_Mage.mArmorType = eArmorType.Hero
    bundleSkywrath_Mage.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/skywrath_mage_vert.jpg"
    bundleSkywrath_Mage.mWebpageLink = "http://www.dota2.com/hero/Skywrath_Mage/"

    bundleSkywrath_Mage.mAttackType = eAttackType.Ranged
    bundleSkywrath_Mage.mBaseHitpoints = 0
    bundleSkywrath_Mage.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleSkywrath_Mage.mBaseAttackDamage = New ValueWrapper(12, 22)

    bundleSkywrath_Mage.mDaySightRange = 1800
    bundleSkywrath_Mage.mNightSightRange = 800

    bundleSkywrath_Mage.mAttackRange = 600
    bundleSkywrath_Mage.mMissileSpeed = 1000

    bundleSkywrath_Mage.mAbilityNames.Add(eAbilityName.abArcane_Bolt)
    bundleSkywrath_Mage.mAbilityNames.Add(eAbilityName.abConcussive_Shot)
    bundleSkywrath_Mage.mAbilityNames.Add(eAbilityName.abAncient_Seal)


    bundleSkywrath_Mage.mAbilityNames.Add(eAbilityName.abMystic_Flare)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleSkywrath_Mage.mDevName = "Skywrath_Mage"

    bundleSkywrath_Mage.mRoles.Add(eRole.Nuker)
    bundleSkywrath_Mage.mRoles.Add(eRole.Support)

    bundleSkywrath_Mage.mPrimaryStat = ePrimaryStat.Intelligence

    bundleSkywrath_Mage.mBio = "A highly placed mage in the court of the Ghastly Eyrie, Dragonus lives a troubled existence. Sworn by birth to protect whoever sits within the Nest of Thorns, he hates the current Skywrath queen with all his soul. As a youth, high-born, he was a friend and companion to the eldest Skywrath princess, Shendelzare, first in line for the Nest. He had loved her warmly and unshakably, but as his studies took hold, his mind turned to arcane learning and the mastery of Skywrath sorcery.|Obsessed with matters aetherial, he missed the mundane signs of courtly treachery that hinted at a plot against Shendelzare, and lost his chance to foil it. When the court was shaken by a swift and violent coup, he emerged from his studies to discover his oldest and dearest friend had been lost to him. The Nest of Thorns now belonged to Shendelzare's ruthless younger sister, and Dragonus could do nothing. The magic of the Skywrath Mage serves only the sworn protector of the Skywrath scion, so to act against the Nest would render him helpless. He clings to his post, believing it to be the best hope of one day restoring his true love to her rightful place. Meanwhile, his secret is known only to the goddess Scree'auk, whose magic it was transformed Shendelzare from a crippled physical creature into an embodiment of pure vengeful energy.|While he dreams of restoring his beloved queen to the Ghastly Eyrie, he dreams even more desperately of restoring Shendelzare herself to a fully healed physical form. The duplicity of his role at court tortures him, for he is a noble and good-hearted creature; but the worst torture of all is imagining the hatred that Vengeful Spirit must hold in her heart for him. "

    bundleSkywrath_Mage.mBaseStr = 19
    bundleSkywrath_Mage.mStrIncrement = 1.5

    bundleSkywrath_Mage.mBaseInt = 27
    bundleSkywrath_Mage.mIntIncrement = 3.6

    bundleSkywrath_Mage.mBaseAgi = 18
    bundleSkywrath_Mage.mAgiIncrement = 0.8


    bundleSkywrath_Mage.mBaseMoveSpeed = 325

    bundleSkywrath_Mage.mBaseArmor = -2

    bundleSkywrath_Mage.mBaseArmordebuff = 0.18

    bundleSkywrath_Mage.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleSkywrath_Mage.mName, bundleSkywrath_Mage)



    '----------------------------------------------------------
    '-TECHIES START-----------------------------
    '----------------------------------------------------------
    Dim bundleTechies As New HeroBundle
    'FROM UNITBASE
    bundleTechies.mIDItem = New dvID(New Guid("b81ad0b9-5276-4e96-a337-3ef95a9bc519"), "Herobundle: Techies", eEntity.Herobundle)
    bundleTechies.mName = eHeroName.untTechies
    bundleTechies.DisplayName = "Techies"
    bundleTechies.mArmorType = eArmorType.Hero
    bundleTechies.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/techies_vert.jpg"
    bundleTechies.mWebpageLink = "http://www.dota2.com/hero/Techies/"

    bundleTechies.mAttackType = eAttackType.Ranged
    bundleTechies.mBaseHitpoints = 0
    bundleTechies.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleTechies.mBaseAttackDamage = New ValueWrapper(7, 9)

    bundleTechies.mDaySightRange = 1800
    bundleTechies.mNightSightRange = 800

    bundleTechies.mAttackRange = 700
    bundleTechies.mMissileSpeed = 900

    bundleTechies.mAbilityNames.Add(eAbilityName.abLand_Mines)
    bundleTechies.mAbilityNames.Add(eAbilityName.abStasis_Trap)
    bundleTechies.mAbilityNames.Add(eAbilityName.abSuicide_Squad_Attack)
    'bundleTechies.mAbilityNames.Add(eAbilityName.abFocused_Detonate)

    'bundleTechies.mAbilityNames.Add(eAbilityName.abMinefield_Sign)
    bundleTechies.mAbilityNames.Add(eAbilityName.abRemote_Mines)




    'FROM HEROBASE
    'Fixed, immutable stats
    bundleTechies.mDevName = "Techies"


    bundleTechies.mPrimaryStat = ePrimaryStat.Intelligence

    bundleTechies.mBio = "In the storied saga of Dredger's Bight, no business has ever been more reviled than Techies Demolitions. Then again, Dredger's Bight no longer exists. Nor does Toterin. Or even Trapper Town. In fact, if one were to track the history of Techies Demolitions they might notice that shortly after Techies appear, towns tend to disappear.|Like every inevitable disaster surrounding Techies, the obliteration of Dredger's Bight began with an invention. Tasked with designing a safer way of detonating explosives in the mines beneath the city, pyrotechnic prodigies Squee, Spleen, and Spoon developed their most outlandish creation yet: a button which, when pressed, would trigger a distant device to spark a fuse.|Overeager to test their invention, the trio stuffed barrel after barrel with flamesalt explosives, piling every corner of their tiny workshop high with the newly developed remote bombs. From this stockpile they plucked a single payload, burying it in a far away field. As they cowered in a ditch, Spleen pressed the detonator button. Yet after a moment, nothing happened. Confused, he stood up, pressing his button again and again until, finally, an explosion tore a hole in the field. Elated, Squee and Spleen turned toward home just as a massive wave of sound and force arrived to knock them over.|Bewildered, their ears ringing from the unexpected blast, they gathered in the dingy miasma to see a smoking ruin where their workshop once stood. Chunks of wood and stone continued to fall as the yawning crater before them slowly deepened into an expanding pit. The whole of Dredger's Bight shuddered, and then gradually started to slide into the mines below as its panicked residents fled.|Sitting at the edge of their sinking home they grinned and giggled, as giddy at the possibilities as they were oblivious to the scorn of their former neighbors. They wondered only one thing: how could they trigger an even bigger blast? "

    bundleTechies.mBaseStr = 17
    bundleTechies.mStrIncrement = 2

    bundleTechies.mBaseInt = 22
    bundleTechies.mIntIncrement = 2.9

    bundleTechies.mBaseAgi = 14
    bundleTechies.mAgiIncrement = 1.3


    bundleTechies.mBaseMoveSpeed = 270
    bundleTechies.mBaseArmor = 5


    bundleTechies.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleTechies.mName, bundleTechies)



    '----------------------------------------------------------
    '-AXE START-----------------------------
    '----------------------------------------------------------
    Dim bundleAxe As New HeroBundle
    'FROM UNITBASE
    bundleAxe.mIDItem = New dvID(New Guid("5d38d7b1-a8f0-418e-9fab-6aa330df3c6e"), "Herobundle: Axe", eEntity.Herobundle)
    bundleAxe.mName = eHeroName.untAxe
    bundleAxe.DisplayName = "Axe"
    bundleAxe.mArmorType = eArmorType.Hero
    bundleAxe.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/axe_vert.jpg"
    bundleAxe.mWebpageLink = "http://www.dota2.com/hero/Axe/"

    bundleAxe.mAttackType = eAttackType.Melee
    bundleAxe.mBaseHitpoints = 0
    bundleAxe.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleAxe.mBaseAttackDamage = New ValueWrapper(24, 28)

    bundleAxe.mDaySightRange = 1800
    bundleAxe.mNightSightRange = 800

    bundleAxe.mAttackRange = 128
    bundleAxe.mMissileSpeed = Nothing

    bundleAxe.mAbilityNames.Add(eAbilityName.abBerserkers_Call)
    bundleAxe.mAbilityNames.Add(eAbilityName.abBattle_Hunger)

    bundleAxe.mAbilityNames.Add(eAbilityName.abCounter_Helix)
    bundleAxe.mAbilityNames.Add(eAbilityName.abCulling_Blade)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleAxe.mDevName = "Axe"

    bundleAxe.mRoles.Add(eRole.Durable)
    bundleAxe.mRoles.Add(eRole.Initiator)
    bundleAxe.mRoles.Add(eRole.Disabler)
    bundleAxe.mRoles.Add(eRole.Jungler)

    bundleAxe.mPrimaryStat = ePrimaryStat.Strength

    bundleAxe.mBio = "As a grunt in the Army of Red Mist, Mogul Khan set his sights on the rank of Red Mist General. In battle after battle he proved his worth through gory deed. His rise through the ranks was helped by the fact that he never hesitated to decapitate a superior. Through the seven year Campaign of the Thousand Tarns, he distinguished himself in glorious carnage, his star of fame shining ever brighter, while the number of comrades in arms steadily dwindled. On the night of ultimate victory, Axe declared himself the new Red Mist General, and took on the ultimate title of 'Axe.' But his troops now numbered zero. Of course, many had died in battle, but a significant number had also fallen to Axe's blade. Needless to say, most soldiers now shun his leadership. But this matters not a whit to Axe, who knows that a one-man army is by far the best. "

    bundleAxe.mBaseStr = 25
    bundleAxe.mStrIncrement = 2.5

    bundleAxe.mBaseInt = 18
    bundleAxe.mIntIncrement = 1.6

    bundleAxe.mBaseAgi = 20
    bundleAxe.mAgiIncrement = 2.2


    bundleAxe.mBaseMoveSpeed = 290

    bundleAxe.mBaseArmor = -1

    bundleAxe.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleAxe.mName, bundleAxe)



    '----------------------------------------------------------
    '-PUDGE START-----------------------------
    '----------------------------------------------------------
    Dim bundlePudge As New HeroBundle
    'FROM UNITBASE
    bundlePudge.mIDItem = New dvID(New Guid("62a48b66-0761-4f83-bccf-60afc4c70fef"), "Herobundle: Pudge", eEntity.Herobundle)
    bundlePudge.mName = eHeroName.untPudge
    bundlePudge.DisplayName = "Pudge"
    bundlePudge.mArmorType = eArmorType.Hero
    bundlePudge.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/pudge_vert.jpg"
    bundlePudge.mWebpageLink = "http://www.dota2.com/hero/Pudge/"

    bundlePudge.mAttackType = eAttackType.Melee
    bundlePudge.mBaseHitpoints = 0
    bundlePudge.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundlePudge.mBaseAttackDamage = New ValueWrapper(27, 33)

    bundlePudge.mDaySightRange = 1800
    bundlePudge.mNightSightRange = 800

    bundlePudge.mAttackRange = 128
    bundlePudge.mMissileSpeed = Nothing

    bundlePudge.mAbilityNames.Add(eAbilityName.abMeat_Hook)
    bundlePudge.mAbilityNames.Add(eAbilityName.abRot)

    bundlePudge.mAbilityNames.Add(eAbilityName.abFlesh_Heap)
    bundlePudge.mAbilityNames.Add(eAbilityName.abDismember)



    'FROM HEROBASE
    'Fixed, immutable stats
    bundlePudge.mDevName = "Pudge"

    bundlePudge.mRoles.Add(eRole.Durable)
    bundlePudge.mRoles.Add(eRole.Disabler)

    bundlePudge.mPrimaryStat = ePrimaryStat.Strength

    bundlePudge.mBio = "In the Fields of Endless Carnage, far to the south of Quoidge, a corpulent figure works tirelessly through the night--dismembering, disembowelling, piling up the limbs and viscera of the fallen that the battlefield might be clear by dawn. In this cursed realm, nothing can decay or decompose; no corpse may ever return to the earth from which it sprang, no matter how deep you dig the grave. Flocked by carrion birds who need him to cut their meals into beak-sized chunks, Pudge the Butcher hones his skills with blades that grow sharper the longer he uses them. Swish, swish, thunk. Flesh falls from the bone; tendons and ligaments part like wet paper. And while he always had a taste for the butchery, over the ages, Pudge has developed a taste for its byproduct as well. Starting with a gobbet of muscle here, a sip of blood there...before long he was thrusting his jaws deep into the toughest of torsos, like a dog gnawing at rags. Even those who are beyond fearing the Reaper, fear the Butcher. "

    bundlePudge.mBaseStr = 25
    bundlePudge.mStrIncrement = 3.2

    bundlePudge.mBaseInt = 14
    bundlePudge.mIntIncrement = 1.5

    bundlePudge.mBaseAgi = 14
    bundlePudge.mAgiIncrement = 1.5


    bundlePudge.mBaseMoveSpeed = 285

    bundlePudge.mBaseArmor = -1

    bundlePudge.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundlePudge.mName, bundlePudge)



    '----------------------------------------------------------
    '-SAND KING START-----------------------------
    '----------------------------------------------------------
    Dim bundleSand_King As New HeroBundle
    'FROM UNITBASE
    bundleSand_King.mIDItem = New dvID(New Guid("029ac82b-9bf0-4584-8d60-f097365d7bcd"), "Herobundle: Sand King", eEntity.Herobundle)
    bundleSand_King.mName = eHeroName.untSand_King
    bundleSand_King.DisplayName = "Sand King"
    bundleSand_King.mArmorType = eArmorType.Hero
    bundleSand_King.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/sand_king_vert.jpg"
    bundleSand_King.mWebpageLink = "http://www.dota2.com/hero/Sand_King/"

    bundleSand_King.mAttackType = eAttackType.Melee
    bundleSand_King.mBaseHitpoints = 0
    bundleSand_King.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleSand_King.mBaseAttackDamage = New ValueWrapper(25, 41)

    bundleSand_King.mDaySightRange = 1800
    bundleSand_King.mNightSightRange = 800

    bundleSand_King.mAttackRange = 128
    bundleSand_King.mMissileSpeed = Nothing


    bundleSand_King.mAbilityNames.Add(eAbilityName.abBurrowstrike)
    bundleSand_King.mAbilityNames.Add(eAbilityName.abSand_Storm)
    bundleSand_King.mAbilityNames.Add(eAbilityName.abCaustic_Finale)
    bundleSand_King.mAbilityNames.Add(eAbilityName.abEpicenter)



    'FROM HEROBASE
    'Fixed, immutable stats
    bundleSand_King.mDevName = "Sand_King"

    bundleSand_King.mRoles.Add(eRole.Initiator)
    bundleSand_King.mRoles.Add(eRole.Disabler)
    bundleSand_King.mRoles.Add(eRole.Nuker)

    bundleSand_King.mPrimaryStat = ePrimaryStat.Strength

    bundleSand_King.mBio = "The sands of the Scintillant Waste are alive and sentient--the whole vast desert speaks to itself, thinking thoughts only such a vastness can conceive. But when it needs must find a form to communicate with those of more limited scope, it frees a fragment of itself, and fills a carapace of magic armor formed by the cunning Djinn of Qaldin. This essential identity calls itself Crixalis, meaning 'Soul of the Sand,' but others know it as Sand King. Sand King takes the form of a huge arachnid, inspired by the Scintillant Waste's small but ubiquitous denizens; and this is a true outward expression of his ferocious nature. Guardian, warrior, ambassador--Sand King is all of these things, inseparable from the endless desert that gave him life. "

    bundleSand_King.mBaseStr = 18
    bundleSand_King.mStrIncrement = 2.6

    bundleSand_King.mBaseInt = 16
    bundleSand_King.mIntIncrement = 1.8

    bundleSand_King.mBaseAgi = 19
    bundleSand_King.mAgiIncrement = 2.1


    bundleSand_King.mBaseMoveSpeed = 300
    bundleSand_King.mBaseArmor = 0


    bundleSand_King.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleSand_King.mName, bundleSand_King)



    '----------------------------------------------------------
    '-SLARDAR START-----------------------------
    '----------------------------------------------------------
    Dim bundleSlardar As New HeroBundle
    'FROM UNITBASE
    bundleSlardar.mIDItem = New dvID(New Guid("2ecadcf0-90bd-4e7a-abeb-60ed78ee87e7"), "Herobundle: Slardar", eEntity.Herobundle)
    bundleSlardar.mName = eHeroName.untSlardar
    bundleSlardar.DisplayName = "Slardar"
    bundleSlardar.mArmorType = eArmorType.Hero
    bundleSlardar.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/slardar_vert.jpg"
    bundleSlardar.mWebpageLink = "http://www.dota2.com/hero/Slardar/"

    bundleSlardar.mAttackType = eAttackType.Melee
    bundleSlardar.mBaseHitpoints = 0
    bundleSlardar.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleSlardar.mBaseAttackDamage = New ValueWrapper(30, 38)

    bundleSlardar.mDaySightRange = 1800
    bundleSlardar.mNightSightRange = 800

    bundleSlardar.mAttackRange = 128
    bundleSlardar.mMissileSpeed = Nothing

    bundleSlardar.mAbilityNames.Add(eAbilityName.abSprint)
    bundleSlardar.mAbilityNames.Add(eAbilityName.abSlithereen_Crush)
    bundleSlardar.mAbilityNames.Add(eAbilityName.abBash)
    bundleSlardar.mAbilityNames.Add(eAbilityName.abAmplify_Damage)





    'FROM HEROBASE
    'Fixed, immutable stats
    bundleSlardar.mDevName = "Slardar"

    bundleSlardar.mRoles.Add(eRole.Carry)
    bundleSlardar.mRoles.Add(eRole.Durable)
    bundleSlardar.mRoles.Add(eRole.Disabler)
    bundleSlardar.mRoles.Add(eRole.Initiator)

    bundleSlardar.mPrimaryStat = ePrimaryStat.Strength

    bundleSlardar.mBio = "Slardar is a Slithereen, one of the Deep Ones, guardian of the great wealth of sunken cities and the ancient riches buried there. In the lightless gulf of the great ocean abysses, the Slithereen Guard carries his lure-light with him through the secret treasure rooms. Subaqueous thieves (sent into the deeps by covetous dryland sorcerers) are drawn in by its friendly glow, never to return. He is utterly loyal, and his taciturn nature hides deep knowledge of the most secret places of the sea. He rises to the shallows in spite of the pain caused him by brightness, to commit reconnaissance, to make sure no one is conspiring against the depths, and sometimes in relentless pursuit of the rare few who manage to steal off with an item from the Sunken Treasury. Because he has spent his whole life at great pressure, under tremendous weight of the sea, Slardar the Slithereen Guard is a creature of great power. "

    bundleSlardar.mBaseStr = 21
    bundleSlardar.mStrIncrement = 2.8

    bundleSlardar.mBaseInt = 15
    bundleSlardar.mIntIncrement = 1.5

    bundleSlardar.mBaseAgi = 17
    bundleSlardar.mAgiIncrement = 2.4


    bundleSlardar.mBaseMoveSpeed = 300
    bundleSlardar.mBaseArmor = 3


    bundleSlardar.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleSlardar.mName, bundleSlardar)



    '----------------------------------------------------------
    '-TIDEHUNTER START-----------------------------
    '----------------------------------------------------------
    Dim bundleTidehunter As New HeroBundle
    'FROM UNITBASE
    bundleTidehunter.mIDItem = New dvID(New Guid("acfd5634-37e2-45f4-8e6a-79a8f46ee4f6"), "Herobundle: Tidehunter", eEntity.Herobundle)
    bundleTidehunter.mName = eHeroName.untTidehunter
    bundleTidehunter.DisplayName = "Tidehunter"
    bundleTidehunter.mArmorType = eArmorType.Hero
    bundleTidehunter.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/tidehunter_vert.jpg"
    bundleTidehunter.mWebpageLink = "http://www.dota2.com/hero/Tidehunter/"

    bundleTidehunter.mAttackType = eAttackType.Melee
    bundleTidehunter.mBaseHitpoints = 0
    bundleTidehunter.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleTidehunter.mBaseAttackDamage = New ValueWrapper(25, 31)

    bundleTidehunter.mDaySightRange = 1800
    bundleTidehunter.mNightSightRange = 800

    bundleTidehunter.mAttackRange = 128
    bundleTidehunter.mMissileSpeed = Nothing

    bundleTidehunter.mAbilityNames.Add(eAbilityName.abGush)
    bundleTidehunter.mAbilityNames.Add(eAbilityName.abKraken_Shell)
    bundleTidehunter.mAbilityNames.Add(eAbilityName.abAnchor_Smash)


    bundleTidehunter.mAbilityNames.Add(eAbilityName.abRavage)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleTidehunter.mDevName = "Tidehunter"

    bundleTidehunter.mRoles.Add(eRole.Initiator)
    bundleTidehunter.mRoles.Add(eRole.Durable)
    bundleTidehunter.mRoles.Add(eRole.Disabler)
    bundleTidehunter.mRoles.Add(eRole.Support)

    bundleTidehunter.mPrimaryStat = ePrimaryStat.Strength

    bundleTidehunter.mBio = "The Tidehunter known as Leviathan was once the champion of the Sunken Isles, but his motives are as mysterious as those of his people. We all know the importance of the Drylanders' shipping lanes, how empires may rise and fall according to who controls the open water. Far less is known of the submarine lanes, and how the warring tribes of the Meranthic Diaspora have carved out habitations through endless undersea skirmishes. In the fragile treaties between the Mer and Men, we can glimpse the extent of the drowned empires, but their politics appear complex and opaque. It would seem that Leviathan tired of such petty strife, and set off on his own, loyal only to his abyssal god, Maelrawn the Tentacular. He stalks the shallows now in search of men or meranths who stray into his path, and with a particular loathing for Admiral Kunkka, who has long been his nemesis for reasons lost in the deepest trenches of the sea. "

    bundleTidehunter.mBaseStr = 22
    bundleTidehunter.mStrIncrement = 3

    bundleTidehunter.mBaseInt = 16
    bundleTidehunter.mIntIncrement = 1.7

    bundleTidehunter.mBaseAgi = 15
    bundleTidehunter.mAgiIncrement = 1.5


    bundleTidehunter.mBaseMoveSpeed = 310
    bundleTidehunter.mBaseArmor = 1


    bundleTidehunter.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleTidehunter.mName, bundleTidehunter)



    '----------------------------------------------------------
    '-WRAITH KING START-----------------------------
    '----------------------------------------------------------
    Dim bundleWraith_King As New HeroBundle
    'FROM UNITBASE
    bundleWraith_King.mIDItem = New dvID(New Guid("c4f5b6dd-9868-407d-850b-a507694739ba"), "Herobundle: Wraith King", eEntity.Herobundle)
    bundleWraith_King.mName = eHeroName.untWraith_King
    bundleWraith_King.DisplayName = "Wraith King"
    bundleWraith_King.mArmorType = eArmorType.Hero
    bundleWraith_King.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/skeleton_king_vert.jpg"
    bundleWraith_King.mWebpageLink = "http://www.dota2.com/hero/Wraith_King/"

    bundleWraith_King.mAttackType = eAttackType.Melee
    bundleWraith_King.mBaseHitpoints = 0
    bundleWraith_King.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleWraith_King.mBaseAttackDamage = New ValueWrapper(32, 34)

    bundleWraith_King.mDaySightRange = 1800
    bundleWraith_King.mNightSightRange = 800

    bundleWraith_King.mAttackRange = 128
    bundleWraith_King.mMissileSpeed = Nothing

    bundleWraith_King.mAbilityNames.Add(eAbilityName.abWraithfire_Blast)
    bundleWraith_King.mAbilityNames.Add(eAbilityName.abVampiric_Aura)
    bundleWraith_King.mAbilityNames.Add(eAbilityName.abMortal_Strike)
    bundleWraith_King.mAbilityNames.Add(eAbilityName.abReincarnation)




    'FROM HEROBASE
    'Fixed, immutable stats
    bundleWraith_King.mDevName = "Wraith_King"

    bundleWraith_King.mRoles.Add(eRole.Durable)
    bundleWraith_King.mRoles.Add(eRole.Carry)
    bundleWraith_King.mRoles.Add(eRole.Disabler)

    bundleWraith_King.mPrimaryStat = ePrimaryStat.Strength

    bundleWraith_King.mBio = "For untold years, King Ostarion built a kingdom from the remains of his enemies. It was an obsessive's errand, done to pass the long eternities of a monarchy that seemed fated never to end. He believed that as long as he built up the towers of his palace, he could not die. But eventually he learned that he had been deluded...that bone itself could perish. Deeply mistrustful of flesh, he sought a more permanent way of extending his reign, and at last settled on pursuit of wraith energy, a form of pure spirit given off by certain dark souls at death. Should he infuse himself with Wraith Essence, he thought he might create a body as luminous and eternal as his ego. On the millennial solstice known as Wraith-Night, he submitted to a rite of transformation, compelling his subjects to harvest enough souls to fuel his ambition for immortality. No one knows how many of his champions died, for the only survivor who mattered was the Wraith King who rose with the sun on the following morn. Now he rarely spends a moment on his glowing throne--but strides out with sword drawn, demanding a fealty that extends far beyond death. "

    bundleWraith_King.mBaseStr = 22
    bundleWraith_King.mStrIncrement = 2.9

    bundleWraith_King.mBaseInt = 18
    bundleWraith_King.mIntIncrement = 1.6

    bundleWraith_King.mBaseAgi = 18
    bundleWraith_King.mAgiIncrement = 1.7


    bundleWraith_King.mBaseMoveSpeed = 300
    bundleWraith_King.mBaseArmor = 0


    bundleWraith_King.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleWraith_King.mName, bundleWraith_King)



    '----------------------------------------------------------
    '-LIFESTEALER START-----------------------------
    '----------------------------------------------------------
    Dim bundleLifestealer As New HeroBundle
    'FROM UNITBASE
    bundleLifestealer.mIDItem = New dvID(New Guid("a784467e-a0e8-43a9-9ab0-bc7a7543e1e7"), "Herobundle: Lifestealer", eEntity.Herobundle)
    bundleLifestealer.mName = eHeroName.untLifestealer
    bundleLifestealer.DisplayName = "Lifestealer"
    bundleLifestealer.mArmorType = eArmorType.Hero
    bundleLifestealer.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/life_stealer_vert.jpg"
    bundleLifestealer.mWebpageLink = "http://www.dota2.com/hero/Lifestealer/"

    bundleLifestealer.mAttackType = eAttackType.Melee
    bundleLifestealer.mBaseHitpoints = 0
    bundleLifestealer.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleLifestealer.mBaseAttackDamage = New ValueWrapper(32, 42)

    bundleLifestealer.mDaySightRange = 1800
    bundleLifestealer.mNightSightRange = 800

    bundleLifestealer.mAttackRange = 128
    bundleLifestealer.mMissileSpeed = Nothing

    bundleLifestealer.mAbilityNames.Add(eAbilityName.abRage)
    bundleLifestealer.mAbilityNames.Add(eAbilityName.abFeast)
    bundleLifestealer.mAbilityNames.Add(eAbilityName.abOpen_Wounds)
    bundleLifestealer.mAbilityNames.Add(eAbilityName.abInfest)
    'bundleLifestealer.mAbilityNames.Add(eAbilityName.abConsume)






    'FROM HEROBASE
    'Fixed, immutable stats
    bundleLifestealer.mDevName = "Lifestealer"

    bundleLifestealer.mRoles.Add(eRole.Carry)
    bundleLifestealer.mRoles.Add(eRole.Durable)
    bundleLifestealer.mRoles.Add(eRole.Jungler)
    bundleLifestealer.mRoles.Add(eRole.Escape)

    bundleLifestealer.mPrimaryStat = ePrimaryStat.Strength

    bundleLifestealer.mBio = "In the dungeons of Devarque, a vengeful wizard lay in shackles, plotting his escape. He shared his cell with a gibbering creature known as N'aix, a thief cursed by the Vile Council with longevity, so that its life-sentence for theft and cozening might be as punishing as possible. Over the years, its chains had corroded, along with its sanity; N'aix retained no memory of its former life and no longer dreamt of escape. Seeing a perfect vessel for his plans, the wizard wove a spell of Infestation and cast his life-force into N'aix's body, intending to compel N'aix to sacrifice itself in a frenzy of violence while the mage returned to his body and crept away unnoticed. Instead, the wizard found his mind caught in a vortex of madness so powerful that it swept away his plans and shattered his will. Jarred to consciousness by the sudden infusion of fresh life, N'aix woke from its nightmare of madness and obeyed the disembodied voice that filled its skull, which had only the one thought: To escape. In that moment Lifestealer was born. The creature cast its mind into dungeon guards and soldiers, compelling them to open locks and cut down their companions, opening an unobstructed path to freedom while feeding on their lives. Lifestealer still wears the broken shackles as a warning that none may hold him, but on the inside remains a prisoner. Two minds inhabit the single form--a nameless creature of malevolent cunning, and the Master whose voice he pretends to obey. "

    bundleLifestealer.mBaseStr = 25
    bundleLifestealer.mStrIncrement = 2.4

    bundleLifestealer.mBaseInt = 15
    bundleLifestealer.mIntIncrement = 1.75

    bundleLifestealer.mBaseAgi = 18
    bundleLifestealer.mAgiIncrement = 1.9


    bundleLifestealer.mBaseMoveSpeed = 315

    bundleLifestealer.mBaseArmor = -1

    bundleLifestealer.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleLifestealer.mName, bundleLifestealer)



    '----------------------------------------------------------
    '-NIGHT STALKER START-----------------------------
    '----------------------------------------------------------
    Dim bundleNight_Stalker As New HeroBundle
    'FROM UNITBASE
    bundleNight_Stalker.mIDItem = New dvID(New Guid("fe033f42-ad01-4139-9455-9a4c50813586"), "Herobundle: Night Stalker", eEntity.Herobundle)
    bundleNight_Stalker.mName = eHeroName.untNight_Stalker
    bundleNight_Stalker.DisplayName = "Night Stalker"
    bundleNight_Stalker.mArmorType = eArmorType.Hero
    bundleNight_Stalker.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/night_stalker_vert.jpg"
    bundleNight_Stalker.mWebpageLink = "http://www.dota2.com/hero/Night_Stalker/"

    bundleNight_Stalker.mAttackType = eAttackType.Melee
    bundleNight_Stalker.mBaseHitpoints = 0
    bundleNight_Stalker.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleNight_Stalker.mBaseAttackDamage = New ValueWrapper(38, 42)

    bundleNight_Stalker.mDaySightRange = 1200
    bundleNight_Stalker.mNightSightRange = 1800

    bundleNight_Stalker.mAttackRange = 128
    bundleNight_Stalker.mMissileSpeed = Nothing

    bundleNight_Stalker.mAbilityNames.Add(eAbilityName.abVoid)
    bundleNight_Stalker.mAbilityNames.Add(eAbilityName.abCrippling_Fear)

    bundleNight_Stalker.mAbilityNames.Add(eAbilityName.abHunter_In_The_Night)
    bundleNight_Stalker.mAbilityNames.Add(eAbilityName.abDarkness)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleNight_Stalker.mDevName = "Night_Stalker"

    bundleNight_Stalker.mRoles.Add(eRole.Durable)
    bundleNight_Stalker.mRoles.Add(eRole.Initiator)

    bundleNight_Stalker.mPrimaryStat = ePrimaryStat.Strength

    bundleNight_Stalker.mBio = "Of the Night Stalker, there is no history, only stories. There are ancient tales woven into the lore of every race and every culture, of an impossible time before sunlight and daytime, when night reigned alone and the world was covered with the creatures of darkness-creatures like Balanar the Night Stalker.|It is said that on the dawn of the First Day, all the night creatures perished. All, that is, save one. Evil's embodiment, Night Stalker delights in his malevolence. He created the primal role of the Night Terror, the Boogeyman, and as long as there have been younglings, his is the specter summoned to terrify them. This is a role he relishes-nor are these empty theatrics. He does indeed stalk the unwary, the defenseless, those who have strayed beyond the lighted paths or denied the warnings of their communities. Night Stalker serves as living proof that every child's worst nightmare....is true. "

    bundleNight_Stalker.mBaseStr = 23
    bundleNight_Stalker.mStrIncrement = 2.8

    bundleNight_Stalker.mBaseInt = 16
    bundleNight_Stalker.mIntIncrement = 1.6

    bundleNight_Stalker.mBaseAgi = 18
    bundleNight_Stalker.mAgiIncrement = 2.25


    bundleNight_Stalker.mBaseMoveSpeed = 295
    bundleNight_Stalker.mBaseArmor = 3



    bundleNight_Stalker.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleNight_Stalker.mName, bundleNight_Stalker)



    '----------------------------------------------------------
    '-DOOM START-----------------------------
    '----------------------------------------------------------
    Dim bundleDoom As New HeroBundle
    'FROM UNITBASE
    bundleDoom.mIDItem = New dvID(New Guid("9cbd9b7b-fd4f-49ca-a724-a56d6eacc7c8"), "Herobundle: Doom", eEntity.Herobundle)
    bundleDoom.mName = eHeroName.untDoom
    bundleDoom.DisplayName = "Doom"
    bundleDoom.mArmorType = eArmorType.Hero
    bundleDoom.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/doom_bringer_vert.jpg"
    bundleDoom.mWebpageLink = "http://www.dota2.com/hero/Doom/"

    bundleDoom.mAttackType = eAttackType.Melee
    bundleDoom.mBaseHitpoints = 0
    bundleDoom.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleDoom.mBaseAttackDamage = New ValueWrapper(27, 33)

    bundleDoom.mDaySightRange = 1800
    bundleDoom.mNightSightRange = 800

    bundleDoom.mAttackRange = 150
    bundleDoom.mMissileSpeed = Nothing


    bundleDoom.mAbilityNames.Add(eAbilityName.abDevour)
    bundleDoom.mAbilityNames.Add(eAbilityName.abScorched_Earth)

    bundleDoom.mAbilityNames.Add(eAbilityName.abLvl_Death)
    bundleDoom.mAbilityNames.Add(eAbilityName.abDoom)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleDoom.mDevName = "Doom"

    bundleDoom.mRoles.Add(eRole.Durable)
    bundleDoom.mRoles.Add(eRole.Carry)
    bundleDoom.mRoles.Add(eRole.Nuker)

    bundleDoom.mPrimaryStat = ePrimaryStat.Strength

    bundleDoom.mBio = "He that burns and is not consumed, devours and is never sated, kills and is beyond all judgment--Lucifer brings doom to all who would stand against him. Bearing away souls on the tip of a fiery sword, he is the Fallen One, a once-favored general from the realm behind the light, cast out for the sin of defiance: he would not kneel.|Six times his name was tolled from the great bell of Vashundol. Six and sixty times his wings were branded, until only smoking stumps remained. Without wings, he slipped loose from the tethers that bound him within the light and he fell screaming to earth. A crater in the desert, Paradise lost. Now he attacks without mercy, without motive, the only living being able to move freely between the seven dark dominions. Lashed by inescapable needs, twisted by unimaginable talents, Doom carries his own hell with him wherever he goes. Defiant to the last. Eventually, the world will belong to Doom. "

    bundleDoom.mBaseStr = 26
    bundleDoom.mStrIncrement = 3.2

    bundleDoom.mBaseInt = 13
    bundleDoom.mIntIncrement = 2.1

    bundleDoom.mBaseAgi = 11
    bundleDoom.mAgiIncrement = 0.9


    bundleDoom.mBaseMoveSpeed = 290

    bundleDoom.mBaseArmor = -1

    bundleDoom.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleDoom.mName, bundleDoom)



    '----------------------------------------------------------
    '-SPIRIT BREAKER START-----------------------------
    '----------------------------------------------------------
    Dim bundleSpirit_Breaker As New HeroBundle
    'FROM UNITBASE
    bundleSpirit_Breaker.mIDItem = New dvID(New Guid("c8542fe5-66bc-4d2c-a64c-7e09499c6ae9"), "Herobundle: Spirit Breaker", eEntity.Herobundle)
    bundleSpirit_Breaker.mName = eHeroName.untSpirit_Breaker
    bundleSpirit_Breaker.DisplayName = "Spirit Breaker"
    bundleSpirit_Breaker.mArmorType = eArmorType.Hero
    bundleSpirit_Breaker.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/spirit_breaker_vert.jpg"
    bundleSpirit_Breaker.mWebpageLink = "http://www.dota2.com/hero/Spirit_Breaker/"

    bundleSpirit_Breaker.mAttackType = eAttackType.Melee
    bundleSpirit_Breaker.mBaseHitpoints = 0
    bundleSpirit_Breaker.mBaseAttackSpeed = 1.9 '  http://dota2.gamepedia.com/Attack_speed

    bundleSpirit_Breaker.mBaseAttackDamage = New ValueWrapper(31, 41)

    bundleSpirit_Breaker.mDaySightRange = 1800
    bundleSpirit_Breaker.mNightSightRange = 800

    bundleSpirit_Breaker.mAttackRange = 128
    bundleSpirit_Breaker.mMissileSpeed = Nothing


    bundleSpirit_Breaker.mAbilityNames.Add(eAbilityName.abCharge_Of_Darkness)
    bundleSpirit_Breaker.mAbilityNames.Add(eAbilityName.abEmpowering_Haste)
    bundleSpirit_Breaker.mAbilityNames.Add(eAbilityName.abGreater_Bash)
    bundleSpirit_Breaker.mAbilityNames.Add(eAbilityName.abNether_Strike)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleSpirit_Breaker.mDevName = "Spirit_Breaker"

    bundleSpirit_Breaker.mRoles.Add(eRole.Durable)
    bundleSpirit_Breaker.mRoles.Add(eRole.Carry)
    bundleSpirit_Breaker.mRoles.Add(eRole.Initiator)
    bundleSpirit_Breaker.mRoles.Add(eRole.Disabler)

    bundleSpirit_Breaker.mPrimaryStat = ePrimaryStat.Strength

    bundleSpirit_Breaker.mBio = "Barathrum the Spirit Breaker is a lordly and powerful being, a fierce and elemental intelligence which chose to plane-shift into the world of matter to take part in events with repercussions in the elemental realm that is his home. To that end, he assembled a form that would serve him well, both in our world and out of it. His physical form borrows from the strengths of this world, blending features both bovine and simian--horns, hooves and hands-as outward emblems of his inner qualities of strength, speed and cunning. He wears a ring in his nose, as a reminder that he serves a hidden master, and that this world in which he works is but a shadow of the real one. "

    bundleSpirit_Breaker.mBaseStr = 29
    bundleSpirit_Breaker.mStrIncrement = 2.4

    bundleSpirit_Breaker.mBaseInt = 14
    bundleSpirit_Breaker.mIntIncrement = 1.8

    bundleSpirit_Breaker.mBaseAgi = 17
    bundleSpirit_Breaker.mAgiIncrement = 1.7


    bundleSpirit_Breaker.mBaseMoveSpeed = 290
    bundleSpirit_Breaker.mBaseArmor = 3


    bundleSpirit_Breaker.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleSpirit_Breaker.mName, bundleSpirit_Breaker)



    '----------------------------------------------------------
    '-LYCAN START-----------------------------
    '----------------------------------------------------------
    Dim bundleLycan As New HeroBundle
    'FROM UNITBASE
    bundleLycan.mIDItem = New dvID(New Guid("60c65b80-76c0-4b76-9550-cb093989006f"), "Herobundle: Lycan", eEntity.Herobundle)
    bundleLycan.mName = eHeroName.untLycan
    bundleLycan.DisplayName = "Lycan"
    bundleLycan.mArmorType = eArmorType.Hero
    bundleLycan.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/lycan_vert.jpg"
    bundleLycan.mWebpageLink = "http://www.dota2.com/hero/Lycan/"

    bundleLycan.mAttackType = eAttackType.Melee
    bundleLycan.mBaseHitpoints = 0
    bundleLycan.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleLycan.mBaseAttackDamage = New ValueWrapper(36, 41)

    bundleLycan.mDaySightRange = 1800
    bundleLycan.mNightSightRange = 800

    bundleLycan.mAttackRange = 128
    bundleLycan.mMissileSpeed = Nothing

    bundleLycan.mAbilityNames.Add(eAbilityName.abSummon_Wolves)
    bundleLycan.mAbilityNames.Add(eAbilityName.abHowl)
    bundleLycan.mAbilityNames.Add(eAbilityName.abFeral_Impulse)

    bundleLycan.mAbilityNames.Add(eAbilityName.abShapeshift)



    'FROM HEROBASE
    'Fixed, immutable stats
    bundleLycan.mDevName = "Lycan"

    bundleLycan.mRoles.Add(eRole.Carry)
    bundleLycan.mRoles.Add(eRole.Jungler)
    bundleLycan.mRoles.Add(eRole.Pusher)
    bundleLycan.mRoles.Add(eRole.Durable)

    bundleLycan.mPrimaryStat = ePrimaryStat.Strength

    bundleLycan.mBio = "Banehallow was noble-born to the house of Ambry, the greatest of the landed castes in the old kingdom of Slom. Before the Fall, as the King's wants grew strange, and his court grew crowded with sorcerers and charlatans, the house of Ambry was the first to rise against the avarice of the throne. No longer willing to pay homage and fealty, they instead sent six-thousand swords into the capital, where they were wiped out in the Massacre of the Apostates. And then came the teeth behind the old truth: When you strike a king's neck, you had better take his head. Enraged by the betrayal, the king exterminated the vast Ambry bloodline, sparing only the lord of the house and his youngest son, Banehallow. Before all the royal court, with the disgraced lord chained to the ornate marble floor, the King bade his magicians transform the boy into a wolf so that he might tear out his own father's throat. """"Do this,"""" the king said, """"so that Lord Ambry will understand the bite of betrayal."""" Powerful magic was invoked, and the child was transformed. But though his body was changed, his spirit remained intact, and instead of biting the exposed neck of his father, he attacked his handlers, tearing them to pieces. A dozen of the King's knights perished under the wolf's teeth before they managed to drive it off into the night. Lord Ambry laughed from his chains even as the King ran him through with a sword. Now the heir to the lost house of Ambry, Banehallow wanders the trail as the Lycan, part warrior, part wolf, in search of justice for all that he lost. "

    bundleLycan.mBaseStr = 22
    bundleLycan.mStrIncrement = 2.75

    bundleLycan.mBaseInt = 17
    bundleLycan.mIntIncrement = 1.55

    bundleLycan.mBaseAgi = 16
    bundleLycan.mAgiIncrement = 1.9


    bundleLycan.mBaseMoveSpeed = 305
    bundleLycan.mBaseArmor = 1


    bundleLycan.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleLycan.mName, bundleLycan)



    '----------------------------------------------------------
    '-CHAOS KNIGHT START-----------------------------
    '----------------------------------------------------------
    Dim bundleChaos_Knight As New HeroBundle
    'FROM UNITBASE
    bundleChaos_Knight.mIDItem = New dvID(New Guid("394d6563-405b-40e7-91ad-b090eccbea3a"), "Herobundle: Chaos Knight", eEntity.Herobundle)
    bundleChaos_Knight.mName = eHeroName.untChaos_Knight
    bundleChaos_Knight.DisplayName = "Chaos Knight"
    bundleChaos_Knight.mArmorType = eArmorType.Hero
    bundleChaos_Knight.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/chaos_knight_vert.jpg"
    bundleChaos_Knight.mWebpageLink = "http://www.dota2.com/hero/Chaos_Knight/"

    bundleChaos_Knight.mAttackType = eAttackType.Melee
    bundleChaos_Knight.mBaseHitpoints = 0
    bundleChaos_Knight.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleChaos_Knight.mBaseAttackDamage = New ValueWrapper(29, 59)

    bundleChaos_Knight.mDaySightRange = 1800
    bundleChaos_Knight.mNightSightRange = 800

    bundleChaos_Knight.mAttackRange = 128
    bundleChaos_Knight.mMissileSpeed = Nothing


    bundleChaos_Knight.mAbilityNames.Add(eAbilityName.abChaos_Bolt)
    bundleChaos_Knight.mAbilityNames.Add(eAbilityName.abReality_Rift)
    bundleChaos_Knight.mAbilityNames.Add(eAbilityName.abChaos_Strike)
    bundleChaos_Knight.mAbilityNames.Add(eAbilityName.abPhantasm)



    'FROM HEROBASE
    'Fixed, immutable stats
    bundleChaos_Knight.mDevName = "Chaos_Knight"

    bundleChaos_Knight.mRoles.Add(eRole.Carry)
    bundleChaos_Knight.mRoles.Add(eRole.Disabler)
    bundleChaos_Knight.mRoles.Add(eRole.Durable)
    bundleChaos_Knight.mRoles.Add(eRole.Pusher)

    bundleChaos_Knight.mPrimaryStat = ePrimaryStat.Strength

    bundleChaos_Knight.mBio = "The veteran of countless battles on a thousand worlds, Chaos Knight hails from a far upstream plane where the fundamental laws of the universe have found sentient expression. Of all the ancient Fundamentals, he is the oldest and most tireless, endlessly searching out a being he knows only as """"The Light."""" Long ago the Light ventured out from the progenitor realm, in defiance of the first covenant. Now Chaos Knight shifts from plane to plane, always on the hunt to extinguish the Light wherever he finds it. A thousand times he has snuffed out the source, and always he slides into another plane to continue his search anew.|Upon his steed Armageddon he rides, wading into battle with maniacal frenzy, drawing strength from the disorder of the universe. A physical manifestation of chaos itself, in times of need he calls upon other versions of himself from other planes, and together these dark horsemen ride into battle, as unstoppable as any force of nature. Only when the last Light of the world is scoured from existence will the search be ended. Where rides the Chaos Knight, death soon follows. "

    bundleChaos_Knight.mBaseStr = 20
    bundleChaos_Knight.mStrIncrement = 2.9

    bundleChaos_Knight.mBaseInt = 16
    bundleChaos_Knight.mIntIncrement = 1.2

    bundleChaos_Knight.mBaseAgi = 14
    bundleChaos_Knight.mAgiIncrement = 2.1


    bundleChaos_Knight.mBaseMoveSpeed = 325
    bundleChaos_Knight.mBaseArmor = 2


    bundleChaos_Knight.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleChaos_Knight.mName, bundleChaos_Knight)



    '----------------------------------------------------------
    '-UNDYING START-----------------------------
    '----------------------------------------------------------
    Dim bundleUndying As New HeroBundle
    'FROM UNITBASE
    bundleUndying.mIDItem = New dvID(New Guid("db2b1806-a579-4911-8ad0-c9058a927819"), "Herobundle: Undying", eEntity.Herobundle)
    bundleUndying.mName = eHeroName.untUndying
    bundleUndying.DisplayName = "Undying"
    bundleUndying.mArmorType = eArmorType.Hero
    bundleUndying.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/undying_vert.jpg"
    bundleUndying.mWebpageLink = "http://www.dota2.com/hero/Undying/"

    bundleUndying.mAttackType = eAttackType.Melee
    bundleUndying.mBaseHitpoints = 0
    bundleUndying.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleUndying.mBaseAttackDamage = New ValueWrapper(35, 43)

    bundleUndying.mDaySightRange = 1800
    bundleUndying.mNightSightRange = 800

    bundleUndying.mAttackRange = 128
    bundleUndying.mMissileSpeed = Nothing


    bundleUndying.mAbilityNames.Add(eAbilityName.abDecay)
    bundleUndying.mAbilityNames.Add(eAbilityName.abSoul_Rip)
    bundleUndying.mAbilityNames.Add(eAbilityName.abTombstone)
    bundleUndying.mAbilityNames.Add(eAbilityName.abFlesh_Golem)




    'FROM HEROBASE
    'Fixed, immutable stats
    bundleUndying.mDevName = "Undying"

    bundleUndying.mRoles.Add(eRole.Durable)
    bundleUndying.mRoles.Add(eRole.Pusher)
    bundleUndying.mRoles.Add(eRole.Disabler)
    bundleUndying.mRoles.Add(eRole.Initiator)

    bundleUndying.mPrimaryStat = ePrimaryStat.Strength

    bundleUndying.mBio = "How long has it been since he lost his name? The torn ruin of his mind no longer knows.|Dimly he recalls armor and banners and grim-faced kin riding at his side. He remembers a battle: pain and fear as pale hands ripped him from his saddle. He remembers terror as they threw him into the yawning pit of the Dead God alongside his brothers, to hear the Dirge and be consumed into nothingness. In the darkness below, time left them. Thought left them. Sanity left them. Hunger, however, did not. They turned on each other with split fingernails and shattered teeth. Then it came: distant at first, a fragile note at the edge of perception, joined by another, then another, inescapable and unending. The chorus grew into a living wall of sound pulsing in his mind until no other thought survived. With the Dirge consuming him, he opened his arms to the Dead God and welcomed his obliteration. Yet destruction was not what he'd been chosen for. The Dead God demanded war. In the belly of the great nothing, he was granted a new purpose: to spread the Dirge across the land, to rally the sleepless dead against the living. He was to become the Undying, the herald of the Dead God, to rise and fall and rise again whenever his body failed him. To trudge on through death unending, that the Dirge might never end. "

    bundleUndying.mBaseStr = 22
    bundleUndying.mStrIncrement = 2.1

    bundleUndying.mBaseInt = 27
    bundleUndying.mIntIncrement = 2.5

    bundleUndying.mBaseAgi = 10
    bundleUndying.mAgiIncrement = 0.8


    bundleUndying.mBaseMoveSpeed = 310
    bundleUndying.mBaseArmor = 2


    bundleUndying.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleUndying.mName, bundleUndying)



    '----------------------------------------------------------
    '-MAGNUS START-----------------------------
    '----------------------------------------------------------
    Dim bundleMagnus As New HeroBundle
    'FROM UNITBASE
    bundleMagnus.mIDItem = New dvID(New Guid("fd9a34f1-8fa7-4847-ab94-765e4f439141"), "Herobundle: Magnus", eEntity.Herobundle)
    bundleMagnus.mName = eHeroName.untMagnus
    bundleMagnus.DisplayName = "Magnus"
    bundleMagnus.mArmorType = eArmorType.Hero
    bundleMagnus.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/magnataur_vert.jpg"
    bundleMagnus.mWebpageLink = "http://www.dota2.com/hero/Magnus/"

    bundleMagnus.mAttackType = eAttackType.Melee
    bundleMagnus.mBaseHitpoints = 0
    bundleMagnus.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleMagnus.mBaseAttackDamage = New ValueWrapper(28, 40)

    bundleMagnus.mDaySightRange = 1800
    bundleMagnus.mNightSightRange = 800

    bundleMagnus.mAttackRange = 128
    bundleMagnus.mMissileSpeed = Nothing

    bundleMagnus.mAbilityNames.Add(eAbilityName.abShockwave)
    bundleMagnus.mAbilityNames.Add(eAbilityName.abEmpower)


    bundleMagnus.mAbilityNames.Add(eAbilityName.abSkewer)
    bundleMagnus.mAbilityNames.Add(eAbilityName.abReverse_Polarity)

    'FROM HEROBASE
    'Fixed, immutable stats
    bundleMagnus.mDevName = "Magnus"

    bundleMagnus.mRoles.Add(eRole.Initiator)
    bundleMagnus.mRoles.Add(eRole.Disabler)
    bundleMagnus.mRoles.Add(eRole.Nuker)
    bundleMagnus.mRoles.Add(eRole.Carry)

    bundleMagnus.mPrimaryStat = ePrimaryStat.Strength

    bundleMagnus.mBio = "The master-smiths of Mt. Joerlak agree on only a single point: that the horn of a magnoceros is more precious than any alloy. And of all such horns, the largest and sharpest belongs to the beast they call Magnus. For half a generation, Magnus took easy sport goring hunters come to claim the treasures of his kin. Each time he would return to his cave with hooves and horns stained red, until his Matriarch urged him and all their kin to seek refuge to the north beyond the shadow of the mountain. But Magnus scoffed, having never failed to defend his people. The magnoceroi would stay, he decided, for a magnoceros does not believe in chance... nor does it ever change its mind. But when Mt. Joerlak erupted without warning, and half his kin perished in the fire and ash, Magnus changed his mind after all. The survivors pushed north, until they reached a blockade watched over by a hundred hunters armed with bow and steel. Magnus expected no less. He led his fiercest brothers and sisters in a charge against their enemies, and fought with a ferocity matched only by the fire-spewing mountain at his back. Meanwhile the magnoceros elders, mothers, and calves vanished into the drifts. The master-smiths are divided about what happened next. Some say Magnus reheronameed with his kin, while others claim he suffered mortal injuries and expired alongside the body of his Matriarch. Neither theory is correct. Magnus did vow to rejoin his kin...but only after seeking out those responsible for the eruption of Mt. Joerlak and watching them die upon his horn, for a magnoceros does not believe in chance. "

    bundleMagnus.mBaseStr = 21
    bundleMagnus.mStrIncrement = 2.75

    bundleMagnus.mBaseInt = 19
    bundleMagnus.mIntIncrement = 1.65

    bundleMagnus.mBaseAgi = 15
    bundleMagnus.mAgiIncrement = 2.5


    bundleMagnus.mBaseMoveSpeed = 315
    bundleMagnus.mBaseArmor = 2


    bundleMagnus.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleMagnus.mName, bundleMagnus)



    '----------------------------------------------------------
    '-ABADDON START-----------------------------
    '----------------------------------------------------------
    Dim bundleAbaddon As New HeroBundle
    'FROM UNITBASE
    bundleAbaddon.mIDItem = New dvID(New Guid("9272390f-3ffd-4d31-9fbb-f1825cf6ceaa"), "Herobundle: Abaddon", eEntity.Herobundle)
    bundleAbaddon.mName = eHeroName.untAbaddon
    bundleAbaddon.DisplayName = "Abaddon"
    bundleAbaddon.mArmorType = eArmorType.Hero
    bundleAbaddon.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/abaddon_vert.jpg"
    bundleAbaddon.mWebpageLink = "http://www.dota2.com/hero/Abaddon/"

    bundleAbaddon.mAttackType = eAttackType.Melee
    bundleAbaddon.mBaseHitpoints = 0
    bundleAbaddon.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleAbaddon.mBaseAttackDamage = New ValueWrapper(32, 42)

    bundleAbaddon.mDaySightRange = 1800
    bundleAbaddon.mNightSightRange = 800

    bundleAbaddon.mAttackRange = 128
    bundleAbaddon.mMissileSpeed = Nothing


    bundleAbaddon.mAbilityNames.Add(eAbilityName.abMist_Coil)
    bundleAbaddon.mAbilityNames.Add(eAbilityName.abAphotic_Shield)
    bundleAbaddon.mAbilityNames.Add(eAbilityName.abCurse_Of_Avernus)
    bundleAbaddon.mAbilityNames.Add(eAbilityName.abBorrowed_Time)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleAbaddon.mDevName = "Abaddon"

    bundleAbaddon.mRoles.Add(eRole.Durable)
    bundleAbaddon.mRoles.Add(eRole.Support)
    bundleAbaddon.mRoles.Add(eRole.Carry)

    bundleAbaddon.mPrimaryStat = ePrimaryStat.Strength

    bundleAbaddon.mBio = "The Font of Avernus is the source of a family's strength, a crack in primal stones from which vapors of prophetic power have issued for generations. Each newborn of the cavernous House Avernus is bathed in the black mist, and by this baptism they are given an innate connection to the mystic energies of the land. They grow up believing themselves fierce protectors of their lineal traditions, the customs of the realm--but what they really are protecting is the Font itself. And the motives of the mist are unclear.|When the infant Abaddon was bathed in the Font, they say something went awry. In the child's eyes there flared a light of comprehension that startled all present and set the sacerdotes to whispering. He was raised with every expectation of following the path all scions of Avernus took--to train in war, that in times of need he might lead the family's army in defense of the ancestral lands. But Abaddon was always one apart. Where others trained with weapons, he bent himself to meditation in the presence of the mist. He drank deep from the vapors that welled from the Font, learning to blend his spirit with the potency that flowed from far beneath the House; he became a creature of the black mist.|There was bitterness within the House Avernus--elders and young alike accusing him of neglecting his responsibilities. But all such accusations stopped when Abaddon rode into battle, and they saw how the powers of the mist had given him mastery over life and death beyond those of any lord the House had ever known. "

    bundleAbaddon.mBaseStr = 23
    bundleAbaddon.mStrIncrement = 2.7

    bundleAbaddon.mBaseInt = 21
    bundleAbaddon.mIntIncrement = 2

    bundleAbaddon.mBaseAgi = 17
    bundleAbaddon.mAgiIncrement = 1.5


    bundleAbaddon.mBaseMoveSpeed = 310

    bundleAbaddon.mBaseArmor = -1

    bundleAbaddon.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleAbaddon.mName, bundleAbaddon)



    '----------------------------------------------------------
    '-BLOODSEEKER START-----------------------------
    '----------------------------------------------------------
    Dim bundleBloodseeker As New HeroBundle
    'FROM UNITBASE
    bundleBloodseeker.mIDItem = New dvID(New Guid("17dfeb9d-c874-4da3-a7ca-c7e59951f786"), "Herobundle: BloodSeeker", eEntity.Herobundle)
    bundleBloodseeker.mName = eHeroName.untBloodseeker
    bundleBloodseeker.DisplayName = "Bloodseeker"
    bundleBloodseeker.mArmorType = eArmorType.Hero
    bundleBloodseeker.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/bloodseeker_vert.jpg"
    bundleBloodseeker.mWebpageLink = "http://www.dota2.com/hero/Bloodseeker/"

    bundleBloodseeker.mAttackType = eAttackType.Melee
    bundleBloodseeker.mBaseHitpoints = 0
    bundleBloodseeker.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleBloodseeker.mBaseAttackDamage = New ValueWrapper(29, 35)


    bundleBloodseeker.mDaySightRange = 1800
    bundleBloodseeker.mNightSightRange = 800

    bundleBloodseeker.mAttackRange = 128
    bundleBloodseeker.mMissileSpeed = Nothing

    bundleBloodseeker.mAbilityNames.Add(eAbilityName.abBloodrage)
    bundleBloodseeker.mAbilityNames.Add(eAbilityName.abBlood_Rite)
    bundleBloodseeker.mAbilityNames.Add(eAbilityName.abThirst)
    bundleBloodseeker.mAbilityNames.Add(eAbilityName.abRupture)

    'FROM HEROBASE
    'Fixed, immutable stats
    bundleBloodseeker.mDevName = "Bloodseeker"

    bundleBloodseeker.mRoles.Add(eRole.Carry)
    bundleBloodseeker.mRoles.Add(eRole.Jungler)

    bundleBloodseeker.mPrimaryStat = ePrimaryStat.Agility

    bundleBloodseeker.mBio = "Strygwyr the Bloodseeker is a ritually sanctioned hunter, Hound of the Flayed Twins, sent down from the mist-shrouded peaks of Xhacatocatl in search of blood. The Flayed Ones require oceanic amounts of blood to keep them sated and placated, and would soon drain their mountain empire of its populace if the priests of the high plateaus did not appease them. Strygwyr therefore goes out in search of carnage. The vital energy of any blood he lets, flows immediately to the Twins through the sacred markings on his weapons and armor. Over the years, he has come to embody the energy of a vicious hound; in battle he is savage as a jackal. Beneath the Mask of the Bloodseeker, in the rush of bloody quenching, it is said that you can sometime see the features of the Flayers taking direct possession of their Hound. "

    bundleBloodseeker.mBaseStr = 23
    bundleBloodseeker.mStrIncrement = 2

    bundleBloodseeker.mBaseInt = 18
    bundleBloodseeker.mIntIncrement = 1.7

    bundleBloodseeker.mBaseAgi = 24
    bundleBloodseeker.mAgiIncrement = 3


    bundleBloodseeker.mBaseMoveSpeed = 300

    bundleBloodseeker.mBaseArmor = 0

    bundleBloodseeker.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleBloodseeker.mName, bundleBloodseeker)



    '----------------------------------------------------------
    '-SHADOW FIEND START-----------------------------
    '----------------------------------------------------------
    Dim bundleShadow_Fiend As New HeroBundle
    'FROM UNITBASE
    bundleShadow_Fiend.mIDItem = New dvID(New Guid("d2f26089-d1e7-4403-8971-8e4ef8f6d795"), "Herobundle: Shadow Fiend", eEntity.Herobundle)
    bundleShadow_Fiend.mName = eHeroName.untShadow_Fiend
    bundleShadow_Fiend.DisplayName = "Shadow Fiend"
    bundleShadow_Fiend.mArmorType = eArmorType.Hero
    bundleShadow_Fiend.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/nevermore_vert.jpg"
    bundleShadow_Fiend.mWebpageLink = "http://www.dota2.com/hero/Shadow_Fiend/"

    bundleShadow_Fiend.mAttackType = eAttackType.Ranged
    bundleShadow_Fiend.mBaseHitpoints = 0
    bundleShadow_Fiend.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleShadow_Fiend.mBaseAttackDamage = New ValueWrapper(15, 21)

    bundleShadow_Fiend.mDaySightRange = 1800
    bundleShadow_Fiend.mNightSightRange = 800

    bundleShadow_Fiend.mAttackRange = 500
    bundleShadow_Fiend.mMissileSpeed = 1200

    bundleShadow_Fiend.mAbilityNames.Add(eAbilityName.abShadowraze)
    bundleShadow_Fiend.mAbilityNames.Add(eAbilityName.abNecromastery)
    bundleShadow_Fiend.mAbilityNames.Add(eAbilityName.abPresence_Of_The_Dark_Lord)
    bundleShadow_Fiend.mAbilityNames.Add(eAbilityName.abRequiem_Of_Souls)



    'FROM HEROBASE
    'Fixed, immutable stats
    bundleShadow_Fiend.mDevName = "Shadow_Fiend"

    bundleShadow_Fiend.mRoles.Add(eRole.Carry)
    bundleShadow_Fiend.mRoles.Add(eRole.Nuker)

    bundleShadow_Fiend.mPrimaryStat = ePrimaryStat.Agility

    bundleShadow_Fiend.mBio = "It is said that Nevermore the Shadow Fiend has the soul of a poet, and in fact he has thousands of them. Over the ages he has claimed the souls of poets, priests, emperors, beggars, slaves, philosophers, criminals and (naturally) heroes; no sort of soul escapes him. What he does with them is unknown. No one has ever peered into the Abysm whence Nevermore reaches out like an eel from among astral rocks. Does he devour them one after another? Does he mount them along the halls of an eldritch temple, or pickle the souls in necromantic brine? Is he merely a puppet, pushed through the dimensional rift by a demonic puppeteer? Such is his evil, so intense his aura of darkness, that no rational mind may penetrate it. Of course, if you really want to know where the stolen souls go, there's one sure way to find out: Add your soul to his collection. Or just wait for Nevermore. "

    bundleShadow_Fiend.mBaseStr = 15
    bundleShadow_Fiend.mStrIncrement = 2

    bundleShadow_Fiend.mBaseInt = 18
    bundleShadow_Fiend.mIntIncrement = 2

    bundleShadow_Fiend.mBaseAgi = 20
    bundleShadow_Fiend.mAgiIncrement = 2.9


    bundleShadow_Fiend.mBaseMoveSpeed = 305

    bundleShadow_Fiend.mBaseArmor = -1

    bundleShadow_Fiend.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleShadow_Fiend.mName, bundleShadow_Fiend)



    '----------------------------------------------------------
    '-RAZOR START-----------------------------
    '----------------------------------------------------------
    Dim bundleRazor As New HeroBundle
    'FROM UNITBASE
    bundleRazor.mIDItem = New dvID(New Guid("0371f42a-5167-4251-891e-f09cd3cfd63d"), "Herobundle: Razor", eEntity.Herobundle)
    bundleRazor.mName = eHeroName.untRazor
    bundleRazor.DisplayName = "Razor"
    bundleRazor.mArmorType = eArmorType.Hero
    bundleRazor.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/razor_vert.jpg"
    bundleRazor.mWebpageLink = "http://www.dota2.com/hero/Razor/"

    bundleRazor.mAttackType = eAttackType.Ranged
    bundleRazor.mBaseHitpoints = 0
    bundleRazor.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleRazor.mBaseAttackDamage = New ValueWrapper(23, 25)

    bundleRazor.mDaySightRange = 1800
    bundleRazor.mNightSightRange = 800

    bundleRazor.mAttackRange = 475
    bundleRazor.mMissileSpeed = 2000

    bundleRazor.mAbilityNames.Add(eAbilityName.abPlasma_Field)
    bundleRazor.mAbilityNames.Add(eAbilityName.abStatic_Link)
    bundleRazor.mAbilityNames.Add(eAbilityName.abUnstable_Current)
    bundleRazor.mAbilityNames.Add(eAbilityName.abEye_Of_The_Storm)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleRazor.mDevName = "Razor"

    bundleRazor.mRoles.Add(eRole.Carry)
    bundleRazor.mRoles.Add(eRole.Durable)
    bundleRazor.mRoles.Add(eRole.Nuker)

    bundleRazor.mPrimaryStat = ePrimaryStat.Agility

    bundleRazor.mBio = "Among the emblematic powers that populate the Underscape, Razor the Lightning Revenant is one of the most feared. With his whip of lightning, he patrols the Narrow Maze, that treacherous webwork of passages by which the souls of the dead are sorted according to their own innate intelligence, cunning and persistence. Drifting above the Maze, Razor looks down on the baffled souls below, and delivers jolts of scalding electricity that both punish and quicken the souls as they decide their own fates, hurrying on toward luminous exits or endlessly dark pits. Razor is the eternal embodiment of a dominating power, abstract and almost clinical in his application of power. Yet he has a lordly air that suggests he takes a sardonic satisfaction in his work. "

    bundleRazor.mBaseStr = 21
    bundleRazor.mStrIncrement = 2.3

    bundleRazor.mBaseInt = 19
    bundleRazor.mIntIncrement = 1.8

    bundleRazor.mBaseAgi = 22
    bundleRazor.mAgiIncrement = 2


    bundleRazor.mBaseMoveSpeed = 295

    bundleRazor.mBaseArmor = -1

    bundleRazor.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleRazor.mName, bundleRazor)



    '----------------------------------------------------------
    '-VENOMANCER START-----------------------------
    '----------------------------------------------------------
    Dim bundleVenomancer As New HeroBundle
    'FROM UNITBASE
    bundleVenomancer.mIDItem = New dvID(New Guid("79e1bfef-0fd8-4c33-8f94-3fad5a9ac8c3"), "Herobundle: Venomancer", eEntity.Herobundle)
    bundleVenomancer.mName = eHeroName.untVenomancer
    bundleVenomancer.DisplayName = "Venomancer"
    bundleVenomancer.mArmorType = eArmorType.Hero
    bundleVenomancer.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/venomancer_vert.jpg"
    bundleVenomancer.mWebpageLink = "http://www.dota2.com/hero/Venomancer/"

    bundleVenomancer.mAttackType = eAttackType.Ranged
    bundleVenomancer.mBaseHitpoints = 0
    bundleVenomancer.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleVenomancer.mBaseAttackDamage = New ValueWrapper(19, 21)

    bundleVenomancer.mDaySightRange = 1800
    bundleVenomancer.mNightSightRange = 800

    bundleVenomancer.mAttackRange = 450
    bundleVenomancer.mMissileSpeed = 900

    bundleVenomancer.mAbilityNames.Add(eAbilityName.abVenomous_Gale)
    bundleVenomancer.mAbilityNames.Add(eAbilityName.abPoison_Sting)
    bundleVenomancer.mAbilityNames.Add(eAbilityName.abPlague_Ward)
    bundleVenomancer.mAbilityNames.Add(eAbilityName.abPoison_Nova)




    'FROM HEROBASE
    'Fixed, immutable stats
    bundleVenomancer.mDevName = "Venomancer"

    bundleVenomancer.mRoles.Add(eRole.Support)
    bundleVenomancer.mRoles.Add(eRole.Nuker)
    bundleVenomancer.mRoles.Add(eRole.Initiator)
    bundleVenomancer.mRoles.Add(eRole.Pusher)

    bundleVenomancer.mPrimaryStat = ePrimaryStat.Agility

    bundleVenomancer.mBio = "In the Acid Jungles of Jidi Isle, poison runs in the veins and bubbles in the guts of every creature that scuttles, climbs or swoops between fluorescent vines dripping with caustic sap. Yet even in this toxic menagerie, Venomancer is acknowledged as the most venomous. Ages ago, an Herbalist named Lesale crossed the Bay of Fradj by coracle, searching for potent essences that might be extracted from bark and root, and found instead a nightmare transformation. Two leagues into Jidi's jungle, Lesale encountered a reptile camouflaged as an epiphyte, which stung him as he mistakenly plucked it. In desperation, he used his partial knowledge of the jungle's herbal bounty, mixing the venom of the (swiftly throttled) reptile with the nectar of an armored orchid, to compound an antidote. In the moments before a black paralysis claimed him completely, he injected himself by orchid-thorn, and instantly fell into a coma. Seventeen years later, something stirred in the spot where he had fallen, throwing off the years' accumulation of humus: Venomancer. Lesale the Herbalist no longer-but Lesale the Deathbringer. His mind was all but erased, and his flesh had been consumed and replaced by a new type of matter-one fusing the venom of the reptile with the poisonous integument of the orchid. Jidi's Acid Jungles knew a new master, one before whom even the most vicious predators soon learned to bow or burrow for their lives. The lurid isle proved too confining, and some human hunger deep in the heart of the Venomancer drove Lesale out in search of new poisons-and new deaths to bring. "

    bundleVenomancer.mBaseStr = 18
    bundleVenomancer.mStrIncrement = 1.85

    bundleVenomancer.mBaseInt = 15
    bundleVenomancer.mIntIncrement = 1.75

    bundleVenomancer.mBaseAgi = 22
    bundleVenomancer.mAgiIncrement = 2.6


    bundleVenomancer.mBaseMoveSpeed = 285
    bundleVenomancer.mBaseArmor = 0


    bundleVenomancer.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleVenomancer.mName, bundleVenomancer)



    '----------------------------------------------------------
    '-FACELESS VOID START-----------------------------
    '----------------------------------------------------------
    Dim bundleFaceless_Void As New HeroBundle
    'FROM UNITBASE
    bundleFaceless_Void.mIDItem = New dvID(New Guid("78d56e62-fb9e-4d2c-8c96-8fb0cde882ea"), "Herobundle: Faceless Void", eEntity.Herobundle)
    bundleFaceless_Void.mName = eHeroName.untFaceless_Void
    bundleFaceless_Void.DisplayName = "Faceless Void"
    bundleFaceless_Void.mArmorType = eArmorType.Hero
    bundleFaceless_Void.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/faceless_void_vert.jpg"
    bundleFaceless_Void.mWebpageLink = "http://www.dota2.com/hero/Faceless_Void/"

    bundleFaceless_Void.mAttackType = eAttackType.Melee
    bundleFaceless_Void.mBaseHitpoints = 0
    bundleFaceless_Void.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleFaceless_Void.mBaseAttackDamage = New ValueWrapper(37, 43)

    bundleFaceless_Void.mDaySightRange = 1800
    bundleFaceless_Void.mNightSightRange = 800

    bundleFaceless_Void.mAttackRange = 128
    bundleFaceless_Void.mMissileSpeed = Nothing

    bundleFaceless_Void.mAbilityNames.Add(eAbilityName.abTime_Walk)
    bundleFaceless_Void.mAbilityNames.Add(eAbilityName.abBacktrack)
    bundleFaceless_Void.mAbilityNames.Add(eAbilityName.abTime_Lock)
    bundleFaceless_Void.mAbilityNames.Add(eAbilityName.abChronosphere)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleFaceless_Void.mDevName = "Faceless_Void"

    bundleFaceless_Void.mRoles.Add(eRole.Carry)
    bundleFaceless_Void.mRoles.Add(eRole.Initiator)
    bundleFaceless_Void.mRoles.Add(eRole.Disabler)
    bundleFaceless_Void.mRoles.Add(eRole.Escape)

    bundleFaceless_Void.mPrimaryStat = ePrimaryStat.Agility

    bundleFaceless_Void.mBio = "Darkterror the Faceless Void is a visitor from Claszureme, a realm outside of time. It remains a mystery why this being from another dimension believes the struggle for the Nemesis Stones is worth entering our physical plane, but apparently an upset in the balance of power in this world has repercussions in adjacent dimensions. Time means nothing to Darkterror, except as a way to thwart his foes and aid his allies. His long-view of the cosmos has given him a remote, disconnected quality, although in battle he is quite capable of making it personal. "

    bundleFaceless_Void.mBaseStr = 23
    bundleFaceless_Void.mStrIncrement = 1.6

    bundleFaceless_Void.mBaseInt = 15
    bundleFaceless_Void.mIntIncrement = 1.5

    bundleFaceless_Void.mBaseAgi = 23
    bundleFaceless_Void.mAgiIncrement = 2.65


    bundleFaceless_Void.mBaseMoveSpeed = 300
    bundleFaceless_Void.mBaseArmor = 1


    bundleFaceless_Void.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleFaceless_Void.mName, bundleFaceless_Void)



    '----------------------------------------------------------
    '-PHANTOM ASSASSIN START-----------------------------
    '----------------------------------------------------------
    Dim bundlePhantom_Assassin As New HeroBundle
    'FROM UNITBASE
    bundlePhantom_Assassin.mIDItem = New dvID(New Guid("a4eda5a1-1f45-42ba-8635-9c59491b05d9"), "Herobundle: Phantom Assassin", eEntity.Herobundle)
    bundlePhantom_Assassin.mName = eHeroName.untPhantom_Assassin
    bundlePhantom_Assassin.DisplayName = "Phantom Assassin"
    bundlePhantom_Assassin.mArmorType = eArmorType.Hero
    bundlePhantom_Assassin.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/phantom_assassin_vert.jpg"
    bundlePhantom_Assassin.mWebpageLink = "http://www.dota2.com/hero/Phantom_Assassin/"

    bundlePhantom_Assassin.mAttackType = eAttackType.Melee
    bundlePhantom_Assassin.mBaseHitpoints = 0
    bundlePhantom_Assassin.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundlePhantom_Assassin.mBaseAttackDamage = New ValueWrapper(23, 25)

    bundlePhantom_Assassin.mDaySightRange = 1800
    bundlePhantom_Assassin.mNightSightRange = 800

    bundlePhantom_Assassin.mAttackRange = 128
    bundlePhantom_Assassin.mMissileSpeed = Nothing

    bundlePhantom_Assassin.mAbilityNames.Add(eAbilityName.abStifling_Dagger)
    bundlePhantom_Assassin.mAbilityNames.Add(eAbilityName.abPhantom_Strike)
    bundlePhantom_Assassin.mAbilityNames.Add(eAbilityName.abBlur)
    bundlePhantom_Assassin.mAbilityNames.Add(eAbilityName.abCoup_De_Grace)




    'FROM HEROBASE
    'Fixed, immutable stats
    bundlePhantom_Assassin.mDevName = "Phantom_Assassin"

    bundlePhantom_Assassin.mRoles.Add(eRole.Carry)
    bundlePhantom_Assassin.mRoles.Add(eRole.Escape)

    bundlePhantom_Assassin.mPrimaryStat = ePrimaryStat.Agility

    bundlePhantom_Assassin.mBio = "Through a process of divination, children are selected for upbringing by the Sisters of the Veil, an order that considers assassination a sacred part of the natural order. The Veiled Sisters identify targets through meditation and oracular utterances. They accept no contracts, and never seem to pursue targets for political or mercenary reasons. Their killings bear no relation to any recognizable agenda, and can seem to be completely random: A figure of great power is no more likely to be eliminated than a peasant or a well digger. Whatever pattern the killings may contain, it is known only to them. They treat their victims as sacrifices, and death at their hand is considered an honor. Raised with no identity except that of their order, any Phantom Assassin can take the place of any other; their number is not known. Perhaps there are many, perhaps there are few. Nothing is known of what lies under the Phantom Veil. Except that this one, from time to time, when none are near enough to hear, is known to stir her veils with the forbidden whisper of her own name: Mortred. "

    bundlePhantom_Assassin.mBaseStr = 20
    bundlePhantom_Assassin.mStrIncrement = 1.85

    bundlePhantom_Assassin.mBaseInt = 13
    bundlePhantom_Assassin.mIntIncrement = 1

    bundlePhantom_Assassin.mBaseAgi = 23
    bundlePhantom_Assassin.mAgiIncrement = 3.15


    bundlePhantom_Assassin.mBaseMoveSpeed = 310
    bundlePhantom_Assassin.mBaseArmor = 1


    bundlePhantom_Assassin.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundlePhantom_Assassin.mName, bundlePhantom_Assassin)



    '----------------------------------------------------------
    '-VIPER START-----------------------------
    '----------------------------------------------------------
    Dim bundleViper As New HeroBundle
    'FROM UNITBASE
    bundleViper.mIDItem = New dvID(New Guid("d7448630-5cd9-412d-9606-9c76bfef1e13"), "Herobundle: Viper", eEntity.Herobundle)
    bundleViper.mName = eHeroName.untViper
    bundleViper.DisplayName = "Viper"
    bundleViper.mArmorType = eArmorType.Hero
    bundleViper.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/viper_vert.jpg"
    bundleViper.mWebpageLink = "http://www.dota2.com/hero/Viper/"

    bundleViper.mAttackType = eAttackType.Ranged
    bundleViper.mBaseHitpoints = 0
    bundleViper.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleViper.mBaseAttackDamage = New ValueWrapper(23, 25)

    bundleViper.mDaySightRange = 1800
    bundleViper.mNightSightRange = 800

    bundleViper.mAttackRange = 575
    bundleViper.mMissileSpeed = 1200

    bundleViper.mAbilityNames.Add(eAbilityName.abPoison_Attack)
    bundleViper.mAbilityNames.Add(eAbilityName.abNethertoxin)
    bundleViper.mAbilityNames.Add(eAbilityName.abCorrosive_Skin)
    bundleViper.mAbilityNames.Add(eAbilityName.abViper_Strike)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleViper.mDevName = "Viper"

    bundleViper.mRoles.Add(eRole.Carry)
    bundleViper.mRoles.Add(eRole.Durable)

    bundleViper.mPrimaryStat = ePrimaryStat.Agility

    bundleViper.mBio = "The malevolent familiar of a sadistic wizard who captured and hoped to tame him, Viper was curiously glad to have been sprung from the sealed and unchanging subterranean Nether Reaches where his race had lived for millions of years, after tectonic slippage had sealed off the Netherdrakes in luminous caverns. Viper spent some time appearing to submit to the wizard's enchainments, hoping to learn what he could of the dark magics the mage practiced. But he soon realized that few spells were as deadly as the toxins that were his birthright. Exuding an acid that swiftly ate away the bars of his cage, the Netherdrake slipped free of his confines, spit poison in the old spellcaster's eyes, and soared out to let the world know that it had a new master. "

    bundleViper.mBaseStr = 20
    bundleViper.mStrIncrement = 1.9

    bundleViper.mBaseInt = 15
    bundleViper.mIntIncrement = 1.8

    bundleViper.mBaseAgi = 21
    bundleViper.mAgiIncrement = 2.5


    bundleViper.mBaseMoveSpeed = 285

    bundleViper.mBaseArmor = -1

    bundleViper.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleViper.mName, bundleViper)



    '----------------------------------------------------------
    '-CLINKZ START-----------------------------
    '----------------------------------------------------------
    Dim bundleClinkz As New HeroBundle
    'FROM UNITBASE
    bundleClinkz.mIDItem = New dvID(New Guid("6109393a-bb01-400c-81cb-a29457c42681"), "Herobundle: Clinkz", eEntity.Herobundle)
    bundleClinkz.mName = eHeroName.untClinkz
    bundleClinkz.DisplayName = "Clinkz"
    bundleClinkz.mArmorType = eArmorType.Hero
    bundleClinkz.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/clinkz_vert.jpg"
    bundleClinkz.mWebpageLink = "http://www.dota2.com/hero/Clinkz/"

    bundleClinkz.mAttackType = eAttackType.Ranged
    bundleClinkz.mBaseHitpoints = 0
    bundleClinkz.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleClinkz.mBaseAttackDamage = New ValueWrapper(15, 21)
    
    bundleClinkz.mDaySightRange = 1800
    bundleClinkz.mNightSightRange = 800

    bundleClinkz.mAttackRange = 600
    bundleClinkz.mMissileSpeed = 900

    bundleClinkz.mAbilityNames.Add(eAbilityName.abStrafe)
    bundleClinkz.mAbilityNames.Add(eAbilityName.abSearing_Arrows)
    bundleClinkz.mAbilityNames.Add(eAbilityName.abSkeleton_Walk)
    bundleClinkz.mAbilityNames.Add(eAbilityName.abDeath_Pact)





    'FROM HEROBASE
    'Fixed, immutable stats
    bundleClinkz.mDevName = "Clinkz"

    bundleClinkz.mRoles.Add(eRole.Carry)
    bundleClinkz.mRoles.Add(eRole.Escape)

    bundleClinkz.mPrimaryStat = ePrimaryStat.Agility

    bundleClinkz.mBio = "At the base of the Bleeding Hills stretches a thousand-league wood, a place called The Hoven, where black pools gather the tarry blood of the uplands, and the king-mage Sutherex sits in benevolent rule. Once a sworn protector of the Hoven lands, Clinkz earned a reputation for his skill with a bow. In the three-hundredth year of the king-mage, the demon Maraxiform rose from sixth hell to lay claim to the forest. In response, the king-mage decreed an unbreakable spell: to any who slew the demon would be granted Life Without End.|Unaware of the spell, Clinkz waded into battle, defending his lands against the demon's fiery onslaught. Clinkz drove Maraxiform back to the gates of sixth-hell itself, where on that fiery threshold the two locked in a mortal conflict. Grievously wounded, the demon let out a blast of hellfire as Clinkz loosed his final arrow. The arrow struck the demon true as hellfire poured out across the land, lighting the black pools and burning Clinkz alive at the instant of the demon's death. Thus, the mage's spell took effect at the very moment of the archer's conflagration, preserving him in this unholy state, leaving him a being of bones and rage, caught in the very act of dying, carrying hell's breath with him on his journey into eternity. "

    bundleClinkz.mBaseStr = 15
    bundleClinkz.mStrIncrement = 1.6

    bundleClinkz.mBaseInt = 16
    bundleClinkz.mIntIncrement = 1.55

    bundleClinkz.mBaseAgi = 22
    bundleClinkz.mAgiIncrement = 3


    bundleClinkz.mBaseMoveSpeed = 300

    bundleClinkz.mBaseArmor = 1

    bundleClinkz.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleClinkz.mName, bundleClinkz)



    '----------------------------------------------------------
    '-BROODMOTHER START-----------------------------
    '----------------------------------------------------------
    Dim bundleBroodmother As New HeroBundle
    'FROM UNITBASE
    bundleBroodmother.mIDItem = New dvID(New Guid("f0cb9043-603b-49d1-8b78-8857edb81bcd"), "Herobundle: Broodmother", eEntity.Herobundle)
    bundleBroodmother.mName = eHeroName.untBroodmother
    bundleBroodmother.DisplayName = "Broodmother"
    bundleBroodmother.mArmorType = eArmorType.Hero
    bundleBroodmother.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/broodmother_vert.jpg"
    bundleBroodmother.mWebpageLink = "http://www.dota2.com/hero/Broodmother/"

    bundleBroodmother.mAttackType = eAttackType.Melee
    bundleBroodmother.mBaseHitpoints = 0
    bundleBroodmother.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleBroodmother.mBaseAttackDamage = New ValueWrapper(26, 32)

    bundleBroodmother.mDaySightRange = 1800
    bundleBroodmother.mNightSightRange = 800

    bundleBroodmother.mAttackRange = 128
    bundleBroodmother.mMissileSpeed = Nothing

    bundleBroodmother.mAbilityNames.Add(eAbilityName.abSpawn_Spiderlings)
    bundleBroodmother.mAbilityNames.Add(eAbilityName.abSpin_Web)

    bundleBroodmother.mAbilityNames.Add(eAbilityName.abIncapacitating_Bite)
    bundleBroodmother.mAbilityNames.Add(eAbilityName.abInsatiable_Hunger)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleBroodmother.mDevName = "Broodmother"

    bundleBroodmother.mRoles.Add(eRole.Pusher)
    bundleBroodmother.mRoles.Add(eRole.Carry)
    bundleBroodmother.mRoles.Add(eRole.Escape)

    bundleBroodmother.mPrimaryStat = ePrimaryStat.Agility

    bundleBroodmother.mBio = "For centuries, Black Arachnia the Broodmother lurked in the dark lava tubes beneath the smoldering caldera of Mount Pyrotheos, raising millions of spiderlings in safety before sending them to find prey in the wide world above. In a later age, the Vizier of Greed, Ptholopthales, erected his lodestone ziggurat on the slopes of the dead volcano, knowing that any looters who sought his magnetic wealth must survive the spider-haunted passages. After millennia of maternal peace, Black Arachnia found herself beset by a steady trickle of furfeet and cutpurses, bold knights and noble youths--all of them delicious, certainly, and yet tending to create a less than nurturing environment for her innocent offspring. Tiring of the intrusions, she paid a visit to Ptholopthales; and when he proved unwilling to discuss a compromise, she wrapped the Vizier in silk and set him aside to be the centerpiece of a special birthday feast. Unfortunately, the absence of the Magnetic Ziggurat's master merely emboldened a new generation of intruders. When one of her newborns was trodden underfoot by a clumsy adventurer, she reached the end of her silken rope. Broodmother headed for the surface, declaring her intent to rid the world of each and every possible invader, down to the last Hero if necessary, until she could ensure her nursery might once more be a safe and wholesome environment for her precious spiderspawn. "

    bundleBroodmother.mBaseStr = 17
    bundleBroodmother.mStrIncrement = 2.5

    bundleBroodmother.mBaseInt = 18
    bundleBroodmother.mIntIncrement = 2

    bundleBroodmother.mBaseAgi = 18
    bundleBroodmother.mAgiIncrement = 2.2


    bundleBroodmother.mBaseMoveSpeed = 295

    bundleBroodmother.mBaseArmor = 0

    bundleBroodmother.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleBroodmother.mName, bundleBroodmother)



    '----------------------------------------------------------
    '-WEAVER START-----------------------------
    '----------------------------------------------------------
    Dim bundleWeaver As New HeroBundle
    'FROM UNITBASE
    bundleWeaver.mIDItem = New dvID(New Guid("e5228387-f481-40ae-923f-11edf6327050"), "Herobundle: Weaver", eEntity.Herobundle)
    bundleWeaver.mName = eHeroName.untWeaver
    bundleWeaver.DisplayName = "Weaver"
    bundleWeaver.mArmorType = eArmorType.Hero
    bundleWeaver.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/weaver_vert.jpg"
    bundleWeaver.mWebpageLink = "http://www.dota2.com/hero/Weaver/"

    bundleWeaver.mAttackType = eAttackType.Ranged
    bundleWeaver.mBaseHitpoints = 0
    bundleWeaver.mBaseAttackSpeed = 1.8 ' http://dota2.gamepedia.com/Attack_speed

    bundleWeaver.mBaseAttackDamage = New ValueWrapper(36, 46)

    bundleWeaver.mDaySightRange = 1800
    bundleWeaver.mNightSightRange = 800

    bundleWeaver.mAttackRange = 425
    bundleWeaver.mMissileSpeed = 900

    bundleWeaver.mAbilityNames.Add(eAbilityName.abThe_Swarm)
    bundleWeaver.mAbilityNames.Add(eAbilityName.abShukuchi)
    bundleWeaver.mAbilityNames.Add(eAbilityName.abGeminate_Attack)
    bundleWeaver.mAbilityNames.Add(eAbilityName.abTime_Lapse)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleWeaver.mDevName = "Weaver"

    bundleWeaver.mRoles.Add(eRole.Carry)
    bundleWeaver.mRoles.Add(eRole.Escape)

    bundleWeaver.mPrimaryStat = ePrimaryStat.Agility

    bundleWeaver.mBio = "The fabric of creation needs constant care, lest it grow tattered; for when it unravels, whole worlds come undone. It is the work of the Weavers to keep the fabric tight, to repair worn spots in the mesh of reality. They also defend from the things that gnaw and lay their eggs in frayed regions, whose young can quickly devour an entire universe if the Weavers let their attention lapse. Skitskurr was a master Weaver, charged with keeping one small patch of creation tightly woven and unfaded. But the job was not enough to satisfy. It nagged him that the original work of creation all lay in the past; the Loom had done its work and travelled on. He wanted to create rather than merely maintain-to weave worlds of his own devising. He began making small changes to his domain, but the thrill of creation proved addictive, and his strokes became bolder, pulling against the pattern that the Loom had woven. The guardians came, with their scissors, and Weaver's world was pared off, snipped from the cosmic tapestry, which they rewove without him in it. Skitskurr found himself alone, apart from his kind, a state that would have been torment for any other Weaver. But Skitskurr rejoiced, for now he was free. Free to create for himself, to begin anew. The raw materials he needed to weave a new reality were all around him. All he had to do was tear apart this old world at the seams. "

    bundleWeaver.mBaseStr = 15
    bundleWeaver.mStrIncrement = 1.5

    bundleWeaver.mBaseInt = 15
    bundleWeaver.mIntIncrement = 1.8

    bundleWeaver.mBaseAgi = 14
    bundleWeaver.mAgiIncrement = 2.5


    bundleWeaver.mBaseMoveSpeed = 290

    bundleWeaver.mBaseArmor = -1

    bundleWeaver.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleWeaver.mName, bundleWeaver)



    '----------------------------------------------------------
    '-SPECTRE START-----------------------------
    '----------------------------------------------------------
    Dim bundleSpectre As New HeroBundle
    'FROM UNITBASE
    bundleSpectre.mIDItem = New dvID(New Guid("7522daca-6711-47b7-8b33-ad78f8034760"), "Herobundle: Spectre", eEntity.Herobundle)
    bundleSpectre.mName = eHeroName.untSpectre
    bundleSpectre.DisplayName = "Spectre"
    bundleSpectre.mArmorType = eArmorType.Hero
    bundleSpectre.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/spectre_vert.jpg"
    bundleSpectre.mWebpageLink = "http://www.dota2.com/hero/Spectre/"

    bundleSpectre.mAttackType = eAttackType.Melee
    bundleSpectre.mBaseHitpoints = 0
    bundleSpectre.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleSpectre.mBaseAttackDamage = New ValueWrapper(23, 27)

    bundleSpectre.mDaySightRange = 1800
    bundleSpectre.mNightSightRange = 800

    bundleSpectre.mAttackRange = 128
    bundleSpectre.mMissileSpeed = Nothing

    bundleSpectre.mAbilityNames.Add(eAbilityName.abSpectral_Dagger)
    bundleSpectre.mAbilityNames.Add(eAbilityName.abDesolate)
    bundleSpectre.mAbilityNames.Add(eAbilityName.abDispersion)
    'bundleSpectre.mAbilityNames.Add(eAbilityName.abReality)
    bundleSpectre.mAbilityNames.Add(eAbilityName.abHaunt)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleSpectre.mDevName = "Spectre"

    bundleSpectre.mRoles.Add(eRole.Carry)
    bundleSpectre.mRoles.Add(eRole.Durable)

    bundleSpectre.mPrimaryStat = ePrimaryStat.Agility

    bundleSpectre.mBio = "Just as higher states of energy seek a lower level, the Spectre known as Mercurial is a being of intense and violent energy who finds herself irresistibly drawn to scenes of strife as they unfold in the physical world. While her normal spectral state transcends sensory limitations, each time she takes on a physical manifestation, she is stricken by a loss of self--though not of purpose. In the clash of combat, her identity shatters and reconfigures, and she begins to regain awareness. She grasps that she is Mercurial the Spectre--and that all of her Haunts are but shadows of the one true Spectre. Focus comes in the struggle for survival; her true mind reasserts itself; until in the final moments of victory or defeat, she transcends matter and is restored once more to her eternal form. "

    bundleSpectre.mBaseStr = 19
    bundleSpectre.mStrIncrement = 2

    bundleSpectre.mBaseInt = 16
    bundleSpectre.mIntIncrement = 1.9

    bundleSpectre.mBaseAgi = 23
    bundleSpectre.mAgiIncrement = 2.2


    bundleSpectre.mBaseMoveSpeed = 295

    bundleSpectre.mBaseArmor = 0

    bundleSpectre.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleSpectre.mName, bundleSpectre)



    '----------------------------------------------------------
    '-MEEPO START-----------------------------
    '----------------------------------------------------------
    Dim bundleMeepo As New HeroBundle
    'FROM UNITBASE
    bundleMeepo.mIDItem = New dvID(New Guid("7cab72ad-9450-4cd3-a98d-75db62941395"), "Herobundle: Meepo", eEntity.Herobundle)
    bundleMeepo.mName = eHeroName.untMeepo
    bundleMeepo.DisplayName = "Meepo"
    bundleMeepo.mArmorType = eArmorType.Hero
    bundleMeepo.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/meepo_vert.jpg"
    bundleMeepo.mWebpageLink = "http://www.dota2.com/hero/Meepo/"

    bundleMeepo.mAttackType = eAttackType.Melee
    bundleMeepo.mBaseHitpoints = 0
    bundleMeepo.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleMeepo.mBaseAttackDamage = New ValueWrapper(16, 22)

    bundleMeepo.mDaySightRange = 1800
    bundleMeepo.mNightSightRange = 800

    bundleMeepo.mAttackRange = 128
    bundleMeepo.mMissileSpeed = Nothing

    bundleMeepo.mAbilityNames.Add(eAbilityName.abEarthbind)

    bundleMeepo.mAbilityNames.Add(eAbilityName.abPoof)
    bundleMeepo.mAbilityNames.Add(eAbilityName.abGeostrike)

    bundleMeepo.mAbilityNames.Add(eAbilityName.abDivided_We_Stand)

    'FROM HEROBASE
    'Fixed, immutable stats
    bundleMeepo.mDevName = "Meepo"

    bundleMeepo.mRoles.Add(eRole.Carry)
    bundleMeepo.mRoles.Add(eRole.Disabler)
    bundleMeepo.mRoles.Add(eRole.Initiator)

    bundleMeepo.mPrimaryStat = ePrimaryStat.Agility

    bundleMeepo.mBio = """If you ask me, life is all about who you know and what you can find. When you live up in the Riftshadow Ruins, just finding food can be tough. So you need to cut corners, you need to scrounge, you need to know your strengths. Some of the beasts up there can kill you, so you need a way to trap the weak and duck the strong. On the upside, the ruins have history, and history is worth a lot to some people. There used to be a palace there, where they had all these dark rituals. Bad stuff. If you survived the ceremony, they would shatter a crystal and split your soul into pieces. They made great art though! Sculptures and such. Let me tell you: sometimes you stumble onto some of those old carvings. Take a pack full of those to town and sell them, then get yourself food for a few weeks. If luck is really on your side, you might find a Riftshadow crystal. Get it appraised and start asking around. Someone always knows some crazy fool looking for this kind of thing. If all else fails, sell it to a Magus the next time one's in town. They love that stuff. Still, whatever you do, be careful handling those crystals. You do not want one to go off on you. It really hurts."""

    bundleMeepo.mBaseStr = 23
    bundleMeepo.mStrIncrement = 1.6

    bundleMeepo.mBaseInt = 20
    bundleMeepo.mIntIncrement = 1.6

    bundleMeepo.mBaseAgi = 23
    bundleMeepo.mAgiIncrement = 1.9


    bundleMeepo.mBaseMoveSpeed = 315
    bundleMeepo.mBaseArmor = 1


    bundleMeepo.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleMeepo.mName, bundleMeepo)



    '----------------------------------------------------------
    '-NYX ASSASSIN START-----------------------------
    '----------------------------------------------------------
    Dim bundleNyx_Assassin As New HeroBundle
    'FROM UNITBASE
    bundleNyx_Assassin.mIDItem = New dvID(New Guid("d6b7ef76-e2af-4133-905b-0634408a511a"), "Herobundle: Nyx Assassin", eEntity.Herobundle)
    bundleNyx_Assassin.mName = eHeroName.untNyx_Assassin
    bundleNyx_Assassin.DisplayName = "Nyx Assassin"
    bundleNyx_Assassin.mArmorType = eArmorType.Hero
    bundleNyx_Assassin.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/nyx_assassin_vert.jpg"
    bundleNyx_Assassin.mWebpageLink = "http://www.dota2.com/hero/Nyx_Assassin/"

    bundleNyx_Assassin.mAttackType = eAttackType.Melee
    bundleNyx_Assassin.mBaseHitpoints = 0
    bundleNyx_Assassin.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleNyx_Assassin.mBaseAttackDamage = New ValueWrapper(30, 34)

    bundleNyx_Assassin.mDaySightRange = 1800
    bundleNyx_Assassin.mNightSightRange = 800

    bundleNyx_Assassin.mAttackRange = 128
    bundleNyx_Assassin.mMissileSpeed = Nothing


    bundleNyx_Assassin.mAbilityNames.Add(eAbilityName.abImpale)
    bundleNyx_Assassin.mAbilityNames.Add(eAbilityName.abMana_Burn)
    bundleNyx_Assassin.mAbilityNames.Add(eAbilityName.abSpiked_Carapace)
    bundleNyx_Assassin.mAbilityNames.Add(eAbilityName.abVendetta)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleNyx_Assassin.mDevName = "Nyx_Assassin"

    bundleNyx_Assassin.mRoles.Add(eRole.Disabler)
    bundleNyx_Assassin.mRoles.Add(eRole.Nuker)

    bundleNyx_Assassin.mPrimaryStat = ePrimaryStat.Agility

    bundleNyx_Assassin.mBio = "Deep in the Archive of Ultimyr, shelved between scholarly treatises on dragon cladistics and books of untranslatable spells, there is an ancient tome of entomological curiosities. Compiled by scholars, the book describes the telepathic talents of the zealot scarab, a strange species of social insect with abilities unique to all the seven planes.|Unlike most grubs of his colony, Nyx Assassin did not arise from metamorphosis with the plodding thoughts and blunted appendages common to the worker caste of his kind. For his was a special transformation, guided by the grace of Nyx. He was the chosen one, selected from the many and anointed with an extract of the queen goddess herself. Not all survive the dark blessing of the queen's chamber, but he emerged with a penetrating mind, and dagger-like claws--his razor sharp mandibles raking the air while his thoughts projected directly into the minds of those around him. Of all zealot scarabs, he alone was selected for the highest calling. After his metamorphosis, he was reborn, by grace of Nyx, with abilities which shaped him for one thing and one thing only: to kill in the name of his goddess. "

    bundleNyx_Assassin.mBaseStr = 18
    bundleNyx_Assassin.mStrIncrement = 2

    bundleNyx_Assassin.mBaseInt = 18
    bundleNyx_Assassin.mIntIncrement = 2.1

    bundleNyx_Assassin.mBaseAgi = 19
    bundleNyx_Assassin.mAgiIncrement = 2.2


    bundleNyx_Assassin.mBaseMoveSpeed = 300
    bundleNyx_Assassin.mBaseArmor = 1


    bundleNyx_Assassin.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleNyx_Assassin.mName, bundleNyx_Assassin)



    '----------------------------------------------------------
    '-SLARK START-----------------------------
    '----------------------------------------------------------
    Dim bundleSlark As New HeroBundle
    'FROM UNITBASE
    bundleSlark.mIDItem = New dvID(New Guid("5d09dad3-6622-4552-85a7-401038f3d146"), "Herobundle: Slark", eEntity.Herobundle)
    bundleSlark.mName = eHeroName.untSlark
    bundleSlark.DisplayName = "Slark"
    bundleSlark.mArmorType = eArmorType.Hero
    bundleSlark.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/slark_vert.jpg"
    bundleSlark.mWebpageLink = "http://www.dota2.com/hero/Slark/"

    bundleSlark.mAttackType = eAttackType.Melee
    bundleSlark.mBaseHitpoints = 0
    bundleSlark.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleSlark.mBaseAttackDamage = New ValueWrapper(33, 41)

    bundleSlark.mDaySightRange = 1800
    bundleSlark.mNightSightRange = 1800

    bundleSlark.mAttackRange = 128
    bundleSlark.mMissileSpeed = Nothing


    bundleSlark.mAbilityNames.Add(eAbilityName.abDark_Pact)
    bundleSlark.mAbilityNames.Add(eAbilityName.abPounce)
    bundleSlark.mAbilityNames.Add(eAbilityName.abEssence_Shift)

    bundleSlark.mAbilityNames.Add(eAbilityName.abShadow_Dance)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleSlark.mDevName = "Slark"

    bundleSlark.mRoles.Add(eRole.Escape)

    bundleSlark.mPrimaryStat = ePrimaryStat.Agility

    bundleSlark.mBio = "Little known to the inhabitants of the dry world, Dark Reef is a sunken prison where the worst of the sea-bred are sent for crimes against their fellows. It is a razor barbed warren full of murderous slithereen, treacherous Deep Ones, sociopathic meranths. In this dim labyrinth, patrolled by eels and guarded by enormous anemones, only the vicious survive. Pitched into Dark Reef for crimes unknown, Slark spent half a lifetime without kin or kindness, trusting no one, surviving through a combination of stealth and ruthlessness, keeping his thoughts and his plans to himself. When the infamous Dark Reef Dozen plotted their ill-fated breakout, they kept their plans a perfect secret, murdering anyone who could have put the pieces together--but somehow Slark discovered their scheme and made a place for himself in it. Ten of the Dozen died in the escape attempt, and two were captured, hauled back to Dark Reef, then executed for the entertainment of their fellow inmates. But Slark, the unsung thirteenth, used the commotion as cover and slipped away, never to be caught. Now a furtive resident of the carnivorous mangrove scrub that grips the southern reach of Shadeshore, Slark remains the only successful escapee from Dark Reef. "

    bundleSlark.mBaseStr = 21
    bundleSlark.mStrIncrement = 1.8

    bundleSlark.mBaseInt = 16
    bundleSlark.mIntIncrement = 1.9

    bundleSlark.mBaseAgi = 21
    bundleSlark.mAgiIncrement = 1.5


    bundleSlark.mBaseMoveSpeed = 305

    bundleSlardar.mBaseArmor = -1

    bundleSlark.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleSlark.mName, bundleSlark)



    '----------------------------------------------------------
    '-MEDUSA START-----------------------------
    '----------------------------------------------------------
    Dim bundleMedusa As New HeroBundle
    'FROM UNITBASE
    bundleMedusa.mIDItem = New dvID(New Guid("196f0d56-de90-45e9-93e0-79785947908c"), "Herobundle: Medusa", eEntity.Herobundle)
    bundleMedusa.mName = eHeroName.untMedusa
    bundleMedusa.DisplayName = "Medusa"
    bundleMedusa.mArmorType = eArmorType.Hero
    bundleMedusa.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/medusa_vert.jpg"
    bundleMedusa.mWebpageLink = "http://www.dota2.com/hero/Medusa/"

    bundleMedusa.mAttackType = eAttackType.Ranged
    bundleMedusa.mBaseHitpoints = 0
    bundleMedusa.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleMedusa.mBaseAttackDamage = New ValueWrapper(24, 30)

    bundleMedusa.mDaySightRange = 1800
    bundleMedusa.mNightSightRange = 800

    bundleMedusa.mAttackRange = 600
    bundleMedusa.mMissileSpeed = 1200

    bundleMedusa.mAbilityNames.Add(eAbilityName.abSplit_Shot)
    bundleMedusa.mAbilityNames.Add(eAbilityName.abMystic_Snake)
    bundleMedusa.mAbilityNames.Add(eAbilityName.abMana_Shield)
    bundleMedusa.mAbilityNames.Add(eAbilityName.abStone_Gaze)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleMedusa.mDevName = "Medusa"

    bundleMedusa.mRoles.Add(eRole.Carry)

    bundleMedusa.mPrimaryStat = ePrimaryStat.Agility

    bundleMedusa.mBio = "Beauty is power. This thought comforted Medusa--the youngest and loveliest of three beautiful Gorgon sisters, born to a sea goddess--because she alone of the sisters was mortal. It comforted her, that is, until the day masked assailants invaded the Gorgon realm and tore the two immortal sisters from their home, unmoved by their beauty or by their tears. One of the invaders seized Medusa as well, but then cast her aside with a disgusted look: 'This one has the mortal stink upon her. We have no use for that which dies.' Humiliated, enraged, Medusa fled to the temple of her mother and cast herself before the goddess, crying, 'You denied me eternal life--therefore I beg you, give me power! Power, so I can dedicate what life I have to rescuing my sisters and avenging this injustice!' After long thought, the goddess granted her daughter's request, allowing Medusa to trade her legendary beauty for a face and form of terrifying strength. Never for a moment has Medusa regretted her choice. She understands that power is the only beauty worth possessing--for only power can change the world. "

    bundleMedusa.mBaseStr = 14
    bundleMedusa.mStrIncrement = 1.65

    bundleMedusa.mBaseInt = 19
    bundleMedusa.mIntIncrement = 1.85

    bundleMedusa.mBaseAgi = 20
    bundleMedusa.mAgiIncrement = 2.5


    bundleMedusa.mBaseMoveSpeed = 290

    bundleMedusa.mBaseArmor = -1

    bundleMedusa.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleMedusa.mName, bundleMedusa)



    '----------------------------------------------------------
    '-TERRORBLADE START-----------------------------
    '----------------------------------------------------------
    Dim bundleTerrorblade As New HeroBundle
    'FROM UNITBASE
    bundleTerrorblade.mIDItem = New dvID(New Guid("1286b2c9-1e17-4b45-841d-b9689c4ea31d"), "Herobundle: Terrorblade", eEntity.Herobundle)
    bundleTerrorblade.mName = eHeroName.untTerrorblade
    bundleTerrorblade.DisplayName = "Terrorblade"
    bundleTerrorblade.mArmorType = eArmorType.Hero
    bundleTerrorblade.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/terrorblade_vert.jpg"
    bundleTerrorblade.mWebpageLink = "http://www.dota2.com/hero/Terrorblade/"

    bundleTerrorblade.mAttackType = eAttackType.Melee
    bundleTerrorblade.mBaseHitpoints = 0
    bundleTerrorblade.mBaseAttackSpeed = 1.5 '  http://dota2.gamepedia.com/Attack_speed

    bundleTerrorblade.mBaseAttackDamage = New ValueWrapper(26, 32)

    bundleTerrorblade.mDaySightRange = 1800
    bundleTerrorblade.mNightSightRange = 800

    bundleTerrorblade.mAttackRange = 128
    bundleTerrorblade.mMissileSpeed = 900

    bundleTerrorblade.mAbilityNames.Add(eAbilityName.abReflection)
    bundleTerrorblade.mAbilityNames.Add(eAbilityName.abConjure_Image)
    bundleTerrorblade.mAbilityNames.Add(eAbilityName.abMetamorphosis)
    bundleTerrorblade.mAbilityNames.Add(eAbilityName.abSunder)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleTerrorblade.mDevName = "Terrorblade"

    bundleTerrorblade.mRoles.Add(eRole.Carry)

    bundleTerrorblade.mPrimaryStat = ePrimaryStat.Agility

    bundleTerrorblade.mBio = "Terrorblade is the demon marauder--an outlaw hellion whom even other demons fear. A cosmic iconoclast, he stole from the Demon Lords, ignored the codified rites that should have bound his behavior, and broke every law of the seven Infernal Regions. For his crimes, he was taught this lesson: even Hell has a hell. A short, brutal trial ensued, with many dead on all sides, and he was finally incarcerated in Foulfell, a hidden dimension where demonkind imprison their own.|But Foulfell is no normal prison. In this dark mirror of reality, demons are sentenced to gaze eternally into the twisted reflection of their own souls. But instead of suffering, Terrorblade made himself master of his own reflected worst self--a raging, thieving demon of unimaginable power. With his inner beast under sway, he destroyed the fractal prison walls and burst free to turn his terror loose upon all creation. "

    bundleTerrorblade.mBaseStr = 15
    bundleTerrorblade.mStrIncrement = 1.4

    bundleTerrorblade.mBaseInt = 19
    bundleTerrorblade.mIntIncrement = 1.75

    bundleTerrorblade.mBaseAgi = 22
    bundleTerrorblade.mAgiIncrement = 3.2


    bundleTerrorblade.mBaseMoveSpeed = 315
    bundleTerrorblade.mBaseArmor = 4


    bundleTerrorblade.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleTerrorblade.mName, bundleTerrorblade)



    '----------------------------------------------------------
    '-BANE START-----------------------------
    '----------------------------------------------------------
    Dim bundleBane As New HeroBundle
    'FROM UNITBASE
    bundleBane.mIDItem = New dvID(New Guid("f632b492-4027-486f-8546-afde80291078"), "Herobundle: Bane", eEntity.Herobundle)
    bundleBane.mName = eHeroName.untBane
    bundleBane.DisplayName = "Bane"
    bundleBane.mArmorType = eArmorType.Hero
    bundleBane.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/bane_vert.jpg"
    bundleBane.mWebpageLink = "http://www.dota2.com/hero/Bane/"

    bundleBane.mAttackType = eAttackType.Ranged
    bundleBane.mBaseHitpoints = 0
    bundleBane.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleBane.mBaseAttackDamage = New ValueWrapper(33, 39)

    bundleBane.mDaySightRange = 1800
    bundleBane.mNightSightRange = 800

    bundleBane.mAttackRange = 400
    bundleBane.mMissileSpeed = 900

    bundleBane.mAbilityNames.Add(eAbilityName.abEnfeeble)
    bundleBane.mAbilityNames.Add(eAbilityName.abBrain_Sap)
    bundleBane.mAbilityNames.Add(eAbilityName.abNightmare)
    bundleBane.mAbilityNames.Add(eAbilityName.abFiends_Grip)

    'bundleBane.mAbilityNames.Add(eAbilityName.abNightmare_End)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleBane.mDevName = "Bane"

    bundleBane.mRoles.Add(eRole.Disabler)
    bundleBane.mRoles.Add(eRole.Nuker)
    bundleBane.mRoles.Add(eRole.Support)

    bundleBane.mPrimaryStat = ePrimaryStat.Intelligence

    bundleBane.mBio = "When the gods have nightmares, it is Bane Elemental who brings them. Also known as Atropos, Bane was born from the midnight terrors of the goddess Nyctasha. A force of terror too powerful to be contained by sleep, he surfaced from her slumbers, fed upon her immortality, and stole his vaporous form from her inky blood. He is the essence of fear. Mortals who hear his voice hear their darkest secrets whispered in their ear. He calls to the hidden fear in every Hero's heart. Wakefulness is no protection, for Bane's black blood, continuously dripping, is a tar that traps his enemies in nightmare. In the presence of Bane, every Hero remembers to fear the dark. "

    bundleBane.mBaseStr = 22
    bundleBane.mStrIncrement = 2.1

    bundleBane.mBaseInt = 22
    bundleBane.mIntIncrement = 2.1

    bundleBane.mBaseAgi = 22
    bundleBane.mAgiIncrement = 2.1


    bundleBane.mBaseMoveSpeed = 315
    bundleBane.mBaseArmor = 1


    bundleBane.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleBane.mName, bundleBane)



    '----------------------------------------------------------
    '-LICH START-----------------------------
    '----------------------------------------------------------
    Dim bundleLich As New HeroBundle
    'FROM UNITBASE
    bundleLich.mIDItem = New dvID(New Guid("9cd03376-1f7d-4496-97d0-02c35bb4accd"), "Herobundle: Lich", eEntity.Herobundle)
    bundleLich.mName = eHeroName.untLich
    bundleLich.DisplayName = "Lich"
    bundleLich.mArmorType = eArmorType.Hero
    bundleLich.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/lich_vert.jpg"
    bundleLich.mWebpageLink = "http://www.dota2.com/hero/Lich/"

    bundleLich.mAttackType = eAttackType.Ranged
    bundleLich.mBaseHitpoints = 0
    bundleLich.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleLich.mBaseAttackDamage = New ValueWrapper(24, 33)

    bundleLich.mDaySightRange = 1800
    bundleLich.mNightSightRange = 800

    bundleLich.mAttackRange = 550
    bundleLich.mMissileSpeed = 900

    bundleLich.mAbilityNames.Add(eAbilityName.abFrost_Blast)
    bundleLich.mAbilityNames.Add(eAbilityName.abIce_Armor)
    bundleLich.mAbilityNames.Add(eAbilityName.abSacrifice)
    bundleLich.mAbilityNames.Add(eAbilityName.abChain_Frost)





    'FROM HEROBASE
    'Fixed, immutable stats
    bundleLich.mDevName = "Lich"

    bundleLich.mRoles.Add(eRole.Support)
    bundleLich.mRoles.Add(eRole.LaneSupport)
    bundleLich.mRoles.Add(eRole.Nuker)

    bundleLich.mPrimaryStat = ePrimaryStat.Intelligence

    bundleLich.mBio = "In life, the frost-mage Ethreain (not yet a Lich) had used the threat of destructive ice to enslave entire kingdoms. His subjects, aided by a few desperate magicians, eventually grew bold enough to ambush him. Armed with enough charmed rope to bind him forever, they tied the frost mage to adamant weights and dropped him in a pool known chiefly for being bottomless. It wasn't. He only fell for a year or so before an outcrop snagged him. There he rested, dead but undecaying, until the geomancer Anhil thought to verify the legend of the supposedly bottomless Black Pool. Anhil's plumbline snarled with the ropes that bound the drowned magician, and up he hauled an unexpected prize. Thinking that by rendering the dead undead, he could question the Lich about the properties of the pool, he removed the bindings and commenced a simple rite of resurrection. Even the descendants of Ethreain's enemies were long forgotten by time, so there were none to warn Anhil against imprudence. But he learned the error of his judgment almost immediately, as Lich threw off the shackles and consumed him. "

    bundleLich.mBaseStr = 18
    bundleLich.mStrIncrement = 1.55

    bundleLich.mBaseInt = 18
    bundleLich.mIntIncrement = 3.25

    bundleLich.mBaseAgi = 15
    bundleLich.mAgiIncrement = 2


    bundleLich.mBaseMoveSpeed = 315

    bundleLich.mBaseArmor = -1

    bundleLich.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleLich.mName, bundleLich)



    '----------------------------------------------------------
    '-LION START-----------------------------
    '----------------------------------------------------------
    Dim bundleLion As New HeroBundle
    'FROM UNITBASE
    bundleLion.mIDItem = New dvID(New Guid("0d95c72d-0cba-42c2-b26d-0d0f1da5dbe5"), "Herobundle: Lion", eEntity.Herobundle)
    bundleLion.mName = eHeroName.untLion
    bundleLion.DisplayName = "Lion"
    bundleLion.mArmorType = eArmorType.Hero
    bundleLion.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/lion_vert.jpg"
    bundleLion.mWebpageLink = "http://www.dota2.com/hero/Lion/"

    bundleLion.mAttackType = eAttackType.Ranged
    bundleLion.mBaseHitpoints = 0
    bundleLion.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleLion.mBaseAttackDamage = New ValueWrapper(27, 33)

    bundleLion.mDaySightRange = 1800
    bundleLion.mNightSightRange = 800

    bundleLion.mAttackRange = 600
    bundleLion.mMissileSpeed = 900


    bundleLion.mAbilityNames.Add(eAbilityName.abEarth_Spike)
    bundleLion.mAbilityNames.Add(eAbilityName.abLion_Hex)
    bundleLion.mAbilityNames.Add(eAbilityName.abMana_Drain)
    bundleLion.mAbilityNames.Add(eAbilityName.abFinger_Of_Death)




    'FROM HEROBASE
    'Fixed, immutable stats
    bundleLion.mDevName = "Lion"

    bundleLion.mRoles.Add(eRole.Disabler)
    bundleLion.mRoles.Add(eRole.Nuker)
    bundleLion.mRoles.Add(eRole.LaneSupport)
    bundleLion.mRoles.Add(eRole.Support)

    bundleLion.mPrimaryStat = ePrimaryStat.Intelligence

    bundleLion.mBio = "Once a Grandmaster of the Demon Witch tradition of sorcery, Lion earned fame among his brethren for fighting on the side of light and righteousness. But adulation corrupts. With powers surpassed only by his ambition, the mage was seduced by a demon and turned to evil, trading his soul for prestige. After committing horrible crimes that marred his soul, he was abandoned. The demon betrayed him, striking better deals with his enemies. Such was Lion's rage that he followed the demon back to hell and slew it, ripping it limb from limb, taking its demonic hand for his own. However, such demonoplasty comes at a cost. Lion was transfigured by the process, his body transformed into something unrecognizable. He rose from hell, rage incarnate, slaying even those who had once called him master, and laying waste to the lands where he had once been so adored. He survives now as the sole practitioner of the Demon Witch tradition, and those who present themselves as acolytes or students are soon relieved of their mana and carried off by the faintest gust of wind. "

    bundleLion.mBaseStr = 16
    bundleLion.mStrIncrement = 1.7

    bundleLion.mBaseInt = 22
    bundleLion.mIntIncrement = 3

    bundleLion.mBaseAgi = 15
    bundleLion.mAgiIncrement = 1.5


    bundleLion.mBaseMoveSpeed = 290

    bundleLion.mBaseArmor = -1

    bundleLion.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleLion.mName, bundleLion)



    '----------------------------------------------------------
    '-WITCH DOCTOR START-----------------------------
    '----------------------------------------------------------
    Dim bundleWitch_Doctor As New HeroBundle
    'FROM UNITBASE
    bundleWitch_Doctor.mIDItem = New dvID(New Guid("432f3dea-4833-42a0-a49c-8ab223df22e0"), "Herobundle: Witch Doctor", eEntity.Herobundle)
    bundleWitch_Doctor.mName = eHeroName.untWitch_Doctor
    bundleWitch_Doctor.DisplayName = "Witch Doctor"
    bundleWitch_Doctor.mArmorType = eArmorType.Hero
    bundleWitch_Doctor.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/witch_doctor_vert.jpg"
    bundleWitch_Doctor.mWebpageLink = "http://www.dota2.com/hero/Witch_Doctor/"

    bundleWitch_Doctor.mAttackType = eAttackType.Ranged
    bundleWitch_Doctor.mBaseHitpoints = 0
    bundleWitch_Doctor.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleWitch_Doctor.mBaseAttackDamage = New ValueWrapper(27, 37)

    bundleWitch_Doctor.mDaySightRange = 1800
    bundleWitch_Doctor.mNightSightRange = 800

    bundleWitch_Doctor.mAttackRange = 600
    bundleWitch_Doctor.mMissileSpeed = 1200

    bundleWitch_Doctor.mAbilityNames.Add(eAbilityName.abParalyzing_Cask)
    bundleWitch_Doctor.mAbilityNames.Add(eAbilityName.abVoodoo_Restoration)
    bundleWitch_Doctor.mAbilityNames.Add(eAbilityName.abMaledict)
    bundleWitch_Doctor.mAbilityNames.Add(eAbilityName.abDeath_Ward)



    'FROM HEROBASE
    'Fixed, immutable stats
    bundleWitch_Doctor.mDevName = "Witch_Doctor"

    bundleWitch_Doctor.mRoles.Add(eRole.Support)
    bundleWitch_Doctor.mRoles.Add(eRole.Disabler)

    bundleWitch_Doctor.mPrimaryStat = ePrimaryStat.Intelligence

    bundleWitch_Doctor.mBio = "A wiry silhouette hitches forward--uneven of feature and limb, bizarre of gait, relentlessly criss-crossing the battlefield in search of that vital weak point where his talents can do most good, and most harm. Whether broken or mismade it is not clear, but still, none can doubt the power carried in his twisted physique. A long staff thumps the earth as Zharvakko the Witch Doctor advances, deploying a terrifying arsenal of fetishes, hexes and spells. It is a body of magical knowledge learned and perfected over several lifetimes in the island highlands of Arktura, now wielded with precision accuracy against his enemies. Zharvakko can be your best friend or your worst enemy--healing allies and laying waste to all who oppose him. "

    bundleWitch_Doctor.mBaseStr = 16
    bundleWitch_Doctor.mStrIncrement = 1.8

    bundleWitch_Doctor.mBaseInt = 24
    bundleWitch_Doctor.mIntIncrement = 2.9

    bundleWitch_Doctor.mBaseAgi = 13
    bundleWitch_Doctor.mAgiIncrement = 1.4


    bundleWitch_Doctor.mBaseMoveSpeed = 305

    bundleWitch_Doctor.mBaseArmor = -1

    bundleWitch_Doctor.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleWitch_Doctor.mName, bundleWitch_Doctor)



    '----------------------------------------------------------
    '-ENIGMA START-----------------------------
    '----------------------------------------------------------
    Dim bundleEnigma As New HeroBundle
    'FROM UNITBASE
    bundleEnigma.mIDItem = New dvID(New Guid("3d1f1de4-c46a-4420-afb3-c5fd7ac628af"), "Herobundle: Enigma", eEntity.Herobundle)
    bundleEnigma.mName = eHeroName.untEnigma
    bundleEnigma.DisplayName = "Enigma"
    bundleEnigma.mArmorType = eArmorType.Hero
    bundleEnigma.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/enigma_vert.jpg"
    bundleEnigma.mWebpageLink = "http://www.dota2.com/hero/Enigma/"

    bundleEnigma.mAttackType = eAttackType.Ranged
    bundleEnigma.mBaseHitpoints = 0
    bundleEnigma.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleEnigma.mBaseAttackDamage = New ValueWrapper(22, 28)

    bundleEnigma.mDaySightRange = 1800
    bundleEnigma.mNightSightRange = 800

    bundleEnigma.mAttackRange = 500
    bundleEnigma.mMissileSpeed = 900

    bundleEnigma.mAbilityNames.Add(eAbilityName.abMalefice)
    bundleEnigma.mAbilityNames.Add(eAbilityName.abDemonic_Conversion)
    bundleEnigma.mAbilityNames.Add(eAbilityName.abMidnight_Pulse)
    bundleEnigma.mAbilityNames.Add(eAbilityName.abBlack_Hole)

    'FROM HEROBASE
    'Fixed, immutable stats
    bundleEnigma.mDevName = "Enigma"

    bundleEnigma.mRoles.Add(eRole.Disabler)
    bundleEnigma.mRoles.Add(eRole.Initiator)
    bundleEnigma.mRoles.Add(eRole.Jungler)
    bundleEnigma.mRoles.Add(eRole.Pusher)

    bundleEnigma.mPrimaryStat = ePrimaryStat.Intelligence

    bundleEnigma.mBio = "Nothing is known of Enigma's background. There are only stories and legends, most of them apocryphal, passed down through the ages. In truth, Enigma is a mystery for whom the only true biography is description: he is a universal force, a consumer of worlds. He is a being of the void, at times corporeal, other times ethereal. A beast between the planes.|There are stories that say he was once a great alchemist who tried to unlock the secrets of the universe and was cursed for his arrogance. Other legends tell that he is an ancient being of strange gravity, the abyss personified-a twisted voice from out the original darkness, before the first light in the universe. And there are older legends that say he is the first collapsed star, a black hole grown complicated and sentient-his motivations unknowable, his power inexorable, a force of destruction unleashed upon existence itself. "

    bundleEnigma.mBaseStr = 17
    bundleEnigma.mStrIncrement = 2.1

    bundleEnigma.mBaseInt = 20
    bundleEnigma.mIntIncrement = 3.4

    bundleEnigma.mBaseAgi = 14
    bundleEnigma.mAgiIncrement = 1


    bundleEnigma.mBaseMoveSpeed = 300
    bundleEnigma.mBaseArmor = 2


    bundleEnigma.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleEnigma.mName, bundleEnigma)



    '----------------------------------------------------------
    '-NECROPHOS START-----------------------------
    '----------------------------------------------------------
    Dim bundleNecrophos As New HeroBundle
    'FROM UNITBASE
    bundleNecrophos.mIDItem = New dvID(New Guid("5da58ff1-f89f-4d42-a8ab-fc05276e0625"), "Herobundle: Necrophos", eEntity.Herobundle)
    bundleNecrophos.mName = eHeroName.untNecrophos
    bundleNecrophos.DisplayName = "Necrophos"
    bundleNecrophos.mArmorType = eArmorType.Hero
    bundleNecrophos.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/necrolyte_vert.jpg"
    bundleNecrophos.mWebpageLink = "http://www.dota2.com/hero/Necrophos/"

    bundleNecrophos.mAttackType = eAttackType.Ranged
    bundleNecrophos.mBaseHitpoints = 0
    bundleNecrophos.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleNecrophos.mBaseAttackDamage = New ValueWrapper(22, 26)

    bundleNecrophos.mDaySightRange = 1800
    bundleNecrophos.mNightSightRange = 800

    bundleNecrophos.mAttackRange = 550
    bundleNecrophos.mMissileSpeed = 900


    bundleNecrophos.mAbilityNames.Add(eAbilityName.abDeath_Pulse)
    bundleNecrophos.mAbilityNames.Add(eAbilityName.abHeartstopper_Aura)
    bundleNecrophos.mAbilityNames.Add(eAbilityName.abSadist)
    bundleNecrophos.mAbilityNames.Add(eAbilityName.abReapers_Scythe)



    'FROM HEROBASE
    'Fixed, immutable stats
    bundleNecrophos.mDevName = "Necrophos"

    bundleNecrophos.mRoles.Add(eRole.Support)
    bundleNecrophos.mRoles.Add(eRole.Durable)
    bundleNecrophos.mRoles.Add(eRole.Carry)

    bundleNecrophos.mPrimaryStat = ePrimaryStat.Intelligence

    bundleNecrophos.mBio = "In a time of great plague, an obscure monk of dark inclinations, one Rotund'jere, found himself promoted to the rank of Cardinal by the swift death of all his superiors. While others of the order went out to succor the ill, the newly ordained cardinal secluded himself within the Cathedral of Rumusque, busily scheming to acquire the property of dying nobles, promising them spiritual rewards if they signed over their terrestrial domains. As the plague receded to a few stubborn pockets, his behavior came to the attention of the greater order, which found him guilty of heresy and sentenced him to serve in the plague ward, ensorcelled with spells that would ensure him a slow and lingering illness. But they had not counted on his natural immunity. Rotund'jere caught the pox, but instead of dying, found it feeding his power, transforming him into a veritable plague-mage, a Pope of Pestilence. Proclaiming himself Necrophos, he travels the world, spreading plague wherever he goes, and growing in terrible power with every village his pestilential presence obliterates. "

    bundleNecrophos.mBaseStr = 16
    bundleNecrophos.mStrIncrement = 2

    bundleNecrophos.mBaseInt = 22
    bundleNecrophos.mIntIncrement = 2.5

    bundleNecrophos.mBaseAgi = 15
    bundleNecrophos.mAgiIncrement = 1.7


    bundleNecrophos.mBaseMoveSpeed = 290
    bundleNecrophos.mBaseArmor = 0


    bundleNecrophos.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleNecrophos.mName, bundleNecrophos)



    '----------------------------------------------------------
    '-WARLOCK START-----------------------------
    '----------------------------------------------------------
    Dim bundleWarlock As New HeroBundle
    'FROM UNITBASE
    bundleWarlock.mIDItem = New dvID(New Guid("cd5b8024-1b0d-4608-9740-b14245ac8752"), "Herobundle: Warlock", eEntity.Herobundle)
    bundleWarlock.mName = eHeroName.untWarlock
    bundleWarlock.DisplayName = "Warlock"
    bundleWarlock.mArmorType = eArmorType.Hero
    bundleWarlock.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/warlock_vert.jpg"
    bundleWarlock.mWebpageLink = "http://www.dota2.com/hero/Warlock/"

    bundleWarlock.mAttackType = eAttackType.Ranged
    bundleWarlock.mBaseHitpoints = 0
    bundleWarlock.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleWarlock.mBaseAttackDamage = New ValueWrapper(22, 32)

    bundleWarlock.mDaySightRange = 1800
    bundleWarlock.mNightSightRange = 800

    bundleWarlock.mAttackRange = 600
    bundleWarlock.mMissileSpeed = 1200

    bundleWarlock.mAbilityNames.Add(eAbilityName.abFatal_Bonds)
    bundleWarlock.mAbilityNames.Add(eAbilityName.abShadow_Word)
    bundleWarlock.mAbilityNames.Add(eAbilityName.abUpheaval)
    bundleWarlock.mAbilityNames.Add(eAbilityName.abChaotic_Offering)

    'FROM HEROBASE
    'Fixed, immutable stats
    bundleWarlock.mDevName = "Warlock"

    bundleWarlock.mRoles.Add(eRole.Initiator)
    bundleWarlock.mRoles.Add(eRole.Support)
    bundleWarlock.mRoles.Add(eRole.LaneSupport)
    bundleWarlock.mRoles.Add(eRole.Disabler)

    bundleWarlock.mPrimaryStat = ePrimaryStat.Intelligence

    bundleWarlock.mBio = "As Chief Curator and Head of Acquisitions for the Arcane Archives of the Ultimyr Academy, Demnok Lannik was tireless in his pursuit of lost, rare and forbidden tomes. No cursed temple was so foreboding, no cavern path so treacherous, that any concern for his own survival could dissuade him from entering if rumors hinted that some pamphlet of primordial lore might still survive in its depths. However, so often did his investigations trigger the wrath of protector entities, that he finally found it necessary to master the arts of magic. He bent himself to learning sorcery with the same thorough obsessiveness that marked his quest for incunabula, becoming the most powerful Warlock of the Academy in less time than most practitioners required to complete a course of undergraduate work. Almost as an afterthought, he carved a staff of Dreadwood and summoned into it a captive spirit from the Outer Hells. And anticipating the day when he will have recovered every last lost spellbook, he has commenced writing his own Black Grimoire. It will undoubtedly be instructive. "

    bundleWarlock.mBaseStr = 18
    bundleWarlock.mStrIncrement = 2.5

    bundleWarlock.mBaseInt = 24
    bundleWarlock.mIntIncrement = 2.7

    bundleWarlock.mBaseAgi = 10
    bundleWarlock.mAgiIncrement = 1


    bundleWarlock.mBaseMoveSpeed = 295
    bundleWarlock.mBaseArmor = 1


    bundleWarlock.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleWarlock.mName, bundleWarlock)



    '----------------------------------------------------------
    '-QUEEN OF PAIN START-----------------------------
    '----------------------------------------------------------
    Dim bundleQueen_Of_Pain As New HeroBundle
    'FROM UNITBASE
    bundleQueen_Of_Pain.mIDItem = New dvID(New Guid("7a6cf431-5e9e-4548-b0e6-ed2a8282724c"), "Herobundle: Queen of Pain", eEntity.Herobundle)
    bundleQueen_Of_Pain.mName = eHeroName.untQueen_of_Pain
    bundleQueen_Of_Pain.DisplayName = "Queen of Pain"
    bundleQueen_Of_Pain.mArmorType = eArmorType.Hero
    bundleQueen_Of_Pain.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/queenofpain_vert.jpg"
    bundleQueen_Of_Pain.mWebpageLink = "http://www.dota2.com/hero/Queen_of_Pain/"

    bundleQueen_Of_Pain.mAttackType = eAttackType.Ranged
    bundleQueen_Of_Pain.mBaseHitpoints = 0
    bundleQueen_Of_Pain.mBaseAttackSpeed = 1.6 '  http://dota2.gamepedia.com/Attack_speed

    bundleQueen_Of_Pain.mBaseAttackDamage = New ValueWrapper(25, 33)

    bundleQueen_Of_Pain.mDaySightRange = 1800
    bundleQueen_Of_Pain.mNightSightRange = 800

    bundleQueen_Of_Pain.mAttackRange = 550
    bundleQueen_Of_Pain.mMissileSpeed = 1500

    bundleQueen_Of_Pain.mAbilityNames.Add(eAbilityName.abShadow_Strike)
    bundleQueen_Of_Pain.mAbilityNames.Add(eAbilityName.abQoP_Blink)
    bundleQueen_Of_Pain.mAbilityNames.Add(eAbilityName.abScream_Of_Pain)
    bundleQueen_Of_Pain.mAbilityNames.Add(eAbilityName.abSonic_Wave)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleQueen_Of_Pain.mDevName = "Queen_of_Pain"

    bundleQueen_Of_Pain.mRoles.Add(eRole.Nuker)
    bundleQueen_Of_Pain.mRoles.Add(eRole.Escape)
    bundleQueen_Of_Pain.mRoles.Add(eRole.Carry)

    bundleQueen_Of_Pain.mPrimaryStat = ePrimaryStat.Intelligence

    bundleQueen_Of_Pain.mBio = "The Ecclesiast-King of Elze nursed a desire for pain--forbidden pain. In a less prominent political figure, such desires might be considered unwise, but in a monarch of his stature, to satisfy such thirsts would have threatened the virtue of the Divine Throne itself. Therefore he turned to his dungeon full of demonologists, promising freedom to whoever could summon a personal succubus of torment and bind it entirely to his service. The creature who arrived, Akasha by name, visited upon him such exquisite torments that he named her his Secret Queen, and he began to spend all his spare moments submitting to her clever torments--eventually abdicating all his responsibilities in his pursuit of the painful pleasures that only she could bring. Queen of Pain could bring him to the brink of death, but she was rune-bound to keep him alive. At last the King's neglect of state brought on an uprising. He was dragged from his chamber and hurled from the Tower of Invocations, and at the moment of death, Queen of Pain was let loose into the world, freed from servitude--freed to visit her sufferings on anyone she deigned to notice. "

    bundleQueen_Of_Pain.mBaseStr = 16
    bundleQueen_Of_Pain.mStrIncrement = 1.7

    bundleQueen_Of_Pain.mBaseInt = 24
    bundleQueen_Of_Pain.mIntIncrement = 2.5

    bundleQueen_Of_Pain.mBaseAgi = 18
    bundleQueen_Of_Pain.mAgiIncrement = 2


    bundleQueen_Of_Pain.mBaseMoveSpeed = 300

    bundleQueen_Of_Pain.mBaseArmor = -1

    bundleQueen_Of_Pain.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleQueen_Of_Pain.mName, bundleQueen_Of_Pain)



    '----------------------------------------------------------
    '-DEATH PROPHET START-----------------------------
    '----------------------------------------------------------
    Dim bundleDeath_Prophet As New HeroBundle
    'FROM UNITBASE
    bundleDeath_Prophet.mIDItem = New dvID(New Guid("9c014d9d-cc3a-4bb7-875f-659b7b1ae1f8"), "Herobundle: Death Prophet", eEntity.Herobundle)
    bundleDeath_Prophet.mName = eHeroName.untDeath_Prophet
    bundleDeath_Prophet.DisplayName = "Death Prophet"
    bundleDeath_Prophet.mArmorType = eArmorType.Hero
    bundleDeath_Prophet.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/death_prophet_vert.jpg"
    bundleDeath_Prophet.mWebpageLink = "http://www.dota2.com/hero/Death_Prophet/"

    bundleDeath_Prophet.mAttackType = eAttackType.Ranged
    bundleDeath_Prophet.mBaseHitpoints = 0
    bundleDeath_Prophet.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleDeath_Prophet.mBaseAttackDamage = New ValueWrapper(24, 36)

    bundleDeath_Prophet.mDaySightRange = 1800
    bundleDeath_Prophet.mNightSightRange = 800

    bundleDeath_Prophet.mAttackRange = 600
    bundleDeath_Prophet.mMissileSpeed = 1000


    bundleDeath_Prophet.mAbilityNames.Add(eAbilityName.abCrypt_Swarm)
    bundleDeath_Prophet.mAbilityNames.Add(eAbilityName.abSilence)
    bundleDeath_Prophet.mAbilityNames.Add(eAbilityName.abWitchcraft)
    bundleDeath_Prophet.mAbilityNames.Add(eAbilityName.abExorcism)

    'FROM HEROBASE
    'Fixed, immutable stats
    bundleDeath_Prophet.mDevName = "Death_Prophet"

    bundleDeath_Prophet.mRoles.Add(eRole.Pusher)
    bundleDeath_Prophet.mRoles.Add(eRole.Nuker)
    bundleDeath_Prophet.mRoles.Add(eRole.Durable)

    bundleDeath_Prophet.mPrimaryStat = ePrimaryStat.Intelligence

    bundleDeath_Prophet.mBio = "Krobelus was a Death Prophet-which is one way of saying she told fortunes for the wealthiest of those who wished to look beyond the veil. But after years of inquiring on behalf of others, she began to seek clues on her own fate. When death refused to yield its secrets, she tried to buy them with her life. But the ultimate price proved insufficient. Death disgorged her again and again, always holding back its deepest mysteries. Her jealousy grew. Others could die for eternity--why not she? Why must she alone be cast back on the shores of life with such tiresome regularity? Why was she not worthy of the one thing all other living creatures took for granted? Still, she would not be discouraged. Each time she returned from the grave, she brought a bit of death back with her. Wraiths followed her like fragments of her shattered soul; her blood grew thin and ectoplasmic; the feasting creatures of twilight took her for their kin.. She gave a little of her life with every demise, and it began to seem as if her end was in sight. With her dedication to death redoubled, and no client other than herself, Krobelus threw herself ever more fervently into death's abyss, intent on fulfilling the one prophecy that eluded her: That someday the Death Prophet would return from death no more. "

    bundleDeath_Prophet.mBaseStr = 19
    bundleDeath_Prophet.mStrIncrement = 2.2

    bundleDeath_Prophet.mBaseInt = 20
    bundleDeath_Prophet.mIntIncrement = 3

    bundleDeath_Prophet.mBaseAgi = 14
    bundleDeath_Prophet.mAgiIncrement = 1.4


    bundleDeath_Prophet.mBaseMoveSpeed = 280
    bundleDeath_Prophet.mBaseArmor = 1


    bundleDeath_Prophet.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleDeath_Prophet.mName, bundleDeath_Prophet)



    '----------------------------------------------------------
    '-PUGNA START-----------------------------
    '----------------------------------------------------------
    Dim bundlePugna As New HeroBundle
    'FROM UNITBASE
    bundlePugna.mIDItem = New dvID(New Guid("3262d8ec-ce62-46c9-a9fb-bc1644bf1ade"), "Herobundle: Pugna", eEntity.Herobundle)
    bundlePugna.mName = eHeroName.untPugna
    bundlePugna.DisplayName = "Pugna"
    bundlePugna.mArmorType = eArmorType.Hero
    bundlePugna.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/pugna_vert.jpg"
    bundlePugna.mWebpageLink = "http://www.dota2.com/hero/Pugna/"

    bundlePugna.mAttackType = eAttackType.Ranged
    bundlePugna.mBaseHitpoints = 0
    bundlePugna.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundlePugna.mBaseAttackDamage = New ValueWrapper(19, 27)

    bundlePugna.mDaySightRange = 1800
    bundlePugna.mNightSightRange = 800

    bundlePugna.mAttackRange = 600
    bundlePugna.mMissileSpeed = 900

    bundlePugna.mAbilityNames.Add(eAbilityName.abNether_Blast)
    bundlePugna.mAbilityNames.Add(eAbilityName.abDecrepify)
    bundlePugna.mAbilityNames.Add(eAbilityName.abNether_Ward)
    bundlePugna.mAbilityNames.Add(eAbilityName.abLife_Drain)

    'FROM HEROBASE
    'Fixed, immutable stats
    bundlePugna.mDevName = "Pugna"

    bundlePugna.mRoles.Add(eRole.Nuker)
    bundlePugna.mRoles.Add(eRole.Pusher)
    bundlePugna.mRoles.Add(eRole.Support)

    bundlePugna.mPrimaryStat = ePrimaryStat.Intelligence

    bundlePugna.mBio = "In the realm of Pugna's birth, near the vents of the Nether Reaches, there stood a lamasery devoted to the Arts of Oblivion, which drew its power from the nether energies. The Grandmaster of the temple compound had himself passed into Oblivion several years prior, leaving his academy without a leader. From the moment of their master's death, the regents of the temple began rites of divination to identify their master's reincarnation, and eventually all signs converged on the immediate neighborhood. Several villages squatted in the shadow of the temple, their alleys and plazas full of the laughter of squalling children. Pugna, a mere thirteen months of age, was but one candidate among the local brats, and on the appointed day he was presented at the temple alongside two other promising tots. The lamas offered a jumble of worn relics to the children, treasured possessions of their former grandmaster. One boy reached for a porphyry wand that had belonged to the lama...and put it in his nostril. An impish girl pulled out an amulet that had also been the lama's, and immediately swallowed it. Pugna regarded the other two coolly, gave a merry laugh, and blasted them with gouts of emerald flame, reducing them to ashes in an instant. He then snatched up the wand and amulet, saying 'Mine!' The regents hoisted the beaming Pugna on their shoulders, wrapped him in their grandmaster's vestments, and rushed him to the throne before his mood could change. Within five years, the temple itself was another pile of ash, which pleased Pugna to no end. "

    bundlePugna.mBaseStr = 17
    bundlePugna.mStrIncrement = 1.2

    bundlePugna.mBaseInt = 26
    bundlePugna.mIntIncrement = 4

    bundlePugna.mBaseAgi = 16
    bundlePugna.mAgiIncrement = 1


    bundlePugna.mBaseMoveSpeed = 320

    bundlePugna.mBaseArmor = -1

    bundlePugna.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundlePugna.mName, bundlePugna)



    '----------------------------------------------------------
    '-DAZZLE START-----------------------------
    '----------------------------------------------------------
    Dim bundleDazzle As New HeroBundle
    'FROM UNITBASE
    bundleDazzle.mIDItem = New dvID(New Guid("820a778b-a9cd-4de2-8b22-134cfb66cb35"), "Herobundle: Dazzle", eEntity.Herobundle)
    bundleDazzle.mName = eHeroName.untDazzle
    bundleDazzle.DisplayName = "Dazzle"
    bundleDazzle.mArmorType = eArmorType.Hero
    bundleDazzle.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/dazzle_vert.jpg"
    bundleDazzle.mWebpageLink = "http://www.dota2.com/hero/Dazzle/"

    bundleDazzle.mAttackType = eAttackType.Ranged
    bundleDazzle.mBaseHitpoints = 0
    bundleDazzle.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleDazzle.mBaseAttackDamage = New ValueWrapper(14, 32)

    bundleDazzle.mDaySightRange = 1800
    bundleDazzle.mNightSightRange = 800

    bundleDazzle.mAttackRange = 500
    bundleDazzle.mMissileSpeed = 1200


    bundleDazzle.mAbilityNames.Add(eAbilityName.abPoison_Touch)
    bundleDazzle.mAbilityNames.Add(eAbilityName.abShallow_Grave)
    bundleDazzle.mAbilityNames.Add(eAbilityName.abShadow_Wave)
    bundleDazzle.mAbilityNames.Add(eAbilityName.abWeave)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleDazzle.mDevName = "Dazzle"

    bundleDazzle.mRoles.Add(eRole.Support)
    bundleDazzle.mRoles.Add(eRole.LaneSupport)

    bundleDazzle.mPrimaryStat = ePrimaryStat.Intelligence

    bundleDazzle.mBio = "Each young acolyte to the Dezun order must complete a series of rites before becoming a shadow priest. The final rite, the rite of shades, is a harrowing spiritual journey through the Nothl Realm, an unpredictable domain from which not all visitants return. Of those who do, some return mad. Others return with strange aptitudes. But all who go there are changed by their experiences. Driven by the need for enlightenment, Dazzle was the youngest of his tribe ever to request the sacred ritual. At first the order refused him, saying he was too young. But Dazzle was not to be dissuaded. Sensing something special in the headstrong young acolyte, the elders relented. Dazzle drank down the sacred potion and sat by the fire while the rest of his tribe danced through the night. In this ethereal dimension of the Nothl Realm, the properties of light and dark are inverted. Thus his brilliant healing light, beautiful to our eye, is actually a sinister kind of evil; and the darkest deeds are done in a dazzling glow. The elders' intuition was prophetic: Dazzle returned to his people as a Shadow Priest like none seen before, with the power to heal as well as to destroy. Now he uses his gift to cut down his enemies and mend his friends. "

    bundleDazzle.mBaseStr = 16
    bundleDazzle.mStrIncrement = 1.85

    bundleDazzle.mBaseInt = 27
    bundleDazzle.mIntIncrement = 3.4

    bundleDazzle.mBaseAgi = 21
    bundleDazzle.mAgiIncrement = 1.7


    bundleDazzle.mBaseMoveSpeed = 305

    bundleDazzle.mBaseArmor = -1

    bundleDazzle.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleDazzle.mName, bundleDazzle)



    '----------------------------------------------------------
    '-LESHRAC START-----------------------------
    '----------------------------------------------------------
    Dim bundleLeshrac As New HeroBundle
    'FROM UNITBASE
    bundleLeshrac.mIDItem = New dvID(New Guid("6646b83e-2cf1-4399-be1a-17beb1fb6e0b"), "Herobundle: Leshrac", eEntity.Herobundle)
    bundleLeshrac.mName = eHeroName.untLeshrac
    bundleLeshrac.DisplayName = "Leshrac"
    bundleLeshrac.mArmorType = eArmorType.Hero
    bundleLeshrac.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/leshrac_vert.jpg"
    bundleLeshrac.mWebpageLink = "http://www.dota2.com/hero/Leshrac/"

    bundleLeshrac.mAttackType = eAttackType.Ranged
    bundleLeshrac.mBaseHitpoints = 0
    bundleLeshrac.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleLeshrac.mBaseAttackDamage = New ValueWrapper(19, 23)

    bundleLeshrac.mDaySightRange = 1800
    bundleLeshrac.mNightSightRange = 800

    bundleLeshrac.mAttackRange = 600
    bundleLeshrac.mMissileSpeed = 900

    bundleLeshrac.mAbilityNames.Add(eAbilityName.abSplit_Earth)
    bundleLeshrac.mAbilityNames.Add(eAbilityName.abDiabolic_Edict)
    bundleLeshrac.mAbilityNames.Add(eAbilityName.abLightning_Storm)
    bundleLeshrac.mAbilityNames.Add(eAbilityName.abPulse_Nova)



    'FROM HEROBASE
    'Fixed, immutable stats
    bundleLeshrac.mDevName = "Leshrac"

    bundleLeshrac.mRoles.Add(eRole.Nuker)
    bundleLeshrac.mRoles.Add(eRole.Pusher)
    bundleLeshrac.mRoles.Add(eRole.Disabler)
    bundleLeshrac.mRoles.Add(eRole.Support)

    bundleLeshrac.mPrimaryStat = ePrimaryStat.Intelligence

    bundleLeshrac.mBio = "Leshrac, Tormented Soul, is an entity torn from the heart of nature, a liminal being that exists half in one plane of existence, half in another. His penetrating intelligence is such that he can never ignore for a moment the agonizing horror at the heart of all creation. Once a great philosopher who sought the meaning of existence, he plumbed the depths of nature with the haunted Chronoptic Crystals, and was forever altered by the hideous mysteries thereby revealed to him. Now the darkest depths of his enlightenment are illumined only by the fitful glare of his arrogance. Like other elemental characters, he is completely at one with nature, but in his case it is a nature lurid and vile. He alone sees the evil truth of reality, and has no use for those who believe the cosmos reserves a special reward for those who practice benevolence. "

    bundleLeshrac.mBaseStr = 16
    bundleLeshrac.mStrIncrement = 1.5

    bundleLeshrac.mBaseInt = 26
    bundleLeshrac.mIntIncrement = 3

    bundleLeshrac.mBaseAgi = 23
    bundleLeshrac.mAgiIncrement = 1.7


    bundleLeshrac.mBaseMoveSpeed = 315
    bundleLeshrac.mBaseArmor = 0


    bundleLeshrac.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleLeshrac.mName, bundleLeshrac)



    '----------------------------------------------------------
    '-DARK SEER START-----------------------------
    '----------------------------------------------------------
    Dim bundleDark_Seer As New HeroBundle
    'FROM UNITBASE
    bundleDark_Seer.mIDItem = New dvID(New Guid("d8b2e05f-cfd5-4d74-9a5f-4bc2ad311bff"), "Herobundle: Dark Seer", eEntity.Herobundle)
    bundleDark_Seer.mName = eHeroName.untDark_Seer
    bundleDark_Seer.DisplayName = "Dark Seer"
    bundleDark_Seer.mArmorType = eArmorType.Hero
    bundleDark_Seer.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/dark_seer_vert.jpg"
    bundleDark_Seer.mWebpageLink = "http://www.dota2.com/hero/Dark_Seer/"

    bundleDark_Seer.mAttackType = eAttackType.Melee
    bundleDark_Seer.mBaseHitpoints = 0
    bundleDark_Seer.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleDark_Seer.mBaseAttackDamage = New ValueWrapper(31, 37)

    bundleDark_Seer.mDaySightRange = 1800
    bundleDark_Seer.mNightSightRange = 800

    bundleDark_Seer.mAttackRange = 128
    bundleDark_Seer.mMissileSpeed = Nothing

    bundleDark_Seer.mAbilityNames.Add(eAbilityName.abVacuum)
    bundleDark_Seer.mAbilityNames.Add(eAbilityName.abIon_Shell)
    bundleDark_Seer.mAbilityNames.Add(eAbilityName.abSurge)
    bundleDark_Seer.mAbilityNames.Add(eAbilityName.abWall_Of_Replica)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleDark_Seer.mDevName = "Dark_Seer"

    bundleDark_Seer.mRoles.Add(eRole.Initiator)
    bundleDark_Seer.mRoles.Add(eRole.Nuker)
    bundleDark_Seer.mRoles.Add(eRole.Escape)

    bundleDark_Seer.mPrimaryStat = ePrimaryStat.Intelligence

    bundleDark_Seer.mBio = "Fast when he needs to be, and a cunning strategist, Ish'Kafel the Dark Seer requires no edged weapons to vanquish his enemies, relying instead on the strength of his powerful mind. His talent lies in his ability to maneuver the fight to his advantage. Hailing from a place he calls 'The Land behind the wall,' Dark Seer remains an outsider here-a warrior from a realm beyond the veil of this reality.|Once a great general among his people, and a valiant defender of the god-king Damathryx, Dark Seer's army was wiped out by a much larger force in the final days of the Great Boundaries War. Facing certain defeat, he made one last desperate act: he led the enemy forces into the maze between the walls. At the last moment, just before capture, he crossed over-then sealed the walls forever in an explosive release of dark energy. When the dust settled, he saw that he had saved his people but found himself blinking at the sun of a different world, with no way to return. Now he is committed to proving his worth as a military strategist, and vows to show that he's the greatest tactician this strange new world has ever seen. "

    bundleDark_Seer.mBaseStr = 22
    bundleDark_Seer.mStrIncrement = 2.3

    bundleDark_Seer.mBaseInt = 29
    bundleDark_Seer.mIntIncrement = 2.7

    bundleDark_Seer.mBaseAgi = 12
    bundleDark_Seer.mAgiIncrement = 1.2


    bundleDark_Seer.mBaseMoveSpeed = 300
    bundleDark_Seer.mBaseArmor = 5


    bundleDark_Seer.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleDark_Seer.mName, bundleDark_Seer)



    '----------------------------------------------------------
    '-BATRIDER START-----------------------------
    '----------------------------------------------------------
    Dim bundleBatrider As New HeroBundle
    'FROM UNITBASE
    bundleBatrider.mIDItem = New dvID(New Guid("73bb88b5-3e30-42a8-b06c-fe3d92b61f31"), "Herobundle: Batrider", eEntity.Herobundle)
    bundleBatrider.mName = eHeroName.untBatrider
    bundleBatrider.DisplayName = "Batrider"
    bundleBatrider.mArmorType = eArmorType.Hero
    bundleBatrider.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/batrider_vert.jpg"
    bundleBatrider.mWebpageLink = "http://www.dota2.com/hero/Batrider/"

    bundleBatrider.mAttackType = eAttackType.Ranged
    bundleBatrider.mBaseHitpoints = 0
    bundleBatrider.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleBatrider.mBaseAttackDamage = New ValueWrapper(14, 18)

    bundleBatrider.mDaySightRange = 1200
    bundleBatrider.mNightSightRange = 800

    bundleBatrider.mAttackRange = 375
    bundleBatrider.mMissileSpeed = 900

    bundleBatrider.mAbilityNames.Add(eAbilityName.abSticky_Napalm)
    bundleBatrider.mAbilityNames.Add(eAbilityName.abFlamebreak)
    bundleBatrider.mAbilityNames.Add(eAbilityName.abFirefly)
    bundleBatrider.mAbilityNames.Add(eAbilityName.abFlaming_Lasso)



    'FROM HEROBASE
    'Fixed, immutable stats
    bundleBatrider.mDevName = "Batrider"

    bundleBatrider.mRoles.Add(eRole.Initiator)
    bundleBatrider.mRoles.Add(eRole.Disabler)
    bundleBatrider.mRoles.Add(eRole.Nuker)
    bundleBatrider.mRoles.Add(eRole.Escape)

    bundleBatrider.mPrimaryStat = ePrimaryStat.Intelligence

    bundleBatrider.mBio = "There is no such thing as harmony among the creatures of the Yama Raskav Jungle. By bite, or claw, or pincer, or hoof, even the slightest sign of weakness means a swift death. They say the Rider was just a lad cutting chaff in his family's field when he was taken, swept up by a massive morde-bat looking for take-out. But this boy had a better idea, and wriggled his way from his captor's grip, onto the beast's back, and hacked it down with his tools. Emerging from the bloody wreckage and intoxicated by the thrill of flight, the boy realized he'd found his calling. The boy grew, and every summer he'd return to his family's field, often setting out into the bush seeking to reclaim that first thrill of facing death in the form of jaws or a fatal fall. The years went on, but his fire only grew stronger. He studied the overgrowth, plunging deeper with each expedition, until finally he found his way to the caves at the heart of hostility. They say the Rider, on the eve of a scorching summer night, had nothing but a rope, a bottle of liquid courage and a burning determination to feel the skies once more, when he plunged inside... "

    bundleBatrider.mBaseStr = 23
    bundleBatrider.mStrIncrement = 2.4

    bundleBatrider.mBaseInt = 24
    bundleBatrider.mIntIncrement = 2.5

    bundleBatrider.mBaseAgi = 15
    bundleBatrider.mAgiIncrement = 1.5


    bundleBatrider.mBaseMoveSpeed = 290
    bundleBatrider.mBaseArmor = 0


    bundleBatrider.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleBatrider.mName, bundleBatrider)



    '----------------------------------------------------------
    '-ANCIENT APPARITION START-----------------------------
    '----------------------------------------------------------
    Dim bundleAncient_Apparition As New HeroBundle
    'FROM UNITBASE
    bundleAncient_Apparition.mIDItem = New dvID(New Guid("73897e7a-f963-41f6-90b4-e58e9286c247"), "Herobundle: Ancient Apparition", eEntity.Herobundle)
    bundleAncient_Apparition.mName = eHeroName.untAncient_Apparition
    bundleAncient_Apparition.DisplayName = "Ancient Apparition"
    bundleAncient_Apparition.mArmorType = eArmorType.Hero
    bundleAncient_Apparition.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/ancient_apparition_vert.jpg"
    bundleAncient_Apparition.mWebpageLink = "http://www.dota2.com/hero/Ancient_Apparition/"

    bundleAncient_Apparition.mAttackType = eAttackType.Ranged
    bundleAncient_Apparition.mBaseHitpoints = 0
    bundleAncient_Apparition.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleAncient_Apparition.mBaseAttackDamage = New ValueWrapper(19, 29)

    bundleAncient_Apparition.mDaySightRange = 1800
    bundleAncient_Apparition.mNightSightRange = 800

    bundleAncient_Apparition.mAttackRange = 600
    bundleAncient_Apparition.mMissileSpeed = 1250

    bundleAncient_Apparition.mAbilityNames.Add(eAbilityName.abCold_Feet)
    bundleAncient_Apparition.mAbilityNames.Add(eAbilityName.abIce_Vortex)
    bundleAncient_Apparition.mAbilityNames.Add(eAbilityName.abChilling_Touch)
    bundleAncient_Apparition.mAbilityNames.Add(eAbilityName.abIce_Blast)

    'bundleAncient_Apparition.mAbilityNames.Add(eAbilityName.abRelease)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleAncient_Apparition.mDevName = "Ancient_Apparition"

    bundleAncient_Apparition.mRoles.Add(eRole.Support)
    bundleAncient_Apparition.mRoles.Add(eRole.Disabler)

    bundleAncient_Apparition.mPrimaryStat = ePrimaryStat.Intelligence

    bundleAncient_Apparition.mBio = "Kaldr, the Ancient Apparition, is an image projected from outside time. He springs from the cold, infinite void that both predates the universe and awaits its end. Kaldr is, Kaldr was, Kaldr shall be...and what we perceive, powerful as it appears to us, is but the faintest faded echo of the true, eternal Kaldr. Some believe that as the cosmos ages and approaches its final moments, the brightness and power of Kaldr will also intensify--that the Ancient Apparition will grow younger and stronger as eternity's end draws nigh. His grip of ice will bring all matter to a stop, his image will cast a light too terrible to behold. An Apparition no longer! "

    bundleAncient_Apparition.mBaseStr = 18
    bundleAncient_Apparition.mStrIncrement = 1.4

    bundleAncient_Apparition.mBaseInt = 25
    bundleAncient_Apparition.mIntIncrement = 2.6

    bundleAncient_Apparition.mBaseAgi = 20
    bundleAncient_Apparition.mAgiIncrement = 2.2


    bundleAncient_Apparition.mBaseMoveSpeed = 295

    bundleAncient_Apparition.mBaseArmor = -1

    bundleAncient_Apparition.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleAncient_Apparition.mName, bundleAncient_Apparition)



    '----------------------------------------------------------
    '-INVOKER START-----------------------------
    '----------------------------------------------------------
    Dim bundleInvoker As New HeroBundle
    'FROM UNITBASE
    bundleInvoker.mIDItem = New dvID(New Guid("c8763abb-5543-4503-8585-0440979d925e"), "Herobundle: Invoker", eEntity.Herobundle)
    bundleInvoker.mName = eHeroName.untInvoker
    bundleInvoker.DisplayName = "Invoker"
    bundleInvoker.mArmorType = eArmorType.Hero
    bundleInvoker.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/invoker_vert.jpg"
    bundleInvoker.mWebpageLink = "http://www.dota2.com/hero/Invoker/"

    bundleInvoker.mAttackType = eAttackType.Ranged
    bundleInvoker.mBaseHitpoints = 0
    bundleInvoker.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleInvoker.mBaseAttackDamage = New ValueWrapper(13, 19)

    bundleInvoker.mDaySightRange = 1800
    bundleInvoker.mNightSightRange = 800

    bundleInvoker.mAttackRange = 600
    bundleInvoker.mMissileSpeed = 900


    bundleInvoker.mAbilityNames.Add(eAbilityName.abQuas)
    bundleInvoker.mAbilityNames.Add(eAbilityName.abWex)
    bundleInvoker.mAbilityNames.Add(eAbilityName.abExort)
    bundleInvoker.mAbilityNames.Add(eAbilityName.abInvoke)
    'bundleInvoker.mAbilityNames.Add(eAbilityName.abCold_Snap)
    'bundleInvoker.mAbilityNames.Add(eAbilityName.abGhost_Walk)
    'bundleInvoker.mAbilityNames.Add(eAbilityName.abTornado)
    'bundleInvoker.mAbilityNames.Add(eAbilityName.abEmp)
    'bundleInvoker.mAbilityNames.Add(eAbilityName.abAlacrity)
    'bundleInvoker.mAbilityNames.Add(eAbilityName.abChaos_Meteor)
    'bundleInvoker.mAbilityNames.Add(eAbilityName.abSun_Strike)
    'bundleInvoker.mAbilityNames.Add(eAbilityName.abForge_Spirit)
    'bundleInvoker.mAbilityNames.Add(eAbilityName.abIce_Wall)
    'bundleInvoker.mAbilityNames.Add(eAbilityName.abDeafening_Blast)












    'FROM HEROBASE
    'Fixed, immutable stats
    bundleInvoker.mDevName = "Invoker"

    bundleInvoker.mRoles.Add(eRole.Carry)
    bundleInvoker.mRoles.Add(eRole.Nuker)
    bundleInvoker.mRoles.Add(eRole.Initiator)
    bundleInvoker.mRoles.Add(eRole.Escape)

    bundleInvoker.mPrimaryStat = ePrimaryStat.Intelligence

    bundleInvoker.mBio = "In its earliest, and some would say most potent form, magic was primarily the art of memory. It required no technology, no wands or appurtenances other than the mind of the magician. All the trappings of ritual were merely mnemonic devices, meant to allow the practitioner to recall in rich detail the specific mental formulae that unlocked a spell's power. The greatest mages in those days were the ones blessed with the greatest memories, and yet so complex were the invocations that all wizards were forced to specialize. The most devoted might hope in a lifetime to have adequate recollection of three spells--four at most. Ordinary wizards were content to know two, and it was not uncommon for a village mage to know only one--with even that requiring him to consult grimoires as an aid against forgetfulness on the rare occasions when he might be called to use it. But among these early practitioners there was one exception, a genius of vast intellect and prodigious memory who came to be known as the Invoker. In his youth, the precocious wizard mastered not four, not five, not even seven incantations: He could command no fewer than ten spells, and cast them instantly. Many more he learned but found useless, and would practice once then purge from his mind forever, to make room for more practical invocations. One such spell was the Sempiternal Cantrap--a longevity spell of such power that those who cast it in the world's first days are among us still (unless they have been crushed to atoms). Most of these quasi-immortals live quietly, afraid to admit their secret: But Invoker is not one to keep his gifts hidden. He is ancient, learned beyond all others, and his mind somehow still has space to contain an immense sense of his own worth...as well as the Invocations with which he amuses himself through the long slow twilight of the world's dying days. "

    bundleInvoker.mBaseStr = 19
    bundleInvoker.mStrIncrement = 1.7

    bundleInvoker.mBaseInt = 22
    bundleInvoker.mIntIncrement = 2.5

    bundleInvoker.mBaseAgi = 20
    bundleInvoker.mAgiIncrement = 1.9


    bundleInvoker.mBaseMoveSpeed = 280

    bundleInvoker.mBaseArmor = -1

    bundleInvoker.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleInvoker.mName, bundleInvoker)



    '----------------------------------------------------------
    '-OUTWORLD DEVOURER START-----------------------------
    '----------------------------------------------------------
    Dim bundleOutworld_Devourer As New HeroBundle
    'FROM UNITBASE
    bundleOutworld_Devourer.mIDItem = New dvID(New Guid("64cd438f-fbcd-4773-9a93-55809ad75a80"), "Herobundle: Outworld Devourer", eEntity.Herobundle)
    bundleOutworld_Devourer.mName = eHeroName.untOutworld_Devourer
    bundleOutworld_Devourer.DisplayName = "Outworld Devourer"
    bundleOutworld_Devourer.mArmorType = eArmorType.Hero
    bundleOutworld_Devourer.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/obsidian_destroyer_vert.jpg"
    bundleOutworld_Devourer.mWebpageLink = "http://www.dota2.com/hero/Outworld_Devourer/"

    bundleOutworld_Devourer.mAttackType = eAttackType.Ranged
    bundleOutworld_Devourer.mBaseHitpoints = 0
    bundleOutworld_Devourer.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleOutworld_Devourer.mBaseAttackDamage = New ValueWrapper(20, 35)

    bundleOutworld_Devourer.mDaySightRange = 1800
    bundleOutworld_Devourer.mNightSightRange = 800

    bundleOutworld_Devourer.mAttackRange = 450
    bundleOutworld_Devourer.mMissileSpeed = 900


    bundleOutworld_Devourer.mAbilityNames.Add(eAbilityName.abArcane_Orb)
    bundleOutworld_Devourer.mAbilityNames.Add(eAbilityName.abAstral_Imprisonment)
    bundleOutworld_Devourer.mAbilityNames.Add(eAbilityName.abEssence_Aura)
    bundleOutworld_Devourer.mAbilityNames.Add(eAbilityName.abSanitys_Eclipse)


    'FROM HEROBASE
    'Fixed, immutable stats
    bundleOutworld_Devourer.mDevName = "Outworld_Devourer"

    bundleOutworld_Devourer.mRoles.Add(eRole.Carry)

    bundleOutworld_Devourer.mPrimaryStat = ePrimaryStat.Intelligence

    bundleOutworld_Devourer.mBio = "One of a lordly and magisterial race, Harbinger prowls the edge of the Void, sole surviving sentry of an outpost on the world at the rim of the abyss. From this jagged crystalline Outworld, forever on guard, he has gazed for eternities into the heavens, alert for any stirring in the bottomless night beyond the stars. Imprinted deep in the shining lattices of his intellect lies a resonant pattern akin to prophecy, a dark music implying that eventually some evil will wake out there, beyond the edges of creation, and turn its attention to our world. With his whole being focused on his vigil, Outworld Devourer paid little attention to events closer in to the sun. But at last the clamor of the Ancients, and a sense of growing threat from within as well as without, sent him winging sunward to visit the plains of war. Harbinger's place in our own prophecies is unambiguous: he must be considered an omen of worse things to come. But his arrival in itself is bad enough. "

    bundleOutworld_Devourer.mBaseStr = 19
    bundleOutworld_Devourer.mStrIncrement = 1.85

    bundleOutworld_Devourer.mBaseInt = 26
    bundleOutworld_Devourer.mIntIncrement = 3.3

    bundleOutworld_Devourer.mBaseAgi = 24
    bundleOutworld_Devourer.mAgiIncrement = 2


    bundleOutworld_Devourer.mBaseMoveSpeed = 315
    bundleOutworld_Devourer.mBaseArmor = 2


    bundleOutworld_Devourer.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleOutworld_Devourer.mName, bundleOutworld_Devourer)



    '----------------------------------------------------------
    '-SHADOW DEMON START-----------------------------
    '----------------------------------------------------------
    Dim bundleShadow_Demon As New HeroBundle
    'FROM UNITBASE
    bundleShadow_Demon.mIDItem = New dvID(New Guid("1e383e4d-180a-4853-aea4-5f3b3f7e4cbe"), "Herobundle: Shadow Demon", eEntity.Herobundle)
    bundleShadow_Demon.mName = eHeroName.untShadow_Demon
    bundleShadow_Demon.DisplayName = "Shadow Demon"
    bundleShadow_Demon.mArmorType = eArmorType.Hero
    bundleShadow_Demon.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/shadow_demon_vert.jpg"
    bundleShadow_Demon.mWebpageLink = "http://www.dota2.com/hero/Shadow_Demon/"

    bundleShadow_Demon.mAttackType = eAttackType.Ranged
    bundleShadow_Demon.mBaseHitpoints = 0
    bundleShadow_Demon.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleShadow_Demon.mBaseAttackDamage = New ValueWrapper(27, 31)

    bundleShadow_Demon.mDaySightRange = 1800
    bundleShadow_Demon.mNightSightRange = 800

    bundleShadow_Demon.mAttackRange = 500
    bundleShadow_Demon.mMissileSpeed = 900

    bundleShadow_Demon.mAbilityNames.Add(eAbilityName.abDisruption)
    bundleShadow_Demon.mAbilityNames.Add(eAbilityName.abSoul_Catcher)
    bundleShadow_Demon.mAbilityNames.Add(eAbilityName.abShadow_Poison)
    bundleShadow_Demon.mAbilityNames.Add(eAbilityName.abDemonic_Purge)


    'bundleShadow_Demon.mAbilityNames.Add(eAbilityName.abShadow_Poison_Release)



    'FROM HEROBASE
    'Fixed, immutable stats
    bundleShadow_Demon.mDevName = "Shadow_Demon"

    bundleShadow_Demon.mRoles.Add(eRole.Support)
    bundleShadow_Demon.mRoles.Add(eRole.Disabler)
    bundleShadow_Demon.mRoles.Add(eRole.Nuker)

    bundleShadow_Demon.mPrimaryStat = ePrimaryStat.Intelligence

    bundleShadow_Demon.mBio = "Among the sovereign Demons with explicit access to this world, Doom scarcely bothers with the affairs of Noninfernals and Lesser Spectral Consorts, while Shadow Fiend passes through almost exclusively on collecting expeditions. The Shadow Demon, however, has always taken a deep and abiding interest in the material plane, as if sensing that mastery of this gritty dimensional nexus might be the key to total domination of all realities. Summoned first by minor wizards, the Shadow Demon granted every wish and put on increasingly impressive displays of power until he had the full attention of the greatest demonologists, and through them the various lords, tyrants, autarchs and heirophants who depended on sorcery to buttress their mundane power. So great was his deception that all his summoners considered themselves the master and Shadow Demon the servant; meanwhile, he eroded their identities and made their minds his own. In the end, most members of the cult were hollow puppets, extensions of his evil will. What Shadow Demon's next step would have been remains open to speculation, for around this time, Nevermore the Shadow Fiend bit into a particularly nasty-tasting soul and discovered that it held nothing but a foul nougat of Shadow Demon's essence. Alerted that a coup was underway, and that the ancient equilibrium of the Umbral Pact was about to be destabilized, Doom Bringer and Shadow Fiend briefly joined forces to destroy the burgeoning cult. Combining spells of incredible force, they undid Shadow Demon's centuries of patient work, reducing his cult to smithereens--and all its members to a bloody splatter. Nothing remained except a tiny speck of demon shadow. Immortal and irreducible, this mote of evil was enough to seed the Shadow Demon's next scheme, and in fits and starts, over further centuries, he began to regroup. Whatever that speck of shadow touched, it tainted, and its influence gradually grew. A chaos of damaged parts pulled together, reknit, and combined to give Shadow Demon a form even stronger than his former. He is all but complete now, and his plan for infinite dominion lacks all of its former weaknesses. It would seem that such a being of pure malice and malevolence, a threat to all creation, would be forever out of place in our world...yet Shadow Demon does not lack for followers. "

    bundleShadow_Demon.mBaseStr = 17
    bundleShadow_Demon.mStrIncrement = 1.9

    bundleShadow_Demon.mBaseInt = 23
    bundleShadow_Demon.mIntIncrement = 2.7

    bundleShadow_Demon.mBaseAgi = 18
    bundleShadow_Demon.mAgiIncrement = 2.2


    bundleShadow_Demon.mBaseMoveSpeed = 295
    bundleShadow_Demon.mBaseArmor = 0


    bundleShadow_Demon.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleShadow_Demon.mName, bundleShadow_Demon)



    '----------------------------------------------------------
    '-VISAGE START-----------------------------
    '----------------------------------------------------------
    Dim bundleVisage As New HeroBundle
    'FROM UNITBASE
    bundleVisage.mIDItem = New dvID(New Guid("952f1cc6-e6d3-4011-bb58-167c6c4bb2fe"), "Herobundle: Visage", eEntity.Herobundle)
    bundleVisage.mName = eHeroName.untVisage
      bundleVisage.DisplayName = "Visage"
      bundleVisage.mArmorType = eArmorType.Hero
      bundleVisage.mUnitImage = "http://cdn.dota2.com/apps/dota2/images/heroes/visage_vert.jpg"
      bundleVisage.mWebpageLink = "http://www.dota2.com/hero/Visage/"

      bundleVisage.mAttackType = eAttackType.Ranged
      bundleVisage.mBaseHitpoints = 0
      bundleVisage.mBaseAttackSpeed = 1.7 ' Fix for special heroes: http://dota2.gamepedia.com/Attack_speed

    bundleVisage.mBaseAttackDamage = New ValueWrapper(24, 34)

      bundleVisage.mDaySightRange = 1800
      bundleVisage.mNightSightRange = 800

      bundleVisage.mAttackRange = 600
      bundleVisage.mMissileSpeed = 900


    bundleVisage.mAbilityNames.Add(eAbilityName.abGrave_Chill)
    bundleVisage.mAbilityNames.Add(eAbilityName.abSoul_Assumption)
    bundleVisage.mAbilityNames.Add(eAbilityName.abGravekeepers_Cloak)
    bundleVisage.mAbilityNames.Add(eAbilityName.abSummon_Familiars)


      'FROM HEROBASE
      'Fixed, immutable stats
      bundleVisage.mDevName = "Visage"

      bundleVisage.mRoles.Add(eRole.Nuker)
      bundleVisage.mRoles.Add(eRole.Durable)
      bundleVisage.mRoles.Add(eRole.Disabler)

    bundleVisage.mPrimaryStat = ePrimaryStat.Intelligence

      bundleVisage.mBio = "Perched atop the entrance to the Narrow Maze sit the looming shapes of sneering gargoyles, the paths into the hereafter forever in their gaze. Beasts and birds, men and monsters, all creatures that die and choose to travel beyond must someday pass beneath their sight. For an untethered spirit, the decision to journey through the veil of death is irrevocable. When chance comes, and by craft or cunning some restless soul escapes their hells and heavens, it is the dreaded gargoyle Visage, the bound form of the eternal spirit Necro'lic, who is dispatched to reclaim them. Ruthless and efficient, unhindered by the principles of death and fatigue, Visage stalks its prey without mercy or end, willingly destroying all which may give shelter to the fugitive essence. That which flaunts the laws of the afterlife may never rest, for while it is true that the dead may be revived, it is only a matter of time before Visage finds and returns them to their proper place. "

      bundleVisage.mBaseStr = 22
      bundleVisage.mStrIncrement = 2.4

      bundleVisage.mBaseInt = 24
      bundleVisage.mIntIncrement = 2.5

      bundleVisage.mBaseAgi = 11
      bundleVisage.mAgiIncrement = 1.3


      bundleVisage.mBaseMoveSpeed = 285

    bundleVisage.mBaseArmor = -2

    bundleVisage.mBaseArmordebuff = 0.46

      bundleVisage.mBaseMagicResistance = 0.25 'Check This http://dota2.gamepedia.com/Magic_resistance

    Me.Add(bundleVisage.mName, bundleVisage)





  End Sub


End Class
