   M S B A M L   `   `   `  ����E  AGROUP04WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:FUMiniHotelManagementFUMiniHotelManagement  5   	   &     FUMiniHotelManagement.ChangeType   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:FUMiniHotelManagement     5   	     � Title$  
ChangeType��5   	   $	��400��6   $	��600��6)    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      � $��0,0,0,-6q�6   ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5      �  � Color$ #0099FF��6    � Offset$ 0Q�6/   � 5      $ 	#FF347BDA��6   $ 0.794Q�61   � 5      $ 	#FF60B1E7��6   $ 1Q�61   � 5      $ 	#FF596FDD��6   $ 0.309Q�61   � 5      $ 	#FF472FDE��6   $ 0.484Q�61   5      .+�5   
   �� $��Manage Room Type��6   $��24(�6+   $
��Bold"�69   $��Center=�6K   $	��Top=�6h   $��0,20,0,0q�6�   � 5   
   $��55,99,55,42q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5       $
��133* �6#   �� 5!      $
��200* �6#   �� 5"      $	��67* �6#   .+�5%      �� $��
Search ID:��6   $��0��6)   $��0��66   $��5,5,5,5q�6F   �� 5&      -   5         ��Name$ txtSearchId��5&      $��0��6+   $��1��68   $��5,5,5,5q�6H   �� 5'      -   5        	 ��Name$	 	btnSearch��5'      $��Search��6(   $��60��69   $��	11,5,11,5q�6D   $��0��6W   $��2��6d   ���	#FF0099FF��5(      �� 5)      
 �� 
TargetType"
 ��6&   .R�5*      ��  �� CornerRadius$ 5��5+      #��z��5,      ._�5-      �� $��Center=�6/   $��Center=�5.      5/      50      52      �� 54      $��Room Type Name:��6   $��1��6.   $��0��6;   $��5,5,5,5q�6K   �� 55      -   5        $ txtRoomTypeName��55      $��1��6/   $��1��6<   $��5,5,5,5q�6L   $��2��6]   ${�False��6q   �� 57      $��Type Description:��6   $��2��60   $��0��6=   $��5,5,5,5q�6M   �� 58      -   5        $ txtTypeDescription��58      $��2��62   $��1��6?   $��5,5,5,5q�6O   $��2��6`   ${�False��6t   �� 5:      $��
Type Note:��6   $��3��6)   $��0��66   $��5,5,5,5q�6F   �� 5;      -   5        $ txtTypeNote��5;      $��3��6+   $��1��68   $��5,5,5,5q�6H   $��2��6Y   ${�False��6m   �� 5=       �� Orientation$ 
Horizontal=�6   $��6��62   $��1��6?   $
��Left=�6O   $��5,5,0,0q�6j   $��2��6{   $	��312��6�   .+�5>      �� -   5        $	 	btnUpdate��5>      $��Update��6,   $	��100��6=   $��2q�6I   ���	#FF0099FF${�False��6�   5@      �� 5A      -   5        $	 	btnDelete��5A      $��Delete��6,   $	��100��6=   $��2q�6I   ���	#FFEF8F18${�False��6�   �� 5B      -   5        $	 btnSave��5B      $
��Save��6*   $	��100��69   $��2q�6E   ���	#FF8F00FF${�False��6�   5C      5D      5E      5F      