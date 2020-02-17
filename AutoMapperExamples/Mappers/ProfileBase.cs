using AutoMapper;

namespace AutoMapperExamples.Mappers
{
    public abstract class ProfileBase : Profile
    {
        protected ProfileBase(ConfigurationStore store)
        {
            Store = store;
        }

        protected ConfigurationStore Store;

        protected ProfileBase() {}

        public override string ProfileName
        {
            get { return GetType().Name; }
        } 
    }
}
