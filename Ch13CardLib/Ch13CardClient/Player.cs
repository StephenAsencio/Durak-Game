/**
 * Chapter 13 Example Application: Card Client - Player class
 * 
 * @author      Karli Watson et al.
 * @transcriber Simon Yarrow (100738683)
 * @version     1.0
 * @since       2020-03-05
 * @see         Beginning Visual C# 2012 Programming (Wrox Press, 2013)
 * NOTE:        Copied for educational purposes by Simon Yarrow (100738683) starting on Mar. 05, 2020, for the class OOP 4200.
 */
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ch13CardLib;

namespace Ch13CardClient
{
    /// <summary>
    /// The Player class utilized by the game logic in Game.cs (for the card game KarliCards - see also Program.cs)
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Name property - a player's name, which can be retrieve but not set (it can only be set in the constructor)
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// PlayHand property - a player's hand of cards, which can be get but not set through this property
        /// (however, it can be manipulated using methods of the Cards class)
        /// </summary>
        public Cards PlayHand { get; private set; }

        /// <summary>
        /// Default constructor - private, not to be used
        /// </summary>
        private Player()
        {
        }

        /// <summary>
        /// Parameterized constructor - sets a player's name and initial hand of cards
        /// </summary>
        /// <param name="name"></param>
        public Player(string name)
        {
            Name = name;
            PlayHand = new Cards();
        }

        /// <summary>
        /// HasWon - determines whether this player has won a game of KarliCards (note: this makes the Player class
        /// specific to KarliCards)
        /// </summary>
        /// <returns>A boolean representing whether this player has won a game of KarliCards</returns>
        public bool HasWon()
        {
            bool won = true;
            Suit match = PlayHand[0].suit;              // The suit of the first card in the player's hand
            for (int i = 1; i < PlayHand.Count; i++)    // Loop through the rest of the hand...
            {
                won &= PlayHand[i].suit == match;       // ...checking whether each card's suit matches that of the first card
            }
            return won;
        }
    }
}