Imports System.IO
Imports System.IO.IsolatedStorage



Public Class Logging

  Implements iLogging



  Private mdirectory As String

  Private mBuffer As New List(Of String)
  Public Sub New(thedirectory As String)
    mdirectory = thedirectory

    If Not Directory.Exists(mdirectory) Then
      Directory.CreateDirectory(mdirectory)
    End If
  End Sub
  Public Sub Writelog1(message As String) Implements iLogging.Writelog

    ' Exit Sub
    Dim filepath = GetLogFilePath(Date.Now, mdirectory)

    Dim msg = GetDateStamp(Date.Now) & " " & message & vbCrLf
    My.Computer.FileSystem.WriteAllText(filepath, msg, True)

    Console.WriteLine(msg)
  End Sub

  Public Sub WriteTestLog1(message As String) Implements iLogging.WriteTestLog

    Dim filepath = GetTestLogFilePath(Date.Now, mdirectory)

    Dim msg = GetDateStamp(Date.Now) & " " & message & vbCrLf
    My.Computer.FileSystem.WriteAllText(filepath, msg, True)

    Console.WriteLine(msg)
  End Sub

  Public Function GetLogFilePath([date] As Date, directory As String) As String Implements iLogging.GetLogFilePath

    Dim curdate = Date.Now
    Return System.IO.Path.Combine([directory], [date].Year.ToString & [date].Month.ToString & [date].Day.ToString & ".txt")
  End Function

  Shared Function GetTestLogFilePath(thedate As DateTime, thedirectory As String) As String

    Dim curdate = Date.Now
    Return System.IO.Path.Combine(thedirectory, curdate.Year.ToString & curdate.Month.ToString & curdate.Day.ToString & " TEST.txt")
  End Function


  Public Function GetDateStamp([date] As Date) As String Implements iLogging.GetDateStamp


    Return [date].TimeOfDay.ToString
  End Function






End Class