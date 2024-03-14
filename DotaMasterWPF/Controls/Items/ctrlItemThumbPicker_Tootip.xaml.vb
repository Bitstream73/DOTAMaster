Public Class ctrlItemThumbPicker_Tootip
  Private mitem As Item_Info
  Private mbuildsfrom As List(Of Item_Info)
  Private mBuildsto As List(Of Item_Info)
  Private dbImages As Image_Database

  Public Sub New(theitem As Item_Info, buildsfrom As List(Of Item_Info), buildsto As List(Of Item_Info), imagedb As Image_Database)
    InitializeComponent()


    mbuildsfrom = buildsfrom
    mBuildsto = buildsto
    dbImages = imagedb
    mitem = theitem

    If mitem.ItemName = eItemname.itmGAUNTLETS_OF_STRENGTH Then
      Dim y = 2
    End If

    lblItemName.Content = mitem.DisplayName


    Dim paras = mitem.Description.Split("|")

    For i As Integer = 0 To paras.Count - 1
      Dim paralbl As New ctrlBody_Paragraph
      paralbl.LayoutRoot.Text = paras(i)
      spnlDescription.Children.Add(paralbl)
    Next

    If Not mbuildsfrom Is Nothing Then
      If mbuildsfrom.Count = 0 Then lblBuildsFrom.Visibility = Windows.Visibility.Collapsed
      For i As Integer = 0 To mbuildsfrom.Count - 1
        Dim curitem = mbuildsfrom.Item(i)
        Dim themenuitem As New ctrlItem_Tooltip_Icon(curitem, dbImages.GetItemImage(curitem.ItemName))
     
        spnlBuildsFrom.Children.Add(themenuitem)

      Next
    Else
      lblBuildsFrom.Visibility = Windows.Visibility.Collapsed
    End If

    If Not mBuildsto Is Nothing Then
      If mBuildsto.Count = 0 Then lblBuildsTo.Visibility = Windows.Visibility.Collapsed
      For i As Integer = 0 To mBuildsto.Count - 1
        Dim curitem = mBuildsto.Item(i)
        Dim themenuitem As New ctrlItem_Tooltip_Icon(curitem, dbImages.GetItemImage(curitem.ItemName))

        spnlBuildsTo.Children.Add(themenuitem)

      Next

    Else
      lblBuildsTo.Visibility = Windows.Visibility.Collapsed
    End If


  End Sub
End Class
