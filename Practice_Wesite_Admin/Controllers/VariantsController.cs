using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practice_Wesite_Admin.Data;
using Practice_Wesite_Admin.Models;

namespace Practice_Wesite_Admin.Controllers
{
    public class VariantsController : Controller
    {
        private readonly ApplicationContext _context;

        public VariantsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Variants
        public async Task<IActionResult> Index()
        {
            return View(await _context.variants.ToListAsync());
        }

        // GET: Variants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var variants = await _context.variants
                .FirstOrDefaultAsync(m => m.VariantID == id);
            if (variants == null)
            {
                return NotFound();
            }

            return View(variants);
        }

        // GET: Variants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Variants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VariantID,VariantName,status")] Variants variants)
        {
            if (ModelState.IsValid)
            {
                _context.Add(variants);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(variants);
        }

        // GET: Variants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var variants = await _context.variants.FindAsync(id);
            if (variants == null)
            {
                return NotFound();
            }
            return View(variants);
        }

        // POST: Variants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VariantID,VariantName,status")] Variants variants)
        {
            if (id != variants.VariantID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(variants);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VariantsExists(variants.VariantID))
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
            return View(variants);
        }

        // GET: Variants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var variants = await _context.variants
                .FirstOrDefaultAsync(m => m.VariantID == id);
            if (variants == null)
            {
                return NotFound();
            }

            return View(variants);
        }

        // POST: Variants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var variants = await _context.variants.FindAsync(id);
            _context.variants.Remove(variants);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VariantsExists(int id)
        {
            return _context.variants.Any(e => e.VariantID == id);
        }
    }
}
