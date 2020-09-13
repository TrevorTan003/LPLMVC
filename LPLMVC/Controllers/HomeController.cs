﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LPLMVC.Models;
using LPLMVC.Data;
using Microsoft.EntityFrameworkCore;

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

        // GET: Team
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
