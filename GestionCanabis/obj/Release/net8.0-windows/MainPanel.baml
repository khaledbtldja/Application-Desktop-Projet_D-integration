   M S B A M L   `   `   `  ���� I  EGestionCanabis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:GestionCanabisGestionCanabis      GestionCanabis.MainPanel   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:GestionCanabis     -     � Title$  Gestion Canabis��$	��550��$
��1200�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � AllowsTransparency$
 True�� � WindowStartupLocation$ CenterScreen=�����  �� Color$ Transparent��.���� 
��� � �$��2q�
������ ._��� .+�� 
���   �$��30��$	��Top=�.+��� $��Images/logo.png��$
��Left=�$��20���� $��
MontSerrat)�
�������$��20,0,0,0q�.��Gestion Canabis�� -    ��Name$ 
homebutton��
������ $��0q�$��Center=�$��25�� � Cursor$
 Hand������  �� ImageSource$ Images/home.png���� -   $ btnClose��$��0q�$��X��
�������$��16(�$��
MontSerrat)�$
 Hand��$��20,0,0,0q�$��Right=�$��Center=����� 	 �� 
TargetType"	 ��.��� 
 �� Property
 � �� �� Value
 �  ������  �� 
TargetType" ��.R��� $��18��$��18�� �� CornerRadius$ 9��#��z��._��� $��X��$��Center=�$��Center=��� -   $ btnMinimize��$��0q�$��-��
�������$��16(�$��
MontSerrat)�$
 Hand��$��0,0,20,0q�$��Right=����� "	 ��.��� 
 � ��
 � � ����� " ��.R��� $��18��$��18��$ 9��#��z��._��� $��-��$��Center=�$��Center=�� $	��520�� � ColumnDefinitions �� $	��250 ��� $	��950 �.+�� $��0������ $ Black�� � RowDefinitions �� �� �� �� �� .+��� -   $ 
btnAccueil��$��2��$��
MontSerrat)�
��� � �$��20(�
���   �.����  �� Orientation$ 
Horizontal=�.+��� $��Images/import.png��$��25���� $��
MontSerrat)�
��� � �$��20(�.��Importation�� -   $ btnGP��$��0��$��
MontSerrat)�
��� � �$��20(�
������ .���� $ 
Horizontal=�.+��� $��Images/plantule.png��$��25���� $��
MontSerrat)�
��� � �$��20(�.��Gestion Plantules�� -   $ btnGG��$��3��$��
MontSerrat)�
��� � �$��20(�
������ .���� $ 
Horizontal=�.+��� $��Images/management.png��$��25���� $��
MontSerrat)�
��� � �$��20(�.��Gestion Générale�� -   $ btnHistorique��$��1��$��
MontSerrat)�
��� � �$��20(�
������ .���� $ 
Horizontal=�.+��� $��Images/history.png��$��25���� $��
MontSerrat)�
��� � �$��20(�.��Historique Plantules�� -	   $ btnDeconnexion��$��4��$��
MontSerrat)�
��� � �$��20(�
������ .���� $ 
Horizontal=�.+��� $��Images/logout.png��$��25���� $��
MontSerrat)�
��� � �$��20(�.��Déconnexion� $��1��
���   �.+� � -
     �Name$ ContentPage��  � NavigationUIVisibility$ Hidden=�