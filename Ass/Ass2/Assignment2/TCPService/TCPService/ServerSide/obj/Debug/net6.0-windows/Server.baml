   M S B A M L   `   `   `  ����E  AServerSide, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ServerSide
ServerSide  5   	       ServerSide.Server   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ServerSide     5   	     � Title$  
MainServer��5      $	��450��6    $	��800��6-   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��Server:��6   $��0��6"   �� 5   
   -   5         ��Name$ ServerTextBox��5      $��0��6)   $��70,0,0,5q�66   �� 5   
   $��Port:��6   $��1��6    �� 5   
   -   5        $ PortTextBox��5      $��1��6'   $��70,0,0,5q�64   �� 5   
   -   5        $��Connect��5      $��2��6?   $��0,5,0,5q�6L   �� 5   
   $��Message:��6   $��3��6#   �� 5   
   -   5        $ MessageTextBox��5      $��3��6*   $��70,0,0,5q�67   �� 5   
   -   5        $��Send Message��5      $��4��6H   $��0,5,0,5q�6U   �� 5!   
   -   5         ��Name$ MessageListBox��5!      $��5��6*   $��
0,10,0,-15q�67   �� 5"   
   -   5         ��Name$ StatusTextBlock��5"      $��5��6-   $��
0,43,0,-53q�6:   5#      5$      