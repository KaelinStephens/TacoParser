using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

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
        [InlineData("34.073638, -84.677017, Taco Bell Acwort", " Taco Bell Acwort")]
        [InlineData("34.176666, -84.420356, Taco Bell Canto", " Taco Bell Canto")]
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
    }
}
