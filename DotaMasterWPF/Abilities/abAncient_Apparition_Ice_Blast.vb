Public Class abIce_Blast
Inherits AbilityBase
  Public frostbittenduration As ValueWrapper
  Public frostbittenDPS As ValueWrapper
  Public ShatterHealthThreshold As ValueWrapper
  Public scepterfrostbittenduration As New List(Of Double?)
Public Sub New()
    BlockedByMagicImmune = False
    RemovedByMagicImmune = False
    CanBePurged = False
    CanBeUsedByIllusions = False
    CanSelfDeny = False
    BlockedByLinkens = False
    BreaksStun = False
    IsUniqueAttackModifier = False
    PiercesSpellImmunity = True

    Notes = "Upon cast, Ice Blast icon.png Ice Blast is replaced by the sub-skill Release.|The tracer projectile travels at a speed of 1500 until Release is cast, Ancient Apparition dies, or it reaches the map boundaries.|The tracer has invisibility and is never visible to enemies. However, with true sight, enemies can see the projectile as a dot on their minimap.|The invisibility also causes the typical shockwave effect caused by some invisibility sources, which is visible to the enemies.|The tracer projectile itself is harmless. It neither deals damage, nor places the debuff.|The explosion radius starts at 275 and increases by 50 for every second the tracer traveled, capped at 1000 radius.|The tracer provides 500 radius flying vision around itself as it travels. This vision does not last.|The debuff is placed on heroes (including Meepo clones, but not illusions), Lone Druid's Spirit Bear, Visage's Familiars, Warlock's Golem and the Primal Split spirits.|The debuff can also be placed on spell immune or invulnerable, but not on hidden units.|Unlike the debuff, the explosion damage hits all enemy units, including creeps, excluding buildings and wards.|The debuff prevents the current health of affected units to increase in any way. The only exceptions are Sunder, Decay and Time Lapse.|Units with the debuff on die instantly when their health drops below the threshold. The kill is credited to the source of the damage which brought them below the threshold.|However, if it was caused by self afflicted damage, Ancient Apparition will be credited for the kill.|Shallow Grave prevents affected units from dying to the shatter for its duration. Invulnerable units cannot shatter.|The debuff deals damage in 1 second intervals, starting 1 second after the debuff is applied, resulting in 8/9/10 (17*) instances.|The debuff itself can deal up to 100/180/320 (212.5/340/544*) damage (before reductions).|Together with the explosion, Ice Blast can deal up to 350/530/770 (462.5/690/994*) damage (before reductions)."

    mName = eAbilityName.abIce_Blast
    Me.EntityName = eEntity.abIce_Blast

    'mFriendlyName =PageHandler.dbAbilities.GetFriendlyName(mName)
    ParentGameEntityType = eUnit.untAncient_Apparition
    mDisplayName = "Ice Blast"
    mAbilityPosition = 4

    mIsUltimate = True
mIsAghsUpgradable = False 'FixFixFix

mAbilityImage = "http://cdn.dota2.com/apps/dota2/images/abilities/ancient_apparition_ice_blast_hp2.png"

    Description = "An explosive ball of icy hail that can be used to strike targets anywhere on the map. On first use, Kaldr launches a tracer towards the targeted location. The second use marks the current location of the blast, upon which the actual projectile is launched - the greater the distance, the larger the radius affected. It deals damage to enemy units and applies a frostbite curse to units in and around the area that prevents regeneration or healing. Frostbitten units will take minor damage over time; if the units drop below a certain percentage of hitpoints, they'll instantly shatter. Upgradable by Aghanim's Scepter."

    ManaCost = New ValueWrapper(100, 125, 150)


    Cooldown = New ValueWrapper(40, 40, 40)
    AbilityTypes.Add(eAbilityType.PointTarget)

    Affects.Add(eUnit.untEnemyUnits)

    DamageType = eDamageType.Magical




    Range = New ValueWrapper(Constants.cMapWideArea, Constants.cMapWideArea, Constants.cMapWideArea, Constants.cMapWideArea)

    Damage = New ValueWrapper(250, 350, 450)

    frostbittenduration = New ValueWrapper(8, 9, 10)
    scepterfrostbittenduration.Add(17)
    scepterfrostbittenduration.Add(17)
    scepterfrostbittenduration.Add(17)
    frostbittenduration.LoadScepterValues(scepterfrostbittenduration)

    frostbittenDPS = New ValueWrapper(12.5, 20, 32)

    ShatterHealthThreshold = New ValueWrapper(0.1, 0.11, 0.12)


  End Sub

  Public Overrides Function GetActiveModifiers(thestateindex As Integer, thegame As dGame, theability_InfoID As IUnitUpgrade, _
                                                   thecaster As iDisplayUnit, _
                                                  thetarget As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

    Dim outmods As New ModifierList

    Dim pointtargetauraenemies = Helpers.GetPointTargetAuraEnemyUnitsInfo(theability_InfoID, _
                                                                          thecaster, _
                                                                          thetarget, _
                                                                          "", eModifierCategory.Active)

    'damage
    Dim damval As New modValue(Damage, eModifierType.DamageMagicalInflicted, occurencetime, aghstime)

    Dim dammod As New Modifier(damval, pointtargetauraenemies)
    outmods.Add(dammod)

    'DoT
    Dim dotval As New modValue(frostbittenDPS, eModifierType.DamageMagicalInflicted, New ValueWrapper(1, 1, 1), occurencetime, aghstime)
    dotval.mValueDuration = frostbittenduration

    'regen and heal mute
    Dim healval As New modValue(frostbittenduration, eModifierType.HealthvalueFrozen, occurencetime, aghstime)
    healval.mValueDuration = frostbittenduration

    Dim healmod As New Modifier(healval, pointtargetauraenemies)
    outmods.Add(healmod)


    'shatter
    Dim shatval As New modValue(ShatterHealthThreshold, eModifierType.Shatter, occurencetime, aghstime)
    shatval.mThreshold = ShatterHealthThreshold

    Dim shatmod As New Modifier(shatval, pointtargetauraenemies)
    outmods.Add(shatmod)

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
