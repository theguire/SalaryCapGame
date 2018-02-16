using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalaryCapData.Models;

namespace SalaryCapData.Interfaces
{
    public interface IFranchise
    {
        IEnumerable<Franchise> GetAll();
        Franchise Get( int id );

        void Add( Franchise newFranchise );
        
        string Name( int id );
        void Update( Franchise franchise );

        int OwnerId( int id );
        Owner Owner( int id );

        int LeagueId( int id );
        League League( int id );

        bool Any( int id );

        long PointTotal( int id );
        decimal FranchiseValue( int id );
        int NumberOfTrades( int id );

        IEnumerable<Franchise> GetAllByOwnerId( int ownerId );
        

    }
}
