Public Class TypesAndTargets

  Private _modTargsTypes As Dictionary(Of Guid, List(Of eModifierType))
  Private _statTargsTypes As Dictionary(Of Guid, List(Of eStattype))
 

  Public Sub New(themodtargetsandtypes As Dictionary(Of Guid, List(Of eModifierType)), _
                                                      thestattargetsandtypes As Dictionary(Of Guid, List(Of eStattype)))

    _modTargsTypes = themodtargetsandtypes
    _statTargsTypes = thestattargetsandtypes

  End Sub

  Public ReadOnly Property ModTargetsnTypes As Dictionary(Of Guid, List(Of eModifierType))
    Get
      Return _modTargsTypes
    End Get
  End Property

  Public ReadOnly Property StatTargetsnTypes As Dictionary(Of Guid, List(Of eStattype))
    Get
      Return _statTargsTypes
    End Get
  End Property

  Public Function ContainsKey( thekey As Guid) As Boolean
    If _statTargsTypes.ContainsKey(thekey) Then Return True
    If _modTargsTypes.ContainsKey(thekey) Then Return True
    Return False
  End Function


End Class
