   M S B A M L   `   `   `  ����A  =PE_Hoc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PE_HocPE_Hoc  5   	       PE_Hoc.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:PE_Hoc     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��1.* �6   6.   �� 5      6!   .+�5   
   � $��0��6   .+�5      �� $��ID��6   $
��Left=�6!   $��	36,45,0,0q�6<   $	��Top=�6O   �� 5      -   5         ��Name$ txtID��5      $
��Left=�6%   $��
113,49,0,0q�6@    �� TextWrapping$
 Wrap=�6T   $	��Top=�6h   $	��120��6�   �� 5      $
��Name��6   $
��Left=�6#   $��	36,78,0,0q�6>   $	��Top=�6Q   �� 5      -   5        $ txtName��5      $
��Left=�6'   $��
113,82,0,0q�6B   $
 Wrap=�6V   $	��Top=�6j   $	��120��6�   �� 5      -   5         ��Name$ 
cbCategory��5       �� DisplayMemberPath$ CategoryName��5      $
��Left=�5      $��113,119,0,0q�62   $	��Top=�6G   $	��120��6_   �� 5      $��Category��6   $
��Left=�6'   $��
36,117,0,0q�6B   $	��Top=�6V   �� 5      $��Quantity��6   $
��Left=�6'   $��
36,163,0,0q�6B   $	��Top=�6V   �� 5      -   5        $ txtQuantity��5      $
��Left=�6+   $��113,171,0,0q�6F   $
 Wrap=�6[   $	��Top=�6o   $	��120��6�   �� 5      $��Discontinued��6   $
��Left=�6+   $��
36,209,0,0q�6F   $	��Top=�6Z   	� 5      -   5         	�Name$ rbtnTrue��5      $
��True��6,   $
��Left=�6;   $��132,215,0,0q�6V   $	��Top=�6k   ${�False��6�    d� 	IsChecked$
 TrueY�6�   	� 5      -   5        $ 	rbtnFalse��5      $��False��6-   $
��Left=�6=   $��192,215,0,0q�6X   $	��Top=�6m   �� 5      -   5         ��Name$ btnAdd��5      $	��Add��6%   $
��Left=�63   $��
38,257,0,0q�6N   $	��Top=�6b   6z   �� 5      -   5        $ 	btnDelete��5      $��Delete��6(   $
��Left=�69   $��163,257,0,0q�6T   $	��Top=�6i   6�   �� 5      -	   5        $ btnLoad��5      $
��Load��6&   $
��Left=�65   $��226,257,0,0q�6P   $	��Top=�6e   6}   �� 5       -
   5        $ 	btnUpdate��5       $��Update��6)   $
��Left=�6:   $��
92,257,0,0q�6U   $	��Top=�6i   6�   5!      � 5"   
   $��1��6   
�������	 � RowDefinitions	 5#      �� 5$      $	��3.* �6    6/   �� 5%      6#   .+�5'      � $��0��6   5)      � 5*      $��1��6   .+�5+      �� .+�5,      �� -   5        $ btnSaveFile1��5,      $��	Save File��63   6G   �� 5-      -   5        $ btnLoadFile1��5-      $��	Load File��63   $��0,10,0,0q�6G   6Y   5.      50      �� 51      -   5        
 ��Name$
 	lvProduct��51       �� View 52      �� 53      .P�54      ��  �� Width$ 30��6)   $��ID��64    �� DisplayMemberBinding 6@   ��  �� Path$ 	ProductId�6r   �� 55      $	 100��6)   $
��Name��65    6C   �� $ ProductName�6w   �� 56      $	 100��6)   $��Category��65    6G   �� $ Category.CategoryName�6�   �� 57      $ 80��6)   $��Quantity��64    6F   �� $ QuantityPerUnit�6~   �� 58      $ 80��6)   $��Discontinued��64    6J   �� $ Discontinued�6   59      5;      5<      5=      5?      