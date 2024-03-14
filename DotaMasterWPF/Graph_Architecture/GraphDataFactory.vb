Public Class GraphDataFactory

  'Private mMyMods As List(Of ModifierList)
  'Private mMyStats As List(Of List(Of Stat))
  Private mDataItems As List(Of List(Of iDataItem))

  Private mGame As dGame
  Private mtimes As List(Of ddFrame)
  ' Private dbcolors As Colors_Database

  Private mValuecolor As Color
  Private mParentcolors As New List(Of List(Of Color))
  Private mSourcecolors As New List(Of List(Of Color))
  Private mTeamColors As New List(Of Color)

  Private mValues As New List(Of List(Of List(Of Double))) 'list Teams & Values for each timepoint

  Private mMaxHeight As Double
  Private mMaxTeamHeight As Double

  Public Function CreateGraphData(dataitems As List(Of List(Of iDataItem)), game As dGame) As GraphDataPackage
    Dim outdata As New BarDataList



    mGame = game
    mtimes = mGame.TimeKeeper.TimePoints.TheFrames
    mDataItems = dataitems

    CalcParentColors()
    CalcSourceColors()
    CalcTeamColors()
    CalcValueColor()

    mMaxHeight = 0
    mMaxTeamHeight = 0

    CalcValues(mDataItems)

    Dim bardlist = CreateBarDataItems(mParentcolors, mSourcecolors, mTeamColors, mValuecolor, mValues)

    Dim outp As New GraphDataPackage()
    outp.maxheight = mMaxHeight
    outp.maxteamheight = mMaxTeamHeight
    outp.thebardatalist = bardlist

    Dim outdataitems As New List(Of List(Of iDataItem))
    For i = 0 To mDataItems.Count - 1
      Dim outlist As New List(Of iDataItem)
      outlist.AddRange(mDataItems.Item(i))
      outdataitems.Add(outlist)
    Next
    outp.dataitems = outdataitems

    Return outp


  End Function
  Public Function CreateGraphData(modifiers As List(Of ModifierList), game As dGame) As GraphDataPackage
    Dim outdataitems As New List(Of List(Of iDataItem))
    For i = 0 To modifiers.Count - 1
      Dim outlist As New List(Of iDataItem)
      outlist.AddRange(modifiers.Item(i))
      outdataitems.Add(outlist)
    Next

    Return CreateGraphData(outdataitems, game)
  End Function

  Public Function CreateGraphData(thestats As List(Of List(Of Stat)), game As dGame) As GraphDataPackage
    Dim outdataitems As New List(Of List(Of iDataItem))
    For i = 0 To thestats.Count - 1
      Dim outlist As New List(Of iDataItem)
      outlist.AddRange(thestats.Item(i))
      outdataitems.Add(outlist)
    Next

    Return CreateGraphData(outdataitems, game)
  End Function

  Private Function CreateBarDataItems(mparentcolors As List(Of List(Of Color)), _
                                      msourcecolors As List(Of List(Of Color)), _
                                      mteamcolors As List(Of Color), _
                                      mvaluecolor As Color, _
                                      mvalues As List(Of List(Of List(Of Double)))) As BarDataList

    Dim data As New BarDataList()

    For i = 0 To mtimes.Count - 1

      If i = 200 Then
        Dim x = 2
      End If
      data.Add(New BarData(mtimes.Item(i), _
                           mvalues.Item(i), _
                           mparentcolors, _
                           msourcecolors, _
                           mvaluecolor, _
                           mteamcolors))

    Next
    Return data
  End Function

  Private Sub CalcParentColors()
    mParentcolors = New List(Of List(Of Color))

    Dim rcolors As New List(Of Color)
    For i = 0 To mDataItems.Item(0).Count - 1
      rcolors.Add(mDataItems.Item(0).Item(i).ParentGameEntity.MyColor)
    Next

    Dim dcolors As New List(Of Color)
    For i = 0 To mDataItems.Item(1).Count - 1
      dcolors.Add(mDataItems.Item(1).Item(i).ParentGameEntity.MyColor)
    Next

    mParentcolors.Add(rcolors)
    mParentcolors.Add(dcolors)


  End Sub

  Private Sub CalcSourceColors()
    mSourcecolors = New List(Of List(Of Color))
    Dim rcolors As New List(Of Color)
    For i = 0 To mDataItems.Item(0).Count - 1
      rcolors.Add(PageHandler.dbColors.GetColor(mDataItems.Item(0).Item(i).DataGenerator))
    Next

    Dim dcolors As New List(Of Color)
    For i = 0 To mDataItems.Item(1).Count - 1
      dcolors.Add(PageHandler.dbColors.GetColor(mDataItems.Item(1).Item(i).DataGenerator))
    Next

    mSourcecolors.Add(rcolors)
    mSourcecolors.Add(dcolors)

  End Sub



  Private Sub CalcTeamColors()
    mTeamColors = New List(Of Color)
    mTeamColors.Add(mGame.GetColorForTeam(eTeamName.Radiant))
    mTeamColors.Add(mGame.GetColorForTeam(eTeamName.Dire))
  End Sub

  Private Sub CalcValueColor()

    If Not mDataItems.Item(0).Count < 1 Then
      mValuecolor = mDataItems.Item(0).Item(0).MyColor
    End If
    If Not mDataItems.Item(1).Count < 1 Then
      mValuecolor = mDataItems.Item(1).Item(0).MyColor
    End If




  End Sub

  'Private Sub CalcValues(mods As List(Of ModifierList))
  '  mValues = New List(Of List(Of List(Of Double)))
  '  mMaxHeight = 0
  '  mMaxTeamHeight = 0
  '  Dim radlist As New List(Of Double)
  '  Dim dirlist As New List(Of Double)
  '  Dim rmods = mods.Item(0)
  '  Dim dmods = mods.Item(1)



  '  For i = 0 To mtimes.Count - 1
  '    If i = 200 Then
  '      Dim x = 2
  '    End If
  '    Dim rlist As New List(Of Double)
  '    For r = 0 To rmods.Count - 1
  '      Dim val = rmods.Item(r).Value(mtimes.Item(i))
  '      If val.HasValue Then
  '        rlist.Add(rmods.Item(r).Value(mtimes.Item(i)))
  '      Else
  '        rlist.Add(0)
  '      End If
  '    Next
  '    checkmaxTeamHeight(rlist)

  '    Dim dlist As New List(Of Double)
  '    For d = 0 To dmods.Count - 1
  '      Dim val = dmods.Item(d).Value(mtimes.Item(i))
  '      If val.HasValue Then
  '        dlist.Add(val)
  '      Else
  '        dlist.Add(0)
  '      End If

  '    Next
  '    checkmaxTeamHeight(dlist)

  '    Dim rdlist As New List(Of List(Of Double))
  '    rdlist.Add(rlist)
  '    rdlist.Add(dlist)
  '    CheckMaxHeight(rdlist)
  '    mValues.Add(rdlist)
  '  Next
  'End Sub

  Private Sub CalcValues(dataitems As List(Of List(Of iDataItem)))
    mValues = New List(Of List(Of List(Of Double)))
    Dim rdataitems = dataitems.Item(0)
    Dim ddataitems = dataitems.Item(1)



    For i = 0 To mtimes.Count - 1

      Dim rlist As New List(Of Double)
      For r = 0 To rdataitems.Count - 1
        Dim val As Double? = rdataitems.Item(r).Value(mtimes.Item(i))
        If Not val.HasValue Then val = 0
        rlist.Add(val)
        checkmaxTeamHeight(rlist)
      Next

      Dim dlist As New List(Of Double)
      For d = 0 To ddataitems.Count - 1
        Dim val As Double? = ddataitems.Item(d).Value(mtimes.Item(i))
        If Not val.HasValue Then val = 0
        dlist.Add(val)
        checkmaxTeamHeight(dlist)
      Next
      Dim rdlist As New List(Of List(Of Double))
      rdlist.Add(rlist)
      rdlist.Add(dlist)
      CheckMaxHeight(rdlist)
      mValues.Add(rdlist)
    Next

  End Sub
  'Private Sub Calcvalues(stats As List(Of List(Of Stat)))
  '  mValues = New List(Of List(Of List(Of Double)))
  '  Dim radlist As New List(Of Stat)
  '  Dim dirlist As New List(Of Stat)
  '  Dim rstats = stats.Item(0)
  '  Dim dstats = stats.Item(1)



  '  For i = 0 To mtimes.Count - 1

  '    Dim rlist As New List(Of Double)
  '    For r = 0 To rstats.Count - 1

  '      rlist.Add(rstats.Item(r).Value(mtimes.Item(i)))
  '      checkmaxTeamHeight(rlist)
  '    Next

  '    Dim dlist As New List(Of Double)
  '    For d = 0 To dstats.Count - 1
  '      dlist.Add(dstats.Item(d).Value(mtimes.Item(i)))
  '      checkmaxTeamHeight(dlist)
  '    Next
  '    Dim rdlist As New List(Of List(Of Double))
  '    rdlist.Add(rlist)
  '    rdlist.Add(dlist)
  '    CheckMaxHeight(rdlist)
  '    mValues.Add(rdlist)
  '  Next

  'End Sub

  Private Sub CheckMaxHeight(theheights As List(Of List(Of Double)))

    Dim newheights = theheights.Item(0).Sum
    newheights += theheights.Item(1).Sum

    If newheights > mMaxHeight Then
      mMaxHeight = newheights
    End If
  End Sub

  Private Sub checkmaxTeamHeight(theheight As List(Of Double))
    Dim newheights = theheight.Sum
    If newheights > mMaxTeamHeight Then
      mMaxTeamHeight = newheights
    End If
  End Sub

End Class

Public Class GraphDataPackage
  
  Public thebardatalist As BarDataList
  Public maxteamheight As Double
  Public maxheight As Double
  'Public mods As List(Of ModifierList)
  'Public stats As List(Of List(Of Stat))
  Public dataitems As List(Of List(Of iDataItem))
End Class
