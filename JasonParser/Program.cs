using Newtonsoft.Json;
using System;
using System.IO;
using static JasonParser.PlayerRoster;

namespace JasonParser
{
    public class Program
    {
        static void Main( string[] args )
        {
            ReadJsonDeserialize();

        }

        public static void ReadJsonDeserialize()
        {
            // read file into a string and deserialize JSON to a type
            // Rosterplayers rosterplayers = JsonConvert.DeserializeObject<Rosterplayers>( File.ReadAllText( @"Q:\Users\Stephen\Documents\sportsfeeds\MYSPORTSFEEDS-ROSTER_PLAYERS-MLB-2017REGULAR-20171001.json" ) );
            Rootobject rootObject = JsonConvert.DeserializeObject<Rootobject>( File.ReadAllText( @"Q:\Users\Stephen\Documents\sportsfeeds\MYSPORTSFEEDS-ROSTER_PLAYERS-MLB-2017REGULAR-20171001.json" ) );

            foreach ( var item in rootObject.rosterplayers.playerentry )
            {
                
            }


        }
    }
}
