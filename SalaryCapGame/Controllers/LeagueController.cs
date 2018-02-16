using Microsoft.AspNetCore.Mvc;
using SalaryCapData.Interfaces;
using SalaryCapGame.ViewModels;
using System.Linq;

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
            var leagues = _leagues.GetAll();
            var listingResult = leagues.Select( result => new LeagueIndexListingModel
            {
                LeagueListingModel = new LeagueListingModel
                {
                    Id = result.Id,
                    Name = result.Name,
                    CommissionerId = result.CommissionerId,
                    Commissioner = result.Commissioner,
                },
                Franchises = result.Franchises

            } ).ToList();
            

            var model = new LeagueIndexModel()
            {
                Leagues = listingResult.ToList()
            };

            return View( model );
        }

        public IActionResult Detail( int id )
        {
            var leagueModel = _leagues.Get( id );
            var leagueDetail = new LeagueIndexListingModel()
            {
                LeagueListingModel = new LeagueListingModel
                {
                    Id = id,
                    Name = leagueModel.Name,
                    Commissioner = leagueModel.Commissioner,
                    CommissionerId = leagueModel.CommissionerId,
                },
                Franchises = leagueModel.Franchises.OrderByDescending( f => f.Points )
            };

            return View( leagueDetail );
        }

        public IActionResult Summary( int id )
        {
            var leagueModel = _leagues.Get( id );
            var listingResult = new LeagueListingModel()
            {
                Id = leagueModel.Id,
                Name = leagueModel.Name,
                Commissioner = leagueModel.Commissioner

            };

            return View( leagueModel );
        }

    }
}
