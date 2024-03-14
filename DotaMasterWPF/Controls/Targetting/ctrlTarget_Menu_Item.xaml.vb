Public Class ctrlTarget_Menu_Item
  Private mHero As iHeroUnit
  Public Sub New(hero As iHeroUnit)

    InitializeComponent()

    mHero = hero

    rectOne.Fill = New SolidColorBrush(mHero.MyColor)
    lblTextOne.Content = mHero.DisplayName

    rectTwo.Visibility = Windows.Visibility.Collapsed
    lblTextTwo.Visibility = Windows.Visibility.Collapsed
    
  End Sub

  Public ReadOnly Property Hero As iHeroUnit
    Get
      Return mHero
    End Get
  End Property
  Public Overrides Function ToString() As String
    Return mHero.DisplayName
  End Function
End Class
