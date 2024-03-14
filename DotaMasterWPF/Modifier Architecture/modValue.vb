Public Class modValue
  Private mValue As Double

  Private mValueList As ValueList

  ' Private mAbilityValueList As AbilityValueList

  Private mValWrapper As ValueWrapper

  ''' <summary>
  ''' values in seconds
  ''' </summary>
  ''' <remarks></remarks>
  Public mValueDuration As ValueWrapper

  Public mCooldown As ValueWrapper

  ''' <summary>
  ''' values in seconds
  ''' </summary>
  ''' <remarks></remarks>
  Public mValueInterval As ValueWrapper 'for dps, HoT, DoT

  Public mModType As eModifierType


  Public mPercentChance As ValueWrapper 'ie pierce chance percentage of whether additional damage will be added

  Private mCharges As ValueWrapper

  Private mActiveDuration As ValueWrapper

  Public mThreshold As ValueWrapper
  Public mValueMax As ValueWrapper 'for items that have a max value like QuillSpray max damage
  Public mValueMin As ValueWrapper 'used along with mValueMax for ChaosKnightspells
  Public mRange As ValueWrapper
  Public mRadius As ValueWrapper
  Public mAreaOfAffected As ValueWrapper
  Private modValueType As eModifierValueType

  Private mLifetime As Lifetime
  Private mAghsLifetime As Lifetime

  'vars for heroaltform and pets
  'Public mPet As HeroPet_Info

  Public mStateIndex As Integer 'the index of the objects state associated with this mod. Most times it will be 0. but for things like power treads or invoke it will be other


  Public Sub New( values As ValueWrapper, _
                  modtype As eModifierType, _
                  thelifetime As Lifetime, _
                  theaghslifetime As Lifetime)
    modValueType = eModifierValueType.ValueWrapper
    mValWrapper = values
    mLifetime = thelifetime
    mModType = modtype
    mCharges = New ValueWrapper(1)

  End Sub

  Public Sub New( values As ValueWrapper, _
                modtype As eModifierType, _
                valueinterval As ValueWrapper, _
                thelifetime As Lifetime, _
                 theaghslifetime As Lifetime)

    Me.New(values, modtype, thelifetime, theaghslifetime)
    mValueInterval = valueinterval
  End Sub




  Public Sub New( values As ValueList, _
                  modtype As eModifierType, _
                  thelifetime As Lifetime, _
                   theaghslifetime As Lifetime)
    modValueType = eModifierValueType.ValueList


    mValueList = values
    mLifetime = thelifetime
    mAghsLifetime = theaghslifetime
    mModType = modtype
    mCharges = New ValueWrapper(1)
  End Sub

  Public Sub New( value As Double, _
                  modtype As eModifierType, _
                  thelifetime As Lifetime)
    modValueType = eModifierValueType.Value
    mValue = value
    mModType = modtype
    mCharges = New ValueWrapper(1)
    mLifetime = thelifetime
    mAghsLifetime = Nothing
  End Sub

  Public Sub New( value As Double, _
                 modtype As eModifierType, _
                 thelifetime As Lifetime, _
                 thestatenum As Integer)
    modValueType = eModifierValueType.Value
    mValue = value
    mModType = modtype
    mCharges = New ValueWrapper(1)
    mLifetime = thelifetime
    mAghsLifetime = Nothing
    mStateIndex = thestatenum
  End Sub

  Public Sub New( value As Double, _
                  modtype As eModifierType, _
                  valueinterval As ValueWrapper, _
                  thelifetime As Lifetime)

    Me.New(value, modtype, thelifetime)
    modValueType = eModifierValueType.Value
    mValueInterval = valueinterval
  End Sub

  Public Sub SetAreaOfAffected( theareas As ValueWrapper)
    mAreaOfAffected = theareas
  End Sub

  Public Function GetAreaOfAffected( themodlevel As Integer) As Double
    If mAreaOfAffected Is Nothing Then Return CalcAreaOfAffected(themodlevel)

    Return mAreaOfAffected.Value(themodlevel - 1)

  End Function

  'Public Sub New( abilityvalues As List(Of Double), _
  '              modtype As eModifierType, _
  '              valueinterval As ValueWrapper, _
  '              thelifetime As Lifetime)

  '  Me.New(abilityvalues, modtype, thelifetime)
  '  modValueType = eModifierValueType.AbilityValueList
  '  mValueInterval = valueinterval
  'End Sub
  'Public Sub New( AbilityValues As List(Of Double), _
  '              modtype As eModifierType, _
  '              thelifetime As Lifetime)
  '  modValueType = eModifierValueType.AbilityValueList
  '  mAbilityValueList = New AbilityValueList(thelifetime, AbilityValues)
  '  mModType = modtype
  '  mLifetime = thelifetime
  'End Sub
  'Public Sub LoadActiveDurations( thedurations As List(Of Double))
  '  mActiveDurations = thedurations
  'End Sub

  'Public Sub LoadActiveDuration( theduration As Double)
  '  mActiveDuration = theduration
  'End Sub

  Public Function GetLevelAtTime( thetime As ddFrame) As Integer
    Return mLifetime.GetLevelAtTime(thetime)

  End Function

  'Public ReadOnly Property ActiveDurations() As List(Of Double)
  '  Get
  '    If Not mActiveDurations Is Nothing Then
  '      Return mActiveDurations
  '    End If

  '    If Not mActiveDuration = Nothing Then
  '      Dim newlist As New List(Of Double)
  '      Return newlist.Add(mActiveDuration)
  '    End If

  '    Return Nothing
  '  End Get
  'End Property

  'Public Function GetValueIntervalasTimespan( currenttime As DateTime) As TimeSpan
  '  Return New TimeSpan(0, 0, mValueInterval.Value(mLifetime.GetLevelAtTime(currenttime) - 1)
  'End Function
  Public Sub LoadCharges(charges As List(Of Double?))

    mCharges = New ValueWrapper(charges)

  End Sub

  Public Sub LoadCharge( thecharge As Integer)
    mCharges = New ValueWrapper(thecharge)
  End Sub

  Public Property Charges() As ValueWrapper
    Get
      Return mCharges
    End Get
    Set(value As ValueWrapper)
      mCharges = value
    End Set
  End Property

  Public ReadOnly Property StateNumber As Integer
    Get
      If mStateIndex = Nothing Then Return 0
      Return mStateIndex
    End Get
  End Property

  ''' <summary>
  ''' return -1 if there is no associated value for the time. 0 for duration values denotes it lasts for entire lifetime
  ''' </summary>
  ''' <param name="thetime"></param>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public ReadOnly Property Value( thetime As ddFrame) As Double?
    Get
      'Dim outvalue As Double
      Select Case modValueType
        'Case eModifierValueType.AbilityValueList
        '  Return mAbilityValueList.GetValueForTime(thetime)
        Case eModifierValueType.Value
          If mLifetime.LifeTimeContainsTime(thetime) Then
            Return mValue
          Else
            Return Nothing 'outvalue = 0
          End If

        Case eModifierValueType.ValueList


          Return mValueList.Item(thetime)

        Case eModifierValueType.ValueWrapper

          If Not mAghsLifetime Is Nothing Then
            If mAghsLifetime.LifeTimeContainsTime(thetime) Then
              Return mValWrapper.ScepterValue(mLifetime.GetLevelAtTime(thetime) - 1)
            End If
          End If

          Dim curlevel = mLifetime.GetLevelAtTime(thetime)
          If Not curlevel < 1 Then
            Return mValWrapper.Value(curlevel - 1)

          Else
            Return Nothing
          End If


        Case eModifierValueType.None
          Return Nothing
        Case Else

          Dim x = 2
          Return Nothing
      End Select


      'If outvalue = -1 Then
      '  Dim x = 2
      '  PageHandler.theLog.writelog("ModValue.Value(" & thetime.count.ToString & ") passed -1. Modtype: " & Me.mModType.ToString)
      '  outvalue = 0
      'End If


      'Return outvalue
    End Get
  End Property

  Public ReadOnly Property _LifeTime As Lifetime
    Get
      Return mLifetime
    End Get
  End Property
  Private Function CalcAreaOfAffected( modlevel As Integer)
    'If modlevel < 1 Then
    '  Dim x = 2
    'End If
    If Not mRadius Is Nothing Then
      If Not modlevel < 1 Then
        Return Helpers.GetCircleArea(mRadius.Value(modlevel - 1))
      End If

    End If

    Return 0

  End Function

  Public ReadOnly Property MaxValue As Double?
    Get
      Select Case modValueType
        Case eModifierValueType.Value
          Return mValue
        Case eModifierValueType.ValueList
          Return mValueList.MaxValue
        Case eModifierValueType.ValueWrapper
          Return mValWrapper.MaxValue
      End Select
    End Get
  End Property
End Class
