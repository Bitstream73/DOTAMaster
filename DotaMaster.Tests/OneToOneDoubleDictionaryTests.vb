Imports Xunit
Imports Telerik.JustMock
Public Class OneToOneDoubleDictionaryTests
  Public Function GetGameEntityMock(parentgameentity As iGameEntity) As iGameEntity
    Dim ge = Mock.Create(Of iGameEntity)()

    Dim gid = Guid.NewGuid
    Dim id As New dvID(gid, gid.ToString, eEntity.abAcid_Spray)
    Mock.Arrange(Function() ge.Id()).Returns(id)


    Mock.Arrange(Function() ge.DisplayName()).Returns("testitem id " & id.GuidID.ToString)

    Mock.Arrange(Function() ge.EntityName()).Returns(eEntity.abAcid_Spray)

    Mock.Arrange(Function() ge.MyType()).Returns(eSourceType.Ability_Info)

    Mock.Arrange(Function() ge.ParentGameEntity()).Returns(parentgameentity)

    Mock.Arrange(Function() ge.ParentGameEntityType()).Returns(eSourceType.Ability_Info)

    Return ge
  End Function


  <Fact> Sub Add_Adds_Values()
    Dim item1 = GetGameEntityMock(Nothing)
    Dim mocklog = Mock.Create(Of iLogging)()
    Dim dd As New OneToOneDoubleDictionary(Of eEntity, iGameEntity)(mocklog)
    dd.AddorUpdate(item1.EntityName, item1)

    Dim result = dd.ValueForKey(item1.EntityName)
    Assert.NotNull(result)

  End Sub

  <Fact> Sub Remove_Removes_Values()
    Dim item1 = GetGameEntityMock(Nothing)
    Dim mocklog = Mock.Create(Of iLogging)()
    Dim dd As New OneToOneDoubleDictionary(Of eEntity, iGameEntity)(mocklog)
    dd.AddorUpdate(item1.EntityName, item1)

    dd.Remove(item1.EntityName, item1)

    Dim result = dd.ValueForKey(item1.EntityName)
    Assert.Null(result)

  End Sub

  <Fact> Sub ValuesForKey0_Returns_Key1()
    Dim item1 = GetGameEntityMock(Nothing)
    Dim mocklog = Mock.Create(Of iLogging)()
    Dim dd As New OneToOneDoubleDictionary(Of eEntity, iGameEntity)(mocklog)
    dd.AddorUpdate(item1.EntityName, item1)


    Dim result = dd.ValueForKey(item1.EntityName)
    Assert.NotNull(result)
  End Sub

  <Fact> Sub ValuesForKey1_Returns_Key0()
    Dim item1 = GetGameEntityMock(Nothing)
    Dim mocklog = Mock.Create(Of iLogging)()
    Dim dd As New OneToOneDoubleDictionary(Of eEntity, iGameEntity)(mocklog)
    dd.AddorUpdate(item1.EntityName, item1)


    Dim result = dd.ValueForKey(item1)
    Assert.NotNull(result)
  End Sub

  <Fact> Sub Coutn_Returns_Count()
    Dim item1 = GetGameEntityMock(Nothing)
    Dim mocklog = Mock.Create(Of iLogging)()
    Dim dd As New OneToOneDoubleDictionary(Of eEntity, iGameEntity)(mocklog)
    dd.AddorUpdate(item1.EntityName, item1)


    Assert.Equal(1, dd.Count)
  End Sub

End Class
