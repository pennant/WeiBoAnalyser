using System;
using System.IO;
using System.Net;

namespace WeiBoAnalyser.Common
{
    public class HttpRequestWorker
    {
        public static void Get(string url, Action<string> callback)
        {
            if (String.IsNullOrEmpty(url)) throw new ArgumentNullException("url");
            if (callback == null) throw new ArgumentNullException("callback");

            HttpWebRequest request = HttpWebRequest.CreateHttp(url);
            request.Method = "GET";
            request.BeginGetResponse((result) =>
                {
                    HttpWebRequest returnRequest = result.AsyncState as HttpWebRequest;
                    if (returnRequest != null)
                    {
                        WebResponse response = returnRequest.EndGetResponse(result);
                        long length = response.ContentLength;
                        using (Stream stream = response.GetResponseStream())
                        {
                            byte[] data = new byte[length];
                            stream.Read(data, 0, data.Length);
                            string content = System.Text.Encoding.UTF8.GetString(data, 0, data.Length);
                            callback(content);
                        }
                    }
                }, request);
        }
    }
}
