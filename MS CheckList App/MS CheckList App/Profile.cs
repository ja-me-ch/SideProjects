using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MS_CheckList_App
{
	[Serializable()]
    public class Profile : ISerializable
    {
		//Character Data
		public String ProfileName { get; set; }
		public String description { get; set; }

		public DateTime lastDateTimeCheck { get; set; }

		public Profile()
		{

		}

		public Profile(string name)
		{
			ProfileName = name;
		}

		//Boss Data
		//Zakum
		public Boolean eZak  { get; set; } //Daily
		public Boolean nZak { get; set; } //Daily Shares with eZak
		public Boolean cZak { get; set; } //Weekly

		//Von Leon e, n, h, all share daily
		public Boolean eVLeon { get; set; }
		public Boolean nVLeon { get; set; }
		public Boolean hVLeon { get; set; }

		//Horntail e, n, c, all share daily
		public Boolean eHTail { get; set; }
		public Boolean nHTail { get; set; }
		public Boolean cHTail { get; set; }

		//Arkarium e, n, share daily
		public Boolean eArk { get; set; }
		public Boolean nArk { get; set; }

		//Ranmaru
		public Boolean nRanmaru { get; set; }
		public Boolean hRanmaru { get; set; }

		//Hilla
		public Boolean nHilla { get; set; } //daily
		public Boolean hHilla { get; set; } //weekly

		//Empress Cygnus both share weekly
		public Boolean eCygnus { get; set; }
		public Boolean nCygnus { get; set; }

		//Root Abyss normal and chaos do not share
		public Boolean nCQueen { get; set; }//All normals daily
		public Boolean nPierre { get; set; }
		public Boolean nVonBon { get; set; }
		public Boolean nVellum { get; set; }
		public Boolean cCQueen { get; set; }//All chaos weekly
		public Boolean cPierre { get; set; }
		public Boolean cVonBon { get; set; }
		public Boolean cVellum { get; set; }

		//Pink Bean
		public Boolean nPinkBean { get; set; } //daily
		public Boolean cPinkBean { get; set; } //weekly

		//Magnus e, n, share daily
		public Boolean eMagnus { get; set; }
		public Boolean nMagnus { get; set; }
		public Boolean hMagnus { get; set; } //weekly

		//Gollux
		public Boolean gollux { get; set; } //daily

		//Ursus
		public Boolean ursus { get; set; }

		//Lotus both share weekly
		public Boolean nLotus { get; set; }
		public Boolean hLotus { get; set; }

		//Damien both share weekly
		public Boolean nDamien { get; set; }
		public Boolean hDamien { get; set; }

		//Lucid both share weekly
		public Boolean nLucid { get; set; }
		public Boolean hLucid { get; set; }

		//Will both share weekly
		public Boolean nWill { get; set; }
		public Boolean hWill { get; set; }

		//Gloom, VHilla, Darknell, do not share, all weekly
		public Boolean nGloom { get; set; } //weekly
		public Boolean hVHilla { get; set; } //weekly
		public Boolean nDarknell { get; set; } //weekly

		//Black Mage
		public Boolean hBlackMage { get; set; } //monthly?

		//Non-Boss Data
		//Commerci all daily
		public Boolean comVoyages { get; set; }
		public Boolean comPQ { get; set; }

		//Dojo
		public Boolean dojDojo { get; set; }

		//Monster Park
		public Boolean mpMonsterPark { get; set; }

		//Legion
		public Boolean legQuests { get; set; } //daily

		//Arcane River
		//Vanishing Journey
		public Boolean vjQuests { get; set; } //daily
		public Boolean vjErdaSpectrum { get; set; } //daily

		//Chu Chu Island
		public Boolean chuchuQuests { get; set; }
		public Boolean chuchuHMuto { get; set; }

		//Lachelein
		public Boolean lachQuests { get; set; }
		public Boolean lachDDefender { get; set; }

		//Arcana
		public Boolean arcQuests { get; set; }
		public Boolean arcSSavior { get; set; }

		//Morass and Esfera
		public Boolean morQuests { get; set; }
		public Boolean esfQuests { get; set; }

		//SY DWT
		public Boolean syQuests { get; set; }
		public Boolean dwtQuests { get; set; }

		public void ResetDaily()
		{
			eZak = false;
			nZak = false;
			eVLeon = false;
			nVLeon = false;
			hVLeon = false;
			eHTail = false;
			nHTail = false;
			cHTail = false;
			eArk = false;
			nArk = false;
			nRanmaru = false;
			hRanmaru = false;
			nHilla = false;
			nCQueen = false;
			nPierre = false;
			nVonBon = false;
			nVellum = false;
			nPinkBean = false;
			eMagnus = false;
			nMagnus = false;
			gollux = false;
			ursus = false;
			comVoyages = false;
			comPQ = false;
			mpMonsterPark = false;
			legQuests = false;
			vjQuests = false;
			vjErdaSpectrum = false;
			chuchuQuests = false;
			chuchuHMuto = false;
			lachQuests = false;
			lachDDefender = false;
			arcQuests = false;
			arcSSavior = false;
			morQuests = false;
			esfQuests = false;
		}//end of ResetDaily

		public void ResetWeeklyWednesday()
		{
			cZak = false;
			eCygnus = false;
			nCygnus = false;
			cCQueen = false;
			cPierre = false;
			cVonBon = false;
			cVellum = false;
			cPinkBean = false;
			hMagnus = false;
			nLotus = false;
			hLotus = false;
			nDamien = false;
			hDamien = false;
			nLucid = false;
			hLucid = false;
			nWill = false;
			hWill = false;
			nGloom = false;
			hVHilla = false;
			nDarknell = false;
			hBlackMage = false;
			dojDojo = false;
		}

		public void ResetWeeklySunday()
		{
			dojDojo = false;
			syQuests = false;
			dwtQuests = false;
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("Profile Name", ProfileName);
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
		}

		public Profile(SerializationInfo info, StreamingContext context)
		{
			ProfileName = (string)info.GetValue("Profile Name", typeof(string));
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
		}//end of profile xml deserial
	}//end of Profile class

}//end of namespace
