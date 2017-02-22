using Pirates;

namespace Boom
{
    public class DroneEx : AircraftEx
    {
        public Drone Drone { get; set; }

        /// <summary>
        /// Creates a new DroneEx instance, initialized with wrapped Drone instance
        /// </summary>
        /// <param name="drone">The wrapped Drone instance</param>
        public DroneEx(Drone drone)
            :base(drone)
        {
            Drone = drone;
        }

        /// <summary>
        /// Assignment operator for Drone objects
        /// </summary>
        /// <param name="drone">Drone object</param>
        public static implicit operator DroneEx(Drone drone)
        {
            return new DroneEx(drone);
        }
    }
}
