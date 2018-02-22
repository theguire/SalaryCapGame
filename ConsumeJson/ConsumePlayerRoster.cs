using Newtonsoft.Json;
using SalaryCapData.Models;
using System.IO;
using static ConsumeJson.PlayerRoster;

namespace ConsumeJson
{
    public class ConsumePlayerRoster
    {
        public static void ReadJsonDeserialize( string fileName )
        {
            // read file into a string and deserialize JSON to a type
            // Rosterplayers rosterplayers = JsonConvert.DeserializeObject<Rosterplayers>( File.ReadAllText( @"Q:\Users\Stephen\Documents\sportsfeeds\MYSPORTSFEEDS-ROSTER_PLAYERS-MLB-2017REGULAR-20171001.json" ) );
            //Rootobject rootObject = JsonConvert.DeserializeObject<Rootobject>( File.ReadAllText( @"Q:\Users\Stephen\Documents\sportsfeeds\MYSPORTSFEEDS-ROSTER_PLAYERS-MLB-2017REGULAR-20171001.json" ) );
            Rootobject rootObject = JsonConvert.DeserializeObject<Rootobject>( File.ReadAllText( fileName ) );

            foreach ( var item in rootObject.rosterplayers.playerentry )
            {
                SalaryCapData.Models.Team team = ( SalaryCapData.Models.Team )item.team;
                Player player = new Player
                {
                    Id = item.player.ID,
                    Age = item.player.Age,


                };



            }


        }



    }
}
