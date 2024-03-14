
Public Class ctrlSwatchDataItemLabelDual
  Implements iControlIO, iGraphable


  'Private myStattype As eStattype
  ' Private mRadHero As HeroInstance
  Private mRadDataitem As iDataItem
  ' Private mDireHero As HeroInstance
  Private mDireDataitem As iDataItem

  Private mCurtime As ddFrame
  Public mTooltip As ToolTip
  'Private mIconPath As String
  Private mValBrush As SolidColorBrush
  Private mHeadingTextBrush As SolidColorBrush
  Private mBodyTextBrush As SolidColorBrush
  Private mfontSize As Integer
  'Public Event StatTypeSelected( ddobj As DDObject)
  Private mIsSelected As Boolean = False
  Public Event SelectedChanged(gameentity As iGameEntity) Implements iControlIO.SelectedChanged
  Public Event isDirty(gameentity As iGameEntity) Implements iControlIO.isDirty

  Private mPrefix As String
  Private mSuffix As String

  Private mRadBrush As SolidColorBrush
  Private mDireBrush As SolidColorBrush

  Public Event GraphableSelected(sender As iGraphable) Implements iGraphable.GraphableSelected


  Private mSelectedGraphedType As eSelectedDualLabelGraphitem

  Public Sub New(curtime As ddFrame, _
                    raddataitem As iDataItem, _
                    diredataitem As iDataItem, _
                   headingtextbrush As SolidColorBrush, bodytextbrush As SolidColorBrush, _
                   thevalcolor As SolidColorBrush, fontsize As Double, _
                   theprefix As String, thesuffix As String, _
                   radbrush As SolidColorBrush, direbrush As SolidColorBrush) '

    InitializeComponent()

    mRadBrush = New SolidColorBrush(raddataitem.MyColor)
    mDireBrush = New SolidColorBrush(diredataitem.MyColor)

    LoadMe(curtime, raddataitem, diredataitem, headingtextbrush, bodytextbrush, thevalcolor, fontsize, theprefix, thesuffix)

    mTooltip = New ToolTip
    Dim thick As New Thickness(0)
    ToolTipService.SetToolTip(Me, mTooltip)

    AddHandler Me.MouseEnter, AddressOf Me_MouseEnter
    AddHandler Me.MouseLeftButtonDown, AddressOf Me_MouseLeftButtonDown

    Dim selctedgraphcolor = New SolidColorBrush(PageHandler.dbColors.GraphedColor)
    rectLeftGraphSelected.Visibility = Windows.Visibility.Collapsed
    rectLeftGraphSelected.Stroke = selctedgraphcolor

    rectRightGraphSelected.Visibility = Windows.Visibility.Collapsed
    rectRightGraphSelected.Stroke = selctedgraphcolor

    rectBothGraphSelected.Visibility = Windows.Visibility.Collapsed
    rectBothGraphSelected.Stroke = selctedgraphcolor

  End Sub


  Private Sub LoadMe(curtime As ddFrame, _
                        raddataitem As iDataItem, _
                    diredataitem As iDataItem, _
                      headingtextbrush As SolidColorBrush, bodytextbrush As SolidColorBrush, _
                      thevalcolor As SolidColorBrush, fontsize As Double, _
                      theprefix As String, thesuffix As String)
    
    ' mRadHero = theradowner
    mRadDataitem = raddataitem

    '  mDireHero = thedireowner
    mDireDataitem = diredataitem

    If mRadDataitem Is Nothing Then
      Dim x = 2
    End If
    mCurtime = curtime
    mPrefix = theprefix
    mSuffix = thesuffix

    mfontSize = fontsize
    mValBrush = thevalcolor
    mHeadingTextBrush = headingtextbrush
    mBodyTextBrush = bodytextbrush
    LoadMe()

  End Sub

  Private Sub LoadMe()




    Dim prefixes = mPrefix.Split(" ")
    Dim charlength As Integer = 0
    For i As Integer = 0 To prefixes.Count - 1

      Dim lblstatname As New Label
      lblstatname.Content = prefixes(i) & " "
      lblstatname.VerticalAlignment = TextAlignment.Center
      lblstatname.HorizontalAlignment = Windows.HorizontalAlignment.Center
      lblstatname.VerticalContentAlignment = Windows.VerticalAlignment.Center
      lblstatname.HorizontalContentAlignment = Windows.HorizontalAlignment.Center
      lblstatname.Foreground = mBodyTextBrush
      lblstatname.FontFamily = Constants.cBodyFont
      lblstatname.Height = 18
      lblstatname.FontSize = mfontSize
      lblstatname.Padding = New Thickness(0)
      lblstatname.Margin = New Thickness(0)
      wpnlStatNameLabels.Children.Add(lblstatname)
      If prefixes(i).Length > charlength Then charlength = prefixes(i).Length
    Next
    ''I hate wpf for making me do hacks like this. just tell me how wide you are you pima
    'colStatnameoricon.MinWidth = charlength * mfontSize * 1.2

    Dim valrad As Double?
    If mRadDataitem IsNot Nothing Then
      valrad = mRadDataitem.Value(mCurtime)
      If valrad.HasValue Then
        Dim valdub As Double = valrad
        lblRadStatValue.Content = mRadDataitem.ValueWithFormatting(mCurtime) & mSuffix
      Else
        valrad = 0
        lblRadStatValue.Content = valrad & mSuffix
      End If

    End If
    Dim valdire As Double?
    If mDireDataitem IsNot Nothing Then
      valdire = mDireDataitem.Value(mCurtime)
      If valdire.HasValue Then
        Dim valdub As Double = valdire
        lblDireStatValue.Content = mDireDataitem.ValueWithFormatting(mCurtime) & mSuffix
      Else
        valdire = 0
        lblDireStatValue.Content = valdire & mSuffix
      End If

    End If

    lblRadStatValue.Foreground = mHeadingTextBrush
    lblRadStatValue.FontFamily = Constants.cBodyFont
    lblRadStatValue.FontSize = mfontSize

    lblDireStatValue.Foreground = mHeadingTextBrush
    lblDireStatValue.FontFamily = Constants.cBodyFont
    lblDireStatValue.FontSize = mfontSize

    'bdrDireStatValue.BorderThickness = New Thickness(1)
    'bdrRadStatValue.BorderThickness = New Thickness(1)
    If valrad > valdire Then
      bdrRadStatValue.BorderThickness = New Thickness(1)
      bdrRadStatValue.BorderBrush = mRadBrush

      Dim darkenedbrush = Helpers.DarkenBrush(mRadBrush, 0.8)
      bdrRadStatValue.Background = darkenedbrush

      Dim brightnessval = Helpers.RGBtoHSB(darkenedbrush.Color).Bri
      If brightnessval > 0.7 Then
        lblRadStatValue.Foreground = New SolidColorBrush(PageHandler.dbColors.BackgroundColor)
      End If
    ElseIf valdire > valrad Then
      bdrDireStatValue.BorderThickness = New Thickness(1)
      bdrDireStatValue.BorderBrush = mDireBrush

      Dim darkenedbrush = Helpers.DarkenBrush(mDireBrush, 0.8)
      bdrDireStatValue.Background = darkenedbrush

      Dim brightnessval = Helpers.RGBtoHSB(darkenedbrush.Color).Bri
      If brightnessval > 0.7 Then
        lblDireStatValue.Foreground = New SolidColorBrush(PageHandler.dbColors.BackgroundColor)
      End If
    End If

    AddHandler lblRadStatValue.MouseLeftButtonDown, AddressOf RadGraphSelected
    AddHandler lblDireStatValue.MouseLeftButtonDown, AddressOf DireGraphSelected
    AddHandler wpnlStatNameLabels.MouseLeftButtonDown, AddressOf BothGraphSelected





    'lblDash.Foreground = mHeadingTextBrush
    'lblDash.FontFamily = Constants.cBodyFont
    'lblDash.FontSize = mfontSize

    elpsSwatch.elpsSwatch.Fill = New SolidColorBrush(RadDataitem.MyColor)

    'lblStatValue.CharacterSpacing = 100
  End Sub
  Public Sub RefreshStat()
    ' mMyStat = mMyHerobuild.mGame.dbModifiers.GetStatByParentIDandType(mMyHerobuild.ID, myStattype)
    LoadMe()
  End Sub

  Public ReadOnly Property RadDataitem As iDataItem
    Get
      Return mRadDataitem
    End Get
  End Property

  Public ReadOnly Property DireDataitem As iDataItem
    Get
      Return mDireDataitem
    End Get
  End Property

  Public Sub UpdateValue(curtime As ddFrame)

    mCurtime = curtime

    Dim valrad As Double?
    If mRadDataitem IsNot Nothing Then
      valrad = mRadDataitem.Value(mCurtime)
      If valrad.HasValue Then
        Dim valdub As Double = valrad
        lblRadStatValue.Content = mRadDataitem.ValueWithFormatting(mCurtime) & mSuffix
      Else
        valrad = 0
        lblRadStatValue.Content = valrad & mSuffix
      End If

    End If

    Dim valdire As Double?
    If mDireDataitem IsNot Nothing Then
      valdire = mDireDataitem.Value(mCurtime)
      If valdire.HasValue Then
        Dim valdub As Double = valdire
        lblDireStatValue.Content = mDireDataitem.ValueWithFormatting(mCurtime) & mSuffix
      Else
        valdire = 0
        lblDireStatValue.Content = valdire & mSuffix
      End If
    End If

    If valrad > valdire Then
      bdrRadStatValue.BorderBrush = mRadBrush
      bdrDireStatValue.BorderBrush = Nothing
    ElseIf valdire > valrad Then
      bdrRadStatValue.BorderBrush = Nothing
      bdrDireStatValue.BorderBrush = mDireBrush
    End If

  End Sub
  Private Sub Me_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs)
    mIsSelected = True
    RaiseEvent SelectedChanged(Me)
  End Sub

  Private Sub Me_MouseEnter(sender As Object, e As MouseEventArgs)

    If mRadDataitem.MyType = eSourceType.Stat Then
      Dim outstring As New List(Of List(Of String))
      Dim r As New List(Of String)
      r.Add("Radiant:")
      outstring.Add(r)
      Dim radstat As Stat = DirectCast(mRadDataitem, Stat)
      outstring.AddRange(radstat.GetFriendlyFormula(mCurtime))
      Dim s As New List(Of String)
      s.Add("")
      outstring.Add(s)
      Dim d As New List(Of String)
      d.Add("Dire:")
      outstring.Add(d)
      Dim direstat As Stat = DirectCast(mDireDataitem, Stat)
      outstring.AddRange(direstat.GetFriendlyFormula(mCurtime))

      Dim tt As New ctrlText_Tooltip(outstring)
      mTooltip.Content = tt

    End If

  End Sub



  Public ReadOnly Property IsSelected As Boolean Implements iControlIO.IsSelected
    Get
      Return mIsSelected
    End Get
  End Property



  Public Sub SetSelected(isselected As Boolean) Implements iControlIO.SetSelected
    mIsSelected = isselected
  End Sub


  Public Property GraphDataItems As List(Of List(Of iDataItem)) Implements iGraphable.GraphDataItems
    Get

      Select Case mSelectedGraphedType
        Case eSelectedDualLabelGraphitem.Radiant
          Dim outlist As New List(Of List(Of iDataItem))

          Dim rlist As New List(Of iDataItem)
          rlist.Add(mRadDataitem)
          outlist.Add(rlist)

          Dim llist As New List(Of iDataItem)
          outlist.Add(llist)

          Return outlist

        Case eSelectedDualLabelGraphitem.Dire
          Dim outlist As New List(Of List(Of iDataItem))

          Dim rlist As New List(Of iDataItem)
          outlist.Add(rlist)

          Dim llist As New List(Of iDataItem)
          llist.Add(mDireDataitem)
          outlist.Add(llist)

          Return outlist


        Case eSelectedDualLabelGraphitem.Both
          Dim outlist As New List(Of List(Of iDataItem))

          Dim rlist As New List(Of iDataItem)
          rlist.Add(mRadDataitem)
          outlist.Add(rlist)

          Dim llist As New List(Of iDataItem)
          llist.Add(mDireDataitem)
          outlist.Add(llist)

          Return outlist

        Case Else
          Throw New NotImplementedException
      End Select
    End Get
    Set(value As List(Of List(Of iDataItem)))

    End Set
  End Property
  Public Property GraphPreferences As Graph_Preferences Implements iGraphable.GraphPreferences
    Get
      Select Case mSelectedGraphedType
        Case eSelectedDualLabelGraphitem.Both
          Dim title = "Radiant & Dire's" & mRadDataitem.DisplayName
          Return New Graph_Preferences(title, eGraphType.Advantage, eBarType.Parent, eChartType.Advantage)
        Case eSelectedDualLabelGraphitem.Dire
          Dim title = "Dire's" & mDireDataitem.DisplayName
          Return New Graph_Preferences(title, eGraphType.TeamsStacked, eBarType.Parent, eChartType.Stacked)

        Case eSelectedDualLabelGraphitem.Radiant
          Dim title = "Radiant's" & mRadDataitem.DisplayName
          Return New Graph_Preferences(title, eGraphType.TeamsStacked, eBarType.Parent, eChartType.Stacked)
        Case Else
          Throw New NotImplementedException
      End Select
    End Get
    Set(value As Graph_Preferences)

    End Set
  End Property

  Public Sub SetGraphed(isgraphed As Boolean) Implements iGraphable.SetGraphed
    Select Case mSelectedGraphedType
      Case eSelectedDualLabelGraphitem.Radiant
        If isgraphed Then
          rectLeftGraphSelected.Visibility = Windows.Visibility.Visible
        Else
          rectLeftGraphSelected.Visibility = Windows.Visibility.Collapsed
        End If

      Case eSelectedDualLabelGraphitem.Dire
        If isgraphed Then
          rectRightGraphSelected.Visibility = Windows.Visibility.Visible
        Else
          rectRightGraphSelected.Visibility = Windows.Visibility.Collapsed
        End If

      Case eSelectedDualLabelGraphitem.Both
        If isgraphed Then
          rectBothGraphSelected.Visibility = Windows.Visibility.Visible
        Else
          rectBothGraphSelected.Visibility = Windows.Visibility.Collapsed
        End If

      Case Else
        Throw New NotImplementedException
    End Select
  End Sub

  Private Sub RadGraphSelected()
    mSelectedGraphedType = eSelectedDualLabelGraphitem.Radiant
    RaiseEvent GraphableSelected(Me)
  End Sub

  Private Sub DireGraphSelected(sender As Object, e As MouseButtonEventArgs)
    mSelectedGraphedType = eSelectedDualLabelGraphitem.Dire
    RaiseEvent GraphableSelected(Me)
  End Sub


  Private Sub BothGraphSelected(sender As Object, e As MouseButtonEventArgs)
    mSelectedGraphedType = eSelectedDualLabelGraphitem.Both
    RaiseEvent GraphableSelected(Me)
  End Sub
End Class

Public Enum eSelectedDualLabelGraphitem
  none
  Radiant
  Dire
  Both
End Enum
