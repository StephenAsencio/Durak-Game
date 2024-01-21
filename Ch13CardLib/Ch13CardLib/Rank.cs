/**
 * Chapter 13 Example Application: Card Library - Rank enum
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
    /// An enumeration that holds the 13 possible ranks of a playing card in order.
    /// Assigning the value of 1 to the Ace causes the remaining values to have the
    /// values 2 through 13 respectively, which may be useful for games like Blackjack,
    /// where card values are used mathematically (otherwise, the values would default
    /// to 0 through 12).
    /// </summary>
    public enum Rank
    {
        Ace = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }
}