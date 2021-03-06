﻿namespace WordGuessClient
{
    public partial class WordGuessClient
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
            this.PlayerInfoGroup = new System.Windows.Forms.GroupBox();
            this.aliasLabel = new System.Windows.Forms.Label();
            this.aNumLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.aliasTextBox = new System.Windows.Forms.TextBox();
            this.aNumTextBox = new System.Windows.Forms.TextBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.addressGroup = new System.Windows.Forms.GroupBox();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.NewGameBtn = new System.Windows.Forms.Button();
            this.GamePanel = new System.Windows.Forms.Panel();
            this.incorrectLabel = new System.Windows.Forms.TextBox();
            this.numOfCharLabel = new System.Windows.Forms.Label();
            this.guessTextbox = new System.Windows.Forms.TextBox();
            this.definitionTextBox = new System.Windows.Forms.TextBox();
            this.hintTextBox = new System.Windows.Forms.TextBox();
            this.guessLabel = new System.Windows.Forms.Label();
            this.defLabel = new System.Windows.Forms.Label();
            this.hintLabel = new System.Windows.Forms.Label();
            this.guessBtn = new System.Windows.Forms.Button();
            this.hintBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.gameIdLabel = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.playerScoreLabel = new System.Windows.Forms.Label();
            this.errorTextBox = new System.Windows.Forms.TextBox();
            this.PlayerInfoGroup.SuspendLayout();
            this.addressGroup.SuspendLayout();
            this.GamePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlayerInfoGroup
            // 
            this.PlayerInfoGroup.Controls.Add(this.aliasLabel);
            this.PlayerInfoGroup.Controls.Add(this.aNumLabel);
            this.PlayerInfoGroup.Controls.Add(this.lastNameLabel);
            this.PlayerInfoGroup.Controls.Add(this.firstNameLabel);
            this.PlayerInfoGroup.Controls.Add(this.aliasTextBox);
            this.PlayerInfoGroup.Controls.Add(this.aNumTextBox);
            this.PlayerInfoGroup.Controls.Add(this.lastNameTextBox);
            this.PlayerInfoGroup.Controls.Add(this.firstNameTextBox);
            this.PlayerInfoGroup.Location = new System.Drawing.Point(327, 49);
            this.PlayerInfoGroup.Name = "PlayerInfoGroup";
            this.PlayerInfoGroup.Size = new System.Drawing.Size(298, 155);
            this.PlayerInfoGroup.TabIndex = 0;
            this.PlayerInfoGroup.TabStop = false;
            this.PlayerInfoGroup.Text = "Player Information";
            // 
            // aliasLabel
            // 
            this.aliasLabel.AutoSize = true;
            this.aliasLabel.Location = new System.Drawing.Point(19, 120);
            this.aliasLabel.Name = "aliasLabel";
            this.aliasLabel.Size = new System.Drawing.Size(77, 17);
            this.aliasLabel.TabIndex = 7;
            this.aliasLabel.Text = "Username:";
            // 
            // aNumLabel
            // 
            this.aNumLabel.AutoSize = true;
            this.aNumLabel.Location = new System.Drawing.Point(67, 92);
            this.aNumLabel.Name = "aNumLabel";
            this.aNumLabel.Size = new System.Drawing.Size(29, 17);
            this.aNumLabel.TabIndex = 6;
            this.aNumLabel.Text = "A#:";
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(16, 64);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(80, 17);
            this.lastNameLabel.TabIndex = 5;
            this.lastNameLabel.Text = "Last Name:";
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(16, 36);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(80, 17);
            this.firstNameLabel.TabIndex = 4;
            this.firstNameLabel.Text = "First Name:";
            // 
            // aliasTextBox
            // 
            this.aliasTextBox.Location = new System.Drawing.Point(102, 117);
            this.aliasTextBox.Name = "aliasTextBox";
            this.aliasTextBox.Size = new System.Drawing.Size(169, 22);
            this.aliasTextBox.TabIndex = 3;
            // 
            // aNumTextBox
            // 
            this.aNumTextBox.Location = new System.Drawing.Point(102, 89);
            this.aNumTextBox.Name = "aNumTextBox";
            this.aNumTextBox.Size = new System.Drawing.Size(169, 22);
            this.aNumTextBox.TabIndex = 2;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(102, 61);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(169, 22);
            this.lastNameTextBox.TabIndex = 1;
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(102, 33);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(169, 22);
            this.firstNameTextBox.TabIndex = 0;
            // 
            // addressGroup
            // 
            this.addressGroup.Controls.Add(this.portTextBox);
            this.addressGroup.Controls.Add(this.portLabel);
            this.addressGroup.Controls.Add(this.addressLabel);
            this.addressGroup.Controls.Add(this.addressTextBox);
            this.addressGroup.Location = new System.Drawing.Point(23, 49);
            this.addressGroup.Name = "addressGroup";
            this.addressGroup.Size = new System.Drawing.Size(298, 155);
            this.addressGroup.TabIndex = 1;
            this.addressGroup.TabStop = false;
            this.addressGroup.Text = "Server Address";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(112, 72);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(163, 22);
            this.portTextBox.TabIndex = 3;
            this.portTextBox.Text = "12001";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(14, 77);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(92, 17);
            this.portLabel.TabIndex = 2;
            this.portLabel.Text = "Port Number:";
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(26, 42);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(80, 17);
            this.addressLabel.TabIndex = 1;
            this.addressLabel.Text = "IP Address:";
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(112, 37);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(163, 22);
            this.addressTextBox.TabIndex = 0;
            this.addressTextBox.Text = "127.0.0.1";
            // 
            // NewGameBtn
            // 
            this.NewGameBtn.Location = new System.Drawing.Point(23, 230);
            this.NewGameBtn.Name = "NewGameBtn";
            this.NewGameBtn.Size = new System.Drawing.Size(112, 32);
            this.NewGameBtn.TabIndex = 2;
            this.NewGameBtn.Text = "New Game";
            this.NewGameBtn.UseVisualStyleBackColor = true;
            this.NewGameBtn.Click += new System.EventHandler(this.NewGameBtn_Click);
            // 
            // GamePanel
            // 
            this.GamePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GamePanel.Controls.Add(this.playerScoreLabel);
            this.GamePanel.Controls.Add(this.scoreLabel);
            this.GamePanel.Controls.Add(this.incorrectLabel);
            this.GamePanel.Controls.Add(this.numOfCharLabel);
            this.GamePanel.Controls.Add(this.guessTextbox);
            this.GamePanel.Controls.Add(this.definitionTextBox);
            this.GamePanel.Controls.Add(this.hintTextBox);
            this.GamePanel.Controls.Add(this.guessLabel);
            this.GamePanel.Controls.Add(this.defLabel);
            this.GamePanel.Controls.Add(this.hintLabel);
            this.GamePanel.Controls.Add(this.guessBtn);
            this.GamePanel.Controls.Add(this.hintBtn);
            this.GamePanel.Location = new System.Drawing.Point(23, 292);
            this.GamePanel.Name = "GamePanel";
            this.GamePanel.Size = new System.Drawing.Size(602, 261);
            this.GamePanel.TabIndex = 3;
            // 
            // incorrectLabel
            // 
            this.incorrectLabel.BackColor = System.Drawing.SystemColors.Control;
            this.incorrectLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.incorrectLabel.Enabled = false;
            this.incorrectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.incorrectLabel.ForeColor = System.Drawing.Color.Red;
            this.incorrectLabel.Location = new System.Drawing.Point(405, 221);
            this.incorrectLabel.Name = "incorrectLabel";
            this.incorrectLabel.Size = new System.Drawing.Size(182, 29);
            this.incorrectLabel.TabIndex = 9;
            // 
            // numOfCharLabel
            // 
            this.numOfCharLabel.AutoSize = true;
            this.numOfCharLabel.Location = new System.Drawing.Point(445, 32);
            this.numOfCharLabel.Name = "numOfCharLabel";
            this.numOfCharLabel.Size = new System.Drawing.Size(0, 17);
            this.numOfCharLabel.TabIndex = 8;
            // 
            // guessTextbox
            // 
            this.guessTextbox.Location = new System.Drawing.Point(83, 195);
            this.guessTextbox.Name = "guessTextbox";
            this.guessTextbox.Size = new System.Drawing.Size(316, 22);
            this.guessTextbox.TabIndex = 7;
            this.guessTextbox.Enter += new System.EventHandler(this.guessTextbox_Enter);
            // 
            // definitionTextBox
            // 
            this.definitionTextBox.Location = new System.Drawing.Point(83, 77);
            this.definitionTextBox.Multiline = true;
            this.definitionTextBox.Name = "definitionTextBox";
            this.definitionTextBox.ReadOnly = true;
            this.definitionTextBox.Size = new System.Drawing.Size(316, 103);
            this.definitionTextBox.TabIndex = 6;
            // 
            // hintTextBox
            // 
            this.hintTextBox.Location = new System.Drawing.Point(83, 30);
            this.hintTextBox.Name = "hintTextBox";
            this.hintTextBox.ReadOnly = true;
            this.hintTextBox.Size = new System.Drawing.Size(316, 22);
            this.hintTextBox.TabIndex = 5;
            // 
            // guessLabel
            // 
            this.guessLabel.AutoSize = true;
            this.guessLabel.Location = new System.Drawing.Point(16, 195);
            this.guessLabel.Name = "guessLabel";
            this.guessLabel.Size = new System.Drawing.Size(53, 17);
            this.guessLabel.TabIndex = 4;
            this.guessLabel.Text = "Guess:";
            // 
            // defLabel
            // 
            this.defLabel.AutoSize = true;
            this.defLabel.Location = new System.Drawing.Point(6, 80);
            this.defLabel.Name = "defLabel";
            this.defLabel.Size = new System.Drawing.Size(71, 17);
            this.defLabel.TabIndex = 3;
            this.defLabel.Text = "Definition:";
            // 
            // hintLabel
            // 
            this.hintLabel.AutoSize = true;
            this.hintLabel.Location = new System.Drawing.Point(40, 33);
            this.hintLabel.Name = "hintLabel";
            this.hintLabel.Size = new System.Drawing.Size(37, 17);
            this.hintLabel.TabIndex = 2;
            this.hintLabel.Text = "Hint:";
            // 
            // guessBtn
            // 
            this.guessBtn.Location = new System.Drawing.Point(445, 192);
            this.guessBtn.Name = "guessBtn";
            this.guessBtn.Size = new System.Drawing.Size(102, 23);
            this.guessBtn.TabIndex = 1;
            this.guessBtn.Text = "Make Guess";
            this.guessBtn.UseVisualStyleBackColor = true;
            this.guessBtn.Click += new System.EventHandler(this.guessBtn_Click);
            // 
            // hintBtn
            // 
            this.hintBtn.Location = new System.Drawing.Point(445, 74);
            this.hintBtn.Name = "hintBtn";
            this.hintBtn.Size = new System.Drawing.Size(102, 23);
            this.hintBtn.TabIndex = 0;
            this.hintBtn.Text = "Get Hint";
            this.hintBtn.UseVisualStyleBackColor = true;
            this.hintBtn.Click += new System.EventHandler(this.hintBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(23, 573);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(75, 23);
            this.exitBtn.TabIndex = 4;
            this.exitBtn.Text = "Quit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // gameIdLabel
            // 
            this.gameIdLabel.AutoSize = true;
            this.gameIdLabel.Location = new System.Drawing.Point(609, 268);
            this.gameIdLabel.Name = "gameIdLabel";
            this.gameIdLabel.Size = new System.Drawing.Size(0, 17);
            this.gameIdLabel.TabIndex = 5;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(536, 268);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(67, 17);
            this.idLabel.TabIndex = 6;
            this.idLabel.Text = "Game ID:";
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.Location = new System.Drawing.Point(455, 100);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(83, 29);
            this.scoreLabel.TabIndex = 10;
            this.scoreLabel.Text = "Score:";
            this.scoreLabel.Visible = false;
            // 
            // playerScoreLabel
            // 
            this.playerScoreLabel.AutoSize = true;
            this.playerScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerScoreLabel.Location = new System.Drawing.Point(474, 129);
            this.playerScoreLabel.Name = "playerScoreLabel";
            this.playerScoreLabel.Size = new System.Drawing.Size(43, 48);
            this.playerScoreLabel.TabIndex = 11;
            this.playerScoreLabel.Text = "0";
            this.playerScoreLabel.Visible = false;
            // 
            // errorTextBox
            // 
            this.errorTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.errorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorTextBox.Location = new System.Drawing.Point(301, 573);
            this.errorTextBox.Name = "errorTextBox";
            this.errorTextBox.Size = new System.Drawing.Size(240, 15);
            this.errorTextBox.TabIndex = 7;
            // 
            // WordGuessClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 622);
            this.Controls.Add(this.errorTextBox);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.gameIdLabel);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.GamePanel);
            this.Controls.Add(this.NewGameBtn);
            this.Controls.Add(this.addressGroup);
            this.Controls.Add(this.PlayerInfoGroup);
            this.Name = "WordGuessClient";
            this.Text = "Word Guess Game";
            this.PlayerInfoGroup.ResumeLayout(false);
            this.PlayerInfoGroup.PerformLayout();
            this.addressGroup.ResumeLayout(false);
            this.addressGroup.PerformLayout();
            this.GamePanel.ResumeLayout(false);
            this.GamePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox PlayerInfoGroup;
        private System.Windows.Forms.GroupBox addressGroup;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.Button NewGameBtn;
        private System.Windows.Forms.Panel GamePanel;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Label aliasLabel;
        private System.Windows.Forms.Label aNumLabel;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.TextBox aliasTextBox;
        private System.Windows.Forms.TextBox aNumTextBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.TextBox hintTextBox;
        private System.Windows.Forms.Label guessLabel;
        private System.Windows.Forms.Label defLabel;
        private System.Windows.Forms.Label hintLabel;
        private System.Windows.Forms.Button guessBtn;
        private System.Windows.Forms.Button hintBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.TextBox guessTextbox;
        private System.Windows.Forms.TextBox definitionTextBox;
        private System.Windows.Forms.Label gameIdLabel;
        private System.Windows.Forms.Label numOfCharLabel;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.TextBox incorrectLabel;
        private System.Windows.Forms.Label playerScoreLabel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.TextBox errorTextBox;
    }
}

