   M S B A M L   `   `   `  ����E  AGROUP04WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:GROUP04WPF
GROUP04WPF  5   	        GROUP04WPF.ChangesPassword   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:GROUP04WPF     5   	     � Title$  ChangesPassword��5   	   $	��250��6!   $	��400��6.    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      � ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5      �  � Color$ #0099FF��6    � Offset$ 0Q�6/   � 5      $ 	#FF347BDA��6   $ 0.794Q�61   � 5      $ 	#FF60B1E7��6   $ 1Q�61   � 5      $ 	#FF596FDD��6   $ 0.309Q�61   � 5      $ 	#FF472FDE��6   $ 0.484Q�61   5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   $	��120��6,   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5    
   �� $��Current Password:��6   $��0��6,   $��0��69   $��10q�6I   $��Right=�6U   �� 5!   
   -   5         ��Name$ txtCurrentPassword��5!      $��0��6.   $��1��6;   $��2��6K   $��10q�6_   �� 5#   
   $��New Password:��6   $��1��6(   $��0��65   $��10q�6E   $��Right=�6Q   �� 5$   
   -   5        $ txtNewPassword��5$      $��1��6*   $��1��67   $��2��6G   $��10q�6[   �� 5&   
   $��Confirm Password:��6   $��2��6,   $��0��69   $��10q�6I   $��Right=�6U   �� 5'   
   -   5        $ txtConfirmPassword��5'      $��2��6.   $��1��6;   $��2��6K   $��10q�6_   �� 5)   
   $��3��6   $��1��6"   $��2��62   	 �� Orientation$	 
Horizontal=�6F   $��Center=�6_   $��10q�6|   .+�5*      �� -   5        $��Confirm��5*      $��70��6'   $��30��62   $��5q�6>   
���������5+      �� 5,      
 �� 
TargetType"
 ��6&   .R�5-      ��  �� CornerRadius$ 5��5.      #��z��5/      ._�50      �� $��Center=�6/   $��Center=�51      52      53      55      �� 56      -   5        $��Cancel��56      $��70��6&   $��30��61   $��5q�6=   
��� E����57      �� 58      "
 ��6&   .R�59      �� $ 5��5:      #��z��5;      ._�5<      �� $��Center=�6/   $��Center=�5=      5>      5?      5A      5B      5C      5D      