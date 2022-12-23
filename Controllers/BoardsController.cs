using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlowCaseTracking.Database;
using Flow_CaseTracking.Models;

namespace Flow_CaseTracking.Controllers
{
    public class BoardsController : Controller
    {
        private readonly FlowCaseDbContext _context;

        public BoardsController(FlowCaseDbContext context)
        {
            _context = context;
        }

        // GET: Boards
        public async Task<IActionResult> Index()
        {
            var flowCaseDbContext = _context.Boards.Include(b => b.User);
            return View(await flowCaseDbContext.ToListAsync());
        }

        // GET: Boards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Boards == null)
            {
                return NotFound();
            }

            var boards = await _context.Boards
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boards == null)
            {
                return NotFound();
            }

            return View(boards);
        }

        // GET: Boards/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email");
            return View();
        }

        // POST: Boards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulli,UserId")] Boards boards)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boards);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", boards.UserId);
            return View(boards);
        }

        // GET: Boards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Boards == null)
            {
                return NotFound();
            }

            var boards = await _context.Boards.FindAsync(id);
            if (boards == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", boards.UserId);
            return View(boards);
        }

        // POST: Boards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulli,UserId")] Boards boards)
        {
            if (id != boards.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boards);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoardsExists(boards.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", boards.UserId);
            return View(boards);
        }

        // GET: Boards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Boards == null)
            {
                return NotFound();
            }

            var boards = await _context.Boards
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boards == null)
            {
                return NotFound();
            }

            return View(boards);
        }

        // POST: Boards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Boards == null)
            {
                return Problem("Entity set 'FlowCaseDbContext.Boards'  is null.");
            }
            var boards = await _context.Boards.FindAsync(id);
            if (boards != null)
            {
                _context.Boards.Remove(boards);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoardsExists(int id)
        {
          return _context.Boards.Any(e => e.Id == id);
        }
    }
}
