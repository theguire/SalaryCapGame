using Newtonsoft.Json;
using SalaryCapData.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SalaryCapData.ConsumeJson.Models.Cumulative
{
    public class CumulativePlayerStats
    {
        public void ReadJsonDeserialize( string fileName, IPlayer _players )
        {

            // read file into a string and deserialize JSON to a type
            // Rosterplayers rosterplayers = JsonConvert.DeserializeObject<Rosterplayers>( File.ReadAllText( @"Q:\Users\Stephen\Documents\sportsfeeds\MYSPORTSFEEDS-ROSTER_PLAYERS-MLB-2017REGULAR-20171001.json" ) );
            //Rootobject rootObject = JsonConvert.DeserializeObject<Rootobject>( File.ReadAllText( @"Q:\Users\Stephen\Documents\sportsfeeds\MYSPORTSFEEDS-ROSTER_PLAYERS-MLB-2017REGULAR-20171001.json" ) );
            try
            {
                Rootobject rootObject = JsonConvert.DeserializeObject<Rootobject>( File.ReadAllText( fileName ) );
                //DateTime date = Convert.ToDateTime( rootObject.dailyplayerstats.lastUpdatedOn );
                foreach ( var p in rootObject.cumulativeplayerstats.playerstatsentry )
                {
                    if ( p.player.Position == "P" )
                        AddPitcherStats( Convert.ToInt32( p.player.ID ), p.stats, _players );
                    else
                        AddHitterStats( Convert.ToInt32( p.player.ID ), p.stats, _players );
                }
            }
            catch ( Exception ex )
            {
                Console.WriteLine( "Error reading Json file: " + ex );
            }

        }

        public void AddPitcherStats( int id, Stats stats, IPlayer _context )
        {
            SalaryCapData.Models.PitcherDailyStats playerStats = new SalaryCapData.Models.PitcherDailyStats
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
                //Date = DateTime.Parse( date.ToShortDateString() )
                Date = DateTime.Today
            };

            _context.AddPitcherStats( playerStats );
        }

        public void AddHitterStats( int id, Stats stats, IPlayer _context )
        {
            //Console.WriteLine( stats.Hits ] );
            Console.WriteLine( stats.AtBats.ToString() );
            SalaryCapData.Models.HitterDailyStats playerStats = new SalaryCapData.Models.HitterDailyStats
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
                //Date = DateTime.Parse( date.ToShortDateString() )
                Date = DateTime.Today
            };

            _context.AddHitterStats( playerStats );
        }
    }
}
