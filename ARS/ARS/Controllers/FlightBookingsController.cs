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
    public class FlightBookingsController : Controller
    {
        private readonly ContextCS _context;

        public FlightBookingsController(ContextCS context)
        {
            _context = context;
        }

        // GET: FlightBookings
        public async Task<IActionResult> Index()
        {
            return View(await _context.FlightBooking.ToListAsync());
        }

        // GET: FlightBookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flightBooking = await _context.FlightBooking
                .FirstOrDefaultAsync(m => m.bid == id);
            if (flightBooking == null)
            {
                return NotFound();
            }

            return View(flightBooking);
        }

        // GET: FlightBookings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FlightBookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("bid,CusName,CusAddress,CusEmail,CusSeat,CusPhone,CusCnic,ResId,bCusName,DTime,Planeid,SeatType")] FlightBooking flightBooking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flightBooking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flightBooking);
        }

        // GET: FlightBookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flightBooking = await _context.FlightBooking.FindAsync(id);
            if (flightBooking == null)
            {
                return NotFound();
            }
            return View(flightBooking);
        }

        // POST: FlightBookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("bid,CusName,CusAddress,CusEmail,CusSeat,CusPhone,CusCnic,ResId,bCusName,DTime,Planeid,SeatType")] FlightBooking flightBooking)
        {
            if (id != flightBooking.bid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flightBooking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightBookingExists(flightBooking.bid))
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
            return View(flightBooking);
        }

        // GET: FlightBookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flightBooking = await _context.FlightBooking
                .FirstOrDefaultAsync(m => m.bid == id);
            if (flightBooking == null)
            {
                return NotFound();
            }

            return View(flightBooking);
        }

        // POST: FlightBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flightBooking = await _context.FlightBooking.FindAsync(id);
            if (flightBooking != null)
            {
                _context.FlightBooking.Remove(flightBooking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightBookingExists(int id)
        {
            return _context.FlightBooking.Any(e => e.bid == id);
        }
    }
}
