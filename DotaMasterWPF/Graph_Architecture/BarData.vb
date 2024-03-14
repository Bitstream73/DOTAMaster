Public Class BarData
  Private mBarsTime As ddFrame
  Private mValues As New List(Of List(Of Double)) '0 rad, 1 Dire

  Private mParentColors As List(Of List(Of Color)) '0 rad, 1 Dire
  Private mSourceColors As List(Of List(Of Color)) '0 rad, 1 Dire
  Private mValueColor As Color
  Private mTeamColors As List(Of Color) '0 rad, 1 Dire


  
  Public Sub New(barstime As ddFrame, _
                 values As List(Of List(Of Double)), _
                 parentcolors As List(Of List(Of Color)), _
                 sourcecolors As List(Of List(Of Color)), _
                 valuecolor As Color, _
                 teamcolors As List(Of Color))

    mBarsTime = barstime
    mValues = values

    mParentColors = parentcolors
    mSourceColors = sourcecolors
    mValueColor = valuecolor
    mTeamColors = teamcolors

  End Sub

  Public Property BarsTime As ddFrame
    Get
      Return mBarsTime
    End Get
    Set(value As ddFrame)
      mBarsTime = value
    End Set
  End Property

  Public Property Values As List(Of List(Of Double))
    Get
      Return mValues
    End Get
    Set(value As List(Of List(Of Double)))
      mValues = value
    End Set
  End Property

  Public Property ParentColors As List(Of List(Of Color))
    Get
      Return mParentColors
    End Get
    Set(value As List(Of List(Of Color)))
      mParentColors = value
    End Set
  End Property

  Public Property SourceColors As List(Of List(Of Color))
    Get
      Return mSourceColors
    End Get
    Set(value As List(Of List(Of Color)))
      mSourceColors = value
    End Set
  End Property

  Public Property ValueColor As Color
    Get
      Return mValueColor
    End Get
    Set(value As Color)
      mValueColor = value
    End Set
  End Property

  Public Property TeamColors As List(Of Color)
    Get
      Return mTeamColors
    End Get
    Set(value As List(Of Color))
      mTeamColors = value
    End Set
  End Property
End Class
