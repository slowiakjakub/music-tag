using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTagLibrary.Exceptions
{
    [Serializable]
    public class AudioTooShortException : Exception
    {
        public AudioTooShortException() { }

        public AudioTooShortException(string message)
            : base(message) { }

        public AudioTooShortException(string message, Exception inner)
            : base(message, inner) { }
    }
}
