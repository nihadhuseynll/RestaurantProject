using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFrameWork
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(SignalRContext context) : base(context)
        {
        }

		public void BookingStatusApproved(int id)
		{
			using var _context=new SignalRContext();
			var value=_context.Bookings.Find(id);
			value.Description = "Rezervasyon Onaylandı.";
			_context.SaveChanges();
		}

		public void BookingStatusCancelled(int id)
		{
			using var _context = new SignalRContext();
			var value = _context.Bookings.Find(id);
			value.Description = "Rezervasyon Iptal Edildi.";
			_context.SaveChanges();
		}
	}
}
