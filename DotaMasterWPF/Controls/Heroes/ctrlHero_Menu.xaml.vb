Public Class ctrlHero_Menu
  Private mOwner As ctrlHero_Badge
  Event HeroPicked( thehero As HeroBuild,  owner As ctrlHero_Badge)
  Public Sub New()
    InitializeComponent()
  End Sub
  Public Sub AddItem( theitem As ctrlHero_Menu_Item,  therow As Integer,  thecol As Integer)

    theitem.SetValue(Grid.RowProperty, therow)
    theitem.SetValue(Grid.ColumnProperty, thecol)
    'AddHandler theitem.MouseLeftButtonDown, Me_MouseLeftButtonDown


    LayoutRoot.Children.Add(theitem)
    AddHandler Me.MouseLeftButtonDown, AddressOf Me_MouseLeftButtonDown
  End Sub

  Public Sub OpenMenu( owner As ctrlHero_Badge)
    Dim pgrid As Grid = Me.Parent
    pgrid.Visibility = Windows.Visibility.Visible
    Me.Visibility = Windows.Visibility.Visible
    mOwner = owner
  End Sub

  Private Sub Me_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs)
    Dim Source As FrameworkElement = TryCast(e.OriginalSource, FrameworkElement)
    Me.Visibility = Windows.Visibility.Collapsed
    Dim pgrid As Grid = Me.Parent
    pgrid.Visibility = Windows.Visibility.Collapsed

    Select Case Source.Name
      Case "tbkClose"

        RaiseEvent HeroPicked(Nothing, Nothing)
      Case "ImageThumb"
        Dim theGrid As Grid = Source.Parent
        Dim thectrl As ctrlHero_Menu_Item = theGrid.Parent


        RaiseEvent HeroPicked(thectrl.mHero, mOwner)

    End Select
    e.Handled = True
  End Sub
End Class
