   M S B A M L   `   `   `  ���� P  LLCE Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:LCE_Management_SystemLCE_Management_System  #    LCE_Management_System.Invoice   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     5local#clr-namespace:LCE_Management_System     V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  .��� ���#303030  � ColumnDefinitions  �� $��3* ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto � � RowDefinitions �� $
��auto ��� $
��auto ��� $��2* �.+��� -    ��Name$ image��$��0��$��Right=�$	��140��$��./Resources/Invoice.jpg��$
��Fill=�$��	20,0,20,0q�$��Bottom=��� -    ��Name$ btnAddInvoice��$��1��$��Center=�$��Bottom=�$��75��
������ $��10q�
������ .���� .+�'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ 
PlusCircle=�$��70��$��70�����#1585B5$��Center=�$��Center=��� $��Center=����#1585B5$��30(�Add�� -   $ btnDeleteInvoice��$��2��$��Center=�$��Bottom=�$	��100��
������ 
������ $��10q�.���� .+�  $ Delete=�$��70��$��70�����#1585B5$��Center=�$��Center=��� $��Center=����#1585B5$��30(�Delete�� $��3��$��Bottom=�$��0,0,0,10q�.+��� -    ��Name$ label��$��3��$
��Left=�$��Bottom=�$��From/To Date:��
�������(  "System.Windows.Controls.DatePicker  -     Name$ FromDate��$��3��$��Right=�$	��Top=�   SelectedDate ��  �� Path$ FromDate�	 � 	Resources	 :  4System.Windows.Controls.Primitives.DatePickerTextBox
 �� 
TargetType �� Property �� Value ��Name �� StringFormat �� RelativeSource �� AncestorType��%�   '        �� "
  .���  � �� �� .R��� $ PART_TextBox������ $ SelectedDate�$ 
dd-MM-yyyy�� �� "    -   $ ToDate��$��3��$��Right=�$	��Top=� �� $ ToDate�	 ��%�   '        �� "
  .���  � �� �� .R��� $ PART_TextBox������ $ SelectedDate�$ 
dd-MM-yyyy�� �� "  �� -   $ label2��$
��Left=�$��Bottom=�$��Show:��
��������� -    ��Name$ comboBoxShow��$��3��$
��Left=�$��Bottom=�$��80��$��3,0,0,0q�.@��� $	��All�� �� 
IsSelected . �� $
��Paid���� $��Unpaid���� -	   $ 
searchText��$��2��$��1�� �� TextWrapping$
 Wrap=�$��Bottom=�$
��Left=�$�� ��$	��100��$��5,0,0,0q��� -
   $ 	searchBtn��$��3��$��1��$��0,10,0,0q�$��60��$��20��$��Bottom=�$
��Left=�.��Search�� $��0��$��5�����#1585B5$��0,0,0,4q�$	��140��$	��Top=��� -   $ label1��$��(Y=Yes, N=No)��$��1��$��4��$
��Left=�$	��Top=�$��	0,10,20,0q�
�������&   System.Windows.Controls.DataGrid  -     Name$ dataGrid��$	��500��$
��1000��$��2��$��5��$��Center=�$��Center=�   
IsReadOnly .    AutoGenerateColumns .  $��
20,0,20,20q�$��5,0,5,0q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 
Invoice No��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding �� *	InvoiceId+  $ * $
 Date�� �� *DateA+  $ 3* $ Company Name�� �� *NameCompany+  $ * $ Price�� �� *InvoicePrice+  $ * $ Due Date�� �� *DateB+  $ * $
 Paid�� �� *
StatusPaid+���� )
  #System.Windows.Controls.DataGridRow"
 
 .�-   