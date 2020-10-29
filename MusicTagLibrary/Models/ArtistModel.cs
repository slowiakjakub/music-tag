using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTagLibrary.Models
{
    public class ArtistModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var o = obj as ArtistModel;

            return Id.Equals(o.Id);
        }

        // override object.GetHashCode
        // Test Method
        public override int GetHashCode()
        {
            int hash = 0;

            for (int i = 0; i < Id.Length; i++)
            {
                hash += 7*Id[i];
            }
            return hash;
        }
    }
}
