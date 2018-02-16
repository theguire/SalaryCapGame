using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SalaryCapData;
using SalaryCapData.Interfaces;
using SalaryCapData.Models;

namespace SalaryCapServices
{
    public class FranchiseService : IFranchise
    {

        private GameDBContext _context;

               public FranchiseService( GameDBContext context )
        {
            _context = context;
        }

        public void Add( Franchise newFranchise )
        {
            _context.Add( newFranchise );
            _context.SaveChanges();
        }

        public Franchise Get( int id )
        {
            return ( GetAll().FirstOrDefault( f => f.Id == id ));
        }

        public IEnumerable<Franchise> GetAll()
        {
            return ( _context.Franchises
                                .Include( f => f.League )
                                .Include( f => f.Owner ) ).OrderBy( f => f.Id );

        }

        //public int GetNumberOfFranchises( int id )
        //{
        //    //return Get( id ).C
        //}
        public void Update( Franchise franchise )
        {
            _context.Update( franchise );
            _context.SaveChanges();
        }

        //public void JoinLeague( int leagueId, int franchiseId )
        //{
        //    Franchise franchise = Get( franchiseId );
        //    franchise.LeagueId = leagueId;
        //    Update( franchise );
        //}

        public Owner Owner( int id )
        {
            return ( Get( id ).Owner );
        }

        public League League( int id )
        {
            return ( Get( id ).League );
        }

        public string Name( int id )
        {
            return ( Get( id ).Name );
        }

        public int OwnerId( int id )
        {
            return Get( id ).OwnerId;
        }

        public int LeagueId( int id )
        {
            return Get( id ).LeagueId;
        }

        public bool Any( int id )
        {
            return Get( id ) != null;
        }

        public long PointTotal( int id )
        {
            return Get( id ).Points;
        }

        public decimal FranchiseValue( int id )
        {
            return Get( id ).Value;
        }

        public int NumberOfTrades( int id )
        {
            return Get( id ).NumberOfTrades;
        }

        public IEnumerable<Franchise> GetAllByOwnerId( int ownerId )
        {
            return ( GetAll().Where( f => f.OwnerId == ownerId ) );
        }
    }
}
