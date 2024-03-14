Public MustInherit Class UnitBase
  'Represents the standard props and methods
  'for Heroes, Creeps and Structures
  'Units with abilities implement IAbility
  'do define the methods for communicating with
  'an ability

#Region "fixed immutable stats"

  'Protected mName As String 'Depricated. Child classes implments with enum specific to it's type
  'Protected mUniqueName As String 'instance name of npc unit or build name of hero
  ' Protected mID As Guid
  Protected mUnitType As eUnittype 'describes what type of unit this is. Required to set base attack modifiers 
  Protected mArmorType As eArmorType
  Protected mUnitImage As String
  Protected mWebpageLink As String


  Protected mAttackType As eAttackType
  Protected mBaseHitpoints As Double
  Protected mBaseAttackSpeed As ValueWrapper

  Protected mSightRange As New List(Of ValueWrapper)
  Protected mAttackRange As ValueWrapper
  Protected mMissileSpeed As Double

  Protected mBaseAttackDamage As ValueWrapper
  'Protected mBaseAttackDamageHigh As ValueWrapper
  ''' <summary>
  ''' Represents the list of modifiers for the abilities and Auros from sources other than the unit itself
  ''' </summary>
  ''' <remarks></remarks>
  Private mIncomingModifiers As ModifierList

  ''' <summary>
  ''' Represents the modifiers that the unit itself generates (buffs, debuffs, Lifetaps, manataps)
  ''' </summary>
  ''' <remarks></remarks>
  Private mPersonalModifiers As ModifierList



  Protected mAblityNames As New List(Of String)
  'Protected mAbilitiesList As New List(Of eAbilit)

  'not sure this is even a thing, but just in case....
  Protected mbasedamage = 0
  Protected mBaseMoveSpeed As Double
#End Region
  Public Sub New()

  End Sub
  'Public Sub New( uniquename As String)
  '  mUniqueName = uniquename
  'End Sub

  'Public ReadOnly Property UniqueName As String
  '  Get
  '    Return mUniqueName
  '  End Get
  'End Property
  



  Public ReadOnly Property _UnitType() As eUnittype
    Get
      Return mUnitImage
    End Get
  End Property

  Public ReadOnly Property _eArmorType() As eArmorType
    Get
      Return mArmorType
    End Get
  End Property

  Public ReadOnly Property _AttackType As eAttackType
    Get
      Return mAttackType
    End Get
  End Property

  Public ReadOnly Property UnitImage As String
    Get
      Return mUnitImage
    End Get
  End Property

  Public ReadOnly Property BaseHitPoints As Double
    Get
      Return mBaseHitpoints
    End Get
  End Property

  Public Property BaseAttackSpeed As ValueWrapper
    Get
      Return mBaseAttackSpeed
    End Get
    Set(value As ValueWrapper)
      mBaseAttackSpeed = value
    End Set
  End Property

  Public ReadOnly Property SightRange As List(Of ValueWrapper)
    Get
      Return mSightRange
    End Get
  End Property

  Public Property AttackRange As ValueWrapper
    Get
      Return mAttackRange
    End Get
    Set(value As ValueWrapper)
      mAttackRange = value
    End Set
  End Property

  Public Property MissileSpeed As Double
    Get
      Return mMissileSpeed
    End Get
    Set(value As Double)
      mMissileSpeed = value
    End Set
  End Property

  'Public ReadOnly Property Ailities As List(Of Ability)
  '  Get
  '    Return mAbilitiesList
  '  End Get
  'End Property

#Region "Resistances"

  Public ReadOnly Property NormalDamageResistance As Double
    Get 'http://dota2.gamepedia.com/Siege_damage#Siege_Damage
      Select Case mArmorType
        Case eArmorType.Hero
          Return 0.75
        Case eArmorType.Fortified
          Return 0.7
        Case eArmorType.Heavy
          Return 1.25
        Case eArmorType.Medium
          Return 1.5
        Case eArmorType.Light
          Return 1
        Case eArmorType.Unarmored
          Return 1
        Case Else
          Dim x = 2
          Return -1
      End Select
    End Get
  End Property

  Public ReadOnly Property PierceDamageResistance As Double
    Get 'http://dota2.gamepedia.com/Siege_damage#Siege_Damage
      Select Case mArmorType
        Case eArmorType.Hero
          Return 0.5
        Case eArmorType.Fortified
          Return 0.35
        Case eArmorType.Heavy
          Return 0.75
        Case eArmorType.Medium
          Return 0.75
        Case eArmorType.Light
          Return 2
        Case eArmorType.Unarmored
          Return 1.5
        Case Else
          Dim x = 2
          Return -1
      End Select
    End Get
  End Property

  Public ReadOnly Property SiegeDamageResistance As Double
    Get 'http://dota2.gamepedia.com/Siege_damage#Siege_Damage
      Select Case mArmorType
        Case eArmorType.Hero
          Return 0.75

        Case eArmorType.Fortified
          Return 1.5
        Case eArmorType.Heavy
          Return 1.25
        Case eArmorType.Medium
          Return 0.5
        Case eArmorType.Light
          Return 1
        Case eArmorType.Unarmored
          Return 1
        Case Else
          Dim x = 2
          Return -1
      End Select
    End Get
  End Property

  Public ReadOnly Property ChaosDamageResistance As Double
    Get 'http://dota2.gamepedia.com/Siege_damage#Siege_Damage
      Select Case mArmorType
        Case eArmorType.Hero
          Return 1
        Case eArmorType.Fortified
          Return 0.4
        Case eArmorType.Heavy
          Return 1
        Case eArmorType.Medium
          Return 1
        Case eArmorType.Light
          Return 1
        Case eArmorType.Unarmored
          Return 1
        Case Else
          Dim x = 2
          Return -1
      End Select
    End Get
  End Property

  Public ReadOnly Property HeroDamageResistance As Double
    Get 'http://dota2.gamepedia.com/Siege_damage#Siege_Damage
      Select Case mArmorType
        Case eArmorType.Hero
          Return 1
        Case eArmorType.Fortified
          Return 0.5
        Case eArmorType.Heavy
          Return 1
        Case eArmorType.Medium
          Return 1
        Case eArmorType.Light
          Return 1
        Case eArmorType.Unarmored
          Return 1
        Case Else
          Dim x = 2
          Return -1
      End Select
    End Get
  End Property

  Public ReadOnly Property SpellDamageResistance As Double
    Get 'http://dota2.gamepedia.com/Siege_damage#Siege_Damage
      Select Case mArmorType
        Case eArmorType.Hero
          Return BaseSpellResistance
        Case eArmorType.Fortified
          Return 0.5
        Case eArmorType.Heavy
          Return 1
        Case eArmorType.Medium
          Return 1
        Case eArmorType.Light
          Return 1
        Case eArmorType.Unarmored
          Return 1
        Case Else
          Dim x = 2
          Return -1
      End Select
    End Get
  End Property

  MustOverride ReadOnly Property BaseSpellResistance As Double
#End Region









End Class
