   M S B A M L   `   `   `  ����G  CHotelManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:HotelManagerHotelManager  5   	        HotelManager.BookingWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:HotelManager     5   	     � Title$  Booking Window��5   	   $	��450��6    $	��800��6-   .��5	      � .+�5
   
    � -   5        $	��frm��5
        � NavigationUIVisibility$ Hidden=�6   6=   �� 5   
   .+�5      �� $��	0,0,0,-50q�6   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $	��400��6!   $
��Auto��6-   $
��Left=�6=   .+�5      �� $ 
Horizontal=�6%   .+�5      �� 6+   �� 5      $��
Booking ID��6$   �� 5      -   5         ��Name$ txtBookingID��5   &    �� TextWrapping$
 Wrap=�6<   $��40��6Q   $��16��6�   ��6\   �� *	BookingId+ � DataContext 6w   �� *SelectedItem+ �� ElementName$ 	lvBooking��6�   �� 5      $��Customer ID��6$   �� 5      -   5        $ txtCustomerID��5   F   $
 Wrap=�6&   $��40��6;   $��16��6�   ��6]   �� *
CustomerId+ 6y   �� *SelectedItem+$ 	lvBooking��6�   �� 5      $��Room ID��6%   �� 5      -   5        $ 	txtRoomID��5   F   $
 Wrap=�6&   $��40��6;   $��16��6�   ��6Y   �� *RoomId+ 6q   �� *SelectedItem+$ 	lvBooking��6�   5      �� 5      $��Check in date��6    (  "System.Windows.Controls.DatePicker  5      -   5          Name$ dtpCheckInDate��5   %   $	��389��6�      SelectedDate 6=   �� *CheckinDate+ 6b   �� *SelectedItem+$ 	lvBooking��6�   �� 5      $��Check out date��6      5      -   5        $ dtpCheckOutDate��5   %   $	��389��6�    6>   �� *CheckoutDate+ 6d   �� *SelectedItem+$ 	lvBooking��6�   �� 5      $��Total price��6    �� 5      -   5        $ txtTotalPrice��5   "   $
 Wrap=�69   $	��389��6N   ��6Z   �� *
TotalPrice+ 6v   �� *SelectedItem+$ 	lvBooking���� 5      $��43��6%   $ 
Horizontal=�61   $��Center=�6J   $��	0,10,0,10q�6g   .+�5      �� -   5        	 ��Name$	 
btnRefresh��5   %   $��Refresh��69   $��70��6K   $��-1,1,1,1q�6V   $��5,5,0,5q�6i   $��2,1,1,1q�6z   6�   �� 5       -	   5        $	 btnAdd��5    %   $	��Add��65   $��70��6C   $��-1,1,1,1q�6N   $��5,5,0,5q�6a   $��2,1,1,1q�6r   6�   �� 5!      -
   5        $	 btnEdit��5!   %   $
��Edit��66   $��70��6E   $��-1,1,1,1q�6P   $��5,5,0,5q�6c   $��2,1,1,1q�6t   6�   �� 5"      -   5        $	 	btnDelete��5"   %   $��Cancel��68   $��70��6I   $��-1,1,1,1q�6T   $��5,5,0,5q�6g   $��2,1,1,1q�6x   6�   �� 5#      -   5        $	 btnCalculat��5#   %   $��Calculating��6:   $��70��6P   $��-1,1,1,1q�6[   $��5,5,0,5q�6n   $��2,1,1,1q�6   6�   5$      5%      �� 5&      $	��400��6!   $
��Auto��6-   $��Center=�6=   .+�5'      �� $��Center=�6    $��Hotel Manager��6=   $��30(�6U   $
��Bold"�6c   
���  ��6u   �� 5(      -   5        $	 	btnRoomMN��5(   !   $��Room Manager��64   $	��214��6K   $��-1,1,1,1q�6W   $��5,5,0,5q�6j   $��2,1,1,1q�6{   $��26��6�   6�   �� 5)      -   5        $	 btncustomerMN��5)   !   $��Customer Manager��68   $	��214��6S   $��-1,1,1,1q�6_   $��5,5,0,5q�6r   $��2,1,1,1q�6�   $��27��6�   6�   �� 5*      -   5        $	 btnReportMN��5*   !   $��Report Analyzing Manager��66   $	��214��6Y   $��-1,1,1,1q�6e   $��5,5,0,5q�6x   $��2,1,1,1q�6�   $��26��6�   6�   5,      5-      �� 5/      -   5        
 ��Name$
 	lvBooking��5/      $
��Auto��6.   $��Center=�6<   $	��797��6�    �� View 50      �� 51      .P�52      �� $��
Booking ID��6-    �� Width$ 90��6A    �� DisplayMemberBinding 6L   �� *	BookingId+�� 53      $��Customer ID��6-   $ 90��6B    6M   �� *
CustomerId+�� 54      $��Room ID��6-   $ 90��6>    6I   �� *RoomId+�� 55      $��Check in date��6-   $	 150��6D    6P   ��  �� Path$ CheckinDate� �� StringFormat$ 
dd/MM/yyyy���� 56      $��Check out date��6-   $	 150��6E    6Q   �� $ CheckoutDate�$ 
dd/MM/yyyy���� 57      $��Total price��6-   $	 180��6B    6N   �� *
TotalPrice+58      5:      5<      5=      5>      5?      