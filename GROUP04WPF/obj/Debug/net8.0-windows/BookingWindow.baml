   M S B A M L   `   `   `  ����E  AGROUP04WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:GROUP04WPF
GROUP04WPF  5   	       GROUP04WPF.BookingWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:GROUP04WPF     5   	     � Title$  BookingWindow��5   	   $	��480��6   $	��600��6,    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      � $��0,0,0,-6q�6    � ColumnDefinitions 5   
   �� 5      $
��366* �6   �� 5      $
��235* �6   ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5      �  � Color$ #0099FF��6    � Offset$ 0Q�6/   � 5      $ 	#FF347BDA��6   $ 0.794Q�61   � 5      $ 	#FF60B1E7��6   $ 1Q�61   � 5      $ 	#FF596FDD��6   $ 0.309Q�61   � 5      $ 	#FF472FDE��6   $ 0.484Q�61   5      .+�5   
   �� $ ��Create Booking Reservation��6   $��
Montserrat)�65   $��24(�6M   $
��Bold"�6[   $
��Left=�6m   $	��Top=�6�   $��
138,20,0,0q�6�   $��2��6�   � 5   
   $��50,122,50,25q�6   $��2��6%    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5       $
��Auto �6    �� 5!      $
��Auto �6    �� 5"      $
��Auto �6     5$      �� 5%      $	��150 �6#   �� 5&      $��* �6#   .+�5)      �� $��Room Number:��6   $��0��6+   $��0��68   $��5q�6H   �� 5*      -   5         ��Name$ cmbRoomNumber��5*      $��0��6.   $��1��6;   $��5q�6K   5+      �� 5-      $��Customer Name:��6   $��1��6-   $��0��6:   $��5q�6J   �� 5.      -   5        	 ��Name$	 txtCustomerId��5.      $��1��6-   $��1��6:   $��5q�6J   ${�False��6U   �� 50      $��Booking Date:��6   $��2��6,   $��0��69   $��5q�6I   (  "System.Windows.Controls.DatePicker  51      -   5        
  Name$
 txtBookingDate��51      $��2��61   $��1��6>   $��	5,5,208,5q�6N   ${�False��6a   �� 53      $��Start Date:��6   $��3��6*   $��0��67   $��5q�6G     54      -   5        $
 txtStartDate��54      $��3��6/   $��1��6<   $��	5,5,208,5q�6L   6_   �� 56      $��	End Date:��6   $��4��6(   $��0��65   $��5q�6E     57      -   5        $
 
txtEndDate��57      $��4��6-   $��1��6:   $��	5,5,208,5q�6J   6]   �� 59      $��Actual Price:��6   $��5��6,   $��0��69   $��5q�6I   �� 5:      -   5        $	 txtActualPrice��5:      $��5��6.   $��1��6;   $��5q�6K   ${�False��6V   �� 5<      $��Total Price:��6   $��6��6+   $��0��68   $��5q�6H   �� 5=      -   5        $	 txtTotalPrice��5=      $��6��6-   $��1��6:   $��5q�6J   ${�False��6U   �� 5?       �� Orientation$ 
Horizontal=�6   $��7��62   $��1��6?   $
��Left=�6O   $��5q�6j   .+�5@      �� -   5         ��Name$ CreateButton��5@      $��Create��6/   $	��100��6@   $��5q�6L   ���	#FF0099FF��5A      �� 5B       �� 
TargetType" ��6*   .R�5C      ��  �� CornerRadius$ 5��5D      #��z��5E      ._�5F   "   �� $��Center=�63   $��Center=�5G      5H      5I      5K      �� 5L      -	   5        $ CancelButton��5L      $��Cancel��6/   $	��100��6@   $��5q�6L   ���	#FFEF8F18��5M      �� 5N      " ��6*   .R�5O      �� $ 5��5P      #��z��5Q      ._�5R   "   �� $��Center=�63   $��Center=�5S      5T      5U      5W      5X      5Y      5Z      5[      