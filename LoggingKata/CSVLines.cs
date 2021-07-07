using System;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using GeoCoordinatePortable;
using System.Linq;

namespace LoggingKata
{
    public class CSVLines 
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";
        public  string[] GetCSVLines(string line)
        {
            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(line);
            LogMessage(lines);

            return lines;
        }

        public string LogMessage(string[] lines)
        {
            if (lines[0] == null)
            {
                logger.LogError($"Error: lines[0] is ", null);
                return ($"Error: lines[0] is null");
            }
            else if (lines[1] == null)
            {
                logger.LogWarning($"Warning: {lines[0]} is the only line found");
                return $"Warning: {lines[0]} is the only line found";
            }
            else
            {
                logger.LogInfo("All's good");
                return "All's good";
            }
        }
    }
}
