Public Class abMorph__Agility_Gain
  Inherits AbilityBase


  Public manapersec As ValueWrapper
  Public pointspershift As ValueWrapper
  Public shiftrate As ValueWrapper
  Public bonusagility As ValueWrapper

  Public Sub New()
    BlockedByMagicImmune = True 'FixFixFix
    RemovedByMagicImmune = True 'FixFixFix
    CanBePurged = True 'FixFixFix
    CanBeUsedByIllusions = True 'FixFixFix
    CanSelfDeny = True 'FixFixFix
    BlockedByLinkens = True 'FixFixFix
    BreaksStun = True 'FixFixFix
    IsUniqueAttackModifier = True 'FixFixFix
    PiercesSpellImmunity = False

    '''''
    '!!!!!! this has to do double duty for both strength and agi!!!!
    '''''
    Notes = "" 'FixFixFix"

    mDisplayName = "Agility/Strength Gain"
    mName = eAbilityName.abMorph_Agility_Gain
    Me.EntityName = eEntity.abMorph_Agility_Gain

    ''mFriendlyName = =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untMorphling

    mAbilityPosition = 3

    mIsUltimate = False
    mIsAghsUpgradable = False 'FixFixFix

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/morphling_morph_agi_hp2.png"

    Description = "Morphling shifts its form, pulling points from Strength and pouring them into Agility. The process is reversible. Additional points in Morph increase the rate of stat change. Passively grants bonus Agility."

    'mCooldown = New ValueWrapper(0, 0, 0, 0)

    AbilityTypes.Add(eAbilityType.NoTarget)
    AbilityTypes.Add(eAbilityType.Toggle)

    Affects.Add(eUnit.untSelf)

    manapersec = New ValueWrapper(30, 30, 30, 30)
    pointspershift = New ValueWrapper(2, 2, 2, 2)
    shiftrate = New ValueWrapper(1, 0.5, 0.33, 0.2)
    bonusagility = New ValueWrapper(3, 4, 5, 6)

    mStates = New List(Of String)
    mStates.Add("Off")
    mStates.Add("Str")
    mStates.Add("Agi")


    mStateImageURLs = New List(Of String)
    mStateImageURLs.Add("http://cdn.dota2.com/apps/dota2/images/heroes/morphling_vert.jpg")
    mStateImageURLs.Add("http://cdn.dota2.com/apps/dota2/images/abilities/morphling_morph_str_hp2.png")
    mStateImageURLs.Add("http://cdn.dota2.com/apps/dota2/images/abilities/morphling_morph_agi_hp2.png")
  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim toggleself = Helpers.GetToggleSelfInfo(theability_InfoID, _
                                                   thecaster, _
                                                   thetarget, _
                                                   "", eModifierCategory.Passive)










    Select Case thestateindex
      'off
      Case 0



        'Str
      Case 1
        Dim manadrainval As New modValue(manapersec, eModifierType.ManaRemovedoT, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)

        Dim manamod As New Modifier(manadrainval, toggleself)
        outmods.Add(manamod)

        Dim strgainval As New modValue(pointspershift, eModifierType.StrAdded, shiftrate, occurencetime, aghstime)


        Dim strmod As New Modifier(strgainval, toggleself)
        outmods.Add(strmod)

        Dim agilossval As New modValue(pointspershift, eModifierType.AgiSubtracted, shiftrate, occurencetime, aghstime)

        Dim agimod As New Modifier(agilossval, toggleself)
        outmods.Add(agimod)


        'Agi
      Case 2
        Dim manadrainval As New modValue(manapersec, eModifierType.ManaRemovedoT, New ValueWrapper(1, 1, 1, 1), occurencetime, aghstime)

        Dim manamod As New Modifier(manadrainval, toggleself)
        outmods.Add(manamod)

        Dim agigainval As New modValue(pointspershift, eModifierType.AgiAdded, shiftrate, occurencetime, aghstime)

        Dim agimod As New Modifier(agigainval, toggleself)
        outmods.Add(agimod)


        Dim strlossval As New modValue(pointspershift, eModifierType.StrSubtracted, shiftrate, occurencetime, aghstime)

        Dim strmod As New Modifier(strlossval, toggleself)
        outmods.Add(strmod)

      Case Else

        PageHandler.theLog.writelog("Incorrect state passed to abMorphling_Morph_Agility_Gain: " & thestateindex.ToString)
    End Select

    Return outmods
  End Function


  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, caster As iDisplayUnit, target As iDisplayUnit, ftarget As iDisplayUnit, isfriendbias As Boolean, occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim notargetself = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                caster, _
                                                target, _
                                                "", eModifierCategory.Passive)


    Dim bonusstrval As New modValue(bonusagility, eModifierType.StrAdded, occurencetime, aghstime)

    Dim strmod As New Modifier(bonusstrval, notargetself)
    outmods.Add(strmod)

    Dim bonusagival As New modValue(bonusagility, eModifierType.AgiAdded, occurencetime, aghstime)

    Dim agimod As New Modifier(bonusagival, notargetself)
    outmods.Add(agimod)

    Return outmods

  End Function


End Class
