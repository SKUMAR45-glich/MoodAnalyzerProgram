using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyzer
{
    public class MoodAnalyseFactory
    {
        public static object CreateMoodAnalyse(string className, string constructorName)
        {
           
            Match match = Regex.Match(className, constructorName);

            if (match.Success)
            {
                try
                {
                    Assembly excute = Assembly.GetExecutingAssembly();
                    Type moodAnalyse = excute.GetType(className);
                    return Activator.CreateInstance(moodAnalyse);
                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_CLASS, "No such Class");
                }
            }
            else
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_FIELD, "No such Constructor");
            }

           
        }
    }
}
