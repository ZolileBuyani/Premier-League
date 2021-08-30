using System;
using System.Collections.Generic;
using Premier_League.BE;
using Premier_League.Data;
using System.Threading.Tasks;

namespace Premier_League.BL
{
    class RankCalculator
    {

        public List<Team> GetTeamStandings()
        {
            try
            {
                Data.Data leagueData = new Data.Data();
                string[] lines = leagueData.GetPremierLeagueData();
                List<Team> lstTeams = new List<Team>();

                for (int z = 1; z <= lines.Length - 1; z++)
                {
                    Team team = new Team();
                    string[] matchResults = lines[z].Split(',');
                    team.name = matchResults[0];

                    for (int y = 1; y <= matchResults.Length - 1;)
                    {
                        matchResults[y] = matchResults[y].Replace(" ", string.Empty);

                        team.CalculatePoints(matchResults[y]);
                        team.CalculateGoalsScored(matchResults[y]);
                        team.CalculateGoalsConceded(matchResults[y]);
                        team.CalculateGoalDifference(matchResults[y]);
                        team.played++;
                        y++;
                    }

                    lstTeams.Add(team);
                }

                return lstTeams;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
