   M S B A M L   `   `   `  ����B  >loginDb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:loginDb.ViewloginDb.View  5   	   7 clr-namespace:loginDb.ConvertersloginDb.Converters  62   7 clr-namespace:loginDb.ViewModelsloginDb.ViewModels  5   	   &     loginDb.View.AddOrEditClientView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:loginDb.View     5   	   3local1 clr-namespace:loginDb.Converters     62   7
viewmodels clr-namespace:loginDb.ViewModels     5   	   -   5        $	��350��5	   
     � WindowStartupLocation$  CenterScreen=�5
   	    � WindowStyle$
 None=�5   	    � Topmost .  � 
ResizeMode$ 	CanResize=�5   	   
������  � AllowsTransparency .  � 	Resources 5         BooleanToVisibility&    loginDb.Converters.ModeConverter  ModeConverter2   ,loginDb.Converters.ModeToVisibilityConverter  ModeToVisibilityConverter��%W   &	        &	      &	 &     �� 5   
   6'     5   
   6     5   
   6+   5      y�5      �� 5   
    �� Path$ IsViewVisible�6    �� Mode$ TwoWay=�6'    �� 	Converter# [  65   .��5,      �� 	 �� CornerRadius$	 12��6   $��Stretch=�6   $��Center=�6=   ��5-   
   �� 5.      
 �� ImageSource$
 /Images/screen.jpg��6    j� Stretch$
 None=�6:   ._�51   
   �� $	 10��6   $��1q�52       J� Opacity$	 0.9Q�53      ��54      �� 55       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��56      �   winBorderColor1 � Color# [ 6#    � Offset$ 0Q�6L   � 57        winBorderColor2# [ 6#   $
 0.75Q�6L   � 58        winBorderColor3# [ 6#   $ 1Q�6L   5:      ��5=      �� 5>      $	 0,1&�6&   $	 1,0&�67   .��5?      �   primaryBackColor1# [ 6#   $ 0Q�6N   � 5@        primaryBackColor2# [ 6#   $
 0.75Q�6N   5A      ._�5C      �  � RowDefinitions 5D      �� 5E      $��30 �6$   �� 5F      .+�5H      �  � ColumnDefinitions 5I      �� 5J      �� 5K      $��25 �6+   �� 5L      $��25 �6+   �� 5M      $��5 �6+   .+�5O      ��   titleColor3#��[ 5P       $��10(�6K   $��
Montserrat)�6Y   $��0��5Q       $��Center=�60   $��10,0,0,0q�6K   ��5O   $   �� $ CurrentMode�# [  �� ConverterParameter$ CLIENT��5Q   K   �� 5R      -   5         ��Name$ btnClose��5R      $��0q�5S      $��X��6-   
�������$��12(�5T   ,   $��
Montserrat)�6:    � Cursor$
 Hand��5U      $��2��5V      ��5X      �� 5Y       �� 
TargetType" ��6$   .�5Z   "   ��  �� Property � �� 
	 color2 �� Value# [	 6?    �� Triggers 5[   "   P� 5\   &    P� Property �@J�IsMouseOver P� Value . . �5]   *   ��  � �� �	#FFAF2B9A6G   5^   '   5`      ��5b      �� 5c       �� 
TargetType" ��6.   .R�5d   "   �� $��18��6)   $��18��64   $	 9��6@   #��z��6Q   ._�5e   &   �� $��Center=�67   $��Center=�6R   5g   #   5h      5j      5k      �� 5l      $��2��6   .+�5m      �� $��Id��6   $	��Top=�6*   $��Center=�6B   #��[ 6_   �� 5n      $��25��6   $	��200��6>   $	��Top=�6�   $��Center=�6�   #��[ 6�   ��6*   �� *Id+y�6J   �� *CurrentMode+# [ $	 Add��6�   �� 5o      $��25��6   $ No��5p       �� 
IsReadOnly . $	��200��6<   $	��Top=�6H   $��Center=�6`   #��[ 6}   ��5o   *   �� *SelectedClient.Id+y�6M   �� *CurrentMode+# [ $
 Edit��5p   }   �� 5q      $
��Name��6   $	��Top=�6,   $��Center=�6D   #��[ 6a   �� 5r      $��25��6   $	��200��6�   $	��Top=�6�   $��Center=�6�   #��[ 6�   ��6*   �� *Name+y�6@   �� *CurrentMode+# [ $	 Add��6�   �� 5s      $��25��6   $	��200��6�   $	��Top=�6�   $��Center=�6�   #��[ 6  ��6*   �� *SelectedClient.Cname+y�6P   �� *CurrentMode+# [ $
 Edit��6  �� 5t      $��
Birth Date��6   $	��Top=�62   $��Center=�6J   #��[ 6g   (  "System.Windows.Controls.DatePicker  5u      $��25��6!   $	��200��6�   $	��Top=�6�   $��Center=�6�   #��[ 6     SelectedDate 6-   �� *	BirthDate+y�6P   �� *CurrentMode+# [ $	 Add��6    5v      $��25��6!   $	��200��6�   $	��Top=�6�   $��Center=�6�   #��[ 6   6-   �� *SelectedClient.BirthDate+y�6_   �� *CurrentMode+# [ $
 Edit��6  �� 5w      $��Phone��6   $	��Top=�6-   $��Center=�6E   #��[ 6b   �� 5x      $��25��6   $	��200��6�   $	��Top=�6�   $��Center=�6�   #��[ 6�   ��6*   �� *Phone+y�6A   �� *CurrentMode+# [ $	 Add��6�   �� 5y      $��25��6   $	��200��6�   $	��Top=�6�   $��Center=�6�   #��[ 6  ��6*   �� *SelectedClient.Phone+y�6P   �� *CurrentMode+# [ $
 Edit��6  �� 5z      $��Email��6   $	��Top=�6-   $��Center=�6E   #��[ 6b   �� 5{      $��25��6   $	��200��6�   $	��Top=�6�   $��Center=�6�   #��[ 6�   ��6*   �� *Email+y�6A   �� *CurrentMode+# [ $	 Add��6�   �� 5|      $��25��6   $	��200��6�   $	��Top=�6�   $��Center=�6�   #��[ 6  ��6*   �� *SelectedClient.Email+y�6P   �� *CurrentMode+# [ $
 Edit��6  �� 5}      $��Payer��6   $	��Top=�6-   $��Center=�6E   #��[ 6b   �� 5~       �� SelectedValuePath$ Id��5        �� DisplayMemberPath$  Pname��5�      $��25��5�      $	��200��6%   $��Center=�61   $��Center=�6L    
 panelActiveColor#��[
 5�      ! �� 
IsReadOnly! . ��5~      �� *Payers+" �� SelectedValue" 5�      �� *
SpePayerId+y�5�      �� *CurrentMode+# [ $	 Add��5�   H   �� 5�      $ Id��6   $��25��5�      $	��200��6%   $��Center=�61   $��Center=�6L   #��[
 5�      ! . $  Pname��6Z   ��5�   6   �� *Payers+" 6U   �� *
SpePayerId+$ Default=�y�5�      �� *CurrentMode+# [ $
 Edit��5�   Z   �� 5�      ���#D7596D$��13(�5�      $��Medium"�5�      $��
Montserrat)�5�      $��30,10,30,10q�5�      $
��Wrap=�5�      ��5�       �� *ErrorMessage+# �� UpdateSourceTrigger$# PropertyChanged=�5�      �� 5�      $��13(�5�      $��
Montserrat)�6'   $��0,0,0,20q�6?   $
 Hand��6Q   $��0q�6_   
�������$	��110��6�   ��5�      �� *AorECommand+��6=   �� $ CurrentMode�# [ $ Client����5�      �� 5�      " ��6$   .�5�   "   ��  � ��# [	 6?   �� 5�   "    � �� 5�   &   �� 5�   *   " ��6:   .R�5�   .   �� $��30��65   $	 15��5�   )   #��z��5�   )   ._�5�   2   �� $��Center=�6C   $��Center=�5�   ;   5�   /   5�   +   5�   #    5�   "   P� 5�   &    �@J�IsMouseOver . . �5�   *   ��  � �� �#836EFB6G   5�   '   5�      5�      5�      5�      5�      5�      5�      