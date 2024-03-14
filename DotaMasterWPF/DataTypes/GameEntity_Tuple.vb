Public Class GameEntity_Tuple
  Implements iGameEntity

  Private mID As dvID
  Private mGame As dGame
  Public ItemOne As iGameEntity
  Public ItemTwo As iGameEntity
  Public Sub New(item1 As iGameEntity, item2 As iGameEntity, game As dGame)
    ItemOne = item1
    ItemTwo = item2

    Me.mID = New dvID(Guid.NewGuid, "GameEntity_Tuple.New", eEntity.GameEntity_Tuple)
  End Sub

  Public Sub calcmods() Implements iGameEntity.calcmods

  End Sub

  Public Property DisplayName As String Implements iGameEntity.DisplayName
    Get
      Return ItemOne.DisplayName & " vs " & ItemTwo.DisplayName
    End Get
    Set(value As String)

    End Set
  End Property

  Public Property EntityName As eEntity Implements iGameEntity.EntityName

  Public Property Id As dvID Implements iGameEntity.Id
    Get
      Return Me.mID
    End Get
    Set(value As dvID)

    End Set
  End Property

  Public Property MyType As eSourceType Implements iGameEntity.MyType
    Get
      Return eSourceType.GameEntity_Tuple
    End Get
    Set(value As eSourceType)

    End Set
  End Property

  Public Property ParentGameEntity As iGameEntity Implements iGameEntity.ParentGameEntity
    Get
      Return mGame
    End Get
    Set(value As iGameEntity)

    End Set
  End Property

  Public Property ParentGameEntityType As eSourceType Implements iGameEntity.ParentGameEntityType
    Get
      Return eSourceType.Game
    End Get
    Set(value As eSourceType)

    End Set
  End Property

  Public Property MyColor As Color Implements iGameEntity.MyColor
    Get
      Return PageHandler.dbColors.NeutralTeamColor
    End Get
    Set(value As Color)

    End Set
  End Property
End Class
