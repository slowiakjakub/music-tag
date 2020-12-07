using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcoustID;
using MusicTagLibrary.AudioProcessing;

namespace MusicTagLibrary
{
    public class FingerprintProcessor
    {
        public static string GetFingerprintFromFile(NAudioDecoder decodedFile)
        {
            AudioBuffer bfr = new AudioBuffer();
            decodedFile.Decode(bfr, decodedFile.Length);

            //At this point mp3 file is decoded into bfr.data[] 

            ChromaContext ctx = new ChromaContext();

            ctx.Start(decodedFile.SampleRate, decodedFile.Channels);
            ctx.Feed(bfr.data, bfr.data.Length);
            ctx.Finish();

            string fp = ctx.GetFingerprint();

            return fp;
        }
    }
}
