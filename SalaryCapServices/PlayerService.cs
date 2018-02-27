using Microsoft.EntityFrameworkCore;
using SalaryCapData;
using SalaryCapData.ConsumeJson.Models.PlayerSalary;
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

        public void AddHitterStats( HitterDailyStats stats )
        {
            _context.HitterStats.Add( stats );
            _context.SaveChanges();
        }

        public void AddPitcherStats( PitcherDailyStats stats )
        {
            _context.PitcherStats.Add( stats );
            _context.SaveChanges();
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
            //return ( _context.Players.Include( p => p.Team ).Include( p => p.PlayerPosition )).OrderByDescending( s => s.InitialValue );
            return ( _context.Players.Include( p => p.Team )).OrderByDescending( s => s.InitialValue );

        }


        public void Update( Player player )
        {
            _context.Update( player );
            _context.SaveChanges();
        }
    }
}
