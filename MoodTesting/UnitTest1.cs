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
            string msg = "Parameter";
            object expected = new MoodAnalyser(msg);
            object actual = MoodAnalyseFactory.CreateMoodAnalyse(className, cName, msg);

            expected.Equals(actual);
        }
        [TestMethod]
        public void GivenMoodAnalyseClassName_ReturnClassNotFound()
        {
            string className = "MoodAnalyseWrong";
            string cName = className;
            string expected = "No such Class";

            string msg = "Parameter";

            string actualstring; //= MoodAnalyseFactory.CreateMoodAnalyse(className, cName);

            try
            {
                object actual = MoodAnalyseFactory.CreateMoodAnalyse(className, cName, msg);
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

            string msg = "Parameter";
            string expected = "No such Constructor";
            string actualstring; //= MoodAnalyseFactory.CreateMoodAnalyse(className, cName);

            try
            {
                object actual = MoodAnalyseFactory.CreateMoodAnalyse(className, cName, msg);
                actualstring = actual.ToString();
            }
            catch (MoodAnalysisException e)
            {
                actualstring = e.Message;
            }
            Assert.AreEqual(expected, actualstring);
        }
        [TestMethod]
        public void GivenHappyMoodShouldReturnHappy()
        {
            string expected = "HAPPY";
            string mood = MoodAnalyseFactory.InvokeAnalyseMood("HAPPY", "AnalyseMood");
            Assert.AreEqual(expected, mood);
        }

        [TestMethod]
        public void GivenHappyMoodShouldReturnNoSuchMethod()
        {
            string expected = "No such Method";
            string mood;
            try
            {
                mood = MoodAnalyseFactory.InvokeAnalyseMood("Wrong", "AnalyseMood");
            }
            catch (MoodAnalysisException e)
            {
                mood = e.Message;
            }
            Assert.AreEqual(expected, mood);
        }

        [TestMethod]
        public void GivenPropertyShouldReturnHappy()
        {
            string expected = "HAPPY";
            string mood = MoodAnalyseFactory.InvokeAnalyseMood("HAPPY", "AnalyseMood");
            Assert.AreEqual(expected, mood);
        }


        [TestMethod]
        public void GivenPropertyMoodShouldReturnNoSuchProperty()
        {
            string expected = "No such Field";
            string mood;
            try
            {
                mood = MoodAnalyseFactory.SetField("Wrong", "AnalyseMood");
            }
            catch (MoodAnalysisException e)
            {
                mood = e.Message;
            }
            Assert.AreEqual(expected, mood);
        }
    }
}
