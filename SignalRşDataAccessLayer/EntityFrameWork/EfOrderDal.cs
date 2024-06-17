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
	public class EfOrderDal : GenericRepository<Order>, IOrderDal
	{
		public EfOrderDal(SignalRContext context) : base(context)
		{
		}

		public int ActiveOrderCount()
		{
			using var _context = new SignalRContext();
			return _context.Orders.Count(o => o.Description == "Burda");
		}

		public decimal LastOrderPrice()
		{
			using var _context= new SignalRContext();
			return _context.Orders.OrderByDescending(o=>o.OrderId).Take(1).Select(o=>o.TotalPrice).FirstOrDefault();	
		}

		public int PassiveOrderCount()
		{
			using var _context = new SignalRContext();
			return _context.Orders.Count(o => o.Description == "Ayrildi");
		}

		public decimal TodayOrderEarning()
		{
			using var _context = new SignalRContext();
			return _context.Orders.Where(o => o.Description == "Ayrildi" && o.Date.Date == DateTime.Now.Date)
				                  .Sum(a => a.TotalPrice);
		}

		public int TotalOrderCount()
		{
			using var _context = new SignalRContext();
			return _context.Orders.Count();
		}
	}
}
