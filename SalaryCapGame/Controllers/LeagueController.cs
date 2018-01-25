using Microsoft.AspNetCore.Mvc;
using SalaryCapData;
using SalaryCapGame.WebViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryCapGame.Controllers
{
    public class LeagueController : Controller
    {
        private readonly ILeague _leagues;

        public LeagueController( ILeague leagues )
        {
            _leagues = leagues;
        }

        public IActionResult Index()
        {
            var leagueModel = _leagues.GetAll();
            var listingResult = leagueModel.Select( result => new LeagueIndexListingModel
            {
                Id = result.LeagueId,
                Name = result.Name,
                Commissioner = result.Commissioner

            } );

            var model = new LeagueIndexModel()
            {
                Leagues = listingResult.ToList()
            };

            return View( model );
        }

        public IActionResult Detail( int id )
        {
            var leagueModel = _leagues.Get( id );
            var leagueDetail = new LeagueDetailModel()
            {
                Id = id,
                Name = leagueModel.Name,
                Commissioner = leagueModel.Commissioner,
                Franchises = leagueModel.Franchises
            };

            return View( leagueDetail );
        }

        public IActionResult Summary( int id )
        {
            var leagueModel = _leagues.Get( id );
            var listingResult = new LeagueIndexListingModel()
            {
                Id = leagueModel.LeagueId,
                Name = leagueModel.Name,
                Commissioner = leagueModel.Commissioner

            };

            return View( leagueModel );
        }
    }
}
