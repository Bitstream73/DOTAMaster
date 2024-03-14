Public Class HeroBundle

  'FROM UNITBASE
  Public mIDItem As dvID
  Public mName As eUnit
  Public Displayname As String
  Public mUnitType As eUnittype 'describes what type of unit this is. Required to set base attack modifiers 
  Public mArmorType As eArmorType
  Public mUnitImage As String
  Public mWebpageLink As String


  Public mAttackType As eAttackType
  Public mBaseHitpoints As Double
  Private BaseAttackSpeed As ValueWrapper

  Public mBaseAttackDamage As ValueWrapper


  Public mDaySightRange As Double
  Public mNightSightRange As Double

  Public mAttackRange As Double
  Public mMissileSpeed As Double




  Public mAbilityNames As New List(Of eAbilityName)


  'FROM HEROBASE
  'Fixed, immutable stats
  Public mDevName As String

  Public mRoles As New List(Of eRole)
  Public mPrimaryStat As ePrimaryStat

  Public mBio As String

  Public mBaseStr As Double
  Public mStrIncrement As Double

  Public mBaseInt As Double
  Public mIntIncrement As Double

  Public mBaseAgi As Double
  Public mAgiIncrement As Double


  Public mBaseMoveSpeed As Double

  Public mBaseArmor As Double
  'Public mBaseArmorPositive As Double = 0
  'Public mBaseArmorNegative As Double = 0
  Public mBaseArmordebuff As Double = 0 'change for heroes with neg base armor like io and phoenix
  ''' <summary>
  '''  http://dota2.gamepedia.com/Armor
  ''' </summary>
  ''' <remarks></remarks>
  Public mBaseMagicResistance As Double

  Public Property mBaseAttackSpeed As Double
    Get
      Return BaseAttackSpeed.Value(0)
    End Get
    Set(value As Double)
      BaseAttackSpeed = New ValueWrapper(value)



    End Set
  End Property
End Class
