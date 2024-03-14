#Const devmode = True

Imports System.Windows.Media.Imaging

Public Class ctrlHero_Thumb
  'Private mUrl As String
  Private mheroColor As SolidColorBrush
  Private mprmaryStat As ePrimaryStat

  ' Private mHeroList As List(Of eHeroName)
  'Private mTooltip As ToolTip
  'Event LevelChanged( thelevel As Integer)
  Public Event isdirty( owner As Object)
  Public Sub New()

    InitializeComponent()


    ' LoadHero(thehero, herocolor, primaryatt)

    Dim statelist As New List(Of String)
    statelist.Add("Pick Hero")

    Dim colorsdb = PageHandler.dbColors
    btnChangeHero.LoadButton(statelist, _
                             New SolidColorBrush(colorsdb.ButtonColorSelected), New SolidColorBrush(colorsdb.ButtonColorNotSelected), _
                             New SolidColorBrush(colorsdb.HeadingTextColor), 10, 16, New Thickness(0))


    'AddHandler Me.cbxHeroLevel.SelectionChanged, AddressOf cbxHeroLevel_SelectionChanged
    'temp
    'GetColorFromImageCenter(Me.thumbImage)
  End Sub



  'Public Sub New(thecreep As Creep_Info,  herocolor As SolidColorBrush,  primaryatt As ePrimaryStat)

  '  InitializeComponent()


  '  LoadCreep(thecreep, herocolor, primaryatt)

  '  Dim statelist As New List(Of String)
  '  statelist.Add("Pick Hero")

  '  Dim colorsdb = PageHandler.dbColors
  '  btnChangeHero.LoadButton(statelist, _
  '                           colorsdb.ButtonColorSelected, colorsdb.ButtonColorNotSelected, _
  '                           colorsdb.HeadingTextColor, 10, 18, New Thickness(5))


  '  'AddHandler Me.cbxHeroLevel.SelectionChanged, AddressOf cbxHeroLevel_SelectionChanged
  '  'temp
  '  'GetColorFromImageCenter(Me.thumbImage)
  'End Sub


  Public Sub SetUnresponsive( height As Double)


    Dim oldwidth = LayoutRoot.Width
    Dim oldheight = LayoutRoot.Height

    LayoutRoot.Width = ((height * oldwidth) / oldheight)

    ' rowChange.Height = New GridLength(0)
    LayoutRoot.Height = height

    PrimaryAttThumb.Visibility = Windows.Visibility.Collapsed
    'colSwatch.Width = New GridLength(colSwatch.Width.Value / 2, GridUnitType.Pixel)
    lblHeroLevel.Visibility = Windows.Visibility.Collapsed
    'lblPriority.Visibility = Windows.Visibility.Collapsed

  End Sub

  Public Sub SetAsSwatch( width As Double,  height As Double)
    LayoutRoot.Width = width
    LayoutRoot.Height = height
    LayoutRoot.Margin = New Thickness(0, 5, 0, 5)
    colPortrait.Width = New GridLength(0)
    'colSwatch.Width = New GridLength(width)
    rowSwatchPortrait.Height = New GridLength(height)
    'rowChange.Height = New GridLength(0)

    lblHeroLevel.Visibility = Windows.Visibility.Collapsed
    PrimaryAttThumb.Visibility = Windows.Visibility.Collapsed
  End Sub
  Public Sub LoadHero(thehero As HeroInstance, herocolor As SolidColorBrush, primaryatt As ePrimaryStat)
    ' mUrl = imageurl
    mheroColor = herocolor
    mprmaryStat = primaryatt

    'If Not mUrl Is Nothing Then
    'Helpers.SetURLImageSource(mUrl, Me.thumbImage)
    If Not thehero Is Nothing Then
      Me.thumbImage.Source = PageHandler.dbImages.GetHeroImage(thehero.HeroName)
    End If

    'Me.thumbImage.Source = PageHandler.dbHeroBuilds.GetBitmapForHero(murl)
    '  End If


    swatch.Fill = herocolor

    SetPrimaryStat()



  End Sub

  Public Sub LoadPet(pet As Pet_Instance, petcolor As SolidColorBrush, primaryatt As ePrimaryStat)

    mheroColor = petcolor
    mprmaryStat = primaryatt

    If Not pet Is Nothing Then
      Me.thumbImage.Source = PageHandler.dbImages.GetPetImage(pet.PetName)
    End If


    swatch.Fill = petcolor

    SetPrimaryStat()



  End Sub


  Public Sub SetHeroLevel( thelevel As Integer)
    If thelevel < 0 Then
      lblHeroLevel.Content = "Level 0"
      Exit Sub
    End If
    If thelevel > 25 Then
      lblHeroLevel.Content = "Level 25"
      Exit Sub
    End If

    lblHeroLevel.Content = "Level " & thelevel.ToString

  End Sub
  Private Sub SetPrimaryStat()
    Select Case mprmaryStat
      Case ePrimaryStat.Agility
        PrimaryAttThumb.Source = New BitmapImage(New Uri("http://cdn.dota2.com/apps/dota2/images/heropedia/overviewicon_int.png"))
        'Helpers.SetURLImageSource("http://cdn.dota2.com/apps/dota2/images/heropedia/overviewicon_int.png", PrimaryAttThumb)
      Case ePrimaryStat.Intelligence
        'Helpers.SetURLImageSource("http://cdn.dota2.com/apps/dota2/images/heropedia/overviewicon_agi.png", PrimaryAttThumb)
        PrimaryAttThumb.Source = New BitmapImage(New Uri("http://cdn.dota2.com/apps/dota2/images/heropedia/overviewicon_agi.png"))
      Case ePrimaryStat.Strength
        ' Helpers.SetURLImageSource("http://cdn.dota2.com/apps/dota2/images/heropedia/overviewicon_str.png", PrimaryAttThumb)
        PrimaryAttThumb.Source = New BitmapImage(New Uri("http://cdn.dota2.com/apps/dota2/images/heropedia/overviewicon_str.png"))
    End Select
  End Sub
  'Private Sub GetColorFromImageCenter( theimage As System.Windows.Controls.Image)


  '  Dim fu As New BitmapImage
  '  fu.CreateOptions = BitmapCreateOptions.None
  '  AddHandler fu.ImageOpened, AddressOf fu_imageopened
  '  fu.UriSource = New Uri("http://cdn.dota2.com/apps/dota2/images/heroes/earthshaker_vert.jpg", UriKind.Absolute)


  '  Dim fu2 As New BitmapImage()


  'End Sub
  'Private Sub fu_imageopened(sender As Object, e As RoutedEventArgs)
  '  Dim wbmp As New WriteableBitmap(sender)

  '  Dim pixels = wbmp.Pixels

  '  Dim outpixel = pixels(pixels.Count / 2)

  '  Dim thebytes() = BitConverter.GetBytes(outpixel)



  '  Me.swatch.Fill = New SolidColorBrush(Color.FromArgb(thebytes(3), thebytes(0), thebytes(1), thebytes(2)))
  'End Sub

  'Private Sub cbxHeroLevel_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
  '  Dim thecombo As ComboBox = sender
  '  RaiseEvent LevelChanged(thecombo.SelectedIndex)
  'End Sub

End Class
