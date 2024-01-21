/**
 * GameGui.cs ~ Main Game form code
 * 
 * @author  Simon Yarrow, Jesse Revell, Stephen Asencio
 * 
 * @version 2.0
 * @since       2020-04-016
 */

using Ch13CardLib;
using CardBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjWork
{
    public partial class GameGUI : Form
    {
        #region "Constants & Variables"
        private const int HUMAN_PLAYER_ID = 0;
        private const int MAX_PLAYERS = 6;
        private GameSettingForm setting;
        private int nextPlayer;
        private DurakGame thisGame;
        private Cards myHand;
        private int[] computerHands = new int[MAX_PLAYERS - 1];
        private Cards attackingCards;
        private Cards defendingCards;
        private int deckCardsRemaining;
        private int? durak;
        private int playersThisGame;
        private int deckSize;
        private Card myCard = new Card(Suit.Spade, Rank.Ace);
        #endregion

        #region "Constructor"
        /// <summary>
        /// Constructor
        /// </summary>
        public GameGUI()
        {
            InitializeComponent();
        }
        #endregion

        #region "Event Handlers"
        /// <summary>
        /// Initial Loaded state of form, with no game data loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameGUI_Load(object sender, EventArgs e)
        {
            btnPlayCard.Enabled = false;
            btnPass.Enabled = false;
            btnNewGame.Select();
        }

        /// <summary>
        /// New Game Button. Opens Setting Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            setting = new GameSettingForm(this);
            setting.Show();
        }

        /// <summary>
        /// Pass Turn button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPass_Click(object sender, EventArgs e)
        {
            try
            {
                thisGame.Pass(HUMAN_PLAYER_ID);
                btnPass.Enabled = false;
                btnPlayCard.Enabled = false;
                PlayAITurns(thisGame.NextPlayer);
            }
            catch (GameOverException ex)
            {
                GameOver();
            }
        }
        #endregion

        #region "Private Methods"
        /// <summary>
        /// Takes care of computer player plays.
        /// </summary>
        /// <param name="currentPlayer"></param>
        private void PlayAITurns(int currentPlayer)
        {
            try
            {
                while (currentPlayer != HUMAN_PLAYER_ID)
                {
                    //System.Threading.Thread.Sleep(500);
                    currentPlayer = thisGame.PlayTurn(currentPlayer);
                    UpdateState();
                }
                btnPlayCard.Enabled = true;
                btnPass.Enabled = true;
                if (thisGame.BoutDefender == HUMAN_PLAYER_ID)
                    lblYourTurn.Text = "Your turn -> DEFEND!";
                else
                    lblYourTurn.Text = "Your turn -> ATTACK!";
                cbMyHand.Select();
            }
            catch (GameOverException ex)
            {
                GameOver();
            }
        }

        /// <summary>
        /// Update the state of the game form, with updated images etc
        /// </summary>
        private void UpdateState()
        {
            Label[] oppHandLabels = new Label[] { lblP2Cards, lblP3Cards, lblP4Cards, lblP5Cards, lblP6Cards};
            CardBox.CardBox newBox;
            for (int i = 0; i < playersThisGame; i++)
            {
                if (i == HUMAN_PLAYER_ID)
                {
                    myHand = thisGame.GetPlayerHand(i);
                    cbMyHand.Items.Clear();
                    pnlCardHome.Controls.Clear();
                    for (int j = 0; j < myHand.Count; j++)
                    {
                        cbMyHand.Items.Add(myHand[j].ToString());
                        newBox = new CardBox.CardBox(myHand[j]);
                        newBox.Size = new Size(75, 107);
                        newBox.Click += CardBox_Click;
                        pnlCardHome.Controls.Add(newBox);
                    }
                    if (cbMyHand.Items.Count > 0)
                        cbMyHand.SelectedIndex = 0;
                    RealignCards(pnlCardHome);
                }
                else
                {
                    oppHandLabels[i - 1].Text = thisGame.GetPlayerHand(i).Count + " cards";
                }
            }
            pnlPlay.Controls.Clear();
            attackingCards = thisGame.AttackingCards;
            for (int k = 0; k < attackingCards.Count; k++)
            {
                newBox = new CardBox.CardBox(attackingCards[k]);
                newBox.Size = new Size(75, 107);
                newBox.Location = new Point(0 + k * 75, 0);
                pnlPlay.Controls.Add(newBox);
            }
            defendingCards = thisGame.DefendingCards;
            for (int m = 0; m < defendingCards.Count; m++)
            {
                newBox = new CardBox.CardBox(defendingCards[m]);
                newBox.Size = new Size(75, 107);
                newBox.Location = new Point(0 + m * 75, 114);
                pnlPlay.Controls.Add(newBox);
            }
            deckCardsRemaining = thisGame.GetCardsRemaining();
            lblCardCount.Text = deckCardsRemaining.ToString();
            if (deckCardsRemaining == 0)
            {
                lblTrumpDrawn.Visible = true;
                if (thisGame.TrumpHandId == HUMAN_PLAYER_ID)
                    lblTrumpDrawn.Text = "Drawn by you!";
                else
                    lblTrumpDrawn.Text = "Drawn by player " + thisGame.TrumpHandId + "!";
            }
        }
        /// <summary>
        /// Finishes the game
        /// </summary>
        private void GameOver()
        {
            String boxMessage = "GAME OVER!";
            UpdateState();
            durak = thisGame.LastDurak;
            btnPlayCard.Enabled = false;
            btnPass.Enabled = false;
            lblYourTurn.Text = "";
            btnNewGame.Select();
            if (durak != null)
                boxMessage += " Durak: P" + (durak + 1) + ".";
            else
                boxMessage += " Tie game!";
            MessageBox.Show(boxMessage);
        }
        #endregion

        #region "Public Start Game Method"
        /// <summary>
        /// Starts game
        /// </summary>
        /// <param name="totalPlayers"></param>
        /// <param name="deckStartSize"></param>
        public void StartGame(int totalPlayers, int deckStartSize)
        {
            Label[] oppHandLabels = new Label[] { lblP2Cards, lblP3Cards, lblP4Cards, lblP5Cards, lblP6Cards };
            foreach (Label oppHand in oppHandLabels)
                oppHand.Text = "0 cards";
            lblTrumpDrawn.Text = "";
            lblTrumpDrawn.Visible = false;
            playersThisGame = totalPlayers;
            deckSize = deckStartSize;
            thisGame = new DurakGame(playersThisGame, deckSize);
            durak = null;
            pbTrumpCard.Image = thisGame.TrumpCard.GetCardImage();
            UpdateState();
            nextPlayer = thisGame.NextPlayer;
            PlayAITurns(nextPlayer);
        }
        #endregion
        /// <summary>
        /// Play Card Method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlayCard_Click(object sender, EventArgs e)
        {
            try
            {
                if (thisGame.PlayCard(HUMAN_PLAYER_ID, myHand.ElementAt(cbMyHand.SelectedIndex)))
                {
                    btnPass.Enabled = false;
                    btnPass.Enabled = false;
                    lblYourTurn.Text = "";
                    UpdateState();
                    PlayAITurns(thisGame.NextPlayer);
                }
                else
                {
                    MessageBox.Show("You cannot play that card.");
                }
            }
            catch (GameOverException ex)
            {
                btnPass.Enabled = false;
                btnPlayCard.Enabled = false;
                GameOver();
            }
        }
        /// <summary>
        /// Alternative play card method
        /// NOT WORKING
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        void CardBox_Click(object sender, EventArgs e)
        {
            CardBox.CardBox thisBox = sender as CardBox.CardBox;
            if (thisBox != null)
            {
                try
                {
                    if (thisGame.PlayCard(HUMAN_PLAYER_ID, thisBox.Card))
                    {
                        btnPass.Enabled = false;
                        btnPass.Enabled = false;
                        UpdateState();
                        PlayAITurns(thisGame.NextPlayer);
                    }
                    else
                    {
                        MessageBox.Show("You cannot play that card.");
                    }
                }
                catch (GameOverException ex)
                {
                    btnPass.Enabled = false;
                    btnPlayCard.Enabled = false;
                    GameOver();
                }
            }
        }

        /// <summary>
        /// Repositions the cards in a panel so that they are evenly distributed in the area available.
        /// NOTE: This method written almost entirely by Thom MacDonald.
        /// </summary>
        /// <param name="thisPanel">The panel in which the cards will be realigned</param>
        private void RealignCards(Panel thisPanel)
        {
            // Determine the number of cards/controls in the panel.
            int myCount = thisPanel.Controls.Count;

            // If there are any cards in the panel
            if (myCount > 0)
            {
                // Determine how wide one card/control is.
                int cardWidth = thisPanel.Controls[0].Width;

                // Determine where the left-hand edge of a card/control placed 
                // in the middle of the panel should be  
                int startPoint = (thisPanel.Width - cardWidth) / 2;

                // An offset for the remaining cards
                int offset = 0;

                // If there are more than one cards/controls in the panel
                if (myCount > 1)
                {
                    // Determine what the offset should be for each card based on the 
                    // space available and the number of card/controls
                    offset = (thisPanel.Width - cardWidth) / (myCount - 1);

                    // If the offset is bigger than the card/control width, i.e. there is lots of room, 
                    // set the offset to the card width. The cards/controls will not overlap at all.
                    if (offset > cardWidth)
                        offset = cardWidth;

                    // Determine width of all the cards/controls 
                    int allCardsWidth = (myCount - 1) * offset + cardWidth;

                    // Set the start point to where the left-hand edge of the "first" card should be.
                    startPoint = (thisPanel.Width - allCardsWidth) / 2;
                }

                // Aligning the cards: Note that I align them in reserve order from how they
                // are stored in the controls collection. This is so that cards on the left 
                // appear underneath cards to the right. This allows the user to see the rank
                // and suit more easily.

                // Align the first card
                thisPanel.Controls[0].Top = 0;
                thisPanel.Controls[0].Left = startPoint;

                // For each of the remaining controls
                for (int index = 1; index < myCount; index++)
                {
                    // Align the current card
                    thisPanel.Controls[index].Top = 0;
                    thisPanel.Controls[index].Left = thisPanel.Controls[index - 1].Left + offset;
                }
            }
        }
    }
}