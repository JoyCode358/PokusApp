using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Data;
using System.Runtime.ExceptionServices;
using Microsoft.Extensions.Configuration;

namespace TodoApi.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class HotelBookingController : ControllerBase
    {
        private ApiContext _context;
        private readonly IConfiguration _configuration;

        public HotelBookingController(ApiContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        //Post
        //Create
        [HttpPost("/api/[controller]/booking")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<HotelBooking> Post(HotelBooking booking)
        {
            if (booking.Id == 0)
            {
                _context.Bookings.Add(booking);
                _context.SaveChanges();
            }
            else
            {
                var bookingInDb = _context.Bookings.Find(booking.Id);
                if (bookingInDb == null)
                {
                    return NotFound();
                }
                booking = bookingInDb;
            }

            try
            {
                return Ok(booking);
            }
            catch (Exception)
            {
                return Problem(_configuration["ErrorMessages:ErrorPost"]);
            }
        }

        //Get
        [HttpGet("/api/[controller]/booking/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<HotelBooking> Get(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var result = _context.Bookings.Find(id);

            if (result == null)
            {
                return NotFound();
            }

            try
            {
                return Ok(result);
            }
            catch (Exception)
            {
                return Problem(_configuration["ErrorMessages:ErrorGet"]);
            }
        }

        //Get All
        [HttpGet("/api/[controller]/booking")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<HotelBooking>> GetAll()
        {
            var result = _context.Bookings.ToList();
            if (result == null)
            {
                return NotFound();
            }

            try
            {
                return Ok(result);
            }
            catch (Exception)
            {
                return Problem(_configuration["ErrorMessages:ErrorGetAll"]);
            }
            
        }

        //Delete
        [HttpDelete("/api/[controller]/booking/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var result = _context.Bookings.Find(id);

            if (result == null)
            {
                return NotFound();
            }

            try
            {
                _context.Bookings.Remove(result);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return Problem(_configuration["ErrorMessages:ErrorDelete"]);
            }
        }

        //Put
        [HttpPut("/api/[controller]/booking/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<HotelBooking> Update(int id, HotelBooking hotelBooking)
        {
            if (hotelBooking == null || id != hotelBooking.Id)
            {
                return BadRequest();
            }

            var result = _context.Bookings.FirstOrDefault(u => u.Id == id);

            if (result == null)
            {
                return NotFound();
            }

            result.RoomNumber = hotelBooking.RoomNumber;
            result.ClientsName = hotelBooking.ClientsName;
            result.Description = hotelBooking.Description;
            result.Adress = hotelBooking.Adress;

            try
            {
                _context.Bookings.Update(result);
                _context.SaveChanges();
                return Ok(result);
            }
            catch (Exception)
            {
                //return StatusCode(StatusCodes.Status500InternalServerError);
                return Problem(_configuration["ErrorMessages:ErrorPut"]);
            }
        }
    }
}
