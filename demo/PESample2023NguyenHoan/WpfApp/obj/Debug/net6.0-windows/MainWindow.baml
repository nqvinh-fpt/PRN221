   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  5   	       WpfApp.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WpfApp     5   	     � Title$  Employee Windows��5   	   $	��500��6"   $	��800��6/   .��5
      � .+�5   
   �� .+�5   
   �� $	��400��6   $
��Auto��6!   ���	#FF39E5E5$
��Left=�6G   .+�5      �� $��Employee ID��6   �� 5      -   5         ��Name$ txtEmployeeID��5       �� TextWrapping$
 Wrap=�6-   $	��400��6B   ��6N   �� *Id+ � DataContext 6b   �� *SelectedItem+ �� ElementName$ lvEmployees���� 5      $��Employee Name��6   �� 5      -   5        $ txtEmployeeName��5   ;   $
 Wrap=�6   $	��400��6/   ��6T   �� *Name+ 6j   �� *SelectedItem+$ lvEmployees���� 5      $��Gender��6   �� 5      $��31��6    �� Orientation$ 
Horizontal=�6%   .+�5      	� -   5         	�Name$ rbMale��5   >   $
��Male��6    d� 	IsChecked$
 TrueY�6-   6>   	� 5      -   5        $ rbFemale��5   A   $��Female��6   $��10,0,0,0q�6/   6A   5      �� 5      $��Date of Birth��6   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ dtpDOB��5      	   Text	 6-   �� *Dob+ 6B   �� *SelectedItem+$ lvEmployees���� 5      $��Phone��6   �� 5      -   5        $ txtPhone��5      $
 Wrap=�6,   $	��400��6A   ��6M   �� *Phone+ 6d   �� *SelectedItem+$ lvEmployees���� 5      $��	ID Number��6   �� 5      -   5        $ txtIDNumber��5      $
 Wrap=�6/   $	��400��6D   ��6P   �� *
Idnumber+ 6j   �� *SelectedItem+$ lvEmployees���� 5      $��43��6   $ 
Horizontal=�6%   $��Center=�6>   .+�5      �� -   5        
 ��Name$
 
btnRefresh��5      $��Refresh��6-   $��90��6?   $��-1,1,1,1q�6J   $��5,5,0,5q�6]   $��2,1,1,1q�6n   6�   �� 5      -	   5        $
 btnAdd��5      $	��Add��6)   $��90��67   $��-1,1,1,1q�6B   $��5,5,0,5q�6U   $��2,1,1,1q�6f   6�   �� 5      -
   5        $
 btnEdit��5      $
��Edit��6*   $��90��69   $��-1,1,1,1q�6D   $��5,5,0,5q�6W   $��2,1,1,1q�6h   6�   �� 5       -   5        $
 	btnDelete��5       $��Delete��6,   $��90��6=   $��-1,1,1,1q�6H   $��5,5,0,5q�6[   $��2,1,1,1q�6l   6�   5!      5"      �� 5#      -   5         ��Name$ lvEmployees��5#      $
��Auto��6,   $��Center=�6:   $��Center=�6W    �� View 5$      �� 5%      .P�5&      �� $��Employee ID��6)    �� Width$	 130��6>    �� DisplayMemberBinding 6J   ��  �� Path$ Id��� 5'      $��Employee Name��6)   $	 130��6@    6L   �� $
 Name��� 5(      $��Gender��6)   $	 130��69    6E   �� $ Gender��� 5)      $��Date of Birth��6)   $	 130��6@    6L   �� $	 Dob� �� StringFormat$ 
dd/MM/yyyy���� 5*      $��Phone��6)   $	 130��68    6D   �� $ Phone��� 5+      $��	ID Number��6)   $	 130��6<    6H   �� $ Idnumber�5,      5.      50      51      52      