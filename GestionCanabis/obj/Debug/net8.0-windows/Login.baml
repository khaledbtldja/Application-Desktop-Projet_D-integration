   M S B A M L   `   `   `  ����I  EGestionCanabis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:GestionCanabisGestionCanabis  5   	       GestionCanabis.Login   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:GestionCanabis     5   	   -   5          � Title$  Login��5   	   $	��600��6   $	��300��6$    � WindowStartupLocation$ CenterScreen=�5	   	    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�5   	    � AllowsTransparency$
 True��5   	   ��5      �� 5   
    �� Color$ Transparent��6    �� Opacity$	 0.1Q�6.    � 	Resources 5         RoundedTextBoxStyle �� 
TargetType	 �� Property
 �� Value �� 
TargetType �� CornerRadius �� ImageSource j� Stretch j� 
AlignmentX ��Name  RoundedPasswordBoxStyle  RoundedButtonStyle��%�  &	        &	 S    &	 �    �� 5   
   " ��6,   .�5      �� 	 � ��
 5      �� 5      " ��6&   .R�5      �� $ 20��5   !   
��� � �$��1q�5   !   ��5      �� 5   "   $ Images/user.png��6-   $
 None=�6K   $
 Left=�6Z   6o   ._�5      �� $ PART_ContentHost��66   $��0q�6+   66   5      5       5"      5#      �� 5$   
   " G�60   .�5%      �� 	 � ��
 5&      �� 5'      " G�6&   .R�5(      �� $ 20��5)   !   
��� � �$��1q�5+   !   ��5,      �� 5-   "   $ Images/key.png��6-   $
 None=�6J   $
 Left=�6Y   6m   ._�5/      �� $ PART_ContentHost��66   $��0q�6+   66   50      51      53      54      �� 55   
   " ��6+   .�56      �� 	 � ��
 57      �� 58      " ��6&   .R�59      �� 
��� � �$ 20��64   $��1q�6F   
��� � �._�5:      �� $��Login��6/   $��Center=�6?   $��Center=�6Z   6y   5;      5=      5?      5@      5A      .��5B      �� $ 50��6   $��0q�6   
������ ��5C   
   �� 5D      $ Black��6   $	 0.5Q�6,   6<   ._�5F      �� $ 50��6   ��5G   
   �� 5H      $ Images/background.png��6   $
 Fill=�6=   6N   ._�5J      � .+�5N   
   �� 
������ $ 50��6+   ._�5O      �� $��Center=�6   .+�5P      �� -   5        $��Images/logo.png��5P      $��50��61   $��50��6<   6H   �� 5Q      $��0,20,0,0q�6   $��
MontSerrat)�6*   
�������$��20(�6U   $��Center=�6c   $��Gestion��6�   6�   �� 5R      $��0,0,0,0q�6   $��
MontSerrat)�6)   
�������$��20(�6T   $��Center=�6b   $��Canabis��6   6�   �� 5S      -   5         ��Name$ un��5S      $��
MontSerrat)�6/   $��16(�6G    �� TextAlignment$ Center=�6U   
�������#��[  6�   $	��200��6�   $��	0,20,0,10q�6�   $��10q�6�   $��40��6�    �� 
CaretBrush
 �����6�   G� 5T      -   5         G�Name$	 pwd��5T   �   $��
MontSerrat)�64   $��16(�6L   $��Center=�6Z   $��Center=�6~   
�������#��[ 6�   $	��200��6�   $��	0,10,0,20q�6�   $��10q�6  $��40��6   G� 
CaretBrush
 �����6)  �� 5U      -   5         � Cursor$
 Hand��5U      #��[ 6'   $��Login��6S   
��� � �
�������$	��100��6�   $��10q�6�   $��40��6�   6�   5V      5W      5X      5Y      5Z      5[      