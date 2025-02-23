using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ARS.Models;
using System.Net.Mail;
using System.Net;

namespace ARS.Controllers
{
    public class UserAccountsController : Controller
    {
        private readonly ContextCS _context;

        public UserAccountsController(ContextCS context)
        {
            _context = context;
        }

        // GET: UserAccounts
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserLogins.ToListAsync());
        }

        // GET: UserAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAccount = await _context.UserLogins
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (userAccount == null)
            {
                return NotFound();
            }

            return View(userAccount);
        }

        // GET: UserAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,FirstName,LastName,Email,Password,CPassword,Age,PhoneNo,CNo")] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userAccount);
        }

        // GET: UserAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAccount = await _context.UserLogins.FindAsync(id);
            if (userAccount == null)
            {
                return NotFound();
            }
            return View(userAccount);
        }

        // POST: UserAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserID,FirstName,LastName,Email,Password,CPassword,Age,PhoneNo,CNo")] UserAccount userAccount)
        {
            if (id != userAccount.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserAccountExists(userAccount.UserID))
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
            return View(userAccount);
        }

        // GET: UserAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAccount = await _context.UserLogins
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (userAccount == null)
            {
                return NotFound();
            }

            return View(userAccount);
        }

        public async Task<IActionResult> BookingHistory(int id)
        {
            var user = await _context.UserLogins
                .Include(u => u.FlightBookings)
                .FirstOrDefaultAsync(u => u.UserID == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user.FlightBookings);
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> SendEmail(string email, string message)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(message))
            {
                return BadRequest("Email and message are required.");
            }

            var senderEmail = "yourgmail@gmail.com";  // Replace with your Gmail
            var senderPassword = "your-app-password";  // Use an App Password (not your Gmail password)
            var recipientEmail = "yourgmail@gmail.com"; // Your email to receive messages

            try
            {
                using (var client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.Credentials = new NetworkCredential(senderEmail, senderPassword);
                    client.EnableSsl = true;

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(senderEmail),
                        Subject = "New Comment Received",
                        Body = $"From: {email}\n\nMessage:\n{message}",
                        IsBodyHtml = false
                    };

                    mailMessage.To.Add(recipientEmail);

                    await client.SendMailAsync(mailMessage);
                }

                return Ok("Message sent successfully!");
            }
            catch
            {
                return StatusCode(500, "Failed to send the message.");
            }
        }
    

        // POST: UserAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userAccount = await _context.UserLogins.FindAsync(id);
            if (userAccount != null)
            {
                _context.UserLogins.Remove(userAccount);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserAccountExists(int id)
        {
            return _context.UserLogins.Any(e => e.UserID == id);
        }
    }
}
