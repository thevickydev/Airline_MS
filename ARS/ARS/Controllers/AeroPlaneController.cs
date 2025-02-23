using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ARS.Models;

namespace ARS.Controllers
{
    public class AeroPlaneController : Controller
    {
        private readonly ContextCS _context;

        public AeroPlaneController(ContextCS context)
        {
            _context = context;
        }

        // GET: AeroPlane
        public async Task<IActionResult> Index()
        {
            return View(await _context.AeroPlaneInfo.ToListAsync());
        }

        // GET: AeroPlane/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aeroPlaneInfo = await _context.AeroPlaneInfo
                .FirstOrDefaultAsync(m => m.PlaneId == id);
            if (aeroPlaneInfo == null)
            {
                return NotFound();
            }

            return View(aeroPlaneInfo);
        }

        // GET: AeroPlane/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AeroPlane/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlaneId,APlaneName,SeatingCapacity,Price")] AeroPlaneInfo aeroPlaneInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aeroPlaneInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aeroPlaneInfo);
        }

        // GET: AeroPlane/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aeroPlaneInfo = await _context.AeroPlaneInfo.FindAsync(id);
            if (aeroPlaneInfo == null)
            {
                return NotFound();
            }
            return View(aeroPlaneInfo);
        }

        // POST: AeroPlane/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlaneId,APlaneName,SeatingCapacity,Price")] AeroPlaneInfo aeroPlaneInfo)
        {
            if (id != aeroPlaneInfo.PlaneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aeroPlaneInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AeroPlaneInfoExists(aeroPlaneInfo.PlaneId))
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
            return View(aeroPlaneInfo);
        }

        // GET: AeroPlane/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aeroPlaneInfo = await _context.AeroPlaneInfo
                .FirstOrDefaultAsync(m => m.PlaneId == id);
            if (aeroPlaneInfo == null)
            {
                return NotFound();
            }

            return View(aeroPlaneInfo);
        }

        // POST: AeroPlane/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aeroPlaneInfo = await _context.AeroPlaneInfo.FindAsync(id);
            if (aeroPlaneInfo != null)
            {
                _context.AeroPlaneInfo.Remove(aeroPlaneInfo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AeroPlaneInfoExists(int id)
        {
            return _context.AeroPlaneInfo.Any(e => e.PlaneId == id);
        }
    }
}
