using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalaryCapData.Models;

namespace SalaryCapData
{
    public interface IFranchise
    {
        IQueryable<Franchise> Franchises { get; }
        IEnumerable<Franchise> GetAll();

        void Add( Franchise newFranchise );
        Franchise Get( int id );
        string Name( int id );
        void UpdateFranchise( Franchise franchise );

        void JoinLeague( int leagueId, int franchiseId );

        Owner Owner( int id );
        League League( int id );

    }
}
