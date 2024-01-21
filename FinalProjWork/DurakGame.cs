/**
 * DurakGame.cs ~ Main game class. Holds all game logic. 
 * 
 * @author  Simon Yarrow, Jesse Revell, Stephen Asencio
 * 
 * @version 2.0
 * @since       2020-04-016
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ch13CardLib;

namespace FinalProjWork
{
    class DurakGame
    {
        #region "Private instance variables"
        private const int MAX_HAND_SIZE = 6;
        private const int DEFAULT_MAX_ATTACKS = 6;
        private int nextPlayer;
        private Deck myDeck;
        private int playerCount;                // Number of players at beginning of game
        private int deckSize;                   // Deck size at beginning of game
        private Card currentCard;
        private int currentIndex;               // Location in deck from which to "draw" next card
        private int boutAttacker;               // Player who is primary attacker this bout
        private int boutDefender;               // Player who is defender this bout
        private Cards attackingCards = new Cards();
        private Cards defendingCards = new Cards();
        private Card trumpCard;
        private bool trumpDrawn = false;        // Whether the trump card has been drawn
        private int? trumpHandId;               // Player who has drawn trump card (nullable so that it can be reset each game)
        private int? lastDurak;                 // Loser of most recent game during this session (nullable in case of tie - i.e., no loser)
        private Random rand = new Random();     // Random number generator to randomize dealer
        private int maxAttacksThisBout;
        private List<Player> gamePlayers = new List<Player>();
        private int dealerId;
        private int DELETEME = 0;
        #endregion

        #region "Constructor"
        /// <summary>
        /// Game Logic method
        /// </summary>
        /// <param name="numPlayers"></param>
        /// <param name="numCards"></param>
        public DurakGame(int numPlayers, int numCards)
        {
            trumpHandId = null;
            currentIndex = 0;
            myDeck = new Deck(true, true, numCards);
            playerCount = numPlayers;
            gamePlayers.Add(new Player());
            for (int h = 1; h < playerCount; h++)
            {
                gamePlayers.Add(new ComputerPlayer());
            }
            deckSize = numCards;
            myDeck.Shuffle();
            dealerId = rand.Next(0, playerCount);
            for (int i = 0; i < MAX_HAND_SIZE; i++)
            {
                for (int j = 0; j < playerCount; j++)
                {
                    gamePlayers[(j + dealerId + 1) % playerCount].AddCard(myDeck.GetCard(currentIndex));
                    currentIndex++;
                }
            }
            if (numPlayers * MAX_HAND_SIZE < numCards) // Trump card still in deck.
            {
                trumpCard = myDeck.GetCard(currentIndex);
                currentIndex++;
            }
            else // Entire deck has been dealt, so trump card is in a player's hand.
            {
                trumpCard = myDeck.GetCard(deckSize - 1);
                trumpDrawn = true;
                trumpHandId = playerCount - 1;
            }
            Card.trump = trumpCard.suit; // Set trump suit in Card class
            for (int k = 0; k < playerCount; k++) // Determine which player has the lowest trump card
            {
                gamePlayers[k].SortHand(); // NOTE: necessary because, currently, the hands are sorting by suit during dealing, before the trump suit is set
                if (currentCard == null && gamePlayers[k].LowestTrumpCard() != null)
                {
                    boutAttacker = k;
                    currentCard = gamePlayers[k].LowestTrumpCard();
                }
                else if (currentCard != null && gamePlayers[k].LowestTrumpCard() != null && gamePlayers[k].LowestTrumpCard() < currentCard)
                {
                    boutAttacker = k;
                    currentCard = gamePlayers[k].LowestTrumpCard();
                }
            }
            if (boutAttacker == playerCount - 1)
                boutDefender = 0;
            else
                boutDefender = boutAttacker + 1;
            nextPlayer = boutAttacker;
            maxAttacksThisBout = DEFAULT_MAX_ATTACKS;
        }
        #endregion
        
        #region "Properties"
        // Accessors
        public int NextPlayer { get { return nextPlayer; } }
        public Cards AttackingCards { get { return attackingCards; } }
        public Cards DefendingCards { get { return defendingCards; } }
        public int? LastDurak { get { return lastDurak; } }
        public Card TrumpCard { get { return trumpCard; } }
        public int BoutAttacker { get { return boutAttacker; } }    // In case we ever want to indicate primary attacker in GUI
        public int BoutDefender { get { return boutDefender; } }    // In case we ever want to indicate defender in GUI
        public int? TrumpHandId { get { return trumpHandId; } }
        #endregion

        #region "Other accessors"
        /// <summary>
        /// Accessor for players hand
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns>Cards</returns>
        public Cards GetPlayerHand(int playerId)
        {
            return gamePlayers[playerId].Hand;
        }
        /// <summary>
        /// accessor for cards remaining in the deck
        /// </summary>
        /// <returns>Cards Remaining</returns>
        public int GetCardsRemaining()
        {
            int cardsRemaining;
            if (!trumpDrawn) // Trump card has been skipped; pretending it's at the bottom of the deck and hasn't been drawn yet
                cardsRemaining = deckSize - currentIndex + 1;
            else
                cardsRemaining = deckSize - currentIndex;
            if (cardsRemaining < 0) // If trump is not drawn in initial hands, it is handled in a way that can make currentIndex > deckSize
                cardsRemaining = 0;
            return cardsRemaining;
        }
        #endregion

        #region "Public methods"
        /// <summary>
        /// Play Turn method. 
        /// This handles what player is currently playing, and who plays next 
        /// </summary>
        /// <param name="currentPlayer"></param>
        /// <returns></returns>
        public int PlayTurn(int currentPlayer)
        {
            bool isAttacking = true;
            if (currentPlayer == boutDefender)
                isAttacking = false;
            currentCard = gamePlayers[currentPlayer].MakeAPlay(attackingCards, defendingCards, isAttacking);
            if (currentCard == null)
                Pass(currentPlayer);
            else
                PlayerMakesPlay(currentPlayer, currentCard);
            return nextPlayer;
        }
        /// <summary>
        /// This method determines if the play is valid
        /// </summary>
        /// <param name="playerNumber"></param>
        /// <param name="cardPlayed"></param>
        /// <returns></returns>
        public bool PlayCard(int playerNumber, Card cardPlayed)
        {
            bool isValidPlay = false;
            if (IsLegalPlay(attackingCards, defendingCards, !(playerNumber == boutDefender), cardPlayed))
            {
                isValidPlay = true;
                PlayerMakesPlay(playerNumber, cardPlayed);
            }
            return isValidPlay;
        }
        /// <summary>
        /// This method passes a turn
        /// </summary>
        /// <param name="playerNumber"></param>
        /// <returns></returns>
        public int Pass(int playerNumber)
        {
            PlayerMakesPlay(playerNumber);
            return nextPlayer;
        }
        #endregion

        #region "Private methods"
        /// <summary>
        /// Main Game logic method. Handles the adding and re
        /// </summary>
        /// <param name="player"></param>
        /// <param name="card"></param>
        private void PlayerMakesPlay(int player, Card card = null)
        {
            // Console.WriteLine("Player " + player + ", card " + card + ", defender " + boutDefender);
            gamePlayers[player].RemoveCard(card);
            bool boutIsOver = false;
            if (player != boutDefender)
            {
                if (card != null)
                {
                    attackingCards.Add(card);
                    nextPlayer = boutDefender;
                }
                else
                {
                    if (player == boutAttacker)
                        nextPlayer = NextViablePlayer(boutDefender); // Next attacker is next player with > 0 cards in hand after defender
                    else
                        nextPlayer = NextViablePlayer(player); // Next attacker is next player with > 0 cards in hand after this player
                    if (nextPlayer == boutAttacker || nextPlayer == boutDefender) // All possible attackers have passed or no attackers have cards in hand
                        boutIsOver = true;
                }
            }
            else // Player is defender
            {
                if (card != null)
                    defendingCards.Add(card);
                if (attackingCards.Count() < maxAttacksThisBout)
                {
                    if (gamePlayers[boutAttacker].Hand.Count == 0) // Bout attacker has no cards left right now
                    {
                        nextPlayer = NextViablePlayer(boutDefender);
                        if (nextPlayer == boutAttacker || nextPlayer == boutDefender) // All possible attackers have passed or no attackers have cards in hand)
                            boutIsOver = true;
                    }
                    else // Normal case: after successful defense, next player is bout attacker
                        nextPlayer = boutAttacker;
                }
                else // Max attacks reached; bout is over
                    boutIsOver = true;
            }
            if (boutIsOver) // PROBLEM: CURRENTLY, GRAPHICS WILL _NOT_ BE UPDATED BETWEEN LAST CARD PLAYED AND THIS
            {
                if (attackingCards.Count() > defendingCards.Count())
                {
                    foreach (Card newCard in attackingCards)
                    {
                        gamePlayers[boutDefender].AddCard(newCard);
                    }
                    foreach (Card newCard in defendingCards)
                    {
                        gamePlayers[boutDefender].AddCard(newCard);
                    }
                }
                for (int i = boutAttacker; i != -1;) // -1 arbitrarily chosen as exit symbol
                {
                    if (i == -2) // -2 arbitrarily chosen as defender symbol
                    {
                        while (gamePlayers[boutDefender].Hand.Count < 6 && currentIndex <= deckSize)
                        {
                            if (currentIndex == deckSize && !trumpDrawn) // If out of range by 1 but trump card has not been drawn, pretend it's the bottom card and draw it
                            {
                                gamePlayers[boutDefender].AddCard(trumpCard);
                                trumpDrawn = true;
                                trumpHandId = boutDefender;
                                currentIndex++; // Out of range by 2, so no more cards can be drawn this game no matter what
                            }
                            else if (currentIndex < deckSize)
                            {
                                gamePlayers[boutDefender].AddCard(myDeck.GetCard(currentIndex));
                                currentIndex++;
                            }
                        }
                        i = -1; // Last player (defender) has been dealt to, so exit loop
                    }
                    else // Fill hand of a player other than defender
                    {
                        while (gamePlayers[i].Hand.Count < 6 && currentIndex <= deckSize)
                        {
                            if (currentIndex == deckSize && !trumpDrawn) // If out of range by 1 but trump card has not been drawn, pretend it's the bottom card and draw it
                            {
                                gamePlayers[i].AddCard(trumpCard);
                                trumpDrawn = true;
                                trumpHandId = i;
                                currentIndex++; // Out of range by 2, so no more cards can be drawn this game no matter what
                            }
                            else if (currentIndex < deckSize)
                            {
                                gamePlayers[i].AddCard(myDeck.GetCard(currentIndex));
                                currentIndex++;
                            }
                        }
                        if (i + 1 == boutDefender) // Skip defender until all other hands have been filled
                        {
                            i = i + 2;
                        }
                        else
                        {
                            i++;
                        }
                        if (i == playerCount) // End of players, loop back to beginning
                        {
                            i = 0;
                            if (i == boutDefender) // Skip defender until all other hands have been filled
                                i++;
                        }
                        if (i == boutAttacker) // Once attacker has been reached again, it's time to refill defender's hand
                            i = -2;
                    }
                }
                if (attackingCards.Count() > defendingCards.Count()) // Defender failed to defend an attacking card
                    boutAttacker = NextViablePlayer(boutDefender); // Next attacker is first player with > 0 cards in hand AFTER DEFENDER
                else // All attacking cards were defended
                    boutAttacker = NextViablePlayer(boutAttacker); // Next attacker is first player with > 0 cards in hand AFTER ATTACKER (defender may have gone out!)
                boutDefender = NextViablePlayer(boutAttacker); // Next defender is first player with > 0 cards in hand after NEW attacker
                attackingCards.Clear();
                defendingCards.Clear();
                if (gamePlayers[boutDefender].Hand.Count >= MAX_HAND_SIZE) // Set max attackers for next bout
                    maxAttacksThisBout = MAX_HAND_SIZE;
                else
                    maxAttacksThisBout = gamePlayers[boutDefender].Hand.Count;
                if (GameIsOver())
                {
                    throw new GameOverException();
                }
                nextPlayer = boutAttacker;
            }
        }
        /// <summary>
        /// Game over method. Checks if the game is over and returns an appropriate boolean
        /// </summary>
        /// <returns></returns>
        private bool GameIsOver()
        {
            bool gameOver = false;
            var playersRemaining = new List<int>();
            for (int i = 0; i < playerCount; i++)
            {
                if (gamePlayers[i].Hand.Count > 0)
                {
                    playersRemaining.Add(i);
                }
            }
            if (playersRemaining.Count == 1)        // One loser (the 'durak')
            {
                lastDurak = playersRemaining.ElementAt(0);
                gameOver = true;
            }
            else if (playersRemaining.Count == 0)   // Tie game (no loser)
            {
                lastDurak = null;
                gameOver = true;
            }
            return gameOver;
        }
        /// <summary>
        /// Determines the next viabl plyer
        /// </summary>
        /// <param name="startPoint"></param>
        /// <returns></returns>
        private int NextViablePlayer(int startPoint)
        {
            int nextViable;
            if (startPoint == playerCount - 1)
                nextViable = 0;
            else
                nextViable = startPoint + 1;
            if (GameIsOver()) // Without this, the 'while' loop below would loop forever if all players have 0 cards in hand
            {
                throw new GameOverException();
            }
            else
            {
                while (gamePlayers[nextViable].Hand.Count == 0)
                {
                    nextViable++;
                    if (nextViable == playerCount)
                        nextViable = 0;
                }
            }
            return nextViable;
        }
        #endregion

        #region "Public static methods"
        /// <summary>
        /// Determines if the play is legal
        /// </summary>
        /// <param name="attackers"></param>
        /// <param name="defenders"></param>
        /// <param name="isAttacking"></param>
        /// <param name="theCard"></param>
        /// <returns></returns>
        public static bool IsLegalPlay(Cards attackers, Cards defenders, bool isAttacking, Card theCard)
        {
            bool legalMove = false;
            if (isAttacking)
            {
                int cardCount = 0;
                if (attackers.Count == 0)
                    legalMove = true;
                while (!legalMove && cardCount < attackers.Count)
                {
                    if (theCard.rank == attackers[cardCount].rank)
                    {
                        legalMove = true;
                    }
                    else
                    {
                        cardCount++;
                    }
                }
                if (!legalMove)
                {
                    cardCount = 0;
                    while (!legalMove && cardCount < defenders.Count)
                    {
                        if (theCard.rank == defenders[cardCount].rank)
                        {
                            legalMove = true;
                        }
                        else
                        {
                            cardCount++;
                        }
                    }
                }
            }
            else // Defending
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
        #endregion
    }
}
