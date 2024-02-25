using Cleaver.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cleaver
{
    internal partial class RebuildMenu : Form
    {
        AppInstance instance;
        List<string> parts = new List<string>();

        public RebuildMenu(AppInstance inInstance)
        {
            instance = inInstance;
            InitializeComponent();
        }

        private void addPart_Click(object sender, EventArgs e)
        {
            partLoader.ShowDialog();
        }

        private void partLoader_FileOk(object sender, CancelEventArgs e)
        {
            filesList.Items.Add(partLoader.FileName);
            parts.Add(partLoader.FileName);
            filesList.Refresh();
        }

        private void reconstructButton_Click(object sender, EventArgs e)
        {
            List<string> paths = new List<string>();
            foreach (string path in filesList.Items)
            {
                paths.Add(path);
            }
            instance.ReconstructFile(paths, passwordBox.Text);
        }

        private void RebuildMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance.SwitchMenu("select");
        }

        internal void UpdateDisplayMessage(string inMessage, Color inColor)
        {
            messageText.Text = inMessage;
            messageText.ForeColor = inColor;
            messageText.Visible = true;
        }
    }
}
