using Pirates;
using System.Collections.Generic;
using System.Linq;

namespace Boom
{
    public class PirateGameEx
    {
        public PirateGame Game { get; set; }


        public List<AircraftEx> MyAircrafts { get; set; }
        public List<AircraftEx> MyLivingAircrafts { get; set; }
        public List<AircraftEx> EnemyAircrafts { get; set; }
        public List<AircraftEx> EnemyLivingAircrafts { get; set; }

        public List<DroneEx> MyLivingDrones { get; set; }
        public List<DroneEx> EnemyLivingDrones { get; set; }

        public List<PirateEx> MyPirates { get; set; }
        public List<PirateEx> MyLivingPirates { get; set; }
        public List<PirateEx> EnemyPirates { get; set; }
        public List<PirateEx> EnemyLivingPirates { get; set;}
        
        public PirateGameEx(PirateGame pirateGame)
        {
            Game = pirateGame;

            MyPirates = CreateExList(Game.GetAllMyPirates());
            MyLivingPirates = CreateExList(Game.GetMyLivingPirates());
            EnemyPirates = CreateExList(Game.GetAllEnemyPirates());
            EnemyLivingPirates = CreateExList(Game.GetEnemyLivingPirates());

            MyLivingDrones = CreateExList(Game.GetMyLivingDrones());
            EnemyLivingDrones = CreateExList(Game.GetEnemyLivingDrones());

            MyLivingAircrafts = CreateExList(Game.GetMyLivingAircrafts());
            MyAircrafts = ConvertList<PirateEx, AircraftEx>(MyPirates) +
                ConvertList<DroneEx, AircraftEx>(MyLivingDrones);
            EnemyLivingAircrafts = CreateExList(Game.GetEnemyLivingAircrafts());

            
        }

        private List<AircraftEx> CreateExList(List<Aircraft> list)
        {
            return (from aircraft in list
                    select new AircraftEx(aircraft)).ToList();
        }

        private List<DroneEx> CreateExList(List<Drone> list)
        {
            return (from drone in list
                    select new DroneEx(drone)).ToList();
        }

        private List<PirateEx> CreateExList(List<Pirate> list)
        {
            return (from pirate in list
                    select new PirateEx(pirate)).ToList();
        }

        private List<TDest> ConvertList<TSource, TDest>(List<TSource> list)
            where TSource : TDest
        {
            List<TDest> result = new List<TDest>();
            if (!typeof(TDest).IsSubclassOf(typeof(TSource)))
                return result;

            foreach (TSource src in list)
                result.Add(src);

            return result;
        }
    }
}
