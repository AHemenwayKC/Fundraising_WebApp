using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CS451R_Fundraiser.Data;
using CS451R_Fundraiser.Models;
using Microsoft.AspNetCore.Identity;

namespace CS451R_Fundraiser.Controllers
{
    public class FundraisersController : Controller
    {
        private readonly CS451R_FundraiserContext _context;
        private readonly SignInManager<User> _signInManager;

        public FundraisersController(CS451R_FundraiserContext context, SignInManager<User> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("Launch")]
        public IActionResult Launch()
        {
            return View("Launch");
        }
        
        
        // GET: Fundraisers
        public async Task<IActionResult> Index(string fundraiserCategory, string searchString)
        {
            if (_context.Fundraiser == null)
            {
                return Problem("Entity set 'CS451R_Fundraisers.Fundraisers'  is null.");
            }

            // Use LINQ to get list of genres.
            IQueryable<string> categoryQuery = from m in _context.Fundraiser
                                            orderby m.Category
                                            select m.Category;
            var fundraisers = from m in _context.Fundraiser
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                fundraisers = fundraisers.Where(s => s.Title!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(fundraiserCategory))
            {
                fundraisers = fundraisers.Where(x => x.Category == fundraiserCategory);
            }

            var fundraiserCategoryVM = new FundraiserCategoryViewModel
            {
                Categories = new SelectList(await categoryQuery.Distinct().ToListAsync()),
                Fundraisers = await fundraisers.ToListAsync()
            };

            return View(fundraiserCategoryVM);
        }

        // GET: Fundraisers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fundraiser == null)
            {
                return NotFound();
            }

            var fundraiser = await _context.Fundraiser
                .FirstOrDefaultAsync(m => m.Id == id);
            var donations = _context.Donation
                                .Where(b => b.fundraiserId.Equals(fundraiser.Id));


            if (fundraiser == null)
            {
                return NotFound();
            }

            var fundraiserDonationvm = new FundraiserDonationViewModel
            {
                Fundraiser = fundraiser,
                Donations = await donations.ToListAsync()
                
            };

            return View(fundraiserDonationvm);
        }

        // GET: Fundraisers/Create
        public IActionResult Create()
        {
            if (User.Identity.IsAuthenticated) 
            {
                return View();
            }
            else
            {
                return View("~/Views/Shared/_LoginPartial.cshtml");
            }
            
        }

        // POST: Fundraisers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,PostDate,Category,Goal")] Fundraiser fundraiser)
        {
            if (ModelState.IsValid)
            //if (true)
            {
                _context.Add(fundraiser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fundraiser);
        }

        // GET: Fundraisers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fundraiser == null)
            {
                return NotFound();
            }

            var fundraiser = await _context.Fundraiser.FindAsync(id);
            if (fundraiser == null)
            {
                return NotFound();
            }
            return View(fundraiser);
        }

        // POST: Fundraisers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,PostDate,Category,Goal")] Fundraiser fundraiser)
        {
            if (id != fundraiser.Id)
            {
                return NotFound();
            }

            //foreach (var modelStateKey in ViewData.ModelState.Keys)
            //{
            //    var modelStateVal = ViewData.ModelState[modelStateKey];
            //    foreach (var error in modelStateVal.Errors)
            //    {
            //        var key = modelStateKey;
            //        var errorMessage = error.ErrorMessage;
            //        var exception = error.Exception;
            //        System.Diagnostics.Debug.WriteLine(key);
            //        System.Diagnostics.Debug.WriteLine(errorMessage);
            //        System.Diagnostics.Debug.WriteLine(exception);
            //    }
            //}

            if (ModelState.IsValid)
            //if (true)
            {
                try
                {
                    _context.Update(fundraiser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FundraiserExists(fundraiser.Id))
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
            return View(fundraiser);
        }

        // GET: Fundraisers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fundraiser == null)
            {
                return NotFound();
            }

            var fundraiser = await _context.Fundraiser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fundraiser == null)
            {
                return NotFound();
            }

            return View(fundraiser);
        }

        // POST: Fundraisers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fundraiser == null)
            {
                return Problem("Entity set 'CS451R_FundraiserContext.Fundraiser'  is null.");
            }
            var fundraiser = await _context.Fundraiser.FindAsync(id);
            if (fundraiser != null)
            {
                _context.Fundraiser.Remove(fundraiser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FundraiserExists(int id)
        {
          return (_context.Fundraiser?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
