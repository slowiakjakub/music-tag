using MusicTagLibrary.AudioProcessing;
using MusicTagLibrary.DataAccess;
using MusicTagLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTagLibrary
{
    public static class MusicRecognizer
    {
        public static async void RunMusicTagForAudioFile(string filePath)
        {
            LookupResponseModel lookupResponse;

            NAudioDecoder decodedFile = new NAudioDecoder(filePath);
            if (decodedFile.Length >= FingerprintProcessor.MinimumLengthForGeneratingFingerprint)
            {
                string fingerprint = FingerprintProcessor.GetFingerprintFromFile(decodedFile);
                lookupResponse = await AudioAPIDataProcessor.LoadLookupData(fingerprint, decodedFile.Length);
            }
            else
            {
                throw new ArgumentException("Audio file's duration is too small.");
            }

            if (lookupResponse.Results.Count > 0) // In case we got results from the lookup
            {
                FileTagger fileTagger = new FileTagger(filePath, lookupResponse);

                fileTagger.TagFile();

                FileProcessor.RenameFile(ref filePath, lookupResponse.CreateBasicFileName());
            }
            else
            {
                //throw new
            }
        }
    }
}
