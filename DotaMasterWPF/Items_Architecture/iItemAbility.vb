Interface iItemAbility

  ReadOnly Property AbilityName As String

  ReadOnly Property AbilityDescription As String

  Function GetAbilityModifiers(thestateindex As Integer, thegame As dGame, theitem_InfoID As IUnitUpgrade, _
                                thecaster As iDisplayUnit, _
                                thetarget As iDisplayUnit, _
                                ftarget As iDisplayUnit, _
                                isfriendbias As Boolean, _
                                occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


End Interface

