   M S B A M L   `   `   `  ���� E  AQuickServe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:QuickServe
QuickServe      QuickServe.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:QuickServe     -     � Title$  
QuickServe��$��534.771��$��750.634�� � Icon$ q.ico�� � 	Resources    textBoxTemplate �� Path �� UpdateSourceTrigger  nameTemplate  typeTemplate �� SelectedValuePath �� SelectedValue  checkBoxTemplate d� IsThreeState d� 	IsChecked/   )QuickServe.ParameterValueTemplateSelector " parameterValueTemplateSelector	   TextBoxTemplate
   CheckBoxTemplate.   (QuickServe.ParameterNameTemplateSelector ! parameterNameTemplateSelector   TextBoxTemplate.   (QuickServe.ParameterTypeTemplateSelector ! parameterTypeTemplateSelector   TypeTemplate��%�  &	        &	 i     &	 �     &	 '    &	 j    7   7  &	 y    7  &	 �    7  �� .R��� $��10, 0, 10, 0q�$��1q����� $ 	TextValue�$ PropertyChanged=���Z� ��Z� �� .R��� $��10, 0, 10, 0q����� $
 Name���Z� ��Z� �� .R��� -   $ Content��$	��100�� �� $
 Type�.@��� $��Boolean���� $��Number���� $��String���� .R��� $��10, 0, 10, 0q� .   �� $ BooleanValue�  8	   8
    8     8   .��� .+��� -    ��Name$ 
tabControl��$��	0,46,0,43q� �� SelectedIndex �� $ Index����� $ 
Responders�����  �� 
TargetType" ��.���  �� Property � �� �� Value �� *Name+��  � ��$  ��� $��0,85,0,0q� � ColumnDefinitions �� $	��59* ��� $	��41* ��� $
��637* �.+��� -    ��Name$ urlInput��$��28��$��6.513,10,0,0q� �� TextWrapping$
 Wrap=�$��
5, 5, 5, 5q�$	��Top=�$��2��$
��Left=�$	��514������ $ SubURL�$ PropertyChanged=��� -    ��Name$ label��$��Request��$
��Left=�$��	10,10,0,0q�$	��Top=�$��92��$��3���� -    ��Name$ methodInput��$��525.513,10,10,0q�$	��Top=�$��26��$��2�� �� $ MethodIndex�.@��� $	��ANY���� $	��GET���� $
��POST���� -   $ label2_Copy��$��Response��$
��Left=�$��	10,43,0,0q�$	��Top=�$��3��$	��137���� -   $ responseTypeInput��$��2��$��
52,43,10,0q�$	��Top=�$��26�� �� $ ResponderInputType� �� Mode$ OneWay=�.@��� $
��None���� $��String���� $
��File���� $��Values��� -	   $��NoInputType��$
��Left=�$��
10,74,0,54q�$	��723��$��3��
�������� -
   $��StringInputType��$
��Left=�$��
10,74,0,54q�$	��723��$��3��
������� � RowDefinitions �� $	��32* ��� $
��303* �.+��� -   $ stringInput��$
��Left=�$
 Wrap=� �� AcceptsReturn .  �� 
AcceptsTab . $��
10,10,0,10q�$��
5, 5, 5, 5q�$	��703��$��2������ $ String�$ TwoWay=�$ PropertyChanged=�� -   $��FileInputType��$
��Left=�$��
10,74,0,54q�$	��723��$��3��
�������.+��� -   $ label3��$
��Path��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��125��$��33���� -   $ filePath��$��
5, 5, 5, 5q�$
��Left=�$��33��$��
140,10,0,0q�$
 Wrap=�$	��Top=�$	��440������ $ String��� -    ��Name$ button3��$��Browse��$
��Left=�$��	585,9,0,0q�$	��Top=�$	��128��$��34��� -   $��ParameterInputType��$��10,74,10,54q�$��3��
�������.+��� -   $��ParameterList��$��0,47,0,0q����� $ 
Parameters�$ TwoWay=� �� View �� P��� $
��Name�� �� CellTemplateSelector# [  �� Width ��  �� ElementName$ helperField��$ ActualWidth��� $��Value��# [  �� $ helperField��$ ActualWidth��� $
��Type��$	 130��# [ � $y�Hidden=� �� ���� $ ActualWidth��� $��0.66* �.+�� -     �Name$  helperField��$��1���� -   $ button1��$��Add Parameter��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��348��$��32���� -   $ button1_Copy��$��Remove Parameter��$��363,10,10,0q�$	��Top=�$��32���� -   $ button��$��Add Request Handler��$��10,10,547,0q�$	��Top=�$��31���� -   $ label1��$
��Port��$��
0,10,142,0q�$	��Top=�$��31��$��Right=�$��63���� -   $ textBox1��$��31��$��	0,10,10,0q�$
 Wrap=�$	��Top=�$��5,5,5,5q�$��Right=�$	��127������ $
 Port�� $
��10,0q�$��43��$��Bottom=�.+��� -   $ serverButton��$��0,5,10,0q�$	��Top=�$��33��$��Right=�$	��116������ $ Button�$ PropertyChanged=�{��� $ ButtonEnabled��� -   $ label2��$��Server Status: ��$
��Left=�$	��Top=�$��33��$��82���� -   $ serverStatus��$
��Left=�$	��Top=�$��33��$��82��$��87,0,0,0q����� $ Status�$ PropertyChanged=��� -   $ label4��$	��IP:��$
��Left=�$��
222,10,0,0q�$	��Top=�$��31��$��48���� -   $ 	ipAddress��$
��Left=�$��
275,10,0,0q�$	��Top=�$��31��$	��258������ $ IP�