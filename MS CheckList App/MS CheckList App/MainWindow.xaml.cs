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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Win32;
using Path = System.IO.Path;
using System.Threading;
using System.Diagnostics;

namespace MS_CheckList_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool isProfileLoaded = false;
        public static string safeFileName;
        public static string fileName;
        public static Profile profileLoaded = new Profile();
        public static DateTime DailyResetTime;
        public static DateTime WeeklyResetTimeBosses;
        public static DateTime WeeklyResetTimeQuests;
        public static string SettingsWindow_ComboBox_WeeklyBoss_Result;
        public static string SettingsWindow_ComboBox_WeeklyQuest_Result;
        public DateTime initialDateTime;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = profileLoaded;
            StatusBarStatusText("Ready");
            //WaitForDailyReset();
        }//end of MainWindow

        public void WaitForDailyReset()
        {
            string dailyResetTimeString = Properties.Settings.Default.DailyResetTime.ToString();
            string weeklyResetBossString = Properties.Settings.Default.WeeklyBossResetDay.ToString();
            string weklyResetQuestString = Properties.Settings.Default.WeeklyQuestResetDay.ToString();
            //if ()
            initialDateTime = DateTime.Now;
            string initialDayOfMonth = initialDateTime.Day.ToString();
            string initialDayOfWeek = initialDateTime.DayOfWeek.ToString();
            string initialTimeOfDay = initialDateTime.TimeOfDay.ToString();
            string initialMonth = initialDateTime.Month.ToString();
            string initialYear = initialDateTime.Year.ToString();

            DateTime nextDateTime = initialDateTime.AddHours(24);
            string nextDayOfMonth = nextDateTime.Day.ToString();
            string nextDayOfWeek = nextDateTime.DayOfWeek.ToString();
            string nextTimeOfDay = nextDateTime.TimeOfDay.ToString();
            string nextMonth = nextDateTime.Month.ToString();
            string nextYear = nextDateTime.Year.ToString();

            string initialResetDate = $"{initialDayOfWeek}, {initialDayOfMonth} {initialMonth} {initialYear} {initialTimeOfDay}";
            DateTime initialParsedDateTime = DateTime.Parse(initialResetDate);


            //string resetDateTime = ""
            //DateTime resetDateTime = ""
            //MessageBox.Show(currentDayOfYear);
            string dailyTime = Properties.Settings.Default.DailyResetTime.ToString();

            //MessageBox.Show(dailyTime);
        }

        private void MenuItem_Save_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true)
            {
                SaveExistingProfile();
            }
            else
            {
                SaveNewProfile();
            }
            //if (isProfileLoaded == false)
            //{
            //    SaveFileDialog saveFileDialog = new SaveFileDialog();
            //    saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            //    if (saveFileDialog.ShowDialog() == true)
            //    {
            //        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Profile));
            //        safeFileName = Path.GetFileNameWithoutExtension(saveFileDialog.FileName);
            //        StreamWriter sw = new StreamWriter(safeFileName+".xml");
            //        profileLoaded.ProfileName = safeFileName;
            //        xmlSerializer.Serialize(sw, profileLoaded);
            //        sw.Close();
            //        isProfileLoaded = true;
            //        DataContext = null;
            //        DataContext = profileLoaded;
            //        //StatusBarStatusText("Profile successfully saved");
            //        //statusbar_CurrentFile.Text = Path.GetFileName(saveFileDialog.FileName);
            //    }
            //    else
            //    {
            //        StatusBarStatusText("Save dialog exited");
            //    }
            //}//end of if
        }//end of MenuItem_Save_Click

        private void SaveNewProfile()
        {
            if (isProfileLoaded == false)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == true)
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Profile));
                    safeFileName = Path.GetFileNameWithoutExtension(saveFileDialog.FileName);
                    fileName = Path.GetFileName(saveFileDialog.FileName);
                    StreamWriter sw = new StreamWriter(fileName);
                    //profileLoaded.ProfileName = safeFileName;
                    xmlSerializer.Serialize(sw, profileLoaded);
                    sw.Close();
                    isProfileLoaded = true;
                    DataContext = null;
                    DataContext = profileLoaded;
                    statusbar_CurrentFile.Text = fileName;
                    StatusBarStatusText("Profile successfully saved.");

                }
                else
                {
                    StatusBarStatusText("Save dialog exited");
                }
            }
        }//end of SaveNewProfile

        private void SaveExistingProfile()
        {
            if (isProfileLoaded == true)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Profile));
                //StreamWriter sw = new StreamWriter(safeFileName + ".xml");
                StreamWriter sw = new StreamWriter(fileName);
                xmlSerializer.Serialize(sw, profileLoaded);
                sw.Close();
                DataContext = null;
                DataContext = profileLoaded;
                StatusBarStatusText("Profile successfully saved.");
            }
            else
            {
                StatusBarStatusText("Error saving profile.");
            }
            
        }//end of SaveExistingProfile

        private void MenuItem_Load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Profile));
                try
                {
                    if ((Profile)xmlSerializer.Deserialize(openFileDialog.OpenFile()) == null)
                    {
                        StatusBarStatusText("No file selected");
                    }
                    else
                    {
                        profileLoaded.ResetAll();
                        profileLoaded = (Profile)xmlSerializer.Deserialize(openFileDialog.OpenFile());
                        //if (profileLoaded.ProfileName == null)
                        //{
                        //    safeFileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                        //    profileLoaded.ProfileName = safeFileName;
                        //}
                        safeFileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                        fileName = Path.GetFileName(openFileDialog.FileName);
                        StatusBarStatusText("Profile loaded successfully");
                        statusbar_CurrentFile.Text = fileName;
                        DataContext = profileLoaded;
                        isProfileLoaded = true;
                    }//end of else
                }//end of try
                catch (Exception)
                {
                    StatusBarStatusText("Error, invalid file");
                }
            }//end of if
        }//end of MenuItem_Load_Click

        private void MenuItem_New_Click(object sender, RoutedEventArgs e)
        {
            profileLoaded.ResetAll();
            isProfileLoaded = false;
            DataContext = profileLoaded;
            StatusBarStatusText("New profile created");
        }
        #region Tools -> Reset Menus
        private void MenuItem_ResetAll_Click(object sender, RoutedEventArgs e)
        {
            profileLoaded.ResetDaily();
            profileLoaded.ResetWeeklyWednesday();
            profileLoaded.ResetWeeklySunday();
            statusbar_Status.Text = "Reset All complete";
        }

        private void MenuItem_ResetDaily_Click(object sender, RoutedEventArgs e)
        {
            profileLoaded.ResetDaily();
            StatusBarStatusText("Daily Reset complete");
        }

        private void MenuItem_ResetWeeklyWednesday_Click(object sender, RoutedEventArgs e)
        {
            profileLoaded.ResetWeeklyWednesday();
            StatusBarStatusText("Weekly (Wed) Reset complete");
        }

        private void MenuItem_ResetWeeklySunday_Click(object sender, RoutedEventArgs e)
        {
            profileLoaded.ResetWeeklySunday();
            statusbar_Status.Text = "Weekly (Sun) Reset complete";
        }
        #endregion

        private void MenuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true)
            {
                SaveExistingProfile();
            }
            this.Close();
        }


        private void MenuItem_Settings_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true)
            {
                SettingsWindow settingsWindow = new SettingsWindow();
                settingsWindow.Show();
            }//end of if
            else
            {
                MessageBox.Show("Please load a profile.", "Error");
            }//end of else
        }//end of MenuItem_Settings_Click

        #region About Menu
        private void MenuItem_ViewHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Saving a profile will set its profile name to the filename.\n\n" +
                "You can change your profile name in the settings menu after you have saved a profile.\n\n" +
                "Currently there is no automatic reset feature. You can reset manually in the Tools menu.", "Help");
        }

        private void MenuItem_About_Click(object sender, RoutedEventArgs e)
        {
            if (EasterEggCheck(profileLoaded.ProfileName) == true)
            {
                MessageBox.Show("Cleanse best guild. uwu", "Secret Menu");
            }
            else
            {
                MessageBox.Show("Enjoy playing Mushroom Game. uwu", "About");
            }
        }//end of MenuItem_About_Click 
        #endregion

        public void StatusBarStatusText(string status)
        {
            statusbar_Status.Text = status;
        }

        private Boolean EasterEggCheck(string profileName)
        {
            List<string> cleanse = new List<string>()
            {
                "Xuey", "KunMoLee6", "Arkvaaark", "Vivin", "Stockwell", "Rakusas", "Douken"
            };
            foreach (string name in cleanse)
            {
                if (profileName == name)
                {
                    StatusBarStatusText("Easter Egg Activated.");
                    return true;
                }
            }//end of foreach
            return false;
        }//end of EasterEggCheck

        #region CheckBox_Zak_Click
        private void chbx_eZak_Click(object sender, RoutedEventArgs e)
        {

            chbx_nZak.IsChecked = false;

        }//end of chbx_eZak_Click

        private void chbx_nZak_Click(object sender, RoutedEventArgs e)
        {

            chbx_eZak.IsChecked = false;

        }//end of chbx_nZak_Click 
        #endregion

        #region CheckBox_VonLeon_Click
        private void chbx_eVLeon_Click(object sender, RoutedEventArgs e)
        {

            chbx_nVLeon.IsChecked = false;
            chbx_hVLeon.IsChecked = false;

        }//end of chbx_eVLeon_Click

        private void chbx_nVLeon_Click(object sender, RoutedEventArgs e)
        {

            chbx_eVLeon.IsChecked = false;
            chbx_hVLeon.IsChecked = false;

        }

        private void chbx_hVLeon_Click(object sender, RoutedEventArgs e)
        {

            chbx_eVLeon.IsChecked = false;
            chbx_nVLeon.IsChecked = false;

        }


        #endregion

        #region CheckBox_Horntail_Click
        private void chbx_eHTail_Click(object sender, RoutedEventArgs e)
        {

            chbx_nHTail.IsChecked = false;
            chbx_cHTail.IsChecked = false;

        }//chbx_eHTail_Click

        private void chbx_nHTail_Click(object sender, RoutedEventArgs e)
        {

            chbx_eHTail.IsChecked = false;
            chbx_cHTail.IsChecked = false;

        }//end of chbx_nHTail_Click

        private void chbx_cHTail_Click(object sender, RoutedEventArgs e)
        {

            chbx_eHTail.IsChecked = false;
            chbx_nHTail.IsChecked = false;

        }//end of chbx_cHTail_Click

        #endregion

        #region CheckBox_Arkarium_Click
        private void chbx_eArk_Click(object sender, RoutedEventArgs e)
        {

            chbx_nArk.IsChecked = false;

        }//end of chbx_eArk_Click

        private void chbx_nArk_Click(object sender, RoutedEventArgs e)
        {

            chbx_eArk.IsChecked = false;

        }//end of chbx_nArk_Click
        #endregion

        #region CheckBox_Ranmaru_Click
        private void chbx_nRanmaru_Click(object sender, RoutedEventArgs e)
        {

            chbx_hRanmaru.IsChecked = false;

        }

        private void chbx_hRanmaru_Click(object sender, RoutedEventArgs e)
        {

            chbx_nRanmaru.IsChecked = false;

        }
        #endregion

        #region CheckBox_Cygnus_Click
        private void chbx_eCygnus_Click(object sender, RoutedEventArgs e)
        {

            chbx_nCygnus.IsChecked = false;

        }

        private void chbx_nCygnus_Click(object sender, RoutedEventArgs e)
        {
            chbx_eCygnus.IsChecked = false;
        }
        #endregion

        #region CheckBox_Magnus_Click
        private void chbx_eMagnus_Click(object sender, RoutedEventArgs e)
        {
            chbx_nMagnus.IsChecked = false;
        }

        private void chbx_nMagnus_Click(object sender, RoutedEventArgs e)
        {
            chbx_eMagnus.IsChecked = false;
        }
        #endregion

        #region CheckBox_Lotus_Click
        private void chbx_nLotus_Click(object sender, RoutedEventArgs e)
        {
            chbx_hLotus.IsChecked = false;
        }

        private void chbx_hLotus_Click(object sender, RoutedEventArgs e)
        {
            chbx_nLotus.IsChecked = false;
        }
        #endregion

        #region CheckBox_Damien_Click
        private void chbx_nDamien_Click(object sender, RoutedEventArgs e)
        {
            chbx_hDamien.IsChecked = false;
        }

        private void chbx_hDamien_Click(object sender, RoutedEventArgs e)
        {
            chbx_nDamien.IsChecked = false;
        }
        #endregion

        #region Check_Lucid_Click
        private void chbx_nLucid_Click(object sender, RoutedEventArgs e)
        {
            chbx_hLucid.IsChecked = false;
        }

        private void chbx_hLucid_Click(object sender, RoutedEventArgs e)
        {
            chbx_nLucid.IsChecked = false;
        }
        #endregion

        #region CheckBox_Will_Click
        private void chbx_nWill_Click(object sender, RoutedEventArgs e)
        {
            chbx_hWill.IsChecked = false;
        }

        private void chbx_hWill_Click(object sender, RoutedEventArgs e)
        {
            chbx_nWill.IsChecked = false;
        }
        #endregion
    }//end of class
}//end of namespace
