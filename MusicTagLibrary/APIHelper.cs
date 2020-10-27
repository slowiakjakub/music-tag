using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MusicTagLibrary
{
    public class APIHelper
    {
        public static HttpClient ApiClient { get; set; }
        public static void InitializeClient()
        {
            APIHelper.SetApplicationClientKey();

            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static void SetApplicationClientKey()
        {
            AcoustID.Configuration.ClientKey = "pYEBEoFX0R";
        }
    }
}
