
Imports System.Threading
Imports System.ComponentModel
Imports System.Threading.Tasks
Imports System.IO
Public Class LoadingScreen



  'threading stuff
  Event WorkComplete(st As StartupItems)
  Public Sub New()
    InitializeComponent()
    Me.Cursor = Cursors.Wait
    Dim bw As New BackgroundWorker

    bw.WorkerSupportsCancellation = False
    bw.WorkerReportsProgress = True

    AddHandler bw.DoWork, AddressOf bw_DoWork
    bw.RunWorkerAsync()

    AddHandler bw.ProgressChanged, AddressOf bw_ProgressChanged
    AddHandler bw.RunWorkerCompleted, AddressOf bw_RunWorkerCompleted

    backimage.Width = Me.Width
    backimage.Height = Me.Height

    lblStatus.Foreground = New SolidColorBrush(Color.FromArgb(255, 183, 183, 183))
  End Sub




  Private Sub bw_DoWork(sender As Object, e As DoWorkEventArgs)
    Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)


    Dim swatch As New Stopwatch
    swatch.Start()

    Dim appdirectory = System.AppDomain.CurrentDomain.BaseDirectory

    Dim progressint As Integer = 1
    'worker.RunWorkerAsync(1)
    Dim outobj As New StartupItems
    outobj.theLog = New Logging("debug")
    worker.ReportProgress(progressint, "Log Loaded")
    progressint += 1

    outobj.mID = New dvID(New Guid("bde548aa-01a5-481d-8519-3b3089388174"), "Pagehandler ID", eEntity.Pagehandler)


    outobj.NoParentID = New dvID(New Guid("8e62cf0f-9861-48bf-8d98-be7454f7d0d5"), "Pagehandler/NoParentID", eEntity.None)

    outobj.theLog = New Logging(Path.Combine(appdirectory, "Logging"))

    outobj.dbNames = New FriendlyName_Database(outobj.theLog)
    worker.ReportProgress(progressint, "Friendly Names Loaded")
    progressint += 1


    outobj.dbColors = New Colors_Database(outobj.theLog)
    worker.ReportProgress(progressint, "Colors Loaded")
    progressint += 1

    outobj.mTimeKeeper = New TimeKeeper(Constants.cFramerate, Constants.cGameStartTime, Constants.cGameduration)
    worker.ReportProgress(progressint, "4th Dimension Loaded")
    progressint += 1

    'outobj.dbColors = New Colors_Database(outobj.theLog)
    'worker.ReportProgress(progressint, "Look at the pretty colors!")
    'progressint += 1

    outobj.dbFormulas = New Formula_Database(outobj.theLog, outobj.dbNames)
    worker.ReportProgress(progressint, "Formulas Loaded")
    progressint += 1




    outobj.dbItems = New item_Database(outobj.theLog, outobj.dbNames, outobj.dbColors)
    worker.ReportProgress(progressint, "Items Loading")
    progressint += 1

    outobj.dbItems.Load()
    worker.ReportProgress(progressint, "Items Loaded")
    progressint += 1

    outobj.dbAbilities = New ability_Database(outobj.theLog, outobj.dbNames)
    worker.ReportProgress(progressint, "Abilities Loading")
    progressint += 1

    outobj.dbAbilities.Load()
    worker.ReportProgress(progressint, "Abilites Loaded")
    progressint += 1






    outobj.dbHeroBuilds = New HeroBuild_Database()
    worker.ReportProgress(progressint, "Heroes Loading")
    progressint += 1

    outobj.dbHeroBuilds.load(outobj.dbItems, outobj.dbAbilities, outobj.mTimeKeeper, _
                            outobj.dbColors, outobj.dbFormulas, outobj.dbNames, outobj.dbImages, outobj.theLog)
    worker.ReportProgress(progressint, "Heroes Loaded")
    progressint += 1

    outobj.dbCreeps = New Creeps_and_Pets_Database(outobj.theLog, outobj.mTimeKeeper)
    worker.ReportProgress(progressint, "Creeps Loading")
    progressint += 1

    outobj.dbCreeps.load()
    worker.ReportProgress(progressint, "Creeps Loaded")
    progressint += 1

  
    outobj.dbImages = New Image_Database(outobj.dbNames, outobj.theLog)
    AddHandler outobj.dbImages.ImageDownloaded, Sub(message As String)
                                                  progressint += 1
                                                  worker.ReportProgress(progressint, message)
                                                End Sub
    worker.ReportProgress(progressint, "Images Loading")
    progressint += 1

    outobj.dbImages.Load(appdirectory, outobj.dbItems, outobj.dbAbilities, outobj.dbColors, outobj.dbHeroBuilds, outobj.dbCreeps)
    worker.ReportProgress(progressint, "Images Loaded")


    worker.ReportProgress(progressint, "Loading Interface")
    swatch.Stop()
    outobj.startupmsecs = swatch.ElapsedMilliseconds

    RaiseEvent WorkComplete(outobj)
    'outobj.TeamvTeam = New TeamvsTeam()


    ''menus
    'outobj.itemmenu = dbItems.ItemMenu


    'outobj.heromenu = dbHeroBuilds.HeroMenu
  
  End Sub

  Public Sub bw_ProgressChanged(sender As Object, e As ProgressChangedEventArgs)
    Dim msg As String = e.UserState

    UpdateStatus(msg)
  End Sub

  Public Sub UpdateStatus(msg As String)
    lblStatus.Content = msg
  End Sub
  Private Sub bw_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
    'Throw New NotImplementedException
  End Sub





End Class
