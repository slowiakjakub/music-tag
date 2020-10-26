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
        string file = @"C:\Users\dwaba\Desktop\Programowanie\skarbek.mp3";

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
                file = ofd.FileName;
            }
        }

        private async void runMusictagButton_Click(object sender, EventArgs e)
        {
            string fp = FingerprintProcessor.GetFingerprintFromFile(file);

            int length = new NAudioDecoder(file).Length; // Gets Length of an audio file
            // TODO - Make code better by using dependecy injection
      
            var lookupResponse = await AudioAPIDataProcessor.LoadLookupData(fp, length);

            FileProcessor.RenameFile(file, lookupResponse.CreateBasicFileName());
        }
    }
}
