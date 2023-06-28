using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Employee_Server.Data;
using Employee_Server.Models;

namespace Employee_Server.Controllers
{
    public class WorkingHoursController : Controller
    {
        private readonly EmployeeContext _context;

        public WorkingHoursController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: WorkingHours
        public async Task<IActionResult> Index()
        {
              return _context.WorkingHours != null ? 
                          View(await _context.WorkingHours.ToListAsync()) :
                          Problem("Entity set 'EmployeeContext.WorkingHours'  is null.");
        }

        // GET: WorkingHours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WorkingHours == null)
            {
                return NotFound();
            }

            var workingHour = await _context.WorkingHours
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workingHour == null)
            {
                return NotFound();
            }

            return View(workingHour);
        }

        // GET: WorkingHours/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkingHours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ShiftName,ShiftHours")] WorkingHour workingHour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workingHour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workingHour);
        }

        // GET: WorkingHours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WorkingHours == null)
            {
                return NotFound();
            }

            var workingHour = await _context.WorkingHours.FindAsync(id);
            if (workingHour == null)
            {
                return NotFound();
            }
            return View(workingHour);
        }

        // POST: WorkingHours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ShiftName,ShiftHours")] WorkingHour workingHour)
        {
            if (id != workingHour.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workingHour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkingHourExists(workingHour.Id))
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
            return View(workingHour);
        }

        // GET: WorkingHours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WorkingHours == null)
            {
                return NotFound();
            }

            var workingHour = await _context.WorkingHours
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workingHour == null)
            {
                return NotFound();
            }

            return View(workingHour);
        }

        // POST: WorkingHours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WorkingHours == null)
            {
                return Problem("Entity set 'EmployeeContext.WorkingHours'  is null.");
            }
            var workingHour = await _context.WorkingHours.FindAsync(id);
            if (workingHour != null)
            {
                _context.WorkingHours.Remove(workingHour);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkingHourExists(int id)
        {
          return (_context.WorkingHours?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
