   M S B A M L   `   `   `  ����  MoneyLoverDesktop"    MoneyLoverDesktop.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
MainWindow��5   	   $	��552��6   $
��1070��6)   .��5      �  � RowDefinitions 5   
   �� 5      $
��193* �6   �� 5      $
��328* �6   .+�5
   
   �� -   5        $��	btnReport��5
   g   $��Generate Report��6   $��23��6+   $
��Left=�67   $��927,295,0,0q�6R   $	��Top=�6x   $	��115��6�   $��1��6�   &   System.Windows.Controls.Calendar  5   
   -   5        $��	beginDate��5   O   $	��170��6   $
��Left=�6    $��
648,10,0,0q�6;   $	��Top=�6`   $	��180��6x      IsTodayHighlighted . 6�     5   
   -   5        $��endDate��5   O   $	��170��6   $
��Left=�6    $��
853,10,0,0q�6;   $	��Top=�6^   $	��180��6v   6�   �� 5   
   $��Selected date range:��6   $
��Left=�6/   $��
115,52,0,0q�6J   $	��Top=�6^   $	��119��6v   �� 5   
   $��01/01/2001 to 01/01/2001��6   $
��Left=�63   $��
234,52,0,0q�6N   $	��Top=�6b   �� 5   
   -   5         ��Name$ tbxSourceFileLocation��5      $
��Left=�61   $��23��6L   $��	62,10,0,0q�6X    �� TextWrapping$
 Wrap=�6k   $�� ��6   $	��Top=�6�   $	��449��6�   {�.  6�   �� 5   
   $��Source:��6   $
��Left=�6"   $��10,7,0,0q�6=   $	��Top=�6O   $��52��6g   �� 5   
   $��Description:��6   $
��Left=�6'   $��
42,109,0,0q�6B   $	��Top=�6V   �� 5   
   $��	Category:��6   $
��Left=�6$   $��
42,135,0,0q�6?   $	��Top=�6S   �� 5   
   $��Amount:��6   $
��Left=�6"   $��
42,161,0,0q�6=   $	��Top=�6Q     5   
   -   5          Name$ dtRecord��5      $
��Left=�6%   $��	42,20,0,0q�6@   $	��Top=�6S   $��1��6k   �� 5   
   $��Date:��6   $
��Left=�6!   $��
42,187,0,0q�6<   $	��Top=�6P   $��2��6h   �� 5   
   -   5         ��Name$ btnAdd��5      $	��Add��6!   $
��Left=�6/   $��221,206,0,0q�6J   $��1��6_   $	��Top=�6l   $��75��6�   6�   �� 5   
   -   5        $ tbxDescription��5      $
��Left=�6*   $��23��6E   $��143,112,0,0q�6Q   $
 Wrap=�6f   $��Description��6z   $	��Top=�6�   $	��216��6�   �� 5   
   -   5        $ tbxCategory��5      $
��Left=�6'   $��23��6B   $��143,138,0,0q�6N   $
 Wrap=�6c   $��Category��6w   $	��Top=�6�   $	��216��6�   �� 5   
   -	   5        $ 	tbxAmount��5      $
��Left=�6%   $��23��6@   $��143,164,0,0q�6L   $
 Wrap=�6a   $��Amount��6u   $	��Top=�6�   $	��216��6�   �� 5   
   -
   5        $ btnLoad��5      $
��Load��6"   $
��Left=�61   $��828,295,0,0q�6L   $��1��6a   $	��Top=�6n   $��75��6�   6�   5      5      