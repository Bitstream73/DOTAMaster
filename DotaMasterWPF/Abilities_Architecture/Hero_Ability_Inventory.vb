Public Class Hero_Ability_Inventory
  Implements iHero_Ability_Inventory


  Private mAbilitiesListedByUIPosition As Ability_Info_List

  Private mCurrentAbilityLevelsForEachHeroLevel As New List(Of List(Of Integer)) 'integer represents the level of the ability, 0 means unpicked

  Private mHeroInstance As iHeroUnit
  Private mGame As dGame
  Public Sub New(game As dGame)
    mGame = game
  End Sub

  Public Sub load(hero As iPlayerUnit)
    mHeroInstance = hero

    GetAbilityInfos()
    CalcActiveAbilitiesByLevelListedByUIPosition()
    CalcAbilityLifetimes()
  End Sub

  Private Sub GetAbilityInfos()
    mAbilitiesListedByUIPosition = New Ability_Info_List()
    For i = 0 To mHeroInstance.GetHero.AbilityNames.Count - 1
      Dim abilityname = mHeroInstance.GetHero.AbilityNames.Item(i)
      'Lifetime shouldn't really be needed and isn't calculable right now
      Dim ab = mGame.dbAbilities.CreateAbilityInfoInstance(abilityname, 0, Me.mHeroInstance, Me.mHeroInstance.Lifetime)
      mAbilitiesListedByUIPosition.Add(ab)
    Next

  End Sub
  'Private Sub LevelUpAbility(abilityname As eAbilityName, herolevel As Integer)
  '  Dim abposition As Integer = GetAbility(abilityname).AbilitysUIPosition

  '  If AbilityCanLevel(abilityname, herolevel) Then

  '    'wipe values past the new ability picked since they may now be invalid
  '    If mHeroInstance.GetBuild.mAbilityBuildOrderByUIPosition.Count > herolevel Then
  '      For i As Integer = herolevel To mHeroInstance.GetBuild.mAbilityBuildOrderByUIPosition.Count - 1
  '        mAbilitiesBuildOrderByUIPosition.RemoveAt(herolevel)
  '      Next
  '    End If

  '    mAbilitiesBuildOrderByUIPosition.Add(abposition)
  '    LoadAbilitiesBuildOrderByUIPosition()
  '  End If
  'End Sub

  'Private Sub LoadAbilitiesBuildOrderByUIPosition()

  '  mAbilitiesBuildOrderByUIPosition.Clear()
  '  For i As Integer = 0 To mHeroInstance.GetBuild..Count - 1

  '    Dim abilitybchosenatcurrentlevel = mAbilitiesBuildOrderByUIPosition.Item(i)

  '    mAbilitiesBuildOrderByUIPosition.Add(abilitybchosenatcurrentlevel)
  '  Next
  'End Sub

  ''' <summary>
  ''' figures out which abilities (and their level) are active at each hero level
  ''' </summary>
  ''' <remarks></remarks>
  Private Sub CalcActiveAbilitiesByLevelListedByUIPosition() '

    Dim maximumabilitiesatonetime = mAbilitiesListedByUIPosition.Count


    mCurrentAbilityLevelsForEachHeroLevel.Clear()
    Dim abilitybuildorder = mHeroInstance.GetBuild.mAbilityBuildOrderByUIPosition
    If abilitybuildorder.Count < 1 Then
      mCurrentAbilityLevelsForEachHeroLevel = New List(Of List(Of Integer))
      Exit Sub
    End If
    'first item won't have a previous item to build from so
    'we calc it seperately
    Dim positionindexoflevelingability = abilitybuildorder.Item(0)
    Dim level1abilities As New List(Of Integer)
    For x = 0 To mAbilitiesListedByUIPosition.Count - 1
      If x = positionindexoflevelingability Then
        level1abilities.Add(1)
      Else
        level1abilities.Add(0)
      End If
    Next
    mCurrentAbilityLevelsForEachHeroLevel.Add(level1abilities)


    'calc the rest of the abilities
    For i As Integer = 1 To abilitybuildorder.Count - 1
      positionindexoflevelingability = abilitybuildorder.Item(i)

      Dim abilitylevelsforcurrentherolevel As New List(Of Integer)

      For x = 0 To mAbilitiesListedByUIPosition.Count - 1

        If x = positionindexoflevelingability Then
          'we've found the ability that has leveled
          abilitylevelsforcurrentherolevel.Add(mCurrentAbilityLevelsForEachHeroLevel.Item(i - 1).Item(x) + 1)
        Else
          'hasn't leveled so copy previous level for the ability
          abilitylevelsforcurrentherolevel.Add(mCurrentAbilityLevelsForEachHeroLevel.Item(i - 1).Item(x))
        End If

      Next

      mCurrentAbilityLevelsForEachHeroLevel.Add(abilitylevelsforcurrentherolevel)
    Next



    'For i As Integer = 0 To mAbilitiesListedByUIPosition.Count - 1
    '  Dim newtally As New List(Of Integer)
    '  If i = 0 Then
    '    For x As Integer = 0 To maximumabilitiesatonetime - 1
    '      If x = mAbilitiesListedByUIPosition.Item(i) Then
    '        newtally.Add(1)
    '      Else
    '        newtally.Add(0)
    '      End If
    '    Next
    '  End If

    '  Dim minimumherolevel = 1
    '  Dim maximumherolevel = 25
    '  If i >= minimumherolevel And i <= maximumherolevel Then


    '    For x As Integer = 0 To maximumabilitiesatonetime - 1
    '      If x = mAbilitiesBuildOrderByUIPosition.Item(i) Then
    '        If mCurrentAbilityLevelsForEachHeroLevel.Item(i - 1).Item(x) > 1 Then
    '          Dim y = 2
    '        End If
    '        newtally.Add(mCurrentAbilityLevelsForEachHeroLevel.Item(i - 1).Item(x) + 1)
    '        If newtally.Item(newtally.Count - 1) > 1 Then
    '          Dim z = 2
    '        End If
    '      Else
    '        newtally.Add(mCurrentAbilityLevelsForEachHeroLevel.Item(i - 1).Item(x))
    '      End If
    '    Next
    '    'End If
    '  End If

    '  mCurrentAbilityLevelsForEachHeroLevel.Add(newtally)
    'Next





  End Sub
  Private Sub CalcAbilityLifetimes()
    ' mAbilitiesLifetimes = New List(Of Lifetime)
    ' THERE HAS TO BE A BETTER WAY TO DO THIS
    Dim thestarts As New List(Of List(Of Integer))
    For currentabilityuiposition As Integer = 0 To mAbilitiesListedByUIPosition.Count - 1

      Dim previousabilitylevel As Integer = 0

      Dim herolevelswhereeachabilitylevelwaschosen As New List(Of Integer)


      For currentHeroLevel As Integer = 1 To 25

        Dim currentability = mAbilitiesListedByUIPosition.Item(currentabilityuiposition)

        Dim currentabilitylevel As Integer = GetAbilityLevelAtHeroLevel(currentability, currentHeroLevel)

        If currentabilitylevel > previousabilitylevel Then
          previousabilitylevel = currentabilitylevel
          herolevelswhereeachabilitylevelwaschosen.Add(currentHeroLevel)
        End If
      Next
      thestarts.Add(herolevelswhereeachabilitylevelwaschosen)
    Next


    For currentability As Integer = 0 To mAbilitiesListedByUIPosition.Count - 1
      Dim currentabilityslifetime As Lifetime
      Dim abstarts = thestarts.Item(currentability)
      Dim curability = mAbilitiesListedByUIPosition.Item(currentability)

      Dim lifestarts = New List(Of ddFrame)
      Dim lifeends As New List(Of ddFrame)

      For z As Integer = 0 To abstarts.Count - 1
        Dim xpneeded = mHeroInstance.XPCurve.GetXPNeededforLevel(abstarts.Item(z))
        Dim thestart = mHeroInstance.XPCurve.GetTimeforValue(xpneeded)
        If Not thestart Is Nothing Then
          lifestarts.Add(thestart)
          Dim theend As ddFrame
          If z < abstarts.Count - 1 Then
            Dim xpneeded2 = mHeroInstance.XPCurve.GetXPNeededforLevel(abstarts.Item(z + 1))
            theend = mHeroInstance.XPCurve.GetTimeforValue(xpneeded2)
          Else
            theend = mGame.TimeKeeper.GameEnd
          End If
          If theend Is Nothing Then
            theend = mGame.TimeKeeper.GameEnd
          End If
          lifeends.Add(theend)

        End If

      Next
      currentabilityslifetime = New Lifetime(lifestarts, lifeends)

      mAbilitiesListedByUIPosition.Item(currentability).mLifetime = currentabilityslifetime


    Next

    Dim e = 2


  End Sub

#Region "Info"

  Private Function AbilityCanLevel(theabname As eAbilityName, herolevel As Integer) As Boolean Implements iAbility_Inventory.AbilityCanLevel
    Dim availableabs = GetUpgradableAbilitiesByLevel(herolevel)

    For i As Integer = 0 To availableabs.Count - 1
      If availableabs.Item(i).AbilityName = theabname Then Return True
    Next
    Return False
  End Function

  Private Function AbilityLevelIsCapped(theab As Ability_Info, herolevel As Integer) As Boolean Implements iAbility_Inventory.AbilityLevelIsCapped
    Dim levelcap As Integer = 0
    If Not theab.IsUltimate Then
      If Not mHeroInstance.HeroName = eHeroName.untInvoker Then
        levelcap = 4
      Else
        levelcap = 7
      End If

    Else 'its an ulti
      levelcap = 3
    End If

    If GetAbilityLevelAtHeroLevel(theab, herolevel) >= levelcap Then Return True

    Return False

  End Function

  'Public Property AbilityInfos As List(Of Ability_Info) Implements iAbility_Inventory.AbilityInfos
  '  Get
  '    Return AbilityCanLevel+
  '    If mAbilitiesListedByUIPosition.Count < 1 Then
  '      mAbilitiesListedByUIPosition = GetAbilityInfos(mGame)
  '    End If
  '    Return mAbilitiesListedByUIPosition
  '  End Get
  '  Set(value As List(Of Ability_Info))
  '    If AbilityInfos Is Nothing Then
  '      mAbilitiesListedByUIPosition = value
  '    End If
  '  End Set
  'End Property

  Public Property AbilitiesListedByUIPosition As Ability_Info_List Implements iAbility_Inventory.AbilitiesListedByUIPosition
    Get
      Return mAbilitiesListedByUIPosition
    End Get
    Set(value As Ability_Info_List)

    End Set
  End Property

  Public Function GetAbilitiesListedByUIPositionAsGameEntities() As List(Of iGameEntity) Implements iAbility_Inventory.GetAbilitiesListedByUIPositionAsGameEntities
    Dim outlist As New List(Of iGameEntity)
    For i = 0 To mAbilitiesListedByUIPosition.Count - 1
      outlist.Add(mAbilitiesListedByUIPosition.Item(i))
    Next
    Return outlist

  End Function

  Public Property A

  'Public Property AbilitiesBuildOrderByUIPosition As List(Of Integer) Implements iPlayerUnit_Ability_Inventory.AbilitiesBuildOrderByUIPosition
  '  Get
  '    Return mAbilitiesBuildOrderByUIPosition
  '  End Get
  '  Set(value As List(Of Integer))

  '  End Set
  ' End Property

  Property CurrentAbilityLevelsForEachHeroLevel As List(Of List(Of Integer)) Implements iHero_Ability_Inventory.CurrentAbilityLevelsForEachHeroLevel
    Get
      Return mCurrentAbilityLevelsForEachHeroLevel
    End Get
    Set(value As List(Of List(Of Integer)))

    End Set
  End Property

#End Region

#Region "CRUD"

  Public Function GetNewAbilityByLevel(herolevel As Integer) As Ability_Info Implements iHero_Ability_Inventory.GetNewAbilityByLevel
    If herolevel = 0 Then Return Nothing
    'If herolevel <= mAbilitiesListedByUIPosition.Count Then
    '  Return mAbilitiesListedByUIPosition.Item(mAbilitiesListedByUIPosition.Item(herolevel - 1))
    'End If
    If Not herolevel > 25 Then
      Dim positionofcurrentnewabilitylevel = mHeroInstance.GetBuild.mAbilityBuildOrderByUIPosition.IndexOf(herolevel - 1)
      Return mAbilitiesListedByUIPosition.Item(positionofcurrentnewabilitylevel)
    End If
    Return Nothing
  End Function

  Private Function GetAbility(abilityname As eAbilityName) As Ability_Info Implements iAbility_Inventory.GetAbility
    For i As Integer = 0 To mAbilitiesListedByUIPosition.Count - 1
      If mAbilitiesListedByUIPosition.Item(i).AbilityName = abilityname Then Return mAbilitiesListedByUIPosition.Item(i)
    Next
    Dim x = 2
    Return Nothing
  End Function

  Public Function GetActiveAbilitiesByLevel(herolevel As Integer) As List(Of Integer) Implements iHero_Ability_Inventory.GetActiveAbilitiesByLevel
    Dim levelslist As New List(Of Integer)

    ' this is a clue
    Dim abilityinfos = Me.AbilitiesListedByUIPosition
    For i As Integer = 0 To mAbilitiesListedByUIPosition.Count - 1

      levelslist.Add(GetAbilityLevelAtHeroLevel(abilityinfos.Item(i), herolevel))
    Next

    Return levelslist
  End Function



  ''' <summary>
  ''' returns a list of all apgradable abilites for a herolevel
  ''' </summary>
  ''' <param name="herolevel"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function GetUpgradableAbilitiesByLevel(herolevel As Integer) As Ability_Info_List Implements iHero_Ability_Inventory.GetUpgradableAbilitiesByLevel


    If herolevel = 6 Then
      Dim x = 2
    End If
    Dim outlist As New Ability_Info_List
    Dim lastpicked = GetNewAbilityByLevel(herolevel - 1)
    Dim ulti = GetUltimate()

    If ulti Is Nothing Then
      Dim x = 2
    End If

    Dim maxspelllevel As Integer
    Select Case herolevel
      Case 0, 1, 2
        maxspelllevel = 1
      Case 3, 4
        maxspelllevel = 2
      Case 5, 6
        If Not mHeroInstance.HeroName = eHeroName.untInvoker Then
          maxspelllevel = 3
        Else
          maxspelllevel = 7
        End If

      Case Else
        If Not mHeroInstance.GetHero.Name = eHeroName.untInvoker Then
          maxspelllevel = 4
        Else
          maxspelllevel = 7
        End If

    End Select

    For i As Integer = 0 To mAbilitiesListedByUIPosition.Count - 1
      outlist.Add(mAbilitiesListedByUIPosition.Item(i))
    Next

    Select Case herolevel
      Case 0
        Return Nothing

      Case 1, 2, 3, 4, 5
        If Not ulti Is Nothing Then
          RemoveAbility(ulti, outlist)
        End If


      Case 6, 7, 8, 9, 10
        If Not ulti Is Nothing Then

          If GetAbilityLevelAtHeroLevel(ulti, herolevel) > 0 Then
            RemoveAbility(ulti, outlist)
          End If

        End If

      Case 11, 12, 13, 14, 15


        If Not ulti Is Nothing Then


          If GetAbilityLevelAtHeroLevel(ulti, herolevel) > 1 Then
            RemoveAbility(ulti, outlist)
          End If
        End If


      Case 16, 17, 18, 19, 20, 21, 22, 23, 24, 25

        If GetAbilityLevelAtHeroLevel(mAbilitiesListedByUIPosition.Item(0), herolevel) > 9 Then
          RemoveAbility(mAbilitiesListedByUIPosition.Item(0), outlist)
        End If

        If Not ulti Is Nothing Then
          If GetAbilityLevelAtHeroLevel(ulti, herolevel) > 2 Then
            RemoveAbility(ulti, outlist)
          End If
        End If



    End Select

    For i As Integer = outlist.Count - 1 To 0 Step -1
      Dim theab = outlist.Item(i)

      If GetAbilityLevelAtHeroLevel(theab, herolevel) >= maxspelllevel Then
        outlist.Remove(theab)
      End If
    Next

    For i As Integer = outlist.Count - 1 To 0 Step -1
      If AbilityLevelIsCapped(outlist.Item(i), herolevel) Then
        outlist.RemoveAt(i)
      End If
    Next

    If outlist.Count = 0 Then
      outlist.Add(Me.AbilitiesListedByUIPosition.Item(0))
    End If

    Return outlist


    Return outlist
  End Function

  Public Function GetAbilityLevelAtHeroLevel(theab As Ability_Info, herolevel As Integer) As Integer Implements iHero_Ability_Inventory.GetAbilityLevelAtHeroLevel
    If herolevel = 0 Then Return 0
    If mCurrentAbilityLevelsForEachHeroLevel.Count < 1 Then Return 0


    If herolevel > mCurrentAbilityLevelsForEachHeroLevel.Count Then
      Return mCurrentAbilityLevelsForEachHeroLevel.Item(mCurrentAbilityLevelsForEachHeroLevel.Count - 1).Item(theab.AbilitysUIPosition)
    End If
    Return mCurrentAbilityLevelsForEachHeroLevel.Item(herolevel - 1).Item(theab.AbilitysUIPosition)
  End Function

  Private Function RemoveAbility(theability As Ability_Info, theabilitylist As List(Of Ability_Info)) As List(Of Ability_Info) Implements iHero_Ability_Inventory.RemoveAbility
    If theabilitylist.Contains(theability) Then
      theabilitylist.Remove(theability)
    Else
      Dim x = 2
    End If
    Return theabilitylist
  End Function

  'Public Sub SetAbility(theability As Ability_Info, herolevel As Integer)

  '  Dim currability = GetAbility(theability.AbilityName)


  '  Dim newabsequence As New List(Of Integer)


  '  Select Case herolevel
  '    Case 0
  '      Exit Sub
  '    Case 1
  '      mAbilitiesBuildOrderByUIPosition.Clear()
  '      mAbilitiesBuildOrderByUIPosition.Add(theability.AbilitysUIPosition)
  '    Case 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
  '      If herolevel <= mAbilitiesBuildOrderByUIPosition.Count + 1 Then
  '        For i As Integer = 0 To herolevel - 2


  '          newabsequence.Add(mAbilitiesBuildOrderByUIPosition.Item(i))
  '        Next
  '      End If
  '      newabsequence.Add(theability.AbilitysUIPosition)
  '      mAbilitiesBuildOrderByUIPosition = newabsequence
  '  End Select

  '  LoadAbility_InfoSequenceList()

  '  CalcActiveAbilitiesByLevelListedByUIPosition()
  'End Sub
  Public Function GetAbilities() As List(Of Ability_Info)
    Return mAbilitiesListedByUIPosition
  End Function
  Public Function GetAbilityById(id As dvID) As Ability_Info Implements iAbility_Inventory.GetAbilityById
    For i As Integer = 0 To mAbilitiesListedByUIPosition.Count - 1
      If mAbilitiesListedByUIPosition.Item(i).Id.GuidID = id.GuidID Then Return mAbilitiesListedByUIPosition.Item(i)
    Next
    Return Nothing
  End Function

  'Public Function GetAbilityInfos(game As dGame) As List(Of Ability_Info) Implements iAbility_Inventory.GetAbilityInfos
  '  If mAbilitiesListedByUIPosition Is Nothing Then
  '    mAbilitiesListedByUIPosition = New Ability_Info_List
  '    Dim abilitylevels As Integer 'to set amount of levels in stat gain (25 - totalofabilitylevels)
  '    For i As Integer = 0 To mHeroInstance.GetAbilityNames.Count - 1

  '      mAbilitiesListedByUIPosition.Add(mGame.dbAbilities.CreateAbilityInfoInstance(mHeroInstance.GetAbilityNames.Item(i), 0, Me, Nothing))

  '      If i > 0 Then
  '        abilitylevels += mAbilitiesListedByUIPosition.Item(i).AbilityLevelCount
  '      End If
  '    Next

  '    mAbilitiesListedByUIPosition.Item(0).AbilityLevelCount = 25 - abilitylevels

  '  End If
  '  Return mAbilitiesListedByUIPosition
  'End Function

  Private Function GetPositionFromAbilityinfo(theinfo As Ability_Info) As Integer Implements iAbility_Inventory.GetPositionFromAbilityinfo
    For i As Integer = 0 To mAbilitiesListedByUIPosition.Count - 1
      If theinfo Is mAbilitiesListedByUIPosition.Item(i) Then Return i
    Next
    Return Nothing
  End Function
#End Region


  Public Function GetUltimate() As Ability_Info Implements iHero_Ability_Inventory.GetUltimate
    Dim ult = mAbilitiesListedByUIPosition.Item(mAbilitiesListedByUIPosition.Count - 1)
    If ult.IsUltimate Then Return ult

    Return Nothing
  End Function
End Class
