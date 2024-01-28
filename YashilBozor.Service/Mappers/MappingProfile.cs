using AutoMapper;
using YashilBozor.Domain.Entities.Categories;
using YashilBozor.Domain.Entities.Notification;
using YashilBozor.Domain.Entities.Users;
using YashilBozor.Service.DTOs.Categories;
using YashilBozor.Service.DTOs.Categories.Assets.ProductAssets;
using YashilBozor.Service.DTOs.Categories.Products;
using YashilBozor.Service.DTOs.Users;
using YashilBozor.Service.Models;
namespace YashilBozor.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Users
        CreateMap<User, UserForUpdateDto>().ReverseMap();
        CreateMap<User, UserForResultDto>().ReverseMap();
        CreateMap<User, SignUpDetails>().ReverseMap();

        //Notifications
        CreateMap<EmailMessage, Email>().ReverseMap();

        //Categories
        CreateMap<Category, CategoryForResultDto>().ReverseMap();
        CreateMap<Category, CategoryForUpdateDto>().ReverseMap();
        CreateMap<Category, CategoryForCreationDto>().ReverseMap();

        //Products
        CreateMap<Product, ProductForResultDto>().ReverseMap();
        CreateMap<Product, ProductForUpdateDto>().ReverseMap();
        CreateMap<Product, ProductForCreationDto>().ReverseMap();

        //Product Assets
        CreateMap<Asset, ProductAssetForCreationDto>().ReverseMap();
        CreateMap<Asset, ProductAssetForResultDto>().ReverseMap();
    }
}
