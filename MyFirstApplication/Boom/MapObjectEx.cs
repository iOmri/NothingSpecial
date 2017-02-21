﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pirates;

namespace Boom
{
    public class MapObjectEx
    {
        MapObject MapObject { get; set; }

        /// <summary>
        /// Created a new MapObjectEx instance, initialized with wrapped MapObject instance
        /// </summary>
        /// <param name="mapObject">The wrapped MapObject</param>
        public MapObjectEx(MapObject mapObject)
        {
            MapObject = mapObject;
        }

        /// <summary>
        /// Returns the distance in tiles from other MapObjectEx
        /// </summary>
        /// <param name="other">Other MapObjectEx instance</param>
        /// <returns>The distance in tiles</returns>
        public int Distance(MapObjectEx other)
        {
            return MapObject.Distance(other.MapObject);
        }

        /// <summary>
        /// Calculates the air distance from other MapObjectEx
        /// </summary>
        /// <param name="other">Other MapObjectEx instance</param>
        /// <returns>The air distance</returns>
        public double AirDistance(MapObjectEx other)
        {
            int dx = MapObject.GetLocation().Col - other.MapObject.GetLocation().Col;
            int dy = MapObject.GetLocation().Row - other.MapObject.GetLocation().Row;

            // Simple pythtagoras
            return Math.Sqrt(dx * dx + dy * dy);
        }

        /// <summary>
        /// Sorts MapObjectEx list by each item's distance to this instance
        /// </summary>
        /// <param name="objects">MapObject list</param>
        /// <returns>Sorted list by distance to this instance</returns>
        public List<MapObjectEx> SortByDistance(List<MapObjectEx> objects)
        {
            // Don't change the original list
            List<MapObjectEx> copy = new List<MapObjectEx>(objects);

            // Bubble sort by distance from this map object
            for(int i = 0; i < copy.Count; i++)
            {
                for(int j = 0; j < copy.Count - i - 1; j++)
                {
                    if(Distance(copy[j]) > Distance(copy[j+1]))
                    {
                        MapObjectEx temp = copy[j];
                        copy[j] = copy[j + 1];
                        copy[j + 1] = temp;
                    }
                }
            }

            return copy;
        }

        /// <summary>
        /// Gets the closest MapObjectEx object to this instance from a given list
        /// </summary>
        /// <param name="objects">MapObject list</param>
        /// <returns>The closest object from a given list</returns>
        public MapObjectEx GetClosest(List<MapObjectEx> objects)
        {
            return SortByDistance(objects)[0];
        }

        /// <summary>
        /// Filters MapObjectEx instances that are withing a given range from this instance
        /// </summary>
        /// <param name="objects">MapObject list</param>
        /// <param name="radius">The filter radius</param>
        /// <returns>Filtered list</returns>
        public List<MapObjectEx> NearbyObjects(List<MapObjectEx> objects, int radius)
        {
            List<MapObjectEx> result = new List<MapObjectEx>();

            // Add to the result each object that is in the range
            foreach (MapObjectEx mapObject in objects)
                if (Distance(mapObject) <= radius)
                    result.Add(mapObject);

            return result;
        }

        /// <summary>
        /// Counts objects from given lists that are within a given range
        /// </summary>
        /// <param name="objects">MapObject list</param>
        /// <param name="radius">The filter radius</param>
        /// <returns>Filtered list</returns>
        public int CountNearbyObjects(List<MapObjectEx> objects, int radius)
        {
            return NearbyObjects(objects, radius).Count;
        }
    }
}
