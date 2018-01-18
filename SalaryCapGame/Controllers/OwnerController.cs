using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SalaryCapGame.WebViewModels;
using SalaryCapData;
using System.Threading.Tasks;
using SalaryCapData.Models;

namespace SalaryCapGame.Controllers
{
    public class OwnerController : Controller
    {
        private readonly IOwner _owners;
        private readonly IFranchise _franchises;
        private readonly ILeague _leagues;

        public OwnerController( IOwner owners, IFranchise franchises, ILeague leagues )
        {
            _owners = owners;
            _franchises = franchises;
            _leagues = leagues;
        }

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
            var model = new OwnerDetailModel
            {
                OwnerId = id,
                OwnerFirstName = owner.FirstName,
                OwnerLastName = owner.LastName,
                Franchises = owner.Franchises,
                //Leagues = _leagues.GetAll()
                ImageUrl = owner.ImageUrl,
                NewFranchiseName = ""
            };

            return ( View( model ) );
        }

        // POST: Franchise/CreateFranchise
        [HttpPost]
        public IActionResult CreateFranchise( int OwnerId, string newFranchiseName )
        {
            Franchise franchise = new Franchise();
            franchise.OwnerId = OwnerId;
            franchise.Name = newFranchiseName;
            _franchises.Add( franchise );
            return ( RedirectToAction( nameof( Detail ), new { id = OwnerId }));
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
