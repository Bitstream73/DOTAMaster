Public Interface iCreepUnit
  Inherits iDisplayUnit
  'Creeps are not player controlled, and can not use items. They only have abilities.

  Property CreepName As eCreepName

  Property CreepsOwned As List(Of CreepStack)
  Property TeamPosition As Integer
  Function NonScepterExistsAtLevel(lvl As Integer)
End Interface
