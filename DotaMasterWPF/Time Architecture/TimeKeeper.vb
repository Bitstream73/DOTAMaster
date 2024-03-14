Public Class TimeKeeper
  Private mMasterTimePoints As DDFrame_List 'New List(Of ddFrame)
  Private mFramerate As ddFrame
  Private mGameStart As ddFrame
  Private mGameEnd As ddFrame
  Private mGameDuration As ddFrame
  Private mGameLifetime As Lifetime
  Private mCurrentTime As ddFrame
  Private mCurrentTimeIndex As UInteger = 0
  Private mFriendlyTimes As New List(Of String)

  Private mDayLifetime As Lifetime
  Private mNightLifetime As Lifetime

  Public Sub New( theframerate As ddFrame,  gamestart As ddFrame,  gameduration As ddFrame)
    mFramerate = theframerate
    mGameStart = gamestart
    mGameDuration = gameduration
    mGameEnd = New ddFrame(mGameStart.count + gameduration.count - 1)
    mGameLifetime = New Lifetime(New ddFrame(mGameStart.count), mGameDuration)
    LoadTimes()
    LoadFriendlyTimes()

    CalcDayLifeTime()
    CalcNightLifeTime()
  End Sub

  Private Sub LoadTimes()
    '  mMasterTimePoints.Clear()
    Dim outlist As New List(Of ddFrame)
    Dim curtime As New ddFrame(mGameStart.count)
    Dim index As Integer = 0
    Do While curtime.count <= mGameEnd.count
      Dim curframe As New ddFrame(curtime.count)
      curframe.TimeIndex = index

      outlist.Add(curframe)

      curtime.count = curtime.count + mFramerate.count
      index += 1
    Loop

    mMasterTimePoints = New DDFrame_List(outlist)
    mGameEnd = mMasterTimePoints.TheFrames.Item(mMasterTimePoints.TheFrames.Count - 1)
    mGameDuration = New ddFrame(mGameEnd.count - mGameStart.count)
  End Sub

  Private Sub LoadFriendlyTimes()
    Dim tpoints = mMasterTimePoints.TheFrames
    For i = 0 To tpoints.Count - 1
      Dim curframe = tpoints.Item(i)
      mFriendlyTimes.Add(CreateFriendlyTime(curframe))
    Next
  End Sub

  Private Sub CalcDayLifeTime()
    Dim daynightint = Constants.cDayNightFrameCount

    Dim daystarttimes As New List(Of ddFrame)
    Dim dayendtimes As New List(Of ddFrame)

    Dim lastframe = TimePoints.TheFrames.Count
    For i = 0 To lastframe - 1 Step (daynightint / mFramerate.count) * 2
      daystarttimes.Add(New ddFrame(i))
      If Not i + daynightint + 1 > lastframe Then
        dayendtimes.Add(New ddFrame(i + daynightint))
      Else
        dayendtimes.Add(New ddFrame(lastframe))
      End If

    Next

    mDayLifetime = New Lifetime(daystarttimes, dayendtimes)
  End Sub

  Private Sub CalcNightLifeTime()
    Dim daynightint = Constants.cDayNightFrameCount

    Dim nightstarttimes As New List(Of ddFrame)
    Dim nightendtimes As New List(Of ddFrame)

    Dim lastframe = TimePoints.TheFrames.Count
    For i = (daynightint / mFramerate.count) - 1 To lastframe - 1 Step (daynightint / mFramerate.count) * 2
      nightstarttimes.Add(New ddFrame(i))
      If Not i + daynightint + 1 > lastframe Then
        nightendtimes.Add(New ddFrame(i + daynightint))
      Else
        nightendtimes.Add(New ddFrame(lastframe))
      End If

    Next

    mNightLifetime = New Lifetime(nightstarttimes, nightendtimes)

  End Sub

  Public ReadOnly Property DayLifetime As Lifetime
    Get
      Return mDayLifetime
    End Get
  End Property

  Public ReadOnly Property NightLifetime As Lifetime
    Get
      Return mNightLifetime
    End Get
  End Property
  Public ReadOnly Property FriendlyTimes As List(Of String)
    Get
      Return mFriendlyTimes
    End Get
  End Property

  Private Function CreateFriendlyTime(thetime As ddFrame) As String

    Return CreateFriendlyTime(New DateTime(thetime.count * TimeSpan.TicksPerSecond))
  End Function
  Private Function CreateFriendlyTime(thetime As DateTime) As String
    Dim hours = thetime.Hour.ToString

    Dim mins = thetime.Minute.ToString

    Dim secs = thetime.Second.ToString

    Dim ticks = thetime.Millisecond

    Select Case hours
      Case 0
        hours = ""
      Case 1
        hours = "0" & hours & ":"
      Case 2
        hours = hours & ":"
    End Select


    Select Case mins.Length
      Case 0
        mins = "00"
      Case 1
        mins = "0" & mins
    End Select

    Select Case secs.Length
      Case 0
        secs = "00"
      Case 1
        secs = "0" & secs
    End Select
    Dim outval = hours & mins & ":" & secs

    If ticks > 0 Then
      Dim outticks = ticks / 1000
      outticks = Math.Round(outticks, 2)
      Dim strticks = outticks.ToString
      strticks = strticks.Substring(strticks.IndexOf("."))
      outval = outval & strticks
    End If
    Return outval
  End Function

  Public Property CurrentTime As ddFrame
    Get
      If mCurrentTime Is Nothing Then
        mCurrentTime = New ddFrame(0)
      End If

      Return mCurrentTime
    End Get
    Set(value As ddFrame)
      mCurrentTime = value

    End Set
  End Property



  ''' <summary>
  ''' index of the current ddframe, for use with graph.updatetime(bar as index)
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public ReadOnly Property CurrentTimeIndex As Integer
    Get
      Return mCurrentTime.TimeIndex
    End Get
  End Property
  'Public Function GetDurationAsMinutes() As Double
  '  Return mGameDuration.count / 60
  '  'theminutes += mGameDuration.Minutes
  '  'theminutes += mGameDuration.Hours * 60

  '  'Return theminutes
  'End Function

  Public ReadOnly Property GameLifetime() As Lifetime
    Get
      Return mGameLifetime
    End Get
  End Property
  Public ReadOnly Property TimePoints As DDFrame_List 'List(Of ddFrame)
    Get
      Return mMasterTimePoints
    End Get
  End Property


  Public ReadOnly Property Framerate As ddFrame
    Get
      Return mFramerate
    End Get
  End Property

  Public ReadOnly Property GameStart As ddFrame
    Get
      Return mGameStart
    End Get
  End Property


  Public ReadOnly Property GameEnd As ddFrame
    Get
      Return mGameEnd
    End Get
  End Property

  Public ReadOnly Property GameDuration As ddFrame
    Get
      Return mGameDuration
    End Get
  End Property
End Class
