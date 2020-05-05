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
        public List<string> listOfWeekdays = new List<string> 
        { 
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday"
        };

        public List<string> listOfHours = new List<string>
        {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"
        };

        public List<string> listOfMinutes = new List<string>
        {
            "00",
            "15",
            "30",
            "45"
        };


        public SettingsWindow()
        {
            InitializeComponent();
            string time = Properties.Settings.Default.DailyResetTime;
            string hour, minute;
            if (time.Length >= 5)
            {
                hour = time.Substring(0, 2);
                minute = time.Substring(3, 2);
                cmbbx_DailyResetTimeHours.SelectedItem = hour;
                cmbbx_DailyResetTimeMinutes.SelectedItem = minute;
            }


            cmbbx_WeeklyResetBoss.SelectedItem = Properties.Settings.Default.WeeklyBossResetDay;
            cmbbx_WeeklyResetQuests.SelectedItem = Properties.Settings.Default.WeeklyQuestResetDay;

            txbx_ChangeProfileName.Text = MainWindow.profileLoaded.ProfileName;
            cmbbx_WeeklyResetBoss.ItemsSource = listOfWeekdays;
            cmbbx_WeeklyResetQuests.ItemsSource = listOfWeekdays;
            cmbbx_DailyResetTimeHours.ItemsSource = listOfHours;
            cmbbx_DailyResetTimeMinutes.ItemsSource = listOfMinutes;

        }//end of SettingsWindow constructor

        private void btn_SaveSettings_Click(object sender, RoutedEventArgs e)
        {
            if (txbx_ChangeProfileName.Text != null)
            {
                string hour = cmbbx_DailyResetTimeHours.SelectedItem.ToString();
                string minute = cmbbx_DailyResetTimeMinutes.SelectedItem.ToString();
                string time = hour + ":" + minute;

                MainWindow.profileLoaded.ProfileName = txbx_ChangeProfileName.Text;
                Properties.Settings.Default.DailyResetTime = time;
                Properties.Settings.Default.WeeklyQuestResetDay = cmbbx_WeeklyResetQuests.SelectedItem.ToString();
                Properties.Settings.Default.WeeklyBossResetDay = cmbbx_WeeklyResetBoss.SelectedItem.ToString();
                Properties.Settings.Default.Save();
                this.Close();
            }//end of if
            else
            {
                MessageBox.Show("Profile name cannot be null.", "Error");
            }
        }//end of btn_SaveSettings_Click
    }//end of SettingsWindow partial class
}//end of namespace
