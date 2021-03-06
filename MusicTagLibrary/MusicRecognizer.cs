﻿using MusicTagLibrary.AudioProcessing;
using MusicTagLibrary.DataAccess;
using MusicTagLibrary.Models;
using MusicTagLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTagLibrary
{
    public class MusicRecognizer
    {
        public static async Task RunMusicTagForAudioFileAsync(string filePath) // TODO - make task fully asynchronous
        {
            LookupResponseModel lookupResponse;

            NAudioDecoder decodedFile = new NAudioDecoder(filePath);
            if (decodedFile.Length >= FingerprintProcessor.MinimumLengthForGeneratingFingerprint)
            {
                string fingerprint = await (Task.Run(() => FingerprintProcessor.GetFingerprintFromFile(decodedFile)));
                lookupResponse = await AudioAPIDataProcessor.LoadLookupData(fingerprint, decodedFile.Length);
            }
            else
            {
                throw new AudioTooShortException("Audio file's duration is too small.");
            }

            if (lookupResponse.Results.Count > 0) // In case we got results from the lookup
            {
                FileTagger fileTagger = new FileTagger(filePath, lookupResponse);

                fileTagger.TagFile();

                FileProcessor.RenameFile(ref filePath, lookupResponse.CreateBasicFileName());
            }
            else
            {
                throw new ResultsArrayEmptyException("There is no matching song in a database.");
            }
        }
    }
}
