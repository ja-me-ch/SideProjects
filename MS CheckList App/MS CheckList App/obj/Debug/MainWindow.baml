   M S B A M L   `   `   `  ����K  GMS CheckList App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MS_CheckList_AppMS_CheckList_App  5   	   !    MS_CheckList_App.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:MS_CheckList_App     5   	     � Title$  MS CheckList App��5   	   $	��480��6"   $	��800��6/   .��5	      �  � 	Resources 5
   
    �� 
TargetType �� Property �� Value��%�   '��       �� 5      " ��6   .�5      ��  � ��
 �����60   �� 5       � ��$ 1q�64   �� 5       � ��$ 1 1 1 1q�6+   5      5       � ColumnDefinitions 5   
   �� 5      $��15 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��15 �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��15 �6   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5    
   o� -   5         o�Name$ _menu��5       $��0��5!      $��10��5"      $��0��5#      .@�5$      m� $
��File��6   .@�5%      m� -   5         m�Name$ MenuItem_New��5%      $	��New��62   6?   m� 5&      -   5        $ MenuItem_Load��5&      $
��Load��62   6@   m� 5'      -   5        $ MenuItem_Save��5'      $
��Save��62   6@   m� 5(      -   5        $ MenuItem_Exit��5(      $
��Exit��62   6@   5)      m� 5*      $��Profile��6   .@�5+      m� -   5        $ MenuItem_AutoSave��5+      $��	Auto Save��66   	 m� 	IsChecked	 6I   �� *
AutoSave+
 �� Mode$
 TwoWay=�6u   m� 5,      -   5        $ MenuItem_AutoReset��5,      $��
Auto Reset��67   	 6K   �� *	AutoReset+$
 TwoWay=�6x   5-      m� 5.      $��Tools��6   .@�5/      m� -   5        $ MenuItem_ResetAll��5/      $��	Reset All��66   6I   m� 50      -	   5        $ MenuItem_ResetDaily��50      $��Reset All Dailies��68   6S   m� 51      -
   5        $# MenuItem_ResetWeeklyWednesday��51      $$��Reset All Weeklies (Wednesday)��6B   6j   m� 52      -   5        $  MenuItem_ResetWeeklySunday��52      $!��Reset All Weeklies (Sunday)��6?   6d   53      m� 54      $
��Help��6   .@�55      m� -   5        $ MenuItem_ViewHelp��55      $��	View Help��66   6I   m� 56      -   5        $ MenuItem_About��56      $��About��63   6B   57      58      �� 5G   
   $��
Early Game��6   $��1��5H      $��2��5I      �� 5J   
   $��Mid Game��6   $��2��5K      $��2��5L      �� 5M   
   $��	Late Game��6   $��3��5N      $��2��5O      �� 5P   
   $��Arcane River��6   $��4��5Q      $��2��5R      �� 5V   
   -   5         ��Name$ StackPanel_1��5V      $��3��5W      $��1��5X      $��1 1 1 1q�5Y      .+�5Z      �� -   5         ��Name$ 
Border_1_1��5Z      $��1��5[      $��3��5\      $��1q�5]      ._�5^      �� -   5        $ StackPanel_1_1��5^      .+�5_      �� -   5        $��	chbx_eZak��5_      $��
Easy Zakum��60    d� 	IsChecked 6E   �� *EZak+$
 TwoWay=�6m   �� 5`      -   5        $��	chbx_nZak��5`      $��Normal Zakum��60    6G   �� *NZak+$
 TwoWay=�6o   �� 5a      -   5        $��	chbx_cZak��5a      $��Chaos Zakum��60    6F   �� *CZak+$
 TwoWay=�6n   5b      5c      �� 5d      -   5        $ 
Border_1_2��5d      $��1��5e      $��4��5f      $��1q�5g      ._�5h      �� -   5        $ StackPanel_1_2��5h      .+�5i      �� -   5        $��chbx_eVLeon��5i      $��Easy VonLeon��62    6I   �� *EVLeon+$
 TwoWay=�6s   �� 5j      -   5        $��chbx_nVLeon��5j      $��Normal VonLeon��62    6K   �� *NVLeon+$
 TwoWay=�6u   �� 5k      -   5        $��chbx_hVLeon��5k      $��Hard VonLeon��62    6I   �� *HVLeon+$
 TwoWay=�6s   5l      5m      �� 5n      -   5        $ 
Border_1_3��5n      $��1��5o      $��4��5p      $��1q�5q      ._�5r      �� -   5        $ StackPanel_1_3��5r      .+�5s      �� -   5        $��chbx_eHTail��5s      $��Easy Horntail��62    6J   �� *EHTail+$
 TwoWay=�6t   �� 5t      -   5        $��chbx_nHTail��5t      $��Normal Horntail��62    6L   �� *NHTail+$
 TwoWay=�6v   �� 5u      -   5        $��chbx_cHTail��5u      $��Chaos Horntail��62    6K   �� *CHTail+$
 TwoWay=�6u   5v      5w      �� 5x      -   5        $ 
Border_1_4��5x      $��1��5y      $��4��5z      $��1q�5{      ._�5|      �� -   5        $ StackPanel_1_4��5|      .+�5}      �� -    5        $��	chbx_eArk��5}      $��Easy Arkarium��60    6H   �� *EArk+$
 TwoWay=�6p   �� 5~      -!   5        $��	chbx_nArk��5~      $��Normal Arkarium��60    6J   �� *NArk+$
 TwoWay=�6r   5      5�      �� 5�      -"   5        $ 
Border_1_5��5�      $��1��5�      $��4��5�      $��1q�5�      ._�5�      �� -#   5        $ StackPanel_1_5��5�      .+�5�      �� -$   5        $��chbx_nRanmaru��5�      $��Normal Ranmaru��64    6M   �� *
NRanmaru+$
 TwoWay=�6y   �� 5�      -%   5        $��chbx_hRanmaru��5�      $��Hard Ranmaru��64    6K   �� *
HRanmaru+$
 TwoWay=�6w   5�      5�      �� 5�      -&   5        $ 
Border_1_6��5�      $��1��5�      $��4��5�      $��1q�5�      ._�5�      �� -'   5        $ StackPanel_1_6��5�      .+�5�      �� -(   5        $��chbx_nHilla��5�      $��Normal Hilla��62    6I   �� *NHilla+$
 TwoWay=�6s   �� 5�      -)   5        $��chbx_hHilla��5�      $��
Hard Hilla��62    6G   �� *HHilla+$
 TwoWay=�6q   5�      5�      �� 5�      -*   5        $ 
Border_1_7��5�      $��1��5�      $��4��5�      $��1q�5�      ._�5�      �� -+   5        $ StackPanel_1_7��5�      .+�5�      �� -,   5        $��chbx_eCygnus��5�      $��Easy Cygnus��63    6I   �� *	ECygnus+$
 TwoWay=�6t   �� 5�      --   5        $��chbx_nCygnus��5�      $��Normal Cygnus��63    6K   �� *	NCygnus+$
 TwoWay=�6v   5�      5�      �� 5�      ._�5�      �� -.   5        $ StackPanel_1_8��5�      .+�5�      �� -/   5        $��chbx_dojDojo��5�      $��Mulung Dojo��63    6I   �� *	DojDojo+$
 TwoWay=�6t   �� 5�      -0   5        $��chbx_mpMonsterPark��5�      $��Monster Park��69    6P   �� *MpMonsterPark+$
 TwoWay=�6�   5�      5�      5�      �� 5�   
   -1   5        $ StackPanel_2��5�      $��3��5�      $��2��5�      $��1 1 1 1q�5�      .+�5�      �� -2   5        $ 
Border_2_1��5�      $��1��5�      $��3��5�      $��1q�5�      ._�5�      �� -3   5        $ StackPanel_2_1��5�      .+�5�      �� -4   5        $��lb_RootAbyss��5�       $��
Root Abyss��64   �� 5�      -5   5        $��chbx_nCQueen��5�      $��Crimson Queen��63    6K   �� *	NCQueen+$
 TwoWay=�6v   �� 5�      -6   5        $��chbx_nPierre��5�      $��Pierre��63    6D   �� *	NPierre+$
 TwoWay=�6o   �� 5�      -7   5        $��chbx_nVonBon��5�      $��Von Bon��63    6E   �� *	NVonBon+$
 TwoWay=�6p   �� 5�      -8   5        $��chbx_nVellum��5�      $��Vellum��63    6D   �� *	NVellum+$
 TwoWay=�6o   5�      5�      �� 5�      -9   5        $ 
Border_2_2��5�      $��1��5�      $��3��5�      $��1q�5�      ._�5�      �� -:   5        $ StackPanel_2_2��5�      .+�5�      �� -;   5        $��lb_ChaosRootAbyss��5�       $��Chaos Root Abyss��69   �� 5�      -<   5        $��chbx_cCQueen��5�      $��Crimson Queen��63    6K   �� *	CCQueen+$
 TwoWay=�6v   �� 5�      -=   5        $��chbx_cPierre��5�      $��Pierre��63    6D   �� *	CPierre+$
 TwoWay=�6o   �� 5�      ->   5        $��chbx_cVonBon��5�      $��Von Bon��63    6E   �� *	CVonBon+$
 TwoWay=�6p   �� 5�      -?   5        $��chbx_cVellum��5�      $��Vellum��63    6D   �� *	CVellum+$
 TwoWay=�6o   5�      5�      �� 5�      -@   5        $ 
Border_2_3��5�      $��1��5�      $��3��5�      $��1q�5�      ._�5�      �� -A   5        $ StackPanel_2_3��5�      .+�5�      �� -B   5        $��chbx_nPinkBean��5�      $��Normal Pink Bean��65    6P   �� *	NPinkBean+$
 TwoWay=�6}   �� 5�      -C   5        $��chbx_cPinkBean��5�      $��Chaos Pink Bean��65    6O   �� *	CPinkBean+$
 TwoWay=�6|   5�      5�      �� 5�      -D   5        $ 
Border_2_4��5�      $��1��5�      $��3��5�      $��1q�5�      ._�5�      �� -E   5        $ StackPanel_2_4��5�      .+�5�      �� -F   5        $��chbx_eMagnus��5�      $��Easy Magnus��63    6I   �� *	EMagnus+$
 TwoWay=�6t   �� 5�      -G   5        $��chbx_nMagnus��5�      $��Normal Magnus��63    6K   �� *	NMagnus+$
 TwoWay=�6v   �� 5�      -H   5        $��chbx_hMagnus��5�      $��Hard Magnus��63    6I   �� *	HMagnus+$
 TwoWay=�6t   5�      5�      �� 5�      -I   5        $ 
Border_2_5��5�      $��1��5�      $��3��5�      $��1q�5�      ._�5�      �� -J   5        $ StackPanel_2_5��5�      .+�5�      �� -K   5        $��	chbx_ePap��5�      $��Easy Papulatus��60    6I   �� *EPap+$
 TwoWay=�6q   �� 5�      -L   5        $��	chbx_nPap��5�      $��Normal Papulatus��60    6K   �� *NPap+$
 TwoWay=�6s   �� 5�      -M   5        $��	chbx_cPap��5�      $��Chaos Papulatus��60    6J   �� *CPap+$
 TwoWay=�6r   5�      5�      �� 5�      -N   5        $ 
Border_2_6��5�      $��1��5�      $��3��5�      $��1q�5�      ._�5�      �� -O   5        $ StackPanel_2_6��5�      .+�5�      �� -P   5        $��chbx_Gollux��5�      $��Gollux��62    6C   �� *Gollux+$
 TwoWay=�6m   �� 5�      -Q   5        $��
chbx_Ursus��5�      $��Ursus��61    6A   �� *Ursus+$
 TwoWay=�6j   �� 5�      -R   5        $��chbx_legQuests��5�      $��Legion Dailies��65    6N   �� *	LegQuests+$
 TwoWay=�6{   �� 5�      -S   5        $��chbx_MapleTour��5�      $��
Maple Tour��65    6J   �� *	MapleTour+$
 TwoWay=�6w   5�      5�      5�      �� 5�   
   -T   5        $ StackPanel_3��5�      $��1 1 1 1q�5�      $��3��5�      $��3��5�      .+�5�      �� -U   5        $ 
Border_3_1��5�      $��1��5�      $��3��5�      $��1q�5�      ._�5�      �� -V   5        $ StackPanel_3_1��5�      .+�5�      �� -W   5        $��chbx_nLotus��5�      $��Normal Lotus��62    6I   �� *NLotus+$
 TwoWay=�6s   �� 5�      -X   5        $��chbx_hLotus��5�      $��
Hard Lotus��62    6G   �� *HLotus+$
 TwoWay=�6q   5�      5�      �� 5�      -Y   5        $ 
Border_3_2��5�      $��1��5�      $��3��5      $��1q�5     ._�5     �� -Z   5        $ StackPanel_3_2��5     .+�5     �� -[   5        $��chbx_nDamien��5     $��Normal Damien��63    6K   �� *	NDamien+$
 TwoWay=�6v   �� 5     -\   5        $��chbx_hDamien��5     $��Hard Damien��63    6I   �� *	HDamien+$
 TwoWay=�6t   5     5     �� 5     -]   5        $ 
Border_3_3��5     $��1��5     $��3��5	     $��1q�5
     ._�5     �� -^   5        $ StackPanel_3_3��5     .+�5     �� -_   5        $��chbx_nLucid��5     $��Normal Lucid��62    6I   �� *NLucid+$
 TwoWay=�6s   �� 5     -`   5        $��chbx_hLucid��5     $��
Hard Lucid��62    6G   �� *HLucid+$
 TwoWay=�6q   5     5     �� 5     -a   5        $ 
Border_3_4��5     $��1��5     $��3��5     $��1q�5     ._�5     �� -b   5        $ StackPanel_3_4��5     .+�5     �� -c   5        $��
chbx_nWill��5     $��Normal Will��61    6G   �� *NWill+$
 TwoWay=�6p   �� 5     -d   5        $��
chbx_hWill��5     $��	Hard Will��61    6E   �� *HWill+$
 TwoWay=�6n   5     5     �� 5     -e   5        $ 
Border_3_5��5     $��1��5     $��3��5     $��1q�5     ._�5     �� -f   5        $ StackPanel_3_5��5     .+�5     �� $��Tenebris Bosses��6    �� 5     -g   5        $��chbx_nGloom��5     $��Gloom��62    6B   �� *NGloom+$
 TwoWay=�6l   �� 5      -h   5        $��chbx_hVHilla��5      $��Verus Hilla��63    6I   �� *	HVHilla+$
 TwoWay=�6t   �� 5!     -i   5        $��chbx_nDarknell��5!     $��Darknell��65    6H   �� *	NDarknell+$
 TwoWay=�6u   �� 5"     -j   5        $��chbx_hBlackMage��5"     $��
Black Mage��66    6K   �� *
HBlackMage+$
 TwoWay=�6y   5#     5$     �� 5%     -k   5        $ 
Border_3_6��5%     $��1��5&     $��3��5'     $��1q�5(     ._�5)     �� -l   5        $ StackPanel_3_6��5)     .+�5*     �� $��Misc.��6    �� 5+     -m   5        $��chbx_comVoyages��5+     $��Commerci Voyages��66    6Q   �� *
ComVoyages+$
 TwoWay=�6   �� 5,     -n   5        $��
chbx_comPQ��5,     $��Commerci PQ (MTU)��61    6M   �� *ComPQ+$
 TwoWay=�6v   �� 5-     -o   5        $��chbx_syQuests��5-     $��Scrapyard Quests��64    6O   �� *
SyQuests+$
 TwoWay=�6{   �� 5.     -p   5        $��chbx_dwtQuests��5.     $��Dark World Tree Quests��65    6V   �� *	DwtQuests+$
 TwoWay=�6�   5/     50     51     �� 56  
   -q   5        $ StackPanel_4��56     $��1 1 1 1q�57     $��4��58     $��3��59     .+�5:     �� -r   5        $ 
Border_4_1��5:     $��4��5;     $��3��5<     $��1q�5=     ._�5>     �� -s   5        $ StackPanel_4_1��5>     .+�5?     �� $��Vanishing Journey��6    �� 5@     -t   5        $��chbx_vjQuests��5@     $��Daily Quests��64    6K   �� *
VjQuests+$
 TwoWay=�6w   �� 5A     -u   5        $��chbx_vjErdaSpectrum��5A     $��Erda Spectrum��6:    6R   �� *VjErdaSpectrum+$
 TwoWay=�6�   �� 5B     $��Chu Chu Island��6    �� 5C     -v   5        $��chbx_chuchuQuests��5C     $��Daily Quests��68    6O   �� *ChuchuQuests+$
 TwoWay=�6   �� 5D     -w   5        $��chbx_chuchuHMuto��5D     $��Hungry Muto��67    6M   �� *ChuchuHMuto+$
 TwoWay=�6|   �� 5E     $��	Lachelein��6    �� 5F     -x   5        $��chbx_lachQuests��5F     $��Daily Quests��66    6M   �� *
LachQuests+$
 TwoWay=�6{   �� 5G     -y   5        $��chbx_lachDDefender��5G     $��Dream Defender��69    6R   �� *LachDDefender+$
 TwoWay=�6�   �� 5H     $��Arcana��6    �� 5I     -z   5        $��chbx_arcQuests��5I     $��Daily Quests��65    6L   �� *	ArcQuests+$
 TwoWay=�6y   �� 5J     -{   5        $��chbx_arcSSavior��5J     $��Spirit Savior��66    6N   �� *
ArcSSavior+$
 TwoWay=�6|   �� 5K     $��Morass & Esfera��6    �� 5L     -|   5        $��chbx_morQuests��5L     $��Morass Daily Quests��65    6S   �� *	MorQuests+$
 TwoWay=�6�   �� 5M     -}   5        $��chbx_esfQuests��5M     $��Esfera Daily Quests��65    6S   �� *	EsfQuests+$
 TwoWay=�6�   5N     5O     5[     � 5\  
   -~   5         �Name$ StatusBar_Grid_1��5\     $��5��5]     $��0��5^     $��6��5_      5`     �� 5a     $��22 �6     5c     �� 5d     $��15 �6#   �� 5e     $��* �6#   �� 5f     $��* �6#   �� 5g     $��* �6#   �� 5h     $��15 �6#   .+�5j     �� -   5         ��Name$ StatusBar_1��5j     $��4��5k     $��0��5l     $��6��5m     5n     �� 5u     $��1��6   $��Center=�5v     �� 5w     $�Current File: ��6    �� 5x     -�   5         ��Name$ statusbar_CurrentFile��5x     5y     �� 5z     $��3��6   $��Center=�5{     �� 5|     $�Status: ��6    �� 5}     -�   5        $ statusbar_Status��5}     5~     5     5�     5�     