using SalaryCapData;
using SalaryCapData.ConsumeJson;
using SalaryCapData.ConsumeJson.Models.Cumulative;
using SalaryCapData.ConsumeJson.Models.Daily;
using SalaryCapData.ConsumeJson.Models.PlayerSalary;
using SalaryCapData.ConsumeJson.Models.Roster;
using SalaryCapData.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SalaryCapServices
{
    public class JsonService
    {
        private readonly ITeam _teams;
        private readonly IPlayer _players;

        public JsonService( GameDBContext context )
        {
            _teams = new TeamService( context );
            _players = new PlayerService( context );
        }

        public void UpdateDailyStats()
        {
            DailyPlayerStats dailyStatsJson = new DailyPlayerStats();
            string[] fileArray = Directory.GetFiles( @"Q:\Users\Stephen\Documents\sportsfeeds\Daily", "*.json" );
            DateTime date = DateTime.Today;
            foreach ( var file in fileArray )
            {

                dailyStatsJson.ReadJsonDeserialize( file, _players, date );
                date = date.AddDays( 1 );

            }
        }
        public void UpdatePlayerRoster()
        {
            ConsumePlayerRoster players = new ConsumePlayerRoster();
            string[] fileArray = Directory.GetFiles( @"Q:\Users\Stephen\Documents\sportsfeeds\", "*.json" );
            IEnumerable<Playersalary> playerSalary = new GetPlayerSalaryList().GetSalaries( @"Q:\Users\Stephen\Documents\sportsfeeds\Salaries\playersalary.json" );
            foreach ( var file in fileArray )
            {
                players.ReadJsonDeserialize( file, _teams, _players, playerSalary );


            }
            foreach ( var file in fileArray )
            {
                try
                {
                    string fileName = Path.GetFileName( file );
                    string x = Path.GetDirectoryName( file );
                    string newDir = Path.GetDirectoryName( file + @"\Processed\" );
                    string moveTo = Path.Combine( newDir, fileName );
                    File.Move( file, newDir );
                }

                catch ( Exception e )
                {
                    Console.WriteLine( "Exception Handled" + e );
                }
            }
        }
        public void LoadCumulativePlayerStats()
        {
            CumulativePlayerStats playerStats = new CumulativePlayerStats();
            string fileName = @"Q:\Users\Stephen\Documents\sportsfeeds\2017\cumulative_player_stats.json";

            playerStats.ReadJsonDeserialize( fileName, _players );
        }
    }

}
