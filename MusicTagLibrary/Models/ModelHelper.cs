﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTagLibrary.Models
{
    public static class ModelHelper
    {
        public static string CreateBasicFileName(this LookupResponseModel model)
        {
            string output = "";

            if(model.Results!=null)
            {
                List<LookupResultModel> results = model.Results.Where(x => x.Recordings != null).ToList();
                if (results!=null)
                {
                    foreach (LookupResultModel result in results)
                    {
                        List<RecordingModel> recordings = result.Recordings.Where((x => (x.Artists != null)&&(x.Title!=null))).ToList();
                        if (recordings!=null)
                        {
                            output = $"{recordings.First().Artists.First().Name} - {recordings.First().Title}";
                            return output;
                        }
                    }
                }
            }
            throw new ArgumentNullException();
        }
    }
}
