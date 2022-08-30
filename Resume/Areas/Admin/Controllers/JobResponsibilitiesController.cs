using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CV.Data;
using Resume.Areas.Admin.Models;

namespace Resume.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class JobResponsibilitiesController : Controller
    {
        private readonly DBContext _context;

        public JobResponsibilitiesController(DBContext context)
        {
            _context = context;
        }

        // GET: Admin/JobResponsibilities
        public async Task<IActionResult> Index()
        {
            var cVContext = _context.JobResponsibility.Include(j => j.Job);
            return View(await cVContext.ToListAsync());
        }

        // GET: Admin/JobResponsibilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobResponsibility = await _context.JobResponsibility
                .Include(j => j.Job)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobResponsibility == null)
            {
                return NotFound();
            }

            return View(jobResponsibility);
        }

        // GET: Admin/JobResponsibilities/Create
        public IActionResult Create()
        {
            ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Id");
            return View();
        }

        // POST: Admin/JobResponsibilities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,JobId,DescriptionEn,DescriptionEs")] JobResponsibility jobResponsibility)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobResponsibility);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Id", jobResponsibility.JobId);
            return View(jobResponsibility);
        }

        // GET: Admin/JobResponsibilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobResponsibility = await _context.JobResponsibility.FindAsync(id);
            if (jobResponsibility == null)
            {
                return NotFound();
            }
            ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Id", jobResponsibility.JobId);
            return View(jobResponsibility);
        }

        // POST: Admin/JobResponsibilities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,JobId,DescriptionEn,DescriptionEs")] JobResponsibility jobResponsibility)
        {
            if (id != jobResponsibility.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobResponsibility);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobResponsibilityExists(jobResponsibility.Id))
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
            ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Id", jobResponsibility.JobId);
            return View(jobResponsibility);
        }

        // GET: Admin/JobResponsibilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobResponsibility = await _context.JobResponsibility
                .Include(j => j.Job)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobResponsibility == null)
            {
                return NotFound();
            }

            return View(jobResponsibility);
        }

        // POST: Admin/JobResponsibilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobResponsibility = await _context.JobResponsibility.FindAsync(id);
            _context.JobResponsibility.Remove(jobResponsibility);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobResponsibilityExists(int id)
        {
            return _context.JobResponsibility.Any(e => e.Id == id);
        }
    }
}
