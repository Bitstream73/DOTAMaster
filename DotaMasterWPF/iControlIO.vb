Public Interface iControlIO


  Event isDirty(gameentity As iGameEntity)
  Event SelectedChanged(gameentity As iGameEntity)
  Sub SetSelected( isselected As Boolean)

  ReadOnly Property IsSelected As Boolean

End Interface
