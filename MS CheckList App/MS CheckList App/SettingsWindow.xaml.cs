using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MS_CheckList_App
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();

            //Set Profile Name
            chbx_AutoSave.IsChecked = MainWindow.profileLoaded.AutoSave;
            chbx_AutoReset.IsChecked = MainWindow.profileLoaded.AutoReset;

        }//end of SettingsWindow constructor

        private void btn_SaveSettings_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.profileLoaded.AutoSave = (bool)chbx_AutoSave.IsChecked;
            MainWindow.profileLoaded.AutoReset = (bool)chbx_AutoReset.IsChecked;
            
        }//end of btn_SaveSettings_Click
    }//end of SettingsWindow partial class
}//end of namespace
