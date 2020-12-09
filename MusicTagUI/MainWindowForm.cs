using System;
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
using MusicTagLibrary.Exceptions;
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
            try // catching exceptions don't work, because method is async
            {
                MusicRecognizer.RunMusicTagForAudioFile(filePath);
            }
            catch (AudioTooShortException)
            {
                MessageBox.Show($"Your audio file is too short!{Environment.NewLine}" +
                    $"It should be 30 seconds minimum!");
                return;
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
            //else
            //{
            //    MessageBox.Show("Cannot recognize a song.");
            //}
        }
    }
}
