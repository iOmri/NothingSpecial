using Pirates;
using System.Collections.Generic;
using System.Linq;

namespace Boom
{
    public class IslandEx : MapObjectEx
    {
        public Island Island { get; set; }
        public List<PirateEx> SurroundingEnemies { get; set; }

        /// <summary>
        /// Creates a new IslandEx instance, initialized with a wrapped Island instance
        /// </summary>
        /// <param name="island">The wrapped Island instance</param>
        public IslandEx(Island island)
            : base(island)
        {
            Island = island;

            // Filtered enemy living pirates list by their distance to the island
            SurroundingEnemies = (from enemy in GameManager.CurrentTurn.EnemyLivingPirates
                                  where Island.InControlRange(enemy.Pirate)
                                  select enemy).ToList();
        }

        /// <summary>
        /// Gets my closest city to the island
        /// </summary>
        /// <returns>CityEx object</returns>
        public CityEx GetClosestCity()
        {
            return GetClosest(PirateGameEx.ConvertList<CityEx, MapObjectEx>(GameManager.CurrentTurn.MyCities)) as CityEx;
        }
    }
}
