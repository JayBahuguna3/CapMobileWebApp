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
    public class CustomersController : ParentController
    {
        private readonly CapRetailContext _context;

        public CustomersController(CapRetailContext context, UserService userService) : base(userService)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
              return _context.Customer != null ? 
                          View(await _context.Customer.Take(10).OrderBy(e => e.CustomerId).ToListAsync()) :
                          Problem("Entity set 'CapRetailContext.Customer'  is null.");
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create(int customerid = 0)
        {
            if (customerid > 0)
            {
                var cust = _context.Customer.Where(e => e.CustomerId == customerid).FirstOrDefault();
                if (cust != null)
                {
                    return View(cust);
                }
            }

            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]  
        public async Task<IActionResult> Create([Bind("CustomerId,CustomerName,AccountDate,ResAddress,OffAddress,TelPhoneNo,MobileNo,PhotoIdentityNumber,PanCardNo,BirthDate,Age,ActiveBy,City,Mstate,EmailId,Pincode,Photoid,Mphoto,Idtype,Memactive,GroupId,BranchId,LastModifiedBy,Approval,ManagerId,Csrapprove,Prpoposedloanamount,ManagerRemark,Csrremark,Mangerdate,Csrdate,LoanTypeid,LoanCycleNo,MartialStatus,SpouseName,SpouseDob,NomineeName,NomineeAge,NomineeRelation,Status,Reason,Religion,Caste,Gender,ApplicantFather,FamilyDetails,FamilyRelation,Rationcardno,VoterIdcardno,Uidno,LoanPurpose,Idproof1,Idproof2,OriginatorId,OfficerChangeDate,CustomerSign,FamilyDetails2,FamilyRelation2,FamilyDetails3,FamilyRelation3,FamilyDetails4,FamilyRelation4,TebusinessActivity,VebusinessActivity,ApplicantName,ActivityConfirmation,CreditHistory,VerificationOfDocs,DvecustomerApproval,DvecustomerApprovalDateTime,ExActiveCustId,ExActiveLoanAc,IsReLoan,IsExistingLoanClose,IsTopupLoan,CustomerGender,CustomerAadharAddress,CustomerCurrentAddress,CustomerDistrict,CustomerTaluka,CustomerVillage,CustomerLat,CustomerLong,CustomerLoanApplicationDate,CustomerDrivingLicNo,CustomerEducation,CustomerCategory,CustomerLoanType,NomineeAadharCard,NomineePanCard,NomineeMobileNo,GuarantorName,GuarantorAddress,GuarantorGender,GuarantorMobileNo,GuarantorDob,GuarantorPhoto,GuarantorCompanyName,GuarantorSalary")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                this.userInfo = _userService.GetUserInfo(User);
                customer.CreatedBy = this.userInfo.UserId;
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
            return View(customer);
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
            if (customer != null && !string.IsNullOrWhiteSpace(customer.CustomerId.ToString())) {
                var custCategory = _context.Customer.Where(e => e.CustomerId == customer.CustomerId).Select(e => e.CustomerCategory).FirstOrDefault();
                if (custCategory.ToString() == "Salary")
                {
                    return RedirectToActionPermanent("Create", "CashFlowSalaries", new { customerid = customer.CustomerId });
                }
                else if(custCategory.ToString() == "Business")
                {
                    return RedirectToActionPermanent("Create", "CashFlowBusinesses", new { customerid = customer.CustomerId });
                }
                else
                {
                    ModelState.AddModelError("IncorrectCustomer", "User Category not found");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("NoSelection", "Customer not selected");
                return View();
            }
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("CustomerId,CustomerName,AccountDate,ResAddress,OffAddress,TelPhoneNo,MobileNo,PhotoIdentityNumber,PanCardNo,BirthDate,Age,ActiveBy,City,Mstate,EmailId,Pincode,Photoid,Mphoto,Idtype,Memactive,GroupId,BranchId,LastModifiedBy,Approval,ManagerId,Csrapprove,Prpoposedloanamount,ManagerRemark,Csrremark,Mangerdate,Csrdate,LoanTypeid,LoanCycleNo,MartialStatus,SpouseName,SpouseDob,NomineeName,NomineeAge,NomineeRelation,Status,Reason,Religion,Caste,Gender,ApplicantFather,FamilyDetails,FamilyRelation,Rationcardno,VoterIdcardno,Uidno,LoanPurpose,Idproof1,Idproof2,OriginatorId,OfficerChangeDate,CustomerSign,FamilyDetails2,FamilyRelation2,FamilyDetails3,FamilyRelation3,FamilyDetails4,FamilyRelation4,TebusinessActivity,VebusinessActivity,ApplicantName,ActivityConfirmation,CreditHistory,VerificationOfDocs,DvecustomerApproval,DvecustomerApprovalDateTime,ExActiveCustId,ExActiveLoanAc,IsReLoan,IsExistingLoanClose,IsTopupLoan,CustomerGender,CustomerAadharAddress,CustomerCurrentAddress,CustomerDistrict,CustomerTaluka,CustomerVillage,CustomerLat,CustomerLong,CustomerLoanApplicationDate,CustomerDrivingLicNo,CustomerEducation,CustomerCategory,CustomerLoanType,NomineeAadharCard,NomineePanCard,NomineeMobileNo,GuarantorName,GuarantorAddress,GuarantorGender,GuarantorMobileNo,GuarantorDob,GuarantorPhoto,GuarantorCompanyName,GuarantorSalary")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerId))
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
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Customer == null)
            {
                return Problem("Entity set 'CapRetailContext.Customer'  is null.");
            }
            var customer = await _context.Customer.FindAsync(id);
            if (customer != null)
            {
                _context.Customer.Remove(customer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(long id)
        {
          return (_context.Customer?.Any(e => e.CustomerId == id)).GetValueOrDefault();
        }
    }
}
