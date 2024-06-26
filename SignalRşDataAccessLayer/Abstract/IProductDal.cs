using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> GetProductsWithCategories();
        int ProductCount();
        int ProductCountByHamburger();
        int ProductCountByIcecek();
        decimal ProductPriceByAvg();
        string ProductNameByMaxPrice();
        string ProductNameByMinPrice();
        decimal ProductAvgPriceByHamburger();
    }
}
