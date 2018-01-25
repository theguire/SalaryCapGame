using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalaryCapData.Models;

namespace SalaryCapData
{
    public interface ILeague
    {
        IEnumerable<League> GetAll();
        League Get( int id );

        void Add( League newLeague );
        string Name( int id );
        Owner Commissioner( int id );

        
        IEnumerable<Franchise> Franchises( int id );
    }
}
