Public Interface iManyToManyStore(Of key0, key1)


  Function ValuesForKey(key As Key0) As IEnumerable(Of Key1)
  Function ValuesForKey(key As key1) As IEnumerable(Of key0)

  Sub Add(key As key0, values As IEnumerable(Of key1))
End Interface
