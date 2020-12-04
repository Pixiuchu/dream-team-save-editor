using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Save_Editor_1
{
    public partial class Stats_Information_Box : Form
    {
        public Stats_Information_Box()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.mariowiki.com/Mario_%26_Luigi:_Dream_Team_level_up_progressions");
        }

        private void Stats_Information_Box_Load(object sender, EventArgs e)
        {

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        System.Diagnostics.Process.Start("https://www.mariowiki.com/Rank#Mario_.26_Luigi:_Dream_Team");
        }
    }
}
