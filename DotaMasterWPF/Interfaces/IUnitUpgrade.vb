Public Interface IUnitUpgrade
  Inherits iGameEntity




  Property mImageURL As String
  Property mWebpageLink As String
  Property mDescription As String
  Property mNotes As String
  Property mColorText As String

  Property Lifetime As Lifetime

  Property mManaCost As ValueWrapper '125, 140, 155, 170,  Owner: Earthshaker
  Property mCooldown As ValueWrapper '125, 140, 155, 170,  Owner: Earthshaker
  Property mCharges As ValueWrapper
  Property mAbilityTypes As List(Of eAbilityType) 'Unit Target, Point Target,  Owner: Earthshaker
  Property mAffects As List(Of eUnit) 'Unit Target, Point Target,  Owner: Earthshaker
  Property mDamageType As eDamageType
  Property mDamage As ValueWrapper 'one for each level of the spell, if applicable
  Property mDuration As ValueWrapper 'one for each level of the spell, if applicable
  Property mRadius As ValueWrapper 'one for each level of the spell, if applicable
  Property mRange As ValueWrapper

  Property mBlockedByMagicImmune As Boolean
  Property mRemovedByMagicImmune As Boolean
  Property mCanBePurged As Boolean 'diffusal blade
  Property mCanBeUsedByIllusions As Boolean
  Property mCanSelfDeny As Boolean
  Property mBlockedByLinkens As Boolean
  Property mBreaksStun As Boolean
  Property mIsUniqueAttackModifier As Boolean
  Property mAbilityLevelCount As Integer
  Property mPiercesSpellImmunity As Boolean

  Property mTeamEnemyTarget As iDisplayUnit
  Property mTeamFriendlyTarget As iDisplayUnit
  Property mTargetFriendBias As Boolean

  Property StatesAndStateUrls As List(Of List(Of String))
  Property States As List(Of String)
  Property StateImageUrls As List(Of String)
  Property CurrentStateIndex As Integer

  Property CurrentLevel As Integer
  Function GetActiveModifiers(stateindex As Integer, game As dGame, unitupgrade As IUnitUpgrade, _
                                                caster As iDisplayUnit, _
                                               target As iDisplayUnit, _
                                                ftarget As iDisplayUnit, _
                                                isfriendbias As Boolean, _
                                                occurencetime As Lifetime, aghstime As Lifetime) As ModifierList

  Function GetPassiveModifiers(thestateindex As Integer, game As dGame, unitupgrade As IUnitUpgrade, _
                                                   caster As iDisplayUnit, _
                                                   target As iDisplayUnit, _
                                                   ftarget As iDisplayUnit, _
                                                   isfriendbias As Boolean, _
                                                   occurencetime As Lifetime, aghstime As Lifetime) As ModifierList



End Interface
