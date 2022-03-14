using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Booking.Models;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly BookingContext _context;
        //private readonly IHttpClientFactory _clientFactory;

        public BookingController(BookingContext context)
        {
            _context = context;
            //_clientFactory = clientFactory;
        }

        // GET: api/Booking
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingItem>>> GetBookingItems()
        {
            return await _context.BookingItems.ToListAsync();
        }

        // GET: api/Booking/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingItem>> GetBookingItem(int id)
        {
            var bookingItem = await _context.BookingItems.FindAsync(id);

            if (bookingItem == null)
            {
                return NotFound();
            }

            return bookingItem;
        }

        // PUT: api/Booking/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingItem(int id, BookingItem bookingItem)
        {
            if (id != bookingItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookingItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Booking
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookingItem>> PostBookingItem(BookingItem bookingItem)
        {
            _context.BookingItems.Add(bookingItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBookingItem), new { id = bookingItem.Id }, bookingItem);
        }

        // DELETE: api/Booking/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingItem(int id)
        {
            var bookingItem = await _context.BookingItems.FindAsync(id);
            if (bookingItem == null)
            {
                return NotFound();
            }

            _context.BookingItems.Remove(bookingItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        
        private bool BookingItemExists(int id)
         {
            return _context.BookingItems.Any(e => e.Id == id);
         }
    }
}
