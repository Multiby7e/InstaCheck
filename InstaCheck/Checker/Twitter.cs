using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InstaCheck.Checker
{
    class Twitter
    {
        public static string GetHTML(string Url)
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(Url);
            WebHeaderCollection getHeaders = myRequest.Headers;
            myRequest.Method = "GET";
            WebResponse myResponse = myRequest.GetResponse();
            StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
            string HTML = sr.ReadToEnd();
            sr.Close();
            myResponse.Close();
            return HTML;
        }

        public static bool Exists(string Username)
        {

            try
            {
                return !GetHTML("https://twitter.com/" + Username).Contains("Sorry, that page doesn’t exist!");
            }
            catch { return false; }
        }
    }
}
