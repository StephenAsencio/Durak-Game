/**
 * Program.cs ~ Main method which launches the game
 * 
 * @author  Simon Yarrow, Jesse Revell, Stephen Asencio
 * 
 * @version 2.0
 * @since       2020-04-016
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjWork
{
    static class Program
    { 

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GameGUI Game = new GameGUI();
            Application.Run(Game);
        }
    }
}
