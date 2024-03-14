Public Class Pet_Instance
  Implements iPetUnit




#Region "Vars"
  Private mID As dvID
  Private mPetInfo As Pet_Info
  Public mGame As dGame
  Private mDisplayName As String
  Private mLog As Logging


  Private mParent As iHeroUnit
  Private mSource As IUnitUpgrade
  ' Private mActiveItemsByLevel As New Item_List

  Private mItemInv As Hero_Item_Inventory
  Private mAbility_Inventory As iHero_Ability_Inventory

  'Team Stuff
  Private mTeam As dTeam
  Private mTeamPosition As Integer

  'targetting
  Private mEnemyTarget As iDisplayUnit
  Private mFriendTarget As iDisplayUnit
  Private mTargetBias As Boolean
  'special cases
  Private mIsMeepo As Boolean = False
  Private mIsSpirit_Bear As Boolean = False


#End Region

  Public Sub New(pet As Pet_Info, petdisplayname As String, theparent As iHeroUnit, _
                 source As IUnitUpgrade, _
                teamposition As Integer, myteam As dTeam, thegame As dGame, _
                thelog As Logging)
    mPetInfo = pet
    mGame = thegame
    DisplayName = petdisplayname
    mTeamPosition = teamposition
    mTeam = myteam
    mLog = thelog
    mParent = theparent
    mSource = source

    mID = New dvID(Guid.NewGuid, "Pet_Instance New", eEntity.Pet_Instance)

    Me.ParentGameEntityType = theparent.MyType


    SetTargets(mTeam.EnemyTarget, mTeam.FriendlyTarget, mTeam.TargetFriendlyBias)

    Me.ImageUrl = New Uri(mPetInfo.mUnitImage)
    Me.calcmods()
  End Sub
  Public Property Armor As Stat Implements iDisplayUnit.Armor

  Public Function GetEnemyTarget() As iDisplayUnit Implements iDisplayUnit.GetEnemyTarget
    Return mEnemyTarget
  End Function

  Public Function GetFriendlyTarget() As iDisplayUnit Implements iDisplayUnit.GetFriendlyTarget
    Return mFriendTarget
  End Function

  Public Function GetLevelForTime(thetime As ddFrame) As Integer Implements iDisplayUnit.GetLevelForTime
    Return Me.Lifetime.GetLevelAtTime(thetime)
  End Function

  Public Function GetTargetFriendBias() As Boolean Implements iDisplayUnit.GetTargetFriendBias
    Return mTargetBias
  End Function

  Public Property HitPoints As Stat Implements iDisplayUnit.HitPoints
    Get
      Return mGame.dbModifiers.GetStatByParentandType(Me, eStattype.HitPoints)
    End Get
    Set(value As Stat)

    End Set
  End Property

  Public Property ImageUrl As Uri Implements iDisplayUnit.ImageUrl
    Get
      Return New Uri(mPetInfo.mUnitImage)
    End Get
    Set(value As Uri)

    End Set
  End Property

  Public Property Lifetime As Lifetime Implements iDisplayUnit.Lifetime
    Get
      Return mSource.Lifetime
    End Get
    Set(value As Lifetime)

    End Set
  End Property

  Public Property MovementSpeed As Stat Implements iDisplayUnit.MovementSpeed
    Get
      Return mGame.dbModifiers.GetStatByParentandType(Me, eStattype.MovementSpeed)
    End Get
    Set(value As Stat)

    End Set
  End Property

  Public Property MyColor As Color Implements iDisplayUnit.MyColor
    Get
      Return mSource.MyColor
    End Get
    Set(value As Color)

    End Set
  End Property



  Public Sub SetTargets(theenemytarget As iDisplayUnit, thefriendlytarget As iDisplayUnit, isfriendbias As Boolean) Implements iDisplayUnit.SetTargets
    mEnemyTarget = theenemytarget
    mFriendTarget = thefriendlytarget
    mTargetBias = isfriendbias
  End Sub

  Public Property Team As dTeam Implements iDisplayUnit.Team
    Get
      Return mParent
    End Get
    Set(value As dTeam)

    End Set
  End Property

  Public Property WebPageUrl As Uri Implements iDisplayUnit.WebPageUrl
    Get
      Return New Uri(mPetInfo.mWebpageLink)
    End Get
    Set(value As Uri)

    End Set
  End Property

  Public Sub calcmods() Implements iGameEntity.calcmods

  End Sub

  Public Property DisplayName As String Implements iGameEntity.DisplayName
    Get
      Return mDisplayName
    End Get
    Set(value As String)

    End Set
  End Property

  Public Property EntityName As eEntity Implements iGameEntity.EntityName
    Get
      Return eEntity.Pet_Instance
    End Get
    Set(value As eEntity)

    End Set
  End Property

  Public Property Id As dvID Implements iGameEntity.Id
    Get
      Return Me.mID
    End Get
    Set(value As dvID)

    End Set
  End Property

  Public Property MyType As eSourceType Implements iGameEntity.MyType
    Get
      Return eSourceType.Pet_Instance
    End Get
    Set(value As eSourceType)

    End Set
  End Property

  Public Property ParentGameEntity As iGameEntity Implements iGameEntity.ParentGameEntity
    Get
      Return mParent
    End Get
    Set(value As iGameEntity)

    End Set
  End Property

  Public Property ParentGameEntityType As eSourceType Implements iGameEntity.ParentGameEntityType
    Get
      Return eSourceType.Hero_Instance
    End Get
    Set(value As eSourceType)

    End Set
  End Property



  Public Property PetName As ePetName Implements iPetUnit.PetName
    Get
      Return mPetInfo.mName
    End Get
    Set(value As ePetName)

    End Set
  End Property

  Public Property Source As IUnitUpgrade Implements iPetUnit.Source
    Get
      Return mSource
    End Get
    Set(value As IUnitUpgrade)

    End Set
  End Property

  Public Property AghsLifetime As Lifetime Implements iPlayerUnit.AghsLifetime
    Get
      Return mParent.AghsLifetime
    End Get
    Set(value As Lifetime)

    End Set
  End Property

  Public Property BaseMagicResistance As Double Implements iPlayerUnit.BaseMagicResistance
    Get
      Return mPetInfo.mMagicResistance.Value(0)
    End Get
    Set(value As Double)

    End Set
  End Property
  Public Property BaseMovementSpeed As Double Implements iPlayerUnit.BaseMovementSpeed
    Get
      Return mPetInfo.mMoveSpeed.Value(0)
    End Get
    Set(value As Double)

    End Set
  End Property
  Public Property Bio As String Implements iPlayerUnit.Bio
    Get
      Return ""
    End Get
    Set(value As String)

    End Set
  End Property

  Public Function GetTempAbilityLifetimes(ab As Ability_Info) As Lifetime Implements iPlayerUnit.GetTempAbilityLifetimes
    Return Nothing
  End Function

  Public Property HasAghs As Boolean Implements iPlayerUnit.HasAghs
    Get
      Return mParent.HasAghs
    End Get
    Set(value As Boolean)

    End Set
  End Property

  Public Function HasAghsAtTime(time As ddFrame) As Boolean Implements iPlayerUnit.HasAghsAtTime
    Return mParent.HasAghsAtTime(time)
  End Function

  Public Property Mana As Stat Implements iPlayerUnit.Mana
    Get
      Return mGame.dbModifiers.GetStatByParentandType(Me, eStattype.Mana)
    End Get
    Set(value As Stat)

    End Set
  End Property

  Public Property TeamPosition As Integer Implements iPlayerUnit.TeamPosition
    Get
      Return mParent.TeamPosition
    End Get
    Set(value As Integer)

    End Set
  End Property

  Public Property UnitName As eUnit Implements iUnit.UnitName
    Get
      Throw New NotImplementedException
    End Get
    Set(value As eUnit)

    End Set
  End Property

  Public Property UnitType As eUnittype Implements iUnit.UnitType
    Get
      Return mPetInfo.mUnitType
    End Get
    Set(value As eUnittype)

    End Set
  End Property

  Public Function NonScepterExistsAtLevel(lvl As Integer) As Boolean Implements iPetUnit.NonScepterExistsAtLevel
    Return mPetInfo.NonScepterExistsAtLevel(lvl)
  End Function

  Public Property PetsOwned As List(Of PetStack) Implements iPetUnit.PetsOwned
    Get
      'TODO
      Return Nothing
    End Get
    Set(value As List(Of PetStack))

    End Set
  End Property

  Public Property ItemInventory As Pet_Item_Inventory Implements iPetUnit.ItemInventory
    Get
      Return New Pet_Item_Inventory(Me, New Item_List(), mGame)
    End Get
    Set(value As Pet_Item_Inventory)

    End Set
  End Property

  Public Property AbilityInventory As Hero_Ability_Inventory Implements iPetUnit.AbilityInventory
    Get
      Return mAbility_Inventory
    End Get
    Set(value As Hero_Ability_Inventory)

    End Set
  End Property
End Class
