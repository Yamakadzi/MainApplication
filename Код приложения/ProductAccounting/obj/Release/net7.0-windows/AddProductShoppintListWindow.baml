   M S B A M L   `   `   `  ���� L  HProductAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ProductAccountingProductAccounting  4    .ProductAccounting.AddProductShoppintListWindow   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:ProductAccounting       � Title$J  DДобавление продукта в список покупок��$	��530��$	��800�� � 
ResizeMode$ NoResize=����#DEF4FE.���  � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� �� $
��auto � � ColumnDefinitions �� �� .+��� $0��*Наименование продукта:��$��25(�$��2��
���   �
���   ��� -    ��Name$ NameProductsTextBox��$��2��$��1��$��Center=�$��20(����#DEF4FE
���   �
���   ��� $��Количество��$��2��$��2��$��25(�
���   �
���   ��� -   $ CountProductsTextBox��$��2��$��3��$��Center=�$��20(����#DEF4FE
���   �
���   ��� -    ��Name$ 
AddProduct��$%��Добавить продукт��$��25(�$��1��$��5��$��1�����#318EAB
���   �
���   ��� -   $ ProductList��$!��Список покупок��$��25(�$��0��$��5��$��1�����#845EC2
���   �
���   �