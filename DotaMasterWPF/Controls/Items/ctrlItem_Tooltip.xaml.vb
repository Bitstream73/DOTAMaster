Public Class ctrlItem_Tooltip
  Private mitem As Item_Info
  Private mBuildsfrom As List(Of Item_Info)
  Private mBuildsto As List(Of Item_Info)
  Private dbImages As Image_Database
  'Private mbuildsto As New List(Of eItemname)
  'Private mbuildsfrom As New List(Of eItemname)
  Public Sub New(theitem As Item_Info, thebmp As BitmapImage, buildsfrom As List(Of Item_Info), buildsto As List(Of Item_Info), imagedb As Image_Database)
    InitializeComponent()
    dbImages = imagedb
    mitem = theitem

    If mitem.ItemName = eItemname.itmGAUNTLETS_OF_STRENGTH Then
      Dim x = 2
    End If

    ' mbuildsto = buildsto
    ' mbuildsfrom = buildsfrom

    lblItemName.Content = mitem.DisplayName


    Dim paras = mitem.Description.Split("|")

    For i As Integer = 0 To paras.Count - 1
      Dim paralbl As New ctrlBody_Paragraph
      paralbl.LayoutRoot.Text = paras(i)
      spnlDescription.Children.Add(paralbl)
    Next

    If Not mBuildsfrom Is Nothing Then

      If mBuildsfrom.Count = 0 Then lblBuildsFrom.Visibility = Windows.Visibility.Collapsed
      For i As Integer = 0 To mBuildsfrom.Count - 1

        Dim themenuitem As New ctrlItem_Tooltip_Icon(mBuildsfrom.Item(i), dbImages.GetItemImage(mBuildsfrom.Item(i).ItemName))
        spnlBuildsFrom.Children.Add(themenuitem)

      Next
    End If


    If Not mBuildsto Is Nothing Then
      If mBuildsto.Count = 0 Then lblBuildsFrom.Visibility = Windows.Visibility.Collapsed
      For i As Integer = 0 To mBuildsto.Count - 1

        Dim themenuitem As New ctrlItem_Tooltip_Icon(mBuildsto.Item(i), PageHandler.dbImages.GetItemImage(mBuildsto.Item(i).ItemName))

        spnlBuildsTo.Children.Add(themenuitem)

      Next
    End If



  End Sub
End Class
