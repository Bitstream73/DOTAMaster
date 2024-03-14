Imports System.IO
Imports System.Xml.Serialization
Imports System.Windows.Media.Imaging

Public Class Helpers



#Region "ModInfos"



  Public Shared Function GetActiveAuraAlliedHeroesInfo(thesource As IUnitUpgrade, _
                                                       theowner As iDisplayUnit, _
                                                       thetarget As iDisplayUnit, _
                                                       thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.ActiveAura, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untAlliedHeroes, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetActiveAuraAlliedNonHeroUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                     thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.ActiveAura, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untAlliedNonHeroUnits, _
                       thenotes, themodcategory)

  End Function
  Public Shared Function GetActiveAuraAlliedUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                     thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.ActiveAura, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untAlliedUnits, _
                       thenotes, themodcategory)

  End Function

  ''' <summary>
  ''' needed for Enchantress Nature's Attendant since self needs to be part of random target pool
  ''' </summary>
  ''' <param name="thesource"></param>
  ''' <param name="theowner"></param>
  ''' <param name="thetarget"></param>
  ''' <param name="thenotes"></param>
  ''' <param name="themodcategory"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function GetActiveAuraAlliedUnitsandSelfInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                   thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.ActiveAura, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untAlliedUnits, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetActiveAuraEnemyUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                   thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.ActiveAura, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemyUnits, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetActiveAuraEnemyUnitRandomInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                 thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.ActiveAura, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untRandomEnemyUnit, _
                       thenotes, themodcategory)

  End Function
  Public Shared Function GetActiveAuraEnemyStructuresInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                 thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.ActiveAura, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemyStructures, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetActiveAuraEnemyCreepsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                               thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.ActiveAura, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemyCreeps, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetActiveAuraEnemyHeroesInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                 thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.ActiveAura, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemyHeroes, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetActiveAuraNearestEnemyHeroInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                   thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.ActiveAura, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemyHeroNearest, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetActiveAuraSelfInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                     thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.ActiveAura, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untSelf, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetAutoCastEnemyCreepInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                           thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.AutoCast, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemyCreep, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetAutoCastEnemyHeroInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                             thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.AutoCast, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemyHero, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetAutoCastEnemyTargetInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                               thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.AutoCast, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemyTarget, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetAutoCastAllyTargetInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                             thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.AutoCast, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untTargettedAlly, _
                       thenotes, themodcategory)

  End Function
  Public Shared Function GetAutoCastEnemyUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                 thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.AutoCast, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemyUnits, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetAutoCastSelfInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                   thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.AutoCast, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untSelf, _
                       thenotes, themodcategory)

  End Function


  Public Shared Function GetChanneledAuraAlliedUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                             thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.ChnneledAura, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untAlliedUnits, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetChanneledAuraEnemydUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                           thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.ChnneledAura, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemyUnits, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetChanneledEnemyHeroesInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                               thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.Channeled, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemyHeroes, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetChanneledEnemyTargetInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                               thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.Channeled, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemyTarget, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetChanneledEnemyUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                 thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.Channeled, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemyUnits, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetChanneledSelfInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                               thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.Channeled, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untSelf, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetUnitTargetConeUntargettedEnemyUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                               thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.UnitTargetCone, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untUntargetedEnemyUnits, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetPointTargetLineAlliedUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                           thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.PointTargetLine, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untAlliedUnits, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetPointTargetLineEnemyUnitInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                            thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.PointTargetLine, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemyUnit, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetPointTargetLineEnemyHeroesInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                          thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.PointTargetLine, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemyHeroes, _
                       thenotes, themodcategory)

  End Function
  Public Shared Function GetPointTargetLineEnemyUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                            thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.PointTargetLine, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemyUnits, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetNoTargetLineEnemyUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                          thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.NoTargetLine, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemyUnits, _
                       thenotes, themodcategory)

  End Function
  Public Shared Function GetPointTargetLineTreesInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                             thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.PointTargetLine, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untTree, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetMapwideAuraAlliedHeroesInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                 thenotes As String, themodcategory As eModifierCategory) As modInfo

    Return New modInfo(eAbilityType.MapWideAura, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untAlliedHeroes, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetMapwideAuraAllAlliedControlledUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                               thenotes As String, themodcategory As eModifierCategory) As modInfo

    Return New modInfo(eAbilityType.MapWideAura, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untControlledUnits, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetMapwideAuraAlliedRangedHeroesInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                   thenotes As String, themodcategory As eModifierCategory) As modInfo

    Return New modInfo(eAbilityType.MapWideAura, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untAlliedRangeHeroes, _
                       thenotes, themodcategory)
  End Function
  ''' <summary>
  ''' specifically, units controlled ONLY by the modifiers Owner
  ''' </summary>
  ''' <param name="thesource"></param>
  ''' <param name="theowner"></param>
  ''' <param name="thetarget"></param>
  ''' <param name="thenotes"></param>
  ''' <param name="themodcategory"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function GetNoTargetControlledUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                 thenotes As String, themodcategory As eModifierCategory) As modInfo

    Return New modInfo(eAbilityType.NoTarget, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untControlledUnits, _
                       thenotes, themodcategory)
  End Function
  Public Shared Function GetNoTargetAlliedUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                   thenotes As String, themodcategory As eModifierCategory) As modInfo

    Return New modInfo(eAbilityType.NoTarget, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untAlliedUnits, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetNoTargetAttackingEnemyUnitInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                 thenotes As String, themodcategory As eModifierCategory) As modInfo

    Return New modInfo(eAbilityType.NoTarget, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untAttackingEnemyUnit, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetNoTargetAlliedHeroesInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                     thenotes As String, themodcategory As eModifierCategory) As modInfo

    Return New modInfo(eAbilityType.NoTarget, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untAlliedHeroes, _
                       thenotes, themodcategory)
  End Function



  ''' <summary>
  ''' includes all heroes and player controlled units
  ''' </summary>
  ''' <param name="thesource"></param>
  ''' <param name="theowner"></param>
  ''' <param name="thetarget"></param>
  ''' <param name="thenotes"></param>
  ''' <param name="themodcategory"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function GetNoTargetAlliedTeamInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                   thenotes As String, themodcategory As eModifierCategory) As modInfo

    Return New modInfo(eAbilityType.NoTarget, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untAlliedHeroes, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetNoTargetRandomUnitInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                     thenotes As String, themodcategory As eModifierCategory) As modInfo

    Return New modInfo(eAbilityType.NoTarget, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untRandomUnit, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetNoTargetRandomEnemyUnitInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                   thenotes As String, themodcategory As eModifierCategory) As modInfo

    Return New modInfo(eAbilityType.NoTarget, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untRandomEnemyUnit, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetNoTargetSelfInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                       thenotes As String, themodcategory As eModifierCategory) As modInfo

    Return New modInfo(eAbilityType.NoTarget, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untSelf, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetNoTargetBuildingInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                  thenotes As String, themodcategory As eModifierCategory) As modInfo

    Return New modInfo(eAbilityType.NoTarget, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untBuilding, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetNoTargetBuildingsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                    thenotes As String, themodcategory As eModifierCategory) As modInfo

    Return New modInfo(eAbilityType.NoTarget, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untBuildings, _
                       thenotes, themodcategory)
  End Function
  Public Shared Function GetNoTargetUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                     thenotes As String, themodcategory As eModifierCategory) As modInfo

    Return New modInfo(eAbilityType.NoTarget, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untUnits, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetNoTargetEnemyUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                     thenotes As String, themodcategory As eModifierCategory) As modInfo

    Return New modInfo(eAbilityType.NoTarget, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemyUnits, _
                       thenotes, themodcategory)
  End Function


  Public Shared Function GetNoTargetEnemyHeroNearestInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                   thenotes As String, themodcategory As eModifierCategory) As modInfo

    Return New modInfo(eAbilityType.NoTarget, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemyHeroNearest, _
                       thenotes, themodcategory)
  End Function


  Public Shared Function GetNoTargetEnemyHeroesInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                   thenotes As String, themodcategory As eModifierCategory) As modInfo

    Return New modInfo(eAbilityType.NoTarget, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemyHeroes, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetNoTargetTwoRandomEnemyUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                   thenotes As String, themodcategory As eModifierCategory) As modInfo

    Return New modInfo(eAbilityType.NoTarget, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemyUnits, _
                       thenotes, themodcategory)
  End Function
  Public Shared Function GetNoTargetEnemyStructuresInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                   thenotes As String, themodcategory As eModifierCategory) As modInfo

    Return New modInfo(eAbilityType.NoTarget, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemyStructure, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetNoTargetEnemyTargettingCasterInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                       thenotes As String, themodcategory As eModifierCategory) As modInfo

    Return New modInfo(eAbilityType.NoTarget, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemyTargettingCaster, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetPassiveAttackingEnemyInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                    thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.Passive, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untAttackingEnemyUnit, _
                       thenotes, themodcategory)
  End Function
  Public Shared Function GetPassiveAuraAlliedHeroesInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                       thenotes As String, themodcategory As eModifierCategory) As modInfo

    Return New modInfo(eAbilityType.PassiveAura, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untAlliedHeroes, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetPassiveAuraAlliedNonHeroesInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                     thenotes As String, themodcategory As eModifierCategory) As modInfo

    Return New modInfo(eAbilityType.PassiveAura, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untAlliedNonHeroUnits, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetPassiveAuraEnemyUnitesNotTargettedInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                     thenotes As String, themodcategory As eModifierCategory) As modInfo

    Return New modInfo(eAbilityType.PassiveAura, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untEnemyUnitsNotTargetted, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetPassiveAuraAlliedUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                     thenotes As String, themodcategory As eModifierCategory) As modInfo

    Return New modInfo(eAbilityType.PassiveAura, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untAlliedUnits, _
                       thenotes, themodcategory)
  End Function

  ''' <summary>
  ''' only affects units controlled by Owner, not all controlled units
  ''' </summary>
  ''' <param name="thesource"></param>
  ''' <param name="theowner"></param>
  ''' <param name="thetarget"></param>
  ''' <param name="thenotes"></param>
  ''' <param name="themodcategory"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function GetPassiveAuraControlledUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                   thenotes As String, themodcategory As eModifierCategory) As modInfo

    Return New modInfo(eAbilityType.PassiveAura, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untControlledUnits, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetPassiveAuraAlliedMeleeUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                   thenotes As String, themodcategory As eModifierCategory) As modInfo

    Return New modInfo(eAbilityType.PassiveAura, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untAlliedMeleeUnits, _
                       thenotes, themodcategory)
  End Function



  Public Shared Function GetPassiveAuraEnemyStealthUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                       thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.PassiveAura, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemyStealthUnits, _
                       thenotes, themodcategory)

  End Function
  Public Shared Function GetPassiveAuraEnemyTargetInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                       thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.PassiveAura, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untEnemyTarget, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetPassiveAuraEnemyUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                     thenotes As String, themodcategory As eModifierCategory) As modInfo

    Return New modInfo(eAbilityType.PassiveAura, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untEnemyUnits, _
                       thenotes, themodcategory)
  End Function


  Public Shared Function GetPassiveAuraSelfInfo(thesource As IUnitUpgrade, _
                                                         theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                   thenotes As String, themodcategory As eModifierCategory) As modInfo

    Return New modInfo(eAbilityType.PassiveAura, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untSelf, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetPassiveEnemyCreepInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                   thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.Passive, _
                   thesource, _
                   theowner, _
                   thetarget, _
                   eUnit.untEnemyCreep, _
                   thenotes, themodcategory)

  End Function
  Public Shared Function GetPassiveEnemyTargetInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                   thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.Passive, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untEnemyTarget, _
                       thenotes, themodcategory)

  End Function
  Public Shared Function GetPassiveSelfInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                     thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.Passive, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untSelf, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetPointTargetAuraEnemyUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                  thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.PointTargetAura, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemyUnits, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetPointTargetAuraEnemySummonedUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.PointTargetAura, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemySummonedUnits, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetPointTargetAuraEnemyUnitInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.PointTargetAura, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemyUnit, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetPointTargetAuraUntargetedEnemyUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.PointTargetAura, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untUntargetedEnemyUnits, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetPointTargetAlliedHeroesInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                  thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.PointTarget, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untAlliedHeroes, _
                       thenotes, themodcategory)

  End Function
  Public Shared Function GetPointTargetAlliedUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                    thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.PointTarget, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untAlliedUnits, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetPointTargetAuraAlliedHeroesInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                 thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.PointTargetAura, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untAlliedHeroes, _
                       thenotes, themodcategory)

  End Function
  Public Shared Function GetPointTargetAuraAlliedUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                  thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.PointTargetAura, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untAlliedUnits, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetPointTargetEnemyCreepsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                               thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.PointTarget, _
                   thesource, _
                   theowner, _
                   Nothing, _
                   eUnit.untEnemyCreeps, _
                   thenotes, themodcategory)
  End Function

  Public Shared Function GetPointTargetEnemyTeamInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                 thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.PointTarget, _
                   thesource, _
                   theowner, _
                   Nothing, _
                   eUnit.untEnemieTeam, _
                   thenotes, themodcategory)
  End Function

  Public Shared Function GetPointTargetEnemyHeroesInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                               thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.PointTarget, _
                   thesource, _
                   theowner, _
                   Nothing, _
                   eUnit.untEnemyHeroes, _
                   thenotes, themodcategory)
  End Function

  Public Shared Function GetPointTargetEnemyStructuresInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                             thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.PointTarget, _
                   thesource, _
                   theowner, _
                   Nothing, _
                   eUnit.untEnemyStructures, _
                   thenotes, themodcategory)
  End Function

  Public Shared Function GetPointTargetChanneledEnemyUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                               thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.PointTargetChanneled, _
                   thesource, _
                   theowner, _
                   Nothing, _
                   eUnit.untEnemyUnits, _
                   thenotes, themodcategory)
  End Function

  Public Shared Function GetPointTargetEnemyUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                             thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.PointTarget, _
                   thesource, _
                   theowner, _
                   Nothing, _
                   eUnit.untEnemyUnits, _
                   thenotes, themodcategory)
  End Function

  Public Shared Function GetPointTargetEnemyUnitNearestInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                           thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.PointTarget, _
                   thesource, _
                   theowner, _
                   Nothing, _
                   eUnit.untEnemyUnitNearest, _
                   thenotes, themodcategory)
  End Function
  Public Shared Function GetPointTargetMultiAffectsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                   thenotes As String, themodcategory As eModifierCategory, _
                                                   theaffected As List(Of eUnit)) As modInfo

    Return New modInfo(eAbilityType.PointTarget, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       theaffected, _
                       thenotes, themodcategory)
  End Function
  Public Shared Function GetPointTargetSelfInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                     thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.PointTarget, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untSelf, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetPointTargetUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                             thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.PointTarget, _
                   thesource, _
                   theowner, _
                   Nothing, _
                   eUnit.untUnits, _
                   thenotes, themodcategory)
  End Function

  Public Shared Function GetToggleEnemyUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                   thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.Toggle, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemyUnits, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetToggleAuraEnemyUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                 thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.ToggleAura, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemyUnits, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetToggleUntargettedEnemyUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                 thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.Toggle, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untUntargetedEnemyUnits, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetToggleSelfInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                 thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.Toggle, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untSelf, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetUnitTargetAlliedHeroInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                             thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.UnitTarget, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untAlliedHero, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetUnitTargetAlliedUnitInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                   thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.UnitTarget, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untAlliedUnit, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetUnitTargetAlliedUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                               thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.UnitTarget, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untAlliedUnits, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetUnitTargetAuraAlliedHeroesInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                               thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.UnitTargetAura, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untAlliedHeroes, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetUnitTargetAuraEnemyHeroesInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                             thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.UnitTargetAura, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untEnemyHeroes, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetUnitTargetAuraEnemyUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                 thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.UnitTargetAura, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untEnemyUnits, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetConeEnemyUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                             thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.PointTargetCone, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemyUnits, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetConeAlliedUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                           thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.PointTargetCone, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untAlliedUnits, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetNoTargetConeEnemyUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                           thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.NoTargetCone, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemyUnits, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetNoTargetConeEnemyCreepsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                         thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.NoTargetCone, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemyCreeps, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetNoTargetEnemyCreepsInfo(thesource As IUnitUpgrade, _
                                                         theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                         thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.NoTarget, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemyCreeps, _
                       thenotes, themodcategory)

  End Function

  Public Shared Function GetNoTargetConeEnemyHeroesInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                        thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.NoTargetCone, _
                       thesource, _
                       theowner, _
                       Nothing, _
                       eUnit.untEnemyHeroes, _
                       thenotes, themodcategory)

  End Function
  Public Shared Function GetUnitTreeSelfInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.UnitTreeTarget, _
                       thesource, _
                       theowner, _
                       theowner, _
                       eUnit.untSelf, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetUnitTeamEnemyUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                              thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.UnitTeam, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untEnemyUnits, _
                       thenotes, themodcategory)
  End Function
  Public Shared Function GetUnitTargetAlliedHeroesAttackingCastersTarget(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                 thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.UnitTarget, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untAlliedHerosAttackingCastersTarget, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetUnitTargetAlliedCreepInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.UnitTarget, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untAlliedCreep, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetUnitTargetCreepInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                  thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.UnitTarget, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untCreep, _
                       thenotes, themodcategory)
  End Function
  Public Shared Function GetUnitTargetEnemyCreepInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                    thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.UnitTarget, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untEnemyCreep, _
                       thenotes, themodcategory)
  End Function


  Public Shared Function GetUnitTargetEnemyCreepsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                  thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.UnitTarget, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untEnemyCreeps, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetUnitTargetEnemyHeroInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                  thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.UnitTarget, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untEnemyHero, _
                       thenotes, themodcategory)
  End Function


  Public Shared Function GetUnitTargetEnemyHeroesInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.UnitTarget, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untEnemyHeroes, _
                       thenotes, themodcategory)
  End Function
  Public Shared Function GetUnitTargetEnemyStructureInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.UnitTarget, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untEnemyStructure, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetUnitTargetEnemyUnitwLowestHealthInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                  thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.UnitTarget, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untEnemyUnitwLowestHealth, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetUnitTargetEnemyRangedTargetInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                   thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.UnitTarget, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untEnemyRangedTarget, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetUnitTargetEnemyMeleeTargetInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                 thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.UnitTarget, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untEnemyMeleeTarget, _
                       thenotes, themodcategory)
  End Function
  Public Shared Function GetUnitTargetEnemyTargetInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                     thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.UnitTarget, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untEnemyTarget, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetUnitTargetDyingEnemyTargetInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                   thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.UnitTarget, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untDyingEnemyTarget, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetUnitTargetHauntInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                   thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.UnitTarget, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untEnemyUnits, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetUnitTargetEnemyTargetsFixedCountInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                   thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.UnitTarget, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untEnemyTargetsFixedCount, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetUnitTargetEnemyUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                 thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.UnitTarget, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untEnemyUnits, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetUnitTargetHeroInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.UnitTarget, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untHero, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetUnitTargetRoshanInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                   thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.UnitTarget, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untRoshan, _
                       thenotes, themodcategory)
  End Function
  Public Shared Function GetUnitTargetUnitInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                              thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.UnitTarget, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untUnit, _
                       thenotes, themodcategory)
  End Function
  Public Shared Function GetUnitTargetUntargettedEnemyUnitsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                   thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.UnitTarget, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       eUnit.untUntargetedEnemyUnits, _
                       thenotes, themodcategory)
  End Function


  Public Shared Function GetUnitTargetMultiAffectsInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                     thenotes As String, themodcategory As eModifierCategory, _
                                                     theaffected As List(Of eUnit)) As modInfo

    Return New modInfo(eAbilityType.UnitTarget, _
                       thesource, _
                       theowner, _
                       thetarget, _
                       theaffected, _
                       thenotes, themodcategory)
  End Function

  Public Shared Function GetUnitTargetEnemyHeroNearestInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                 thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.UnitTarget, _
                   thesource, _
                   theowner, _
                   thetarget, _
                   eUnit.untEnemyHeroNearest, _
                   thenotes, themodcategory)
  End Function

  Public Shared Function GetUnitTargetEnemyIllusionInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                               thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.UnitTarget, _
                   thesource, _
                   theowner, _
                   thetarget, _
                   eUnit.untEnemyHeroNearest, _
                   thenotes, themodcategory)
  End Function

  Public Shared Function GetPointTargetTreesInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                 thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.PointTarget, _
                   thesource, _
                   theowner, _
                   thetarget, _
                   eUnit.untTrees, _
                   thenotes, themodcategory)
  End Function

  Public Shared Function GetUnitTargetTreeInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                   thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.UnitTarget, _
                   thesource, _
                   theowner, _
                   thetarget, _
                   eUnit.untTree, _
                   thenotes, themodcategory)
  End Function

  Public Shared Function GetUnitTargetSelfInfo(thesource As IUnitUpgrade, _
                                                        theowner As iDisplayUnit, _
                                                      thetarget As iDisplayUnit, _
                                                 thenotes As String, themodcategory As eModifierCategory) As modInfo
    Return New modInfo(eAbilityType.UnitTarget, _
                   thesource, _
                   theowner, _
                   thetarget, _
                   eUnit.untSelf, _
                   thenotes, themodcategory)
  End Function
#End Region

  ' ''' <summary>
  ' ''' ID0: Enemytarget, ID1: FriendTarget, ID2: FriendBias, ID3: SourceID
  ' ''' </summary>
  ' ''' <param name="displayunit"></param>
  ' ''' <returns></returns>
  ' ''' <remarks></remarks>
  'Public Shared Function GetTargetsInfoForGameEntity(GameEnAs iDisplayUnit) As TargetsInfo
  '  Dim entarget As iDisplayUnit
  '  Dim frtarget As iDisplayUnit
  '  Dim frbias As Boolean
  '  'Dim parentid As dvID
  '  Select Case displayunit.EntityName
  '    Case eEntity.Hero_Instance
  '      Dim hparent As HeroInstance = DirectCast(displayunit, HeroInstance)
  '      entarget = hparent.GetEnemyTarget
  '      frtarget = hparent.GetFriendlyTarget
  '      frbias = hparent.GetTargetFriendBias
  '    Case eEntity.Creep_Info
  '      Dim tparent As Creep_Info = DirectCast(displayunit, Creep_Info)
  '      entarget = tparent.mTeamEnemyTarget
  '      frtarget = tparent.mTeamFriendlyTarget
  '      frbias = tparent.mTargetFriendBias
  '    Case Else

  '      PageHandler.theLog.WriteLog("Helpers.GetTargetsandIDforObject unhandled case: " & theobj.type.ToString)
  '      Throw New NotImplementedException
  '  End Select


  '  Return New TargetsInfo(entarget, frtarget, frbias)
  'End Function

  Public Shared Function GetInGameTargetsStringForMod(themod As Modifier, thegame As dGame) As String
    Dim outstring As String = ""
    Dim owner = themod.Parent
    Dim curlvl As Integer
    If themod.TheModInfo.ModGenerator.MyType = eSourceType.Ability_Info Then

      curlvl = Helpers.GetLevelForAbility(themod.TheModInfo.ModGenerator, owner.ID, thegame)

    Else
      curlvl = 1
    End If

    Dim mCurInGameTargets = Helpers.GetAffectedUnitsForMod(themod, thegame)


    For i As Integer = 0 To mCurInGameTargets.Count - 1
      outstring += Helpers.GetFriendlyGuid(mCurInGameTargets.Item(i).Id.GuidID)
    Next

    Return outstring
  End Function
  Public Shared Function GetAffectedUnitsForMod(themod As Modifier, thegame As dGame) As List(Of iDisplayUnit) ' thegame As dGame, _
    If themod Is Nothing Then Return New List(Of iDisplayUnit)

    Dim outlist As New List(Of iDisplayUnit)


    Dim curtime = thegame.TimeKeeper.CurrentTime
    Dim curlvl As Integer

    Select Case themod.TheModInfo.ModGenerator.MyType
      Case eSourceType.Ability_Info
        curlvl = Helpers.GetLevelForAbility(themod.ModGenerator, themod.Parent, thegame)
      Case Else
        curlvl = 1
    End Select

    Dim affectedunitTypes = themod.TheModInfo.AffectedUnitTypes
    Dim myteam = thegame.GetTeamFromGameEntity(themod.Parent)

    myteam = thegame.GetTeamFromGameEntity(themod.Parent)
    If myteam IsNot Nothing Then
      Dim myteamUnits = myteam.GetAllHeroes()
      Dim myteambuilds = myteam.GetAllHeroInstances

      Dim enemyteam = thegame.GetEnemyTeam(themod.Parent)

      Dim enemyteamunits = thegame.GetEnemyTeamUnits(themod.Parent)



      For i As Integer = 0 To affectedunitTypes.Count - 1

        Dim curlist = GetAffectUnitsforType(thegame, themod, curlvl, affectedunitTypes.Item(i), myteam, myteamUnits, enemyteam)

        For x As Integer = 0 To curlist.Count - 1
          If Not outlist.Contains(curlist.Item(x)) Then outlist.Add(curlist.Item(x))
        Next
      Next
    End If

    Return outlist





  End Function

  Public Shared Function GetAffectUnitsforType(game As dGame, _
                                               modifier As Modifier, _
                                               curmodlvl As Integer, _
                                               thetype As eUnit, _
                                               associatedteam As dTeam, _
                                               associatedteamUnits As List(Of iDisplayUnit), _
                                               enemies As dTeam) As List(Of iDisplayUnit)
    Dim outlist As New List(Of iDisplayUnit)
    Dim myteamids = associatedteamUnits
    Dim myteam = associatedteam
    Dim myteambuilds = myteam.GetAllHeroInstances
    Dim parent = modifier.Parent
    Dim parentid = parent.Id
    Dim enemyteam = enemies
    Dim themod = modifier
    Dim enemyteamids = enemyteam.GetAllHeroAndPetUnits
    Dim enemybuilds = enemyteam.GetAllHeroInstances
    Dim thegame = game
    Dim curlvl = curmodlvl
    Dim curtime = game.TimeKeeper.CurrentTime
    Select Case thetype
      Case eUnit.untAlliedHeroes

        For i As Integer = 0 To myteamids.Count - 1
          '  If Not myteamids.Item(i).Id.GuidID = parentid.GuidID Then
          outlist.Add(myteamids.Item(i))
          ' End If
        Next
        Return outlist

      Case eUnit.untAlliedHerosAttackingCastersTarget
        Dim theheros = myteam.GetAllHeroInstances
        Dim parenthero = myteam.GetHeroInstance(parentid)
        For i As Integer = 0 To theheros.Count - 1
          If theheros.Item(i).GetEnemyTarget.Id.GuidID = parenthero.GetEnemyTarget.Id.GuidID Then
            outlist.Add(theheros.Item(i))
          End If
        Next
        Return outlist

      Case eUnit.untAlliedHero
        Dim parentunit = DirectCast(parent, iDisplayUnit)
        If parentunit IsNot Nothing Then
          Dim targ = parentunit.GetFriendlyTarget
          outlist.Add(targ)
        End If
        Return outlist



      Case eUnit.untAlliedMeleeUnits
        Dim theheroes = myteam.GetAllHeroInstances

        For i As Integer = 0 To theheroes.Count - 1
          Dim curhero = theheroes.Item(i)
          If Not curhero.Id.GuidID = parentid.GuidID Then
            If curhero.GetHero._AttackType = eAttackType.Melee Then
              outlist.Add(curhero)
            End If
          End If
        Next

        Return outlist



      Case eUnit.untAlliedNonHeroUnits
        Dim nonheroes = myteam.GetAllPetUnits
        nonheroes = Helpers.AddlisttoList(nonheroes, myteam.GetAllPetUnits)

        Return nonheroes



      Case eUnit.untAlliedRangeHeroes
        Dim theheroes = myteam.GetAllHeroInstances

        For i As Integer = 0 To theheroes.Count - 1
          Dim curhero = theheroes.Item(i)
          If Not curhero.Id.GuidID = parentid.GuidID Then
            If curhero.GetHero._AttackType = eAttackType.Ranged Then
              outlist.Add(curhero)
            End If
          End If
        Next

        Return outlist

      Case eUnit.untAlliedUnit
        Dim parentunit As iDisplayUnit = DirectCast(parent, iDisplayUnit)
        If parentunit IsNot Nothing Then
          Dim targ = parentunit.GetFriendlyTarget

          outlist.Add(targ)
        End If

        Return outlist



      Case eUnit.untAlliedUnits
        Return myteam.GetAllHeroAndPetUnits



      Case eUnit.untAttackingEnemyUnit
        Dim attackingenemies = enemyteam.GetAllHeroInstances

        For i As Integer = 0 To attackingenemies.Count - 1
          Dim enemy = attackingenemies.Item(i)
          If enemy.GetEnemyTarget.Id.GuidID = parentid.GuidID Then
            outlist.Add(enemy)
          End If
        Next

        Return outlist



      Case eUnit.untControlledUnits
        Return myteam.GetAllPetUnits



      Case eUnit.untCreep
        Dim thecreeps = enemyteam.GetAllCreepUnits

        If Not thecreeps Is Nothing Then
          For i As Integer = 0 To thecreeps.Count - 1
            If thecreeps.Item(i).Id.GuidID = themod.Target.Id.GuidID Then
              outlist.Add(thecreeps.Item(i))
              Return outlist
            End If
          Next
          Return outlist

        Else
          Return outlist
        End If



      Case eUnit.untEnemieTeam
        Return enemyteamids



      Case eUnit.untEnemyCreep
        Dim thecreeps = enemyteam.GetAllCreepUnits

        If Not thecreeps Is Nothing Then
          For i As Integer = 0 To thecreeps.Count - 1
            If thecreeps.Item(i).Id.GuidID = themod.Target.Id.GuidID Then
              outlist.Add(thecreeps.Item(i))
              Return outlist
            End If
          Next
          Return outlist

        Else
          Return outlist
        End If

      Case eUnit.untEnemyCreeps
        Return enemyteam.GetAllCreepUnits



      Case eUnit.untEnemyHero
        Dim parenthero = DirectCast(parent, HeroInstance)
        If Not parenthero Is Nothing Then
          outlist.Add(parenthero)
          Return outlist
        Else
          Return outlist
        End If



      Case eUnit.untEnemyHeroes
        Return enemyteam.GetAllHeroes



      Case eUnit.untEnemyHeroNearest
        Dim theindex = myteam.GetIndexOfHero(parentid)
        If enemyteamids.Count < theindex Then
          outlist.Add(enemyteamids.Item(theindex))
          Return outlist
        Else
          outlist.Add(enemyteamids.Item(enemyteamids.Count - 1))
        End If
        Return outlist


      Case eUnit.untEnemyMeleeTarget
        Dim parentunit = DirectCast(parent, HeroInstance)

        If parentunit IsNot Nothing Then
          Dim enemytarget = parentunit.GetEnemyTarget

          If parentunit.GetHero._AttackType = eAttackType.Melee Then
            outlist.Add(enemytarget)
          Else
            Return outlist
          End If

        End If
        Return outlist


      Case eUnit.untEnemyStealthUnits
        'this will not work as intended... not mechanism to reevaluate stealth state over time
        For i As Integer = 0 To enemybuilds.Count - 1

          If enemybuilds.Item(i).IsStealthed(thegame.TimeKeeper.CurrentTime) Then
            outlist.Add(enemybuilds.Item(i))
          End If

        Next
        Return outlist


      Case eUnit.untEnemyStructure

        Dim parentunit = DirectCast(parent, iDisplayUnit)
        If parentunit IsNot Nothing Then
          Dim structs = enemyteam.GetAllStructures
          For i As Integer = 0 To structs.Count - 1
            If structs.Item(i).Id.GuidID = parentunit.GetEnemyTarget.Id.GuidID Then
              outlist.Add(structs.Item(i))
            End If
          Next

        End If
        Return outlist



      Case eUnit.untEnemyStructures
        Return enemyteam.GetAllStructures



      Case eUnit.untEnemyTarget
        Dim parentunit = DirectCast(parent, iDisplayUnit)
        If parentunit IsNot Nothing Then
          Dim targ = parentunit.GetEnemyTarget
          If targ IsNot Nothing Then
            outlist.Add(targ)
          End If

        End If

        Return outlist



      Case eUnit.untEnemyTargetsFixedCount
        Dim eunits = enemyteam.GetAllHeroAndPetUnits
        Dim unitcount = eunits.Count
        For i As Integer = 0 To themod.TheModValue.Charges.Count - 1
          If i < unitcount Then
            outlist.Add(eunits.Item(i))
          End If
        Next
        Return outlist



      Case eUnit.untEnemyTargettingCaster
        For i As Integer = 0 To enemybuilds.Count - 1
          If enemybuilds.Item(i).GetEnemyTarget.Id.GuidID = parentid.GuidID Then
            outlist.Add(enemybuilds.Item(i))
          End If
        Next
        Return outlist



      Case eUnit.untEnemyUnit
        outlist.Add(myteam.EnemyTarget)
        Return outlist



      Case eUnit.untEnemyUnitNearest
        outlist.Add(enemyteam.GetAllHeroAndPetUnits.Item(0))
        Return outlist



        'Case eUnit.untEnemyUnitRandom
        '  Dim units = enemyteam.GetAllUnitIDs
        '  Dim unitcount = units.Count
        '  Dim rndunit = CInt(Math.Ceiling(Rnd() * unitcount)) + 1

        '  outlist.Add(units.Item(rndunit))
        '  Return outlist



      Case eUnit.untEnemyUnits
        Return CalcEnemyUnitsAffected(themod, curlvl, thegame, curtime)



      Case eUnit.untEnemyUnitsNotTargetted

        For i As Integer = 0 To myteambuilds.Count - 1
          Dim thetarget = myteambuilds.Item(i)
          If Not outlist.Contains(thetarget) Then outlist.Add(thetarget)
        Next
        Return outlist



      Case eUnit.untEnemyUnitwLowestHealth
        Dim theunit = enemyteam.GetUnitWithLowestHealth(curtime)

        outlist.Add(theunit)
        Return outlist



      Case eUnit.untRandomEnemyUnit
        Dim units = enemyteam.GetAllHeroAndPetUnits
        Dim unitcount = units.Count
        Dim rndunit = CInt(Math.Ceiling(Rnd() * unitcount)) - 1

        outlist.Add(units.Item(rndunit))
        Return outlist


      Case eUnit.untRandomUnit
        Dim units = thegame.GetAllUnits
        Dim unitcount = units.Count
        Dim rndunit = CInt(Math.Ceiling(Rnd() * unitcount)) - 1

        outlist.Add(units.Item(rndunit))
        Return outlist



      Case eUnit.untRoshan
        'need to implement once units are added
        Return outlist



      Case eUnit.untSelf
        outlist.Add(themod.TheModInfo.Parent)
        Return outlist

      Case eUnit.untTree
        'need to implement once units are added
        Return outlist

      Case eUnit.untTrees
        'need to implement once units are added
        Return outlist

      Case eUnit.untUnits
        Return thegame.GetAllUnits



      Case eUnit.untUntargetedEnemyUnits
        outlist = enemyteamids

        For i As Integer = 0 To myteambuilds.Count - 1

          For y As Integer = outlist.Count - 1 To 0 Step -1
            If myteambuilds.Item(i).GetEnemyTarget.Id.GuidID = outlist.Item(y).Id.GuidID Then
              outlist.Remove(outlist.Item(y))
            End If
          Next
        Next
        Return outlist

      Case eUnit.untAlliedCreep
        'change when creeps are back on teams
        Return outlist

      Case Else
        Dim xb = 2
        PageHandler.theLog.Writelog("Helpers.GetaffectedUnitIDsForMod missing " & thetype.ToString)

        outlist.Add(themod.TheModInfo.Parent)
        Return outlist

    End Select

  End Function

  Public Shared Function GetTransparencyBrush(transamount As Integer, thecolor As SolidColorBrush) As SolidColorBrush
    Dim thecol = thecolor.Color
    If transamount > 255 Then transamount = 255

    Return New SolidColorBrush(Color.FromArgb(transamount, thecol.R, thecol.G, thecol.B))

  End Function


  Public Shared Function CalcEnemyUnitsAffected(themod As Modifier, _
                                                   thecurabilitylevel As Integer, _
                                                   thegame As dGame, _
                                                   thecurtime As ddFrame) As List(Of iDisplayUnit)

    '  Dim thetarg = themod.TheModInfo.Target
    '  Dim affectedunitTypes = themod.TheModInfo.AffectedUnitTypes
    'Dim thecaster = themod.ModGenerator
    Dim outlist As New List(Of iDisplayUnit)
    Dim enemyteam = thegame.GetEnemyTeamUnits(themod.Parent)
    ' Dim myteam = thegame.GetTeamFromUnit(themod.Parent)
    ' Dim parentid = themod.Parent


    Dim AoA As Double = themod.TheModValue.GetAreaOfAffected(thecurabilitylevel)


    Dim enemycount As Integer = 0
    Select Case AoA

      Case Is <= Constants.cMaxSmallArea
        If enemyteam.Count >= Constants.cSmallEnemyCount Then
          enemycount = Constants.cSmallEnemyCount
        Else
          enemycount = enemyteam.Count
        End If

      Case Is <= Constants.cMaxMedArea
        If enemyteam.Count >= Constants.cMedEnemyCount Then
          enemycount = Constants.cMedEnemyCount
        Else
          enemycount = enemyteam.Count
        End If

      Case Is > Constants.cMaxMedArea
        If enemyteam.Count >= Constants.cLrgEnemyCount Then
          enemycount = Constants.cLrgEnemyCount
        Else
          enemycount = enemyteam.Count
        End If

      Case Else 'includes large radius and mapwide radius
        enemycount = enemyteam.Count

    End Select

    For i As Integer = 0 To enemycount - 1
      outlist.Add(enemyteam.Item(i))
    Next
    Return outlist
  End Function


  Public Shared Function GetAllTimesFromLifetime(thelife As Lifetime, theframerate As ddFrame) As List(Of ddFrame)
    If thelife.Lifespan.count < theframerate.count Then Return New List(Of ddFrame)
    Dim currtime = thelife.CreationTime
    Dim outlist As New List(Of ddFrame)


    Dim endtime = New ddFrame(thelife.CreationTime.count + thelife.Lifespan.count)
    Do Until currtime.count > endtime.count

      outlist.Add(currtime)
      currtime = New ddFrame(currtime.count + theframerate.count)

    Loop
    Return outlist


  End Function

  Public Shared Function GetCommonLifetimeFromLifetimes(firstlife As Lifetime, seclife As Lifetime, theframerate As ddFrame)

    Dim firsttimes = GetAllTimesFromLifetime(firstlife, theframerate)

    Dim outtimes As New List(Of ddFrame)
    For i As Integer = 0 To firsttimes.Count - 1

      Dim curframe = firsttimes.Item(i)

      If seclife.LifeTimeContainsTime(curframe) Then
        outtimes.Add(curframe)
      End If
    Next
    Return New Lifetime(outtimes, theframerate)
  End Function

  Public Shared Function ParseStringForImg(thestring As String) As String

    If thestring.Contains("src") Then
      'Dim thestrings = thestring.Split("src=""")
      Dim thestrings As String() = thestring.Split(New String() {"src="""},
                                        StringSplitOptions.None)
      thestrings = thestrings(1).Split("""")

      Dim outstring As String = thestrings(0)
      'If outstring.Contains("http://") Then
      '  outstring = outstring.Remove(outstring.IndexOf("http://"), 7)
      'End If
      Return outstring
    End If
    Return Nothing
  End Function

  Public Shared Function MakeTextBlock(thetext As String) As TextBlock
    Dim pid As New TextBlock
    pid.FontFamily = Constants.cBodyFont
    pid.Foreground = New SolidColorBrush(PageHandler.dbColors.BodyTextColor)
    pid.FontSize = Constants.cBodyFontSize
    pid.Text = thetext

    Return pid
  End Function

  Public Shared Function MakeHeadingBlock(thetext As String) As ctrlHeadingLabel
    Dim outlbl As New ctrlHeadingLabel()
    outlbl._Content = thetext
    Return outlbl
  End Function

  Public Shared Function MakeSubHeadingLabel(thetext As String) As ctrlSubHeading
    Dim outlbl As New ctrlSubHeading()
    outlbl.LayoutRoot.Content = thetext
    Return outlbl
  End Function

  Public Shared Function GetFriendlyTime(thetime As ddFrame) As String
    'Dim themins = (thetime.count / 60) - (thetime.count Mod 60)
    'Dim thesecs = thetime.count - (themins * 60)

    'Return themins & ":" & thesecs

    'Return GetFriendlyTime(New DateTime((thetime.count * PageHandler.mTimeKeeper.Framerate.count) * TimeSpan.TicksPerSecond))
    Return GetFriendlyTime(New DateTime(thetime.count * TimeSpan.TicksPerSecond))
  End Function
  Public Shared Function GetFriendlyTime(thetime As DateTime) As String
    Dim hours = thetime.Hour.ToString

    Dim mins = thetime.Minute.ToString

    Dim secs = thetime.Second.ToString

    Dim ticks = thetime.Millisecond

    Select Case hours
      Case 0
        hours = ""
      Case 1
        hours = "0" & hours & ":"
      Case 2
        hours = hours & ":"
    End Select


    Select Case mins.Length
      Case 0
        mins = "00"
      Case 1
        mins = "0" & mins
    End Select

    Select Case secs.Length
      Case 0
        secs = "00"
      Case 1
        secs = "0" & secs
    End Select
    Dim outval = hours & mins & ":" & secs

    If ticks > 0 Then
      Dim outticks = ticks / 1000
      outticks = Math.Round(outticks, 2)
      Dim strticks = outticks.ToString
      strticks = strticks.Substring(strticks.IndexOf("."))
      outval = outval & strticks
    End If
    Return outval
  End Function

  Public Shared Function GetFriendlyTimeSpan(theseconds As Double) As String
    If theseconds = Nothing Then Return ""
    Return GetFriendlyTimeSpan(TimeSpan.FromSeconds(theseconds))
  End Function

  Public Shared Function GetFriendlyTimeSpan(thespan As TimeSpan) As String
    Dim hours = thespan.Hours.ToString

    Dim mins = thespan.Minutes.ToString

    Dim secs = thespan.Seconds.ToString

    Dim ticks = thespan.Milliseconds

    Select Case hours
      Case 0
        hours = ""
      Case 1
        hours = "0" & hours
      Case 2
        hours = hours
    End Select


    Select Case mins.Length
      Case 0
        mins = "00"
      Case 1
        mins = "0" & mins
    End Select


    Select Case secs.Length
      Case 0
        secs = "00"
      Case 1
        secs = "0" & secs
    End Select


    Dim outval As String = ""

    If Not hours = "" Then
      outval = hours & ":"
    End If

    If mins = "00" Then
      If Not hours = "" Then
        outval = outval & mins & ":"
      End If
    End If
    If outval = "" Then
      If Not secs = "00" Then
        outval = thespan.Seconds.ToString
      End If
    Else
      outval = outval & secs
    End If


    If ticks > 0 Then
      Dim outticks = ticks / 1000
      outticks = Math.Round(outticks, 2)
      Dim strticks = outticks.ToString
      strticks = strticks.Substring(strticks.IndexOf("."))
      outval = outval & strticks
    End If
    Return outval
  End Function
  Public Shared Function GetFriendlyGuid(theguid As Guid) As String
    Dim str = theguid.ToString
    Return str.Substring(0, 4)
  End Function

  Public Shared Function GetTimeSpanAsSeconds(thespan As TimeSpan) As Double
    Return thespan.Ticks / 10000000

  End Function
  '#Region "Friendly Names"

  '  Public Shared Function GetFriendlyCreepName( thecreeptype As eCreepName) As String
  '    Select Case thecreeptype
  '      Case eCreepName.untHawk
  '        Return "Hawk"
  '      Case eCreepName.untBoar
  '        Return "Boar"
  '      Case eCreepName.untLycan_Wolf
  '        Return "Lycan Wolf"
  '      Case eCreepName.untUndying_Zombie
  '        Return "Undying Zombie"
  '      Case eCreepName.untSpiderling
  '        Return "Spiderling"
  '      Case eCreepName.untSpiderite
  '        Return "Spiderite"
  '      Case eCreepName.untTreant
  '        Return "Treant"
  '      Case eCreepName.untEidolon
  '        Return "Eidolon"
  '      Case eCreepName.untForged_Spirit
  '        Return "Forged Spirit"
  '      Case eCreepName.untSkeleton_Warrior
  '        Return "Skeleton Warrior"
  '      Case eCreepName.untNecro_Warrior
  '        Return "Necronomicon Warrior"
  '      Case eCreepName.untNecro_Archer
  '        Return "Necronomicon Warrior"
  '      Case eCreepName.untEarth_Brewmaster
  '        Return "Earth"
  '      Case eCreepName.untStorm_Brewmaster
  '        Return "Storm"
  '      Case eCreepName.untFire_Brewmaster
  '        Return "Fire"
  '      Case eCreepName.untGolem_Warlock
  '        Return "Golem"
  '      Case eCreepName.untSpirit_Bear
  '        Return "Spirit Bear"
  '      Case eCreepName.untFamiliar
  '        Return "Familiar"
  '      Case eCreepName.untPlague_Ward
  '        Return "Plague Ward"
  '      Case eCreepName.untSerpent_Ward
  '        Return "Serpent Ward"
  '      Case eCreepName.untDeath_Ward
  '        Return "Death Ward"
  '      Case eCreepName.untHealing_Ward
  '        Return "Healing Ward"
  '      Case eCreepName.untFrozen_Sigil
  '        Return "Frozen Sigil"
  '      Case eCreepName.untTornado
  '        Return "Tornado"
  '      Case eCreepName.untPsionic_Trap
  '        Return "Psionic Trap"
  '      Case eCreepName.untLand_Mine
  '        Return "Land Mine"
  '      Case eCreepName.untStasis_Trap
  '        Return "Stasis Trap"
  '      Case eCreepName.untRemote_Mine
  '        Return "Remote Mine"
  '      Case eCreepName.untNether_Ward
  '        Return "Nether Ward"
  '      Case eCreepName.untPower_Cog
  '        Return "Power Cog"
  '      Case eCreepName.untTombstone
  '        Return "Tombstone"
  '      Case eCreepName.untPhoenix_Sun
  '        Return "Phoenix Sun"
  '      Case eCreepName.untObserver_Ward
  '        Return "Observer Ward"
  '      Case eCreepName.untSentry_Ward
  '        Return "Sentry Ward"
  '      Case eCreepName.untMelee_Creep
  '        Return "Melee Creep"
  '      Case eCreepName.untSuper_Melee_Creep
  '        Return "Super Melee Creep"
  '      Case eCreepName.untMega_Melee_Creep
  '        Return "Mega Melee Creep"
  '      Case eCreepName.untRanged_Creep
  '        Return "Ranged Creep"
  '      Case eCreepName.untSuper_Ranged_Creep
  '        Return "Super Ranged Creep"
  '      Case eCreepName.untMega_Ranged_Creep
  '        Return "Mega Ranged Creep"
  '      Case eCreepName.untSiege_Creep
  '        Return "Siege Creep"
  '      Case eCreepName.untSiege_Creep_Bonus
  '        Return "Siege Creep Bonus Damage"
  '      Case eCreepName.untKobold
  '        Return "Kobold"
  '      Case eCreepName.untKobold_Soldier
  '        Return "Kobold Soldier"
  '      Case eCreepName.untKobold_Foreman
  '        Return "Kobold Foreman"
  '      Case eCreepName.untHill_Troll_Berserker
  '        Return "Hill Troll Berserker"
  '      Case eCreepName.untHill_Troll_Priest
  '        Return "Hill Troll Priest"
  '      Case eCreepName.untVhoul_Assassin
  '        Return "Vhoul Assassin"
  '      Case eCreepName.untFell_Spirit
  '        Return "Fell Spirit"
  '      Case eCreepName.untGhost
  '        Return "Ghost"
  '      Case eCreepName.untHarpy_Scout
  '        Return "Harpy Scount"
  '      Case eCreepName.untHarpy_Stormcrafter
  '        Return "Harpy Stormcrafter"
  '      Case eCreepName.untCentaur_Conqueror
  '        Return "Centaur Conqueror"
  '      Case eCreepName.untCentaur_Courser
  '        Return "Centaur Courser"
  '      Case eCreepName.untGiant_Wolf
  '        Return "Giant Wolf"
  '      Case eCreepName.untAlpha_Wolf
  '        Return "Alpha Wolf"
  '      Case eCreepName.untSatyr_Banisher
  '        Return "Satyr Banisher"
  '      Case eCreepName.untSatyr_Mindstealer
  '        Return "Satyr Mindstealer"
  '      Case eCreepName.untOgre_Bruiser
  '        Return "Ogre Bruiser"
  '      Case eCreepName.untOgre_Frostmage
  '        Return "Ogre Frostmage"
  '      Case eCreepName.untMud_Golem
  '        Return "Mud Golem"
  '      Case eCreepName.untSatyr_Tormentor
  '        Return "Satyr Tormentor"
  '      Case eCreepName.untHellbear
  '        Return "Hellbear"
  '      Case eCreepName.untHellbear_Smasher
  '        Return "Hellbear Smasher"
  '      Case eCreepName.untWildwing
  '        Return "Wildwing"
  '      Case eCreepName.untWildwing_Ripper
  '        Return "Wildwing Ripper"
  '      Case eCreepName.untDark_Troll_Summoner
  '        Return "Dark Troll Summoner"
  '      Case eCreepName.untHill_Trll
  '        Return "Hill Troll"
  '      Case eCreepName.untAncient_Black_Dragon
  '        Return "Ancient Black Dragon"
  '      Case eCreepName.untAncient_Black_Drake
  '        Return "Ancient Black Drake"
  '      Case eCreepName.untAncient_Granite_Golem
  '        Return "Ancient Granite Golem"
  '      Case eCreepName.untAncient_Rock_Golem
  '        Return "Ancient Rock Golem"
  '      Case eCreepName.untAncient_Thunderhide
  '        Return "Ancient Thunderhide"
  '      Case eCreepName.untAncient_Rumblehide
  '        Return "Ancient Rumblehide"
  '      Case eCreepName.untRoshan
  '        Return "Roshan"
  '      Case eCreepName.untTower_Tier_1
  '        Return ""
  '      Case eCreepName.untTower_Tier_2
  '        Return ""
  '      Case eCreepName.untTower_Tier_3
  '        Return ""
  '      Case eCreepName.untTower_Tier_4
  '        Return ""
  '      Case eCreepName.untAncient
  '        Return ""
  '      Case eCreepName.untMelee_Barracks
  '        Return ""
  '      Case eCreepName.untRanged_Barracks
  '        Return ""
  '      Case eCreepName.untFountain
  '        Return ""
  '      Case eCreepName.untBuffer_Building
  '        Return ""

  '    End Select
  '  End Function

  '  Public Shared Function GetFriendlyStatName( thestat As eStat) As String
  '    Select Case thestat
  '      Case eStat.None
  '        Return "None"
  '      Case eStat.AttackSpeed 'AttackSpeed = AttackSpeedBuffs - AttaskSpeedDebuffs
  '        Return "Attack Speed"
  '      Case eStat.AttackDamageLow
  '        Return "Attack Damage Low"
  '      Case eStat.AttackDamageHigh
  '        Return "Attack Damage High"
  '      Case eStat.AttackRange
  '        Return "Attack Range"
  '      Case eStat.PhysicalArmor
  '        Return "Physical Armor"
  '      Case eStat.PhysicalDamageReduction
  '        Return "Physical Damage Reduction"
  '      Case eStat.PhysicalDamageAmplification
  '        Return "Physical Damage Amplification"
  '      Case eStat.PhysicalDamageNegation
  '        Return "Physical Damage Negation"
  '      Case eStat.MagicalDamageResistance
  '        Return "Magic Resistance"
  '      Case eStat.MovementSpeed
  '        Return "Movement Speed"
  '      Case eStat.Strength
  '        Return "Strength"
  '      Case eStat.Agility
  '        Return "Agility"
  '      Case eStat.Intelligence
  '        Return "Intelligence"
  '      Case eStat.Networth
  '        Return "Net Worth"
  '      Case eStat.Experience
  '        Return "Experience"
  '      Case eStat.MagicDamage
  '        Return "Magical Damage"
  '      Case eStat.PhysicalDamage
  '        Return "Physical Damage"
  '      Case eStat.PureDamage
  '        Return "Pure Damage"
  '      Case eStat.HitPoints
  '        Return "Hit Points"
  '      Case eStat.HitPointRegen
  '        Return "Health Regeneration"
  '      Case eStat.Mana
  '        Return "Mana"
  '      Case eStat.ManaRegen
  '        Return "Mana Regeneration"
  '      Case eStat.Vision
  '        Return "Vision"
  '      Case eStat.TrueSight
  '        Return "TrueSight"
  '      Case eStat.Stealth
  '        Return "Stealth"
  '      Case eStat.PrimaryAttribute
  '        Return "Primary Attribute"
  '      Case Else
  '        PageHandler.theLog.writelog("helpers.getfriendlystatname unhandled type: " & thestat.ToString)
  '        Return thestat.ToString

  '    End Select
  '  End Function
  '  Public Shared Function GetFriendlyModifierName( themodtype As eModifierType) As String




  '    Select Case themodtype

  '      Case eModifierType.AbilityEffectiveHp '= 87
  '      Case eModifierType.MuteAbilities '= 79 'unable to cast abilities
  '        Return "Abilities Disabled"
  '      Case eModifierType.AbilitySteal 'Doom Devour
  '        Return "Aquires All Targetted Creep's Abilities"
  '      Case eModifierType.AdaptiveStrikeDamageMagicalInflicted 'Morphling Adaptive Strike. Used Agility to calc damage inflicted
  '        Return "Magic Damage Inflicted"
  '      Case eModifierType.AdaptiveStrikeStun 'Morphling Adaptive Strike. Calculated using current strength and agility
  '        Return "Stun"
  '      Case eModifierType.AgiAdded '= 15
  '        Return "Agility Added"
  '      Case eModifierType.AgioT '= 17
  '        Return "Agility Over Time Added"
  '      Case eModifierType.AgiPercent '= 16
  '        Return "Agility Increase"
  '      Case eModifierType.AgiSubtracted ' Slark Essence Shift
  '        Return "Agility Removed"
  '      Case eModifierType.ArcaneOrb '= 50 'OD
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString
  '      Case eModifierType.ArmorAdded
  '        Return "Physical Armor Added"
  '      Case eModifierType.ArmorAddedPerSec '= 9
  '        Return "Physical Armor Added Over Time"
  '      Case eModifierType.ArmoroT '= 11
  '        Return "Physical Armor Added Over Time"
  '      Case eModifierType.ArmorPercentage '= 10
  '        Return "Physical Armor Increase"
  '      Case eModifierType.ArmorStackSubtracted 'Bristlebakc Nasal Goo
  '        Return "Physical Armor Stack Removed"
  '      Case eModifierType.ArmorSubtracted
  '        Return "Physical Armor Removed"
  '      Case eModifierType.AstralSpiritDamageMagicalAdded 'Elder Titan, will have to determine how many units were hit for this to be accurate
  '        Return "Magic Damage Added"
  '      Case eModifierType.AstralSpiritMoveSpeedPercentAdded 'Elder Titan, have to determine how many creeps hit
  '        Return "Movement Speed Increase"
  '      Case eModifierType.AstrlImpIntStolen 'OD Astral Imprisonment. Only steals int if target is enemy hero
  '        Return "Intelligence Added"
  '      Case eModifierType.MuteAttacks 'Flaming Lasso Batrider
  '        Return "Right-click Disabled"
  '      Case eModifierType.AttackSpeedAdded '= 25
  '        Return "Attack Speed Added"
  '      Case eModifierType.AttackSpeedAddedPerHeroPerMissHP 'Bloodseeker Thirst
  '        Return "Attack Speed Added"
  '      Case eModifierType.AttackSpeedAddedtoXAttacks 'Ursa Overpower. Attack speed only added to a certain number of rightclick attacks
  '        Return "Attack Speed for ? Attacks"
  '      Case eModifierType.AttackSpeedMaxed 'Windranger Focus Fire
  '        Return "Attack Speed Maxed Out"
  '      Case eModifierType.AttackSpeedoT '= 27
  '        Return "Attack Speed Added over Time"
  '      Case eModifierType.AttackSpeedPercentAdded '= 26
  '        Return "Attack Speed Increase"
  '      Case eModifierType.AttackSpeedPercentofTargetAdded 'Visage Grave Chill
  '        Return "Attack Speed Increase"
  '      Case eModifierType.AttackSpeedPercentSubtracted 'Medusa Stone Gaze
  '        Return "Attack Speed Decrease"
  '      Case eModifierType.AttackSpeedStackAdded 'Lina Fiery Soul
  '        Return "Attack Speed Stack Added"
  '      Case eModifierType.AttackspeedSubtracted 'AA Chilling Touch
  '        Return "Attack Speed Removed"
  '      Case eModifierType.BackstabRightclickDamageAddedAsPercofAgi 'Riki Backstab. only occurs when attacking from rear
  '        Return "Right-click Damage Added"
  '      Case eModifierType.BallLightDamMagicalInflicted 'Storm Spirit Ball Lightning
  '        Return "Magic Damage Inflicted"
  '      Case eModifierType.BallLightPushForward 'SS Ball Lightning charge
  '        Return "Push Forward"
  '      Case eModifierType.Barrier 'earthsaker wall, tusk iceshards...
  '        Return "Barrier"
  '      Case eModifierType.BaseAgi '= 89
  '        Return "Base Agility Added"
  '      Case eModifierType.BaseandBonusDamageReduction 'Windranger Focus Fire
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString
  '      Case eModifierType.BaseArmorPercentSubtracted 'Elder Titan Natural Order
  '        Return "Base Physical Armor Decrease"
  '      Case eModifierType.BaseAttackDamageLow
  '        Return "Base Attack Damage Low"
  '      Case eModifierType.BaseAttackDamageHigh
  '        Return "Base Attack Damage High"
  '      Case eModifierType.BaseAttackDamageAvg
  '        Return "Average Base Attack Damage"
  '      Case eModifierType.BaseAttackRange
  '        Return "Base Attack Range"
  '      Case eModifierType.BaseAttackTime '= 24
  '        Return "Right-click Attack Speed Added"
  '      Case eModifierType.BaseAttackTimeChangedTo ' Alchemist Chemical Rage
  '        Return "Right-click Attack Speed Added"
  '        'Case eModifierType.BaseEffectiveHP '= 1
  '        '  PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString
  '        'Case eModifierType.BaseHP '= 0
  '        '  Return "Base HP Added"
  '      Case eModifierType.BaseInt '= 90
  '        Return "Base Intelligence Added"
  '      Case eModifierType.BaseMagicResistance '= 29
  '        Return "Base Magic Resistance Added"
  '      Case eModifierType.BaseMagicResistancePercentSubtracted 'Elder Titan Natural Order
  '        Return "Base Magic Resistance Decrease"
  '      Case eModifierType.BaseMana '= 5
  '        Return "Base Mana Added"
  '      Case eModifierType.BaseStr '= 88
  '        Return "Base Strength Added"
  '      Case eModifierType.BaseXP
  '        Return "Experience"
  '      Case eModifierType.Bash '= 35 'http://dota2.gamepedia.com/Bash
  '        Return "Bash Physical Damage"
  '      Case eModifierType.BearBonusDamage 'Lone Druid Synergy
  '        Return "Bonus Damage"
  '      Case eModifierType.BearMoveSpeedAdded 'Lone Druid Synergy
  '        Return "Movement Speed Added"
  '      Case eModifierType.BerserkersBonusAttackSpeed 'Huskar Berserker's Blood. Oy
  '        Return "Attack Speed Added"
  '      Case eModifierType.BerserkersBonusMagicResistance 'Huskar Berserker's Blood
  '        Return "Bonus Magic Resistance Added"
  '      Case eModifierType.BlindChance '= 57 'http://dota2.gamepedia.com/Blind
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString
  '      Case eModifierType.BlindDuration '= 58
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString
  '      Case eModifierType.MuteBlink '= 81 'unable to blink
  '        Return "Blink Disabled"
  '      Case eModifierType.BonusDamage
  '        Return "Bonus Damage Added"
  '      Case eModifierType.BonusDamageoT
  '        Return "Bonus Damage Added Over Time"
  '      Case eModifierType.BonusDamagePercent 'Lycan Feral Impulse
  '      Case eModifierType.BonusGold
  '        Return "Bonus Gold Added"
  '      Case eModifierType.BountyGold
  '        Return "Gold Added"
  '      Case eModifierType.CausticFinale '= 45 'SandKing
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString
  '      Case eModifierType.ChainLightning '= 54 'Maelstrom, Mjolnir
  '        Return "Chain Lightning Damage"
  '      Case eModifierType.ChenAncientCount 'count of potential ancients that can be holy pursuasioned
  '        Return "Ancients Able to Be Persuaded"
  '      Case eModifierType.ChenCreepFullHeal 'Chen Hand of God
  '        Return "Target Creep is Fully Healed"
  '      Case eModifierType.CleavePercentage '= 36 'http://dota2.gamepedia.com/Cleave , http://dota2.gamepedia.com/Mechanics#Cleave_Damage
  '        Return "Cleave Damage Increase"
  '      Case eModifierType.ColdAttack '= 53 'Skadi
  '        Return "Cold Attack Added"
  '      Case eModifierType.ConjuredImage 'Terrorblade Conjure Image. Takes stats from TB's current stats
  '        Return "Conjured Image"
  '      Case eModifierType.Consumption 'Doom Devour
  '        Return "Consumes Enemy"
  '      Case eModifierType.ControlledCreepHealthBonus 'Chen Holy Pursuasion
  '        Return "HP Added to Controlled Creeps"
  '      Case eModifierType.Corruption '= 52 'Desolator
  '        Return "Physical Armor Removed"
  '      Case eModifierType.CreepControlled 'Chen Holy Pursuasion
  '        Return "Creep Controlled"
  '      Case eModifierType.CripplingFearMissChance 'NightStalker. Values change if day or night
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString
  '      Case eModifierType.CritChance '= 37 'http://dota2.gamepedia.com/Critical_strike
  '        Return "Right-click Crit Chance Increase"
  '      Case eModifierType.CritDamage 'Jinada
  '        Return "Right-click Crit Damage Added"
  '      Case eModifierType.CritMultiplier '= 38
  '        Return "Right-click Damage Multiplied"
  '      Case eModifierType.Cyclone '= 59 'http://dota2.gamepedia.com/Cyclone
  '        Return "Invulnerability"
  '      Case eModifierType.DamageAbsorbedForMana 'Medusa Mana Shield .absorbs damage in exchange for mana
  '        Return "Incoming Damage Abosorbed/ Mana Removed"
  '      Case eModifierType.DamageAllTypesIncomingIncreasesPercent 'Slardar Sprint
  '        Return "All Incoming Damage Increase"
  '      Case eModifierType.DamageAllTypesPercentAdded 'Clinkz DeathPact
  '        Return "All Damage Increase"
  '      Case eModifierType.DamageAllTypesStackAdded 'Bristleback Warpath adds damage to spells and abilitys of all damage types
  '        Return "All Damage Added"
  '      Case eModifierType.DamageAmplification '= 31 'http://dota2.gamepedia.com/Damage_amplification
  '        Return "All Damage Increase"
  '      Case eModifierType.DamageBlock
  '        Return "Damage Removed"
  '      Case eModifierType.DamageBlockRemoved 'SS Hex
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString
  '      Case eModifierType.DamageBothBlockAdded
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString
  '      Case eModifierType.DamageChainMagicalInflicted 'WitchDoctor Paralyzing cask
  '        Return "Magic Damage per Hit Inflicted"
  '      Case eModifierType.DamageChainPhysicalInflicted 'Mjolnir
  '        Return "Physical Damage per Hit Inflicted"
  '      Case eModifierType.DamageDelay 'Kunka Ghost Ship
  '        Return "Damage Delay Time"
  '      Case eModifierType.DamageIncreasePercent 'Chen Penitence
  '        Return "All Incoming Damage Increase"
  '      Case eModifierType.DamageInstanceBlock 'treant Living Armor
  '        Return "Damage Instance Blocked"
  '      Case eModifierType.DamageLost 'due to LC Duel, Razor static link
  '        Return "Right-click Damage Removed"
  '      Case eModifierType.DamageMagicalAbsorbed 'Ember Spirit Flameguard
  '        Return "Magic Damage Removed"
  '      Case eModifierType.DamageMagicalAdded 'for passaive abilities
  '        Return "Magic Damage Added"
  '      Case eModifierType.DamageMagicalAddedToPhysicalAttacks ' AA Chilling Touch
  '        Return "Right-click Magic Damage Added"
  '      Case eModifierType.DamageMagicalBouncesInflicted 'Lich ulti
  '        Return "Magic Damage per Hit Inflicted"
  '      Case eModifierType.DamageMagicalEarthSplitterAdded 'Elder Titan. Based on unit being attacked's max HP
  '        Return "Magic Damage Added"
  '      Case eModifierType.DamageMagicalImmunity 'OmniKnight Repel
  '        Return "Magic Damage Removed"
  '      Case eModifierType.DamageMagicalInflicted 'for active abilities
  '        Return "Magic Damage Inflicted"
  '      Case eModifierType.DamageMagicalInflictedOnSpellCast 'SS Overload
  '        Return "Magic Damage Inflicted"
  '      Case eModifierType.DamageMagicalInflictedPerAlly ' Tusk Snowball
  '        Return "Magic Damage Inflicted"
  '      Case eModifierType.DamageMagicalInflictedPerTarget 'SS Ether Shock, for abilities that hit x num of targets, each only once
  '        Return "Magic Damage Inflicted"
  '      Case eModifierType.DamageMagicalInflictedPerUnit 'Undying Soul Rip
  '        Return "Magic Damage Inflicted"
  '      Case eModifierType.DamageMagicalInflictedUntilSpellcast 'Silencer Curse of the Silent
  '        Return "Magic Damage Inflicted Over Time"
  '      Case eModifierType.DamageMagicalMinMaxInflicted 'value has a min and max value
  '        Return "Magic Damage Inflicted Range"
  '      Case eModifierType.DamageMagicaloTAsMultofStr 'Pudge Dismemeber
  '        Return "Magic Damage Over Time"
  '      Case eModifierType.DamageMagicalOverTimeInflicted 'LeechSeed pulse
  '        Return "Magic Damage Over Time"
  '      Case eModifierType.DamageMagicalPercent
  '        Return "Magic Damage Increase"
  '      Case eModifierType.DamageMagicalPerCreep 'LC Overwhelming Odds
  '        Return "Magic Damage Added per Creep"
  '      Case eModifierType.DamageMagicalPerHero 'LC Overwhelming Odds
  '        Return "Magic Damage Added per Hero"
  '      Case eModifierType.DamageMagicalPerMissingHP 'Necro Reaper's Scythe
  '        Return "Magic Damage Added per Missing HP"
  '      Case eModifierType.DamageMagicalPerMissingMana 'Anti Mage Mana Void
  '        Return "Magic Damage Added per Missing Mana"
  '      Case eModifierType.DamageMagicalPerSec ''axe battle hunger
  '        Return "Magic Damage Over Time"
  '      Case eModifierType.DamageMagicalRandomInflicted 'uses maxval and minval in modvalue for range of random value
  '        Return "Magic Damage Inflicted"
  '      Case eModifierType.DamageMagicalTimesInt ' Skywrath Arcane Bolt
  '        Return "Damage Magical Added"
  '      Case eModifierType.DamageMeleeAdded
  '        Return "Right-click Melee Damage Added"
  '      Case eModifierType.DamageMeleeBlockAdded '= 32 'http://dota2.gamepedia.com/Damage_Block
  '        Return "Right-click Melee Damage Removed"
  '      Case eModifierType.DamageMeleemultiplier
  '        Return "Right-click Melee Damage Multiplied"
  '      Case eModifierType.DamageoTMagicalInflicted
  '        Return "Magic Damage Over Time Inflicted"
  '      Case eModifierType.damagePerSecond 'Radiance burn
  '        Return "Physical Damage Over Time"
  '      Case eModifierType.DamagePhysicalAdded 'passive abilites
  '        Return "Physical Damage Added"
  '      Case eModifierType.DamagePhysicalBouncesInflicted 'Witch doc Death Ward
  '        Return "Physical Damage Bounces Inflicted"
  '      Case eModifierType.DamagePhysicalEarthSplitterAdded 'Elder Titan. Based on unit being attacked's max HP
  '        Return "Physical Damage Inflicted"
  '      Case eModifierType.DamagePhysicalImmunity 'OmniKnight Guardian Angel
  '        Return "Physical Damage Immunity"
  '      Case eModifierType.DamagePhysicalIncomingIncreasedPercent 'Medusa Stone Gaze
  '        Return "Incoming Physical Damage Increase"
  '      Case eModifierType.DamagePhysicalInflicted 'active abilities
  '        Return "Physical Damage Inflicted"
  '      Case eModifierType.DamagePhysicaloT
  '        Return "Physical Damage Inflicted Over Time"
  '      Case eModifierType.DamagePhysicalPercent
  '        Return "Pysical Damage Increase"
  '      Case eModifierType.DamagePhysicalPerSec
  '        Return "Physical Damage Over Time"
  '      Case eModifierType.DamagePhysicalStackingInflicted 'Bristelback Quillspray
  '        Return "Physical Damage Inflicted"
  '      Case eModifierType.DamagePhysicalSubtracted 'Enfeeble
  '        Return "Physical Damage Removed"
  '      Case eModifierType.DamagePierceAdded
  '        Return "Piercing Physical Damage Added"
  '      Case eModifierType.DamagePierceChancePercent
  '        Return "Piercing Physical Damage Chance"
  '      Case eModifierType.DamagePureAdded
  '        Return "Pure Damage Added"
  '      Case eModifierType.DamagePureAsPercentofManaPool 'OD Arcane Orb
  '        Return "Pure Damage Added"
  '      Case eModifierType.DamagePureAsPercentofMaxHP 'Enigma Midnight pulse
  '        Return "Pure Damage Added"
  '      Case eModifierType.DamagePureAsPercentofMoveDist 'Bloodseeker Rupture
  '        Return "Pure Damage Added"
  '      Case eModifierType.DamagePureInflicted
  '        Return "Pure Damage Inflicted"
  '      Case eModifierType.DamagePureoTasPercofMaxHP 'Phoenix Sun Ray
  '        Return "Pure Damage Added Over Time"
  '      Case eModifierType.DamagePureoTInflicted 'Phoenix Sun Ray
  '        Return "Pure Damage Inflicted Over Time"
  '      Case eModifierType.DamagePurePercent
  '        Return "Pure Damage Increase"
  '      Case eModifierType.DamagePureRandomInflicted 'Chen Test of Faith. uses maxval and minval in modvalue for range of random value
  '        Return "Pure Damage Inflicted"
  '      Case eModifierType.DamageRangeAdded
  '        Return "Right-click Ranged Damage Added"
  '      Case eModifierType.DamageRangeBlockAdded '= 33
  '        Return "Right-click Ranged Damage Reduced"
  '      Case eModifierType.DamageRangemultiplier
  '        Return "Right-click Ranged Damage Multiplied"
  '      Case eModifierType.DamageReduction 'Tide Anchor smash
  '        Return "Incoming Damage Decrease"
  '      Case eModifierType.DamageReturnDuration 'Blademail
  '        Return "All Damage Returned"
  '      Case eModifierType.DamageSharedWithBoundUnits 'Warlock Fatal Bonds
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString
  '      Case eModifierType.DamagetoHealPercent 'abadon ulti
  '        Return "Health Restored"
  '      Case eModifierType.DamageTransferedToCaster 'abaddon borrowed time
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString
  '      Case eModifierType.DarknessNight 'NightStalker. Artificial night induced. max vis for all enemies 675
  '        Return "Day Turns to Night"
  '      Case eModifierType.DestroysCreep 'Lich Sacrifice
  '        Return "Creep Killed"
  '      Case eModifierType.DestroysHero 'Techies Suicide
  '        Return "Techies Die"
  '      Case eModifierType.DestroysHeroBelowThreshold 'Axe Culling Blade
  '        Return "Hero Dies"
  '      Case eModifierType.DestroysTree 'Quellingblade
  '        Return "Targetted Tree Destroyed"
  '      Case eModifierType.Disarm
  '        Return "Right-click Disabled"
  '      Case eModifierType.DisarmMelee '= 69 'http://dota2.gamepedia.com/Disarm
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString
  '      Case eModifierType.DisarmRange ' Heaven's Halberd
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString
  '      Case eModifierType.DisjointRange '= 70 'http://dota2.gamepedia.com/Disjoint
  '        Return "Ranged Projectiles Lose Caster's Target"
  '      Case eModifierType.Dispel '= 71 'http://dota2.gamepedia.com/Dispel This may need to be more granular..... normal dispels, magic ummune dispels, strong dispells
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString
  '      Case eModifierType.DisruptionIllusion 'ShadowDemon Illusion
  '        Return "Targetted Hero Illusion"
  '      Case eModifierType.Dominate 'Helm of the dominator
  '        Return "Targetted Creep Controlled"
  '      Case eModifierType.DuelBonusDamage 'lc duel, seperate item so we can do a buff icon for it
  '        Return "Right-click Damage Added"
  '      Case eModifierType.ElderDragonForm 'Dragon Knight
  '        Return "Elder Dragon Form"
  '      Case eModifierType.Ensnare '= 67 'http://dota2.gamepedia.com/Ensnare
  '        Return "Movement Disabled"
  '      Case eModifierType.Entangle '= 68 'http://dota2.gamepedia.com/Entangle
  '        Return "Movement Disabled"
  '      Case eModifierType.EssenceAuraManaRestored 'instances of this determined by amount of enemies in range?
  '        Return "Mana Restored"
  '      Case eModifierType.Ethereal_Time '= 77 'http://dota2.gamepedia.com/Ethereal
  '        Return "Physical Damage Immunity" 'also mutes movement... may need to add a mod for it
  '      Case eModifierType.EvasionPercent
  '        Return "Evasion Increase"
  '      Case eModifierType.EvasionRemoved ' SS Hex removes all evasion
  '        Return "All Evasion Removed"
  '      Case eModifierType.EvilSpirits 'special modtype since spirit count is affected by witchcraft, so has to be calced from inside the mod itself
  '        Return "Evil Spirits"
  '      Case eModifierType.FadeBoltDamageMagicalBounces 'Rubick, Fade Bolt. bounces diminish the damage, thus the unique modifier. also has no bounce limit but cant hit same target twice
  '        Return "Magic Damage Bounces"
  '      Case eModifierType.Feedback '= 55 'Diffusal Blade
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString
  '      Case eModifierType.FrostArrows '= 48 'Drow
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString
  '      Case eModifierType.Ghost_Form_Time 'Ghost scepter, ethereal blade
  '        Return "Ghost Form"
  '      Case eModifierType.GlaivesWisdom '= 51 'Silencer
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString
  '      Case eModifierType.GreaterBashofCurrentLevel 'Spirit Breaker Nether Strike
  '        Return "Greater Bash Instance Added"
  '      Case eModifierType.Haunt 'Spectre haunt. Takes attributes of Spectre at time of cast
  '        Return "Haunt"
  '      Case eModifierType.HealAdded
  '        Return "Health Restored"
  '      Case eModifierType.HealAddedAsPercOfTargetCurrHP 'Lifestealer Feast
  '        Return "Health Restored"
  '      Case eModifierType.HealAddedoT 'Treant Leach Seed
  '        Return "Health Restored Over Time"
  '      Case eModifierType.HealAddedoTAsPercofMaxHP 'Phoenix Sun Ray
  '        Return "Health Restored"
  '      Case eModifierType.HealAddedPerDeadCreep 'Undying Flesh Golem
  '        Return "Health Restored"
  '      Case eModifierType.HealAddedPerDeadHero 'Undying Flesh Golem
  '        Return "Health Restored"
  '      Case eModifierType.HealAddedPerUnit 'Undying Soul Rip
  '        Return "Health Restored per Unit"
  '      Case eModifierType.HealAsPercentofHP
  '        Return "% of Max Health Restored"
  '      Case eModifierType.HealFriendlyorDamageEnemy
  '        Return "Health Restored or Magic Damage Inflicted"
  '      Case eModifierType.HealFriendlyorMagicDamEnemyoT 'Warlock Shadow Word
  '        Return "Health Restored or Magic Damage Over Time Inflicted"
  '      Case eModifierType.HealMinMaxAdded 'Value has a min and max range
  '        Return "Health Restored"
  '      Case eModifierType.HealPercent
  '        Return "Health Restored"
  '      Case eModifierType.HealthFullyRestored 'Phoenix Supernova
  '        Return "Health Fully Restored"
  '      Case eModifierType.HealthRegenAdded 'Alchemist Chemical Rage
  '        Return "HP Regen Added"
  '      Case eModifierType.HealthvalueFrozen 'AA Ice Blast
  '        Return "Immune to Health Regen"
  '        'Case eModifierType.Heropet
  '        '  Return "Pet"
  '      Case eModifierType.HeroReflection 'Terrorblade Reflection. Takes stats from targetted hero
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString
  '      Case eModifierType.Hex '= 62 'http://dota2.gamepedia.com/Hex
  '        Return "Hex"
  '      Case eModifierType.HPAdded '= 2 ' amount (pos or neg representing heal of damage) Damage type (puredamagesingletarget, magicdamageAOE, etc)
  '        Return "Hit Points Added"
  '      Case eModifierType.HPoT '= 4 'amount as total amount, damagetype(for negative numbers, otherwise none)
  '        Return "Health Restored Over Time"
  '      Case eModifierType.HPPercent '= 3 ' amount as decimal
  '        Return "Health Increase"
  '      Case eModifierType.HPRegenAdded
  '        Return "Health Regen Added"
  '      Case eModifierType.HPRegenSubtracted
  '        Return "Health Regen Removed"
  '      Case eModifierType.HPRegenPercent
  '        Return "Health Regen Increase"
  '      Case eModifierType.HPRegenPercentofCasters 'io Tether
  '        Return "Health Restored"
  '      Case eModifierType.HPRegenPerUnitKilledAdded 'necro sadist
  '        Return "Health Added Per Unit Killed"
  '      Case eModifierType.HPSubtracted
  '        Return "Health Removed"
  '      Case eModifierType.Impetus '= 43 'Enchantress
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString
  '      Case eModifierType.ImpetusDamagePureInflicted 'Enchantress Impetus. damage as function of distance
  '        Return "Pure Damage Inflicted"
  '      Case eModifierType.IncapBite '= 47 'Broodmother
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString
  '      Case eModifierType.InfestCreepHeal 'Lifestealer Infest. If infest in creep then creep hp as heal on consume
  '        Return "Health Restored"
  '      Case eModifierType.InnerVitalityPercentHealAdded 'Huskar Inner Vitality. Will have to check target's health to see which healpercentage to use
  '        Return "Health Restored"
  '      Case eModifierType.IntAdded '= 18
  '        Return "Intelligence Added"
  '      Case eModifierType.IntoT '= 20
  '        Return "Intelligence Added Over Time"
  '      Case eModifierType.IntPercent '= 19
  '        Return "Intelligence Increase"
  '      Case eModifierType.IntSubtracted 'slark Essence Shift
  '        Return "Intelligence Removed"
  '      Case eModifierType.Invisibility '= 72 'http://dota2.gamepedia.com/Invisibility
  '        Return "Invisibility"
  '      Case eModifierType.MuteInvisibility 'treant overgrowth
  '        Return "Invisibility Disabled"
  '      Case eModifierType.Invulnerability '= 73 'http://dota2.gamepedia.com/Invulnerability
  '        Return "Invulnerability"
  '      Case eModifierType.ItemEffectiveHP '= 86
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString
  '      Case eModifierType.MuteItems '= 80 'unable to cast items
  '        Return "Item Abilities Disabled"
  '      Case eModifierType.Knockback 'batrider firefly and many others
  '        Return "Knockback"
  '      Case eModifierType.KotLSpiritForm 'Kotl
  '        Return "Spirit Form"
  '      Case eModifierType.LastHitGoldAdded 'Alchemist Greevil's Greed
  '        Return "Gold Added"
  '      Case eModifierType.LastHitGoldBonusPerStack 'Alchemist Greevil's Greed
  '        Return "Gold Added Per Stack"
  '      Case eModifierType.Leap 'slark spiritbreaker
  '        Return "Leap"
  '      Case eModifierType.LifeDrainDrainfromTarget 'Pugna Life Drain. Different effects depending if target is friend or foe
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString
  '      Case eModifierType.LifeDrainPercent 'DP Exorcism
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString
  '      Case eModifierType.LifeDrainSelfEffect 'Pugna Life Drain. Different effect to pugna depending on whether targeting friend or foe
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString
  '      Case eModifierType.LifeStealAdded '= 56 'Helm of the Dominator, mask of madness, satanic 'http://dota2.gamepedia.com/Lifesteal
  '        Return "Health Restored"
  '      Case eModifierType.LifestealAddedtoAllAttackers 'Lifestealer Open Wounds. Allied Heroes get healtch when attacking enemy unit with this debuff
  '        Return "Health Added"
  '      Case eModifierType.LifeStealPercent
  '        Return "Healing Increase"
  '      Case eModifierType.LiquidFire '= 44 'Jakiro
  '        Return "Liquid Fire Damage Inflicted"
  '      Case eModifierType.LostHealthDamagePercent 'Witch Doc Maledict
  '        Return "of Lost health Inflicted as Magic Damage"
  '      Case eModifierType.LucentBeamHits 'Luna Eclipse
  '        Return "Lucent Beams"
  '      Case eModifierType.LvlDeathDamageMagicalInflicted 'Doom Lvl? Death. has to be calced at time using attacked hero level and abdoom_lvl_death.herolevelmultiplier
  '        Return "Magic Damage Inflicted"
  '      Case eModifierType.MagicDamageReceivedMultiplier ' ghost scepte
  '        Return "Magic Damage Received Increase"
  '      Case eModifierType.MagicImmunity '= 30 'http://dota2.gamepedia.com/Magic_immunity
  '        Return "Magic Immunity"
  '      Case eModifierType.MagicResistanceAdded
  '        Return "Magic Resistance Added"
  '      Case eModifierType.MagicResistanceCapped 'Lifestealer Rage. Gives 100% Magic Resistance
  '        Return "Magic Resistance Maxed (100%)"
  '      Case eModifierType.MagicResistancePercentAdded
  '        Return "Magic Resistance Increase"
  '      Case eModifierType.MagicResistancePercentSubtracted 'Pugna Decrepify
  '        Return "Magic Resistance Reduced"
  '      Case eModifierType.MagicResistanceSet 'Medusa Stone Gaze. Set Magic Resistance at a value
  '        Return "Magic Resistance Set"
  '      Case eModifierType.MagicResistanceSubtracted 'AA Ice Vortex
  '        Return "Magic Resistance Reduced"
  '      Case eModifierType.MagnatizeDamageOverTime 'will have to make concession for num enemyheroes and numboulders
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString
  '      Case eModifierType.MaimChance 'sange
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString 'this shouldn't really be a mod... just perc chance of move slow and att slow
  '      Case eModifierType.ManaAdded '= 6
  '        Return "Mana Added"
  '      Case eModifierType.ManaBreak '= 41 'Anti-Mage
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString 'shouldn't this be mana removed and magic damage?
  '      Case eModifierType.ManaBurnDamage 'Nyx Mana Burn. uses target's intelligence to calc damage
  '        Return "Magic Damage Inflicted"
  '      Case eModifierType.ManaBurnManaremoved 'Nyx Mana Burn. Uses target's intelligence to calc mana removed.
  '        Return "Mana Removed"
  '      Case eModifierType.ManaDrained ' antimage manaburn, it damage to mana inflicted.
  '        Return "Mana Removed"
  '      Case eModifierType.ManaDrainedUntilSpellcast 'Silencer Curse of the Silent. Darinas mana until duration end or target casts spell
  '        Return "Mana Removed"
  '      Case eModifierType.ManaoT '= 8
  '        Return "Mana Over Time Added"
  '      Case eModifierType.ManaPercent '= 7
  '        Return "Mana Increase"
  '      Case eModifierType.ManaPercentDrained 'Bane Fiend's Grip, percent is based off of targets max mana
  '        Return "Mana Decrease"
  '      Case eModifierType.ManaRegenAdded
  '        Return "Mana Regen Added"
  '      Case eModifierType.ManaRegenSubtracted
  '        Return "Mana Regen Removed"
  '      Case eModifierType.ManaRegenPercent
  '        Return "Mana Regen Increase"
  '      Case eModifierType.ManaRegenPercentofCasters 'IO tether
  '        Return "Mana Regen Increase"
  '      Case eModifierType.ManaRegenPerUnitKillAdded 'Necro Sadist
  '        Return "Mana Regen Added"
  '      Case eModifierType.ManaRemovedPercentoT 'KotL Mana Leak
  '        Return "Mana Decrease Over Time"
  '      Case eModifierType.ManaRestored
  '        Return "Mana Restored"
  '      Case eModifierType.ManaRestoredAsPercentOfHP 'Lich Sacrifice
  '        Return "Mana Restored"
  '      Case eModifierType.ManaRestoredPercent
  '        Return "Mana Restored"
  '      Case eModifierType.MantaMeleeIllusionDamagePercentage 'Manta style
  '        Return "Physical Melee Damage"
  '      Case eModifierType.MantaRangeIllusionDamagePercentage
  '        Return "Physical Ranged Damage"
  '      Case eModifierType.MeepoClone 'Meepo Divided We Stand
  '        Return "Clone"
  '      Case eModifierType.MeleeSlow 'orb of venom
  '        Return "Right-click Melee Attack Speed Removed"
  '      Case eModifierType.MeleeStun ' Abyssal Blade
  '        Return "Right-click Stun"
  '      Case eModifierType.MeltingStrike '= 49 'Invoker's forged Spirit
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString
  '      Case eModifierType.MidnightPulsePureDamageAdded 'Black hole scepter upgrade adds midnight pulse damage at current level
  '        Return "Pure Damage Added"
  '      Case eModifierType.Minibash_Damage
  '        Return "Physical Damage"
  '      Case eModifierType.MiniMapInvisibility 'Phantom Ass, Blur
  '        Return "Mini-map Invisibility"
  '      Case eModifierType.MiniStun
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString
  '      Case eModifierType.MirrorImage 'Naga Siren Mirror Image. Takes props from hero's stats at time
  '        Return "Mirror Image"
  '      Case eModifierType.MissChance 'Broodmother incapacitating Bite
  '        Return "Right-Click Miss Chance Added"
  '      Case eModifierType.MuteMove '= 82 'unable to move
  '        Return "Movement Disabled"
  '      Case eModifierType.MoveSpeedAdded '= 21 ''http://dota2.gamepedia.com/Slow
  '        Return "Movement Speed Added"
  '      Case eModifierType.MoveSpeedMinimum 'for haste, sets minimum movespeed at time for unit, used for Centaur stampede, etc
  '        Return "Minimum Movement Speed Set"
  '      Case eModifierType.MoveSpeedoT '= 23
  '        Return "Movement Speed Over Time Added"
  '      Case eModifierType.MoveSpeedPercent
  '        Return "Move Speed Increase"
  '      Case eModifierType.MoveSpeedPercentAdded 'Slardar Sprint
  '        Return "Movement Speed Increase"
  '      Case eModifierType.MoveSpeedPercentAddedPerHeroPerMissHP 'Bloodseeker Thirst
  '        Return "Movement Speed Increase Per Missing Hero HP"
  '      Case eModifierType.MoveSpeedPercentAsDamage 'Spiritbreaker greater bash
  '        Return "Bash Physical Damage Increase"
  '      Case eModifierType.MoveSpeedPercentofTargetAdded 'Visage Grave Chill
  '        Return "Movement Speed Added"
  '      Case eModifierType.MoveSpeedPercentStackSubtracted 'Bristleback Nasal Goo
  '        Return "Movement Speed Decreased"
  '      Case eModifierType.MoveSpeedPercentSubtracted 'Bristleback Nasal Goo
  '        Return "Movement Speed Removed"
  '      Case eModifierType.MoveSpeedSet 'Lycan Shapeshift
  '        Return "Movement Speed Set"
  '      Case eModifierType.MoveSpeedStackAdded 'Lina Fiery Soul
  '        Return "Movement Speed Added"
  '      Case eModifierType.MoveSpeedSubtracted 'boar moveslow
  '        Return "Movement Speed Reduced"
  '      Case eModifierType.MulticastBloodlustCoolReduction
  '        Return "Bloodlust Cooldown Reduction"
  '      Case eModifierType.MulticastBloodlustRadiusAdded
  '        Return "Bloodlust Radius Added"
  '      Case eModifierType.MulticastFireblastCoolReduction
  '        Return "FireBlast Cooldown Reduction"
  '      Case eModifierType.MulticastFireblastManaAdded
  '        Return "FireBlast Mana Added"
  '      Case eModifierType.MulticastFourXChance
  '        Return "4x Chance"
  '      Case eModifierType.MulticastIgniteCastRangeAdded
  '        Return "Ignite Range Added"
  '      Case eModifierType.MulticastIgniteRadius
  '        Return "Ignite Radius Added"
  '      Case eModifierType.MulticastThreeXChance
  '        Return "3x Chance"
  '      Case eModifierType.MulticastTwoXChance
  '        Return "2x Chance"
  '      Case eModifierType.MysticSnakeDamageAdded 'Medusa Mystic Snake. ability bounces between enemies, inflicting more damage the more it jumps
  '        'PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return "Magic Damage Inflicted"
  '      Case eModifierType.MysticSnakeManaAdded 'Medusa Mystic Snake. ability bounces between enemies, grabbing more mana the more it jumps
  '        Return "Mana Added"
  '      Case eModifierType.MysticSnakeManaSubtracted 'enemy units hit by mystic snake lose mana
  '        Return "Mana Reduced"
  '      Case eModifierType.BaseGold
  '        Return "Gold Accumulated"
  '      Case eModifierType.NightAttackSpeedAdded 'Nightstalker Hunter in the Night
  '        Return "Attack Speed Added"
  '      Case eModifierType.NightAttackSpeedSubtracted 'Nightstalker Void. Duration differs for day and night
  '        Return "Attack Speed Removed"
  '      Case eModifierType.NightMoveSpeedAdded 'NightStalker Hunter in the Night
  '        Return "Movement Speed Added"
  '      Case eModifierType.OpenWoundsSlowInflicted 'Lifestealer Open Wounds. Will have to call list for slow values for each interval
  '        Return "Movement Speed Reduced"
  '      Case eModifierType.PercentofCreepHealthGained 'Clinks DeathPact
  '        Return "HP Added"
  '      Case eModifierType.Phantasms 'Chaoes night ulti, receiver will have to get current chaos knight build to calc phant stats
  '        Return "Phantasm"
  '      Case eModifierType.PhantomStrikeAttSpeedAdded 'Phantom Ass, Phantom Strike. If target is enemy hero the att speed added for mCharge count of rightclick attacks
  '        Return "Right-click Attack Speed Added for ? Attacks"
  '      Case eModifierType.Phase_Form 'phase boots
  '        Return "Phase Form"
  '      Case eModifierType.PoisonAttack '= 46 'Viper, Orb of Venom
  '        Return "Magic Damage Inflicted"
  '      Case eModifierType.PrimaryStatDamageAdded 'Ethereal Blade
  '        Return "Physical Damage Inflicted"
  '      Case eModifierType.PrimaryStatLossPercent 'timeber whirling death
  '        Return "? Decrease" '? is either int, str, agi
  '      Case eModifierType.Pullback ' x marks, pudgehook
  '        Return "Pull Back"
  '      Case eModifierType.PullForward
  '        Return "Pull Forward"
  '      Case eModifierType.Purge '= 74 'http://dota2.gamepedia.com/Purge
  '        Return "Purde" 'this should at least be accompanied by move slow and att slow
  '      Case eModifierType.PurgeFrequency '= 75
  '        Return "Purge Frequency" 'isn't this just purgeval.mchance?
  '      Case eModifierType.PushForward 'force staff
  '        Return "Push Forward"
  '      Case eModifierType.PushSideways 'Beastmaster Primal Roar
  '        Return "Push SideWays"
  '      Case eModifierType.QuillSprayCast 'Bristleback Bristleback ability
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString
  '      Case eModifierType.RabidAttackSpeedAdded 'Lone Druid Rabid. Has to apply to both druid and bear
  '        Return "Attack Speed Added"
  '      Case eModifierType.RabidDurationBonus 'Lone Druid
  '        Return "Rabid Duration Time Added"
  '      Case eModifierType.RabidMoveSpeedAdded 'Lone Druid Rabid. Needs to add to both druid and bear
  '        Return "Rabid Movespeed Added"
  '      Case eModifierType.RandomTargetHealAdded 'Enchantress nature's attendants
  '        Return "Health Restored"
  '      Case eModifierType.RangeSlow
  '        Return "Right-click Ranged Attack Speed Decreased"
  '      Case eModifierType.RangeStun 'Abyssal blade
  '        Return "Stun"
  '      Case eModifierType.ReflectedDamageInflicted 'Nyx Spiked Carapace. damage component of spell. inlficted on attacker
  '        Return "Incoming Damage Inflicted to Damage Source"
  '      Case eModifierType.Reincarnate 'Aegis
  '        Return "Return To Life Where Unit Died"
  '      Case eModifierType.RemoveBuffs 'Diffusal Blade
  '        Return "Removes Buffs"
  '      Case eModifierType.RemoveDebuffs ' abaddon ulti
  '        Return "Removes Debuffs"
  '      Case eModifierType.RemoveDisables 'LC Press the attack
  '        Return "Removes Disables"
  '      Case eModifierType.ReplacedByPets 'Brew Primal Split
  '        Return "BrewMaster Splits into 3"
  '      Case eModifierType.petEarth_Brewmaster
  '        Return "Earth Spirit"
  '      Case eModifierType.petStorm_Brewmaster
  '        Return "Storm Spirit"
  '      Case eModifierType.petFire_Brewmaster
  '        Return "Fire Spirit"
  '      Case eModifierType.Replicant 'Morphling Replicate. Need to know which hero is targeted at the time
  '        Return "Replicant"
  '      Case eModifierType.RequiemDamageMagicalInflicted 'Shadow Fiend Reqiem of Souls. Damage is per line. Line count is 1 for each 2 soulds in Necromastery
  '        Return "Magic Damage Inflicted"
  '      Case eModifierType.Reset_Cooldowns 'Refresher
  '        Return "Resets Ability and Item Cooldowns"
  '      Case eModifierType.RightClickAttackAttackSlowInflicted 'Right click attack also adds an attack speed debuff to target
  '        Return "Attack Speed Reduced"
  '      Case eModifierType.RightClickAttackDamage 'Ember's Sleight of Fist, represents the damge from one instance of rightclick damage
  '        Return "Right-click Physical Damage Added"
  '      Case eModifierType.RightClickDamageFromPrimaryAtt
  '        Return "Right-click Physical Damage from Strength"
  '      Case eModifierType.RightClickBonusDamageAdded 'TB Metamorphosis
  '        Return "Right-click Bonus Physical Damage Added"
  '      Case eModifierType.RightClickBonusDamageInflicted 'Faceless Void Time Lock
  '        Return "Right Click Bonus Damage Inflicted"
  '      Case eModifierType.RightClickBonusPureDamageInflicted 'Spectre Desolate
  '        Return "Bonus Pure Damage Inflicted"
  '      Case eModifierType.RightClickCausticFinale 'Sand King Caustic Finale added
  '        Return "Cuastic Finale Damage Added"
  '      Case eModifierType.RightClickCounterAttack 'Axw counter helix, LC MomentofCOurage
  '        Return "Additional Right-click Inflicted"
  '      Case eModifierType.RightClickDamageAdded 'LC Duel
  '        Return "Right-click Physical Damage Added"
  '      Case eModifierType.RightClickDamageAsLine 'TA Psi blades. RightClick damage now emanates in line away from TA so multitargets
  '        Return "Right-click Physical Damage Inflicted"
  '      Case eModifierType.RightClickDamageAsPercOfTargetCurrHP 'lifestealer Feast
  '        Return "Right-click Physical Damage Inflicted"
  '      Case eModifierType.RightClickDamageInflicted 'Windranger Focus Fire
  '        Return "Right-click Physical Damage Inflicted"
  '      Case eModifierType.RightClickDamageInstanceAvoided 'Faceless BackTrack
  '        Return "Incoming Right-click Damage Instance Removed"
  '      Case eModifierType.RightClickDamageMultipleInflicted 'Phantom Ass, Coup de Grace
  '        Return "Right-click Physical Damage Multiple Inflicted"
  '      Case eModifierType.RightClickDamageMultiplier 'weaver germinate
  '        Return "Right Click Damage Increase"
  '      Case eModifierType.RightClickDamageoT 'Right Click attack also puts a DoT on target
  '        Return "Right Click Damage Over Time Inflicted"
  '      Case eModifierType.RightClickDamagePercentageInflicted
  '        Return "of Right-click Damage Inflicted"
  '      Case eModifierType.RightClickDamagePercentInflicted 'Phantom Lancer Spirit Lance Illusion damage
  '        Return "Right-click Physical Damage Inflicted"
  '      Case eModifierType.RightClickDamagePercentSubtracted 'SF Requiem of Souls
  '        Return "Right-click Physical Damage Decreased"
  '      Case eModifierType.RightClickDamageWithBuffs 'gyro flak cannon
  '        Return "Right-click Physical Damage Inflicted"
  '      Case eModifierType.RightClickDamageWithoutBuffs 'gyro flak cannon
  '        Return "Right-click Physical Damage Inflicted"
  '      Case eModifierType.RightClickDamPhysStackingInflicted 'Ursa furry swipes
  '        Return "Right-click Physical Damage Inflicted"
  '      Case eModifierType.RightClickHealthasDamagePercInflicted 'Ursa Enrage
  '        Return "Right-click Physical Damage Inflicted"
  '      Case eModifierType.RightClickInttoPureDamage 'Silencer Glaives of Wisdom. deals a percentage of silencer's int as pure damage
  '        Return "Pure Damage Inflicted"
  '      Case eModifierType.RightClickMoonGlaiveBounces 'Luna moon glaive
  '        Return "Right-click Damage Bounces"
  '      Case eModifierType.RightClickMoveSpeedPercSubtracted 'Meepo Geostrike
  '        Return "Movement Speed Reduced"
  '      Case eModifierType.MuteRightClick '= 84 'unable to rightclick
  '        Return "Right-click Damage Disabled"
  '      Case eModifierType.RightClickNetherToxinDamage 'Viper Nethertoxin does damage for each 20% of health missing in target
  '        Return "Right-click Physical Damage Inflicted"
  '      Case eModifierType.RightClickStun 'Faceless TimeLock
  '        Return "Stun"
  '      Case eModifierType.SanitysDamageMagicalInflictedAsMultofIntDiff 'OD Sanity's Eclipse. Damage is a multiple of the difference between OD's int and affected enemy's int. if difference is negative, then no effect
  '        Return "Magic Damage Inflicted"
  '      Case eModifierType.SanitysManaPercentRemovedwithThreshold 'OD Sanity's Eclipse. If the diff of int between OD and affected enemy is less than threshold then mana removed
  '        Return "Mana Removed"
  '      Case eModifierType.SearingArrows '= 42 'Clinkz
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString
  '      Case eModifierType.SelfDeny 'Bloodstone Pocket Suicide
  '        Return "Self Deny"
  '      Case eModifierType.ShackleTime '= 61 'http://dota2.gamepedia.com/Disable like lasso
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString
  '      Case eModifierType.ShadowPoisonStackDamage 'Shadow Demon Shadow Poison, Each staup up to 5 increases damage, after that it's 50 each addl stack
  '        Return "Magic Damage Added"
  '      Case eModifierType.ShallowGrave 'Dazzle
  '        Return "Target is Unkillable, But Still Takes Damage"
  '      Case eModifierType.Shatter 'AA IceBlast
  '        'PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return "Target Dies if below *% Health"
  '      Case eModifierType.Silence '= 76 'http://dota2.gamepedia.com/Silence
  '        Return "Ability and Item Casts Disabled"
  '      Case eModifierType.Sleep '= 66 'http://dota2.gamepedia.com/Sleep
  '        Return "Unit Stunned until Hit with Damage"
  '      Case eModifierType.SpellBlock ' Linken's blocks n spells
  '        Return "Blocks ? Incoming Spell"
  '      Case eModifierType.SpellBlockDuration ' Blocks all spells for n seconds
  '        Return "Incoming Spell Block"
  '      Case eModifierType.StaticFieldHealthReduction 'Zeus Static Field
  '        Return "Health Removed"
  '      Case eModifierType.StaticLinkBonusDamage 'Razer
  '        Return "Right-click Physical Damage Added"
  '      Case eModifierType.StaticStormDamageMagicalInflicted 'Disruptor Static Storm. Will have to call list for pulse values and calc with or without aghs
  '        Return "Magic Damage Inflicted"
  '      Case eModifierType.StationaryInvisibility 'TA Meld. Invis until TA moves
  '        Return "Invisibility until Unit Moves"
  '      Case eModifierType.StealthVisibility 'dust of appearance, sentry wards
  '        Return "Reveals Invisible Enemy Units"
  '      Case eModifierType.StrAdded '= 12
  '        Return "Strength Added"
  '      Case eModifierType.StrAddedPerKill 'pudge FleshHeap
  '        Return "Strength Added Per Kill"
  '      Case eModifierType.StrengthPercentageAsAllDamage 'Centaur stampede
  '        Return "Damage All Types Increase"
  '      Case eModifierType.StrengthPercentageCounterAttack 'Centaur Warrunner Return
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString
  '      Case eModifierType.StroT '= 14
  '        Return "Strength Added Over Time"
  '        'Case eModifierType.StrPercent '= 13
  '        '  Return "Strength Increase"
  '      Case eModifierType.StrSubtracted 'Slark Essence Shift
  '        Return "Strength Removed"
  '      Case eModifierType.Stun '= 60 'http://dota2.gamepedia.com/Stun 'Does NOT include MiniStuns
  '        Return "Stun"
  '      Case eModifierType.StunChain 'Witch doc Paralyzing Cask
  '        Return "Stun Instances"
  '      Case eModifierType.StunRandom 'ChaosKnight Chaos Bolt
  '        Return "Random Stun"
  '      Case eModifierType.Sunder 'TB Sunder. Swaps health with target
  '        Return "Health Restored"
  '      Case eModifierType.MuteTargetability '= 85 'unable to be targetted
  '        Return "Abilities Disabled"
  '      Case eModifierType.TargetedDamageReflected 'nyx Spiked Carapace. Only reflects damage targetted directly at nyx
  '        Return "Incoming Damage Reflected and Inflicted to Damage Source"
  '      Case eModifierType.MuteAllOnTarget 'stops eveything on target (items, move, abilities, etc.) Bane Nightmare
  '        Return "Abilities, Items, Movement and Right-click Disabled"
  '      Case eModifierType.TargetsCurrentHealthAsDamageMagicalInfliced 'Huskar Life Break Damage Dealt
  '        Return "Magic Damage Inflicted"
  '      Case eModifierType.Taunt '= 65 'http://dota2.gamepedia.com/Taunt
  '        Return "Forces Target to Attack Caster"
  '      Case eModifierType.Teleport '= 78
  '        Return "Teleport"
  '      Case eModifierType.MuteTeleport 'Blink (Queen of Pain) , Blink, Teleportation, Charge of Darkness, Phase Shift and Blink Dagger.
  '        Return "Teleport Disabled"
  '      Case eModifierType.TeleportRandom 'Chaosknight Reality Rift
  '        Return "Teleport"
  '      Case eModifierType.TimeLapse 'weaver ulti
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString
  '      Case eModifierType.TinyTossBonusDamage 'Tiny Grow
  '        Return "Bonus Damage Added to Toss"
  '      Case eModifierType.TinyTossDamageInflicted 'seperate type to enable check for TinyTossBonusDamage
  '        Return "Magic Damage Inflicted"
  '      Case eModifierType.Traptime '= 64 'http://dota2.gamepedia.com/Trap clockwork cogs
  '        Return "Trap"
  '      Case eModifierType.TrueFormHPAdded 'Lone Druid 
  '        Return "Health Added"
  '      Case eModifierType.Truesight '= 39 'http://dota2.gamepedia.com/Invisibility
  '        Return "TrueSight"
  '      Case eModifierType.TruesightofTarget 'bounty hunter track
  '        Return "TrueSight of Target"
  '      Case eModifierType.MuteTurn '= 83 'unable to turn
  '        Return "Turning Disabled"
  '      Case eModifierType.TurnRateSubtracted 'Batrider Sticky Napalm
  '        Return "Turn Rate Added"
  '      Case eModifierType.UnobstructedMovementandVision 'batrider firefly
  '        Return "Unobstructed Movement & Vision"
  '      Case eModifierType.UnobstructedVision 'Nightstalker Darkness
  '        Return "Unobstructed Vision"
  '      Case eModifierType.VanguardMeleeBlockAdded 'block dependant on whether you are melee or ranged
  '        Return "Damage Block Added"
  '      Case eModifierType.VanguardRangeblockAdded 'Vanguard:
  '        Return "Damage Block Added"
  '      Case eModifierType.Vision 'observerward
  '        Return "Vision Added"
  '      Case eModifierType.VisionDay 'beast hawk
  '        Return "Vision Added"
  '      Case eModifierType.VisionNight 'beast hawk
  '        Return "Vision Added"
  '      Case eModifierType.VisionNightAdded 'Lycan Shapeshift
  '        Return "Vision Added"
  '      Case eModifierType.VoidMoveSpeedPercentSubtracted 'Nightstalker void. Duration changes depending on day or night
  '        Return "Movement Speed Decreased"
  '      Case eModifierType.WallHeroReplica 'Dark Seer Wall of Replica
  '        Return "Replica Wall"
  '      Case eModifierType.Web 'Broodmother Spin Web
  '        Return "Web"
  '      Case eModifierType.WitchcraftCooldownDecrease
  '        Return "Witchcraft Cooldown Decrease"
  '      Case eModifierType.WitchcraftManaCostDecrease 'DP Witchcraft
  '        Return "Witchcraft Mana Cost Decrease"
  '      Case eModifierType.WitchcraftSpiritIncrease
  '        Return "Additional Witchcraft Spirits"
  '      Case eModifierType.WrathofNatureMagicDamageBounceInflicted 'Nature's Proph damage increases with each bounce
  '        Return "Magic Damage Bounces"
  '      Case eModifierType.XPAdded 'Lich Sacrifice
  '        Return "XP Added"
  '      Case eModifierType.ZombiesPerUnit 'Undying Tombstone Zombies
  '        Return "Zombies Per Unit"
  '      Case eModifierType.IntIncrementAdded
  '        Return "Intelligence Level Increment"
  '      Case eModifierType.AgiIncrementAdded
  '        Return "Agility Level Increment"
  '      Case eModifierType.StrIncrementAdded
  '        Return "Strength Level Increment"

  '      Case Else
  '        PageHandler.theLog.writelog(themodtype.ToString & " not implemented in helpers.getgriendlymodifiername")
  '        Return themodtype.ToString
  '    End Select

  '  End Function
  '  Public Shared Function GetFriendlyDamageType( thedam As eDamageType) As String
  '    Select Case thedam
  '      'Case eDamageType.Composite
  '      '  Return "Composite"
  '      'Case eDamageType.HPRemoval
  '      '  Return "HP Removal"
  '      Case eDamageType.Magical
  '        Return "Magical"
  '      Case eDamageType.None
  '        Return "None"
  '      Case eDamageType.Physical
  '        Return "Physical"
  '      Case eDamageType.Pure
  '        Return "Pure"
  '        'Case eDamageType.Universal
  '        '  Return "Universal"
  '      Case Else
  '        PageHandler.theLog.writelog(thedam.ToString & " not implemented in helpers.getfriendlydamagetype")
  '        Return thedam.ToString
  '    End Select
  '  End Function
  '  Public Shared Function GetFriendlyAbilityType( thetype As eAbilityType) As String
  '    Select Case thetype
  '      Case eAbilityType.ActiveAura
  '        Return "Active Aura"
  '      Case eAbilityType.AutoCast
  '        Return "Autocast"
  '      Case eAbilityType.Channeled
  '        Return "Channeled"
  '      Case eAbilityType.PointTargetCone
  '        Return "Cone"
  '      Case eAbilityType.PointTargetLine
  '        Return "Line"
  '      Case eAbilityType.MapWideAura
  '        Return "Global"
  '      Case eAbilityType.NoTarget
  '        Return "No Target"
  '      Case eAbilityType.Passive
  '        Return "Passive"
  '      Case eAbilityType.PassiveAura
  '        Return "Passive Aura"
  '      Case eAbilityType.PointTarget
  '        Return "Ground Point Target"
  '      Case eAbilityType.PointTargetAura
  '        Return "Ground Point Target Aura"
  '      Case eAbilityType.Stats
  '        Return "Stat Buff"
  '      Case eAbilityType.Toggle
  '        Return "Toggle"
  '      Case eAbilityType.Trail
  '        Return "Trail"
  '      Case eAbilityType.UnitTarget
  '        Return "Unit Target"
  '      Case Else
  '        PageHandler.theLog.writelog(thetype.ToString & " not implented in helpers.getfriendlyabilitytype")
  '        Return thetype.ToString
  '    End Select

  '  End Function

  '  Public Shared Function GetFriendlyNameforEItemPlan( theplan As eItemPlan) As String
  '    Select Case theplan
  '      Case eItemPlan.UseAtOnce
  '        Return "Use at Once"
  '      Case eItemPlan.Disassemble
  '        Return "Split for Parts"
  '      Case eItemPlan.KeepForever
  '        Return "Keep or Combine"
  '      Case eItemPlan.SellAtOnce
  '        Return "Sell at Once"
  '      Case eItemPlan.SellForSpace
  '        Return "Sell for Space"
  '      Case eItemPlan.UseFor1Level
  '        Return "Keep 1 Level"
  '      Case eItemPlan.UseFor2Levels
  '        Return "Keep 2 Levels"
  '      Case eItemPlan.UseFor3Levels
  '        Return "Keep 3 Levels"
  '      Case eItemPlan.UseFor4Levels
  '        Return "Keep 4 Levels"
  '      Case eItemPlan.UseFor5Levels
  '        Return "Keep 5 Levels"
  '      Case Else
  '        Dim x = 2
  '        Return "oops"
  '    End Select
  '  End Function
  '  Public Shared Function GetFriendlyUnitName( theunit As eUnit) As String
  '    Select Case theunit
  '      Case eUnit.untSelf
  '        Return "Self"
  '      Case eUnit.untAlliedHero
  '        Return "Allied Hero"
  '      Case eUnit.untAlliedHeroes
  '        Return "Allied Heroes"
  '      Case eUnit.untAlliedUnit, eUnit.untAlly
  '        Return "Allied Hero or Creep"
  '      Case eUnit.untAlliedUnits
  '        Return "Allied Heroes and Creeps"
  '      Case eUnit.untAlliedMeleeUnits
  '        Return "Melee Ally"
  '      Case eUnit.untAlliedNonHeroUnits
  '        Return "Non-Hero Ally"
  '      Case eUnit.untAlliedRangeUnits
  '        Return "Ranged Ally"
  '      Case eUnit.untAlliedStructure
  '        Return "Allied Structure"


  '      Case eUnit.untHeroes
  '        Return "Allied and Enemy Heroes"

  '      Case eUnit.untEnemyTarget
  '        Return "Targetted Enemy"
  '      Case eUnit.unitTargettedEnemyCreep
  '        Return "Targetted Enemy Creep"
  '      Case eUnit.untEnemyUnit
  '        Return "Enemy Unit"
  '      Case eUnit.untEnemyUnits
  '        Return "Enemies"
  '      Case eUnit.untEnemyCreeps
  '        Return "Enemy Creeps"
  '      Case eUnit.untEnemyCreep
  '        Return "Enemy Creep"
  '      Case eUnit.untEnemyHero
  '        Return "EnemyHero"
  '      Case eUnit.untEnemyHeroes
  '        Return "Enemy Heroes"
  '      Case eUnit.untAttackingEnemyUnit
  '        Return "Attacking Enemy"
  '      Case eUnit.untEnemieTeam
  '        Return "Enemy Team"
  '      Case eUnit.untEnemyHeroNearest
  '        Return "Nearest Enemy Hero"
  '      Case eUnit.untEnemyMeleeTarget
  '        Return "Targetted Enemy Melee Unit"
  '      Case eUnit.untEnemyRangedTarget
  '        Return "Targetted Enemy Ranged Unit"
  '      Case eUnit.untEnemyStealthUnits
  '        Return "Invisible Enemy Units"
  '      Case eUnit.untEnemyStructure
  '        Return "Enemy Structure"
  '      Case eUnit.untEnemySummonedUnit
  '        Return "Summoned Enemy Unit"
  '        'Case eUnit.untRandomEnemyUnit
  '        '  Return "Random Enemy"
  '      Case eUnit.untEnemyUnitsNotTargetted
  '        Return "Untargetted Enemies"
  '      Case eUnit.untEnemyUnitwLowestHealth
  '        Return "Enemy with Lowest Health"

  '      Case Else
  '        PageHandler.theLog.writelog("GetFriendlyUnitName." & theunit.ToString & " not implemented in helpers.getfriendlyunitname")
  '        Return theunit.ToString
  '    End Select
  '  End Function

  '#End Region
  Public Shared Function AddModstoMods(modlist1 As ModifierList, modlist2 As ModifierList) As ModifierList

    For i As Integer = 0 To modlist2.Count - 1
      modlist1.Add(modlist2.Item(i))
    Next
    Return modlist1
  End Function



  Public Shared Function AddlisttoList(Of t)(list1 As List(Of t), list2 As List(Of t)) As List(Of t)
    Dim outlist = list1
    For i As Integer = 0 To list2.Count - 1
      Dim curitem = list2.Item(i)
      If Not outlist.Contains(curitem) Then outlist.Add(curitem)
    Next
    Return outlist
  End Function

  Public Shared Function AddDicttoDict(Of T, T2)(dict1 As Dictionary(Of T, T2), dict2 As Dictionary(Of T, T2)) As Dictionary(Of T, List(Of T2))

    Dim outdict As New Dictionary(Of T, List(Of T2))

    For Each kv As KeyValuePair(Of T, T2) In dict1
      Dim outlist As New List(Of T2)
      outlist.Add(kv.Value)
      outdict.Add(kv.Key, outlist)
    Next

    For Each kv As KeyValuePair(Of T, T2) In dict2
      If outdict.ContainsKey(kv.Key) Then
        Dim curlist = outdict.Item(kv.Key)
        If Not curlist.Contains(kv.Value) Then
          curlist.Add(kv.Value)
        End If


      End If


    Next
    Return outdict
  End Function

  'Select Case theabs.Count - 1
  '  Case 4
  '    Dim outhero As New Hero(thehero.mBuild.mUniqueName, thehero.mBundle, thehero.mBuild, _
  '                            theabs.Item(1).mName, theabs.Item(2).mName, _
  '                            theabs.Item(3).mName, theabs.Item(4).mName)
  '  Case 5
  '    Dim outhero As New Hero(thehero.mBuild.mUniqueName, thehero.mBundle, thehero.mBuild, _
  '                            theabs.Item(1).mName, theabs.Item(2).mName, _
  '                            theabs.Item(3).mName, theabs.Item(4).mName, _
  '                            theabs.Item(5).mName)
  '  Case 6
  '    Dim outhero As New Hero(thehero.mBuild.mUniqueName, thehero.mBundle, thehero.mBuild, _
  '                            theabs.Item(1).mName, theabs.Item(2).mName, _
  '                            theabs.Item(3).mName, theabs.Item(4).mName, _
  '                            theabs.Item(5).mName, theabs.Item(6).mName)

  '  Case 7
  '    Dim outhero As New Hero(thehero.mBuild.mUniqueName, thehero.mBundle, thehero.mBuild, _
  '                            theabs.Item(1).mName, theabs.Item(2).mName, _
  '                            theabs.Item(3).mName, theabs.Item(4).mName, _
  '                            theabs.Item(5).mName, theabs.Item(6).mName, _
  '                            theabs.Item(7).mName)
  '  Case 8
  '    Dim outhero As New Hero(thehero.mBuild.mUniqueName, thehero.mBundle, thehero.mBuild, _
  '                     theabs.Item(1).mName, theabs.Item(2).mName, _
  '                     theabs.Item(3).mName, theabs.Item(4).mName, _
  '                     theabs.Item(5).mName, theabs.Item(6).mName, _
  '                     theabs.Item(7).mName, theabs.Item(8).mName)

  '  Case 9
  '    Dim outhero As New Hero(thehero.mBuild.mUniqueName, thehero.mBundle, thehero.mBuild, _
  '                     theabs.Item(1).mName, theabs.Item(2).mName, _
  '                     theabs.Item(3).mName, theabs.Item(4).mName, _
  '                     theabs.Item(5).mName, theabs.Item(6).mName, _
  '                     theabs.Item(7).mName, theabs.Item(8).mName, _
  '                     theabs.Item(9).mName)

  '  Case 10
  '    Dim outhero As New Hero(thehero.mBuild.mUniqueName, thehero.mBundle, thehero.mBuild, _
  '                     theabs.Item(1).mName, theabs.Item(2).mName, _
  '                     theabs.Item(3).mName, theabs.Item(4).mName, _
  '                     theabs.Item(5).mName, theabs.Item(6).mName, _
  '                     theabs.Item(7).mName, theabs.Item(8).mName, _
  '                     theabs.Item(9).mName, theabs.Item(10).mName)
  '  Case 13
  '    Dim outhero As New Hero(thehero.mBuild.mUniqueName, thehero.mBundle, thehero.mBuild, _
  '             theabs.Item(1).mName, theabs.Item(2).mName, _
  '             theabs.Item(3).mName, theabs.Item(4).mName, _
  '             theabs.Item(5).mName, theabs.Item(6).mName, _
  '             theabs.Item(7).mName, theabs.Item(8).mName, _
  '             theabs.Item(9).mName, theabs.Item(10).mName, _
  '             theabs.Item(11).mName, theabs.Item(12).mName, _
  '             theabs.Item(13).mName)

  '  Case Else
  '    Dim x = 2
  'End Select


  Public Shared Function ConcatStrings(thedubs As List(Of Double), theseperator As String) As String
    Dim outstring = ""
    For i As Integer = 0 To thedubs.Count - 1
      outstring += thedubs(i) & theseperator.Trim & " "
    Next
    Return outstring
  End Function

  Public Shared Function ConcatStrings(thetypes As List(Of eAbilityType), theseperator As String) As String
    Dim outstring = ""
    For i As Integer = 0 To thetypes.Count - 1
      outstring += thetypes(i).ToString & theseperator.Trim & " "
    Next
    Return outstring
  End Function
  Public Shared Function ConcatStrings(theaffects As List(Of eUnit), theseperator As String) As String
    Dim outstring = ""
    For i As Integer = 0 To theaffects.Count - 1
      outstring += theaffects(i).ToString & theseperator.Trim & " "
    Next
    Return outstring
  End Function

  Public Shared Function ConcatStrings(theroles As List(Of eRole), theseperator As String) As String
    Dim outstring = ""
    For i As Integer = 0 To theroles.Count - 1
      outstring += theroles(i).ToString & theseperator.Trim & " "
    Next
    Return outstring
  End Function

  Public Shared Function ConcatStrings(thedamagetypes As List(Of eDamageType), theseperator As String) As String
    Dim outstring = ""
    For i As Integer = 0 To thedamagetypes.Count - 1
      outstring += thedamagetypes(i).ToString & theseperator.Trim & " "
    Next
    Return outstring
  End Function
  Public Shared Function ConvertStringToNumber(thestring As String) As Double
    Try
      'Logging.writeLog("ConvertStringToNumber: " + thestring)
      'Logging.writeLog("ScrapeWizard|ConvertStringToNymber: " + thestring)

      thestring = thestring.Replace(",", "")
      thestring = thestring.Trim(".")
      Dim newstring As String = thestring

      Dim newnumstring As String = ""
      For i As Integer = 0 To thestring.Length - 1
        If ContainsANumber(thestring.Substring(i, 1)) Or thestring.Substring(i, 1) = "." _
            Or thestring.Substring(i, 1) = "-" Then
          newnumstring = newnumstring + thestring.Substring(i, 1)
        End If
      Next
      Dim thedouble As Double
      If Not newnumstring = "" And newnumstring.Length < 10 And newnumstring.Length >= 1 Then
        If Not CountCharacter(newnumstring, ".") > 1 Then
          thedouble = newnumstring
        Else
          thedouble = -1
        End If

      Else
        thedouble = -1
      End If

      'fview.AddItem("Singlereturned", thesingle)
      Return thedouble
    Catch ex As Exception
      ' Logging.LogError("ConvertStringToNumber", ex.Message)
      Return Nothing
    End Try

  End Function

  Public Shared Function StringArrayToList(stringarray As String()) As List(Of String)
    Dim outlist As New List(Of String)
    For i As Integer = 0 To stringarray.Count - 1
      outlist.Add(stringarray(i))
    Next
    Return outlist

  End Function
  Public Shared Function SingleArrayToList(Singlearray As Single()) As List(Of Single)
    Dim outlist As New List(Of Single)
    For i As Integer = 0 To Singlearray.Count - 1
      outlist.Add(Singlearray(i))
    Next
    Return outlist

  End Function
  Public Shared Function ConvertStringstoPercents(thestrings As String()) As List(Of Double)
    Dim thelist = ConvertStringsToNumber(thestrings)
    Dim outlist As New List(Of Double)
    For i As Integer = 0 To thelist.Count - 1
      outlist.Add(thelist.Item(i) * 0.01)
    Next

    Return outlist
  End Function

  Public Shared Sub WriteStream(thestrings As List(Of String), thefilename As String, append As Boolean)

    Dim sw As StreamWriter
    If Not File.Exists(thefilename) And append Then

      sw = New StreamWriter(thefilename, True)
    Else
      sw = New StreamWriter(thefilename)
    End If

    For i As Integer = 0 To thestrings.Count - 1
      sw.WriteLine(thestrings.Item(i))
    Next
    sw.Close()

  End Sub
  Public Shared Sub WriteStream(thestrings As Dictionary(Of String, String), thefilename As String, append As Boolean)

    Dim sw As StreamWriter
    If Not File.Exists(thefilename) And append Then

      sw = New StreamWriter(thefilename, True)
    Else
      sw = New StreamWriter(thefilename)
    End If

    For Each item As KeyValuePair(Of String, String) In thestrings
      sw.WriteLine(item.Value)
    Next
    sw.Close()

  End Sub
  Public Shared Function ParseStringsHeroRoles(thestrings() As String) As List(Of eRole)
    Dim theroles As New List(Of eRole)
    For i As Integer = 0 To thestrings.Count - 1
      Select Case True
        Case thestrings(i).Contains("Initiator")
          theroles.Add(eRole.Initiator)
        Case thestrings(i).Contains("Disabler")
          theroles.Add(eRole.Disabler)


        Case thestrings(i).Contains("Lane Support")
          theroles.Add(eRole.LaneSupport)
        Case thestrings(i).Contains("Support")
          theroles.Add(eRole.Support)
        Case thestrings(i).Contains("Carry")
          theroles.Add(eRole.Carry)
        Case thestrings(i).Contains("Nuker")
          theroles.Add(eRole.Nuker)
        Case thestrings(i).Contains("Durable")
          theroles.Add(eRole.Durable)
        Case thestrings(i).Contains("Escape")
          theroles.Add(eRole.Escape)
        Case thestrings(i).Contains("Pusher")
          theroles.Add(eRole.Pusher)
        Case thestrings(i).Contains("Jungler")
          theroles.Add(eRole.Jungler)
        Case thestrings(i).Contains("Melee")

        Case thestrings(i).Contains("Ranged")

        Case Else
          MessageBox.Show("New Role: " & thestrings(i))

      End Select

    Next
    Return theroles
  End Function


  Public Shared Function ParseStringToAbilityTypes(thestring As String, thedelimiter As Char) As List(Of eAbilityType)
    Dim theabilitytypes As New List(Of eAbilityType)
    Dim thestrings = thestring.Split("|")
    For i As Integer = 0 To thestrings.Count - 1
      Select Case True
        Case thestrings(i).Contains("UnitTarget")
          theabilitytypes.Add(eAbilityType.UnitTarget)
        Case thestrings(i).Contains("PointTarget")
          theabilitytypes.Add(eAbilityType.PointTarget)
        Case thestrings(i).Contains("Passive")
          theabilitytypes.Add(eAbilityType.Passive)
        Case thestrings(i).Contains("Aura")
          theabilitytypes.Add(eAbilityType.PassiveAura)
        Case thestrings(i).Contains("AutoCast")
          theabilitytypes.Add(eAbilityType.AutoCast)
        Case thestrings(i).Contains("NoTarget")
          theabilitytypes.Add(eAbilityType.NoTarget)
        Case thestrings(i).Contains("Channeled")
          theabilitytypes.Add(eAbilityType.Channeled)
        Case Else
          Dim x = 2
      End Select

    Next
    Return theabilitytypes
  End Function

  'Public Shared Function GetColorFromImageCenter( theimage As System.Windows.Controls.Image) As SolidColorBrush

  '  ' Dim bi As BitmapImage = theimage.Source

  '  '  Dim fu As New BitmapImage()

  '  '  AddHandler fu.ImageFailed, AddressOf fu_Imagefailed
  '  '  fu = New BitmapImage(New Uri("http://cdn.dota2.com/apps/dota2/images/heroes/earthshaker_vert.jpg", UriKind.Absolute))  With { _
  '  '.pixelWidth = 200, _
  '  '.Height = 25 _
  '  Dim fu As New BitmapImage
  '  fu.CreateOptions = BitmapCreateOptions.None
  '  AddHandler fu.ImageOpened, AddressOf fu_imageopened
  '  fu.UriSource = New Uri("http://cdn.dota2.com/apps/dota2/images/heroes/earthshaker_vert.jpg", UriKind.Absolute)


  '  Dim fu2 As New BitmapImage()

  '  'fu2.be()
  '  ' Dim wbmp As New WriteableBitmap(bi)

  '  'Dim pixels = wbmp.Pixels

  '  'Dim outpixel = pixels(pixels.Count / 2)

  '  '' Dim thebytes() = BitConverter.GetBytes(outpixel)


  '  '' bi.UriSource = New Uri(

  '  'Return New SolidColorBrush(Color.FromArgb(thebytes(0), thebytes(1), thebytes(2), thebytes(3)))

  'End Function
  Public Shared Function ParseStringToAffects(thestring As String, thedelimiter As Char) As List(Of eUnit)
    Dim theaffects As New List(Of eUnit)
    Dim thestrings = thestring.Split("|")
    For i As Integer = 0 To thestrings.Count - 1
      Select Case True
        Case thestrings(i).Contains("EnemyUnits")
          theaffects.Add(eUnit.untEnemyUnits)
        Case thestrings(i).Contains("UnitTarget")
          theaffects.Add(eUnit.untUnitTarget)
        Case thestrings(i).Contains("PointTarget")
          theaffects.Add(eUnit.untPointTarget)
        Case thestrings(i).Contains("Passive")
          theaffects.Add(eUnit.untPassive)
        Case thestrings(i).Contains("Aura")
          theaffects.Add(eUnit.untAura)
        Case thestrings(i).Contains("AutoCast")
          theaffects.Add(eUnit.untAutoCast)
        Case thestrings(i).Contains("Channeled")
          theaffects.Add(eUnit.untChanneled)
        Case thestrings(i).Contains("NoTarget")
          theaffects.Add(eUnit.untNoTarget)
        Case thestrings(i).Contains("Toggle")
          theaffects.Add(eUnit.untToggle)
        Case thestrings(i).Contains("Heroes")
          theaffects.Add(eUnit.untHeroes)
        Case thestrings(i).Contains("Allies")
          theaffects.Add(eUnit.untAlliedHeroes)
        Case thestrings(i).Contains("AlliedUnits")
          theaffects.Add(eUnit.untAlliedUnits)
        Case thestrings(i).Contains("AlliedUnits")
          theaffects.Add(eUnit.untAlliedUnits)
        Case thestrings(i).Contains("Enemies")
          theaffects.Add(eUnit.untEnemieTeam)
        Case thestrings(i).Contains("EnemyCreeps")
          theaffects.Add(eUnit.untEnemyCreeps)
        Case thestrings(i).Contains("Units")
          theaffects.Add(eUnit.untUnits)
        Case Else
          Dim x = 2
      End Select

    Next
    Return theaffects
  End Function

  Public Shared Function ParseStringToDamageTypes(thestring As String, thedelimiter As Char) As List(Of eDamageType)
    Dim thedamagetypes As New List(Of eDamageType)
    Dim thestrings = thestring.Split("|")
    For i As Integer = 0 To thestrings.Count - 1
      Select Case True
        Case thestrings(i).Contains("Physical")
          thedamagetypes.Add(eDamageType.Physical)
        Case thestrings(i).Contains("Magical")
          thedamagetypes.Add(eDamageType.Magical)
          'Case thestrings(i).Contains("Composite")
          '  thedamagetypes.Add(eDamageType.Composite)
        Case thestrings(i).Contains("Pure")
          thedamagetypes.Add(eDamageType.Pure)
          'Case thestrings(i).Contains("HPRemoval")
          '  thedamagetypes.Add(eDamageType.HPRemoval)
          'Case thestrings(i).Contains("Universal")
          '  thedamagetypes.Add(eDamageType.Universal)
        Case Else
          Dim x = 2
      End Select

    Next
    Return thedamagetypes
  End Function
  Public Shared Function ParseStringToSingles(thestring As String, thedelimiter As Char) As List(Of Single)
    Dim thesings = thestring.Split(thedelimiter)
    Dim outlist As New List(Of Single)
    For i As Integer = 0 To thesings.Count - 1
      outlist.Add(Convert.ToSingle(thesings(i)))
    Next
    Return outlist
  End Function
  Public Shared Function ScrubString(thestring As String) As String
    'thestring = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(thestring.ToLower())
    thestring = thestring.Trim()
    thestring = thestring.Trim(ChrW(&H9))
    thestring = thestring.Trim(ChrW(&HA))
    thestring = thestring.Trim(ChrW(&HB))
    thestring = thestring.Trim(ChrW(&HC))
    thestring = thestring.Trim(ChrW(&HD))
    thestring = thestring.Trim(ChrW(&H20))
    thestring = thestring.Trim(ChrW(&HA0))
    thestring = thestring.Trim(ChrW(&H2000))
    thestring = thestring.Trim(ChrW(&H2001))
    thestring = thestring.Trim(ChrW(&H2002))
    thestring = thestring.Trim(ChrW(&H2003))
    thestring = thestring.Trim(ChrW(&H2004))
    thestring = thestring.Trim(ChrW(&H2005))
    thestring = thestring.Trim(ChrW(&H2006))
    thestring = thestring.Trim(ChrW(&H2007))
    thestring = thestring.Trim(ChrW(&H2008))
    thestring = thestring.Trim(ChrW(&H2009))
    thestring = thestring.Trim(ChrW(&H200A))
    thestring = thestring.Trim(ChrW(&H200B))
    thestring = thestring.Trim(ChrW(&H3000))
    thestring = thestring.Trim(ChrW(&HFEFF))
    thestring = thestring.Trim("\r")
    thestring = thestring.Trim("\n")
    thestring = thestring.Trim(" ")
    thestring = thestring.Replace(vbCrLf, "")
    thestring = thestring.Replace(vbCr, "")
    thestring = thestring.Replace("(", "_")
    thestring = thestring.Replace(")", "_")
    thestring = thestring.Replace("\", "_")
    thestring = thestring.Replace("/", "_")
    thestring = thestring.Replace(" ", "_")

    Return thestring
  End Function
  Public Shared Function RemoveNumbers(thestring As String) As String
    thestring = thestring.Replace("1", "")
    thestring = thestring.Replace("2", "")
    thestring = thestring.Replace("3", "")
    thestring = thestring.Replace("4", "")
    thestring = thestring.Replace("5", "")
    thestring = thestring.Replace("6", "")
    thestring = thestring.Replace("7", "")
    thestring = thestring.Replace("8", "")
    thestring = thestring.Replace("9", "")
    thestring = thestring.Replace("0", "")

    Return thestring
  End Function
  Public Shared Function ConvertStringsToNumber(thestrings As String()) As List(Of Double)
    Dim outlist As New List(Of Double)
    For i As Integer = 0 To thestrings.Count - 1
      Dim thenum As Double = Helpers.ConvertStringToNumber(thestrings(i))

      If Helpers.ContainsANumber(thenum) Then
        outlist.Add(thenum)
      End If
    Next

    Return outlist
  End Function

  'Public Shared Function GetIDFromDDObject(gameentity As igameentity)
  '  Select Case theobj.type
  '    Case eEntity.Game
  '      Dim g As dGame = theobj.obj
  '      Return g.Id
  '    Case eEntity.Team
  '      Dim t As dTeam = theobj.obj
  '      Return t.ID
  '    Case eEntity.Hero_Instance
  '      Dim hb As HeroInstance = theobj.obj
  '      Return hb.Id
  '    Case eEntity.Creep_Info
  '      Dim ci As Creep_Info = theobj.obj
  '      Return ci.ID
  '    Case eEntity.Ability_Info
  '      Dim ai As Ability_Info = theobj.obj
  '      Return ai.Id
  '    Case eEntity.Item_Info
  '      Dim ii As Item_Info = theobj.obj
  '      Return ii.Id
  '    Case eEntity.ctrlHero_Badge
  '      Dim hb As ctrlHero_Badge = theobj.obj
  '      Return hb.mHeroInstState.Id
  '    Case eEntity.ctrlCreep_Badge
  '      Dim cp As ctrlCreep_Badge = theobj.obj
  '      Return cp.mCreep.Id


  '    Case Else
  '      Dim x = 2
  '      PageHandler.theLog.WriteLog("Helpers.GetIDFromDDObject passed unhandled type: " & theobj.type.ToString)
  '      Throw New NotImplementedException
  '  End Select
  'End Function
  Public Shared Function ConvertStringToNumbers(thestring As String) As List(Of Double)
    'Fix For multiple numbers seperated in a string
    Try
      thestring = thestring.Replace(",", "")
      Dim outnums As New List(Of Double)
      Dim inanumber = False
      Dim curnumstring As String = ""
      For i As Integer = 0 To thestring.Length - 1
        If ContainsANumber(thestring.Substring(i, 1)) Then
          inanumber = True
          curnumstring = curnumstring & thestring.Substring(i, 1)
          If curnumstring = "0" Then
            Dim x = 2
          End If
        Else
          If inanumber Then
            outnums.Add(ConvertStringToNumber(curnumstring))
            curnumstring = ""
            inanumber = False

          End If
        End If


      Next
      Return outnums


    Catch ex As Exception

      Return Nothing
    End Try

  End Function

  Public Shared Function ContainsANumber(thestring As String) As Boolean
    Select Case True
      Case thestring.Contains("1")
        Return True
      Case thestring.Contains("2")
        Return True
      Case thestring.Contains("3")
        Return True
      Case thestring.Contains("4")
        Return True
      Case thestring.Contains("5")
        Return True
      Case thestring.Contains("6")
        Return True
      Case thestring.Contains("7")
        Return True
      Case thestring.Contains("8")
        Return True
      Case thestring.Contains("9")
        Return True
      Case thestring.Contains("0")
        Return True
      Case Else
        Return False
    End Select
  End Function

  Public Shared Function GetDecimalNumbersFromString(thestring As String) As List(Of Double)
    If thestring Is Nothing Then Return Nothing
    thestring = thestring.Replace(",", "")
    Dim currnum As String = ""
    Dim inanumber As Boolean = False
    Dim outnums As New List(Of Double)
    For i As Integer = 0 To thestring.Length - 1
      Dim thechar As String = thestring.Substring(i, 1)
      If Char.IsDigit(thechar) Xor thechar = "." Then
        inanumber = True
        currnum = currnum + thestring.Substring(i, 1)
      ElseIf inanumber Then
        inanumber = False
        If currnum.Contains(".") And currnum.Length > 1 Then
          Dim thenum = CastStringToDouble(currnum)
          If Not thenum = 0 Then
            outnums.Add(CastStringToDouble(currnum))
          End If

        End If

        currnum = ""
      Else
        inanumber = False

      End If
    Next

    If currnum.Contains(".") And currnum.Length > 1 Then
      Dim thenum = CastStringToDouble(currnum)
      If Not thenum = 0 Then
        outnums.Add(CastStringToDouble(currnum))
      End If
    End If

    Return outnums
  End Function

  Public Shared Function CastStringToDouble(thestring As String) As Double
    Try
      ' Logging.writeLog("ScrapeWizard|CastStringToInteger: " + thestring)
      Dim thei As Double
      If Single.TryParse(thestring, thei) Then
        Return thei
      Else
        Return Nothing
      End If
    Catch ex As Exception
      ' Logging.LogError("CastStringToInteger", ex.Message)
      Return Nothing
    End Try


  End Function
  Public Shared Function CountCharacter(value As String, ch As Char) As Integer
    Try
      ' Logging.writeLog("ScrapeWizard|CountCharacter: " + value + " ch: " + ch.ToString)
      'Logging.writeLog("CountCharacter")
      Dim cnt As Integer = 0
      For Each c As Char In value
        If c = ch Then cnt += 1
      Next
      Return cnt
    Catch ex As Exception
      'Logging.LogError("CountCharavter", ex.Message)
      Return Nothing
    End Try

  End Function

  Public Shared Function ParseSinglesToString(theSingles As List(Of Single), thedelimiter As Char) As String
    Dim outstring As String = ""
    For i As Integer = 0 To theSingles.Count - 1
      If i < theSingles.Count - 1 Then
        outstring += Convert.ToString(theSingles.Item(i)) & thedelimiter.ToString
      Else
        outstring += Convert.ToString(theSingles.Item(i))
      End If
    Next

    Return outstring
  End Function

  Public Shared Function ParseAbilityTypesToString(theabs As List(Of eAbilityType), thedelimiter As Char) As String
    Dim outstring As String = ""
    For i As Integer = 0 To theabs.Count - 1
      Dim thename = [Enum].GetName(GetType(eAbilityType), theabs.Item(i))
      If i < theabs.Count - 1 Then
        outstring += thename & thedelimiter.ToString
      Else
        outstring += thename
      End If
    Next

    Return outstring
  End Function

  Public Shared Function ParseAffectsToString(theaffs As List(Of eUnit), thedelimiter As Char) As String
    Dim outstring As String = ""
    For i As Integer = 0 To theaffs.Count - 1
      Dim thename = [Enum].GetName(GetType(eUnit), theaffs.Item(i))
      If i < theaffs.Count - 1 Then
        outstring += thename & thedelimiter.ToString
      Else
        outstring += thename
      End If
    Next

    Return outstring
  End Function

  Public Shared Function ParseDamageTypesToString(thedams As List(Of eDamageType), thedelimiter As Char) As String
    Dim outstring As String = ""
    For i As Integer = 0 To thedams.Count - 1
      Dim thename = [Enum].GetName(GetType(eDamageType), thedams.Item(i))
      If i < thedams.Count - 1 Then
        outstring += thename & thedelimiter.ToString
      Else
        outstring += thename
      End If
    Next

    Return outstring
  End Function

  'Public Shared Function ParseObjectsToString( theobs As List(Of Object),  thedelimiter As Char) As String
  '  Dim outstring As String = ""
  '  For i As Integer = 0 To theobs.Count - 1
  '    If i < theobs.Count - 1 Then
  '      outstring += Convert.ToString(theobs.Item(i)) & thedelimiter.ToString
  '    Else
  '      outstring += Convert.ToString(theobs.Item(i))
  '    End If
  '  Next

  '  Return outstring
  'End Function

  Public Shared Function ParseRolesToString(theroles As List(Of eRole), thedelimiter As Char) As String
    Dim outstring As String = ""
    For i As Integer = 0 To theroles.Count - 1
      Dim thename = [Enum].GetName(GetType(eRole), theroles.Item(i))
      If i < theroles.Count - 1 Then
        outstring += thename & thedelimiter.ToString
      Else
        outstring += thename
      End If
    Next

    Return outstring

  End Function

  Public Shared Function ParseStringsToString(thestrings As List(Of String), thedelimiter As Char) As String
    Dim outstring As String = ""
    For i As Integer = 0 To thestrings.Count - 1
      If i < thestrings.Count - 1 Then
        outstring += Convert.ToString(thestrings.Item(i)) & thedelimiter.ToString
      Else
        outstring += Convert.ToString(thestrings.Item(i))
      End If
    Next

    Return outstring
  End Function

  Public Shared Function ParseAttackTypesToString(theAtts As List(Of eAttackType), thedelimiter As Char) As String
    Dim outstring As String = ""
    For i As Integer = 0 To theAtts.Count - 1
      Dim thename = [Enum].GetName(GetType(eAttackType), theAtts.Item(i))
      If i < theAtts.Count - 1 Then
        outstring += thename & thedelimiter.ToString
      Else
        outstring += thename
      End If
    Next

    Return outstring
  End Function

  'Public Shared Sub SetURLImageSource( theurl As String,  theimage As System.Windows.Controls.Image)
  '  'If theurl = "" Then Exit Sub
  '  'If theurl = Nothing Then
  '  '  Dim x = 2
  '  'End If
  '  If Not theurl = Nothing Or Not theurl = "" Then
  '    Dim theuri As New Uri(theurl, UriKind.Absolute)
  '    theimage.Source = New BitmapImage(theuri)
  '  Else
  '    theimage.Source = Nothing

  '  End If

  'End Sub

  Public Shared Sub SetFileImageSource(thefilepath As String, theimage As System.Windows.Controls.Image)
    'If theurl = "" Then Exit Sub
    'If theurl = Nothing Then
    '  Dim x = 2
    'End If

    If Not thefilepath = Nothing Or Not thefilepath = "" Then
      'Dim theuri As New Uri("/Assets/DMIcon32.png", UriKind.Relative)
      Dim theuri As New Uri(thefilepath, UriKind.Relative)
      theimage.Source = New BitmapImage(theuri)
    Else
      theimage.Source = Nothing

    End If

  End Sub

  'Public Shared Function GetSwatchFromImage( theimage As BitmapImage) As Color
  '  'NEEDS REQWRITE FOR WPF
  '  'grab this for new implementation of getcolor
  '  'Dim wbmp As New WriteableBitmap(theimage)
  '  'Dim pixel = wbmp.Pixels(wbmp.Pixels.Count / 2)
  '  'Dim curbytes() As Byte
  '  'Dim curhsb As objHSB

  '  'Dim outcolor As SolidColorBrush
  '  'For i As Integer = wbmp.Pixels.Count / 2 To (wbmp.Pixels.Count / 2) + 100
  '  '  curbytes = BitConverter.GetBytes(wbmp.Pixels(i))

  '  '  curhsb = RGBtoHSB(curbytes(0), curbytes(1), curbytes(2))

  '  '  If curhsb.Bri > 0.6 And curhsb.Sat > 0.25 Then
  '  '    outcolor = New SolidColorBrush(Color.FromArgb(255, curbytes(0), curbytes(1), curbytes(2)))
  '  '    Exit For
  '  '  End If

  '  'Next


  '  'If outcolor Is Nothing Then
  '  '  curbytes = BitConverter.GetBytes(wbmp.Pixels(wbmp.Pixels.Count / 2))
  '  '  curhsb = RGBtoHSB(curbytes(0), curbytes(1), curbytes(2))

  '  '  If curhsb.Sat < 0.25 Then
  '  '    curhsb.Sat = 0.25
  '  '  End If

  '  '  If curhsb.Bri < 0.6 Then curhsb.Bri = 0.6



  '  '  outcolor = New SolidColorBrush(HSBToRGB(curhsb))
  '  'End If

  '  Dim outcolor = Color.FromArgb(128, 128, 128, 128)
  '  Return outcolor 'New SolidColorBrush(Color.FromArgb(thebytes(3), thebytes(0), thebytes(1), thebytes(2)))
  'End Function
  Private Shared Sub fu_Imagefailed(sender As Object, e As ExceptionRoutedEventArgs)

  End Sub


  Public Shared Function RGBtoHSB(ther As Double, theg As Double, theb As Double) As objHSB
    Dim outcol = Color.FromArgb(255, ther, theg, theb)
    Return RGBtoHSB(outcol)
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

  Public Shared Function DarkenBrush(thebrush As SolidColorBrush, amountaspercent As Decimal) As SolidColorBrush
    Return New SolidColorBrush(DarkenColor(thebrush.Color, amountaspercent))
  End Function
  Public Shared Function DarkenColor(thecolor As Color, amountaspercent As Decimal) As Color
    Dim hsbcolor = Helpers.RGBtoHSB(thecolor)

    hsbcolor.Bri = hsbcolor.Bri * (amountaspercent)

    Return Helpers.HSBToRGB(hsbcolor)
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

  ' ''' <summary>
  ' ''' returns nothing if no unit exists with supplied ID
  ' ''' </summary>
  ' ''' <param name="theid"></param>
  ' ''' <returns></returns>
  ' ''' <remarks></remarks>
  'Public Shared Function GetUnitForId(theid As dvID, thegame As dGame) As DDObject

  '  Dim outobj As Object

  '  outobj = thegame.GetHeroInstanceByID(theid)

  '  If Not outobj Is Nothing Then
  '    Dim hb As HeroInstance = outobj
  '    Return New DDObject(outobj, eEntity.Hero_Instance, hb.ID, thegame.dbNames)
  '  End If

  '  outobj = thegame.GetCreepInstanceByID(theid)

  '  If Not outobj Is Nothing Then
  '    Dim cb As Creep_Info = outobj
  '    Return New DDObject(outobj, eEntity.Creep_Info, cb.ID, thegame.dbNames)
  '  End If


  '  'need to add searches for pets and nonplayer units when implemented

  '  Return Nothing


  'End Function

  Public Shared Function GetCircleArea(theradius As Double) As Double
    Return theradius * theradius * Math.PI
  End Function

  Public Shared Function GetTrapezoidArea(shortheight As Double, longheight As Double, length As Double) As Double

    Return ((shortheight + longheight) / 2) * length

  End Function

  Public Shared Function GetConeArea(startradius As Double, endradius As Double, length As Double)

    Return (GetCircleArea(startradius) / 2) + GetTrapezoidArea(startradius * 2, endradius * 2, length) + (GetCircleArea(endradius) / 2)
  End Function

  Public Shared Function GetLevelForAbility(ability As iAbility_Info, owner As iDisplayUnit, game As dGame)
    'Dim curlvl As Integer


    Select Case owner.EntityName
      Case eEntity.Hero_Instance
        Dim hero As HeroInstance = DirectCast(owner, HeroInstance)

        Return hero.AbilityInventory.GetAbilityLevelAtHeroLevel(ability, hero.GetLevelForTime(game.TimeKeeper.CurrentTime))

      Case eEntity.Creep_Info
        Dim cr As Creep_Info = DirectCast(owner, Creep_Info)

        Return cr.GetAbilityLevel(ability, cr.GetLevelForTime(game.TimeKeeper.CurrentTime))

      Case Else
        PageHandler.theLog.Writelog("Helpers.GetLevelForAbility ownerobj.type not handled: " & owner.EntityName.ToString)
        Dim x = 2
        Return 1
    End Select



  End Function


End Class

