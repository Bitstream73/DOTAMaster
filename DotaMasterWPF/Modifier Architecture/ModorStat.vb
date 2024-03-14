Public Class ModorStat
  Private mMod As Modifier
  Private mStat As Stat
  Private misMod As Boolean

  Public Sub New( themod As Modifier)
    mMod = themod
    misMod = True
  End Sub

  Public Sub New( thestat As Stat)
    mStat = thestat
    misMod = False
  End Sub
End Class
