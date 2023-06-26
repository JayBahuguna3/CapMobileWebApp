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
    public class NomineesController : ParentController
    {
        private readonly CapRetailContext _context;

        public NomineesController(CapRetailContext context, UserService userService) : base(userService)
        {
            _context = context;
        }

        // GET: Nominees
        public async Task<IActionResult> Index()
        {
            var capRetailContext = _context.Nominee.Include(n => n.Customer);
            return View(await capRetailContext.ToListAsync());
        }

        // GET: Nominees/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Nominee == null)
            {
                return NotFound();
            }

            var nominee = await _context.Nominee
                .Include(n => n.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nominee == null)
            {
                return NotFound();
            }

            return View(nominee);
        }

        // GET: Nominees/Create
        //public IActionResult Create()
        //{
        //    var user = this._userService.GetUserInfo(User);
        //    if (user != null)
        //    {
        //        ViewData["CustomerId"] = new SelectList(_context.Customer
        //        .Where(e => e.CreatedBy == user.UserId), "CustomerId", "CustomerName");
        //    }
        //    else
        //    {
        //        ViewData["CustomerId"] = new SelectList(new List<Customer>());
        //    }
        //    return View();
        //}

        public IActionResult Create(int customerid)
        {
            var user = this._userService.GetUserInfo(User);
            if (user != null)
            {
                ViewData["CustomerId"] = new SelectList(_context.Customer
                .Where(e => e.CreatedBy == user.UserId), "CustomerId", "CustomerName", customerid);
            }
            else
            {
                ViewData["CustomerId"] = new SelectList(new List<Customer>());
            }
            if (customerid != null)
            {
                var cust = _context.Nominee.Where(e => e.CustomerId == customerid).FirstOrDefault();
                if (cust != null)
                {
                    return View(cust);
                }
            }

            return View();
        }

        // POST: Nominees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Gender,Relation,Aadhar,Pan,Mobile,IsMinor,Appointe,Address,Photo,CustomerId")] Nominee nominee)
        {
            if (ModelState.IsValid)
            {
                if (nominee.Id > 0)
                {
                    _context.Update(nominee);
                }
                else if (nominee.Id == 0)
                {
                    _context.Add(nominee);
                }
                else
                {
                    ModelState.AddModelError("NoID", "No nominee id found.");
                    return View(nominee);

                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerName", nominee.CustomerId);
            return View(nominee);
        }

        // GET: Nominees/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Nominee == null)
            {
                return NotFound();
            }

            var nominee = await _context.Nominee.FindAsync(id);
            if (nominee == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "City", nominee.CustomerId);
            return View(nominee);
        }

        // POST: Nominees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Gender,Relation,Aadhar,Pan,Mobile,IsMinor,Appointe,Address,Photo,CustomerId")] Nominee nominee)
        {
            if (id != nominee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nominee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NomineeExists(nominee.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "City", nominee.CustomerId);
            return View(nominee);
        }

        // GET: Nominees/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Nominee == null)
            {
                return NotFound();
            }

            var nominee = await _context.Nominee
                .Include(n => n.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nominee == null)
            {
                return NotFound();
            }

            return View(nominee);
        }

        // POST: Nominees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Nominee == null)
            {
                return Problem("Entity set 'CapRetailContext.Nominee'  is null.");
            }
            var nominee = await _context.Nominee.FindAsync(id);
            if (nominee != null)
            {
                _context.Nominee.Remove(nominee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NomineeExists(long id)
        {
          return (_context.Nominee?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public IActionResult ChooseCustomer()
        {
            var user = this._userService.GetUserInfo(User);
            if (user != null)
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
        [HttpPost]
        public IActionResult ChooseCustomer([Bind("CustomerId,CustomerName")] Customer customer)
        {
            if (customer != null && !string.IsNullOrWhiteSpace(customer.CustomerId.ToString()))
            {
                return RedirectToActionPermanent("Create", new { customerid = customer.CustomerId });
            }
            else
            {
                ModelState.AddModelError("NoSelection", "Customer not selected");
                return View();
            }
        }

    }
}
