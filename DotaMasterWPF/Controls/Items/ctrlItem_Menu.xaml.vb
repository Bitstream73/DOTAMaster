Public Class ctrlItem_Menu
  Private mOwner As ctrlItem_Thumb_Picker_3
  Event itemPicked( theitem As Item_Info,  owner As ctrlItem_Thumb_Picker_3)
  Public Sub New()
    InitializeComponent()

    Me.Visibility = Windows.Visibility.Collapsed
    AddHandler Me.MouseLeftButtonDown, AddressOf Me_MouseLeftButtonDown

  End Sub

  Public Sub AddTab( themenupage As ctrlItem_MenuPage,  theheader As String)
    Dim tabitem As New TabItem
    tabitem.Header = theheader
    tabitem.Content = themenupage

    tctrlTabs.Items.Add(tabitem)
    AddHandler themenupage.MouseLeftButtonDown, AddressOf Me_MouseLeftButtonDown
  End Sub

  Public Sub OpenMenu( owner As ctrlItem_Thumb_Picker_3)
    Dim pgrid As Grid = Me.Parent
    pgrid.Visibility = Windows.Visibility.Visible
    Me.Visibility = Windows.Visibility.Visible
    mOwner = owner
  End Sub

  Private Sub Me_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs)
    Dim Source As FrameworkElement = TryCast(e.OriginalSource, FrameworkElement)
    Dim pgrid As Grid = Me.Parent
    pgrid.Visibility = Windows.Visibility.Collapsed

    Select Case Source.Name
      Case "tbkClose"
        Me.Visibility = Windows.Visibility.Collapsed
        RaiseEvent itemPicked(Nothing, Nothing)
      Case "ImageThumb"
        Dim theGrid As Grid = Source.Parent
        Dim thectrl As ctrlItem_MenuItem = theGrid.Parent
        Me.Visibility = Windows.Visibility.Collapsed
        If Not thectrl Is Nothing Then
          RaiseEvent itemPicked(thectrl.mitem, mOwner)
        Else
          Dim x = 2
        End If


    End Select

  End Sub
End Class
