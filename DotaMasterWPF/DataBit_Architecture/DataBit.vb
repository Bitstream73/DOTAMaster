Public Class DataBit
  Public mSource As eUnit
  Public mOwner As eUnit
  Public mTooltip As ctrlToolTip
  Public mValue As Double
  Public mSourceColor As SolidColorBrush
  Public mValueColor As SolidColorBrush

  Event mousedown( thebit As DataBit)
  Public Sub New( thesource As eUnit,  theowner As eUnit, _
                  thetooltip As ctrlToolTip,  thevalue As Double, _
                  thesourcecolor As SolidColorBrush,  thevaluecolor As SolidColorBrush)

    mSource = thesource
    mOwner = theowner
    mTooltip = thetooltip
    mValue = thevalue
    mSourceColor = thesourcecolor
    mValueColor = thevaluecolor

    'add handler for rect.mousedown

  End Sub

End Class
