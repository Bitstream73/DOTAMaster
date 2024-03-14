Imports System.IO
Imports System.Net
Public Class Image_Database

  ' Private ItemBitmaps As New Dictionary(Of eItemname, BitmapImage)
  Private ItemURLs As New Dictionary(Of eItemname, Uri)

  ' Private Herobitmaps As New Dictionary(Of eHeroName, BitmapImage)
  Private HeroURLS As New Dictionary(Of eHeroName, Uri)

  ' Private AbilityBitmaps As New Dictionary(Of eAbilityName, BitmapImage)
  Private AbilityURLs As New Dictionary(Of eAbilityName, Uri)

  ' Private CreepBitmaps As New Dictionary(Of eCreepName, BitmapImage)
  Private CreepURLs As New Dictionary(Of eCreepName, Uri)

  ' Private PetBitmaps As New Dictionary(Of ePetName, BitmapImage)
  Private PetURLs As New Dictionary(Of ePetName, Uri)

  Private mIDItem As dvID
  Private dbItems As item_Database
  Private dbAbilities As ability_Database
  Private dbHeroes As HeroBuild_Database
  Private dbCreeps As Creeps_and_Pets_Database
  Private dbColors As Colors_Database

  Private mRootDir As String
  Private mImageFolderPath As String

  Private mHeroImageFolderPath As String
  Private mItemImageFolderPath As String
  Private mAbilityImageFolderPath As String
  Private mCreepImagefolderPath As String
  Private mPetImageFolderPath As String

  Event ImageDownloaded(filename As String)

  Private mErrorImageFilepath As String
  'Private mErrorBitmap As BitmapImage

  Private dbNames As FriendlyName_Database
  Private mLog As iLogging

  Private reader As WebClient
  Public Sub New(friendlynames As FriendlyName_Database, log As iLogging)
    dbNames = friendlynames
    mLog = log

    mIDItem = New dvID(New Guid("68a4ff69-a736-46d0-b38d-ee4fd565ca58"), "Image_Database/New", eEntity.ImageDatabase)

    reader = New WebClient
  End Sub
  Public Sub Load(applicationrootdir As String, _
                   itemdb As item_Database, abilitydb As ability_Database, _
                  thecolordb As Colors_Database, _
                   herodb As HeroBuild_Database, creepdb As Creeps_and_Pets_Database)

    dbItems = itemdb
    dbAbilities = abilitydb
    dbHeroes = herodb
    dbCreeps = creepdb
    dbColors = thecolordb

    mRootDir = applicationrootdir

    mErrorImageFilepath = Path.Combine(applicationrootdir, "Assets\missingimage.jpg")
    'mErrorBitmap = 

    mImageFolderPath = Path.Combine(mRootDir, "Images")
    If Not Directory.Exists(mImageFolderPath) Then
      Directory.CreateDirectory(mImageFolderPath)
    End If

    mHeroImageFolderPath = Path.Combine(mImageFolderPath, "Heroes")
    If Not Directory.Exists(mHeroImageFolderPath) Then
      Directory.CreateDirectory(mHeroImageFolderPath)
    End If


    mItemImageFolderPath = Path.Combine(mImageFolderPath, "Items")
    If Not Directory.Exists(mItemImageFolderPath) Then
      Directory.CreateDirectory(mItemImageFolderPath)
    End If

    mAbilityImageFolderPath = Path.Combine(mImageFolderPath, "Abilities")
    If Not Directory.Exists(mAbilityImageFolderPath) Then
      Directory.CreateDirectory(mAbilityImageFolderPath)
    End If

    mCreepImagefolderPath = Path.Combine(mImageFolderPath, "Creeps")
    If Not Directory.Exists(mCreepImagefolderPath) Then
      Directory.CreateDirectory(mCreepImagefolderPath)
    End If

    mPetImageFolderPath = Path.Combine(mImageFolderPath, "Pets")
    If Not Directory.Exists(mPetImageFolderPath) Then
      Directory.CreateDirectory(mPetImageFolderPath)
    End If

    LoadItems(mItemImageFolderPath)
    LoadAbilities(mAbilityImageFolderPath)
    LoadHeroes(mHeroImageFolderPath)
    LoadCreeps(mCreepImagefolderPath)
    LoadPets(mPetImageFolderPath)
    'items
    'Dim EnumItems = System.Enum.GetValues(GetType(eItemname))
    'For Each item In EnumItems
    '  If Not item Is Nothing Then
    '    If Not item = eItemname.None Then
    '      If item = eItemname.itmPERSEVERANCE Then
    '        Dim x = 2
    '      End If
    '      Dim theIInfo = dbItems.GetItemInfo(item, mIDItem, Constants.cDefaultLifetime)
    '      Dim theuri As New Uri(theIInfo.ImageUrl, UriKind.Absolute)
    '      Dim thebit = New BitmapImage(theuri)
    '      ItemBitmaps.Add(item, thebit)
    '    End If
    '  End If
    'Next


    ''heroes
    'EnumItems = System.Enum.GetValues(GetType(eHeroName))
    'For Each item In EnumItems
    '  If Not item Is Nothing And Not item = eHeroName.None Then

    '    Dim theherobuild As HeroBuild = dbHeroes.GetFirstBuildForHero(item)
    '    Dim theuri As New Uri(theherobuild.mHero.UnitImage, UriKind.Absolute)
    '    Dim thebit = New BitmapImage(theuri)
    '    Herobitmaps.Add(item, thebit)

    '  End If
    'Next
  End Sub

  Private Sub LoadItems(itempath As String)
    'items
    Dim EnumItems = System.Enum.GetValues(GetType(eItemname))
    For Each item In EnumItems
      Try
        If Not item = eItemname.None Then

          Dim curitem = dbItems.GetItemInfoNoParent(item)
          Dim theuri As New Uri(curitem.ImageUrl, UriKind.Absolute)
          If Not ItemURLs.ContainsKey(curitem.ItemName) Then
            ItemURLs.Add(curitem.ItemName, theuri)
          End If


          Dim imagefilepath = Path.Combine(itempath, Path.GetFileName(theuri.AbsolutePath))

          If Not File.Exists(imagefilepath) Then
            WriteImageTodisc(curitem.DisplayName, theuri, imagefilepath)

          End If

          Dim thebmp = GetBitmap(New Uri(imagefilepath))
          dbColors.AddColor(curitem, GetColorForBitmapImage(thebmp))
   
        End If
      Catch ex As Exception
        Dim x = 2
      End Try

    Next
  End Sub

  Private Sub LoadHeroes(heropath As String)
    'items
    Dim EnumItems = System.Enum.GetValues(GetType(eHeroName))
    For Each item In EnumItems
      If Not item = eHeroName.None Then

        Dim curhero = dbHeroes.GetFirstBuildForHero(item)
        Dim theuri As New Uri(curhero.UnitImage, UriKind.Absolute)

        If Not HeroURLS.ContainsKey(curhero.mHero.Name) Then
          HeroURLS.Add(curhero.mHero.Name, theuri)
        End If


        Dim imagefilepath = Path.Combine(heropath, Path.GetFileName(theuri.AbsolutePath))

        If Not File.Exists(imagefilepath) Then
          WriteImageTodisc(curhero.FriendlyName, theuri, imagefilepath)

        End If

        Dim thebmp = GetBitmap(New Uri(imagefilepath))
        dbColors.AddColor(curhero.mHero.Name, GetColorForBitmapImage(thebmp))
        'If File.Exists(imagefilepath) Then
        '  If Not Herobitmaps.ContainsKey(curhero.Name) Then
        '    Herobitmaps.Add(curhero.Name, ReadFromDisc(New Uri(imagefilepath, UriKind.Absolute)))
        '    RaiseEvent ImageDownloaded(curhero.FriendlyName & " Loaded")
        '  End If

        'End If

      End If
    Next
  End Sub

  Private Sub LoadAbilities(abilitypath As String)

    'Dim ind As Integer = 0
    Dim EnumItems = System.Enum.GetValues(GetType(eAbilityName))
    For Each item In EnumItems
      If Not item = eHeroName.None Then

        Dim curability As Ability_Info = dbAbilities.GetAbilityInfoNoParent(item)
        If Not curability Is Nothing Then
          'curability.mFriendlyName = dbNames.GetFriendlyAbilityName(curability.mName)


          Dim theuri As New Uri(curability.ImageUrl, UriKind.Absolute)

          If Not AbilityURLs.ContainsKey(curability.AbilityName) Then


            AbilityURLs.Add(curability.AbilityName, theuri)


          End If


          Dim imagefilepath = Path.Combine(abilitypath, Path.GetFileName(theuri.AbsolutePath))

          If Not File.Exists(imagefilepath) Then
            WriteImageTodisc(curability.DisplayName, theuri, imagefilepath)

          End If

          Dim thebmp = GetBitmap(New Uri(imagefilepath))
          dbColors.AddColor(curability.AbilityName, GetColorForBitmapImage(thebmp))
          'If File.Exists(imagefilepath) Then
          '  If Not AbilityBitmaps.ContainsKey(curability.mName) Then
          '    AbilityBitmaps.Add(curability.mName, ReadFromDisc(New Uri(imagefilepath, UriKind.Absolute)))
          '    RaiseEvent ImageDownloaded(curability.mFriendlyName & " Loaded")
          '  End If

          'End If
        End If


      End If
      'ind += 1
      'mLog.WriteLog(ind.ToString)
    Next
  End Sub

  Private Sub LoadCreeps(creeppath As String)

    Dim EnumItems = System.Enum.GetValues(GetType(eCreepName))
    For Each item In EnumItems
      If Not item = eCreepName.None Then

        Dim creepimage = dbCreeps.GetCreepImageURL(item)
        If Not creepimage = "" Then

          Dim mFriendlyName = dbNames.GetFriendlyCreepName(item)
          Dim theuri As New Uri(creepimage, UriKind.Absolute)

          If Not CreepURLs.ContainsKey(item) Then
            CreepURLs.Add(item, theuri)
          End If

          Dim imagefilepath = Path.Combine(creeppath, Path.GetFileName(theuri.AbsolutePath))

          If Not File.Exists(imagefilepath) Then
            WriteImageTodisc(mFriendlyName, theuri, imagefilepath)

          End If


          Dim thebmp = GetBitmap(New Uri(imagefilepath))
          dbColors.AddColor(item, GetColorForBitmapImage(thebmp))
          'If File.Exists(imagefilepath) Then
          '  If Not AbilityBitmaps.ContainsKey(item) Then
          '    CreepBitmaps.Add(item, ReadFromDisc(New Uri(imagefilepath, UriKind.Absolute)))
          '    RaiseEvent ImageDownloaded(mFriendlyName & " Loaded")
          '  End If

          'End If
        End If


      End If
    Next
  End Sub

  Private Sub LoadPets(petpath As String)

    Dim EnumItems = System.Enum.GetValues(GetType(ePetName))
    For Each item In EnumItems
      If Not item = ePetName.None Then

        Dim petimage = dbCreeps.GetPetImageUrl(item)
        If Not petimage = "" Then

          Dim mFriendlyName = dbNames.GetFriendlyPetName(item)
          Dim theuri As New Uri(petimage, UriKind.Absolute)

          If Not PetURLs.ContainsKey(item) Then
            PetURLs.Add(item, theuri)
          End If

          Dim imagefilepath = Path.Combine(petpath, Path.GetFileName(theuri.AbsolutePath))

          If Not File.Exists(imagefilepath) Then
            WriteImageTodisc(mFriendlyName, theuri, imagefilepath)

          End If


          Dim thebmp = GetBitmap(New Uri(imagefilepath))
          dbColors.AddColor(item, GetColorForBitmapImage(thebmp))
          'If File.Exists(imagefilepath) Then
          '  If Not AbilityBitmaps.ContainsKey(item) Then
          '    CreepBitmaps.Add(item, ReadFromDisc(New Uri(imagefilepath, UriKind.Absolute)))
          '    RaiseEvent ImageDownloaded(mFriendlyName & " Loaded")
          '  End If

          'End If
        End If


      End If
    Next
  End Sub

  'Private Function GetColorForBitmapImage(thebmp As BitmapImage) As Color

  '  Dim height As Integer = thebmp.PixelHeight
  '  Dim width As Integer = thebmp.PixelWidth
  '  Dim nStride As Integer = (thebmp.PixelWidth * thebmp.Format.BitsPerPixel + 7) / 8
  '  Dim pixelByteArray() As Byte = New Byte(thebmp.PixelHeight * nStride) {}
  '  thebmp.CopyPixels(pixelByteArray, nStride, 0)


  '  Dim midpixindex As Integer = ((pixelByteArray.Count / 4) / 2) * 4
  '  Dim alpha = pixelByteArray(midpixindex + 3)
  '  Dim r = pixelByteArray(midpixindex)
  '  Dim g = pixelByteArray(midpixindex + 1)
  '  Dim b = pixelByteArray(midpixindex + 2)

  '  Dim thecolor = Color.FromArgb(alpha, r, g, b)
  '  RaiseEvent ImageDownloaded(alpha.ToString & " " & r.ToString & " " & g.ToString & " " & b.ToString)

  '  Return thecolor
  'End Function


  Private Function GetColorForBitmapImage(thebmp As BitmapImage) As Color
    Dim height As Integer = thebmp.PixelHeight
    Dim width As Integer = thebmp.PixelWidth
    Dim nStride As Integer = (thebmp.PixelWidth * thebmp.Format.BitsPerPixel + 7) / 8
    Dim pixelByteArray() As Byte = New Byte(thebmp.PixelHeight * nStride) {}
    thebmp.CopyPixels(pixelByteArray, nStride, 0)


    Dim midpixindex As Integer = ((pixelByteArray.Count / 4) / 2) * 4
    'Dim alpha = pixelByteArray(midpixindex + 3)
    'Dim r = pixelByteArray(midpixindex)
    'Dim g = pixelByteArray(midpixindex + 1)
    'Dim b = pixelByteArray(midpixindex + 2)

    'Dim curbytes() As Byte
    Dim curhsb As objHSB

    Dim outcolor As Color
    Dim alpha As Byte = 255
    Dim r As Byte
    Dim g As Byte
    Dim b As Byte

       For i As Integer = midpixindex To midpixindex + 400 Step 4
      r = pixelByteArray(i + 1)
      g = pixelByteArray(i + 2)
      b = pixelByteArray(i + 3)


      curhsb = RGBtoHSB(Color.FromArgb(alpha, r, g, b))

      If curhsb.Bri > 0.6 And curhsb.Sat > 0.25 Then
        outcolor = Color.FromArgb(255, r, g, b)
        Exit For
      End If

    Next


    If outcolor = Nothing Then
      r = midpixindex + 1
      g = midpixindex + 2
      b = midpixindex + 3


      curhsb = RGBtoHSB(Color.FromArgb(255, r, g, b))

      If curhsb.Sat < 0.25 Then
        curhsb.Sat = 0.25
      End If

      If curhsb.Bri < 0.6 Then curhsb.Bri = 0.6



      outcolor = HSBToRGB(curhsb)
    End If

    ' Dim outcolor = Color.FromArgb(128, 128, 128, 128)
    Return outcolor
  End Function

  Public Shared Function RGBtoHSB(thergb As Color) As objHSB
    Dim min As Double
    Dim max As Double
    Dim delta As Double

    Dim inR As Double = thergb.R / 256
    Dim inG As Double = thergb.G / 256
    Dim inB As Double = thergb.B / 256

    Dim outH As Double
    Dim outS As Double
    Dim outB As Double

    min = Math.Min(inR, inG)
    min = Math.Min(min, inB)

    max = Math.Max(inR, inG)
    max = Math.Max(max, inB)
    outB = max

    delta = max - min

    'If delta = 0 Then
    '  Dim x = 2
    'End If

    If Not max = 0 Then
      outS = delta / max
    Else
      outS = 0
      outH = -1
    End If


    If inR = max Then
      outH = (inG - inB) / delta
    ElseIf inG = max Then
      outH = 2 + (inB - inR) / delta
    Else
      outH = 4 + (inR - inG) / delta
    End If

    outH *= 60

    If outH < 0 Or outH > 360 Then
      Dim x = 2
    End If
    If outH < 0 Then outH = 360
    If delta = 0 Then outH = 360

    If outS < 0.25 Then
      Dim x = 2
    End If
    Dim i = Math.Floor(outH)
    Return New objHSB(outH, outS, outB)
  End Function

  Public Shared Function HSBToRGB(thehsb As objHSB) As Color

    Dim i As Integer

    Dim inH = thehsb.Hue

    Dim inS = thehsb.Sat
    Dim inB = thehsb.Bri

    Dim ouTR As Double
    Dim outG As Double
    Dim outB As Double

    Dim f As Double
    Dim p As Double
    Dim q As Double
    Dim t As Double



    If inS = 0 Then
      Return Color.FromArgb(255, inB, inB, inB)
    End If

    inH /= 60
    i = Math.Floor(inH)
    'If inH < 0 Or inH > 360 Or inH = Nothing Then
    '  Dim x = 2
    'End If


    f = inH - i
    p = inB * (1 - inS)
    q = inB * (1 - inS * f)
    t = inB * (1 - inS * (1 - f))

    Select Case i
      Case 0
        ouTR = inB
        outG = t
        outB = p

      Case 1
        ouTR = q
        outG = inB
        outB = p
      Case 2
        ouTR = p
        outG = inB
        outB = t
      Case 3
        ouTR = p
        outG = q
        outB = inB
      Case 4
        ouTR = t
        outG = p
        outB = inB
      Case Else
        ouTR = inB
        outG = p
        outB = q
    End Select


    Return Color.FromArgb(255, ouTR * 256, outG * 256, outB * 256)

  End Function
  Private Sub WriteImageTodisc(name As String, url As Uri, filepath As String)
    If name.Contains("Ice") And name.Contains("Armor") Then
      Dim x = 2
    End If

    Try

      reader.DownloadFile(url, filepath)
      RaiseEvent ImageDownloaded(Path.GetFileName(url.LocalPath) & " downloaded")
    Catch ex As WebException
      If File.Exists(filepath) Then
        File.Delete(filepath)
      End If
      RaiseEvent ImageDownloaded(Path.GetFileName(url.LocalPath) & "failed to download")
      mLog.WriteLog("Image_Database.writeimagetodisc: " & ex.Message & " for " & url.LocalPath)
    End Try




  End Sub

  Private Function ReadFromDisc(filepath As Uri) As BitmapImage
    Dim outimage = New BitmapImage(New Uri(mErrorImageFilepath))

    Dim fi As FileInfo = New FileInfo(filepath.LocalPath)
    If fi.Length = 0 Then
      File.Delete(filepath.LocalPath)
    Else
      Try
        outimage = New BitmapImage(filepath)
      Catch ex As Exception
        mLog.WriteLog("Image_Database.ReadFromDisc: " & ex.Message & " for " & filepath.LocalPath)
        outimage = New BitmapImage(New Uri(mErrorImageFilepath))
      End Try

    End If


    Return outimage
  End Function

  Public Function GetItemImage(itemname As eItemname) As BitmapImage
    If ItemURLs.ContainsKey(itemname) Then
      Dim imagefilepath = New Uri(Path.Combine(mItemImageFolderPath, Path.GetFileName(ItemURLs.Item(itemname).AbsolutePath)))

      Return GetBitmap(imagefilepath)
    Else
      Return New BitmapImage(New Uri(mErrorImageFilepath))
    End If

  End Function

  Public Function GetHeroImage(heroname As eHeroName) As BitmapImage
    'If Herobitmaps.ContainsKey(heroname) Then
    '  Return Herobitmaps.Item(heroname)
    'End If
    If HeroURLS.ContainsKey(heroname) Then
      Dim imagefilepath = New Uri(Path.Combine(mHeroImageFolderPath, Path.GetFileName(HeroURLS.Item(heroname).AbsolutePath)))

      Return GetBitmap(imagefilepath)
    Else
      Return New BitmapImage(New Uri(mErrorImageFilepath))
    End If

  End Function

  Public Function GetPetImage(petname As ePetName) As BitmapImage
    Throw New NotImplementedException
  End Function
  Public Function GetCreepImage(creepname As eCreepName) As BitmapImage

    If CreepURLs.ContainsKey(creepname) Then
      Dim imagefilepath = New Uri(Path.Combine(mCreepImagefolderPath, Path.GetFileName(CreepURLs.Item(creepname).AbsolutePath)))

      Return GetBitmap(imagefilepath)
    Else
      Return New BitmapImage(New Uri(mErrorImageFilepath))

    End If

  End Function

  Public Function GetAbilityImage(abilityname As eAbilityName) As BitmapImage

    If AbilityURLs.ContainsKey(abilityname) Then
      Dim imagefilepath = New Uri(Path.Combine(mAbilityImageFolderPath, Path.GetFileName(AbilityURLs.Item(abilityname).AbsolutePath)))

      Return GetBitmap(imagefilepath)
    Else
      Return New BitmapImage(New Uri(mErrorImageFilepath))
    End If

  End Function

  Private Function GetBitmap(filepath As Uri) As BitmapImage
    If Not filepath Is Nothing Then

      If File.Exists(filepath.LocalPath) Then
        Return New BitmapImage(filepath)
      End If
    End If


    Return New BitmapImage(New Uri(mErrorImageFilepath))

  End Function

End Class
