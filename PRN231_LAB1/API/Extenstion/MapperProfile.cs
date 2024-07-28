using AutoMapper;
using BusinisseObjects.Dto;
using BusinisseObjects.Dto.Request;
using BusinisseObjects.Dto.Response;
using BusinisseObjects.Models;

namespace API.Extenstion;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Product, ProductResponseDto>().ReverseMap();
        CreateMap<Product, ProductRequestDto>().ReverseMap();
        CreateMap<Member, MemberResponseDto>().ReverseMap();
        CreateMap<Member, MemberRequestDto>().ReverseMap();
        CreateMap<Order, OrderResponseDto>().ReverseMap();
        CreateMap<Order, OrderRequestDto>().ReverseMap();
        CreateMap<Category, CategoryResponseDto>().ReverseMap();
        CreateMap<Category, CategoryRequestDto>().ReverseMap();
    }
}