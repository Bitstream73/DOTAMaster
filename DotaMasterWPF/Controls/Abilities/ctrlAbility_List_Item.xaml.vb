Public Class ctrlAbility_List_Item
  Implements IComparable(Of ctrlitem_List_Item)

  'Implements IComparable(Of ctrlitem_List_Item)
  'Implements IEquatable(Of ctrlitem_List_Item)

  Private mImage As String
  Private mContent As String
  Public mAbility As Ability_Info
  Public mTooltip As ToolTip
  Public mFriendlyAbilityName As String
  Public Sub New(theability As Ability_Info, friendlyname As String)
    InitializeComponent()
    mImage = theability.ImageUrl
    mFriendlyAbilityName = friendlyname
    mContent = friendlyname
    mAbility = theability

    mTooltip = New ToolTip()
    Dim thick As New Thickness(0)
    mTooltip.BorderThickness = thick
    ToolTipService.SetToolTip(Me, mTooltip)

    'Helpers.SetURLImageSource(mImage, Me.ImageThumb)
    Me.ImageThumb.Source = PageHandler.dbImages.GetAbilityImage(theability.AbilityName)

    lblItemName.Content = mFriendlyAbilityName
    FormatMe()



    'mToolTip = New ToolTip()

    'Dim ctrlTT As New ctrlAbility_Tooltipe(mAbility)
    'Dim thick As New Thickness(0)
    'mToolTip.BorderThickness = thick
    'mTooltip.Content = ctrlTT
    AddHandler Me.MouseEnter, AddressOf Me_MouseEnter
    ' AddHandler Me.MouseLeave, AddressOf Me_MouseLeave
    ' AddHandler Me.MouseLeftButtonDown, AddressOf Me_MouseLeftButtonDown

    'ToolTipService.SetToolTip(Me, mToolTip)
  End Sub



  Private Sub FormatMe()
    If mAbility.IsUltimate Then
      lblItemName.Foreground = New SolidColorBrush(Color.FromArgb(255, 255, 0, 0))
    Else
      lblItemName.Foreground = New SolidColorBrush(Color.FromArgb(255, 0, 0, 0))
    End If
  End Sub



  Public Function CompareTo(other As ctrlitem_List_Item) As Integer Implements IComparable(Of ctrlitem_List_Item).CompareTo
    If other Is Nothing Then
      Return 1
    Else
      Dim tcont As String = Me.lblItemName.Content
      Return tcont.CompareTo(other)

    End If
  End Function

  Private Sub Me_MouseEnter(sender As Object, e As MouseEventArgs)


    Dim ctrlTT As New ctrlAbility_Tooltipe(mAbility, 0, mFriendlyAbilityName)

    mTooltip.Content = ctrlTT

    ' mTooltip.IsOpen = True
  End Sub

  'Private Sub Me_MouseLeave(sender As Object, e As MouseEventArgs)
  '  mTooltip.IsOpen = False
  'End Sub

  'Private Sub Me_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs)
  '  mTooltip.IsOpen = False
  'End Sub
End Class
