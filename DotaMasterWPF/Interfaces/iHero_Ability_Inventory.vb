Public Interface iHero_Ability_Inventory
  Inherits iAbility_Inventory

  ' Property AbilitiesBuildOrderByUIPosition As List(Of Integer)

  Property CurrentAbilityLevelsForEachHeroLevel As List(Of List(Of Integer))

  Function GetNewAbilityByLevel(herolevel As Integer) As Ability_Info

  Function GetActiveAbilitiesByLevel(herolevel As Integer) As List(Of Integer)

  Function GetUpgradableAbilitiesByLevel(herolevel As Integer) As Ability_Info_List

  Function GetAbilityLevelAtHeroLevel(theab As Ability_Info, herolevel As Integer) As Integer

  Function RemoveAbility(theability As Ability_Info, theabilitylist As List(Of Ability_Info)) As List(Of Ability_Info)

  Function GetUltimate() As Ability_Info
End Interface
