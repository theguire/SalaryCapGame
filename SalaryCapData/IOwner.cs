using System.Collections.Generic;
using System.Linq;
using SalaryCapData.Models;

namespace SalaryCapData
{
    public interface IOwner
    {
        IQueryable <Owner> Owners { get; }
        IQueryable<Franchise> FranchisesQ( int id );
        
        Owner Get( int id );
        void Add( Owner newOwner );

        IEnumerable<Owner> GetAll();
        IEnumerable<Franchise> Franchises( int id );
    }
}
