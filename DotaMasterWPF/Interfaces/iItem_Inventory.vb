﻿Public Interface iItem_Inventory

  Function GetItemsAtTime(thetime As ddFrame) As Item_List

  Function HasAghs() As Boolean

  Function HasAghsAtTime(thetime As ddFrame) As Boolean

  Function GetAghsLifetime() As Lifetime

  Sub ReplaceItemAtIndex(item As Item_Info, index As Integer)

  Sub DeleteItemAtIndex(index As Integer)

  Sub DeleteItemByID(id As dvID)

  Sub InsertItemAtIndex(index As Integer, item As Item_Info)

  Sub UpdateAllItemsTargets(enemytarget As iDisplayUnit, friendtarget As iDisplayUnit, bias As Boolean)

  Function GetItemBuildAndAutoGeneratedItems() As Item_List

  Function GetItemBuildAndAutoGeneratedItemsAsGameEntities() As List(Of iGameEntity)
End Interface