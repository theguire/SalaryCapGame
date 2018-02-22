using SalaryCapData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCapData.Interfaces
{
    public interface ITeam
    {
        IEnumerable<Team> GetAll();
        Team Get( int id );
        bool Exists( int id );
        void Add( Team newTeam );
       
    }
}