Public Class Constants
  Public Shared cStartingGold As Double = 625
  Public Shared cPeriodicgGoldPerSec As Double = 0.6

  Public Shared cMapWidth As Integer = 17408
  Public Shared cMapHeight As Integer = 15872

  'For AoE abilities. Radius determines how many units struck
  Public Shared cMaxSmallRadius As Integer = 200
  Public Shared cMaxSmallArea As Integer = (cMaxSmallRadius * cMaxSmallRadius * Math.PI)
  Public Shared cSmallEnemyCount As Integer = 2

  Public Shared cMaxMedRadius As Integer = 400
  Public Shared cMaxMedArea As Integer = (cMaxMedRadius * cMaxMedRadius * Math.PI)
  Public Shared cMedEnemyCount As Integer = 4


  'large radius is any value greater than maxMedRadius
  Public Shared cLrgEnemyCount As Integer = 7 '5 heroes, a pack of lane creeps, and a tower... theoretically

  Public Shared cMapWideRadius As Integer = -1
  Public Shared cMapWideArea As Integer = cMapHeight * cMapWidth

  'constants, exposed through mTimeKeeper
  Public Shared cGameStartTime As New ddFrame(0) 'DateTime = New DateTime(1, 1, 1, 0, 0, 0)
  Public Shared cGameduration As ddFrame = New ddFrame(60 * 60) 'TimeSpan '= New TimeSpan(1, 30, 0)
  Public Shared cGameEndTime As ddFrame = New ddFrame(cGameStartTime.count + cGameduration.count) 'DateTime
  Public Shared cFramerate As New ddFrame(10) 'TimeSpan = New TimeSpan(0, 0, 1) 'sets the smallest slice of gametime for analysis
  Public Shared cDayNightFrameCount As Integer = 240
  Public Shared cDefaultLifetime As New Lifetime(New ddFrame(0), New ddFrame(60 * 60))


  Public Shared cBarTimePointCount As Integer = 1 'this is misleading after change to how mtimekeeper.timepoints works now since it already spits out a subset of all possible timepoints making this setting somewhat redundant


  Public Shared cSwatchMinimalLargeWidth As Integer = 15
  Public Shared cSwatchMinimalLargeHeight As Integer = 15

  Public Shared cSwatchMinimalSmallWidth As Integer = 10
  Public Shared cSwatchMinimalSmallHeight As Integer = 10

  Public Shared cHeadingFont As New FontFamily("Segoe UI") '"Georgia")
  Public Shared cHeadingFontSize As Integer = 19

  Public Shared cSubHeadingFont As New FontFamily("Segoe UI")
  Public Shared cSubHeadingFontSize As Integer = 16

  'Public Shared cbodyFont As New FontFamily("Helvetica")
  Public Shared cBodyFont As New FontFamily("Arial")
  Public Shared cBodyFontSize As Double = 11.5
  Public Shared cSubtextFontSize As Double = 9
  Public Shared cModifierFontSize As Double = 11

  'Buttons
  Public Shared cMinBtnTextSize As Double = 7
  Public Shared cMinbtnHeight As Double = 16
  Public Shared cMinBtnMargin As New Thickness(4)
  Public Shared cMinBtnStrokeThickness As Double = 1

  Public Shared cMaxAttackSpeed = 600

  'kills
  Public Shared cGoldPerKill As Integer = 3000

  'IO
  Public Shared cRootPath As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)

  Public Shared mSelectedColor As New SolidColorBrush(Color.FromArgb(255, 255, 255, 0))
End Class
