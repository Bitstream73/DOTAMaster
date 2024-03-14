Public Class abRemote_Mines
  Inherits AbilityBase
  Public explosionradius As ValueWrapper
  Public mineduration As ValueWrapper
  Public fadetime As ValueWrapper
  Public scepterdamage As New List(Of Double?)
  Public scepterexplosionradius As New List(Of Double?)
  Public sceptercastrange As New List(Of Double?)
  Public Sub New()
    BlockedByMagicImmune = False '
    RemovedByMagicImmune = False '
    CanBePurged = False '
    CanBeUsedByIllusions = False '
    CanSelfDeny = False '
    BlockedByLinkens = False '
    BreaksStun = False '
    IsUniqueAttackModifier = False '
    PiercesSpellImmunity = False

    Notes = "Can be activated manually or by the sub-ability Focused Detonate|The mines can still be detonated when you are dead by activating them manually.|If destroyed by attacks the mines will still explode.|Has a cast time of 1.5 seconds.|There is no direct cap to the amount of Remote Mines you may place at once, it is only limited by the cooldown/duration.|Remote Mines have no collision and can be placed on top of each other.|Remote Mines have a 700/700 Sight Range.|Remote Mines have 200 HP and 0 medium armor.|Remote Mines will not block neutral camps from spawning.|The size of Remote Mines increases with levels." '"

    mDisplayName = "Remote Mines"
    mName = eAbilityName.abRemote_Mines
    Me.EntityName = eEntity.abRemote_Mines

    'mFriendlyName = = PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untTechies

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = True '

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/techies_remote_mines_hp2.png"

    Description = "Plant an invisible explosive that will only detonate when triggered. Does not damage buildings. Upgradable by Aghanim's Scepter."

    ManaCost = New ValueWrapper(200, 240, 300)
    
    Cooldown = New ValueWrapper(10, 10, 10)

    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untSelf)

    DamageType = eDamageType.Magical

    Damage = New ValueWrapper(300, 450, 600)
    scepterdamage.Add(450)
    scepterdamage.Add(600)
    scepterdamage.Add(750)
    Damage.LoadScepterValues(scepterdamage)

    explosionradius = New ValueWrapper(425, 425, 425)
    scepterexplosionradius.Add(425)
    scepterexplosionradius.Add(600)
    scepterexplosionradius.Add(750)
    explosionradius.LoadScepterValues(scepterexplosionradius)

    mineduration = New ValueWrapper(600, 600, 600)

    fadetime = New ValueWrapper(2, 2, 2)

    Range = New ValueWrapper(500, 500, 500)
    sceptercastrange.Add(700)
    sceptercastrange.Add(700)
    sceptercastrange.Add(700)
    Range.LoadScepterValues(sceptercastrange)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Dim outmods As New ModifierList

    Dim pointtargetenemies = Helpers.GetPointTargetEnemyUnitsInfo(theability_InfoID, _
                                                                  thecaster, _
                                                                  thetarget, _
                                                                  "", eModifierCategory.Active)


    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim thedamage As New Modifier(damval, pointtargetenemies)
    outmods.Add(thedamage)



    Return outmods
  End Function


  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                              theowner As iDisplayUnit, _
                                              thetarget As iDisplayUnit, _
                                              ftarget As iDisplayUnit, _
                                              isfriendbias As Boolean, _
                                              occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return New ModifierList
  End Function
End Class
