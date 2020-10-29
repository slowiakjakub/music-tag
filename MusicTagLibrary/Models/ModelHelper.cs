using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTagLibrary.Models
{
    public static class ModelHelper
    {
        /// <summary>
        /// Creates a name for the output file
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A name for a file containing basic information about the song</returns>
        public static string CreateBasicFileName(this LookupResponseModel model)
        {

            string output = "";

            ModelValidator modelValidator = new ModelValidator(model);

            bool isValidResults = false;
            List<LookupResultModel> results = modelValidator.TryGetValidLookupResults(out isValidResults);

            if (isValidResults)
            {
                foreach (LookupResultModel result in results)
                {
                    bool isValidRecordings = false;
                    List<RecordingModel> recordings = modelValidator.TryGetValidRecordings(result.Recordings, out isValidRecordings);
                    if (isValidRecordings)
                    {
                        output = $"{recordings.First().Artists.First().Name} - {recordings.First().Title}";
                        return output;
                    }
                }
            }
            throw new ArgumentNullException();
        }
    }
}