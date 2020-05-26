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
using System.Windows.Controls.Primitives;

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
        public static string pathFileName;
        public static Profile profileLoaded = new Profile();
        public static DateTime NextDailyResetTime;
        public static DateTime NextWeeklyResetTimeBosses;
        public static DateTime NextWeeklyResetTimeQuests;
        public static string SettingsWindow_ComboBox_WeeklyBoss_Result;
        public static string SettingsWindow_ComboBox_WeeklyQuest_Result;
        public DateTime initialDateTime;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = profileLoaded;
            StatusBarStatusText("Ready");
            LastResetCheck();
        }//end of MainWindow

        public void LastResetCheck()
        {
            Trace.WriteLine("Daily Reset: " + NextDailyResetDateTime().ToString());
            Trace.WriteLine("Wed Reset: " + NextWednesdayResetDateTime().ToString());
            Trace.WriteLine("Sun Reset: " + NextSundayResetDateTime().ToString());

            DateTime last_DailyReset = profileLoaded.LastDateTimeReset_Daily;
            DateTime last_WeeklyWedReset = profileLoaded.LastDateTimeReset_WeeklyWednesday;
            DateTime last_WeeklySunReset = profileLoaded.LastDateTimeReset_WeeklySunday;
            Trace.WriteLine(last_DailyReset.ToString());
            Trace.WriteLine(last_WeeklyWedReset.ToString());
            Trace.WriteLine(last_WeeklySunReset.ToString());

            if (last_DailyReset != default(DateTime) && last_WeeklyWedReset != default(DateTime) && last_WeeklySunReset != default(DateTime))
            {
                //1 = t1 is later than t2; 
                //0 = t1 = t2;
                //-1 = t1 is earlier than t1
                int compareDaily = DateTime.Compare(NextDailyResetDateTime(), last_DailyReset);
                if (compareDaily == 1) //daily reset is later than last_DailyReset
                {
                    Task.Run (()=> {
                        WaitForDailyReset();
                    });
                }//end of if
                else
                {
                    Trace.WriteLine("Reset detected.");
                }//end of else

                int compareWedWeekly = DateTime.Compare(NextWednesdayResetDateTime(), last_WeeklyWedReset);
                if (compareWedWeekly == 1)
                {
                    Task.Run(() =>
                    {
                        WaitForWedWeeklyReset();
                    });
                }//end of if
                else
                {
                    Trace.WriteLine("Wed Reset detected.");
                }

                int compareSunWeekly = DateTime.Compare(NextSundayResetDateTime(), last_WeeklySunReset);
                if (compareSunWeekly == 1)
                {
                    Task.Run(() =>
                    {
                        WaitForSunWeeklyReset();
                    });
                }//end of if
                else
                {
                    Trace.WriteLine("Sun Reset detected.");
                }

            }//end of if
            else
            {
                
            }//end of else

        }//end of wait for reset

        private DateTime NextDailyResetDateTime()
        {
            DateTime currentTime = DateTime.UtcNow;
            currentTime = currentTime.AddDays(1);
            DateTime resetTime = new DateTime();
            //Set the reset Date and Time to UTC time 00:00
            resetTime = new DateTime(
                currentTime.Year,
                currentTime.Month,
                currentTime.Day,
                0,
                0,
                0,
                DateTimeKind.Utc);

            return resetTime;
        }//end of GetNextDailyResetDateTime

        private DateTime NextWednesdayResetDateTime()
        {
            DateTime currentTime = DateTime.UtcNow;
            DateTime resetTime = new DateTime();
            for (int x = 0; x<=7; x++)
            {
                if (currentTime.DayOfWeek == DayOfWeek.Thursday)
                {

                    resetTime = new DateTime(
                        currentTime.Year,
                        currentTime.Month,
                        currentTime.Day,
                        0,
                        0,
                        0,
                        DateTimeKind.Utc);
                    break;
                }//end of if
                    currentTime = currentTime.AddDays(1);
            }//end of for
            return resetTime;
        }//end of GetNextWednesdayResetDateTime

        private DateTime NextSundayResetDateTime()
        {
            DateTime currentTime = DateTime.UtcNow;
            DateTime resetTime = new DateTime();
            for (int x = 0; x <= 7; x++)
            {
                if (currentTime.DayOfWeek == DayOfWeek.Monday)
                {

                    resetTime = new DateTime(
                        currentTime.Year,
                        currentTime.Month,
                        currentTime.Day,
                        0,
                        0,
                        0,
                        DateTimeKind.Utc);
                    break;
                }//end of if
                currentTime = currentTime.AddDays(1);
            }//end of for
            return resetTime;
        }//end of GetNextWednesdayResetDateTime

        private void WaitForDailyReset()
        {
            TimeSpan timeUntilReset = NextDailyResetDateTime().Subtract(DateTime.UtcNow);
            //TimeSpan timeUntilReset = last_ResetDateTime.AddMinutes(1).Subtract(last_ResetDateTime); //for debugging
            Trace.WriteLine("Time Until Daily Reset: " + timeUntilReset.ToString());
            Thread.Sleep(timeUntilReset);
            Trace.WriteLine("sleep complete.");
            if (profileLoaded.AutoReset == true)
            {
                Trace.WriteLine("Daily Reset Complete.");
                profileLoaded.ResetDaily();
            }
            else
            {
                Trace.WriteLine("Daily reset has occurred.");
            }
        }//end of WaitForReset

        private void WaitForWedWeeklyReset()
        {
            TimeSpan timeUntilReset = NextWednesdayResetDateTime().Subtract(DateTime.UtcNow);
            //TimeSpan timeUntilReset = last_ResetDateTime.AddMinutes(1).Subtract(last_ResetDateTime);
            Trace.WriteLine("Time Until Wednesday Reset:" + timeUntilReset.ToString());
            Thread.Sleep(timeUntilReset);
            if (profileLoaded.AutoReset == true)
            {
                profileLoaded.ResetWeeklyWednesday();
            }
            else
            {
                Trace.WriteLine("Weekly boss reset has occurred.");
            }
        }//end of WaitForReset

        private void WaitForSunWeeklyReset()
        {
            TimeSpan timeUntilReset = NextSundayResetDateTime().Subtract(DateTime.UtcNow);
            //TimeSpan timeUntilReset = last_ResetDateTime.AddMinutes(1).Subtract(last_ResetDateTime);
            Trace.WriteLine("Time Until Sunday Reset: " + timeUntilReset.ToString());
            Thread.Sleep(timeUntilReset);
            if (profileLoaded.AutoReset == true)
            {
                profileLoaded.ResetWeeklySunday();
            }//end of if
            else
            {
                Trace.WriteLine("Weekly quests reset has occurred.");
            }
        }//end of WaitForReset

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
                try {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Profile));
                //StreamWriter sw = new StreamWriter(safeFileName + ".xml");
                //StreamWriter sw = new StreamWriter(fileName);
                StreamWriter sw = new StreamWriter(pathFileName);
                xmlSerializer.Serialize(sw, profileLoaded);
                sw.Close();
                DataContext = null;
                DataContext = profileLoaded;
                StatusBarStatusText("Profile successfully saved.");
                }
                catch (Exception)
                {
                    StatusBarStatusText("Error occured when trying to save.");
                }
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
                        try
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
                            pathFileName = openFileDialog.FileName;
                            StatusBarStatusText("Profile loaded successfully");
                            statusbar_CurrentFile.Text = fileName;
                            DataContext = profileLoaded;
                            isProfileLoaded = true;
                            LastResetCheck(); //new
                        }//end of try
                        catch (Exception)
                        {
                            StatusBarStatusText("File is in use by another process.");
                        }//end of catch
                        
                        
                    }//end of else
                }//end of try
                catch (Exception)
                {
                    StatusBarStatusText("Error, invalid file");
                }//end of catch
            }//end of if
            LastResetCheck();
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
            profileLoaded.LastDateTimeReset_Daily = DateTime.UtcNow;
            StatusBarStatusText("Daily Reset complete");
        }

        private void MenuItem_ResetWeeklyWednesday_Click(object sender, RoutedEventArgs e)
        {
            profileLoaded.ResetWeeklyWednesday();
            profileLoaded.LastDateTimeReset_WeeklyWednesday = DateTime.UtcNow;
            StatusBarStatusText("Weekly (Wed) Reset complete");
        }

        private void MenuItem_ResetWeeklySunday_Click(object sender, RoutedEventArgs e)
        {
            profileLoaded.ResetWeeklySunday();
            profileLoaded.LastDateTimeReset_WeeklySunday = DateTime.UtcNow;
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


        //private void MenuItem_Settings_Click(object sender, RoutedEventArgs e)
        //{
        //    if (isProfileLoaded == true)
        //    {
        //        SettingsWindow settingsWindow = new SettingsWindow();
        //        settingsWindow.Show();
        //    }//end of if
        //    else
        //    {
        //        MessageBox.Show("Please load a profile.", "Error");
        //    }//end of else
        //}//end of MenuItem_Settings_Click

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

        #region CheckBox_Click_Events

        #region CheckBox_Zak_Click
        private void chbx_eZak_Click(object sender, RoutedEventArgs e)
        {
            chbx_nZak.IsChecked = false;
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }

        }//end of chbx_eZak_Click

        private void chbx_nZak_Click(object sender, RoutedEventArgs e)
        {

            chbx_eZak.IsChecked = false;
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }

        }//end of chbx_nZak_Click 
        private void chbx_cZak_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }

        #endregion //end of CheckBox_Zak_Click

        #region CheckBox_VonLeon_Click
        private void chbx_eVLeon_Click(object sender, RoutedEventArgs e)
        {

            chbx_nVLeon.IsChecked = false;
            chbx_hVLeon.IsChecked = false;
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }

        }//end of chbx_eVLeon_Click

        private void chbx_nVLeon_Click(object sender, RoutedEventArgs e)
        {

            chbx_eVLeon.IsChecked = false;
            chbx_hVLeon.IsChecked = false;
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }

        }

        private void chbx_hVLeon_Click(object sender, RoutedEventArgs e)
        {

            chbx_eVLeon.IsChecked = false;
            chbx_nVLeon.IsChecked = false;
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }

        }


        #endregion

        #region CheckBox_Horntail_Click
        private void chbx_eHTail_Click(object sender, RoutedEventArgs e)
        {

            chbx_nHTail.IsChecked = false;
            chbx_cHTail.IsChecked = false;
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }//chbx_eHTail_Click

        private void chbx_nHTail_Click(object sender, RoutedEventArgs e)
        {

            chbx_eHTail.IsChecked = false;
            chbx_cHTail.IsChecked = false;
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }//end of chbx_nHTail_Click

        private void chbx_cHTail_Click(object sender, RoutedEventArgs e)
        {

            chbx_eHTail.IsChecked = false;
            chbx_nHTail.IsChecked = false;
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }//end of chbx_cHTail_Click

        #endregion

        #region CheckBox_Arkarium_Click
        private void chbx_eArk_Click(object sender, RoutedEventArgs e)
        {

            chbx_nArk.IsChecked = false;
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }

        }//end of chbx_eArk_Click

        private void chbx_nArk_Click(object sender, RoutedEventArgs e)
        {

            chbx_eArk.IsChecked = false;
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }//end of chbx_nArk_Click
        #endregion

        #region CheckBox_Ranmaru_Click
        private void chbx_nRanmaru_Click(object sender, RoutedEventArgs e)
        {

            chbx_hRanmaru.IsChecked = false;
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }

        private void chbx_hRanmaru_Click(object sender, RoutedEventArgs e)
        {

            chbx_nRanmaru.IsChecked = false;
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }
        #endregion

        #region CheckBox_Hilla_Click
        private void chbx_nHilla_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }

        private void chbx_hHilla_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }
        #endregion

        #region CheckBox_Cygnus_Click
        private void chbx_eCygnus_Click(object sender, RoutedEventArgs e)
        {

            chbx_nCygnus.IsChecked = false;
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }

        private void chbx_nCygnus_Click(object sender, RoutedEventArgs e)
        {
            chbx_eCygnus.IsChecked = false;
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }
        #endregion

        #region Other_StackPanel_1
        private void chbx_dojDojo_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }

        private void chbx_mpMonsterPark_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }
        #endregion

        #region CheckBox_RootAbyss_Click
        private void chbx_nCQueen_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }

        private void chbx_nPierre_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }

        private void chbx_nVonBon_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }

        private void chbx_nVellum_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }
        #endregion

        #region CheckBox_Chaos_RootAbyss_Click
        private void chbx_cCQueen_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }

        private void chbx_cPierre_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }

        private void chbx_cVonBon_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }

        private void chbx_cVellum_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }
        #endregion

        #region CheckBox_PinkBean_Click
        private void chbx_nPinkBean_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }

        private void chbx_cPinkBean_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }
        #endregion

        #region CheckBox_Magnus_Click
        private void chbx_eMagnus_Click(object sender, RoutedEventArgs e)
        {
            chbx_nMagnus.IsChecked = false;
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }

        private void chbx_nMagnus_Click(object sender, RoutedEventArgs e)
        {
            chbx_eMagnus.IsChecked = false;
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }

        private void chbx_hMagnus_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }
        #endregion

        #region Other_StackPanel_2
        private void chbx_Gollux_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }

        private void chbx_Ursus_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }

        private void chbx_legQuests_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }

        private void chbx_MapleTour_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }
        #endregion

        #region CheckBox_Lotus_Click
        private void chbx_nLotus_Click(object sender, RoutedEventArgs e)
        {
            chbx_hLotus.IsChecked = false;
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }

        private void chbx_hLotus_Click(object sender, RoutedEventArgs e)
        {
            chbx_nLotus.IsChecked = false;
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }
        #endregion

        #region CheckBox_Damien_Click
        private void chbx_nDamien_Click(object sender, RoutedEventArgs e)
        {
            chbx_hDamien.IsChecked = false;
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }

        private void chbx_hDamien_Click(object sender, RoutedEventArgs e)
        {
            chbx_nDamien.IsChecked = false;
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }
        #endregion

        #region CheckBox_Lucid_Click
        private void chbx_nLucid_Click(object sender, RoutedEventArgs e)
        {
            chbx_hLucid.IsChecked = false;
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }

        private void chbx_hLucid_Click(object sender, RoutedEventArgs e)
        {
            chbx_nLucid.IsChecked = false;
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }
        #endregion

        #region CheckBox_Will_Click
        private void chbx_nWill_Click(object sender, RoutedEventArgs e)
        {
            chbx_hWill.IsChecked = false;
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }

        private void chbx_hWill_Click(object sender, RoutedEventArgs e)
        {
            chbx_nWill.IsChecked = false;
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }

        }
        #endregion

        #region CheckBox_TenebrisBosses_Click
        private void chbx_nGloom_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }

        private void chbx_hVHilla_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }

        private void chbx_nDarknell_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }

        private void chbx_hBlackMage_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }
        #endregion

        #region Other_StackPanel_3
        private void chbx_comVoyages_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }

        private void chbx_comPQ_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }

        private void chbx_syQuests_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }

        private void chbx_dwtQuests_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }
        #endregion

        #region CheckBox_VJ_Dailies_Click
        private void chbx_vjQuests_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }

        private void chbx_vjErdaSpectrum_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }
        #endregion

        #region CheckBox_ChuChu_Dailies_Click
        private void chbx_chuchuQuests_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }

        private void chbx_chuchuHMuto_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }

        #endregion //end of endregion CheckBox_Click_Event

        #region CheckBox_Lach_Dailies_Click
        private void chbx_lachQuests_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }

        private void chbx_lachDDefender_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }
        #endregion

        #region CheckBox_Arc_Dailies_Click
        private void chbx_arcQuests_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }

        private void chbx_arcSSavior_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }
        #endregion

        #region CheckBox_Mor_Esf_Dailies_Click
        private void chbx_morQuests_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }

        private void chbx_esfQuests_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == true && profileLoaded.AutoSave == true)
            {
                SaveExistingProfile();
            }
        }
        #endregion

        #endregion

        private void MenuItem_AutoSave_Click(object sender, RoutedEventArgs e)
        {
            if (MenuItem_AutoSave.IsChecked == true)
            {
                MenuItem_AutoSave.IsChecked = false;
            }//end of if
            else
            {
                MenuItem_AutoSave.IsChecked = true;
            }
            
        }//end of MenuItem_AutoSave_Click

        private void MenuItem_AutoReset_Click(object sender, RoutedEventArgs e)
        {
            if (MenuItem_AutoReset.IsChecked == true)
            {
                MenuItem_AutoReset.IsChecked = false;
            }//end of if
            else
            {
                MenuItem_AutoReset.IsChecked = true;
            }
        }//end of MenuItem_AutoReset_Click

        
    }//end of class
}//end of namespace
