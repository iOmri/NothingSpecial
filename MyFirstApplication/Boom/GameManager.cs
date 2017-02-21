using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boom
{
    static class GameManager
    {
        private static Stack<PirateGameEx> previousTurns = new Stack<PirateGameEx>();
        public static PirateGameEx CurrentTurn
        {
            get { return previousTurns.Peek(); }
            set { previousTurns.Push(value); }
        }
    }
}
