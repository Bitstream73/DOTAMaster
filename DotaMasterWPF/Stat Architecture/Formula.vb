Public Class Formula
  Inherits List(Of FormulaElement)
  Implements iformula

  Private mParents As List(Of eStatSource)
  Private mSources As List(Of eStatSource)
  Private mTargets As List(Of eStatSource)

  Private mModtypes As List(Of eModifierType)
  Private mStatTypes As List(Of eStattype)
  Public Sub New(parents As List(Of eStatSource), sources As List(Of eStatSource), targets As List(Of eStatSource))
 
    mParents = parents
    mSources = sources
    mTargets = targets
  End Sub

  Public Overrides Function ToString() As String
    Dim outstring = ""
    For i As Integer = 0 To Me.Count - 1
      Dim curEl = Me.Item(i)
      outstring += curEl.ToString & "|"
    Next
    Return outstring
  End Function
  Private Sub CalcModTypes()
    mModtypes = New List(Of eModifierType)
    For i = 0 To Me.Count - 1
      Dim curtype = Me.Item(i).ModType
      If Not mModtypes.Contains(curtype) AndAlso Not curtype = eModifierType.None Then
        mModtypes.Add(Me.Item(i).ModType)
      End If
    Next

  End Sub

  Private Sub CalcStatTypes()
    mStatTypes = New List(Of eStattype)
    For i = 0 To Me.Count - 1
      Dim curtype = Me.Item(i).StatType
      If Not mStatTypes.Contains(curtype) AndAlso Not curtype = eStattype.None Then
        mStatTypes.Add(Me.Item(i).StatType)
      End If
    Next
  End Sub

  Public Function GetModTypes() As List(Of eModifierType)
    If mModtypes Is Nothing Then
      CalcModTypes()
    End If
    Return mModtypes
  End Function

  Public Function GetStatTypes() As List(Of eStattype)
    If mStatTypes Is Nothing Then
      CalcStatTypes()
    End If
    Return mStatTypes
  End Function

  Public ReadOnly Property Parents As List(Of eStatSource) Implements iformula.Parents
    Get
      Return mParents
    End Get
  End Property

  Public ReadOnly Property Sources As List(Of eStatSource) Implements iformula.Sources
    Get
      Return mSources
    End Get
  End Property

  Public ReadOnly Property Targets As List(Of eStatSource) Implements iformula.Targets
    Get
      Return mTargets
    End Get
  End Property
End Class
