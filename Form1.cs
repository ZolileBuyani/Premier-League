using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Premier_League.BE;
using Premier_League.BL;
using System.Linq;
using System.Data;

namespace Premier_League
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                RankCalculator rankings = new RankCalculator();
                List<Team> lstTeams =  rankings.GetTeamStandings();

                lstTeams = lstTeams.OrderByDescending(x => x.points).ThenBy(x => x.goalDifference).ThenBy(x => x.goalsScored).ToList();

                int rank = 1;

                listBox1.Items.Add(string.Format("Rank | Name | Played | Won | Drawn | Lost | Goals F | Goals A | Diff | PTS "));
                foreach (Team team in lstTeams)
                {
                    listBox1.Items.Add(string.Format("{0,-10}",
                    rank) + string.Format("{0,-10}", team.name) + string.Format("{0,-9}", team.played) + string.Format("{0,-10}", team.won) + string.Format("{0,-10}", team.draw) + string.Format("{0,-10}", team.lost) + string.Format("{0,-10}", team.goalsScored ) + string.Format("{0,-10}", team.goalsConceded ) + string.Format("{0,-10}", team.goalDifference) + team.points);
                    rank++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oops something went wrong: " + ex.Message, "Application Error");
            }
        }

    }
}
