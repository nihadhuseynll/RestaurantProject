using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> TGetProductsWithCategories();
        int TProductCount();
		int TProductCountByFood();
		int TProductCountByDrink();
		decimal TProductPriceByAvg();
		string TProductNameByMaxPrice();
		string TProductNameByMinPrice();
		decimal TProductAvgPriceByFood();
	}
}
