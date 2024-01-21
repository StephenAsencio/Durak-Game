namespace FinalProjWork
{
    partial class GameSettingForm
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
            this.grpNumPlayers = new System.Windows.Forms.GroupBox();
            this.rbPlayers6 = new System.Windows.Forms.RadioButton();
            this.rbPlayers5 = new System.Windows.Forms.RadioButton();
            this.rbPlayers4 = new System.Windows.Forms.RadioButton();
            this.rbPlayers3 = new System.Windows.Forms.RadioButton();
            this.rbPlayers2 = new System.Windows.Forms.RadioButton();
            this.grpNumCards = new System.Windows.Forms.GroupBox();
            this.rbDeck52 = new System.Windows.Forms.RadioButton();
            this.rbDeck36 = new System.Windows.Forms.RadioButton();
            this.rbDeck24 = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.grpNumPlayers.SuspendLayout();
            this.grpNumCards.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpNumPlayers
            // 
            this.grpNumPlayers.Controls.Add(this.rbPlayers6);
            this.grpNumPlayers.Controls.Add(this.rbPlayers5);
            this.grpNumPlayers.Controls.Add(this.rbPlayers4);
            this.grpNumPlayers.Controls.Add(this.rbPlayers3);
            this.grpNumPlayers.Controls.Add(this.rbPlayers2);
            this.grpNumPlayers.Location = new System.Drawing.Point(13, 34);
            this.grpNumPlayers.Name = "grpNumPlayers";
            this.grpNumPlayers.Size = new System.Drawing.Size(189, 145);
            this.grpNumPlayers.TabIndex = 0;
            this.grpNumPlayers.TabStop = false;
            this.grpNumPlayers.Text = "Players";
            // 
            // rbPlayers6
            // 
            this.rbPlayers6.AutoSize = true;
            this.rbPlayers6.Location = new System.Drawing.Point(7, 116);
            this.rbPlayers6.Name = "rbPlayers6";
            this.rbPlayers6.Size = new System.Drawing.Size(31, 17);
            this.rbPlayers6.TabIndex = 4;
            this.rbPlayers6.TabStop = true;
            this.rbPlayers6.Text = "6";
            this.rbPlayers6.UseVisualStyleBackColor = true;
            this.rbPlayers6.CheckedChanged += new System.EventHandler(this.rbPlayers6_CheckedChanged);
            // 
            // rbPlayers5
            // 
            this.rbPlayers5.AutoSize = true;
            this.rbPlayers5.Location = new System.Drawing.Point(7, 92);
            this.rbPlayers5.Name = "rbPlayers5";
            this.rbPlayers5.Size = new System.Drawing.Size(31, 17);
            this.rbPlayers5.TabIndex = 3;
            this.rbPlayers5.TabStop = true;
            this.rbPlayers5.Text = "5";
            this.rbPlayers5.UseVisualStyleBackColor = true;
            this.rbPlayers5.CheckedChanged += new System.EventHandler(this.rbPlayers5_CheckedChanged);
            // 
            // rbPlayers4
            // 
            this.rbPlayers4.AutoSize = true;
            this.rbPlayers4.Location = new System.Drawing.Point(7, 68);
            this.rbPlayers4.Name = "rbPlayers4";
            this.rbPlayers4.Size = new System.Drawing.Size(31, 17);
            this.rbPlayers4.TabIndex = 2;
            this.rbPlayers4.TabStop = true;
            this.rbPlayers4.Text = "4";
            this.rbPlayers4.UseVisualStyleBackColor = true;
            // 
            // rbPlayers3
            // 
            this.rbPlayers3.AutoSize = true;
            this.rbPlayers3.Location = new System.Drawing.Point(7, 44);
            this.rbPlayers3.Name = "rbPlayers3";
            this.rbPlayers3.Size = new System.Drawing.Size(31, 17);
            this.rbPlayers3.TabIndex = 1;
            this.rbPlayers3.TabStop = true;
            this.rbPlayers3.Text = "3";
            this.rbPlayers3.UseVisualStyleBackColor = true;
            // 
            // rbPlayers2
            // 
            this.rbPlayers2.AutoSize = true;
            this.rbPlayers2.Location = new System.Drawing.Point(7, 20);
            this.rbPlayers2.Name = "rbPlayers2";
            this.rbPlayers2.Size = new System.Drawing.Size(31, 17);
            this.rbPlayers2.TabIndex = 0;
            this.rbPlayers2.TabStop = true;
            this.rbPlayers2.Text = "2";
            this.rbPlayers2.UseVisualStyleBackColor = true;
            // 
            // grpNumCards
            // 
            this.grpNumCards.Controls.Add(this.rbDeck52);
            this.grpNumCards.Controls.Add(this.rbDeck36);
            this.grpNumCards.Controls.Add(this.rbDeck24);
            this.grpNumCards.Location = new System.Drawing.Point(209, 34);
            this.grpNumCards.Name = "grpNumCards";
            this.grpNumCards.Size = new System.Drawing.Size(196, 93);
            this.grpNumCards.TabIndex = 1;
            this.grpNumCards.TabStop = false;
            this.grpNumCards.Text = "Cards";
            // 
            // rbDeck52
            // 
            this.rbDeck52.AutoSize = true;
            this.rbDeck52.Location = new System.Drawing.Point(7, 68);
            this.rbDeck52.Name = "rbDeck52";
            this.rbDeck52.Size = new System.Drawing.Size(37, 17);
            this.rbDeck52.TabIndex = 2;
            this.rbDeck52.TabStop = true;
            this.rbDeck52.Text = "52";
            this.rbDeck52.UseVisualStyleBackColor = true;
            // 
            // rbDeck36
            // 
            this.rbDeck36.AutoSize = true;
            this.rbDeck36.Location = new System.Drawing.Point(7, 44);
            this.rbDeck36.Name = "rbDeck36";
            this.rbDeck36.Size = new System.Drawing.Size(37, 17);
            this.rbDeck36.TabIndex = 1;
            this.rbDeck36.TabStop = true;
            this.rbDeck36.Text = "36";
            this.rbDeck36.UseVisualStyleBackColor = true;
            // 
            // rbDeck24
            // 
            this.rbDeck24.AutoSize = true;
            this.rbDeck24.Location = new System.Drawing.Point(7, 20);
            this.rbDeck24.Name = "rbDeck24";
            this.rbDeck24.Size = new System.Drawing.Size(37, 17);
            this.rbDeck24.TabIndex = 0;
            this.rbDeck24.TabStop = true;
            this.rbDeck24.Text = "24";
            this.rbDeck24.UseVisualStyleBackColor = true;
            this.rbDeck24.CheckedChanged += new System.EventHandler(this.rbDeck24_CheckedChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(209, 133);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(331, 133);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // GameSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 202);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.grpNumCards);
            this.Controls.Add(this.grpNumPlayers);
            this.MaximumSize = new System.Drawing.Size(437, 241);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(437, 241);
            this.Name = "GameSettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            this.grpNumPlayers.ResumeLayout(false);
            this.grpNumPlayers.PerformLayout();
            this.grpNumCards.ResumeLayout(false);
            this.grpNumCards.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.RadioButton rbPlayers6;
        public System.Windows.Forms.RadioButton rbPlayers5;
        public System.Windows.Forms.RadioButton rbPlayers4;
        public System.Windows.Forms.RadioButton rbPlayers3;
        public System.Windows.Forms.RadioButton rbPlayers2;
        public System.Windows.Forms.RadioButton rbDeck52;
        public System.Windows.Forms.RadioButton rbDeck36;
        public System.Windows.Forms.RadioButton rbDeck24;
        public System.Windows.Forms.Button btnStart;
        public System.Windows.Forms.Button btnExit;
        public System.Windows.Forms.GroupBox grpNumPlayers;
        public System.Windows.Forms.GroupBox grpNumCards;
    }
}

