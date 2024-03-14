#Const devmode = True
Public Class ctrlBuild_List_Item
  'Private mImage As String
  Private mContent As String
  Public mBuild As Build
  Public Sub New( thecontent As String,  thebuild As Build) ' imageurl As String, 
    InitializeComponent()

    mContent = thecontent
    mBuild = thebuild


#If Not devmode Then
    lblItemName.Content = thecontent
#Else
    Dim strid = thebuild.IDitem.ToString
    strid = strid.Substring(0, 4)
    lblItemName.Content = thecontent & " - " & strid
#End If



  End Sub
End Class
