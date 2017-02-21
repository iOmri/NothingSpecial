using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pirates;

namespace Boom
{
    public class AircraftEx : MapObjectEx
    {
        public Aircraft Aircraft { get; set; }
        public bool CanMove { get; set; }
        public bool IsThreatened { get; set; }
        public MapObjectEx FinalDestination { get; set; }

        /// <summary>
        /// Creates a new AircraftEx instance, initialize with wrapped Aircraft instance
        /// </summary>
        /// <param name="aircraft">The wrapped Aircraft</param>
        public AircraftEx(Aircraft aircraft)
            :base(aircraft)
        {
            Aircraft = aircraft;
            CanMove = true;

            /// TODO:
            /// Check if there are any threats
            /// Prerequisites:
            /// PirateGameEx must contain enemy pirates list
            int attackRadius = GameManager.CurrentTurn.Game.GetAttackRange();
            
        }

        /// <summary>
        /// Assignment operator for Aircraft type
        /// </summary>
        /// <param name="aircraft"></param>
        public static implicit operator AircraftEx(Aircraft aircraft)
        {
            return new AircraftEx(aircraft);
        }

        /// <summary>
        /// Makes a step towards a destination
        /// Updates CanMove to false if movement occures
        /// </summary>
        /// <param name="destination">The final destination</param>
        /// <returns>true if movement succeeds, else false</returns>
        public bool HeadTo(MapObjectEx destination)
        {
            // If the pirate cannot move, return false
            if (!CanMove)
                return false;

            // Cannot move to null destination
            if (destination == null)
                return false;

            // Cannot move to the current location
            if (Aircraft.Location == destination.MapObject.GetLocation())
                return false;

            // Get sail options
            List<Location> options = GameManager.CurrentTurn.Game.GetSailOptions(Aircraft, destination.MapObject);

            // If there are no sail options, return false
            if (options == null || options.Count == 0)
                return false;

            // Currently pick the first option
            Location nextDestination = options[0];
            GameManager.CurrentTurn.Game.SetSail(Aircraft, nextDestination);
            CanMove = false;

            return true;
        }
    }
}
