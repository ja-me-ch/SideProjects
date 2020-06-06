using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using System.Diagnostics;

namespace MS_CheckList_App
{
    [Serializable()]
    public class Profile : ISerializable, INotifyPropertyChanged
    {
        //Profile Data
        private String profileName;
        public String ProfileName
        {
            get { return profileName; }
            set { if (profileName != value)
                {
                    profileName = value;
                    OnPropertyChanged("ProfileName");
                } 
            }
        }

        private Boolean autoReset;
        public Boolean AutoReset
        {
            get { return autoReset; }
            set 
            {
                if (autoReset != value) 
                {
                    autoReset = value;
                    OnPropertyChanged("AutoReset");
                }
            }
        }

        private Boolean autoSave;
        public Boolean AutoSave
        {
            get { return autoSave; }
            set
            {
                if (autoSave != value)
                {
                    autoSave = value;
                    OnPropertyChanged("AutoSave");
                }
            }
        }
        public String description { get; set; }

        private DateTime lastDateTimeReset_Daily;
        public DateTime LastDateTimeReset_Daily 
        { 
            get { return lastDateTimeReset_Daily; }
            set
            {
                if (lastDateTimeReset_Daily != value)
                {
                    lastDateTimeReset_Daily = value;
                    OnPropertyChanged("LastDateTimeReset_Daily");
                }
            }
        }

        private DateTime lastDateTimeReset_WeeklyWednesday;
        public DateTime LastDateTimeReset_WeeklyWednesday 
        { 
            get { return lastDateTimeReset_WeeklyWednesday; }
            set
            {
                if (lastDateTimeReset_WeeklyWednesday != value)
                {
                    lastDateTimeReset_WeeklyWednesday = value;
                    OnPropertyChanged("LastDateTimeReset_WeeklyWednesday");

                }
            }
        }

        private DateTime lastDateTimeReset_WeeklySunday;
        public DateTime LastDateTimeReset_WeeklySunday 
        { 
            get { return lastDateTimeReset_WeeklySunday; }
            set
            {
                if (lastDateTimeReset_WeeklySunday != value)
                {
                    lastDateTimeReset_WeeklySunday = value;
                    OnPropertyChanged("LastDateTimeReset_WeeklySunday");
                }
            }
        }

        //Constructors
        public Profile()
        {

        }

        //Boss Variables
        private Boolean eZak;
        private Boolean nZak;
        private Boolean cZak;
        private Boolean eVLeon;
        private Boolean nVLeon;
        private Boolean hVLeon;
        private Boolean eHTail;
        private Boolean nHTail;
        private Boolean cHTail;
        private Boolean eArk;
        private Boolean nArk;
        private Boolean nRanmaru;
        private Boolean hRanmaru;
        private Boolean nHilla;
        private Boolean hHilla;
        private Boolean eCygnus;
        private Boolean nCygnus;
        private Boolean nCQueen;
        private Boolean nPierre;
        private Boolean nVonBon;
        private Boolean nVellum;
        private Boolean cCQueen;
        private Boolean cPierre;
        private Boolean cVonBon;
        private Boolean cVellum;
        private Boolean nPinkBean;
        private Boolean cPinkBean;
        private Boolean eMagnus;
        private Boolean nMagnus;
        private Boolean hMagnus;
        private Boolean ePap;
        private Boolean nPap;
        private Boolean cPap;
        private Boolean gollux;
        private Boolean ursus;
        private Boolean mapleTour;
        private Boolean nLotus;
        private Boolean hLotus;
        private Boolean nDamien;
        private Boolean hDamien;
        private Boolean nLucid;
        private Boolean hLucid;
        private Boolean nWill;
        private Boolean hWill;
        private Boolean nGloom;
        private Boolean hVHilla;
        private Boolean nDarknell;
        private Boolean hBlackMage;
        private Boolean dojDojo;
        private Boolean comVoyages;
        private Boolean comPQ;
        private Boolean mpMonsterPark;
        private Boolean legQuests;
        private Boolean vjQuests;
        private Boolean vjErdaSpectrum;
        private Boolean chuchuQuests;
        private Boolean chuchuHMuto;
        private Boolean lachQuests;
        private Boolean lachDDefender;
        private Boolean arcQuests;
        private Boolean arcSSavior;
        private Boolean morQuests;
        private Boolean esfQuests;
        private Boolean syQuests;
        private Boolean dwtQuests;

        #region CheckBox Data
        //Boss Data
        //Zakum
        public Boolean EZak //Daily
        {
            get { return eZak; }
            set
            {
                if (eZak != value)
                {
                    eZak = value;
                    OnPropertyChanged("EZak");
                }
            }
        }
        public Boolean NZak //Daily Shares with eZak
        {
            get { return nZak; }
            set
            {
                if (nZak != value)
                {
                    nZak = value;
                    OnPropertyChanged("NZak");
                }
            }
        }
        public Boolean CZak //weekly
        {
            get { return cZak; }
            set
            {
                if (cZak != value)
                {
                    cZak = value;
                    OnPropertyChanged("CZak");
                }
            }
        }
        //Von Leon e, n, h, all share daily
        public Boolean EVLeon
                {
            get { return eVLeon; }
            set
            {
                if (eVLeon != value)
                {
                    eVLeon = value;
                    OnPropertyChanged("EVLeon");
}
            }
        }
        public Boolean NVLeon
        {
            get { return nVLeon; }
            set
            {
                if (nVLeon != value)
                {
                    nVLeon = value;
                    OnPropertyChanged("NVLeon");
                }
            }
        }
        public Boolean HVLeon
        {
            get { return hVLeon; }
            set
            {
                if (hVLeon != value)
                {
                    hVLeon = value;
                    OnPropertyChanged("HVLeon");
                }
            }
        }

        //Horntail e, n, c, all share daily
        public Boolean EHTail
        {
            get { return eHTail; }
            set
            {
                if (eHTail != value)
                {
                    eHTail = value;
                    OnPropertyChanged("EHTail");
                }
            }
        }
        public Boolean NHTail
        {
            get { return nHTail; }
            set
            {
                if (NHTail != value)
                {
                    nHTail = value;
                    OnPropertyChanged("NHTail");
                }
            }
        }
        public Boolean CHTail
        {
            get { return cHTail; }
            set
            {
                if (cHTail != value)
                {
                    cHTail = value;
                    OnPropertyChanged("CHTail");
                }
            }
        }

        //Arkarium e, n, share daily
        public Boolean EArk
        {
            get { return eArk; }
            set
            {
                if (eArk != value)
                {
                    eArk = value;
                    OnPropertyChanged("EArk");
                }
            }
        }
        public Boolean NArk
        {
            get { return nArk; }
            set
            {
                if (nArk != value)
                {
                    nArk = value;
                    OnPropertyChanged("NArk");
                }
            }
        }

        //Ranmaru
        public Boolean NRanmaru
        {
            get { return nRanmaru; }
            set
            {
                if (nRanmaru != value)
                {
                    nRanmaru = value;
                    OnPropertyChanged("NRanmaru");
                }
            }
        }
        public Boolean HRanmaru
        {
            get { return hRanmaru; }
            set
            {
                if (hRanmaru != value)
                {
                    hRanmaru = value;
                    OnPropertyChanged("HRanmaru");
                }
            }
        }

        //Hilla
        public Boolean NHilla //daily
        {
            get { return nHilla; }
            set
            {
                if (nHilla != value)
                {
                    nHilla = value;
                    OnPropertyChanged("NHilla");
                }
            }
        }
        public Boolean HHilla //weekly
        {
            get { return hHilla; }
            set
            {
                if (hHilla != value)
                {
                    hHilla = value;
                    OnPropertyChanged("HHilla");
                }
            }
        }

        //Empress Cygnus both share weekly
        public Boolean ECygnus
        {
            get { return eCygnus; }
            set
            {
                if (eCygnus != value)
                {
                    eCygnus = value;
                    OnPropertyChanged("ECygnus");
                }
            }
        }
        public Boolean NCygnus
        {
            get { return nCygnus; }
            set
            {
                if (nCygnus != value)
                {
                    nCygnus = value;
                    OnPropertyChanged("NCygnus");
                }
            }
        }

        //Root Abyss normal and chaos do not share
        //All Normals Daily
        //All Chaos Weekly
        public Boolean NCQueen
        {
            get { return nCQueen; }
            set
            {
                if (nCQueen != value)
                {
                    nCQueen = value;
                    OnPropertyChanged("NCQueen");
                }
            }
        }
        public Boolean NPierre
        {
            get { return nPierre; }
            set
            {
                if (nPierre != value)
                {
                    nPierre = value;
                    OnPropertyChanged("NPierre");
                }
            }
        }
        public Boolean NVonBon
        {
            get { return nVonBon; }
            set
            {
                if (nVonBon != value)
                {
                    nVonBon = value;
                    OnPropertyChanged("NVonBon");
                }
            }
        }
        public Boolean NVellum
        {
            get { return nVellum; }
            set
            {
                if (nVellum != value)
                {
                    nVellum = value;
                    OnPropertyChanged("NVellum");
                }
            }
        }

        public Boolean CCQueen
        {
            get { return cCQueen; }
            set
            {
                if (cCQueen != value)
                {
                    cCQueen = value;
                    OnPropertyChanged("CCQueen");
                }
            }
        }
        public Boolean CPierre
        {
            get { return cPierre; }
            set
            {
                if (cPierre != value)
                {
                    cPierre = value;
                    OnPropertyChanged("CPierre");
                }
            }
        }
        public Boolean CVonBon
        {
            get { return cVonBon; }
            set
            {
                if (cVonBon != value)
                {
                    cVonBon = value;
                    OnPropertyChanged("CVonBon");
                }
            }
        }
        public Boolean CVellum
        {
            get { return cVellum; }
            set
            {
                if (cVellum != value)
                {
                    cVellum = value;
                    OnPropertyChanged("CVellum");
                }
            }
        }

        //Pink Bean
        public Boolean NPinkBean //Daily
        {
            get { return nPinkBean; }
            set
            {
                if (nPinkBean != value)
                {
                    nPinkBean = value;
                    OnPropertyChanged("NPinkBean");
                }
            }
        }
        public Boolean CPinkBean //Weekly
        {
            get { return cPinkBean; }
            set
            {
                if (cPinkBean != value)
                {
                    cPinkBean = value;
                    OnPropertyChanged("CPinkBean");
                }
            }
        }

        //Magnus e, n, share daily
        public Boolean EMagnus
        {
            get { return eMagnus; }
            set
            {
                if (eMagnus != value)
                {
                    eMagnus = value;
                    OnPropertyChanged("EMagnus");
                }
            }
        }
        public Boolean NMagnus
        {
            get { return nMagnus; }
            set
            {
                if (nMagnus != value)
                {
                    nMagnus = value;
                    OnPropertyChanged("NMagnus");
                }
            }
        }
        public Boolean HMagnus //Weekly
        {
            get { return hMagnus; }
            set
            {
                if (hMagnus != value)
                {
                    hMagnus = value;
                    OnPropertyChanged("HMagnus");
                }
            }
        }

        //Pap
        public Boolean EPap
        {
            get { return ePap; }
            set
            {
                if (ePap != value)
                {
                    ePap = value;
                    OnPropertyChanged("EPap");
                }
            }
        }

        public Boolean NPap
        {
            get { return nPap; }
            set
            {
                if (nPap != value)
                {
                    nPap = value;
                    OnPropertyChanged("NPap");
                }
            }
        }

        public Boolean CPap
        {
            get { return cPap; }
            set
            {
                if (cPap != value)
                {
                    cPap = value;
                    OnPropertyChanged("CPap");
                }
            }
        }


        //Gollux
        public Boolean Gollux
        {
            get { return gollux; }
            set
            {
                if (gollux != value)
                {
                    gollux = value;
                    OnPropertyChanged("Gollux");
                }
            }
        }

        //Ursus
        public Boolean Ursus
        {
            get { return ursus; }
            set
            {
                if (ursus != value)
                {
                    ursus = value;
                    OnPropertyChanged("Ursus");
                }
            }
        }

        public Boolean MapleTour
        {
            get { return mapleTour; }
            set
            {
                if (mapleTour != value)
                {
                    mapleTour = value;
                    OnPropertyChanged("MapleTour");
                }
            }
        }

        //Lotus both share weekly
        public Boolean NLotus
        {
            get { return nLotus; }
            set
            {
                if (nLotus != value)
                {
                    nLotus = value;
                    OnPropertyChanged("NLotus");
                }
            }
        }
        public Boolean HLotus
        {
            get { return hLotus; }
            set
            {
                if (hLotus != value)
                {
                    hLotus = value;
                    OnPropertyChanged("HLotus");
                }
            }
        }

        //Damien both share weekly
        public Boolean NDamien
        {
            get { return nDamien; }
            set
            {
                if (nDamien != value)
                {
                    nDamien = value;
                    OnPropertyChanged("NDamien");
                }
            }
        }
        public Boolean HDamien
        {
            get { return hDamien; }
            set
            {
                if (hDamien != value)
                {
                    hDamien = value;
                    OnPropertyChanged("HDamien");
                }
            }
        }

        //Lucid both share weekly
        public Boolean NLucid
        {
            get { return nLucid; }
            set
            {
                if (nLucid != value)
                {
                    nLucid = value;
                    OnPropertyChanged("NLucid");
                }
            }
        }
        public Boolean HLucid
        {
            get { return hLucid; }
            set
            {
                if (hLucid != value)
                {
                    hLucid = value;
                    OnPropertyChanged("HLucid");
                }
            }
        }

        //Will both share weekly
        public Boolean NWill
        {
            get { return nWill; }
            set
            {
                if (nWill != value)
                {
                    nWill = value;
                    OnPropertyChanged("NWill");
                }
            }
        }
        public Boolean HWill
        {
            get { return hWill; }
            set
            {
                if (hWill != value)
                {
                    hWill = value;
                    OnPropertyChanged("HWill");
                }
            }
        }

        //Gloom, VHilla, Darknell, do not share, all weekly
        public Boolean NGloom
        {
            get { return nGloom; }
            set
            {
                if (nGloom != value)
                {
                    nGloom = value;
                    OnPropertyChanged("NGloom");
                }
            }
        }
        public Boolean HVHilla
        {
            get { return hVHilla; }
            set
            {
                if (hVHilla != value)
                {
                    hVHilla = value;
                    OnPropertyChanged("HVHilla");
                }
            }
        }
        public Boolean NDarknell
        {
            get { return nDarknell; }
            set
            {
                if (nDarknell != value)
                {
                    nDarknell = value;
                    OnPropertyChanged("NDarknell");
                }
            }
        }

        //Black Mage
        public Boolean HBlackMage //monthly? maybe
        {
            get { return hBlackMage; }
            set
            {
                if (hBlackMage != value)
                {
                    hBlackMage = value;
                    OnPropertyChanged("HBlackMage");
                }
            }
        }

        //Non-Boss Data
        //Commerci all daily
        public Boolean ComVoyages
        {
            get { return comVoyages; }
            set
            {
                if (comVoyages != value)
                {
                    comVoyages = value;
                    OnPropertyChanged("ComVoyages");
                }
            }
        }
        public Boolean ComPQ
        {
            get { return comPQ; }
            set
            {
                if (comPQ != value)
                {
                    comPQ = value;
                    OnPropertyChanged("ComPQ");
                }
            }
        }

        //Dojo
        public Boolean DojDojo
        {
            get { return dojDojo; }
            set
            {
                if (dojDojo != value)
                {
                    dojDojo = value;
                    OnPropertyChanged("DojDojo");
                }
            }
        }

        //Monster Park
        public Boolean MpMonsterPark
        {
            get { return mpMonsterPark; }
            set
            {
                if (mpMonsterPark != value)
                {
                    mpMonsterPark = value;
                    OnPropertyChanged("MpMonsterPark");
                }
            }
        }

        //Legion
        public Boolean LegQuests
        {
            get { return legQuests; }
            set
            {
                if (legQuests != value)
                {
                    legQuests = value;
                    OnPropertyChanged("LegQuests");
                }
            }
        }

        //Arcane River
        //Vanishing Journey
        public Boolean VjQuests
        {
            get { return vjQuests; }
            set
            {
                if (vjQuests != value)
                {
                    vjQuests = value;
                    OnPropertyChanged("VjQuests");
                }
            }
        }
        public Boolean VjErdaSpectrum
        {
            get { return vjErdaSpectrum; }
            set
            {
                if (vjErdaSpectrum != value)
                {
                    vjErdaSpectrum = value;
                    OnPropertyChanged("VjErdaSpectrum");
                }
            }
        }

        //Chu Chu Island
        public Boolean ChuchuQuests
        {
            get { return chuchuQuests; }
            set
            {
                if (chuchuQuests != value)
                {
                    chuchuQuests = value;
                    OnPropertyChanged("ChuchuQuests");
                }
            }
        }
        public Boolean ChuchuHMuto
        {
            get { return chuchuHMuto; }
            set
            {
                if (chuchuHMuto != value)
                {
                    chuchuHMuto = value;
                    OnPropertyChanged("ChuchuHMuto");
                }
            }
        }

        //Lachelein
        public Boolean LachQuests
        {
            get { return lachQuests; }
            set
            {
                if (lachQuests != value)
                {
                    lachQuests = value;
                    OnPropertyChanged("LachQuests");
                }
            }
        }
        public Boolean LachDDefender
        {
            get { return lachDDefender; }
            set
            {
                if (lachDDefender != value)
                {
                    lachDDefender = value;
                    OnPropertyChanged("LachDDefender");
                }
            }
        }

        //Arcana
        public Boolean ArcQuests
        {
            get { return arcQuests; }
            set
            {
                if (arcQuests != value)
                {
                    arcQuests = value;
                    OnPropertyChanged("ArcQuests");
                }
            }
        }
        public Boolean ArcSSavior
        {
            get { return arcSSavior; }
            set
            {
                if (arcSSavior != value)
                {
                    arcSSavior = value;
                    OnPropertyChanged("ArcSSavior");
                }
            }
        }

        //Morass and Esfera
        public Boolean MorQuests
        {
            get { return morQuests; }
            set
            {
                if (morQuests != value)
                {
                    morQuests = value;
                    OnPropertyChanged("MorQuests");
                }
            }
        }
        public Boolean EsfQuests
        {
            get { return esfQuests; }
            set
            {
                if (esfQuests != value)
                {
                    esfQuests = value;
                    OnPropertyChanged("EsfQuests");
                }
            }
        }

        //SY DWT
        public Boolean SyQuests
        {
            get { return syQuests; }
            set
            {
                if (syQuests != value)
                {
                    syQuests = value;
                    OnPropertyChanged("SyQuests");
                }
            }
        }
        public Boolean DwtQuests
        {
            get { return dwtQuests; }
            set
            {
                if (dwtQuests != value)
                {
                    dwtQuests = value;
                    OnPropertyChanged("DwtQuests");
                }
            }
        }
        #endregion

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ResetAll()
        {
            ProfileName = null;
            ResetDaily();
            ResetWeeklyWednesday();
            ResetWeeklySunday();
        }

        public void ResetDaily()
        {
            EZak = false;
            NZak = false;
            EVLeon = false;
            NVLeon = false;
            HVLeon = false;
            EHTail = false;
            NHTail = false;
            CHTail = false;
            EArk = false;
            NArk = false;
            NRanmaru = false;
            HRanmaru = false;
            NHilla = false;
            NCQueen = false;
            NPierre = false;
            NVonBon = false;
            NVellum = false;
            NPinkBean = false;
            EMagnus = false;
            NMagnus = false;
            EPap = false;
            NPap = false;
            Gollux = false;
            Ursus = false;
            MapleTour = false;
            ComVoyages = false;
            ComPQ = false;
            MpMonsterPark = false;
            LegQuests = false;
            VjQuests = false;
            VjErdaSpectrum = false;
            ChuchuQuests = false;
            ChuchuHMuto = false;
            LachQuests = false;
            LachDDefender = false;
            ArcQuests = false;
            ArcSSavior = false;
            MorQuests = false;
            EsfQuests = false;
            LastDateTimeReset_Daily = DateTime.UtcNow;
        }//end of ResetDaily

        public void ResetWeeklyWednesday()
        {
            CZak = false;
            ECygnus = false;
            NCygnus = false;
            HHilla = false;
            CCQueen = false;
            CPierre = false;
            CVonBon = false;
            CVellum = false;
            CPinkBean = false;
            HMagnus = false;
            CPap = false;
            NLotus = false;
            HLotus = false;
            NDamien = false;
            HDamien = false;
            NLucid = false;
            HLucid = false;
            NWill = false;
            HWill = false;
            NGloom = false;
            HVHilla = false;
            NDarknell = false;
            HBlackMage = false;
            LastDateTimeReset_WeeklyWednesday = DateTime.UtcNow;
        }

        public void ResetWeeklySunday()
        {
            DojDojo = false;
            SyQuests = false;
            DwtQuests = false;
            LastDateTimeReset_WeeklySunday = DateTime.UtcNow;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Profile Name", ProfileName);
            info.AddValue("Auto Reset", autoReset);
            info.AddValue("Auto Save", autoSave);
            info.AddValue("Easy Zakum", eZak);
            info.AddValue("Normal Zakum", nZak);
            info.AddValue("Chaos Zakum", cZak);
            info.AddValue("Easy Von Leon", eVLeon);
            info.AddValue("Normal Von Leon", nVLeon);
            info.AddValue("Hard Von Leon", hVLeon);
            info.AddValue("Easy Horntail", eHTail);
            info.AddValue("Normal Horntail", nHTail);
            info.AddValue("Chaos Horntail", cHTail);
            info.AddValue("Easy Arkarium", eArk);
            info.AddValue("Normal Arkarium", nArk);
            info.AddValue("Normal Ranmaru", nRanmaru);
            info.AddValue("Hard Ranmaru", hRanmaru);
            info.AddValue("Normal Hilla", nHilla);
            info.AddValue("Hard Hilla", hHilla);
            info.AddValue("Easy Cygnus", eCygnus);
            info.AddValue("Normal Cygnus", nCygnus);
            info.AddValue("Crimson Queen", nCQueen);
            info.AddValue("Pierre", nPierre);
            info.AddValue("Von Bon", nVonBon);
            info.AddValue("Vellum", nVellum);
            info.AddValue("Chaos Crimson Queen", cCQueen);
            info.AddValue("Chaos Pierre", cPierre);
            info.AddValue("Chaos Von Bon", cVonBon);
            info.AddValue("Chaos Vellum", cVellum);
            info.AddValue("Normal Pink Bean", nPinkBean);
            info.AddValue("Chaos Pink Bean", cPinkBean);
            info.AddValue("Easy Magnus", eMagnus);
            info.AddValue("Normal Magnus", nMagnus);
            info.AddValue("Hard Magnus", hMagnus);
            info.AddValue("Gollux", gollux);
            info.AddValue("Ursus", ursus);
            info.AddValue("MapleTour", mapleTour);
            info.AddValue("Normal Lotus", nLotus);
            info.AddValue("Hard Lotus", hLotus);
            info.AddValue("Normal Damien", nDamien);
            info.AddValue("Hard Damien", hDamien);
            info.AddValue("Normal Lucid", nLucid);
            info.AddValue("Hard Lucid", hLucid);
            info.AddValue("Normal Will", nWill);
            info.AddValue("Hard Will", hWill);
            info.AddValue("Gloom", nGloom);
            info.AddValue("Verus Hilla", hVHilla);
            info.AddValue("Darknell", nDarknell);
            info.AddValue("Black Mage", hBlackMage);
            info.AddValue("Commerci Voyages", comVoyages);
            info.AddValue("Commerci PQ", comPQ);
            info.AddValue("Mulung Dojo", dojDojo);
            info.AddValue("Monster Park", mpMonsterPark);
            info.AddValue("Legion Dailies", legQuests);
            info.AddValue("VJ Quests", vjQuests);
            info.AddValue("VJ Erda Spectrum", vjErdaSpectrum);
            info.AddValue("ChuChu Quests", chuchuQuests);
            info.AddValue("ChuChu HMuto", chuchuHMuto);
            info.AddValue("Lach Quests", lachQuests);
            info.AddValue("Lach DDefender", lachDDefender);
            info.AddValue("Arc Quests", arcQuests);
            info.AddValue("Arc SSavior", arcSSavior);
            info.AddValue("Mor Quests", morQuests);
            info.AddValue("Esf Quests", esfQuests);
            info.AddValue("SY Quests", syQuests);
            info.AddValue("DWT Quests", dwtQuests);
            info.AddValue("LastDateTimeReset_Daily", lastDateTimeReset_Daily);
            info.AddValue("LastDateTimeReset_WeeklyWednesday", lastDateTimeReset_WeeklyWednesday);
            info.AddValue("LastDateTimeReset_WeeklySunday", lastDateTimeReset_WeeklySunday);
        }

        public Profile(SerializationInfo info, StreamingContext context)
        {
            ProfileName = (string)info.GetValue("Profile Name", typeof(string));
            autoReset = (bool)info.GetValue("Auto Reset", typeof(bool));
            autoSave = (bool)info.GetValue("Auto Save", typeof(bool));
            eZak = (bool)info.GetValue("Easy Zakum", typeof(bool));
            nZak = (bool)info.GetValue("Normal Zakum", typeof(bool));
            cZak = (bool)info.GetValue("Chaos Zakum", typeof(bool));
            eVLeon = (bool)info.GetValue("Easy Von Leon", typeof(bool));
            nVLeon = (bool)info.GetValue("Normal Von Leon", typeof(bool));
            hVLeon = (bool)info.GetValue("Hard Von Leon", typeof(bool));
            eHTail = (bool)info.GetValue("Easy Horntail", typeof(bool));
            nHTail = (bool)info.GetValue("Normal Horntail", typeof(bool));
            cHTail = (bool)info.GetValue("Chaos Horntail", typeof(bool));
            eArk = (bool)info.GetValue("Easy Arkarium", typeof(bool));
            nArk = (bool)info.GetValue("Normal Arkarium", typeof(bool));
            nRanmaru = (bool)info.GetValue("Normal Ranmaru", typeof(bool));
            hRanmaru = (bool)info.GetValue("Hard Ranmaru", typeof(bool));
            nHilla = (bool)info.GetValue("Normal Hilla", typeof(bool));
            hHilla = (bool)info.GetValue("Hard Hilla", typeof(bool));
            eCygnus = (bool)info.GetValue("Easy Cygnus", typeof(bool));
            nCygnus = (bool)info.GetValue("Normal Cygnus", typeof(bool));
            nCQueen = (bool)info.GetValue("Crimson Queen", typeof(bool));
            nPierre = (bool)info.GetValue("Pierre", typeof(bool));
            nVonBon = (bool)info.GetValue("Von Bon", typeof(bool));
            nVellum = (bool)info.GetValue("Vellum", typeof(bool));
            cCQueen = (bool)info.GetValue("Chaos Crimson Queen", typeof(bool));
            cPierre = (bool)info.GetValue("Chaos Pierre", typeof(bool));
            cVonBon = (bool)info.GetValue("Chaos Von Bon", typeof(bool));
            cVellum = (bool)info.GetValue("Chaos Vellum", typeof(bool));
            nPinkBean = (bool)info.GetValue("Normal Pink Bean", typeof(bool));
            cPinkBean = (bool)info.GetValue("Chaos Pink Bean", typeof(bool));
            eMagnus = (bool)info.GetValue("Easy Magnus", typeof(bool));
            nMagnus = (bool)info.GetValue("Normal Magnus", typeof(bool));
            hMagnus = (bool)info.GetValue("Hard Magnus", typeof(bool));
            gollux = (bool)info.GetValue("Gollux", typeof(bool));
            ursus = (bool)info.GetValue("Ursus", typeof(bool));
            mapleTour = (bool)info.GetValue("MapleTour", typeof(bool));
            nLotus = (bool)info.GetValue("Normal Lotus", typeof(bool));
            hLotus = (bool)info.GetValue("Hard Lotus", typeof(bool));
            nDamien = (bool)info.GetValue("Normal Damien", typeof(bool));
            hDamien = (bool)info.GetValue("Hard Damien", typeof(bool));
            nLucid = (bool)info.GetValue("Normal Lucid", typeof(bool));
            hLucid = (bool)info.GetValue("Hard Lucid", typeof(bool));
            nWill = (bool)info.GetValue("Normal Will", typeof(bool));
            hWill = (bool)info.GetValue("Hard Will", typeof(bool));
            comVoyages = (bool)info.GetValue("Commerci Voyages", typeof(bool));
            comPQ = (bool)info.GetValue("Commerci PQ", typeof(bool));
            dojDojo = (bool)info.GetValue("Mulung Dojo", typeof(bool));
            mpMonsterPark = (bool)info.GetValue("Monster Park", typeof(bool));
            legQuests = (bool)info.GetValue("Legion Dailies", typeof(bool));
            vjQuests = (bool)info.GetValue("VJ Quests", typeof(bool));
            vjErdaSpectrum = (bool)info.GetValue("VJ Erda Spectrum", typeof(bool));
            chuchuQuests = (bool)info.GetValue("ChuChu Quests", typeof(bool));
            chuchuHMuto = (bool)info.GetValue("ChuChu HMuto", typeof(bool));
            lachQuests = (bool)info.GetValue("Lach Quests", typeof(bool));
            lachDDefender = (bool)info.GetValue("Lach DDefender", typeof(bool));
            arcQuests = (bool)info.GetValue("Arc Quests", typeof(bool));
            arcSSavior = (bool)info.GetValue("Arc SSavior", typeof(bool));
            morQuests = (bool)info.GetValue("ChuChu Quests", typeof(bool));
            esfQuests = (bool)info.GetValue("Esf Quests", typeof(bool));
            syQuests = (bool)info.GetValue("SY Quests", typeof(bool));
            dwtQuests = (bool)info.GetValue("DWT Quests", typeof(bool));
            lastDateTimeReset_Daily = (DateTime)info.GetValue("LastDateTimeReset_Daily", typeof(DateTime));
            lastDateTimeReset_WeeklyWednesday = (DateTime)info.GetValue("LastDateTimeReset_WeeklyWednesday", typeof(DateTime));
            lastDateTimeReset_WeeklySunday = (DateTime)info.GetValue("LastDateTimeReset_WeeklySunday", typeof(DateTime));
        }//end of profile xml deserial
    }//end of Profile class

}//end of namespace
