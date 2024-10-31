using AutoMapper;
using Classwork.Application.DTOs;
using Classwork.Domain.Entities;
using static Classwork.Application.DTOs.ProductDTO;

namespace Classworkk.Application.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CategoryDTO, Category>().ReverseMap();
            CreateMap<CategoryCreateDTO, Category>().ReverseMap();
            CreateMap<CategoryUpdateDTO, Category>().ReverseMap();
           // CreateMap<Paginate<Category>, CategoryListDTO>().ReverseMap();
           

            CreateMap<ProductDTO, Product>().ReverseMap(); 
            CreateMap<ProductCreateDto, Product>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>().ReverseMap();
           // CreateMap<Paginate<Product>, ProductListDto>().ReverseMap();
        }
    }
}
