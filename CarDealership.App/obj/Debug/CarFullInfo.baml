   M S B A M L   `   `   `  ����L  HCarDealership.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:CarDealership.AppCarDealership.App  5   	   #    CarDealership.App.CarFullInfo   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:CarDealership.App     5   	     � Title$  Car`s Full Info��5   	   $��708.8��6!   $��951.609��60   .��5	      � .+�5
   
   �� -   5         ��Name$ image��5
      $
��Left=�6   $	��354��6:   $��
187,24,0,0q�6G   $	��Top=�6[   $	��568��6s   $��UniformToFill=�6   �� 5   
   -   5         ��Name$ label��5      $
��Make��6   $
��Left=�6.   $��151,383,0,0q�6I   $	��Top=�6^   $��20(�6v   $��Copperplate Gothic Light)�6�   �� 5   
   -   5        $ 	makeLabel��5      $�� ��6#   $
��Left=�6.   $��231,383,0,0q�6I   $	��Top=�6^   $��20(�6v   $��Copperplate Gothic Light)�6�   �� 5   
   -   5        $ label1��5      $��Model��6    $
��Left=�60   $��137,414,0,0q�6K   $	��Top=�6`   $��20(�6x   $��Copperplate Gothic Light)�6�   �� 5   
   -   5        $ 
modelLabel��5      $�� ��6$   $
��Left=�6/   $��231,414,0,0q�6J   $	��Top=�6_   $��Copperplate Gothic Light)�6w   $��20(�6�   �� 5   
   -   5        $ label3��5      $��Production Year��6    $
��Left=�6:   $��
23,478,0,0q�6U   $	��Top=�6i   $��Copperplate Gothic Light)�6�   $��20(�6�   �� 5   
   -   5        $ 	yearLabel��5      $�� ��6#   $
��Left=�6.   $��231,478,0,0q�6I   $	��Top=�6^   $��Copperplate Gothic Light)�6v   $��20(�6�   �� 5   
   -   5        $ label2��5      $��External Color��6    $
��Left=�69   $��
31,515,0,0q�6T   $	��Top=�6h   $��Copperplate Gothic Light)�6�   $��20(�6�   �� 5   
   -	   5        $ 
colorLabel��5      $�� ��6$   $
��Left=�6/   $��231,515,0,0q�6J   $	��Top=�6_   $��Copperplate Gothic Light)�6w   $��20(�6�   �� 5   
   -
   5        $ label4��5      $��Price��6    $
��Left=�60   $��148,446,0,0q�6K   $	��Top=�6`   $��Copperplate Gothic Light)�6x   $��20(�6�   �� 5   
   -   5        $ 
priceLabel��5      $�� ��6$   $
��Left=�6/   $��231,446,0,0q�6J   $	��Top=�6_   $��Copperplate Gothic Light)�6w   $��20(�6�   �� 5   
   -   5        $ label5��5      $
��Fuel��6    $
��Left=�6/   $��575,383,0,0q�6J   $	��Top=�6_   $��20(�6w   $��Copperplate Gothic Light)�6�   �� 5   
   -   5        $ label6��5      $��Transmission��6    $
��Left=�67   $��482,414,0,0q�6R   $	��Top=�6g   $��20(�6   $��Copperplate Gothic Light)�6�   �� 5   
   -   5        $ label7��5      $��	Km Passed��6    $
��Left=�64   $��513,446,0,0q�6O   $	��Top=�6d   $��20(�6|   $��Copperplate Gothic Light)�6�   �� 5   
   -   5        $ label8��5      $��Engine Displacement��6    $
��Left=�6>   $��399,480,0,0q�6Y   $	��Top=�6n   $��20(�6�   $��Copperplate Gothic Light)�6�   �� 5   
   -   5        $ label9��5      $��
HorsePower��6    $
��Left=�65   $��485,515,0,0q�6P   $	��Top=�6e   $��20(�6}   $��Copperplate Gothic Light)�6�   �� 5   
   -   5        $ 	fuelLabel��5      $�� ��6#   $
��Left=�6.   $��658,383,0,0q�6I   $	��Top=�6^   $��20(�6v   $��Copperplate Gothic Light)�6�   �� 5   
   -   5        $ 	tranLabel��5      $�� ��6#   $
��Left=�6.   $��658,414,0,0q�6I   $	��Top=�6^   $��20(�6v   $��Copperplate Gothic Light)�6�   �� 5   
   -   5        $ edLabel��5      $�� ��6!   $
��Left=�6,   $��658,478,0,0q�6G   $	��Top=�6\   $��20(�6t   $��Copperplate Gothic Light)�6�   �� 5   
   -   5        $ hpLabel��5      $�� ��6!   $
��Left=�6,   $��658,515,0,0q�6G   $	��Top=�6\   $��20(�6t   $��Copperplate Gothic Light)�6�   �� 5   
   -   5        $ kmLabel��5      $�� ��6!   $
��Left=�6,   $��658,446,0,0q�6G   $	��Top=�6\   $��20(�6t   $��Copperplate Gothic Light)�6�   �� 5   
   -   5        $ desLabel��5      $�� ��6"   $
��Left=�6-   $��
31,625,0,0q�6H   $	��Top=�6\   $��20(�6t   $��Copperplate Gothic Light)�6�    J� RenderTransformOrigin$ -0.62,0.571&�6�   �� 5    
   -   5         ��Name$ button��5       $
��Next��6!   $
��Left=�60   $��823,341,0,0q�6K   $	��Top=�6`   $��75��6x   {�.  6�   �� 5!   
   -   5        $ 
errorLabel��5!      $ ��The car has no images yet!��6$   $
��Left=�6I   $��174,148,0,0q�6d   $	��Top=�6y   $��Copperplate Gothic Light)�6�   $��36(�6�   $y�Hidden=�6�   �� 5"   
   -   5        $ label10��5"      $��Seller��6!   $
��Left=�62   $��133,552,0,0q�6M   $	��Top=�6b   $��20(�6z   $��Copperplate Gothic Light)�6�   �� 5#   
   -   5        $ sellerNames��5#      $�� ��6%   $
��Left=�60   $��246,552,0,0q�6K   $	��Top=�6`   $��20(�6x   $��Copperplate Gothic Light)�6�   �� 5$   
   -   5        $ label11��5$      $��Seller`s PhoneNumber��6!   $
��Left=�6@   $��
23,588,0,0q�6[   $	��Top=�6o   $��20(�6�   $��Copperplate Gothic Light)�6�   �� 5%   
   -   5        $ 
phoneLabel��5%      $�� ��6$   $
��Left=�6/   $��305,588,0,0q�6J   $	��Top=�6_   $ -0.738,0.965&�6w   $��Copperplate Gothic Light)�6�   $��20(�6�   5'      5(      