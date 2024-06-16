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
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(SignalRContext context) : base(context)
        {
        }

		public int ActiveCategoryCount()
		{
			using var _context= new SignalRContext();
			return _context.Categories.Where(c=>c.CategoryStatus==true).Count();
		}

		public int CategoryCount()
		{
			using var _context = new SignalRContext();
			return _context.Categories.Count();	
		}

		public int PassiveCategoryCount()
		{
			using var _context = new SignalRContext();
			return _context.Categories.Where(c => c.CategoryStatus == false).Count();
		}
	}
}
