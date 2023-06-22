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
    public class CashFlowBusinessesController : ParentController
    {
        private readonly CapRetailContext _context;

        public CashFlowBusinessesController(CapRetailContext context)
        {
            _context = context;
        }

        // GET: CashFlowBusinesses
        public async Task<IActionResult> Index()
        {
            var capRetailContext = _context.CashFlowBusiness.Include(c => c.Customer);
            return View(await capRetailContext.ToListAsync());
        }

        // GET: CashFlowBusinesses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CashFlowBusiness == null)
            {
                return NotFound();
            }

            var cashFlowBusiness = await _context.CashFlowBusiness
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cashFlowBusiness == null)
            {
                return NotFound();
            }

            return View(cashFlowBusiness);
        }

        // GET: CashFlowBusinesses/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "City");
            return View();
        }

        // POST: CashFlowBusinesses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IncomingCash,IncomingSales,IncomingReceivables,OtherIncome,TotalIncome,LoanEmi,Rent,MaterialPurchase,SalariesAndWages,MarketingExp,PhoneBills,Internet,ElectricityBill,MotorFuelExpenses,TransportationExpenses,MotorMaintenanceExp,Insurance,Taxes,Utility,GeneralAndAdministrative,MedicalExp,MiscellaneousExp,CustomerId,TotalOutgoing")] CashFlowBusiness cashFlowBusiness)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cashFlowBusiness);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "City", cashFlowBusiness.CustomerId);
            return View(cashFlowBusiness);
        }

        // GET: CashFlowBusinesses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CashFlowBusiness == null)
            {
                return NotFound();
            }

            var cashFlowBusiness = await _context.CashFlowBusiness.FindAsync(id);
            if (cashFlowBusiness == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "City", cashFlowBusiness.CustomerId);
            return View(cashFlowBusiness);
        }

        // POST: CashFlowBusinesses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IncomingCash,IncomingSales,IncomingReceivables,OtherIncome,TotalIncome,LoanEmi,Rent,MaterialPurchase,SalariesAndWages,MarketingExp,PhoneBills,Internet,ElectricityBill,MotorFuelExpenses,TransportationExpenses,MotorMaintenanceExp,Insurance,Taxes,Utility,GeneralAndAdministrative,MedicalExp,MiscellaneousExp,CustomerId,TotalOutgoing")] CashFlowBusiness cashFlowBusiness)
        {
            if (id != cashFlowBusiness.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cashFlowBusiness);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CashFlowBusinessExists(cashFlowBusiness.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "City", cashFlowBusiness.CustomerId);
            return View(cashFlowBusiness);
        }

        // GET: CashFlowBusinesses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CashFlowBusiness == null)
            {
                return NotFound();
            }

            var cashFlowBusiness = await _context.CashFlowBusiness
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cashFlowBusiness == null)
            {
                return NotFound();
            }

            return View(cashFlowBusiness);
        }

        // POST: CashFlowBusinesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CashFlowBusiness == null)
            {
                return Problem("Entity set 'CapRetailContext.CashFlowBusiness'  is null.");
            }
            var cashFlowBusiness = await _context.CashFlowBusiness.FindAsync(id);
            if (cashFlowBusiness != null)
            {
                _context.CashFlowBusiness.Remove(cashFlowBusiness);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CashFlowBusinessExists(int id)
        {
          return (_context.CashFlowBusiness?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
