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
            try
            {
                if ( !Exists( newPlayer.Id ) )
                {
                    _context.Add( newPlayer );
                    _context.SaveChanges();
                }
            } catch ( Exception ex )
            {
                System.Diagnostics.Debug.WriteLine( "Error Adding Hitter Stat:" + ex );
            }
        }

 
        public void AddHitterStats( HitterStats stats )
        {
            try
            {
                _context.HitterStats.Add( stats );
                _context.SaveChanges();
            } catch ( Exception ex )
            {
                System.Diagnostics.Debug.WriteLine( "Error Adding Hitter Stat:" + ex );
            }
        }

        public void AddPitcherStats( PitcherStats stats )
        {
            try
            {
                _context.PitcherStats.Add( stats );
                _context.SaveChanges();
            }
            catch ( Exception ex )
            {
                System.Diagnostics.Debug.WriteLine( "Error Adding Hitter Stat:" + ex );
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
            //return ( _context.Players.Include( p => p.Team ).Include( p => p.PlayerPosition )).OrderByDescending( s => s.InitialValue );
            return ( _context.Players
                                        .Include( p => p.HitterStats )
                                        .Include( p => p.PitcherStats )
                                        .Include( p => p.Team ))
                                        .OrderByDescending( s => s.InitialValue );

        }

        public HitterStats GetPlayerHitterStats( int playerId )
        {
            return _context.HitterStats.FirstOrDefault( s => s.Id == playerId );
        }

		public IEnumerable<HitterStats> GetHitterStats()
		{
			return _context.HitterStats.Include( p => p.Player ).Include( t => t.Player.Team );
		}

		public PitcherStats GetPlayerPitcherStats( int playerId )
		{
			return _context.PitcherStats.FirstOrDefault( s => s.Id == playerId );
		}

		public IEnumerable<PitcherStats> GetPitcherStats()
		{
			return _context.PitcherStats.Include( p => p.Player ).Include( t => t.Player.Team );
		}


		public void Update( Player player )
        {
            _context.Update( player );
            _context.SaveChanges();
        }
    }
}
