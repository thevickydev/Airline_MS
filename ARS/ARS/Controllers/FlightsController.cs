using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ARS.Models;
using Microsoft.AspNetCore.Authorization;

namespace ARS.Controllers
{
    public class FlightsController : Controller
    {
        private readonly ContextCS _context;

        public FlightsController(ContextCS context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var flights = _context.Flights.Include(f => f.UserAccount);
            return View(await flights.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var flight = await _context.Flights.Include(f => f.UserAccount)
                                               .FirstOrDefaultAsync(m => m.BookingId == id);
            return flight == null ? NotFound() : View(flight);
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchResults(string from, string to)
        {
            var flights = await _context.Flights
                .Where(f => f.From.ToLower() == from.ToLower() && f.To.ToLower() == to.ToLower())
                .ToListAsync();

            return View(flights);
        }

        [Authorize]
        public async Task<IActionResult> Book(int id)
        {
            var flight = await _context.Flights.FindAsync(id);
            if (flight == null || flight.PlaneSeat == "0")
            {
                return NotFound();
            }

            flight.PlaneSeat = (int.Parse(flight.PlaneSeat) - 1).ToString();
            await _context.SaveChangesAsync();

            return View(new FlightBooking { bid = id, CusSeat = flight.SeatType });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Book([Bind("bid,CusName,CusEmail,CusPhone,CusCnic,CusSeat,Price")] FlightBooking booking)
        {
            if (!ModelState.IsValid) return View(booking);

            var user = await _context.UserLogins.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
            if (user == null) return RedirectToAction("Login", "UserAccounts");

            booking.bid = user.UserID;
            _context.FlightBooking.Add(booking);

            var flight = await _context.Flights.FindAsync(booking.bid);
            if (flight != null && int.Parse(flight.PlaneSeat) > 0)
            {
                flight.PlaneSeat = (int.Parse(flight.PlaneSeat) - 1).ToString();
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("BookingHistory", "UserAccounts", new { id = user.UserID });
        }

        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.UserLogins, "UserID", "Email");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,CusName,CusEmail,CusPhone,CusCnic,From,To,DepartureTime,PlaneId,PlaneSeat,TicketPrice,SeatType,UserID")] Flight flight)
        {
            if (!ModelState.IsValid) return View(flight);

            _context.Add(flight);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var flight = await _context.Flights.FindAsync(id);
            if (flight == null) return NotFound();

            ViewData["UserID"] = new SelectList(_context.UserLogins, "UserID", "Email", flight.UserID);
            return View(flight);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingId,CusName,CusEmail,CusPhone,CusCnic,From,To,DepartureTime,PlaneId,PlaneSeat,TicketPrice,SeatType,UserID")] Flight flight)
        {
            if (id != flight.BookingId) return NotFound();

            if (!ModelState.IsValid) return View(flight);

            try
            {
                _context.Update(flight);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Flights.Any(e => e.BookingId == flight.BookingId)) return NotFound();
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var flight = await _context.Flights.Include(f => f.UserAccount)
                                               .FirstOrDefaultAsync(m => m.BookingId == id);
            return flight == null ? NotFound() : View(flight);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flight = await _context.Flights.FindAsync(id);
            if (flight != null)
            {
                _context.Flights.Remove(flight);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
