using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTagLibrary.Models
{
    public class ReleaseGroupModel
    {
        public List<SecondaryType> secondaryTypes { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
    }
}
