using System;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using GeoCoordinatePortable;


namespace LoggingKata
{
    public class CSVLines 
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";
        public  string[] GetCSVLines(string line)
        {
            var lines = File.ReadAllLines(line);         //  grabs all the lines from csv file

            return lines;
        }
    }
}
