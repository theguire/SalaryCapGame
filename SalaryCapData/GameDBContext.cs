using Microsoft.EntityFrameworkCore;
using SalaryCapData.Models;

namespace SalaryCapData
{
    public class GameDBContext : DbContext
    {
        // add a constructor
        public GameDBContext( DbContextOptions options ) : base( options ) // take the options and pass to the base class constructor (DbContext)
        {
            // where will you use this class? Could inject directly into controllers, but
            // we already have an abstraction injected into controllers - the interfaces.
            // we should create an interface that can talk to the databse.
        }

        public DbSet<Franchise> Franchises { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Player>  Players { get; set; }
        public DbSet<PlayerAssignment> PlayerAssignments { get; set; }
        public DbSet<PlayerAssignmentDate> PlayerAssignmentDates { get; set; }
        public DbSet<PlayerValue> PlayerValues { get; set; }
        public DbSet<PlayerTransactions> PlayerTrades { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<PlayerPosition> PlayerPositions { get; set; }
        public DbSet<PitcherDailyStats> PitcherStats { get; set; }
        public DbSet<HitterDailyStats> HitterStats { get; set; }
    }
}
