using System;
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
            string fp = FingerprintProcessor.GetFingerprintFromFile(filePath);

            int length = new NAudioDecoder(filePath).Length; // TODO - Make code better by using dependecy injection

            try
            {
                var lookupResponse = await AudioAPIDataProcessor.LoadLookupData(fp, length);

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
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Connection to AcousticID API failed: " + Environment.NewLine + ex.Message);
            }
        }
    }
}
