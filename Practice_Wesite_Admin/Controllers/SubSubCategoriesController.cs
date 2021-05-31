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
    public class SubSubCategoriesController : Controller
    {
        private readonly ApplicationContext _context;

        public SubSubCategoriesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: SubSubCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.subSubCategories.ToListAsync());
        }

        // GET: SubSubCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subSubCategory = await _context.subSubCategories
                .FirstOrDefaultAsync(m => m.SubSubCategoryID == id);
            if (subSubCategory == null)
            {
                return NotFound();
            }

            return View(subSubCategory);
        }

        // GET: SubSubCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SubSubCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubSubCategoryID,SubsUBCategoryName,Status")] SubSubCategory subSubCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subSubCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subSubCategory);
        }

        // GET: SubSubCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subSubCategory = await _context.subSubCategories.FindAsync(id);
            if (subSubCategory == null)
            {
                return NotFound();
            }
            return View(subSubCategory);
        }

        // POST: SubSubCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubSubCategoryID,SubsUBCategoryName,Status")] SubSubCategory subSubCategory)
        {
            if (id != subSubCategory.SubSubCategoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subSubCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubSubCategoryExists(subSubCategory.SubSubCategoryID))
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
            return View(subSubCategory);
        }

        // GET: SubSubCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subSubCategory = await _context.subSubCategories
                .FirstOrDefaultAsync(m => m.SubSubCategoryID == id);
            if (subSubCategory == null)
            {
                return NotFound();
            }

            return View(subSubCategory);
        }

        // POST: SubSubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subSubCategory = await _context.subSubCategories.FindAsync(id);
            _context.subSubCategories.Remove(subSubCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubSubCategoryExists(int id)
        {
            return _context.subSubCategories.Any(e => e.SubSubCategoryID == id);
        }
    }
}
