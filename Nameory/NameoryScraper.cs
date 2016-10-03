using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Nameory
{
    public class NameoryScraper
    {
        private MatchCollection matches;
        public string[] UrlsToImages { get; private set; }
        public string[] FirstNames { get; private set; }
        public string[] LastNames { get; private set; }
        public string[] Bios { get; private set; }
        public string[] Genders { get; private set; }

        public NameoryScraper(Uri url, string regularExpression)
        {
            string sourceCode = GetSourceCode(url);

            //DEBUG
            sourceCode = sourceCode.Substring(sourceCode.IndexOf("<body"));
            //DEBUG
            matches = Scrape(sourceCode, regularExpression);

            UrlsToImages = GetGroupFromMatches("url");
            FirstNames = GetGroupFromMatches("firstname");
            LastNames = GetGroupFromMatches("lastname");
            Bios = GetGroupFromMatches("bio");
            Genders = AssumeGender(GetGroupFromMatches("bio"));
        }


        /*private string[] NewCoolScraper(string url)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.Load("file.htm");
            foreach (HtmlNode link in doc.DocumentElement.SelectNodes("//a[@href"])
                {
                HtmlAttribute att = link["href"];
                att.Value = FixLink(att);
            }
            doc.Save("file.htm");

        }*/

        /// <summary>
        /// Tar in en string-url och skickar tillbaka en Uri-url.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static Uri CheckUrl(string url)
        {
            try
            {
                return new Uri(url);
            }
            catch (Exception exception)
            {
                throw exception;
            }

            throw new Exception("URL inkorrekt.");
        }

        private string GetSourceCode(Uri url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                string data = readStream.ReadToEnd();

                response.Close();
                readStream.Close();

                return data;
            }
            else
            {
                throw new Exception("Något gick fel i datahämtningen.");
            }
        }

        public MatchCollection Scrape(string sourceCode, string regularExpression)
        {
            MatchCollection matches = Regex.Matches(sourceCode, regularExpression);

            return matches;
        }

        public string[] GetGroupFromMatches(string group)
        {
            string[] tempArray = new string[matches.Count];

            for (int i = 0; i < matches.Count; i++)
            {
                tempArray[i] = matches[i].Groups[group].Value;
            }

            return tempArray;
        }

        // Den här är kaos
        public string[] AssumeGender(string[] bios)
        {
            string[] tempArray = new string[bios.Length];

            for (int i = 0; i < bios.Length; i++)
            {
                if (bios[i].ToLower().Contains(" hon "))
                {
                    tempArray[i] = "female";
                }
                else /*if (bios[i].ToLower().Contains(" han "))*/
                {
                    tempArray[i] = "male";
                }
                /*else
                {
                    tempArray[i] = "unknown";
                }*/
            }

            return tempArray;
        }
    }
}