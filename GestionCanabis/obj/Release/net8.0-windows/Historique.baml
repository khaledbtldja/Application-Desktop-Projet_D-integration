   M S B A M L   `   `   `  ���� I  EGestionCanabis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:GestionCanabisGestionCanabis      GestionCanabis.Historique   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:GestionCanabis       N� Title$  
Historique�� � 	Resources    ExpandableTextBlockStyle �� 
TargetType �� Property �� Value �� Triggers :� RoutedEvent �� TargetProperty	 W� To	 g� Duration��%_  &	        �� " ��.���  � ��$ 30����  � ��$	 300����  �@��CornerRadius$ 10����  � ��
 ���� ��  �@��Padding$ 10q���  � ��$ 5q���  �@J�SnapsToDevicePixels$
 True����  � ��
 � � ���  � ��$ 1q� :� $ 
MouseLeave��.[��� .���� .��W� $ Height� 30$	 0:0:0.2D�.���� 
���   �._��� ���� 
 �� ImageSource$
 Images/background.png�� j� Stretch$ UniformToFill=�._��  � ColumnDefinitions �� �� .+�� $��0��$	��400��
������ $	��300��.+��� .+��� $��
MontSerrat)�
�������$��16(�$��Center=�.��Recherche par ID�� $��Center=� �� Orientation$ 
Horizontal=�.+��� -    ��Name$	 IDP�� �� TextAlignment$ Center=�
�������$	��100��
��� � �
������ $��0,0,0,1q�$��0,10,0,0q� �� 
CaretBrush
 ������� -    � Cursor$
 Hand��$��	10,10,0,0q�$��25��$��25������ $
 Images/search.png���� $��
MontSerrat)�
�������$��16(�$��Center=�$��0,50,0,0q�.��Recherche par Photo�� $��Center=�.+��� -    ��Name$ startCamera��$��25��$��25��$
 Hand������ $
 Images/camera.png���� 
��� � �$��1q�$	��150��$	��150��$��0,20,0,0q�._��� -   $��
CameraFeed��$	��150��$	��150��� $��1��.+��� .+��� $��
MontSerrat)�
�������$��16(�$��Center=�$��
0,75,150,0q�.��
Historique�� -    ��Name$ scroll��$��Visible=�$	��330��$	��350��$��	0,3,100,0q�
�������$��5,5,5,5q�
�������.���� -   $��TextBlocksItemsControl��$��Center=�$	��Top=����� .R��� -   #��[  ._��� 
�������$
��Wrap=�$��Center=�$��Center=����� 