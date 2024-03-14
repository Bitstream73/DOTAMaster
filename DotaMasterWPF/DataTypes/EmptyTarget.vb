
Public Class EmptyTarget
  Implements iDisplayUnit

  Private mgame As dGame
  Public Sub New(game As dGame)
    mgame = game
  End Sub


  Public Property DisplayName As String Implements iDisplayUnit.DisplayName
    Get
      Return "No Target"
    End Get
    Set(value As String)

    End Set
  End Property






  Public Function GetEnemyTarget() As iDisplayUnit Implements iDisplayUnit.GetEnemyTarget
    Return New EmptyTarget(mgame)
  End Function

  Public Function GetFriendlyTarget() As iDisplayUnit Implements iDisplayUnit.GetFriendlyTarget
    Return New EmptyTarget(mgame)
  End Function







  Public Function GetLevelForTime(thetime As ddFrame) As Integer Implements iDisplayUnit.GetLevelForTime
    Return 0
  End Function

  Public Function GetTargetFriendBias() As Boolean Implements iDisplayUnit.GetTargetFriendBias
    Return True
  End Function



  Public Property ImageUrl As Uri Implements iDisplayUnit.ImageUrl
    Get
      Return New Uri("")
    End Get
    Set(value As Uri)

    End Set
  End Property





  Public Property MyColor As Color Implements iDisplayUnit.MyColor
    Get
      Return Color.FromArgb(255, 255, 255, 255)
    End Get
    Set(value As Color)

    End Set
  End Property






  Public Sub SetTargets(theenemytarget As iDisplayUnit, thefriendlytarget As iDisplayUnit, isfriendbias As Boolean) Implements iDisplayUnit.SetTargets

  End Sub

  Public Property Team As dTeam Implements iDisplayUnit.Team
    Get
      Return Nothing
    End Get
    Set(value As dTeam)

    End Set
  End Property

  Public Property WebPageUrl As Uri Implements iDisplayUnit.WebPageUrl
    Get
      Return New Uri("")
    End Get
    Set(value As Uri)

    End Set
  End Property

  Public Sub calcmods() Implements iGameEntity.calcmods

  End Sub

  Public Property EntityName As eEntity Implements iGameEntity.EntityName
    Get
      Return eEntity.None
    End Get
    Set(value As eEntity)

    End Set
  End Property

  Public Property Id As dvID Implements iGameEntity.Id
    Get
      Return New dvID(Guid.Empty, "Empty Target", eEntity.None)
    End Get
    Set(value As dvID)

    End Set
  End Property

  Public Property MyType As eSourceType Implements iGameEntity.MyType
    Get
      Return eSourceType.None
    End Get
    Set(value As eSourceType)

    End Set
  End Property

  Public Property ParentGameEntity As iGameEntity Implements iGameEntity.ParentGameEntity
    Get
      Return Nothing
    End Get
    Set(value As iGameEntity)

    End Set
  End Property

  Public Property ParentGameEntityType As eSourceType Implements iGameEntity.ParentGameEntityType
    Get
      Return eSourceType.None
    End Get
    Set(value As eSourceType)

    End Set
  End Property


  Public Property UnitName As eUnit Implements iUnit.UnitName
    Get
      Return eUnit.None
    End Get
    Set(value As eUnit)

    End Set
  End Property

  Public Property UnitType As eUnittype Implements iUnit.UnitType
    Get
      Return eUnittype.None
    End Get
    Set(value As eUnittype)

    End Set
  End Property


  Public Property Armor As Stat Implements iDisplayUnit.Armor
    Get
      Return New Stat(eStattype.PhysicalArmor, Me, mgame) ', "Armor")
    End Get
    Set(value As Stat)

    End Set
  End Property

  Public Property HitPoints As Stat Implements iDisplayUnit.HitPoints
    Get
      Return New Stat(eStattype.HitPoints, Me, mgame) ', "HitPoints")
    End Get
    Set(value As Stat)

    End Set
  End Property
  Public Property Lifetime As Lifetime Implements iDisplayUnit.Lifetime
    Get
      Return mgame.TimeKeeper.GameLifetime
    End Get
    Set(value As Lifetime)

    End Set
  End Property

  Public Property MovementSpeed As Stat Implements iDisplayUnit.MovementSpeed
    Get
      Return New Stat(eStattype.MovementSpeed, Me, mgame) ', "Movement Speed")
    End Get
    Set(value As Stat)

    End Set
  End Property
End Class
