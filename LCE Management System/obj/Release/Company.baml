   M S B A M L   `   `   `  ���� P  LLCE Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:LCE_Management_SystemLCE_Management_System  #    LCE_Management_System.Company   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     5local#clr-namespace:LCE_Management_System     V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  .��� ���#303030  � ColumnDefinitions  �� $��3* ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto � � RowDefinitions �� $
��auto ��� $��2* �.+��� -    ��Name$ image��$��0��$��Right=�$	��140��$#��./Resources/companybanner.jpg��$
��Fill=�$��	20,0,20,0q�$��Bottom=��� -    ��Name$ btnAddCompany��$��1��$��Center=�$��Bottom=�$��75��
������ $��10q�.���� .+�'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ 
PlusCircle=�$��70��$��70�����#1585B5$��Center=�$��Center=��� $��Center=����#1585B5$��30(�Add�� -   $ btnDeleteCompany��$��2��$��Center=�$��Bottom=�$	��100��
������ $��10q�.���� .+�  $ Delete=�$��70��$��70�����#1585B5$��Center=�$��Center=��� $��Center=����#1585B5$��30(�Delete�� -    ��Name$ comboBoxSearch��$��3��$
��Left=�$��Bottom=�$	��120��$��	20 20 0 0q��� -    ��Name$ 
searchText��$��4��$��23�� �� TextWrapping$
 Wrap=�$��Bottom=�$��TextBox��$	��120��$��
10 20 10 0q��� $��0��$��5�����#1585B5$��0,0,0,4q�$	��140��$	��Top=�&   System.Windows.Controls.DataGrid  -     Name$ dataGrid��$	��500��$	��900��$��1��$��5��$��Center=�$��Center=�	   
IsReadOnly	 . 
   AutoGenerateColumns
 .  $��20,20,20,20q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Company Id Number��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	CompanyId+  $ 4* $ Company Name�� �� *CompanyName+