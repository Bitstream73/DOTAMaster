Public Class btnMinimalState
  Private mButtonStates As List(Of String)
  Private mCurState As Integer
  Private mOnColor As SolidColorBrush
  Private mOffColor As SolidColorBrush
  Private mFontColor As SolidColorBrush
  Private mFontSize As Double
  Private mHeight As Double
  Private mMargin As Thickness
  Event Click( btn As btnMinimalState)
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
    btnMinimal.Height = mHeight

    mMargin = themargin
    btnMinimal.Margin = mMargin



    mCurState = 0
    btnMinimal.Content = thebuttonStates.Item(0).ToUpper


    'for buttons that aren't on/off switches
    If mButtonStates.Count > 2 Or mButtonStates.Count < 2 Then
      mOffColor = mOnColor
    End If

    SetState(0)
  End Sub

  Public Function getstate() As Integer
    Return mCurState
  End Function

  Public Sub SetState( thestateindex As Integer)
    If mButtonStates Is Nothing Then Exit Sub

    If thestateindex < 0 Then
      mCurState = mButtonStates.Count - 1
    Else
      mCurState = thestateindex
    End If
    If thestateindex >= mButtonStates.Count Then
      mCurState = 0
    End If


    If thestateindex = 1 Then
      btnMinimal.Background = mOnColor
    Else
      btnMinimal.Background = mOffColor
    End If

    btnMinimal.Content = " " & mButtonStates.Item(mCurState).ToUpper & " "
  End Sub

  Public Sub SetAsActive( isactive As Boolean)
    If isactive Then
      AddHandler Me.MouseLeftButtonDown, AddressOf btnMinimal_MouseLeftButtonDown
      SetState(0)
    Else
      RemoveHandler Me.MouseLeftButtonDown, AddressOf btnMinimal_MouseLeftButtonDown
      Dim trspnt = New SolidColorBrush(PageHandler.dbColors.Transparent)
      Me.btnMinimal.Background = trspnt
      Me.btnMinimal.Foreground = trspnt

    End If
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
