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

        public AircraftEx(Aircraft aircraft)
            :base(aircraft)
        {
            Aircraft = aircraft;
            CanMove = true;
            
            /// TODO:
            /// Check if there are any threats
        }

        public bool HeadTo(MapObjectEx destination)
        {
            if (destination == null)
                return false;

            // if(Aircraft.Location == destination.)

            return true;
        }
    }
}
