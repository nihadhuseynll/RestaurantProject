using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;
using SignalRApi.Models;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        public IActionResult GetBasketByMenuTableNumber(int id)
        {
            var values = _basketService.TGetBasketByMenuTableNumber(id);
            return Ok(values);
        }
        [HttpGet("BasketListByMenuTableWithProductName")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            using var _context = new SignalRContext();
            var values = _context.Baskets.Include(b => b.Product).Where(b => b.MenuTableId == id).
                Select(z => new ResultBasketListWithProducts
                {
                    BasketId = z.BasketId,
                    Count = z.Count,
                    MenuTableId = z.MenuTableId,
                    Price = z.Price,
                    ProductId = z.ProductId,
                    TotalPrice = z.TotalPrice,
                    ProductName = z.Product.ProductName
                }).ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            using var _context = new SignalRContext();
            _basketService.TAdd(new Basket()
            {
                ProductId = createBasketDto.ProductId,
                Count = 1,
                MenuTableId = 3,
                Price = _context.Products.Where(p => p.ProductId == createBasketDto.ProductId)
                                         .Select(p => p.Price).FirstOrDefault(),
                TotalPrice = 0
            });
            return Ok("Sebet Ugurla Elave Edildi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value=_basketService.TGetById(id);  
            _basketService.TDelete(value);
            return Ok("Sepetinizde secili urun silindi");
        }
    }
}
