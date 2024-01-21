/**
 * GameSettingForm.cs ~ Code which handles the number of players, and deck size
 *  
 * @author  Simon Yarrow, Jesse Revell, Stephen Asencio
 * 
 * @version 2.0
 * @since       2020-04-016
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ch13CardLib;

namespace FinalProjWork
{
    public partial class GameSettingForm : Form
    {
        GameGUI myParent; 
        int players;
        int cards;
        int[] playerOptions = new int[] { 2, 3, 4, 5, 6 };
        int[] deckSizeOptions = new int[] { 24, 36, 52 };

        /// <summary>
        /// Defaukt Constructor. Not Used
        /// </summary>
        private GameSettingForm()
        {
            // Not used
        }

        /// <summary>
        /// Paramaterized constructor
        /// </summary>
        /// <param name="callingForm"></param>
        public GameSettingForm(GameGUI callingForm)
        {
            InitializeComponent();
            myParent = callingForm;
            rbPlayers4.Select();
            rbDeck36.Select();
        }

        /// <summary>
        /// Start Game button. Send settings to GameGui
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            int counter = 0;
            foreach (RadioButton rb in grpNumPlayers.Controls)
            {
                if (rb.Checked)
                    players = playerOptions[playerOptions.Length -1 -counter];
                counter++;
            }
            counter = 0;
            foreach (RadioButton rb in grpNumCards.Controls)
            {
                if (rb.Checked)
                    cards = deckSizeOptions[deckSizeOptions.Length - 1 - counter];
                counter++;
            }
            this.Close();
            myParent.StartGame(players, cards);
        }
        /// <summary>
        ///  If 5 players are selected. Cannot use a 24 card deck
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void rbPlayers5_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                if (rbDeck24.Checked)
                    rbDeck36.Select();
                rbDeck24.Enabled = false;
            }
            else
                rbDeck24.Enabled = true;
        }

        /// <summary>
        /// If 24 card deck is selected. Cannot have 5 or 6 players
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbDeck24_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                if (rbPlayers6.Checked || rbPlayers5.Checked)
                    rbPlayers4.Select();
                rbPlayers5.Enabled = false;
                rbPlayers6.Enabled = false;
            }
            else
            {
                rbPlayers5.Enabled = true;
                rbPlayers6.Enabled = true;
            }
        }
        /// <summary>
        /// Close The Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        ///  If 6 players are selected. Cannot use a 24 card deck
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbPlayers6_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                if (rbDeck24.Checked)
                    rbDeck36.Select();
                rbDeck24.Enabled = false;
            }
            else
                rbDeck24.Enabled = true;
        }
    }
}
