using Newtonsoft.Json;
using SalaryCapData.Interfaces;
using SalaryCapData.Models;
using System;
using System.Collections.Generic;
using System.IO;
using static SalaryCapData.ConsumeJson.PlayerRoster;

namespace SalaryCapData.ConsumeJson
{
    public  class ConsumePlayerRoster
    {
        //private static ITeam _teams;
        //private static IPlayer _players;

        //public ConsumePlayerRoster( ITeam teamsContext, IPlayer playersContext )
        //{
        //    _teams = teamsContext;
        //    _players = playersContext;
        //}

        public void ReadJsonDeserialize( string fileName, ITeam _teams, IPlayer _players )
        {
                        
            // read file into a string and deserialize JSON to a type
            // Rosterplayers rosterplayers = JsonConvert.DeserializeObject<Rosterplayers>( File.ReadAllText( @"Q:\Users\Stephen\Documents\sportsfeeds\MYSPORTSFEEDS-ROSTER_PLAYERS-MLB-2017REGULAR-20171001.json" ) );
            //Rootobject rootObject = JsonConvert.DeserializeObject<Rootobject>( File.ReadAllText( @"Q:\Users\Stephen\Documents\sportsfeeds\MYSPORTSFEEDS-ROSTER_PLAYERS-MLB-2017REGULAR-20171001.json" ) );
            Rootobject rootObject = JsonConvert.DeserializeObject<Rootobject>( File.ReadAllText( fileName ) );

            foreach ( var item in rootObject.rosterplayers.playerentry )
            {
                Models.Team team = new Models.Team
                {
                    Id = Convert.ToInt32( item.team.ID ),
                    City = item.team.City,
                    Name = item.team.Name,
                    Abbrev = item.team.Abbreviation
                };
                _teams.Add( team );

                PlayerPosition playerPosition = new PlayerPosition
                {
                    PlayerId = Convert.ToInt32( item.player.ID ),
                    Position = item.player.Position
                };
                _players.AddPlayerPosition( playerPosition );

                Models.Player player = new Models.Player
                {
                    Id = Convert.ToInt32( item.player.ID ),
                    Age = Convert.ToInt32( item.player.Age ),
                    FirstName = item.player.FirstName,
                    LastName = item.player.LastName,
                    IsRookie = item.player.IsRookie == "true" ? true : false,
                    Position = item.player.Position,
                    Team = team,
                    PlayerPosition = playerPosition,

                };
                _players.Add( player );
            }


        }
    }

       
}
