using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyzer
{
    public class MoodAnalyser
    {
        enum Errors
        {
            NULL, Empty, Others
        }
        string mood;
        public string AnalyseMood(string msg)
        {
            if (msg == null)
            {
                throw new MoodAnalysisException(Errors.NULL.ToString());
            }
            else if (msg.Length == 0)
            {
                throw new MoodAnalysisException(Errors.Empty.ToString());
            }
            Regex regexExp = new Regex("^(.*[ ])*[sSaAdD]{3}([ ].*)*");

            try
            {
                mood = regexExp.IsMatch(msg) ? "SAD" : "HAPPY";
            }
            catch (MoodAnalysisException)
            {
                throw new MoodAnalysisException(Errors.Others.ToString());
            }
            return mood;
        }
    }
}
