   M S B A M L   `   `   `  ����   DotaMasterWPF#    DotaMasterWPF.ctrlCreep_Badge   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .��� -     �Name$  
LayoutRoot�����	#FF252627$��2q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -    ��Name$ rectBackColor��$��0��$��17���� -    ��Name$ spnlStashContainer�� �� Orientation$ 
Horizontal=�$y�	Collapsed=�$��0��.+��� -    ��Name$ lblStash��$��Stash: ��$��0q�$
��left=�$��Center=����	#FFD9D9D9$��5,0,0,0q��� -   $ 	spnlStash��$ 
Horizontal=�$��5q��� -   $ spnlBuffContainer��$ 
Horizontal=�$y�	Collapsed=�$��1��.+��� -   $ lblBuffs��$��Buffs/Debuffs: ��$��0q�$
��left=�$��Center=����	#FFD9D9D9$��5,0,0,0q��� -   $ 	spnlBuffs��$ 
Horizontal=�$��5q�� $��2�� � ColumnDefinitions �� $
��Auto ��� .+��� -	   $ spnlHeroPortrait��$��2��$��0��$��Center=�� $��2��$��1��$��Center=� �� $
��Auto ��� .+��� -
   $ spnlHeading��$��0,5,0,0q�.+��� -   $ spnlCurrItemsRow1��$��1��$��1��$��Center=�$��center=�$ 
Horizontal=��� -   $ spnlCurrItemsRow2��$��1��$��1��$��center=�$��Center=�$ 
Horizontal=��� $��1��$��1��$ vertical=�.+��� -   $ lblHeroName��$��1��$��0��$��0q�$��Keeper of the Light�����	#FFD9D9D9$��16(�$��5,0,0,0q��� $ 
Horizontal=�$��Center=�.+��� -   $ lblGoldTotal��$��58��$��Gold: 0��$��0q����	#FFF6DD5C$��5,0,5,0q�$��10(��� -   $ 
lblXPTotal��$��0q�$��58��$��Exp: 0�����	#FF5C94F6$��5,0,5,0q�$��10(�$
��Left=��� -   $ lblBuildName��$��Center=�$��0q�$��1��$��0��$ ��Build: Keeper of the Light�����	#FFD9D9D9$��10(�$	��5,0q�� -    �Name$ wpnlAbilities��$��3��$��Center=�]� -    ]�Name$ dpnlDevPlusMinus��$��4��.+��� -   $ lblDevPlusMinus��$��0q�$��+��$��2q�$��Center=�$
��Left=����	#FFD9D9D9$
��Bold"�$��14(��� $��
devdetails��$��0q�$��2q�$��Center=�$
��Left=����	#FFD9D9D9$��9(��� -   $ rectDevDividerMid��$��1��$��5,0,10,0q����	#FF6E6E6E$��Stretch=�$��Center=��� -   $ spnlDevDetails��$ Vertical=�$��5��]� -   $ dpnlPlusMinus��$��6��.+��� -   $ lblPlusMinus��$��+��$��0q�$��2q�$��Center=�$
��Left=����	#FFD9D9D9$
��Bold"�$��14(��� -   $ 
lblDetails��$��details��$��0q�$��2q�$��Center=�$
��Left=����	#FFD9D9D9$��9(��� -   $ rectDividerMid��$��1��$��5,0,10,0q����	#FF6E6E6E$��Stretch=�$��Center=��� -   $ spnlPetHeading��$��7�����	#3FFFFFFF$��0,20,0,5q�.+��� -   $ lbletHeading��$"��Pets/Summons/Illusions/Wards��$��0q�$��2q�$��Center=�$��Center=����	#FFD9D9D9�� -   $ spnlPets��$��8��$	��230��$
��auto��$��Center=��� -   $ spnlBuildHeading��$��9�����	#3FFFFFFF$��0,20,0,5q�.+��� -   $ lblBuildHeading��$��Current Build��$��0q�$��2q�$��Center=�$��Center=����	#FFD9D9D9]� -   $ spnlHeroBuild��$��10��.+��� -    	 ��Name$	 cbxBuildSelect�����	#FF252627$��20��$��Center=�$��5,0,5,0q�$��9(��� -!   
 ��Name$
 btnNewBuildSave��$
��Save���� -"   $
 btnCancelBuildSave��$��Cancel���� -#    ��Name$ tbxNewBuildName��$��New build name��$��0,0,5,0q�]� -$   $ dpnlPriorityTarget��$��11��.+��� -%   $	 cbxPrioritySelect�����	#FF252627$��20��$��Center=�$��5,0,5,0q�$��9(��� -&   $	 	cbxTarget�����	#FF252627$��20��$��Center=�$��5,0,5,0q�$��9(��� -'   $ spnlItemBuildHeading��$��12�����	#3FFFFFFF$��0,20,0,5q�.+��� -(   $ lblItemBuild��$��
Item Build��$��0q�$��2q�$��Center=�$��Center=����	#FFD9D9D9�� -)   $ wpnlItem_Picker��$��13��$ Vertical=��� -*   $ spnlAbilityBuildHeading��$��14�����	#3FFFFFFF$��0,20,0,5q�.+��� -+   $ lblAbilityBuild��$��Ability Build��$��0q�$��2q�$��Center=�$��Center=����	#FFD9D9D9
�������� -,   $ wpnlAbility_Picker��$��15�� � Orientation$ 
Horizontal=�$��center=��� --   $ spnlDivider��$��16��$��13q�.+��� $��1��$��	10,0,10,0q����	#FF6E6E6E$��Stretch=�$��Center=��� -.   $ rectSelected��
��� ���$��0��$��16��$��2��