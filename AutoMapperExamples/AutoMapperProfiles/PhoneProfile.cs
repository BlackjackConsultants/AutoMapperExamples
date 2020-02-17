using AutoMapper;
using AutoMapperExamples.Dto;
using AutoMapperExamples.Entity;
using AutoMapperExamples.Mappers;

namespace AutoMapperExamples.AutoMapperProfiles {
    public class PhoneProfile : ProfileBase
    {
        public PhoneProfile(ConfigurationStore store) {
            Store = store;
        }

        public PhoneProfile() {
            System.Diagnostics.Debug.WriteLine("test");
        }

        protected override void Configure() {
            CreateMap<Phone, PhoneDto>();
            CreateMap<PhoneDto, Phone>();
		}

        public override string ProfileName
        {
            get { return this.GetType().Name; }
        } 

	}
}
