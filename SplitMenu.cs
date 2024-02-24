using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using Cleaver.Classes;

namespace Cleaver
{
    internal partial class SplitMenu : Form
    {
        AppInstance instance;
        byte[]? readFile;

        public SplitMenu(AppInstance inInstance)
        {
            instance = inInstance;
            InitializeComponent();

            chunkSizeCounter.Maximum = 99999999;
            chunkSizeCounter.Minimum = 1;

            numChunksCounter.Minimum = 2;
            numChunksCounter.Maximum = 99999999;


        }


        private void openTargetFileButton_Click(object sender, EventArgs e)
        {
            TargetFileDialogue.ShowDialog(this);
        }

        private void TargetFileDialogue_FileOk(object sender, CancelEventArgs e)
        {
            targetFileFilepath.Text = TargetFileDialogue.FileName;
            readFile = File.ReadAllBytes(TargetFileDialogue.FileName);

            chunkSizeCounter.Value = Math.Ceiling(readFile.Length / numChunksCounter.Value);
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance.SwitchMenu("select");
        }

        private void splitButton_Click_1(object sender, EventArgs e)
        {
            Enabled = false;

            if (readFile != null)
            {
                byte[] key = instance.splitter.GetHash(Encoding.UTF8.GetBytes(passwordBox.Text));
                byte[] iv = new byte[16];

                bool success = instance.SplitFile(TargetFileDialogue.FileName, (int)Math.Ceiling(readFile!.Length / (numChunksCounter.Value - 1)), key, iv);
                if (success)
                {
                    Debug.WriteLine("Sucessfully Split File");
                    // Update UI Here
                }
            }

            Enabled = true;
        }


        public void UpdateMessage(string inMessage, Color textColor)
        {
            statusText.ForeColor = textColor;
            statusText.Text = inMessage;
            statusText.Visible = true;
        }

        private void chunkSizeCounter_ValueChanged(object sender, EventArgs e)
        {
            if (readFile != null)
            {
                numChunksCounter.Value = (int)Math.Ceiling(readFile.Length / chunkSizeCounter.Value) + 1;
            }
        }

        private void numChunksCounter_ValueChanged(object sender, EventArgs e)
        {
            if (readFile != null)
            {
                chunkSizeCounter.Value = Math.Ceiling(readFile.Length / (numChunksCounter.Value - 1));
            }
        }

        private void SplitMenu_FormClosing(object sender, FormClosingEventArgs e)
        {

            instance.SwitchMenu("select");
        }
    }
}
