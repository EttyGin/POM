   M S B A M L   `   `   `  ����B  >loginDb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:loginDb.ViewloginDb.View  5      7 clr-namespace:loginDb.ConvertersloginDb.Converters  5      7 clr-namespace:loginDb.ViewModelsloginDb.ViewModels  5          loginDb.View.ReportsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:loginDb.View     5      7
converters clr-namespace:loginDb.Converters     5      X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  6B   1
viewmodels clr-namespace:loginDb.ViewModels  5      -   5          � 	Resources  5      0   *loginDb.Converters.TextToFontSizeConverter   TextToFontSizeConverter1   +loginDb.Converters.BooleanToStatusConverter  BooleanToTrueConverter   BooleanToVisibilityConverter��%W   &	        &	      &	 &       5   
   6-     5   
   6.   �� 5   
   6'   5      .��5      �� $
��Auto=�6   $��Disabled=�66   .��5   
   �� $��1��6    �� CornerRadius$ 10��5       �� Padding$ 10q�5      ��5      �� 5       �� 
StartPoint$	 1,1&�6&    �� EndPoint$	 0,0&�67   .��5      �   secondaryBackColor1 � Color# [ 6#    � Offset$ 0Q�6P   � 5        secondaryBackColor2# [ 6#   $ 1Q�6P   5      ._�5      �� .+�5      9� $�� General��6   $��25(�6-   $��Calibri)�6;    
 color6#��[ 6P     
panelColor#��[ 6u   $��1.5,5,1.5,1.5q�6�   $	��Top=�6�   .��5      � $	��Top=�6   ���	#FF23105C  5         shakeAnimation��%!   &	       �� 5!      5"      5#       � ColumnDefinitions 5$      �� 5%      $��* �6/   �� 5&      $��* �6/   �� 5'      $��* �6/   �� 5(      $��* �6/    � RowDefinitions 5*      �� 5+      $	��120 �6,   �� 5,      $��40 �6,   .+�5.      A� $��0��6"     reportsAnimation#��[ 62    
	 color7#��[	 6]   $	��110��6|   $	��100��6�   $��0,10,0,0q�6�   �� 5/      $��0��6$   $��Heavy"�6S   $��Calibri)�6f   	 �� TextAlignment$	 Center=�6{   $��Center=�6�   $��Center=�6�   $��0,0,0,-5q�50   t   ��5/   4   �� *NumOfClients+��50       �� *
Receivable+
 �� 	Converter#
 [  6t   �� 51      $��1��6$   $��0��61   $��Clients��6A   $��30(�6P   $	 Center=�6^   #��[	 6u   A� 53      $��1��6"   #��[ 62    

 color8#��[
 6]   $	��110��6|   $	��100��6�   $��0,10,0,0q�6�   �� 54      $��1��6$   $��Heavy"�6T   $��Calibri)�6g   $	 Center=�6|   $��Center=�6�   $��Center=�6�   $��0,0,0,-5q�55   t   ��54   4   �� *NumOfMeetings+��55       �� *
Receivable+#
 [  6t   �� 56      $��1��6$   $��1��61   $��Meetings��6A   $��30(�6Q   $	 Center=�6_   #��[
 6v   A� 58      $��2��6"   #��[ 62    
 color9#��[ 6]   $	��110��6|   $	��100��6�   $��0,10,0,0q�6�   �� 59      $��2��6$   $��Heavy"�6M   $��Calibri)�6`   $	 Center=�6u   $��Center=�6�   $��Center=�6�   $��0,0,0,-5q�5:   t   ��59   4   �� *	Revenue+��5:       �� *
Receivable+#
 [  6t   �� 5;      $��2��6$   $	��₪��64   $��20(�6=   $��Heavy"�6K   $	 Center=�6^   $��Bottom=�6u   $��0,0,0,10q�6�   �� 5<      $��1��6$   $��2��61   $��Revenue��6A   $��28(�6P   $	 Center=�6^   #��[ 6u   A� 5>      $��3��6"   #��[ 62     color10#��[ 6]   $	��110��6}   $	��100��6�   $��0,10,0,0q�6�   �� 5?      -   5         ��Name$ ReceivableText��5?   $   $��3��6<   $��Heavy"�6h   $��Calibri)�6{   $	 Center=�6�   $��Center=�6�   $��Center=�6�   $��0,0,0,-5q�5@   s   ��5?   L   �� *
Receivable+��5@      �� *
Receivable+#
 [  5A      �� 5C      $��3��6$   $	��₪��64   $��20(�6=   $��Heavy"�6K   $��Calibri)�6^   $	 Center=�6t   $��Bottom=�6�   $��0,0,0,10q�6�   �� 5D      $��1��6$   $��3��61   $��
Receivable��6A   $��29(�6S   $��Calibri)�6a   $	 Center=�6v   #��[ 6�   5G      5H      9� 5I      $�� Clients��6    
 color2#��[ 6-   $��25(�6R   $��Calibri)�6`   $
��Auto��6u   #��[ 6�   $��1.5,5,1.5,1.5q�6�   $	��Top=�6�   .��5J      �� $��1.5,5,1.5,1.5q�6}   ��6#   �� *FilteredClients+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���5K      �� 5L      .R�5M   "   � #��[ 6,   5N      ��5P      �� 5Q      .R�5}   "   �� $��10q�6-   .+�5~   &   � .+�5   *   ��   reportsBorder#��[ 62   $ 30��6[   $	��120��6m   $	��130��6y   ��5�   .   
� 5�   2    
� Center$ 0.5,0.5&�6F    
� RadiusX$	 0.5Q�6W    
� RadiusY$	 0.5Q�6e   .��5�   6   � $ #784DFD��6C   $ 0Q�6S   � 5�   6   $ 	#FF4726AB��6C   $ 1Q�6U   5�   3   5�   +   � 5�   *   $	��110��6/   $	��130��6;   $��0,0,0,5q�6H    5�   .   �� 5�   2   $
��0.7* �6@   �� 5�   2   $��* �6@   �� 5�   2   $
��0.7* �6@   �� 5�   2   $��* �6@   .+�5�   .   �� $��0��64   $��18(�6A   $��	0,0,0,-10q�6O   $��	Meetings:��6b     titleColor2#���  6v   $��Center=�6�   $	��Top=�6�   �� 5�   .   $��1��64   $��25(�6A   $��Medium"�6P   $��
0,-5,0,-10q�6e   #���  6�   $��Stretch=�6�   $��Center=�6�   ��6y   �� *MeetingsAmount+6�   �� 5�   .   $��2��64   $��18(�6A   $��
0,-5,0,-10q�6O   $��Debt:��6c   #���  6s   $��Center=�6�   $��Stretch=�6�   �� 5�   .   $��3��64   $��25(�6A   $��Medium"�6P   #���  6}   $��Bottom=�6�   $��Center=�6�   ��6d   �� *Debt+6�   5�   +   5�   '   �� 5�   &   #��[ 6F   $��Heavy"�6k   $��Calibri)�6~   $	 Center=�6�   $	��120��6�   $��22(�5�   )   $��0,0,0,5q�67   ��5�   0   �� *Name+5�   7   5�   #   5�      5�      5�      5�      5�      5�      5�      