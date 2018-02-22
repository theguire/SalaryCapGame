using SalaryCapData;
using SalaryCapData.Interfaces;
using SalaryCapData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalaryCapServices
{
    public class PlayerService : IPlayer
    {
        private GameDBContext _context;

        public PlayerService( GameDBContext context )
        {
            _context = context;
        }
        public void Add( Player newPlayer )
        {
            if ( !Exists( newPlayer.Id ) )
            {
                _context.Add( newPlayer );
                _context.SaveChanges();
            }
        }

        public void AddPlayerPosition( PlayerPosition playerPosition )
        {
            _context.PlayerPositions.Add( playerPosition );
        }

        public bool Exists( int id )
        {
            return _context.Players.Any( e => e.Id == id );
        }

        public Player Get( int PlayerId )
        {
            return ( GetAll().FirstOrDefault( p => p.Id == PlayerId ));
        }

        public IEnumerable<Player> GetAll()
        {
            return ( _context.Players );
                       
        }

        public void Update( Player player )
        {
            _context.Update( player );
            _context.SaveChanges();
        }
    }
}
