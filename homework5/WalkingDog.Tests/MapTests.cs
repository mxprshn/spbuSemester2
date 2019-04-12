using System;
using System.IO;
using NUnit.Framework;

namespace WalkingDog.Tests
{
    [TestFixture]
    public class MapTests
    {
        private Map testMap;

        [Test]
        [TestCase()]
        public void MapConstructorTest(string filePath)
        {
            testMap = new Map(filePath);

            using (var mapReader = new StreamReader(filePath))
            {
                Assert.AreEqual(int.Parse(mapReader.ReadLine());
                var expectedWidth = int.Parse(mapReader.ReadLine());

                while (!mapReader.EndOfStream)
                {
                    foreach ()
                    {

                    }
                }
            }
        }
}
}
