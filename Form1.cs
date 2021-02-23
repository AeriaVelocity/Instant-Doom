using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Instant_Doom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            GetPathFromIni();
            //MessageBox.Show(GlobalVars.ExecutablePath);
        }

        public static class GlobalVars
        {
            public static string ExecutablePath = ""; 
        }

        public static void GetPathFromIni()
        {
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
                GlobalVars.ExecutablePath = IniFileR.ReadLine();
            }
            catch
            {
                GlobalVars.ExecutablePath = ".\\chocolate-doom.exe";
            }
            finally
            {
                IniFileR.Close();
            }
        }

        public static void LaunchDoom(int game)
        {
            if (game == 1)
            {
                if (File.Exists(".\\wads\\DOOM.WAD"))
                {
                    try
                    {
                        Process.Start(GlobalVars.ExecutablePath, "-iwad .\\wads\\DOOM.WAD " + CmdLineOpt.CmdLine.Options);
                    }
                    catch (Win32Exception)
                    {
                        MessageBox.Show("The source port executable was not found.\nMake sure the path is configured correctly.", "There's a teabag in my coffee!");
                    }
                }
                else if (File.Exists(".\\wads\\DOOM1.WAD"))
                {
                    try
                    {
                        Process.Start(GlobalVars.ExecutablePath, "-iwad .\\wads\\DOOM1.WAD " + CmdLineOpt.CmdLine.Options);
                    }
                    catch (Win32Exception)
                    {
                        MessageBox.Show("The source port executable was not found.\nMake sure the path is configured correctly.", "There's a teabag in my coffee!");
                    }
                }
                else
                {
                    MessageBox.Show("The IWAD file for DOOM 1 was not found.\nPlease add your DOOM.WAD (DOOM1.WAD for shareware) file into the 'wads' folder.\nIf you don't own DOOM, you can download a copy of the shareware.", "There's a teabag in my coffee!");
                }
            }
            if (game == 2)
            {
                if (File.Exists(".\\wads\\DOOM2.WAD"))
                {
                    try
                    {
                        Process.Start(GlobalVars.ExecutablePath, "-iwad .\\wads\\DOOM2.WAD " + CmdLineOpt.CmdLine.Options);
                    }
                    catch (Win32Exception)
                    {
                        MessageBox.Show("The source port executable was not found.\nMake sure the path is configured correctly.", "There's a teabag in my coffee!");
                    }
                }
                else
                {
                    MessageBox.Show("The IWAD file for DOOM 2 was not found.\nPlease add your DOOM2.WAD file into the 'wads' folder.", "There's a teabag in my coffee!");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            LaunchDoom(1);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            LaunchDoom(2);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D1)
            {
                LaunchDoom(1);
            }
            if (e.KeyCode == Keys.D2)
            {
                LaunchDoom(2);
            }
            if (e.KeyCode == Keys.S)
            {
                try
                {
                    string HalfOfSetup = GlobalVars.ExecutablePath.Remove(GlobalVars.ExecutablePath.Length - 4);
                    Process.Start(HalfOfSetup + "-setup.exe");
                }
                catch (Win32Exception)
                {
                    MessageBox.Show("This button only works for Chocolate or Crispy Doom.\nLaunch Doom normally and configure the settings within the source port.\nIf you are using Chocolate or Crispy Doom, make sure the setup program is in the same place as the main program.", "There's a teabag in my coffee!");
                }
            }
            if (e.KeyCode == Keys.C)
            {
                SPSelect SPS = new SPSelect();
                SPS.Show();
            }
            if (e.KeyCode == Keys.E)
            {
                CmdLineOpt clo = new CmdLineOpt();
                clo.Show();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string HalfOfSetup = GlobalVars.ExecutablePath.Remove(GlobalVars.ExecutablePath.Length - 4);
                Process.Start(HalfOfSetup + "-setup.exe");
            }
            catch (Win32Exception)
            {
                MessageBox.Show("This button only works for Chocolate or Crispy Doom.\nLaunch Doom normally and configure the settings within the source port.\nIf you are using Chocolate or Crispy Doom, make sure the setup program is in the same place as the main program.", "There's a teabag in my coffee!");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            SPSelect SPS = new SPSelect();
            SPS.Show();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            GetPathFromIni();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            CmdLineOpt clo = new CmdLineOpt();
            clo.Show();
        }
    }
}
