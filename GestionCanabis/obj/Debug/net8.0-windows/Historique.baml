   M S B A M L   `   `   `  ����I  EGestionCanabis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:GestionCanabisGestionCanabis  5          GestionCanabis.Historique   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:GestionCanabis     5        N� Title$  
Historique��5	       � 	Resources 5
         ExpandableTextBlockStyle �� 
TargetType �� Property �� Value �� Triggers :� RoutedEvent �� TargetProperty	 W� To	 g� Duration��%X  &	        �� 5   
   " ��61   .�5      ��  � ��$ 30��6'   �� 5       � ��$	 300��6&   �� 5       �@��CornerRadius$ 10��6-   �� 5       � ��
 ���� 6+   �� 5       �@��Padding$ 10q�6(   �� 5       � ��$ 5q�6'   �� 5       �@J�SnapsToDevicePixels$
 True��64   �� 5       � ��
 � � �6,   �� 5       � ��$ 1q�60    5      :� 5      $ 
MouseLeave��6   .[�5      �� .��5      �� .��5      W� $ Height�6.    305   .   $	 0:0:0.2D�5   .   5      5      5       5"      5#      .��5$      �� 
���   �._�5%   
   �� ��5&      �� 5'      
 �� ImageSource$
 Images/background.png��6    j� Stretch$ UniformToFill=�6A   6[   ._�5)      �  � ColumnDefinitions 5*      �� 5+      5-      �� 5.      50      .+�52      � $��0��6   $	��400��6'   
������ $	��300��6M   .+�53      �� .+�54      �� $��
MontSerrat)�6    
�������$��16(�6K   $��Center=�6Y   .��6}   Recherche par ID6�   �� 55      $��Center=�6%    �� Orientation$ 
Horizontal=�6B   .+�56      �� -   5         ��Name$	 IDP��56   f    �� TextAlignment$ Center=�6&   
�������$	��100��6s   
��� � �
������ $��0,0,0,1q�6�   $��0,10,0,0q�6�    �� 
CaretBrush
 �����6�   �� 57      -   5         � Cursor$
 Hand��57   %   $��	10,10,0,0q�64   $��25��6G   $��25��6R   ��58   "   �� 59   &   $
 Images/search.png��61   6S   5;      5<      �� 5=      $��
MontSerrat)�6    
�������$��16(�6K   $��Center=�6Y   $��0,50,0,0q�6}   .��6�   Recherche par Photo6�   �� 5>      $��Center=�6%   .+�5?      �� -   5         ��Name$ startCamera��5?   J   $��25��6%   $��25��60   $
 Hand��6<   ��5@   "   �� 5A   &   $
 Images/camera.png��61   6S   5C      �� 5D      
��� � �$��1q�69   $	��150��6M   $	��150��6Z   $��0,20,0,0q�6f   ._�5E   "   �� -   5        $��
CameraFeed��5E   (   $	��150��6:   $	��150��6F   6V   5F      5G      5H      5I      � 5J      $��1��6   .+�5K      �� .+�5L      �� $��
MontSerrat)�6    
�������$��16(�6K   $��Center=�6Y   $��
0,75,150,0q�6}   .��6�   
Historique6�   �� 5M      -   5         ��Name$ scroll��5M   '   $��Visible=�67   $	��330��6]   $	��350��6i   $��	0,3,100,0q�6v   
�������$��5,5,5,5q�6�   
�������.��5N      �� -   5        $��TextBlocksItemsControl��5N   +   $��Center=�6I   $	��Top=�6f   ��5O   "   �� 5P   &   .R�5Q   *   �� -   5        #��[  5Q   1   ._�5R   .   �� 
�������$
��Wrap=�6\   $��Center=�6p   $��Center=�6�   ��6K   �� 6�   5S   +   5T   '   5V      5W      5X      5Y      5Z      5[      5\      5]      