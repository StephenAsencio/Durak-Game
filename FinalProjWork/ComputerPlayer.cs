/**
 * ComputerPlayer.cs ~ Class for a computer player. Handles how computer players play the game
 * 
 * @author  Simon Yarrow, Jesse Revell, Stephen Asencio
 * 
 * @version 1.4
 * @since       2020-04-010
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ch13CardLib;

namespace FinalProjWork
{
    class ComputerPlayer : Player
    {
        public override Card MakeAPlay(Cards attackers = null, Cards defenders = null, bool isAttacking = true)
        {
            bool legalMove = false;
            int currentCard = 0;
            do
            {
                legalMove = DurakGame.IsLegalPlay(attackers, defenders, isAttacking, hand[currentCard]);
                currentCard++;
            } while (!legalMove && currentCard < hand.Count());
            if (currentCard > hand.Count() - 1 && !legalMove) // Reached end of hand with no legal play
            {
                return null; // "Pass"
            }
            else
            {
                return hand[currentCard - 1];
            }
        }

        /* MOVED TO DurakGame CLASS
        public bool IsLegal(Cards attackers, Cards defenders, bool isAttacking, Card theCard)
        {
            bool legalMove = false;
            if (isAttacking == true)
            {
                int atkCount = 0;
                while (!legalMove && atkCount < attackers.Count)
                {
                    int atkCardCount = -1;
                    foreach (Card attackingCards in attackers)
                    {
                        atkCardCount++;
                        if (theCard.rank == attackers[atkCardCount].rank)
                        {
                            legalMove = true;
                        }
                        else
                        {
                            legalMove = false;
                            atkCount++;
                        }
                    }
                }
                if (!legalMove)
                {
                    int defCount = 0;
                    while (!legalMove && defCount < defenders.Count)
                    {
                        int defCardCount = -1;
                        foreach (Card defendingCards in defenders)
                        {
                            defCardCount++;
                            if (theCard.rank == defenders[defCardCount].rank)
                            {
                                legalMove = true;
                            }
                            else
                            {
                                legalMove = false;
                                defCount++;
                            }
                        }
                    }
                }
            }
            else
            {
                if ((theCard > attackers[attackers.Count - 1] && theCard.suit == attackers[attackers.Count - 1].suit) || ((attackers[attackers.Count - 1].suit != Card.trump) && theCard.suit == Card.trump))
                {
                    legalMove = true;
                }
                else
                {
                    legalMove = false;
                }
            }
            return legalMove;
        }
        */
    }
}

