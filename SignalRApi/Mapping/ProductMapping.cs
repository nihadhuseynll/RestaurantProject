using AutoMapper;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product,ResultProductDto>().ReverseMap();
            CreateMap<Product,CreateProductDto>().ReverseMap();
            CreateMap<Product,UpdateProductDto>().ReverseMap();
            CreateMap<Product,GetProductDto>().ReverseMap();
            CreateMap<Product,ResultProductWithCategoryDto>()
                .ForMember(e=>e.CategoryName,o=>o.MapFrom(d=>d.Category.CategoryName)).ReverseMap();
        }
    }
}
