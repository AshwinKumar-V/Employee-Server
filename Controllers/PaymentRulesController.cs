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
    public class PaymentRulesController : Controller
    {
        private readonly EmployeeContext _context;

        public PaymentRulesController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: PaymentRules
        public async Task<IActionResult> Index()
        {
              return _context.PaymentRules != null ? 
                          View(await _context.PaymentRules.ToListAsync()) :
                          Problem("Entity set 'EmployeeContext.PaymentRules'  is null.");
        }

        // GET: PaymentRules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PaymentRules == null)
            {
                return NotFound();
            }

            var paymentRule = await _context.PaymentRules
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentRule == null)
            {
                return NotFound();
            }

            return View(paymentRule);
        }

        // GET: PaymentRules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaymentRules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Rule")] PaymentRule paymentRule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paymentRule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paymentRule);
        }

        // GET: PaymentRules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PaymentRules == null)
            {
                return NotFound();
            }

            var paymentRule = await _context.PaymentRules.FindAsync(id);
            if (paymentRule == null)
            {
                return NotFound();
            }
            return View(paymentRule);
        }

        // POST: PaymentRules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Rule")] PaymentRule paymentRule)
        {
            if (id != paymentRule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentRule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentRuleExists(paymentRule.Id))
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
            return View(paymentRule);
        }

        // GET: PaymentRules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PaymentRules == null)
            {
                return NotFound();
            }

            var paymentRule = await _context.PaymentRules
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentRule == null)
            {
                return NotFound();
            }

            return View(paymentRule);
        }

        // POST: PaymentRules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PaymentRules == null)
            {
                return Problem("Entity set 'EmployeeContext.PaymentRules'  is null.");
            }
            var paymentRule = await _context.PaymentRules.FindAsync(id);
            if (paymentRule != null)
            {
                _context.PaymentRules.Remove(paymentRule);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentRuleExists(int id)
        {
          return (_context.PaymentRules?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
