
Public Class dGame
  Implements iGameEntity




  Private mId As dvID
  Private mRadiant As dTeam
  Private mDire As dTeam

  Private mRColors As New List(Of SolidColorBrush)
  Private mDColors As New List(Of SolidColorBrush)
  Private mTeams As New List(Of dTeam)

  Private mAllUnits As New List(Of Guid)

  Private mEconomy As EconomyManager


  Event TargetsChanged(gameentity As iGameEntity)
  Event IsDirty(gameentity As iGameEntity)


  Public dbItems As item_Database

  Public dbAbilities As ability_Database

  Private dbHeroBuilds As HeroBuild_Database

  Private dbCreeps As Creeps_and_Pets_Database

  Public dbModifiers As Modifier_Database

  Public dbFormulas As Formula_Database

  Public dbNames As FriendlyName_Database

  Public dbColors As Colors_Database

  Public TimeKeeper As TimeKeeper

  Private mMyMods As New List(Of Modifier)

  Public Log As iLogging

  Private mStatPackageFactory As Stat_Package_Factory
  Private mGraphDataFactory As New GraphDataFactory

  Public Sub New(itemsdb As item_Database, _
                 abilitiesdb As ability_Database,
                 heroesdb As HeroBuild_Database, _
                creepsdb As Creeps_and_Pets_Database, _
                 formulasdb As Formula_Database, _
                 namesdb As FriendlyName_Database, _
                 time As TimeKeeper, _
                 log As iLogging, _
                 colorsdb As Colors_Database)

    Id = New dvID(Guid.NewGuid, "Game.New", eEntity.Game)


    dbItems = itemsdb

    dbAbilities = abilitiesdb

    dbHeroBuilds = heroesdb

    dbCreeps = creepsdb

    dbFormulas = formulasdb

    dbModifiers = New Modifier_Database(Me, dbNames, dbFormulas, log, TimeKeeper)


    dbColors = colorsdb

    dbNames = namesdb

    TimeKeeper = time

    mEconomy = New EconomyManager(TimeKeeper)

    Me.Log = log

    mRadiant = New dTeam(eTeamName.Radiant, Me, log, dbModifiers)
    mDire = New dTeam(eTeamName.Dire, Me, log, dbModifiers)

    mTeams = New List(Of dTeam)
    mTeams.Add(mRadiant)
    mTeams.Add(mDire)

    dbNames = namesdb



    AddHandler mRadiant.isDirty, AddressOf Object_IsDirty
    AddHandler mRadiant.TargetsChanged, AddressOf Object_TargetsChanged

    AddHandler mDire.isDirty, AddressOf Object_IsDirty
    AddHandler mDire.TargetsChanged, AddressOf Object_TargetsChanged



  End Sub

  Public Sub LoadStartup()

    Dim herofactory As New HeroInstanceFactory(Me, dbCreeps)
    Dim emptyid As New dvID(Guid.Empty, "Empty ID", eEntity.Hero_Instance)


    Dim viper = dbHeroBuilds.GetFirstBuildForHero(eHeroName.untViper)
    Dim viperinst = herofactory.CreateHeroInstance(viper, _
                                                   dbColors.GetTeamColor(eTeamName.Dire, 0), _
                                                   mDire, 0, 0.2, 0.2)
    Me.AddHeroInstance(viperinst)

    Dim medusa = dbHeroBuilds.GetFirstBuildForHero(eHeroName.untMedusa)
    Dim medusainst = herofactory.CreateHeroInstance(medusa, _
                                                    dbColors.GetTeamColor(eTeamName.Dire, 1), _
                                                    mDire, 1, 0.2, 0.2)
    Me.AddHeroInstance(medusainst)

    Dim batrider = dbHeroBuilds.GetFirstBuildForHero(eHeroName.untBatrider)
    Dim batriderinst = herofactory.CreateHeroInstance(batrider, _
                                                      dbColors.GetTeamColor(eTeamName.Dire, 2), _
                                                      mDire, 2, 0.2, 0.2)
    Me.AddHeroInstance(batriderinst)


    Dim ancient = dbHeroBuilds.GetFirstBuildForHero(eHeroName.untAncient_Apparition)
    Dim ancientinst = herofactory.CreateHeroInstance(ancient, _
                                                      dbColors.GetTeamColor(eTeamName.Dire, 3), _
                                                      mDire, 3, 0.2, 0.2)
    Me.AddHeroInstance(ancientinst)

    Dim venge = dbHeroBuilds.GetFirstBuildForHero(eHeroName.untVengeful_Spirit)
    Dim vengeinst = herofactory.CreateHeroInstance(venge, _
                                                   dbColors.GetTeamColor(eTeamName.Dire, 4), _
                                                   mDire, 4, 0.2, 0.2)
    Me.AddHeroInstance(vengeinst)

    Dim tiny = dbHeroBuilds.GetFirstBuildForHero(eHeroName.untTiny)
    Dim tinyinst = herofactory.CreateHeroInstance(tiny, _
                                                    dbColors.GetTeamColor(eTeamName.Radiant, 0), _
                                                    mRadiant, 0, 0.2, 0.2)
    Me.AddHeroInstance(tinyinst)

    Dim brew = dbHeroBuilds.GetFirstBuildForHero(eHeroName.untBrewmaster)
    Dim brewinst = herofactory.CreateHeroInstance(brew, _
                                                  dbColors.GetTeamColor(eTeamName.Radiant, 1), _
                                                  mRadiant, 1, 0.2, 0.2)
    Me.AddHeroInstance(brewinst)

    Dim nyx = dbHeroBuilds.GetFirstBuildForHero(eHeroName.untNyx_Assassin)
    Dim nyxinst = herofactory.CreateHeroInstance(nyx, _
                                                 dbColors.GetTeamColor(eTeamName.Radiant, 2), _
                                                 mRadiant, 2, 0.2, 0.2)
    Me.AddHeroInstance(nyxinst)

    Dim sky = dbHeroBuilds.GetFirstBuildForHero(eHeroName.untSkywrath_Mage)
    Dim skyinst = herofactory.CreateHeroInstance(sky, _
                                                 dbColors.GetTeamColor(eTeamName.Radiant, 3), _
                                                 mRadiant, 3, 0.2, 0.2)
    Me.AddHeroInstance(skyinst)

    Dim io = dbHeroBuilds.GetFirstBuildForHero(eHeroName.untIo)
    Dim ioinst = herofactory.CreateHeroInstance(io, _
                                                dbColors.GetTeamColor(eTeamName.Radiant, 4), _
                                                mRadiant, 4, 0.2, 0.2)
    Me.AddHeroInstance(ioinst)

    Dim direHero = mDire.GetHeroInstances.Item(0)
    Dim RadHero = mRadiant.GetHeroInstances.Item(0)
    SetTargets(direHero, RadHero, True, mRadiant)
    SetTargets(RadHero, direHero, True, mDire)

    mRadiant.CalcMods()
    mDire.CalcMods()
  End Sub

  Public Sub SetCurrentTime(thetime As ddFrame)

    TimeKeeper.CurrentTime = thetime

  End Sub
  Public Sub calcmods() Implements iGameEntity.calcmods

  End Sub

  Public Function GetRootNavigationItemsForUI() As List(Of iGameEntity)
    Dim outlist As New List(Of iGameEntity)

    Dim RadvDire As New GameEntity_Tuple(mRadiant, mDire, Me)
    outlist.Add(RadvDire)

    outlist.Add(mRadiant)
    outlist.Add(mDire)

    Dim mods = dbModifiers.GetModsByParent(Me)
    If mods IsNot Nothing Then
      outlist.AddRange(mods)
    End If

    Dim stats = dbModifiers.GetStatsByParent(Me)
    If stats IsNot Nothing Then
      outlist.AddRange(stats)
    End If

    Return outlist
  End Function

  Public Function GetNavigationItemsForItem(item As iGameEntity) As List(Of iGameEntity)
    Dim outlist As New List(Of iGameEntity)
    Dim gameentfactory As New GameEntityFactory

    Select Case item.MyType
      Case eSourceType.Game
        Dim game As dGame = item
        outlist.Add(game.mRadiant)
        outlist.Add(game.mDire)

      Case eSourceType.Team
        Dim team As dTeam = item
        Dim heroes = team.GetAllHeroes
        For i = 0 To heroes.Count - 1
          outlist.Add(heroes.Item(i))
        Next
        outlist.AddRange(gameentfactory.ConvertToGameEntities(Of Stat)(dbModifiers.GetStatsByParent(team)))

      Case eSourceType.GameEntity_Tuple
        Dim tuple As GameEntity_Tuple = item
        'outlist.Add(tuple.ItemOne)
        'outlist.Add(tuple.ItemTwo)

        Select Case tuple.ItemOne.MyType
          Case eSourceType.Hero_Instance


            Dim hero1 As HeroInstance = tuple.ItemOne
            outlist.AddRange(hero1.AbilityInventory.GetAbilitiesListedByUIPositionAsGameEntities)
            outlist.AddRange(hero1.ItemInventory.GetItemBuildAndAutoGeneratedItemsAsGameEntities)
            Dim hero2 As HeroInstance = tuple.ItemTwo
            outlist.AddRange(hero2.AbilityInventory.GetAbilitiesListedByUIPositionAsGameEntities)
            outlist.AddRange(hero2.ItemInventory.GetItemBuildAndAutoGeneratedItemsAsGameEntities)



          Case eSourceType.Team
            Dim allheroes = Me.GetAllHeroes

            Dim radheroes = Me.GetHeroInstancesForTeam(eTeamName.Radiant)
            Dim direheroes = Me.GetHeroInstancesForTeam(eTeamName.Dire)

            Dim maxheropairs As Integer = radheroes.Count
            If direheroes.Count < maxheropairs Then maxheropairs = direheroes.Count

            For i = 0 To maxheropairs - 1
              Dim herotuple As New GameEntity_Tuple(radheroes.Item(i), direheroes.Item(i), Me)
              outlist.Add(herotuple)
            Next

            Dim heroents As New List(Of iGameEntity)
            For i = 0 To allheroes.Count - 1
              For x = 0 To allheroes.Item(i).Count - 1
                Dim heroent As iGameEntity = allheroes.Item(i).Item(x)
                heroents.Add(heroent)
              Next

            Next
            outlist.AddRange(heroents)
            outlist.AddRange(gameentfactory.ConvertToGameEntities(Of Stat)(dbModifiers.GetStatsByParent(mRadiant)))
            outlist.AddRange(gameentfactory.ConvertToGameEntities(Of Stat)(dbModifiers.GetStatsByParent(mDire)))
          Case Else
            Throw New NotImplementedException
        End Select

      Case eSourceType.Hero_Instance
        Dim hero As HeroInstance = item
        outlist.AddRange(hero.AbilityInventory.GetAbilitiesListedByUIPositionAsGameEntities)
        outlist.AddRange(hero.ItemInventory.GetItemBuildAndAutoGeneratedItemsAsGameEntities)
        outlist.AddRange(gameentfactory.ConvertToGameEntities(Of Stat)(dbModifiers.GetStatsByParent(hero)))
      Case eSourceType.Item_Info
        Dim iteminf As Item_Info = item
        outlist.AddRange(gameentfactory.ConvertToGameEntities(Of Modifier)(dbModifiers.GetModsBySource(iteminf)))
        '        outlist.AddRange(gameentfactory.ConvertToGameEntities(Of Modifier)(dbModifiers.GetModsByParent(iteminf)))

      Case eSourceType.Ability_Info
        Dim ability As Ability_Info = item
        outlist.AddRange(gameentfactory.ConvertToGameEntities(Of Modifier)(dbModifiers.GetModsBySource(ability)))
        ' outlist.AddRange(gameentfactory.ConvertToGameEntities(Of Modifier)(dbModifiers.GetModsByParent(ability)))

      Case eSourceType.Stat
        Dim thestat As Stat = item
        outlist.AddRange(thestat.MyStats)
        Dim mods = thestat.MyModsByType
        For Each modlist In mods
          For i = 0 To modlist.Value.Count - 1
            Dim themod = modlist.Value.Item(i)
            outlist.Add(themod)

          Next
        Next
      Case eSourceType.Modifier

      Case Else
        Throw New NotImplementedException

    End Select

    Return outlist
  End Function
#Region "Props"

  Public Property StatPackageFactory As Stat_Package_Factory
    Get
      If mStatPackageFactory Is Nothing Then
        mStatPackageFactory = New Stat_Package_Factory(Me)
      End If
      Return mStatPackageFactory
    End Get
    Set(value As Stat_Package_Factory)

    End Set
  End Property
  Public Property MyColor As Color Implements iGameEntity.MyColor
    Get
      Return dbColors.NeutralTeamColor
    End Get
    Set(value As Color)

    End Set
  End Property

  Public Property EntityName As eEntity Implements iGameEntity.EntityName
    Get
      Return eEntity.Game
    End Get
    Set(value As eEntity)

    End Set
  End Property

  Public Property Id As dvID Implements iGameEntity.Id
    Get
      Return Me.mId
    End Get
    Set(value As dvID)
      If mId Is Nothing Then
        mId = value
      End If
    End Set
  End Property

  Public Property ParentGameEntity As iGameEntity Implements iGameEntity.ParentGameEntity
    Get
      Return Me
    End Get
    Set(value As iGameEntity)

    End Set
  End Property

  Public Property MyType As eSourceType Implements iGameEntity.MyType
    Get
      Return eSourceType.Game
    End Get
    Set(value As eSourceType)

    End Set
  End Property

  Public Property ParentGameEntityType As eSourceType Implements iGameEntity.ParentGameEntityType
    Get
      Return eSourceType.None
    End Get
    Set(value As eSourceType)

    End Set
  End Property

  Public Property DisplayName As String Implements iGameEntity.DisplayName
    Get
      Return "Game"
    End Get
    Set(value As String)

    End Set
  End Property

  ''' <summary>
  ''' 0: radiant, 1:Dire
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public ReadOnly Property HeroTeamUnits As List(Of List(Of iDisplayUnit))
    Get
      Dim outlist As New List(Of List(Of iDisplayUnit))
      outlist.Add(mRadiant.GetAllHeroes)
      outlist.Add(mDire.GetAllHeroes)
      Return outlist
    End Get
  End Property

  Public Property Economy As EconomyManager
    Get
      Return mEconomy
    End Get
    Set(value As EconomyManager)

    End Set
  End Property

  Public ReadOnly Property RadiantTeam As dTeam
    Get
      Return mRadiant
    End Get
  End Property

  Public ReadOnly Property DireTeam As dTeam
    Get
      Return mDire
    End Get
  End Property
#End Region

#Region "Graphing Data"
  Public Function GetGraphData(themods As List(Of ModifierList)) As GraphDataPackage
    Return mGraphDataFactory.CreateGraphData(themods, Me)
  End Function
  Public Function GetGraphData(thestats As List(Of List(Of Stat))) As GraphDataPackage
    Return mGraphDataFactory.CreateGraphData(thestats, Me)
  End Function

  Public Function GetGraphData(dataitems As List(Of List(Of iDataItem))) As GraphDataPackage
    Return mGraphDataFactory.CreateGraphData(dataitems, Me)
  End Function
#End Region


#Region "Unit ID stuff"

  Public Function GameContainsUnit(unit As iDisplayUnit) As Boolean
    Dim contains As Boolean = True
    For i = 0 To mTeams.Count - 1
      If mTeams.Item(i).ContainsUnit(unit) Then contains = True
    Next

    Return True
  End Function

  Public Function GetAllUnits() As List(Of iDisplayUnit)
    Dim outlist As New List(Of iDisplayUnit)

    For i = 0 To mTeams.Count - 1
      outlist.AddRange(mTeams.Item(0).GetAllHeroAndPetUnits())
    Next
    Return outlist
  End Function

  Public Function GetEnemyTeamUnits(unit As iDisplayUnit) As List(Of iDisplayUnit)
    Dim enemyteam As List(Of iDisplayUnit)
    If mRadiant.ContainsUnit(unit) Then
      enemyteam = mDire.GetAllHeroAndPetUnits
    End If
    If mDire.ContainsUnit(unit) Then
      enemyteam = mRadiant.GetAllHeroAndPetUnits
    End If

    Return New List(Of iDisplayUnit)

  End Function


  Public Function GetColorForTeam(team As eTeamName) As Color
    Select Case team
      Case eTeamName.Radiant
        Return dbColors.RadiantColor
      Case eTeamName.Dire
        Return dbColors.DireColor

      Case Else
        Throw New NotImplementedException
    End Select

  End Function
  Public Function GetTeamNameFromUnit(unit As iDisplayUnit) As eTeamName
    If mRadiant.ContainsUnit(unit) Then
      Return eTeamName.Radiant
    End If

    If mDire.ContainsUnit(unit) Then
      Return eTeamName.Dire
    End If

    Return Nothing
  End Function

  Public Function GetTeamFromGameEntity(gameentity As iGameEntity) As dTeam
    If mRadiant.ContainsID(gameentity.Id) Then
      Return mRadiant
    End If

    If mDire.ContainsID(gameentity.Id) Then
      Return mDire
    End If

    Return Nothing
  End Function


#End Region

#Region "Units CRUD"


  Public Function GetEnemyTeam(unit As iDisplayUnit) As dTeam


    If mRadiant.ContainsUnit(unit) Then
      Return mDire
    End If
    If mDire.ContainsUnit(unit) Then
      Return mRadiant
    End If
    Throw New NotImplementedException
  End Function



#End Region

#Region "Targetting"

  Public Sub SetTargets(theenemytarget As iHeroUnit, _
                         thefriendlytarget As iHeroUnit, _
                         isfriendlybias As Boolean, theteam As dTeam)

    Select Case theteam.TeamName
      Case eTeamName.Radiant
        mRadiant.SetTargets(theenemytarget, thefriendlytarget, isfriendlybias)
      Case eTeamName.Dire
        mDire.SetTargets(theenemytarget, thefriendlytarget, isfriendlybias)
      Case Else
        Dim x = 2
    End Select

    ClearDirtyData()
    RaiseEvent TargetsChanged(Me)
  End Sub


  Public Function GetEnemyTarget(thecaster As iDisplayUnit) As iDisplayUnit
    If mRadiant.ContainsUnit(thecaster) Then
      Return mRadiant.EnemyTarget
    End If

    If mDire.ContainsUnit(thecaster) Then
      Return mDire.EnemyTarget
    End If
    Return Nothing
  End Function

  Public Function GetFriendlyTarget(thecaster As iDisplayUnit) As iDisplayUnit

    If mRadiant.ContainsUnit(thecaster) Then
      Return mRadiant.FriendlyTarget
    End If

    If mDire.ContainsUnit(thecaster) Then
      Return mDire.FriendlyTarget
    End If
    Return Nothing

  End Function
  Public Function GetFriendBias(theteam As eTeamName) As Boolean
    Select Case theteam
      Case eTeamName.Radiant
        Return mRadiant.TargetFriendlyBias
      Case eTeamName.Dire
        Return mDire.TargetFriendlyBias
      Case Else
        Dim x = 2
        Return Nothing
    End Select
  End Function

  Public Function GetFriendBias(thecaster As iDisplayUnit) As Boolean
    If mRadiant.ContainsUnit(thecaster) Then
      Return mRadiant.TargetFriendlyBias
    End If

    If mDire.ContainsUnit(thecaster) Then
      Return mDire.TargetFriendlyBias
    End If
    Return Nothing
  End Function



#End Region


#Region "Herobuild CRUD"

  Private Sub AddHeroInstance(hero As HeroInstance)

    'Dim thehero = mHeroInstFactory.CreateHeroInstance(hero, herocolor, theteam, heroposition, goldshare, xpshare)

    Select Case hero.Team.TeamName
      Case eTeamName.Radiant
        dbModifiers.RemoveAllHeroModsAndStatsByHero(hero)


        mRadiant.AddorReplaceHeroInstance(hero, hero.TeamPosition)
        hero.CalcMods()
      Case eTeamName.Dire

        mDire.AddorReplaceHeroInstance(hero, hero.TeamPosition)
        hero.CalcMods()
    End Select

    ClearDirtyData()
  End Sub

  Public Sub RemoveHeroInstance(theteam As eTeamName, heroposition As Integer)
    Select Case theteam
      Case eTeamName.Radiant
        mRadiant.RemoveHeroBadge(heroposition)
      Case eTeamName.Dire
        mDire.RemoveHeroBadge(heroposition)
    End Select

    ClearDirtyData()
  End Sub

  Public Sub AddorReplaceHeroInstance(hero As HeroInstance, herocolor As Color, _
                                 theteam As dTeam, heroposition As Integer, _
                                 goldshare As Decimal, xpshare As Decimal)



    theteam.AddorReplaceHeroInstance(hero, hero.mTeamPosition)
    hero.CalcMods()
    ClearDirtyData()

  End Sub

  Public Sub ClearDirtyData()
    mStatPackageFactory = New Stat_Package_Factory(Me)
  End Sub

  Public Function GetHeroInstanceByTeamAndPositionIndex(theteam As dTeam, theindex As Integer) As HeroInstance
    Select Case theteam.TeamName
      Case eTeamName.Radiant
        Return mRadiant.GetHeroInstance(theindex)
      Case eTeamName.Dire
        Return mDire.GetHeroInstance(theindex)
      Case Else
        Throw New NotImplementedException
    End Select
  End Function



  Public Function GetHeroInstancesForTeam(theteam As eTeamName) As List(Of iHeroUnit)

    Select Case theteam
      Case eTeamName.Dire
        Return mDire.GetHeroInstances
      Case eTeamName.Radiant
        Return mRadiant.GetHeroInstances
      Case Else
        Log.Writelog("Get HeroInstancesForTeam Unhandled type")
    End Select
    Return Nothing
  End Function

  Public Function GetAllHeroes() As List(Of List(Of iDisplayUnit))
    Dim outlist As New List(Of List(Of iDisplayUnit))

    outlist.Add(GetAllHeroesForTeam(eTeamName.Radiant))
    outlist.Add(GetAllHeroesForTeam(eTeamName.Dire))
    Return outlist
  End Function
  Public Function GetAllHeroesForTeam(theteam As eTeamName) As List(Of iDisplayUnit)
    Select Case theteam
      Case eTeamName.Radiant
        Return mRadiant.GetAllHeroes
      Case eTeamName.Dire
        Return mDire.GetAllHeroes

    End Select
    Return New List(Of iDisplayUnit)
  End Function

  Public Function GetTeamHeroCount(theteam As eTeamName) As Integer
    Select Case theteam
      Case eTeamName.Radiant
        Return mRadiant.HeroCount
      Case eTeamName.Dire
        Return mDire.HeroCount
      Case Else
        Throw New NotImplementedException
    End Select
  End Function
#End Region

#Region "Creep CRUD"
  Public Function GetCreepInstanceByID(theid As dvID) As Creep_Instance

    Dim outcreep = mRadiant.GetCreepInstance(theid)
    If outcreep IsNot Nothing Then
      Return outcreep
    End If
    outcreep = mDire.GetCreepInstance(theid)
    Return outcreep
  End Function

#End Region

#Region "Herobuild Manipulation"



#End Region


#Region "Event Handlers"

  Private Sub Object_TargetsChanged(gameentity As iGameEntity)
    RaiseEvent TargetsChanged(Me)
  End Sub

  Private Sub Object_IsDirty(gameentity As iGameEntity)
    ClearDirtyData()

  End Sub



#End Region






End Class

