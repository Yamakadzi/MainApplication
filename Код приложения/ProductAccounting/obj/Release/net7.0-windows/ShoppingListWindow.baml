   M S B A M L   `   `   `  ���� L  HProductAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ProductAccountingProductAccounting  *    $ProductAccounting.ShoppingListWindow   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:ProductAccounting       � Title$!  Список Покупок��$	��530��$	��800�� � 
ResizeMode$ NoResize=����#DEF4FE.���  � RowDefinitions �� $
��auto ��� �� $
��auto ��� $
��auto � � ColumnDefinitions �� �� .+��� $��
Поиск��$��25(�
���   �
���   �$��1q��� -    ��Name$ SearchTextBox��$��1��$��Center=�$��20(����#DEF4FE
���   �
���   �&   System.Windows.Controls.DataGrid  -     Name$ DGridProductsList��$��1��$��2��   AutoGenerateColumns$ False��   
IsReadOnly$
 True�����#DEF4FE � 	Resources *  $System.Windows.Controls.DataGridCell	 �� 
TargetType
 �� Property �� Value=  7System.Windows.Controls.Primitives.DataGridColumnHeader��%f   '        '  )     �� "	  .��� 
 � �� �#DEF4FE�� "	  .��� 
 � �� �#DEF4FE   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$' !Название продукта��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *NameProduct+  $ Количество��$ *  �� *Count+4  .System.Windows.Controls.DataGridTemplateColumn  $
 auto    CellTemplate �� .R���  �� Orientation$ 
Horizontal=�.+���  ��Name$ PurchasedButton��-   $��Куплено�����#318EAB
���   �
���   ��� $ RemoveButton��-   $��Удалить�����#845EC2
���   �
���   ��� -   $ ExportListProduct��$/��)Экспортировать данные��$��25(�$��2��$��2�����#00C2A8
���   �
���   ��� -   $ 
MyProducts��$��Мои продукты��$��25(�$��3�����#845EC2
���   �
���   ��� -   $ AddMyProducts��$%��Добавить продукт��$��25(�$��3��$��1�����#318EAB
���   �
���   �