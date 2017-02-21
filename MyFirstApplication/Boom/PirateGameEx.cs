using Pirates;
using System.Collections.Generic;

namespace Boom
{
    public class PirateGameEx
    {
        public PirateGame Game { get; set; }


        public List<AircraftEx> MyAircrafts;
        public List<AircraftEx> MyLivingAircrafts;
        public List<AircraftEx> EnemyAircrafts;
        public List<AircraftEx> EnemyLivingAircrafts;

        public List<PirateEx> MyPirates { get; set; }
        public List<PirateEx> MyLivingPirates { get; set; }
        public List<PirateEx> EnemyPirates { get; set; }
        public List<PirateEx> EnemyLivingPirates { get; set;}
        
        public PirateGameEx(PirateGame pirateGame)
        {
            Game = pirateGame;
        }
    }
}
