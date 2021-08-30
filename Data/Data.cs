using System;
using System.IO;

namespace Premier_League.Data
{
    class Data
    {
        string strPremierLeagueData = File.ReadAllText("Data/input.csv");      
        public string[] GetPremierLeagueData(){
            string[] lines = strPremierLeagueData.Split(new char[] { '\n' },
                StringSplitOptions.RemoveEmptyEntries);
            return lines;
        }
       
    }
}
