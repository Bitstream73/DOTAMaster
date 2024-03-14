Public Class TargetsInfo
  Public EnemyTarget As iDisplayUnit
  Public FriendlyTarget As iDisplayUnit
  Public FriendTargetBias As Boolean

  Public Sub New(enemytarget As iDisplayUnit, friendlytarget As iDisplayUnit, friendtargetbias As Boolean)
    Me.EnemyTarget = enemytarget
    Me.FriendlyTarget = friendlytarget
    Me.FriendTargetBias = friendtargetbias
  End Sub
End Class
