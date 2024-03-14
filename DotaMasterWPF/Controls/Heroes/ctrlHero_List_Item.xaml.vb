Public Class ctrlHero_List_Item
  Private mImage As String
  Private mContent As String
  Public mHerobuild As HeroBuild
  Public Sub New( imageurl As String,  thecontent As String,  theherobuild As HeroBuild)
    InitializeComponent()
    mImage = imageurl
    mContent = thecontent
    mHerobuild = theherobuild

    'Helpers.SetURLImageSource(imageurl, Me.ImageThumb)
    Me.ImageThumb.Source = PageHandler.dbImages.GetHeroImage(theherobuild.mHero.Name)


    lblItemName.Content = thecontent


  End Sub
End Class
