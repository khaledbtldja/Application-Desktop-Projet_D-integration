   M S B A M L   `   `   `  ����I  EGestionCanabis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:GestionCanabisGestionCanabis  5          GestionCanabis.GR   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:GestionCanabis     5        N� Title$  GR��5	       � 	Resources 5
       �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%�   '��       �� 5   
   " ��6    5      P� 5       � {�$ False��6/   . �5      ��  � y�$ Hidden=�63   6D   5      P� 5       � {�$
 True��6/   . �5      ��  � y�$ Visible=�63   6E   5      5      5      .��5      �� 
���   �._�5   
   �� ��5      �� 5       �� ImageSource$ Images/background.png��6   	 j� Stretch$	 UniformToFill=�6A   6[   ._�5      � 
 � RowDefinitions
 5      �� 5      $	��250 �6$   5      �� 5       $	��180 �6$   5"      .+�5$      �� $��0��6   .+�5%      �� -   5         ��Name$
 back��5%   Z   $��0q�6   $��25��61   $��25��6<   $��0,20,0,0q�6H    � Cursor$
 Hand��6h   ��5&      �� 5'      $ Images/arrow.png��6)   $
	 Fill=�6H   5)      5+      �� 5,      
�������$��Center=�6/   $��
MontSerrat)�6L   $��24(�6d   $
��Bold"�6r   .��6�   Liste des Responsables6�   &   System.Windows.Controls.DataGrid  5-      -   5          Name$ 	DataGridP��5-   e   $	��180��6   $��Center=�6/   
������    AutoGenerateColumns$ False��6�      	RowHeight$ 40Q�6�   ��6x   �� *list+ 5.      =  7System.Windows.Controls.Primitives.DataGridColumnHeader*  $System.Windows.Controls.DataGridCell)  #System.Windows.Controls.DataGridRow:  4System.Windows.Controls.Primitives.DataGridRowHeader��%   '        '  �     '  �    '      '�� `    'n�     '�� �    �� 5/      "  6$   .�50   "   ��  � ��
 ���� 6?   �� 51   "    � ��
 � � �6@   �� 52   "    � ��$ 1q�6D   �� 53   "    � ��
 �����6?   �� 54   "    � ��$ Center=�6O   6`   55      �� 57      "  6$   .�58   "   ��  � ��
 ���� 6?   �� 59   "    � ��
 � � �6@   �� 5:   "    � ��$ 1q�6D   �� 5;   "    � ��
 �����6?   �� 5<   "    � ��$ Center=�6O   6`   5>      �� 5?      "  6$   .�5@   "   ��  � ��
 ���� 6U   5A      �� 5B      "  6$   .�5C   "   ��  � ��
 ���� 6U   5D      �� 5E      " ��6$   .�5F   "   ��  � ��
 ���� 6U   �� 5G   "    � ��
 � � �6O   �� 5H   "    � ��
 � � �6P   �� 5I   "    � ��$ 3��6;   6G   5K      �� 5L      " n�6$   .�5M   "   ��  � ��
 � � �6O   �� 5N   "    � ��$ 3��6;   6G   5O      �� 5P      " ��6$   .�5Q   "   ��  � ��
 � � �6O   5R      5S         Columns 5T      0  *System.Windows.Controls.DataGridTextColumn  5U      ,  &System.Windows.Controls.DataGridColumn   Header$	 Nom��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *a+4	  .System.Windows.Controls.DataGridTemplateColumn	  5W      $ Actions��65    	  CellTemplate 5X   "   �� 5Y   &   .R�5Z   *   ��  �� Orientation$ 
Horizontal=�65   .+�5[   .   �� $ btnmodifier��6C   -   5        $
 Hand��5[   5   $��Modifier��6X   $��0q�6~   
������ 
��� ���$��2q�6�   
 � Tag 6k   �� *a+6�   �� 5\   .   $ btnsupprimer��6C   -   5        $
 Hand��5\   5   $��	Supprimer��6Y   $��0q�6   
������ 
���  ��$��2q�6�    6m   �� *a+6�   5]   +   5^   '   5`      5b      5c      �� 5d      $��0,30,0,0q�6   $��1��6+   $��Center=�68   
��� � �$��1q�6i   ._�5e      �� $��Center=�6!   .+�5f      �� 
�������$��Center=�63   $��
MontSerrat)�6P   $��24(�6h   $
��Bold"�6v   .��6�   Gestion des Responsables6�   �� 5g      $ 
Horizontal=�6%   .+�5h      �� 
�������$��Center=�67   $��
MontSerrat)�6T   $��12(�6l   $��Light"�6z   .��6�   Nom6�   �� 5i      -   5         ��Name$	 nom��5i   9   
������� �� 
CaretBrush
 �����$��	124,0,0,0q�6Y    �� TextAlignment$ Center=�6l   
������ $	��100��6�   $��
MontSerrat)�6�   $��12(�6�   $��Light"�6�   
��� � �$��0,0,0,1q�6�   6  5j      �� 5k      $ 
Horizontal=�6%   $��0,20,0,0q�6>   .+�5l      �� -   5        $ boutonajout��5l   4   $
 Hand��6%   $��Center=�6I   $��
30,10,30,0q�6f   $��60��6z   $��20��6�   $��Ajouter��6�   
�������
��� � �
��� � �6�   �� 5m      -   5        $ boutonmodification��5m   %   ${�False��6A   $��Center=�6S   $��
30,10,30,0q�6p   $��60��6�   $��20��6�   $��Modifier��6�   
�������
��� ���
��� ���6  �� 5n      -   5        $ annulermodification��5n   %   ${�False��6B   $��Center=�6T   $��
30,10,30,0q�6q   $��60��6�   $��20��6�   $��Annuler��6�   
�������
���  ��
���  ��6  5o      5p      5q      5r      5s      5t      5u      