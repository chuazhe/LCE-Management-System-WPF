   M S B A M L   `   `   `  ����P  LLCE Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:LCE_Management_SystemLCE_Management_System  5   	   *    $LCE_Management_System.CompanyInvoice   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:LCE_Management_System     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   .��5      � ���#303030  � ColumnDefinitions  5   
   �� 5      $��3* �6   �� 5      $
��auto �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��2* �6   .+�5   
   �� $��20,0,0,0q�6   .+�5      �� -   5         ��Name$ companyName��5      $��0��6*   $��0��6:   ���#1585B5$��30(�6\   .��6j   Company Name6x   �� 5      -   5        $ 	companyId��5      $��0��6'   $��1��67   
�������.��6W   
Company Id6c   �� 5      -   5        $ companyAddress1��5      $��0��6-   $��2��6=   
�������.��6]   Company Address 16p   �� 5      -   5        $ companyAddress2��5      $��0��6-   $��3��6=   
�������.��6]   Company Address 26p   �� 5      -   5        $ companyAddress3��5      $��0��6-   $��4��6=   
�������.��6]   Company Address 36p   5       �� 5!   
   $��5��6   $��2��6   ���#1585B5$��0,0,0,4q�6H   $��0,10,0,0q�6b   $	��Top=�6t   5"      &   System.Windows.Controls.DataGrid  5$   
   -   5          Name$ 	dataGrid2��5$   T   $	��300��6   $
��1000��6#   $��6��63   $��2��6@   $��Center=�6g   $��Center=�6�      
IsReadOnly .    AutoGenerateColumns .  $��	20,0,20,0q�6�      Columns 5%      0  *System.Windows.Controls.DataGridTextColumn  5&      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Invoice No��6C      Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 6W   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6%   �� *	InvoiceId+6W     5'      $ * 6?   $
 Date��6I   	 6%   �� *DateA+6I     5(      $ 3* 6E   $ Company Name��6P   	 6%   �� *NameCompany+6P     5)      $ * 6F   $ Price��6P   	 6%   �� *InvoicePrice+6P     5*      $ * 6?   $ Due Date��6I   	 6%   �� *DateB+6I     5+      $ * 6D   $
 Paid��6N   	 6%   �� *
StatusPaid+6N   ��5-      �� 5.      
 �� 
TargetType)  #System.Windows.Controls.DataGridRow"
  6   .�5/      -   5        50      52      53      54      