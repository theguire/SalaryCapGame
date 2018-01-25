using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SalaryCapGame.WebViewModels;
using SalaryCapData;
using System.Threading.Tasks;
using SalaryCapData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace SalaryCapGame.Controllers
{
    public class OwnerController : Controller
    {
        private readonly IOwner _owners;
        private readonly IFranchise _franchises;
        private readonly ILeague _leagues;
        public int PageSize = 4;

        public OwnerController( IOwner owners, IFranchise franchises, ILeague leagues )
        {
            _owners = owners;
            _franchises = franchises;
            _leagues = leagues;
        }

        //public ViewResult List() => View( _owners.Owners );
        
        //List of all owners
        public IActionResult Index()
        {
            var ownerModels = _owners.GetAll();
            var listingResult = ownerModels.Select( result => new OwnerIndexListingModel
            {
                Id = result.OwnerId,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Email = result.Email,
                ImageUrl =  result.ImageUrl,
                Franchises = result.Franchises
            } );

            var model = new OwnerIndexModel()
            {
                Owners = listingResult.ToList()
            };

            return ( View( model ) );
        }

        public IActionResult Detail( int id )
        {
            var owner = _owners.Get( id );
            var ownerModel = new OwnerIndexListingModel
            {
                Id = owner.OwnerId,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                Email = owner.Email,
                ImageUrl = owner.ImageUrl,
                Franchises = owner.Franchises
            };

            //var leagues = _leagues.GetAll();
            //var sll = new SelectLeagueModel
            //{
            //    Leagues = leagues.Select( l => new SelectListItem
            //    {
            //        Text = l.Name,
            //        Value = l.LeagueId.ToString()
            //    } )

            //};


            //var model = new OwnerDetailModel
            //{
            //    OwnerId = id,
            //    OwnerFirstName = owner.FirstName,
            //    OwnerLastName = owner.LastName,
            //    Franchises = owner.Franchises,
            //    ImageUrl = owner.ImageUrl,
            //    SelectLeague = sll,
            //    NewFranchiseName = ""
            //};

            var model = new OwnerDetailModel
            {
                OwnerIndexListingModel = ownerModel,
            };
            PopulateLeagueDropDownList();
            return ( View( model ) );
        }


        private void PopulateLeagueDropDownList( object selectedLeague = null )
        {
            var leagues = _leagues.GetAll();
            var leagueListingResult = leagues.Select( result => new LeagueIndexListingModel
            {
                Id = result.LeagueId,
                Name = result.Name,
                Commissioner = result.Commissioner,
                LeagueInfo = result.Name 
                                + " " 
                                + result.Commissioner.FirstName 
                                + " " 
                                + result.Commissioner.LastName
                                + " "
                                + result.Franchises.Count().ToString() + "/10"
            } );


            ViewBag.LeagueID = new SelectList( leagueListingResult, "Id", "LeagueInfo",  selectedLeague );
        }

        //public ActionResult CreateNewFranchisePopUp()
        //{
        //    return View();
        //}

        //protected void SaveData( Object sender, EventArgs e )
        //{
        //    var  i = 0;
        //}
        // POST: Franchise/CreateFranchise
        [HttpPost]
        public IActionResult CreateFranchise( int ownerId, string franchiseName )
        {
            Franchise franchise = new Franchise();
            franchise.Owner.OwnerId = ownerId;
            franchise.Name = franchiseName;
            _franchises.Add( franchise );
            return ( RedirectToAction( nameof( Detail ), new { id = ownerId }));
        
        }

        public IActionResult CreateFranchise( int id )
        {
            EditFranchiseName editFranchise = new EditFranchiseName();
            editFranchise.OwnerId = id;
             return View( "CreateFranchise", editFranchise );

        }

        
        //public IActionResult JoinLeague( int leagueId, int franchiseId, int ownerId )
        //{
        //    //int selectedLeagueId = detailModel.SelectLeague.SelectedLeagueId;
        //    //int franchiseId = _franchises.Get( detailModel.OwnerIndexListingModel.Id ).FranchiseId;

        //    _franchises.JoinLeague( franchiseId, leagueId );
        //    return ( RedirectToAction( nameof( Detail ), new { id = ownerId } ) );
        //    //return ( RedirectToAction( nameof( Detail ) ) );
        //}

        //[HttpPost]
        //public IActionResult JoinLeague( Franchise franchise )
        //{
        //    //int selectedLeagueId = detailModel.SelectLeague.SelectedLeagueId;
        //    //Franchise franchise = _franchises.Get( detailModel.OwnerIndexListingModel.Id );
        //    //franchise.LeagueId = selectedLeagueId;
        //    //franchise.League = _leagues.Get( selectedLeagueId );
        //    //int franchiseId = _franchises.Get( detailModel.OwnerIndexListingModel.Id ).FranchiseId;

        //    _franchises.UpdateFranchise( franchise );
        //    //_franchises.JoinLeague( franchiseId, selectedLeagueId );
        //    //return ( RedirectToAction( nameof( Detail ), new { id = OwnerId } ) );
        //    return ( RedirectToAction( nameof( Detail ), new { id = franchise.Owner.OwnerId } ) );
        //}

        public IActionResult LeagueDetail( int id )
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
        // GET:Franchise/New
        public IActionResult New()
        {
            return ( View() );
        }

        //POST: Franshise/New
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New( [Bind( "FranchiseId, OwnerId, LeagueId, Name, DateCreated, DateModified" )] Franchise franchise)
        {
            _franchises.Add( franchise );
            return ( RedirectToAction( nameof( Detail )));
        }
        // GET: Owners1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Owners1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( [Bind( "OwnerId,FirstName,LastName,Email,DateCreated,DateModified" )] Owner owner )
        {
            if ( ModelState.IsValid )
            {
                _owners.Add( owner );
                return RedirectToAction( nameof( Index ) );
            }
            return View( owner );
        }

    }
}
