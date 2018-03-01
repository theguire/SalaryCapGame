using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCapData.ConsumeJson.Models
{
 
    public class Rootobject
    {
        public Cumulativeplayerstats cumulativeplayerstats { get; set; }
    }

    public class Cumulativeplayerstats
    {
        public string lastUpdatedOn { get; set; }
        public Playerstatsentry[] playerstatsentry { get; set; }
    }

    public class Playerstatsentry
    {
        public Player player { get; set; }
        public Team team { get; set; }
        public Stats stats { get; set; }
    }

    public class Player
    {
        public string ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string JerseyNumber { get; set; }
        public string Position { get; set; }
    }

    public class Team
    {
        public string ID { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
    }

    public class Stats
    {
        public Gamesplayed GamesPlayed { get; set; }
        public Atbats AtBats { get; set; }
        public Runs Runs { get; set; }
        public Hits Hits { get; set; }
        public Secondbasehits SecondBaseHits { get; set; }
        public Thirdbasehits ThirdBaseHits { get; set; }
        public Homeruns Homeruns { get; set; }
        public Earnedruns EarnedRuns { get; set; }
        public Unearnedruns UnearnedRuns { get; set; }
        public Runsbattedin RunsBattedIn { get; set; }
        public Batterwalks BatterWalks { get; set; }
        public Batterswings BatterSwings { get; set; }
        public Batterstrikes BatterStrikes { get; set; }
        public Batterstrikesfoul BatterStrikesFoul { get; set; }
        public Batterstrikesmiss BatterStrikesMiss { get; set; }
        public Batterstrikeslooking BatterStrikesLooking { get; set; }
        public Battertagouts BatterTagOuts { get; set; }
        public Batterforceouts BatterForceOuts { get; set; }
        public Batterputouts BatterPutOuts { get; set; }
        public Battergroundballs BatterGroundBalls { get; set; }
        public Batterflyballs BatterFlyBalls { get; set; }
        public Batterlinedrives BatterLineDrives { get; set; }
        public Batter2seamfastballs Batter2SeamFastballs { get; set; }
        public Batter4seamfastballs Batter4SeamFastballs { get; set; }
        public Battercurveballs BatterCurveballs { get; set; }
        public Batterchangeups BatterChangeups { get; set; }
        public Battercutters BatterCutters { get; set; }
        public Battersliders BatterSliders { get; set; }
        public Battersinkers BatterSinkers { get; set; }
        public Battersplitters BatterSplitters { get; set; }
        public Batterstrikeouts BatterStrikeouts { get; set; }
        public Stolenbases StolenBases { get; set; }
        public Caughtbasesteals CaughtBaseSteals { get; set; }
        public Batterstolenbasepct BatterStolenBasePct { get; set; }
        public Battingavg BattingAvg { get; set; }
        public Batteronbasepct BatterOnBasePct { get; set; }
        public Battersluggingpct BatterSluggingPct { get; set; }
        public Batteronbaseplussluggingpct BatterOnBasePlusSluggingPct { get; set; }
        public Batterintentionalwalks BatterIntentionalWalks { get; set; }
        public Hitbypitch HitByPitch { get; set; }
        public Battersacrificebunts BatterSacrificeBunts { get; set; }
        public Battersacrificeflies BatterSacrificeFlies { get; set; }
        public Totalbases TotalBases { get; set; }
        public Extrabasehits ExtraBaseHits { get; set; }
        public Batterdoubleplays BatterDoublePlays { get; set; }
        public Battertripleplays BatterTriplePlays { get; set; }
        public Battergroundouts BatterGroundOuts { get; set; }
        public Batterflyouts BatterFlyOuts { get; set; }
        public Battergroundouttoflyoutratio BatterGroundOutToFlyOutRatio { get; set; }
        public Pitchesfaced PitchesFaced { get; set; }
        public Plateappearances PlateAppearances { get; set; }
        public Leftonbase LeftOnBase { get; set; }
        public Wins Wins { get; set; }
        public Losses Losses { get; set; }
        public Earnedrunavg EarnedRunAvg { get; set; }
        public Saves Saves { get; set; }
        public Saveopportunities SaveOpportunities { get; set; }
        public Inningspitched InningsPitched { get; set; }
        public Hitsallowed HitsAllowed { get; set; }
        public Secondbasehitsallowed SecondBaseHitsAllowed { get; set; }
        public Thirdbasehitsallowed ThirdBaseHitsAllowed { get; set; }
        public Runsallowed RunsAllowed { get; set; }
        public Earnedrunsallowed EarnedRunsAllowed { get; set; }
        public Homerunsallowed HomerunsAllowed { get; set; }
        public Pitcherwalks PitcherWalks { get; set; }
        public Pitcherswings PitcherSwings { get; set; }
        public Pitcherstrikes PitcherStrikes { get; set; }
        public Pitcherstrikesfoul PitcherStrikesFoul { get; set; }
        public Pitcherstrikesmiss PitcherStrikesMiss { get; set; }
        public Pitcherstrikeslooking PitcherStrikesLooking { get; set; }
        public Pitchergroundballs PitcherGroundBalls { get; set; }
        public Pitcherflyballs PitcherFlyBalls { get; set; }
        public Pitcherlinedrives PitcherLineDrives { get; set; }
        public Pitcher2seamfastballs Pitcher2SeamFastballs { get; set; }
        public Pitcher4seamfastballs Pitcher4SeamFastballs { get; set; }
        public Pitchercurveballs PitcherCurveballs { get; set; }
        public Pitcherchangeups PitcherChangeups { get; set; }
        public Pitchercutters PitcherCutters { get; set; }
        public Pitchersliders PitcherSliders { get; set; }
        public Pitchersinkers PitcherSinkers { get; set; }
        public Pitchersplitters PitcherSplitters { get; set; }
        public Pitchersacrificebunts PitcherSacrificeBunts { get; set; }
        public Pitchersacrificeflies PitcherSacrificeFlies { get; set; }
        public Pitcherstrikeouts PitcherStrikeouts { get; set; }
        public Pitchingavg PitchingAvg { get; set; }
        public Walksandhitsperinningpitched WalksAndHitsPerInningPitched { get; set; }
        public Completedgames CompletedGames { get; set; }
        public Shutouts Shutouts { get; set; }
        public Battershit BattersHit { get; set; }
        public Pitcherintentionalwalks PitcherIntentionalWalks { get; set; }
        public Gamesfinished GamesFinished { get; set; }
        public Holds Holds { get; set; }
        public Pitcherdoubleplays PitcherDoublePlays { get; set; }
        public Pitchertripleplays PitcherTriplePlays { get; set; }
        public Pitchergroundouts PitcherGroundOuts { get; set; }
        public Pitcherflyouts PitcherFlyOuts { get; set; }
        public Pitcherwildpitches PitcherWildPitches { get; set; }
        public Balks Balks { get; set; }
        public Pitcherstolenbasesallowed PitcherStolenBasesAllowed { get; set; }
        public Pitchercaughtstealing PitcherCaughtStealing { get; set; }
        public Pickoffattempts PickoffAttempts { get; set; }
        public Pickoffs Pickoffs { get; set; }
        public Totalbattersfaced TotalBattersFaced { get; set; }
        public Pitchesthrown PitchesThrown { get; set; }
        public Winpct WinPct { get; set; }
        public Pitchergroundouttoflyoutratio PitcherGroundOutToFlyOutRatio { get; set; }
        public Pitcheronbasepct PitcherOnBasePct { get; set; }
        public Pitchersluggingpct PitcherSluggingPct { get; set; }
        public Pitcheronbaseplussluggingpct PitcherOnBasePlusSluggingPct { get; set; }
        public Strikeoutsper9innings StrikeoutsPer9Innings { get; set; }
        public Walksallowedper9innings WalksAllowedPer9Innings { get; set; }
        public Hitsallowedper9innings HitsAllowedPer9Innings { get; set; }
        public Strikeoutstowalksratio StrikeoutsToWalksRatio { get; set; }
        public Pitchesperinning PitchesPerInning { get; set; }
        public Pitcheratbats PitcherAtBats { get; set; }
        public Inningsplayed InningsPlayed { get; set; }
        public Totalchances TotalChances { get; set; }
        public Fieldertagouts FielderTagOuts { get; set; }
        public Fielderforceouts FielderForceOuts { get; set; }
        public Fielderputouts FielderPutOuts { get; set; }
        public Outsfaced OutsFaced { get; set; }
        public Assists Assists { get; set; }
        public Errors Errors { get; set; }
        public Fielderdoubleplays FielderDoublePlays { get; set; }
        public Fieldertripleplays FielderTriplePlays { get; set; }
        public Fielderstolenbasesallowed FielderStolenBasesAllowed { get; set; }
        public Fieldercaughtstealing FielderCaughtStealing { get; set; }
        public Fielderstolenbasepct FielderStolenBasePct { get; set; }
        public Passedballs PassedBalls { get; set; }
        public Fielderwildpitches FielderWildPitches { get; set; }
        public Fieldingpct FieldingPct { get; set; }
        public Rangefactor RangeFactor { get; set; }
        public Gamesstarted GamesStarted { get; set; }
    }

    public class Gamesplayed
    {
		[JsonProperty( "@abbreviation" )]
		public string abbreviation { get; set; }
		[JsonProperty( "#text" )]
		public string text { get; set; }
	}

    public class Atbats
    {
		[JsonProperty( "@category" )]
		public string category { get; set; }
		[JsonProperty( "@abbreviation" )]
		public string abbreviation { get; set; }
		[JsonProperty( "#text" )]
		public string text { get; set; }
	}

    public class Runs
    {
        [JsonProperty( "@category" )]
        public string category { get; set; }
        [JsonProperty( "@abbreviation" )]
        public string abbreviation { get; set; }
        [JsonProperty( "#text" )]
        public string text { get; set; }
    }

    public class Hits
    {
        [JsonProperty( "@category" )]
        public string category { get; set; }
        [JsonProperty( "@abbreviation" )]
        public string abbreviation { get; set; }
        [JsonProperty( "#text" )]
        public string text { get; set; }
    }

    public class Secondbasehits
    {
        [JsonProperty( "@category" )]
        public string category { get; set; }
        [JsonProperty( "@abbreviation" )]
        public string abbreviation { get; set; }
        [JsonProperty( "#text" )]
        public string text { get; set; }
    }

    public class Thirdbasehits
    {
        [JsonProperty( "@category" )]
        public string category { get; set; }
        [JsonProperty( "@abbreviation" )]
        public string abbreviation { get; set; }
        [JsonProperty( "#text" )]
        public string text { get; set; }
    }

    public class Homeruns
    {
        [JsonProperty( "@category" )]
        public string category { get; set; }
        [JsonProperty( "@abbreviation" )]
        public string abbreviation { get; set; }
        [JsonProperty( "#text" )]
        public string text { get; set; }
    }

    public class Earnedruns
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Unearnedruns
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Runsbattedin
    {
        [JsonProperty( "@category" )]
        public string category { get; set; }
        [JsonProperty( "@abbreviation" )]
        public string abbreviation { get; set; }
        [JsonProperty( "#text" )]
        public string text { get; set; }
    }

    public class Batterwalks
    {
        [JsonProperty( "@category" )]
        public string category { get; set; }
        [JsonProperty( "@abbreviation" )]
        public string abbreviation { get; set; }
        [JsonProperty( "#text" )]
        public string text { get; set; }
    }

    public class Batterswings
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Batterstrikes
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Batterstrikesfoul
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Batterstrikesmiss
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Batterstrikeslooking
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Battertagouts
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Batterforceouts
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Batterputouts
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Battergroundballs
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Batterflyballs
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Batterlinedrives
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Batter2seamfastballs
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Batter4seamfastballs
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Battercurveballs
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Batterchangeups
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Battercutters
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Battersliders
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Battersinkers
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Battersplitters
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Batterstrikeouts
    {
        [JsonProperty( "@category" )]
        public string category { get; set; }
        [JsonProperty( "@abbreviation" )]
        public string abbreviation { get; set; }
        [JsonProperty( "#text" )]
        public string text { get; set; }
    }

    public class Stolenbases
    {
        [JsonProperty( "@category" )]
        public string category { get; set; }
        [JsonProperty( "@abbreviation" )]
        public string abbreviation { get; set; }
        [JsonProperty( "#text" )]
        public string text { get; set; }
    }

    public class Caughtbasesteals
    {
        [JsonProperty( "@category" )]
        public string category { get; set; }
        [JsonProperty( "@abbreviation" )]
        public string abbreviation { get; set; }
        [JsonProperty( "#text" )]
        public string text { get; set; }
    }

    public class Batterstolenbasepct
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Battingavg
    {
		[JsonProperty( "@category" )]
		public string category { get; set; }
		[JsonProperty( "@abbreviation" )]
		public string abbreviation { get; set; }
		[JsonProperty( "#text" )]
		public string text { get; set; }
	}

    public class Batteronbasepct
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Battersluggingpct
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Batteronbaseplussluggingpct
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Batterintentionalwalks
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Hitbypitch
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Battersacrificebunts
    {
		[JsonProperty( "@category" )]
		public string category { get; set; }
		[JsonProperty( "@abbreviation" )]
		public string abbreviation { get; set; }
		[JsonProperty( "#text" )]
		public string text { get; set; }
	}

    public class Battersacrificeflies
    {
		[JsonProperty( "@category" )]
		public string category { get; set; }
		[JsonProperty( "@abbreviation" )]
		public string abbreviation { get; set; }
		[JsonProperty( "#text" )]
		public string text { get; set; }
	}

    public class Totalbases
    {
        [JsonProperty( "@category" )]
        public string category { get; set; }
        [JsonProperty( "@abbreviation" )]
        public string abbreviation { get; set; }
        [JsonProperty( "#text" )]
        public string text { get; set; }
    }

    public class Extrabasehits
    {
        [JsonProperty( "@category" )]
        public string category { get; set; }
        [JsonProperty( "@abbreviation" )]
        public string abbreviation { get; set; }
        [JsonProperty( "#text" )]
        public string text { get; set; }
    }

    public class Batterdoubleplays
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Battertripleplays
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Battergroundouts
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Batterflyouts
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Battergroundouttoflyoutratio
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pitchesfaced
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Plateappearances
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Leftonbase
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Wins
    {
        [JsonProperty( "@category" )]
        public string category { get; set; }
        [JsonProperty( "@abbreviation" )]
        public string abbreviation { get; set; }
        [JsonProperty( "#text" )]
        public string text { get; set; }
    }

    public class Losses
    {
        [JsonProperty( "@category" )]
        public string category { get; set; }
        [JsonProperty( "@abbreviation" )]
        public string abbreviation { get; set; }
        [JsonProperty( "#text" )]
        public string text { get; set; }
    }

    public class Earnedrunavg
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Saves
    {
    [JsonProperty( "@category" )]
    public string category { get; set; }
    [JsonProperty( "@abbreviation" )]
    public string abbreviation { get; set; }
    [JsonProperty( "#text" )]
    public string text { get; set; }
}

    public class Saveopportunities
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Inningspitched
    {
        [JsonProperty( "@category" )]
        public string category { get; set; }
        [JsonProperty( "@abbreviation" )]
        public string abbreviation { get; set; }
        [JsonProperty( "#text" )]
        public string text { get; set; }
    }

    public class Hitsallowed
    {
        [JsonProperty( "@category" )]
        public string category { get; set; }
        [JsonProperty( "@abbreviation" )]
        public string abbreviation { get; set; }
        [JsonProperty( "#text" )]
        public string text { get; set; }
    }

    public class Secondbasehitsallowed
    {
        [JsonProperty( "@category" )]
        public string category { get; set; }
        [JsonProperty( "@abbreviation" )]
        public string abbreviation { get; set; }
        [JsonProperty( "#text" )]
        public string text { get; set; }
    }

    public class Thirdbasehitsallowed
    {
        [JsonProperty( "@category" )]
        public string category { get; set; }
        [JsonProperty( "@abbreviation" )]
        public string abbreviation { get; set; }
        [JsonProperty( "#text" )]
        public string text { get; set; }
    }

    public class Runsallowed
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Earnedrunsallowed
    {
        [JsonProperty( "@category" )]
        public string category { get; set; }
        [JsonProperty( "@abbreviation" )]
        public string abbreviation { get; set; }
        [JsonProperty( "#text" )]
        public string text { get; set; }
    }

    public class Homerunsallowed
    {
        [JsonProperty( "@category" )]
        public string category { get; set; }
        [JsonProperty( "@abbreviation" )]
        public string abbreviation { get; set; }
        [JsonProperty( "#text" )]
        public string text { get; set; }
    }

    public class Pitcherwalks
    {
        [JsonProperty( "@category" )]
        public string category { get; set; }
        [JsonProperty( "@abbreviation" )]
        public string abbreviation { get; set; }
        [JsonProperty( "#text" )]
        public string text { get; set; }
    }

    public class Pitcherswings
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pitcherstrikes
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pitcherstrikesfoul
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pitcherstrikesmiss
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pitcherstrikeslooking
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pitchergroundballs
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pitcherflyballs
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pitcherlinedrives
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pitcher2seamfastballs
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pitcher4seamfastballs
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pitchercurveballs
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pitcherchangeups
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pitchercutters
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pitchersliders
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pitchersinkers
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pitchersplitters
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pitchersacrificebunts
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pitchersacrificeflies
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pitcherstrikeouts
    {
        [JsonProperty( "@category" )]
        public string category { get; set; }
        [JsonProperty( "@abbreviation" )]
        public string abbreviation { get; set; }
        [JsonProperty( "#text" )]
        public string text { get; set; }
    }

    public class Pitchingavg
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Walksandhitsperinningpitched
    {
        [JsonProperty( "@category" )]
        public string category { get; set; }
        [JsonProperty( "@abbreviation" )]
        public string abbreviation { get; set; }
        [JsonProperty( "#text" )]
        public string text { get; set; }
    }

    public class Completedgames
    {
        [JsonProperty( "@category" )]
        public string category { get; set; }
        [JsonProperty( "@abbreviation" )]
        public string abbreviation { get; set; }
        [JsonProperty( "#text" )]
        public string text { get; set; }
    }

    public class Shutouts
    {
        [JsonProperty( "@category" )]
        public string category { get; set; }
        [JsonProperty( "@abbreviation" )]
        public string abbreviation { get; set; }
        [JsonProperty( "#text" )]
        public string text { get; set; }
    }

    public class Battershit
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pitcherintentionalwalks
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Gamesfinished
    {
    [JsonProperty( "@category" )]
    public string category { get; set; }
    [JsonProperty( "@abbreviation" )]
    public string abbreviation { get; set; }
    [JsonProperty( "#text" )]
    public string text { get; set; }
}

    public class Holds
    {
    [JsonProperty( "@category" )]
    public string category { get; set; }
    [JsonProperty( "@abbreviation" )]
    public string abbreviation { get; set; }
    [JsonProperty( "#text" )]
    public string text { get; set; }
}

    public class Pitcherdoubleplays
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pitchertripleplays
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pitchergroundouts
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pitcherflyouts
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pitcherwildpitches
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Balks
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pitcherstolenbasesallowed
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pitchercaughtstealing
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pickoffattempts
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pickoffs
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Totalbattersfaced
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pitchesthrown
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Winpct
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pitchergroundouttoflyoutratio
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pitcheronbasepct
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pitchersluggingpct
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pitcheronbaseplussluggingpct
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Strikeoutsper9innings
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Walksallowedper9innings
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Hitsallowedper9innings
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Strikeoutstowalksratio
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pitchesperinning
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Pitcheratbats
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Inningsplayed
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Totalchances
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Fieldertagouts
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Fielderforceouts
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Fielderputouts
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Outsfaced
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Assists
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Errors
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Fielderdoubleplays
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Fieldertripleplays
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Fielderstolenbasesallowed
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Fieldercaughtstealing
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Fielderstolenbasepct
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Passedballs
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Fielderwildpitches
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Fieldingpct
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Rangefactor
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }

    public class Gamesstarted
    {
        public string category { get; set; }
        public string abbreviation { get; set; }
        public string text { get; set; }
    }
}




