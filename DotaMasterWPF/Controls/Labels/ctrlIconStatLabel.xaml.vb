Imports System.Windows.Media.Imaging
Public Class ctrlIconStatLabel
  Implements iControlIO, iGameEntity


  Private mID As dvID
  Private myStattype As eStattype
  Private mMyHero As HeroInstance
  Private mMyStat As Stat
  Private mCurtime As ddFrame
  Public mTooltip As ToolTip
  Private mIconPath As String
  Private mValBrush As SolidColorBrush
  Private mHeadingTextBrush As SolidColorBrush
  Private mBodyTextBrush As SolidColorBrush
  Private mfontSize As Integer
  'Public Event StatTypeSelected( ddobj As DDObject)
  Private mIsSelected As Boolean = False
  Public Event SelectedChanged(gameentity As iGameEntity) Implements iControlIO.SelectedChanged
  Public Event isDirty(gameentity As iGameEntity) Implements iControlIO.isDirty

  Private mPrefix As String
  Private mSuffix As String
  Private mDecimalPlaces As Integer


  Public Sub New(curtime As ddFrame, iconpath As String, _
                    thestat As Stat, _
                   headingtextbrush As SolidColorBrush, bodytextbrush As SolidColorBrush, _
                   thevalcolor As SolidColorBrush, thefontsize As Double, _
                   theprefix As String, thesuffix As String, thedecimalplaces As Integer) '

    InitializeComponent()


    Me.mID = New dvID(Guid.NewGuid, "ctrlIconStatLabel/New", eEntity.ctrlIconStatLabel)

    LoadMe(curtime, iconpath, thestat, headingtextbrush, bodytextbrush, thevalcolor, thefontsize, theprefix, thesuffix, thedecimalplaces)

    mTooltip = New ToolTip
    Dim thick As New Thickness(0)
    ToolTipService.SetToolTip(Me, mTooltip)

    AddHandler Me.MouseEnter, AddressOf Me_MouseEnter
    AddHandler Me.MouseLeftButtonDown, AddressOf Me_MouseLeftButtonDown

  End Sub

  Private Sub LoadMe(curtime As ddFrame, iconpath As String, _
                        thestat As Stat, _
                      headingtextbrush As SolidColorBrush, bodytextbrush As SolidColorBrush, _
                      thevalcolor As SolidColorBrush, thefontsize As Double, _
                      theprefix As String, thesuffix As String, thedecimalplaces As Integer)
    myStattype = thestat.StatType
    mMyStat = thestat
    If mMyStat Is Nothing Then
      Dim x = 2
    End If
    mIconPath = iconpath
    mCurtime = curtime
    mPrefix = theprefix
    mSuffix = thesuffix
    mDecimalPlaces = thedecimalplaces
    mfontSize = thefontsize
    mValBrush = thevalcolor
    mHeadingTextBrush = headingtextbrush
    mBodyTextBrush = bodytextbrush
    LoadMe()

  End Sub

  Private Sub LoadMe()
    If Not mIconPath = "" Then

      Helpers.SetFileImageSource(mIconPath, ThumbImage)

      ThumbImage.Visibility = Windows.Visibility.Visible
    Else
      ThumbImage.Visibility = Windows.Visibility.Collapsed
    End If


    Dim val As Double? = mMyStat.Value(mCurtime)
    If val.HasValue Then
      Dim valdub As Double = val
      lblStatValue.Content = Math.Round(valdub, mDecimalPlaces).ToString & mSuffix
    Else
      lblStatValue.Content = "0" & mSuffix
    End If

    If Not mPrefix = "" Then
      lblStatName.Content = mPrefix
    Else
      lblStatName.Visibility = Windows.Visibility.Collapsed
    End If
    lblStatValue.Foreground = mHeadingTextBrush
    lblStatValue.FontFamily = Constants.cBodyFont
    lblStatValue.FontSize = mfontSize

    lblStatName.Foreground = mBodyTextBrush
    lblStatName.FontFamily = Constants.cBodyFont
    lblStatName.FontSize = mfontSize

    'lblStatValue.CharacterSpacing = 100
  End Sub

  Public Sub RefreshStat()
    ' mMyStat = mMyHerobuild.mGame.dbModifiers.GetStatByParentIDandType(mMyHerobuild.ID, myStattype)
    LoadMe()
  End Sub

  Public Sub UpdateValue(curtime As ddFrame)

    mCurtime = curtime

    Dim val As Double? = mMyStat.Value(mCurtime)
    If val.HasValue Then
      Dim valdub As Double = val
      lblStatValue.Content = Math.Round(valdub, mDecimalPlaces).ToString & mSuffix
    Else
      lblStatValue.Content = "0" & mSuffix
    End If

  End Sub

  Public Sub SetSelected(isselected As Boolean) Implements iControlIO.SetSelected
    mIsSelected = isselected
  End Sub

  Public Sub calcmods() Implements iGameEntity.calcmods

  End Sub
#Region "Info"
  Public Property MyColor As Color Implements iGameEntity.MyColor
    Get
      Return mMyStat.MyColor
    End Get
    Set(value As Color)

    End Set
  End Property
  Public ReadOnly Property mStat As Stat
    Get
      Return mMyStat
    End Get
  End Property

  Public ReadOnly Property IsSelected As Boolean Implements iControlIO.IsSelected
    Get
      Return mIsSelected
    End Get
  End Property

  Public Property DisplayName As String Implements iGameEntity.DisplayName
    Get
      Return "Icon Stat Label"
    End Get
    Set(value As String)

    End Set
  End Property
  Public Property EntityName As eEntity Implements iGameEntity.EntityName
    Get
      Return eEntity.ctrlIconStatLabel
    End Get
    Set(value As eEntity)

    End Set
  End Property

  Public Property Id As dvID Implements iGameEntity.Id
    Get
      Return Me.mID
    End Get
    Set(value As dvID)

    End Set
  End Property

  Public Property MyType As eSourceType Implements iGameEntity.MyType
    Get
      Return eSourceType.Control
    End Get
    Set(value As eSourceType)

    End Set
  End Property

  Public Property ParentGameEntity As iGameEntity Implements iGameEntity.ParentGameEntity
    Get
      Return Nothing
    End Get
    Set(value As iGameEntity)

    End Set
  End Property

  Public Property ParentGameEntityType As eSourceType Implements iGameEntity.ParentGameEntityType
    Get
      Return Nothing
    End Get
    Set(value As eSourceType)

    End Set
  End Property
#End Region

#Region "Event Handlers"
  Private Sub Me_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs)
    mIsSelected = True
    RaiseEvent SelectedChanged(Me)
  End Sub

  Private Sub Me_MouseEnter(sender As Object, e As MouseEventArgs)
    Dim contents = mMyStat.GetFriendlyFormula(mCurtime)

    Dim tt As New ctrlText_Tooltip(contents)
    mTooltip.Content = tt

  End Sub
#End Region














 
End Class
