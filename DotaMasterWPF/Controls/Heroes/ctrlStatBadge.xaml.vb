
Imports DotaMasterWPF.PageHandler
Public Class ctrlStatBadge
  Implements iControlIO

  Private mStats As List(Of Stat)
  Private mStatlabels As New Dictionary(Of eStattype, ctrlIconStatLabel)
  Private mGame As dGame
  Private myIconstatLabels As List(Of ctrlIconStatLabel)
  Private mMyhero As HeroInstance

  Private mBodyTextBrush As SolidColorBrush
  Private mHeadingTextBrush As SolidColorBrush

  Private mHPBrush As SolidColorBrush

  Private mIntBrush As SolidColorBrush

  Private mAgiBush As SolidColorBrush

  Private mStrBrush As SolidColorBrush


  Private mManaBrush As SolidColorBrush

  Private mDamBrush As SolidColorBrush

  Private mMoveBrush As SolidColorBrush

  Private mArmBrush As SolidColorBrush


  Public Event isDirty(gameentity as igameentity) Implements iControlIO.isDirty
  Public Event SelectedChanged(gameentity as igameentity) Implements iControlIO.SelectedChanged
  Public Sub New()
    InitializeComponent()
  End Sub

  Public Sub LoadStats(heroowner As HeroInstance, _
                       headingtextbrush As SolidColorBrush, bodytextbrush As SolidColorBrush, _
                       thestats As List(Of Stat), thegame As dGame)

    mMyhero = heroowner
    mStats = thestats
    mGame = thegame
    mStatlabels = New Dictionary(Of eStattype, ctrlIconStatLabel)

    Dim agic As New SolidColorBrush(dbColors.AgiColor)
    Dim intc As New SolidColorBrush(dbColors.IntColor)
    Dim strc As New SolidColorBrush(dbColors.StrColor)
    Dim headc As New SolidColorBrush(dbColors.HeadingTextColor)

    mHPBrush = agic
    mIntBrush = intc
    mAgiBush = agic
    mStrBrush = strc
    mManaBrush = intc
    mDamBrush = New SolidColorBrush(dbColors.GetColorForDamageType(eDamageType.Physical))
    mMoveBrush = headc
    mArmBrush = headc
    mBodyTextBrush = bodytextbrush
    mHeadingTextBrush = headingtextbrush

    Dim curtime = mGame.TimeKeeper.CurrentTime
    For i As Integer = 0 To mStats.Count - 1
      Dim curstat = mStats.Item(i)

      Select Case curstat.StatType
        Case eStattype.HitPoints
          Dim hp = CreateStatLabel(curtime, "", curstat, mHeadingTextBrush, mBodyTextBrush, mHPBrush, Constants.cBodyFontSize, _
                                   "Hp:", "", 0)
          spnlHP.Children.Clear()
          spnlHP.Children.Add(hp)
          mStatlabels.Add(curstat.StatType, hp)
        Case eStattype.Intelligence
          Dim int = CreateStatLabel(curtime, "/Assets/primaryoverviewicon_int.png", curstat, mHeadingTextBrush, mBodyTextBrush, mIntBrush, Constants.cBodyFontSize, _
                                  "", "", 0)

          spnlInt.Children.Clear()
          spnlInt.Children.Add(int)
          mStatlabels.Add(curstat.StatType, int)
        Case eStattype.Agility
          Dim agi = CreateStatLabel(curtime, "/Assets/primaryoverviewicon_agi.png", curstat, mHeadingTextBrush, mBodyTextBrush, mAgiBush, Constants.cBodyFontSize, _
                               "", "", 0)

          spnlAgi.Children.Clear()
          spnlAgi.Children.Add(agi)
          mStatlabels.Add(curstat.StatType, agi)
        Case eStattype.Strength
          Dim str = CreateStatLabel(curtime, "/Assets/primaryoverviewicon_str.png", curstat, mHeadingTextBrush, mBodyTextBrush, mStrBrush, Constants.cBodyFontSize, _
                                "", "", 0)

          spnlstr.Children.Clear()
          spnlstr.Children.Add(str)
          mStatlabels.Add(curstat.StatType, str)
        Case eStattype.Mana
          Dim mna = CreateStatLabel(curtime, "", curstat, mHeadingTextBrush, mBodyTextBrush, mManaBrush, Constants.cBodyFontSize, _
                                   "Mana:", "", 0)
          spnlMana.Children.Clear()
          spnlMana.Children.Add(mna)
          mStatlabels.Add(curstat.StatType, mna)
        Case eStattype.AttackDamageLow
          Dim att = CreateStatLabel(curtime, "/Assets/overviewicon_attack.png", curstat, mHeadingTextBrush, mBodyTextBrush, mDamBrush, Constants.cBodyFontSize, _
                                            "", "", 0)
          spnlDamLo.Children.Clear()
          spnlDamLo.Children.Add(att)
          mStatlabels.Add(curstat.StatType, att)
        Case eStattype.AttackDamageHigh
          Dim damh = CreateStatLabel(curtime, "", curstat, mHeadingTextBrush, mBodyTextBrush, mDamBrush, Constants.cBodyFontSize, _
                                       "", "", 0)
          spnlDamHi.Children.Clear()
          spnlDamHi.Children.Add(damh)
          mStatlabels.Add(curstat.StatType, damh)

        Case eStattype.MovementSpeed
          Dim sp = CreateStatLabel(curtime, "/Assets/overviewicon_speed.png", curstat, mHeadingTextBrush, mBodyTextBrush, mMoveBrush, Constants.cBodyFontSize, _
                                  "", "", 0)

          spnlMove.Children.Clear()
          spnlMove.Children.Add(sp)
          mStatlabels.Add(curstat.StatType, sp)
        Case eStattype.PhysicalArmor
          Dim arm = CreateStatLabel(curtime, "/Assets/overviewicon_defense.png", curstat, mHeadingTextBrush, mBodyTextBrush, mArmBrush, Constants.cBodyFontSize, _
                                   "", "", 2)

          spnlArmor.Children.Clear()
          spnlArmor.Children.Add(arm)
          mStatlabels.Add(curstat.StatType, arm)

        Case eStattype.Networth
          Dim gld = CreateStatLabel(curtime, "", curstat, mHeadingTextBrush, mBodyTextBrush, mArmBrush, Constants.cBodyFontSize, _
                                   "Gld:", "", 0)

          spnlGold.Children.Clear()
          spnlGold.Children.Add(gld)
          mStatlabels.Add(curstat.StatType, gld)


        Case eStattype.Experience
          Dim xp = CreateStatLabel(curtime, "", curstat, mHeadingTextBrush, mBodyTextBrush, mArmBrush, Constants.cBodyFontSize, _
                                   "Xp:", "", 0)

          spnlXP.Children.Clear()
          spnlXP.Children.Add(xp)
          mStatlabels.Add(curstat.StatType, xp)

        Case eStattype.Kills
          Dim kills = CreateStatLabel(curtime, "", curstat, mHeadingTextBrush, mBodyTextBrush, mArmBrush, Constants.cBodyFontSize, _
                                   "Kills:", "", 2)

          spnlKills.Children.Clear()
          spnlKills.Children.Add(kills)
          mStatlabels.Add(curstat.StatType, kills)

        Case eStattype.Resources
          Dim res = CreateStatLabel(curtime, "", curstat, mHeadingTextBrush, mBodyTextBrush, mArmBrush, Constants.cBodyFontSize, _
                                   "Res's:", "", 2)

          spnlResources.Children.Clear()
          spnlResources.Children.Add(res)
          mStatlabels.Add(curstat.StatType, res)

        Case Else
          Dim x = 2
      End Select


    Next



    AddHandler Me.Loaded, AddressOf Me_Loaded

    lblDash.Foreground = mHeadingTextBrush
    lblDash.FontSize = Constants.cBodyFontSize
    lblDash.Content = "-"


  End Sub

  Private Function CreateStatLabel(curtime As ddFrame, iconpath As String, _
                                    thestat As Stat, _
                                    headingtextbrush As SolidColorBrush, bodytextbrush As SolidColorBrush, _
                                    thevalbrush As SolidColorBrush, fontsize As Integer, _
                                    theprefix As String, thesuffix As String, thedecimalplaces As Integer) As ctrlIconStatLabel

    Dim outctrl = New ctrlIconStatLabel(curtime, iconpath, thestat, headingtextbrush, bodytextbrush, thevalbrush, fontsize, _
                                  theprefix, thesuffix, thedecimalplaces)
    AddHandler outctrl.SelectedChanged, AddressOf ChildControl_SelectedChanged

    Return outctrl
  End Function

  Public Sub SetTime(curtime As ddFrame)
    For Each kv As KeyValuePair(Of eStattype, ctrlIconStatLabel) In mStatlabels
      kv.Value.UpdateValue(curtime)
    Next
  End Sub

  Private Sub ChildControl_SelectedChanged( gameentity as igameentity)
    RaiseEvent SelectedChanged(gameentity)
  End Sub


  Public ReadOnly Property IsSelected As Boolean Implements iControlIO.IsSelected
    Get
      Return False
    End Get
  End Property



  Public Sub SetSelected( isselected As Boolean) Implements iControlIO.SetSelected

  End Sub

  Private Sub Me_Loaded(sender As Object, e As RoutedEventArgs)
    Dim x = 2
  End Sub

  'Private Sub dbMods_Modschanged(theaffected As TypesAndTargets)
  '  Dim thestats = theaffected.StatTargetsnTypes

  '  If thestats.ContainsKey(mMyHero.ID.GuidID) Then
  '    Dim mydirtystats = thestats.Item(mMyHero.ID.GuidID)

  '    For i As Integer = 0 To mydirtystats.Count - 1
  '      Dim curstat = mydirtystats.Item(i)
  '      If mStatlabels.ContainsKey(curstat) Then
  '        Dim curctrl = mStatlabels.Item(curstat)
  '        curctrl.RefreshStat()
  '      End If
  '    Next
  '  End If
  'End Sub

End Class
