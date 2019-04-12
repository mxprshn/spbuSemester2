using System.IO;
using NUnit.Framework;

namespace WalkingDog.Tests
{
    [TestFixture]
    public class MapTests
    {
        private Map testMap;        

        [Test]
        [TestCase(".\\Map1.txt")]
        [TestCase(".\\Map2.txt")]
        [TestCase(".\\Map3.txt")]
        [TestCase(".\\Map4.txt")]
        [TestCase(".\\Map5.txt")]
        public void MapConstructorTest(string filePath)
        {
            testMap = new Map(TestContext.CurrentContext.TestDirectory + filePath);

            using (var mapReader = new StreamReader(TestContext.CurrentContext.TestDirectory + filePath))
            {
                var actualHeight = int.Parse(mapReader.ReadLine());
                var actualWidth = int.Parse(mapReader.ReadLine());

                Assert.AreEqual(actualHeight, testMap.Height);
                Assert.AreEqual(actualWidth, testMap.Width);

                for (var i = 0; i < actualHeight; ++i)
                {
                    for (var j = 0; j < actualWidth; ++j)
                    {
                        var currentCharacter = (char)mapReader.Read();

                        while (currentCharacter == '\n' || currentCharacter == '\r')
                        {
                            currentCharacter = (char)mapReader.Read();
                        }

                        if (currentCharacter == '@')
                        {
                            Assert.AreEqual(' ', testMap[i, j]);
                            Assert.AreEqual(i, testMap.DogSpawnPosition.top);
                            Assert.AreEqual(j, testMap.DogSpawnPosition.left);
                        }
                        else if (currentCharacter == '#')
                        {
                            Assert.AreEqual(' ', testMap[i, j]);
                            Assert.AreEqual(i, testMap.EscapePosition.top);
                            Assert.AreEqual(j, testMap.EscapePosition.left);
                        }
                        else
                        {
                            Assert.AreEqual(currentCharacter, testMap[i, j]);
                        }
                    }
                }
            }
        }

        [Test]
        [TestCase(".\\IncorrectMap1.txt")]
        [TestCase(".\\IncorrectMap2.txt")]
        [TestCase(".\\IncorrectMap3.txt")]
        public void IncorrectMapConstructorTest(string filePath)
        {
            Assert.Throws<MapFormatException>(() => testMap = new Map(TestContext.CurrentContext.TestDirectory + filePath));
        }

        [Test]
        [TestCase(".\\Map1.txt")]
        [TestCase(".\\Map2.txt")]
        [TestCase(".\\Map3.txt")]
        [TestCase(".\\Map4.txt")]
        [TestCase(".\\Map5.txt")]
        public void IndexOutOfMapGetterTest(string filePath)
        {
            testMap = new Map(TestContext.CurrentContext.TestDirectory + filePath);

            Assert.AreEqual('*', testMap[testMap.Height + 1, 0]);
            Assert.AreEqual('*', testMap[-10, 0]);
            Assert.AreEqual('*', testMap[0, testMap.Width + 1]);
            Assert.AreEqual('*', testMap[0, -10]);
        }
    }
}