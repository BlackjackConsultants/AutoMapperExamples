using AutoMapper;
using AutoMapperExamples.Dto;
using AutoMapperExamples.Entity;
using AutoMapperExamples.Mappers;

namespace AutoMapperExamples.AutoMapperProfiles {
    public class ContactProfile : ProfileBase {
        public ContactProfile(ConfigurationStore store) : base(store) {
            this.Store = store;
        }

        public ContactProfile() {}

        protected override void Configure() {
            Mapper.CreateMap<ContactBase, ContactBaseDto>()
                .Include<Individual, IndividualDto>()
                .Include<Organization, OrganizationDto>();
            Mapper.CreateMap<Individual, IndividualDto>()
		        .ForMember(dest => dest.FName, option => option.MapFrom(src => src.Name));
            Mapper.CreateMap<Organization, OrganizationDto>();

            Mapper.CreateMap<ContactBaseDto, ContactBase>()
                .Include<IndividualDto, Individual>()
                .Include<OrganizationDto, Organization>();
            Mapper.CreateMap<IndividualDto, Individual>()
                .ForMember(dest => dest.Name, option => option.MapFrom(src => src.FName));
            Mapper.CreateMap<OrganizationDto, Organization>();
        }
	}

}
