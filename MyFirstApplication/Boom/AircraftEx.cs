using System.Collections.Generic;
using Pirates;
using System.Linq;

namespace Boom
{
    public class AircraftEx : MapObjectEx
    {
        public Aircraft Aircraft { get; set; }
        public bool CanMove { get; set; }
        public bool IsThreatened { get; }
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
            FinalDestination = null;
            IsThreatened = GetThreateningPirates().Count() > 0;            
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
        /// Makes a step towards a destination.
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

        /// <summary>
        /// Gets the list of threatening enemy pirates
        /// </summary>
        /// <returns>PirateEx list</returns>
        public List<PirateEx> GetThreateningPirates()
        {
            return (from enemy in GameManager.CurrentTurn.EnemyLivingPirates
                    where enemy.InAttackRange(this)
                    select enemy).ToList();
        }
    }
}
