using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LPLMVC.Data;
using LPLMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace LPLMVC.Controllers
{
    public class TeamController : Controller
    {
        private readonly LPLTeamsContext _context;

        public TeamController(LPLTeamsContext context)
        {
            _context = context;
        }

        // GET: Team
        public async Task<IActionResult> Index()
        {
            return View(await _context.TeamDataModels.ToListAsync());
        }

        // GET: Team/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamDataModel = await _context.TeamDataModels
                .FirstOrDefaultAsync(m => m.TeamId == id);
            if (teamDataModel == null)
            {
                return NotFound();
            }

            return View(teamDataModel);
        }

        // GET: Team/Create
        [Authorize(Roles = "User, Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Team/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "User, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeamId,SchoolName,Player1,Player2,Player3,Player4,Player5,Player6,Player7")] TeamDataModel teamDataModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teamDataModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teamDataModel);
        }

        // GET: Team/Edit/5
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamDataModel = await _context.TeamDataModels.FindAsync(id);
            if (teamDataModel == null)
            {
                return NotFound();
            }
            return View(teamDataModel);
        }

        // POST: Team/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "User, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeamId,SchoolName,Player1,Player2,Player3,Player4,Player5,Player6,Player7,Wins,Games")] TeamDataModel teamDataModel)
        {
            if (id != teamDataModel.TeamId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teamDataModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamDataModelExists(teamDataModel.TeamId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(teamDataModel);
        }

        // GET: Team/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamDataModel = await _context.TeamDataModels
                .FirstOrDefaultAsync(m => m.TeamId == id);
            if (teamDataModel == null)
            {
                return NotFound();
            }

            return View(teamDataModel);
        }

        // POST: Team/Delete/5
        [Authorize(Roles = "User, Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teamDataModel = await _context.TeamDataModels.FindAsync(id);
            _context.TeamDataModels.Remove(teamDataModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamDataModelExists(int id)
        {
            return _context.TeamDataModels.Any(e => e.TeamId == id);
        }
    }
}
