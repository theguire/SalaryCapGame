using SalaryCapData.ConsumeJson.Models.PlayerSalary;
using SalaryCapData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCapData.Interfaces
{
    public interface IPlayer
    {
        IEnumerable<Player> GetAll();
        Player Get( int PlayerId );
        void Add( Player newPlayer );
        void Update( Player player );
        bool Exists( int id );

        void AddPitcherStats( PitcherDailyStats stats );
        void AddHitterStats( HitterDailyStats stats );

        void AddPlayerPosition( PlayerPosition playerPosition );

    }
}
