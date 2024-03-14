Public Class ctrlAbility_Tooltipe
  Private mAbility As Ability_Info
  Private mAbilityLevel As Integer

  Public Sub New(theAbility As Ability_Info, abilitylevel As Integer, friendlyname As String)
    InitializeComponent()

    mAbility = theAbility
    mAbilityLevel = abilitylevel
    Try
      If Not theAbility Is Nothing Then


        lblAbilityName.Content = friendlyname


        Dim paras = mAbility.Description.Split("|")

        For i As Integer = 0 To paras.Count - 1
          Dim paralbl As New ctrlBody_Paragraph
          paralbl.LayoutRoot.Text = paras(i)
          spnlDescription.Children.Add(paralbl)
        Next

      End If
    Catch ex As Exception
      Dim x = 2
    End Try

  End Sub
End Class
