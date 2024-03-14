Public Class ctrlSelectedDataitemDualViewer
  Implements iControlIO, iGraphable

  Private mDataitems As New Dictionary(Of iDataItem, ctrlSwatchDataItemLabelDual)
  Private mGame As dGame
  Private mHeadingtextbrush As SolidColorBrush
  Private mBodytextbrush As SolidColorBrush
  Private mFontsize As Double
  Private mVerticalOrientation As Boolean

  ' Private mSelectedGraphable As Boolean = False
  Private mHoveredDataItemLabel As ctrlSwatchDataItemLabelDual
  Private mGraphedDataItemLabel As ctrlSwatchDataItemLabelDual

  Public Event isDirty(gameentity As iGameEntity) Implements iControlIO.isDirty

  Public Event SelectedChanged(gameentity As iGameEntity) Implements iControlIO.SelectedChanged

  Public Event GraphableSelected(sender As iGraphable) Implements iGraphable.GraphableSelected


  Public Sub Load(headingtextbrush As SolidColorBrush, bodytextbrush As SolidColorBrush, _
                   thefontsize As Double, verticalorientaton As Boolean, _
                   game As dGame)

    mGame = game
    mHeadingtextbrush = headingtextbrush
    mBodytextbrush = bodytextbrush
    mFontsize = thefontsize
    mVerticalOrientation = verticalorientaton


  End Sub

  Public Sub UpdateTime(time As ddFrame)
    For Each item In mDataitems
      item.Value.UpdateValue(time)
    Next
  End Sub

  Public ReadOnly Property GraphSelectedDataItemViewer As ctrlSwatchDataItemLabelDual
    Get
      Return mGraphedDataItemLabel
    End Get
  End Property

  Public Sub AddDataitem(raddataitem As iDataItem, diredataitem As iDataItem)


    Dim ctrl = PageHandler.dbControls.GetctrlSwatchDataitemLabelDual(mGame.TimeKeeper.CurrentTime, _
                                                                 raddataitem, diredataitem, raddataitem.DisplayName, "", _
                                                                 New SolidColorBrush(raddataitem.MyColor), New SolidColorBrush(diredataitem.MyColor))


    mDataitems.Add(raddataitem, ctrl)
    mDataitems.Add(diredataitem, ctrl)
  End Sub

  Public Sub SetVisibleAttribute(dataitem As iDataItem)
    LayoutRoot.Children.Clear()

    If dataitem Is Nothing Then
      mHoveredDataItemLabel = Nothing
      Me.SetGraphed(False)
      Exit Sub
    End If

    If mDataitems.ContainsKey(dataitem) Then
      Dim curitem = mDataitems.Item(dataitem)
      mHoveredDataItemLabel = curitem
      LayoutRoot.Children.Add(curitem)
    End If

  End Sub
  Public ReadOnly Property IsSelected As Boolean Implements iControlIO.IsSelected
    Get
      Return False
    End Get
  End Property


  Public Sub SetSelected(isselected As Boolean) Implements iControlIO.SetSelected

  End Sub


  Public Property GraphDataItems As List(Of List(Of iDataItem)) Implements iGraphable.GraphDataItems
    Get
      If Not mHoveredDataItemLabel Is Nothing Then
        Return mHoveredDataItemLabel.GraphDataItems
      End If
      Return Nothing
    End Get
    Set(value As List(Of List(Of iDataItem)))

    End Set
  End Property

  Public Property GraphPreferences As Graph_Preferences Implements iGraphable.GraphPreferences
    Get
      If Not mHoveredDataItemLabel Is Nothing Then
        Return mHoveredDataItemLabel.GraphPreferences
      End If
    End Get
    Set(value As Graph_Preferences)

    End Set
  End Property

  Public Sub SetGraphed(isgraphed As Boolean) Implements iGraphable.SetGraphed
    If Not mHoveredDataItemLabel Is Nothing Then
      mHoveredDataItemLabel.SetGraphed(isgraphed)

      If Not mGraphedDataItemLabel Is Nothing Then
        mGraphedDataItemLabel.SetGraphed(False)
      End If
      mGraphedDataItemLabel = mHoveredDataItemLabel
    End If
  End Sub
End Class
