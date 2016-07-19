using System;
using System.Net;
using System.IO;
using System.Web;
using System.Media;
using Yam.Microsoft.Translator;

namespace ConsoleApplicationPlayWav
{
    class Program
    {
        static void Main()
        {
            //Get Client Id and Client Secret from https://datamarket.azure.com/developer/applications/
            //Refer obtaining AccessToken (http://msdn.microsoft.com/en-us/library/hh454950.aspx)
            var admAuth = new AdmAuthentication("hse012944", "85mAFSflv5sQFatif5YiODi2N6VdHyg/V1FCBKISuNg=");
            try
            {
                var admToken = admAuth.GetAccessToken();
                // Create a header with the access_token property of the returned token
                var headerValue = "Bearer " + admToken.access_token;
                SpeakMethod(headerValue);
            }
            catch (WebException e)
            {
                ProcessWebException(e);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
            }
        }

        private static void SpeakMethod(string authToken)
        {
            var uri = "http://api.microsofttranslator.com/v2/Http.svc/Speak?text=welcome&language=en&format=" + HttpUtility.UrlEncode("audio/wav") + "&options=MaxQuality";

            var webRequest = WebRequest.Create(uri);
            webRequest.Headers.Add("Authorization", authToken);
            WebResponse response = null;
            try
            {
                response = webRequest.GetResponse();
                using (var stream = response.GetResponseStream())
                {
                    using (var player = new SoundPlayer(stream))
                    {
                        player.PlaySync();
                    }
                }
            }
            finally
            {
                response?.Close();
            }
        }
        private static void ProcessWebException(WebException e)
        {
            Console.WriteLine("{0}", e);
            // Obtain detailed error information
            var strResponse = string.Empty;
            using (var response = (HttpWebResponse)e.Response)
            {
                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                        using (var sr = new StreamReader(responseStream, System.Text.Encoding.ASCII))
                        {
                            strResponse = sr.ReadToEnd();
                        }
                }
            }
            Console.WriteLine("Http status code={0}, error message={1}", e.Status, strResponse);
        }
    }
}
