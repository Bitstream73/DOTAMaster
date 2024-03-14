﻿Public Interface iDisplayUnit
  Inherits iUnit



  Property Team As dTeam


  Property ImageUrl As Uri
  Property WebPageUrl As Uri

  Function GetLevelForTime(thetime As ddFrame) As Integer

  ' Property AbilitiesListedByUIPosition As List(Of Ability_Info)


  Sub SetTargets(theenemytarget As iDisplayUnit, _
                           thefriendlytarget As iDisplayUnit, _
                           isfriendbias As Boolean)

  Function GetEnemyTarget() As iDisplayUnit
  Function GetFriendlyTarget() As iDisplayUnit
  Function GetTargetFriendBias() As Boolean



  '  Property AbilityInventory() As iAbility_Inventory

  Property Armor As Stat

  Property HitPoints As Stat

  Property Lifetime As Lifetime

  Property MovementSpeed As Stat
  ' Function GetAbilityNames() As List(Of eAbilityName)
  'Function GetAbilityInfos(game As dGame) As List(Of Ability_Info)

  ' Function GetAbilityByPosition(position As Integer) As Ability_Info
  'Function GetAbilityById(id As dvID) As Ability_Info

  ' Function GetAbilityLevel(theab As Ability_Info, herolevel As Integer) As Integer
  ' Function GetActiveAbilitiesByLevel(herolevel As Integer) As List(Of Integer)

  'Property ItemBuildAndAutoGeneratedItems As Item_List
  'Property ItemBuildSequence As Item_List
  'Function GetItemByID(id As dvID) As Item_Info
  'Function GetItemsAtTime(time As ddFrame) As Item_List
  'Function GetItemLifetime(item As Item_Info) As Lifetime

  'Sub InsertItemAtIndex(theindex As Integer, theitem As Item_Info)
  'Sub DeleteItemAtIndex(theindex As Integer)
  'Sub ReplaceItemAtIndex(item As Item_Info, index As Integer)

 
End Interface