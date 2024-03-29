﻿/**
 * Chapter 13 Example Application: Card Client - Game class
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
    /// The Game class - contains the game logic for the card game "KarliCards" (see also Program.cs for the user interface and
    /// Player.cs for the Player class utilized by the game logic below)
    /// </summary>
    public class Game
    {
        private int currentCard;
        private Deck playDeck;
        private Player[] players;
        private Cards discardedCards;

        /// <summary>
        /// Default (and only) constructor - sets current card pointer to index of first card in a deck, establishes a new deck,
        /// wires the LastCardDrawn event to the Reshuffle event handler, shuffles the deck, and establishes a new empty collection
        /// of cards to hold discarded cards.
        /// </summary>
        public Game()
        {
            currentCard = 0;
            playDeck = new Deck(true);
            playDeck.LastCardDrawn += Reshuffle;
            playDeck.Shuffle();
            discardedCards = new Cards();
        }

        /// <summary>
        /// The Reshuffle event handler - shuffler the deck, empties the discarded cards collection, and resets the current card pointer
        /// </summary>
        /// <param name="source">The deck from which this event was called</param>
        /// <param name="args"></param>
        private void Reshuffle(object source, EventArgs args)
        {
            Console.WriteLine("Discarded cards reshuffled into deck.");
            ((Deck)source).Shuffle();
            discardedCards.Clear();
            currentCard = 0;
        }

        /// <summary>
        /// SetPlayers - sets the game's array of players as equal to the parameter array of players as long as it doesn't
        /// contain too many or too few players (and throws an exception otherwise)
        /// </summary>
        /// <param name="newPlayers"></param>
        public void SetPlayers(Player[] newPlayers)
        {
            if (newPlayers.Length > 7)
                throw new ArgumentException(
                   "A maximum of 7 players may play this game.");

            if (newPlayers.Length < 2)
                throw new ArgumentException(
                   "A minimum of 2 players may play this game.");
            players = newPlayers;
        }

        /// <summary>
        /// DealHands - deals 7 cards into the hand of each player, in order
        /// </summary>
        private void DealHands()
        {
            for (int p = 0; p < players.Length; p++)
            {
                for (int c = 0; c < 7; c++)
                {
                    players[p].PlayHand.Add(playDeck.GetCard(currentCard++));
                }
            }
        }

        /// <summary>
        /// PlayGame - the main gameplay logic of KarliCards
        /// </summary>
        /// <returns>An integer representing the winning player (0 = player 1, etc.)</returns>
        public int PlayGame()
        {
            // Only play if players exist.
            if (players == null)
                return -1;
            // Deal initial hands.
            DealHands();

            // Initialize game vars, including an initial card to place on the
            // table: playCard.
            bool GameWon = false;
            int currentPlayer;
            Card playCard = playDeck.GetCard(currentCard++);
            discardedCards.Add(playCard);

            // Main game loop, continues until GameWon == true.
            do
            {
                // Loop through players in each game round.
                for (currentPlayer = 0; currentPlayer < players.Length;
                     currentPlayer++)
                {
                    // Write out current player, player hand, and the card on the
                    // table.
                    Console.WriteLine("{0}'s turn.", players[currentPlayer].Name);
                    Console.WriteLine("Current hand:");
                    foreach (Card card in players[currentPlayer].PlayHand)
                    {
                        Console.WriteLine(card);
                    }
                    Console.WriteLine("Card in play: {0}", playCard);
                    // Prompt player to pick up card on table or draw a new one.
                    bool inputOK = false;
                    do
                    {
                        Console.WriteLine("Press T to take card in play or D to " +
                                          "draw:");
                        string input = Console.ReadLine();
                        if (input.ToLower() == "t")
                        {
                            // Add card from table to player hand.
                            Console.WriteLine("Drawn: {0}", playCard);

                            // Remove from discarded cards if possible (if deck
                            // is reshuffled it won't be there any more)
                            if (discardedCards.Contains(playCard))
                            {
                                discardedCards.Remove(playCard);
                            }

                            players[currentPlayer].PlayHand.Add(playCard);
                            inputOK = true;
                        }
                        if (input.ToLower() == "d")
                        {
                            // Add new card from deck to player hand.
                            Card newCard;
                            // Only add card if it isn't already in a player hand
                            // or in the discard pile
                            bool cardIsAvailable;
                            do
                            {
                                newCard = playDeck.GetCard(currentCard++);
                                // Check if card is in discard pile
                                cardIsAvailable = !discardedCards.Contains(newCard);
                                if (cardIsAvailable)
                                {
                                    // Loop through all player hands to see if newCard
                                    // is already in a hand.
                                    foreach (Player testPlayer in players)
                                    {
                                        if (testPlayer.PlayHand.Contains(newCard))
                                        {
                                            cardIsAvailable = false;
                                            break;
                                        }
                                    }
                                }
                            } while (!cardIsAvailable);
                            // Add the card found to player hand.
                            Console.WriteLine("Drawn: {0}", newCard);
                            players[currentPlayer].PlayHand.Add(newCard);
                            inputOK = true;
                        }
                    } while (inputOK == false);

                    // Display new hand with cards numbered.
                    Console.WriteLine("New hand:");
                    for (int i = 0; i < players[currentPlayer].PlayHand.Count; i++)
                    {
                        Console.WriteLine("{0}: {1}", i + 1,
                                          players[currentPlayer].PlayHand[i]);
                    }
                    // Prompt player for a card to discard.
                    inputOK = false;
                    int choice = -1;
                    do
                    {
                        Console.WriteLine("Choose card to discard:");
                        string input = Console.ReadLine();
                        try
                        {
                            // Attempt to convert input into a valid card number.
                            choice = Convert.ToInt32(input);
                            if ((choice > 0) && (choice <= 8))
                                inputOK = true;
                        }
                        catch
                        {
                            // Ignore failed conversions, just continue prompting.
                        }
                    } while (inputOK == false);

                    // Place reference to removed card in playCard (place the card
                    // on the table), then remove card from player hand and add
                    // to discarded card pile.
                    playCard = players[currentPlayer].PlayHand[choice - 1];
                    players[currentPlayer].PlayHand.RemoveAt(choice - 1);
                    discardedCards.Add(playCard);
                    Console.WriteLine("Discarding: {0}", playCard);

                    // Space out text for players
                    Console.WriteLine();

                    // Check to see if player has won the game, and exit the player
                    // loop if so.
                    GameWon = players[currentPlayer].HasWon();
                    if (GameWon == true)
                        break;
                }
            } while (GameWon == false);

            // End game, noting the winning player.
            return currentPlayer;
        }
    }
}