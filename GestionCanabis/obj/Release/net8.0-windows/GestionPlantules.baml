   M S B A M L   `   `   `  ���� I  EGestionCanabis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:GestionCanabisGestionCanabis  %    GestionCanabis.GestionPlantules   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:GestionCanabis       N� Title$  GestionPlantules�� � 	Resources  �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value �� 
TargetType	 �� 	ClickMode
 d� 	IsChecked �� Path �� Mode �� RelativeSource F�Name �� Triggers �� 
TargetName �� Angle J� IsHitTestVisible �� SelectionBoxItem �� SelectionBoxItemTemplate ��Name �� 
IsReadOnly �� 
IsReadOnly �� IsDropDownOpen � AllowsTransparency J� SnapsToDevicePixels � ActualWidth �� MaxDropDownHeight ��Name K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation  P� 
SourceName��%�  '��       '�� z     '�� !    '�� �    '�� &    �� " �� P�  � {�$ False��. ���  � y�$ Hidden=�P�  � {�$
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
 ���� .��� ���� ! �� Color$! Black��.+�� ���� " �� ImageSource$" Images/background.png��# j� Stretch$# UniformToFill=�$ � RowDefinitions$ �� $	��250 ��� $	��220 �.+��� $��0��$��0,0,0,0q�
������ ._��� .+��� 
�������$��Center=�$��
MontSerrat)�$��24(�$
��Bold"�.��Liste des Plantes&   System.Windows.Controls.DataGrid  -   %  Name$% 	DataGridP��$	��180��
������ &   AutoGenerateColumns$& False��'   	RowHeight$' 40Q����� *listp+ =  7System.Windows.Controls.Primitives.DataGridColumnHeader*  $System.Windows.Controls.DataGridCell)  #System.Windows.Controls.DataGridRow:  4System.Windows.Controls.Primitives.DataGridRowHeader��%a  '        '  �     '      '  -    '�� R    'n� �    '�� �    �� "  .���  � ��
 ���� ��  � ��
 � � ���  � ��$ 1q���  � ��
 �������  � ��$ Center=��� "  .���  � ��
 ���� ��  � ��
 � � ���  � ��$ 1q���  � ��
 �������  � ��$ Center=��� "  .���  � ��
 ���� �� "  .���  � ��
 ���� �� " ��.���  � ��
 ���� ��  � ��
 � � ���  � ��
 � � ���  � ��$ 3���� " n�.���  � ��
 � � ���  � ��$ 3���� " ��.���  � ��
 � � �(   Columns( 4  .System.Windows.Controls.DataGridTemplateColumn  )   CellTemplate) �� .R��� -   
�������
* � Tag* �� *ID+
 �� *
rowchecked+$ TwoWay=�0  *System.Windows.Controls.DataGridTextColumn  +   
Foreground
+ �����,	  &System.Windows.Controls.DataGridColumn, 	  Header$, Etat de Santé��- 	  
IsReadOnly$
- True��1
  +System.Windows.Controls.DataGridBoundColumn. 
  Binding. �� *ETATDESANTE+/ 
  ElementStyle/ �� " ��.���  � ��
 ����  �� 0 �� Binding0 �� *ETATDESANTE+1 �� Value1 PLANTE EN DANGER.a���  � ��
 �  ���� 0 �� *ETATDESANTE+1 MAUVAISE SANTE.a���  � ��
 � ����� 0 �� *ETATDESANTE+1 SANTE MOYENNE.a���  � ��
 � ����� 0 �� *ETATDESANTE+1 BONNE SANTE.a���  � ��
 � � �  $, Date Entrée��$
- True��. �� *DE+  $, Identification��$
- True��. �� *ID+/ �� " ��.���  � ��
 ����   $, 
Provenance��$
- True��. �� *
PROVENANCE+  $, Description��$
- True��. �� *DESCRIPTION+  $, Stade��$
- True��. �� *STADE+  $, Entreposage��$
- True��. �� *ENTREPOSAGE+  
+ �����$, 	Activité��$
- True��. �� *AC+/ �� " ��.���  � ��
 �   � �� 0 �� *AC+1 Inactif.a���  � ��
 �  ���� 0 �� *AC+	1 Actif.a���  � ��
 � � �  $, Date Retrait��$
- True��. �� *DR+  $, Raison de Retrait��$
- True��. �� *RAISONDERETRAIT+  $, Responsable��$
- True��. �� *RESPONSABLE+  $
, Note��. �� *NOTE+  $, Code QR��2 	  Width5  /System.Windows.Controls.DataGridLengthConverter$2 70 ) �� .R��� 3 �� Orientation$3 
Horizontal=�
������ .+��� -   
������ $��0q�4 � Cursor$
4 Hand��$��0,0,10,0q�$��25��* �� *ID+���� $" Images/view.png���� -   
������ $��0q�$
4 Hand��$��25��* �� *ID+���� $" Images/print.png���� 5 ��Name$5 RedoQR��-   
������ $��0q�$
4 Hand��$��25��* �� *ID+���� $" Images/redo.png��  $, Actions��) �� .R��� 
������ ._��� $3 
Horizontal=�
������ .+��� $5 btnhistorique��-   $
4 Hand��$��0q�$��25��$��2q�* �� *ID+���� $" Images/history.png���� $5 btnmodifier��-   $
4 Hand��$��Modifier��$��0q�
������ 
��� ���$��2q�* �� *ID+�� $5 btnsupprimer��-   $
4 Hand��$��	Supprimer��$��0q�
������ 
���  ��$��2q�* �� *ID+�� $5 btnannulerretrait��-	   $
4 Hand��$��Annuler Retrait��$��0q�
������ 
����  �$��2q�* �� *ID+{��� *AR+�� $5 	btnexport��-
   $
4 Hand��$��0q�$��25��$��2q�* �� *ID+���� $" Images/export.png���� $3 
Horizontal=�$��Center=�.+��� -   $5 boutonexportation��$
4 Hand��${�False��$��Center=�$��
30,10,30,0q�$��70��$��20��$��Exporter��
�������
��� � �
��� � ��� -   $5 boutonreparationqr��$
4 Hand��${�False��$��Center=�$��
30,10,30,0q�$��70��$��20��$��Réparer QR��
�������
��� ���
��� ����� -   $5 boutonimpression��$
4 Hand��${�False��$��Center=�$��
30,10,30,0q�$��70��$��20��$��Imrpimer��
�������
���  ��
���  ��� -   6 �Name$6 prbar��$y�Hidden=�$	��100��$��20��$��Bottom=�
�������
��������� $��1��
��� � �$��1q�7 �� CornerRadius$7 5��$��0,25,0,0q�
������ $��Center=�._��� .+��� 
�������$��Center=�$��
MontSerrat)�$��24(�$
��Bold"�.��Gestion des Plantes�� $3 
Horizontal=�.+��� 
�������$��
MontSerrat)�.��Etat de Santé�� -   8 ��Name$8 ETATDESANTE��$	��100��$��10,0,0,0q��� 
�������$��
MontSerrat)�$��10,0,0,0q�.��Date Entrée(  "System.Windows.Controls.DatePicker  -   9  Name$9 
DATEENTREE��$	��100��$��10,0,0,0q��� 
�������$��
MontSerrat)�$��10,0,0,0q�.��
Provenance�� -   $ 
PROVENANCE��$��
MontSerrat)�$	��100��$��10,0,0,0q��� 
�������$��
MontSerrat)�$��10,0,0,0q�.��Stade�� -   $8 STADE��$	��100��$��
MontSerrat)�$��10,0,0,0q��� $3 
Horizontal=�.+��� 
�������$��
MontSerrat)�$��0,10,0,0q�.��Description�� -   : ��Name$: DESCRIPTION��$	��110��$��	10,10,0,0q�$��40��$��
MontSerrat)��� 
�������$��
MontSerrat)�$��	10,10,0,0q�.��Entreposage�� -   $8 ENTREPOSAGE��$��
MontSerrat)�$	��100��$��10,0,0,0q�$��25���� 
�������$��
MontSerrat)�$��	10,10,0,0q�.��	Activité�� -   $8 ACTIVITE��$��
MontSerrat)�$��10,0,0,0q�$	��100��$��25���� 
�������$��
MontSerrat)�$��	10,10,0,0q�.��Responsable�� -   $8 RESPONSABLE��$��
MontSerrat)�$��80��$��25��$��10,0,0,0q��� $3 
Horizontal=�.+��� 
�������$��0,10,0,0q�$��
MontSerrat)�.��Date Retrait  -   $9 DATERETRAIT��$	��100��$��
MontSerrat)�$��	10,10,0,0q��� 
�������$��
MontSerrat)�$��	10,10,0,0q�.��Raison de Retrait�� -   $8 RAISONRETRAIT��$	��100��$��25��$��	10,10,0,0q�$��
MontSerrat)��� 
�������$��
MontSerrat)�$��	10,10,0,0q�.��Note�� -   $
 NOTE��$��
MontSerrat)�$	��100��$��25��$��	10,10,0,0q��� 
�������$��
MontSerrat)�$��	10,10,0,0q�.��Type�� -   $
8 TYPE��$��
MontSerrat)�$	��100��$��	10,10,0,0q�$��25��; �� DisplayMemberPath$; DESCRIPTION��< �� SelectedValuePath$< ABBREV������ *listt+�� $3 
Horizontal=�$��Center=�.+��� -   $5 boutonajout��$
4 Hand��$��Center=�$��
30,10,30,0q�$��60��$��20��$��Ajouter��
�������
��� � �
��� � ��� -   $5 boutonmodification��$
4 Hand��${�False��$��Center=�$��
30,10,30,0q�$��60��$��20��$��Modifier��
�������
��� ���
��� ����� -   $5 annulermodification��$
4 Hand��${�False��$��Center=�$��
30,10,30,0q�$��60��$��20��$��Annuler��
�������
���  ��
���  ��