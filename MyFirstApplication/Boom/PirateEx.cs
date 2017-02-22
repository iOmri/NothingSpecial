using Pirates;
using System.Collections.Generic;
using System.Linq;

namespace Boom
{
    public class PirateEx : AircraftEx
    {
        private bool canAttack;

        public bool CanAttack
        {
            get { return canAttack && CanMove; }
            set { canAttack = value; }
        }

        public Pirate Pirate { get; set; }

        /// <summary>
        /// Constructs a new PirateEx instance, initialized with wrapped Pirate instance
        /// </summary>
        /// <param name="pirate">The wrapped pirate instance</param>
        public PirateEx(Pirate pirate)
            :base(pirate)
        {
            Pirate = pirate;
            canAttack = GetAttackOptions().Count > 0;
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
            // Return false if attack cannot be made
            if (!CanAttack)
                return false;

            // Return false if the given target is not within the range
            if (!InAttackRange(target))
                return false;

            // Attack
            GameManager.CurrentTurn.Game.Attack(Pirate, target.Aircraft);
            CanAttack = false;
            CanMove = false;
            return true;
        }

        /// <summary>
        /// Checks if a map object is within the attack range of the pirate
        /// </summary>
        /// <param name="target">The attack target</param>
        /// <returns>true if the target is within the range, else false</returns>
        public bool InAttackRange(MapObjectEx target)
        {
            return Pirate.InAttackRange(target.MapObject);
        }

        /// <summary>
        /// Returns a list of all living enemy aircrafts that are within the attack range
        /// </summary>
        /// <returns>AircraftEx list</returns>
        public List<AircraftEx> GetAttackOptions()
        {
            return (from aircraft in GameManager.CurrentTurn.EnemyLivingAircrafts
                    where InAttackRange(aircraft)
                    select aircraft).ToList();
        }


    }
}
