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
	public class EfMenuTableDal : GenericRepository<MenuTable>, IMenuTableDal
	{
		public EfMenuTableDal(SignalRContext context) : base(context)
		{
		}

		public int MenuTableCount()
		{
			using var _context= new SignalRContext();
			return _context.MenuTables.Count();
		}
	}
}
