#Const devmode = True

Imports System.Windows.Media.Imaging


Public Class ctrlUnit_Menu_Item_Name
  Public mHero As HeroInstance
  Public mUnitFriendlyName As String
  Public mUnitFriendlyID As String
  Public mBitmap As BitmapImage
  'Public mTooltip As ToolTip
  '  Public Sub New( theunit As DDObject)
  '    InitializeComponent()

  '    mUnit = theunit

  '    'will eventually have to add pet and npcunittypes
  '    Select Case theunit.type
  '      Case eEntity.Hero_Instance

  '      Case Else
  '        Dim x = 2

  '    End Select

  '#If devmode Then
  '    lblHeroName.Content = mUnitFriendlyName & " " & mUnitFriendlyID

  '#Else
  '    lblHeroName.Content = munitfriendlyname

  '#End If


  '  End Sub

  Public Sub New(theunit As HeroInstance)
    InitializeComponent()

    mHero = theunit
    mUnitFriendlyName = theunit.DisplayName
    lblHeroName.Content = mUnitFriendlyName
    mUnitFriendlyID = theunit.ID.FriendlyGuid
    mBitmap = PageHandler.dbImages.GetHeroImage(theunit.HeroName)

    Me.ImageThumb.Source = mBitmap


  End Sub
End Class
