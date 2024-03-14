Public Class Lifetime
  'Private mCreationTime As DateTime
  'Private mLifespan As TimeSpan

  'Private mAbilityLevelTimes As List(Of DateTime)
  'Private isAbilityLifetime As Boolean = False

  Private mStartTimes As List(Of ddFrame)
  Private mEndTimes As List(Of ddFrame)

  Private mAghsStartTimes As List(Of ddFrame)
  Private mAghsEndTimes As List(Of ddFrame)

  Public Sub New( thestarts As List(Of ddFrame),  theends As List(Of ddFrame))

    For i As Integer = 0 To thestarts.Count - 1
      If thestarts.Item(i) Is Nothing Then
        Dim x = 2
      End If
    Next

    For i As Integer = 0 To theends.Count - 1
      If theends.Item(i) Is Nothing Then
        Dim x = 2
      End If

    Next
    mStartTimes = thestarts
    mEndTimes = theends
  End Sub

  Public Sub New( thestart As ddFrame,  theend As ddFrame)
    mStartTimes = New List(Of ddFrame)
    mEndTimes = New List(Of ddFrame)

    mStartTimes.Add(thestart)
    mEndTimes.Add(theend)
  End Sub

  Public Sub New( thetimes As List(Of ddFrame),  theframerate As ddFrame)

    mStartTimes = New List(Of ddFrame)
    mEndTimes = New List(Of ddFrame)

    Dim prevFrame As ddFrame
    ' Dim previousframecount As Integer
    Dim frameratecoune As Integer = theframerate.count


    If thetimes.Count > 0 Then
      mStartTimes.Add(thetimes.Item(0))

      prevFrame = thetimes.Item(0)

      If thetimes.Count > 1 Then
        For i As Integer = 1 To thetimes.Count - 1


          Dim curframe = thetimes.Item(i)

          If i = thetimes.Count - 1 Then
            mEndTimes.Add(curframe)
          End If

          If Not curframe.count - frameratecoune = prevFrame.count Then
            mEndTimes.Add(prevFrame)
            mStartTimes.Add(curframe)
          End If

          prevFrame = curframe
        Next
        

      Else
        mEndTimes.Add(thetimes.Item(0))
      End If

    End If


  End Sub

  'Public Sub New( thecreationtime As DateTime,  thelifespan As TimeSpan)
  '  mStartTimes = New List(Of DateTime)
  '  mEndTimes = New List(Of DateTime)

  '  mStartTimes.Add(thecreationtime)

  '  mEndTimes.Add(New DateTime(thecreationtime.Ticks + thelifespan.Ticks))
  'End Sub

  'Public Sub New( theabilityleveltimes As List(Of DateTime))
  '  isAbilityLifetime = True
  '  mAbilityLevelTimes = theabilityleveltimes
  'End Sub

  Public ReadOnly Property EndTime As ddFrame
    Get
      If Not mEndTimes Is Nothing Then
        Return mEndTimes.Item(mEndTimes.Count - 1)
      Else
        Return Nothing
      End If

      'If Not isAbilityLifetime Then
      '  Return mCreationTime.AddTicks(mLifespan.Ticks)
      'Else
      '  Return PageHandler.mTimeKeeper.GameEnd
      'End If

    End Get
  End Property

  Public Function GetLevelAtTime( thetime As ddFrame) As Integer
    If StartTimes.Count < 1 Then Return 0
    If thetime.count < StartTimes.Item(0).count Then Return 0

    For i As Integer = StartTimes.Count - 1 To 0 Step -1
      If thetime.count >= StartTimes.Item(i).count Then Return i + 1
    Next
    Return StartTimes.Count
  End Function
  Public Function LifeTimeContainsTime( thetime As ddFrame) As Boolean
    For i As Integer = 0 To mStartTimes.Count - 1
      If thetime.count >= mStartTimes.Item(i).count And thetime.count <= mEndTimes.Item(i).count Then Return True
    Next


    Return False
  End Function

  Public Function IsAghsAtTime( thetime As ddFrame) As Boolean
    For i As Integer = 0 To mStartTimes.Count - 1
      If thetime.count >= mAghsStartTimes.Item(i).count And thetime.count <= mAghsEndTimes.Item(i).count Then Return True
    Next
    Return False
  End Function
  Public Sub LoadAghsTimes( thestarts As List(Of ddFrame),  theends As List(Of ddFrame))
    mAghsStartTimes = thestarts
    mAghsEndTimes = theends

  End Sub

  Public ReadOnly Property StartTimes As List(Of ddFrame)
    Get
      If Not mStartTimes Is Nothing Then
        Return mStartTimes
      End If
      Return Nothing
    End Get
  End Property
  Public ReadOnly Property CreationTime As ddFrame
    Get
      If Not mStartTimes Is Nothing Then
        Return mStartTimes.Item(0)

      End If
      Return Nothing
    End Get
  End Property

  Public ReadOnly Property Lifespan As ddFrame
    Get
      If Not mEndTimes Is Nothing And Not mStartTimes Is Nothing Then
        If mStartTimes.Count > 0 And mEndTimes.Count > 0 Then
          Return New ddFrame(mEndTimes.Item(mEndTimes.Count - 1).count - mStartTimes.Item(0).count)
        End If

      End If
      Return Nothing
    End Get
  End Property
End Class
