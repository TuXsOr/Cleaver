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
    internal partial class SelectMenu : Form
    {
        AppInstance instance;


        public SelectMenu(AppInstance inInstance)
        {
            instance = inInstance;
            InitializeComponent();
        }

        private void splitButton_Click(object sender, EventArgs e)
        {
            instance.SwitchMenu("split");
        }
    }
}
