Public Class ctrlItem_Thumb_Stash
  'Private mItemList As List(Of ctrlitem_List_Item)
  Private mItem As Item_Info

  'Private defaultswatch As New SolidColorBrush(Color.FromArgb(255, 128, 128, 128))
  Public Sub New()
    InitializeComponent()


    'LoadItem(theitem, itemlist)
    'mItemNames = itemlist
    'mItem = theitem

    'If Not theitem Is Nothing Then
    '  Helpers.SetImageSource(theitem.mImageUrl, Me.thumbImage)
    '  GetColorFromImageCenter(theitem.mImageUrl)
    'End If


    'Me.cmbItemPicker.ItemsSource = 

    'Me.swatch.Fill = Helpers.GetColorFromImageCenter(Me.thumbImage)
  End Sub

  Public Sub LoadItem( theitem As Item_Info)
    If theitem Is mItem Then Exit Sub
    'mItemList = itemlist
    mItem = theitem
    If Not theitem Is Nothing Then
      'Helpers.SetURLImageSource(theitem.ImageUrl, Me.thumbImage)
      Me.thumbImage.Source = PageHandler.dbImages.GetItemImage(theitem.ItemName)
      'GetColorFromImageCenter(theitem.mImageUrl)
    Else
      'Helpers.SetURLImageSource(Nothing, Me.thumbImage)
      Me.thumbImage.Source = Nothing
      'swatch.Fill = defaultswatch
    End If


    'Me.cmbItemPicker.ItemsSource = mItemList

  End Sub
  'Private Sub GetColorFromImageCenter( theimageurl As String)
  '  If theimageurl = "" Then Exit Sub
  '  Dim fu As New BitmapImage
  '  fu.CreateOptions = BitmapCreateOptions.None
  '  AddHandler fu.ImageOpened, AddressOf fu_imageopened
  '  fu.UriSource = New Uri("http://cdn.dota2.com/apps/dota2/images/heroes/earthshaker_vert.jpg", UriKind.Absolute)
  '  fu.UriSource = New Uri(theimageurl, UriKind.Absolute)

  'End Sub
  'Private Sub fu_imageopened(sender As Object, e As RoutedEventArgs)
  '  Dim wbmp As WriteableBitmap
  '  Try
  '    wbmp = New WriteableBitmap(sender)
  '  Catch ex As Exception
  '    Dim x = 2
  '  End Try

  '  If Not wbmp Is Nothing Then
  '    Dim pixels = wbmp.Pixels

  '    Dim britepix As New List(Of Integer)
  '    For i As Integer = 0 To pixels.Count - 1


  '      Dim thebytes() = BitConverter.GetBytes(pixels(i))

  '      If thebytes(0) > 50 And thebytes(1) > 50 And thebytes(2) > 50 Then
  '        britepix.Add(pixels(i))
  '      End If
  '    Next

  '    Dim outpix As Integer = britepix.Item(britepix.Count / 2)

  '    Dim outbytes() = BitConverter.GetBytes(outpix)
  '    Me.swatch.Fill = New SolidColorBrush(Color.FromArgb(outbytes(3), outbytes(0), outbytes(1), outbytes(2)))
  '  End If

  'End Sub
End Class
