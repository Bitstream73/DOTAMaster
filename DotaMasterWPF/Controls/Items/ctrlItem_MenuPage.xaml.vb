Imports System.Windows.Media.Imaging
Public Class ctrlItem_MenuPage
  'Event ItemSelected( theitem As Item_Info)
  Public Sub New()
    InitializeComponent()


  End Sub

  Public Sub AddItem( theitem As ctrlItem_MenuItem,  therow As Integer,  thecol As Integer)

    theitem.SetValue(Grid.RowProperty, therow)
    theitem.SetValue(Grid.ColumnProperty, thecol)
    'AddHandler theitem.MouseLeftButtonDown, Me_MouseLeftButtonDown


    LayoutRoot.Children.Add(theitem)

  End Sub

  'Public Sub AddItem(theitem As ctrlItem_MenuItem, therow As Integer, thecol As Integer, thebitmap As BitmapImage, buildsfrom As List(Of Item_Info), buildsto As List(Of Item_Info))
  '  Dim newctrl As New ctrlItem_MenuItem(theitem.mitem, thebitmap, buildsfrom, buildsto)

  '  AddItem(newctrl, therow, thecol)
  'End Sub

  'Private Function Me_MouseLeftButtonDown() As Object
  '  RaiseEvent ItemSelected()
  'End Function

End Class
