#Const DEVMODE = True
Imports System.Windows.Media.Imaging

Public Class HeroBuild

  Private mID As dvID
  Public mHero As Hero
  Public mBuild As Build

  Private mGoldCurve As EconomyCurve
  Private mXPCurve As EconomyCurve


  Event isDirty(thehero As HeroBuild)

  Public Sub New(thehero As Hero, thebuild As Build, _
                  thexpcurve As EconomyCurve, thegoldcurve As EconomyCurve)

    mID = thebuild.IDItem
    mHero = thehero

    mBuild = thebuild
    mBuild.mImage = thehero.UnitImage

    mBuild.PriorityLevel = thebuild.PriorityLevel

  End Sub

#Region "Info"
  Public ReadOnly Property ID As dvID
    Get
      Return mID
    End Get
  End Property
  Public ReadOnly Property FriendlyName As String
    Get
      Return mHero.FriendlyName
    End Get
  End Property

  Public ReadOnly Property UnitImage As String
    Get
      Return mHero.UnitImage
    End Get
  End Property

  Public Property GoldCurve As EconomyCurve
    Get
      Return mGoldCurve
    End Get
    Set(value As EconomyCurve)
      mGoldCurve = GoldCurve
    End Set
  End Property

  Public Property XPCurve As EconomyCurve
    Get
      Return mXPCurve
    End Get
    Set(value As EconomyCurve)
      mXPCurve = XPCurve
    End Set
  End Property

  Public ReadOnly Property PrimaryStat() As ePrimaryStat
    Get
      Return mHero.PrimaryStat
    End Get
  End Property
#End Region
  
End Class
