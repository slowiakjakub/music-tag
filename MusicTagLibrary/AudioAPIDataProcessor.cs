using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicTagLibrary.Models;
using AcoustID;
using System.Net.Http;

namespace MusicTagLibrary
{
    public class AudioAPIDataProcessor
    {
        /// <summary>
        /// Sends a request to AcoustID API.
        /// </summary>
        /// <param name="fingerprint">Audio fingerprint data</param>
        /// <param name="duration">Duration of the whole audio file in seconds</param>
        /// <returns>Information about audio stored in data models</returns>
        public static async Task<LookupResponseModel> LoadLookupData(string fingerprint, int duration)
        {
            string url = $"https://api.acoustid.org/v2/lookup?client={ Configuration.ClientKey }&meta=recordings+releasegroups+compress&duration={ duration }&fingerprint={ fingerprint }";

            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(url))
            {
                if(response.IsSuccessStatusCode)
                {
                    LookupResponseModel lookupResponse = await response.Content.ReadAsAsync<LookupResponseModel>();

                    return lookupResponse;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
