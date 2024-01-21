/**
 * Chapter 13 Example Application: Card Client - Program class
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
    class Program
    {
        static void Main(string[] args)
        {
            // NOTE: the following is the contents of the "Main" method established earlier in Chapter 13, rendered obsolete by the
            // card game code that followed later.

            /*
            /// This is a simple tester file to test the custom exception CardOutOfRangeException. It creates a standard 52-card deck,
            /// tries to retrieve the card located at position 60 (the 61st position) in the deck, catches the exception thrown,
            /// outputs the message contained in the exception, and outputs the card in position 0 (first position) in the exception's
            /// internal deck to show that the exception now contains a clone of the deck created in this tester.
            Deck deck1 = new Deck();
            try
            {
                Card myCard = deck1.GetCard(60);
            }
            catch (CardOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.DeckContents[0]);
            }
            Console.ReadKey();
            */

            Cards cards = new Cards();
            Deck deck = new Deck();
            for (int i = 0; i < 52; i++)
            {
                cards.Add(deck.GetCard(i));
            }
            Console.WriteLine("Cards length: " + cards.Count);
            Console.WriteLine(cards[3].ToString());
            cards.Remove(cards[3]);
            Console.WriteLine("Cards length: " + cards.Count);
            Console.WriteLine(cards[3].ToString());
            cards.Add(deck.GetCard(3));
            Console.WriteLine("Cards length: " + cards.Count);
            Console.WriteLine(cards[51].ToString());
            Console.ReadKey();


            /*
            // The "KarliCards" card game (user interface - note that the game logic is contained in Game.cs)

            // Display introduction.
            Console.WriteLine("KarliCards: a new and exciting card game.");
            Console.WriteLine("To win you must have 7 cards of the same suit in" +
                              " your hand.");
            Console.WriteLine();

            // Prompt for number of players.
            bool inputOK = false;
            int choice = -1;
            do
            {
                Console.WriteLine("How many players (2–7)?");
                string input = Console.ReadLine();
                try
                {
                    // Attempt to convert input into a valid number of players.
                    choice = Convert.ToInt32(input);
                    if ((choice >= 2) && (choice <= 7))
                        inputOK = true;
                }
                catch
                {
                    // Ignore failed conversions, just continue prompting.
                }
            } while (inputOK == false);

            // Initialize array of Player objects.
            Player[] players = new Player[choice];

            // Get player names.
            for (int p = 0; p < players.Length; p++)
            {
                Console.WriteLine("Player {0}, enter your name:", p + 1);
                string playerName = Console.ReadLine();
                players[p] = new Player(playerName);
            }

            // Start game.
            Game newGame = new Game();
            newGame.SetPlayers(players);
            int whoWon = newGame.PlayGame();

            // Display winning player.
            Console.WriteLine("{0} has won the game!", players[whoWon].Name);
            Console.ReadKey();
            */
        }
    }
}