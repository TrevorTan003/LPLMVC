using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LPLMVC.Models;
using LPLMVC.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LPLMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LPLTeamsContext _context;

        public HomeController(ILogger<HomeController> logger, LPLTeamsContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.TeamDataModels.ToListAsync());
        }

        public IActionResult Rules()
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
