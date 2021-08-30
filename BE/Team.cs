using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premier_League.BE
{
   public class Team
    {

        //declare constant value for points in case of a win
        const int PointsWin = 3;
        const int PointsDraw = 1;


        public string name { get; set; }
        public int played { get; set; }
        public int points { get; set; }
        public int won { get; set; }
        public int lost { get; set; }
        public int draw { get; set; }
        public int goalsScored { get; set; }
        public int goalsConceded { get; set; }
        public int goalDifference { get; set; }

        public Team() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="RoundResult"></param>
        public void CalculatePoints (string RoundResult)
        {
            RoundResult = RoundResult.Replace(" ", string.Empty);            
            if (RoundResult[0] > RoundResult[2]){
                points += PointsWin;
                won++;
            }            
            else if (RoundResult[0] == RoundResult[2])
            {
                points += PointsDraw;
                draw++;
            }
            else
            {                
                lost++;                
            }
            
        }
        /// <summary>
        /// Calculates total goals scored by a team
        /// </summary>
        /// <param name="RoundResult"></param>
        public void CalculateGoalsScored(string RoundResult)
         {
            int goals = Convert.ToInt32(RoundResult.Substring(0,1));
            goalsScored += goals;           
         }

        /// <summary>
        /// Calculates total goals conceded by a team
        /// </summary>
        /// <param name="RoundResult"></param>
        public void CalculateGoalsConceded(string RoundResult)
        {
            int goals = Convert.ToInt32(RoundResult.Substring(2, 1));
            goalsConceded += goals;
        }       

        public  void CalculateGoalDifference(string RoundResult)
        {
            goalDifference = goalsScored - goalsConceded;         
        }

    }
}
