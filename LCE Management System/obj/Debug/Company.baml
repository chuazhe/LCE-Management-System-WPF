   M S B A M L   `   `   `  ����P  LLCE Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:LCE_Management_SystemLCE_Management_System  5      #    LCE_Management_System.Company   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:LCE_Management_System     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5      � ���#303030  � ColumnDefinitions  5   
   �� 5      $��3* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � RowDefinitions 5   
   �� 5   
   $
��auto �6   �� 5   
   $��2* �6   .+�5   
   �� -   5         ��Name$ image��5      $��0��6   $	��140��6/   $	��800��6<   $#��./Resources/companybanner.jpg��6H   $
��Fill=�6o   $��	20,0,20,0q�6~   $��Bottom=�6�   �� 5   
   -   5         ��Name$ btnAddCompany��5      $��1��6(   $��Center=�68   $��Bottom=�6U   $��75��6p   
������ $��10q�6�   .��5      �� .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ 
PlusCircle=�6*   $��70��6<   $��70��6G   ���#1585B5$��Center=�6h   $��Center=�6�   �� 5      $��Center=�6   ���#1585B5$��30(�6N   Add6a   5      5      �� 5   
   -   5        $ btnRefreshCompany��5      $��2��6,   $��Center=�6<   $��Bottom=�6Y   $	��100��6t   
������ $��10q�6�   .��5      �� .+�5         $ Refresh=�6*   $��70��69   $��70��6D   ���#1585B5$��Center=�6e   $��Center=�6�   �� 5!      $��Center=�6   ���#1585B5$��30(�6N   	Refresh6e   5"      5#      �� 5$   
   -   5         ��Name$ 
searchText��5$      $��4��6&   $��23��66    �� TextWrapping$
 Wrap=�6B   $��Bottom=�6V   $��TextBox��6q   $	��120��6�   $��10 20 10 30q�6�   �� 5%   
   -   5        $ 	searchBtn��5%      $��4��6$   $	��100��64   $��20��6@   $��Bottom=�6L   .��6   Search6�   �� 5&   
   $��0��6   $��5��6   ���#1585B5$��0,0,0,4q�6H   $	��140��6b   $	��Top=�6o   &   System.Windows.Controls.DataGrid  5'   
   -   5          Name$ 	dataGrid3��5'   T   $	��500��6   $
��1000��6#   $��1��63   $��5��6@   $��Center=�6g   $��Center=�6�      
IsReadOnly . 	   AutoGenerateColumns	 .  $��	20,0,20,0q�6�   $��5,0,5,0q�6�   
   Columns
 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn   Header$ Company Id Number��6C      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6^   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *	CompanyId+6^     5*      $ 4* 6E   $ Company Name��6P    6%   �� *CompanyName+6P   ��5,      �� 5-       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5.      -   5        5/      51      52      53      