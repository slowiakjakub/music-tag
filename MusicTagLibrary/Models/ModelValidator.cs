using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTagLibrary.Models
{
    public static class ModelValidator
    {
        public static List<LookupResultModel> TryGetValidLookupResults(List<LookupResultModel> results, out bool isValidResults)
        {
            List<LookupResultModel> output = new List<LookupResultModel>();
            isValidResults = false;

            if (results.Count > 0)
            {
                output = results.Where(x => x.Recordings != null).ToList();
                if (output.Count > 0)
                {
                    isValidResults = true;
                }
            }

            return output;
        }
        public static List<RecordingModel> TryGetValidRecordings(List<RecordingModel> recordings, out bool isValidRecordings)
        {
            List<RecordingModel> output = new List<RecordingModel>();
            isValidRecordings = false;

            if (recordings.Count > 0)
            {
                output = recordings.Where((x => (x.Artists != null) && (x.Title != null))).ToList();
                if(output.Count>0)
                {
                    isValidRecordings = true;
                }
            }

            return output;
        }
        public static List<ReleaseGroupModel> GetReleaseGroupsBySpecificArtists(List<ReleaseGroupModel> releaseGroups,List<ArtistModel> artists)
        {
            List<ReleaseGroupModel> artistReleaseGroups = new List<ReleaseGroupModel>();

            foreach (ReleaseGroupModel releaseGroup in releaseGroups)
            {
                if (releaseGroup.Artists.SequenceEqual(artists))
                {
                    artistReleaseGroups.Add(releaseGroup); // TODO - add some kind of sorting before comparing two lists
                }
            }

            return artistReleaseGroups;

        }
    }
}
