Imports System.Windows.Media.Imaging
Public Class ctrlImageThumb
  
  Public Sub New(unit As iDisplayUnit, portraitheight As Double, portraitwidth As Double) ',  thegame As dGame) ', theabilitylevel As Integer)
    InitializeComponent()

    LoadNewImage(unit)

    SetPortraitSize(portraitheight, portraitwidth)

  End Sub


  Public Sub HidePortrait(hideit As Boolean)
    If hideit Then
      thumbImage.Width = 0
    End If
  End Sub

  Public Sub SetPortraitSize(portraitheight As Double, portralwidth As Double)
    thumbImage.Height = portraitheight
    thumbImage.Width = portralwidth
  End Sub

  Public Sub LoadNewImage(unit As iDisplayUnit)

    Select Case unit.EntityName
      Case eEntity.Hero_Instance
        Dim hero As HeroInstance = DirectCast(unit, HeroInstance)
        Me.thumbImage.Source = PageHandler.dbImages.GetHeroImage(hero.HeroName)
        Me.swatch.Fill = New SolidColorBrush(hero.MyColor)

      Case eEntity.Ability_Info
        Dim ability As Ability_Info = DirectCast(unit, Ability_Info)
        Me.thumbImage.Source = PageHandler.dbImages.GetAbilityImage(ability.AbilityName)
        Me.swatch.Fill = New SolidColorBrush(PageHandler.dbColors.GetColor(ability))
      Case eEntity.Item_Info
        Dim item As Item_Info = DirectCast(unit, Item_Info)
        Me.thumbImage.Source = PageHandler.dbImages.GetItemImage(item.ItemName)
        Me.swatch.Fill = New SolidColorBrush(PageHandler.dbColors.GetColor(item))

      Case Else
        Throw New NotImplementedException
    End Select

  End Sub

End Class
