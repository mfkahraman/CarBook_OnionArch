using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook_OnionArch.Application.Features.CQRS.Results.CategoryResults;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Mappings
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category,CreateCategoryCommand>().ReverseMap();
            CreateMap<Category,UpdateCategoryCommand>().ReverseMap();
            CreateMap<Category,GetCategoryQueryResult>();
            CreateMap<Category,GetCategoryByIdQueryResult>();
        }
    }
}
