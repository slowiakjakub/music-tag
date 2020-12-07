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
        public static string GetFingerprintFromFile(string file)
        {
            AudioBuffer bfr = new AudioBuffer();
            NAudioDecoder decoder = new NAudioDecoder(file);
            decoder.Decode(bfr, decoder.Length);

            //At this point mp3 file is decoded into bfr.data[] 

            ChromaContext ctx = new ChromaContext();

            ctx.Start(decoder.SampleRate, decoder.Channels);
            ctx.Feed(bfr.data, bfr.data.Length);
            ctx.Finish();

            string fp = ctx.GetFingerprint();

            return fp;
        }
    }
}
