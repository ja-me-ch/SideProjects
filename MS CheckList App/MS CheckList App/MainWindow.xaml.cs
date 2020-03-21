﻿using System;
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

        public MainWindow()
        {
            InitializeComponent();
            DataContext = profileLoaded;
        }//end of MainWindow

        private void MenuItem_Save_Click(object sender, RoutedEventArgs e)
        {
            if (isProfileLoaded == false)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == true)
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Profile));
                    safeFileName = Path.GetFileNameWithoutExtension(saveFileDialog.FileName);
                    StreamWriter sw = new StreamWriter(safeFileName+".xml");
                    profileLoaded.ProfileName = safeFileName;
                    xmlSerializer.Serialize(sw, profileLoaded);
                    sw.Close();
                    isProfileLoaded = true;
                    DataContext = null;
                    DataContext = profileLoaded;
                }
                else
                {
                    MessageBox.Show("Save Dialog exited.");
                }
            }//end of if
            else
            {
                MessageBox.Show("Profile found, saving to " + safeFileName + ".xml");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Profile));
                StreamWriter sw = new StreamWriter(safeFileName + ".xml");
                xmlSerializer.Serialize(sw, profileLoaded);
                sw.Close();
            }
        }//end of MenuItem_Save_Click

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
                        MessageBox.Show("Invalid file");
                    }
                    else
                    {
                        profileLoaded = null;
                        MessageBox.Show("Profile loaded successfully.");
                        profileLoaded = (Profile)xmlSerializer.Deserialize(openFileDialog.OpenFile());
                        safeFileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                        profileLoaded.ProfileName = safeFileName;
                        DataContext = profileLoaded;
                        isProfileLoaded = true;
                    }//end of else
                }//end of try
                catch (Exception)
                {
                    MessageBox.Show("Invalid file");
                }
            }//end of if
        }//end of MenuItem_Load_Click

        private void MenuItem_New_Click(object sender, RoutedEventArgs e)
        {
            profileLoaded = null;
            isProfileLoaded = false;
            DataContext = profileLoaded;
        }

        private void MenuItem_ResetAll_Click(object sender, RoutedEventArgs e)
        {
            DataContext = null;
            profileLoaded.ResetDaily();
            profileLoaded.ResetWeeklyWednesday();
            profileLoaded.ResetWeeklySunday();
            DataContext = profileLoaded;
        }

        private void MenuItem_ResetDaily_Click(object sender, RoutedEventArgs e)
        {
            DataContext = null;
            profileLoaded.ResetDaily();
            DataContext = profileLoaded;
        }

        private void MenuItem_ResetWeeklyWednesday_Click(object sender, RoutedEventArgs e)
        {
            DataContext = null;
            profileLoaded.ResetWeeklyWednesday();
            DataContext = profileLoaded;
        }

        private void MenuItem_ResetWeeklySunday_Click(object sender, RoutedEventArgs e)
        {
            DataContext = null;
            profileLoaded.ResetWeeklySunday();
            DataContext = profileLoaded;
        }
    }//end of class
}//end of namespace