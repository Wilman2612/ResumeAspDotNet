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
    public class CVModel_JobRespController : Controller
    {
        private readonly DBContext _context;

        public CVModel_JobRespController(DBContext context)
        {
            _context = context;
        }

        // GET: Admin/CVModel_JobResp
        public async Task<IActionResult> Index()
        {
            var cVContext = _context.CVModel_JobResp.Include(c => c.CVModel).Include(c => c.JobResponsibility);
            return View(await cVContext.ToListAsync());
        }

        // GET: Admin/CVModel_JobResp/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cVModel_JobResp = await _context.CVModel_JobResp
                .Include(c => c.CVModel)
                .Include(c => c.JobResponsibility)
                .FirstOrDefaultAsync(m => m.CVModelId == id);
            if (cVModel_JobResp == null)
            {
                return NotFound();
            }

            return View(cVModel_JobResp);
        }

        // GET: Admin/CVModel_JobResp/Create
        public IActionResult Create()
        {
            ViewData["CVModelId"] = new SelectList(_context.CVModels, "Id", "Id");
            ViewData["JobResponsibilityId"] = new SelectList(_context.JobResponsibility, "Id", "DescriptionEn");
            return View();
        }

        // POST: Admin/CVModel_JobResp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CVModelId,JobResponsibilityId")] CVModel_JobResp cVModel_JobResp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cVModel_JobResp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CVModelId"] = new SelectList(_context.CVModels, "Id", "Id", cVModel_JobResp.CVModelId);
            ViewData["JobResponsibilityId"] = new SelectList(_context.JobResponsibility, "Id", "DescriptionEn", cVModel_JobResp.JobResponsibilityId);
            return View(cVModel_JobResp);
        }

        // GET: Admin/CVModel_JobResp/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cVModel_JobResp = await _context.CVModel_JobResp.FindAsync(id);
            if (cVModel_JobResp == null)
            {
                return NotFound();
            }
            ViewData["CVModelId"] = new SelectList(_context.CVModels, "Id", "Id", cVModel_JobResp.CVModelId);
            ViewData["JobResponsibilityId"] = new SelectList(_context.JobResponsibility, "Id", "DescriptionEn", cVModel_JobResp.JobResponsibilityId);
            return View(cVModel_JobResp);
        }

        // POST: Admin/CVModel_JobResp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CVModelId,JobResponsibilityId")] CVModel_JobResp cVModel_JobResp)
        {
            if (id != cVModel_JobResp.CVModelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cVModel_JobResp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CVModel_JobRespExists(cVModel_JobResp.CVModelId))
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
            ViewData["CVModelId"] = new SelectList(_context.CVModels, "Id", "Id", cVModel_JobResp.CVModelId);
            ViewData["JobResponsibilityId"] = new SelectList(_context.JobResponsibility, "Id", "DescriptionEn", cVModel_JobResp.JobResponsibilityId);
            return View(cVModel_JobResp);
        }

        // GET: Admin/CVModel_JobResp/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cVModel_JobResp = await _context.CVModel_JobResp
                .Include(c => c.CVModel)
                .Include(c => c.JobResponsibility)
                .FirstOrDefaultAsync(m => m.CVModelId == id);
            if (cVModel_JobResp == null)
            {
                return NotFound();
            }

            return View(cVModel_JobResp);
        }

        // POST: Admin/CVModel_JobResp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cVModel_JobResp = await _context.CVModel_JobResp.FindAsync(id);
            _context.CVModel_JobResp.Remove(cVModel_JobResp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CVModel_JobRespExists(string id)
        {
            return _context.CVModel_JobResp.Any(e => e.CVModelId == id);
        }
    }
}
