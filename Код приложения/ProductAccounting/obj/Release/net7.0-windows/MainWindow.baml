   M S B A M L   `   `   `  ���� L  HProductAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ProductAccountingProductAccounting  "    ProductAccounting.MainWindow   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:ProductAccounting       � Title$  Авторизация��$	��530��$	��800�����#DEF4FE � 
ResizeMode$ NoResize=�.���  � RowDefinitions �� �� $
��auto ��� $
��auto ��� $
��auto ���  � ColumnDefinitions �� �� �� �� .+��� $��
Логин��$��1��$��1��$��1q�$��25(�
���   �
���   ��� $��Пароль��$��2��$��1��$��1q�$��25(�
���   �
���   ��� -    ��Name$ LoginTextBox��$��1��$��2��$��Center=�$��20(�
���   ����#DEF4FE
���   �G� -    G�Name$ PasswordBox��$��2��$��2��$��Center=�$��20(����#DEF4FE
���   �
���   ��� -    ��Name$ RegistrationButton��$��Регистрация��$��3��$��1��$��25(����#845EC2
���   �
���   ��� -   $ AuthorizationButton��$"��Авторизоваться��$��3��$��2��$��25(����#318EAB
���   �
���   �