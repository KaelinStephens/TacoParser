using System.Linq;
namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");
            var cells = line.Split(',');         // splits up each line into an array of strings, separated by the char ','
            if (cells.Length < 3)       // If your array.Length is less than 3, something went wrong
            {
                logger.LogError("This line has a Length < 3", null);
                return null; 
            }

            var lat = double.Parse(cells[0]);     // grab the latitude from your array at index 0 and parse string as a `double`
            var lon = double.Parse(cells[1]);     // grab the longitude from your array at index 1 and parse string as a `double`
            var name = cells[2];    // grab the name from your array at index 2

            var store = new TacoBell();
            var point = new Point();
            point.Latitude = lat;
            point.Longitude = lon;
            store.Location = point;
            store.Name = name;
            
            return store;
        }
    }
}