   M S B A M L   `   `   `  ����E  AGROUP04WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:FUMiniHotelManagementFUMiniHotelManagement  5   	   &     FUMiniHotelManagement.CreateType   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:FUMiniHotelManagement     5   	     � Title$  
CreateType��5   	   $	��400��6   $	��600��6)    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      � ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5      �  � Color$ #0099FF��6    � Offset$ 0Q�6/   � 5      $ 	#FF347BDA��6   $ 0.794Q�61   � 5      $ 	#FF60B1E7��6   $ 1Q�61   � 5      $ 	#FF596FDD��6   $ 0.309Q�61   � 5      $ 	#FF472FDE��6   $ 0.484Q�61   5      .+�5   
   �� $��Create Room Type��6   $��24(�6+   $
��Bold"�69   $��Center=�6K   $	��Top=�6h   $��0,20,0,0q�6�   � 5   
   $��50,109,50,108q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      $	��150 �6#   �� 5      $��* �6#   .+�5!      �� $��Room Type Name:��6   $��0��6.   $��0��6;   $��5q�6K   �� 5"      -   5         ��Name$ txtTypeName��5"      $��0��6+   $��1��68   $��5q�6H   �� 5#      $��Type Description:��6   $��1��60   $��0��6=   $��5q�6M   �� 5$      -   5        $ txtDescription��5$      $��1��6.   $��1��6;   $��5q�6K   �� 5&      $��
Type Note:��6   $��2��6)   $��0��66   $��5q�6F   �� 5'      -   5        $ txtNote��5'      $��2��6'   $��1��64   $��5q�6D   �� 5)      	 �� Orientation$	 
Horizontal=�6   $��3��62   $��1��6?   $
��Left=�6O   $��5q�6j   .+�5*      �� -   5        
 ��Name$
 CreateButton��5*      $��Create��6/   $	��100��6@   $��5q�6L   ���	#FF0099FF��5+      �� 5,       �� 
TargetType" ��6*   .R�5-      ��  �� CornerRadius$ 5��5.      #��z��5/      ._�50   "   �� $��Center=�63   $��Center=�51      52      53      55      �� 56      -   5        $
 CancelButton��56      $��Cancel��6/   $	��100��6@   $��5q�6L   ���	#FFEF8F18��57   &   �� 58      " ��6&   .R�59      �� $ 5��5:      #��z��5;      ._�5<      �� $��Center=�6/   $��Center=�5=      5>      5?      5A      5B      5C      5D      5E      