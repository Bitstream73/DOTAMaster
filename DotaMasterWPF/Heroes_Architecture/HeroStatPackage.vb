Public Class HeroStatPackage
  Public strength As Stat
  Public intel As Stat
  Public agility As Stat

  Public attackrange As Stat
  Public attackspersec As Stat
  Public missilespeed As Stat
  Public baseattacktime As Stat

  Public movespeed As Stat
  Public turnrate As Stat

  Public networth As Stat
  Public xp As Stat
  Public periodicgold As Stat


  Public kills As Stat

  Public effectiveHP As Stat
  Public hitpoints As Stat
  Public hpregen As Stat

  Public mana As Stat
  Public manaregen As Stat

  Public physicalarmor As Stat
  Public magicresistance As Stat
  Public magicimmunityBurst As Stat
  Public magicimmunityavg As Stat
  Public speelimmunitycount As Stat

  Public visiondayarea As Stat
  Public visionnightarea As Stat
  Public trusightarea As Stat
  Public stealthtime As Stat

  Public stundurationburst As Stat
  Public stundurationavg As Stat

  Public hexdurationburst As Stat
  Public hexdurationavg

  Public rightclickavgdamage As Stat
  Public rightclickhidamage As Stat
  Public rightclicklodamage As Stat

  Public critchance As Stat
  Public critmultiplier As Stat
  Public critDamage As Stat

  Public physicaldamageburst As Stat
  Public physicaldamageavg As Stat

  Public magicdamageburst As Stat
  Public magicdamageavg As Stat

  Public puredamageburst As Stat
  Public puredamageavg As Stat

  Public alldamageburst As Stat
  Public alldamageavg As Stat

  Public hpremoval As Stat
  Public negativeregen As Stat

  Public mStats As New List(Of Stat)

  Public Sub New(hero As HeroInstance, game As dGame)

    Dim moddb = game.dbModifiers
    strength = moddb.GetStatByParentandType(hero, eStattype.Strength)
    mStats.Add(strength)

    intel = moddb.GetStatByParentandType(hero, eStattype.Intelligence)
    mStats.Add(intel)

    agility = moddb.GetStatByParentandType(hero, eStattype.Agility)
    mStats.Add(agility)



    attackrange = moddb.GetStatByParentandType(hero, eStattype.AttackRange)
    mStats.Add(attackrange)

    attackspersec = moddb.GetStatByParentandType(hero, eStattype.AttackSpeed)
    mStats.Add(attackspersec)

    missilespeed = moddb.GetStatByParentandType(hero, eStattype.MissileSpeed)
    mStats.Add(missilespeed)

    baseattacktime = moddb.GetStatByParentandType(hero, eStattype.BaseAttackTime)
    mStats.Add(baseattacktime)


    missilespeed = moddb.GetStatByParentandType(hero, eStattype.MissileSpeed)
    mStats.Add(missilespeed)

    movespeed = moddb.GetStatByParentandType(hero, eStattype.MovementSpeed)
    mStats.Add(movespeed)

    turnrate = moddb.GetStatByParentandType(hero, eStattype.TurnRate)
    mStats.Add(turnrate)

    networth = moddb.GetStatByParentandType(hero, eStattype.Networth)
    mStats.Add(networth)

    xp = moddb.GetStatByParentandType(hero, eStattype.Experience)
    mStats.Add(xp)

    periodicgold = moddb.GetStatByParentandType(hero, eStattype.PeriodicGold)
    mStats.Add(periodicgold)


    kills = moddb.GetStatByParentandType(hero, eStattype.Kills)
    mStats.Add(kills)

    effectiveHP = moddb.GetStatByParentandType(hero, eStattype.EffectiveHP)
    mStats.Add(effectiveHP)

    hitpoints = moddb.GetStatByParentandType(hero, eStattype.HitPoints)
    mStats.Add(hitpoints)

    hpregen = moddb.GetStatByParentandType(hero, eStattype.HitPointRegen)
    mStats.Add(hpregen)

    mana = moddb.GetStatByParentandType(hero, eStattype.Mana)
    mStats.Add(mana)

    manaregen = moddb.GetStatByParentandType(hero, eStattype.ManaRegen)
    mStats.Add(manaregen)

    physicalarmor = moddb.GetStatByParentandType(hero, eStattype.PhysicalArmor)
    mStats.Add(physicalarmor)

    magicresistance = moddb.GetStatByParentandType(hero, eStattype.MagicalDamageResistance)
    mStats.Add(magicresistance)

    magicimmunityBurst = moddb.GetStatByParentandType(hero, eStattype.MagicImmunity)
    mStats.Add(magicimmunityBurst)

    magicimmunityavg = moddb.GetStatByParentandType(hero, eStattype.MagicImmunityAvg)
    mStats.Add(magicimmunityavg)

    speelimmunitycount = moddb.GetStatByParentandType(hero, eStattype.SpellImmunityCount)
    mStats.Add(speelimmunitycount)

    visiondayarea = moddb.GetStatByParentandType(hero, eStattype.VisionDay)
    mStats.Add(visiondayarea)

    visionnightarea = moddb.GetStatByParentandType(hero, eStattype.VisionNight)
    mStats.Add(visionnightarea)

    trusightarea = moddb.GetStatByParentandType(hero, eStattype.TrueSight)
    mStats.Add(trusightarea)

    stealthtime = moddb.GetStatByParentandType(hero, eStattype.Stealth)
    mStats.Add(stealthtime)

    stundurationburst = moddb.GetStatByParentandType(hero, eStattype.Stun)
    mStats.Add(stundurationburst)

    stundurationavg = moddb.GetStatByParentandType(hero, eStattype.StunAvg)
    mStats.Add(stundurationavg)

    hexdurationburst = moddb.GetStatByParentandType(hero, eStattype.Hex)
    mStats.Add(hexdurationburst)

    hexdurationavg = moddb.GetStatByParentandType(hero, eStattype.HexAvg)
    mStats.Add(hexdurationavg)

    rightclickavgdamage = moddb.GetStatByParentandType(hero, eStattype.AttackDamageAverage)
    mStats.Add(rightclickavgdamage)

    rightclickhidamage = moddb.GetStatByParentandType(hero, eStattype.AttackDamageHigh)
    mStats.Add(rightclickhidamage)

    rightclicklodamage = moddb.GetStatByParentandType(hero, eStattype.AttackDamageLow)
    mStats.Add(rightclicklodamage)

    critchance = moddb.GetStatByParentandType(hero, eStattype.CritChance)
    mStats.Add(critchance)

    critmultiplier = moddb.GetStatByParentandType(hero, eStattype.CritMultiplier)
    mStats.Add(critmultiplier)

    physicaldamageburst = moddb.GetStatByParentandType(hero, eStattype.PhysicalDamage)
    mStats.Add(physicaldamageburst)

    physicaldamageavg = moddb.GetStatByParentandType(hero, eStattype.PhysicalDamageAvg)
    mStats.Add(physicaldamageavg)

    magicdamageburst = moddb.GetStatByParentandType(hero, eStattype.MagicDamage)
    mStats.Add(magicdamageburst)

    magicdamageavg = moddb.GetStatByParentandType(hero, eStattype.MagicDamageAvg)
    mStats.Add(magicdamageavg)

    puredamageburst = moddb.GetStatByParentandType(hero, eStattype.PureDamage)
    mStats.Add(puredamageburst)

    puredamageavg = moddb.GetStatByParentandType(hero, eStattype.PureDamageAvg)
    mStats.Add(puredamageavg)

    alldamageburst = moddb.GetStatByParentandType(hero, eStattype.AllDamageBurst)
    mStats.Add(alldamageburst)

    alldamageavg = moddb.GetStatByParentandType(hero, eStattype.AllDamageAvg)
    mStats.Add(alldamageavg)

    hpremoval = moddb.GetStatByParentandType(hero, eStattype.HPRemoval)
    mStats.Add(hpremoval)

    negativeregen = moddb.GetStatByParentandType(hero, eStattype.PhysicalDamageNegation)
    mStats.Add(negativeregen)

    critchance = moddb.GetStatByParentandType(hero, eStattype.CritChance)
    mStats.Add(critchance)

    critDamage = moddb.GetStatByParentandType(hero, eStattype.CritDamage)
    mStats.Add(critDamage)

    critmultiplier = moddb.GetStatByParentandType(hero, eStattype.CritMultiplier)
    mStats.Add(critmultiplier)

  End Sub
End Class
