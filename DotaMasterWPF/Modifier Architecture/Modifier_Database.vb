Public Class Modifier_Database



  Public mVersion682cID As dvID


  Private mMods As New Dictionary(Of Guid, Modifier)
  Private mStats As New Dictionary(Of Guid, Stat)
  Private isSorted As Boolean = False

  Private dbNames As FriendlyName_Database
  Private dbFormulas As Formula_Database

  Private mTimekeeper As TimeKeeper

  Private mLog As Logging
  Private mGame As dGame
  Event Modschanged(theaffected As TypesAndTargets)

  Public Sub New(thegame As dGame, namesdb As FriendlyName_Database, formulas As Formula_Database, thelog As Logging, thetime As TimeKeeper)

    mGame = thegame
    mLog = thelog
    mTimekeeper = thetime
    dbNames = namesdb
    dbFormulas = formulas

    mVersion682cID = New dvID(New Guid("b0e46a01-f529-4216-98f0-964d83918cd4"), "Version 6.82c ID", eEntity.GameVersion)

  End Sub


#Region "Public CRUD Operations"
  Public Sub ReplaceModifiers(modstoadd As ModifierList, modidstoremove As List(Of dvID))

    If Not modidstoremove Is Nothing Then
      RemoveModifiersByModIDs(modidstoremove)

    End If

    If Not modstoadd Is Nothing Then
      AddModifiers(modstoadd)
    End If

    Dim allmods As ModifierList

    If Not modstoadd Is Nothing Then
      allmods = modstoadd
    Else
      allmods = New ModifierList
    End If

    If Not modidstoremove Is Nothing Then
      Dim remmods = Me.GetModsByModIDs(modidstoremove)
      allmods.AddList(remmods)

    End If

    BroadcastChangedModsnStats(Nothing, allmods)



  End Sub


  Public Sub ReplaceStats(statstoadd As List(Of Stat), statidstoremove As List(Of dvID))

    If Not statidstoremove Is Nothing Then
      If statidstoremove.Item(0).MetaContainsString("Tiny") Then
        Dim x = 2
      End If
      If statidstoremove.Item(0).MetaContainsString("Brew") Then
        Dim x = 2
      End If
      RemoveStatsByStatIDs(statidstoremove)
    End If

    If Not statstoadd Is Nothing Then
      If statstoadd.Item(0).ParentGameEntity.Id.MetaContainsString("Tiny") Then
        Dim x = 2
      End If
      If statstoadd.Item(0).ParentGameEntity.Id.MetaContainsString("Brew") Then
        Dim x = 2
      End If
      AddStats(statstoadd)
    End If

    Dim remstats = Me.GetStatsbyStatIDs(statidstoremove)
    Dim allstats = statstoadd
    allstats = Helpers.AddListToList(Of Stat)(allstats, remstats)

    If Not allstats Is Nothing Then
      If Not allstats.Count < 1 Then
        BroadcastChangedModsnStats(allstats, Nothing)

      End If

    End If

  End Sub

  Public Sub RemoveModifiersForSourceID(thesourceid As dvID)
    Dim deletelist As New List(Of Guid)
    For Each kv As KeyValuePair(Of Guid, Modifier) In mMods

      If kv.Value.TheModInfo.ModGenerator.Id.GuidID = thesourceid.GuidID Then
        If Not deletelist.Contains(kv.Key) Then
          deletelist.Add(kv.Key)
        End If
      End If

    Next

    For i As Integer = 0 To deletelist.Count - 1
      mMods.Remove(deletelist.Item(i))
    Next
  End Sub

  Public Sub RemoveAllHeroModsAndStatsByHero(hero As iPlayerUnit)
    If hero.Id.MetaContainsString("Tiny") Then
      Dim x = 2
    End If
    If hero.Id.MetaContainsString("Brew") Then
      Dim x = 2
    End If
    Dim remmodlist As New List(Of Guid)
    Dim remstatlist As New List(Of Guid)
    For Each kv As KeyValuePair(Of Guid, Modifier) In mMods
      Dim themod = kv.Value
      Dim theymatch As Boolean = False
      If themod.Parent.Id.GuidID = hero.Id.GuidID Then
        theymatch = True
      End If
      If themod.ModGenerator.Id.GuidID = hero.Id.GuidID Then
        theymatch = True
      End If

      If theymatch Then
        remmodlist.Add(kv.Key)
      End If
    Next

    For i As Integer = 0 To remmodlist.Count - 1
      Dim themod = mMods.Item(remmodlist.Item(i))
      '  mLog.WriteLog("REMOVED " & themod.ToString)
      mMods.Remove(remmodlist.Item(i))

    Next

    For Each kv As KeyValuePair(Of Guid, Stat) In mStats
      Dim thestat = kv.Value
      Dim theymatch As Boolean = False
      If thestat.ParentGameEntity.Id.GuidID = hero.Id.GuidID Then
        theymatch = True
      End If

      If thestat.ParentGameEntity.Id.GuidID = hero.Id.GuidID Then
        theymatch = True
      End If


      If theymatch Then
        remstatlist.Add(kv.Key)
      End If
    Next

    For i As Integer = 0 To remstatlist.Count - 1
      Dim thestat = mStats.Item(remstatlist.Item(i))
      ' mLog.WriteLog("REMOVED in RAHMSBYHID " & thestat.ToString)
      mStats.Remove(remstatlist.Item(i))
    Next
  End Sub
#End Region


#Region "Private CRUD Operations"
  Private Sub AddModifiers(themods As ModifierList)

    If themods Is Nothing Then Exit Sub

    For i As Integer = 0 To themods.Count - 1

      If themods.Item(i).ModifierType = eModifierType.BaseArmor Then
        Dim x = 2
      End If


      AddModifier(themods.Item(i))


    Next


  End Sub

  Private Sub AddStats(thestats As List(Of Stat))

    For i As Integer = 0 To thestats.Count - 1

      AddStat(thestats.Item(i))
    Next
  End Sub
  Private Sub AddModifier(themod As Modifier)



    If mMods.ContainsKey(themod.IDItem.GuidID) Then
      mMods.Remove(themod.IDItem.GuidID)
    End If

    'no longer used. Users of a mod subscribe directly to moddirty
    'AddHandler(themod.ModDirty, AddressOf Modifier_ModDirty)

    mMods.Add(themod.IDItem.GuidID, themod)
    ' mLog.WriteLog("ADDED " & themod.ToString)
    isSorted = False
    'moving sort to get mods requests. less repetition that way
    'Mods = DictValueSortDesc(Mods)
  End Sub

  Private Sub AddStat(thestat As Stat)
    If thestat.ParentGameEntity.Id.MetaContainsString("Venge") Then
      Dim x = 2
    End If

    If mStats.ContainsKey(thestat.ID.GuidID) Then
      ' mLog.WriteLog("REMOVED IN ADDStAT " & thestat.ToString)
      mStats.Remove(thestat.ID.GuidID)

    End If

    ' mLog.WriteLog("ADDED " & thestat.ToString)
    mStats.Add(thestat.ID.GuidID, thestat)

  End Sub


  Private Sub RemoveModifiersByModIDs(themodids As List(Of dvID))

    For i As Integer = 0 To themodids.Count - 1

      RemoveModifierByModID(themodids.Item(i))

    Next

  End Sub

  Private Sub RemoveStatsByStatIDs(thestatids As List(Of dvID))
    For i As Integer = 0 To thestatids.Count - 1
      RemoveStatByStatID(thestatids.Item(i))
    Next
  End Sub
  Private Sub RemoveModifierByModID(themodid As dvID)
    If mMods.ContainsKey(themodid.GuidID) Then
      Dim curmod = mMods.Item(themodid.GuidID)
      If curmod.ModifierType = eModifierType.BaseGold Then
        Dim x = 2
      End If
      ' mLog.WriteLog("REMOVED MOD " & curmod.ToString)

      mMods.Remove(themodid.GuidID)

    End If

  End Sub


  Private Sub RemoveStatByStatID(thestatid As dvID)
    If mStats.ContainsKey(thestatid.GuidID) Then
      Dim curstat = mStats.Item(thestatid.GuidID)

      ' mLog.WriteLog("REMOVED STAT " & curstat.ToString)
      mStats.Remove(thestatid.GuidID)
    End If

  End Sub

#End Region

#Region "Gets"



  Public Function GetModsByParentsAndType(theparents As IEnumerable(Of iGameEntity), thetype As eModifierType) As List(Of Modifier)
    CheckSort()

    Dim outmods As New List(Of Modifier)

    For Each parent In theparents
      Dim mods = GetModsbyParentAndType(parent, thetype)

      For x As Integer = 0 To mods.Count - 1
        outmods.Add(mods.Item(x))
      Next
    Next
    Return outmods
  End Function

  Public Function GetModsBySourcesAndType(sources As IEnumerable(Of iGameEntity), thetype As eModifierType) As List(Of Modifier)
    CheckSort()

    Dim outmods As New List(Of Modifier)

    For Each source In sources
      Dim mods = GetModsBySourceAndType(source, thetype)

      For x As Integer = 0 To mods.Count - 1
        outmods.Add(mods.Item(x))
      Next
    Next
    Return outmods

  End Function

  Public Function GetModsByTargetsAndType(targets As IEnumerable(Of iGameEntity), thetype As eModifierType) As List(Of Modifier)
    CheckSort()

    Dim outmods As New List(Of Modifier)

    For Each target In targets
      Dim mods = GetModsByTargetandType(target, thetype)

      For x As Integer = 0 To mods.Count - 1
        outmods.Add(mods.Item(x))
      Next
    Next
    Return outmods

  End Function

  Public Function GetModsBySourceAndType(source As iGameEntity, type As eModifierType) As List(Of Modifier)
    Dim outmods As New List(Of Modifier)
    For Each kv As KeyValuePair(Of Guid, Modifier) In mMods

      Dim curmod = kv.Value

      If Not curmod.ModGenerator.Id.GuidID = source.Id.GuidID Then
        Dim x = 2
      End If

      If curmod.ModGenerator.Id.GuidID = source.Id.GuidID Then
        If curmod.Type = type Then
          outmods.Add(curmod)
        End If
      End If

    Next
    Return outmods
  End Function

  Public Function GetModsByTargetandType(target As iDisplayUnit, thetype As eModifierType) As List(Of Modifier)
    Dim outmods As New List(Of Modifier)
    For Each kv As KeyValuePair(Of Guid, Modifier) In mMods

      Dim curmod = kv.Value
      Dim thetargs = Helpers.GetAffectedUnitsForMod(curmod, mGame)

      Dim guids As New List(Of Guid)
      For t = 0 To thetargs.Count - 1
        guids.Add(thetargs.Item(t).Id.GuidID)
      Next

      If guids.Contains(target.Id.GuidID) Then
        If curmod.Type = thetype Then
          outmods.Add(curmod)
        End If
      End If

    Next
    Return outmods


  End Function

  Public Function GetModsbyParentAndType(theparent As iGameEntity, thetype As eModifierType) As List(Of Modifier)

    Dim outmods As New List(Of Modifier)
    For Each kv As KeyValuePair(Of Guid, Modifier) In mMods

      Dim curmod = kv.Value

      If Not curmod.Parent.Id.GuidID = theparent.Id.GuidID Then
        Dim x = 2
      End If

      If curmod.Parent.Id.GuidID = theparent.Id.GuidID Then
        If curmod.Type = thetype Then
          outmods.Add(curmod)
        End If
      End If

    Next
    Return outmods
  End Function

  Public Function GetModsByParentAndTypes(theparent As iGameEntity, thetypes As List(Of eModifierType)) As List(Of Modifier)
    Dim outmods As New List(Of Modifier)
    Dim parentguid = theparent.Id.GuidID
    For Each kv As KeyValuePair(Of Guid, Modifier) In mMods
      Dim curmod = kv.Value

      If thetypes.Contains(curmod.ModifierType) Then
        If curmod.Parent.Id.GuidID = parentguid Then
          outmods.Add(curmod)
        End If

      End If

    Next
    Return outmods
  End Function

  'Public Function GetStatByParentandType(parent As iGameEntity, thestattype As eStattype) As Stat

  '  Dim parentguid = parent.Id.GuidID

  '  Dim metastring As String = ""
  '  For i As Integer = 0 To parent.Id.MetaInfo.Count - 1
  '    metastring = metastring & parent.Id.MetaInfo.Item(i)
  '  Next

  '  If metastring.Contains("Tiny") Then
  '    Dim x = 2
  '  End If
  '  If thestattype = eStattype.Strength Then
  '    Dim x = 2
  '  End If

  '  For Each kv As KeyValuePair(Of Guid, Stat) In mStats
  '    Dim curstat = kv.Value

  '    If thestattype = curstat.StatType Then
  '      If curstat.ParentGameEntity.Id.GuidID = parentguid Then
  '        Return curstat
  '      End If

  '    End If


  '  Next
  '  Return Nothing
  'End Function

  Public Function GetModsBySource(thesource As iGameEntity) As List(Of Modifier)
    Dim outlist As New List(Of Modifier)
    Dim sourceguid = thesource.Id.GuidID
    For Each kv As KeyValuePair(Of Guid, Modifier) In mMods
      Dim curmod = kv.Value

      If curmod.ModGenerator.Id.GuidID = sourceguid Then
        outlist.Add(curmod)
      End If
    Next
    Return outlist
  End Function
  Public Function GetStatsByParent(theparent As iGameEntity) As List(Of Stat)
    Dim outlist As New List(Of Stat)
    Dim parentguid = theparent.Id.GuidID
    For Each kv As KeyValuePair(Of Guid, Stat) In mStats
      Dim curstat = kv.Value

      If curstat.ParentGameEntity.Id.GuidID = parentguid Then
        outlist.Add(curstat)
      End If
    Next
    Return outlist
  End Function

  Public Function GetStatsByParentandTypes(theparent As iGameEntity, thestattypes As List(Of eStattype)) As List(Of Stat)
    Dim outstats As New List(Of Stat)
    Dim pguid = theparent.Id.GuidID
    For Each kv As KeyValuePair(Of Guid, Stat) In mStats
      Dim curstat = kv.Value

      If thestattypes.Contains(curstat.StatType) Then
        If curstat.ParentGameEntity.Id.GuidID = pguid Then
          outstats.Add(curstat)
        End If
      End If
    Next
    Return outstats
  End Function

  Public Function GetStatByParentandType(parent As iGameEntity, stattype As eStattype) As Stat
    Dim pguid = parent.Id.GuidID

    For Each kv As KeyValuePair(Of Guid, Stat) In mStats
      Dim curstat = kv.Value
      If stattype = kv.Value.StatType Then
        If curstat.ParentGameEntity.Id.GuidID = pguid Then
          Return kv.Value
        End If

      End If
    Next
    Return Nothing
  End Function

  Public Function GetModsByTargetandTypes(thetarget As iDisplayUnit, thetypes As List(Of eModifierType)) As List(Of Modifier)
    Dim outmods As New List(Of Modifier)
    Dim targetguid = thetarget.Id.GuidID
    For Each kv As KeyValuePair(Of Guid, Modifier) In mMods
      Dim curmod = kv.Value

      If thetypes.Contains(curmod.ModifierType) Then
        If curmod.Target.Id.GuidID = targetguid Then
          outmods.Add(curmod)
        End If
      End If

    Next
    Return outmods
  End Function
  Public Function GetModsByParent(parent As iGameEntity) As ModifierList
    Dim outmods As New ModifierList
    Dim gID = parent.Id.GuidID
    For Each kv As KeyValuePair(Of Guid, Modifier) In mMods
      Dim curmod = kv.Value
      If gID = curmod.Parent.Id.GuidID Then outmods.Add(curmod)

    Next
    Return outmods
  End Function

  Public Function GetAllModsAffectingHero(hero As iPlayerUnit) As ModifierList
    Dim outmods As New ModifierList
    Dim hID = hero.Id.GuidID
    For Each kv As KeyValuePair(Of Guid, Modifier) In mMods
      Dim curmod = kv.Value
      If hID = curmod.Parent.Id.GuidID Then
        outmods.Add(curmod)
      Else
        Dim affected = Helpers.GetAffectedUnitsForMod(curmod, mGame)
        For i As Integer = 0 To affected.Count - 1
          If affected.Item(i).Id.GuidID = hID Then
            outmods.Add(curmod)
          End If
        Next
      End If


    Next
    Return outmods
  End Function

  Public Function GetModsByModIDs(themodids As List(Of dvID)) As List(Of Modifier)
    Dim outlist As New List(Of Modifier)

    For i As Integer = 0 To themodids.Count - 1
      Dim curmod = GetModByModID(themodids.Item(i))
      If Not curmod Is Nothing Then outlist.Add(curmod)

    Next
    Return outlist
  End Function
  Public Function GetModByModID(themodid As dvID) As Modifier
    For Each kv As KeyValuePair(Of Guid, Modifier) In mMods

      If kv.Value.IDItem.GuidID = themodid.GuidID Then Return kv.Value

    Next

    Return Nothing
  End Function

  Public Function GetStatsbyStatIDs(thestatids As List(Of dvID)) As List(Of Stat)

    Dim outlist As New List(Of Stat)
    If thestatids Is Nothing Then Return outlist
    For i As Integer = 0 To thestatids.Count - 1
      Dim curstat = GetStatbyStatID(thestatids.Item(i))
      If Not curstat Is Nothing Then
        outlist.Add(curstat)
      End If
    Next
    Return outlist
  End Function
  Public Function GetStatbyStatID(thestatid As dvID) As Stat
    For Each kv As KeyValuePair(Of Guid, Stat) In mStats

      If kv.Value.ID.GuidID = thestatid.GuidID Then Return kv.Value
    Next
    Return Nothing
  End Function
  Public Function GetModsByModGenerator(modgenerator As iGameEntity) As ModifierList
    Dim outmods As New ModifierList
    Dim gID = modgenerator.Id.GuidID
    For Each kv As KeyValuePair(Of Guid, Modifier) In mMods
      Dim curmod = kv.Value
      If gID = curmod.ModGenerator.Id.GuidID Then outmods.Add(curmod)

    Next
    Return outmods
  End Function
  Public Function GetModsByType(themodtype As eModifierType) As ModifierList
    CheckSort()

    Dim outmods As New ModifierList

    For Each kv As KeyValuePair(Of Guid, Modifier) In mMods
      Dim currmod = kv.Value

      If currmod.ModifierType = themodtype Then outmods.Add(currmod)
    Next

    Return outmods
  End Function

  Public Function GetAvailableModifierTypesForGame(thegame As dGame) As List(Of eModifierType)
    Dim outlist As New List(Of eModifierType)

    For Each kv As KeyValuePair(Of Guid, Modifier) In mMods
      If Not outlist.Contains(kv.Value.ModifierType) And thegame.GameContainsUnit(kv.Value.Parent) Then
        outlist.Add(kv.Value.ModifierType)
      End If

    Next
    outlist.Sort()
    Return outlist
  End Function



#End Region

  Private Function DictValueSortDesc(SourceDictionary As Dictionary(Of Guid, Modifier)) As Dictionary(Of Guid, Modifier)

    ''TEMP
    'Return SourceDictionary
    'Do a Dictionary Sort on the Value Highest to lowest

    Dim outDict As New Dictionary(Of Guid, Modifier)
    Dim currentminKey As Guid = Guid.Empty
    Dim currentminValue As Modifier = Nothing

    Do Until SourceDictionary.Keys.Count < 1
      'find smallest key currently in dict
      For Each kv As KeyValuePair(Of Guid, Modifier) In SourceDictionary
        If currentminKey = Guid.Empty Then currentminKey = kv.Key
        If currentminValue Is Nothing Then currentminValue = kv.Value

        If String.Compare(kv.Key.ToString, currentminKey.ToString) < 0 Then
          currentminKey = kv.Key
          currentminValue = kv.Value
        End If

      Next

      outDict.Add(currentminKey, currentminValue)
      SourceDictionary.Remove(currentminKey)

      currentminKey = Nothing
      currentminValue = Nothing



    Loop


    Return outDict

  End Function
  Private Sub CheckSort()
    If Not isSorted Then
      mMods = DictValueSortDesc(mMods)
      isSorted = True
    End If
  End Sub

  Private Sub BroadcastChangedModsnStats(thestats As List(Of Stat), themods As ModifierList)

    Dim outmods As New Dictionary(Of Guid, List(Of eModifierType))
    Dim outstats As New Dictionary(Of Guid, List(Of eStattype))

    If Not themods Is Nothing Then
      If Not themods.Count < 1 Then
        For i As Integer = 0 To themods.Count - 1
          Dim curmod = themods.Item(i)

          Dim themodtype = curmod.ModifierType
          Dim theparent = curmod.Parent.Id.GuidID
          Dim thetargets = Helpers.GetAffectedUnitsForMod(curmod, mGame) 'dbNames, mTimekeeper)

          'add parents affected by mod
          If outmods.ContainsKey(theparent) Then
            Dim curlist = outmods.Item(theparent)
            If Not curlist.Contains(themodtype) Then
              curlist.Add(themodtype)
            End If
          Else
            Dim outlist As New List(Of eModifierType)
            outlist.Add(themodtype)
            outmods.Add(theparent, outlist)
          End If

          'add targets affected by mod
          For x As Integer = 0 To thetargets.Count - 1
            Dim curtarget = thetargets.Item(x).Id.GuidID

            If outmods.ContainsKey(curtarget) Then
              Dim curlist = outmods.Item(curtarget)
              If Not curlist.Contains(themodtype) Then
                curlist.Add(themodtype)
              End If
            Else
              Dim outlist As New List(Of eModifierType)
              outlist.Add(themodtype)
              outmods.Add(curtarget, outlist)
            End If

          Next

          'add stats affected by mod
          Dim dirtystats = dbFormulas.GetStatsDependentOnMod(curmod.ModifierType)
          If Not dirtystats Is Nothing Then
            For y As Integer = 0 To dirtystats.Count - 1
              Dim curstat = dirtystats.Item(y)
              If outstats.ContainsKey(theparent) Then
                Dim curlist = outstats.Item(theparent)
                If Not curlist.Contains(curstat) Then
                  curlist.Add(curstat)
                End If
              Else
                Dim outlist As New List(Of eStattype)
                outlist.Add(curstat)
                outstats.Add(theparent, outlist)
              End If

            Next
          End If

        Next
      End If
    End If


    'go through supplied stats
    If Not thestats Is Nothing Then
      For z As Integer = 0 To thestats.Count - 1
        Dim curstat = thestats.Item(z)
        Dim parent = curstat.ParentGameEntity.Id.GuidID
        If outstats.ContainsKey(parent) Then
          Dim curlist = outstats.Item(parent)
          If Not curlist.Contains(curstat.StatType) Then
            curlist.Add(curstat.StatType)
          End If
        Else
          Dim newlist As New List(Of eStattype)
          newlist.Add(curstat.StatType)
          outstats.Add(parent, newlist)
        End If

        'go through any stats that may be dependent on our stats
        Dim morestats = dbFormulas.GetStatsDependentonStat(curstat.StatType)
        If Not morestats Is Nothing Then
          For a As Integer = 0 To morestats.Count - 1
            Dim curstattype = morestats.Item(a)
            Dim theparent = curstat.ParentGameEntity.Id.GuidID
            If outstats.ContainsKey(parent) Then
              Dim curlist = outstats.Item(parent)
              If Not curlist.Contains(curstattype) Then
                curlist.Add(curstattype)
              End If
            Else
              Dim newerlist As New List(Of eStattype)
              newerlist.Add(curstattype)
              outstats.Add(theparent, newerlist)

            End If
          Next
        End If



      Next
    End If


    If Not outmods.Count < 1 Or Not outstats.Count < 1 Then
      RaiseEvent Modschanged(New TypesAndTargets(outmods, outstats))
    End If


  End Sub





End Class

