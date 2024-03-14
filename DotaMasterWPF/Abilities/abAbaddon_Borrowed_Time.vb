Public Class abBorrowed_Time
  Inherits AbilityBase


  Private hpthreshold As Integer = 400
  Private scepterduration As New List(Of Double?)
  Private redirectrange As ValueWrapper ' = 900
  Private scepterredirectrange As New List(Of Double?)
  Private damagetohealpercentage As ValueWrapper
  Private allydammagetohealpercentage As ValueWrapper
  Private scepterdamagetohealpercentage As New List(Of Double?)
  Public Sub New()

    BlockedByMagicImmune = False
    RemovedByMagicImmune = False
    CanBePurged = False
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = True
    IsUniqueAttackModifier = False

    PiercesSpellImmunity = False
    mDisplayName = "Borrowed Time"
    mName = eAbilityName.abBorrowed_Time
    Me.EntityName = eEntity.abBorrowed_Time

    ''mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untAbaddon

    mAbilityPosition = 4

    mIsUltimate = True
    mIsAghsUpgradable = True 'Check This
    'mHasAghs = False

    mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/abaddon_borrowed_time_hp2.png"
    WebpageLink = ""
    Description = "When activated, all damage dealt to you will heal instead of harm. Most negative buffs will also be removed. If the ability is not on cooldown, it will passively activate if your hitpoints drop below 400. Upgradable by Aghanim's Scepter."
    Notes = "Borrowed Time will activate itself if Abaddon suffers damage while he has less than 400 HP.|Upon casting Borrowed Time, Abaddon will effectively dodge most projectiles currently flying at him.|When activated it removes most negative buffs from Abaddon, including Stuns.|Borrowed Time can be manually activated.|Borrowed Time is activated during Duel, if Abbadon hits the HP-Threshold.|It is possible to kill Abaddon without triggering Borrowed Time's auto-activation if he were to take damage higher than his remaining health, due to the fact that on activation of Borrowed Time, Abaddon takes the damage that activated it and then heals double the amount. Any other damage taken during the duration of Borrowed Time will deal 0 damage and heal instead.|Culling Blade icon.png Culling Blade and Ice Blast icon.png Ice Blast will kill Abaddon if he reaches the health threshold, even with Borrowed Time active. Ice Blast also prevents Abaddon from being healed by attacks, but Abaddon will not take any damage either for Borrowed Time's duration.|If Abaddon is doomed before he hits the HP threshold, Borrowed Time will not activate.|With Aghanim's Scepter, the effective health of Abaddon's nearby allies will be increased by 53.85%.|While Borrowed Time is active Abaddon cannot reflect damage through Blade Mail."

    ' mManaCost = New ValueWrapper(0, 0, 0)


    Cooldown = New ValueWrapper(60, 50, 40)

    AbilityTypes.Add(eAbilityType.NoTarget)

    Affects.Add(eUnit.untSelf)

    Duration = New ValueWrapper(3, 4, 5)
    scepterduration.Add(5)
    scepterduration.Add(6)
    scepterduration.Add(7)
    Duration.LoadScepterValues(scepterduration)

    redirectrange = New ValueWrapper(-1, -1, -1)
    scepterredirectrange.Add(900)
    scepterredirectrange.Add(900)
    scepterredirectrange.Add(900)
    redirectrange.LoadScepterValues(scepterredirectrange)


    damagetohealpercentage = New ValueWrapper(1, 1, 1)

    allydammagetohealpercentage = New ValueWrapper(-1, -1, -1)
    scepterdamagetohealpercentage.Add(0.35)
    scepterdamagetohealpercentage.Add(0.35)
    scepterdamagetohealpercentage.Add(0.35)
    allydammagetohealpercentage.LoadScepterValues(scepterdamagetohealpercentage)
  End Sub

  Public Shadows ReadOnly Property Radius(thecaster As HeroInstance, thetime As ddFrame) As ValueWrapper
    Get
      Dim outlist As New List(Of Double?)
      If Not thecaster Is Nothing Then
        If thecaster.HasAghsAtTime(thetime) Then
          outlist.Add(900)
          Return New ValueWrapper(outlist)
        End If
        Return Nothing
      Else
        outlist.Add(0)
        Return New ValueWrapper(outlist)
      End If
    End Get
  End Property
  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                    thecaster As iDisplayUnit, _
                                                   thetarget As iDisplayUnit, _
                                                    ftarget As iDisplayUnit, _
                                                    isfriendbias As Boolean, _
                                                    occurencetime As Lifetime, aghstime As Lifetime) As ModifierList


    Dim outmods As New ModifierList

    Dim notargetselfinfo = Helpers.GetNoTargetSelfInfo(theability_InfoID, _
                                                        thecaster, _
                                                        thetarget, _
                                                        "", eModifierCategory.Active)


    Dim damhealval As New modValue(damagetohealpercentage, eModifierType.DamagetoHealPercent, occurencetime, aghstime)
    damhealval.mValueDuration = Duration

    Dim damageabsorption As New Modifier(damhealval, notargetselfinfo)

    outmods.Add(damageabsorption)


    Dim debuffval As New modValue(1, eModifierType.RemoveDebuffs, occurencetime)

    Dim debuffpurge As New Modifier(debuffval, notargetselfinfo)

    outmods.Add(damageabsorption)



    Dim auraalliesinfo = Helpers.GetActiveAuraAlliedHeroesInfo(theability_InfoID, _
                                                               thecaster, _
                                                               thetarget, _
                                                               "", eModifierCategory.Active)

    Dim damval As New modValue(allydammagetohealpercentage, eModifierType.DamageTransferedToCaster, occurencetime, aghstime)

    Dim allydamageabsorption As New Modifier(damval, auraalliesinfo)

    outmods.Add(allydamageabsorption)

    Return outmods

  End Function

  Public Overrides Function GetPassiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                 caster As iDisplayUnit, _
                                                 target As iDisplayUnit, _
                                                 ftarget As iDisplayUnit, _
                                                 isfriendbias As Boolean, _
                                                 occurencetime As Lifetime, aghstime As Lifetime) As ModifierList
    Return New ModifierList
  End Function
End Class
