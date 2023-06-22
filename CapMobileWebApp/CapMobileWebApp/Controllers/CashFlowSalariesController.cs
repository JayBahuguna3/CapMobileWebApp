using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapMobileWebApp.DAL.Context;
using CapMobileWebApp.DAL.Model;
using CapMobileWebApp.Services;

namespace CapMobileWebApp.Controllers
{
    public class CashFlowSalariesController : ParentController
    {
        private readonly CapRetailContext _context;

        public CashFlowSalariesController(CapRetailContext context, UserService userService)
             : base(userService)
        {
            _context = context;
        }

        // GET: CashFlowSalaries
        public async Task<IActionResult> Index()
        {
            var capRetailContext = _context.CashFlowSalary.Include(c => c.Customer);
            return View(await capRetailContext.ToListAsync());
        }

        // GET: CashFlowSalaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CashFlowSalary == null)
            {
                return NotFound();
            }

            var cashFlowSalary = await _context.CashFlowSalary
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cashFlowSalary == null)
            {
                return NotFound();
            }

            return View(cashFlowSalary);
        }

        // GET: CashFlowSalaries/Create
        public IActionResult Create()
        {
            var user = this._userService.GetUserInfo(User);
            if(user != null)
            {
                ViewData["CustomerId"] = new SelectList(_context.Customer
                .Where(e => e.CreatedBy == user.UserId), "CustomerId", "CustomerName");
            }
            else
            {
                ViewData["CustomerId"] = new SelectList(new List<Customer>());
            }
            
            return View();
        }

        // POST: CashFlowSalaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,MonthlyIncome,SpouseIncome,OtherFamilyMemberIncome,OtherIncome,TotalIncome,LoanEmi,Rent,EducationalFees,TutionFees,PersonalInsurance,PropertyTax,Sip,PhoneBill,Internet,ElectricityBill,Dth,GroceryAndVegetable,Milk,CookingGas,Maid,CarInsurance,Fuel,VehicleMaintenance,MedicalExpenses,FunctionCelebration,OtherExpenses,TotalOutgoing")] CashFlowSalary cashFlowSalary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cashFlowSalary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "City", cashFlowSalary.CustomerId);
            return View(cashFlowSalary);
        }

        // GET: CashFlowSalaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CashFlowSalary == null)
            {
                return NotFound();
            }

            var cashFlowSalary = await _context.CashFlowSalary.FindAsync(id);
            if (cashFlowSalary == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "City", cashFlowSalary.CustomerId);
            return View(cashFlowSalary);
        }

        // POST: CashFlowSalaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId,MonthlyIncome,SpouseIncome,OtherFamilyMemberIncome,OtherIncome,TotalIncome,LoanEmi,Rent,EducationalFees,TutionFees,PersonalInsurance,PropertyTax,Sip,PhoneBill,Internet,ElectricityBill,Dth,GroceryAndVegetable,Milk,CookingGas,Maid,CarInsurance,Fuel,VehicleMaintenance,MedicalExpenses,FunctionCelebration,OtherExpenses,TotalOutgoing")] CashFlowSalary cashFlowSalary)
        {
            if (id != cashFlowSalary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cashFlowSalary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CashFlowSalaryExists(cashFlowSalary.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "City", cashFlowSalary.CustomerId);
            return View(cashFlowSalary);
        }

        // GET: CashFlowSalaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CashFlowSalary == null)
            {
                return NotFound();
            }

            var cashFlowSalary = await _context.CashFlowSalary
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cashFlowSalary == null)
            {
                return NotFound();
            }

            return View(cashFlowSalary);
        }

        // POST: CashFlowSalaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CashFlowSalary == null)
            {
                return Problem("Entity set 'CapRetailContext.CashFlowSalary'  is null.");
            }
            var cashFlowSalary = await _context.CashFlowSalary.FindAsync(id);
            if (cashFlowSalary != null)
            {
                _context.CashFlowSalary.Remove(cashFlowSalary);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CashFlowSalaryExists(int id)
        {
          return (_context.CashFlowSalary?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
