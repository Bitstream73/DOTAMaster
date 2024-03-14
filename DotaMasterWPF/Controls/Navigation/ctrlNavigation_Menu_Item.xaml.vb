Public Class ctrlNavigation_Menu_Item
  Private mGameEntity As iGameEntity
  Private mIsSummary As Boolean
  Public Sub New(gameent As iGameEntity, issummary As Boolean)

    InitializeComponent()

    If gameent.MyType = eSourceType.Item_Info Then
      Dim x = 2
    End If

    mGameEntity = gameent
    mIsSummary = issummary
    If Not gameent.MyType = eSourceType.GameEntity_Tuple Then
      If Not mIsSummary Then
        If Not gameent.ParentGameEntity.MyType = eSourceType.Game Then
          lblTextOne.Content = gameent.ParentGameEntity.DisplayName & "'s " & gameent.DisplayName
        Else
          lblTextOne.Content = gameent.DisplayName
        End If

      Else
        lblTextOne.Content = "Summary"
      End If

      If Not gameent.ParentGameEntity.MyType = eSourceType.Game Then

        Dim swatch1 As New ctrlSwatchMinimalLarge
        swatch1.rectSwatch.Fill = New SolidColorBrush(gameent.ParentGameEntity.MyColor)
        swatch1.rectSwatch.Width = 8
        spnlSwatches.Children.Add(swatch1)
      End If


      Select Case gameent.MyType
        Case eSourceType.Modifier, eSourceType.Stat
          Dim swatch2 As New ctrlSwatchRoundMinimalLarge
          swatch2.elpsSwatch.Fill = New SolidColorBrush(gameent.MyColor)
          spnlSwatches.Children.Add(swatch2)

        Case Else
          Dim swatch2 As New ctrlSwatchMinimalLarge
          swatch2.rectSwatch.Fill = New SolidColorBrush(gameent.MyColor)
          spnlSwatches.Children.Add(swatch2)
      End Select

   
      lblTextTwo.Visibility = Windows.Visibility.Collapsed
    Else

      Dim tuple As GameEntity_Tuple = gameent

      Dim swatch1 As New ctrlSwatchMinimalLarge()
      swatch1.rectSwatch.Fill = New SolidColorBrush(tuple.ItemOne.MyColor)
      spnlSwatches.Children.Add(swatch1)

      Dim swatch2 As New ctrlSwatchMinimalLarge
      swatch2.rectSwatch.Fill = New SolidColorBrush(tuple.ItemTwo.MyColor)
      spnlSwatches.Children.Add(swatch2)


      If Not mIsSummary Then
        lblTextOne.Content = tuple.ItemOne.DisplayName & " vs"
        lblTextTwo.Content = tuple.ItemTwo.DisplayName
      Else
        lblTextOne.Content = "Summary"
        lblTextTwo.Visibility = Windows.Visibility.Collapsed
      End If

    End If
  End Sub

  Public ReadOnly Property IsSummary As Boolean
    Get
      Return mIsSummary
    End Get
  End Property
  Public ReadOnly Property MyGameEntity As iGameEntity
    Get
      Return mGameEntity
    End Get
  End Property

End Class
