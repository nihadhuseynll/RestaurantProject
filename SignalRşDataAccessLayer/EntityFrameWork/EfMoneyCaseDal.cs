﻿using SignalR.DataAccessLayer.Abstract;
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
	public class EfMoneyCaseDal : GenericRepository<MoneyCase>, IMoneyCaseDal
	{
		public EfMoneyCaseDal(SignalRContext context) : base(context)
		{
		}

		public decimal TotalMoneyCaseAmount()
		{
			using var _context= new SignalRContext();
			return _context.MoneyCases.Select(m=>m.TotalAmount).FirstOrDefault();
		}
	}
}
