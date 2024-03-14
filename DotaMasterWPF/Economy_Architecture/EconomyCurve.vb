Imports DotaMasterWPF.PageHandler
Public Class EconomyCurve

  Private mPercentage As Decimal
  Private mtimes As DDFrame_List
  Private mvals As List(Of Double?)
  Private mtimekeeper As TimeKeeper
  Private mPeriodicGold As List(Of Double?)

  Private _xpNeededPerLevel As List(Of Integer)

  Public Sub New(thetimes As DDFrame_List, thevals As List(Of Double?), _
                  thepercentage As Decimal, _
                  thexpneededperlevel As List(Of Integer), _
                  thetimekeeper As TimeKeeper, _
                  theperiodicgold As List(Of Double?))

    mtimekeeper = thetimekeeper
    mtimes = thetimes
    mvals = thevals
    mPercentage = thepercentage
    mPeriodicGold = theperiodicgold
    _xpNeededPerLevel = thexpneededperlevel


    ' CalcPeriodicGold()
  End Sub

  Public Function GetValueForIndex( theind As Integer) As Double?
    Return mvals.Item(theind)
  End Function
  Public Function GetLevelForTime( thetime As ddFrame) As Integer
   
    Dim availablexp = Me.GetValueForTime(thetime)

    Dim outlevel As Integer = 1

    For i As Integer = 0 To _xpNeededPerLevel.Count - 1
      Dim curxp = _xpNeededPerLevel.Item(i)
      If availablexp > curxp Then
        outlevel += 1
      Else

        Return outlevel
      End If

    Next

    Return 25

  End Function

  'Private Function CalcPeriodicGold()
  '  Dim curval As Double = Constants.cStartingGold

  '  Dim times = mtimekeeper.TimePoints.TheFrames
  '  Dim minuteval = Constants.cPeriodicgGoldPerSec * mtimekeeper.Framerate.count
  '  mPeriodicGold = New List(Of Double?)
  '  For i = 0 To times.Count - 1
  '    mPeriodicGold.Add(curval)
  '    curval += minuteval
  '  Next
  'End Function

  Public ReadOnly Property XPNeededPerLevel() As List(Of Integer)
    Get

      Return _xpNeededPerLevel

    End Get
  End Property

  Public Function GetXPNeededforLevel( thelevel As Integer) As Integer
    If thelevel < 2 Then Return 0
    Return _xpNeededPerLevel.Item(thelevel - 2)

  End Function

  Public ReadOnly Property Percentage As Decimal
    Get
      Return mPercentage
    End Get
  End Property


  Public ReadOnly Property Values As List(Of Double?)
    Get
      Return mvals
    End Get
  End Property
  Public Function GetValueForTime( thetime As ddFrame) As Integer

    If mtimes.TheFrames.Contains(thetime) Then
      Return mvals.Item(mtimes.TheFrames.IndexOf(thetime))
    Else
      Dim curtime As Integer = 0
      For i As Integer = 0 To mtimes.TheFrames.Count - 1
        If thetime.count >= mtimes.Item(i).count Then
          curtime = i
        End If
      Next
      Return mvals.Item(curtime)
     
    End If
  

  End Function

  Public ReadOnly Property PeriodicGold As List(Of Double?)
    Get
      Return mPeriodicGold
    End Get
  End Property
  Public Function GetTimeforValue( thevalue As Double) As ddFrame
    If thevalue = 17000 Then
      Dim x = 2

    End If


    If mvals.Contains(thevalue) Then
      Return mTimeKeeper.TimePoints.Item(mvals.IndexOf(thevalue))
    Else

      Dim curindex As Integer = 0


      For i As Integer = 0 To mvals.Count - 1
        If thevalue >= mvals.Item(i) Then
          curindex = i
        End If

      Next

      If thevalue > mvals.Item(mvals.Count - 1) Then
        Return Nothing
      Else
        Return mTimeKeeper.TimePoints.Item(curindex)
      End If


    End If



  End Function

End Class
