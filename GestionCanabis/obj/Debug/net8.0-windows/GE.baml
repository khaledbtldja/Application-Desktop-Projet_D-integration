   M S B A M L   `   `   `  ����I  EGestionCanabis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:GestionCanabisGestionCanabis  5          GestionCanabis.GE   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:GestionCanabis     5        N� Title$  GE��5	       � 	Resources 5
       �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%�   '��       �� 5   
   " ��6    5      P� 5       � {�$ False��6/   . �5      ��  � y�$ Hidden=�63   6D   5      P� 5       � {�$
 True��6/   . �5      ��  � y�$ Visible=�63   6E   5      5      5      .��5      �� 
���   �._�5   
   �� ��5      �� 5       �� ImageSource$ Images/background.png��6   	 j� Stretch$	 UniformToFill=�6A   6[   ._�5      � 
 � RowDefinitions
 5      �� 5      $	��250 �6$   5      �� 5       $	��250 �6$   5"      .+�5$      �� $��0��6   .+�5%      �� -   5         ��Name$
 back��5%   Z   $��0q�6   $��25��61   $��25��6<   $��0,20,0,0q�6H    � Cursor$
 Hand��6h   ��5&      �� 5'      $ Images/arrow.png��6)   $
	 Fill=�6H   5)      5+      �� 5,      
�������$��Center=�6/   $��
MontSerrat)�6L   $��24(�6d   $
��Bold"�6r   .��6�   Liste des Entreposages6�   �� 5-      .��5.      &   System.Windows.Controls.DataGrid  -   5          Name$ 	DataGridP��5.   �   "   VerticalScrollBarVisibility$ Visible=�6   $	��180��6E   $��Center=�6U   
������    AutoGenerateColumns$ False��6�      	RowHeight$ 40Q�6�   ��6�   �� *list+ 5/      =  7System.Windows.Controls.Primitives.DataGridColumnHeader*  $System.Windows.Controls.DataGridCell)  #System.Windows.Controls.DataGridRow:  4System.Windows.Controls.Primitives.DataGridRowHeader��%   '        '  �     '  �    '      '�� `    'n�     '�� �    �� 50   "   "  6(   .�51   &   ��  � ��
 ���� 6C   �� 52   &    � ��
 � � �6D   �� 53   &    � ��$ 1q�6H   �� 54   &    � ��
 �����6C   �� 55   &    � ��$ Center=�6S   6d   56   #   �� 58   "   "  6(   .�59   &   ��  � ��
 ���� 6C   �� 5:   &    � ��
 � � �6D   �� 5;   &    � ��$ 1q�6H   �� 5<   &    � ��
 �����6C   �� 5=   &    � ��$ Center=�6S   6d   5?   #   �� 5@   "   "  6(   .�5A   &   ��  � ��
 ���� 6Y   5B   #   �� 5C   "   "  6(   .�5D   &   ��  � ��
 ���� 6Y   5E   #   �� 5F   "   " ��6(   .�5G   &   ��  � ��
 ���� 6Y   �� 5H   &    � ��
 � � �6S   �� 5I   &    � ��
 � � �6T   �� 5J   &    � ��$ 3��6?   6K   5L   #   �� 5M   "   " n�6(   .�5N   &   ��  � ��
 � � �6S   �� 5O   &    � ��$ 3��6?   6K   5P   #   �� 5Q   "   " ��6(   .�5R   &   ��  � ��
 � � �6S   5S   #   5T         Columns 5U      0  *System.Windows.Controls.DataGridTextColumn  5V      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *ID+  5W      $ Description��61    6F   �� *Description+4	  .System.Windows.Controls.DataGridTemplateColumn	  5X      $ Actions��65    	  CellTemplate 5Y   "   �� 5Z   &   .R�5[   *   ��  �� Orientation$ 
Horizontal=�65   .+�5\   .   �� $ btnmodifier��6C   -   5        $
 Hand��5\   5   $��Modifier��6X   $��0q�6   
������ 
��� ���$��2q�6�   
 � Tag 6k   �� *ID+6�   �� 5]   .   $ btnsupprimer��6C   -   5        $
 Hand��5]   5   $��	Supprimer��6Y   $��0q�6�   
������ 
���  ��$��2q�6�    6m   �� *ID+6�   5^   +   5_   '   5a      5c      5d      5e      �� 5f      $��1��6   $��Center=�6&   
��� � �$��1q�6W   $��0,50,0,0q�6k   ._�5g      �� $��Center=�6!   .+�5h      �� 
�������$��Center=�63   $��
MontSerrat)�6P   $��24(�6h   $
��Bold"�6v   .��6�   Gestion des Entreposages6�   �� 5i      $ 
Horizontal=�6%   .+�5j      �� 
�������$��Center=�67   $��
MontSerrat)�6T   $��12(�6l   $��Light"�6z   .��6�   ID6�   �� 5k      -   5         ��Name$	 nom��5k   9   
������� �� 
CaretBrush
 �����$��	124,0,0,0q�6Y    �� TextAlignment$ Center=�6l   
������ $	��100��6�   $��
MontSerrat)�6�   $��12(�6�   $��Light"�6�   
��� � �$��0,0,0,1q�6�   6  5l      �� 5m      $ 
Horizontal=�6%   .+�5n      �� 
�������$��Center=�67   $��
MontSerrat)�6T   $��12(�6l   $��Light"�6z   .��6�   Description6�   �� 5o      -   5        $ description��5o   9   
�������
 �����$��68,0,0,0q�6a   $ Center=�6s   
������ $	��100��6�   $��
MontSerrat)�6�   $��12(�6�   $��Light"�6�   
��� � �$��0,0,0,1q�6�   6  5p      �� 5q      $ 
Horizontal=�6%   $��0,20,0,0q�6>   .+�5r      �� -   5        $ boutonajout��5r   4   $
 Hand��6%   $��Center=�6I   $��
30,10,30,0q�6f   $��60��6z   $��20��6�   $��Ajouter��6�   
�������
��� � �
��� � �6�   �� 5s      -   5        $ boutonmodification��5s   3   $
 Hand��6%   ${�False��6O   $��Center=�6a   $��
30,10,30,0q�6~   $��60��6�   $��20��6�   $��Modifier��6�   
�������
��� ���
��� ���6  �� 5t      -	   5        $ annulermodification��5t   3   $
 Hand��6%   ${�False��6P   $��Center=�6b   $��
30,10,30,0q�6   $��60��6�   $��20��6�   $��Annuler��6�   
�������
���  ��
���  ��6  5u      5v      5w      5x      5y      5z      5{      