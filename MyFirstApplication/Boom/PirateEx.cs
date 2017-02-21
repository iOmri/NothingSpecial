using Pirates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boom
{
    public class PirateEx : AircraftEx
    {
        public bool CanAttack { get; set; }
        public Pirate Pirate { get; set; }

        /// <summary>
        /// Constructs a new PirateEx instance, initialized with wrapped Pirate instance
        /// </summary>
        /// <param name="pirate">The wrapped pirate instance</param>
        public PirateEx(Pirate pirate)
            :base(pirate)
        {
            Pirate = pirate;
            /// TODO:
            /// Set CanAttack to true if there are nearby enemies
        }

        /// <summary>
        /// Assignment operator for Pirate
        /// </summary>
        /// <param name="pirate">Pirate object</param>
        public static implicit operator PirateEx(Pirate pirate)
        {
            return new PirateEx(pirate);
        }

        /// <summary>
        /// Attacks a target if possible
        /// Sets CanAttack and CanMove to false if attack is made
        /// </summary>
        /// <param name="target">Target aircraft</param>
        /// <returns>Attack result</returns>
        public bool Attack(AircraftEx target)
        {
            if (!CanAttack)
                return false;

            GameManager.CurrentTurn.Game.Attack(Pirate, target.Aircraft);
            CanAttack = false;
            CanMove = false;
            return true;
        }
    }
}
