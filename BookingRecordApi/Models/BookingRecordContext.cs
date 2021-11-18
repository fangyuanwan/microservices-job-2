using System;
using Microsoft.EntityFrameworkCore;
namespace BookingRecordApi.Models
{
    public class BookingRecordContext:DbContext

    {
        public BookingRecordContext(DbContextOptions<BookingRecordContext> options)
            : base(options)
        {
        }
        public DbSet<BookingRecordItem> BookingRecordItems { get; set; }
    }
}
