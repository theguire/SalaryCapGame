using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SalaryCapData;
using SalaryCapData.Interfaces;
using SalaryCapData.Models;

namespace SalaryCapServices
{
    public class LeagueService : ILeague
    {
        private GameDBContext _leagues;

        public LeagueService( GameDBContext context )
        {
            _leagues = context;
        }

        public void Add( League newLeague )
        {
            _leagues.Add( newLeague );
            _leagues.SaveChanges();
        }

        public League Get( int id )
        {
            return ( GetAll().FirstOrDefault( f => f.Id == id ) );
        }

        public IEnumerable<League> GetAll()
        {
            return ( _leagues.Leagues
                                .Include( l => l.Franchises )
                                .Include( f => f.Commissioner ) ).OrderBy( l => l.Name );
        }


        public string Name( int id )
        {
            return ( Get( id ).Name );
        }

        public Owner Commissioner( int id )
        {
            return ( Get( id ).Commissioner );
        }

        public IEnumerable<Franchise> Franchises( int id )
        {
            return( Get( id ).Franchises );
        }

        public void Update( League league )
        {
            _leagues.Update( league );
            _leagues.SaveChanges();
        }

        public bool Any()
        {
            return _leagues.Leagues != null;
        }
    }
}
