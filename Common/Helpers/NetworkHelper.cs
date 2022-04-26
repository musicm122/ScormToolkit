using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HackerFerretCommon.Helpers
{
    public static class NetworkHelper
    {
        public static bool IsConnectedToInternet()
        {
            //todo:implement 
            return IsEndpointAvailable("http://www.google.com");
        }

        public static bool IsEndpointAvailable(String URL)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Timeout = 5000;
                request.Credentials = CredentialCache.DefaultNetworkCredentials;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                return (response.StatusCode == HttpStatusCode.OK);

            }
            catch
            {
                return false;
            }
        }
    }
}
