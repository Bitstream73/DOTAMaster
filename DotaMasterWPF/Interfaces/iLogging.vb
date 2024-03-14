Public Interface iLogging
  Sub Writelog(message As String)
  Sub WriteTestLog(message As String)

  Function GetLogFilePath([date] As DateTime, [directory] As String) As String

  Function GetDateStamp([date] As DateTime) As String
End Interface
