using SalaryCapData.Interfaces;
using SalaryCapData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCapData.ConsumeJson.Models.PlayerStats
{
    public class SaveStats
    {
        public PitcherStats BuildPitcherStatModel( int id, Stats stats, DateTime date )
        {
            PitcherStats playerStats = new PitcherStats
            {
                PlayerId = id,
                EarnedRunsAllowed = Convert.ToInt32( stats.EarnedRunsAllowed.text ),
                HitsAllowed = Convert.ToInt32( stats.HitsAllowed.text ),
                CompleteGames = Convert.ToInt32( stats.CompletedGames.text ),
                Holds = Convert.ToInt32( stats.Holds.text ),
                InningsPitched = (float)Convert.ToDouble( stats.InningsPitched.text ),
                Loses = Convert.ToInt32( stats.Losses.text ),
                Saves = Convert.ToInt32( stats.Saves.text ),
                PitcherWalks = Convert.ToInt32( stats.PitcherWalks.text ),
                Wins = Convert.ToInt32( stats.Wins.text ),
                Strikeouts = Convert.ToInt32( stats.PitcherStrikeouts.text ),
                GamesFinished = Convert.ToInt32( stats.GamesFinished.text ),
                IsCumulative = false,
                WHIP = (float)Convert.ToDouble( stats.WalksAndHitsPerInningPitched.text ),
                Date = DateTime.Parse( date.ToShortDateString() )
           };

            return playerStats;
        }

        public HitterStats BuildHitterMStatModel( int id, Stats stats, DateTime date )
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
                IsCumulative = false,
                Date = DateTime.Parse( date.ToShortDateString() )
            };

            return playerStats;
            
        }
    }
}
