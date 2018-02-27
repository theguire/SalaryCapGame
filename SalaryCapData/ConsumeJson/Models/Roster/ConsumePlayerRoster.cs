using Newtonsoft.Json;
using SalaryCapData.ConsumeJson.Models.PlayerSalary;
using SalaryCapData.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SalaryCapData.ConsumeJson.Models.Roster
{
    public  class ConsumePlayerRoster
    {

        public void ReadJsonDeserialize( string fileName, ITeam _teams, IPlayer _players, IEnumerable<Playersalary> playerSalaries  )
        {
                        
            Rootobject rootObject = JsonConvert.DeserializeObject<Rootobject>( File.ReadAllText( fileName ) );

            decimal salary;
            int i = 1;
            int j = 0;
            foreach ( var item in rootObject.rosterplayers.playerentry )
            {
                try
                {
                    
                    var name = item.player.LastName + " " + item.player.FirstName;
                    System.Diagnostics.Debug.Write( "#: " + i++ + "Id: " + item.player.ID + " " + name );
                    Playersalary playerSalary = playerSalaries.FirstOrDefault( p => p.Player == name );
                    if (( playerSalary == null ) || ( playerSalary.Salary == null ))
                    {
                        System.Diagnostics.Debug.Write( " " + j++ + "No Salary" );
                        salary = 1000000;
                    }
                    else 
                    {
                        salary = ( decimal ) ( playerSalary.Salary );
                    }
                   
                    salary /= 1000000;
                    SalaryCapData.Models.Team team = new SalaryCapData.Models.Team
                    {
                        Id = Convert.ToInt32( item.team.ID ),
                        City = item.team.City,
                        Name = item.team.Name,
                        Abbrev = item.team.Abbreviation
                    };
                    int playerId = Convert.ToInt32( item.player.ID );

                    SalaryCapData.Models.PlayerPosition playerPosition = new SalaryCapData.Models.PlayerPosition
                    {
                        PlayerId = playerId,
                        Position = item.player.Position
                    };

                    SalaryCapData.Models.Player player = new SalaryCapData.Models.Player
                    {
                        Id = playerId,
                        Age = Convert.ToInt32( item.player.Age ),
                        FirstName = item.player.FirstName,
                        LastName = item.player.LastName,
                        IsRookie = item.player.IsRookie == "true" ? true : false,
                        Position = item.player.Position,
                        Team = team,
                        TeamId = team.Id,
                        //PlayerPositions = playerPositions,
                        InitialValue = salary
                    };
                    _players.Add( player );
                    _teams.Add( team );
                    _players.AddPlayerPosition( playerPosition );

                    System.Diagnostics.Debug.Write( "\n" );
                }
                catch ( Exception ex )
                {
                    System.Diagnostics.Debug.Write( ex );
                }
                System.Diagnostics.Debug.WriteLine ( i + "Records Processed.  " + j + "Had no salary.  Delta: " + (i - j ));
            }


        }

       
    }

       
}
