Public Class ctrlSummary
  Implements iGraphable

  Private ctrlDataItemViewer As ctrlSelectedDataitemViewer





  Public Event GraphableSelected(sender As iGraphable) Implements iGraphable.GraphableSelected

  Private mSelectedGraphableDatItem As iGraphable

  Private mSummaryDataitem As ctrlSwatchDataItemLabel
  Public Sub Load(summarydataitem As iDataItem, dataitems As List(Of List(Of iDataItem)), subheadingtitles As List(Of String), _
                  headingtextbrush As SolidColorBrush, bodytextbrush As SolidColorBrush, _
                  thefontsize As Double, verticalorientaton As Boolean, _
                  barwidth As GridLength, margin As GridLength, game As dGame)




    grphSummary.Load(dataitems, subheadingtitles, barwidth, margin, game)



    ctrlDataItemViewer = New ctrlSelectedDataitemViewer()

    ctrlDataItemViewer.Load(headingtextbrush, bodytextbrush, thefontsize, verticalorientaton, game)

    mSummaryDataitem = New ctrlSwatchDataItemLabel(summarydataitem, headingtextbrush, bodytextbrush, _
                                                                  New SolidColorBrush(summarydataitem.MyColor), Constants.cHeadingFontSize, summarydataitem.DisplayName, "", False, game)
    spnlSummaryAttribute.Children.Add(mSummaryDataitem)

    AddHandler mSummaryDataitem.GraphableSelected, AddressOf mSummaryDataitem_GraphableSelected








    For i = 0 To dataitems.Count - 1
      Dim curlist = dataitems.Item(i)
      For x = 0 To curlist.Count - 1
        ctrlDataItemViewer.AddDataitem(curlist.Item(x))
      Next


    Next

    spnlSelectedAttribute.Children.Add(ctrlDataItemViewer)

    AddHandler grphSummary.GraphableSelected, AddressOf grphSummary_GraphableSelected
    AddHandler grphSummary.SummaryBarHovered, AddressOf grphSummary_SummaryBarHovered
    AddHandler grphSummary.SummaryBarUnhovered, AddressOf grphSummary_SummaryBarUnhovered

    AddHandler grphSummary.MouseLeave, AddressOf grphSummary_MouseLeave


  End Sub

  Private Sub grphSummary_GraphableSelected(sender As iGraphable)

    mSelectedGraphableDatItem = sender
    ctrlDataItemViewer.SetGraphed(True)
    RaiseEvent GraphableSelected(mSelectedGraphableDatItem)
  End Sub

  Private Sub grphSummary_SummaryBarHovered(sender As ctrlSummaryBar)
    ctrlDataItemViewer.SetVisibleAttribute(sender.DataItem)
  End Sub


  Private Sub grphSummary_SummaryBarUnhovered(sender As ctrlSummaryBar)
    ctrlDataItemViewer.SetVisibleAttribute(Nothing)
  End Sub


  Public Sub Updatetime(time As ddFrame)
    grphSummary.UpdateTime(time)
    ctrlDataItemViewer.UpdateTime(time)
    mSummaryDataitem.UpdateValue(time)
  End Sub

  Public Property GraphDataItems As List(Of List(Of iDataItem)) Implements iGraphable.GraphDataItems
    Get
      If Not mSelectedGraphableDatItem Is Nothing Then
        Return mSelectedGraphableDatItem.GraphDataItems
      End If
      Return Nothing
    End Get
    Set(value As List(Of List(Of iDataItem)))

    End Set
  End Property

  Public Property GraphPreferences As Graph_Preferences Implements iGraphable.GraphPreferences
    Get
      If Not mSelectedGraphableDatItem Is Nothing Then
        Return mSelectedGraphableDatItem.GraphPreferences
      End If
      Return Nothing
    End Get
    Set(value As Graph_Preferences)

    End Set
  End Property

  Public Sub SetGraphed(isgraphed As Boolean) Implements iGraphable.SetGraphed
    If Not mSelectedGraphableDatItem Is Nothing Then
      mSelectedGraphableDatItem.SetGraphed(isgraphed)
    End If
  End Sub

  Private Sub grphSummary_MouseLeave(sender As Object, e As MouseEventArgs)
    If Not grphSummary.SelectedSummmaryBar Is Nothing Then
      ctrlDataItemViewer.SetVisibleAttribute(ctrlDataItemViewer.GraphSelectedDataItemViewer.Dataitem)
    End If
  End Sub


  Private Sub mSummaryDataitem_GraphableSelected(sender As iGraphable)
    mSelectedGraphableDatItem = sender
    RaiseEvent GraphableSelected(sender)
  End Sub





End Class
