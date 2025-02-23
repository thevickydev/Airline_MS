    using System.Security.Claims;
    using System.Security.Cryptography;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ARS.Models;
using System.Diagnostics;

    namespace ARS.Controllers
    {
        public class UserController : Controller
        {
            private readonly ContextCS _context;

            public UserController(ContextCS context)
            {
                _context = context;
            }

            // GET: Signup
            public IActionResult Signup()
            {
                return View();
            }

            // POST: Signup
            [HttpPost]
            public async Task<IActionResult> Signup(UserAccount model)
            {
                if (ModelState.IsValid)
                {
                    // Check if email already exists
                    if (await _context.UserLogins.AnyAsync(u => u.Email == model.Email))
                    {
                        ModelState.AddModelError("Email", "Email is already registered.");
                        return View(model);
                    }

                    // Hash password
                    model.Password = model.Password;
                    model.CPassword = model.Password;

                    _context.UserLogins.Add(model);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Login");
                }
                return View(model);
            }

            // GET: Login
            public IActionResult Login()
            {
                return View();
            }

            // POST: Login
            [HttpPost]
            public async Task<IActionResult> Login(string Email, string Password)
            {
                var user = await _context.UserLogins.FirstOrDefaultAsync(u => u.Email == Email);

                if (user == null ||  user.Password != Password)
                {
                    ViewBag.Error = "Invalid Email or Password";
                    return View();
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim("FullName", user.FirstName + " " + user.LastName),
                    new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties { IsPersistent = true };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                              new ClaimsPrincipal(claimsIdentity), authProperties);

                return RedirectToAction("SearchFlights");
            }

            // Logout
            public async Task<IActionResult> Logout()
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Login");
            }

        [Authorize]
        public async Task<IActionResult> SearchFlights()
        {
            //var flights = await _context.TicketReserve_tbl
            //    .Include(f => f.plane_tbls) // Ensure this relationship is correctly configured
            //    .ToListAsync();
            var flights = "";
            if (flights == null)
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

            return View(flights);
        }




        // GET: Book Flight (only for authenticated users)
        [Authorize]
            public IActionResult BookFlight(int flightId)
            {
                var flight = _context.TicketReserve_tbl.FirstOrDefault(f => f.ResId == flightId);
                if (flight == null)
                {
                    return NotFound();
                }
                return View(flight);
            }

            // POST: Book Flight
            [Authorize]
            [HttpPost]
            public async Task<IActionResult> BookFlight(int flightId, int seatCount)
            {
                var flight = await _context.TicketReserve_tbl.FirstOrDefaultAsync(f => f.ResId == flightId);
                if (flight == null || flight.PlaneSeat < seatCount)
                {
                    ModelState.AddModelError("", "Not enough seats available.");
                    return View(flight);
                }

                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                var user = await _context.UserLogins.FindAsync(userId);

                var booking = new FlightBooking
                {
                    CusName = user.FirstName + " " + user.LastName,
                    CusEmail = user.Email,
                    CusPhone = user.PhoneNo,
                    CusCnic = user.CNo,
                    CusSeat = seatCount.ToString(),
                    DTime = flight.ResFtime,
                    Price = (int)(seatCount * flight.ResTicketPrice),
                    Planeid = flight.PlaneId,
                    ResId = flight.ResId,
                    CusAddress = "Default Address" // Ensure a valid address
                };

                _context.FlightBooking.Add(booking);
                flight.PlaneSeat -= seatCount;

                await _context.SaveChangesAsync();

                // Redirect to User Details View after booking
                return RedirectToAction("UserDetails", new { bookingId = booking.bid });
            }

            [Authorize]
            public async Task<IActionResult> UserDetails(int bookingId)
            {
                var booking = await _context.FlightBooking
                    .Include(b => b.TicketReserve_tbls) // Ensure Flight details are included
                    .FirstOrDefaultAsync(b => b.bid == bookingId);

                if (booking == null)
                {
                    return NotFound();
                }

                return View(booking);
            }


            private bool VerifyPassword(string enteredPassword, string storedPassword)
            {
                return enteredPassword == storedPassword;
            }
        }
    }
