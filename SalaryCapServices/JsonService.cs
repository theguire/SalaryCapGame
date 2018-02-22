using SalaryCapData;
using SalaryCapData.ConsumeJson;
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

        public void UpdatePlayerRoster()
        {
            ConsumePlayerRoster playerRoster = new ConsumePlayerRoster();
            string[] fileArray = Directory.GetFiles( @"Q:\Users\Stephen\Documents\sportsfeeds\", "*.json" );
            foreach (var file in fileArray )
            {
                playerRoster.ReadJsonDeserialize( file, _teams, _players );
            }

    }

}
}
