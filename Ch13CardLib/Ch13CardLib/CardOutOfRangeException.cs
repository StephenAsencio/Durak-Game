/**
 * Chapter 13 Example Application: Card Library - CardOutOfRangeException class
 * 
 * @author      Karli Watson et al.
 * @transcriber Simon Yarrow (100738683)
 * @version     1.0
 * @since       2020-03-05
 * @see         Beginning Visual C# 2012 Programming (Wrox Press, 2013)
 * NOTE:        Copied for educational purposes by Simon Yarrow (100738683) starting on Mar. 03, 2020, for the class OOP 4200.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch13CardLib
{
    /// <summary>
    /// New exception class: CardOutOfRangeException. This exception is to be thrown whenever code attempts to access
    /// a card at a position in the deck where no card exists (either before the first card position of 0 or after the
    /// position of the final card in the deck - e.g., 51 in a standard deck).
    /// </summary>
    public class CardOutOfRangeException : Exception
    {
        /// <summary>
        /// Private field to hold a deck of cards (should be a CLONE of the deck that generated this exception)
        /// </summary>
        private Cards deckContents;

        /// <summary>
        /// Public property to return (but not set) the deck of cards in the private field above
        /// </summary>
        public Cards DeckContents
        {
            get
            {
                return deckContents;
            }
        }

        /// <summary>
        /// Parameterized constructor - takes a deck of cards as a parameter (should be a CLONE of the deck in question)
        /// and stores it in the exception object so that its contents can be referenced if needed, even if the original
        /// deck's contents (e.g., card order) change.
        /// </summary>
        /// <param name="sourceDeckContents"></param>
        public CardOutOfRangeException(Cards sourceDeckContents)
           : base("There are only " + sourceDeckContents.Count +" cards in the deck.")
        {
            deckContents = sourceDeckContents;
        }
    }
}
