Public Class ctrlText_Tooltip
  Public Sub New( thetexts As List(Of List(Of String)))
    InitializeComponent()

    Dim thecol = New SolidColorBrush(PageHandler.dbColors.BodyTextColor)
    For i As Integer = 0 To thetexts.Count - 1

      If Not thetexts.Item(i) Is Nothing Then
        If Not thetexts.Item(i).Count < 1 Then
          Dim curtexts = thetexts.Item(i)
          For x As Integer = 0 To curtexts.Count - 1
            Dim para As New ctrlBody_Paragraph()
            para.LoadText(curtexts.Item(x), thecol)
            LayoutRoot.Children.Add(para)
          Next
        End If
      End If
    Next
  End Sub
End Class
