using SalaryCapData;
using SalaryCapData.ConsumeJson;
using SalaryCapData.ConsumeJson.Models.Cumulative;

using SalaryCapData.ConsumeJson.Models.PlayerSalary;
using SalaryCapData.ConsumeJson.Models.PlayerStats;
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
            int i = 0;
            foreach ( var file in fileArray )
            {
                System.Diagnostics.Debug.WriteLine( "Reading Daily Stats: " + file + " " + i++ + " of " + fileArray.Length );

                dailyStatsJson.ReadJsonDeserialize( file, _players, date );
                date = date.AddDays( 1 );

            }
            System.Diagnostics.Debug.WriteLine( "Done...." );
        }
        public void UpdatePlayerRoster()
        {
           
            ConsumePlayerRoster players = new ConsumePlayerRoster();
            string[] fileArray = Directory.GetFiles( @"Q:\Users\Stephen\Documents\sportsfeeds\", "*.json" );
			if ( fileArray.Length == 0 )
				return;
            IEnumerable<Playersalary> playerSalary = new GetPlayerSalaryList().GetSalaries( @"Q:\Users\Stephen\Documents\sportsfeeds\Salaries\playersalary.json" );
            int i = 0;
            foreach ( var file in fileArray )
            {
                System.Diagnostics.Debug.WriteLine( "Reading Player Roster: " + file + " " + i++ + " of " + fileArray.Length );
                players.ReadJsonDeserialize( file, _teams, _players, playerSalary );
            }
            System.Diagnostics.Debug.WriteLine( "Done...." );
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
                    System.Diagnostics.Debug.WriteLine( "Exception Handled" + e );
                }
            }
        }
        public void LoadCumulativePlayerStats()
        {
            System.Diagnostics.Debug.WriteLine( "Reading Cumulative Stats..." );
            CumulativePlayerStats playerStats = new CumulativePlayerStats();
            string fileName = @"Q:\Users\Stephen\Documents\sportsfeeds\2017\cumulative_player_stats.json";

            playerStats.ReadJsonDeserialize( fileName, _players, DateTime.Today );
            System.Diagnostics.Debug.WriteLine( "Done...." );
        }
    }

}
