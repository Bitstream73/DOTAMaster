Public Class Build_List
  Inherits List(Of Build)

  Public Sub New()

  End Sub
  Public Function GetListItems() As Build_Listitem_list
    Dim outlist As New Build_Listitem_list
    For i As Integer = 0 To Me.Count - 1
      ' Dim newcombo As New ComboBoxItem
      Dim thebuild = Me.Item(i)
      Dim newctrl As New ctrlBuild_List_Item(thebuild.mUniqueName, thebuild)
      'newcombo.Content = newctrl
      outlist.Add(newctrl)
    Next
    outlist = outlist.GetSortedList()

    Return outlist
  End Function
  'Private Sub LoadDrowTest()

  '  Dim outlist As New List(Of List(Of eItemname))
  '  For i As Integer = 0 To 25
  '    Dim outitems As New List(Of eItemname)

  '    Select Case i
  '      Case 0
  '        outitems.Add(eItemname.None)
  '        outitems.Add(eItemname.None)
  '        outitems.Add(eItemname.None)
  '        outitems.Add(eItemname.None)
  '        outitems.Add(eItemname.None)
  '        outitems.Add(eItemname.None)

  '      Case i Mod 1 = 0
  '        outitems.Add(eItemname.itmIRON_BRANCH)
  '        outitems.Add(eItemname.itmIRON_BRANCH)
  '        outitems.Add(eItemname.itmIRON_BRANCH)
  '        outitems.Add(eItemname.itmTANGO)
  '        outitems.Add(eItemname.itmTANGO)
  '        outitems.Add(eItemname.itmTANGO)
  '      Case i Mod 2 = 0
  '        outitems.Add(eItemname.itmIRON_BRANCH)
  '        outitems.Add(eItemname.itmCIRCLET)
  '        outitems.Add(eItemname.itmIRON_BRANCH)
  '        outitems.Add(eItemname.itmTANGO)
  '        outitems.Add(eItemname.itmTANGO)
  '        outitems.Add(eItemname.itmTANGO)
  '      Case i Mod 3 = 0
  '        outitems.Add(eItemname.itmIRON_BRANCH)
  '        outitems.Add(eItemname.itmCIRCLET)
  '        outitems.Add(eItemname.itmIRON_BRANCH)
  '        outitems.Add(eItemname.itmCLARITY)
  '        outitems.Add(eItemname.itmTANGO)
  '        outitems.Add(eItemname.itmTANGO)
  '      Case i Mod 4 = 0
  '        outitems.Add(eItemname.itmIRON_BRANCH)
  '        outitems.Add(eItemname.itmCIRCLET)
  '        outitems.Add(eItemname.itmIRON_BRANCH)
  '        outitems.Add(eItemname.itmCLARITY)
  '        outitems.Add(eItemname.itmTANGO)
  '        outitems.Add(eItemname.itmMEKANSM)

  '      Case i Mod 5 = 0
  '        outitems.Add(eItemname.itmTOWN_PORTAL_SCROLL)
  '        outitems.Add(eItemname.itmCIRCLET)
  '        outitems.Add(eItemname.itmIRON_BRANCH)
  '        outitems.Add(eItemname.itmCLARITY)
  '        outitems.Add(eItemname.itmTANGO)
  '        outitems.Add(eItemname.itmMEKANSM)
  '    End Select
  '    outlist.Add(outitems)
  '  Next


  '  Dim outabslist As New List(Of String)
  '  For i As Integer = 0 To 25
  '    Dim outabs As New List(Of eAbilityName)

  '    Select Case i
  '      Case 0
  '        outabs.Add(Nothing)

  '      Case i Mod 1 = 0
  '        outabs.Add(eAbilityName.abFrost_Arrows)
  '        outabs.Add(eAbilityName.abGust)
  '        outabs.Add(eAbilityName.None)
  '        outabs.Add(eAbilityName.None)
  '      Case i Mod 2 = 0
  '        outabs.Add(eAbilityName.None)
  '        outabs.Add(eAbilityName.None)
  '        outabs.Add(eAbilityName.abMarksmanship)
  '        outabs.Add(eAbilityName.abPrecision_Aura)
  '      Case i Mod 3 = 0
  '        outabs.Add(eAbilityName.None)
  '        outabs.Add(eAbilityName.abGust)
  '        outabs.Add(eAbilityName.abMarksmanship)
  '        outabs.Add(eAbilityName.None)
  '      Case i Mod 4 = 0
  '        outabs.Add(eAbilityName.abFrost_Arrows)
  '        outabs.Add(eAbilityName.abGust)
  '        outabs.Add(eAbilityName.abMarksmanship)
  '        outabs.Add(eAbilityName.abPrecision_Aura)

  '      Case i Mod 5 = 0
  '        outabs.Add(eAbilityName.abFrost_Arrows)
  '        outabs.Add(eAbilityName.None)
  '        outabs.Add(eAbilityName.None)
  '        outabs.Add(eAbilityName.abPrecision_Aura)
  '    End Select
  '    ' outabslist.Add(outabs)
  '  Next


  '  'Dim Drowtest As New Hero_Build("Drow Test", _
  '  '                               eHeroName.untDrow_Ranger, _
  '  '                               outlist, _
  '  '                               outabslist)
  '  'Me.Add(Drowtest)
  'End Sub
  'Private Sub LoadDrowEmpty()
  '  Dim outlist As New List(Of List(Of eItemname))
  '  For i As Integer = 0 To 25
  '    Dim outitems As New List(Of eItemname)

  '    outitems.Add(eItemname.None)
  '    outitems.Add(eItemname.None)
  '    outitems.Add(eItemname.None)
  '    outitems.Add(eItemname.None)
  '    outitems.Add(eItemname.None)
  '    outitems.Add(eItemname.None)

  '    outlist.Add(outitems)
  '  Next

  '  Dim outablist As New List(Of List(Of eAbilityName))

  '  For i As Integer = 0 To 25
  '    Dim outabs As New List(Of eAbilityName)


  '    outabs.Add(eAbilityName.None)
  '    outabs.Add(eAbilityName.None)
  '    outabs.Add(eAbilityName.None)
  '    outabs.Add(eAbilityName.None)

  '    outablist.Add(outabs)
  '  Next

  '  'Dim DrowEmpty As New Hero_Build("Drow Empty", _
  '  '                                eHeroName.untDrow_Ranger, _
  '  '                                outlist, _
  '  '                                outablist)

  '  'Me.Add(DrowEmpty)
  'End Sub
End Class
