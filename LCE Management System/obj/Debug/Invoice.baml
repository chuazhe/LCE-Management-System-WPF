   M S B A M L   `   `   `  ����P  LLCE Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:LCE_Management_SystemLCE_Management_System  5      #    LCE_Management_System.Invoice   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:LCE_Management_System     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5      � ���#303030  � ColumnDefinitions  5   
   �� 5      $��3* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��2* �6   .+�5   
   �� -   5         ��Name$ image��5      $��0��6   $	��140��60   $	��800��6=   $��./Resources/Invoice.jpg��6I   $
��Fill=�6j   $��	20,0,20,0q�6y   $��Bottom=�6�   �� 5   
   -   5         ��Name$ btnAddInvoice��5      $��1��6(   $��Center=�68   $��Bottom=�6U   $��75��6p   
������ $��10q�6�   
������ .��5      �� .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ 
PlusCircle=�6*   $��70��6<   $��70��6G   ���#1585B5$��Center=�6h   $��Center=�6�   �� 5      $��Center=�6   ���#1585B5$��30(�6N   Add6a   5      5      �� 5    
   -   5        $ 
btnRefresh��5       $��2��6%   $��Center=�65   $��Bottom=�6R   $	��100��6m   
������ 
������ $��10q�6�   .��5!      �� .+�5"        $ Refresh=�6*   $��70��69   $��70��6D   ���#1585B5$��Center=�6e   $��Center=�6�   �� 5#      $��Center=�6   ���#1585B5$��30(�6N   	Refresh6e   5$      5%      �� 5'   
   $��3��6   $��Bottom=�6%   $��0,0,0,10q�6@   .+�5(      �� -   5         ��Name$ label��5(      $��3��6$   $
��Left=�64   $��Bottom=�6P   $��From/To Date:��6k   
�������6�   (  "System.Windows.Controls.DatePicker  5*      -   5          Name$ FromDate��5*      $��3��6T   $��Right=�6d   $	��Top=�6�      SelectedDate 6-   ��  �� Path$ FromDate�	 � 	Resources	 5+      :  4System.Windows.Controls.Primitives.DatePickerTextBox
 �� 
TargetType �� Property �� Value ��Name �� StringFormat �� RelativeSource �� AncestorType��%�   '        �� 5,      "
  6   .�5-      ��  � �� 5.      �� 5/   "   .R�50   &   �� $ PART_TextBox��6.   ��51      �� $ SelectedDate�$ 
dd-MM-yyyy�� �� "  53   #   55      56      57      58        59      -   5        $ ToDate��59      $��3��6O   $��Right=�6_   $	��Top=�6|    6*   �� $ ToDate�	 5:      ��%�   '        �� 5;      "
  6   .�5<      ��  � �� 5=      �� 5>   "   .R�5?   &   �� $ PART_TextBox��6.   ��5@      �� $ SelectedDate�$ 
dd-MM-yyyy�� �� "  5B   #   5D      5E      5F      5G      �� 5H      -   5        $ label2��5H      $
��Left=�6$   $��Bottom=�6@   $��Show:��6[   
�������6k   �� 5J      -   5         ��Name$ comboBoxShow��5J      $��3��6-   $
��Left=�6=   $��Bottom=�6X   $��80��6t   $��3,0,0,0q�6�   .@�5K      �� $	��All��6    �� 
IsSelected . 6A   �� 5L      $
��Paid��6   60   �� 5M      $��Unpaid��6   62   5N      5O      �� 5P   
   -	   5        $ 
searchText��5P      $��1��6&   $��1��66    �� TextWrapping$
 Wrap=�6D   $��Bottom=�6X   $
��Left=�6s   $�� ��6�   $	��100��6�   $��5,0,0,0q�6�   �� 5Q      -
   5        $ 	searchBtn��5Q      $��2��6(   $��1��68   $��	10,10,0,0q�6E   $	��120��6X   $��20��6d   $��Bottom=�6p   $
��Left=�6�   .��6�   Search with Company Name5R      �� 5U   
   $��0��6   $��5��6   ���#1585B5$��0,0,0,4q�6H   $	��140��6b   $	��Top=�6o   $��0,0,0,0q�6�   5W      �� 5X   
   -   5        $ label1��5X      $��(Y=Yes, N=No)��6    $��1��68   $��4��6E   $
��Left=�6U   $	��Top=�6p   $��	0,10,20,0q�6�   
�������6�   &   System.Windows.Controls.DataGrid  5Y   
   -   5          Name$ dataGrid��5Y   T   $	��500��6   $
��1000��6#   $��2��63   $��5��6@   $��Center=�6f   $��Center=�6�      
IsReadOnly .    AutoGenerateColumns .  $��
20,0,20,20q�6�   $��5,0,5,0q�6�      Columns 5Z      0  *System.Windows.Controls.DataGridTextColumn  5[      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Invoice No��6C      Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 6W   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6%   �� *	InvoiceId+6W     5\      $ * 6?   $
 Date��6I    6%   �� *DateA+6I     5]      $ 3* 6E   $ Company Name��6P    6%   �� *NameCompany+6P     5^      $ * 6F   $ Price��6P    6%   �� *InvoicePrice+6P     5_      $ * 6?   $ Due Date��6I    6%   �� *DateB+6I     5`      $ * 6D   $
 Paid��6N    6%   �� *
StatusPaid+6N   ��5b      �� 5c      )
  #System.Windows.Controls.DataGridRow"
 
 6   .�5d      -   5        5e      5g      5j      5k      