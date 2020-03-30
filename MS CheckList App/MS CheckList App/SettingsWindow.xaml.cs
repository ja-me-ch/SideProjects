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
            txbx_ChangeProfileName.Text = MainWindow.profileLoaded.ProfileName;
        }//end of SettingsWindow constructor

        private void btn_SaveSettings_Click(object sender, RoutedEventArgs e)
        {
            if (txbx_ChangeProfileName.Text != null)
            {
                MainWindow.profileLoaded.ProfileName = txbx_ChangeProfileName.Text;
                this.Close();
            }//end of if
            else
            {
                MessageBox.Show("Profile name cannot be null.", "Error");
            }
        }//end of btn_SaveSettings_Click
    }//end of SettingsWindow partial class
}//end of namespace
