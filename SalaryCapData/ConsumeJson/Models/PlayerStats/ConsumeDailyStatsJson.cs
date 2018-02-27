using Newtonsoft.Json;
using SalaryCapData.Interfaces;
using SalaryCapData.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SalaryCapData.ConsumeJson.Models.PlayerStats
{
    public class DailyPlayerStats
    {

        public void ReadJsonDeserialize( string fileName, IPlayer _players, DateTime date )
        {
            SaveStats playerStats = new SaveStats();
            int i = 0;
            try
            {
                Rootobject rootObject = JsonConvert.DeserializeObject<Rootobject>( File.ReadAllText( fileName ) );
                foreach ( var p in rootObject.dailyplayerstats.playerstatsentry )
                {
                    System.Diagnostics.Debug.WriteLine( "#: " + i++ + "Id: " + p.player.ID + " " + p.player.LastName );
                    if ( p.player.Position == "P" )
                    {
                        PitcherStats stats = playerStats.BuildPitcherStatModel( Convert.ToInt32( p.player.ID ), p.stats, date );
                        _players.AddPitcherStats( stats );
                    }
                    else
                    {
                        HitterStats stats = playerStats.BuildHitterMStatModel( Convert.ToInt32( p.player.ID ), p.stats, date );
                        _players.AddHitterStats( stats );

                    }
                }
            }
            catch ( Exception ex )
            {
                System.Diagnostics.Debug.WriteLine( "Error reading Json file: " + ex );
            }
            System.Diagnostics.Debug.WriteLine( i + " Daily Stats Records Read. " );
        }
    }
}