using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicTagLibrary.Models;

namespace MusicTagLibrary.DataAccess
{
    public class FileTagger
    {
        public string filePath;
        public LookupResponseModel lookupResponse;

        public FileTagger(string filePath,LookupResponseModel lookupResponse)
        {
            this.filePath = filePath;
            this.lookupResponse = lookupResponse;
        }

        public void TagFile()
        {
            var tfile = TagLib.File.Create(filePath);

            ModelValidator modelValidator = new ModelValidator(lookupResponse);

            bool isValidResults = false;
            List<LookupResultModel> validResults = modelValidator.TryGetValidLookupResults(out isValidResults);

            if (isValidResults)
            {
                bool isValidRecordings = false;
                List<RecordingModel> validRecordings = modelValidator.TryGetValidRecordings(validResults.First().Recordings, out isValidRecordings);
                if (isValidRecordings)
                {
                    RecordingModel firstValidRecording = validRecordings.First();

                    tfile.Tag.Performers = firstValidRecording.GetAllArtistsNames();
                    tfile.Tag.Title = firstValidRecording.Title;

                    List<ReleaseGroupModel> foundSongReleaseGroups = modelValidator.GetReleaseGroupsBySpecificArtists(firstValidRecording.ReleaseGroups, firstValidRecording.Artists);

                    if (foundSongReleaseGroups.Count > 0)
                    {
                        ReleaseGroupModel foundSongFirstReleaseGroup = foundSongReleaseGroups.First();

                        if (foundSongFirstReleaseGroup.Type.Equals("Album"))
                        {
                            if (foundSongFirstReleaseGroup.Title != null)
                            {
                                tfile.Tag.Album = foundSongFirstReleaseGroup.Title;
                            }
                        }
                        bool isValidReleases = false;
                        List<ReleaseModel> validReleases = modelValidator.TryGetValidReleases(foundSongFirstReleaseGroup.Releases, out isValidReleases);

                        if (isValidReleases)
                        {
                            ReleaseModel firstValidRelease = validReleases.First();
                            tfile.Tag.Year = uint.Parse(firstValidRelease.Date.Year);
                        }
                    }
                    tfile.Save();
                }
            }
        }
    }
}
