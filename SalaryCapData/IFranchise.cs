using System;
using System.Collections.Generic;
using System.Text;
using SalaryCapData.Models;

namespace SalaryCapData
{
    public interface IFranchise
    {
        IEnumerable<Franchise> GetAll();
        void Add( Franchise newFranchise );
        Franchise Get( int id );
        string Name( int id );

        Owner Owner( int id );
        League League( int id );

    }
}
