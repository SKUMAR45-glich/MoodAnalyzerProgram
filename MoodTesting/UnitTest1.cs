using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzer;
namespace MoodTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestforSad()
        {
            //Arrange
            MoodAnalyser moodAnalyser = new MoodAnalyser();
            string msg = "I am in Sad Mood";
            string mood = "SAD";

            //Act
            string result = moodAnalyser.AnalyseMood(msg);

            //Assert
            Assert.AreEqual(mood, result);
        }
        [TestMethod]
        public void TestforHappy()
        {
            //Arrange
            MoodAnalyser moodAnalyser = new MoodAnalyser();
            string msg = "I am in Any Mood";
            string mood = "HAPPY";

            //Act
            string result = moodAnalyser.AnalyseMood(msg);

            //Assert
            Assert.AreEqual(mood, result);
        }
    }
}
