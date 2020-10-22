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
        public string Title;
    }
}
