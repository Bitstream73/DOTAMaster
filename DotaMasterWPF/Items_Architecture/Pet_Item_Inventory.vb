﻿Public Class Pet_Item_Inventory
  Implements iItem_Inventory


  Private mParent As iDisplayUnit
  Public mItemBuildSequence As Item_List 'list of items actually selected by the build author

  Private mGame As dGame
  Public Sub New(parent As iDisplayUnit, _
                 itemlist As Item_List, _
                 game As dGame)

    mItemBuildSequence = itemlist
    mGame = game
  End Sub


  Public Sub UpdateAllItemsTargets(enemytarget As iDisplayUnit, friendtarget As iDisplayUnit, bias As Boolean) Implements iItem_Inventory.UpdateAllItemsTargets
    mItemBuildSequence.UpdateTargets(enemytarget, friendtarget, bias)
  End Sub

#Region "Info"
  Public Function GetAghsLifetime() As Lifetime Implements iItem_Inventory.GetAghsLifetime
    If mItemBuildSequence.ContainsName(eItemname.itmAGHANIMS_SCEPTER) Then
      Return mItemBuildSequence.GetItemByName(eItemname.itmAGHANIMS_SCEPTER).Lifetime
    End If

    Return Nothing
  End Function

  Public Function GetItemsAtTime(thetime As ddFrame) As Item_List Implements iItem_Inventory.GetItemsAtTime
    Dim outlist As New Item_List
    For i As Integer = 0 To mItemBuildSequence.Count - 1
      Dim theitem = mItemBuildSequence.Item(i)

      If theitem.ExistsAtTime(thetime) Then outlist.AddItem(theitem)
    Next

    Return outlist
  End Function

  Public Function HasAghs() As Boolean Implements iItem_Inventory.HasAghs
    If mItemBuildSequence.ContainsName(eItemname.itmAGHANIMS_SCEPTER) Then Return True
    Return False
  End Function

  Public Function HasAghsAtTime(thetime As ddFrame) As Boolean Implements iItem_Inventory.HasAghsAtTime
    If HasAghs() Then
      Dim aghs = mItemBuildSequence.GetItemByName(eItemname.itmAGHANIMS_SCEPTER)

      If aghs IsNot Nothing Then
        If aghs.Lifetime.LifeTimeContainsTime(thetime) Then Return True
      End If
    End If
    Return False
  End Function

  Public Function GetItemBuildAndAutoGeneratedItems() As Item_List Implements iItem_Inventory.GetItemBuildAndAutoGeneratedItems
    Return mItemBuildSequence
  End Function

  Public Function GetItemBuildAndAutoGeneratedItemsAsGameEntities() As List(Of iGameEntity) Implements iItem_Inventory.GetItemBuildAndAutoGeneratedItemsAsGameEntities
    Dim outlist As New List(Of iGameEntity)

    For i = 0 To mItemBuildSequence.Count - 1
      outlist.Add(mItemBuildSequence.Item(i))

    Next
    Return outlist

  End Function
#End Region

#Region "CRUD"
  Public Sub DeleteItemAtIndex(index As Integer) Implements iItem_Inventory.DeleteItemAtIndex
    mItemBuildSequence.RemoveAt(index)
  End Sub

  Public Sub DeleteItemByID(id As dvID) Implements iItem_Inventory.DeleteItemByID
    For i = 0 To mItemBuildSequence.Count
      Dim currentitem = mItemBuildSequence.Item(i)
      If currentitem.Id.GuidID = id.GuidID Then
        mItemBuildSequence.Remove(currentitem)
        RefreshItemIndexes()
      End If
    Next
  End Sub

  Public Sub InsertItemAtIndex(index As Integer, item As Item_Info) Implements iItem_Inventory.InsertItemAtIndex
    If index < mItemBuildSequence.Count Then

      mItemBuildSequence.Insert(index, item)
    Else

      mItemBuildSequence.Add(item)
    End If

    RefreshItemIndexes()


  End Sub



  Public Sub ReplaceItemAtIndex(item As Item_Info, index As Integer) Implements iItem_Inventory.ReplaceItemAtIndex

    DeleteItemAtIndex(index)
    If index >= mItemBuildSequence.Count Then
      mItemBuildSequence.Add(item)

    Else
      mItemBuildSequence.Insert(index, item)
    End If

    RefreshItemIndexes()

  End Sub
#End Region

#Region "Private Helpers"
  Private Sub RefreshItemIndexes()
    For i As Integer = 0 To mItemBuildSequence.Count - 1
      mItemBuildSequence.Item(i).Index = i
    Next
  End Sub
#End Region





End Class
