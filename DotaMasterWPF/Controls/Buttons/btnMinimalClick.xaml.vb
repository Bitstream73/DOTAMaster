Public Class btnMinimalClick
  Private mButtonStates As List(Of String)
  Private mCurState As Integer
  Private mOnColor As SolidColorBrush
  Private mOffColor As SolidColorBrush
  Private mFontColor As SolidColorBrush
  Private mFontSize As Double
  Private mHeight As Double
  Private mMargin As Thickness

  Private mOnStateBorderThickness As New Thickness(0)
  Private mOnStateBorderColor = New SolidColorBrush(PageHandler.dbColors.AccentedColor)

  Private mOffStateBorderThickness As New Thickness(0)
  Private mOffStateBorderColor = New SolidColorBrush(PageHandler.dbColors.Transparent)

  Event Click( btn As btnMinimalClick)
  Public Sub New()
    InitializeComponent()
  End Sub

  Public Sub LoadButton( thebuttonStates As List(Of String), _
                         theoncolor As SolidColorBrush,  theoffcolor As SolidColorBrush,
                         thefontcolor As SolidColorBrush,  thefontsize As Double, _
                         theheight As Double,  themargin As Thickness)

    mButtonStates = thebuttonStates

    mOnColor = theoncolor
    mOffColor = theoffcolor

    mFontColor = thefontcolor
    btnMinimal.Foreground = mFontColor

    mFontSize = thefontsize
    btnMinimal.FontSize = thefontsize

    mHeight = theheight
    brdr.Height = mHeight
    btnMinimal.Height = mHeight

    mMargin = themargin
    btnMinimal.Margin = mMargin

    AddHandler Me.MouseLeftButtonDown, AddressOf btnMinimal_MouseLeftButtonDown

    mCurState = 0
    btnMinimal.Content = thebuttonStates.Item(0)



    'for buttons that aren't on/off switches
    If mButtonStates.Count > 2 Or mButtonStates.Count < 2 Then
      mOffColor = mOnColor
    End If

    SetState(0)
  End Sub

  Public Sub SetOnStateBorder( thethicknesses As Thickness,  thecolor As SolidColorBrush)
    mOnStateBorderThickness = thethicknesses
    mOnStateBorderColor = thecolor
  End Sub

  Public Sub SetOffStateBorder( thethicknesses As Thickness,  thecolor As SolidColorBrush)

  End Sub
  'Public Sub SetBorderThickness( thethicknesses As Thickness)
  '  btnMinimal.BorderThickness = thethicknesses
  'End Sub

  'Public Sub SetBorderColor( thecolor As SolidColorBrush)
  '  btnMinimal.BorderBrush = thecolor
  'End Sub
  Public Sub SetState( thestateindex As Integer)

    If thestateindex < 0 Then
      mCurState = mButtonStates.Count - 1
    Else
      mCurState = thestateindex
    End If
    If thestateindex >= mButtonStates.Count Then
      mCurState = 0
    End If


    If thestateindex = 1 Then
      brdr.Background = mOnColor
      btnMinimal.BorderThickness = mOnStateBorderThickness
      btnMinimal.BorderBrush = mOnStateBorderColor
    Else
      brdr.Background = mOffColor
      btnMinimal.BorderThickness = mOffStateBorderThickness
      btnMinimal.BorderBrush = mOffStateBorderColor
    End If

    btnMinimal.Content = " " & mButtonStates.Item(mCurState) & " "
  End Sub

  Private Sub btnMinimal_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs)
    SetState(mCurState + 1)
    RaiseEvent Click(Me)
  End Sub

  Public ReadOnly Property State() As String
    Get
      Return mButtonStates.Item(mCurState)
    End Get
  End Property
End Class
