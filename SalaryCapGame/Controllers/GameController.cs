using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalaryCapData;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalaryCapGame.Controllers
{
    public class GameController : Controller
    {
        private GameDBContext _context;
        // GET: /<controller>/

        public GameController( GameDBContext context )
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
