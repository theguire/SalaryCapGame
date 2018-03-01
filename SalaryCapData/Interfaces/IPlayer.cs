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

        void AddPitcherStats( PitcherStats stats );
        void AddHitterStats( HitterStats stats );

        void AddPlayerPosition( PlayerPosition playerPosition );

        HitterStats GetPlayerHitterStats( int playerId );
        PitcherStats GetPlayerPitcherStats( int playerId );

		IEnumerable<HitterStats> GetHitterStats();
		IEnumerable<PitcherStats> GetPitcherStats();



    }
}
