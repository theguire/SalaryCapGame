using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalaryCapData;
using SalaryCapData.Interfaces;
using SalaryCapData.Models;
using SalaryCapGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryCapGame.ViewComponents
{
    public class PlayerListViewComponent : ViewComponent
    {
        private readonly GameDBContext _players;

        public PlayerListViewComponent( GameDBContext players )
        {
            _players = players;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var players = await GetPlayersAsync();
            var results = players.Select( p => new PlayerIndexListingModel
            {
                PlayerId = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Position = p.Position,
                Team = p.Team
            } ).ToList();

            var model = new PlayerIndexModel { Players = results };

            return View( model );

        }

        private Task<List<Player>> GetPlayersAsync()
        {
            return _players.Players.ToListAsync();
        }
    }
}
