/**
 * Chapter 13 Example Application: Card Library - Deck class
 * 
 * @author      Karli Watson et al.
 * @transcriber Simon Yarrow (100738683)
 * @version     1.0
 * @since       2020-03-05
 * @see         Beginning Visual C# 2012 Programming (Wrox Press, 2013)
 * NOTE:        Copied for educational purposes by Simon Yarrow (100738683) starting on Jan. 22, 2020, for the class OOP 4200.
 */
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ch13CardLib
{
    /// <summary>
    /// Deck class - represents a standard deck of 52 unique playing cards. The default constructor uses
    /// the Card class and the Rank and Suit enums to create a sorted deck. The class includes a method
    /// to shuffle the deck and a method to get a card (and therefore information about a card) at any
    /// position in the deck.
    /// NEW TO VERSION 2.0: The Deck is now based around a Cards collection object that contains Card
    /// objects. This allows for deep copying of a Deck via the new Clone method, which required that
    /// a new parameterized constructor be created (currently private) that takes a Cards collection
    /// as a parameter and creates a new Deck object with that Cards collection as its content.
    /// NEW TO VERSION 4.0: GetCard updated to use newly created CardOutOfRangeException.
    /// </summary>
    public class Deck : ICloneable
    {
        // Delegate for an event handler called LastCardDrawn (called by GetCard, below)
        public event EventHandler LastCardDrawn;

        private Cards cards = new Cards();   // A collection of cards

        /// <summary>
        /// Deck - default constructor. Populate the Cards collection with 52 cards by cycling
        /// through the values in the Suit and Rank enums to create the 52 possible unique cards
        /// while adding each one to the collection. (The deck is in a "stacked" or "sorted"
        /// state after this.)
        /// </summary>
        public Deck()
        {
            for (int suitVal = 0; suitVal < 4; suitVal++)
            {
                for (int rankVal = 1; rankVal < 14; rankVal++)
                {
                    cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                }
            }
        }

        /// <summary>
        /// Nondefault constructor. Allows aces to be set high.
        /// </summary>
        public Deck(bool isAceHigh) : this()
        {
            Card.isAceHigh = isAceHigh;
        }

        /// <summary>
        /// Nondefault constructor. Allows a trump suit to be used.
        /// </summary>
        public Deck(bool useTrumps, Suit trump) : this()
        {
            Card.useTrumps = useTrumps;
            Card.trump = trump;
        }
        /// <summary>
        /// Nondefault constructor. Allows aces to be set high and a trump suit
        /// to be used.
        /// </summary>
        public Deck(bool isAceHigh, bool useTrumps, Suit trump) : this()
        {
            Card.isAceHigh = isAceHigh;
            Card.useTrumps = useTrumps;
            Card.trump = trump;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deckSize"></param>
        public Deck(bool isAceHigh, bool useTrumps, int deckSize)
        {
            Card.isAceHigh = isAceHigh;
            Card.useTrumps = useTrumps;
            if (deckSize == 24)
            {
                for (int suitVal = 0; suitVal < 4; suitVal++)
                {
                    for (int rankVal = 1; rankVal < 14; rankVal++)
                    {
                        if (rankVal == 1)
                        {
                            cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                            rankVal = 8;
                        }
                        else
                        {
                            cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                        }
                    }
                }
            }
            else if (deckSize == 36)
            {
                for (int suitVal = 0; suitVal < 4; suitVal++)
                {
                    for (int rankVal = 1; rankVal < 14; rankVal++)
                    {
                        if (rankVal == 1)
                        {
                            cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                            rankVal = 5;
                        }
                        else
                        {
                            cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                        }
                    }
                }
            }
            else if (deckSize == 52)
            {
                for (int suitVal = 0; suitVal < 4; suitVal++)
                {
                    for (int rankVal = 1; rankVal < 14; rankVal++)
                    {
                        cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                    }
                }
            }
            else
            {
                throw new IndexOutOfRangeException("Invalid deck size!");
            }
        }

        /// <summary>
        /// GetCard - a method that takes an integer representing a location in the deck (i.e., an index)
        /// as an argument, and returns the card at that location in the deck (the first card is at 
        /// position 0). If that location does not exist within the deck, an CardOutOfRangeException
        /// is thrown (see CardOutOfRangeException.cs in this solution). Also, if there is an event subscribing
        /// to the event handler LastCardDrawn and the parameter indicates the last card in the deck,
        /// the event handler LastCardDrawn is called with this deck object as a parameter.
        /// </summary>
        /// <param name="cardNum">The index of a card to be retrieved (note it is not removed from the deck)</param>
        /// <returns>The card that is in the deck at the indicated index</returns>
        public Card GetCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum <= cards.Count - 1)
            {
                if ((cardNum == cards.Count - 1) && (LastCardDrawn != null))
                    LastCardDrawn(this, EventArgs.Empty);
                return cards[cardNum];
            }
            else
                throw new CardOutOfRangeException((Cards)cards.Clone());
        }

        /// <summary>
        /// Shuffle - a method to randomize the order of cards in a deck while still ensuring that no card
        /// is duplicated. An new Cards collection is created, along with an array of 52 booleans representing
        /// whether the corresponding card in the deck has already been copied into the new collection. A loop
        /// generates a random location within the deck, and, if the card there has not yet been copied into
        /// the new collection, copies that card onto the next end of the new collection, continuing until 52
        /// cards have been copied. Then, the cards in the new collection are copied (in their randomized
        /// order) over the existing cards in the deck using the CopyTo method of the Cards class, resulting in
        /// the deck being "shuffled".
        /// </summary>
        public void Shuffle()
        {
            Cards newDeck = new Cards();
            bool[] assigned = new bool[cards.Count];
            Random sourceGen = new Random();
            for (int i = 0; i < cards.Count; i++)
            {
                int sourceCard = 0;
                bool foundCard = false;
                while (foundCard == false)
                {
                    sourceCard = sourceGen.Next(cards.Count);
                    if (assigned[sourceCard] == false)
                        foundCard = true;
                }
                assigned[sourceCard] = true;
                newDeck.Add(cards[sourceCard]);
            }
            newDeck.CopyTo(cards);
        }

        /// <summary>
        /// Clone - a method that returns an Object (technically a Deck object, but returned as a generic Object) with identical contents
        /// to the current Deck. (This is deep cloning: changing the contents of one Deck will not affect the contents of the other.)
        /// </summary>
        /// <returns>An Object representing a new Deck that is identical to this Deck</returns>
        public object Clone()
        {
            Deck newDeck = new Deck(cards.Clone() as Cards);
            return newDeck;
        }

        /// <summary>
        /// Private parameterized constructor - used by the Clone method, this allows for creation of a new Deck object containing Card
        /// objects in a specific order. In other words, the Cards collection within the Deck that represents the contents is defined as
        /// matching the Cards collection received as a parameter.
        /// </summary>
        /// <param name="newCards">A Cards collection of Card objects that will be the contents (in order) of the new Deck object</param>
        private Deck(Cards newCards)
        {
            cards = newCards;
        }

    }
}