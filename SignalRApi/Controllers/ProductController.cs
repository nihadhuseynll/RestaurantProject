using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _productService.TGetListAll();
            return Ok(values);
        }
        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var values=_mapper.Map<List<ResultProductWithCategoryDto>>(_productService.TGetProductsWithCategories());
            return Ok(values);
        }
        [HttpGet("ProductCount")]
        public IActionResult ProductCount() 
        {
          return Ok(_productService.TProductCount());
        }
		[HttpGet("ProductCountByHamburger")]
		public IActionResult ProductCountByFood()
		{
			return Ok(_productService.TProductCountByHamburger());
		}
		[HttpGet("ProductCountByIcecek")]
		public IActionResult ProductCountByDrink()
		{
			return Ok(_productService.TProductCountByIcecek());
		}
		[HttpGet("ProductPriceByAvg")]
		public IActionResult ProductPriceByAvg()
		{
			return Ok(_productService.TProductPriceByAvg());
		}
		[HttpGet("ProductNameByMaxPrice")]
		public IActionResult ProductNameByMaxPrice()
		{
			return Ok(_productService.TProductNameByMaxPrice());
		}
		[HttpGet("ProductNameByMinPrice")]
		public IActionResult ProductNameByMinPrice()
		{
			return Ok(_productService.TProductNameByMinPrice());
		}
		[HttpGet("ProductAvgPriceByHamburger")]
		public IActionResult ProductAvgPriceByFood()
		{
			return Ok(_productService.TProductAvgPriceByHamburger());
		}
		[HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            _productService.TAdd(new Product()
            {
                Price = createProductDto.Price,
                ProductDescription = createProductDto.ProductDescription,   
                ProductName= createProductDto.ProductName,
                ProductStatus= createProductDto.ProductStatus,
                ImageUrl= createProductDto.ImageUrl,    
                CategoryId= createProductDto.CategoryId
            });
            return Ok("Product Başarıyla eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return Ok("Product Başarıyla Silindi.");
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            _productService.TUpdate(new Product()
            {
                Price = updateProductDto.Price,
                ProductDescription = updateProductDto.ProductDescription,
                ProductName = updateProductDto.ProductName,
                ProductStatus = updateProductDto.ProductStatus,
                ImageUrl = updateProductDto.ImageUrl,
                ProductId= updateProductDto.ProductId,
                CategoryId= updateProductDto.CategoryId
            });
            return Ok("Product Başarıyla güncellendi.");
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value= _productService.TGetById(id);
            return Ok(value);
        }
    }
}
