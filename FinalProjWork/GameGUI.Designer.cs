namespace FinalProjWork
{
    partial class GameGUI
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
            this.pnlCardHome = new System.Windows.Forms.Panel();
            this.pnlOpponent = new System.Windows.Forms.Panel();
            this.pbPlayer6 = new System.Windows.Forms.PictureBox();
            this.pbPlayer5 = new System.Windows.Forms.PictureBox();
            this.pbPlayer4 = new System.Windows.Forms.PictureBox();
            this.pbPlayer3 = new System.Windows.Forms.PictureBox();
            this.pbPlayer2 = new System.Windows.Forms.PictureBox();
            this.pnlPlay = new System.Windows.Forms.Panel();
            this.lblDefender = new System.Windows.Forms.Label();
            this.lblAttacker = new System.Windows.Forms.Label();
            this.lblCardCount = new System.Windows.Forms.Label();
            this.lblTrumpCard = new System.Windows.Forms.Label();
            this.btnPlayCard = new System.Windows.Forms.Button();
            this.btnPass = new System.Windows.Forms.Button();
            this.cbMyHand = new System.Windows.Forms.ComboBox();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.pbTrumpCard = new System.Windows.Forms.PictureBox();
            this.pbDeck = new System.Windows.Forms.PictureBox();
            this.lblPlayer2 = new System.Windows.Forms.Label();
            this.lblPlayer3 = new System.Windows.Forms.Label();
            this.lblPlayer4 = new System.Windows.Forms.Label();
            this.lblPlayer5 = new System.Windows.Forms.Label();
            this.lblPlayer6 = new System.Windows.Forms.Label();
            this.lblTrumpDrawn = new System.Windows.Forms.Label();
            this.lblP2Cards = new System.Windows.Forms.Label();
            this.lblP3Cards = new System.Windows.Forms.Label();
            this.lblP4Cards = new System.Windows.Forms.Label();
            this.lblP5Cards = new System.Windows.Forms.Label();
            this.lblP6Cards = new System.Windows.Forms.Label();
            this.lblYourTurn = new System.Windows.Forms.Label();
            this.lblRemaining = new System.Windows.Forms.Label();
            this.pnlOpponent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrumpCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeck)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCardHome
            // 
            this.pnlCardHome.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pnlCardHome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardHome.Location = new System.Drawing.Point(85, 383);
            this.pnlCardHome.Name = "pnlCardHome";
            this.pnlCardHome.Size = new System.Drawing.Size(471, 107);
            this.pnlCardHome.TabIndex = 10;
            // 
            // pnlOpponent
            // 
            this.pnlOpponent.AllowDrop = true;
            this.pnlOpponent.BackColor = System.Drawing.Color.IndianRed;
            this.pnlOpponent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOpponent.Controls.Add(this.lblP6Cards);
            this.pnlOpponent.Controls.Add(this.lblP5Cards);
            this.pnlOpponent.Controls.Add(this.lblP4Cards);
            this.pnlOpponent.Controls.Add(this.lblP3Cards);
            this.pnlOpponent.Controls.Add(this.lblP2Cards);
            this.pnlOpponent.Controls.Add(this.pbPlayer6);
            this.pnlOpponent.Controls.Add(this.pbPlayer5);
            this.pnlOpponent.Controls.Add(this.pbPlayer4);
            this.pnlOpponent.Controls.Add(this.pbPlayer3);
            this.pnlOpponent.Controls.Add(this.pbPlayer2);
            this.pnlOpponent.Location = new System.Drawing.Point(85, 43);
            this.pnlOpponent.Name = "pnlOpponent";
            this.pnlOpponent.Size = new System.Drawing.Size(471, 107);
            this.pnlOpponent.TabIndex = 8;
            // 
            // pbPlayer6
            // 
            this.pbPlayer6.Image = global::FinalProjWork.Properties.Resources.Back;
            this.pbPlayer6.Location = new System.Drawing.Point(394, 17);
            this.pbPlayer6.Margin = new System.Windows.Forms.Padding(2);
            this.pbPlayer6.Name = "pbPlayer6";
            this.pbPlayer6.Size = new System.Drawing.Size(66, 85);
            this.pbPlayer6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPlayer6.TabIndex = 20;
            this.pbPlayer6.TabStop = false;
            // 
            // pbPlayer5
            // 
            this.pbPlayer5.Image = global::FinalProjWork.Properties.Resources.Back;
            this.pbPlayer5.Location = new System.Drawing.Point(301, 17);
            this.pbPlayer5.Margin = new System.Windows.Forms.Padding(2);
            this.pbPlayer5.Name = "pbPlayer5";
            this.pbPlayer5.Size = new System.Drawing.Size(66, 85);
            this.pbPlayer5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPlayer5.TabIndex = 19;
            this.pbPlayer5.TabStop = false;
            // 
            // pbPlayer4
            // 
            this.pbPlayer4.Image = global::FinalProjWork.Properties.Resources.Back;
            this.pbPlayer4.Location = new System.Drawing.Point(205, 17);
            this.pbPlayer4.Margin = new System.Windows.Forms.Padding(2);
            this.pbPlayer4.Name = "pbPlayer4";
            this.pbPlayer4.Size = new System.Drawing.Size(66, 85);
            this.pbPlayer4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPlayer4.TabIndex = 18;
            this.pbPlayer4.TabStop = false;
            // 
            // pbPlayer3
            // 
            this.pbPlayer3.Image = global::FinalProjWork.Properties.Resources.Back;
            this.pbPlayer3.Location = new System.Drawing.Point(111, 17);
            this.pbPlayer3.Margin = new System.Windows.Forms.Padding(2);
            this.pbPlayer3.Name = "pbPlayer3";
            this.pbPlayer3.Size = new System.Drawing.Size(66, 85);
            this.pbPlayer3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPlayer3.TabIndex = 17;
            this.pbPlayer3.TabStop = false;
            // 
            // pbPlayer2
            // 
            this.pbPlayer2.Image = global::FinalProjWork.Properties.Resources.Back;
            this.pbPlayer2.Location = new System.Drawing.Point(12, 17);
            this.pbPlayer2.Margin = new System.Windows.Forms.Padding(2);
            this.pbPlayer2.Name = "pbPlayer2";
            this.pbPlayer2.Size = new System.Drawing.Size(66, 85);
            this.pbPlayer2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPlayer2.TabIndex = 16;
            this.pbPlayer2.TabStop = false;
            // 
            // pnlPlay
            // 
            this.pnlPlay.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.pnlPlay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPlay.Location = new System.Drawing.Point(85, 156);
            this.pnlPlay.Name = "pnlPlay";
            this.pnlPlay.Size = new System.Drawing.Size(471, 221);
            this.pnlPlay.TabIndex = 9;
            // 
            // lblDefender
            // 
            this.lblDefender.AutoSize = true;
            this.lblDefender.Location = new System.Drawing.Point(2, 273);
            this.lblDefender.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDefender.Name = "lblDefender";
            this.lblDefender.Size = new System.Drawing.Size(77, 13);
            this.lblDefender.TabIndex = 17;
            this.lblDefender.Text = "Defending >>>";
            // 
            // lblAttacker
            // 
            this.lblAttacker.AutoSize = true;
            this.lblAttacker.Location = new System.Drawing.Point(4, 237);
            this.lblAttacker.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAttacker.Name = "lblAttacker";
            this.lblAttacker.Size = new System.Drawing.Size(73, 13);
            this.lblAttacker.TabIndex = 16;
            this.lblAttacker.Text = "Attacking >>>";
            // 
            // lblCardCount
            // 
            this.lblCardCount.BackColor = System.Drawing.SystemColors.Control;
            this.lblCardCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardCount.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblCardCount.Location = new System.Drawing.Point(7, 83);
            this.lblCardCount.Name = "lblCardCount";
            this.lblCardCount.Size = new System.Drawing.Size(67, 32);
            this.lblCardCount.TabIndex = 1;
            this.lblCardCount.Text = "0";
            this.lblCardCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTrumpCard
            // 
            this.lblTrumpCard.BackColor = System.Drawing.SystemColors.Control;
            this.lblTrumpCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrumpCard.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTrumpCard.Location = new System.Drawing.Point(7, 419);
            this.lblTrumpCard.Name = "lblTrumpCard";
            this.lblTrumpCard.Size = new System.Drawing.Size(66, 32);
            this.lblTrumpCard.TabIndex = 1;
            this.lblTrumpCard.Text = "Trump\nCard";
            this.lblTrumpCard.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnPlayCard
            // 
            this.btnPlayCard.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPlayCard.Location = new System.Drawing.Point(165, 511);
            this.btnPlayCard.Name = "btnPlayCard";
            this.btnPlayCard.Size = new System.Drawing.Size(67, 25);
            this.btnPlayCard.TabIndex = 11;
            this.btnPlayCard.Text = "Play &Card:";
            this.btnPlayCard.UseVisualStyleBackColor = true;
            this.btnPlayCard.Click += new System.EventHandler(this.btnPlayCard_Click);
            // 
            // btnPass
            // 
            this.btnPass.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPass.Location = new System.Drawing.Point(435, 511);
            this.btnPass.Name = "btnPass";
            this.btnPass.Size = new System.Drawing.Size(67, 25);
            this.btnPass.TabIndex = 12;
            this.btnPass.Text = "&Pass";
            this.btnPass.UseVisualStyleBackColor = true;
            this.btnPass.Click += new System.EventHandler(this.btnPass_Click);
            // 
            // cbMyHand
            // 
            this.cbMyHand.FormattingEnabled = true;
            this.cbMyHand.Location = new System.Drawing.Point(248, 513);
            this.cbMyHand.Margin = new System.Windows.Forms.Padding(2);
            this.cbMyHand.Name = "cbMyHand";
            this.cbMyHand.Size = new System.Drawing.Size(159, 21);
            this.cbMyHand.TabIndex = 13;
            // 
            // btnNewGame
            // 
            this.btnNewGame.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNewGame.Location = new System.Drawing.Point(14, 511);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(114, 25);
            this.btnNewGame.TabIndex = 14;
            this.btnNewGame.Text = "&New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // pbTrumpCard
            // 
            this.pbTrumpCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbTrumpCard.Location = new System.Drawing.Point(7, 330);
            this.pbTrumpCard.Name = "pbTrumpCard";
            this.pbTrumpCard.Size = new System.Drawing.Size(67, 86);
            this.pbTrumpCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTrumpCard.TabIndex = 2;
            this.pbTrumpCard.TabStop = false;
            // 
            // pbDeck
            // 
            this.pbDeck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbDeck.Image = global::FinalProjWork.Properties.Resources.Back;
            this.pbDeck.Location = new System.Drawing.Point(7, 118);
            this.pbDeck.Name = "pbDeck";
            this.pbDeck.Size = new System.Drawing.Size(67, 86);
            this.pbDeck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDeck.TabIndex = 2;
            this.pbDeck.TabStop = false;
            // 
            // lblPlayer2
            // 
            this.lblPlayer2.AutoSize = true;
            this.lblPlayer2.Location = new System.Drawing.Point(106, 26);
            this.lblPlayer2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlayer2.Name = "lblPlayer2";
            this.lblPlayer2.Size = new System.Drawing.Size(48, 13);
            this.lblPlayer2.TabIndex = 17;
            this.lblPlayer2.Text = "Player 2:";
            // 
            // lblPlayer3
            // 
            this.lblPlayer3.AutoSize = true;
            this.lblPlayer3.Location = new System.Drawing.Point(206, 26);
            this.lblPlayer3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlayer3.Name = "lblPlayer3";
            this.lblPlayer3.Size = new System.Drawing.Size(48, 13);
            this.lblPlayer3.TabIndex = 18;
            this.lblPlayer3.Text = "Player 3:";
            // 
            // lblPlayer4
            // 
            this.lblPlayer4.AutoSize = true;
            this.lblPlayer4.Location = new System.Drawing.Point(299, 26);
            this.lblPlayer4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlayer4.Name = "lblPlayer4";
            this.lblPlayer4.Size = new System.Drawing.Size(48, 13);
            this.lblPlayer4.TabIndex = 19;
            this.lblPlayer4.Text = "Player 4:";
            // 
            // lblPlayer5
            // 
            this.lblPlayer5.AutoSize = true;
            this.lblPlayer5.Location = new System.Drawing.Point(396, 26);
            this.lblPlayer5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlayer5.Name = "lblPlayer5";
            this.lblPlayer5.Size = new System.Drawing.Size(48, 13);
            this.lblPlayer5.TabIndex = 20;
            this.lblPlayer5.Text = "Player 5:";
            // 
            // lblPlayer6
            // 
            this.lblPlayer6.AutoSize = true;
            this.lblPlayer6.Location = new System.Drawing.Point(490, 26);
            this.lblPlayer6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlayer6.Name = "lblPlayer6";
            this.lblPlayer6.Size = new System.Drawing.Size(48, 13);
            this.lblPlayer6.TabIndex = 21;
            this.lblPlayer6.Text = "Player 6:";
            // 
            // lblTrumpDrawn
            // 
            this.lblTrumpDrawn.AutoSize = true;
            this.lblTrumpDrawn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblTrumpDrawn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrumpDrawn.Location = new System.Drawing.Point(-2, 375);
            this.lblTrumpDrawn.MaximumSize = new System.Drawing.Size(62, 30);
            this.lblTrumpDrawn.MinimumSize = new System.Drawing.Size(62, 30);
            this.lblTrumpDrawn.Name = "lblTrumpDrawn";
            this.lblTrumpDrawn.Size = new System.Drawing.Size(62, 30);
            this.lblTrumpDrawn.TabIndex = 22;
            this.lblTrumpDrawn.Visible = false;
            // 
            // lblP2Cards
            // 
            this.lblP2Cards.AutoSize = true;
            this.lblP2Cards.Location = new System.Drawing.Point(20, -1);
            this.lblP2Cards.MaximumSize = new System.Drawing.Size(48, 13);
            this.lblP2Cards.MinimumSize = new System.Drawing.Size(48, 13);
            this.lblP2Cards.Name = "lblP2Cards";
            this.lblP2Cards.Size = new System.Drawing.Size(48, 13);
            this.lblP2Cards.TabIndex = 21;
            this.lblP2Cards.Text = "0 cards";
            // 
            // lblP3Cards
            // 
            this.lblP3Cards.AutoSize = true;
            this.lblP3Cards.Location = new System.Drawing.Point(120, -1);
            this.lblP3Cards.MaximumSize = new System.Drawing.Size(48, 13);
            this.lblP3Cards.MinimumSize = new System.Drawing.Size(48, 13);
            this.lblP3Cards.Name = "lblP3Cards";
            this.lblP3Cards.Size = new System.Drawing.Size(48, 13);
            this.lblP3Cards.TabIndex = 22;
            this.lblP3Cards.Text = "0 cards";
            // 
            // lblP4Cards
            // 
            this.lblP4Cards.AutoSize = true;
            this.lblP4Cards.Location = new System.Drawing.Point(213, -1);
            this.lblP4Cards.MaximumSize = new System.Drawing.Size(48, 13);
            this.lblP4Cards.MinimumSize = new System.Drawing.Size(48, 13);
            this.lblP4Cards.Name = "lblP4Cards";
            this.lblP4Cards.Size = new System.Drawing.Size(48, 13);
            this.lblP4Cards.TabIndex = 23;
            this.lblP4Cards.Text = "0 cards";
            // 
            // lblP5Cards
            // 
            this.lblP5Cards.AutoSize = true;
            this.lblP5Cards.Location = new System.Drawing.Point(310, -1);
            this.lblP5Cards.MaximumSize = new System.Drawing.Size(48, 13);
            this.lblP5Cards.MinimumSize = new System.Drawing.Size(48, 13);
            this.lblP5Cards.Name = "lblP5Cards";
            this.lblP5Cards.Size = new System.Drawing.Size(48, 13);
            this.lblP5Cards.TabIndex = 24;
            this.lblP5Cards.Text = "0 cards";
            // 
            // lblP6Cards
            // 
            this.lblP6Cards.AutoSize = true;
            this.lblP6Cards.Location = new System.Drawing.Point(404, -1);
            this.lblP6Cards.MaximumSize = new System.Drawing.Size(48, 13);
            this.lblP6Cards.MinimumSize = new System.Drawing.Size(48, 13);
            this.lblP6Cards.Name = "lblP6Cards";
            this.lblP6Cards.Size = new System.Drawing.Size(48, 13);
            this.lblP6Cards.TabIndex = 25;
            this.lblP6Cards.Text = "0 cards";
            // 
            // lblYourTurn
            // 
            this.lblYourTurn.AutoSize = true;
            this.lblYourTurn.Location = new System.Drawing.Point(248, 536);
            this.lblYourTurn.MaximumSize = new System.Drawing.Size(159, 13);
            this.lblYourTurn.MinimumSize = new System.Drawing.Size(159, 13);
            this.lblYourTurn.Name = "lblYourTurn";
            this.lblYourTurn.Size = new System.Drawing.Size(159, 13);
            this.lblYourTurn.TabIndex = 23;
            // 
            // lblRemaining
            // 
            this.lblRemaining.AutoSize = true;
            this.lblRemaining.Location = new System.Drawing.Point(10, 61);
            this.lblRemaining.Name = "lblRemaining";
            this.lblRemaining.Size = new System.Drawing.Size(36, 13);
            this.lblRemaining.TabIndex = 24;
            this.lblRemaining.Text = "Deck:";
            // 
            // GameGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(573, 578);
            this.Controls.Add(this.lblRemaining);
            this.Controls.Add(this.lblDefender);
            this.Controls.Add(this.lblYourTurn);
            this.Controls.Add(this.lblAttacker);
            this.Controls.Add(this.lblTrumpDrawn);
            this.Controls.Add(this.lblPlayer6);
            this.Controls.Add(this.lblPlayer5);
            this.Controls.Add(this.lblPlayer4);
            this.Controls.Add(this.lblPlayer3);
            this.Controls.Add(this.lblPlayer2);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.cbMyHand);
            this.Controls.Add(this.btnPass);
            this.Controls.Add(this.btnPlayCard);
            this.Controls.Add(this.lblTrumpCard);
            this.Controls.Add(this.pnlOpponent);
            this.Controls.Add(this.pbTrumpCard);
            this.Controls.Add(this.pbDeck);
            this.Controls.Add(this.pnlCardHome);
            this.Controls.Add(this.pnlPlay);
            this.Controls.Add(this.lblCardCount);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(589, 617);
            this.MinimumSize = new System.Drawing.Size(589, 617);
            this.Name = "GameGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Durak";
            this.Load += new System.EventHandler(this.GameGUI_Load);
            this.pnlOpponent.ResumeLayout(false);
            this.pnlOpponent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrumpCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeck)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbTrumpCard;
        private System.Windows.Forms.PictureBox pbDeck;
        private System.Windows.Forms.Label lblCardCount;
        private System.Windows.Forms.Label lblTrumpCard;
        private System.Windows.Forms.Panel pnlCardHome;
        private System.Windows.Forms.Panel pnlOpponent;
        private System.Windows.Forms.Panel pnlPlay;
        private System.Windows.Forms.ComboBox cbMyHand;
        public System.Windows.Forms.Button btnPlayCard;
        public System.Windows.Forms.Button btnPass;
        public System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Label lblDefender;
        private System.Windows.Forms.Label lblAttacker;
        private System.Windows.Forms.PictureBox pbPlayer6;
        private System.Windows.Forms.PictureBox pbPlayer5;
        private System.Windows.Forms.PictureBox pbPlayer4;
        private System.Windows.Forms.PictureBox pbPlayer3;
        private System.Windows.Forms.PictureBox pbPlayer2;
        private System.Windows.Forms.Label lblPlayer2;
        private System.Windows.Forms.Label lblPlayer3;
        private System.Windows.Forms.Label lblPlayer4;
        private System.Windows.Forms.Label lblPlayer5;
        private System.Windows.Forms.Label lblPlayer6;
        private System.Windows.Forms.Label lblTrumpDrawn;
        private System.Windows.Forms.Label lblP6Cards;
        private System.Windows.Forms.Label lblP5Cards;
        private System.Windows.Forms.Label lblP4Cards;
        private System.Windows.Forms.Label lblP3Cards;
        private System.Windows.Forms.Label lblP2Cards;
        private System.Windows.Forms.Label lblYourTurn;
        private System.Windows.Forms.Label lblRemaining;
    }
}