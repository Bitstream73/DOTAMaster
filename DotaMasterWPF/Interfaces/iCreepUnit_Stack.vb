Public Interface iCreepUnit_Stack
  Inherits iUnit_Stack

  Function GetCreepByIndex(theindex As Integer) As iCreepUnit

  Function GetCreepByName(thename As eCreepName) As iCreepUnit

  Property Creeps As List(Of iCreepUnit)

  Function ContainsCreep(thename As eCreepName) As Boolean
End Interface
