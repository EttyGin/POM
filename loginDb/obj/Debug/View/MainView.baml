   M S B A M L   `   `   `  ����B  >loginDb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:loginDb.ViewloginDb.View  5   	   ?$clr-namespace:loginDb.CustomControlsloginDb.CustomControls  5   	   7 clr-namespace:loginDb.ViewModelsloginDb.ViewModels  5   	       loginDb.View.MainView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:loginDb.View     5   	   ?customcontrols$clr-namespace:loginDb.CustomControls     5   	   6	viewModel clr-namespace:loginDb.ViewModels     5   	   X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5	   	     � Title$  MainWindowView��5   	   $	��450��6    $	��800��6-    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � AllowsTransparency . 
������  � DataContext 5      &    loginDb.ViewModels.MainViewModel  5   
    � 	Resources 5       �� DataType&    loginDb.ViewModels.HomeViewModel   loginDb.View.HomeView   loginDb.View.MainView)   #loginDb.ViewModels.ClientsViewModel   loginDb.View.ClientsView*   $loginDb.ViewModels.MeetingsViewModel   loginDb.View.MeetingsView(	   "loginDb.ViewModels.PayersViewModel
   loginDb.View.PayersView*   $loginDb.ViewModels.PaymentsViewModel   loginDb.View.PaymentsView)   #loginDb.ViewModels.ReportsViewModel   loginDb.View.ReportsView   BooleanToVisibility��%*  (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)(�� �     5      *, +)(�� �     5!      *,	 +)(�� �     5$      *, +)(�� ,    5'      *, +)&	  ^    �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5       �� 5!   
   " 	 6   .R�5"      
  5#      �� 5$   
   "  6   .R�5%        5&      �� 5'   
   "  6   .R�5(        5)      �� 5*   
   6'   5+      y�5,      �� 5-   
    �� Path$ IsViewVisible�6    �� Mode$ TwoWay=�6'   	 �� 	Converter#	 [  65   .��54      �� 
 �� CornerRadius$
 10��6   $��1q�6   ��55   
   �� 56       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��57      �   winBorderColor1 � Color# [ 6    � Offset$ 0Q�6H   � 58        winBorderColor2# [ 6   $
 0.75Q�6H   � 59        winBorderColor3# [ 6   $ 1Q�6H   5;      ._�5>   
   �  � ColumnDefinitions 5?      �� 5A      $��* �6#   �� 5C      $	��200 �6#   .+�5F      �� $
 	0,10,10,0��6   $��1��6.   ��5G      �� 5H      $	 1,1&�6*   $	 0,0&�6;   .��5I      �   secondaryBackColor1# [ 6'   $ 0Q�6T   � 5J        secondaryBackColor2# [ 6'   $ 1Q�6T   5K      ._�5N      �� .+�5P      ��  �� Orientation$ 
Horizontal=�6!   $��35��5Q   %   $��
15,25,0,40q�5R   %   .+�5T      �� $��Peace Of Mind��6$     titleColor2#��[ 5U   ,   $��20(�5V   ,   $��
Montserrat)�5W   ,   $��Medium"�5X   ,   $��Center=�5Y   ,   $��0,5,10,0q�5Z   ,   �� 5[      $��/Images/logo.png��6    $��30��6:   5\      	� 5^        
menuButton#��[ 6"    
 color1
 � Tag# [ 5_   "    d� 	IsChecked$
 TrueY�5`   "   ��5a   "   �� *ShowHomeViewCommand+.��5b      �� $ 
Horizontal=�6%   .+�5c      �� $��	Dashboard��6(    	 menuButtonText#��[	 69   !  FontAwesome.Sharp.IconImage  5d      �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$
 Home=�6+    
 menuButtonIcon#��[
 67   5e      5f      	� 5g      #��[ 6"    
 color2# [ 5h   "   ��5i   "   �� *ShowClientsViewCommand+.��5j      �� $ 
Horizontal=�6%   .+�5k      �� $��Clients��6(   #��[	 67     5l      $ 	UserGroup=�6+   #��[
 6<   5n      5o      	� 5p      #��[ 6"    
 color3# [ 6F   ��5q      �� *ShowMeetingsViewCommand+��6F   �� .��5r      �� $ 
Horizontal=�6%   .+�5s      �� $��Meetings��6(   #��[	 68     5t      $ Couch=�6+   #��[
 68   5u      5v      	� 5w      #��[ 6"    
 color4# [ 6F   ��5x      �� *ShowPayersViewCommand+.��5y      �� $ 
Horizontal=�6%   .+�5z      �� $��Payers��6(   #��[	 66     5{      $ HandHoldingHeart=�6+   #��[
 6C   5|      5}      	� 5~      #��[ 6"    
 color5# [ 6F   ��5      �� *ShowPaymentsViewCommand+.��5�      �� $ 
Horizontal=�6%   .+�5�      �� $��Payments��6(   #��[	 68     5�      $ 
CreditCard=�6+   #��[
 6=   5�      5�      	� 5�      #��[ 6"    
 color6# [ 6F   ��5�      �� *ShowReportsViewCommand+.��5�      �� $ 
Horizontal=�6%   .+�5�      �� $��Reports��6(   #��[	 67     5�      $ ChartPie=�6+   #��[
 6;    J� RenderTransformOrigin$ 	0.618,0.5&�6c   5�      5�      5�      5�      �� 5�      $
 	10,0,0,10��6   $��0��5�      ��5�      �� 5�      $	 0,0&�6*   $	 1,1&�6;   .��5�      �   primaryBackColor1# [ 6'   $ 0Q�6R   � 5�        primaryBackColor2# [ 6'   $ 1Q�6R   5�      ._�5�      �  � RowDefinitions 5�      �� 5�      $��30 �6(   �� 5�      $��35 �6(   �� 5�      $��* �6(   .+�5�      �� -   5         ��Name$ pnlControlBar��5�   !   $��0��5�   !   $ 
Horizontal=�5�   !   $��LeftToRight=�5�   !   
������ $��0,0,5,0q�5�   !   .+�5�      �� -   5         ��Name$ btnClose��5�   !     controlButton#��[ 5�   !   # [ 5�   !   .��5�        $ Xmark=�6+     controlButtonIcon#��[ 68   5�      �� 5�      -   5        $ btnMaximize��5�   !   #��[ 5�   !   # [ 5�   !   .��5�        $ Square=�6+   #��[ 69   5�      �� 5�      -   5        $ btnMinimize��5�   !   #��[ 5�   !    
 color8# [ 5�   !   .��5�        $ WindowMinimize=�6+   $��12��6A   #��[ 6L   5�      5�      � 5�      $��1��6    5�      �� 5�      �� 5�      .+�5�      �� $��0��6%   $ 
Horizontal=�5�   %   $��LeftToRight=�5�   %   $��Center=�5�   %   $��5,0,0,0q�5�   %   .+�5�      ��   
iconButton#��[ 6%   # [ 5�   %   .��5�   "     $ Clock=�6/     iconButtonIcon#��[ 6<   5�      �� 5�      #��[ 6%   # [ 5�   #   .��5�   "     $ Envelope=�6/   #��[ 6?   5�      �� 5�      #��[ 6%   # [ 5�   	   .��5�   "     $
 Bell=�6/   #��[ 6;   5�      A� 5�      -   5        $��35��5�   '   $��35��63   #��[ 5�   &   $��1��5�   &   $��0,0,5,0q�5�   &   ��5�   "   �� 5�   &    �� ImageSource$ \Images\profileT.png��61   5�      �� 5�        titleColor3#��[ 5�   (   $��
Montserrat)�5�   (   $��12(�5�   (   $��Center=�5�   (   ��5�   (   �� * CurrentUserAccount.DisplayName+5�   (   �� 5�      #��[ 6%   # [ 5�   %   ��5�   %   �� *LogoutCommand+.��5�   "     $ RightFromBracket=�6/   $��12��5�   /   $��12��6;   #��[ 5�   /   5�      5�      �� 5�      $��1��6%   $ 
Horizontal=�5�   %   $��Center=�5�   %   $��RightToLeft=�5�   %   .+�5�        $��20��5�   +   $��20��5�   +      
Foreground# [ 5�   +   $��	15,0,10,0q�5�   +    5�   +   �� *Icon+5�   +   �� 5�      #��[ 5�   (   $��16(�5   (   $��
Montserrat)�5  (   $��Medium"�5  (   $��Center=�5  (   ��5�   (   �� *	Caption+5  (   5     5     �� 5	     $��2��5
  %   $��25q�5  %   ��5	  %   �� *CurrentChildView+5  %   5     5     5     5     5     