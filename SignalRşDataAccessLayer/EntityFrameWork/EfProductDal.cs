using Microsoft.EntityFrameworkCore;
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
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
			using var _context = new SignalRContext();
			var values = _context.Products.Include(p => p.Category).ToList();
            return values;
        }

		public int ProductCount()
		{
			using var _context = new SignalRContext();
			return _context.Products.Count();   
		}

		public int ProductCountByDrink()
		{
			using var _context = new SignalRContext();
			return _context.Products.Where(p=>p.CategoryId==(_context.Categories.Where(c=>c.CategoryName=="Icecek"))
			                        .Select(c=>c.CategoryId).FirstOrDefault()).Count();
		}

		public int ProductCountByYemek()
		{
			using var _context = new SignalRContext();
			return _context.Products.Where(p => p.CategoryId == (_context.Categories.Where(c => c.CategoryName == "Yemek"))
									.Select(c => c.CategoryId).FirstOrDefault()).Count();
		}

		public string ProductNameByMaxPrice()
		{
			using var _context = new SignalRContext();	
			return _context.Products.Where(p=>p.Price==(_context.Products.Max(p=>p.Price)))
				                    .Select(p=>p.ProductName).FirstOrDefault();
		}

		public string ProductNameByMinPrice()
		{
			using var _context = new SignalRContext();
			return _context.Products.Where(p => p.Price == (_context.Products.Min(p => p.Price)))
									.Select(p => p.ProductName).FirstOrDefault();
		}

		public decimal ProductPriceByAvg()
		{
			using var _context = new SignalRContext();
			return _context.Products.Average(p=>p.Price);	
		}
	}
}
