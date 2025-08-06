using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.TestimonialResults;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Mappings
{
    public class TestimonialMappingProfile : Profile
    {
        public TestimonialMappingProfile()
        {
            CreateMap<Testimonial, CreateTestimonialCommand>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialCommand>().ReverseMap();
            CreateMap<Testimonial, GetTestimonialByIdQueryResult>();
            CreateMap<Testimonial, GetTestimonialQueryResult>();
        }
    }
}
