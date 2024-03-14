Public Class TeamStatPackage
  Public TeamPhysicalArmor As Stat
  Public TeamMagicResistancea As Stat
  Public TeamKills As Stat
  Public TeamTtlEffectiveHP As Stat
  Public TeamTtlDamageHi As Stat
  Public TeamTtlDamageLo As Stat
  Public TeamTtlDamageAvg As Stat
  Public TeamTtlHP As Stat
  Public TeamTtlHPRegen As Stat
  Public TeamTtlMana As Stat
  Public TeamTtlManaRegen As Stat
  Public TeamTtlVisionDay As Stat
  Public TeamTtlVisionNight As Stat
  Public TeamTtlDPSPeak As Stat
  Public TeamTtlDPSAvg As Stat
  Public TeamTtlPhysDamageBurst As Stat
  Public TeamTtlPhysDPSAvg As Stat
  Public TeamTtlMagDamageBurst As Stat
  Public TeamTtlMagDPSAvg As Stat
  Public TeamTtlPureDamageBurst As Stat
  Public TeamTtlPureDPSAvg As Stat
  Public TeamTtlStunDuratoin As Stat
  Public TeamTtlHexDuration As Stat
  Public TeamTtlSpellImmunityTime As Stat
  Public TeamTtlSpellImmunityCount As Stat

  Public mStats As New List(Of iDataItem)
  Public Sub New(team As dTeam, game As dGame)
    Dim dmmods = game.dbModifiers
    TeamPhysicalArmor = dmmods.GetStatByParentandType(team, eStattype.TeamPhysicalArmor)
    mStats.Add(TeamPhysicalArmor)

    TeamMagicResistancea = dmmods.GetStatByParentandType(team, eStattype.TeamMagicResistance)
    mStats.Add(TeamMagicResistancea)

    TeamKills = dmmods.GetStatByParentandType(team, eStattype.TeamKills)
    mStats.Add(TeamKills)

    TeamTtlEffectiveHP = dmmods.GetStatByParentandType(team, eStattype.TeamTtlEffectiveHP)
    mStats.Add(TeamTtlEffectiveHP)

    TeamTtlDamageHi = dmmods.GetStatByParentandType(team, eStattype.TeamTtlDamageHi)
    mStats.Add(TeamTtlDamageHi)

    TeamTtlDamageLo = dmmods.GetStatByParentandType(team, eStattype.TeamTtlDamageLo)
    mStats.Add(TeamTtlDamageLo)

    TeamTtlDamageAvg = dmmods.GetStatByParentandType(team, eStattype.TeamTtlDamageAvg)
    mStats.Add(TeamTtlDamageAvg)

    TeamTtlHP = dmmods.GetStatByParentandType(team, eStattype.TeamTtlHP)
    mStats.Add(TeamTtlHP)

    TeamTtlHPRegen = dmmods.GetStatByParentandType(team, eStattype.TeamTtlHPRegen)
    mStats.Add(TeamTtlHPRegen)

    TeamTtlMana = dmmods.GetStatByParentandType(team, eStattype.TeamTtlMana)
    mStats.Add(TeamTtlMana)

    TeamTtlManaRegen = dmmods.GetStatByParentandType(team, eStattype.TeamTtlManaRegen)
    mStats.Add(TeamTtlManaRegen)

    TeamTtlVisionDay = dmmods.GetStatByParentandType(team, eStattype.TeamTtlVisionDay)
    mStats.Add(TeamTtlVisionDay)

    TeamTtlVisionNight = dmmods.GetStatByParentandType(team, eStattype.TeamTtlVisionNight)
    mStats.Add(TeamTtlVisionNight)

    TeamTtlDPSPeak = dmmods.GetStatByParentandType(team, eStattype.TeamTtlDPSPeak)
    mStats.Add(TeamTtlDPSPeak)

    TeamTtlPhysDamageBurst = dmmods.GetStatByParentandType(team, eStattype.TeamTtlPhysDamageBurst)
    mStats.Add(TeamTtlPhysDamageBurst)

    TeamTtlMagDamageBurst = dmmods.GetStatByParentandType(team, eStattype.TeamTtlMagDamageBurst)
    mStats.Add(TeamTtlMagDamageBurst)

    TeamTtlPureDamageBurst = dmmods.GetStatByParentandType(team, eStattype.TeamTtlPureDamageBurst)
    mStats.Add(TeamTtlPureDamageBurst)

    TeamTtlStunDuratoin = dmmods.GetStatByParentandType(team, eStattype.TeamTtlStunDuratoin)
    mStats.Add(TeamTtlStunDuratoin)

    TeamTtlHexDuration = dmmods.GetStatByParentandType(team, eStattype.TeamTtlHexDuration)
    mStats.Add(TeamTtlHexDuration)

    TeamTtlSpellImmunityTime = dmmods.GetStatByParentandType(team, eStattype.TeamTtlSpellImmunityCount)
    mStats.Add(TeamTtlSpellImmunityTime)

    TeamTtlSpellImmunityCount = dmmods.GetStatByParentandType(team, eStattype.TeamTtlSpellImmunityCount)
    mStats.Add(TeamTtlSpellImmunityCount)

    TeamTtlDPSAvg = dmmods.GetStatByParentandType(team, eStattype.TeamTtlDPSAvg)
    mStats.Add(TeamTtlDPSAvg)

    TeamTtlPhysDPSAvg = dmmods.GetStatByParentandType(team, eStattype.TeamTtlPhysDPSAvg)
    mStats.Add(TeamTtlPhysDPSAvg)

    TeamTtlMagDPSAvg = dmmods.GetStatByParentandType(team, eStattype.TeamTtlMagDPSAvg)
    mStats.Add(TeamTtlMagDPSAvg)

    TeamTtlPureDPSAvg = dmmods.GetStatByParentandType(team, eStattype.TeamTtlPureDPSAvg)
    mStats.Add(TeamTtlPureDPSAvg)
  End Sub
End Class
