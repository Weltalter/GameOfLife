   M S B A M L   `   `   `  ����K  GGameOfLife.WpfUi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:GameOfLife.WpfUiGameOfLife.WpfUi  5      P LGameOfLife.ViewModels, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\Bclr-namespace:GameOfLife.ViewModels;assembly=GameOfLife.ViewModelsGameOfLife.ViewModels 5	      !    GameOfLife.WpfUi.MainWindow   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:GameOfLife.WpfUi     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      Y
viewmodelsBclr-namespace:GameOfLife.ViewModels;assembly=GameOfLife.ViewModels     5	      J FReactiveUI.Wpf, Version=13.2.0.0, Culture=neutral, PublicKeyToken=null&
reactiveuihttp://reactiveui.net  5
        � Title$  Game Of Life��5      $	��832��6   $
��1200��6'    � 
ResizeMode$ CanMinimize=�64    � SizeToContent$ Manual=�6M   .��5      � $��0,0,0,0q�6   $
��1200��6   .+�5   
   � $	��800��6   $	��800��6   $
��Left=�6(   $��Center=�6C   .+�5      *   $GameOfLife.WpfUi.ClassicGameGridView  -   5          Name$ gameGridView��5   (   5      � 5   
   $��	800,0,0,0q�6   $	��400��6"   $
��Left=�6.   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ Black��6#   � 5      $ 	#FFC1FCF4��6#    � Offset$ 1Q�65   � 5      $ 	#FF07322D��6#   $ 0.176Q�65   5      .+�5      �� -   5         ��Name$ 
tickButton��5      $
��Tick��6)   $��25(�68   $
��Bold"�6F   $��50��6X   $	��100��6d   $��0 0 150 600q�6p   ���	#FF8DCA926�   �� 5      -   5        $ resetButton��5      $��Reset��6*   $��25(�6:   $
��Bold"�6H   $��50��6Z   $	��100��6f   $��150 0 0 600q�6r   ���	#FFCE77776�   �� 5      -   5        	 ��Name$	 InfoGameLabel��5      $��25(�6+   $��0q�69   $
��Bold"�6E   $��40��6W   $��	0 730 0 0q�6c   5      5      5      