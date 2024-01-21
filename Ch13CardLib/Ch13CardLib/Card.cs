/**
 * Chapter 13 Example Application: Card Library - Card class
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
using System.Drawing;

namespace Ch13CardLib

// ATTRIBUTION:
// Playing card faces downloaded from: http://acbl.mybigcommerce.com/52-playing-cards/ on April 9th, 2020.
// Back of cards downloaded from: http://acbl.mybigcommerce.com/back-of-cards/ on April 9th, 2020.
{
    /// <summary>
    /// Card class - represents a standard playing card, with a suit and a rank (no other properties).
    /// Suit and rank can only be set via the parameterized constructor, but can be read from anywhere.
    /// The class also contains a ToString method to return a formatted string describing the card.
    /// NEW TO VERSION 2.0: The class also implements the ICloneable interface and therefore contains
    /// a Clone() method, allowing for copying.
    /// </summary>
    public class Card : ICloneable
    {
        /// <summary>
        /// Flag for trump usage. If true, trumps are valued higher
        /// than cards of other suits.
        /// </summary>
        public static bool useTrumps = false;

        /// <summary>
        /// Trump suit to use if useTrumps is true.
        /// </summary>
        public static Suit trump = Suit.Club;

        /// <summary>
        /// Flag that determines whether aces are higher than kings or lower
        /// than deuces.
        /// </summary>
        public static bool isAceHigh = true;

        // Each card object has a rank and a suit, and these values can be viewed but not changed
        // (except via the parameterized constructor - see below).
        public readonly Rank rank;
        public readonly Suit suit;

        /// <summary>
        /// Card - default constructor. Note "rank" and "suit" will be null. This method is private,
        /// so it cannot be called from outside of this class.
        /// </summary>
        private Card()
        {
        }

        /// <summary>
        /// Card - parameterized constructor. A new card object will be created with suit equal to
        /// the first parameter and rank equal to the second.
        /// </summary>
        /// <param name="newSuit">the suit for the new card being created</param>
        /// <param name="newRank">the rank for the new card being created</param>
        public Card(Suit newSuit, Rank newRank)
        {
            suit = newSuit;
            rank = newRank;
        }

        /// <summary>
        /// ToString - a method that returns a formatted string containing information about this
        /// card; overrides the base Object ToString method.
        /// </summary>
        /// <returns>a formatted string with information about the card</returns>
        public override string ToString()
        {
            return "The " + rank + " of " + suit + "s";
        }

        /// <summary>
        /// Clone - a method that creates and returns a new Object that is a memberwise clone
        /// of the current Card object.
        /// </summary>
        /// <returns>A new Object that is identical to the current Card object</returns>
        public object Clone()
        {
            return MemberwiseClone();
        }

        /// <summary>
        /// Overloaded equals comparison operator. Returns a boolean indicating whether two card
        /// objects are equal (meaning they have equal suit and rank).
        /// </summary>
        /// <param name="card1">First card to compare</param>
        /// <param name="card2">Second card to compare</param>
        /// <returns>Whether the two cards have identical suits and ranks</returns>
        public static bool operator ==(Card card1, Card card2)
        {
            if (object.ReferenceEquals(card1, null))
            {
                return object.ReferenceEquals(card2, null);
            }
            else if (object.ReferenceEquals(card2, null))
            {
                return false;
            }
            else
            {
                return (card1.suit == card2.suit) && (card1.rank == card2.rank);
            }
        }

        /// <summary>
        /// Overloaded "not equal to" comparison operator. Returns a boolean indicating whether two
        /// card objects are not equal (meaning they have differe suits and/or ranks).
        /// </summary>
        /// <param name="card1">First card to compare</param>
        /// <param name="card2">Second card to compare</param>
        /// <returns>Whether the two cards have different suits and/or ranks</returns>
        public static bool operator !=(Card card1, Card card2)
        {
            return !(card1 == card2);
        }

        /// <summary>
        /// Overridden equals function. Returns a boolean indicating whether an object is equal to
        /// this card object (meaning it can be cast as a card object and has the same suit and rank).
        /// </summary>
        /// <param name="card">An object to compare to this card</param>
        /// <returns>Whether the object can be cast as a card with the same suit and rank as this card</returns>
        public override bool Equals(object card)
        {
            return this == (Card)card;
        }

        /// <summary>
        /// Overridden function to return a hash code for this card object. Returns an integer that is
        /// unique to the suit/rank pair of this card. (Cards that are "equal" - i.e., same suit,
        /// same rank - will have the same hash code.)
        /// </summary>
        /// <returns>An integer unique to cards of the suit and rank of this card</returns>
        public override int GetHashCode()
        {
            if (isAceHigh && rank == Rank.Ace)  // If this is an ace and aces are high, make this the highest card in the rank
            {
                return 13 * (int)suit + (int)rank + 13;
            }
            else if (isAceHigh)                 // If this is not an ace and aces are high, move it down one spot in the rank to account for no ace at the bottom
            {
                return 13 * (int)suit + (int)rank - 1;
            }
            else                                // Aces are not high, so assign a value based simply on suit and rank order within their enumerations
            {
                return 13 * (int)suit + (int)rank;
            }
        }

        /// <summary>
        /// Overloaded greater than operator. Returns a boolean indicating whether one card is greater
        /// than (has a higher face value than) a second card, taking into account whether aces have
        /// been set to be high and also whether a trump suit has been set. (If the second card is not
        /// the same suit as the first card, it is higher if it is in the trump suit and lower otherwise.)
        /// </summary>
        /// <param name="card1">A card to test as higher</param>
        /// <param name="card2">A card to test as lower</param>
        /// <returns>Whether the first card is higher than the second card</returns>
        public static bool operator >(Card card1, Card card2)
        {
            if (card1.suit == card2.suit)
            {
                if (isAceHigh)
                {
                    if (card1.rank == Rank.Ace)
                    {
                        if (card2.rank == Rank.Ace)
                            return false;
                        else
                            return true;
                    }
                    else
                    {
                        if (card2.rank == Rank.Ace)
                            return false;
                        else
                            return (card1.rank > card2.rank);
                    }
                }
                else
                {
                    return (card1.rank > card2.rank);
                }
            }
            else
            {
                if (useTrumps && (card2.suit == Card.trump))
                    return false;
                else
                    return true;
            }
        }

        /// <summary>
        /// Overloaded less than operator. Returns a boolean indicating whether one card object
        /// has a lesser value than a second card object, determined by testing whether the
        /// first card is NOT greater than or equal to the second card using the "greater than
        /// or equal to" operator (see below).
        /// </summary>
        /// <param name="card1">A card to test as lower</param>
        /// <param name="card2">A card to test as higher</param>
        /// <returns>Whether the first card is lower than the second card</returns>
        public static bool operator <(Card card1, Card card2)
        {
            return !(card1 >= card2);
        }

        /// <summary>
        /// Overloaded greater than or equal to operator. Returns a boolean indicating whether
        /// one card object has a value greater than or equal to that of a second card object,
        /// taking into consideration whether aces have been set to high and whether a trump
        /// suit has been set (see "greater than" operator above).
        /// </summary>
        /// <param name="card1">A card to test as having higher or equal value</param>
        /// <param name="card2">A card to test as having lower or equal value</param>
        /// <returns>Whether the first card is higher than or equal to the second</returns>
        public static bool operator >=(Card card1, Card card2)
        {
            if (card1.suit == card2.suit)
            {
                if (isAceHigh)
                {
                    if (card1.rank == Rank.Ace)
                    {
                        return true;
                    }
                    else
                    {
                        if (card2.rank == Rank.Ace)
                            return false;
                        else
                            return (card1.rank >= card2.rank);
                    }
                }
                else
                {
                    return (card1.rank >= card2.rank);
                }
            }
            else
            {
                if (useTrumps && (card2.suit == Card.trump))
                    return false;
                else
                    return true;
            }
        }

        /// <summary>
        /// Overloaded "less than or equal to" operator. Returns a boolean indicating whether
        /// a card object has a lower or equal value to a second card object, determined by
        /// checking whether the first card is NOT greater than the second (using the greater
        /// than operator defined above).
        /// </summary>
        /// <param name="card1">A card to check for less than or equal value</param>
        /// <param name="card2">A card to check for higher than or equal value</param>
        /// <returns>Whether the first card is lower than or equal to the second</returns>
        public static bool operator <=(Card card1, Card card2)
        {
            return !(card1 > card2);
        }

        /// <summary>
        /// Finds the appropriate card image and returns that image from the resources; if the
        /// card is not face up, returns the back of a card. If there is an image that fits the
        /// suit and rank of the card, it will return that rank and suit as an image.
        /// </summary>
        /// <returns>The image of the card that is being referenced</returns>
        public Image GetCardImage()
        {
            string imageName;
            Image cardImage;
            imageName = suit + "s" + rank;
            cardImage = Properties.Resources.ResourceManager.GetObject(imageName) as Image;
            return cardImage;
        }
    }
}