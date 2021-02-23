using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Instant_Doom
{
    public partial class CmdLineOpt : Form
    {
        public CmdLineOpt()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        public static class CmdLine
        {
            public static string Options = "";
        }

        private void CmdLineOpt_Load(object sender, EventArgs e)
        {
            CmdBox.Text = CmdLine.Options;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CmdLine.Options = CmdBox.Text;
            Close();
        }
    }
}
