   M S B A M L   `   `   `  ����=  9Q1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Q1Q1  5   	       Q1.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   "localclr-namespace:Q1     5   	     � Title$  EmployeeWindow��5   	   $	��600��6    $	��800��6-   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��2.* �6   6,   �� 5      6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $	��1.* �6#   62   �� 5      6%   .+�5      � $��0��6   
�������$��0,0,0,53q�6:   6N   �� 5      .+�5      �� $��Employee Information��6   $��18(�67   $
��Bold"�6E   
���  ��6W   �� 5      -   5         ��Name$ Employee_Id��5      $��Employee Id��6-   $	��Top=�6C   �� 5      -   5         ��Name$ txtEmployeeId��5       �� TextWrapping$
 Wrap=�61   $	��401��6E   $��23��6Q   �� 5      $��Employee Name��6   �� 5      -   5        $ txtEmployeeName��5      $
 Wrap=�63   $	��401��6G   $��23��6S   �� 5      $��Gender��6   �� 5       �� Orientation$ 
Horizontal=�6   .+�5      	� -   5         	�Name$ rbtnMale��5   "   $
��Male��64   $��92��6C   $
��Left=�6N    d� 	IsChecked$
 TrueY�6i   	� 5      -   5        $ 
rbtnFemale��5   "   $	��148��66   $��Female��6B   5      �� 5       $��Date of birth��6   (  "System.Windows.Controls.DatePicker  5!      -   5        	  Name$	 	sldateDOB��5!      �� 5"      $��Phone��6   �� 5#      -   5        $ txtPhone��5#      $
 Wrap=�6,   $	��401��6@   $��23��6L   �� 5$      $��IDNumber��6   �� 5%      -   5        $ txtIDNumber��5%      $
 Wrap=�6/   $	��401��6C   $��23��6O   �� 5&      $ 
Horizontal=�6   $��0,20,0,0q�66   $��Center=�6H   .+�5'      �� -	   5        
 ��Name$
 
btnRefresh��5'      $��Refresh��61   $��20,10,20,10q�6C   $��Center=�6X   $��50��6u   6�   �� 5(      -
   5        $
 btnAdd��5(      $	��Add��6-   $��20,10,20,10q�6;   $��Center=�6P   $��50��6m   6x   �� 5)      -   5        $
 btnEdit��5)      $
��Edit��6.   $��20,10,20,10q�6=   $��Center=�6R   $��50��6o   �� 5*      -   5        $
 	btnDelete��5*      $��Delete��60   $��20,10,20,10q�6A   $��Center=�6V   $��50��6s   5+      5-      � 5.      $��1��6   6%   5/      � 50   
   $��1��6   .+�51      �� -   5         ��Name$ dgvData��51       �� View 52      �� 53      .P�54      �� 55      57      58      5:      5;      