#Const DEVMODE = True

Imports System.Windows.Media.Imaging
Public Class ctrlItem_Thumb
  Implements iControlIO, iGameEntity


  Private mID As dvID
  'Private mItemList As List(Of ctrlitem_List_Item)
  Private mItem As Item_Info
  Private mGame As dGame
  'Public mDetails As ctrlItem_Details
  Private defaultswatch As New SolidColorBrush(Color.FromArgb(255, 128, 128, 128))
  Private mcolor As Color
  Public Event isDirty(gameentity As iGameEntity) Implements iControlIO.isDirty

  Public Event SelectedChanged(gameentity As iGameEntity) Implements iControlIO.SelectedChanged



  Private mIsSelected As Boolean = False
  Public Sub New()
    InitializeComponent()

    Me.mID = New dvID(Guid.NewGuid, "ctrlItem_Thumb/New", eEntity.ctrlItem_Thumb)
    AddHandler thumbImage.MouseLeftButtonDown, AddressOf Me_MouseLeftButtonDown

    SetSelected(False)
    '  SetBtnStateVisibility(False)

  End Sub


  Public Sub SetUnresponsive(height As Double)
    RemoveHandler Me.MouseLeftButtonDown, AddressOf Me_MouseLeftButtonDown
    Dim oldwidth = LayoutRoot.Width - colSwatch.Width.Value
    Dim oldheight = LayoutRoot.Height
    LayoutRoot.Width = ((height * oldwidth) / oldheight) + colSwatch.Width.Value
    LayoutRoot.Height = height

    rectSelected.Visibility = Windows.Visibility.Collapsed

  End Sub
  Public Sub LoadItem(theitem As Item_Info, thegame As dGame)
    If theitem Is mItem Then Exit Sub

    mItem = theitem

    mcolor = PageHandler.dbColors.GetColor(theitem)

    mGame = thegame



    If Not theitem Is Nothing Then
      mItem.LoadStates(mGame.dbItems.GetItemStateAndUrls(theitem.ItemName))

      If Not theitem.States Is Nothing Then

        If theitem.States.Count > 1 Then

          Dim dbcolors = PageHandler.dbColors
          'btnState.LoadButton(theitem.States, _
          '                    New SolidColorBrush(dbcolors.ButtonColorSelected), New SolidColorBrush(dbcolors.ButtonColorNotSelected), _
          '                    New SolidColorBrush(dbcolors.HeadingTextColor), Constants.cMinBtnTextSize, Constants.cMinbtnHeight, Constants.cMinBtnMargin)

          ' SetBtnStateVisibility(True)
          ' btnState.SetState(mItem.CurrentStateIndex)
        Else
          '  SetBtnStateVisibility(False)
          mItem.CurrentStateIndex = -1 'default for stateless objects
        End If

      Else
        'SetBtnStateVisibility(False)
        mItem.CurrentStateIndex = -1 'default for stateless objects
      End If


      Dim myparent = mItem.ParentGameEntity
      Dim etarg = mGame.GetEnemyTarget(myparent)
      Dim ftarg = mGame.GetFriendlyTarget(myparent)
      mItem.SetTargets(etarg, ftarg, mGame.GetFriendBias(myparent))
      Me.thumbImage.Source = PageHandler.dbImages.GetItemImage(theitem.ItemName)

      Me.swatch.Fill = New SolidColorBrush(PageHandler.dbColors.GetColor(theitem))
    Else
      Me.thumbImage.Source = Nothing
      swatch.Fill = defaultswatch
      ' btnState.SetAsActive(False)

    End If

  End Sub

  Public Sub SetSelected(isselected As Boolean) Implements iControlIO.SetSelected
    If isselected Then
      mIsSelected = True
      rectSelected.Visibility = Windows.Visibility.Visible
    Else
      mIsSelected = False
      rectSelected.Visibility = Windows.Visibility.Collapsed
    End If

  End Sub




  Public Sub calcmods() Implements iGameEntity.calcmods

  End Sub


  'Private Sub SetBtnStateVisibility( isvisible As Boolean)
  '  If isvisible Then
  '    AddHandler btnState.Click, AddressOf btnState_Click
  '    btnState.Foreground = New SolidColorBrush(PageHandler.dbColors.HeadingTextColor)
  '    btnState.SetAsActive(True)
  '  Else
  '    RemoveHandler btnState.Click, AddressOf btnState_Click
  '    btnState.Foreground = New SolidColorBrush(PageHandler.dbColors.Transparent)
  '    btnState.Background = btnState.Foreground
  '    btnState.SetAsActive(False)
  '  End If
  'End Sub

#Region "Info"
  Public ReadOnly Property MyItem As Item_Info
    Get
      Return mItem
    End Get
  End Property
  Public ReadOnly Property IsSelected As Boolean Implements iControlIO.IsSelected
    Get
      Return mIsSelected
    End Get
  End Property

  Public ReadOnly Property CurrentStateIndex As Integer
    Get
      Return mItem.CurrentStateIndex
    End Get
  End Property

  Public Property DisplayName As String Implements iGameEntity.DisplayName
    Get
      Return "ctrlItem_Thumb"
    End Get
    Set(value As String)

    End Set
  End Property

  Public Property EntityName As eEntity Implements iGameEntity.EntityName
    Get
      Return eEntity.ctrlItem_Thumb
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
      Return eSourceType.None
    End Get
    Set(value As eSourceType)

    End Set
  End Property
#End Region

#Region "Event Handlers"
  Private Sub Me_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs)
    If mIsSelected Then
      SetSelected(False)
    Else
      SetSelected(True)
    End If

    RaiseEvent SelectedChanged(Me)
  End Sub

  Private Sub btnState_Click(btn As btnMinimalState)
    mItem.CurrentStateIndex = mItem.CurrentStateIndex + 1
    Me.thumbImage.Source = PageHandler.dbImages.GetItemImage(mItem.ItemName)
    RaiseEvent isDirty(Me)
  End Sub

#End Region



  Public Property MyColor As Color Implements iGameEntity.MyColor
    Get
      Return mcolor
    End Get
    Set(value As Color)

    End Set
  End Property
End Class
