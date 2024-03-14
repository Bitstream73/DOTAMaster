Public Interface iPetUnit_Stack
  Inherits iUnit_Stack

  Function GetPetByIndex(index As Integer) As iPetUnit

  Function GetPetByName(name As ePetName) As iPetUnit

  Property Pets As List(Of iPetUnit)

  Function ContainsPet(thename As ePetName) As Boolean
End Interface
