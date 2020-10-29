using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicTagLibrary.Models;

namespace MusicTagLibrary.DataAccess
{
    public static class FileTagger
    {
        public static void TagFile(string filePath, LookupResponseModel model)
        {
            var tfile = TagLib.File.Create(filePath);


            bool isValidResults = false;
            List<LookupResultModel> validResults = ModelValidator.TryGetValidLookupResults(model.Results, out isValidResults);

            if (isValidResults)
            {
                bool isValidRecordings = false;
                List<RecordingModel> validRecordings = ModelValidator.TryGetValidRecordings(validResults.First().Recordings, out isValidRecordings);
                if (isValidRecordings)
                {
                    RecordingModel firstValidRecording = validRecordings.First();

                    tfile.Tag.Performers = firstValidRecording.GetAllArtistsNames();
                    tfile.Tag.Title = firstValidRecording.Title;

                    //List<ReleaseGroupModel> foundSongReleaseGroups = ModelValidator.GetReleaseGroupsBySpecificArtists(firstValidRecording.ReleaseGroups, firstValidRecording.Artists);

                    //if (foundSongReleaseGroups.Count > 0)
                    //{
                    //    foundSongReleaseGroups.First();

                    //}

                    tfile.Save();
                }
            }
        }
    }
}
