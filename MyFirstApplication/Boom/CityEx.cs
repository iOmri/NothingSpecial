using Pirates;

namespace Boom
{
    public class CityEx : MapObjectEx
    {
        public City City { get; set; }

        public CityEx(City city)
            :base(city)
        {
            City = city;
        }

        public bool IsCamped(int range = -1)
        {
            if (range == -1)
                range = City.UnloadRange;

            // return CountNearbyObjects(GameManager.CurrentTurn.EnemyLivingPirates)
        }
    }
}
