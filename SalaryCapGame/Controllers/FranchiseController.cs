using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SalaryCapGame.WebViewModels;
using SalaryCapData;
using SalaryCapData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SalaryCapGame.Controllers
{
    public class FranchiseController : Controller
    {
        private IFranchise _franchises;
        private ILeague _leagues;

        public FranchiseController( IFranchise franchises, ILeague leagues )
        {
            _franchises = franchises;
            _leagues = leagues;
        }

        //GET: Franchises
        public IActionResult Index()
        {
            var franchiseModels = _franchises.GetAll();
            var listingResult = franchiseModels.Select( result => new FranchiseIndexListingModel
            {
                Id = result.FranchiseId,
                Name = result.Name,
                ImageUrl = result.ImageUrl,
                Owner = result.Owner,
                League = result.League,
            });

            var model = new FranchiseIndexModel()
            {
                Franchises = listingResult
            };

            return ( View( model ));
        }

        [HttpPost]
        public IActionResult JoinLeague( int leagueId, int franchiseId, int ownerId )
        {
            //int selectedLeagueId = detailModel.SelectLeague.SelectedLeagueId;
            //int franchiseId = _franchises.Get( detailModel.OwnerIndexListingModel.Id ).FranchiseId;

            _franchises.JoinLeague( franchiseId, leagueId );
            return ( RedirectToAction( nameof( Detail ), new { id = ownerId } ) );
            //return ( RedirectToAction( nameof( Detail ) ) );
        }




        public IActionResult Detail( int id )
        {
            var franchise = _franchises.Get( id );
            var model = new FranchiseDetailModel
            {
                Id = id,
                ImageUrl = "",
                League = franchise.League,
                Owner = franchise.Owner,
                Name = franchise.Name
            };
            return View( model );
        }
        //public IActionResult Create()
        //{
        //    PopulateLeagueDropDownList();
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create( [Bind( "FranchiseID,OwnerId,Name, LeagueId" )] Franchise franchise )
        //{
        //    if ( ModelState.IsValid )
        //    {
        //        _franchises.Add( franchise );
        //        return RedirectToAction( nameof( Index ) );
        //    }
        //    PopulateLeagueDropDownList( franchise.LeagueId );
        //    return View( franchise );
        //}

        //public IActionResult Create1( Franchise franchise )
        //{
        //    if ( ModelState.IsValid )
        //    {
        //        _franchises.Add( franchise );
        //        return RedirectToAction( nameof( Index ) );
        //    }
        //    PopulateLeagueDropDownList( franchise.LeagueId );
        //    return View( franchise );
        //}

        private void PopulateLeagueDropDownList( object selectedLeague = null )
        {
            var leagues = _leagues.GetAll();
            var leagueListingResult = leagues.Select( result => new LeagueIndexListingModel
            {
                Id = result.LeagueId,
                Name = result.Name,
                Commissioner = result.Commissioner,
                CommissionerId = result.CommissionerId
            } );


            ViewBag.LeagueID = new SelectList( leagueListingResult, "Name", "Commissioner", selectedLeague );
        }
    }
}
