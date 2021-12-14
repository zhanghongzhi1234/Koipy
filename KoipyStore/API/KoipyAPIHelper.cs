using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace API
{
    public class KoipyAPIHelper
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static volatile KoipyAPIHelper instance;        //singleton
        private static object syncRoot = new Object();

        public static KoipyAPIHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new KoipyAPIHelper();
                    }
                }

                return instance;
            }
        }

        //call API by url
        //return: null: fail
        public string getAPI(string url)
        {
            string responseFromServer = "" ;
            try
            {
                //                url = "http://localhost/store/storeuser/login/language/en_us";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.UserAgent = "Koipy";
                //               request.Headers.Add("HTTP_USER_AGENT", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.1 (KHTML, like Gecko) Chrome/21.0.1134.0 Safari/537.1");
                //               request.Headers.Add("HTTP_ACCEPT", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
                //               request.Headers.Add("HTTP_ACCEPT_ENCODING", "gzip,deflate");
                //               request.Headers.Add("HTTP_ACCEPT_LANGUAGE", "es_us");
                //               request.Headers.Add("HTTP_ACCEPT_CHARSET", "ISO-8859-1,utf-8;q=0.7,*;q=0.3");
                request.Headers.Add("Accept-Language", "en;q=0.8");

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    log.Info("Response Status Code is OK and StatusDescription is:" + response.StatusDescription);
                    // Get the stream containing content returned by the server.
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    responseFromServer = reader.ReadToEnd();
                    log.Info(responseFromServer);
//                    responseFromServer.Replace("\\\"", "\"");
                    reader.Close();
                    dataStream.Close();
                }
                response.Close();

            }
            catch (WebException ex)
            {   //Cannot connect to Koipy server!
                log.Error(ex.ToString());
                //下面把出错的API返回结果kopy到剪贴板, only for debug
/*                HttpWebResponse res = (HttpWebResponse)ex.Response;
                StreamReader sr = new StreamReader(res.GetResponseStream());
                string strHtml = sr.ReadToEnd();
                strHtml.Replace("\n", "\r\n");
                strHtml.Replace("\t", "");
                strHtml.Replace("\\\"", "\"");
                Clipboard.SetText(strHtml);*/
            }
            catch (System.Exception ex)
            {
                log.Error(ex.ToString());
            }
            return responseFromServer;
        }
    }
}
