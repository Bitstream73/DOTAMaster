Public Interface iGameEntity
  Property Id As dvID

  Property DisplayName As String
  Property EntityName As eEntity

  Property MyType As eSourceType
  Property ParentGameEntityType As eSourceType
  Property ParentGameEntity As iGameEntity

  Property MyColor As Color

  Sub calcmods()

End Interface
