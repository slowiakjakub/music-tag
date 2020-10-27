using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTagLibrary.Models
{
    public class ReleaseModel
    {
        public List<ArtistModel> Artists { get; set; }
        public DateModel Date { get; set; }
    }
}
