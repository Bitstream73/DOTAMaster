Public Class Formula_Database

  Private mStatModDependencies As Dictionary(Of eModifierType, List(Of eStattype))
  Private mStatStatDependencies As Dictionary(Of eStattype, List(Of eStattype))


  'Hero Details
  Dim fIntelligence As Formula
  Dim fAgility As Formula
  Dim fStrength As Formula

  Dim fKills As Formula

  Dim fAttackRange As Formula
  Dim fAttackSpeed As Formula
  Dim fMissileSpeed As Formula
  Dim fBaseAttackTime As Formula

  Dim fMovementSpeed As Formula
  Dim fTurnRate As Formula

  Dim fNetworth As Formula
  Dim fExperience As Formula
  Dim fPeriodicGold As Formula

  Dim fEffectiveHitpoints As Formula
  Dim fHitPoints As Formula
  Dim fHitPointRegen As Formula

  Dim fMana As Formula
  Dim fManaRegen As Formula

  Dim fPhysicalArmor As Formula
  Dim fMagicalDamageResistance As Formula
  Dim fMagicImmunityTimeBurst As Formula
  Dim fMagicImmunityTimeAvg As Formula
  Dim fSpellImmunityCount As Formula

  Dim fVisionday As Formula
  Dim fVisionNight As Formula
  Dim fTrueSight As Formula
  Dim fStealth As Formula

  Dim fStunDurationBurst As Formula
  Dim fStunDurationAvg As Formula

  Dim fHexDurationBurst As Formula
  Dim fHexDurationAvg As Formula

  Dim fRightclickDamageAvg As Formula
  Dim fCritChance As Formula
  Dim fCritDamageMultiplier As Formula
  Dim fCritDamage As Formula

  Dim fPhysicalDamage As Formula
  Dim fPhysicalDamageAvg As Formula

  Dim fMagicDamageBurst As Formula
  Dim fMagicDamageAvg As Formula

  Dim fPureDamageBurst As Formula
  Dim fPureDamageAvg As Formula

  Dim fAllDamageBurst As Formula
  Dim fAllDamageAvg As Formula

  Dim fHPRemoval As Formula
  Dim fNegativeRegen As Formula

  'Team Details
  Dim fTeamKills As Formula
  Dim fTeamTtlEffectiveHP As Formula
  Dim fTeamTtlDamageHi As Formula
  Dim fTeamTtlDamageLo As Formula
  Dim fTeamTtlDamageAvg As Formula
  Dim fTeamTtlHP As Formula
  Dim fTeamTtlHPRegen As Formula
  Dim fTeamTtlMana As Formula
  Dim fTeamTtlManaRegen As Formula
  Dim fTeamTtlVisionDay As Formula
  Dim fTeamTtlVisionNight As Formula
  Dim fTeamTtlDPSPeak As Formula
  Dim fTeamTtlPhysDamageBurst As Formula
  Dim fTeamTtlMagDamageBurst As Formula
  Dim fTeamTtlPureDamageBurst As Formula
  Dim fTeamTtlStunDuratoin As Formula
  Dim fTeamTtlHexDuration As Formula
  Dim fTeamTtlSpellImmunityCount As Formula
  Dim fTeamPhysicalArmor As Formula
  Dim fTeamMagicResistance As Formula
  'stat helpers (dependencies for other stats)
  Dim fAttackDamageLow As Formula
  Dim fAttackDamageHigh As Formula
  Dim fBonusAttackDamage As Formula

  Dim fPhysicalDamageAmplification As Formula
  Dim fPhysicalDamageReduction As Formula
  Dim fPhysicalDamageNegation As Formula

  Dim fNumber1 As Formula
  Dim fNumberPoint06 As Formula


  Dim fArmorxPoint06 As Formula
  Private fPrimaryAttribute As Formula

  Dim fHitPointRegenDebuffs As Formula


  Dim fResources As Formula
  Private mLog As iLogging
  Private mNames As FriendlyName_Database

  'eUnit Lists
  Private lstSelf As List(Of eStatSource)
  Private lstEmpty As List(Of eStatSource)
  Private lstMyTeam As List(Of eStatSource)
  Private lstEnemyTeam As List(Of eStatSource)

  Public Sub New(thelog As iLogging, names As FriendlyName_Database)

    mLog = thelog
    mStatModDependencies = New Dictionary(Of eModifierType, List(Of eStattype))
    mStatStatDependencies = New Dictionary(Of eStattype, List(Of eStattype))

    LoadeUnitLists()

    LoadBaseAttackTime()
    LoadAttackSpeed()

    LoadAttackDamageLow()
    LoadAttackDamageHigh()
    LoadAttackDamageAvg()

    LoadPhysicalArmor()

    LoadPhysicalDamageAmplification()
    LoadPhysicalDamageReduction()
    LoadPhysicalDamageNegation()

    LoadMagicalDamageResistance()

    LoadMovementSpeed()
    LoadAttackRange()
    LoadMissileSpeed()

    LoadStrength()
    LoadAgility()
    LoadIntelligence()

    LoadNetWorth()

    LoadExperience()

    LoadMagicDamage()

    LoadPhysicalDamage()

    LoadPureDamage()

    LoadHPRemoval()

    LoadAllDamageBurst()

    LoadHitPoints()

    LoadHitPointRegen()

    LoadMana()

    LoadManaRegen()

    LoadVisionDay()
    LoadVisionNight()

    LoadTrueSight()

    LoadStealth()

    LoadKills()

    LoadResources()

    LoadPeriodicGold()

    LoadCritChance()

    LoadCritDamage()

    LoadCritDamageMultiplier()

    LoadEffectiveHitpoints()

    LoadMagicImmunityTimeBurst()

    LoadSpellImmunityCount()

    LoadStunDurationBurst()

    LoadHexDurationBurst()

    LoadNumber1()

    LoadNumberPoint06()

    LoadArmorxPoint06()

    LoadTeamKills()
    LoadTeamTtlEffectiveHP()
    LoadTeamTtlDamageHi()
    LoadTeamTtlDamageLo()
    LoadTeamTtlDamageAvg()
    LoadTeamTtlHP()
    LoadTeamTtlHPRegen()
    LoadTeamTtlMana()
    LoadTeamTtlManaRegen()
    LoadTeamTtlVisionDay()
    LoadTeamTtlVisionNight()
    'LoadTeamTtlDPSPeak()
    LoadTeamTtlPhysDamageBurst()
    LoadTeamTtlMagDamageBurst()
    LoadTeamTtlPureDamageBurst()
    LoadTeamTtlStunDuratoin()
    LoadTeamTtlHexDuration()
    LoadTeamTtlSpellImmunityCount()
    LoadTeamPhysicalArmor()
    LoadTeamMagicResistance()
  End Sub

  Private Sub LoadeUnitLists() 'lists used to specify the parents, sources and targets used to calc formulas
    lstSelf = New List(Of eStatSource)
    lstSelf.Add(eStatSource.Self)

    lstEmpty = New List(Of eStatSource)

    lstEnemyTeam = New List(Of eStatSource)
    lstEnemyTeam.Add(eStatSource.EnemyTeamMembers)

    lstMyTeam = New List(Of eStatSource)
    lstMyTeam.Add(eStatSource.TeamMembers)
  End Sub

  Public Function GetFormula(thestat As eStattype, primaryattribute As ePrimaryStat) As Formula
    Select Case thestat

      Case eStattype.AttackSpeed
        Return fAttackSpeed

      Case eStattype.AttackDamageLow
        Return fAttackDamageLow

      Case eStattype.AttackDamageHigh
        Return fAttackDamageHigh

      Case eStattype.AttackDamageAverage
        Return fRightclickDamageAvg

      Case eStattype.AttackRange
        Return fAttackRange

      Case eStattype.PhysicalArmor
        Return fPhysicalArmor

      Case eStattype.PhysicalDamageReduction
        Return fPhysicalDamageReduction

      Case eStattype.PhysicalDamageAmplification
        Return fPhysicalDamageAmplification

      Case eStattype.PhysicalDamageNegation
        Return fPhysicalDamageNegation

      Case eStattype.MagicalDamageResistance
        Return fMagicalDamageResistance

      Case eStattype.MovementSpeed
        Return fMovementSpeed

      Case eStattype.Strength
        Return fStrength

      Case eStattype.Agility
        Return fAgility

      Case eStattype.Intelligence
        Return fIntelligence

      Case eStattype.PrimaryAttribute
        Select Case primaryattribute
          Case ePrimaryStat.Agility
            Return fAgility
          Case ePrimaryStat.Intelligence
            Return fIntelligence
          Case ePrimaryStat.Strength
            Return fStrength
          Case Else
            Dim x = 2
        End Select

      Case eStattype.Networth
        Return fNetworth

      Case eStattype.Experience
        Return fExperience

      Case eStattype.MagicDamage
        Return fMagicDamageBurst

      Case eStattype.PhysicalDamage
        Return fPhysicalDamage

      Case eStattype.PureDamage
        Return fPureDamageBurst

      Case eStattype.HitPoints
        Return fHitPoints

      Case eStattype.HitPointRegen
        Return fHitPointRegen

      Case eStattype.Mana
        Return fMana

      Case eStattype.ManaRegen
        Return fManaRegen

      Case eStattype.VisionDay
        Return fVisionday

      Case eStattype.VisionNight
        Return fVisionNight

      Case eStattype.TrueSight
        Return fTrueSight

      Case eStattype.Stealth
        Return fStealth


      Case eStattype.Kills
        Return fKills

      Case eStattype.Resources
        Return fResources
      Case eStattype.MissileSpeed
        Return fMissileSpeed
      Case eStattype.BaseAttackTime
        Return fBaseAttackTime
      Case eStattype.PeriodicGold
        Return fPeriodicGold
      Case eStattype.CritChance
        Return fCritChance

      Case eStattype.CritDamage
        Return fCritDamage
      Case eStattype.CritMultiplier
        Return fCritDamageMultiplier
      Case eStattype.AllDamageBurst
        Return fAllDamageBurst
      Case eStattype.HPRemoval
        Return fHPRemoval
      Case eStattype.EffectiveHP
        Return fEffectiveHitpoints
      Case eStattype.MagicImmunity
        Return fMagicImmunityTimeBurst
      Case eStattype.SpellImmunityCount
        Return fSpellImmunityCount
      Case eStattype.Stun
        Return fStunDurationBurst
      Case eStattype.Hex
        Return fHexDurationBurst
      Case eStattype.Number1
        Return fNumber1
      Case eStattype.NumberPoint06
        Return fNumberPoint06
      Case eStattype.ArmorxPoint06
        Return fArmorxPoint06
      Case eStattype.TeamKills
        Return fTeamKills
      Case eStattype.TeamTtlEffectiveHP
        Return fTeamTtlEffectiveHP
      Case eStattype.TeamTtlDamageHi
        Return fTeamTtlDamageHi
      Case eStattype.TeamTtlDamageLo
        Return fTeamTtlDamageLo
      Case eStattype.TeamTtlDamageAvg
        Return fTeamTtlDamageAvg
      Case eStattype.TeamTtlHP
        Return fTeamTtlHP
      Case eStattype.TeamTtlHPRegen
        Return fTeamTtlHPRegen
      Case eStattype.TeamTtlMana
        Return fTeamTtlMana
      Case eStattype.TeamTtlManaRegen
        Return fTeamTtlManaRegen
      Case eStattype.TeamTtlVisionDay
        Return fTeamTtlVisionDay
      Case eStattype.TeamTtlVisionNight
        Return fTeamTtlVisionNight
      Case eStattype.TeamTtlDPSPeak
        Return fTeamTtlDPSPeak
      Case eStattype.TeamTtlPhysDamageBurst
        Return fTeamTtlPhysDamageBurst
      Case eStattype.TeamTtlMagDamageBurst
        Return fTeamTtlMagDamageBurst
      Case eStattype.TeamTtlPureDamageBurst
        Return fTeamTtlPureDamageBurst
      Case eStattype.TeamTtlStunDuratoin
        Return fTeamTtlStunDuratoin
      Case eStattype.TeamTtlHexDuration
        Return fTeamTtlHexDuration
      Case eStattype.TeamTtlSpellImmunityCount
        Return fTeamTtlSpellImmunityCount
      Case eStattype.TeamPhysicalArmor
        Return fTeamPhysicalArmor
      Case eStattype.TeamMagicResistance
        Return fTeamMagicResistance
      Case Else

        mLog.Writelog("StatCalc.GetFormula unhandled type: " & thestat.ToString)
        Throw New NotImplementedException
    End Select
    Return Nothing
  End Function

  Private Sub AddStatModDependency(themod As eModifierType, thestat As eStattype)

    If Not mStatModDependencies.ContainsKey(themod) Then
      Dim newlist As New List(Of eStattype)
      newlist.Add(thestat)
      mStatModDependencies.Add(themod, newlist)
    Else
      Dim curlist = mStatModDependencies.Item(themod)

      If Not curlist.Contains(thestat) Then
        curlist.Add(thestat)
      End If

    End If

  End Sub

  Private Sub AddStatStatDependency(thestatingredient As eStattype, thestat As eStattype)


    If Not mStatStatDependencies.ContainsKey(thestatingredient) Then
      Dim newlist As New List(Of eStattype)
      newlist.Add(thestat)
      mStatStatDependencies.Add(thestatingredient, newlist)
    Else
      Dim curlist = mStatStatDependencies.Item(thestatingredient)

      If Not curlist.Contains(thestat) Then
        curlist.Add(thestat)
      End If

    End If
  End Sub

  Public Function GetStatsDependentOnMods(themods As ModifierList) As List(Of eStattype)
    Dim outmods As New List(Of eModifierType)
    For i As Integer = 0 To themods.Count - 1
      If Not outmods.Contains(themods.Item(i).ModifierType) Then
        outmods.Add(themods.Item(i).ModifierType)
      End If
    Next

    Return GetStatsDependentOnMods(outmods)

  End Function

  Public Function GetStatsDependentOnMods(themods As List(Of eModifierType)) As List(Of eStattype)
      If themods Is Nothing Then
        Return New List(Of eStattype)
      End If
      If themods.Count < 1 Then
        Return New List(Of eStattype)
      End If

      Dim outlist As New List(Of eStattype)
      For i As Integer = 0 To themods.Count - 1

        Dim curstats = GetStatsDependentOnMod(themods.Item(i))
        If Not curstats Is Nothing Then
          For x As Integer = 0 To curstats.Count - 1
            If Not outlist.Contains(curstats.Item(x)) Then
              outlist.Add(curstats.Item(x))
            End If

          Next
        End If


      Next
      Return outlist
   
  End Function
  Public Function GetStatsDependentOnMod(themod As eModifierType) As List(Of eStattype)

    If mStatModDependencies.ContainsKey(themod) Then
      Return mStatModDependencies.Item(themod)
    End If
    Return Nothing

  End Function

  Public Function GetStatsDependentonStats(thestats As List(Of eStattype)) As List(Of eStattype)
    If thestats Is Nothing Then
      Return New List(Of eStattype)
    End If

    If thestats.Count < 1 Then
      Return New List(Of eStattype)
    End If

    Dim outlist As New List(Of eStattype)
    For i As Integer = 0 To thestats.Count - 1
      Dim curstats = GetStatsDependentonStat(thestats.Item(i))
      If Not curstats Is Nothing Then
        For x As Integer = 0 To curstats.Count - 1
          If Not outlist.Contains(curstats.Item(x)) Then
            outlist.Add(curstats.Item(x))
          End If
        Next
      End If

    Next
    Return outlist
  End Function

  Public Function GetStatsDependentonStat(thestat As eStattype) As List(Of eStattype)
    If mStatStatDependencies.ContainsKey(thestat) Then
      Return mStatStatDependencies.Item(thestat)
    Else
      Return Nothing
    End If
  End Function


#Region "Loaders"
  Private Sub LoadIntelligence()


    fIntelligence = New Formula(lstSelf, lstSelf, lstSelf)

    fIntelligence.Add(New FormulaElement(eModifierType.BaseInt, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.BaseInt, eStattype.Intelligence)

    fIntelligence.Add(New FormulaElement(eModifierType.IntAdded, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.IntAdded, eStattype.Intelligence)

    fIntelligence.Add(New FormulaElement(eModifierType.IntIncrementAdded, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.IntIncrementAdded, eStattype.Intelligence)

    fIntelligence.Add(New FormulaElement(eModifierType.IntoT, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.IntoT, eStattype.Intelligence)

    fIntelligence.Add(New FormulaElement(eModifierType.IntSubtracted, _
Nothing, _
eMathAction.InputMinusValue, mNames))
    AddStatModDependency(eModifierType.IntSubtracted, eStattype.Intelligence)

    fIntelligence.Add(New FormulaElement(eModifierType.AstrlImpIntStolen, _
Nothing, _
eMathAction.InputMinusValue, mNames))
    AddStatModDependency(eModifierType.AstrlImpIntStolen, eStattype.Intelligence)

    fIntelligence.Add(New FormulaElement(eModifierType.IntPercent, _
Nothing, _
eMathAction.InputPlusPercentageOfPrePercValue, mNames))
    AddStatModDependency(eModifierType.IntPercent, eStattype.Intelligence)




  End Sub
  Private Sub LoadAgility()
    fAgility = New Formula(lstSelf, lstSelf, lstSelf)

    fAgility.Add(New FormulaElement(eModifierType.BaseAgi, _
 Nothing, _
 eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.BaseAgi, eStattype.Agility)

    fAgility.Add(New FormulaElement(eModifierType.AgiAdded, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.AgiAdded, eStattype.Agility)

    fAgility.Add(New FormulaElement(eModifierType.AgiIncrementAdded, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.AgiIncrementAdded, eStattype.Agility)

    '    fAgility.Add(New FormulaElement(eModifierType.AgiAdded, _
    'Nothing, _
    'eMathAction.InputPlusValue))

    fAgility.Add(New FormulaElement(eModifierType.AgioT, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.AgioT, eStattype.Agility)

    fAgility.Add(New FormulaElement(eModifierType.AgiPercent, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.AgiPercent, eStattype.Agility)

    fAgility.Add(New FormulaElement(eModifierType.AgiSubtracted, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.AgiSubtracted, eStattype.Agility)
  End Sub
  Private Sub LoadStrength()
    fStrength = New Formula(lstSelf, lstSelf, lstSelf)

    fStrength.Add(New FormulaElement(eModifierType.BaseStr, _
     Nothing, _
     eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.BaseStr, eStattype.Strength)

    fStrength.Add(New FormulaElement(eModifierType.StrAdded, _
 Nothing, _
 eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.StrAdded, eStattype.Strength)

    fStrength.Add(New FormulaElement(eModifierType.StrIncrementAdded, _
 Nothing, _
 eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.StrIncrementAdded, eStattype.Strength)

    fStrength.Add(New FormulaElement(eModifierType.StrAddedPerKill, _
 Nothing, _
 eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.StrAddedPerKill, eStattype.Strength)

    fStrength.Add(New FormulaElement(eModifierType.StrengthPercentageAsAllDamage, _
 Nothing, _
 eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.StrengthPercentageAsAllDamage, eStattype.Strength)

    fStrength.Add(New FormulaElement(eModifierType.StrengthPercentageCounterAttack, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.StrengthPercentageCounterAttack, eStattype.Strength)

    fStrength.Add(New FormulaElement(eModifierType.StroT, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.StroT, eStattype.Strength)

    fStrength.Add(New FormulaElement(eModifierType.StrSubtracted, _
Nothing, _
eMathAction.InputMinusValue, mNames))
    AddStatModDependency(eModifierType.StrSubtracted, eStattype.Strength)

  End Sub

  Private Sub LoadKills()
    fKills = New Formula(lstSelf, lstSelf, lstEmpty)

    fKills.Add(New FormulaElement(eModifierType.KillsPerGoldIncrement, Nothing, eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.KillsPerGoldIncrement, eStattype.Kills)

  End Sub
  Private Sub LoadTeamKills()
    fTeamKills = New Formula(lstMyTeam, lstMyTeam, lstEmpty)

    fTeamKills.Add(New FormulaElement(eModifierType.KillsPerGoldIncrement, Nothing, eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.KillsPerGoldIncrement, eStattype.TeamKills)



  End Sub


  Private Sub LoadAttackRange()
    fAttackRange = New Formula(lstSelf, lstSelf, lstSelf)

    fAttackRange.Add(New FormulaElement(eModifierType.BaseAttackRange, _
                                      Nothing, _
                                      eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.BaseAttackRange, eStattype.AttackRange)

    fAttackRange.Add(New FormulaElement(eModifierType.DamageRangeAdded, _
                                  Nothing, _
                                  eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamageRangeAdded, eStattype.AttackRange)

    fAttackRange.Add(New FormulaElement(eModifierType.DamageRangemultiplier, _
                                  Nothing, _
                                  eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamageRangemultiplier, eStattype.AttackRange)


  End Sub
  Private Sub LoadAttackSpeed() 'AttackSpeed = AttackSpeedBuffs - AttaskSpeedDebuffs	() 

    fAttackSpeed = New Formula(lstSelf, lstSelf, lstSelf)

    'buffs
    fAttackSpeed.Add(New FormulaElement(eModifierType.AttackSpeedAdded, _
                                            Nothing, eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.AttackSpeedAdded, eStattype.AttackSpeed)

    fAttackSpeed.Add(New FormulaElement(eModifierType.AttackSpeedAddedPerHeroPerMissHP, _
                            Nothing, eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.AttackSpeedAddedPerHeroPerMissHP, eStattype.AttackSpeed)

    fAttackSpeed.Add(New FormulaElement(eModifierType.AttackSpeedAddedtoXAttacks, _
                                               Nothing, eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.AttackSpeedAddedtoXAttacks, eStattype.AttackSpeed)


    fAttackSpeed.Add(New FormulaElement(eModifierType.AttackSpeedoT, _
                                                 Nothing, eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.AttackSpeedoT, eStattype.AttackSpeed)


    fAttackSpeed.Add(New FormulaElement(eModifierType.AttackSpeedPercentofTargetAdded, _
                                               Nothing, eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.AttackSpeedPercentofTargetAdded, eStattype.AttackSpeed)

    fAttackSpeed.Add(New FormulaElement(eModifierType.AttackSpeedStackAdded, _
                                               Nothing, eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.AttackSpeedStackAdded, eStattype.AttackSpeed)

    fAttackSpeed.Add(New FormulaElement(eModifierType.BerserkersBonusAttackSpeed, _
                                               Nothing, eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.BerserkersBonusAttackSpeed, eStattype.AttackSpeed)

    fAttackSpeed.Add(New FormulaElement(eModifierType.DeathlustAttackSpeedAdded, _
                                               Nothing, eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DeathlustAttackSpeedAdded, eStattype.AttackSpeed)

    fAttackSpeed.Add(New FormulaElement(eModifierType.NightAttackSpeedAdded, _
                                               Nothing, eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.NightAttackSpeedAdded, eStattype.AttackSpeed)

    fAttackSpeed.Add(New FormulaElement(eModifierType.RabidAttackSpeedAdded, _
                                               Nothing, eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.RabidAttackSpeedAdded, eStattype.AttackSpeed)

    fAttackSpeed.Add(New FormulaElement(eModifierType.WexAttackSpeedAdded, _
                                               Nothing, eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.WexAttackSpeedAdded, eStattype.AttackSpeed)

    'fAttackSpeed.Add(New FormulaElement(Nothing, _
    '                                           eStat.AgilityBuffs, eMathAction.InputPlusValue))






    'debuffs
    fAttackSpeed.Add(New FormulaElement(eModifierType.AttackspeedSubtracted, _
                                             Nothing, _
                                             eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.AttackspeedSubtracted, eStattype.AttackSpeed)

    fAttackSpeed.Add(New FormulaElement(eModifierType.NightAttackSpeedSubtracted, _
                                               Nothing, _
                                               eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.NightAttackSpeedSubtracted, eStattype.AttackSpeed)

    fAttackSpeed.Add(New FormulaElement(eModifierType.BaseAttackTime, _
                                               Nothing, _
                                               eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.BaseAttackTime, eStattype.AttackSpeed)

    fAttackSpeed.Add(New FormulaElement(eModifierType.BaseAttackTimeChangedTo, _
                                               Nothing, _
                                               eMathAction.SetToValueIfValueExists, mNames))
    AddStatModDependency(eModifierType.BaseAttackTimeChangedTo, eStattype.AttackSpeed)

    fAttackSpeed.Add(New FormulaElement(eModifierType.RightClickAttackAttackSlowInflicted, _
                                               Nothing, _
                                               eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.RightClickAttackAttackSlowInflicted, eStattype.AttackSpeed)





    'percentages
    fAttackSpeed.Add(New FormulaElement(eModifierType.BuildingAttackSpeedPercentAdded, _
                                           Nothing, eMathAction.InputPlusPercentageOfPrePercValue, mNames))
    AddStatModDependency(eModifierType.BuildingAttackSpeedPercentAdded, eStattype.AttackSpeed)

    fAttackSpeed.Add(New FormulaElement(eModifierType.AttackSpeedPercentAdded, _
                                                                  Nothing, eMathAction.InputPlusPercentageOfPrePercValue, mNames))
    AddStatModDependency(eModifierType.AttackSpeedPercentAdded, eStattype.AttackSpeed)

    fAttackSpeed.Add(New FormulaElement(eModifierType.AttackSpeedPercentSubtracted, _
                                           Nothing, _
                                           eMathAction.InputPlusPercentageOfPrePercValue, mNames))
    AddStatModDependency(eModifierType.AttackSpeedPercentSubtracted, eStattype.AttackSpeed)

    'absolutes
    fAttackSpeed.Add(New FormulaElement(eModifierType.AttackSpeedMaxed, _
                                 Nothing, _
                                 eMathAction.SetToMaxValueIfValueExists, mNames))
    AddStatModDependency(eModifierType.AttackSpeedMaxed, eStattype.AttackSpeed)



  End Sub
  Private Sub LoadMissileSpeed()
    fMissileSpeed = New Formula(lstSelf, lstSelf, lstSelf)

    fMissileSpeed.Add(New FormulaElement(eModifierType.MissileSpeed, _
                                         Nothing, _
                                         eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.MissileSpeed, eStattype.MissileSpeed)

  End Sub
  Private Sub LoadBaseAttackTime()
    fBaseAttackTime = New Formula(lstSelf, lstSelf, lstEmpty)

    fBaseAttackTime.Add(New FormulaElement(eModifierType.BaseAttackTime, _
                                           Nothing, _
                                           eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.BaseAttackTime, eStattype.BaseAttackTime)

  End Sub

  Private Sub LoadMovementSpeed()
    fMovementSpeed = New Formula(lstSelf, lstSelf, lstSelf)

    fMovementSpeed.Add(New FormulaElement(eModifierType.BaseMovementSpeed, _
     Nothing, _
     eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.BaseMovementSpeed, eStattype.MovementSpeed)

    fMovementSpeed.Add(New FormulaElement(eModifierType.BearMoveSpeedAdded, _
     Nothing, _
     eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.BearMoveSpeedAdded, eStattype.MovementSpeed)

    '   fMovementSpeed.Add(New FormulaElement(eModifierType.BearMoveSpeedAdded, _
    'Nothing, _
    'eMathAction.InputPlusValue))

    fMovementSpeed.Add(New FormulaElement(eModifierType.MoveSpeedAdded, _
 Nothing, _
 eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.MoveSpeedAdded, eStattype.MovementSpeed)


    fMovementSpeed.Add(New FormulaElement(eModifierType.MoveSpeedoT, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.MoveSpeedoT, eStattype.MovementSpeed)

    fMovementSpeed.Add(New FormulaElement(eModifierType.MoveSpeedPercent, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.MoveSpeedPercent, eStattype.MovementSpeed)

    fMovementSpeed.Add(New FormulaElement(eModifierType.MoveSpeedPercentAdded, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.MoveSpeedPercentAdded, eStattype.MovementSpeed)

    fMovementSpeed.Add(New FormulaElement(eModifierType.MoveSpeedPercentAddedPerHeroPerMissHP, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.MoveSpeedPercentAddedPerHeroPerMissHP, eStattype.MovementSpeed)

    fMovementSpeed.Add(New FormulaElement(eModifierType.MoveSpeedPercentofTargetAdded, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.MoveSpeedPercentofTargetAdded, eStattype.MovementSpeed)

    fMovementSpeed.Add(New FormulaElement(eModifierType.MoveSpeedStackAdded, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.MoveSpeedStackAdded, eStattype.MovementSpeed)

    '    fMovementSpeed.Add(New FormulaElement(eModifierType.MoveSpeedAdded, _
    'Nothing, _
    'eMathAction.InputPlusValue))

    fMovementSpeed.Add(New FormulaElement(eModifierType.MoveSpeedPercentofTargetAdded, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.MoveSpeedPercentofTargetAdded, eStattype.MovementSpeed)

    fMovementSpeed.Add(New FormulaElement(eModifierType.NightMoveSpeedAdded, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.NightMoveSpeedAdded, eStattype.MovementSpeed)

    fMovementSpeed.Add(New FormulaElement(eModifierType.RabidMoveSpeedAdded, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.RabidMoveSpeedAdded, eStattype.MovementSpeed)

    fMovementSpeed.Add(New FormulaElement(eModifierType.MoveSpeedSubtracted, _
Nothing, _
eMathAction.InputMinusValue, mNames))
    AddStatModDependency(eModifierType.MoveSpeedSubtracted, eStattype.MovementSpeed)

    fMovementSpeed.Add(New FormulaElement(eModifierType.MoveSpeedPercentStackSubtracted, _
Nothing, _
eMathAction.InputMinusValue, mNames))
    AddStatModDependency(eModifierType.MoveSpeedPercentStackSubtracted, eStattype.MovementSpeed)

    fMovementSpeed.Add(New FormulaElement(eModifierType.VoidMoveSpeedPercentSubtracted, _
Nothing, _
eMathAction.InputMinusPercetageofPrePercValue, mNames))
    AddStatModDependency(eModifierType.VoidMoveSpeedPercentSubtracted, eStattype.MovementSpeed)

    fMovementSpeed.Add(New FormulaElement(eModifierType.WexMoveSpeedPercentChangeSubtracted, _
Nothing, _
eMathAction.InputMinusPercetageofPrePercValue, mNames))
    AddStatModDependency(eModifierType.WexMoveSpeedPercentChangeSubtracted, eStattype.MovementSpeed)

    fMovementSpeed.Add(New FormulaElement(eModifierType.WexMoveSpeedPercentChangeAdded, _
Nothing, _
eMathAction.InputPlusPercentageOfPrePercValue, mNames))
    AddStatModDependency(eModifierType.WexMoveSpeedPercentChangeAdded, eStattype.MovementSpeed)

    fMovementSpeed.Add(New FormulaElement(eModifierType.AstralSpiritMoveSpeedPercentAdded, _
Nothing, _
eMathAction.InputPlusPercentageOfPrePercValue, mNames))
    AddStatModDependency(eModifierType.AstralSpiritMoveSpeedPercentAdded, eStattype.MovementSpeed)

    fMovementSpeed.Add(New FormulaElement(eModifierType.RightClickMoveSpeedPercSubtracted, _
Nothing, _
eMathAction.InputMinusPercetageofPrePercValue, mNames))
    AddStatModDependency(eModifierType.RightClickMoveSpeedPercSubtracted, eStattype.MovementSpeed)

    fMovementSpeed.Add(New FormulaElement(eModifierType.MoveSpeedPercentSubtracted, _
Nothing, _
eMathAction.InputMinusPercetageofPrePercValue, mNames))
    AddStatModDependency(eModifierType.MoveSpeedPercentSubtracted, eStattype.MovementSpeed)



    fMovementSpeed.Add(New FormulaElement(eModifierType.MoveSpeedMinimum, _
Nothing, _
eMathAction.SetToValueIfGreaterThanInput, mNames))
    AddStatModDependency(eModifierType.MoveSpeedMinimum, eStattype.MovementSpeed)


    fMovementSpeed.Add(New FormulaElement(eModifierType.QuasMoveSpeedPercentChange, _
Nothing, _
eMathAction.SetToValueIfValueExists, mNames))
    AddStatModDependency(eModifierType.QuasMoveSpeedPercentChange, eStattype.MovementSpeed)

    fMovementSpeed.Add(New FormulaElement(eModifierType.MoveSpeedSet, _
Nothing, _
eMathAction.SetToValueIfValueExists, mNames))
    AddStatModDependency(eModifierType.MoveSpeedSet, eStattype.MovementSpeed)

    fMovementSpeed.Add(New FormulaElement(eModifierType.MuteMove, _
Nothing, _
eMathAction.SetToMinValueIfValueExists, mNames))
    AddStatModDependency(eModifierType.MuteMove, eStattype.MovementSpeed)


  End Sub
  Private Sub LoadTurnRate()
    fTurnRate = New Formula(lstSelf, lstSelf, lstSelf)

    fTurnRate.Add(New FormulaElement(eModifierType.BaseTurnRate, _
                                     Nothing, _
                                     eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.BaseTurnRate, eStattype.TurnRate)


    fTurnRate.Add(New FormulaElement(eModifierType.TurnRateSubtracted, _
                                     Nothing, _
                                     eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.TurnRateSubtracted, eStattype.TurnRate)


    fTurnRate.Add(New FormulaElement(eModifierType.MuteTurn, _
                                     Nothing, _
                                     eMathAction.SetToMinValueIfValueExists, mNames))
    AddStatModDependency(eModifierType.MuteTurn, eStattype.TurnRate)
  End Sub

  Private Sub LoadNetWorth()
    fNetworth = New Formula(lstSelf, lstSelf, lstSelf)

    fNetworth.Add(New FormulaElement(eModifierType.BaseGold, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.BaseGold, eStattype.Networth)

    fNetworth.Add(New FormulaElement(eModifierType.BonusGold, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.BonusGold, eStattype.Networth)

    fNetworth.Add(New FormulaElement(eModifierType.BountyGold, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.BountyGold, eStattype.Networth)

    fNetworth.Add(New FormulaElement(eModifierType.LastHitGoldAdded, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.LastHitGoldAdded, eStattype.Networth)

    fNetworth.Add(New FormulaElement(eModifierType.LastHitGoldBonusPerStack, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.LastHitGoldBonusPerStack, eStattype.Networth)
  End Sub
  Private Sub LoadExperience()
    fExperience = New Formula(lstSelf, lstSelf, lstSelf)

    fExperience.Add(New FormulaElement(eModifierType.BaseXP, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.BaseXP, eStattype.Experience)

    fExperience.Add(New FormulaElement(eModifierType.XPAdded, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.XPAdded, eStattype.Experience)


  End Sub
  Private Sub LoadPeriodicGold()
    fPeriodicGold = New Formula(lstSelf, lstSelf, lstEmpty)

    fPeriodicGold.Add(New FormulaElement(eModifierType.PeriodicGold, _
                                         Nothing, eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.PeriodicGold, eStattype.PeriodicGold)
  End Sub

  Private Sub LoadResources()
    fResources = New Formula(lstSelf, lstSelf, lstEmpty)

    fResources.Add(New FormulaElement(eModifierType.ResourceShare, Nothing, eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.ResourceShare, eStattype.Resources)

  End Sub



  Private Sub LoadEffectiveHitpoints()
    fEffectiveHitpoints = New Formula(lstSelf, lstSelf, lstEmpty)

    fEffectiveHitpoints.Add(New FormulaElement(Nothing, _
                                               eStattype.ArmorxPoint06, _
                                               eMathAction.InputPlusValue, mNames))
    AddStatStatDependency(eStattype.ArmorxPoint06, eStattype.EffectiveHP)


    fEffectiveHitpoints.Add(New FormulaElement(Nothing, _
                                               eStattype.Number1, _
                                               eMathAction.InputPlusValue, mNames))
    AddStatStatDependency(eStattype.Number1, eStattype.EffectiveHP)


    fEffectiveHitpoints.Add(New FormulaElement(Nothing, _
                                               eStattype.HitPoints, _
                                               eMathAction.InputMultipliedByValue, mNames))
    AddStatStatDependency(eStattype.HitPoints, eStattype.EffectiveHP)
  End Sub
  Private Sub LoadTeamTtlEffectiveHP()
    fTeamTtlEffectiveHP = New Formula(lstMyTeam, lstMyTeam, lstEmpty)

    fTeamTtlEffectiveHP.Add(New FormulaElement(eModifierType.None, _
                                            eStattype.EffectiveHP, _
                                            eMathAction.InputPlusValue, mNames))
    AddStatStatDependency(eStattype.EffectiveHP, eStattype.TeamTtlEffectiveHP)


  
  End Sub

  Private Sub LoadHitPoints()
    fHitPoints = New Formula(lstSelf, lstSelf, lstEmpty)


    fHitPoints.Add(New FormulaElement(Nothing, _
                       eStattype.Strength, _
                       eMathAction.InputPlusProductofValueAndStaticVal, 19, mNames))
    AddStatStatDependency(eStattype.Strength, eStattype.HitPoints)


    fHitPoints.Add(New FormulaElement(eModifierType.HPAdded, _
                                      Nothing, _
                                      eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.HPAdded, eStattype.HitPoints)

    fHitPoints.Add(New FormulaElement(eModifierType.HealthPercentAdded, _
Nothing, _
eMathAction.SetToValueIfValueExists, mNames))
    AddStatModDependency(eModifierType.HealthPercentAdded, eStattype.HitPoints)
  End Sub
  Private Sub LoadTeamTtlHP()
    fTeamTtlHP = New Formula(lstMyTeam, lstMyTeam, lstEmpty)


    fTeamTtlHP.Add(New FormulaElement(eModifierType.None, eStattype.HitPoints, eMathAction.InputPlusValue, mNames))
    AddStatStatDependency(eStattype.HitPoints, eStattype.TeamTtlHP)

  End Sub

  Private Sub LoadTeamPhysicalArmor()
    fTeamPhysicalArmor = New Formula(lstMyTeam, lstMyTeam, lstEmpty)

    fTeamPhysicalArmor.Add(New FormulaElement(eModifierType.None, eStattype.PhysicalArmor, eMathAction.InputPlusValue, mNames))
    AddStatStatDependency(eStattype.PhysicalArmor, eStattype.TeamPhysicalArmor)

  End Sub
  Private Sub LoadHitPointRegen()
    fHitPointRegen = New Formula(lstSelf, lstSelf, lstSelf)

    fHitPointRegen.Add(New FormulaElement(eModifierType.HealthRegenAdded, _
                                          Nothing, _
                                          eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.HealthRegenAdded, eStattype.HitPointRegen)

    fHitPointRegen.Add(New FormulaElement(eModifierType.HPRegenAdded, _
                                          Nothing, _
                                          eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.HPRegenAdded, eStattype.HitPointRegen)

    fHitPointRegen.Add(New FormulaElement(eModifierType.HPRegenSubtracted, _
                                          Nothing, _
                                          eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.HPRegenSubtracted, eStattype.HitPointRegen)

    fHitPointRegen.Add(New FormulaElement(eModifierType.HPRegenPercentofCasters, _
                                          Nothing, _
                                          eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.HPRegenPercentofCasters, eStattype.HitPointRegen)

    fHitPointRegen.Add(New FormulaElement(eModifierType.HPRegenPerUnitKilledAdded, _
                                          Nothing, _
                                          eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.HPRegenPerUnitKilledAdded, eStattype.HitPointRegen)

    fHitPointRegen.Add(New FormulaElement(eModifierType.HPRegenPercent, _
                                          Nothing, _
                                          eMathAction.InputPlusPercentageOfPrePercValue, mNames))
    AddStatModDependency(eModifierType.HPRegenPercent, eStattype.HitPointRegen)

    fHitPointRegen.Add(New FormulaElement(eModifierType.HealthvalueFrozen, _
                                          Nothing, _
                                          eMathAction.SetToValueIfValueExists, mNames))
    AddStatModDependency(eModifierType.HealthvalueFrozen, eStattype.HitPointRegen)

  End Sub
  Private Sub LoadTeamTtlHPRegen()
    fTeamTtlHPRegen = New Formula(lstMyTeam, lstMyTeam, lstMyTeam)

    fTeamTtlHPRegen.Add(New FormulaElement(eModifierType.None, _
                                      eStattype.HitPointRegen, _
                                      eMathAction.InputPlusValue, mNames))
    AddStatStatDependency(eStattype.HitPointRegen, eStattype.TeamTtlHPRegen)

  End Sub

  Private Sub LoadTeamMagicResistance()
    fTeamMagicResistance = New Formula(lstMyTeam, lstMyTeam, lstMyTeam)

    fTeamMagicResistance.Add(New FormulaElement(eModifierType.None, _
                                                eStattype.MagicalDamageResistance, _
                                                eMathAction.InputPlusValue, mNames))
    AddStatStatDependency(eStattype.MagicalDamageResistance, eStattype.TeamMagicResistance)

  End Sub

  Private Sub LoadMana()
    fMana = New Formula(lstSelf, lstSelf, lstSelf)

    fMana.Add(New FormulaElement(Nothing, _
                         eStattype.Intelligence, _
                         eMathAction.InputPlusProductofValueAndStaticVal, 13, mNames))
    AddStatStatDependency(eStattype.Intelligence, eStattype.Mana)

    fMana.Add(New FormulaElement(eModifierType.MaxManaAdded, _
                                 Nothing, _
                                 eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.MaxManaAdded, eStattype.Mana)
  End Sub
  Private Sub LoadTeamTtlMana()
    fTeamTtlMana = New Formula(lstMyTeam, lstMyTeam, lstEmpty)

    fTeamTtlMana.Add(New FormulaElement(Nothing, _
                     eStattype.Mana, _
                     eMathAction.InputPlusValue, 13, mNames))
    AddStatStatDependency(eStattype.Mana, eStattype.TeamTtlMana)

 


  End Sub

  Private Sub LoadManaRegen()
    fManaRegen = New Formula(lstSelf, lstSelf, lstSelf)

    fManaRegen.Add(New FormulaElement(eModifierType.ManaRegenAdded, _
                                      Nothing, _
                                      eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.ManaRegenAdded, eStattype.ManaRegen)

    fManaRegen.Add(New FormulaElement(eModifierType.ManaRegenSubtracted, _
                                      Nothing, _
                                      eMathAction.InputMinusValue, mNames))
    AddStatModDependency(eModifierType.ManaRegenSubtracted, eStattype.ManaRegen)

    fManaRegen.Add(New FormulaElement(eModifierType.ManaRegenPercentofCasters, _
                                      Nothing, _
                                      eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.ManaRegenPercentofCasters, eStattype.ManaRegen)

    fManaRegen.Add(New FormulaElement(eModifierType.ManaRegenPerUnitKillAdded, _
                                      Nothing, _
                                      eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.ManaRegenPerUnitKillAdded, eStattype.ManaRegen)

    fManaRegen.Add(New FormulaElement(eModifierType.ManaRegenPercent, _
                                      Nothing, _
                                      eMathAction.InputPlusPercentageOfPrePercValue, mNames))
    AddStatModDependency(eModifierType.ManaRegenPercent, eStattype.ManaRegen)
  End Sub
  Private Sub LoadTeamTtlManaRegen()
    fTeamTtlManaRegen = New Formula(lstMyTeam, lstMyTeam, lstMyTeam)

    fTeamTtlManaRegen.Add(New FormulaElement(eModifierType.None, _
                                  eStattype.ManaRegen, _
                                  eMathAction.InputPlusValue, mNames))
    AddStatStatDependency(eStattype.ManaRegen, eStattype.TeamTtlManaRegen)


  End Sub

  Private Sub LoadPhysicalArmor()
    fPhysicalArmor = New Formula(lstSelf, lstSelf, lstSelf)

    'calc agility percentag
    fPhysicalArmor.Add(New FormulaElement(Nothing, _
                       eStattype.Agility, _
                       eMathAction.InputPlusProductofValueAndStaticVal, 0.14, mNames))
    AddStatStatDependency(eStattype.Agility, eStattype.PhysicalArmor)

    fPhysicalArmor.Add(New FormulaElement(eModifierType.BaseArmor, _
                                  Nothing, _
                                  eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.BaseArmor, eStattype.PhysicalArmor)

    'fPhysicalArmor.Add(New FormulaElement(eModifierType.BaseArmorNegative, _
    '                                      Nothing, _
    '                                      eMathAction.InputMinusValue))

    fPhysicalArmor.Add(New FormulaElement(eModifierType.BaseArmorDebuff, _
                                          Nothing, _
                                          eMathAction.InputMinusValue, mNames))
    AddStatModDependency(eModifierType.BaseArmorDebuff, eStattype.PhysicalArmor)

    fPhysicalArmor.Add(New FormulaElement(eModifierType.BaseArmorPercentSubtracted, _
                                      Nothing, _
                                      eMathAction.InputMinusValue, mNames))
    AddStatModDependency(eModifierType.BaseArmorPercentSubtracted, eStattype.PhysicalArmor)

    'fPhysicalArmor.Add(New FormulaElement(eModifierType.AgilityFactorForArmor, _
    '                                    Nothing, _
    '                                    eMathAction.InputMultipliedue))

    fPhysicalArmor.Add(New FormulaElement(eModifierType.ArmorAdded, _
                                          Nothing, _
                                          eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.ArmorAdded, eStattype.PhysicalArmor)

    fPhysicalArmor.Add(New FormulaElement(eModifierType.ArmorAddedPerSec, _
                                      Nothing, _
                                      eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.ArmorAddedPerSec, eStattype.PhysicalArmor)

    fPhysicalArmor.Add(New FormulaElement(eModifierType.ArmoroT, _
                                         Nothing, _
                                         eMathAction.InputMinusValue, mNames))
    AddStatModDependency(eModifierType.ArmoroT, eStattype.PhysicalArmor)

    fPhysicalArmor.Add(New FormulaElement(eModifierType.ArmorStackSubtracted, _
                                      Nothing, _
                                      eMathAction.InputMinusValue, mNames))
    AddStatModDependency(eModifierType.ArmorStackSubtracted, eStattype.PhysicalArmor)

    fPhysicalArmor.Add(New FormulaElement(eModifierType.ArmorSubtracted, _
                                  Nothing, _
                                  eMathAction.InputMinusValue, mNames))
    AddStatModDependency(eModifierType.ArmorSubtracted, eStattype.PhysicalArmor)

    fPhysicalArmor.Add(New FormulaElement(eModifierType.ArmorSubtractedoT, _
                                  Nothing, _
                                  eMathAction.InputMinusValue, mNames))
    AddStatModDependency(eModifierType.ArmorSubtractedoT, eStattype.PhysicalArmor)

    fPhysicalArmor.Add(New FormulaElement(eModifierType.ArmorPercentage, _
                                  Nothing, _
                                  eMathAction.InputMinusValue, mNames))
    AddStatModDependency(eModifierType.ArmorPercentage, eStattype.PhysicalArmor)


  End Sub
  Private Sub LoadMagicalDamageResistance()
    fMagicalDamageResistance = New Formula(lstSelf, lstSelf, lstSelf)


    fMagicalDamageResistance.Add(New FormulaElement(eModifierType.BaseMagicResistance, _
                 Nothing, _
                 eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.BaseMagicResistance, eStattype.MagicalDamageResistance)

    fMagicalDamageResistance.Add(New FormulaElement(eModifierType.BaseMagicResistancePercentSubtracted, _
         Nothing, _
         eMathAction.InputMinusPercetageofPrePercValue, mNames))
    AddStatModDependency(eModifierType.BaseMagicResistancePercentSubtracted, eStattype.MagicalDamageResistance)

    fMagicalDamageResistance.Add(New FormulaElement(eModifierType.DamageMagicalAbsorbed, _
                     Nothing, _
                     eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamageMagicalAbsorbed, eStattype.MagicalDamageResistance)


    fMagicalDamageResistance.Add(New FormulaElement(eModifierType.MagicResistanceAdded, _
                  Nothing, _
                  eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.MagicResistanceAdded, eStattype.MagicalDamageResistance)

    fMagicalDamageResistance.Add(New FormulaElement(eModifierType.MagicResistanceSubtracted, _
                     Nothing, _
                     eMathAction.InputMinusValue, mNames))
    AddStatModDependency(eModifierType.MagicResistanceSubtracted, eStattype.MagicalDamageResistance)

    fMagicalDamageResistance.Add(New FormulaElement(eModifierType.MagicResistancePercentAdded, _
                     Nothing, _
                     eMathAction.InputPlusPercentageOfPrePercValue, mNames))
    AddStatModDependency(eModifierType.MagicResistancePercentAdded, eStattype.MagicalDamageResistance)



    fMagicalDamageResistance.Add(New FormulaElement(eModifierType.BaseMagicResistancePercentSubtracted, _
             Nothing, _
             eMathAction.InputMinusPercetageofPrePercValue, mNames))
    AddStatModDependency(eModifierType.BaseMagicResistancePercentSubtracted, eStattype.MagicalDamageResistance)

    fMagicalDamageResistance.Add(New FormulaElement(eModifierType.MagicResistanceSet, _
         Nothing, _
         eMathAction.SetToValueIfValueExists, mNames))
    AddStatModDependency(eModifierType.MagicResistanceSet, eStattype.MagicalDamageResistance)

    fMagicalDamageResistance.Add(New FormulaElement(eModifierType.DamageMagicalImmunity, _
         Nothing, _
         eMathAction.SetToMaxValueIfValueExists, mNames))
    AddStatModDependency(eModifierType.DamageMagicalImmunity, eStattype.MagicalDamageResistance)

    fMagicalDamageResistance.Add(New FormulaElement(eModifierType.MagicResistanceCapped, _
         Nothing, _
         eMathAction.SetToMaxValueIfValueExists, mNames))
    AddStatModDependency(eModifierType.MagicResistanceCapped, eStattype.MagicalDamageResistance)

  End Sub
  Private Sub LoadMagicImmunityTimeBurst()
    fMagicImmunityTimeBurst = New Formula(lstSelf, lstSelf, lstSelf)

    fMagicImmunityTimeBurst.Add(New FormulaElement(eModifierType.MagicImmunity, _
                                                   Nothing, _
                                                   eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.MagicImmunity, eStattype.MagicImmunity)


    fMagicImmunityTimeBurst.Add(New FormulaElement(eModifierType.DamageMagicalImmunity, _
                                                   Nothing, _
                                                   eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamageMagicalImmunity, eStattype.MagicImmunity)

    fMagicImmunityTimeBurst.Add(New FormulaElement(eModifierType.SpellBlockDuration, _
                                                   Nothing, _
                                                   eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.SpellBlockDuration, eStattype.MagicImmunity)

  End Sub
  Private Sub LoadMagicImmunityTimeAvg()

  End Sub

  Private Sub LoadVisionDay()
    fVisionday = New Formula(lstSelf, lstSelf, lstSelf)

    fVisionday.Add(New FormulaElement(eModifierType.Vision, _
                                      Nothing, _
                                      eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.Vision, eStattype.VisionDay)

    fVisionday.Add(New FormulaElement(eModifierType.VisionDay, _
                                      Nothing, _
                                      eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.VisionDay, eStattype.VisionDay)



    fVisionday.Add(New FormulaElement(eModifierType.VisionNightAdded, _
                                      Nothing, _
                                      eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.VisionNightAdded, eStattype.VisionDay)
  End Sub
  Private Sub LoadTeamTtlVisionDay()
    fTeamTtlVisionDay = New Formula(lstMyTeam, lstMyTeam, lstMyTeam)

    fTeamTtlVisionDay.Add(New FormulaElement(eModifierType.None, _
                                  eStattype.VisionDay, _
                                  eMathAction.InputPlusValue, mNames))
    AddStatStatDependency(eModifierType.VisionDay, eStattype.TeamTtlVisionDay)

  End Sub

  Private Sub LoadVisionNight()
    fVisionNight = New Formula(lstSelf, lstSelf, lstSelf)

    fVisionNight.Add(New FormulaElement(eModifierType.Vision, _
                                        Nothing, _
                                        eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.Vision, eStattype.VisionNight)

    fVisionNight.Add(New FormulaElement(eModifierType.VisionNight, _
                                        Nothing, _
                                        eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.VisionNight, eStattype.VisionNight)

    fVisionNight.Add(New FormulaElement(eModifierType.VisionNightAdded, _
                                        Nothing, _
                                        eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.VisionNightAdded, eStattype.VisionNight)
  End Sub
  Private Sub LoadTeamTtlVisionNight()
    fTeamTtlVisionNight = New Formula(lstMyTeam, lstMyTeam, lstMyTeam)

    fTeamTtlVisionNight.Add(New FormulaElement(eModifierType.None, _
                                    eStattype.VisionNight, _
                                    eMathAction.InputPlusValue, mNames))
    AddStatStatDependency(eStattype.VisionNight, eStattype.TeamTtlVisionNight)

 
  End Sub

  Private Sub LoadTrueSight()
    fTrueSight = New Formula(lstSelf, lstSelf, lstSelf)

    fTrueSight.Add(New FormulaElement(eModifierType.Truesight, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.Truesight, eStattype.TrueSight)

    fTrueSight.Add(New FormulaElement(eModifierType.TruesightofTarget, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.TruesightofTarget, eStattype.TrueSight)

    fTrueSight.Add(New FormulaElement(eModifierType.TruesightRadius, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.TruesightRadius, eStattype.TrueSight)
  End Sub
  Private Sub LoadStealth()
    fStealth = New Formula(lstSelf, lstSelf, lstSelf)

    fStealth.Add(New FormulaElement(eModifierType.Invisibility, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.Invisibility, eStattype.Stealth)


    fStealth.Add(New FormulaElement(eModifierType.InvisibilityWhenNotAttacking, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.InvisibilityWhenNotAttacking, eStattype.Stealth)


    fStealth.Add(New FormulaElement(eModifierType.StationaryInvisibility, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.StationaryInvisibility, eStattype.Stealth)


    fStealth.Add(New FormulaElement(eModifierType.MuteInvisibility, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.MuteInvisibility, eStattype.Stealth)

  End Sub

  Private Sub LoadStunDurationBurst() 'mystun potential
    fStunDurationBurst = New Formula(lstSelf, lstSelf, lstEmpty)

    fStunDurationBurst.Add(New FormulaElement(eModifierType.Stun, Nothing, eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.Stun, eStattype.Stun)

    fStunDurationBurst.Add(New FormulaElement(eModifierType.RightClickStun, Nothing, eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.RightClickStun, eStattype.Stun)

    fStunDurationBurst.Add(New FormulaElement(eModifierType.StunChain, Nothing, eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.StunChain, eStattype.Stun)

    fStunDurationBurst.Add(New FormulaElement(eModifierType.StunRandom, Nothing, eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.StunRandom, eStattype.Stun)

    fStunDurationBurst.Add(New FormulaElement(eModifierType.RangeStun, Nothing, eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.RangeStun, eStattype.Stun)

    fStunDurationBurst.Add(New FormulaElement(eModifierType.MiniStun, Nothing, eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.MiniStun, eStattype.Stun)

    fStunDurationBurst.Add(New FormulaElement(eModifierType.MeleeStun, Nothing, eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.MeleeStun, eStattype.Stun)

    fStunDurationBurst.Add(New FormulaElement(eModifierType.AdaptiveStrikeStun, Nothing, eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.AdaptiveStrikeStun, eStattype.Stun)

  End Sub
  Private Sub LoadTeamTtlStunDuratoin()
    fTeamTtlStunDuratoin = New Formula(lstMyTeam, lstMyTeam, lstEmpty)

    fTeamTtlStunDuratoin.Add(New FormulaElement(eModifierType.None, eStattype.Stun, eMathAction.InputPlusValue, mNames))
    AddStatStatDependency(eStattype.Stun, eStattype.TeamTtlStunDuratoin)

  End Sub

  Private Sub LoadStunDurationAvg()

  End Sub

  Private Sub LoadHexDurationBurst() 'my hex potentia;
    fHexDurationBurst = New Formula(lstSelf, lstSelf, lstEmpty)

    fHexDurationBurst.Add(New FormulaElement(eModifierType.Hex, Nothing, eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.Hex, eStattype.Hex)


  End Sub
  Private Sub LoadTeamTtlHexDuration()
    fTeamTtlHexDuration = New Formula(lstMyTeam, lstMyTeam, lstEmpty)

    fTeamTtlHexDuration.Add(New FormulaElement(eModifierType.None, eStattype.Hex, eMathAction.InputPlusValue, mNames))
    AddStatStatDependency(eStattype.Hex, eStattype.TeamTtlHexDuration)
  End Sub

  Private Sub LoadHexDurationAvg()

  End Sub



#Region "LoadAttackDamage"
  Private Sub LoadAttackDamageLow()
    fAttackDamageLow = New Formula(lstSelf, lstSelf, lstEmpty)
    'modtypes.Add(eModifierType.RightClickAttackAttackSlowInflicted) 'Right click attack also adds an attack speed debuff to target 
    fAttackDamageLow.Add(New FormulaElement(eModifierType.BaseAttackDamageLow, _
                                            Nothing, _
                                            eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.BaseAttackDamageLow, eStattype.AttackDamageLow)

    LoadAttackDamage(fAttackDamageLow)

  End Sub
  Private Sub LoadTeamTtlDamageLo()
    fTeamTtlDamageLo = New Formula(lstMyTeam, lstMyTeam, lstEmpty)

    fTeamTtlDamageLo.Add(New FormulaElement(eModifierType.None, _
                                          eStattype.AttackDamageLow, _
                                          eMathAction.InputPlusValue, mNames))
    AddStatStatDependency(eStattype.AttackDamageLow, eStattype.TeamTtlDamageLo)



  End Sub

  Private Sub LoadAttackDamageHigh()
    fAttackDamageHigh = New Formula(lstSelf, lstSelf, lstEmpty)
    'modtypes.Add(eModifierType.RightClickAttackAttackSlowInflicted) 'Right click attack also adds an attack speed debuff to target 
    fAttackDamageHigh.Add(New FormulaElement(eModifierType.BaseAttackDamageHigh, _
                                            Nothing, _
                                            eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.BaseAttackDamageHigh, eStattype.AttackDamageHigh)

    LoadAttackDamage(fAttackDamageHigh)
  End Sub
  Private Sub LoadTeamTtlDamageHi()
    fTeamTtlDamageHi = New Formula(lstMyTeam, lstMyTeam, lstEmpty)

    fTeamTtlDamageHi.Add(New FormulaElement(eModifierType.None, _
                                        eStattype.AttackDamageHigh, _
                                        eMathAction.InputPlusValue, mNames))
    AddStatStatDependency(eStattype.AttackDamageHigh, eStattype.TeamTtlDamageHi)

  End Sub

  Private Sub LoadAttackDamageAvg()
    fRightclickDamageAvg = New Formula(lstSelf, lstSelf, lstEmpty)

    fRightclickDamageAvg.Add(New FormulaElement(eModifierType.BaseAttackDamageAvg, _
                                            Nothing, _
                                            eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.BaseAttackDamageAvg, eStattype.AttackDamageAverage)

    LoadAttackDamage(fRightclickDamageAvg)
  End Sub
  Private Sub LoadTeamTtlDamageAvg()
    fTeamttlDamageAvg = New Formula(lstMyTeam, lstMyTeam, lstEmpty)

    fTeamTtlDamageAvg.Add(New FormulaElement(eModifierType.None, _
                                         eStattype.AttackDamageAverage, _
                                         eMathAction.InputPlusValue, mNames))
    AddStatStatDependency(eStattype.AttackDamageAverage, eStattype.TeamTtlDamageAvg)


  End Sub


  Private Sub LoadAttackDamage(preloadedformula As Formula)

    preloadedformula.Add(New FormulaElement(eModifierType.RightClickDamageFromPrimaryAtt, _
                                            Nothing, _
                                            eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.RightClickDamageFromPrimaryAtt, eStattype.AttackDamageAverage)
    AddStatModDependency(eModifierType.RightClickDamageFromPrimaryAtt, eStattype.AttackDamageHigh)
    AddStatModDependency(eModifierType.RightClickDamageFromPrimaryAtt, eStattype.AttackDamageLow)

    'preloadedformula.Add(New FormulaElement(Nothing, eStat.PrimaryAttribute, _
    '                                        eMathAction.InputPlusValue))

    preloadedformula.Add(New FormulaElement(eModifierType.RightClickAttackDamage, _
                                        Nothing, _
                                        eMathAction.InputPlusValue, mNames)) 'Ember's Sleight of Fist, represents the damge from one instance of rightclick damage 
    AddStatModDependency(eModifierType.RightClickAttackDamage, eStattype.AttackDamageAverage)
    AddStatModDependency(eModifierType.RightClickAttackDamage, eStattype.AttackDamageHigh)
    AddStatModDependency(eModifierType.RightClickAttackDamage, eStattype.AttackDamageLow)


    preloadedformula.Add(New FormulaElement(eModifierType.RightClickBonusDamageAdded, _
                                            Nothing, _
                                            eMathAction.InputPlusValue, mNames)) 'TB Metamorphosis
    AddStatModDependency(eModifierType.RightClickBonusDamageAdded, eStattype.AttackDamageAverage)
    AddStatModDependency(eModifierType.RightClickBonusDamageAdded, eStattype.AttackDamageHigh)
    AddStatModDependency(eModifierType.RightClickBonusDamageAdded, eStattype.AttackDamageLow)

    preloadedformula.Add(New FormulaElement(eModifierType.RightClickBonusDamageInflicted, _
                                            Nothing, _
                                            eMathAction.InputPlusValue, mNames)) 'Faceless Void Time Lock 
    AddStatModDependency(eModifierType.RightClickBonusDamageInflicted, eStattype.AttackDamageAverage)
    AddStatModDependency(eModifierType.RightClickBonusDamageInflicted, eStattype.AttackDamageHigh)
    AddStatModDependency(eModifierType.RightClickBonusDamageInflicted, eStattype.AttackDamageLow)


    preloadedformula.Add(New FormulaElement(eModifierType.RightClickCounterAttack, _
                                                          Nothing, _
                                                          eMathAction.InputPlusValue, mNames)) 'Axw counter helix, LC MomentofCOurage 
    AddStatModDependency(eModifierType.RightClickCounterAttack, eStattype.AttackDamageAverage)
    AddStatModDependency(eModifierType.RightClickCounterAttack, eStattype.AttackDamageHigh)
    AddStatModDependency(eModifierType.RightClickCounterAttack, eStattype.AttackDamageLow)


    preloadedformula.Add(New FormulaElement(eModifierType.RightClickDamageAdded, _
                                            Nothing, _
                                            eMathAction.InputPlusValue, mNames)) 'LC Duel 
    AddStatModDependency(eModifierType.RightClickDamageAdded, eStattype.AttackDamageAverage)
    AddStatModDependency(eModifierType.RightClickDamageAdded, eStattype.AttackDamageHigh)
    AddStatModDependency(eModifierType.RightClickDamageAdded, eStattype.AttackDamageLow)


    preloadedformula.Add(New FormulaElement(eModifierType.RightClickDamageAsLine, _
                                            Nothing, _
                                            eMathAction.InputPlusValue, mNames)) 'TA Psi blades. RightClick damage now emanates in line away from TA so multitargets 
    AddStatModDependency(eModifierType.RightClickDamageAsLine, eStattype.AttackDamageAverage)
    AddStatModDependency(eModifierType.RightClickDamageAsLine, eStattype.AttackDamageHigh)
    AddStatModDependency(eModifierType.RightClickDamageAsLine, eStattype.AttackDamageLow)


    preloadedformula.Add(New FormulaElement(eModifierType.RightClickDamageAsPercOfTargetCurrHP, _
                                            Nothing, _
                                            eMathAction.InputPlusValue, mNames)) 'lifestealer Feast 
    AddStatModDependency(eModifierType.RightClickDamageAsPercOfTargetCurrHP, eStattype.AttackDamageAverage)
    AddStatModDependency(eModifierType.RightClickDamageAsPercOfTargetCurrHP, eStattype.AttackDamageHigh)
    AddStatModDependency(eModifierType.RightClickDamageAsPercOfTargetCurrHP, eStattype.AttackDamageLow)

    preloadedformula.Add(New FormulaElement(eModifierType.RightClickDamageInflicted, _
                                            Nothing, _
                                            eMathAction.InputPlusValue, mNames)) 'Windranger Focus Fire 
    AddStatModDependency(eModifierType.RightClickDamageInflicted, eStattype.AttackDamageAverage)
    AddStatModDependency(eModifierType.RightClickDamageInflicted, eStattype.AttackDamageHigh)
    AddStatModDependency(eModifierType.RightClickDamageInflicted, eStattype.AttackDamageLow)

    ' modtypes.Add(eModifierType.RightClickDamageInstanceAvoided) 'Faceless BackTrack 

    preloadedformula.Add(New FormulaElement(eModifierType.RightClickDamageMultipleInflicted, _
                                            Nothing, _
                                            eMathAction.InputPlusValue, mNames)) 'Phantom Ass, Coup de Grace 
    AddStatModDependency(eModifierType.RightClickDamageMultipleInflicted, eStattype.AttackDamageAverage)
    AddStatModDependency(eModifierType.RightClickDamageMultipleInflicted, eStattype.AttackDamageHigh)
    AddStatModDependency(eModifierType.RightClickDamageMultipleInflicted, eStattype.AttackDamageLow)


    preloadedformula.Add(New FormulaElement(eModifierType.RightClickDamageoT, _
                                            Nothing, _
                                            eMathAction.InputPlusValue, mNames)) 'Right Click attack also puts a DoT on target 
    AddStatModDependency(eModifierType.RightClickDamageoT, eStattype.AttackDamageAverage)
    AddStatModDependency(eModifierType.RightClickDamageoT, eStattype.AttackDamageHigh)
    AddStatModDependency(eModifierType.RightClickDamageoT, eStattype.AttackDamageLow)


    'modtypes.Add(eModifierType.RightClickDamagePercentSubtracted) 'SF Requiem of Souls 

    preloadedformula.Add(New FormulaElement(eModifierType.RightClickDamageWithBuffs, _
                                            Nothing, _
                                            eMathAction.InputPlusValue, mNames)) 'gyro flak cannon 
    AddStatModDependency(eModifierType.RightClickDamageWithBuffs, eStattype.AttackDamageAverage)
    AddStatModDependency(eModifierType.RightClickDamageWithBuffs, eStattype.AttackDamageHigh)
    AddStatModDependency(eModifierType.RightClickDamageWithBuffs, eStattype.AttackDamageLow)


    preloadedformula.Add(New FormulaElement(eModifierType.RightClickDamageWithoutBuffs, _
                                            Nothing, _
                                            eMathAction.InputPlusValue, mNames)) 'gyro flak cannon 
    AddStatModDependency(eModifierType.RightClickDamageWithoutBuffs, eStattype.AttackDamageAverage)
    AddStatModDependency(eModifierType.RightClickDamageWithoutBuffs, eStattype.AttackDamageHigh)
    AddStatModDependency(eModifierType.RightClickDamageWithoutBuffs, eStattype.AttackDamageLow)


    preloadedformula.Add(New FormulaElement(eModifierType.RightClickDamPhysStackingInflicted, _
                                            Nothing, _
                                            eMathAction.InputPlusValue, mNames)) 'Ursa furry swipes 
    AddStatModDependency(eModifierType.RightClickDamPhysStackingInflicted, eStattype.AttackDamageAverage)
    AddStatModDependency(eModifierType.RightClickDamPhysStackingInflicted, eStattype.AttackDamageHigh)
    AddStatModDependency(eModifierType.RightClickDamPhysStackingInflicted, eStattype.AttackDamageLow)



    ' modtypes.Add(eModifierType.RightClickInttoPureDamage) 'Silencer Glaives of Wisdom. deals a percentage of silencer's int as pure damage 
    ' modtypes.Add(eModifierType.RightClickMoveSpeedPercSubtracted) 'Meepo Geostrike 

    preloadedformula.Add(New FormulaElement(eModifierType.RightClickNetherToxinDamage, _
                                            Nothing, _
                                            eMathAction.InputPlusValue, mNames)) 'Viper Nethertoxin does damage for each 20% of health missing in target 
    AddStatModDependency(eModifierType.RightClickNetherToxinDamage, eStattype.AttackDamageAverage)
    AddStatModDependency(eModifierType.RightClickNetherToxinDamage, eStattype.AttackDamageHigh)
    AddStatModDependency(eModifierType.RightClickNetherToxinDamage, eStattype.AttackDamageLow)


    preloadedformula.Add(New FormulaElement(eModifierType.RightClickHealthasDamagePercInflicted, _
                                           Nothing, _
                                           eMathAction.InputPlusPercentageOfPrePercValue, mNames)) 'Ursa Enrage 
    AddStatModDependency(eModifierType.RightClickHealthasDamagePercInflicted, eStattype.AttackDamageAverage)
    AddStatModDependency(eModifierType.RightClickHealthasDamagePercInflicted, eStattype.AttackDamageHigh)
    AddStatModDependency(eModifierType.RightClickHealthasDamagePercInflicted, eStattype.AttackDamageLow)



    preloadedformula.Add(New FormulaElement(eModifierType.RightClickDamagePercentageInflicted, _
                                        Nothing, _
                                        eMathAction.InputPlusPercentageOfPrePercValue, mNames)) 'Phantom Lancer Spirit Lance Illusion damage 
    AddStatModDependency(eModifierType.RightClickDamagePercentageInflicted, eStattype.AttackDamageAverage)
    AddStatModDependency(eModifierType.RightClickDamagePercentageInflicted, eStattype.AttackDamageHigh)
    AddStatModDependency(eModifierType.RightClickDamagePercentageInflicted, eStattype.AttackDamageLow)


    preloadedformula.Add(New FormulaElement(eModifierType.RightClickDamageMultiplier, _
                                            Nothing, _
                                            eMathAction.InputMultipliedByValue, mNames)) 'weaver germinate 
    AddStatModDependency(eModifierType.RightClickDamageMultiplier, eStattype.AttackDamageAverage)
    AddStatModDependency(eModifierType.RightClickDamageMultiplier, eStattype.AttackDamageHigh)
    AddStatModDependency(eModifierType.RightClickDamageMultiplier, eStattype.AttackDamageLow)


    preloadedformula.Add(New FormulaElement(eModifierType.RightClickMoonGlaiveBounces, _
                                            Nothing, _
                                            eMathAction.InputMultipliedByValue, mNames)) 'Luna moon glaive 
    AddStatModDependency(eModifierType.RightClickMoonGlaiveBounces, eStattype.AttackDamageAverage)
    AddStatModDependency(eModifierType.RightClickMoonGlaiveBounces, eStattype.AttackDamageHigh)
    AddStatModDependency(eModifierType.RightClickMoonGlaiveBounces, eStattype.AttackDamageLow)


    preloadedformula.Add(New FormulaElement(eModifierType.RightClickDamagePercentSubtracted, _
                                            Nothing, _
                                            eMathAction.InputMinusPercetageofPrePercValue, mNames)) 'SF Requiem of Souls 
    AddStatModDependency(eModifierType.RightClickDamagePercentSubtracted, eStattype.AttackDamageAverage)
    AddStatModDependency(eModifierType.RightClickDamagePercentSubtracted, eStattype.AttackDamageHigh)
    AddStatModDependency(eModifierType.RightClickDamagePercentSubtracted, eStattype.AttackDamageLow)
  End Sub
#End Region
  Private Sub LoadCritChance()
    fCritChance = New Formula(lstSelf, lstSelf, lstSelf)

    fCritChance.Add(New FormulaElement(eModifierType.CritChance, Nothing, eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.CritChance, eStattype.CritChance)
  End Sub
  Private Sub LoadCritDamageMultiplier()
    fCritDamageMultiplier = New Formula(lstSelf, lstSelf, lstSelf)

    fCritDamageMultiplier.Add(New FormulaElement(eModifierType.CritMultiplier, Nothing, eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.CritMultiplier, eStattype.CritMultiplier)

    Dim x = eModifierType.CritDamage
  End Sub
  Private Sub LoadCritDamage() 'my drite damage potential
    fCritDamage = New Formula(lstSelf, lstSelf, lstSelf)

    fCritDamage.Add(New FormulaElement(eModifierType.CritDamage, Nothing, eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.CritDamage, eStattype.CritDamage)

  End Sub

  Private Sub LoadPhysicalDamage()
    fPhysicalDamage = New Formula(lstSelf, lstSelf, lstEmpty)

    fPhysicalDamage.Add(New FormulaElement(eModifierType.BaseAttackDamageAvg, _
                                           Nothing, _
                                           eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.BaseAttackDamageAvg, eStattype.PhysicalDamage)


    fPhysicalDamage.Add(New FormulaElement(eModifierType.PrimaryStatDamage, _
                                       Nothing, _
                                       eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.PrimaryStatDamage, eStattype.PhysicalDamage)

    fPhysicalDamage.Add(New FormulaElement(eModifierType.DamageChainPhysicalInflicted, _
                                       Nothing, _
                                       eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamageChainPhysicalInflicted, eStattype.PhysicalDamage)

    fPhysicalDamage.Add(New FormulaElement(eModifierType.DamagePhysicalAdded, _
                                           Nothing, _
                                           eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamagePhysicalAdded, eStattype.PhysicalDamage)

    fPhysicalDamage.Add(New FormulaElement(eModifierType.DamagePhysicalBouncesInflicted, _
                                       Nothing, _
                                       eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamagePhysicalBouncesInflicted, eStattype.PhysicalDamage)

    fPhysicalDamage.Add(New FormulaElement(eModifierType.DamagePhysicalEarthSplitterAdded, _
                                       Nothing, _
                                       eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamagePhysicalEarthSplitterAdded, eStattype.PhysicalDamage)

    fPhysicalDamage.Add(New FormulaElement(eModifierType.DamagePhysicalImmunity, _
                                       Nothing, _
                                       eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamagePhysicalImmunity, eStattype.PhysicalDamage)

    fPhysicalDamage.Add(New FormulaElement(eModifierType.DamagePhysicalIncomingIncreasedPercent, _
                                       Nothing, _
                                       eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamagePhysicalIncomingIncreasedPercent, eStattype.PhysicalDamage)

    fPhysicalDamage.Add(New FormulaElement(eModifierType.DamagePhysicalInflicted, _
                                       Nothing, _
                                       eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamagePhysicalInflicted, eStattype.PhysicalDamage)

    fPhysicalDamage.Add(New FormulaElement(eModifierType.DamagePhysicaloT, _
                                       Nothing, _
                                       eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamagePhysicaloT, eStattype.PhysicalDamage)

    fPhysicalDamage.Add(New FormulaElement(eModifierType.DamagePhysicalPercent, _
                                       Nothing, _
                                       eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamagePhysicalPercent, eStattype.PhysicalDamage)


    fPhysicalDamage.Add(New FormulaElement(eModifierType.DamagePhysicalPerSec, _
                                       Nothing, _
                                       eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamagePhysicalPerSec, eStattype.PhysicalDamage)

    fPhysicalDamage.Add(New FormulaElement(eModifierType.DamagePhysicalStackingInflicted, _
                                       Nothing, _
                                       eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamagePhysicalStackingInflicted, eStattype.PhysicalDamage)


    fPhysicalDamage.Add(New FormulaElement(eModifierType.DamagePhysicalSubtracted, _
                                       Nothing, _
                                       eMathAction.InputMinusValue, mNames))
    AddStatModDependency(eModifierType.DamagePhysicalSubtracted, eStattype.PhysicalDamage)


    fPhysicalDamage.Add(New FormulaElement(eModifierType.DamagePierceAdded, _
                                       Nothing, _
                                       eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamagePierceAdded, eStattype.PhysicalDamage)


    fPhysicalDamage.Add(New FormulaElement(eModifierType.DamagePierceChancePercent, _
                                       Nothing, _
                                       eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamagePierceChancePercent, eStattype.PhysicalDamage)


    fPhysicalDamage.Add(New FormulaElement(eModifierType.DamageRangeAdded, _
                                       Nothing, _
                                       eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamageRangeAdded, eStattype.PhysicalDamage)


    fPhysicalDamage.Add(New FormulaElement(eModifierType.HPRemovalSharedWithBoundUnits, _
                                   Nothing, _
                                   eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.HPRemovalSharedWithBoundUnits, eStattype.PhysicalDamage)

    fPhysicalDamage.Add(New FormulaElement(eModifierType.RightClickAttackDamage, _
                                   Nothing, _
                                   eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.RightClickAttackDamage, eStattype.PhysicalDamage)

    fPhysicalDamage.Add(New FormulaElement(eModifierType.RightClickBonusDamageAdded, _
                                   Nothing, _
                                   eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.RightClickBonusDamageAdded, eStattype.PhysicalDamage)

    fPhysicalDamage.Add(New FormulaElement(eModifierType.RightClickBonusDamageInflicted, _
                                   Nothing, _
                                   eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.RightClickBonusDamageInflicted, eStattype.PhysicalDamage)


    fPhysicalDamage.Add(New FormulaElement(eModifierType.RightClickCounterAttack, _
                                       Nothing, _
                                       eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.RightClickCounterAttack, eStattype.PhysicalDamage)

    fPhysicalDamage.Add(New FormulaElement(eModifierType.RightClickDamageAdded, _
                                   Nothing, _
                                   eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.RightClickDamageAdded, eStattype.PhysicalDamage)

    fPhysicalDamage.Add(New FormulaElement(eModifierType.RightClickDamageAsLine, _
                                   Nothing, _
                                   eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.RightClickDamageAsLine, eStattype.PhysicalDamage)

    fPhysicalDamage.Add(New FormulaElement(eModifierType.RightClickDamageAsPercOfTargetCurrHP, _
                                   Nothing, _
                                   eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.RightClickDamageAsPercOfTargetCurrHP, eStattype.PhysicalDamage)

    fPhysicalDamage.Add(New FormulaElement(eModifierType.RightClickDamageInflicted, _
                                   Nothing, _
                                   eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.RightClickDamageInflicted, eStattype.PhysicalDamage)


    fPhysicalDamage.Add(New FormulaElement(eModifierType.RightClickDamageoT, _
                               Nothing, _
                               eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.RightClickDamageoT, eStattype.PhysicalDamage)


    fPhysicalDamage.Add(New FormulaElement(eModifierType.RightClickDamageWithBuffs, _
                           Nothing, _
                           eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.RightClickDamageWithBuffs, eStattype.PhysicalDamage)



    fPhysicalDamage.Add(New FormulaElement(eModifierType.RightClickDamageWithoutBuffs, _
                               Nothing, _
                               eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.RightClickDamageWithoutBuffs, eStattype.PhysicalDamage)

    fPhysicalDamage.Add(New FormulaElement(eModifierType.RightClickDamPhysStackingInflicted, _
                               Nothing, _
                               eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.RightClickDamPhysStackingInflicted, eStattype.PhysicalDamage)

    fPhysicalDamage.Add(New FormulaElement(eModifierType.RightClickHealthasDamagePercInflicted, _
                               Nothing, _
                               eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.RightClickHealthasDamagePercInflicted, eStattype.PhysicalDamage)


    fPhysicalDamage.Add(New FormulaElement(eModifierType.RightClickMoonGlaiveBounces, _
                          Nothing, _
                          eMathAction.InputMultipliedByValue, mNames))
    AddStatModDependency(eModifierType.RightClickMoonGlaiveBounces, eStattype.PhysicalDamage)

    fPhysicalDamage.Add(New FormulaElement(eModifierType.RightClickNetherToxinDamage, _
                          Nothing, _
                          eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.RightClickNetherToxinDamage, eStattype.PhysicalDamage)

    fPhysicalDamage.Add(New FormulaElement(eModifierType.RightClickDamagePercentageInflicted, _
                           Nothing, _
                           eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.RightClickDamagePercentageInflicted, eStattype.PhysicalDamage)

    fPhysicalDamage.Add(New FormulaElement(eModifierType.RightClickDamageMultipleInflicted, _
                  Nothing, _
                  eMathAction.InputPlusPercentageOfPrePercValue, mNames))
    AddStatModDependency(eModifierType.RightClickDamageMultipleInflicted, eStattype.PhysicalDamage)


    fPhysicalDamage.Add(New FormulaElement(eModifierType.RightClickDamagePercentSubtracted, _
          Nothing, _
          eMathAction.InputMinusPercetageofPrePercValue, mNames))
    AddStatModDependency(eModifierType.RightClickDamagePercentSubtracted, eStattype.PhysicalDamage)



    fPhysicalDamage.Add(New FormulaElement(eModifierType.DamagePhysicalPercent, _
                                       Nothing, _
                                       eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamagePhysicalPercent, eStattype.PhysicalDamage)




    fPhysicalDamage.Add(New FormulaElement(eModifierType.RightClickDamageMultiplier, _
                   Nothing, _
                   eMathAction.InputMultipliedByValue, mNames))
    AddStatModDependency(eModifierType.RightClickDamageMultiplier, eStattype.PhysicalDamage)

  End Sub
  Private Sub LoadTeamTtlPhysDamageBurst()
    fTeamTtlPhysDamageBurst = New Formula(lstMyTeam, lstMyTeam, lstEmpty)

    fTeamTtlPhysDamageBurst.Add(New FormulaElement(eModifierType.None, _
                                           eStattype.PhysicalDamage, _
                                           eMathAction.InputPlusValue, mNames))
    AddStatStatDependency(eStattype.PhysicalDamage, eStattype.TeamTtlPhysDamageBurst)

  End Sub

  Private Sub LoadPhysicalDamageAvg()

  End Sub

  Private Sub LoadMagicDamage()
    fMagicDamageBurst = New Formula(lstSelf, lstSelf, lstSelf)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.AdaptiveStrikeDamageMagicalInflicted, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.AdaptiveStrikeDamageMagicalInflicted, eStattype.MagicDamage)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.AstralSpiritDamageMagicalAdded, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.AstralSpiritDamageMagicalAdded, eStattype.MagicDamage)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.BallLightDamMagicalInflicted, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.BallLightDamMagicalInflicted, eStattype.MagicDamage)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.DamageChainMagicalInflicted, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamageChainMagicalInflicted, eStattype.MagicDamage)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.DamageMagicalAdded, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamageMagicalAdded, eStattype.MagicDamage)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.DamageMagicalAddedToPhysicalAttacks, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamageMagicalAddedToPhysicalAttacks, eStattype.MagicDamage)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.DamageMagicalBouncesInflicted, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamageMagicalBouncesInflicted, eStattype.MagicDamage)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.DamageMagicalChain, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamageMagicalChain, eStattype.MagicDamage)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.DamageMagicalEarthSplitterAdded, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamageMagicalEarthSplitterAdded, eStattype.MagicDamage)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.DamageMagicalInflicted, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamageMagicalInflicted, eStattype.MagicDamage)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.DamageMagicalInflictedOnSpellCast, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamageMagicalInflictedOnSpellCast, eStattype.MagicDamage)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.DamageMagicalInflictedPerAlly, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamageMagicalInflictedPerAlly, eStattype.MagicDamage)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.DamageMagicalInflictedPerTarget, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamageMagicalInflictedPerTarget, eStattype.MagicDamage)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.DamageMagicalInflictedPerUnit, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamageMagicalInflictedPerUnit, eStattype.MagicDamage)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.DamageMagicalInflictedUntilSpellcast, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamageMagicalInflictedUntilSpellcast, eStattype.MagicDamage)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.DamageMagicalMinMaxInflicted, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamageMagicalMinMaxInflicted, eStattype.MagicDamage)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.DamageMagicaloTAsMultofStr, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamageMagicaloTAsMultofStr, eStattype.MagicDamage)


    fMagicDamageBurst.Add(New FormulaElement(eModifierType.DamageMagicalOverTimeInflicted, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamageMagicalOverTimeInflicted, eStattype.MagicDamage)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.DamageMagicalPerCreep, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamageMagicalPerCreep, eStattype.MagicDamage)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.DamageMagicalPerHero, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamageMagicalPerHero, eStattype.MagicDamage)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.DamageMagicalPerMissingHP, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamageMagicalPerMissingHP, eStattype.MagicDamage)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.DamageMagicalPerMissingMana, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamageMagicalPerMissingMana, eStattype.MagicDamage)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.DamageMagicalPerSec, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamageMagicalPerSec, eStattype.MagicDamage)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.DamageMagicalRandomInflicted, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamageMagicalRandomInflicted, eStattype.MagicDamage)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.DamageMagicalTimesInt, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamageMagicalTimesInt, eStattype.MagicDamage)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.DamageoTMagicalInflicted, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamageoTMagicalInflicted, eStattype.MagicDamage)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.ExortDamageMagicalInflicted, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.ExortDamageMagicalInflicted, eStattype.MagicDamage)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.ExortDamageMagicalInflictedoT, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.ExortDamageMagicalInflictedoT, eStattype.MagicDamage)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.HealFriendlyorMagicDamEnemyoT, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.HealFriendlyorMagicDamEnemyoT, eStattype.MagicDamage)


    fMagicDamageBurst.Add(New FormulaElement(eModifierType.RequiemDamageMagicalInflicted, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.RequiemDamageMagicalInflicted, eStattype.MagicDamage)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.SanitysDamageMagicalInflictedAsMultofIntDiff, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.SanitysDamageMagicalInflictedAsMultofIntDiff, eStattype.MagicDamage)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.StaticStormDamageMagicalInflicted, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.StaticStormDamageMagicalInflicted, eStattype.MagicDamage)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.TargetsCurrentHealthAsDamageMagicalInfliced, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.TargetsCurrentHealthAsDamageMagicalInfliced, eStattype.MagicDamage)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.WrathofNatureMagicDamageBounceInflicted, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.WrathofNatureMagicDamageBounceInflicted, eStattype.MagicDamage)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.DamageMagicalPercent, _
Nothing, _
eMathAction.InputPlusPercentageOfPrePercValue, mNames))
    AddStatModDependency(eModifierType.DamageMagicalPercent, eStattype.MagicDamage)

    fMagicDamageBurst.Add(New FormulaElement(eModifierType.MagicDamageReceivedMultiplier, _
Nothing, _
eMathAction.InputMultipliedByValue, mNames))
    AddStatModDependency(eModifierType.MagicDamageReceivedMultiplier, eStattype.MagicDamage)
  End Sub
  Private Sub LoadTeamTtlMagDamageBurst()
    fTeamTtlMagDamageBurst = New Formula(lstMyTeam, lstMyTeam, lstEmpty)

    fTeamTtlMagDamageBurst.Add(New FormulaElement(eModifierType.None, _
                                       eStattype.MagicDamage, _
                                       eMathAction.InputPlusValue, mNames))
    AddStatStatDependency(eStattype.PhysicalDamage, eStattype.TeamTtlPhysDamageBurst)
  End Sub

  Private Sub LoadMagicDamageAvg()

  End Sub

  Private Sub LoadPureDamage()
    fPureDamageBurst = New Formula(lstSelf, lstSelf, lstSelf)

    fPureDamageBurst.Add(New FormulaElement(eModifierType.DamagePureAdded, _
               Nothing, _
               eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamagePureAdded, eStattype.PureDamage)

    fPureDamageBurst.Add(New FormulaElement(eModifierType.DamagePureAsPercentofManaPool, _
           Nothing, _
           eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamagePureAsPercentofManaPool, eStattype.PureDamage)

    fPureDamageBurst.Add(New FormulaElement(eModifierType.DamagePureAsPercentofMaxHP, _
           Nothing, _
           eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamagePureAsPercentofMaxHP, eStattype.PureDamage)

    fPureDamageBurst.Add(New FormulaElement(eModifierType.HPRemovalAsPercentofMoveDist, _
           Nothing, _
           eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.HPRemovalAsPercentofMoveDist, eStattype.PureDamage)

    fPureDamageBurst.Add(New FormulaElement(eModifierType.DamagePureInflicted, _
           Nothing, _
           eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamagePureInflicted, eStattype.PureDamage)

    fPureDamageBurst.Add(New FormulaElement(eModifierType.DamagePureoTasPercofMaxHP, _
           Nothing, _
           eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamagePureoTasPercofMaxHP, eStattype.PureDamage)

    fPureDamageBurst.Add(New FormulaElement(eModifierType.DamagePureoTInflicted, _
           Nothing, _
           eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamagePureoTInflicted, eStattype.PureDamage)

    fPureDamageBurst.Add(New FormulaElement(eModifierType.DamagePureRandomInflicted, _
       Nothing, _
       eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamagePureRandomInflicted, eStattype.PureDamage)

    fPureDamageBurst.Add(New FormulaElement(eModifierType.ImpetusDamagePureInflicted, _
       Nothing, _
       eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.ImpetusDamagePureInflicted, eStattype.PureDamage)

    fPureDamageBurst.Add(New FormulaElement(eModifierType.MidnightPulsePureDamageAdded, _
       Nothing, _
       eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.MidnightPulsePureDamageAdded, eStattype.PureDamage)

    fPureDamageBurst.Add(New FormulaElement(eModifierType.RightClickPureDamageInflicted, _
       Nothing, _
       eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.RightClickPureDamageInflicted, eStattype.PureDamage)


    fPureDamageBurst.Add(New FormulaElement(eModifierType.RightClickInttoPureDamage, _
       Nothing, _
       eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.RightClickInttoPureDamage, eStattype.PureDamage)

    fPureDamageBurst.Add(New FormulaElement(eModifierType.SunStrikePureInflicted, _
       Nothing, _
       eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.SunStrikePureInflicted, eStattype.PureDamage)

    fPureDamageBurst.Add(New FormulaElement(eModifierType.WexDamagePureInflicted, _
       Nothing, _
       eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.WexDamagePureInflicted, eStattype.PureDamage)

    fPureDamageBurst.Add(New FormulaElement(eModifierType.DamagePurePercent, _
       Nothing, _
       eMathAction.InputMultipliedByValue, mNames))
    AddStatModDependency(eModifierType.DamagePurePercent, eStattype.PureDamage)
  End Sub
  Private Sub LoadTeamTtlPureDamageBurst()
    fTeamTtlPureDamageBurst = New Formula(lstMyTeam, lstMyTeam, lstMyTeam)

    fTeamTtlPureDamageBurst.Add(New FormulaElement(eModifierType.None, _
               eStattype.PureDamage, _
               eMathAction.InputPlusValue, mNames))
    AddStatStatDependency(eStattype.PureDamage, eStattype.TeamTtlPureDamageBurst)

   
  End Sub

  Private Sub LoadPureDamageAvg()

  End Sub

  Private Sub LoadAllDamageBurst()
    fAllDamageBurst = New Formula(lstSelf, lstSelf, lstSelf)

    fAllDamageBurst.Add(New FormulaElement(Nothing, eStattype.PhysicalDamage, eMathAction.InputPlusValue, mNames))
    AddStatStatDependency(eStattype.PhysicalDamage, eStattype.AllDamageBurst)

    fAllDamageBurst.Add(New FormulaElement(Nothing, eStattype.MagicDamage, eMathAction.InputPlusValue, mNames))
    AddStatStatDependency(eStattype.PhysicalDamage, eStattype.AllDamageBurst)

    fAllDamageBurst.Add(New FormulaElement(Nothing, eStattype.PureDamage, eMathAction.InputPlusValue, mNames))
    AddStatStatDependency(eStattype.PureDamage, eStattype.AllDamageBurst)

    fAllDamageBurst.Add(New FormulaElement(Nothing, eStattype.HPRemoval, eMathAction.InputPlusValue, mNames))
    AddStatStatDependency(eStattype.HPRemoval, eStattype.AllDamageBurst)

  End Sub
  Private Sub LoadAllDamageAvg()

  End Sub

  Private Sub LoadHPRemoval()
    fHPRemoval = New Formula(lstSelf, lstSelf, lstSelf)

    fHPRemoval.Add(New FormulaElement(eModifierType.HPRemoval, Nothing, eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.HPRemoval, eStattype.HPRemoval)

    fHPRemoval.Add(New FormulaElement(eModifierType.HPRemovalSharedWithBoundUnits, Nothing, eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.HPRemovalSharedWithBoundUnits, eStattype.HPRemoval)


    fHPRemoval.Add(New FormulaElement(eModifierType.HPRemovalAsPercentofMoveDist, Nothing, eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.HPRemovalAsPercentofMoveDist, eStattype.HPRemoval)

  End Sub
  Private Sub LoadNegativeRegen()

  End Sub






  Private Sub LoadSpellImmunityCount()
    fSpellImmunityCount = New Formula(lstSelf, lstSelf, lstSelf)

    fSpellImmunityCount.Add(New FormulaElement(eModifierType.SpellBlock, Nothing, eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.SpellBlock, eStattype.SpellImmunityCount)
  End Sub
  Private Sub LoadTeamTtlSpellImmunityCount()
    fTeamTtlSpellImmunityCount = New Formula(lstMyTeam, lstMyTeam, lstMyTeam)

    fTeamTtlSpellImmunityCount.Add(New FormulaElement(eModifierType.None, eStattype.SpellImmunityCount, eMathAction.InputPlusValue, mNames))
    AddStatStatDependency(eStattype.SpellImmunityCount, eStattype.TeamTtlSpellImmunityCount)
  End Sub



  Private Sub LoadNumber1()
    fNumber1 = New Formula(lstSelf, lstSelf, lstEmpty)

    fNumber1.Add(New FormulaElement(eModifierType.Number1, _
                                    Nothing, _
                                    eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.Number1, eStattype.Number1)
  End Sub

  Private Sub LoadNumberPoint06()
    fNumberPoint06 = New Formula(lstSelf, lstSelf, lstEmpty)

    fNumberPoint06.Add(New FormulaElement(eModifierType.NumberPoint06, _
                                          Nothing, _
                                          eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.NumberPoint06, eStattype.NumberPoint06)

  End Sub

  Private Sub LoadArmorxPoint06()
    fArmorxPoint06 = New Formula(lstSelf, lstSelf, lstEmpty)

    fArmorxPoint06.Add(New FormulaElement(eModifierType.NumberPoint06, _
                                          Nothing, _
                                          eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.NumberPoint06, eModifierType.ArmorxPoint06)

    fArmorxPoint06.Add(New FormulaElement(Nothing, _
                                          eStattype.PhysicalArmor, _
                                          eMathAction.InputMultipliedByValue, mNames))
    AddStatStatDependency(eStattype.PhysicalArmor, eStattype.ArmorxPoint06)
  End Sub

  Private Sub LoadPhysicalDamageAmplification()
    fPhysicalDamageAmplification = New Formula(lstSelf, lstSelf, lstEmpty)


    fPhysicalDamageAmplification.Add(New FormulaElement(eModifierType.DamageAmplification, _
                       Nothing, _
                       eMathAction.InputPlusPercentageOfPrePercValue, mNames))
    AddStatModDependency(eModifierType.DamageAmplification, eStattype.PhysicalDamageAmplification)

    fPhysicalDamageAmplification.Add(New FormulaElement(eModifierType.DamageIncreasePercent, _
                           Nothing, _
                           eMathAction.InputPlusPercentageOfPrePercValue, mNames))
    AddStatModDependency(eModifierType.DamageIncreasePercent, eStattype.PhysicalDamageAmplification)

    fPhysicalDamageAmplification.Add(New FormulaElement(eModifierType.DamageAllTypesPercentAdded, _
                              Nothing, _
                              eMathAction.InputPlusPercentageOfPrePercValue, mNames))
    AddStatModDependency(eModifierType.DamageAllTypesPercentAdded, eStattype.PhysicalDamageAmplification)

    fPhysicalDamageAmplification.Add(New FormulaElement(eModifierType.DamageAllTypesIncomingIncreasesPercent, _
                                  Nothing, _
                                  eMathAction.InputPlusPercentageOfPrePercValue, mNames))
    AddStatModDependency(eModifierType.DamageAllTypesIncomingIncreasesPercent, eStattype.PhysicalDamageAmplification)





  End Sub

  Private Sub LoadPhysicalDamageReduction()
    fPhysicalDamageReduction = New Formula(lstSelf, lstSelf, lstSelf)

    fPhysicalDamageAmplification.Add(New FormulaElement(eModifierType.DamagetoHealPercent, _
                     Nothing, _
                     eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamagetoHealPercent, eStattype.PhysicalDamageReduction)


  End Sub

  Private Sub LoadPhysicalDamageNegation()
    fPhysicalDamageNegation = New Formula(lstSelf, lstSelf, lstSelf)

    fPhysicalDamageAmplification.Add(New FormulaElement(eModifierType.HealAdded, _
                  Nothing, _
                  eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.HealAdded, eStattype.PhysicalDamageNegation)

    fPhysicalDamageAmplification.Add(New FormulaElement(eModifierType.DamageTransferedToCaster, _
               Nothing, _
               eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamageTransferedToCaster, eStattype.PhysicalDamageNegation)

    fPhysicalDamageAmplification.Add(New FormulaElement(eModifierType.ShallowGrave, _
           Nothing, _
           eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.ShallowGrave, eStattype.PhysicalDamageNegation)

    fPhysicalDamageAmplification.Add(New FormulaElement(eModifierType.RightClickDamageInstanceAvoided, _
       Nothing, _
       eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.RightClickDamageInstanceAvoided, eStattype.PhysicalDamageNegation)

    fPhysicalDamageAmplification.Add(New FormulaElement(eModifierType.TargetedDamageReflected, _
   Nothing, _
   eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.TargetedDamageReflected, eStattype.PhysicalDamageNegation)


    fPhysicalDamageAmplification.Add(New FormulaElement(eModifierType.DamageBlock, _
Nothing, _
eMathAction.InputPlusValue, mNames))
    AddStatModDependency(eModifierType.DamageBlock, eStattype.PhysicalDamageNegation)


  End Sub

#End Region


End Class
