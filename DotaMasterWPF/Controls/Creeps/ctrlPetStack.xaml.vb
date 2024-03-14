Public Class ctrlPetStack
  Private mSummary As ctrlPetSummary
  Private mMyPets As PetStack
  Private mButtons As List(Of btnMinimalClick)

  Private mTabs As New List(Of ctrlPet_Badge)

  Private mStrokeThick = Constants.cMinBtnStrokeThickness
  Private mAccentColor = New SolidColorBrush(PageHandler.dbColors.AccentedColor)

  Private mOwner As iDisplayUnit

  Private dbNames As FriendlyName_Database

  Private mTeam As dTeam
  Private mTeamPosition As Integer 'for child of hero_build, use hero_build's postiiong
  Private mGame As dGame
  Private mLog As Logging
  Public Sub New()
    InitializeComponent()
  End Sub

  Public Sub Load(pets As PetStack, theparent As iDisplayUnit, _
                   team As dTeam, theteamposition As Integer, _
                   thegame As dGame, _
                   namesdb As FriendlyName_Database, thelog As Logging)

    mLog = thelog
    mMyPets = pets
    mOwner = theparent
    mTeam = team
    mTeamPosition = theteamposition
    mGame = thegame

    dbNames = namesdb

    LoadTabs()





  End Sub



  Private Sub LoadTabs()

    rectTabButtonTopLine.Fill = mAccentColor
    rectTabButtonTopLine.Height = Constants.cMinBtnStrokeThickness
    rectTabButtonTopLine.HorizontalAlignment = Windows.HorizontalAlignment.Stretch
    rectTabButtonTopLine.VerticalAlignment = Windows.VerticalAlignment.Top

    lblTabContBorder.BorderBrush = mAccentColor
    lblTabContBorder.BorderThickness = New Thickness(mStrokeThick, mStrokeThick, mStrokeThick, 0)

    lblTabContBorder.Background = New SolidColorBrush(PageHandler.dbColors.Transparent)
    LayoutRoot.Margin = lblTabContBorder.BorderThickness
    mSummary = New ctrlPetSummary
    mSummary.Load(mMyPets, mGame)
    Dim oncolor = Helpers.GetTransparencyBrush(PageHandler.dbColors.TrasparencyGlobalValue * 4, New SolidColorBrush(mMyPets.SwatchColor))
    mSummary.LayoutRoot.Background = oncolor
    ContentRoot.Children.Add(mSummary)




    mButtons = New List(Of btnMinimalClick)

    Dim btnsummary As New btnMinimalClick()
    Dim statelist As New List(Of String)
    statelist.Add("Summary")
    statelist.Add("Summary")



    btnsummary.LoadButton(statelist, oncolor, New SolidColorBrush(PageHandler.dbColors.ButtonColorNotSelected), _
                          New SolidColorBrush(PageHandler.dbColors.HeadingTextColor), Constants.cMinBtnTextSize, Constants.cMinbtnHeight, New Thickness(0))
    btnsummary.Name = grdButtons.Name.ToString & "Summary0"
    btnsummary.SetOnStateBorder(New Thickness(mStrokeThick, 0, mStrokeThick, mStrokeThick), mAccentColor)
    btnsummary.SetOffStateBorder(New Thickness(mStrokeThick, 0, mStrokeThick, mStrokeThick), mAccentColor)
    btnsummary.Visibility = Windows.Visibility.Visible
    btnsummary.SetState(1)
    AddHandler btnsummary.Click, AddressOf btnsummary_Click

    mButtons.Add(btnsummary)


    Dim newcol As New ColumnDefinition
    newcol.Width = New GridLength(1, GridUnitType.Star)
    grdButtons.ColumnDefinitions.Add(newcol)
    btnsummary.SetValue(Grid.ColumnProperty, grdButtons.ColumnDefinitions.Count - 1)
    grdButtons.Children.Add(btnsummary)

    For i As Integer = 0 To mMyPets.pets.Count - 1
      AddTab(mMyPets.GetPetByIndex(i), mMyPets.GetPetByIndex(i).DisplayName & " " & i + 1, i + 1)
    Next



  End Sub

  Private Sub SetButtonWidths()
    Dim curbtnwidths As Double

    For i As Integer = 0 To mButtons.Count - 1
      curbtnwidths += mButtons.Item(i).ActualWidth
    Next
    If curbtnwidths > Me.ActualWidth Then
      Dim newwidth As Integer = Math.Floor(Me.ActualWidth / mButtons.Count)
      For i As Integer = 0 To mButtons.Count - 1
        mButtons.Item(i).Width = newwidth
      Next

    End If
  End Sub
  Private Sub AddTab(pet As Pet_Instance, thecreepdisplayname As String, theindex As Integer)

    Dim newtab = New ctrlPet_Badge(pet)

    Dim oncolor = Helpers.GetTransparencyBrush(PageHandler.dbColors.TrasparencyGlobalValue * 4, New SolidColorBrush(mMyPets.SwatchColor))
    newtab.LayoutRoot.Background = New SolidColorBrush(PageHandler.dbColors.DarkenOverlay)
    newtab.Visibility = Windows.Visibility.Collapsed
    Try
      newtab.Name = "fu" ' theindex.ToString & "tab"
    Catch ex As Exception
      Dim x = 2
    End Try

    mTabs.Add(newtab)
    ContentRoot.Children.Add(newtab)


    Dim btntabbtn As New btnMinimalClick()
    Dim statelist As New List(Of String)
    statelist.Add(pet.DisplayName & " " & theindex.ToString)
    statelist.Add(pet.DisplayName & " " & theindex.ToString)



    btntabbtn.LoadButton(statelist, oncolor, New SolidColorBrush(PageHandler.dbColors.ButtonColorNotSelected), _
                          New SolidColorBrush(PageHandler.dbColors.HeadingTextColor), Constants.cMinBtnTextSize, Constants.cMinbtnHeight, New Thickness(0))
    btntabbtn.Name = grdButtons.Name.ToString & theindex.ToString
    btntabbtn.SetOnStateBorder(New Thickness(mStrokeThick, 0, mStrokeThick, mStrokeThick), mAccentColor)
    btntabbtn.SetOffStateBorder(New Thickness(mStrokeThick, 0, mStrokeThick, mStrokeThick), mAccentColor)
    btntabbtn.Visibility = Windows.Visibility.Visible
    btntabbtn.SetState(0)
    mButtons.Add(btntabbtn)
    AddHandler btntabbtn.Click, AddressOf btnsummary_Click

    Dim newcol As New ColumnDefinition
    newcol.Width = New GridLength(1, GridUnitType.Star)
    grdButtons.ColumnDefinitions.Add(newcol)
    btntabbtn.SetValue(Grid.ColumnProperty, grdButtons.ColumnDefinitions.Count - 1)
    grdButtons.Children.Add(btntabbtn)
  End Sub
  Public Sub SetTime(thetime As ddFrame)
    Dim thevisibles = mMyPets.GetVisibleAtTime(thetime)
    mSummary.SetCurrentTime(thetime)
    For i As Integer = 0 To mMyPets.Pets.Count - 1
      If thevisibles.Item(i) Then

      Else


      End If
    Next
  End Sub

  Public Sub SetTargets(theenemytarget As dvID, thefriendtarget As dvID, thebias As Boolean)
    mMyPets.SetTargets(theenemytarget, thefriendtarget, thebias)
  End Sub

  Private Sub SetTabVisibility(thevisibletabindex As Integer)

    If thevisibletabindex = 0 Then
      mSummary.Visibility = Windows.Visibility.Visible
      mButtons.Item(0).SetState(1)
    Else
      mSummary.Visibility = Windows.Visibility.Collapsed
      mButtons.Item(0).SetState(0)
    End If

    For i As Integer = 0 To mTabs.Count - 1
      Dim curtab = mTabs.Item(i)
      If i = thevisibletabindex - 1 Then
        curtab.Visibility = Windows.Visibility.Visible
        mButtons.Item(i + 1).SetState(1)
      Else
        curtab.Visibility = Windows.Visibility.Collapsed
        mButtons.Item(i + 1).SetState(0)
      End If

    Next
  End Sub
  Private Sub btnsummary_Click(btn As btnMinimalClick)
    Dim thebtn As btnMinimalClick = btn

    Select Case btn.Name
      Case grdButtons.Name.ToString & "Summary0"
        If Not mSummary.Visibility = Windows.Visibility.Visible Then
          SetTabVisibility(0)
        End If
      Case Else
        Dim indstr = btn.Name.Trim(grdButtons.Name.ToString)
        Dim ind = Helpers.ConvertStringToNumber(indstr)

        Dim curtab = mTabs.Item(ind - 1)
        If Not curtab.Visibility = Windows.Visibility.Visible Then
          SetTabVisibility(ind)
        End If
    End Select
  End Sub

End Class
