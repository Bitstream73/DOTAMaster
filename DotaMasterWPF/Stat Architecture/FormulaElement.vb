Public Class FormulaElement
  Private mModType As eModifierType
  Private mStatType As eStattype
  Private mIsModifier As Boolean
  Private mMathAction As eMathAction
  Private mStaticValue As Double?
  Private mNames As FriendlyName_Database
  Public Sub New(themodtype As eModifierType, thestattype As eStattype, _
                  themathaction As eMathAction, names As FriendlyName_Database)
    mModType = themodtype
    mStatType = thestattype
    mMathAction = themathaction
    mNames = names
    If themodtype = Nothing AndAlso Not thestattype = Nothing Then
      mIsModifier = False
    ElseIf Not themodtype = Nothing AndAlso thestattype = Nothing Then
      mIsModifier = True
    Else
      Dim x = 2
    End If



  End Sub

  Public Sub New(themodtype As eModifierType, thestattype As eStattype, _
                  themathaction As eMathAction, staticvalue As Double?, names As FriendlyName_Database)

    Me.New(themodtype, thestattype, themathaction, names)
    mStaticValue = staticvalue
  End Sub
  Public Overrides Function ToString() As String
    If mIsModifier Then
      Return mMathAction.ToString & " " & mNames.GetFriendlyModifierName(mModType)
    Else
      Return mMathAction.ToString & " " & mNames.GetFriendlyStatName(mStatType)
    End If

  End Function

  Public ReadOnly Property StaticValue As Double?
    Get
      Return mStaticValue
    End Get
  End Property

  Public ReadOnly Property ModType As eModifierType
    Get
      Return mModType
    End Get
  End Property

  Public ReadOnly Property StatType As eStattype
    Get
      Return mStatType
    End Get
  End Property

  Public ReadOnly Property IsModifier As Boolean
    Get
      Return mIsModifier
    End Get
  End Property

  Public ReadOnly Property MathAction As eMathAction
    Get
      Return mMathAction
    End Get
  End Property
End Class
