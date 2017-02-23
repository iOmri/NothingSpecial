using Pirates;

namespace Boom
{
    public class CityEx : MapObjectEx
    {
        public City City { get; set; }

        /// <summary>
        /// Creates new CityEx instance, initialized with a wrapped City instance
        /// </summary>
        /// <param name="city">The wrapped City instance</param>
        public CityEx(City city)
            :base(city)
        {
            City = city;
        }

        /// <summary>
        /// Checks if there are nearby enemy living pirates within a given range. Default range will be the unload range of the city
        /// </summary>
        /// <param name="range">The range to check</param>
        /// <returns>true for enemies nearby, else false</returns>
        public bool IsCamped(int range = -1)
        {
            // The default check range is the unload range of the city
            if (range == -1)
                range = City.UnloadRange;

            // Return true if the list size of nearby enemy pirates within the range is grater than 0
            return CountNearbyObjects(PirateGameEx.ConvertList<PirateEx, MapObjectEx>(GameManager.CurrentTurn.EnemyLivingPirates), range) > 0;
        }
    }
}
