Imports System.Windows.Media.Imaging
Public Class ctrlitem_List_Item
  Implements IComparable(Of ctrlitem_List_Item)

  'Implements IComparable(Of ctrlitem_List_Item)
  'Implements IEquatable(Of ctrlitem_List_Item)

  'Private mImage As String
  Private mContent As String
  Public mItem As Item_Info
  Public mTooltip As ToolTip
  Public mFriendlyname As String
  Public mbuildsto As List(Of Item_Info)
  Public mbuildsfrom As List(Of Item_Info)
  Private dbImages As Image_Database
  Private mybmp As BitmapImage
  Public Sub New(theitem As Item_Info, buildsfrom As List(Of Item_Info), buildsto As List(Of Item_Info), _
                 friendlyname As String, imagedb As Image_Database)
    InitializeComponent()
    ' mImage = theitem.mImageUrl
    mFriendlyname = friendlyname
    mContent = mFriendlyname
    mItem = theitem
    dbImages = imagedb
    mybmp = dbImages.GetItemImage(theitem.ItemName)
    Me.ImageThumb.Source = mybmp

    mbuildsto = buildsto
    mbuildsfrom = buildsfrom

    lblItemName.Content = friendlyname

    mTooltip = New ToolTip()
    Dim thick As New Thickness(0)
    mTooltip.BorderThickness = thick
    ToolTipService.SetToolTip(Me, mTooltip)

    AddHandler Me.MouseEnter, AddressOf Me_MouseEnter
    Me.ImageThumb.Source = mybmp
  End Sub




  Public Function CompareTo(other As ctrlitem_List_Item) As Integer Implements IComparable(Of ctrlitem_List_Item).CompareTo
    If other Is Nothing Then
      Return 1
    Else
      Dim tcont As String = Me.lblItemName.Content
      Return tcont.CompareTo(other)

    End If
  End Function

  'Public Function Equals1(other As ctrlitem_List_Item) As Boolean Implements IEquatable(Of ctrlitem_List_Item).Equals
  '  If other Is Nothing Then Return False


  'End Function

  Private Sub Me_MouseEnter(sender As Object, e As MouseEventArgs)
    Dim ctrlTT As New ctrlItem_Tooltip(mItem, mybmp, mbuildsfrom, mbuildsto, dbImages)
    mTooltip.Content = ctrlTT
  End Sub

  'Private Sub Me_MouseLeave(sender As Object, e As MouseEventArgs)
  '  mTooltip.IsOpen = False
  'End Sub

  'Private Sub Me_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs)
  '  mTooltip.IsOpen = False
  'End Sub

End Class
