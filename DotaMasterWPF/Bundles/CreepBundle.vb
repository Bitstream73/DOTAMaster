Public Class CreepBundle
  'FROM UNITBASE
  Public mIDItem As dvID

  Public mName As eCreepName
  Public mUnitType As eUnittype 'describes what type of unit this is. Required to set base attack modifiers 
  Public mUnitImage As String
  Public mWebpageLink As String


  Public mDuration As ValueWrapper '- 1 for permanent
  Public mLevel As ValueWrapper

  Public mHealth As ValueWrapper
  Public mHealthIncrement As ValueWrapper
  Public mHealthRegen As ValueWrapper

  Public mMana As ValueWrapper
  Public mManaRegen As ValueWrapper

  Public mDamage As New List(Of ValueWrapper) 'id0 low range, id1 highrange
  Public mDamageIncrement As ValueWrapper

  Public mMagicResistance As ValueWrapper

  Public mArmor As ValueWrapper
  Public mArmorType As eArmorType

  Public mMoveSpeed As ValueWrapper
  Public mCOllisionSize As ValueWrapper
  Public mSightrange As New List(Of ValueWrapper)


  Public mAttackType As eAttackType
  Public mAttackSubType As eAttackSubType
  Public mAttackRange As ValueWrapper
  Public mAttackDuration As New List(Of ValueWrapper) 'id0 attack point, id1 backswing

  Public mCastDuration As List(Of ValueWrapper)

  Public mMissileSpeed As ValueWrapper '-1 for instant
  Public mBaseAttacktime As ValueWrapper

  Public mBounty As New List(Of ValueWrapper) 'id0 low range, id1 high range
  Public mXp As ValueWrapper


  Public mAbilityNames As New List(Of eAbilityName)



End Class
