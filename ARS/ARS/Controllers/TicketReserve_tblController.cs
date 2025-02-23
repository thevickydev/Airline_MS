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
    public class TicketReserve_tblController : Controller
    {
        private readonly ContextCS _context;

        public TicketReserve_tblController(ContextCS context)
        {
            _context = context;
        }

        // GET: TicketReserve_tbl
        public async Task<IActionResult> Index()
        {
            return View(await _context.TicketReserve_tbl.ToListAsync());
        }

        // GET: TicketReserve_tbl/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketReserve_tbl = await _context.TicketReserve_tbl
                .FirstOrDefaultAsync(m => m.ResId == id);
            if (ticketReserve_tbl == null)
            {
                return NotFound();
            }

            return View(ticketReserve_tbl);
        }

        // GET: TicketReserve_tbl/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TicketReserve_tbl/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResId,From,To,ResDate,ResFtime,PlaneId,PlaneSeat,ResTicketPrice,ResPlaneType")] TicketReserve_tbl ticketReserve_tbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticketReserve_tbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticketReserve_tbl);
        }

        // GET: TicketReserve_tbl/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketReserve_tbl = await _context.TicketReserve_tbl.FindAsync(id);
            if (ticketReserve_tbl == null)
            {
                return NotFound();
            }
            return View(ticketReserve_tbl);
        }

        // POST: TicketReserve_tbl/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResId,From,To,ResDate,ResFtime,PlaneId,PlaneSeat,ResTicketPrice,ResPlaneType")] TicketReserve_tbl ticketReserve_tbl)
        {
            if (id != ticketReserve_tbl.ResId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticketReserve_tbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketReserve_tblExists(ticketReserve_tbl.ResId))
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
            return View(ticketReserve_tbl);
        }

        // GET: TicketReserve_tbl/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketReserve_tbl = await _context.TicketReserve_tbl
                .FirstOrDefaultAsync(m => m.ResId == id);
            if (ticketReserve_tbl == null)
            {
                return NotFound();
            }

            return View(ticketReserve_tbl);
        }

        // POST: TicketReserve_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticketReserve_tbl = await _context.TicketReserve_tbl.FindAsync(id);
            if (ticketReserve_tbl != null)
            {
                _context.TicketReserve_tbl.Remove(ticketReserve_tbl);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketReserve_tblExists(int id)
        {
            return _context.TicketReserve_tbl.Any(e => e.ResId == id);
        }
    }
}
