using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SalaryCapData;
using SalaryCapData.Models;

namespace SalaryCapServices
{
    public class OwnerService : IOwner

    {
        private GameDBContext _ownerDbContext;

        //public IQueryable<Owner> Owners { get; }
        public IQueryable<Owner> Owners => _ownerDbContext.Owners;

        public OwnerService( GameDBContext ownerDbContext )
        {
            _ownerDbContext = ownerDbContext;
        }

        public void Add( Owner newOwner )
        {
            _ownerDbContext.Add( newOwner );
            _ownerDbContext.SaveChanges();
        }

        public Owner Get( int id )
        {
            return( GetAll().FirstOrDefault( o => ( o.OwnerId == id )));
        }

        public IEnumerable<Owner> GetAll()
        {
            return( _ownerDbContext.Owners.Include( f => f.Franchises ).ThenInclude( f => f.League ) );
            //.ThenInclude( f => f.League ));

        }

        public virtual void AddFranchise( int id, string franchiseName)
        {
            _ownerDbContext.Franchises.Add( new Franchise
            {
                OwnerId = id,
                Name = franchiseName
            } );
        }
        public IEnumerable<Franchise> Franchises( int id )
        {
            return _ownerDbContext.Franchises
                            .Include( f => f.Name )
                            .Include( f => f.League )
                            .Where( o => o.Owner.OwnerId == id );
        }

        

        public IQueryable<Franchise> FranchisesQ( int id )
        {
            return ( null );
        }
    }
}
