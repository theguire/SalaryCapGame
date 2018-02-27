using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SalaryCapData.ConsumeJson.Models.PlayerStats;
using SalaryCapData.Interfaces;
using SalaryCapData.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Text;

namespace SalaryCapData.ConsumeJson.Models.Cumulative
{
    public class CumulativePlayerStats
    {
        public void ReadJsonDeserialize( string fileName, IPlayer _context, DateTime date )
        {
            int i = 0;
            int j = 0;
            SaveStats playerStats = new SaveStats();
            try
            {
                Rootobject rootObject = JsonConvert.DeserializeObject<Rootobject>( File.ReadAllText( fileName ) );
                foreach ( var p in rootObject.cumulativeplayerstats.playerstatsentry )
                {
                    System.Diagnostics.Debug.Write( "#: " + i++ + " Id: " + p.player.ID + " " + p.player.LastName );
                    //First check to see if the player is in the Player table
                    SalaryCapData.Models.Player player = _context.Get( Convert.ToInt32( p.player.ID ) );
                    if ( player == null )
                        continue;



                    System.Diagnostics.Debug.Write( " " + j++ + " Saved " );
                    if ( p.player.Position == "P" )
                    {
                        BuildPitcherStatModel( Convert.ToInt32( p.player.ID ), p.stats, _context, date );
                    }
                    else
                    {
                        BuildHitterMStatModel( Convert.ToInt32( p.player.ID ), p.stats, _context, date );
                    }
                    System.Diagnostics.Debug.WriteLine( "\n" );
                }
            }
            catch ( Exception ex )
            {
            }
            System.Diagnostics.Debug.WriteLine( i + " Cumulative Records Read.  " + j + " Saved.  Delta: " + (i - j) );
        }

            public void BuildPitcherStatModel( int id, Stats stats, IPlayer _context, DateTime date )
            {
                PitcherStats playerStats = new PitcherStats
                {
                    PlayerId = id,
                    EarnedRunsAllowed = Convert.ToInt32( stats.EarnedRunsAllowed.text ),
                    HitsAllowed = Convert.ToInt32( stats.HitsAllowed.text ),
                    CompleteGames = Convert.ToInt32( stats.CompletedGames.text ),
                    Holds = Convert.ToInt32( stats.Holds.text ),
                    InningsPitched = Convert.ToDouble( stats.InningsPitched.text ),
                    Loses = Convert.ToInt32( stats.Losses.text ),
                    Saves = Convert.ToInt32( stats.Saves.text ),
                    PickOffs = Convert.ToInt32( stats.Pickoffs.text ),
                    PitcherWalks = Convert.ToInt32( stats.PitcherWalks.text ),
                    Wins = Convert.ToInt32( stats.Wins.text ),
                    Strikeouts = Convert.ToInt32( stats.PitcherStrikeouts.text ),
                    GamesFinished = Convert.ToInt32( stats.GamesFinished.text ),
                    WHIP = Convert.ToDouble( stats.WalksAllowedPer9Innings.text ),
                    IsCumulative = true,
                    Date = DateTime.Today
                };

                _context.AddPitcherStats( playerStats );
            }

            public void BuildHitterMStatModel( int id, Stats stats, IPlayer _context, DateTime date )
            {


                HitterStats playerStats = new SalaryCapData.Models.HitterStats
                {
                    PlayerId = id,
                    Doubles = Convert.ToInt32( stats.SecondBaseHits.text ),
                    ExtraBases = Convert.ToInt32( stats.ExtraBaseHits.text ),
                    Hits = Convert.ToInt32( stats.Hits.text ),
                    HomeRuns = Convert.ToInt32( stats.Homeruns.text ),
                    RBI = Convert.ToInt32( stats.RunsBattedIn.text ),
                    Runs = Convert.ToInt32( stats.Runs.text ),
                    Sacrifices = 0,
                    TotalBases = Convert.ToInt32( stats.TotalBases.text ),
                    StolenBases = Convert.ToInt32( stats.StolenBases.text ),
                    Triples = Convert.ToInt32( stats.ThirdBaseHits.text ),
                    Walks = Convert.ToInt32( stats.BatterWalks.text ),
                    IsCumulative = true,
                    Date = DateTime.Today
                };

                _context.AddHitterStats( playerStats );

            }
        }

}
