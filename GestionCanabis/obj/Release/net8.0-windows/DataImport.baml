   M S B A M L   `   `   `  ���� I  EGestionCanabis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:GestionCanabisGestionCanabis      GestionCanabis.DataImport   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:GestionCanabis     -     � Title$  
DataImport��$	��550��$	��950�� � 	Resources  �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value �� 
TargetType	 �� 	ClickMode
 d� 	IsChecked �� Path �� Mode �� RelativeSource F�Name �� Triggers �� 
TargetName �� Angle J� IsHitTestVisible �� SelectionBoxItem �� SelectionBoxItemTemplate ��Name �� 
IsReadOnly �� 
IsReadOnly �� IsDropDownOpen � AllowsTransparency J� SnapsToDevicePixels � ActualWidth �� MaxDropDownHeight ��Name K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation  P� 
SourceName   DataGridRowStyle)  #System.Windows.Controls.DataGridRow! �� Binding" �� Value��%�  '��       '�� z     '�� !    '�� �    '�� &    &	  �    �� " �� P�  � {�$ False��. ���  � y�$ Hidden=�P�  � {�$
 True��. ���  � y�$ Visible=��� " ��.���  � ��
 �������  � ��
 ���� ��  � ��
 � � ���  � ��$ 1q���  �@��
CaretBrush
 �������  � ��$ Center=��� " ��.���  � ��
 �������  � ��
 ���� ��  � ��
 � � ���  � ��$ 1q���  �@��
CaretBrush
 �������  � ��$ Center=��� " ��.���  � ��
 �������  � ��
 ���� ��  � ��
 � � ���  �@�OverridesDefaultStyle$
 True����  � �� �� " ��.R�� .+�d� $��ToggleButton��$��2��$|�False��$	 Press=�
������ 
��� � �
�������
 �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+���� " d�.���  � �� �� " d�.R��� #��z��#��z��$��1q�._�F� $ Arrow��#��z��"����        � 	=  	= � z     	$��Right=�$��0,0,5,0q�$��Center=� P�  �@d�	IsChecked$
 TrueY�. ��� $ Arrow�� � z� �� $	 180Q��� $��ContentSite��$ False��#��z #��z #��z��$��3,3,23,3q�$��Center=�$
��Left=��� $ PART_EditableTextBox��
������ 
�������$
��Left=�$��Center=�$��3,3,23,3q�$
|�True��$y�Hidden=�# z ��Z� � $��Popup��$��Bottom=�#��z $
 True��$|�False��$��Slide=�.��� $��DropDown��$
 True��#��z #��z .+��� $ DropDownBorder��
������ 
��� � �$��1q��� $��4,6,4,6q�$
 True��.���� $
 True��$ 	Contained=� P�  �@��HasItems$ False��. ��� $ DropDownBorder�� � ��$ 95��P�  � {�$ False��. ���  � ��
 �����P�  �@��
IsGrouping$
 True��. ���  � ��$ False��P� $  Popup�� �@�AllowsTransparency$
 True��. ��� $ DropDownBorder�� �@��CornerRadius$ 0���� " �� P�  �@J�	IsFocused$
 True��. ���  � ��
 � � �.���  � ��
 �������  � ��
 ���� ��  � ��
 ���� �� "   �� ! �� *
verifier+	" false.a���  � ��
 �  ����  � ��
 ������� ! �� *
verifier+" true.a���  � ��
 � � ���  � ��
 �����.��� ���� # �� Color$# Black��.+�� ���� $ �� ImageSource$$ Images/background.png��% j� Stretch$% UniformToFill=�& � RowDefinitions& �� $	��255 ��� $	��220 �.+��� $��0��$��0,0,0,0q�
������ ._��� .+��� 
�������$��Center=�$��
MontSerrat)�$��24(�$
��Bold"�.��Liste des Plantes à Importer&   System.Windows.Controls.DataGrid  -   '  Name$' 	DataGridP��$	��180��
������ (   AutoGenerateColumns$( False��)   	RowHeight$) 40Q����� *list+ =  7System.Windows.Controls.Primitives.DataGridColumnHeader*  $System.Windows.Controls.DataGridCell:  4System.Windows.Controls.Primitives.DataGridRowHeader��%a  '        '  �     '      '  -    '�� R    'n� �    '�� �    �� "  .���  � ��
 ���� ��  � ��
 � � ���  � ��$ 1q���  � ��
 �������  � ��$ Center=��� "  .���  � ��
 ���� ��  � ��
 � � ���  � ��$ 1q���  � ��
 �������  � ��$ Center=��� "  .���  � ��
 ���� �� "  .���  � ��
 ���� �� " ��.���  � ��
 ���� ��  � ��
 � � ���  � ��
 � � ���  � ��$ 3���� " n�.���  � ��
 � � ���  � ��$ 3���� " ��.���  � ��
 � � �*   Columns* 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn+   Header$+ Verification��1	  +System.Windows.Controls.DataGridBoundColumn, 	  ElementStyle, �� " ��.���  � ��
 ����� �� ! �� *
verifier+	" false.a���  � ��
 �  ����  � ��
 ������� ! �� *
verifier+" true.a���  � ��
 � � ���  � ��
 �����  -   
Foreground
- �����$+ Etat de Santé��. 	  Binding. �� *ETATDESANTE+, �� " ��.���  � ��
 ����  �� ! �� *ETATDESANTE+" PLANTE EN DANGER.a���  � ��
 �  ���� ! �� *ETATDESANTE+" MAUVAISE SANTE.a���  � ��
 � ����� ! �� *ETATDESANTE+" SANTE MOYENNE.a���  � ��
 �2͚��� ! �� *ETATDESANTE+" BONNE SANTE.a���  � ��
 � � �  $+ Date Entrée��. �� *DE+  $+ Identification��. �� *ID+  $+ 
Provenance��. �� *
PROVENANCE+  $+ Description��. �� *DESCRIPTION+  $+ Stade��. �� *STADE+  $+ Entreposage��. �� *ENTREPOSAGE+  
- �����$+ 	Activité��. �� *AC+, �� " ��.���  � ��
 ����� �� ! �� *AC+" Inactif.a���  � ��
 �  ���� ! �� *AC+	" Actif.a���  � ��
 � � �  $+ Date Retrait��. �� *DR+  $+ Raison de Retrait��. �� *RAISONDERETRAIT+  $+ Responsable��. �� *RESPONSABLE+  $
+ Note��. �� *NOTE+4
  .System.Windows.Controls.DataGridTemplateColumn
  $+ Actions��/ 
  CellTemplate/ �� .R��� 0 �� Orientation$0 
Horizontal=�.+��� 1 ��Name$1 btnmodifier��-   2 � Cursor$
2 Hand��$��Modifier��$��0q�
������ 
��� ���$��2q�
3 � Tag3 �� *	Rownumber+�� $1 btnsupprimer��-   $
2 Hand��$��	Supprimer��$��0q�
������ 
���  ��$��2q�3 �� *	Rownumber+�� $1 btnannulerretrait��-   $
2 Hand��$��Annuler Retrait��$��0q�
������ 
����  �$��2q�3 �� *	Rownumber+{��� *AR+�� $0 
Horizontal=�$��Center=�$��0,10,0,0q�
������ .+��� -   $1 importation��
������ 
��� � �$��1q�$��	30,0,30,0q�$��Center=�
�������$��Importer��� -   4 �Name$4 progressbar��$��0,0,0,0q�$��25��$	��100��
��������� $��1��$��0,25,0,0q�
������ $��Center=�
��� � �$��1q�5 �� CornerRadius$5 15��._��� .+��� $��Center=�
�������$��
MontSerrat)�$��24(�$
��Bold"�.��%#Correction des données des Plantes�� $0 
Horizontal=�.+��� 
�������$��
MontSerrat)�.��Etat de Santé�� -   6 ��Name$6 ETATDESANTE��$	��100��
���   �$��1q�$��10,0,0,0q��� 
�������$��
MontSerrat)�$��10,0,0,0q�.��Date Entrée(  "System.Windows.Controls.DatePicker  -	   7  Name$7 
DATEENTREE��$	��100��
���   �$��1q�$��10,0,0,0q��� 
�������$��
MontSerrat)�$��10,0,0,0q�.��
Provenance�� -
   $ 
PROVENANCE��$��
MontSerrat)�$	��100��$��10,0,0,0q��� 
�������$��
MontSerrat)�$��10,0,0,0q�.��Stade�� -   $6 STADE��$	��100��$��
MontSerrat)�
���   �$��1q�$��10,0,0,0q��� $0 
Horizontal=�.+��� 
�������$��
MontSerrat)�$��0,10,0,0q�.��Description�� -   8 ��Name$8 DESCRIPTION��$	��110��$��	10,10,0,0q�$��40��$��
MontSerrat)��� 
�������$��
MontSerrat)�$��	10,10,0,0q�.��Entreposage�� -   $6 ENTREPOSAGE��$��
MontSerrat)�$	��100��
���   �$��1q�$��10,0,0,0q�$��25���� 
�������$��
MontSerrat)�$��	10,10,0,0q�.��	Activité�� -   $6 ACTIVITE��$��
MontSerrat)�$��10,0,0,0q�$	��100��$��25���� 
�������$��
MontSerrat)�$��	10,10,0,0q�.��Responsable�� -   $6 RESPONSABLE��$��
MontSerrat)�$��80��$��25��$��10,0,0,0q��� $0 
Horizontal=�.+��� 
�������$��0,10,0,0q�$��
MontSerrat)�.��Date Retrait  -   $7 DATERETRAIT��$��
MontSerrat)�$��	10,10,0,0q�
���   �$��1q��� 
�������$��
MontSerrat)�$��	10,10,0,0q�.��Raison de Retrait�� -   $6 RAISONRETRAIT��$	��100��$��25��$��	10,10,0,0q�$��
MontSerrat)��� 
�������$��
MontSerrat)�$��	10,10,0,0q�.��Note�� -   $
 NOTE��$��
MontSerrat)�$	��100��$��25��$��	10,10,0,0q��� $0 
Horizontal=�$��Center=�.+��� -   $1 boutonmodification��${�False��$��Center=�$��
30,10,30,0q�$��60��$��20��$��Modifier��
�������
��� ���
��� ����� -   $1 annulermodification��${�False��$��Center=�$��
30,10,30,0q�$��60��$��20��$��Annuler��
�������
���  ��
���  ��