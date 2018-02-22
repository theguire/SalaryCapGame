using SalaryCapData;
using SalaryCapData.Interfaces;
using SalaryCapData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalaryCapServices
{
    public class TeamService : ITeam
    {
        private GameDBContext _context;

        public TeamService( GameDBContext context )
        {
            _context = context;
        }

        public void Add( Team  newTeam )
        {
            if ( !Exists( newTeam.Id ) )
            {
                try
                {
                    _context.Add( newTeam );
                    _context.SaveChanges();
                }
                catch
                {
                    throw new NotImplementedException();
                }
            }
        }

        public Team Get( int id )
        {
            return ( GetAll().FirstOrDefault( o => ( o.Id == id ) ) );
        }

        public IEnumerable<Team> GetAll()
        {
            return ( _context.Teams );

            //.ThenInclude( f => f.League ));

        }

        public void Update( Team team )
        {
            _context.Update( team );
            _context.SaveChanges();
        }

        public bool Exists( int id )
        {
            return _context.Teams.Any( e => e.Id == id );
        }

        public bool Any()
        {
            return _context.Owners != null;
        }


    }
    
}
