   M S B A M L   `   `   `  ����K  GNotas_Unison_App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Notas_Unison.ViewsNotas_Unison.Views  5      "    Notas_Unison.Views.NotasView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Notas_Unison.Views     5        N� Title$  	NotasView��5      .��5
      � $��Stretch=�6   $��Stretch=�6'   
������� � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� 
���   �$��1q�6%    �� CornerRadius$ 5��69   
�������$��10q�5   (   $��0��64   $��0��6A   $��Stretch=�5      $��2��6/   ._�5      �� $��Notas��6   $��24(�6%   $
��Bold"�63    �� Padding$ 10q�5      5      �� 5   
   $��1��6   $��0��6$   $��2��64   $��10q�6H   .��5       � -   5         �Name$ NotasWrapPanel��5       $
��Left=�60   .+�5!      �� ��6   �� *Notas+��5"      �� 5#      .R�5$      �� 
�������$��1q�68   $ 5��6L   $��5q�6]   
������� �� Padding$ 10q�5%   =   $	��200��6J   $	��150��6V   ._�5&   "   �� .+�5(   &   �� $��16(�6H   $
��Bold"�6V   $
��Wrap=�5)   0   $��0,0,0,5q�6D   ��5(   0   �� *Nombre+5)   D   �� 5,   &   $��14(�6K   $
��Wrap=�5-   0   $��0,0,0,10q�6D   ��5,   0   �� *	Contenido+5-   D   5/   #   50      51      53      54      55      �� 58   
   $��+��6   $��32(�6   $
��Bold"�6+   $��Right=�59      $��Bottom=�6-   $��60��5:      $��70��6   $��10q�6(   $��2��5;      $��1��6   ��5<      �� *AgregarNotaCommand+5=      5>      