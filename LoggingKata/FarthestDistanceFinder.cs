using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    public class FarthestDistanceFinder
    {
        static readonly ILog logger = new TacoLogger();

        public static double GetFarthestDistance(ITrackable[] locations, ref ITrackable farthestLocalA, ref ITrackable farthestLocalB)  //method to get the distance between the 
        {                                                                                                                               //two farthest points, returns that distance, 
            double distance = 0;                                                                                                        //and updates the locations of the two farthest points.
            for (int iOrigin = 0; iOrigin < locations.Length; iOrigin++)        //  loop to grab each location as the origin.
            {
                var localA = new GeoCoordinate(locations[iOrigin].Location.Latitude, locations[iOrigin].Location.Longitude);

                for (int iDestination = 0; iDestination < locations.Length; iDestination++)      //  loop to grab each location as the destination.
                {
                    var localB = new GeoCoordinate(locations[iDestination].Location.Latitude, locations[iDestination].Location.Longitude);

                    var checker = localA.GetDistanceTo(localB);     //compares coordinates of localA and localB and gives a distance between them.
                    if (checker > distance)                             //if the new distance is greater than the previously saved distance, the new will replace the previous
                    {
                        distance = checker;                             //sets the new distance
                        farthestLocalA = locations[iOrigin];            //sets the new farthest location A to locations[iOrigin]
                        farthestLocalB = locations[iDestination];       //sets the new farthest location B to locations[iDestination]
                        logger.LogInfo($"{locations[iOrigin].Name} set as localA");               //logs the change
                        logger.LogInfo($"{locations[iDestination].Name} set as localB");          //logs the change
                    }
                }
            }

            return distance;
        }
    }
}
