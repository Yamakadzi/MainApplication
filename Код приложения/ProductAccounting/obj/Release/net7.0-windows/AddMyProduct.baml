   M S B A M L   `   `   `  ���� L  HProductAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ProductAccountingProductAccounting  $    ProductAccounting.AddMyProduct   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:ProductAccounting       � Title$F  @Добавление продукта в мои продукты��$	��530��$	��800�� � 
ResizeMode$ NoResize=����#DEF4FE.���  � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto � � ColumnDefinitions �� �� .+��� $/��)Наименование продукта��$��25(�
���   �
���   ��� $��Срок хранения��$��1��$��25(�
���   �
���   ��� $��Количество��$��2��$��25(�
���   �
���   ��� -    ��Name$ NameProductsTextBox��$��1��$��Center=�$��20(����#DEF4FE
���   �
���   ��� -   $ CountProductsTextBox��$��2��$��1��$��Center=�$��20(����#DEF4FE
���   �
���   �(� $��1��$��1��.��&   System.Windows.Controls.Calendar  -     Name$ ShelfLifeCalendar��   FirstDayOfWeek$ Monday=����#DEF4FE
���   �
���   ��� -    ��Name$ 
AddProduct��$%��Добавить продукт��$��25(�$��1��$��3��$��1�����#318EAB
���   �
���   ��� -   $ 	MyProduct��$��Мои продукты��$��25(�$��0��$��3��$��1�����#845EC2
���   �
���   �