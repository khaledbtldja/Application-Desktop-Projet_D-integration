   M S B A M L   `   `   `  ���� I  EGestionCanabis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:GestionCanabisGestionCanabis      GestionCanabis.GT   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:GestionCanabis       N� Title$  GT�� � 	Resources  �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%�   '��       �� " �� P�  � {�$ False��. ���  � y�$ Hidden=�P�  � {�$
 True��. ���  � y�$ Visible=�.���� 
���   �._��� ����  �� ImageSource$ Images/background.png��	 j� Stretch$	 UniformToFill=�._�� 
 � RowDefinitions
 �� $	��250 ��� $	��250 �.+��� $��0��.+��� -    ��Name$
 back��$��0q�$��25��$��25��$��0,20,0,0q� � Cursor$
 Hand������ $ Images/arrow.png��$
	 Fill=��� 
�������$��Center=�$��
MontSerrat)�$��24(�$
��Bold"�.��Liste des Types de Plantules�� .��&   System.Windows.Controls.DataGrid  -     Name$ 	DataGridP��"   VerticalScrollBarVisibility$ Visible=�$	��180��$��Center=�
������    AutoGenerateColumns$ False��   	RowHeight$ 40Q����� *list+ =  7System.Windows.Controls.Primitives.DataGridColumnHeader*  $System.Windows.Controls.DataGridCell)  #System.Windows.Controls.DataGridRow:  4System.Windows.Controls.Primitives.DataGridRowHeader��%a  '        '  �     '      '  -    '�� R    'n� �    '�� �    �� "  .���  � ��
 ���� ��  � ��
 � � ���  � ��$ 1q���  � ��
 �������  � ��$ Center=��� "  .���  � ��
 ���� ��  � ��
 � � ���  � ��$ 1q���  � ��
 �������  � ��$ Center=��� "  .���  � ��
 ���� �� "  .���  � ��
 ���� �� " ��.���  � ��
 ���� ��  � ��
 � � ���  � ��
 � � ���  � ��$ 3���� " n�.���  � ��
 � � ���  � ��$ 3���� " ��.���  � ��
 � � �   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Description��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *DESCRIPTION+  $ Abbreviation�� �� *ABBREV+4	  .System.Windows.Controls.DataGridTemplateColumn	  $ Actions�� 	  CellTemplate �� .R���  �� Orientation$ 
Horizontal=�.+��� $ btnmodifier��-   $
 Hand��$��Modifier��$��0q�
������ 
��� ���$��2q�
 � Tag �� *ABBREV+�� $ btnsupprimer��-   $
 Hand��$��	Supprimer��$��0q�
������ 
���  ��$��2q� �� *ABBREV+�� $��1��$��Center=�
��� � �$��1q�$��0,50,0,0q�._��� $��Center=�.+��� 
�������$��Center=�$��
MontSerrat)�$��24(�$
��Bold"�.��Gestion des Types�� $ 
Horizontal=�.+��� 
�������$��Center=�$��
MontSerrat)�$��12(�$��Light"�.��Description�� -    ��Name$	 nom��
������� �� 
CaretBrush
 �����$��75,0,0,0q� �� TextAlignment$ Center=�
������ $	��100��$��
MontSerrat)�$��12(�$��Light"�
��� � �$��0,0,0,1q��� $ 
Horizontal=�.+��� 
�������$��Center=�$��
MontSerrat)�$��12(�$��Light"�.��Abbreviation�� -   $ description��
�������
 �����$��68,0,0,0q�$ Center=�
������ $	��100��$��
MontSerrat)�$��12(�$��Light"�
��� � �$��0,0,0,1q��� $ 
Horizontal=�$��0,20,0,0q�.+��� -   $ boutonajout��$
 Hand��$��Center=�$��
30,10,30,0q�$��60��$��20��$��Ajouter��
�������
��� � �
��� � ��� -   $ boutonmodification��$
 Hand��${�False��$��Center=�$��
30,10,30,0q�$��60��$��20��$��Modifier��
�������
��� ���
��� ����� -	   $ annulermodification��$
 Hand��${�False��$��Center=�$��
30,10,30,0q�$��60��$��20��$��Annuler��
�������
���  ��
���  ��