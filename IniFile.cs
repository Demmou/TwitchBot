using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TwitchBot
{
    class IniFile
    {
        public string path;
        // FUCK YOU KERNEL!
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filepath);
        [DllImport("kernel32")]
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filepath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileSection(string lpAppName, byte[] lpszReturnBuffer, int nSize, string lpFileName);
        [DllImport("kernel32")]
        static extern int GetPrivateProfileSectionNames(byte[] lpszReturnBuffer, int nSize, string lpFileName);

        public IniFile(string iniPath)
        {
            path = iniPath;
        }
        // writing a section into a key in a specific section
        public void iniWriteValue(string sec, string key, string value)
        {
            WritePrivateProfileString(sec, key, value, this.path);
        }

        public string iniReadValue(string section, string key)
        {
            StringBuilder temp = new StringBuilder(10255);
            try
            {
                GetPrivateProfileString(section, key, "", temp, 10255, this.path);
            }
            catch
            {
                return "0";
            }

            return temp.ToString();
        }
        public ComboBox SectionNames()
        {
            ComboBox cboConfiguration = new ComboBox();
            byte[] buffer = new byte[1024];
            GetPrivateProfileSectionNames(buffer, buffer.Length, this.path);
            string allSections = System.Text.Encoding.Default.GetString(buffer);
            string[] sectionNames = allSections.Split('\0');
            foreach (string sectionName in sectionNames)
            {
                if (sectionName != string.Empty)
                    cboConfiguration.Items.Add(sectionName);
            }
            // Returns All names as Items in Combobox
            return cboConfiguration;
        }

        class tmpUserStrct
        {
            public string Name;
            public ulong Points;
            public ulong Time;
        }

        public static void parseToDb()
        {
            string content = File.ReadAllText(@"C:\Users\Demmou\Desktop\pointsHori.ini");
            /*
                [#horican.0llii]
                Points=174
                Time=379
                [#horican.fernseh321]
                Points=16
                Time=75
            */
            // (?<=\.)(.*)(?=\]) // username 
            // (?<=Points=)(.*) // points
            // (?<=Time=)(.*)
            Regex nameRegEx = new Regex(@"(?<=\.)(.*)(?=\])", RegexOptions.IgnoreCase);
            Match nameMatch = nameRegEx.Match(content);
            Regex pointsRegEx = new Regex(@"(?<=Points=)(.*)(?=\r)", RegexOptions.IgnoreCase);
            Match pointsMatch = pointsRegEx.Match(content);
            Regex timeRegEx = new Regex(@"(?<=Time=)(.*)(?=\r)", RegexOptions.IgnoreCase);
            Match timeMatch = timeRegEx.Match(content);
            List<tmpUserStrct> l = new List<tmpUserStrct>();
            IniFile horiIni = new IniFile(@"C:\Users\Demmou\Desktop\pointsHori.ini");
            while (nameMatch.Success)
            {
                
                tmpUserStrct u = new tmpUserStrct();
                u.Name = nameMatch.Groups[0].Value;
                nameMatch = nameMatch.NextMatch();
                l.Add(u);
            }
            int i = 0;
            while (pointsMatch.Success)
            {
                if (l.Count > i)
                    l[i].Points = Convert.ToUInt64(pointsMatch.Groups[0].Value);
                pointsMatch = pointsMatch.NextMatch();
                i++;
            }
            i = 0;
            for (int z = 0; z < l.Count; z++)
            {
                string str  = horiIni.iniReadValue("#horican." + l[z].Name, "time");
                UInt64 time = 0;
                if (str.Length > 0)
                    time = Convert.ToUInt64(str);

                l[z].Time = time;
            }

            foreach (var x in l)
                Database.InsertNewUser(x.Name, x.Points, 0, x.Time);
        }
    }
}
