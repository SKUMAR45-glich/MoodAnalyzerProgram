using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyzer
{
    public class MoodAnalyser
    {
        string _message;

        public MoodAnalyser()
        {
        }

        public MoodAnalyser(string message)
        {
            this._message = message;
        }

        public string AnalyseMood()
        {
            string regexStr = "^(.*[ ])*[sS][aA][dD]([ ].*)*";
            Regex regexExp = new Regex(regexStr);

            try
            {
                if (this._message.Length == 0)
                {
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.EMPTY, "Mood cannot be empty");
                }
                else if (regexExp.IsMatch(this._message))
                {
                    return "Sad";
                }
                else
                {
                    return "Happy";
                }
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NULL, "Mood cannot have null value");
            }
        }
    }

}
}
