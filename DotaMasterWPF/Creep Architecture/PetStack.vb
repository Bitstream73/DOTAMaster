Public Class PetStack
  Implements iPetUnit_Stack


  Private mID As dvID
  Private mPets As New List(Of iPetUnit)


  Private mPetVisibility As New List(Of List(Of Boolean))

  Private mSource As IUnitUpgrade

  Private mOwner As iDisplayUnit

  Private mTimekeeper As TimeKeeper

  Public Sub New(pets As List(Of Pet_Info), parent As iDisplayUnit, source As IUnitUpgrade, theaghslife As Lifetime, _
                  teamposition As Integer, team As dTeam, thegame As dGame, thelog As Logging)
    If pets Is Nothing Then Exit Sub

    Me.mID = New dvID(Guid.NewGuid, "CreepStack/New", eEntity.Creep_Stack)
    For i As Integer = 0 To pets.Count - 1
      Dim curpet = pets.Item(i)
      mPets.Add(New Pet_Instance(pets.Item(i), _
                                     thegame.dbNames.GetFriendlyPetName(curpet.mName), _
                                     parent, source, _
                                     teamposition, _
                                     team, _
                                     thegame, thelog))


    Next

    mSource = source

    mTimekeeper = thegame.TimeKeeper


    mOwner = parent

    CalcPetVisibility()

  End Sub

  Public Sub calcmods() Implements iGameEntity.calcmods

  End Sub

  Public Sub SetTargets(enemytarget As iDisplayUnit, friendtarget As iDisplayUnit, bias As Boolean) Implements iUnit_Stack.SetTargets
    For i As Integer = 0 To mPets.Count - 1
      mPets.Item(i).SetTargets(enemytarget, friendtarget, bias)
    Next
  End Sub
  Private Sub CalcPetVisibility()

    If mPets.Count < 1 Then Exit Sub


    mPetVisibility.Clear()
    Dim starti As Integer
    Dim endi As Integer

    'add falses for times before creeps exist
    Dim falselist As New List(Of Boolean)
    For i As Integer = 0 To mPets.Count - 1
      falselist.Add(False)
    Next

    'Set start time for creep lifetime

    Dim falsestart As ddFrame = mTimekeeper.GameStart '.count - 1
    Dim falseend As ddFrame = mSource.Lifetime.StartTimes.Item(0)
    Dim thetimes = mTimekeeper.TimePoints

    If Not falsestart.count >= falseend.count Then
      starti = thetimes.GetIndexForFrame(falsestart)
      endi = thetimes.GetIndexForFrame(falseend)
      For i As Integer = starti To endi
        mPetVisibility.Add(falselist)
      Next
    End If



    'calc visible while item/ability/creep is active
    Dim creepstart = mSource.Lifetime.StartTimes.Item(0)
    Dim creepend = mSource.Lifetime.EndTime
    Dim creeplifetime = mSource.Lifetime

    starti = thetimes.GetIndexForFrame(creepstart)
    endi = thetimes.GetIndexForFrame(creepend)
    For i As Integer = starti To endi 'creepstart To creepend Step Constants.cFramerate.count

      Dim curlevel = creeplifetime.GetLevelAtTime(thetimes.Item(i))
      Dim outvis As New List(Of Boolean)

      For x As Integer = 0 To mPets.Count - 1

        If mPets.Item(x).NonScepterExistsAtLevel(curlevel) Then
          outvis.Add(True)

        Else
          If mPets.Item(x).NonScepterExistsAtLevel(curlevel) = True Then
            outvis.Add(True)

          Else

            outvis.Add(False)
          End If

        End If
      Next

      mPetVisibility.Add(outvis)
    Next



    'add falses for times aftercreeps

    starti = thetimes.GetIndexForFrame(creepend) + 1
    endi = thetimes.GetIndexForFrame(mTimekeeper.GameEnd) + 1
    If Not starti >= endi Then
      For i As Integer = starti To endi
        mPetVisibility.Add(falselist)
      Next
    End If

  End Sub

  Public Function ContainsPet(name As ePetName) As Boolean Implements iPetUnit_Stack.ContainsPet

    For i As Integer = 0 To mPets.Count - 1
      If mPets.Item(i).PetName = name Then Return True
    Next
    Return False
  End Function


#Region "Info"
  Public ReadOnly Property SwatchColor As Color
    Get
      Return mOwner.MyColor
    End Get
  End Property
  'Public ReadOnly Property Count As Integer
  '  Get
  '    Return mCreeps.Count
  '  End Get
  'End Property
  Public Property Pets As List(Of iPetUnit) Implements iPetUnit_Stack.Pets
    Get
      Return mPets
    End Get
    Set(value As List(Of iPetUnit))

    End Set
  End Property

  Public Property DisplayName As String Implements iGameEntity.DisplayName
    Get
      Return "CreepStack"
    End Get
    Set(value As String)

    End Set
  End Property

  Public Property EntityName As eEntity Implements iGameEntity.EntityName
    Get
      Return eEntity.Creep_Stack
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
      Return eSourceType.Creep_Stack
    End Get
    Set(value As eSourceType)

    End Set
  End Property

  Public Property ParentGameEntity As iGameEntity Implements iGameEntity.ParentGameEntity
    Get
      Return mOwner
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

  Public Property UnitCount As Integer Implements iUnit_Stack.UnitCount
    Get
      Return mPets.Count
    End Get
    Set(value As Integer)

    End Set
  End Property


  Public Property MyColor As Color Implements iGameEntity.MyColor
    Get
      Return PageHandler.dbColors.PetColor
    End Get
    Set(value As Color)

    End Set
  End Property
#End Region

#Region "Gets"
  Public Function GetVisibleUnitsAtTime(thetime As ddFrame) As List(Of Boolean) Implements iPetUnit_Stack.GetVisibleUnitsAtTime

    Dim outlist As New List(Of Boolean)
    For i As Integer = 0 To mPets.Count - 1
      If mPets.Item(i).Lifetime.LifeTimeContainsTime(thetime) Then
        outlist.Add(True)
      Else
        outlist.Add(False)
      End If
    Next
    Return outlist

  End Function

  Public Function GetPetByIndex(index As Integer) As iPetUnit Implements iPetUnit_Stack.GetPetByIndex
    Return mPets.Item(index)
  End Function
  Public Function GetPetByName(name As ePetName) As iPetUnit Implements iPetUnit_Stack.GetPetByName
    If ContainsPet(name) Then

      For i As Integer = 0 To mPets.Count - 1
        If mPets.Item(i).PetName = name Then Return mPets.Item(i)
      Next
      Return Nothing

    Else
      Return Nothing
    End If
  End Function

  Public Function GetVisibleAtTime(thetime As ddFrame) As List(Of Boolean)
    Dim theindex = mTimekeeper.TimePoints.GetIndexForFrame(thetime)
    Return mPetVisibility.Item(theindex)
  End Function

#End Region





 




 
End Class
