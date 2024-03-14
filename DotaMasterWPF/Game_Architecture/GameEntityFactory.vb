Public Class GameEntityFactory

  Public Function ConvertToGameEntities(Of T)(theitems As List(Of T)) As List(Of iGameEntity)
    Dim outlist As New List(Of iGameEntity)
    For i = 0 To theitems.Count - 1
      outlist.Add(theitems.Item(i))

    Next

    Return outlist
  End Function
End Class
