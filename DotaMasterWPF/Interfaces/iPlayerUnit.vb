Public Interface iPlayerUnit
  Inherits iDisplayUnit


  Property Bio As String




  'Function Strength() As Stat
  'Function Intelligence() As Stat
  'Function Agility() As Stat

  ' Property AbilitiesBuildOrderByUIPosition As List(Of Integer)

  Function GetTempAbilityLifetimes(ab As Ability_Info) As Lifetime


  Property BaseMovementSpeed As Double
  Property BaseMagicResistance As Double

  Property TeamPosition As Integer

  Property HasAghs As Boolean
  Property AghsLifetime As Lifetime
  Function HasAghsAtTime(time As ddFrame) As Boolean



  Property Mana As Stat

End Interface
