using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            //      ensure .Parse does something

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("34.176666, -84.420356, Taco Bell Canto...", -84.420356)]
        public void ShouldParseLongitude(string line, double expected)
        {
            //       extract the Longitude.
            //Arrange
            var parse = new TacoParser();
            //Act
            var parsed = parse.Parse(line);
            var actual = parsed.Location.Longitude;
            //Assert
            Assert.Equal(expected, actual);
        }


        //TODO: Create a test ShouldParseLatitude
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("34.176666, -84.420356, Taco Bell Canto...", 34.176666)]
        public void ShouldParseLatitude(string line, double expected)
        {
            //       extract the Latitude.  
            //Arrange
            var parse = new TacoParser();
            //Act
            var parsed = parse.Parse(line);
            var actual = parsed.Location.Latitude;
            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", "Taco Bell Acwort...")]
        [InlineData("34.176666, -84.420356, Taco Bell Canto...", "Taco Bell Canto...")]
        public void ShouldParseName(string line, string expected)
        {
            //       extract the Name.  
            //Arrange
            var parse = new TacoParser();
            //Act
            var parsed = parse.Parse(line);
            var actual = parsed.Name;
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GrabsCSVFile()
        {
            //      ensure csv file is grabbed
            //Arrange
            var lines = new CSVLines();
            //Act
            var actual = lines.GetCSVLines("TacoBell-US-AL.csv");
            //Assert
            Assert.NotNull(actual);
        }
        
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort", "Warning: 34.073638, -84.677017, Taco Bell Acwort is the only line found")]
        [InlineData("", "Error: lines[0] is null")]
        [InlineData("32.571331,-85.499655,Taco Bell Auburn... \n" +
            "32.609135, -85.479907, Taco Bell Auburn... \n" +
        "33.858498, -84.60189, Taco Bell Austel...", "All's good")]
        public void ShouldLogCorrectly(string line, string expected)
        {
            //      ensure log messages are correct for different scenarios 
            //Arrange
            ILog logger = new TacoLogger();
            var lines = new CSVLines();
            //Act
            var parsedLines = lines.GetCSVLines(line);
            var actual = lines.LogMessage(parsedLines);
            //Assert
            Assert.Equal(expected, actual);
        }

         
        /*[Theory]
        [InlineData("34.324462,-86.503055,Taco Bell Ara... \n" +
            "34.992219, -86.841402, Taco Bell Ardmore...\n"+
        "34.795116, -86.97191, Taco Bell Athens...\n"+
            "34.018008, -86.079099, Taco Bell Attall...\n"+
        "32.571331, -85.499655, Taco Bell Auburn...\n"+
        "32.609135, -85.479907, Taco Bell Auburn...\n"+
        "33.858498, -84.60189, Taco Bell Austel...\n"+
        "30.903723, -84.556037, Taco Bell Bainbridg...", Tuple<"Taco Bell Ardmore", "Taco Bell Auburn", 84>)]
        public void ShouldCreateTwoWorkingVariables(string lines, Tuple<ITrackable, ITrackable, double> expected)
        {
            //      extract the two farthest locations and the distance between them

            //Arrange
            var distances = new CSVLines();
            var dist = distances.GetCSVLines(lines);
            
            //Act
            var actual = GetFarthestDistance(dist);
            //Assert
            Assert.Equal(expected, actual);
        }*/

       
    }
}
