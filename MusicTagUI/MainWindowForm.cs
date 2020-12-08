﻿using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using MusicTagLibrary;
using MusicTagLibrary.DataAccess;
using MusicTagLibrary.Models;
using MusicTagLibrary.AudioProcessing;
using System.Net.Http;
using System.IO;

namespace MusicTagUI
{
    public partial class MainWindowForm : Form
    {
        string filePath;

        public MainWindowForm()
        {
            InitializeComponent();
            APIHelper.InitializeClient();
        }

        OpenFileDialog ofd = new OpenFileDialog();
        private void loadFileButton_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Audio file|*.mp3;*.wav";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
            }
        }

        private async void runMusictagButton_Click(object sender, EventArgs e)
        {

            LookupResponseModel lookupResponse;
            try
            {
                NAudioDecoder decodedFile = new NAudioDecoder(filePath);
                if (decodedFile.Length >= FingerprintProcessor.MinimumLengthForGeneratingFingerprint)
                {
                    string fingerprint = FingerprintProcessor.GetFingerprintFromFile(decodedFile);
                    lookupResponse = await AudioAPIDataProcessor.LoadLookupData(fingerprint, decodedFile.Length);
                }
                else
                {
                    MessageBox.Show($"Your audio file is too short!{Environment.NewLine}" +
                        $"It should be 30 seconds minimum!");
                    return;
                }
            }
            catch (Exception ex) when ((ex is InvalidOperationException) || (ex is InvalidDataException))
            {
                MessageBox.Show("There was a problem processing your file." + Environment.NewLine + "Error Info: " + ex.Message);
                return;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Connection to AcousticID API failed: " + Environment.NewLine + ex.Message);
                return;
            }

            if (lookupResponse.Results.Count > 0) // In case we got results from the lookup
            {
                FileTagger fileTagger = new FileTagger(filePath, lookupResponse);

                fileTagger.TagFile();

                FileProcessor.RenameFile(ref filePath, lookupResponse.CreateBasicFileName());
            }
            else
            {
                MessageBox.Show("Cannot recognize a song.");
            }
        }
    }
}
