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
    public class CVModelsController : Controller
    {
        private readonly DBContext _context;

        public CVModelsController(DBContext context)
        {
            _context = context;
        }

        // GET: Admin/CVModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.CVModels.ToListAsync());
        }

        // GET: Admin/CVModels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cVModel = await _context.CVModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cVModel == null)
            {
                return NotFound();
            }

            return View(cVModel);
        }

        // GET: Admin/CVModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/CVModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Remark,AboutMeEn,AboutMeEs")] CVModel cVModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cVModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cVModel);
        }

        // GET: Admin/CVModels/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cVModel = await _context.CVModels.FindAsync(id);
            if (cVModel == null)
            {
                return NotFound();
            }
            return View(cVModel);
        }

        // POST: Admin/CVModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Remark,AboutMeEn,AboutMeEs")] CVModel cVModel)
        {
            if (id != cVModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cVModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CVModelExists(cVModel.Id))
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
            return View(cVModel);
        }

        // GET: Admin/CVModels/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cVModel = await _context.CVModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cVModel == null)
            {
                return NotFound();
            }

            return View(cVModel);
        }

        // POST: Admin/CVModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cVModel = await _context.CVModels.FindAsync(id);
            _context.CVModels.Remove(cVModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CVModelExists(string id)
        {
            return _context.CVModels.Any(e => e.Id == id);
        }
    }
}
