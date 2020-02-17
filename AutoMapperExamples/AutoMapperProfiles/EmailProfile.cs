using AutoMapper;
using AutoMapperExamples.Dto;
using AutoMapperExamples.Entity;
using AutoMapperExamples.Mappers;

namespace AutoMapperExamples.AutoMapperProfiles {
    public class EmailProfile : ProfileBase
    {
        public EmailProfile(ConfigurationStore store) {
            this.Store = store;
        }

        public EmailProfile() {
        }

        protected override void Configure() {
            CreateMap<Email, EmailDto>();
            CreateMap<EmailDto, Email>();
		}

        public override string ProfileName
        {
            get { return this.GetType().Name; }
        } 

	}
}
