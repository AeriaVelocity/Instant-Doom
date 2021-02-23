using System;
using System.IO;
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
    public partial class SPSelect : Form
    {
        public SPSelect()
        {
            InitializeComponent();
            KeyPreview = true;
            try
            {
                StreamReader IniFile = new StreamReader(".\\SourcePort.ini");
                IniFile.Close();
            }
            catch
            {
                StreamWriter IniFileW = new StreamWriter(".\\SourcePort.ini");
                IniFileW.WriteLine(".\\chocolate-doom.exe");
                IniFileW.Close();
            }
            StreamReader IniFileR = new StreamReader(".\\SourcePort.ini");
            try
            {
                SourceBox.Text = IniFileR.ReadLine();
            }
            catch
            {
                SourceBox.Text = ".\\chocolate-doom.exe";
            }
            finally
            {
                IniFileR.Close();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            StreamWriter IniFile = new StreamWriter(".\\SourcePort.ini");
            try
            {
                IniFile.WriteLine(SourceBox.Text);
            }
            catch
            {
                IniFile.WriteLine(".\\chocolate-doom.exe");
            }
            finally
            {
                IniFile.Close();
                Close();
            }
        }

        private void SPSelect_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
