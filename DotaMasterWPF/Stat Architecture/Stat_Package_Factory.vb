Public Class Stat_Package_Factory
  Private mHeroStatPackages As OneToOneDoubleDictionary(Of Guid, HeroStatPackage)
  Private mTeamStatPackages As OneToOneDoubleDictionary(Of Guid, TeamStatPackage)

  Private mGame As dGame
  Public Sub New(game As dGame)

    mGame = game

    mHeroStatPackages = New OneToOneDoubleDictionary(Of Guid, HeroStatPackage)(mGame.Log)
    mTeamStatPackages = New OneToOneDoubleDictionary(Of Guid, TeamStatPackage)(mGame.Log)

  End Sub

  Public Function GetorCreateHeroStatPackage(Hero As HeroInstance) As HeroStatPackage

    Dim outpackage As HeroStatPackage = mHeroStatPackages.ValueForKey(Hero.Id.GuidID)

    If outpackage Is Nothing Then

      outpackage = New HeroStatPackage(Hero, mGame)

      mHeroStatPackages.AddorUpdate(Hero.Id.GuidID, outpackage)
    End If

    Return outpackage

  End Function


  Public Function GetorCreateTeamStatPackage(team As dTeam) As TeamStatPackage

    Dim outpackage As TeamStatPackage = mTeamStatPackages.ValueForKey(team.Id.GuidID)

    If outpackage Is Nothing Then

      outpackage = New TeamStatPackage(team, mGame)

      mTeamStatPackages.AddorUpdate(team.Id.GuidID, outpackage)
    End If

    Return outpackage
  End Function
End Class
