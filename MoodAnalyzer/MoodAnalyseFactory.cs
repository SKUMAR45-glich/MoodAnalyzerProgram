using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyzer
{
    public class MoodAnalyseFactory
    {
        public static object CreateMoodAnalyse(string className, string constructorName, string msg)
        {
            Type type;
            Match match = Regex.Match(className, constructorName);

            if (match.Success)
            {
                try
                {
                    type = Type.GetType("MoodAnalyzer." + className);
                }
                catch (Exception)
                {
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_CLASS, "No such Class");
                }
            }
            else
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_FIELD, "No such Constructor");
            }

            ConstructorInfo constructorInfo = type.GetConstructor(new Type[] { typeof(string) });
            object[] parameter = new object[] { msg };
            object result = constructorInfo.Invoke(parameter);

            return result;
        }

        public static string InvokeAnalyseMood(string msg, string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyzer.MoodAnalyser");
                object moodAnalyse = CreateMoodAnalyse("MoodAnalyzer.MoodAnalyser", "MoodAnalyser", msg);
                MethodInfo analyseMood = type.GetMethod(methodName);
                object mood = analyseMood.Invoke(moodAnalyse, null);
                return mood.ToString();

            }
            catch(NullReferenceException)
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_METHOD, "No such Method");
            }
        }

        public static string SetField(string msg, string fieldName)
        {
            try
            {
                MoodAnalyser moodAnalyser = new MoodAnalyser();
                Type type = typeof(MoodAnalyser);
                FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (msg == null)
                {
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_FIELD, "Msg cannot be null");
                }
                field.SetValue(moodAnalyser, msg);
                return moodAnalyser.msg;
            }
            catch(NullReferenceException)
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_FIELD, "No such Field");
            }
            
        }
       
    }
}
