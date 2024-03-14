Public Class DDObject
  Public obj As Object
  Public type As eEntity
  Private mDvID As dvID = Nothing
  Private dbNames As FriendlyName_Database
  Public Sub New( theobj As Object,  thetype As eEntity,  theobjid As dvID,  namesdb As FriendlyName_Database)
    Me.New(theobj, thetype)
    mDvID = theobjid
    dbNames = namesdb
  End Sub
  Public Sub New( theobj As Object,  thetype As eEntity)
    obj = theobj
    type = thetype
  End Sub
  ''' <summary>
  ''' returns nothing if no ID assigned
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public ReadOnly Property ID As dvID
    Get
      Return Helpers.GetIDFromDDObject(Me)
    End Get
  End Property

  Public Function GetFriendlyName() As String
    Select Case type
      Case eEntity.Hero_Instance
        Dim hb As HeroInstance = obj
        Return hb.DisplayName
      Case eEntity.Creep_Info
        Dim ci As Creep_Info = obj
        Return dbNames.GetFriendlyCreepName(ci.mName)
      Case eEntity.Ability_Info
        Dim ai As Ability_Info = obj
        Return dbNames.GetFriendlyAbilityName(ai.AbilityName)
      Case eEntity.Item_Info
        Dim ii As Item_Info = obj
        Return ii.DisplayName
      Case Else
        PageHandler.theLog.writelog("DDObject.GetFriendlyName Unhandled eEntity Type:" & type.ToString)
        Return "DDObject missing eEntity type"
    End Select
  End Function
End Class
