namespace TwitchBot
{
    partial class DemmouBot
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DemmouBot));
            this.chattyBox = new System.Windows.Forms.RichTextBox();
            this.viewerList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.viewerBoxTimer = new System.Windows.Forms.Timer(this.components);
            this.pointTimer = new System.Windows.Forms.Timer(this.components);
            this.botChatBox = new System.Windows.Forms.RichTextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.commandSpamTimer = new System.Windows.Forms.Timer(this.components);
            this.pointChatTimer = new System.Windows.Forms.Timer(this.components);
            this.messageCycleTimer = new System.Windows.Forms.Timer(this.components);
            this.commandModSayTimer = new System.Windows.Forms.Timer(this.components);
            this.bingoTimer = new System.Windows.Forms.Timer(this.components);
            this.bingoCooldown = new System.Windows.Forms.Timer(this.components);
            this.bankLotteryTimer = new System.Windows.Forms.Timer(this.components);
            this.modChatBox = new System.Windows.Forms.RichTextBox();
            this.smashRegistrationTimer = new System.Windows.Forms.Timer(this.components);
            this.smashCooldown = new System.Windows.Forms.Timer(this.components);
            this.smashFinaleTimer = new System.Windows.Forms.Timer(this.components);
            this.bombExplodeTimer = new System.Windows.Forms.Timer(this.components);
            this.bombGameNameChatSayTimer = new System.Windows.Forms.Timer(this.components);
            this.modChatLabel = new System.Windows.Forms.Label();
            this.modChatWindowBox = new System.Windows.Forms.RichTextBox();
            this.sendButtonModChat = new System.Windows.Forms.Button();
            this.connectButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.raffleStartButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.raffleTwoMinutes = new System.Windows.Forms.Button();
            this.raffleFifteenMinutes = new System.Windows.Forms.Button();
            this.raffleFiveMinutes = new System.Windows.Forms.Button();
            this.raffleTenMinutes = new System.Windows.Forms.Button();
            this.raffleWinnerLabel = new System.Windows.Forms.Label();
            this.raffleParticipantBox = new System.Windows.Forms.ListBox();
            this.raffleWinnerBox = new System.Windows.Forms.ListBox();
            this.raffleTwoMinuteTimer = new System.Windows.Forms.Timer(this.components);
            this.raffleFiveMinuteTimer = new System.Windows.Forms.Timer(this.components);
            this.raffleTenMinuteTimer = new System.Windows.Forms.Timer(this.components);
            this.raffleFifteenMinuteTimer = new System.Windows.Forms.Timer(this.components);
            this.raffleClearButton = new System.Windows.Forms.Button();
            this.viewerGamesParticipantsBox = new System.Windows.Forms.ListBox();
            this.viewerGamesStartButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.selectRandomWinnerViewerGameButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.bingoMessageSaidTimer = new System.Windows.Forms.Timer(this.components);
            this.postkarteLabel = new System.Windows.Forms.Label();
            this.bildZeichnenLabel = new System.Windows.Forms.Label();
            this.postkarteListBox = new System.Windows.Forms.ListBox();
            this.bildZeichnenListBox = new System.Windows.Forms.ListBox();
            this.muenzeTimer = new System.Windows.Forms.Timer(this.components);
            this.muenzeCooldown = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // chattyBox
            // 
            this.chattyBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chattyBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chattyBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chattyBox.ForeColor = System.Drawing.SystemColors.Window;
            this.chattyBox.Location = new System.Drawing.Point(12, 12);
            this.chattyBox.Name = "chattyBox";
            this.chattyBox.ReadOnly = true;
            this.chattyBox.Size = new System.Drawing.Size(534, 199);
            this.chattyBox.TabIndex = 0;
            this.chattyBox.Text = "";
            this.chattyBox.TextChanged += new System.EventHandler(this.chattyBox_TextChanged);
            // 
            // viewerList
            // 
            this.viewerList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.viewerList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.viewerList.ForeColor = System.Drawing.SystemColors.Window;
            this.viewerList.FormattingEnabled = true;
            this.viewerList.Location = new System.Drawing.Point(579, 39);
            this.viewerList.Name = "viewerList";
            this.viewerList.Size = new System.Drawing.Size(148, 455);
            this.viewerList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(575, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Viewers";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // viewerBoxTimer
            // 
            this.viewerBoxTimer.Interval = 300000;
            this.viewerBoxTimer.Tick += new System.EventHandler(this.viewerBoxTimer_Tick);
            // 
            // pointTimer
            // 
            this.pointTimer.Enabled = true;
            this.pointTimer.Interval = 600000;
            this.pointTimer.Tick += new System.EventHandler(this.pointTimer_Tick);
            // 
            // botChatBox
            // 
            this.botChatBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.botChatBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.botChatBox.ForeColor = System.Drawing.SystemColors.Window;
            this.botChatBox.Location = new System.Drawing.Point(12, 217);
            this.botChatBox.Name = "botChatBox";
            this.botChatBox.Size = new System.Drawing.Size(484, 48);
            this.botChatBox.TabIndex = 3;
            this.botChatBox.Text = "";
            this.botChatBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.botChatBox_KeyPress);
            // 
            // sendButton
            // 
            this.sendButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sendButton.ForeColor = System.Drawing.SystemColors.Control;
            this.sendButton.Location = new System.Drawing.Point(502, 217);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(44, 48);
            this.sendButton.TabIndex = 4;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // commandSpamTimer
            // 
            this.commandSpamTimer.Interval = 1000;
            this.commandSpamTimer.Tick += new System.EventHandler(this.commandSpamTimer_Tick);
            // 
            // pointChatTimer
            // 
            this.pointChatTimer.Enabled = true;
            this.pointChatTimer.Interval = 3600000;
            this.pointChatTimer.Tick += new System.EventHandler(this.pointChatTimer_Tick);
            // 
            // messageCycleTimer
            // 
            this.messageCycleTimer.Enabled = true;
            this.messageCycleTimer.Interval = 330000;
            this.messageCycleTimer.Tick += new System.EventHandler(this.messageCycleTimer_Tick);
            // 
            // commandModSayTimer
            // 
            this.commandModSayTimer.Enabled = true;
            this.commandModSayTimer.Interval = 15000;
            this.commandModSayTimer.Tick += new System.EventHandler(this.commandModSayTimer_Tick);
            // 
            // bingoTimer
            // 
            this.bingoTimer.Interval = 90000;
            this.bingoTimer.Tick += new System.EventHandler(this.bingoTimer_Tick);
            // 
            // bingoCooldown
            // 
            this.bingoCooldown.Interval = 600000;
            this.bingoCooldown.Tick += new System.EventHandler(this.bingoCooldown_Tick);
            // 
            // bankLotteryTimer
            // 
            this.bankLotteryTimer.Interval = 200000;
            this.bankLotteryTimer.Tick += new System.EventHandler(this.bankLotteryTimer_Tick);
            // 
            // modChatBox
            // 
            this.modChatBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.modChatBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.modChatBox.ForeColor = System.Drawing.SystemColors.Window;
            this.modChatBox.Location = new System.Drawing.Point(12, 305);
            this.modChatBox.Name = "modChatBox";
            this.modChatBox.ReadOnly = true;
            this.modChatBox.Size = new System.Drawing.Size(534, 147);
            this.modChatBox.TabIndex = 5;
            this.modChatBox.Text = "";
            this.modChatBox.TextChanged += new System.EventHandler(this.modChatBox_TextChanged);
            // 
            // smashRegistrationTimer
            // 
            this.smashRegistrationTimer.Interval = 120000;
            this.smashRegistrationTimer.Tick += new System.EventHandler(this.smashRegistrationTimer_Tick);
            // 
            // smashCooldown
            // 
            this.smashCooldown.Interval = 600000;
            this.smashCooldown.Tick += new System.EventHandler(this.smashCooldown_Tick);
            // 
            // smashFinaleTimer
            // 
            this.smashFinaleTimer.Interval = 40000;
            this.smashFinaleTimer.Tick += new System.EventHandler(this.smashFinaleTimer_Tick);
            // 
            // bombExplodeTimer
            // 
            this.bombExplodeTimer.Interval = 47000;
            this.bombExplodeTimer.Tick += new System.EventHandler(this.bombExplodeTimer_Tick);
            // 
            // bombGameNameChatSayTimer
            // 
            this.bombGameNameChatSayTimer.Interval = 21000;
            this.bombGameNameChatSayTimer.Tick += new System.EventHandler(this.bombGameNameChatSayTimer_Tick);
            // 
            // modChatLabel
            // 
            this.modChatLabel.AutoSize = true;
            this.modChatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.modChatLabel.ForeColor = System.Drawing.Color.White;
            this.modChatLabel.Location = new System.Drawing.Point(8, 282);
            this.modChatLabel.Name = "modChatLabel";
            this.modChatLabel.Size = new System.Drawing.Size(81, 20);
            this.modChatLabel.TabIndex = 6;
            this.modChatLabel.Text = "ModChat";
            this.modChatLabel.Click += new System.EventHandler(this.modChatLabel_Click);
            // 
            // modChatWindowBox
            // 
            this.modChatWindowBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.modChatWindowBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.modChatWindowBox.ForeColor = System.Drawing.Color.White;
            this.modChatWindowBox.Location = new System.Drawing.Point(12, 458);
            this.modChatWindowBox.Name = "modChatWindowBox";
            this.modChatWindowBox.Size = new System.Drawing.Size(484, 36);
            this.modChatWindowBox.TabIndex = 7;
            this.modChatWindowBox.Text = "";
            this.modChatWindowBox.TextChanged += new System.EventHandler(this.modChatWindowBox_TextChanged);
            this.modChatWindowBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.modChatWindowBox_KeyPress);
            // 
            // sendButtonModChat
            // 
            this.sendButtonModChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sendButtonModChat.ForeColor = System.Drawing.SystemColors.Control;
            this.sendButtonModChat.Location = new System.Drawing.Point(503, 459);
            this.sendButtonModChat.Name = "sendButtonModChat";
            this.sendButtonModChat.Size = new System.Drawing.Size(43, 35);
            this.sendButtonModChat.TabIndex = 8;
            this.sendButtonModChat.Text = "Send";
            this.sendButtonModChat.UseVisualStyleBackColor = false;
            this.sendButtonModChat.Click += new System.EventHandler(this.sendButtonModChat_Click);
            // 
            // connectButton
            // 
            this.connectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.connectButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("connectButton.BackgroundImage")));
            this.connectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.connectButton.Location = new System.Drawing.Point(12, 712);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(61, 71);
            this.connectButton.TabIndex = 9;
            this.connectButton.UseVisualStyleBackColor = false;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.disconnectButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("disconnectButton.BackgroundImage")));
            this.disconnectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.disconnectButton.Location = new System.Drawing.Point(79, 712);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(61, 71);
            this.disconnectButton.TabIndex = 10;
            this.disconnectButton.UseVisualStyleBackColor = false;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // raffleStartButton
            // 
            this.raffleStartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.raffleStartButton.ForeColor = System.Drawing.SystemColors.Control;
            this.raffleStartButton.Location = new System.Drawing.Point(12, 543);
            this.raffleStartButton.Name = "raffleStartButton";
            this.raffleStartButton.Size = new System.Drawing.Size(75, 72);
            this.raffleStartButton.TabIndex = 11;
            this.raffleStartButton.Text = "Raffle Start";
            this.raffleStartButton.UseVisualStyleBackColor = false;
            this.raffleStartButton.Click += new System.EventHandler(this.raffleStartButton_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(12, 631);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 72);
            this.button2.TabIndex = 12;
            this.button2.Text = "Raffle End";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // raffleTwoMinutes
            // 
            this.raffleTwoMinutes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.raffleTwoMinutes.ForeColor = System.Drawing.SystemColors.Control;
            this.raffleTwoMinutes.Location = new System.Drawing.Point(189, 546);
            this.raffleTwoMinutes.Name = "raffleTwoMinutes";
            this.raffleTwoMinutes.Size = new System.Drawing.Size(75, 32);
            this.raffleTwoMinutes.TabIndex = 14;
            this.raffleTwoMinutes.Text = "2 Minutes";
            this.raffleTwoMinutes.UseVisualStyleBackColor = false;
            this.raffleTwoMinutes.Click += new System.EventHandler(this.raffleTwoMinutes_Click);
            // 
            // raffleFifteenMinutes
            // 
            this.raffleFifteenMinutes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.raffleFifteenMinutes.ForeColor = System.Drawing.SystemColors.Control;
            this.raffleFifteenMinutes.Location = new System.Drawing.Point(191, 668);
            this.raffleFifteenMinutes.Name = "raffleFifteenMinutes";
            this.raffleFifteenMinutes.Size = new System.Drawing.Size(74, 34);
            this.raffleFifteenMinutes.TabIndex = 15;
            this.raffleFifteenMinutes.Text = "15 Minutes";
            this.raffleFifteenMinutes.UseVisualStyleBackColor = false;
            this.raffleFifteenMinutes.Click += new System.EventHandler(this.raffleFifteenMinutes_Click);
            // 
            // raffleFiveMinutes
            // 
            this.raffleFiveMinutes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.raffleFiveMinutes.ForeColor = System.Drawing.SystemColors.Control;
            this.raffleFiveMinutes.Location = new System.Drawing.Point(189, 584);
            this.raffleFiveMinutes.Name = "raffleFiveMinutes";
            this.raffleFiveMinutes.Size = new System.Drawing.Size(74, 31);
            this.raffleFiveMinutes.TabIndex = 16;
            this.raffleFiveMinutes.Text = "5 Minutes";
            this.raffleFiveMinutes.UseVisualStyleBackColor = false;
            this.raffleFiveMinutes.Click += new System.EventHandler(this.raffleFiveMinutes_Click);
            // 
            // raffleTenMinutes
            // 
            this.raffleTenMinutes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.raffleTenMinutes.ForeColor = System.Drawing.SystemColors.Control;
            this.raffleTenMinutes.Location = new System.Drawing.Point(190, 631);
            this.raffleTenMinutes.Name = "raffleTenMinutes";
            this.raffleTenMinutes.Size = new System.Drawing.Size(75, 31);
            this.raffleTenMinutes.TabIndex = 17;
            this.raffleTenMinutes.Text = "10 Minutes";
            this.raffleTenMinutes.UseVisualStyleBackColor = false;
            this.raffleTenMinutes.Click += new System.EventHandler(this.raffleTenMinutes_Click);
            // 
            // raffleWinnerLabel
            // 
            this.raffleWinnerLabel.AutoSize = true;
            this.raffleWinnerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.raffleWinnerLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.raffleWinnerLabel.Location = new System.Drawing.Point(146, 712);
            this.raffleWinnerLabel.Name = "raffleWinnerLabel";
            this.raffleWinnerLabel.Size = new System.Drawing.Size(94, 17);
            this.raffleWinnerLabel.TabIndex = 19;
            this.raffleWinnerLabel.Text = "Raffle Winner";
            // 
            // raffleParticipantBox
            // 
            this.raffleParticipantBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.raffleParticipantBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.raffleParticipantBox.ForeColor = System.Drawing.SystemColors.Window;
            this.raffleParticipantBox.FormattingEnabled = true;
            this.raffleParticipantBox.Location = new System.Drawing.Point(93, 546);
            this.raffleParticipantBox.Name = "raffleParticipantBox";
            this.raffleParticipantBox.Size = new System.Drawing.Size(90, 156);
            this.raffleParticipantBox.TabIndex = 20;
            // 
            // raffleWinnerBox
            // 
            this.raffleWinnerBox.BackColor = System.Drawing.Color.Gray;
            this.raffleWinnerBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.raffleWinnerBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.raffleWinnerBox.ForeColor = System.Drawing.Color.White;
            this.raffleWinnerBox.FormattingEnabled = true;
            this.raffleWinnerBox.ItemHeight = 16;
            this.raffleWinnerBox.Location = new System.Drawing.Point(149, 732);
            this.raffleWinnerBox.Name = "raffleWinnerBox";
            this.raffleWinnerBox.Size = new System.Drawing.Size(116, 16);
            this.raffleWinnerBox.TabIndex = 21;
            // 
            // raffleTwoMinuteTimer
            // 
            this.raffleTwoMinuteTimer.Interval = 120000;
            this.raffleTwoMinuteTimer.Tick += new System.EventHandler(this.raffleTwoMinuteTimer_Tick);
            // 
            // raffleFiveMinuteTimer
            // 
            this.raffleFiveMinuteTimer.Interval = 300000;
            // 
            // raffleTenMinuteTimer
            // 
            this.raffleTenMinuteTimer.Interval = 600000;
            // 
            // raffleFifteenMinuteTimer
            // 
            this.raffleFifteenMinuteTimer.Interval = 900000;
            // 
            // raffleClearButton
            // 
            this.raffleClearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.raffleClearButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.raffleClearButton.ForeColor = System.Drawing.SystemColors.Control;
            this.raffleClearButton.Location = new System.Drawing.Point(149, 755);
            this.raffleClearButton.Name = "raffleClearButton";
            this.raffleClearButton.Size = new System.Drawing.Size(116, 23);
            this.raffleClearButton.TabIndex = 22;
            this.raffleClearButton.Text = "Clear Raffle";
            this.raffleClearButton.UseVisualStyleBackColor = false;
            this.raffleClearButton.Click += new System.EventHandler(this.raffleClearButton_Click);
            // 
            // viewerGamesParticipantsBox
            // 
            this.viewerGamesParticipantsBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.viewerGamesParticipantsBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.viewerGamesParticipantsBox.ForeColor = System.Drawing.Color.White;
            this.viewerGamesParticipantsBox.FormattingEnabled = true;
            this.viewerGamesParticipantsBox.Location = new System.Drawing.Point(350, 546);
            this.viewerGamesParticipantsBox.Name = "viewerGamesParticipantsBox";
            this.viewerGamesParticipantsBox.Size = new System.Drawing.Size(94, 156);
            this.viewerGamesParticipantsBox.TabIndex = 23;
            // 
            // viewerGamesStartButton
            // 
            this.viewerGamesStartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.viewerGamesStartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.viewerGamesStartButton.ForeColor = System.Drawing.SystemColors.Control;
            this.viewerGamesStartButton.Location = new System.Drawing.Point(270, 546);
            this.viewerGamesStartButton.Name = "viewerGamesStartButton";
            this.viewerGamesStartButton.Size = new System.Drawing.Size(74, 32);
            this.viewerGamesStartButton.TabIndex = 24;
            this.viewerGamesStartButton.Text = "Start Viewergames";
            this.viewerGamesStartButton.UseVisualStyleBackColor = false;
            this.viewerGamesStartButton.Click += new System.EventHandler(this.viewerGamesStartButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(270, 584);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 31);
            this.button1.TabIndex = 25;
            this.button1.Text = "Stop Viewergames";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // selectRandomWinnerViewerGameButton
            // 
            this.selectRandomWinnerViewerGameButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.selectRandomWinnerViewerGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.selectRandomWinnerViewerGameButton.ForeColor = System.Drawing.Color.White;
            this.selectRandomWinnerViewerGameButton.Location = new System.Drawing.Point(271, 631);
            this.selectRandomWinnerViewerGameButton.Name = "selectRandomWinnerViewerGameButton";
            this.selectRandomWinnerViewerGameButton.Size = new System.Drawing.Size(73, 31);
            this.selectRandomWinnerViewerGameButton.TabIndex = 26;
            this.selectRandomWinnerViewerGameButton.Text = "Select next Viewer";
            this.selectRandomWinnerViewerGameButton.UseVisualStyleBackColor = false;
            this.selectRandomWinnerViewerGameButton.Click += new System.EventHandler(this.selectRandomWinnerViewerGameButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.quitButton.ForeColor = System.Drawing.Color.White;
            this.quitButton.Location = new System.Drawing.Point(630, 732);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(90, 46);
            this.quitButton.TabIndex = 27;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = false;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.settingsButton.ForeColor = System.Drawing.Color.White;
            this.settingsButton.Location = new System.Drawing.Point(534, 732);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(90, 46);
            this.settingsButton.TabIndex = 28;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = false;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // bingoMessageSaidTimer
            // 
            this.bingoMessageSaidTimer.Interval = 60000;
            this.bingoMessageSaidTimer.Tick += new System.EventHandler(this.bingoMessageSaidTimer_Tick);
            // 
            // postkarteLabel
            // 
            this.postkarteLabel.AutoSize = true;
            this.postkarteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.postkarteLabel.ForeColor = System.Drawing.Color.White;
            this.postkarteLabel.Location = new System.Drawing.Point(456, 546);
            this.postkarteLabel.Name = "postkarteLabel";
            this.postkarteLabel.Size = new System.Drawing.Size(86, 20);
            this.postkarteLabel.TabIndex = 30;
            this.postkarteLabel.Text = "Postkarte";
            // 
            // bildZeichnenLabel
            // 
            this.bildZeichnenLabel.AutoSize = true;
            this.bildZeichnenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bildZeichnenLabel.ForeColor = System.Drawing.Color.White;
            this.bildZeichnenLabel.Location = new System.Drawing.Point(477, 631);
            this.bildZeichnenLabel.Name = "bildZeichnenLabel";
            this.bildZeichnenLabel.Size = new System.Drawing.Size(39, 20);
            this.bildZeichnenLabel.TabIndex = 31;
            this.bildZeichnenLabel.Text = "Bild";
            // 
            // postkarteListBox
            // 
            this.postkarteListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.postkarteListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.postkarteListBox.ForeColor = System.Drawing.Color.White;
            this.postkarteListBox.FormattingEnabled = true;
            this.postkarteListBox.Location = new System.Drawing.Point(450, 584);
            this.postkarteListBox.Name = "postkarteListBox";
            this.postkarteListBox.Size = new System.Drawing.Size(100, 39);
            this.postkarteListBox.TabIndex = 33;
            // 
            // bildZeichnenListBox
            // 
            this.bildZeichnenListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bildZeichnenListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bildZeichnenListBox.ForeColor = System.Drawing.Color.White;
            this.bildZeichnenListBox.FormattingEnabled = true;
            this.bildZeichnenListBox.Location = new System.Drawing.Point(450, 663);
            this.bildZeichnenListBox.Name = "bildZeichnenListBox";
            this.bildZeichnenListBox.Size = new System.Drawing.Size(100, 39);
            this.bildZeichnenListBox.TabIndex = 34;
            this.bildZeichnenListBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // muenzeTimer
            // 
            this.muenzeTimer.Interval = 180000;
            this.muenzeTimer.Tick += new System.EventHandler(this.muenzeTimer_Tick);
            // 
            // muenzeCooldown
            // 
            this.muenzeCooldown.Interval = 600000;
            this.muenzeCooldown.Tick += new System.EventHandler(this.muenzeCooldown_Tick);
            // 
            // DemmouBot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(732, 795);
            this.Controls.Add(this.bildZeichnenListBox);
            this.Controls.Add(this.postkarteListBox);
            this.Controls.Add(this.bildZeichnenLabel);
            this.Controls.Add(this.postkarteLabel);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.selectRandomWinnerViewerGameButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.viewerGamesStartButton);
            this.Controls.Add(this.viewerGamesParticipantsBox);
            this.Controls.Add(this.raffleClearButton);
            this.Controls.Add(this.raffleWinnerBox);
            this.Controls.Add(this.raffleParticipantBox);
            this.Controls.Add(this.raffleWinnerLabel);
            this.Controls.Add(this.raffleTenMinutes);
            this.Controls.Add(this.raffleFiveMinutes);
            this.Controls.Add(this.raffleFifteenMinutes);
            this.Controls.Add(this.raffleTwoMinutes);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.raffleStartButton);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.sendButtonModChat);
            this.Controls.Add(this.modChatWindowBox);
            this.Controls.Add(this.modChatLabel);
            this.Controls.Add(this.modChatBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.botChatBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.viewerList);
            this.Controls.Add(this.chattyBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DemmouBot";
            this.Text = "Twitchbot by Demmou";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DemmouBot_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox chattyBox;
        private System.Windows.Forms.ListBox viewerList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer viewerBoxTimer;
        private System.Windows.Forms.Timer pointTimer;
        private System.Windows.Forms.RichTextBox botChatBox;
        private System.Windows.Forms.Timer commandSpamTimer;
        private System.Windows.Forms.Timer pointChatTimer;
        private System.Windows.Forms.Timer messageCycleTimer;
        private System.Windows.Forms.Timer commandModSayTimer;
        private System.Windows.Forms.Timer bingoTimer;
        private System.Windows.Forms.Timer bingoCooldown;
        private System.Windows.Forms.Timer bankLotteryTimer;
        private System.Windows.Forms.RichTextBox modChatBox;
        private System.Windows.Forms.Timer smashRegistrationTimer;
        private System.Windows.Forms.Timer smashCooldown;
        private System.Windows.Forms.Timer smashFinaleTimer;
        private System.Windows.Forms.Timer bombExplodeTimer;
        private System.Windows.Forms.Timer bombGameNameChatSayTimer;
        private System.Windows.Forms.Label modChatLabel;
        private System.Windows.Forms.RichTextBox modChatWindowBox;
        private System.Windows.Forms.Button sendButtonModChat;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button raffleStartButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button raffleTwoMinutes;
        private System.Windows.Forms.Button raffleFifteenMinutes;
        private System.Windows.Forms.Button raffleFiveMinutes;
        private System.Windows.Forms.Button raffleTenMinutes;
        private System.Windows.Forms.Label raffleWinnerLabel;
        private System.Windows.Forms.ListBox raffleParticipantBox;
        private System.Windows.Forms.ListBox raffleWinnerBox;
        private System.Windows.Forms.Timer raffleTwoMinuteTimer;
        private System.Windows.Forms.Timer raffleFiveMinuteTimer;
        private System.Windows.Forms.Timer raffleTenMinuteTimer;
        private System.Windows.Forms.Timer raffleFifteenMinuteTimer;
        private System.Windows.Forms.Button raffleClearButton;
        private System.Windows.Forms.ListBox viewerGamesParticipantsBox;
        private System.Windows.Forms.Button viewerGamesStartButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button selectRandomWinnerViewerGameButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button settingsButton;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Timer bingoMessageSaidTimer;
        private System.Windows.Forms.Label bildZeichnenLabel;
        private System.Windows.Forms.Label postkarteLabel;
        private System.Windows.Forms.ListBox bildZeichnenListBox;
        private System.Windows.Forms.ListBox postkarteListBox;
        private System.Windows.Forms.Timer muenzeTimer;
        private System.Windows.Forms.Timer muenzeCooldown;
    }
}

