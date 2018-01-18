using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SalaryCapData;
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
            return ( GetAll().FirstOrDefault( f => f.FranchiseId == id ));
        }

        public IEnumerable<Franchise> GetAll()
        {
            return ( _context.Franchises
                                .Include( f => f.League )
                                .Include( f => f.Owner ) );

        }



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

    }
}
