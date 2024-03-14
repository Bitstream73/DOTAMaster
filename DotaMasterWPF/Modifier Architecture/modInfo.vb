Public Class modInfo
  Public AbilityType As eAbilityType
  Public Parent As iGameEntity
  Private mAffectedUnitTypes As List(Of eUnit)
  Public Notes As String
  Private mTarget As iGameEntity
  ' Public mTargetType As eSourceType
  'when does the modifier occur?
  'Public AbilityLevel As Integer
  Public CreationTime As DateTime

  Public ModGenerator As iGameEntity

  Public mCategory As eModifierCategory

  Public Sub New(abilitytype As eAbilityType, _
                 modgenerator As iGameEntity, _
                  parent As iGameEntity, _
                  target As iGameEntity, _
                  affectedunits As List(Of eUnit), _
                  notes As String, _
                  category As eModifierCategory)

    Me.Load(abilitytype, modgenerator, parent, target, affectedunits, notes, category)
  End Sub

  Public Sub New(abilitytype As eAbilityType, _
               modgenerator As iGameEntity, _
                parent As iGameEntity, _
                target As iGameEntity, _
                affectedunit As eUnit, _
                notes As String, _
                category As eModifierCategory)

    Dim units As New List(Of eUnit)
    units.Add(affectedunit)
    Me.Load(abilitytype, modgenerator, parent, target, units, notes, category)
  End Sub

  Private Sub Load(abilitytype As eAbilityType, _
                 modgenerator As iGameEntity, _
                  parent As iGameEntity, _
                  target As iGameEntity, _
                  affectedunits As List(Of eUnit), _
                  notes As String, _
                  category As eModifierCategory)
    If modgenerator Is Nothing Then
      Dim x = 2
    End If
    If target IsNot Nothing Then
      mTarget = target
    Else
      mTarget = New EmptyTarget(Nothing)
    End If
    Me.AbilityType = abilitytype
    Me.ModGenerator = modgenerator
    Me.Parent = parent

    mAffectedUnitTypes = affectedunits
    Notes = notes
    mCategory = category
  End Sub


  Public ReadOnly Property AffectedUnitTypes As List(Of eUnit)
    Get
      Return mAffectedUnitTypes
    End Get
  End Property
  Public Property Target As iGameEntity
    Get
      Return mTarget
    End Get
    Set(value As iGameEntity)
      mTarget.Id = value
    End Set
  End Property






End Class
