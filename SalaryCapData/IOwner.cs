using System.Collections.Generic;
using SalaryCapData.Models;

namespace SalaryCapData
{
    public interface IOwner
    {
        IEnumerable<Owner> GetAll();
        Owner Get( int id );

        void Add( Owner newOwner );

        IEnumerable<Franchise> Franchises( int id );
    }
}
