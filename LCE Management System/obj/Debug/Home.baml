   M S B A M L   `   `   `  ����P  LLCE Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:LCE_Management_SystemLCE_Management_System  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5           LCE_Management_System.Home   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:LCE_Management_System     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      .��5
      � ���#303030  � ColumnDefinitions  5   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   #  LiveCharts.Wpf.CartesianChart  &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$
 Left=�6A   
�������   Series 6   �� *SeriesCollection+   AxisX 5        LiveCharts.Wpf.Axis     Title$  ��6      
Foreground
 �����   Labels 6$   �� *Labels+6S      AxisY 5        $ RM��6   
 �����	   LabelFormatter	 6&   �� *	Formatter+6a   5      �� 5   
   -   5        
 ��Name$
 DisplayCountOfInvoice��5      $��1��64   $��0��6D   $��Retrieving Data...��6Q   ���#1585B5$��Center=�6�   $��Center=�6�   $��80(�6�   5      �� 5   
   -   5        $
 DisplayCountOfInvoice2��5      $��1��65   $��0��6E   $$��Invoice created in this month!��6R   
�������$��Center=�6�   $��Center=�6�   $��	0,120,0,0q�6�   $��30(�6�   $
��Wrap=�6�   5       �� 5!   
   $��0��6   $��1��6$   $��Not yet implemented��61   
�������$��Center=�6_   $��Center=�6z   5"      �� 5#   
   -   5        $
 DisplayBusiness��5#      $��1��6.   $��1��6>   $��Retrieving Data...��6K   ���#1585B5$��Center=�6{   $��Center=�6�   $��80(�6�   5$      �� 5%   
   -   5        $
 DisplayBusiness2��5%      $��1��6/   $��1��6?   $4��.Total amount of invoice created in this month!��6L   
�������$��Center=�6�   $��Center=�6�   $��	0,120,0,0q�6�   $��20(�6�   $
��Wrap=�6�   5&      �� 5(   
   -   5        $��2��5(      $��2��6%   $��Center=�66   $��Center=�6Q   $��50��6n   $��20��6y   
���   �.��6�   	Refresh6�   5)      5+      