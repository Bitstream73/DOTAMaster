Public Class Pet
  Inherits UnitBase

  Public mImage As String

  Private mTeamEnemyTarget As dvID = Nothing
  Private mTeamFriendlyTarget As dvID = Nothing
  Private mTargetFriendBias As Boolean

  Private mAbilities As Ability_Info_List
  Private mAbilityNames As List(Of eAbilityName)

  Private mBundle As PetBundle

  Public Sub New(petbundle As PetBundle)
    mBundle = petbundle
  End Sub
  'Public Sub LoadEnvironmentInfo(thegame As dGame, theability_InfoID As dvID, _
  '                                                thecaster As dvID, thecastertype As eSourceType, _
  '                                                thetarget As dvID, thetargettype As eSourceType, _
  '                                                ftarget As dvID, ftargettype As eSourceType, _
  '                                                isfriendbias As Boolean, _
  '                                                occurencetime As Lifetime, aghstime As Lifetime)




  'End Sub

  Public ReadOnly Property IDitem As dvID
    Get
      Return mBundle.mIDItem
    End Get
  End Property

  Public ReadOnly Property UnitType
    Get
      Return mBundle.mUnitType
    End Get
  End Property

  Public Overloads ReadOnly Property UnitImage As String
    Get
      Return mBundle.mUnitImage
    End Get
  End Property

  Public ReadOnly Property WebPageLink As String
    Get
      Return mBundle.mWebpageLink
    End Get
  End Property

  Public ReadOnly Property Duration As ValueWrapper
    Get
      Return mBundle.mDuration
    End Get
  End Property

  Public ReadOnly Property Level As ValueWrapper
    Get
      Return mBundle.mLevel
    End Get
  End Property

  Public ReadOnly Property Health As ValueWrapper
    Get
      Return mBundle.mHealth
    End Get
  End Property

  Public ReadOnly Property HealthIncrement As ValueWrapper
    Get
      Return mBundle.mHealthIncrement
    End Get
  End Property

  Public ReadOnly Property HealthRegen As ValueWrapper
    Get
      Return mBundle.mHealthRegen
    End Get
  End Property

  Public ReadOnly Property Mana As ValueWrapper
    Get
      Return mBundle.mMana
    End Get
  End Property

  Public ReadOnly Property ManaRegen
    Get
      Return mBundle.mManaRegen
    End Get
  End Property

  Public ReadOnly Property Damage As List(Of ValueWrapper)
    Get
      Return mBundle.mDamage
    End Get
  End Property

  Public ReadOnly Property DamageIncrement As ValueWrapper
    Get
      Return mBundle.mDamageIncrement
    End Get
  End Property

  Public ReadOnly Property MagicResistance As ValueWrapper
    Get
      Return mBundle.mMagicResistance
    End Get
  End Property

  Public ReadOnly Property Armor As ValueWrapper
    Get
      Return mBundle.mArmor
    End Get
  End Property

  Public ReadOnly Property ArmorType As eArmorType
    Get
      Return mBundle.mArmorType
    End Get
  End Property

  Public ReadOnly Property MoveSpeed As ValueWrapper
    Get
      Return mBundle.mMoveSpeed
    End Get
  End Property

  Public ReadOnly Property CollisionSize As ValueWrapper
    Get
      Return mBundle.mCOllisionSize
    End Get
  End Property

  Public Overloads ReadOnly Property SightRange As List(Of ValueWrapper)
    Get
      Return mBundle.mSightrange
    End Get
  End Property

  Public ReadOnly Property AttackType As eAttackType
    Get
      Return mBundle.mAttackType
    End Get
  End Property

  Public ReadOnly Property AttackSubType As eAttackSubType
    Get
      Return mBundle.mAttackSubType
    End Get
  End Property

  Public Overloads ReadOnly Property AttackRange As ValueWrapper
    Get
      Return mBundle.mAttackRange
    End Get
  End Property

  Public ReadOnly Property AttackDuration As List(Of ValueWrapper)
    Get
      Return mBundle.mAttackDuration
    End Get
  End Property

  Public ReadOnly Property CastDuration As List(Of ValueWrapper)
    Get
      Return mBundle.mCastDuration
    End Get
  End Property

  Public Overloads ReadOnly Property MissileSpeed As ValueWrapper
    Get
      Return mBundle.mMissileSpeed
    End Get
  End Property

  Public Overloads ReadOnly Property BaseAttackTime As ValueWrapper
    Get
      Return mBundle.mBaseAttacktime
    End Get
  End Property

  Public ReadOnly Property Bounty
    Get
      Return mBundle.mBounty
    End Get
  End Property

  Public ReadOnly Property XP As ValueWrapper
    Get
      Return mBundle.mXp
    End Get
  End Property

  Public ReadOnly Property AbilityNames As List(Of eAbilityName)
    Get
      Return mBundle.mAbilityNames
    End Get
  End Property


  Public ReadOnly Property Name As ePetName
    Get
      Return mBundle.mName
    End Get
  End Property
  Public ReadOnly Property EnemyTarget As dvID
    Get
      Return mTeamEnemyTarget
    End Get
  End Property

  Public ReadOnly Property FriendlyTarget As dvID
    Get
      Return mTeamFriendlyTarget
    End Get
  End Property

  Public Overrides ReadOnly Property BaseSpellResistance As Double
    Get
      Throw New NotImplementedException
    End Get
  End Property
End Class
