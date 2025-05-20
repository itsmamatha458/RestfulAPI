using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfulAPI.Models;
using RestfulAPI.Data;

namespace RestfulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelBookingController : ControllerBase
    {
        private readonly APIContext _context;
        public HotelBookingController(APIContext context)
        {
            _context = context;
        }
        //Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(HotelBooking Booking) 
        {
            if (Booking.Id == 0) 
            {
                _context.Bookings.Add(Booking);
            }else 
            {
                var bookingInDb = _context.Bookings.Find(Booking.Id);
                if (Booking.Id == 0)
                    return new JsonResult(NotFound());
                bookingInDb = Booking;
            }
            _context.SaveChanges();
            return new JsonResult(Ok(Booking));
        }
        //Get
        [HttpGet]
        public JsonResult Get(int id) 
        {
            var result = _context.Bookings.Find(id);
            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }
        //Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = (_context.Bookings.Find(id));
            if (result == null)
                return new JsonResult(NotFound());
            _context.Bookings.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent);
        }
    }
}
