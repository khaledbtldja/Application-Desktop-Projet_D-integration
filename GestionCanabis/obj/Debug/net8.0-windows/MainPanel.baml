   M S B A M L   `   `   `  ����I  EGestionCanabis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:GestionCanabisGestionCanabis  5   	       GestionCanabis.MainPanel   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:GestionCanabis     5   	   -   5          � Title$  Gestion Canabis��5   	   $	��550��6!   $
��1200��6.    � WindowStyle$
 None=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � AllowsTransparency$
 True��5   	    � WindowStartupLocation$ CenterScreen=�5   	   ��5      �� 5   
    �� Color$ Transparent��6   60   .��5      �� 
��� � �$��2q�6"   
������ ._�5   
   �� .+�5      � 
���   �$��30��6&   $	��Top=�62   .+�5      �� $��Images/logo.png��6   $
��Left=�61   $��20��6L   6Y   �� 5      $��
MontSerrat)�6   
�������$��20,0,0,0q�6C   .��6U   Gestion Canabis6f   �� 5      -   5         ��Name$ 
homebutton��5   `   
������ $��0q�63   $��Center=�6t   $��25��6�    � Cursor$
 Hand��6�   ��5      �� 5       �� ImageSource$ Images/home.png��6%   6E   5      �� 5      -   5        $ btnClose��5      $��0q�6+   $��X��6?   
�������$��16(�6^   $��
MontSerrat)�6l   $
 Hand��6�   $��20,0,0,0q�6�   $��Right=�6�   $��Center=�6�   ��5      �� 5      	 �� 
TargetType"	 ��6    .�5      �� 
 �� Property
 � �� �� Value
 �  ��5       5!      ��5#      �� 5$       �� 
TargetType" ��6*   .R�5%      �� $��18��6%   $��18��60    �� CornerRadius$ 9��6<   #��z��6M   ._�5&   "   �� $��X��63   $��Center=�6?   $��Center=�6Z   6y   5'      5(      5*      �� 5+      -   5        $ btnMinimize��5+      $��0q�6.   $��-��6B   
�������$��16(�6a   $��
MontSerrat)�6o   $
 Hand��6�   $��0,0,20,0q�6�   $��Right=�6�   ��5,      �� 5-      "	 ��6    .�5.      �� 
 � ��
 � � �5/      50      ��52      �� 53      " ��6*   .R�54      �� $��18��6%   $��18��60   $ 9��6<   #��z��6M   ._�55   "   �� $��-��63   $��Center=�6?   $��Center=�6Z   6y   56      57      59      5:      � 5;      $	��520��6    � ColumnDefinitions 5<      �� 5=      $	��250 �6'   5?      �� 5@      $	��950 �6'   65   .+�5B      � $��0��6   ��5C      �� 5D      $ Black��6*   6:    � RowDefinitions 5F      �� 5G      �� 5H      �� 5I      �� 5J      �� 5K      .+�5M      �� -   5        $ 
btnAccueil��5M      $��2��61   $��
MontSerrat)�6>   
��� � �$��20(�6i   
���   �.��5N      ��  �� Orientation$ 
Horizontal=�6%   .+�5O      �� $��Images/import.png��6$   $��25��6?   6L   �� 5P      $��
MontSerrat)�6$   
��� � �$��20(�6O   .��6]   Importation6j   5Q      5R      �� 5S      -   5        $ btnGP��5S      $��0��6,   $��
MontSerrat)�69   
��� � �$��20(�6d   
������ .��5T      �� $ 
Horizontal=�6%   .+�5U      �� $��Images/plantule.png��6$   $��25��6A   6N   �� 5V      $��
MontSerrat)�6$   
��� � �$��20(�6O   .��6]   Gestion Plantules6p   5W      5X      �� 5Y      -   5        $ btnGG��5Y      $��3��6,   $��
MontSerrat)�69   
��� � �$��20(�6d   
������ .��5Z      �� $ 
Horizontal=�6%   .+�5[      �� $��Images/management.png��6$   $��25��6C   6P   �� 5\      $��
MontSerrat)�6$   
��� � �$��20(�6O   .��6]   Gestion Générale6o   5]      5^      �� 5_      -   5        $ btnHistorique��5_      $��1��64   $��
MontSerrat)�6B   
��� � �$��20(�6m   
������ .��5`      �� $ 
Horizontal=�6%   .+�5a      �� $��Images/history.png��6$   $��25��6@   6M   �� 5b      $��
MontSerrat)�6$   
��� � �$��20(�6O   .��6]   Historique Plantules6s   5c      5d      �� 5e      -	   5        $ btnDeconnexion��5e      $��4��65   $��
MontSerrat)�6C   
��� � �$��20(�6n   
������ .��5f      �� $ 
Horizontal=�6%   .+�5g      �� $��Images/logout.png��6$   $��25��6?   6L   �� 5h      $��
MontSerrat)�6$   
��� � �$��20(�6O   .��6]   Déconnexion6j   5i      5j      5k      � 5l      $��1��6   
���   �.+�5m       � -
   5          �Name$ ContentPage��5m        � NavigationUIVisibility$ Hidden=�61   6S   5n      5o      5p      5r      5s      