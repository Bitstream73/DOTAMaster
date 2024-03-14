#Const Devmode = True
Public Class dvID
  Private mID As Guid

  Private mMetainfo As New List(Of String)

  Private friendlyID As String

  Private outstring As String = ""

  Private mOwnerType As eEntity
  Public Sub New( theid As Guid,  themetainfo As String,  ownertype As eEntity)
    mOwnerType = ownertype
    mID = theid
    friendlyID = Helpers.GetFriendlyGuid(theid)

    mMetainfo.Add(friendlyID & ": " & themetainfo)
    CalcOutString()

  End Sub

  Public ReadOnly Property OwnerType As eEntity
    Get
      Return mOwnerType
    End Get
  End Property

  Public ReadOnly Property FriendlyGuid As String
    Get
      Return Helpers.GetFriendlyGuid(mID)
    End Get
  End Property

  Public ReadOnly Property MetaInfo As List(Of String)
    Get
      Return mMetainfo
    End Get
  End Property
  Public ReadOnly Property GuidID As Guid
    Get
      Return mID
    End Get
  End Property

  Private Sub CalcOutString()
    If Not mMetainfo.Count < 1 Then
      outstring = mMetainfo.Item(mMetainfo.Count - 1) & " MyID: " & Helpers.GetFriendlyGuid(mID)
    Else
      outstring = "No Metadata" & " MyID: " & Helpers.GetFriendlyGuid(mID)
    End If
  End Sub
  Public Sub AppendMetaData( thedata As String)
    mMetainfo.Add(thedata)
    CalcOutString()
  End Sub

  Public Function MetaContainsString(thestr As String) As Boolean
    If MetaInfo Is Nothing Then
      Dim x = 2
    End If
    For i As Integer = 0 To MetaInfo.Count - 1
      If MetaInfo.Item(i).Contains(thestr) Then Return True
    Next
    Return False
  End Function
  Public Overrides Function ToString() As String
    Return outstring
  End Function
End Class

