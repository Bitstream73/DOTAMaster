Public Interface iUnit_Stack
  Inherits iGameEntity
  Sub SetTargets(enemytarget As iDisplayUnit, friendtarget As iDisplayUnit, bias As Boolean)

  Function GetVisibleUnitsAtTime(thetime As ddFrame) As List(Of Boolean)

  Property UnitCount As Integer
End Interface
