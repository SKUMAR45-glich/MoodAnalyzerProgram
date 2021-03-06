﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyzer
{
    public class MoodAnalyser
    {
        string _mood;
        public MoodAnalyser()
        {
            _mood = "";
        }
        public string AnalyseMood(string msg)
        {

            Regex regexExp = new Regex("^(.*[ ])*[sS][aA][dD]([ ].*)*");
            _mood = regexExp.IsMatch(msg) ? "SAD" : "HAPPY";
            return _mood;
        }
    }
}
