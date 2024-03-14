Public Class Creep_Ability_Inventory
  Implements iCreep_Ability_Inventory

  Private mAbilitiesListedByUIPosition As Ability_Info_List
  Private mGame As dGame

  Private mCreepInstance As iCreepUnit
  Public Sub New(game As dGame, abilities As List(Of iAbility))
    mGame = game
    mAbilitiesListedByUIPosition = New Ability_Info_List()
    mAbilitiesListedByUIPosition.AddRange(abilities)
  End Sub

  Public Sub Load(creep As iCreepUnit)
    mCreepInstance = creep
    'LoadAbilitiesBuildOrderByUIPosition()
  End Sub

  'Private Sub LoadAbilitiesBuildOrderByUIPosition()

  '  mAbilitiesBuildOrderByUIPosition.Clear()
  '  For i As Integer = 0 To mAbilitiesBuildOrderByUIPosition.Count - 1

  '    Dim abilitybyuipositionchosenatcurrentlevel = mAbilitiesBuildOrderByUIPosition.Item(i)

  '    mAbilitiesBuildOrderByUIPosition.Add(abilitybyuipositionchosenatcurrentlevel)
  '  Next
  'End Sub
  Public Property AbilitiesListedByUIPosition As Ability_Info_List Implements iAbility_Inventory.AbilitiesListedByUIPosition
    Get
      Return mAbilitiesListedByUIPosition
    End Get
    Set(value As Ability_Info_List)

    End Set
  End Property

  Public Function GetAbilitiesListedByUIPositionAsGameEntities() As List(Of iGameEntity) Implements iAbility_Inventory.GetAbilitiesListedByUIPositionAsGameEntities
    Dim outlist As New List(Of iGameEntity)
    For i = 0 To mAbilitiesListedByUIPosition.Count - 1
      outlist.AddRange(mAbilitiesListedByUIPosition.Item(i))
    Next
    Return outlist

  End Function

  Public Function AbilityCanLevel(theabname As eAbilityName, herolevel As Integer) As Boolean Implements iAbility_Inventory.AbilityCanLevel
    Return False
  End Function


  Public Function AbilityLevelIsCapped(theab As Ability_Info, herolevel As Integer) As Boolean Implements iAbility_Inventory.AbilityLevelIsCapped
    Return True
  End Function

  Public Function GetAbility(abilityname As eAbilityName) As Ability_Info Implements iAbility_Inventory.GetAbility
    For i As Integer = 0 To mAbilitiesListedByUIPosition.Count - 1
      If mAbilitiesListedByUIPosition.Item(i).AbilityName = abilityname Then Return mAbilitiesListedByUIPosition.Item(i)
    Next
    Dim x = 2
    Return Nothing
  End Function

  Public Function GetAbilityById(id As dvID) As Ability_Info Implements iAbility_Inventory.GetAbilityById
    For i As Integer = 0 To mAbilitiesListedByUIPosition.Count - 1
      If mAbilitiesListedByUIPosition.Item(i).Id.GuidID = id.GuidID Then Return mAbilitiesListedByUIPosition.Item(i)
    Next
    Return Nothing
  End Function

  'Public Function GetAbilityInfos(game As dGame) As List(Of Ability_Info) Implements iAbility_Inventory.GetAbilityInfos

  'End Function

  Public Function GetPositionFromAbilityinfo(theinfo As Ability_Info) As Integer Implements iAbility_Inventory.GetPositionFromAbilityinfo
    For i As Integer = 0 To mAbilitiesListedByUIPosition.Count - 1
      If theinfo Is mAbilitiesListedByUIPosition.Item(i) Then Return i
    Next
    Return Nothing
  End Function
End Class
