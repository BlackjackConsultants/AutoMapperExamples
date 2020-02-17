using AutoMapper;
using AutoMapperExamples.AutoMapperProfiles;
using AutoMapperExamples.Dto;
using AutoMapperExamples.Entity;

namespace AutoMapperExamples.Mappers
{
    public class ContactMapper : MapperBase<IndividualDto, Individual> {
        /// <summary>
        /// creates the mapping.  if the same mapping was already created elsewhere it ignores it.  
        /// Note: cant use profiles.
        /// </summary>
        /// <param name="store"></param>
        protected override void CreateMaps(ConfigurationStore store)
        {
            store.AddProfile(new PhoneProfile(store));
            store.AddProfile(new EmailProfile(store));
            store.AddProfile(new ContactProfile(store));
            store.AllowNullDestinationValues = true;
            store.AssertConfigurationIsValid();
        }
    }
}
