   M S B A M L   `   `   `  ����G  CHotelManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:HotelManagerHotelManager  5   	   !    HotelManager.CustomerWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:HotelManager     5   	     � Title$  BookingWindow��5   	   $	��450��6   $	��800��6,   .��5	      � .+�5
   
    � -   5        $	��frm��5
        � NavigationUIVisibility$ Hidden=�6   6=   �� 5   
   .+�5      �� $��	0,0,0,-50q�6   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $	��400��6!   $
��Auto��6-   $
��Left=�6=   .+�5      �� $��Customer ID��6    �� 5      -   5         ��Name$ txtCustomerID��5   "    �� TextWrapping$
 Wrap=�69   $	��388��6N   ��6Z   �� *
CustomerId+ � DataContext 6v   �� *SelectedItem+ �� ElementName$ 
lvCustomer���� 5      $
��Name��6    �� 5      -   5        $ txtName��5   C   $
 Wrap=�6"   $	��388��67   ��6T   �� *Name+ 6j   �� *SelectedItem+$ 
lvCustomer���� 5      $��Phone number��6!   �� 5      -   5        $ txtPhone��5   C   $
 Wrap=�6"   $	��388��67   ��6U   �� *PhoneNumber+ 6r   �� *SelectedItem+$ 
lvCustomer���� 5      $��Email��6    �� 5      -   5        $ txtEmail��5   "   $
 Wrap=�64   $	��388��6I   ��6U   �� *Email+ 6l   �� *SelectedItem+$ 
lvCustomer���� 5      $��Address��6    �� 5      -   5        $ 
txtAddress��5   "   $
 Wrap=�66   $	��388��6K   ��6W   �� *	Address+ 6p   �� *SelectedItem+$ 
lvCustomer���� 5      $��43��6%   $ 
Horizontal=�61   $��Center=�6J   $��	0,10,0,10q�6g   .+�5      �� -   5         ��Name$ 
btnRefresh��5   %   $��Refresh��69   $��90��6K   $��-1,1,1,1q�6V   $��5,5,0,5q�6i   $��2,1,1,1q�6z   6�   �� 5      -   5        $ btnAdd��5   %   $	��Add��65   $��90��6C   $��-1,1,1,1q�6N   $��5,5,0,5q�6a   $��2,1,1,1q�6r   6�   �� 5      -	   5        $ btnEdit��5   %   $
��Edit��66   $��90��6E   $��-1,1,1,1q�6P   $��5,5,0,5q�6c   $��2,1,1,1q�6t   6�   �� 5      -
   5        $ 	btnDelete��5   %   $��Delete��68   $��90��6I   $��-1,1,1,1q�6T   $��5,5,0,5q�6g   $��2,1,1,1q�6x   6�   5      5       �� 5!      $	��400��6!   $
��Auto��6-   $��Center=�6=   .+�5"      �� $��Center=�6    $��Hotel Manager��6=   $��30(�6U   $
��Bold"�6c   
���  ��6u   �� 5#      -   5        $ btnBookingMN��5#   !   $��Booking Manager��67   $	��214��6Q   $��-1,1,1,1q�6]   $��5,5,0,5q�6p   $��2,1,1,1q�6�   $��26��6�   6�   �� 5$      -   5        $ btRoomMN��5$   !   $��Room Manager��63   $	��214��6J   $��-1,1,1,1q�6V   $��5,5,0,5q�6i   $��2,1,1,1q�6z   $��27��6�   6�   �� 5%      -   5        $ btnReportMN��5%   !   $��Report Analyzing Manager��66   $	��214��6Y   $��-1,1,1,1q�6e   $��5,5,0,5q�6x   $��2,1,1,1q�6�   $��26��6�   6�   �� 5&      $ Vertical=�6%   .+�5'      �� -   5        $ 	txtSearch��5'   &   $
 Wrap=�69   $	��375��6N   �� 5*      $��10q�6)   $ 
Horizontal=�65   $��Center=�6N   .+�5+   "   �� -   5         ��Name$ 	cbbSearch��5+   7   $��25��6+   .@�5,   &   �� 	 �� 
IsSelected$
	 True��63   $
��Name��6E   �� 5-   &   $��Phone number��63   �� 5.   &   $��Email��63   �� 5/   &   $��Address��63   50   #   �� 51   "   -   5        $ 	btnSeacrh��51   )   $��Search��6<   $	��214��6M   $��-1,1,1,1q�6Y   $��5,5,0,5q�6l   $��2,1,1,1q�6}   $��26��6�   6�   52      53      54      56      �� 57      -   5        
 ��Name$
 
lvCustomer��57      $
��Auto��6/   $��Center=�6=   $	��797��6�    �� View 58      �� 59      .P�5:      �� $��Customer ID��6-    �� Width$ 90��6B    �� DisplayMemberBinding 6M   �� *
CustomerId+�� 5;      $
��Name��6-   $	 200��6;    6G   �� *Name+�� 5<      $��Phone Number��6-   $	 150��6C    6O   �� *PhoneNumber+�� 5=      $��Email��6-   $	 100��6<    6H   �� *Email+�� 5>      $��Address��6-   $	 200��6>    6J   �� *	Address+5?      5A      5C      5D      5E      5F      