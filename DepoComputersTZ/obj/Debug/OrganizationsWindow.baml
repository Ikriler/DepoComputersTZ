   M S B A M L   `   `   `  ����J  FDepoComputersTZ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:DepoComputersTZDepoComputersTZ  5   	   )    #DepoComputersTZ.OrganizationsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:DepoComputersTZ     5   	     � Title$  Организации��5   	   $	��450��6   $
��1000��6*   .��5	      �  � ColumnDefinitions 5
   
   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      $
��0.4* �6   6,   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      $
��0.4* �6   6,   .+�5   
   �� -   5         ��Name$ GoBackButton��5      $��0��6'   $��0��67   $��5q�6D   .��6j   
Назад6q   �� 5   
   -   5        $ AddOrganization��5      $��1��6*   $��5��6:   $��5q�6G   .��6p   Добавить6z   �� 5   
   -   5        $ ImportButton��5      $��2��6'   $��5��67   $��5q�6D   .��6j   Импорт6r   �� 5   
   -   5        $ ExportButton��5      $��3��6'   $��5��67   $��5q�6D   .��6j   Экспорт6s   �� 5   
   -   5         ��Name$ OrganizationsList��5      $��2��6.   $��1��6>   $��2��6K   $��4��6_    �� View 5      �� 5       �� AllowsColumnReorder . .P�5       �� $��Название��6P    �� DisplayMemberBinding 6%   ��  �� Path$
 name�6P   �� 5!      $��ИНН��6O    6%   �� $	 inn�6O   �� 5"      $��Юр. адрес��6U    6%   �� $ 	uraddress�6U   �� 5#      $��Факт. адрес��6W    6%   �� $ factaddress�6W   5$      5&      �� 5(   
   $��0��6   $��1��6    $��10q�6-   $��Center=�69   $��Center=�6]   .��6   Название6�   �� 5)   
   -   5        	 ��Name$	 nameTextBox��5)      $��1��6'   $��1��67   $��20q�6D   $��Center=�6P   $��Center=�6r   6�   �� 5+   
   $��0��6   $��2��6    $��10q�6-   $��Center=�69   $��Center=�6]   .��6   ИНН6�   �� 5,   
   -   5        $	 
innTextBox��5,      $��1��6&   $��2��66   $��20q�6C   $��Center=�6O   $��Center=�6q   6�   �� 5.   
   $��0��6   $��3��6    $��10q�6-   $��Center=�69   $��Center=�6]   .��6   Юр. адрес6�   �� 5/   
   -   5        $	 uraddressTextBox��5/      $��1��6,   $��3��6<   $��20q�6I   $��Center=�6U   $��Center=�6w   6�   �� 51   
   $��0��6   $��4��6    $��10q�6-   $��Center=�69   $��Center=�6]   .��6   Факт. адрес6�   �� 52   
   -	   5        $	 factaddressTextBox��52      $��1��6.   $��4��6>   $��20q�6K   $��Center=�6W   $��Center=�6y   6�   53      54      