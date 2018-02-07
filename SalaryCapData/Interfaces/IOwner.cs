using System.Collections.Generic;
using System.Linq;
using SalaryCapData.Models;

namespace SalaryCapData.Interfaces
{
    public interface IOwner
    {
        IEnumerable<Owner> GetAll();
        Owner Get( int id );

        void Add( Owner newOwner );
        void Update( Owner owner );
        bool Any();

        
        IEnumerable<Franchise> Franchises( int id );
        IEnumerable<League> Leagues( int id );
    }
}
