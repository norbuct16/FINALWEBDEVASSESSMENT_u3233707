using System.Diagnostics;
using FINALWEBDEV_u3233707.Data;
using FINALWEBDEV_u3233707.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FINALWEBDEV_u3233707.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context ,ILogger<HomeController> logger)
		{
			_logger = logger;
            _context = context;
        }
        public async Task<IActionResult> Index()

		{
            return _context.AddNewGenAI != null ?
                          View(await _context.AddNewGenAI.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.AddNewGenAI'  is null.");
           
        }


		public IActionResult GenAI()
		{
			return View();
		}

		public IActionResult Home()
		{
			return View();
		}

		public IActionResult Jobs()
		{
			return View();
		}

		public IActionResult Contacts()
		{
			return View();
		}

		public IActionResult GenAISites()
		{
			return View();
		}

     

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}