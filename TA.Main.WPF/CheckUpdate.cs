using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Cache;
using System.IO;
using System.Xml;
using System.Diagnostics;


namespace TA.Main
{
    class CheckUpdate
    {
#if !DEBUG
        private static string UrlToXml = @"http://competition-manager.com/last_update.php";
#else
        private static string UrlToXml = @"http://localhost:8080/competition-manager.com/last_update.php";
#endif
        private static string Edition = TA.Corel.EditionManager.Edition.ToString();// "FED_EDITION";
        private static void GetLastUpdate(string currentVersion, fMain mainForm)
        {
            try
            {
                
                StringBuilder sb = new StringBuilder();
                // used on each read operation
                byte[] buf = new byte[8192];
                // prepare the web page we will be asking for
                string url = UrlToXml + "?app_guid=" + LicenseManager.SoftwareGuid.ToString();
                url = url + "&exp_date=" + LicenseManager.LicenseExpireDate;
                url = url + "&email=" + LicenseManager.EMail;
                url = url + "&instance_guid=" + LicenseManager.InstanceGuid;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ProtocolVersion = HttpVersion.Version11;
                request.AllowAutoRedirect = false;
                HttpRequestCachePolicy noCachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
                request.CachePolicy = noCachePolicy;
                request.Accept = "*/*";
                request.Timeout = 15000;
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727)";
                request.Headers.Add("Accept-Language", "en-us");
                request.KeepAlive = true;
                // execute the request
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                // we will read data via the response stream
                Stream resStream = response.GetResponseStream();
                string tempString = null;
                int count = 0;
                do
                {
                    // fill the buffer with data
                    count = resStream.Read(buf, 0, buf.Length);
                    // make sure we read some data
                    if (count != 0)
                    {
                        // translate from bytes to ASCII text
                        tempString = Encoding.ASCII.GetString(buf, 0, count);
                        // continue building the string
                        sb.Append(tempString);
                    }
                }
                while (count > 0); // any more data to read?
                string result = sb.ToString();
                const string ROOT_TAG = @"</LAST_BUILD_DATE>";
                int last = result.LastIndexOf(ROOT_TAG);
                string xml_text = sb.ToString();
                int index = xml_text.IndexOf(ROOT_TAG);
                if (index < 0)
                    return;
                index = index + ROOT_TAG.Length;
                xml_text = xml_text.Substring(0, index);
#if !DEBUG                
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.InnerXml = xml_text;
                XmlNodeList editionDate = xmlDoc.GetElementsByTagName(Edition);
                if (editionDate != null) 
                {
                    string lastUpdate = editionDate[0].Attributes["date"].Value;
                    if (lastUpdate.CompareTo(currentVersion) > 0)
                    {
                        mainForm.ShowDownloadPanel();
                        /*fCheckUpdate form = new fCheckUpdate();
                        form.ShowDialog();*/
                    }
                }
#endif
            }
            catch (Exception)
            {

            }
        }
        public static void CheckLastVersion(DateTime currentBuildDate, fMain mainForm)
        {
            Thread t = new Thread(delegate() { GetLastUpdate(currentBuildDate.ToString("yyyyMMdd"), mainForm); });
            t.Start();
        }
    }
}
