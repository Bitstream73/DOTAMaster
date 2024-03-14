Public Class HeroInstanceFactory

  Private mgame As dGame
  Private dbCreeps As Creeps_and_Pets_Database
  Public Sub New(game As dGame, _
                 creepdb As Creeps_and_Pets_Database)

    mgame = game
    dbCreeps = creepdb
  End Sub
  Public Function CreateHeroInstance(hero As HeroBuild, herocolor As Color, _
                                     theteam As dTeam, heroposition As Integer, _
                                     goldshare As Decimal, xpshare As Decimal)
    Dim thehero As New HeroInstance(hero, herocolor, mgame, mgame.dbModifiers, dbCreeps, mgame.Log)
    thehero.Id.AppendMetaData("dGame/AddHeroInstance")

    thehero.mTeam = theteam
    thehero.mTeamPosition = heroposition

    Dim gold = mgame.Economy.GetGoldCurve(goldshare)
    Dim xp = mgame.Economy.GetXPCurve(xpshare)


    thehero.mTeam = theteam
    thehero.mTeamPosition = heroposition
    thehero.Load(xp, gold, mgame)

    Dim emptytarg As New EmptyTarget(mgame)
    thehero.SetTargets(emptytarg, emptytarg, False)

    Return thehero
  End Function
End Class
