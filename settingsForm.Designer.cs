namespace TwitchBot
{
    partial class settingsForm
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
            this.botNameTextBox = new System.Windows.Forms.TextBox();
            this.botNameLabel = new System.Windows.Forms.Label();
            this.setBotName = new System.Windows.Forms.Button();
            this.botAuthTokenLabel = new System.Windows.Forms.Label();
            this.authTokenTextBox = new System.Windows.Forms.TextBox();
            this.authTokenSetButton = new System.Windows.Forms.Button();
            this.clientIdTextBox = new System.Windows.Forms.TextBox();
            this.clientIdLabel = new System.Windows.Forms.Label();
            this.setClientIdButton = new System.Windows.Forms.Button();
            this.channelNameLabel = new System.Windows.Forms.Label();
            this.channelNameTextBox = new System.Windows.Forms.TextBox();
            this.channelSetButton = new System.Windows.Forms.Button();
            this.currencyName = new System.Windows.Forms.Label();
            this.currencyNameBox = new System.Windows.Forms.TextBox();
            this.setCurrencyNameButton = new System.Windows.Forms.Button();
            this.gameSwitchesLabel = new System.Windows.Forms.Label();
            this.bingoOnButton = new System.Windows.Forms.Button();
            this.bingoGameSwitchLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.smashOnButton = new System.Windows.Forms.Button();
            this.smashOffButton = new System.Windows.Forms.Button();
            this.verdoppelnOnButton = new System.Windows.Forms.Button();
            this.gambleOnButton = new System.Windows.Forms.Button();
            this.verdoppelnOffButton = new System.Windows.Forms.Button();
            this.gambleOffButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bingoStateLabel = new System.Windows.Forms.Label();
            this.smashStateLabel = new System.Windows.Forms.Label();
            this.verdoppelnStateLabel = new System.Windows.Forms.Label();
            this.gambleStateLabel = new System.Windows.Forms.Label();
            this.fiveMinuteMessageOnButton = new System.Windows.Forms.Button();
            this.fiveMinuteMessageButtonOff = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.demmouModeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // botNameTextBox
            // 
            this.botNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.botNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.botNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.botNameTextBox.ForeColor = System.Drawing.Color.White;
            this.botNameTextBox.Location = new System.Drawing.Point(29, 45);
            this.botNameTextBox.Name = "botNameTextBox";
            this.botNameTextBox.Size = new System.Drawing.Size(221, 19);
            this.botNameTextBox.TabIndex = 0;
            this.botNameTextBox.TextChanged += new System.EventHandler(this.botNameTextBox_TextChanged);
            // 
            // botNameLabel
            // 
            this.botNameLabel.AutoSize = true;
            this.botNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.botNameLabel.Location = new System.Drawing.Point(26, 9);
            this.botNameLabel.Name = "botNameLabel";
            this.botNameLabel.Size = new System.Drawing.Size(94, 22);
            this.botNameLabel.TabIndex = 1;
            this.botNameLabel.Text = "Bot Name:";
            // 
            // setBotName
            // 
            this.setBotName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.setBotName.Location = new System.Drawing.Point(257, 45);
            this.setBotName.Name = "setBotName";
            this.setBotName.Size = new System.Drawing.Size(81, 20);
            this.setBotName.TabIndex = 2;
            this.setBotName.Text = "Set Botname";
            this.setBotName.UseVisualStyleBackColor = false;
            this.setBotName.Click += new System.EventHandler(this.setBotName_Click);
            // 
            // botAuthTokenLabel
            // 
            this.botAuthTokenLabel.AutoSize = true;
            this.botAuthTokenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.botAuthTokenLabel.Location = new System.Drawing.Point(27, 76);
            this.botAuthTokenLabel.Name = "botAuthTokenLabel";
            this.botAuthTokenLabel.Size = new System.Drawing.Size(108, 22);
            this.botAuthTokenLabel.TabIndex = 3;
            this.botAuthTokenLabel.Text = "Auth Token:";
            // 
            // authTokenTextBox
            // 
            this.authTokenTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.authTokenTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.authTokenTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.authTokenTextBox.ForeColor = System.Drawing.Color.White;
            this.authTokenTextBox.Location = new System.Drawing.Point(29, 110);
            this.authTokenTextBox.Name = "authTokenTextBox";
            this.authTokenTextBox.PasswordChar = '*';
            this.authTokenTextBox.Size = new System.Drawing.Size(221, 19);
            this.authTokenTextBox.TabIndex = 4;
            // 
            // authTokenSetButton
            // 
            this.authTokenSetButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.authTokenSetButton.Location = new System.Drawing.Point(257, 110);
            this.authTokenSetButton.Name = "authTokenSetButton";
            this.authTokenSetButton.Size = new System.Drawing.Size(81, 19);
            this.authTokenSetButton.TabIndex = 5;
            this.authTokenSetButton.Text = "Set Auth Token";
            this.authTokenSetButton.UseVisualStyleBackColor = false;
            this.authTokenSetButton.Click += new System.EventHandler(this.authTokenSetButton_Click);
            // 
            // clientIdTextBox
            // 
            this.clientIdTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.clientIdTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clientIdTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.clientIdTextBox.ForeColor = System.Drawing.Color.White;
            this.clientIdTextBox.Location = new System.Drawing.Point(29, 175);
            this.clientIdTextBox.Name = "clientIdTextBox";
            this.clientIdTextBox.PasswordChar = '*';
            this.clientIdTextBox.Size = new System.Drawing.Size(221, 19);
            this.clientIdTextBox.TabIndex = 6;
            // 
            // clientIdLabel
            // 
            this.clientIdLabel.AutoSize = true;
            this.clientIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.clientIdLabel.Location = new System.Drawing.Point(27, 141);
            this.clientIdLabel.Name = "clientIdLabel";
            this.clientIdLabel.Size = new System.Drawing.Size(83, 22);
            this.clientIdLabel.TabIndex = 7;
            this.clientIdLabel.Text = "Client ID:";
            // 
            // setClientIdButton
            // 
            this.setClientIdButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.setClientIdButton.Location = new System.Drawing.Point(257, 175);
            this.setClientIdButton.Name = "setClientIdButton";
            this.setClientIdButton.Size = new System.Drawing.Size(81, 19);
            this.setClientIdButton.TabIndex = 8;
            this.setClientIdButton.Text = "Set Client ID";
            this.setClientIdButton.UseVisualStyleBackColor = false;
            this.setClientIdButton.Click += new System.EventHandler(this.setClientIdButton_Click);
            // 
            // channelNameLabel
            // 
            this.channelNameLabel.AutoSize = true;
            this.channelNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.channelNameLabel.Location = new System.Drawing.Point(27, 206);
            this.channelNameLabel.Name = "channelNameLabel";
            this.channelNameLabel.Size = new System.Drawing.Size(134, 22);
            this.channelNameLabel.TabIndex = 9;
            this.channelNameLabel.Text = "Channel Name:";
            // 
            // channelNameTextBox
            // 
            this.channelNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.channelNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.channelNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.channelNameTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.channelNameTextBox.Location = new System.Drawing.Point(29, 241);
            this.channelNameTextBox.Name = "channelNameTextBox";
            this.channelNameTextBox.Size = new System.Drawing.Size(221, 19);
            this.channelNameTextBox.TabIndex = 10;
            // 
            // channelSetButton
            // 
            this.channelSetButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.channelSetButton.ForeColor = System.Drawing.Color.White;
            this.channelSetButton.Location = new System.Drawing.Point(257, 241);
            this.channelSetButton.Name = "channelSetButton";
            this.channelSetButton.Size = new System.Drawing.Size(81, 19);
            this.channelSetButton.TabIndex = 11;
            this.channelSetButton.Text = "Set Channel";
            this.channelSetButton.UseVisualStyleBackColor = false;
            this.channelSetButton.Click += new System.EventHandler(this.channelSetButton_Click);
            // 
            // currencyName
            // 
            this.currencyName.AutoSize = true;
            this.currencyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.currencyName.Location = new System.Drawing.Point(354, 9);
            this.currencyName.Name = "currencyName";
            this.currencyName.Size = new System.Drawing.Size(135, 22);
            this.currencyName.TabIndex = 12;
            this.currencyName.Text = "Currency Name";
            // 
            // currencyNameBox
            // 
            this.currencyNameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.currencyNameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.currencyNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.currencyNameBox.Location = new System.Drawing.Point(358, 45);
            this.currencyNameBox.Name = "currencyNameBox";
            this.currencyNameBox.Size = new System.Drawing.Size(230, 19);
            this.currencyNameBox.TabIndex = 13;
            // 
            // setCurrencyNameButton
            // 
            this.setCurrencyNameButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.setCurrencyNameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.setCurrencyNameButton.ForeColor = System.Drawing.Color.White;
            this.setCurrencyNameButton.Location = new System.Drawing.Point(594, 45);
            this.setCurrencyNameButton.Name = "setCurrencyNameButton";
            this.setCurrencyNameButton.Size = new System.Drawing.Size(75, 20);
            this.setCurrencyNameButton.TabIndex = 14;
            this.setCurrencyNameButton.Text = "Set Currency";
            this.setCurrencyNameButton.UseVisualStyleBackColor = false;
            this.setCurrencyNameButton.Click += new System.EventHandler(this.setCurrencyNameButton_Click);
            // 
            // gameSwitchesLabel
            // 
            this.gameSwitchesLabel.AutoSize = true;
            this.gameSwitchesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gameSwitchesLabel.Location = new System.Drawing.Point(28, 282);
            this.gameSwitchesLabel.Name = "gameSwitchesLabel";
            this.gameSwitchesLabel.Size = new System.Drawing.Size(135, 22);
            this.gameSwitchesLabel.TabIndex = 15;
            this.gameSwitchesLabel.Text = "Game Switches";
            // 
            // bingoOnButton
            // 
            this.bingoOnButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bingoOnButton.Location = new System.Drawing.Point(88, 317);
            this.bingoOnButton.Name = "bingoOnButton";
            this.bingoOnButton.Size = new System.Drawing.Size(75, 26);
            this.bingoOnButton.TabIndex = 16;
            this.bingoOnButton.Text = "Bingo On";
            this.bingoOnButton.UseVisualStyleBackColor = false;
            this.bingoOnButton.Click += new System.EventHandler(this.bingoOnButton_Click);
            // 
            // bingoGameSwitchLabel
            // 
            this.bingoGameSwitchLabel.AutoSize = true;
            this.bingoGameSwitchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bingoGameSwitchLabel.Location = new System.Drawing.Point(29, 322);
            this.bingoGameSwitchLabel.Name = "bingoGameSwitchLabel";
            this.bingoGameSwitchLabel.Size = new System.Drawing.Size(44, 17);
            this.bingoGameSwitchLabel.TabIndex = 17;
            this.bingoGameSwitchLabel.Text = "Bingo";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.Location = new System.Drawing.Point(175, 317);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 26);
            this.button1.TabIndex = 18;
            this.button1.Text = "Bingo Off";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // smashOnButton
            // 
            this.smashOnButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.smashOnButton.Location = new System.Drawing.Point(88, 349);
            this.smashOnButton.Name = "smashOnButton";
            this.smashOnButton.Size = new System.Drawing.Size(75, 26);
            this.smashOnButton.TabIndex = 19;
            this.smashOnButton.Text = "Smash On";
            this.smashOnButton.UseVisualStyleBackColor = false;
            this.smashOnButton.Click += new System.EventHandler(this.smashOnButton_Click);
            // 
            // smashOffButton
            // 
            this.smashOffButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.smashOffButton.Location = new System.Drawing.Point(175, 349);
            this.smashOffButton.Name = "smashOffButton";
            this.smashOffButton.Size = new System.Drawing.Size(75, 26);
            this.smashOffButton.TabIndex = 20;
            this.smashOffButton.Text = "Smash Off";
            this.smashOffButton.UseVisualStyleBackColor = false;
            this.smashOffButton.Click += new System.EventHandler(this.smashOffButton_Click);
            // 
            // verdoppelnOnButton
            // 
            this.verdoppelnOnButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.verdoppelnOnButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.verdoppelnOnButton.Location = new System.Drawing.Point(88, 381);
            this.verdoppelnOnButton.Name = "verdoppelnOnButton";
            this.verdoppelnOnButton.Size = new System.Drawing.Size(75, 26);
            this.verdoppelnOnButton.TabIndex = 21;
            this.verdoppelnOnButton.Text = "Verdoppeln On";
            this.verdoppelnOnButton.UseVisualStyleBackColor = false;
            this.verdoppelnOnButton.Click += new System.EventHandler(this.verdoppelnOnButton_Click);
            // 
            // gambleOnButton
            // 
            this.gambleOnButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gambleOnButton.Location = new System.Drawing.Point(88, 413);
            this.gambleOnButton.Name = "gambleOnButton";
            this.gambleOnButton.Size = new System.Drawing.Size(75, 26);
            this.gambleOnButton.TabIndex = 22;
            this.gambleOnButton.Text = "Gamble On";
            this.gambleOnButton.UseVisualStyleBackColor = false;
            this.gambleOnButton.Click += new System.EventHandler(this.gambleOnButton_Click);
            // 
            // verdoppelnOffButton
            // 
            this.verdoppelnOffButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.verdoppelnOffButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.verdoppelnOffButton.Location = new System.Drawing.Point(175, 381);
            this.verdoppelnOffButton.Name = "verdoppelnOffButton";
            this.verdoppelnOffButton.Size = new System.Drawing.Size(75, 26);
            this.verdoppelnOffButton.TabIndex = 23;
            this.verdoppelnOffButton.Text = "Verdoppeln Off";
            this.verdoppelnOffButton.UseVisualStyleBackColor = false;
            this.verdoppelnOffButton.Click += new System.EventHandler(this.verdoppelnOffButton_Click);
            // 
            // gambleOffButton
            // 
            this.gambleOffButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gambleOffButton.Location = new System.Drawing.Point(175, 413);
            this.gambleOffButton.Name = "gambleOffButton";
            this.gambleOffButton.Size = new System.Drawing.Size(75, 26);
            this.gambleOffButton.TabIndex = 24;
            this.gambleOffButton.Text = "Gamble Off";
            this.gambleOffButton.UseVisualStyleBackColor = false;
            this.gambleOffButton.Click += new System.EventHandler(this.gambleOffButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(22, 354);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Smash";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(1, 386);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "Verdopplen";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(16, 413);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "Gamble";
            // 
            // bingoStateLabel
            // 
            this.bingoStateLabel.AutoSize = true;
            this.bingoStateLabel.Location = new System.Drawing.Point(265, 324);
            this.bingoStateLabel.Name = "bingoStateLabel";
            this.bingoStateLabel.Size = new System.Drawing.Size(35, 13);
            this.bingoStateLabel.TabIndex = 28;
            this.bingoStateLabel.Text = "label4";
            // 
            // smashStateLabel
            // 
            this.smashStateLabel.AutoSize = true;
            this.smashStateLabel.Location = new System.Drawing.Point(265, 356);
            this.smashStateLabel.Name = "smashStateLabel";
            this.smashStateLabel.Size = new System.Drawing.Size(35, 13);
            this.smashStateLabel.TabIndex = 29;
            this.smashStateLabel.Text = "label4";
            // 
            // verdoppelnStateLabel
            // 
            this.verdoppelnStateLabel.AutoSize = true;
            this.verdoppelnStateLabel.Location = new System.Drawing.Point(265, 388);
            this.verdoppelnStateLabel.Name = "verdoppelnStateLabel";
            this.verdoppelnStateLabel.Size = new System.Drawing.Size(35, 13);
            this.verdoppelnStateLabel.TabIndex = 30;
            this.verdoppelnStateLabel.Text = "label4";
            this.verdoppelnStateLabel.Click += new System.EventHandler(this.verdoppelnStateLabel_Click);
            // 
            // gambleStateLabel
            // 
            this.gambleStateLabel.AutoSize = true;
            this.gambleStateLabel.Location = new System.Drawing.Point(265, 420);
            this.gambleStateLabel.Name = "gambleStateLabel";
            this.gambleStateLabel.Size = new System.Drawing.Size(35, 13);
            this.gambleStateLabel.TabIndex = 31;
            this.gambleStateLabel.Text = "label4";
            // 
            // fiveMinuteMessageOnButton
            // 
            this.fiveMinuteMessageOnButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fiveMinuteMessageOnButton.Location = new System.Drawing.Point(88, 445);
            this.fiveMinuteMessageOnButton.Name = "fiveMinuteMessageOnButton";
            this.fiveMinuteMessageOnButton.Size = new System.Drawing.Size(75, 26);
            this.fiveMinuteMessageOnButton.TabIndex = 32;
            this.fiveMinuteMessageOnButton.Text = "Message On";
            this.fiveMinuteMessageOnButton.UseVisualStyleBackColor = false;
            this.fiveMinuteMessageOnButton.Click += new System.EventHandler(this.fiveMinuteMessageOnButton_Click);
            // 
            // fiveMinuteMessageButtonOff
            // 
            this.fiveMinuteMessageButtonOff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fiveMinuteMessageButtonOff.Location = new System.Drawing.Point(175, 445);
            this.fiveMinuteMessageButtonOff.Name = "fiveMinuteMessageButtonOff";
            this.fiveMinuteMessageButtonOff.Size = new System.Drawing.Size(75, 26);
            this.fiveMinuteMessageButtonOff.TabIndex = 33;
            this.fiveMinuteMessageButtonOff.Text = "Message Off";
            this.fiveMinuteMessageButtonOff.UseVisualStyleBackColor = false;
            this.fiveMinuteMessageButtonOff.Click += new System.EventHandler(this.fiveMinuteMessageButtonOff_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(6, 452);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "DemmouMode";
            // 
            // demmouModeLabel
            // 
            this.demmouModeLabel.AutoSize = true;
            this.demmouModeLabel.Location = new System.Drawing.Point(265, 452);
            this.demmouModeLabel.Name = "demmouModeLabel";
            this.demmouModeLabel.Size = new System.Drawing.Size(35, 13);
            this.demmouModeLabel.TabIndex = 35;
            this.demmouModeLabel.Text = "label4";
            this.demmouModeLabel.Click += new System.EventHandler(this.demmouModeLabel_Click);
            // 
            // settingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(701, 557);
            this.Controls.Add(this.demmouModeLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fiveMinuteMessageButtonOff);
            this.Controls.Add(this.fiveMinuteMessageOnButton);
            this.Controls.Add(this.gambleStateLabel);
            this.Controls.Add(this.verdoppelnStateLabel);
            this.Controls.Add(this.smashStateLabel);
            this.Controls.Add(this.bingoStateLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gambleOffButton);
            this.Controls.Add(this.verdoppelnOffButton);
            this.Controls.Add(this.gambleOnButton);
            this.Controls.Add(this.verdoppelnOnButton);
            this.Controls.Add(this.smashOffButton);
            this.Controls.Add(this.smashOnButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bingoGameSwitchLabel);
            this.Controls.Add(this.bingoOnButton);
            this.Controls.Add(this.gameSwitchesLabel);
            this.Controls.Add(this.setCurrencyNameButton);
            this.Controls.Add(this.currencyNameBox);
            this.Controls.Add(this.currencyName);
            this.Controls.Add(this.channelSetButton);
            this.Controls.Add(this.channelNameTextBox);
            this.Controls.Add(this.channelNameLabel);
            this.Controls.Add(this.setClientIdButton);
            this.Controls.Add(this.clientIdLabel);
            this.Controls.Add(this.clientIdTextBox);
            this.Controls.Add(this.authTokenSetButton);
            this.Controls.Add(this.authTokenTextBox);
            this.Controls.Add(this.botAuthTokenLabel);
            this.Controls.Add(this.setBotName);
            this.Controls.Add(this.botNameLabel);
            this.Controls.Add(this.botNameTextBox);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "settingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.settingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox botNameTextBox;
        private System.Windows.Forms.Label botNameLabel;
        private System.Windows.Forms.Button setBotName;
        private System.Windows.Forms.Label botAuthTokenLabel;
        private System.Windows.Forms.TextBox authTokenTextBox;
        private System.Windows.Forms.Button authTokenSetButton;
        private System.Windows.Forms.TextBox clientIdTextBox;
        private System.Windows.Forms.Label clientIdLabel;
        private System.Windows.Forms.Button setClientIdButton;
        private System.Windows.Forms.Label channelNameLabel;
        private System.Windows.Forms.TextBox channelNameTextBox;
        private System.Windows.Forms.Button channelSetButton;
        private System.Windows.Forms.Label currencyName;
        private System.Windows.Forms.TextBox currencyNameBox;
        private System.Windows.Forms.Button setCurrencyNameButton;
        private System.Windows.Forms.Label gameSwitchesLabel;
        private System.Windows.Forms.Button bingoOnButton;
        private System.Windows.Forms.Label bingoGameSwitchLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button smashOnButton;
        private System.Windows.Forms.Button smashOffButton;
        private System.Windows.Forms.Button verdoppelnOnButton;
        private System.Windows.Forms.Button gambleOnButton;
        private System.Windows.Forms.Button verdoppelnOffButton;
        private System.Windows.Forms.Button gambleOffButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label bingoStateLabel;
        private System.Windows.Forms.Label smashStateLabel;
        private System.Windows.Forms.Label verdoppelnStateLabel;
        private System.Windows.Forms.Label gambleStateLabel;
        private System.Windows.Forms.Button fiveMinuteMessageOnButton;
        private System.Windows.Forms.Button fiveMinuteMessageButtonOff;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label demmouModeLabel;
    }
}