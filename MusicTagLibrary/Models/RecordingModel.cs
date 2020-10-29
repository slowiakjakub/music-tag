using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTagLibrary.Models
{
    public class RecordingModel
    {
        public List<ArtistModel> Artists { get; set; }
        public List<ReleaseGroupModel> ReleaseGroups { get; set; }
        public string Title { get; set; }

        public string[] GetAllArtistsNames()
        {
            string[] artists = new string[Artists.Count];

            for (int i = 0; i < Artists.Count; i++)
            {
                artists[i] = Artists[i].Name;
            }
            return artists;
        }
    }
}
