using System.Linq;
namespace LoggingKata
{
    public interface ITrackable
    {
        public string Name { get; set; }
        public Point Location { get; set; }
    }
}