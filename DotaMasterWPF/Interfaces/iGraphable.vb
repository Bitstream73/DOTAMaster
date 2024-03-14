Public Interface iGraphable

  Event GraphableSelected(sender As iGraphable)

  Property GraphDataItems As List(Of List(Of iDataItem))

  Property GraphPreferences As Graph_Preferences

  Sub SetGraphed(isgraphed As Boolean)

End Interface
