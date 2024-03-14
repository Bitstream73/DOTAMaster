Public Interface iAbility_Inventory
  Function AbilityCanLevel(theabname As eAbilityName, herolevel As Integer) As Boolean

  Function AbilityLevelIsCapped(theab As Ability_Info, herolevel As Integer) As Boolean


  Property AbilitiesListedByUIPosition As Ability_Info_List

  Function GetAbilitiesListedByUIPositionAsGameEntities() As List(Of iGameEntity)

  Function GetAbility(abilityname As eAbilityName) As Ability_Info

  Function GetAbilityById(id As dvID) As Ability_Info

  'Function GetAbilityInfos(game As dGame) As List(Of Ability_Info)

  Function GetPositionFromAbilityinfo(theinfo As Ability_Info) As Integer


End Interface
