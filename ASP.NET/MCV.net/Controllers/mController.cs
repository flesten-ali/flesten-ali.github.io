using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MCV.net.Data;
using MCV.net.Models;

namespace MCV.net.Controllers
{
    public class mController : Controller
    {
        private readonly ApplicationDbContext _context;

        public mController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: m
        public async Task<IActionResult> Index()
        {
              return View(await _context.ModleTable.ToListAsync());
        }

        // GET: m/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ModleTable == null)
            {
                return NotFound();
            }

            var model1 = await _context.ModleTable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (model1 == null)
            {
                return NotFound();
            }

            return View(model1);
        }

        // GET: m/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: m/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DisplayOrder,CreatDateTime")] Model1 model1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model1);
        }

        // GET: m/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ModleTable == null)
            {
                return NotFound();
            }

            var model1 = await _context.ModleTable.FindAsync(id);
            if (model1 == null)
            {
                return NotFound();
            }
            return View(model1);
        }

        // POST: m/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DisplayOrder,CreatDateTime")] Model1 model1)
        {
            if (id != model1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Model1Exists(model1.Id))
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
            return View(model1);
        }

        // GET: m/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ModleTable == null)
            {
                return NotFound();
            }

            var model1 = await _context.ModleTable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (model1 == null)
            {
                return NotFound();
            }

            return View(model1);
        }

        // POST: m/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ModleTable == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ModleTable'  is null.");
            }
            var model1 = await _context.ModleTable.FindAsync(id);
            if (model1 != null)
            {
                _context.ModleTable.Remove(model1);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Model1Exists(int id)
        {
          return _context.ModleTable.Any(e => e.Id == id);
        }
    }
}
