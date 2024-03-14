Public Class ctrlPetSummary
  Private mPets As PetStack
  Private mGame As dGame
  Private mThumbs As List(Of ctrlHero_Thumb)
  Public Sub New()
    InitializeComponent()


  End Sub

  Public Sub Load(pets As PetStack, thegame As dGame)
    If pets Is Nothing Then Exit Sub
    If pets.Pets.Count < 1 Then Exit Sub

    mPets = pets
    mGame = thegame
    LayoutRoot.Children.Clear()
    mThumbs = New List(Of ctrlHero_Thumb)

    For i As Integer = 0 To mPets.Pets.Count - 1
      Dim curcreep = mPets.Pets.Item(i)
      Dim color = New SolidColorBrush(PageHandler.dbColors.GetColor(curcreep))
      Dim newthum As New ctrlHero_Thumb()
      newthum.LoadPet(curcreep, color, Nothing)
      newthum.SetUnresponsive(35)
      'newthum.SwatchVisible(True)
      newthum.HorizontalAlignment = Windows.HorizontalAlignment.Center
      mThumbs.Add(newthum)
      LayoutRoot.Children.Add(newthum)
    Next
  End Sub

  Public Sub SetCurrentTime(thetime As ddFrame)
    Dim visible = mPets.GetVisibleAtTime(thetime)

    For i As Integer = 0 To visible.Count - 1
      If visible.Item(i) Then
        mThumbs.Item(i).Visibility = Windows.Visibility.Visible
      Else
        mThumbs.Item(i).Visibility = Windows.Visibility.Collapsed
      End If
    Next
  End Sub
End Class
