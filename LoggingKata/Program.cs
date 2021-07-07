using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;


namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";
     
        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");
            var csv = new CSVLines();
            var lines = csv.GetCSVLines(csvPath);
            foreach (var line in lines)
            {
                logger.LogInfo($"Lines: {line}");
            }
           
            var parser = new TacoParser();     // Creates a new instance of TacoParser class.
           
            var locations = lines.Select(parser.Parse).ToArray();
            foreach (var line in locations)
            {
                logger.LogInfo($"{line.Name} has successfully parsed");
            }

            ITrackable farthestLocalA = null;       //variable to hold the first of the two farthest points.
            ITrackable farthestLocalB = null;       //variable to hold the second of the two farthest points.
            double distance = FarthestDistanceFinder.GetFarthestDistance(locations, ref farthestLocalA, ref farthestLocalB);    //calls method to find the two stores farthest from each other.
            Console.WriteLine();
            Console.WriteLine($"{farthestLocalA.Name} and {farthestLocalB.Name} are the farthest apart at {distance} meters");
        }
     
    }
}
