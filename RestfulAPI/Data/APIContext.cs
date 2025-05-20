using Microsoft.EntityFrameworkCore;
    using RestfulAPI.Models;
namespace RestfulAPI.Data
{
    public class APIContext : DbContext
    {
        public DbSet<HotelBooking> Bookings { get; set; }
        public APIContext(DbContextOptions<APIContext> options) 
        :base(options) { }
        
    }
}
