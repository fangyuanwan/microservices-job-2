using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingRecordApi.Models;

namespace BookingRecordApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingRecordItemsController : ControllerBase
    {
        private readonly BookingRecordContext _context;

        public BookingRecordItemsController(BookingRecordContext context)
        {
            _context = context;
        }

        // GET: api/BookingRecordItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingRecordItem>>> Getbookingitems()
        {
            return await _context.bookingitems.ToListAsync();
        }

        // GET: api/BookingRecordItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingRecordItem>> GetBookingRecordItem(long id)
        {
            var bookingRecordItem = await _context.bookingitems.FindAsync(id);

            if (bookingRecordItem == null)
            {
                return NotFound();
            }

            return bookingRecordItem;
        }

        // PUT: api/BookingRecordItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingRecordItem(long id, BookingRecordItem bookingRecordItem)
        {
            if (id != bookingRecordItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookingRecordItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingRecordItemExists(id))
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

        // POST: api/BookingRecordItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookingRecordItem>> PostBookingRecordItem(BookingRecordItem bookingRecordItem)
        {
            _context.bookingitems.Add(bookingRecordItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookingRecordItem", new { id = bookingRecordItem.Id }, bookingRecordItem);
        }

        // DELETE: api/BookingRecordItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingRecordItem(long id)
        {
            var bookingRecordItem = await _context.bookingitems.FindAsync(id);
            if (bookingRecordItem == null)
            {
                return NotFound();
            }

            _context.bookingitems.Remove(bookingRecordItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingRecordItemExists(long id)
        {
            return _context.bookingitems.Any(e => e.Id == id);
        }
    }
}
