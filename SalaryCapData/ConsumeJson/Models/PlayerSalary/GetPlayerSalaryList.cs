using Newtonsoft.Json;
using SalaryCapData.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SalaryCapData.ConsumeJson.Models.PlayerSalary
{

    public class GetPlayerSalaryList
    {
        public IEnumerable<Playersalary> GetSalaries( string fileName )
        {

            // read file into a string and deserialize JSON to a type
            // Rosterplayers rosterplayers = JsonConvert.DeserializeObject<Rosterplayers>( File.ReadAllText( @"Q:\Users\Stephen\Documents\sportsfeeds\MYSPORTSFEEDS-ROSTER_PLAYERS-MLB-2017REGULAR-20171001.json" ) );
            //Rootobject rootObject = JsonConvert.DeserializeObject<Rootobject>( File.ReadAllText( @"Q:\Users\Stephen\Documents\sportsfeeds\MYSPORTSFEEDS-ROSTER_PLAYERS-MLB-2017REGULAR-20171001.json" ) );
            try
            {
                Rootobject rootObject = JsonConvert.DeserializeObject<Rootobject>( File.ReadAllText( fileName ) );
                //DateTime date = Convert.ToDateTime( rootObject.dailyplayerstats.lastUpdatedOn );
                return rootObject.playersalary;

            }
            catch ( Exception ex )
            {
                Console.WriteLine( "Error reading Json file: " + ex );
                return null;
            }
        }
    }    
}
