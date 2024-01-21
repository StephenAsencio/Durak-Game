/**
 * Chapter 13 Example Application: Card Library - Cards class
 * 
 * @author      Karli Watson et al.
 * @transcriber Simon Yarrow (100738683)
 * @version     1.0
 * @since       2020-03-05
 * @see         Beginning Visual C# 2012 Programming (Wrox Press, 2013)
 * NOTE:        Copied for educational purposes by Simon Yarrow (100738683) starting on Feb. 06, 2020 for the class OOP 4200.
 */
 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch13CardLib
{
    public class Cards : List<Card>, ICloneable
    {
        /// <summary>
        /// Utility method for copying card instances into another Cards
        /// instance—used in Deck.Shuffle(). This implementation assumes that
        /// source and target collections are the same size.
        /// </summary>
        /// <param name="targetCards">A Cards collection that will be filled with the same content as this Cards collection</param>
        public void CopyTo(Cards targetCards)
        {
            for (int index = 0; index < this.Count; index++)
            {
                targetCards[index] = this[index];
            }
        }


        /// <summary>
        /// Return an Object which is a deep copy of this Cards collection (via deep copying).
        /// </summary>
        /// <returns>An Object (a Cards object, but returned as a generic Object) that is a copy of this Cards collection</returns>
        public object Clone()
        {
            Cards newCards = new Cards();
            foreach (Card sourceCard in this)
            {
                newCards.Add((Card)sourceCard.Clone());
            }
            return newCards;
        }

        // NOTE: All code below was rendered obsolete after changes to this file made in Chapter 12 (the Cards class was set to implement
        // a generic List of Card objects, which has the following methods already included)

        ///// <summary>
        ///// Adds a given Card object to this Cards collection (numerically, in terms of indeces, it is added
        ///// to the end of the collection).
        ///// </summary>
        ///// <param name="newCard">A Card object to be added to this collection</param>
        //public void Add(Card newCard)
        //{
        //    List.Add(newCard);
        //}

        ///// <summary>
        ///// Removes from this Cards collection a Card object matching the parameter.
        ///// </summary>
        ///// <param name="oldCard">A Card object to be removed from the Cards collection</param>
        //public void Remove(Card oldCard)
        //{
        //    List.Remove(oldCard);
        //}

        ///// <summary>
        ///// A property to give Cards collections array-like index reference functionality for getting or setting
        ///// the Card object at a given index within this Cards.
        ///// </summary>
        ///// <param name="cardIndex">An index in this Cards collection (treating it as a 0-based array)</param>
        ///// <returns>Via "get", returns the Card object stored at the given index</returns>
        //public Card this[int cardIndex]
        //{
        //    get
        //    {
        //        return (Card)List[cardIndex];
        //    }
        //    set
        //    {
        //        List[cardIndex] = value;
        //    }
        //}

        ///// <summary>
        ///// Check to see if the Cards collection contains a particular card.
        ///// This calls the Contains() method of the ArrayList for the collection,
        ///// which you access through the InnerList property.
        ///// </summary>
        ///// <param name="card">A Card to be checked against this Cards collection</param>
        ///// <returns>A Boolean representing whether the Card in question was found within this Cards collection</returns>
        //public bool Contains(Card card)
        //{
        //    return InnerList.Contains(card);
        //}
    }
}