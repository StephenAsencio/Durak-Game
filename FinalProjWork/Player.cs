/**
 * Player.cs ~ Player Class, Has Player attributes and a few player specific methods
 * 
 * @author  Simon Yarrow, Jesse Revell, Stephen Asencio
 * 
 * @version 2.0
 * @since       2020-04-016
 */

using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ch13CardLib;


namespace FinalProjWork
{
    public class Player : CollectionBase
    {
        // NOTE: WE PROBABLY NEED TO DO SOMETHING WITH 'AsReadOnly' SO THAT HAND CONTENTS CANNOT BE MANIPULATED VIA 'Hand'!
        protected Cards hand = new Cards();
        public Cards Hand { get { return hand; } }

        /// <summary>
        /// Increases card value if trump card
        /// </summary>
        /// <param name="cardValue"></param>
        /// <param name="card"></param>
        /// <returns>cardValue</returns>
        private int TrumpCardValue(int cardValue, Card card)
        {
            if (card.suit == Card.trump)
            {
                cardValue = cardValue * 100;
            }

            return cardValue;
        }

        /// <summary>
        /// Empty cards collection (the player hand)
        /// </summary>
        /// <param name="cards"></param>
        public void AddCard(Card newCard)
        {
            hand.Add(newCard);
            SortHand();
        }

        /// <summary>
        /// Method to remove card from hand
        /// </summary>
        /// <param name="playedCard"></param>
        public void RemoveCard(Card playedCard)
        {
            hand.Remove(playedCard);
        }

        /// <summary>
        /// Returns lowest trump card
        /// </summary>
        /// <returns></returns>
        public Card LowestTrumpCard()
        {
            Card theCard = null;
            int handCount = 0;
            while (theCard == null && handCount < hand.Count)
            {
                if (hand[handCount].suit == Card.trump)
                {
                    theCard = hand[handCount];
                }
                else
                {
                    handCount++;
                }
            }
            return theCard;
        }

        /// <summary>
        /// Sort hand when new card added - by value excluding trump, follow by trump by value
        /// </summary>
        /// <param name="hand"></param>
        public void SortHand()
        {
            Card tempCard;
            for (int cardCount = 0; cardCount < hand.Count() - 1; )
            {
                int cardValue = hand[cardCount].GetHashCode();
                cardValue = TrumpCardValue(cardValue, hand[cardCount]);

                int nextCardValue = hand[cardCount + 1].GetHashCode();
                nextCardValue = TrumpCardValue(nextCardValue, hand[cardCount + 1]);

                if (cardValue > nextCardValue)
                {
                    tempCard = hand[cardCount];
                    hand.Remove(tempCard);
                    hand.Add(tempCard);
                    cardCount = 0;
                }
                else
                {
                    cardCount++;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="attackers"></param>
        /// <param name="defenders"></param>
        /// <param name="isAttacking"></param>
        /// <returns></returns>
        public virtual Card MakeAPlay(Cards attackers = null, Cards defenders = null, bool isAttacking = true)
        {
            return null;
        }
    }
}
