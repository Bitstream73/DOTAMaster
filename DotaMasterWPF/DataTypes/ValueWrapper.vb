Public Class ValueWrapper
  Private mValue As Double?
  Private mValues As List(Of Double?)

  Private mSceptValue As Double?
  Private mSceptValues As List(Of Double?)

  Private mDescription As String

#Region "New's"
  ''' <summary>
  ''' maximum of 4 items for thevals
  ''' </summary>
  ''' <param name="thevals"></param>
  ''' <remarks></remarks>
  Public Sub New(thevals As List(Of Double?))
    mValues = thevals

  End Sub


  Public Sub New(theval As Double?)
    mValue = theval
  End Sub

  Public Sub New(theval1 As Double?, theval2 As Double?)
    mValues = New List(Of Double?)
    mValues.Add(theval1)
    mValues.Add(theval2)
  End Sub

  Public Sub New(theval1 As Double?, theval2 As Double?, theval3 As Double?)
    mValues = New List(Of Double?)
    mValues.Add(theval1)
    mValues.Add(theval2)
    mValues.Add(theval3)
  End Sub

  Public Sub New(theval1 As Double?, theval2 As Double?, theval3 As Double?, theval4 As Double?)
    mValues = New List(Of Double?)
    mValues.Add(theval1)
    mValues.Add(theval2)
    mValues.Add(theval3)
    mValues.Add(theval4)
  End Sub

  Public Sub New(theval1 As Double?, theval2 As Double?, theval3 As Double?, theval4 As Double?, _
                  theval5 As Double?, theval6 As Double?, theval7 As Double?)
    mValues = New List(Of Double?)
    mValues.Add(theval1)
    mValues.Add(theval2)
    mValues.Add(theval3)
    mValues.Add(theval4)
    mValues.Add(theval5)
    mValues.Add(theval6)
    mValues.Add(theval7)
  End Sub

  'statgain
  Public Sub New(theval1 As Double?, theval2 As Double?, theval3 As Double?, theval4 As Double?, _
                theval5 As Double?, theval6 As Double?, theval7 As Double?, theval8 As Double?, _
                theval9 As Double?, theval10 As Double?)
    mValues = New List(Of Double?)
    mValues.Add(theval1)
    mValues.Add(theval2)
    mValues.Add(theval3)
    mValues.Add(theval4)
    mValues.Add(theval5)
    mValues.Add(theval6)
    mValues.Add(theval7)
    mValues.Add(theval8)
    mValues.Add(theval9)
    mValues.Add(theval10)
  End Sub

  'Vals associated with Hero Level
  Public Sub New(theval1 As Double?, theval2 As Double?, theval3 As Double?, theval4 As Double?, _
              theval5 As Double?, theval6 As Double?, theval7 As Double?, theval8 As Double?, _
              theval9 As Double?, theval10 As Double?, theval11 As Double?, theval12 As Double?, _
               theval13 As Double?, theval14 As Double?, theval15 As Double?, theval16 As Double?, _
               theval17 As Double?, theval18 As Double?, theval19 As Double?, theval20 As Double?, _
               theval21 As Double?, theval22 As Double?, theval23 As Double?, theval24 As Double?, _
               theval25 As Double?)
    mValues = New List(Of Double?)
    mValues.Add(theval1)
    mValues.Add(theval2)
    mValues.Add(theval3)
    mValues.Add(theval4)
    mValues.Add(theval5)
    mValues.Add(theval6)
    mValues.Add(theval7)
    mValues.Add(theval8)
    mValues.Add(theval9)
    mValues.Add(theval10)
    mValues.Add(theval11)
    mValues.Add(theval12)
    mValues.Add(theval13)
    mValues.Add(theval14)
    mValues.Add(theval15)
    mValues.Add(theval16)
    mValues.Add(theval17)
    mValues.Add(theval18)
    mValues.Add(theval19)
    mValues.Add(theval20)
    mValues.Add(theval21)
    mValues.Add(theval22)
    mValues.Add(theval23)
    mValues.Add(theval24)
    mValues.Add(theval25)
  End Sub


#End Region

  ''' <summary>
  ''' maximum of 4 items for thevals
  ''' </summary>
  ''' <param name="thevals"></param>
  ''' <remarks></remarks>
  Public Sub LoadScepterValues(thevals As List(Of Double?))
    mSceptValues = thevals
  End Sub
  Public Sub LoadScepterValues(thesval1 As Double?)
    mSceptValue = thesval1
  End Sub

  Public ReadOnly Property Count As Integer
    Get
      If mValue.HasValue Then Return 1
      Return mValues.Count
    End Get
  End Property
  Public Sub LoadScepterValues( thesval1 As Double?,  thesval2 As Double?)
    mSceptValues = New List(Of Double?)
    mSceptValues.Add(thesval1)
    mSceptValues.Add(thesval2)
  End Sub

  Public Sub LoadScepterValues( thesval1 As Double?,  thesval2 As Double?, thesval3 As Double?)
    mSceptValues = New List(Of Double?)
    mSceptValues.Add(thesval1)
    mSceptValues.Add(thesval2)
    mSceptValues.Add(thesval3)
  End Sub

  Public Sub LoadScepterValues( thesval1 As Double?,  thesval2 As Double?, thesval3 As Double?,  thesval4 As Double?)
    mSceptValues = New List(Of Double?)
    mSceptValues.Add(thesval1)
    mSceptValues.Add(thesval2)
    mSceptValues.Add(thesval3)
    mSceptValues.Add(thesval4)
  End Sub

  Public Property Description As String
    Get
      Return mDescription
    End Get
    Set(value As String)
      mDescription = value
    End Set
  End Property


  Public Function Value(theindex As Integer, hasaghs As Boolean) As Double?
    If theindex < 0 Then Return Nothing

    If hasaghs Then
      If Not mSceptValues Is Nothing Then
        If mSceptValues.Count >= theindex Then Return mSceptValues.Item(theindex)
      End If
    End If


    Dim outvalue = Value(theindex)
    If outvalue Is Nothing Then
      Dim x = 2
    End If

    Return outvalue
  End Function

  Public Function Value( theindex As Integer) As Double?
    If theindex < 0 Then Return Nothing

    If mValue.HasValue Then Return mValue

    If Not theindex >= mValues.Count Then
      Return mValues.Item(theindex)
    Else
      Dim x = 2
    End If

  End Function

  Public Function ScepterValue(valuelevel As Integer) As Double?
    If mSceptValue.HasValue Then Return mSceptValue

    If Not mSceptValues Is Nothing Then Return mSceptValues.Item(valuelevel - 1)

    Return Nothing
  End Function

  Public Overrides Function ToString() As String
    If mValue.HasValue Then
      Return mValue.ToString
    Else
      If mValues.Count = 1 Then
        Return mValues.IndexOf(0).ToString
      End If

      Dim issamenum As Boolean = True
      Dim curnum As Double = mValues.Item(0)
      For i As Integer = 1 To mValues.Count - 1
        If Not curnum = mValues.Item(i) Then
          issamenum = False
          Exit For
        End If
      Next

      If issamenum Then
        Return mValues.Item(0).ToString
      Else
        Dim outstring As String = ""
        For i As Integer = 0 To mValues.Count
          outstring += mValues.Item(i).ToString & "/"
        Next

        outstring = outstring.Substring(0, outstring.Length - 1)
        Return outstring
      End If


    End If
  End Function

  Public ReadOnly Property MaxValue As Double?
    Get
      If Not mValues Is Nothing Then
        If mSceptValues.Max > mValues.Max Then Return mSceptValues.Max
        Return mValues.Max
      Else
        If mSceptValue > mValue Then Return mSceptValue
        Return mValue
      End If
    End Get
  End Property
End Class
