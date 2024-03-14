Imports System.Windows.Media.Imaging
Public Class ctrlItem_MenuItem
  Public mitem As Item_Info
  Private mTooltip As ToolTip
  Public mbuildsfrom As List(Of Item_Info)
  Public mbuildsto As List(Of Item_Info)
  Private dbImages As Image_Database
  'Event isSelected( ctrl As ctrlItem_MenuItem)
  Public Sub New(theitem As Item_Info, thebitmap As BitmapImage, _
                  buildsfrom As List(Of Item_Info), buildsto As List(Of Item_Info), imagedb As Image_Database)
    InitializeComponent()
    dbImages = imagedb
    mitem = theitem
    If Not Me.ImageThumb Is Nothing Then

      Me.ImageThumb.Source = thebitmap

    End If

    mbuildsfrom = buildsfrom
    mbuildsto = buildsto

    mTooltip = New ToolTip()
    Dim thick As New Thickness(0)
    mTooltip.BorderThickness = thick


    Dim ctrlTT As New ctrlItem_Tooltip(mitem, thebitmap, mbuildsfrom, mbuildsto, imagedb)
    mTooltip.Content = ctrlTT
    ToolTipService.SetToolTip(Me, mTooltip)


    Me.ImageThumb.Source = thebitmap
  End Sub

  
End Class
