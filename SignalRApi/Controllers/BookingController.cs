using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values=_bookingService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            createBookingDto.Description = "Rezervasyon Alındı";

			Booking booking = new Booking()
            {
                Name = createBookingDto.Name,
                Mail = createBookingDto.Mail,
                Description = createBookingDto.Description,
                PersonCount = createBookingDto.PersonCount,
                Phone = createBookingDto.Phone,
                Date = createBookingDto.Date
            };
            _bookingService.TAdd(booking);
            return Ok("Rezervasyon başarıyla yapıldı.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value=_bookingService.TGetById(id);
            _bookingService.TDelete(value);
            return Ok("Rezervasyon başarıyla silindi.");
        }
        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking()
            {
                BookingId = updateBookingDto.BookingId,
                Name = updateBookingDto.Name,
                Description = updateBookingDto.Description, 
                Mail = updateBookingDto.Mail,
                PersonCount = updateBookingDto.PersonCount,
                Phone = updateBookingDto.Phone,
                Date = updateBookingDto.Date
            };
            _bookingService.TUpdate(booking);
            return Ok("Rezervasyon başarıyla güncellendi.");
        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            return Ok(value);
        }
        [HttpGet("BookingStatusApproved/{id}")]
        public IActionResult BookingStatusApproved(int id)
        {
            _bookingService.TBookingStatusApproved(id);
            return Ok("Rezervasyon Onaylandı");
        }
		[HttpGet("BookingStatusCancelled/{id}")]
		public IActionResult BookingStatusCancelled(int id)
		{
			_bookingService.TBookingStatusCancelled(id);
			return Ok("Rezervasyon İptal Edildi");
		}
	}
}
