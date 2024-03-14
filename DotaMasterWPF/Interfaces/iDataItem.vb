Public Interface iDataItem
  Inherits iGameEntity
  Function Value(time As ddFrame) As Double?

  Function ValueWithFormatting(time As ddFrame) As String

  Property DataItemType As eDataItemType

  Property DataGenerator As iGameEntity

  Property MaxValue As Double?
End Interface
