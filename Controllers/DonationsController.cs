using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APPR.Data;
using APPR.Models;

namespace APPR.Controllers
{
    public class DonationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Donations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Donations.Include(d => d.Donor).Include(d => d.Resource);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Donations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donation = await _context.Donations
                .Include(d => d.Donor)
                .Include(d => d.Resource)
                .FirstOrDefaultAsync(m => m.DonationId == id);
            if (donation == null)
            {
                return NotFound();
            }

            return View(donation);
        }

        // GET: Donations/Create
        public IActionResult Create()
        {
            ViewData["DonorId"] = new SelectList(_context.Set<Donor>(), "DonorId", "DonorId");
            ViewData["ResourceId"] = new SelectList(_context.Resources, "ResourceId", "ResourceId");
            return View();
        }

        // POST: Donations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DonationId,DonorId,DonationType,ResourceId,Quantity,Amount,DonationDate,Status")] Donation donation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DonorId"] = new SelectList(_context.Set<Donor>(), "DonorId", "DonorId", donation.DonorId);
            ViewData["ResourceId"] = new SelectList(_context.Resources, "ResourceId", "ResourceId", donation.ResourceId);
            return View(donation);
        }

        // GET: Donations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donation = await _context.Donations.FindAsync(id);
            if (donation == null)
            {
                return NotFound();
            }
            ViewData["DonorId"] = new SelectList(_context.Set<Donor>(), "DonorId", "DonorId", donation.DonorId);
            ViewData["ResourceId"] = new SelectList(_context.Resources, "ResourceId", "ResourceId", donation.ResourceId);
            return View(donation);
        }

        // POST: Donations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DonationId,DonorId,DonationType,ResourceId,Quantity,Amount,DonationDate,Status")] Donation donation)
        {
            if (id != donation.DonationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonationExists(donation.DonationId))
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
            ViewData["DonorId"] = new SelectList(_context.Set<Donor>(), "DonorId", "DonorId", donation.DonorId);
            ViewData["ResourceId"] = new SelectList(_context.Resources, "ResourceId", "ResourceId", donation.ResourceId);
            return View(donation);
        }

        // GET: Donations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donation = await _context.Donations
                .Include(d => d.Donor)
                .Include(d => d.Resource)
                .FirstOrDefaultAsync(m => m.DonationId == id);
            if (donation == null)
            {
                return NotFound();
            }

            return View(donation);
        }

        // POST: Donations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donation = await _context.Donations.FindAsync(id);
            if (donation != null)
            {
                _context.Donations.Remove(donation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonationExists(int id)
        {
            return _context.Donations.Any(e => e.DonationId == id);
        }
    }
}
