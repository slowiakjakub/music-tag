using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTagLibrary.Exceptions
{
    [Serializable]
    public class ResultsArrayEmptyException : Exception
    {
        public ResultsArrayEmptyException() { }

        public ResultsArrayEmptyException(string message)
            : base(message) { }

        public ResultsArrayEmptyException(string message, Exception inner)
            : base(message, inner) { }
    }
}
