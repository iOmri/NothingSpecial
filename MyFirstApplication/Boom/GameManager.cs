using System.Collections.Generic;

namespace Boom
{
    static class GameManager
    {
        private static Stack<PirateGameEx> previousTurns = new Stack<PirateGameEx>();

        /// <summary>
        /// The current turn. Each assignemnt pushes the previous valuse to a stack
        /// </summary>
        public static PirateGameEx CurrentTurn
        {
            get { return previousTurns.Peek(); }
            set { previousTurns.Push(value); }
        }
    }
}
