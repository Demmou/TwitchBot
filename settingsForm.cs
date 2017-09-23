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

namespace TwitchBot
{
    public partial class settingsForm : Form
    {
        IniFile settingsIni = new IniFile(@"Data\settings.ini");
        public settingsForm()
        {
            InitializeComponent();
            readDataPopulateTextBoxes();
        }
        private void readDataPopulateTextBoxes()
        {
            try
            {
                authTokenTextBox.Text = settingsIni.iniReadValue("settings","authtoken");
                botNameTextBox.Text = settingsIni.iniReadValue("settings", "botname");
                clientIdTextBox.Text = settingsIni.iniReadValue("settings", "clientId");
                channelNameTextBox.Text = settingsIni.iniReadValue("settings", "channel");
                currencyNameBox.Text = settingsIni.iniReadValue("settings", "currencyName");
                bingoStateLabel.Text = settingsIni.iniReadValue("settings", "bingostate");
                gambleStateLabel.Text = settingsIni.iniReadValue("settings", "gamblestate");
                verdoppelnStateLabel.Text = settingsIni.iniReadValue("settings", "verdoppelnstate");
                smashStateLabel.Text = settingsIni.iniReadValue("settings", "smashstate");
            }
            catch (Exception e)
            {

            }
        }
        private void settingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        private void settingsForm_Load(object sender, EventArgs e)
        {
            
        }
        private void botNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void setBotName_Click(object sender, EventArgs e)
        {
            settingsIni.iniWriteValue("settings", "botname", botNameTextBox.Text);
        }
        public class csvFile
        {
            private string csvPath;
            public csvFile(string path)
            {

                csvPath = path;
            }
            public void setPath(string path)
            {
                this.csvPath = path;
            }
            public void writeLine(string id, string message)
            {
                StringBuilder csvContent = new StringBuilder();
                csvContent.AppendLine(id + "=" + message + ";");
                File.AppendAllText(this.csvPath, csvContent.ToString());
            }
            public List<string> getData()
            {
                List<string> line = new List<string>();
                foreach (var lines in File.ReadLines(csvPath))
                {
                    line.Add(lines);
                }
                return line;
            }
        }
        #region buttons
        private void authTokenSetButton_Click(object sender, EventArgs e)
        {
            settingsIni.iniWriteValue("settings", "authtoken", authTokenTextBox.Text);
        }
        private void setClientIdButton_Click(object sender, EventArgs e)
        {
            settingsIni.iniWriteValue("settings", "clientId", clientIdTextBox.Text);
        }
        private void channelSetButton_Click(object sender, EventArgs e)
        {
            settingsIni.iniWriteValue("settings", "channel", channelNameTextBox.Text);
        }
        private void setCurrencyNameButton_Click(object sender, EventArgs e)
        {
            settingsIni.iniWriteValue("settings", "currencyName", currencyNameBox.Text);
        }
        private void bingoOnButton_Click(object sender, EventArgs e)
        {
            settingsIni.iniWriteValue("settings", "bingostate", "true");
            bingoStateLabel.Text = "true";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            settingsIni.iniWriteValue("settings", "bingostate", "false");
            bingoStateLabel.Text = "false";
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void smashOnButton_Click(object sender, EventArgs e)
        {
            settingsIni.iniWriteValue("settings", "smashstate", "true");
            smashStateLabel.Text = "true";
        }
        private void smashOffButton_Click(object sender, EventArgs e)
        {
            settingsIni.iniWriteValue("settings", "smashstate", "false");
            smashStateLabel.Text = "false";
        }
        private void verdoppelnOnButton_Click(object sender, EventArgs e)
        {
            settingsIni.iniWriteValue("settings", "verdoppelnstate", "true");
            verdoppelnStateLabel.Text = "true";
        }
        private void verdoppelnOffButton_Click(object sender, EventArgs e)
        {
            settingsIni.iniWriteValue("settings", "verdoppelnstate", "false");
            verdoppelnStateLabel.Text = "false";
        }
        private void gambleOnButton_Click(object sender, EventArgs e)
        {
            settingsIni.iniWriteValue("settings", "gamblestate", "true");
            gambleStateLabel.Text = "true";
        }
        private void gambleOffButton_Click(object sender, EventArgs e)
        {
            settingsIni.iniWriteValue("settings", "gamblestate", "false");
            gambleStateLabel.Text = "false";
        }
        #endregion

        private void verdoppelnStateLabel_Click(object sender, EventArgs e)
        {

        }

        private void fiveMinuteMessageOnButton_Click(object sender, EventArgs e)
        {
            settingsIni.iniWriteValue("settings", "demmoumode", "true");
            demmouModeLabel.Text = "true";
        }

        private void fiveMinuteMessageButtonOff_Click(object sender, EventArgs e)
        {
            settingsIni.iniWriteValue("settings", "demmoumode", "false");
            demmouModeLabel.Text = "false";
        }

        private void demmouModeLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
