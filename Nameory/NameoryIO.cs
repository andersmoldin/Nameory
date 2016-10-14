using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;


namespace Nameory
{
    static class NameoryIO
    {
        static string[] FilePaths { get; set; }
        static string folderPath;
        static string userChoice { get; set; }
        internal static List<NameoryObject> GetList(int group)
        {
            List<NameoryObject> tempList = new List<NameoryObject>();
            NameoryScraper nameoryScraper = null;
            if (group == 1)
            {
                nameoryScraper = new NameoryScraper(NameoryScraper.CheckUrl("http://academy.se/utbildningen/konsulter-java-ht16"), @"(?<url>http://academy.se/wp-content/uploads\/2016\/0[8-9]\/[A-Za-z0-9_]+.png)(?<crap>[a-z0-9_\<\=\""\>\s\/\.\-\:]+)(?<firstname>[A-Öa-öé]+) (?<lastname>[A-Öa-öé]+)(?<morecrap>[a-z0-9_\<\=\""\>\s\/\.\-\:]+)(?<bio>[^<]+)");
                userChoice = "java_ht16"; // Ugly hack...
            }
            else if (group == 0)
            {
                nameoryScraper = new NameoryScraper(NameoryScraper.CheckUrl("http://academy.se/utbildningen/konsulter-dotnet-ht16"), @"src=""(?<url>http://academy.se/wp-content/upload[^""]+)[^A-Z]+(?<firstname>[^ ]+) (?<lastname>[^<]+)[^A-Z]+(?<bio>[^\n]+)");
                userChoice = "c#_ht16"; // Ugly hack...
            }

            CreateTMPDirectory(userChoice);
            GetFilepathsFromUrl(nameoryScraper, folderPath);

            if (!FileExists(FilePaths))
            {
                DownloadImages(nameoryScraper, FilePaths);
                ChangeUrlToFilepath(nameoryScraper);
                JSONSerializer(ScraperToList(nameoryScraper));
            }

            tempList = JSONDeserializer(folderPath, userChoice);
            return tempList;
        }
        private static void CreateTMPDirectory(string dropdownchoice)
        {
            string tempDirectory = Path.Combine(Path.GetTempPath(), "Nameory", dropdownchoice); // String 3 userChoice.
            try
            {
                Directory.CreateDirectory(tempDirectory); // Creates a new tempfolder if one does not already exist.
                folderPath = tempDirectory;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to create directory." + ex.Message); // Change to messagebox.
            }
        }
        private static void GetFilepathsFromUrl(NameoryScraper nameoryScraper, string folderPath)
        {
            FilePaths = new string[nameoryScraper.UrlsToImages.Length];

            for (int i = 0; i < nameoryScraper.UrlsToImages.Length; i++)
            {
                FilePaths[i] = folderPath + "\\" + nameoryScraper.UrlsToImages[i].Substring(nameoryScraper.UrlsToImages[i].LastIndexOf("/") + 1);
            }
        }
        internal static bool FileExists(string[] filePaths)
        {
            bool fileexists = true;
            for (int i = 0; i < filePaths.Length; i++)
            {
                if (!File.Exists(filePaths[i]))
                {
                    fileexists = false;
                    break;
                }
            }
            return fileexists;
        }
        private static void DownloadImages(NameoryScraper nameoryScraper, string[] filePaths)
        {
            WebClient downloader = new WebClient();
            try
            {
                for (int i = 0; i < filePaths.Length; i++)
                {
                    downloader.DownloadFile(nameoryScraper.UrlsToImages[i], filePaths[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to download files." + ex.Message);
            }
        }
        private static void ChangeUrlToFilepath(NameoryScraper nameoryScraper)
        {
            // Ugly way to change paths to local filepath...
            for (int i = 0; i < nameoryScraper.UrlsToImages.Length; i++)
            {
                nameoryScraper.UrlsToImages[i] = FilePaths[i];
            }
        }
        private static void JSONSerializer(List<NameoryObject> scraperList)
        {
            string jsonClass = JsonConvert.SerializeObject(scraperList, Formatting.Indented);
            try
            {
                File.WriteAllText(folderPath + "\\" + userChoice, jsonClass);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Unable to serialize class to JSON object." + ex.Message);
            }
        }
        private static List<NameoryObject> JSONDeserializer(string folderPath, string userChoice)
        {
            string tmpData = string.Empty;
            List<NameoryObject> listOfNameoryObjects = new List<NameoryObject>();
            try
            {
                tmpData = File.ReadAllText(folderPath + "\\" + userChoice);
                listOfNameoryObjects = JsonConvert.DeserializeObject<List<NameoryObject>>(tmpData);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Deserialization of chosen class failed." + ex.Message);
            }
            return listOfNameoryObjects;
        }
        private static List<NameoryObject> ScraperToList(NameoryScraper nameoryScraper)
        {
            var scraperList = new List<NameoryObject>();

            for (int i = 0; i < nameoryScraper.FirstNames.Length; i++)
            {
                scraperList.Add(new NameoryObject(nameoryScraper.FirstNames[i], nameoryScraper.LastNames[i], nameoryScraper.UrlsToImages[i], nameoryScraper.Bios[i], nameoryScraper.Genders[i]));

            }
            return scraperList;
        }
    }
}
