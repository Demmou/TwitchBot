using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Media;
using System.Diagnostics;
using TwitchCSharp.Clients;
using TwitchCSharp.Models;
using TwitchLib;
using TwitchLib.Models.Client;
using TwitchLib.Events.Client;

namespace TwitchBot
{
    public partial class DemmouBot : Form
    {
        #region variables
        #region vertrauliche variablen NICHT ÖFFNEN IM STREAM
        private string twitchClientID;
        private string botPassWord;
        private string userName;
        private string channelName;
        private string currencyName;
        
        #endregion
        private static int messageCycleVariable = 0;
        private const string databasePath = @"Data\CurrencyDB.sqlite";
        TwitchReadOnlyClient APIClient;
        // Twitch read only chat
        TwitchROChat chatClient;
        // authetification token required to Password
        //twitchapps.com/tmi
        IrcClient irc; 
        NetworkStream serverStream = default(NetworkStream);
        string readData = "";
        Thread chatThread;
        List<string> bannedWords = new List<string> { "hurensohn ", "hitler ", "nazi ", "wap bap", "apored ", "apo red " };
        IniFile PointsIni = new IniFile(@"Data\Points.ini");
        csvFile commandCsv = new csvFile(@"Data\commands.csv");
        csvFile userGreetedCsv = new csvFile(@"Data\usergreeted.csv");
        IniFile settingsIni = new IniFile(@"Data\settings.ini");
        IniFile suggestIni = new IniFile(@"Data\suggetions.ini");
        int sugCounter = 0;
        List<string> usernamesOfViewer = new List<string>();
        List<string> currentModerators = new List<string>();
        private int timeOnline;
        private bool demmouMode = false;
        private int tippcounter;
        private bool subscribertrue;

        // bedarf
        List<string> beggers = new List<string>();
        bool lotteryBankBlocked = false;
        // Bingo command
        bool bingoDown = false;
        List<string> bingoNameList = new List<string>();
        bool onlySendOnce = false;
        int bingoPointsPot = 0;
        bool bingoMessageSaid = false;

        // Smash command
        bool smashGameStarted = false;
        bool sentMessage = false;
        List<string> smashers = new List<string>();
        List<int> smashMoney = new List<int>();
        List<int> smashWinLottery = new List<int>();
        List<string> smashWinners = new List<string>();
        List<int> smashWinnerMoney = new List<int>();
        DateTime starttime = new DateTime();

        // Spam command filter
        bool commandSpamFilter = false;
        bool commandModSayBool = false;
        List<CommandSpamUser> csu = new List<CommandSpamUser>();
        public static readonly DateTime Uptime = DateTime.Now;
        // Bombgame
        string bombCarrier = "";
        bool bombGameOngoing = false;
        List<string> viewerCurrent = new List<string>();

        // raffle
        List<string> raffleParticipants = new List<string>();
        bool raffleOngoing = false;
        int amountOfParticipants = 0;

        // additional variables
        bool viewerGamesListOpen = false;
        List<string> viewerGamesParticipants = new List<string>();

        // Shop Variables
        List<string> viewersBegruesst = new List<string>();

        // Münzwurf variablen
        List<string> muenzeKopf = new List<string>();
        List<string> muenzeZahl = new List<string>();
        bool muenzeOpen = false;
        bool muenzeCooldownBool = false;

        // RPG
        static Dictionary<string,RPGItem> itemDict = new Dictionary<string,RPGItem>();

        #endregion
        
        public DemmouBot()
        {
            timeOnline = 0;
            readDataPopulateTextBoxes();
            Database.Connect(databasePath);
            this.APIClient = new TwitchReadOnlyClient(twitchClientID);
            this.irc = new IrcClient("irc.chat.twitch.tv", 6667, this.userName, this.botPassWord, this.channelName);
            this.chatClient = new TwitchROChat(twitchClientID);
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            userGreetedCsv.deleteAllContentInCSVFile();
            subscribertrue = false;
        }
        private void DemmouBot_FormClosing(object sender, FormClosingEventArgs e)
        {
            Database.Disconnect();
            irc.leaveRoom();
            try { serverStream.Dispose(); } catch { }
            Environment.Exit(0);
        }
        private void getMessage()
        {
            serverStream = irc.tcpClient.GetStream();
            int buffsize = 0;
            byte[] inStream = new byte[10025];
            buffsize = irc.tcpClient.ReceiveBufferSize;


            while (true)
            {
                try
                {
                    readData = irc.readMessage();
                    msg();
                }
                catch (Exception e)
                {
                    //Exception handles PING request. Pong is being sent elsewhere
                    //Console.Beep();
                }
            }
        }
        private void msg()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(msg));
            }
            else
            {
                Chatters AllChatters = chatClient.GetChatters(this.channelName);
                string[] separator = new String[] { "#" + this.channelName + " :" };
                // testing sub once
                string[] whisperseparator = new String[] { userName + " :" };
                string[] seperateName = new String[] { ":", "!" };
                if (readData.Contains("PRIVMSG"))
                {
                    string username;
                    string message;
                    if (readData.Contains("/"))
                    {
                        // 1,subscriber
                        string subscriberyes = readData.Split('/')[1];
                        int subyes = int.Parse(subscriberyes[0].ToString());
                        if (subyes == 1)
                        {
                            subscribertrue = true;
                        }
                        else
                        {
                            subscribertrue = false;
                        }
                        username = readData.Split(seperateName, StringSplitOptions.None)[1];
                        message = readData.Split(separator, StringSplitOptions.None)[1];
                    }
                    else
                    {
                        string subscriberyes = readData.Split(';')[7];
                        try
                        {
                            subscriberyes = subscriberyes.Split('=')[7];
                        } catch
                        {
                            subscriberyes = "0";
                        }
                        
                        int subyes = int.Parse(subscriberyes);
                        if (subyes == 1)
                        {
                            subscribertrue = true;
                        }
                        else
                        {
                            subscribertrue = false;
                        }
                        username = readData.Split(seperateName, StringSplitOptions.None)[1];
                        message = readData.Split(separator, StringSplitOptions.None)[1];
                    }          
                    
                    if (bannedWordFilter(username, message)) return;


                    // commands
                    if (message[0].Equals('!')) commands(username, message);
                    chattyBox.Text = chattyBox.Text + username + ": " + message + Environment.NewLine;

                    int num = chattyBox.Lines.Count();
                    if (chattyBox.Lines.Count() > 51)
                    {
                        var foos = new List<string>(chattyBox.Lines);
                        foos.RemoveAt(0);
                        chattyBox.Lines = foos.ToArray();
                    }
                }
                if (readData.Contains("WHISPER"))
                {

                    string username = readData.Split(seperateName, StringSplitOptions.None)[1];
                    string message = readData.Split(whisperseparator, StringSplitOptions.None)[1];
                    if (message[0].Equals('!')) whisperCommands(username, message);
                    else
                    {
                        irc.sendWhisperMessage(username, "Dies ist ein Bot-Account. Diese Nachricht wird von niemandem gelesen. MrDestructoid Wenn du ein wichtiges Anliegen hast melde dich an eine der folgenden Personen: ");
                        string moderatoren = "";
                        foreach (string moderator in AllChatters.Moderators)
                        {
                            moderatoren += moderator + ", ";
                        }
                        moderatoren.Remove(moderatoren.Length - 1, 1);
                        irc.sendWhisperMessage(username, moderatoren);
                    }

                    chattyBox.Text = chattyBox.Text + "Whisper: " + username + ": " + message + Environment.NewLine;


                    int num = chattyBox.Lines.Count();
                    if (chattyBox.Lines.Count() > 51)
                    {
                        var foos = new List<string>(chattyBox.Lines);
                        foos.RemoveAt(0);
                        chattyBox.Lines = foos.ToArray();
                    }
                }
                if (readData.Contains("USERNOTICE"))
                {
                    // THIS IS THE STRING CONTAINED ON A SUB/RESUB/CHARITY(i suppose bits)

                    // Packing USERNOTICE into message split up by ;
                    string[] message = new string[20];
                    message = readData.Split(';');

                    // splitting msg-id
                    string[] sub = new string[2];
                    sub = message[7].Split('=');
                    // sub is in sub[2]

                    //splitting login=<user>
                    string[] usernameStr = new string[2];
                    usernameStr = message[5].Split('=');
                    // username in usernameStr[2]

                    // splitting msg-param-sub-plan
                    string[] subType = new string[2];
                    subType = message[10].Split('=');
                    // subtype { Prime , 1000 , 2000 , 3000 } in subType[2]

                    string[] subMonths = new string[2];
                    subMonths = message[8].Split('=');
                    // subMonths[2] = Amount of Months subbed

                    if (sub[1].Equals("resub"))
                    {
                        switch (subType[1])
                        {
                            case "1000":
                                irc.sendChatMessage("Vielen Dank für deinen " + subMonths[1] + ". Resub " + usernameStr[1] + " Willkommen zurück in der " + this.channelName + "Army! Deinem Konto werden 500 " + this.currencyName + " gutgeschrieben.");
                                addPoints(usernameStr[1], 500);
                                break;
                            case "2000":
                                irc.sendChatMessage("Vielen Dank für deinen " + subMonths[1] + ". Resub " + usernameStr[1] + " Willkommen zurück in der " + this.channelName + "Army! Deinem Konto werden 1000 " + this.currencyName + " gutgeschrieben.");
                                addPoints(usernameStr[1], 1000);
                                break;
                            case "3000":
                                irc.sendChatMessage("Vielen Dank für deinen " + subMonths[1] + ". Resub " + usernameStr[1] + " Willkommen zurück in der " + this.channelName + "Army! Deinem Konto werden 5000 " + this.currencyName + " gutgeschrieben.");
                                addPoints(usernameStr[1], 5000);
                                break;
                            case "Prime":
                                irc.sendChatMessage("Vielen Dank für deinen " + subMonths[1] + ". Resub mit Twitch Prime " + usernameStr[1] + " Willkommen zurück in der " + this.channelName + "Army! Deinem Konto werden 500 " + this.currencyName + " gutgeschrieben.");
                                addPoints(usernameStr[1], 500);
                                break;
                            case "prime":
                                irc.sendChatMessage("Vielen Dank für deinen " + subMonths[1] + ". Resub mit Twitch Prime " + usernameStr[1] + " Willkommen zurück in der " + this.channelName + "Army! Deinem Konto werden 500 " + this.currencyName + " gutgeschrieben.");
                                addPoints(usernameStr[1], 500);
                                break;
                        }
                    }
                    if (sub[1].Equals("sub"))
                    {
                        switch (subType[1])
                        {
                            case "1000":
                                irc.sendChatMessage("Vielen Dank für deinen Sub " + usernameStr[1] + " Willkommen in der " + this.channelName + "Army! Deinem Konto werden 500 " + this.currencyName + " gutgeschrieben.");
                                addPoints(usernameStr[1], 500);
                                break;
                            case "2000":
                                irc.sendChatMessage("Vielen Dank für deinen Sub " + usernameStr[1] + " Willkommen in der " + this.channelName + "Army! Deinem Konto werden 1000  " + this.currencyName + "  gutgeschrieben.");
                                addPoints(usernameStr[1], 1000);
                                break;
                            case "3000":
                                irc.sendChatMessage("Vielen Dank für deinen Sub " + usernameStr[1] + " Willkommen in der " + this.channelName + "Army! Deinem Konto werden 5000 " + this.currencyName + " gutgeschrieben.");
                                addPoints(usernameStr[1], 5000);
                                break;
                            case "Prime":
                                irc.sendChatMessage("Vielen Dank für deinen Sub mit Twitch Prime " + usernameStr[1] + " Willkommen in der " + this.channelName + "Army! Deinem Konto werden 500 " + this.currencyName + " gutgeschrieben.");
                                addPoints(usernameStr[1], 500);
                                break;
                            case "prime":
                                irc.sendChatMessage("Vielen Dank für deinen Sub mit Twitch Prime " + usernameStr[1] + " Willkommen in der " + this.channelName + "Army! Deinem Konto werden 500 " + this.currencyName + " gutgeschrieben.");
                                addPoints(usernameStr[1], 500);
                                break;
                        }
                    }
                }
            }
            if (readData.Contains("JOIN"))
            {
                // readDataString = :USERNAME
                string[] readDataStr = readData.Split('!');
                string readDataString = readDataStr[0].Split(new[] { ':' }, StringSplitOptions.None)[1];
                List<string> dataFromCsv = new List<string>();
                
                dataFromCsv = userGreetedCsv.getData();
                string[] commandStr = new string[2];
                for (int i = 0; i < dataFromCsv.Count; i++)
                {
                    commandStr = dataFromCsv[i].Split(';');
                    if (readDataString == commandStr[0])
                    {
                        return;
                    }
                }
                try
                {
                    if (Database.HasStatus(readDataString, Statuses.begruessen))
                    {
                        irc.sendChatMessage("Willkommen im Stream " + readDataString);
                        userGreetedCsv.writeUser(readDataString);
                    }
                } catch (Exception e)
                {

                }
            }
        }
        private void commands(string username, string message)
        {
            Chatters AllChatters = chatClient.GetChatters(this.channelName);
            // looking for command. Everything after the Exclamationmark will be read
            string command = message.Split(new[] { ' ', '!' }, StringSplitOptions.None)[1];
            switch (command.ToLower())
            {
                // Adds commands to the db
                #region addcom
                case "addcmd":
                {
                            if (currentModerators.Contains(username))
                            {
                                string[] newCommand = new string[50];
                                newCommand = message.Split(' ');
                                // !addcom name MESSAGE
                                //   [0]    [1]   [2-X]
                                string textInCommand = "";
                                for (int i = 2; i < newCommand.Length; i++)
                                {
                                    textInCommand += newCommand[i] + " ";
                                }
                                Database.InsertNewCommand(newCommand[1].ToLower(), textInCommand);
                                irc.sendChatMessage($"Command '{newCommand[1].ToLower()}' wurde erstellt.");
                                break;
                            }
                        break;
                    }
                        
                    
                #endregion
                // edits commands in the db
                #region editcom
                case "editcmd":
                {
                        if (!(currentModerators.Contains(username))) break;
                        string[] newCmd = new string[50];
                        newCmd = message.Split(' ');
                        string textInCommand = "";
                        for (int i = 2; i < newCmd.Length; i++)
                        {

                            textInCommand += newCmd[i] + " ";
                        }
                        Database.UpdateCommandText(newCmd[1].ToLower(), textInCommand);
                        irc.sendChatMessage($"Command '{newCmd[1].ToLower()}' wurde editiert.");
                    break;
                }
                #endregion
                // deletes commands in the db
                #region delcom
                case "delcmd":
                    {
                        if (!(currentModerators.Contains(username))) break;
                        string[] newCmd = new string[50];
                        newCmd = message.Split(' ');
                        Database.DeleteCommand(newCmd[1].ToLower());
                        irc.sendChatMessage($"Command '{newCmd[1].ToLower()}' wurde geloescht.");
                        break;
                    }
                #endregion

                #region donate
                case "donate":
                    {
                        string[] newCommand = new string[50];
                        newCommand = message.Split(' ');
                        // !donate USERNAME Euro
                        //     0    1       2
                        try
                        {
                            addPoints(newCommand[1], int.Parse(newCommand[2]));
                            irc.sendChatMessage($"Danke {newCommand[1]} für deine Donation von {newCommand[2]}€. Dir wurden {(int.Parse(newCommand[2]) * 100)} {this.currencyName} Gutgeschrieben.");
                        } catch
                        {
                            irc.sendWhisperMessage(username, "Fehler bei der Donation. Bitte erneut eingeben");
                        }
                        break;
                    }
                #endregion

                // lets people join the giveaway
                #region beitreten
                case "beitreten":
                    if (!raffleOngoing) break;
                    if (raffleParticipants.Contains(username)) break;
                    amountOfParticipants++;
                    raffleJoin(username);
                    break;
                #endregion
                // adds people to the viewergamelistqueue
                #region viewergames 
                case "viewergames":
                    if (!viewerGamesListOpen) break;
                    bool userAlreadyInList = false;
                    foreach (var usersInList in viewerGamesParticipants)
                    {
                        if (username == usersInList)
                        {
                            userAlreadyInList = true;
                            break;
                        }
                    }
                    if (userAlreadyInList) {
                        userAlreadyInList = false;
                        break;
                    }
                    joinViewerGame(username);
                    break;
                #endregion
                // doubleup function
                #region doubleup
                case "verdoppeln":
                    if (settingsIni.iniReadValue("settings", "verdoppelnstate") == "false")
                    {
                        irc.sendChatMessage("Verdoppeln ist heute gesperrt!");
                        break;
                    }
                    string[] amount = message.Split(' ');
                    // !verdoppeln 50
                    //    0        1
                    if (amount.Length == 1) break;
                    try
                    {
                        int.Parse(amount[1]);
                    }
                    catch
                    {
                        break;
                    }
                    int win = int.Parse(amount[1]);
                    if (getPoints(username) < win || win < 50) break;
                    Random rnd = new Random();
                    int nmbr = rnd.Next(0, 100);
                    if (nmbr < 46)
                    {
                        irc.sendWhisperMessage(username, "Du hast " + (win * 2) + " " + this.currencyName + " gewonnen!");
                        if (win * 2 > 10000)
                        {
                            irc.sendChatMessage(username + " hat " + win*2 + " " + this.currencyName + " Gewonnen");
                        }
                        addPoints(username, (int.Parse(amount[1]) * 2));
                        addPoints(username, -(int.Parse(amount[1])));
                    } else
                    {
                        irc.sendWhisperMessage(username, "Du hast verloren! Viel Glück beim nächsten mal!");
                        addPoints(userName, (Math.Round(int.Parse(amount[1]) * 0.75)));
                        addPoints(username, -(int.Parse(amount[1])));
                    }
                    break;
                #endregion
                // retrieves amount of currency the user has
                #region requesthori
                case "requesthori":
                    // !requesthori USERNAME
                    foreach (string moderators in AllChatters.Moderators)
                    {
                        if (username == moderators)
                        {
                            string[] amountHorisUser = message.Split(' ');
                            // !requesthori USERNAME
                            //     0         1
                            if (amountHorisUser.Length == 1 || amountHorisUser.Length > 2)
                            {
                                break;
                            }
                            amountHorisUser[1] = amountHorisUser[1].ToLower();
                            irc.sendWhisperMessage(username, "Der User " + amountHorisUser[1] + " hat " + getPoints(amountHorisUser[1]) + " " + this.currencyName);
                        }
                    }
                    break;

                #endregion
                // gamble function
                #region gamble
                case "gamble":
                    if (settingsIni.iniReadValue("settings", "gamblestate") == "false")
                    {
                        irc.sendChatMessage("Gamble ist heute Deaktiviert.");
                        break;
                    }
                    string[] gambleStr = new string[10];
                    gambleStr = message.Split(' ');

                    // !gamble Punktzahl
                    //   [0]     [1]
                    try
                    {
                        int.Parse(gambleStr[1]);
                    }
                    catch (Exception e)
                    {
                        // !gamble 2039wwejase
                        break;
                    }
                    if (int.Parse(gambleStr[1]) > getPoints(username) || getPoints(username) < 50)
                    {
                        break;
                    }
                    addPoints(username, -(int.Parse(gambleStr[1])));
                    // Horis ver8fachen
                    Random random = new Random();
                    int winningNumber = random.Next(0, 100);
                    if (winningNumber < 10)
                    {
                        addPoints(username, int.Parse(gambleStr[1]) * 8);
                        irc.sendWhisperMessage(username, "Du hast " + (int.Parse(gambleStr[1]) * 8) + " " + this.currencyName + " gewonnen");
                    } else
                    {
                        irc.sendWhisperMessage(username, "Du hast verloren. Viel Glück beim nächsten mal.");
                    }
                    break;
                #endregion
                // rewards either viewername or all amount of horis
                #region reward
                case "reward":
                    foreach (string moderator in AllChatters.Moderators)
                    {
                        if (username == moderator)
                        {
                            string recipient = message.Split(new string[] { " " }, StringSplitOptions.None)[1];
                            recipient = recipient.ToLower();
                            if (recipient == username) break;
                            if (recipient[0] == '@')
                            {
                                recipient = recipient.Split(new[] { '@' }, StringSplitOptions.None)[1];
                            }
                            string pointsToTransferString = message.Split(new string[] { " " }, StringSplitOptions.None)[2];
                            double pointsToTransfer = 0;
                            bool validNum = double.TryParse(pointsToTransferString.Split(new[] { ' ' }, StringSplitOptions.None)[0], out pointsToTransfer);
                            if (!validNum) break;
                            if (recipient == "all")
                            {
                                foreach (string viewer in AllChatters.Viewers)
                                {
                                    addPoints(viewer, pointsToTransfer);
                                }
                                foreach (string moderators in AllChatters.Moderators)
                                {
                                    addPoints(moderators, pointsToTransfer);
                                }
                                irc.sendChatMessage(this.currencyName + " transfer successfull.");
                                break;
                            }
                            if (pointsToTransfer > 0)
                            {
                                addPoints(recipient, pointsToTransfer);
                                irc.sendChatMessage(this.currencyName + " transfer successfull.");
                            }
                        }
                    }
                    break;
                #endregion

                #region toppoints: not finished
                case "toppoints":
                    topPoints();
                    break;
                #endregion
                #region charge
                case "charge":
                    //if (username == "demmou" || username == "horican")
                    foreach (string moderator in AllChatters.Moderators)
                    {
                        if (username == moderator || username == this.channelName)
                        {
                            string recipient = message.Split(new string[] { " " }, StringSplitOptions.None)[1];
                            if (recipient == username) break;
                            if (recipient[0] == '@')
                            {
                                recipient = recipient.Split(new[] { '@' }, StringSplitOptions.None)[1];
                            }
                            string pointsToTransferString = message.Split(new string[] { " " }, StringSplitOptions.None)[2];
                            double pointsToTransfer = 0;
                            bool validNum = double.TryParse(pointsToTransferString.Split(new[] { ' ' }, StringSplitOptions.None)[0], out pointsToTransfer);
                            if (!validNum) break;
                            if (pointsToTransfer > 0)
                            {
                                addPoints(recipient.ToLower(), -pointsToTransfer);
                                irc.sendChatMessage(this.currencyName + " transfer successfull.");
                            }
                        }
                    }
                    break;
                #endregion
                #region bombgame
                case "bombgame":
                    break;
                    if (!bombGameOngoing)
                    {
                        foreach (string moderators in AllChatters.Moderators)
                        {
                            if (username == moderators)
                            {
                                foreach (string viewers in AllChatters.Viewers)
                                {
                                    viewerCurrent.Add(viewers);
                                }
                                Random rnds = new Random();
                                bombCarrier = viewerCurrent[rnds.Next(0, viewerCurrent.Count - 1)];
                                irc.sendChatMessage(username + " wirft eine Bombe in die Menge! " + bombCarrier + " hat sie gefangen. Holt sie euch mit !take [NAME]");
                                bombGameNameChatSayTimer.Start();
                                bombExplodeTimer.Start();
                                bombGameOngoing = true;
                            }
                        }
                    }

                    break;
                #endregion
                #region take
                case "take":
                    if (bombGameOngoing)
                    {
                        string userNamePossibleCarrier = message.Split(new[] { ' ', '!' }, StringSplitOptions.None)[2];
                        if (userNamePossibleCarrier == bombCarrier)
                        {
                            bombCarrier = username;
                        }
                    }
                    break;
                #endregion
                #region bank
                case "bank":
                    irc.sendChatMessage("Die Bank besitzt aktuell " + getPoints(userName) + " " + this.currencyName + ". Die Ausschüttung an die bedürftigsten Viewer beginnt in " + (100000 - getPoints(userName)) + " " + this.currencyName + ".");
                    break;
                #endregion
                #region bets
                case "bets":
                    irc.sendChatMessage("1 9999");
                    break;
                #endregion
                #region bingo
                case "bingo":
                    if (settingsIni.iniReadValue("settings", "bingostate") == "false")
                    {
                        bingoMessageSaidTimer.Start();
                        bingoMessageSaid = true;
                        irc.sendChatMessage("Die Bingohalle ist heute geschlossen!");
                        break;
                    }

                    string[] nachricht = message.Split(new string[] { " " }, StringSplitOptions.None);

                    if (nachricht.Length == 1) break;
                    try
                    {
                        if (getPoints(username) < int.Parse(nachricht[1])) break;
                    } catch (Exception e)
                    {
                        break;
                    }
                    if (bingoDown)
                    {
                        irc.sendChatMessage("Die Bingohalle ist momentan geschlossen. Versuchen Sie es in einigen Minuten nochmal!");
                        break;
                    }
                    if (!onlySendOnce)
                    {
                        bingoTimer.Start();
                        irc.sendChatMessage("Eine neue Runde Bingo hat gestartet. Wer mitmachen will schreibt !bingo im Chat! Das mitmachen kostet 1 " + this.currencyName + " pro Ticket");
                        onlySendOnce = true;
                    }
                    if (getPoints(username) > 10)
                    {
                        int pointsLost = int.Parse(nachricht[1]);
                        for (int i = 0; i < pointsLost; i++)
                        {
                            bingoNameList.Add(username);
                        }
                        addPoints(username, -(pointsLost));
                        bingoPointsPot += pointsLost;
                        irc.sendWhisperMessage(username, "Du bist mit " + pointsLost + " Gewinnlosen im Pott! Viel Glück!");
                    }
                    else
                    {
                        break;
                    }
                    break;
                #endregion
                #region BingoInfo
                case "bingoinfo":
                    irc.sendChatMessage("Um Bingo mitzuspielen müsst ihr einfach !bingo X eingeben. Wobei X die Anzahl der Tickets ist! Viel Glück.");
                    break;
                #endregion
                #region horis
                case "points":
                    irc.sendChatMessage("Die '" + this.currencyName + "', die mit !" + this.currencyName + " abfragbar sind, spiegeln eure Aktivität wider. 1 Minuten Zuschauen entsprechen 1 " + this.currencyName + ", Für ein Follow bekommt ihr 100 " + this.currencyName + " und als Subscriber bekommt ihr doppelt so viele.");
                    break;
                #endregion
                #region muenze
                case "muenze":
                    if (muenzeCooldownBool) break;
                    if (muenzeOpen) break;
                    muenzeOpen = true;
                    muenzeTimer.Start();
                    irc.sendChatMessage("Eine Münze wird geworfen entscheidet euch schnell !kopf wenn ihr Kopf denkt, !zahl für Zahl. Der Beitritt kostet 100 " + this.currencyName);
                    break;
                case "kopf":
                    if (muenzeCooldownBool) break;
                    if (!muenzeOpen) break;
                    muenzeKopf.Add(username);
                    addPoints(username, -(100));
                    irc.sendWhisperMessage(username, "Du hast Kopf gewählt");
                    break;
                case "zahl":
                    if (muenzeCooldownBool) break;
                    if (!muenzeOpen) break;
                    muenzeZahl.Add(username);
                    addPoints(username, -(100));
                    irc.sendWhisperMessage(username, "Du hast Zahl gewählt");
                    break;
                #endregion
                #region smash
                case "smash":
                    if (settingsIni.iniReadValue("settings", "smashstate") == "false")
                    {
                        irc.sendChatMessage("Smash ist heute geschlossen!");
                        break;
                    }
                    // !smash    Value
                    //     [0]    [1] 
                    string[] mssge = message.Split(new string[] { " " }, StringSplitOptions.None);
                    try
                    {
                        if (int.Parse(mssge[1]) > getPoints(username))
                        {
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        break;
                    }
                    addPoints(username, -(Math.Round(double.Parse(mssge[1]))));
                    if (smashGameStarted)
                    {
                        TimeSpan t = DateTime.Now - starttime;
                        irc.sendChatMessage("Die Superhelden bereiten sich auf ihren Kampf gegen das Böse vor. Sie sammeln ihre letzten Kräfte damit es gleich losgehen kann! Cooldown: " + (10 - t.Minutes) + " minuten");
                        break;
                    }
                    if (sentMessage)
                    {
                        irc.sendChatMessage(username + " tritt dem Superheldenteam bei.");
                    }
                    if (!sentMessage)
                    {
                        irc.sendChatMessage(username + " möchte ein Superhelden-Team zusammenstellen um die Welt zu retten. - Jeder von euch kann Superheld sein, wenn ihr euch dem Team anschließen wollt tippt !smash (amount).");
                        sentMessage = true;
                        smashRegistrationTimer.Start();
                    }

                    smashers.Add(username);
                    smashMoney.Add(int.Parse(mssge[1]));


                    break;
                #endregion
                #region transfer
                case "transfer":
                    // !transfer Name1  Value
                    //     [0]    [1]    [3]
                    string[] mssg = message.Split(new string[] { " " }, StringSplitOptions.None);
                    mssg[1] = mssg[1].ToLower();
                    try
                    {
                        int x = int.Parse(mssg[2]);
                        if (x < 100)
                        {
                            break;
                        }
                    }
                    catch
                    {
                        break;
                    }
                    if (Database.UserExists(mssg[1]))
                    {
                        if (getPoints(username) < int.Parse(mssg[2]))
                        {
                            irc.sendChatMessage("Transfer nicht möglich! " + username + " hat nicht genügend " + this.currencyName + ".");
                            break;
                        }
                        double pointsOfTransfer = Math.Round(double.Parse(mssg[2]) * 0.93);
                        addPoints(username, -(double.Parse(mssg[2])));
                        addPoints(mssg[1], pointsOfTransfer);
                        addPoints(userName, (Math.Round(double.Parse(mssg[2]) * 0.07)));
                        irc.sendChatMessage("Transfer abgeschlossen. " + pointsOfTransfer + " " + this.currencyName + " wurden " + mssg[1] + " Gutgeschrieben. Die Bank erhält 7% der Transaktion.");
                    }
                    else
                    {
                        double pointsOfTransfer = Math.Round(double.Parse(mssg[2]) * 0.05);
                        irc.sendChatMessage($"Das Konto {mssg[1]} wurde nicht gefunden. Die Bearbeitungsgebühren betragen 5% des zu überweisenden Betrags: {pointsOfTransfer} {this.currencyName}");
                        if (getPoints(username) > pointsOfTransfer)
                        {
                            addPoints(username, -pointsOfTransfer);
                            addPoints(userName, pointsOfTransfer);
                        } else
                        {
                            addPoints(username, -(getPoints(username)));
                            addPoints(mssg[1], getPoints(username));
                        }
                        break;
                    }
                    break;
                #endregion
                #region uptime
                case "uptime":
                    irc.sendChatMessage($"Der Stream ist seit {(this.timeOnline / 60)} Stunden und {(this.timeOnline%60)} Minuten online");
                    break;
                #endregion
                #region bedarf
                case "bedarf":
                    if (this.beggers.Contains(username)) break;
                    this.beggers.Add(username);
                    
                    break;
                #endregion
                #region suggest
                case "suggest":
                    {
                        tippcounter++;
                        string[] newCommand = new string[50];
                        newCommand = message.Split(' ');
                        // !addcom name MESSAGE
                        //   [0]    [1]   [2-X]
                        string textInCommand = "";
                        for (int i = 1; i < newCommand.Length; i++)
                        {
                            textInCommand += newCommand[i] + " ";
                        }
                        suggestIni.iniWriteValue("suggestions", tippcounter.ToString(),textInCommand);
                        settingsIni.iniWriteValue("settings", "suggestcounter", tippcounter.ToString());
                        break;
                    }
                    
                #endregion
                default:
                  if (command == this.currencyName.ToLower())
                    {
                        if (!commandSpamFilter)
                        {
                            foreach (CommandSpamUser singleuser in csu)
                            {
                                if (username == singleuser.usern) return;
                            }
                            // handeling users that spam the command
                            commandSpamFilter = true;
                            CommandSpamUser user = new CommandSpamUser();
                            user.usern = username;
                            user.timeOfMessage = DateTime.Now;
                            csu.Add(user);

                            int yourPoints = Database.GetPoints(username);
                            if (yourPoints == 0)
                            {
                                yourPoints = 20;
                                addPoints(username, yourPoints);
                            }
                            else
                            {
                                if (yourPoints < 20)
                                {
                                    addPoints(username, 20 - yourPoints);
                                    yourPoints = 20;
                                }
                            }
                            int timeWasted = Database.GetMinutesWatched(username);
                            irc.sendWhisperMessage(username, $" Du hast {yourPoints} { this.currencyName} und bisher {timeWasted/(60*24)} Tage {(timeWasted /60) %24} Stunden {timeWasted % 60} Minuten hier verbracht");
                            
                            break;
                        }
                        return;
                    }
                    try
                    {
                        irc.sendChatMessage(Database.GetCommandText(command.ToLower()));
                    } catch { break; }
                    
                    break;
         
            }
        }
        private void whisperCommands(string username, string message)
        {
            string command = message.Split(new[] { ' ', '!' }, StringSplitOptions.None)[1];
            Chatters AllChatters = chatClient.GetChatters(this.channelName);
            switch (command.ToLower())
            {
                #region hori
                case "hori$":
                    if (!commandSpamFilter)
                    {
                        foreach (CommandSpamUser singleuser in csu)
                        {
                            if (username == singleuser.usern) return;
                        }
                        // handeling users that spam the command
                        commandSpamFilter = true;
                        CommandSpamUser user = new CommandSpamUser();
                        user.usern = username;
                        user.timeOfMessage = DateTime.Now;
                        csu.Add(user);

                        int yourPoints = Database.GetPoints(username);
                        if (yourPoints == 0)
                        {
                            yourPoints = 20;
                            addPoints(username, yourPoints);
                        }
                        else
                        {
                            if (yourPoints < 20)
                            {
                                addPoints(username, 20 - yourPoints);
                                yourPoints = 20;
                            }
                        }
                        irc.sendWhisperMessage(username, " Du hast " + yourPoints + " " + this.currencyName + ".");
                    }
                    break;
                #endregion
                #region ban
                case "ban":
                    foreach (string moderator in AllChatters.Moderators)
                    {

                        string reci = message.Split(new string[] { " " }, StringSplitOptions.None)[1];
                        string[] nachricht = message.Split(new string[] { " " }, StringSplitOptions.None);
                        // combining message to final form
                        string messageFinal = "";
                        for (int i = 2; i < nachricht.Count(); i++)
                        {
                            messageFinal += nachricht[i] + " ";
                        }

                        if (username == moderator)
                        {
                            irc.sendChatMessage("/ban " + reci);
                            irc.sendWhisperMessage(reci, "Hallo " + reci + " du wurdest permanent gebannt aufgrund von: " + messageFinal);
                            irc.sendWhisperMessage(reci, "Falls du Fragen hast, melde dich bitte bei einem der Moderatoren");
                        }
                    }
                    break;
                #endregion
                #region timeout
                case "timeout":
                    foreach (string moderator in AllChatters.Moderators)
                    {
                        if (username == moderator)
                        {
                            string recipients = message.Split(new string[] { " " }, StringSplitOptions.None)[1];
                            string[] nachricht = message.Split(new string[] { " " }, StringSplitOptions.None);
                            // combining message to final form
                            string messageFinal = "";
                            for (int i = 3; i < nachricht.Count(); i++)
                            {
                                messageFinal += nachricht[i] + " ";
                            }
                            int minutes = 0;
                            int seconds = 0;
                            if ((int.TryParse(nachricht[2], out minutes)) && (int.TryParse(nachricht[2], out seconds)))
                            {
                                minutes = int.Parse(nachricht[2]) / 60;
                                seconds = int.Parse(nachricht[2]) % 60;
                                irc.sendWhisperMessage(recipients, "Hallo " + recipients + " du wurdest für " + minutes + " Minuten und " + seconds + " Sekunden getimeouted aufgrund von: " + messageFinal);
                            }
                            else
                            {
                                nachricht[2] = "0";
                            }

                            irc.sendChatMessage("/timeout " + recipients + " " + nachricht[2]);
                            if (minutes == 0 && seconds == 0)
                            {
                                irc.sendChatMessage("/timeout " + recipients + " 60");
                                irc.sendWhisperMessage(recipients, "Hallo " + recipients + " du wurdest für 1 Minuten und 0 Sekunden getimeouted aufgrund von: " + messageFinal);
                                irc.sendWhisperMessage(recipients, "Falls du Fragen hast, melde dich bitte bei einem der Moderatoren");
                                break;
                            }
                            irc.sendChatMessage("/timeout " + recipients + " " + nachricht[2]);
                            irc.sendWhisperMessage(recipients, "Hallo " + recipients + " du wurdest für " + minutes + " Minuten und " + seconds + " Sekunden getimeouted aufgrund von: " + messageFinal);
                            irc.sendWhisperMessage(recipients, "Falls du Fragen hast, melde dich bitte bei einem der Moderatoren");
                        }
                    }
                    break;
                #endregion
                #region purge
                case "purge":
                    string recip = message.Split(new string[] { " " }, StringSplitOptions.None)[1];
                    irc.sendChatMessage("/timeout " + recip + " 1");
                    break;
                #endregion
                #region unban
                case "unban":
                    string recite = message.Split(new string[] { " " }, StringSplitOptions.None)[1];
                    irc.sendChatMessage("/unban " + recite);
                    irc.sendWhisperMessage(recite, "Herzlichen Glückwunsch. Du wurdest entbannt!");
                    break;
                #endregion
                #region slowmode
                case "slow":
                    string[] nachr = message.Split(new string[] { " " }, StringSplitOptions.None);
                    irc.sendChatMessage("/slow " + nachr[1]);
                    irc.sendChatMessage("Der Chat ist nun in Slowmode. Ihr dürft nun alle " + nachr[1] + " Sekunden eine Nachricht verfassen.");
                    break;
                #endregion
                #region time
                case "time":
                    if (!commandSpamFilter)
                    {
                        foreach (CommandSpamUser singleuser in csu)
                        {
                            if (username == singleuser.usern) return;
                        }
                        // handeling users that spam the command
                        commandSpamFilter = true;
                        CommandSpamUser user = new CommandSpamUser();
                        user.usern = username;
                        user.timeOfMessage = DateTime.Now;
                        csu.Add(user);

                        int yourTime = Database.GetMinutesWatched(username);
                        if (yourTime == 0)
                        {
                            yourTime = 1;
                            addTime(username, yourTime);
                        }
                        int hours = yourTime / 60;
                        int minutes = yourTime % 60;
                        irc.sendWhisperMessage(username, " Du hast " + hours + " Stunden und " + minutes + " Minuten hier verbracht.");
                    }
                    break;
                #endregion
                #region subscribermode on
                case "subscribersonly":
                    irc.sendChatMessage("/subscribers");
                    irc.sendChatMessage("Nun können nurnoch Subscriber schreiben. Sperrt die Plebs ein!");
                    break;
                #endregion
                #region subscribermode off
                case "subscribersoff":
                    irc.sendChatMessage("/subscribersoff");
                    irc.sendChatMessage("FREE THE PLEBS. ENJOY THE RIDE. MrDestructoid");
                    break;
                #endregion
                #region toppoints
                case "toppoints":
                    topPoints();
                    break;
                #endregion
                #region shop
                case "shop":
                    irc.sendWhisperMessage(username, "Item: Verdoppeln, Preis: 30000 " + this.currencyName + ", Beschreibung: Verdoppelt die Punkte, welche man alle 10 Minuten erhält. | Item: Begrüßung, Preis: 50000 " + this.currencyName + ", Beschreibung: Begrüßung beim Beitritt des Chats vom Chatbot :) MrDestructoid | Item: Autogrammkarte, Preis: 40000 " + this.currencyName + ", Beschreibung: " +this.channelName + " schickt dir persönlich eine Autogrammkarte | Item: Bild, Preis: 5000 " + this.currencyName + ", Beschreibung: " + this.channelName + " zeichnet ein 2 minuten Bild!");
                    irc.sendWhisperMessage(username, "Um ein Item zu kaufen !kaufen ITEMNAME eingeben.");
                    break;
                #endregion
                #region kaufen
                case "kaufen":
                    string[] kaufString = message.Split(' ');
                    if (kaufString.Length == 1) break;
                    kaufString[1] = kaufString[1].ToLower();

                    if (kaufString[1] == "verdoppeln")
                    {
                        if (getPoints(username) < 30000) break;
                        addStatus(username, Statuses.verdoppeln);
                        addPoints(username, -(30000));
                    }
                    if (kaufString[1] == "begrüßung")
                    {
                        if (getPoints(username) < 50000) break;
                        addStatus(username, Statuses.begruessen);
                        addPoints(username, -(50000));
                    }
                    if (kaufString[1] == "autogrammkarte")
                    {
                        if (getPoints(username) < 40000) break;
                        addPoints(username, -(40000));
                        postkarteListBox.Items.Add(username);
                    }
                    if (kaufString[1] == "bild")
                    {
                        if (getPoints(username) < 5000) break;
                        addPoints(username, -(5000));
                        bildZeichnenListBox.Items.Add(username);
                    }
                    break;
                #endregion
                #region swap
                case "swap": // !swap Name1 Name2
                    foreach (string moderator in AllChatters.Moderators)
                    {
                        if (username == moderator)
                        {
                            string[] msg = message.Split(new string[] { " " }, StringSplitOptions.None);
                            // !swap = nachricht[0] // Name1 = nachricht[1] // name2 = nachricht[2]
                            int pointsUserOne = Database.GetPoints(msg[1]);
                            Database.UpdatePoints(msg[1], Database.GetPoints(msg[2]));
                            Database.UpdatePoints(msg[2], pointsUserOne);
                            int timeUserOne = Database.GetMinutesWatched(msg[1]);
                            Database.UpdateMinutesWatched(msg[1], Database.GetMinutesWatched(msg[2]));
                            Database.UpdateMinutesWatched(msg[2], timeUserOne);
                            irc.sendWhisperMessage(username, "Transfer successfull.");
                        }
                    }
                    break;
                #endregion
                #region modsay
                case "modsay":
                    foreach (string moderator in AllChatters.Moderators)
                    {
                        if (username == moderator)
                        {
                            commandModSayTimer.Start();
                            string finalMessage = "";
                            if (commandModSayBool) break;
                            commandModSayBool = true;
                            string[] nachricht = message.Split(new string[] { " " }, StringSplitOptions.None);
                            for (int i = 1; i < nachricht.Length; i++)
                            {
                                finalMessage += nachricht[i] + " ";
                            }
                            modChatBox.Text = modChatBox.Text + username + ": " + finalMessage + Environment.NewLine;
                            foreach (string moderators in AllChatters.Moderators)
                            {
                                if (username != moderators)
                                {
                                    irc.sendWhisperMessage(moderators, username + " sagt: " + finalMessage);
                                    break;
                                }
                            }
                        }
                    }
                    break;
                #endregion
                #region default
                default:
                    break;
                    #endregion
            }
        }
        private bool bannedWordFilter(string username, string message)
        {
            foreach (string word in bannedWords)
            {
                if (message.Contains(word))
                {
                    string command = "/timeout " + username + " 10";
                    irc.sendChatMessage(command);
                    return true;
                }
            }
            return false;
        }
        private void addPoints(string user, double points)
        {
            if ((getPoints(userName) > 100000) && !(lotteryBankBlocked))
            {
                Database.UpdatePoints(this.userName,0);
                winPointsByBank();
                lotteryBankBlocked = true;
            }
            try
            {
                Database.AddPoints(user, Convert.ToInt32(points));
            } catch (Exception e)
            {
                if (points > 0) Database.AddPoints(user, Convert.ToInt32(points));
            }
        }
        private void takeTaxes(double points)
        {

        }
        private void winPointsByBank()
        {
            irc.sendChatMessage("Die Bank ist überfüllt! ALLES MUSS RAUS! Wo sind denn die armen und bedürftigen? !bedarf um eine Gewinnchance zu erhalten! In 2 Minuten muss alles Raus!");
            bankLotteryTimer.Start();
        }
        private void topPoints()
        {
            Dictionary<string /*user*/, int /*points*/> dict = Database.GetTop("Points", 10);
            // Username(Points), Username(Points)
            string str = "";
            foreach (KeyValuePair<string /*user*/, int /*points*/> pair in dict)
                str += $"{pair.Key}({pair.Value}), ";
            str = str.Substring(0, str.Length - 2);
            irc.sendChatMessage($"Die 10 User mit den Meisten {this.currencyName} sind: {str}");
        }
        private void readDataPopulateTextBoxes()
        {
            List<string> csvData = new List<string>();
            String[] linesSplit = new string[2];
            try
            {
                this.botPassWord = settingsIni.iniReadValue("settings", "authtoken");
                this.userName = settingsIni.iniReadValue("settings", "botname");
                this.twitchClientID = settingsIni.iniReadValue("settings", "clientId");
                this.channelName = settingsIni.iniReadValue("settings", "channel");
                this.currencyName = settingsIni.iniReadValue("settings", "currencyName");
                this.demmouMode = bool.Parse(settingsIni.iniReadValue("settings", "demmoumode"));
                this.tippcounter = int.Parse(settingsIni.iniReadValue("settings", "suggestcounter"));
            }
            catch (Exception e)
            {

            }
        }
        private void joinViewerGame(string username)
        {
            viewerGamesParticipants.Add(username);
            viewerGamesParticipantsBox.Items.Add(username);
            irc.sendWhisperMessage(username, "Du bist dabei!");
        }
        private int getPoints(string user)
        {
            return Database.GetPoints(user);
        }
        private void addTime(string user, double time)
        {
            try
            {
                user = user.Trim().ToLower();
                Database.AddMinutesWatched(user, Convert.ToInt32(time));
            }
            catch (Exception e)
            {
                
            }
        }
        private void addStatus(string user, Statuses stat)
        {
            Database.SetStatus(user, stat);

            // rnd
            
        }
        private void pointTimer_Tick(object sender, EventArgs e)
        {
            foreach (string username in usernamesOfViewer)
            {
                if (Database.UserExists(username))
                {
                    int points = 10;
                    int minutes = 10;
                    if (Database.HasStatus(username, Statuses.verdoppeln))
                    {
                        points += 10;
                    }
                    Database.AddPoints(username, points);
                    Database.AddMinutesWatched(username, minutes);
                }
                else
                {
                    Database.InsertNewUser(username, 20, 0, 20);
                }
            }
            timeOnline += 10;
        }
        private void chattyBox_TextChanged(object sender, EventArgs e)
        {
            chattyBox.SelectionStart = chattyBox.Text.Length;
            chattyBox.ScrollToCaret();
        }
        private void viewerBoxTimer_Tick(object sender, EventArgs e)
        {
            viewerListUpdate();
        }
        private void viewerListUpdate()
        {
            usernamesOfViewer.Clear();
            currentModerators.Clear();
            Chatters AllChatters = chatClient.GetChatters(this.channelName);
            chattyBox.Text += "Checking the viewer list..." + Environment.NewLine;
            // unneccessary
            //int numberOfChatters = chatClient.GetChatterCount("demmou");
            foreach (string admin in AllChatters.Admins)
                usernamesOfViewer.Add(admin);
            foreach (string staff in AllChatters.Staff)
                usernamesOfViewer.Add(staff);
            foreach (string globalmod in AllChatters.GlobalMods)
                usernamesOfViewer.Add(globalmod);
            foreach (string moderator in AllChatters.Moderators)
            {
                usernamesOfViewer.Add(moderator);
                currentModerators.Add(moderator);
            }
            foreach (string viewer in AllChatters.Viewers)
                usernamesOfViewer.Add(viewer);
            viewerList.Items.Clear();
            foreach (var viewer in usernamesOfViewer)
                viewerList.Items.Add(viewer);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void sendButton_Click(object sender, EventArgs e)
        {
            irc.sendChatMessage(botChatBox.Text);
            chattyBox.Text += userName + ": " + botChatBox.Text + Environment.NewLine;
            botChatBox.Clear();
        }
        private void botChatBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                irc.sendChatMessage(botChatBox.Text);
                chattyBox.Text += userName + ": " + botChatBox.Text + Environment.NewLine;
                botChatBox.Clear();
            }
        }
        private void commandSpamTimer_Tick(object sender, EventArgs e)
        {
            commandSpamFilter = false;

            List<CommandSpamUser> temp = csu;
            foreach (CommandSpamUser user in temp)
            {
                TimeSpan duration = DateTime.Now - user.timeOfMessage;
                if (duration > TimeSpan.FromSeconds(20))
                {
                    csu.Remove(user);
                    return;
                }
            }
        }
        private void pointChatTimer_Tick(object sender, EventArgs e)
        {
            irc.sendChatMessage("Um eure " + this.currencyName + " einzusehen, gebt !" + this.currencyName + " ein. Ihr müsst auf Twitch eure privaten Nachrichten einschalten. Geht dazu in eure Twitch-Einstellungen. Oder schreibt den Bot privat an. MrDestructoid");
        }
        private void messageCycleTimer_Tick(object sender, EventArgs e)
        {

            
            
            if (messageCycleVariable == 1)
            {
                irc.sendChatMessage("Wenn ihr mich unterstützen möchtet, könntet ihr gerne einen Follow da lassen. Es würde mich freuen!");
            }
            if (demmouMode) return;
            if (messageCycleVariable == 0)
            {
                irc.sendChatMessage("Guckt auch mal bei youtube vorbei und lasst n Abo da: https://www.youtube.com/user/h0ricaN");
            }
            if (messageCycleVariable == 2)
            {
                irc.sendChatMessage("Um mich anderweitig zu unterstützen habt ihr die möglichkeit mich auf Twitch zu abonnieren. Hier ist der link: https://www.twitch.tv/products/horican/ticket/new");

            }
            if (messageCycleVariable == 3)
            {

            }
            messageCycleVariable++;
            messageCycleVariable %= 3;
            if (settingsIni.iniReadValue("settings", "fiveMinutes") == "false" || messageCycleVariable == 2)
            {
                return;
            }
        }
        private void commandModSayTimer_Tick(object sender, EventArgs e)
        {
            commandModSayTimer.Stop();
            commandModSayBool = false;
        }
        private void bingoTimer_Tick(object sender, EventArgs e)
        {
            bingoTimer.Stop();
            if (bingoNameList.Count > 5)
            {
                Random rnd = new Random();
                int winner = rnd.Next(0, bingoNameList.Count - 1);
                irc.sendChatMessage("Jemand steht auf und ruft BINGO!!!! Gratulation " + bingoNameList[winner] + " zu deinem Gewinn von " + Math.Round(bingoPointsPot * 0.93) + " " + this.currencyName + " mit der Nummer " + winner);
                addPoints(bingoNameList[winner], Math.Round(bingoPointsPot * 0.93));
                addPoints(userName, Math.Round(bingoPointsPot * 0.06));
                bingoCooldown.Start();
                bingoDown = true;
            }
            else
            {
                irc.sendChatMessage("Es haben sich nicht genügend Spieler zum Bingospielen eingefunden! Die Runde konnte nicht stattfinden");
            }
        }
        private void bingoCooldown_Tick(object sender, EventArgs e)
        {

            irc.sendChatMessage("Die Bingohalle ist wieder geöffnet!");
            addPoints(userName, Math.Round((bingoPointsPot * 0.07)));
            bingoPointsPot = 0;
            bingoNameList.Clear();
            bingoDown = false;
            onlySendOnce = false;
            bingoCooldown.Stop();
        }
        private void bankLotteryTimer_Tick(object sender, EventArgs e)
        {
            bankLotteryTimer.Stop();
            irc.sendChatMessage("Die Bank gibt nun ihre überflüssigen " + this.currencyName + " raus!");
            List<string> winners = new List<string>();
            int counter = 0;
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                if (i - counter > beggers.Count - 1)
                {
                    continue;
                }
                int tmp = rnd.Next(0, beggers.Count - 1);
                winners.Add(beggers[tmp]);
                counter++;
                beggers.RemoveAt(tmp);
            }
            if (winners.Count < 5)
            {
                for (int i = winners.Count; i < 5; i++)
                {
                    winners.Add("bot_horican");
                }
            }
            string winnerStr = winners[0] + ", " + winners[1] + ", " + winners[2] + ", " + winners[3] + ", " + winners[4];


            irc.sendChatMessage( $"Die ärmsten Schlucker die sich gemeldet haben sind: " + winnerStr + $". Herzlichen Glückwunsch an die Gewinner von jeweils 2000 {this.currencyName}!");
            addPoints(winners[0], 2000);
            addPoints(winners[1], 2000);
            addPoints(winners[2], 2000);
            addPoints(winners[3], 2000);
            addPoints(winners[4], 2000);
            //addPoints("demmoubot", -(10000));
            beggers.Clear();
            lotteryBankBlocked = false;
        }
        private void modChatBox_TextChanged(object sender, EventArgs e)
        {
            modChatBox.SelectionStart = modChatBox.Text.Length;
            modChatBox.ScrollToCaret();
        }
        private void smashRegistrationTimer_Tick(object sender, EventArgs e)
        {
            smashRegistrationTimer.Stop();
            if (smashers.Count == 1)
            {
                irc.sendChatMessage("Es sieht so aus als wenn du nicht genug für den Kampf trainiert hast. Viel glück beim nächsten mal.");
                starttime = DateTime.Now;
                smashCooldown.Start();
                smashGameStarted = true;
            }
            else
            {
                irc.sendChatMessage("ALAAAAAAAARM!!!!!!! Es beginnt! Das Böse muss geschlagen werden! Jeder prüft seine Superhelden-Fähigkeiten und zieht sein bestes Siegeroutfit an. Los alle Superhelden in die Luft, die die nicht fliegen können ab in die Super Rakete und lasst uns das Böse bekämpfen");
                smashFinaleTimer.Start();
                //}
            }
        }
        private void smashFinaleTimer_Tick(object sender, EventArgs e)
        {
            smashCooldown.Start();
            starttime = DateTime.Now;
            smashFinaleTimer.Stop();
            smashGameStarted = true;
            string winners = "";
            Random rnd = new Random();
            int amountOfUserRegistered = 0;
            amountOfUserRegistered = smashers.Count;
            for (int i = 0; i < amountOfUserRegistered; i++)
            {
                if (rnd.Next(0, 100) > 60)
                {
                    double winnermoney = Math.Round(smashMoney[i] * 1.7);
                    int moneyFinal = (int)winnermoney;
                    smashWinners.Add(smashers[i]);
                    smashWinnerMoney.Add(moneyFinal);
                    addPoints(smashers[i], moneyFinal);
                    winners += smashers[i] + "(" + moneyFinal + "), ";
                }
                else
                {
                    if (rnd.Next(0, 100) > 50)
                    {
                        addPoints(userName, smashMoney[i]);
                    }
                }
            }
            if (winners.Length > 2)
            {
                winners.Remove(winners.Length - 3, 2);
                winners += ".";
            }
            if ((100 / amountOfUserRegistered * smashWinners.Count) == 100)
            {
                irc.sendChatMessage("Es scheint so als wäre es nur eine Katze die auf den Alarmknopf gekommen ist, deshalb überleben alle Superhelden - Puh Glück gehabt...");
                sendSmashResults(winners);
                return;
            }
            if ((100 / amountOfUserRegistered * smashWinners.Count) > 74)
            {
                irc.sendChatMessage("Einige der Superhelden haben wohl mehr Pizza gegessen als zu trainieren. Sie lassen ihr Leben im Kampf.");
                sendSmashResults(winners);
                return;
            }
            if ((100 / amountOfUserRegistered * smashWinners.Count) > 24)
            {
                irc.sendChatMessage("Einer der Superhelden hat sich einfach hinterhältig zurückgezogen und sein Team im Stich gelassen.");
                sendSmashResults(winners);
                return;
            }
            if ((100 / amountOfUserRegistered * smashWinners.Count) > 0)
            {
                irc.sendChatMessage("Der Kampf lief erfolgreich! Das Böse wurde besiegt und alle überleben. Doch einige der Superhelden wollten nicht teilen und bringen ihre Kollegen von hinten um.");
                sendSmashResults(winners);
                return;
            }
            if ((100 / amountOfUserRegistered * smashWinners.Count) == 0)
            {
                irc.sendChatMessage("Es gab eine riesige EXPLOSION!!! Sie haben zwar gewonnen aber auch ihr Leben im Kampf gelassen. Den Bürgermeister freuts, er muss keine Siegesboni auszahlen.");
                sendSmashResults(winners);
                return;
            }
        }
        private void sendSmashResults(string winner)
        {
            irc.sendChatMessage("Der Kampf ist entschieden. Die Überlebenden sind: " + winner);
        }
        private void smashCooldown_Tick(object sender, EventArgs e)
        {
            irc.sendChatMessage("Die Superhelden haben ihre Kräfte wieder aufgeladen! Um einen neuen auftrag zu erhalten schreibt !smash [" + this.currencyName + "] ein!");
            sentMessage = false;
            smashGameStarted = false;
            smashWinLottery.Clear();
            smashMoney.Clear();
            smashWinnerMoney.Clear();
            smashWinners.Clear();
            smashers.Clear();
            smashCooldown.Stop();
        }
        private void bombExplodeTimer_Tick(object sender, EventArgs e)
        {
            bombGameNameChatSayTimer.Stop();
            irc.sendChatMessage("BOOOOOOM!!!! Die Bombe ist explodiert! Der Boden wird stark erschüttert. Ein kleiner Riss tut sich auf und " + bombCarrier + " findet 500 " + this.currencyName + ".");
            addPoints(bombCarrier, 500);
            bombGameOngoing = false;
            bombExplodeTimer.Stop();
        }
        private void bombGameNameChatSayTimer_Tick(object sender, EventArgs e)
        {
            irc.sendChatMessage("Aktueller Bombenträger ist: " + bombCarrier);
        }
        private void parseCsv()
        {
            using (var reader = new StreamReader(@"C:\Users\Demmou\Desktop\horibla.csv"))
            {
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                string[] buffer = new string[20];
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    listA.Add(line);
                }
                for (int i = 0; i < listA.Count; i++)
                {
                    buffer = listA[i].Split(',');
                    addPoints(buffer[0], int.Parse(buffer[2]));
                    addTime(buffer[0], int.Parse(buffer[6]));
                }
            }



        }
        private void sendModMessage(string username, string Message)
        {
            Chatters AllChatters = chatClient.GetChatters(this.channelName);
            foreach (string moderator in AllChatters.Moderators)
            {
                foreach (string moderators in AllChatters.Moderators)
                {
                    if (username != moderators)
                    {
                        irc.sendWhisperMessage(moderators, username + " sagt: " + Message);
                    }
                }
            }
        }
        private void modChatLabel_Click(object sender, EventArgs e)
        {

        }
        private void sendButtonModChat_Click(object sender, EventArgs e)
        {
            sendModMessage(this.channelName, modChatWindowBox.Text);
            modChatBox.Text += "Du: " + modChatWindowBox.Text + Environment.NewLine;
            modChatWindowBox.Clear();
        }
        private void modChatWindowBox_TextChanged(object sender, EventArgs e)
        {
            modChatBox.SelectionStart = modChatBox.Text.Length;
            modChatBox.ScrollToCaret();
        }
        private void modChatWindowBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                sendModMessage(this.channelName, modChatWindowBox.Text);
                modChatBox.Text += "Du: " + modChatWindowBox.Text + Environment.NewLine;
                modChatWindowBox.Clear();
            }
        }
        private void connectButton_Click(object sender, EventArgs e)
        {
            irc.joinRoom(this.channelName);
            chatThread = new Thread(getMessage);
            chatThread.Start();
            viewerBoxTimer.Start();
            commandSpamTimer.Start();
            pointChatTimer.Start();
            messageCycleTimer.Start();
            viewerBoxTimer_Tick(null, null);
        }
        private void disconnectButton_Click(object sender, EventArgs e)
        {
            irc.leaveRoom();
            viewerBoxTimer.Stop();
            commandSpamTimer.Stop();
            pointChatTimer.Stop();
            messageCycleTimer.Stop();

        }
        class IrcClient
        {
            private string username;
            private string channel;
            public TcpClient tcpClient;
            private StreamReader inputStream;
            private StreamWriter outputstream;
            public IrcClient(string ip, int port, string userName, string password, string channel)
            {
                this.username = userName;
                this.channel = channel;
                // creating tcpClient that is going to be the bot.
                tcpClient = new TcpClient(ip, port);
                // initializing in- and outgoing streams of the IRC-Chat
                inputStream = new StreamReader(tcpClient.GetStream());
                outputstream = new StreamWriter(tcpClient.GetStream());
                // Logging in with Twitchname
                outputstream.WriteLine("PASS " + password);
                outputstream.WriteLine("NICK " + userName);
                outputstream.WriteLine("USER " + userName + " 8 * :" + userName);
                // requesting permissions for membership and commands
                outputstream.WriteLine("CAP REQ :twitch.tv/membership");
                outputstream.WriteLine("CAP REQ :twitch.tv/tags");
                outputstream.WriteLine("CAP REQ :twitch.tv/commands");
                outputstream.WriteLine("JOIN #" + this.channel + "");
                // flushing
                outputstream.Flush();
            }
            // request to join channel
            public void joinRoom(string channel)
            {
                outputstream.WriteLine("JOIN #" + channel);
            }
            public void leaveRoom()
            {
                outputstream.Close();
                inputStream.Close();
            }
            public void sendIrcMessage(string message)
            {
                try
                {
                    outputstream.WriteLine(message);
                    outputstream.Flush();
                }
                catch (Exception e)
                {
                    Console.Beep();
                }

            }
            public void sendChatMessage(string message)
            {
                sendIrcMessage(":" + this.username + "!" + this.username + "@" + this.username + ".tmi.twitch.tv PRIVMSG #" + this.channel + " :" + message);
            }
            public void sendWhisperMessage(string recipient, string message)
            {
                sendChatMessage($"/w {recipient} {message}");
            }
            public void pingResponse(string content)
            {
                sendIrcMessage("PONG tmi.twitch.tv\r\n");
            }
            public void processMessage(string msg)
            {
                if (msg.Split(' ')[0].Equals("PING"))
                {
                    pingResponse(msg.Split(' ')[1]);
                }
            }
            public string readMessage()
            {
                string message = "";
                message = inputStream.ReadLine();
                Console.Write(message);
                processMessage(message);
                return message;
            }
        }
        class CommandSpamUser
        {
            public string usern;
            public DateTime timeOfMessage;
        }
        public class csvFile
        {
            private string csvPath;
            public csvFile(string path)
            {
                
                csvPath = path;
            }
            public string getPath()
            {
                return this.csvPath;
            }
            public void createFile(string name)
            {
                File.Create(@name + ".csv");
            }
            public void writeLine(string command, string message)
            {
                StringBuilder csvContent = new StringBuilder();
                csvContent.AppendLine(command + ";" + message);
                File.AppendAllText(this.csvPath, csvContent.ToString());
            }
            public void writeUser(string username)
            {
                StringBuilder csvContent = new StringBuilder();
                csvContent.AppendLine(username + ";");
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
            public void deleteAllContentInCSVFile()
            {
                File.WriteAllText(this.csvPath, string.Empty);
                return;
            }
        }
        #region raffle
        #region rafflebuttons
        private void raffleStartButton_Click(object sender, EventArgs e)
        {
            irc.sendChatMessage("Ein Giveaway hat gestartet! !beitreten um beizutreten! Viel Glück an Alle!");
            raffleOngoing = true;
        }
        // button2 = raffleEndButton
        private void button2_Click(object sender, EventArgs e)
        {
            raffleEnd();
        }
        private void raffleTwoMinutes_Click(object sender, EventArgs e)
        {

            // timer 2 minutes
            raffleSendMessage(2);
            raffleTwoMinuteTimer.Start();
            raffleOngoing = true;
        }
        private void raffleFiveMinutes_Click(object sender, EventArgs e)
        {
            raffleSendMessage(5);
            raffleFiveMinuteTimer.Start();
            raffleOngoing = true;
        }
        private void raffleTenMinutes_Click(object sender, EventArgs e)
        {
            raffleSendMessage(10);
            raffleTenMinuteTimer.Start();
            raffleOngoing = true;
        }
        private void raffleFifteenMinutes_Click(object sender, EventArgs e)
        {
            raffleSendMessage(15);
            raffleFifteenMinuteTimer.Start();
            raffleOngoing = true;
        }
        private void raffleClearButton_Click(object sender, EventArgs e)
        {
            raffleParticipantBox.Items.Clear();
            raffleWinnerBox.Items.Clear();
            raffleParticipants.Clear();
        }
        #endregion
        #region raffletimers
        private void raffleTwoMinuteTimer_Tick(object sender, EventArgs e)
        {
            raffleFiveMinuteTimer.Stop();
            raffleEnd();
        }
        private void raffleFiveMinuteTimer_Tick(object sender, EventArgs e)
        {
            raffleEnd();
        }
        private void raffleTenMinuteTimer_Tick(object sender, EventArgs e)
        {
            raffleEnd();
        }
        private void raffleFifteenMinuteTimer_Tick(object sender, EventArgs e)
        {
            raffleEnd();
        }


        #endregion
        #region rafflefunctions
        private void raffleJoin(string username)
        {
            raffleParticipants.Add(username);
            raffleParticipantBox.Items.Add(username);
            irc.sendWhisperMessage(username, "Du bist beim Giveaway dabei! Viel Glück!");
        }
        private void raffleEnd()
        {
            raffleTwoMinuteTimer.Stop();
            raffleFiveMinuteTimer.Stop();
            raffleTenMinuteTimer.Stop();
            raffleFifteenMinuteTimer.Stop();
            raffleOngoing = false;

            Random rnd = new Random();
            int winner = rnd.Next(0, raffleParticipants.Count - 1);
            raffleWinnerBox.Items.Clear();
            raffleWinnerBox.Items.Add(raffleParticipants[winner]);
            irc.sendChatMessage("Herzlichen Glückwunsch an " + raffleParticipants[winner] + ". Du hast Gewonnen! Es waren " + amountOfParticipants + " Leute angemeldet!");
        }
        private void raffleSendMessage(int minutes)
        {
            irc.sendChatMessage("Ein Giveaway hat gestartet! !beitreten um beizutreten! Viel Glück an Alle! In " + minutes + " Minuten wird ein Gewinner ausgelost");
        }
        #endregion

        #endregion
        private void viewerGamesStartButton_Click(object sender, EventArgs e)
        {
            viewerGamesListOpen = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            viewerGamesListOpen = false;
        }
        private void selectRandomWinnerViewerGameButton_Click(object sender, EventArgs e)
        {
            irc.sendChatMessage(viewerGamesParticipants[0] + " du wurdest ausgewählt zum mitspielen!");
            viewerGamesParticipantsBox.Items.RemoveAt(0);
            viewerGamesParticipants.RemoveAt(0);

        }
        private void quitButton_Click(object sender, EventArgs e)
        {
            irc.leaveRoom();
            try { serverStream.Dispose(); } catch { }
            Environment.Exit(0);
        }
        private void settingsButton_Click(object sender, EventArgs e)
        {
            settingsForm settings = new settingsForm();
            settings.Show();
        }
        private void bingoMessageSaidTimer_Tick(object sender, EventArgs e)
        {
            bingoMessageSaid = false;
            bingoMessageSaidTimer.Stop();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void muenzeTimer_Tick(object sender, EventArgs e)
        {
            muenzeCooldown.Start();
            muenzeTimer.Stop();
            
            muenzeCooldownBool = true;
            muenzeOpen = false;
            Random rnd = new Random();
            if (rnd.Next(0,100) > 50)
            {
                foreach(var element in muenzeKopf)
                {
                    addPoints(element, 200);
                }
                irc.sendChatMessage("Die Münze dreht sich immer langsamer. Herzlichen Glückwunsch an alle die auf Kopf gesetzt haben.");
            } else
            {
                foreach (var element in muenzeZahl)
                {
                    addPoints(element, 200);
                }
                irc.sendChatMessage("Die Münze dreht sich immer langsamer. Herzlichen Glückwunsch an alle die auf Zahl gesetzt haben.");
            }
            muenzeKopf.Clear();
            muenzeZahl.Clear();
        }
        private void muenzeCooldown_Tick(object sender, EventArgs e)
        {
            muenzeCooldownBool = false;
        }

    }
}