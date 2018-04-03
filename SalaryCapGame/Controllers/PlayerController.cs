using Microsoft.AspNetCore.Mvc;
using SalaryCapData.Interfaces;
using SalaryCapGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryCapGame.Controllers
{
	public class PlayerController : Controller
	{
		private readonly IPlayer _players;
		private readonly ITeam _teams;

		public PlayerController( IPlayer players, ITeam teams )
		{
			_players = players;
			_teams = teams;
		}

		public IActionResult Index()
		{
			var players = _players.GetAll();
			var results = players.Select( p => new PlayerIndexListingModel
			{
				PlayerId = p.Id,
				FirstName = p.FirstName,
				LastName = p.LastName,
				Position = p.Position,
				Team = p.Team,
				Value = p.InitialValue
			} ).ToList();

			var model = new PlayerIndexModel { Players = results };

			return View( model );
		}



	}
}
