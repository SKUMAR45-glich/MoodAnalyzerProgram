using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzer;
namespace MoodTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldreturnMoodAnalyserObject()
        {
            string className = "MoodAnalyser";
            string cName = className;
            object expected = new MoodAnalyser();
            object actual = MoodAnalyseFactory.CreateMoodAnalyse(className, cName);

            expected.Equals(actual);
        }
        [TestMethod]
        public void GivenMoodAnalyseClassName_ReturnClassNotFound()
        {
            string className = "MoodAnalyseWrong";
            string cName = className;
            string expected = "No such Class";
            string actualstring; //= MoodAnalyseFactory.CreateMoodAnalyse(className, cName);

            try
            {
                object actual = MoodAnalyseFactory.CreateMoodAnalyse(className, cName);
                actualstring = actual.ToString();
            }
            catch (MoodAnalysisException e)
            {
                actualstring = e.Message;
            }
            Assert.AreEqual(expected, actualstring);
        }
        [TestMethod]
        public void GivenMoodAnalyseClassName_ReturnConstructorNotFound()
        {
            string className = "MoodAnalyser";
            string cName = "MoodAnalyseW";
            string expected = "No such Constructor";
            string actualstring; //= MoodAnalyseFactory.CreateMoodAnalyse(className, cName);

            try
            {
                object actual = MoodAnalyseFactory.CreateMoodAnalyse(className, cName);
                actualstring = actual.ToString();
            }
            catch (MoodAnalysisException e)
            {
                actualstring = e.Message;
            }
            Assert.AreEqual(expected, actualstring);
        }
    }
}
