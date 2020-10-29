using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTagLibrary.Models
{
    public class ModelValidator
    {
        LookupResponseModel modelToValidate;

        public ModelValidator(LookupResponseModel model)
        {
            this.modelToValidate = model;
        }

        public List<LookupResultModel> TryGetValidLookupResults(out bool isValidResults)
        {
            List<LookupResultModel> output = new List<LookupResultModel>();
            isValidResults = false;

            if (modelToValidate.Results.Count > 0)
            {
                output = modelToValidate.Results.Where(x => x.Recordings != null).ToList();
                if (output.Count > 0)
                {
                    isValidResults = true;
                }
            }

            return output;
        }
        public List<RecordingModel> TryGetValidRecordings(List<RecordingModel> recordings, out bool isValidRecordings)
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

        public List<ReleaseModel> TryGetValidReleases(List<ReleaseModel> releases, out bool isValidRelases)
        {
            List<ReleaseModel> output = new List<ReleaseModel>();
            isValidRelases = false;

            if(releases.Count>0)
            {
                output = releases.Where(x => x.Date.Year != null).ToList();
                if(output.Count>0)
                {
                    isValidRelases = true;
                }
            }

            return output;
        }
        public List<ReleaseGroupModel> GetReleaseGroupsBySpecificArtists(List<ReleaseGroupModel> releaseGroups,List<ArtistModel> artists)
        {
            List<ReleaseGroupModel> output = new List<ReleaseGroupModel>();

            output = releaseGroups.Where(x => x.Artists.SequenceEqual(artists)).ToList();

            return output;
        }

    }
}
