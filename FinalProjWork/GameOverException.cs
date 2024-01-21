/**
 * GameOverException.cs ~ Custom exception to throw if game is illegal
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

namespace FinalProjWork
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/dotnet/standard/exceptions/how-to-create-user-defined-exceptions
    /// </summary>
    class GameOverException : Exception
    {
        public GameOverException()
        {

        }

        public GameOverException (string message)
            : base(message)
        {

        }

        public GameOverException (string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
