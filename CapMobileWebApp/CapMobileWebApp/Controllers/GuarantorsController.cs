using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapMobileWebApp.DAL.Context;
using CapMobileWebApp.DAL.Model;

namespace CapMobileWebApp.Controllers
{
    public class GuarantorsController : ParentController
    {
        private readonly CapRetailContext _context;

        public GuarantorsController(CapRetailContext context)
        {
            _context = context;
        }

        // GET: Guarantors
        public async Task<IActionResult> Index()
        {
            var capRetailContext = _context.Guarantor.Include(g => g.Customer);
            return View(await capRetailContext.ToListAsync());
        }

        // GET: Guarantors/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Guarantor == null)
            {
                return NotFound();
            }

            var guarantor = await _context.Guarantor
                .Include(g => g.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guarantor == null)
            {
                return NotFound();
            }

            return View(guarantor);
        }

        // GET: Guarantors/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "City");
            return View();
        }

        // POST: Guarantors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Gender,Dob,Age,Mobile,CompanyName,Salary,Address,Photo,CustomerId")] Guarantor guarantor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guarantor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "City", guarantor.CustomerId);
            return View(guarantor);
        }

        // GET: Guarantors/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Guarantor == null)
            {
                return NotFound();
            }

            var guarantor = await _context.Guarantor.FindAsync(id);
            if (guarantor == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "City", guarantor.CustomerId);
            return View(guarantor);
        }

        // POST: Guarantors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Gender,Dob,Age,Mobile,CompanyName,Salary,Address,Photo,CustomerId")] Guarantor guarantor)
        {
            if (id != guarantor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guarantor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuarantorExists(guarantor.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "City", guarantor.CustomerId);
            return View(guarantor);
        }

        // GET: Guarantors/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Guarantor == null)
            {
                return NotFound();
            }

            var guarantor = await _context.Guarantor
                .Include(g => g.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guarantor == null)
            {
                return NotFound();
            }

            return View(guarantor);
        }

        // POST: Guarantors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Guarantor == null)
            {
                return Problem("Entity set 'CapRetailContext.Guarantor'  is null.");
            }
            var guarantor = await _context.Guarantor.FindAsync(id);
            if (guarantor != null)
            {
                _context.Guarantor.Remove(guarantor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuarantorExists(long id)
        {
          return (_context.Guarantor?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
