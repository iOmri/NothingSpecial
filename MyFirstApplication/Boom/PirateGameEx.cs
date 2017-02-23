using Pirates;
using System.Collections.Generic;
using System.Linq;

namespace Boom
{
    /// <summary>
    /// A wrapper class for PirateGame object
    /// This class contains list of extended API types
    /// </summary>
    public class PirateGameEx
    {
        public PirateGame Game { get; set; }

        // Aircraft lists
        public List<AircraftEx> MyAircrafts { get; set; }
        public List<AircraftEx> MyLivingAircrafts { get; set; }
        public List<AircraftEx> EnemyAircrafts { get; set; }
        public List<AircraftEx> EnemyLivingAircrafts { get; set; }
        
        // City lists
        public List<CityEx> MyCities { get; set; }
        public List<CityEx> EnemyCities { get; set; }

        // Drone lists
        public List<DroneEx> MyLivingDrones { get; set; }
        public List<DroneEx> EnemyLivingDrones { get; set; }
        
        // Island lists
        public List<IslandEx> MyIslands { get; set; }
        public List<IslandEx> NeutralIslands { get; set; }
        public List<IslandEx> EnemyIslands { get; set; }

        // Pirate lists
        public List<PirateEx> MyPirates { get; set; }
        public List<PirateEx> MyLivingPirates { get; set; }
        public List<PirateEx> EnemyPirates { get; set; }
        public List<PirateEx> EnemyLivingPirates { get; set;}
        
        /// <summary>
        /// Creates a new PirateGameEx, initialized with a game turn state
        /// Initializes lists of game objects
        /// </summary>
        /// <param name="pirateGame">Current game turn state</param>
        public PirateGameEx(PirateGame pirateGame)
        {
            Game = pirateGame;

            // PirateEx lists
            MyPirates = CreateExList(Game.GetAllMyPirates());
            MyLivingPirates = CreateExList(Game.GetMyLivingPirates());
            EnemyPirates = CreateExList(Game.GetAllEnemyPirates());
            EnemyLivingPirates = CreateExList(Game.GetEnemyLivingPirates());

            // IslandEx lists
            MyIslands = CreateExList(Game.GetMyIslands());
            NeutralIslands = CreateExList(Game.GetNeutralIslands());
            EnemyIslands = CreateExList(Game.GetEnemyIslands());

            // DroneEx lists
            MyLivingDrones = CreateExList(Game.GetMyLivingDrones());
            EnemyLivingDrones = CreateExList(Game.GetEnemyLivingDrones());

            // CityEx lists
            MyCities = CreateExList(Game.GetMyCities());
            EnemyCities = CreateExList(Game.GetEnemyCities());

            // AircraftEx lists
            MyLivingAircrafts = CreateExList(Game.GetMyLivingAircrafts());
            EnemyLivingAircrafts = CreateExList(Game.GetEnemyLivingAircrafts());
            MyAircrafts = ConvertList<PirateEx, AircraftEx>(MyPirates).Concat(ConvertList<DroneEx, AircraftEx>(MyLivingDrones)).ToList();
            EnemyAircrafts = ConvertList<PirateEx, AircraftEx>(EnemyPirates).Concat(ConvertList<DroneEx, AircraftEx>(EnemyLivingDrones)).ToList();
        }

        /// <summary>
        /// Assignment operator for PirateGame object
        /// </summary>
        /// <param name="pirateGame">New PirateGameEx object</param>
        public static implicit operator PirateGameEx(PirateGame pirateGame)
        {
            return new PirateGameEx(pirateGame);
        }
        
        /// <summary>
        /// Converts a list of type TSource into list of type TDest
        /// while TSource derives from TDest
        /// </summary>
        /// <typeparam name="TSource">The item type of the source list</typeparam>
        /// <typeparam name="TDest">The item type of the destination list</typeparam>
        /// <param name="list">A list of type TSource</param>
        /// <returns>A list of type TDest</returns>
        public static List<TDest> ConvertList<TSource, TDest>(List<TSource> list)
            where TSource : TDest
        {
            List<TDest> result = new List<TDest>();
            list.ForEach((item) => result.Add(item));
            return result;
        }

        /// <summary>
        /// Creates an AircraftEx list from Aircraft list
        /// </summary>
        /// <param name="list">An Aircraft list</param>
        /// <returns>An AircraftEx list</returns>
        private List<AircraftEx> CreateExList(List<Aircraft> list)
        {
            return (from aircraft in list
                    select new AircraftEx(aircraft)).ToList();
        }

        /// <summary>
        /// Creates a CityEx list from City list
        /// </summary>
        /// <param name="list">A City list</param>
        /// <returns>A CityEx list</returns>
        private List<CityEx> CreateExList(List<City> list)
        {
            return (from city in list
                    select new CityEx(city)).ToList();
        }

        /// <summary>
        /// Creates an DroneEx list from Drone list
        /// </summary>
        /// <param name="list">A Drone list</param>
        /// <returns>A DroneEx list</returns>
        private List<DroneEx> CreateExList(List<Drone> list)
        {
            return (from drone in list
                    select new DroneEx(drone)).ToList();
        }

        /// <summary>
        /// Creates an IslandEx list from Island list
        /// </summary>
        /// <param name="list">An Island list</param>
        /// <returns>An IslandEx list</returns>
        private List<IslandEx> CreateExList(List<Island> list)
        {
            return (from island in list
                    select new IslandEx(island)).ToList();
        }

        /// <summary>
        /// Creates an PirateEx list from Pirate list
        /// </summary>
        /// <param name="list">A Pirate list</param>
        /// <returns>A PirateEx list</returns>
        private List<PirateEx> CreateExList(List<Pirate> list)
        {
            return (from pirate in list
                    select new PirateEx(pirate)).ToList();
        }
    }
}
