using AutoMapper;
using AutoMapperExamples.Dto;
using AutoMapperExamples.Entity;

namespace AutoMapperExamples.AutoMapperProfiles {
    public class ContactProfileNoPhones : Profile {
        protected override void Configure() {
            Mapper.CreateMap<Individual, IndividualDto>().ForMember(
                dest => dest.FName,
                option => option.MapFrom(src => src.Name)
                );
            Mapper.CreateMap<IndividualDto, Individual>().ForMember(
                dest => dest.Name,
                option => option.MapFrom(src => src.FName)
                );
        }
    }
}