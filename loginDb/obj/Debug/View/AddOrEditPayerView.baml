   M S B A M L   `   `   `  ����B  >loginDb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:loginDb.ViewloginDb.View  5   	   7 clr-namespace:loginDb.ConvertersloginDb.Converters  62   7 clr-namespace:loginDb.ViewModelsloginDb.ViewModels  5   	   %    loginDb.View.AddOrEditPayerView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:loginDb.View     5   	   3local1 clr-namespace:loginDb.Converters     62   7
viewmodels clr-namespace:loginDb.ViewModels     5   	   -   5        $	��350��5	   
     � WindowStartupLocation$  CenterScreen=�5
   	    � WindowStyle$
 None=�5   	    � Topmost .  � 
ResizeMode$ 	CanResize=�5   	   
������  � AllowsTransparency .  � 	Resources 5         BooleanToVisibility&    loginDb.Converters.ModeConverter  ModeConverter2   ,loginDb.Converters.ModeToVisibilityConverter  ModeToVisibilityConverter��%W   &	        &	      &	 &     �� 5   
   6'     5   
   6     5   
   6+   5      y�5      �� 5   
    �� Path$ IsViewVisible�6    �� Mode$ TwoWay=�6'    �� 	Converter# [  65   .��5      �� 	 �� CornerRadius$	 12��6   $��Stretch=�6   $��Center=�6=   ��5   
   �� 5      
 �� ImageSource$
 /Images/screen.jpg��6    j� Stretch$
 None=�6:   ._�5"   
   �� $	 10��6   $��1q�5#       J� Opacity$	 0.9Q�5$      ��5%      �� 5&       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5'      �   winBorderColor1 � Color# [ 6#    � Offset$ 0Q�6L   � 5(        winBorderColor2# [ 6#   $
 0.75Q�6L   � 5)        winBorderColor3# [ 6#   $ 1Q�6L   5+      ��5.      �� 5/      $	 0,1&�6&   $	 1,0&�67   .��50      �   primaryBackColor1# [ 6#   $ 0Q�6N   � 51        primaryBackColor2# [ 6#   $
 0.75Q�6N   52      ._�54      �  � RowDefinitions 55      �� 56      $��30 �6$   �� 57      .+�59      �  � ColumnDefinitions 5:      �� 5;      �� 5<      $��25 �6+   �� 5=      $��25 �6+   �� 5>      $��5 �6+   .+�5@      ��   titleColor3#��[ 5A       $��10(�6K   $��
Montserrat)�6Y   $��0��5B       $��Center=�60   $��10,0,0,0q�6K   ��5@   $   �� $ CurrentMode�# [  �� ConverterParameter$ PAYER��5B   K   �� 5C      -   5         ��Name$ btnClose��5C      $��0q�5D      $��X��6-   
�������$��12(�5E   ,   $��
Montserrat)�6:    � Cursor$
 Hand��5F      $��2��5G      ��5I      �� 5J       �� 
TargetType" ��6$   .�5K   "   ��  �� Property � �� 
	 color4 �� Value# [	 6?    �� Triggers 5L   "   P� 5M   &    P� Property �@J�IsMouseOver P� Value . . �5N   *   ��  � �� �	#FFAF2B9A6G   5O   '   5Q      ��5S      �� 5T       �� 
TargetType" ��6.   .R�5U   "   �� $��18��6)   $��18��64   $	 9��6@   #��z��6Q   ._�5V   &   �� $��Center=�67   $��Center=�6R   5X   #   5Y      5[      5\      �� 5]      $��2��6   .+�5^      �� $
��Name��6   $	��Top=�6,   $��Center=�6D   #��[ 6a   �� 5_      $��25��6   $	��200��6�   $	��Top=�6�   $��Center=�6�   #��[ 6�   ��6*   �� *Name+y�6@   �� *CurrentMode+# [ $	 Add��6�   �� 5`      $��25��6   $	��200��6�   $	��Top=�6�   $��Center=�6�   #��[ 6  ��6*   �� *SelectedPayer.Pname+y�6O   �� *CurrentMode+# [ $
 Edit��6  �� 5a      $��Contact Name��6   $	��Top=�64   $��Center=�6L   #��[ 6i   �� 5b      $��25��6   $	��200��6�   $	��Top=�6�   $��Center=�6�   #��[ 6�   ��6*   �� *CName+y�6A   �� *CurrentMode+# [ $	 Add��6�   �� 5c      $��25��6   $	��200��6�   $	��Top=�6�   $��Center=�6�   #��[ 6	  ��6*   �� *SelectedPayer.ContactName+y�6U   �� *CurrentMode+# [ $
 Edit��6	  �� 5d      $��Contact Email��6   $	��Top=�65   $��Center=�6M   #��[ 6j   �� 5e      $��25��6   $	��200��6�   $	��Top=�6�   $��Center=�6�   #��[ 6�   ��6*   �� *CEmail+y�6B   �� *CurrentMode+# [ $	 Add��6�   �� 5f      $��25��6   $	��200��6�   $	��Top=�6�   $��Center=�6�   #��[ 6
  ��6*   �� *SelectedPayer.ContactEmail+y�6V   �� *CurrentMode+# [ $
 Edit��6
  �� 5g      $��Payment��6   $	��Top=�6/   $��Center=�6G   #��[ 6d   �� 5h      $��25��6   $	��200��6�   $	��Top=�6�   $��Center=�6�   #��[ 6�   ��6*   �� *	Payment+y�6C   �� *CurrentMode+# [ $	 Add��6�   �� 5i      $��25��6   $	��200��6�   $	��Top=�6�   $��Center=�6�   #��[ 6
  ��6*   �� *SelectedPayer.TotalPayment+y�6V   �� *CurrentMode+# [ $
 Edit��6
  �� 5l      ���#D7596D$��13(�5n      $��Medium"�5o      $��
Montserrat)�5p      $��30,10,30,10q�5q      $
��Wrap=�5r      ��5l       �� *ErrorMessage+ �� UpdateSourceTrigger$ PropertyChanged=�5r      �� 5t      $��13(�5u      $��
Montserrat)�6'   $��0,0,0,20q�6?   $
 Hand��6Q   $��0q�6_   
�������$	��110��6�   ��5t      �� *AorECommand+��6=   �� $ CurrentMode�# [ $ Payer����5v      �� 5w      " ��6$   .�5x   "   ��  � ��# [	 6?   �� 5y   "    � �� 5z   &   �� 5{   *   " ��6:   .R�5|   .   �� $��30��65   $	 15��5}   )   #��z��5~   )   ._�5   2   �� $��Center=�6C   $��Center=�5�   ;   5�   /   5�   +   5�   #    5�   "   P� 5�   &    �@J�IsMouseOver . . �5�   *   ��  � �� �	#FFAF2B9A6G   5�   '   5�      5�      5�      5�      5�      5�      5�      