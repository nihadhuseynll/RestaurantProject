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
	public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
	{
		public EfNotificationDal(SignalRContext context) : base(context)
		{
		}

		public List<Notification> GetAllNotificationsByFalse()
		{
			using var _context=new SignalRContext();
			return _context.Notifications.Where(n=>n.Status==false).ToList();	
		}

		public int NotificationCountByStatusFalse()
		{
			using var _context = new SignalRContext();
			return _context.Notifications.Where(n=>n.Status==false).Count();	
		}

		public void NotificationStatusChangeToFalse(int id)
		{
			using var _context = new SignalRContext();
			var value = _context.Notifications.Find(id);
			value.Status = false;
			_context.SaveChanges();
		}

		public void NotificationStatusChangeToTrue(int id)
		{
			using var _context= new SignalRContext();
			var value = _context.Notifications.Find(id);
			value.Status = true;
			_context.SaveChanges();
		}
	}
}
