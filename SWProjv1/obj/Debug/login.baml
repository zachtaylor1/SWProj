   M S B A M L   `   `   `  ����C  ?SWProjv1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:SWProjv1SWProjv1  5          SWProjv1.login   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:SWProjv1     5        N� Title$  login��5	      .��5
      � -   5        $
��grid��5
      ���	#FFE5E5E5 � ColumnDefinitions 5   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� $��1��6   $��1��6%   $��2��62   .+�5      �� $��Username��6    �� Padding$ 10q�6(   $��Center=�65   � 5      .+�5      �� -   5        $��username_inp��5      $	��227��6.   $	��250��6=   $��16(�6L   �� 5       J� IsHitTestVisible .  $��GenericUsername��65   
�������$��16(�6c   $	��250��6q   ��5      �� 5       �� 
TargetType" ��6    .�5      ��  �� Property � y� �� Value$ 	Collapsed=�6;    �� Triggers 5      ^� 5   "   	 ^� 
Conditions	 5   &   �� 5    *   
 �� Binding
 64   ��  �� ElementName$ username_inp�� �� Path$ IsKeyboardFocused� �� Value	 False6y   �� 5!   *   
 64   �� $ username_inp��$
 Text�  6l   .0�5#   &   ��  � y�$ Visible=�6C   5$   #   5&      5(      5)      �� 5*      $��Password��6   $ 10q�6(   $��Center=�65   � 5+      .+�5,      �� -   5        $��password_inp��5,       �� 	MaxLength$ 23��6.   $	��227��6=   $	��250��6L   $��16(�6[   �� 5-       .  $��	*********��65   
�������$	��250��6]   $��16(�6l   ��5.      �� 5/      " ��6    .�50      ��  � y�$ 	Collapsed=�6;    51      ^� 52   "   	 53   &   �� 54   *   
 64   �� $ password_inp��$ IsKeyboardFocused�	 False6y   �� 55   *   
 64   �� $ password_inp��$
 Text�  6l   .0�57   &   ��  � y�$ Visible=�6C   58   #   5:      5<      5=      �� 5>      -   5        $��	login_btn��5>      $��Log In��6&   $��20q�67   $��Center=�6C   6`   �� 5?      -   5        $��HelpLogin_btn��5?      ���	#FFE5E5E5$��0q�6A   
����  �$��Center=�6g   .��5@      �� -   5        $��HelpLogin_txt��5@      $ ��Having trouble logging in?��61   5A      5B      5C      5D      