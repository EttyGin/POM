   M S B A M L   `   `   `  ����B  >loginDb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:loginDb.ViewloginDb.View  5   	   7 clr-namespace:loginDb.ViewModelsloginDb.ViewModels  5   	   ?$clr-namespace:loginDb.CustomControlsloginDb.CustomControls  5   	       loginDb.View.LoginView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:loginDb.View     5   	   6	viewModel clr-namespace:loginDb.ViewModels     5   	   ?customcontrols$clr-namespace:loginDb.CustomControls     5   	   -   5          � Title$  	LoginView��5
   	   $	��550��6   $	��800��6(    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   
������  � AllowsTransparency .  � DataContext 5      '   !loginDb.ViewModels.LoginViewModel  5   
    � 	Resources 5         BooleanToVisibility��%   &	        �� 5   
   6'   5      y�5      �� 5   
    �� Path$ IsViewVisible�6    �� Mode$ TwoWay=�6'   	 �� 	Converter#	 [  65   .��5!      �� 
 �� CornerRadius$
 12��6   ��5"   
   �� 5#       �� ImageSource$ /Images/screen.jpg��6    j� Stretch$
 None=�6:   ._�5&   
   �� $
 10��6   $��1q�5'       J� Opacity$	 0.9Q�5(      ��5)      �� 5*       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5+      �   winBorderColor1 � Color# [ 6#    � Offset$ 0Q�6L   � 5,        winBorderColor2# [ 6#   $
 0.75Q�6L   � 5-        winBorderColor3# [ 6#   $ 1Q�6L   5/      ��52      �� 53      $	 0,1&�6&   $	 1,0&�67   .��54      �   primaryBackColor1# [ 6#   $ 0Q�6N   � 55        primaryBackColor2# [ 6#   $
 0.75Q�6N   56      ._�59      �  � RowDefinitions 5:      �� 5;      $��30 �6$   �� 5<      .+�5>      �  � ColumnDefinitions 5?      �� 5@      �� 5A      $��25 �6+   �� 5B      $��25 �6+   �� 5C      $��5 �6+   .+�5E      �� $��LOG IN��6    
�������$��10(�6D   $��
Montserrat)�6R   $��0��5F       $��Center=�5G       $��10,0,0,0q�6;   �� 5H      -   5         ��Name$ btnMinimize��5H      $��0q�5I      $��-��6.   
�������$��16(�5J   ,   $��
Montserrat)�6:    � Cursor$
 Hand��5K      $��1��5L      ��5N      �� 5O       �� 
TargetType" ��6$   .�5P   "   ��  �� Property � �� �� Value �#28AEED6?    �� Triggers 5Q   "   P� 5R   &    P� Property �@J�IsMouseOver P� Value . . �5S   *   ��  � �� �#278BEF6G   5T   '   5V      ��5X      �� 5Y       �� 
TargetType" ��6.   .R�5Z   "   �� $��18��6)   $��18��64   $
 9��6@   #��z��6Q   ._�5[   &   �� $��Center=�67   $��Center=�6R   5]   #   5^      5`      �� 5a      -   5        $ btnClose��5a      $��0q�5b      $��X��6-   
�������$��12(�5c   ,   $��
Montserrat)�6:   $
 Hand��5d      $��2��5e      ��5g      �� 5h      " ��6$   .�5i   "   ��  � �� �#da34ae6?    5j   "   P� 5k   &    �@J�IsMouseOver . . �5l   *   ��  � �� �	#FFAF2B9A6G   5m   '   5o      ��5q      �� 5r      " ��6.   .R�5s   "   �� $��18��6)   $��18��64   $
 9��6@   #��z��6Q   ._�5t   &   �� $��Center=�67   $��Center=�6R   5v   #   5w      5y      5z      �� 5{      $	��265��6   $��2��6)    �� Orientation$ Vertical=�66   $��0,35,0,0q�6M   .+�5|      �� $��/Images/logo.png��6   $��80��66   $��80��6A   $��0,0,0,5q�6M   �� 5}      $��Peace Of Mind��6    $��25(�65   $��
Montserrat)�6C   
�������$��Medium"�6n    �� TextAlignment$ Center=�6�   $��Center=�6�   �� 5~      $0��*Therapy  practice  management  made  easy.��6    $��13(�5       
�������$��
Montserrat)�6E   $��Medium"�6]   $��Center=�5�       $ Center=�6=   $��5,0,0,0q�6T   �� 5�      $��Username��6    $��12(�5�      
�������$��
Montserrat)�6=   $��Medium"�6U   $��0,35,0,0q�6i   �� 5�      -   5         ��Name$ txtUser��5�      $��13(�6n   $��
Montserrat)�6|   $��Medium"�6�   
�������  �� 
CaretBrush
  �����
�������$��25,0,0,0q�5�      $��0,0,0,1q�63   $��23��6M   $��Center=�6Y   $��0,5,0,0q�6{   ��5�   /   �� *
Username+! �� UpdateSourceTrigger$! PropertyChanged=�.��5�   �   ��5�      �� 5�      $ /Images/user.png��6)   $ Uniform=�6H   " j� 
AlignmentX$
" Left=�6Z   # �� Opacity$
# 0.85Q�6l   $ j� 
AlignmentY$$ Center=�6{   .��5�   .   5�      �� 5�      $��Password��6    $��12(�60   
�������$��
Montserrat)�6T   $��Medium"�6l   $��0,15,0,0q�6�   0   *loginDb.CustomControls.BindablePasswordBox  5�      $��23��5�   9   $��0,5,0,0q�6F   %   Password% 5�   9   �� *
Password+$ TwoWay=�$! PropertyChanged=�5�   Z   �� 5�      ���#D7596D$��12(�5�       $��Medium"�5�       $��
Montserrat)�5�       $��0,10,0,0q�5�       $
��Wrap=�5�       ��5�       �� *ErrorMessage+5�       �� 5�      -   5        $ btnLogin��5�      $��0q�5�      $��LOG IN��6.   
�������$��12(�5�   ,   $��
Montserrat)�6:   $
 Hand��5�      $��2��6'   $��0,50,0,0q�67   ��5�      �� *LoginCommand+��5�      �� 5�      " ��6$   .�5�   "   ��  � �� �#462AD86?    5�   "   P� 5�   &    �@J�IsMouseOver . . �5�   *   ��  � �� �#28AEED6G   5�   '   5�      ��5�      �� 5�      " ��6.   .R�5�   "   �� $	��150��6)   $��40��65   $
 20��6A   #��z��6S   ._�5�   &   �� $��Center=�67   $��Center=�6R   5�   #   5�      5�      5�      5�      5�      5�      5�      