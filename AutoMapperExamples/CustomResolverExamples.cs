using System;
using AutoMapper;
using AutoMapper.Mappers;
using AutoMapperExamples.Dto;
using AutoMapperExamples.Entity;
using AutoMapperExamples.Resolvers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoMapperExamples {
    [TestClass]
    public class CustomResolverExamples {

        [TestInitialize]
        public void Setup() {
            Mapper.Reset();
        }

        [TestMethod]
        public void MapWithConfiguration() {
            var enginestore1 = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            var engine1 = new MappingEngine(enginestore1);

            enginestore1.CreateMap<Source, DestinationDto>()
                .ForMember(dest => dest.Total, opt => opt.ResolveUsing<CustomResolver>());

            var dto = engine1.Map<Source, DestinationDto>(GetEntity());

            Assert.AreEqual(dto.Total, 3);
        }

        private Source GetEntity() {
            var source = new Source();
            source.Value1 = 1;
            source.Value2 = 2;
            return source;
        }
    }
}