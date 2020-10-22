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

namespace MusicTagUI
{
    public partial class MainWindowForm : Form
    {
        string file = @"C:\Users\dwaba\Desktop\Programowanie\test.mp3";

        public MainWindowForm()
        {
            InitializeComponent();
        }

        OpenFileDialog ofd = new OpenFileDialog();

        private void loadFileButton_Click(object sender, EventArgs e)
        {
            ofd.Filter = "MP3|*.mp3";
            if (ofd.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
