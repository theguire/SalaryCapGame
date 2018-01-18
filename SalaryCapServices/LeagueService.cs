using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SalaryCapData;
using SalaryCapData.Models;

namespace SalaryCapServices
{
    public class LeagueService : ILeague
    {
        private GameDBContext _context;

        public LeagueService( GameDBContext context )
        {
            _context = context;
        }

        public void Add( League newLeague )
        {
            _context.Add( newLeague );
            _context.SaveChanges();
        }

        public League Get( int id )
        {
            return ( GetAll().FirstOrDefault( f => f.LeagueId == id ) );
        }

        public IEnumerable<League> GetAll()
        {
            return ( _context.Leagues
                                .Include( f => f.Name )
                                .Include( f => f.Commissioner )
                                .Include( f => f.Name ) );
        }


        public string Name( int id )
        {
            return ( Get( id ).Name );
        }

        public Owner Commissioner( int id )
        {
            return ( Get( id ).Commissioner );
        }

        public IEnumerable<Franchise> Teams( int id )
        {
            return( Get( id ).Franchises );
        }

    }
}
