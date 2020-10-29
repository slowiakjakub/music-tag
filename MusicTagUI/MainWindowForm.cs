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
            ofd.Filter = "MP3|*.mp3";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
            }
        }

        private async void runMusictagButton_Click(object sender, EventArgs e)
        {
            string fp = FingerprintProcessor.GetFingerprintFromFile(filePath);

            int length = new NAudioDecoder(filePath).Length; // Gets Length of an audio file
            // TODO - Make code better by using dependecy injection
      
            var lookupResponse = await AudioAPIDataProcessor.LoadLookupData(fp, length);

            FileTagger.TagFile(filePath,lookupResponse);
            FileProcessor.RenameFile(filePath, lookupResponse.CreateBasicFileName()); //TODO - filePath gets changed, think how to do it without problems
        }
    }
}
