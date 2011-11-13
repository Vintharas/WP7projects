using System;
using System.Net;
using System.IO;
using System.Threading;

namespace GoogleReaderService.Concretes
{
    public class GoogleReader
    {
        public string Sid { get { return _sid; } }
        private string _sid = null;
        public string Token { get { return _token; } }
        private string _token = null;
        private Cookie _cookie = null;

        private string _username;
        private string _password;

        /// <summary>
        /// Initialize members
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public GoogleReader(string username, string password)
        {
            _username = username;
            _password = password;
        }

        /// <summary>
        /// Connect to google reader
        /// </summary>
        /// <returns></returns>
        public bool Connect()
        {
            GetToken();
            return _token != null;
        }
        
        /// <summary>
        /// Get identity token to be able to access google reader
        /// </summary>
        private void GetToken()
        {
            GetSid();
            _cookie = new Cookie("SID", _sid, "/", ".google.com");

            string url = "http://www.google.com/reader/api/0/token";

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "GET";
            req.CookieContainer = new CookieContainer();
            req.CookieContainer.Add(new Uri("http://www.google.com/"), _cookie); // Added Uri

            HttpWebResponse response = (HttpWebResponse)req.GetResponse();
            
            using (var stream = response.GetResponseStream())
            {
                StreamReader r = new StreamReader(stream);
                _token = r.ReadToEnd();
            }
        }

        private void GetSid()
        {
            string requestUrl = string.Format
                ("https://www.google.com/accounts/ClientLogin?service=reader&Email={0}&Passwd={1}",
                _username, _password);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(requestUrl);
            req.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)req.GetResponse();
            using (var stream = response.GetResponseStream())
            {
                StreamReader r = new StreamReader(stream);
                string resp = r.ReadToEnd();

                int indexSid = resp.IndexOf("SID=") + 4;
                int indexLsid = resp.IndexOf("LSID=");
                _sid = resp.Substring(indexSid, indexLsid - 5);
            }
        }
    }
}

namespace System.Net
{
    public static class HttpWebRequestExtensions
    {
        private const int DefaultRequestTimeout = 5000;

        public static HttpWebResponse GetResponse(this HttpWebRequest request)
        {
            var dataReady = new AutoResetEvent(false);
            HttpWebResponse response = null;
            var callback = new AsyncCallback(delegate(IAsyncResult asynchronousResult)
            {
                response = (HttpWebResponse)request.EndGetResponse(asynchronousResult);
                dataReady.Set();
            });

            request.BeginGetResponse(callback, request);

            if (dataReady.WaitOne(DefaultRequestTimeout))
            {
                return response;
            }

            return null;
        }

        public static Stream GetRequestStream(this HttpWebRequest request)
        {
            var dataReady = new AutoResetEvent(false);
            Stream stream = null;
            var callback = new AsyncCallback(delegate(IAsyncResult asynchronousResult)
            {
                stream = (Stream)request.EndGetRequestStream(asynchronousResult);
                dataReady.Set();
            });

            request.BeginGetRequestStream(callback, request);
            if (!dataReady.WaitOne(DefaultRequestTimeout))
            {
                return null;
            }

            return stream;
        }
    }
}