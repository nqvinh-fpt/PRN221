   M S B A M L   `   `   `  ����E  AClientSide, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ClientSide
ClientSide  5   	       ClientSide.Login   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ClientSide     5   	     � Title$  
MainClient��5   	   $	��650��6   $
��1000��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��Server:��6   $��2��6"   $��
10,2,-10,2q�6/   �� 5   
   -   5         ��Name$ ServerTextBox��5      $��2��6)   $��
80,2,686,7q�66   �� 5   
   $��Port:��6   $��
319,2,62,2q�6    $��2��64   �� 5   
   -   5        $ PortTextBox��5      $��416,5,235,6q�6'   $��2��6<   �� 5   
   -   5        $��Connect��5      $��2��6?   $��
770,5,18,5q�6L   �� 5   
   $��Message:��6   $��5��6#   $��10,487,-10,-475q�60   �� 5   
   -   5        $ MessageTextBox��5      $��5��6*   $��80,487,188,-470q�67   �� 5   
   -   5        $��Send Message��5      $��5��6H   $��848,487,18,-469q�6U   ���	#FF00B5FF
���   �6�   �� 5    
   -   5        $ OutputTextBox��5       $��5��6)   $��0,19,0,1q�66   " �� VerticalScrollBarVisibility$
 Auto=�6H   $ �� HorizontalScrollBarVisibility$
 Auto=�6k    �� 
IsReadOnly$
 True��6�   ${�False��6�   $��0,0,0,0q�6�   �� 5!   
   -   5         ��Name$ StatusTextBlock��5!      $��6��6-   $��0,10,0,0q�6:   $��Center=�6L   $��Center=�6g   �� 5"   
   -   5         ��Name$ MessageListBox��5"      $
��Left=�6*   $	��914��6E   $��24,61,0,-424q�6Q   $��5��6g   5#      5$      