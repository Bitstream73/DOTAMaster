Imports System.IO
Imports System.IO.IsolatedStorage
Public Class Settings
  'Public mLastItem As Integer
  'Public mImportPath As String
  Public mBuildPath As String
  'Public mLastLoginName As String
  'Private mIsostore As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication


  ' Private appsettings As IsolatedStorageSettings = IsolatedStorageSettings.ApplicationSettings

 




  Public Sub AddApplicationSetting( settingname As String,  settingvalue As Object)
    'settingname = settingname.ToLower
    'If appsettings.Contains(settingname) Then
    '  appsettings.Remove(settingname)
    'End If
    'appsettings.Add(settingname, settingvalue)
  End Sub



  Public Sub UpdateApplicationSetting( settingname As String,  newvalue As String)
    'settingname = settingname.ToLower
    'appsettings(settingname) = newvalue
  End Sub

  Public Function GetApplicationSetting( settingname As String) As Object
    'settingname = settingname.ToLower
    'If appsettings.Contains(settingname) Then
    '  Return appsettings(settingname)

    'End If
    'Return Nothing
  End Function

  Public Function ContainsSetting( settingname As String) As Boolean
    'If appsettings.Contains(settingname) Then Return True
    'Return False
  End Function


End Class
