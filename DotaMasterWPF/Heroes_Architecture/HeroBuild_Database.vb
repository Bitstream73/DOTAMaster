Imports System.IO
Imports System.IO.IsolatedStorage
Imports System.Windows.Media.Imaging
Public Class HeroBuild_Database
  'Inherits Dictionary(Of eHeroName, Hero)

  Private mHeros As New Dictionary(Of eHeroName, Hero)

  'change builds to herobuilds so they are newed on calls for them in getherbuild

  Private mHeroBuilds As New Dictionary(Of dvID, HeroBuild) 'string is dvID ID
  Private mBuildIDs As New Dictionary(Of eHeroName, List(Of dvID)) 'string is dvID ID that is key for Me.Dictionary

  'clone stuff
  Private mCloneHeroBuilds As New Dictionary(Of dvID, HeroBuild)
  Private mCloneBuildIDs As New Dictionary(Of eHeroName, List(Of dvID))

  Private mFriendlyNames As New Dictionary(Of eHeroName, String)



  Private mstartupbuilds As Build_List
  Private mHBundles As HeroBundles


  'Disk Stuff
  Private mBuildsFolder As String = "Builds"
  Private mClonesFolder As String = "WiP"


  'Menus and bitmaps
  Private EnumItems As Array


  Private dbItems As item_Database
  Private dbAbilities As ability_Database

  Private dbColors As Colors_Database
  Private dbFormulas As Formula_Database
  Private dbNames As FriendlyName_Database

  Private mTimekeeper As TimeKeeper

  Private mLog As iLogging
  Private dbImages As Image_Database

  Public Sub New() ' builds As Hero_Build_List,  bundles As HeroBundles)
    LoadFriendlyNames()
    EnumItems = System.Enum.GetValues(GetType(eHeroName))

  End Sub

  Public Sub load(itemdb As item_Database, abilitydb As ability_Database, _
                  time As TimeKeeper, _
                  colordb As Colors_Database, _
                  formuladb As Formula_Database, namedb As FriendlyName_Database, _
                 imagedb As Image_Database, log As iLogging)

    mLog = log
    dbImages = imagedb
    dbItems = itemdb
    dbAbilities = abilitydb


    dbColors = colordb
    dbFormulas = formuladb
    dbNames = namedb

    mTimekeeper = time
    'mGame = thegame







    mTimekeeper = time


    'clear out clones from last session
    ClearClones()
    mHBundles = New HeroBundles

    ''------------DON"T DELETE------------- builds default empty herobuilds

    For Each Item In EnumItems
      Dim outtype As eHeroName = DirectCast([Enum].Parse(GetType(eHeroName), Item, True), eHeroName)

      If Not outtype = eHeroName.None Then

        Dim thebundle As HeroBundle = mHBundles.Item(outtype)
        LoadHeroInMemory(thebundle)
      End If

    Next

    mstartupbuilds = GetAllBuildsFromDisk()

    For i As Integer = 0 To mstartupbuilds.Count - 1
      Dim thebuild As Build = mstartupbuilds.Item(i)


      LoadBuildInMemory(thebuild)

    Next


  End Sub

#Region "Disk Stuff"

  ''' <summary>
  ''' new dvID is only changed if we are writing a clone, set as nothing uses thebuild.id
  ''' </summary>
  ''' <param name="thebuild"></param>
  ''' <param name="thefolder"></param>
  ''' <param name="thenewdvID"></param>
  ''' <remarks></remarks>
  Private Sub WriteBuildToDisc( thebuild As Build,  thefolder As String, _
                                thenewdvID As dvID, _
                                theparentdvID As dvID, thechilddvID As dvID)
    Dim outdvID = thenewdvID

    If outdvID.ToString.Contains("0000") Then
      Dim x = 2
    End If
    If thebuild.mUniqueName = "ab2" Then
      Dim x = 2
    End If

  
    Dim thepath As String = Constants.cRootPath & "\" & thefolder & "\" & thebuild.GetFileName(thenewdvID)


    Try
      If Not Directory.Exists(Constants.cRootPath & thefolder) Then
        Directory.CreateDirectory(Constants.cRootPath & thefolder)
      End If


      Using writer As StreamWriter = New StreamWriter(thepath, False)
        writer.WriteLine(thebuild.mUniqueName.Trim)
        writer.WriteLine(outdvID.GuidID.ToString.Trim)
        writer.WriteLine(theparentdvID.GuidID.ToString.Trim)
        If Not thechilddvID Is Nothing Then
          writer.WriteLine(thechilddvID.GuidID.ToString.Trim)
        Else
          writer.WriteLine("00000000-0000-0000-0000-000000000000")
        End If

        writer.WriteLine(thebuild.mHeroType.ToString)
        writer.WriteLine(thebuild.PriorityLevel.ToString)
        Dim itemstring As String = "Items|"
        If Not thebuild.ItemList Is Nothing Then
          For i As Integer = 0 To thebuild.ItemList.Count - 1
            Dim theitem = thebuild.ItemList.Item(i)

            If Not theitem Is Nothing Then
              If i = thebuild.ItemList.Count - 1 Then
                itemstring += GetItemWithBuildsFromString(theitem)
              Else
                itemstring += GetItemWithBuildsFromString(theitem) & "|"
              End If
            End If

          Next
        End If


        writer.WriteLine(itemstring)


        Dim abilitystring As String = "Abilities|"

        For i As Integer = 0 To thebuild.mAbilityBuildOrderByUIPosition.Count - 1
          If Not i = thebuild.mAbilityBuildOrderByUIPosition.Count - 1 Then

            abilitystring += thebuild.mAbilityBuildOrderByUIPosition.Item(i).ToString & "|"

          Else
            abilitystring += thebuild.mAbilityBuildOrderByUIPosition.Item(i).ToString
          End If
        Next


        writer.WriteLine(abilitystring)


       
      End Using

    Catch ex As Exception
      Dim x = 2
    End Try
  End Sub


  Private Function GetItemWithBuildsFromString(theitem As Item_Info) As String
    Dim outstring = theitem.ItemName.ToString & "," & theitem.Id.GuidID.ToString & "," & theitem.ItemPlan.ToString & "," & theitem.ParentGameEntity.Id.GuidID.ToString

    If theitem.ItemIsDisassembled Then
      'Dim thecomps = dbItems.CreateItemInstances(theitem.mBuildsFromNames, theitem.ParentID, Constants.cDefaultLifetime)
      Dim thecomps = theitem.GetBuildsFromItem_Infos(dbItems)
      For i As Integer = 0 To thecomps.Count - 1
        Dim thecomp = thecomps.Item(i)
        outstring += "|" & thecomp.ItemName.ToString & "," & thecomp.Id.GuidID.ToString & "," & thecomp.ItemPlan.ToString & "," & thecomp.ParentGameEntity.Id.GuidID.ToString
      Next
    End If

    Return outstring
  End Function




  Private Function ReadBuildFromDisc( foldername As String,  thedvID As dvID) As Build
    Dim thefiles = Directory.GetFiles(Constants.cRootPath & "\" & foldername & "\", "*.bld")
    Dim outbuild As Build
    For i As Integer = 0 To thefiles.Count - 1
      Dim thefile = thefiles(i)
      If thefile.Contains(thedvID.GuidID.ToString) Then

        outbuild = ReadBuildFromDisc(thefile)
        Return outbuild
      End If
    Next
    Return Nothing
  End Function
  Private Function ReadBuildFromDisc( nameandpath As String) As Build

    If (File.Exists(nameandpath)) Then


      Using reader As StreamReader = New StreamReader(nameandpath)
        Dim outname As String = reader.ReadLine().Trim()
        If outname = "AA1" Then
          Dim x = 2
        End If
        Dim outID As Guid = New Guid(reader.ReadLine.Trim)

        If outID.ToString.Contains("15d9a52e") Then
          Dim x = 2
        End If

        Dim outPID As Guid = New Guid(reader.ReadLine.Trim)
        Dim outCID As Guid = New Guid(reader.ReadLine.Trim)
        Dim outtype As eHeroName = DirectCast([Enum].Parse(GetType(eHeroName), reader.ReadLine().Trim(), True), eHeroName)
        Dim outprio As ePriorityGoldXP = DirectCast([Enum].Parse(GetType(ePriorityGoldXP), reader.ReadLine().Trim(), True), ePriorityGoldXP)

        Dim itemstrings = reader.ReadLine().Split("|")
        Dim outitems As New Item_List

        Dim theitem As Item_Info


        If itemstrings.Count > 1 And Not itemstrings(1) = "" Then
          For i As Integer = 1 To itemstrings.Count - 1
            Dim thequatro = itemstrings(i).Split(",")

            Dim itemname = DirectCast([Enum].Parse(GetType(eItemname), thequatro(0), True), eItemname)
            Dim thepID As New dvID(outPID, "HeroBuild_Database/ReadBuildFromDisc: Adding Item " & itemname, eEntity.Item_Info)

            Dim itemguid As Guid = New Guid(thequatro(1))
            Dim itemid = New dvID(itemguid, "HeroBuild_Database/ReadBuildFromDisc: " & itemname.ToString, eEntity.Item_Info)
            theitem = dbItems.CreateItemInstance(itemid, itemname, Nothing, Constants.cDefaultLifetime)


            Dim theItemPlan = DirectCast([Enum].Parse(GetType(eItemPlan), thequatro(2), True), eItemPlan)
            theitem.ItemPlan = theItemPlan

            If theitem.ItemPlan = eItemPlan.Disassemble Then
              theitem.ItemIsDisassembled = True
            End If
    

            outitems.AddItem(theitem)
          Next
        End If

        Dim outabs As String = reader.ReadLine()

        Dim dID As New dvID(outID, "HeroBuild_Database/ReadBuildFromDisc", eEntity.Build)
        Dim pID As New dvID(outPID, "HeroBuild_Database/ReadBuildFromDisc: ParentID", eEntity.Hero_Instance)


        Return New Build(dID, pID, pID, outname, outtype, outitems, outabs, outprio)
      End Using



    End If
    Return Nothing
  End Function


  Public Function GetAbilitiesForHero( thehero As eHeroName) As List(Of eAbilityName)

    Return mHeros.Item(thehero).AbilityNames
  End Function

  Private Function GetAllBuildsFromDisk() As Build_List

    Dim thefiles = Directory.GetFiles(Constants.cRootPath & "\" & mBuildsFolder & "\", "*.bld")

    Dim outlist As New Build_List()

    For i As Integer = 0 To thefiles.Count - 1



      outlist.Add(ReadBuildFromDisc(thefiles(i)))
    Next

    Return outlist
  End Function

  Private Sub ClearClones()
    Dim thefiles = Directory.GetFiles(Constants.cRootPath & "\" & mClonesFolder & "\", "*.bld")
    For i As Integer = 0 To thefiles.Count - 1
      File.Delete(thefiles(i))
    Next
  End Sub

  'Private Function FolderContainsBuild( thebuild As Build,  thefoldername As String) As Boolean
  '  Dim thefiles = mIsostore.GetFileNames("\" & thefoldername & "\" & "*.bld")
  '  Dim folderbuild As Build

  '  For i As Integer = 0 To thefiles.Count - 1
  '    If thefiles(i).fi Then
  '  Next
  'End Function
  Private Function ContainsBuild( heroname As eHeroName,  theiditem As dvID,  hbuildlist As Dictionary(Of dvID, HeroBuild)) As Boolean
    For Each hbuild As KeyValuePair(Of dvID, HeroBuild) In hbuildlist
      If hbuild.Value.mBuild.IDItem Is theiditem Then
        If hbuild.Value.mBuild.mHeroType = heroname Then
          Return True
        End If

      End If
    Next
    Return False
  End Function


  Private Sub AddCloneBuild( theclonebuild As Build,  thedvID As dvID, _
                             thexpcurev As EconomyCurve,  thegoldcurve As EconomyCurve, _
                             thegame As dGame)


    If mCloneHeroBuilds.ContainsKey(theclonebuild.IDItem) Then
      mCloneHeroBuilds.Remove(theclonebuild.IDItem)
      DeleteBuildFromDisc(theclonebuild.mHeroType, theclonebuild.mUniqueName, mClonesFolder)
    End If

    Dim h As Hero = mHeros.Item(theclonebuild.mHeroType)
    Dim hb As New HeroBuild(h, theclonebuild, thexpcurev, thegoldcurve)

    mCloneHeroBuilds.Add(theclonebuild.IDItem, hb)


    If mCloneBuildIDs.ContainsKey(theclonebuild.mHeroType) Then
      Dim clbuilds = mCloneBuildIDs.Item(theclonebuild.mHeroType)
      If Not clbuilds.Contains(theclonebuild.IDItem) Then
        clbuilds.Add(theclonebuild.IDItem)
      End If
    Else
      Dim outlist As New List(Of dvID)
      outlist.Add(theclonebuild.IDItem)
      mCloneBuildIDs.Add(theclonebuild.mHeroType, outlist)
    End If

  End Sub

  Private Sub DeleteFile( thefolder As String,  thefilename As String)
    Dim thepath = Constants.cRootPath & "\" & thefolder & "\" & thefilename
    If (File.Exists(thepath)) Then
      File.Delete(thepath)
    End If
  End Sub
#End Region

  Private Sub DeleteBuildFromDisc( heroname As eHeroName,  buildname As String,  foldername As String)
    Dim thefiles = Directory.GetFiles(Constants.cRootPath & "\" & mBuildsFolder & "\", "*.bld")

    For i As Integer = 0 To thefiles.Count - 1
      Dim thefile = thefiles(i)
      If thefile.Contains(heroname.ToString) Then
        If thefile.Contains(buildname) Then
          File.Delete(Constants.cRootPath & "\" & mBuildsFolder & "\" & thefile)
        End If
      End If
    Next
  End Sub

  Private Sub DeleteBuildFromDisc( thedvID As dvID,  thefolder As String)
    Dim thefiles = Directory.GetFiles(Constants.cRootPath & "\" & thefolder & "\", "*.bld")
    Dim strdvID As String = thedvID.ToString
    For i As Integer = 0 To thefiles.Count - 1
      Dim thefile = thefiles(i)
      If thefile.Contains(strdvID.ToString) Then

        File.Delete("\" & thefolder & "\" & thefile)
        Exit Sub
      End If
    Next
  End Sub

  Private Sub DeleteBuildFromMemory( thedvID As dvID)
    If mHeroBuilds.ContainsKey(thedvID) Then
      mHeroBuilds.Remove(thedvID)
    End If

    Dim curlist As List(Of dvID)
    For i As Integer = 0 To mBuildIDs.Count - 1
      curlist = mBuildIDs.Item(i)
      If curlist.Contains(thedvID) Then curlist.Remove(thedvID)
    Next


  End Sub

  Private Sub DeleteBuildFromCloneMemory( theclonedvID As dvID)
    If mCloneHeroBuilds.ContainsKey(theclonedvID) Then
      mCloneHeroBuilds.Remove(theclonedvID)
    End If

    Dim curlist As List(Of dvID)
    For Each dvIDlist As KeyValuePair(Of eHeroName, List(Of dvID)) In mCloneBuildIDs
      'For i As Integer = mCloneBuildIDs.Count - 1 To 0 Step -1
      curlist = dvIDlist.Value
      If curlist.Contains(theclonedvID) Then curlist.Remove(theclonedvID)
    Next

  End Sub
  Private Sub DeleteBuildFromMemory( theheroname As eHeroName,  thebuildname As String)
    'If mBuilds.ContainsKey(thedvID) Then
    '  mBuilds.Remove(thedvID)
    'End If
    Dim curhbuild As HeroBuild = Nothing
    For Each hbuild As KeyValuePair(Of dvID, HeroBuild) In mHeroBuilds
      If hbuild.Value.mHero.Name = theheroname Then
        If hbuild.Value.mBuild.mUniqueName = thebuildname Then

          curhbuild = hbuild.Value

        End If
      End If
    Next

    If Not curhbuild Is Nothing Then
      mHeroBuilds.Remove(curhbuild.ID)

      Dim curlist As List(Of dvID)
      For i As Integer = 0 To mBuildIDs.Count - 1
        curlist = mBuildIDs.Item(i)
        If curlist.Contains(curhbuild.ID) Then curlist.Remove(curhbuild.ID)
      Next
    End If

  End Sub


  Private Function FolderContainsBuild( foldername As String,  thedvID As dvID) As Boolean

    Dim thefiles = Directory.GetFiles(Constants.cRootPath & "\" & foldername & "\", "*.bld")

    For i As Integer = 0 To thefiles.Count - 1
      Dim thefile = thefiles(i)
      If thefile.Contains(thedvID.ToString) Then

        Return True

      End If
    Next
    Return False
  End Function

#Region "HeroBuild Stuff"



  Private Sub LoadBuildInMemory( thebuild As Build)
    'If thebuild.mHeroType = eHeroName.untEarthshaker Then
    '  Dim x = 2
    'End If
    If ContainsBuild(thebuild.mHeroType, thebuild.IDItem, mHeroBuilds) Then
      'DeleteBuildFile(thebuild.mHeroType, thebuild.mUniqueName)
      'If mBuilds.ContainsKey(thebuild.ID) Then
      '  Dim x = 2
      'End If
      mHeroBuilds.Remove(thebuild.IDItem)
    End If

    'If thebuild.mUniqueName.Contains("New") And thebuild.mHeroType = eHeroName.untEarthshaker Then
    '  Dim x = 2
    'End If

    Dim h As Hero = mHeros.Item(thebuild.mHeroType)
    Dim hb As New HeroBuild(h, thebuild, Nothing, Nothing)
    mHeroBuilds.Add(thebuild.IDItem, hb)


    If mBuildIDs.ContainsKey(thebuild.mHeroType) Then
      Dim hbuilds = mBuildIDs.Item(thebuild.mHeroType)
      If Not hbuilds.Contains(thebuild.IDItem) Then
        hbuilds.Add(thebuild.IDItem)
      End If
    Else
      Dim outlist As New List(Of dvID)
      outlist.Add(thebuild.IDItem)
      mBuildIDs.Add(thebuild.mHeroType, outlist)
    End If


  End Sub
  Private Sub LoadHeroInMemory( thebundle As HeroBundle)
    Dim newhero As Hero
    Select Case thebundle.mAbilityNames.Count
      Case 4
        newhero = New Hero(thebundle.mName.ToString, thebundle, _
                                thebundle.mAbilityNames.Item(0), thebundle.mAbilityNames.Item(1), _
                                thebundle.mAbilityNames.Item(2), thebundle.mAbilityNames.Item(3))

      Case 5
        newhero = New Hero(thebundle.mName.ToString, thebundle, _
                              thebundle.mAbilityNames.Item(0), thebundle.mAbilityNames.Item(1), _
                              thebundle.mAbilityNames.Item(2), thebundle.mAbilityNames.Item(3), _
                              thebundle.mAbilityNames.Item(4))

      Case 6
        newhero = New Hero(thebundle.mName.ToString, thebundle, _
                              thebundle.mAbilityNames.Item(0), thebundle.mAbilityNames.Item(1), _
                              thebundle.mAbilityNames.Item(2), thebundle.mAbilityNames.Item(3), _
                              thebundle.mAbilityNames.Item(4), thebundle.mAbilityNames.Item(5))

      Case 7
        newhero = New Hero(thebundle.mName.ToString, thebundle, _
                              thebundle.mAbilityNames.Item(0), thebundle.mAbilityNames.Item(1), _
                              thebundle.mAbilityNames.Item(2), thebundle.mAbilityNames.Item(3), _
                              thebundle.mAbilityNames.Item(4), thebundle.mAbilityNames.Item(5), _
                              thebundle.mAbilityNames.Item(6))

      Case 8
        newhero = New Hero(thebundle.mName.ToString, thebundle, _
                              thebundle.mAbilityNames.Item(0), thebundle.mAbilityNames.Item(1), _
                              thebundle.mAbilityNames.Item(2), thebundle.mAbilityNames.Item(3), _
                              thebundle.mAbilityNames.Item(4), thebundle.mAbilityNames.Item(5), _
                              thebundle.mAbilityNames.Item(6), thebundle.mAbilityNames.Item(7))

      Case 9
        newhero = New Hero(thebundle.mName.ToString, thebundle, _
                              thebundle.mAbilityNames.Item(0), thebundle.mAbilityNames.Item(1), _
                              thebundle.mAbilityNames.Item(2), thebundle.mAbilityNames.Item(3), _
                              thebundle.mAbilityNames.Item(4), thebundle.mAbilityNames.Item(5), _
                              thebundle.mAbilityNames.Item(6), thebundle.mAbilityNames.Item(7), _
                              thebundle.mAbilityNames.Item(8))

      Case 10
        newhero = New Hero(thebundle.mName.ToString, thebundle, _
                              thebundle.mAbilityNames.Item(0), thebundle.mAbilityNames.Item(1), _
                              thebundle.mAbilityNames.Item(2), thebundle.mAbilityNames.Item(3), _
                              thebundle.mAbilityNames.Item(4), thebundle.mAbilityNames.Item(5), _
                              thebundle.mAbilityNames.Item(6), thebundle.mAbilityNames.Item(7), _
                              thebundle.mAbilityNames.Item(8), thebundle.mAbilityNames.Item(9))


      Case 14
        newhero = New Hero(thebundle.mName.ToString, thebundle, _
                             thebundle.mAbilityNames.Item(0), thebundle.mAbilityNames.Item(1), _
                             thebundle.mAbilityNames.Item(2), thebundle.mAbilityNames.Item(3), _
                             thebundle.mAbilityNames.Item(4), thebundle.mAbilityNames.Item(5), _
                             thebundle.mAbilityNames.Item(6), thebundle.mAbilityNames.Item(7), _
                             thebundle.mAbilityNames.Item(8), thebundle.mAbilityNames.Item(9), _
                             thebundle.mAbilityNames.Item(10), thebundle.mAbilityNames.Item(11), _
                             thebundle.mAbilityNames.Item(12))

      Case Else
        Dim x = 2
        newhero = Nothing
    End Select

    If Not newhero Is Nothing Then
      If Not mHeros.ContainsKey(newhero.Name) Then
        Me.mHeros.Add(newhero.Name, newhero)
      End If

    End If


    'If Not newhero Is Nothing Then
    '  If mBuildIDs.ContainsKey(newhero.Name) Then
    '    Dim herobuilds = mBuildIDs.Item(newhero.Name)
    '    If Not herobuilds.Contains(newhero.UniqueName) Then
    '      herobuilds.Add(newhero.UniqueName)

    '    End If
    '  End If
    'End If

    'temp to write default builds
    'PageHandler.mSettings.WriteBuild(thebuild)

  End Sub

  'Public Function GetHeroBuild( thehero As eHeroName,  thebuildname As String) As HeroBuild
  '  ' Dim thebuild = GetBuild(thebuildname)
  '  Return GetHeroFromBuild(thebuild)
  'End Function

  ''' <summary>
  ''' returns nothing if id is not in database
  ''' </summary>
  ''' <param name="thebuildindex"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function GetHeroBuild( thebuildindex As Integer) As HeroBuild
    Dim currindex = 0
    For Each hbuild As KeyValuePair(Of dvID, HeroBuild) In mHeroBuilds
      If currindex = thebuildindex Then Return hbuild.Value
      currindex += 1
    Next
    Return Nothing
  End Function

  'Public Function ContainsHeroBuild( theid As dvID) As Boolean
  '  For Each hbuild As KeyValuePair(Of dvID, HeroBuild) In mHeroBuilds

  '    If hbuild.Value.ID.GuidID = theid.GuidID Then Return True
  '  Next

  '  Return False
  'End Function

  Public Function GetNonNewHeroBuild( heroname As eHeroName) As HeroBuild
    Dim currindex = 0
    Dim builds = GetHeroBuilds(heroname)

    For i As Integer = 0 To builds.Count - 1
      If Not builds.Item(i).mUniqueName = "New" Then Return GetHeroBuild(builds.Item(i).IDItem)
    Next
    Return Nothing
  End Function
  Public Function GetHeroBuild( theiditem As dvID) As HeroBuild
    If theiditem Is Nothing Then Return Nothing
    If mHeroBuilds.ContainsKey(theiditem) Then

      Return mHeroBuilds.Item(theiditem)
    End If

    If mCloneHeroBuilds.ContainsKey(theiditem) Then
      Return mCloneHeroBuilds.Item(theiditem)
    End If
    Return Nothing
  End Function


  'Private Function GetHeroFromBuild( thebuild As Build) As HeroBuild
  '  Dim thehero = mHeros.Item(thebuild.mHeroType)

  '  Return New HeroBuild(mHeros.Item(thebuild.mHeroType), thebuild)
  'End Function

  Public Function CreateCloneHeroBuild( theid As dvID, _
                                        thexpcurve As EconomyCurve,  thegoldcureve As EconomyCurve, _
                                        thegame As dGame) As HeroBuild
    ' Dim thehero = GetHeroBuild(theid)


    'If mCloneHeroBuilds.ContainsKey(theid) Then

    '  Return mCloneHeroBuilds.Item(theid)

    'Else 'gotta create a clone
    Dim hbuild As HeroBuild
    If mHeroBuilds.ContainsKey(theid) Then
      hbuild = mHeroBuilds.Item(theid)
    End If
    If mCloneHeroBuilds.ContainsKey(theid) Then
      hbuild = mCloneHeroBuilds.Item(theid)
    End If

    If Not hbuild Is Nothing Then
      Dim clonedvID As New dvID(Guid.NewGuid, "HeroBuild_Database/CreateCloneHeroBuild", eEntity.Build)

      hbuild.mBuild.ChildIDItem = clonedvID

      WriteBuildToDisc(hbuild.mBuild, mClonesFolder, clonedvID, hbuild.ID, New dvID(Nothing, "No Child", eEntity.Build))
      Dim cbuild = ReadBuildFromDisc(mClonesFolder, clonedvID)


      AddCloneBuild(cbuild, cbuild.IDItem, thexpcurve, thegoldcureve, thegame)

      Return mCloneHeroBuilds.Item(cbuild.IDItem)
    Else
      Throw New NotImplementedException
    End If


    'Return Nothing

    'End If


  End Function

  Public Function GetFirstBuildForAllHeroes() As List(Of HeroBuild)

    Dim EnumItems = System.Enum.GetValues(GetType(eHeroName))
    Dim ti As New Stopwatch
    Dim ti2 As New Stopwatch
    Dim ind As Integer = 0
    ti2.Start()
    Dim outlist As New List(Of HeroBuild)
    For Each heroname In EnumItems
      ti.Reset()
      ti.Start()
      If Not heroname = eHeroName.None Then
        Dim theherobuild = GetFirstBuildForHero(heroname)


        outlist.Add(theherobuild)
      End If
      ti.Stop()
      ' mLog.WriteLog(ind.ToString & " t: " & ti.ElapsedTicks)
      ind += 1
    Next
    ti2.Stop()
    mLog.WriteLog("Total for GetFirstBuildForAllHeroes: " & ti2.ElapsedMilliseconds & " Milliseconds")
    Return outlist
  End Function

  Public Function GetFirstBuildForHero( thehero As eHeroName) As HeroBuild


    Dim thebuildIDs = mBuildIDs.Item(thehero)
    Dim hbuild = mHeroBuilds.Item(thebuildIDs.Item(0))
    Return hbuild
    'For Each chero As KeyValuePair(Of String, Hero) In Me
    '  If chero.Value.Name = thehero Then
    '    Return chero.Value
    '  End If
    'Next
    Return Nothing
  End Function

  Public Function GetAllHeroBuilds() As HeroBuild_List
    Dim outlist As New HeroBuild_List
    For Each hbuild As KeyValuePair(Of dvID, HeroBuild) In mHeroBuilds

      outlist.Add(hbuild.Value)
    Next

    outlist.Sort()
    Return outlist
    'Dim outlist As New Build_List

    'For Each build As KeyValuePair(Of String, Hero) In Me
    '  outlist.Add(build.Value.mBuild)
    'Next
    'Return outlist
  End Function



  'Public Function GetBuildModifiers( thebuildid As dvID) As ModifierList 'presumed to be all passive?
  '  Dim thebuild As HeroBuild = GetHeroBuild(thebuildid)

  '  Return thebuild.get
  'End Function

  'Public Function GetHeroBuildModifiers( thebuildID As dvID) As ModifierList 'presumed to be all passive?
  '  Dim thehbuild As HeroBuild = GetHeroBuild(thebuildID)

  '  Dim outlist As ModifierList = thehbuild.mBuild.GetBuildModifiers '0 is actives, 1 is passives

  '  'Dim passives = outlist.Item(1)
  '  'passives.AddList(thehbuild.mHero.GetHeroModifiers)

  '  Return outlist

  'End Function
#End Region

#Region "Build Stuff"
  'Private Function GetBuild( thebuildname As String) As Build
  '  For Each hbuild As KeyValuePair(Of dvID, HeroBuild) In mHeroBuilds
  '    If thebuild.Value.mbuild.mUniqueName = thebuildname Then Return hbuild.Value.mBuild
  '  Next
  '  Return Nothing
  'End Function

  Public Sub SaveBuild( theclonebuild As Build)

    'Dim newid As New dvID(Guid.NewGuid(), "HeroBuild_Database/SaveBuild")

    ' DeleteCloneBuild(theclonebuild)
    'DeleteBuildFromDisc(theclonebuild.mHeroType, theclonebuild.mUniqueName, mBuildsFolder)
    ' DeleteBuildFromMemory(theclonebuild.mHeroType, theclonebuild.mUniqueName)

    'delete any old versions in builds folder
    DeleteBuildFromDisc(theclonebuild.mHeroType, theclonebuild.mUniqueName, mBuildsFolder)
    DeleteBuildFromMemory(theclonebuild.mHeroType, theclonebuild.mUniqueName)

    'Update clone on disk to state in memory, delete from WiP and add to bulds.
    WriteBuildToDisc(theclonebuild, mBuildsFolder, theclonebuild.IDItem, theclonebuild.ParentIDItem, Nothing)
    DeleteBuildFromDisc(theclonebuild.IDItem, mClonesFolder)
    LoadBuildInMemory(theclonebuild)
    DeleteBuildFromCloneMemory(theclonebuild.IDItem)

    'MoveCloneToBuilds(theclonebuild, mBuildsFolder)
    'WriteBuildToDisc(theclonebuild, mBuildsFolder, newid, theclonebuild.ID, Nothing)
    'Dim newbuild = ReadBuildFromDisc(mBuildsFolder, newid)
    ' LoadBuildInMemory(newbuild)
  End Sub
  'Private Function DeleteCloneBuild( theclonebuild As Build)
  '  If mCloneBuildIDs.ContainsKey(theclonebuild.mHeroType) Then
  '    Dim theclbuilds = mCloneBuildIDs.Item(theclonebuild.mHeroType)
  '    If theclbuilds.Contains(theclonebuild.ID) Then
  '      theclbuilds.Remove(theclonebuild.ID)
  '      mCloneBuilds.Remove(theclonebuild.ID)
  '      Try

  '        DeleteFile(mClonesFolder, theclonebuild.mHeroType.ToString & "-" & theclonebuild.ID.ToString & ".bld")

  '      Catch ex As Exception
  '        Dim x = 2
  '      End Try

  '    End If

  '  End If


  'End Function

  'Private Function GetBuild( theid As dvID) As Build
  '  Return mHeroBuilds.Item(theid).mBuild
  'End Function

  Public Function GetBuildListItems( thehero As eHeroName) As Build_Listitem_list
    Dim thebuilds = Me.GetHeroBuilds(thehero)
    Dim outlist As New Build_Listitem_list
    For i As Integer = 0 To thebuilds.Count - 1
      Dim newitem As New ctrlBuild_List_Item(thebuilds.Item(i).mUniqueName, thebuilds.Item(i))
      outlist.Add(newitem)
    Next
    outlist = outlist.GetSortedList()

    Return outlist
  End Function

  Public Function GetHeroBuilds( friendlyheroname As String) As Build_List
    Dim sysname As eHeroName = GetSystemName(friendlyheroname)
    Return Me.GetHeroBuilds(sysname)
  End Function

  Public Function GetHeroBuilds( systemheroname As eHeroName) As Build_List
    Dim outlist As New Build_List()
    Dim buildIDs = mBuildIDs.Item(systemheroname)

    For i As Integer = 0 To buildIDs.Count - 1
      If mHeroBuilds.ContainsKey(buildIDs.Item(i)) Then
        Dim hbuild = mHeroBuilds.Item(buildIDs.Item(i))
        outlist.Add(hbuild.mBuild)
      Else
        Dim x = 2
      End If


    Next

    Return outlist
    'For Each theHero As KeyValuePair(Of String, Hero) In Me
    '  If theHero.Value.Name = systemheroname Then
    '    outlist.Add(theHero.Value.mBuild)
    '  End If
    'Next
    'Return outlist
  End Function
#End Region

#Region "Name Stuff"
  Private Sub LoadFriendlyNames()
    'mFriendlyName =s.Add(eHeroName.untEarthshaker, "Earthshaker")
    'mFriendlyName =s.Add(eHeroName.untSven, "Sven")
    'mFriendlyName =s.Add(eHeroName.untTiny, "Tiny")
    'mFriendlyName =s.Add(eHeroName.untKunkka, "Kunkka")
    'mFriendlyName =s.Add(eHeroName.untBeastmaster, "Beastmaster")
    'mFriendlyName =s.Add(eHeroName.untDragon_Knight, "Dragon Knight")
    'mFriendlyName =s.Add(eHeroName.untClockwerk, "Clockwerk")
    'mFriendlyName =s.Add(eHeroName.untOmniknight, "Omniknight")
    'mFriendlyName =s.Add(eHeroName.untHuskar, "Huskar")
    'mFriendlyName =s.Add(eHeroName.untAlchemist, "Alchemist")
    'mFriendlyName =s.Add(eHeroName.untBrewmaster, "Brewmaster")
    'mFriendlyName =s.Add(eHeroName.untTreant_Protector, "Treant Protector")
    'mFriendlyName =s.Add(eHeroName.untIo, "Io")
    'mFriendlyName =s.Add(eHeroName.untCentaur_Warrunner, "Centaur Warrunner")
    'mFriendlyName =s.Add(eHeroName.untTimbersaw, "Timbersaw")
    'mFriendlyName =s.Add(eHeroName.untBristleback, "Bristleback")
    'mFriendlyName =s.Add(eHeroName.untTusk, "Tusk")
    'mFriendlyName =s.Add(eHeroName.untElder_Titan, "Elder Titan")
    'mFriendlyName =s.Add(eHeroName.untLegion_Commander, "Legion Commander")
    'mFriendlyName =s.Add(eHeroName.untEarth_Spirit, "Earth Spirit")
    'mFriendlyName =s.Add(eHeroName.untPhoenix, "Phoenix")
    'mFriendlyName =s.Add(eHeroName.untAnti_Mage, "Anti-Mage")
    'mFriendlyName =s.Add(eHeroName.untDrow_Ranger, "Drow Ranger")
    'mFriendlyName =s.Add(eHeroName.untJuggernaut, "Juggernaut")
    'mFriendlyName =s.Add(eHeroName.untMirana, "Mirana")
    'mFriendlyName =s.Add(eHeroName.untMorphling, "Morphling")
    'mFriendlyName =s.Add(eHeroName.untPhantom_Lancer, "Phantom Lancer")
    'mFriendlyName =s.Add(eHeroName.untVengeful_Spirit, "Vengeful Spirit")
    'mFriendlyName =s.Add(eHeroName.untRiki, "Riki")
    'mFriendlyName =s.Add(eHeroName.untSniper, "Sniper")
    'mFriendlyName =s.Add(eHeroName.untTemplar_Assassin, "Templar Assassin")
    'mFriendlyName =s.Add(eHeroName.untLuna, "Luna")
    'mFriendlyName =s.Add(eHeroName.untBounty_Hunter, "Bounty Hunter")
    'mFriendlyName =s.Add(eHeroName.untUrsa, "Ursa")
    'mFriendlyName =s.Add(eHeroName.untGyrocopter, "Gyrocopter")
    'mFriendlyName =s.Add(eHeroName.untLone_Druid, "Lone Druid")
    'mFriendlyName =s.Add(eHeroName.untNaga_Siren, "Naga Siren")
    'mFriendlyName =s.Add(eHeroName.untTroll_Warlord, "Troll Warlord")
    'mFriendlyName =s.Add(eHeroName.untEmber_Spirit, "Ember Spirit")
    'mFriendlyName =s.Add(eHeroName.untCrystal_Maiden, "Crystal Maiden")
    'mFriendlyName =s.Add(eHeroName.untPuck, "Puck")
    'mFriendlyName =s.Add(eHeroName.untStorm_Spirit, "Storm Spirit")
    'mFriendlyName =s.Add(eHeroName.untWindranger, "Windranger")
    'mFriendlyName =s.Add(eHeroName.untZeus, "Zeus")
    'mFriendlyName =s.Add(eHeroName.untLina, "Lina")
    'mFriendlyName =s.Add(eHeroName.untShadow_Shaman, "Shadow Shaman")
    'mFriendlyName =s.Add(eHeroName.untTinker, "Tinker")
    'mFriendlyName =s.Add(eHeroName.untNatures_Prophet, "Nature's Prophet")
    'mFriendlyName =s.Add(eHeroName.untEnchantress, "Enchantress")
    'mFriendlyName =s.Add(eHeroName.untJakiro, "Jakiro")
    'mFriendlyName =s.Add(eHeroName.untChen, "Chen")
    'mFriendlyName =s.Add(eHeroName.untSilencer, "Silencer")
    'mFriendlyName =s.Add(eHeroName.untOgre_Magi, "Ogre Magi")
    'mFriendlyName =s.Add(eHeroName.untRubick, "Rubick")
    'mFriendlyName =s.Add(eHeroName.untDisruptor, "Disruptor")
    'mFriendlyName =s.Add(eHeroName.untKeeper_of_the_Light, "Keeper of the Light")
    'mFriendlyName =s.Add(eHeroName.untSkywrath_Mage, "Skywrath Mage")
    'mFriendlyName =s.Add(eHeroName.untTechies, "Techies")
    'mFriendlyName =s.Add(eHeroName.untAxe, "Axe")
    'mFriendlyName =s.Add(eHeroName.untPudge, "Pudge")
    'mFriendlyName =s.Add(eHeroName.untSand_King, "Sand King")
    'mFriendlyName =s.Add(eHeroName.untSlardar, "Slardar")
    'mFriendlyName =s.Add(eHeroName.untTidehunter, "Tidehunter")
    'mFriendlyName =s.Add(eHeroName.untWraith_King, "Wraith King")
    'mFriendlyName =s.Add(eHeroName.untLifestealer, "Lifestealer")
    'mFriendlyName =s.Add(eHeroName.untNight_Stalker, "Night Stalker")
    'mFriendlyName =s.Add(eHeroName.untDoom, "Doom")
    'mFriendlyName =s.Add(eHeroName.untSpirit_Breaker, "Spirit Breaker")
    'mFriendlyName =s.Add(eHeroName.untLycan, "Lycan")
    'mFriendlyName =s.Add(eHeroName.untChaos_Knight, "Chaos Knight")
    'mFriendlyName =s.Add(eHeroName.untUndying, "Undying")
    'mFriendlyName =s.Add(eHeroName.untMagnus, "Magnus")
    'mFriendlyName =s.Add(eHeroName.untAbaddon, "Abaddon")
    'mFriendlyName =s.Add(eHeroName.untBloodseeker, "Bloodseeker")
    'mFriendlyName =s.Add(eHeroName.untShadow_Fiend, "Shadow Fiend")
    'mFriendlyName =s.Add(eHeroName.untRazor, "Razor")
    'mFriendlyName =s.Add(eHeroName.untVenomancer, "Venomancer")
    'mFriendlyName =s.Add(eHeroName.untFaceless_Void, "Faceless Void")
    'mFriendlyName =s.Add(eHeroName.untPhantom_Assassin, "Phantom Assassin")
    'mFriendlyName =s.Add(eHeroName.untViper, "Viper")
    'mFriendlyName =s.Add(eHeroName.untClinkz, "Clinkz")
    'mFriendlyName =s.Add(eHeroName.untBroodmother, "Broodmother")
    'mFriendlyName =s.Add(eHeroName.untWeaver, "Weaver")
    'mFriendlyName =s.Add(eHeroName.untSpectre, "Spectre")
    'mFriendlyName =s.Add(eHeroName.untMeepo, "Meepo")
    'mFriendlyName =s.Add(eHeroName.untNyx_Assassin, "Nyx Assassin")
    'mFriendlyName =s.Add(eHeroName.untSlark, "Slark")
    'mFriendlyName =s.Add(eHeroName.untMedusa, "Medusa")
    'mFriendlyName =s.Add(eHeroName.untTerrorblade, "Terrorblade")
    'mFriendlyName =s.Add(eHeroName.untBane, "Bane")
    'mFriendlyName =s.Add(eHeroName.untLich, "Lich")
    'mFriendlyName =s.Add(eHeroName.untLion, "Lion")
    'mFriendlyName =s.Add(eHeroName.untWitch_Doctor, "Witch Doctor")
    'mFriendlyName =s.Add(eHeroName.untEnigma, "Enigma")
    'mFriendlyName =s.Add(eHeroName.untNecrophos, "Necrophos")
    'mFriendlyName =s.Add(eHeroName.untWarlock, "Warlock")
    'mFriendlyName =s.Add(eHeroName.untQueen_of_Pain, "Queen of Pain")
    'mFriendlyName =s.Add(eHeroName.untDeath_Prophet, "Death Prophet")
    'mFriendlyName =s.Add(eHeroName.untPugna, "Pugna")
    'mFriendlyName =s.Add(eHeroName.untDazzle, "Dazzle")
    'mFriendlyName =s.Add(eHeroName.untLeshrac, "Leshrac")
    'mFriendlyName =s.Add(eHeroName.untDark_Seer, "Dark Seer")
    'mFriendlyName =s.Add(eHeroName.untBatrider, "Batrider")
    'mFriendlyName =s.Add(eHeroName.untAncient_Apparition, "Ancient Apparition")
    'mFriendlyName =s.Add(eHeroName.untInvoker, "Invoker")
    'mFriendlyName =s.Add(eHeroName.untOutworld_Devourer, "Outworld Devourer")
    'mFriendlyName =s.Add(eHeroName.untShadow_Demon, "Shadow Demon")
    'mFriendlyName =s.Add(eHeroName.untVisage, "Visage")


  End Sub


  Public Function GetUniqueNames() As List(Of String)

    Dim outlist As New List(Of String)
    For Each theitem As KeyValuePair(Of dvID, HeroBuild) In mHeroBuilds
      outlist.Add(theitem.Value.mBuild.mUniqueName)
    Next

    Return outlist
  End Function

  Public Function GetFriendlyName( heroname As eHeroName) As String
    Return mFriendlyNames.Item(heroname)
  End Function

  Public Function GetSystemName( friendlyname As String) As eHeroName

    For Each name As KeyValuePair(Of eHeroName, String) In mFriendlyNames
      If name.Value = friendlyname Then Return name.Key
    Next
    Return Nothing
  End Function
#End Region

#Region "Hero_Menu Stuff"

  'Public Function GetBitmapForHero( heroname As eHeroName) As BitmapImage
  '  If BitmapItems.ContainsKey(heroname) Then
  '    Return BitmapItems.Item(heroname)
  '  Else
  '    Return Nothing
  '  End If

  'End Function
  'Public ReadOnly Property HeroMenu As ctrlHero_Menu
  '  Get
  '    Return mHeroMenu
  '  End Get
  'End Property
  'Private Sub LoadBitmaps()


  '  For Each item In EnumItems
  '    If Not item Is Nothing And Not item = eHeroName.None Then

  '      Dim theherobuild As HeroBuild = Me.GetFirstBuildForHero(item)
  '      Dim theuri As New Uri(theherobuild.mHero.UnitImage, UriKind.Absolute)
  '      Dim thebit = New BitmapImage(theuri)
  '      BitmapItems.Add(item, thebit)

  '    End If
  '  Next



  'End Sub

  'Private Sub LoadHeroMenu()

  '  For Each heroname In EnumItems
  '    If Not heroname = eHeroName.None Then
  '      Dim theherobuild = Me.GetFirstBuildForHero(heroname)

  '      Dim thectrl As New ctrlHero_Menu_Item(theherobuild, BitmapItems.Item(heroname))

  '      mMenuItems.Add(heroname, thectrl)
  '    End If

  '  Next

  '  mHeroMenu.Visibility = Visibility.Collapsed

  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untEarthshaker), 1, 0)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untSven), 1, 1)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untTiny), 1, 2)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untKunkka), 1, 3)

  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untBeastmaster), 2, 0)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untDragon_Knight), 2, 1)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untClockwerk), 2, 2)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untOmniknight), 2, 3)

  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untHuskar), 3, 0)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untAlchemist), 3, 1)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untBrewmaster), 3, 2)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untTreant_Protector), 3, 3)


  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untIo), 4, 0)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untCentaur_Warrunner), 4, 1)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untTimbersaw), 4, 2)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untBristleback), 4, 3)

  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untTusk), 5, 0)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untElder_Titan), 5, 1)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untLegion_Commander), 5, 2)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untEarth_Spirit), 5, 3)

  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untPhoenix), 6, 0)

  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untAnti_Mage), 1, 5)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untDrow_Ranger), 1, 6)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untJuggernaut), 1, 7)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untMirana), 1, 8)

  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untMorphling), 2, 5)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untPhantom_Lancer), 2, 6)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untVengeful_Spirit), 2, 7)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untRiki), 2, 8)

  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untSniper), 3, 5)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untTemplar_Assassin), 3, 6)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untLuna), 3, 7)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untBounty_Hunter), 3, 8)

  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untUrsa), 4, 5)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untGyrocopter), 4, 6)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untLone_Druid), 4, 7)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untNaga_Siren), 4, 8)

  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untTroll_Warlord), 5, 5)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untEmber_Spirit), 5, 6)

  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untCrystal_Maiden), 1, 10)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untPuck), 1, 11)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untStorm_Spirit), 1, 12)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untWindranger), 1, 13)

  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untZeus), 2, 10)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untLina), 2, 11)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untShadow_Shaman), 2, 12)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untTinker), 2, 13)

  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untNatures_Prophet), 3, 10)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untEnchantress), 3, 11)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untJakiro), 3, 12)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untChen), 3, 13)

  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untSilencer), 4, 10)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untOgre_Magi), 4, 11)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untRubick), 4, 12)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untDisruptor), 4, 13)

  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untKeeper_of_the_Light), 5, 10)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untSkywrath_Mage), 5, 11)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untTechies), 5, 12)

  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untAxe), 7, 0)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untPudge), 7, 1)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untSand_King), 7, 2)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untSlardar), 7, 3)

  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untTidehunter), 8, 0)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untWraith_King), 8, 1)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untLifestealer), 8, 2)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untNight_Stalker), 8, 3)

  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untDoom), 9, 0)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untSpirit_Breaker), 9, 1)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untLycan), 9, 2)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untChaos_Knight), 9, 3)

  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untUndying), 10, 0)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untMagnus), 10, 1)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untAbaddon), 10, 2)

  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untBloodseeker), 7, 5)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untShadow_Fiend), 7, 6)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untRazor), 7, 7)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untVenomancer), 7, 8)


  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untFaceless_Void), 8, 5)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untPhantom_Assassin), 8, 6)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untViper), 8, 7)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untClinkz), 8, 8)


  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untBroodmother), 9, 5)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untWeaver), 9, 6)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untSpectre), 9, 7)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untMeepo), 9, 8)

  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untNyx_Assassin), 10, 5)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untSlark), 10, 6)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untMedusa), 10, 7)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untTerrorblade), 10, 8)

  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untBane), 7, 10)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untLich), 7, 11)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untLion), 7, 12)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untWitch_Doctor), 7, 13)

  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untEnigma), 8, 10)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untNecrophos), 8, 11)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untWarlock), 8, 12)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untQueen_of_Pain), 8, 13)

  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untDeath_Prophet), 9, 10)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untPugna), 9, 11)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untDazzle), 9, 12)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untLeshrac), 9, 13)

  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untDark_Seer), 10, 10)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untBatrider), 10, 11)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untAncient_Apparition), 10, 12)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untInvoker), 10, 13)

  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untOutworld_Devourer), 11, 10)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untShadow_Demon), 11, 11)
  '  mHeroMenu.AddItem(mMenuItems.Item(eHeroName.untVisage), 11, 12)



  'End Sub
#End Region

  'Public Function GetHeroListItems() As Hero_Listitem_List
  '  ' If mHero_Listitems Is Nothing Then
  '  Dim outlist As New Hero_Listitem_List

  '  ' mHero_Listitems = New Hero_Listitem_List

  '  Dim items = System.Enum.GetValues(GetType(eHeroName))

  '  For Each Item As String In items

  '    Dim thename = DirectCast([Enum].Parse(GetType(eHeroName), Item, True), eHeroName)
  '    Dim thehero = Me.GetFirstBuildForHero(thename)
  '    If Not thehero Is Nothing Then
  '      Dim thectrl As New ctrlHero_List_Item(thehero.UnitImage, thehero.FriendlyName, thehero)
  '      outlist.Add(thectrl)
  '    End If


  '  Next


  '  outlist = outlist.GetSortedList()
  '  'mHero_Listitems = outlist
  '  Return outlist
  '  '  Else
  '  'Dim outlist As New Hero_Listitem_List
  '  'For i As Integer = 0 To mHero_Listitems.Count - 1
  '  '  outlist.Add(mHero_Listitems.Item(i))
  '  'Next
  '  'Return outlist
  '  'End If

  'End Function



End Class
