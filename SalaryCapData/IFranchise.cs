using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalaryCapData.Models;

namespace SalaryCapData
{
    public interface IFranchise
    {
        IEnumerable<Franchise> GetAll();
        Franchise Get( int id );

        void Add( Franchise newFranchise );
        
        string Name( int id );
        void Update( Franchise franchise );

        Owner Owner( int id );
        League League( int id );

    }
}
