   M S B A M L   `   `   `  ����D  @TCPClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:TCPClient	TCPClient  5   	       TCPClient.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:TCPClient     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6&   $��10q�6?   .+�5      �� $��	Username:��6   $��Center=�6-   $��0,0,5,0q�6H   �� 5      -   5         ��Name$ UsernameTextBox��5      $	��200��63   5      �� 5      $��1��6   $ 
Horizontal=�6&   $��10q�6?   .+�5      �� $��	Password:��6   $��Center=�6-   $��0,0,5,0q�6H   G� 5      -   5         G�Name$ PasswordBox��5      $	��200��63   5      �� 5      -   5         ��Name$ LoginButton��5      $��2��6*   $��Login��67   $��Center=�6G   $
��0,10q�6d   $��75��6r   6}   �� 5      -   5        $ MessageTextBox��5      $��3��6.   $��10q�6;   " �� VerticalScrollBarVisibility$
 Auto=�6G   �� 5      -   5        $
��Send��5      $��3��6$   $��Right=�61   $��
0,10,10,10q�6M   $��75��6a   6l   �� 5!      -   5         ��Name$ ServerResponseTextBlock��5!      $��4��69   $��Center=�6F   $��Center=�6c   $
��Wrap=�6~   5"      5#      5$      