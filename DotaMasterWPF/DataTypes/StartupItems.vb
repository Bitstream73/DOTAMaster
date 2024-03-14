Public Class StartupItems
  Public mID As dvID

  Public NoParentID As dvID

  Public mTimeKeeper As TimeKeeper

  Public mSelectedColor As SolidColorBrush


  Public hBundles As HeroBundles

  Public dbColors As Colors_Database

  Public dbItems As item_Database

  Public dbAbilities As ability_Database

  Public dbHeroBuilds As HeroBuild_Database

  Public dbCreeps As Creeps_and_Pets_Database

  'Public dbModifiers As Modifier_Database

  Public dbFormulas As Formula_Database

  'Public Shared manEconomy As EconomyManager
  Public dbNames As FriendlyName_Database

  Public theLog As Logging

  Public mSettings As Settings


  Public dbImages As Image_Database

  Public startupmsecs As Integer
  Public Sub New()

    'mSelectedColor = New SolidColorBrush(Color.FromArgb(255, 255, 255, 0))
    mSettings = New Settings
  End Sub
End Class
