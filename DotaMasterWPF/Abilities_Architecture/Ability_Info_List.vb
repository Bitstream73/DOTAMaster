Public Class Ability_Info_List
  Inherits List(Of Ability_Info)



  Public Function GetListItems() As List(Of Ability_Info) ' ctrlAbility_List_item)
    Dim outlist As New List(Of Ability_Info)
    outlist.AddRange(Me) ' ctrlAbility_List_Item)
    'For i As Integer = 0 To Me.Count - 1
    '  ' Dim newcombo As New ComboBoxItem
    '  '     Dim newctrl As New ctrlAbility_List_Item(Me.Item(i), PageHandler.dbNames.GetFriendlyAbilityName(Me.Item(i).mName))
    '  'newcombo.Content = newctrl
    '  outlist.Add(newctrl)
    'Next

    Return outlist
  End Function

  Public Sub updateTargets(theenemytarget As iDisplayUnit, thefriendlytarget As iDisplayUnit, isfriendlybias As Boolean)
    For i As Integer = 0 To Me.Count - 1
      Me.Item(i).SetTargets(theenemytarget, thefriendlytarget, isfriendlybias)
    Next
  End Sub

  Public Overrides Function Equals(obj As Object) As Boolean

    Dim otherlist = TryCast(obj, Ability_Info_List)

    If otherlist Is Nothing Then Return False

    If otherlist.Count <> Me.Count Then Return False

    For i As Integer = 0 To Me.Count - 1
      If Me.Item(i).AbilityName <> otherlist.Item(i).AbilityName Then Return False

    Next
    Return True
  End Function
End Class
