   M S B A M L   `   `   `  ����B  >loginDb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:loginDb.ViewloginDb.View  5      7 clr-namespace:loginDb.ConvertersloginDb.Converters  5      7 clr-namespace:loginDb.ViewModelsloginDb.ViewModels  5          loginDb.View.HomeView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:loginDb.View     5      7
converters clr-namespace:loginDb.Converters     5      X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  6B   1
viewmodels clr-namespace:loginDb.ViewModels  5      -   5          � 	Resources  5      *   $loginDb.Converters.IdToNameConverter   idToNameConverter��%   &	          5   
   6'   5      .��5      ��  �� CornerRadius$ 12��6   ��5   
   �� 5       �� ImageSource$ /Images/screen.jpg��6    j� Stretch$
 None=�6:   ._�5   
   �� $ 10��6   $	��0.1q�5   	    J� Opacity$	 0.9Q�5      ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5      �   winBorderColor1 � Color# [ 6#    � Offset$ 0Q�6L   � 5        winBorderColor2# [ 6#   $
 0.75Q�6L   � 5        winBorderColor3# [ 6#   $ 1Q�6L   5      ��5      �� 5       $	 0,1&�6&   $	 1,0&�67   .��5!      �   secondaryBackColor1# [ 6#   $ 1Q�6P   � 5"        secondaryBackColor2# [ 6#   $ 0Q�6P   5#      ._�5%      �� $��Center=�6   $��Center=�66   $	��400��6Q   .+�5&      �� $��Calibri)�68    
 color1#���  6M   $��36(�6s   $
��Bold"�6�   $	��480��6�   $
��Left=�6�   ��6   �� *DisplayName+6�   �� 5'      	 �� Orientation$	 
Horizontal=�6   .+�5(      �� $��	You have ��6   $��Calibri)�60   #���  6E   $��30(�6k   $��Regular"�6y   $
��Auto��6�   $
��Left=�6�   �� 5)      $��Calibri)�64   #���  6I   $��30(�6o   $��Regular"�6}   $
��Auto��6�   $
��Left=�6�   ��6   �� *Num+6�   �� 5*      $�� meetings for today.��6   $��Calibri)�6;   #���  6P   $��30(�6v   $��Regular"�6�   $
��Auto��6�   $
��Left=�6�   5,      �� 5-      $��Have a great day!��6   $��Calibri)�64   #���  6I   $��30(�6o   $��Regular"�6}   $	��567��6�   $
��Left=�6�   &   System.Windows.Controls.DataGrid  5.      -   5        
  Name$
 datagrid��5.      $
��Auto=�6�   $��0,30,0,0q�5/      $	��300��6*   $��0q�66      GridLinesVisibility$
 None=�50         
IsReadOnly .  J� IsHitTestVisible .    AutoGenerateColumns .  
������    AlternatingRowBackground �#0A003A �� AlternationCount$ 2��52   :      RowBackground
 ����    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ 80 53      $
��Left=�6(   ��5.   -   �� *LstMeetings+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=�  54       �� Color��%�   (��       55   *   * SystemColors.HighlightBrushKey+)(�� %     56   *   *SystemColors.ControlBrushKey+)�� 55      $ Transparent��6\   �� 56      $ Transparent��6Z   57         ColumnHeaderStyle 58      �� 59       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6    .�5:      ��  �� Property � �� �� Value# [ 6;   �� 5;       � ��  
panelColor# �  6;   �� 5<       � ��$ 	10,5,10,5q�68   �� 5=       � ��$ 
Montserrat)�6;   �� 5>       � ��$ DemiBold"�6;   �� 5?       � ��$ 17(�69   5@         	CellStyle 5B      �� 5C      *  $System.Windows.Controls.DataGridCell"  6    .�5D      ��  � ��  titleColor2# �  6;   �� 5E       � ��$ 15(�69   �� 5F       � ��$ Stretch=�6K   �� 5G       � ��$ 
10,10,10,0q�68   �� 5H       � ��$ 10,10,10,10q�67   5I         RowStyle 5K      �� 5L      )  #System.Windows.Controls.DataGridRow"  6     �� Triggers 5M      P� 5N   "    P� Property �@J�IsMouseOver P� Value . . �5O   &   ��  � ��# [ 6C   �� 5P   &    � ��$
 Bold"�6C   �� 5Q   &    � ��$
 Bold"�6C   5R   #   5T         Columns 5W      0  *System.Windows.Controls.DataGridTextColumn  5X      ,  &System.Windows.Controls.DataGridColumn    Header$	  No.��6-   1	  +System.Windows.Controls.DataGridBoundColumn! 	  Binding! 6:   �� *Number+  5Y      $
  Name��6-   ! 6;   �� *
ClientId+" �� ConverterParameter$" Client��# �� 	Converter## [    5Z      $
  Hour��6-   ! 6;   �� *Date+$ �� StringFormat$$ 	{0:HH:mm}��5\      5]      5_      5`      5a      