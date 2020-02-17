using System;
using AutoMapper;
using AutoMapper.Mappers;
using AutoMapperExamples.Dto;
using AutoMapperExamples.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoMapperExamples {
    [TestClass]
    public class SourceDestinationMultipleMappings {
        [TestInitialize]
        public void Setup() {
            Mapper.Reset();
        }

        /// <summary>
        /// if you want to have 2 configurations of AEntity and ADto classes, you need to create 2 configuration stores and create 2 instances
        /// of MapEngine.  This is common with nhibernate since in some cases you want lazy load and other not.
        /// </summary>
        [TestMethod]
        public void MapWithConfiguration() {
            var enginestore1 = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            var enginestore2 = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            var engine1 = new MappingEngine(enginestore1);
            var engine2 = new MappingEngine(enginestore2);

            enginestore1.CreateMap<Individual, IndividualDto>().ForMember(dest => dest.Phones, opt => opt.Ignore());
            enginestore2.CreateMap<Individual, IndividualDto>();

            IndividualDto dto1 = engine1.Map<Individual, IndividualDto>(GetEntity());
            IndividualDto dto2 = engine2.Map<Individual, IndividualDto>(GetEntity());

            Assert.AreEqual(dto1.Phones.Count, 0);
            Assert.AreNotEqual(dto2.Phones.Count, 0);
        }

        private Individual GetEntity() {
            var person = new Individual();
            person.Id = 1;
            person.FileAs = Guid.NewGuid().ToString();
            person.Phones.Add(new Phone {
                Id = 1,
                Number = "555-5555"
            });
            return person;
        }
    }
}