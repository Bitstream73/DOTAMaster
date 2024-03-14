Public Interface iPetUnit
  Inherits iPlayerUnit
  'Pets are player controlled, sometimes only minimally (observer wards can only be placed by playert),
  'sometimes like another hero (Meepos, Spirit Bear). They also can potentially have/use items.

  Property PetName As ePetName

  Property PetsOwned As List(Of PetStack)
  Property Source As IUnitUpgrade

  Property ItemInventory As Pet_Item_Inventory

  Property AbilityInventory As Hero_Ability_Inventory
  Function NonScepterExistsAtLevel(lvl As Integer) As Boolean
End Interface
