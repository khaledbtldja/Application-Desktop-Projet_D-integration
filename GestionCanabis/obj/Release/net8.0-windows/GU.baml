   M S B A M L   `   `   `  ���� I  EGestionCanabis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:GestionCanabisGestionCanabis      GestionCanabis.GU   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:GestionCanabis       N� Title$  GU�� � 	Resources  �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%�   '��       �� " �� P�  � {�$ False��. ���  � y�$ Hidden=�P�  � {�$
 True��. ���  � y�$ Visible=�.���� 
���   �._��� ����  j� Stretch$ UniformToFill=�	 �� ImageSource$	 Images/background.png��._�� 
 � RowDefinitions
 �� $	��230 ��� $	��280 �.+��� $��0��.+��� -    ��Name$
 back��$��25��$��25��$��0,20,0,0q�$��0q� � Cursor$
 Hand������ $	 Images/arrow.png��$
 Fill=��� 
�������$��Center=�$��
MontSerrat)�$��24(�$
��Bold"�.��Liste des Utilisateurs&   System.Windows.Controls.DataGrid  -     Name$ 	DataGridP��$	��180��$��Center=�
������    AutoGenerateColumns$ False��   	RowHeight$ 40Q����� *users+ =  7System.Windows.Controls.Primitives.DataGridColumnHeader*  $System.Windows.Controls.DataGridCell)  #System.Windows.Controls.DataGridRow:  4System.Windows.Controls.Primitives.DataGridRowHeader��%a  '        '  �     '      '  -    '�� R    'n� �    '�� �    �� "  .���  � ��
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
 � � �   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Nom d'Utilisateur��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
username+  $ Mot de Passe�� �� *
password+  $	 Nom�� �� *nom+  $ Prenom�� �� *prenom+  $ Adresse�� �� *	adresse+  $ 	Telephone�� �� *	telephone+4	  .System.Windows.Controls.DataGridTemplateColumn	  $ Actions�� 	  CellTemplate �� .R���  �� Orientation$ 
Horizontal=�.+��� $ btnmodifier��-   $
 Hand��$��Modifier��$��0q�
������ 
��� ���$��2q�
 � Tag �� *
username+�� $ btnsupprimer��-   $
 Hand��$��	Supprimer��$��0q�
������ 
���  ��$��2q� �� *
username+�� $��0,20,0,0q�$��1��$��Center=�
��� � �$��1q�._��� $��Center=�.+��� 
�������$��Center=�$��
MontSerrat)�$��24(�$
��Bold"�.��Gestion des Utilisateurs�� $ 
Horizontal=�.+��� 
�������$��Center=�$��
MontSerrat)�$��12(�$��Light"�.��Nom d'Utilisateur�� -    ��Name$ un��
������� �� 
CaretBrush
 �����$��50,0,0,0q� �� TextAlignment$ Center=�
������ $	��100��$��
MontSerrat)�$��12(�$��Light"�
��� � �$��0,0,0,1q��� -    ��Name$ uncheck��$��Center=�
���  ���� $ 
Horizontal=�.+��� 
�������$��Center=�$��
MontSerrat)�$��10(�$��Light"�.��Mot de PasseG� -    G�Name$	 pwd��
�������
��� � �$��88,0,0,0q�$��Center=�
������ $	��100��$��12(�$��Light"�$��0,0,0,1q� G� 
CaretBrush
 ������� $ 
Horizontal=�.+��� 
�������$��Center=�$��
MontSerrat)�$��12(�$��Light"�.��Nom�� -   $	 nom��
�������
 �����$��	124,0,0,0q�$ Center=�
������ $	��100��$��
MontSerrat)�$��12(�$��Light"�
��� � �$��0,0,0,1q��� $ 
Horizontal=�.+��� 
�������$��Center=�$��
MontSerrat)�$��12(�$��Light"�.��Preom�� -	   $ prenom��
�������
 �����$��	114,0,0,0q�$ Center=�
������ $	��100��$��
MontSerrat)�$��12(�$��Light"�
��� � �$��0,0,0,1q��� $ 
Horizontal=�.+��� 
�������$��Center=�$��
MontSerrat)�$��12(�$��Light"�.��	Adresse�� -
   $ adresse��
�������
 �����$��	107,0,0,0q�$ Center=�
������ $	��100��$��
MontSerrat)�$��12(�$��Light"�
��� � �$��0,0,0,1q��� $ 
Horizontal=�.+��� 
�������$��Center=�$��
MontSerrat)�$��12(�$��Light"�.��	Telephone�� -   $ 	telephone��
�������
 �����$��92,0,0,0q�$ Center=�
������ $	��100��$��
MontSerrat)�$��12(�$��Light"�
��� � �$��0,0,0,1q��� $ 
Horizontal=�$��0,20,0,0q�.+��� -   $ boutonajout��$
 Hand��$��Center=�$��
30,10,30,0q�$��60��$��20��$��Ajouter��
�������
��� � �
��� � ��� -   $ boutonmodification��${�False��$��Center=�$��
30,10,30,0q�$��60��$��20��$��Modifier��
�������
��� ���
��� ����� -   $ annulermodification��${�False��$��Center=�$��
30,10,30,0q�$��60��$��20��$��Annuler��
�������
���  ��
���  ��