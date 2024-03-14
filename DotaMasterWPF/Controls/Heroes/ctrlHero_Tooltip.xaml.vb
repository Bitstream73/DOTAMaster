Public Class ctrlHero_Tooltip
  Private mHero As HeroBuild
  Private mbuildsto As Item_List
  Private mbuildsfrom As Item_List
  Public Sub New( theHero As HeroBuild)
    InitializeComponent()

    mHero = theHero

    lblItemName.Content = mHero.FriendlyName
    Dim pstr As String = "Parent: " & theHero.mBuild.ParentIDitem.ToString
    Dim ppara As New ctrlBody_Paragraph
    ppara.LayoutRoot.Text = pstr
    spnlDescription.Children.Add(ppara)

    Dim ID As String = "    ID: " & theHero.mBuild.IDitem.ToString
    Dim ipara As New ctrlBody_Paragraph
    ipara.LayoutRoot.Text = ID
    spnlDescription.Children.Add(ipara)

    Dim chstr As String = " Child: " & theHero.mBuild.ChildIDitem.ToString
    Dim cpara As New ctrlBody_Paragraph
    cpara.LayoutRoot.Text = chstr
    spnlDescription.Children.Add(cpara)

    Dim paras = mHero.mHero.Bio.Split("|")

    For i As Integer = 0 To paras.Count - 1
      Dim paralbl As New ctrlBody_Paragraph
      paralbl.LayoutRoot.Text = paras(i)
      spnlDescription.Children.Add(paralbl)
    Next






  End Sub
End Class
