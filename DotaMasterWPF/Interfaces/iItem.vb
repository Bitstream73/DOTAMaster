Public Interface iItem
  Inherits IUnitUpgrade

  Property ItemName As eItemname
  Property GoldCost As ValueWrapper
  Property ItemCategory As eItemCategory
  Property MadeFromItemNames As List(Of eItemname)
  Property BuildsToNames As List(Of eItemname)
  Property SoldFrom As List(Of eShopTypes)
  Property Tier As Integer
  Property IsRecipe As Boolean
  Property CanDisassemble As Boolean
  Property Willdisassemble As Boolean
  Property ItemIsDisassembled As Boolean
  Property ItemIsFromDisassembly As Boolean
  Property Index As Integer

  Property ComponentList As Item_List

  Property IsConsumable As Boolean
  Property IsCourier As Boolean

  Property GoldBalance As Integer
  Property BoughtAtLevel As Integer
  Property SoldAtLevel As Integer

  Property ItemPlan As eItemPlan

  Property AbilityDescription As String

  Property AbilityName As String
End Interface
