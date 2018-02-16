using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalaryCapData.Models;

namespace SalaryCapData.Interfaces
{
    public interface ILeague
    {
        IEnumerable<League> GetAll();
        League Get( int id );

        void Add( League newLeague );
        void Update( League league );
        bool Any();

        string Name( int id );

        Owner Commissioner( int id );

        
        IEnumerable<Franchise> Franchises( int id );
        //int GetNumberOfFranchises( int id );
    }
}
