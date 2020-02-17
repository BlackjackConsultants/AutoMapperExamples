using System.Collections.Generic;
using AutoMapper;
using AutoMapperExamples.Dto;
using AutoMapperExamples.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoMapperExamples {
	[TestClass]
	public class AutoMapperExamples {
		[TestInitialize]
		public void Setup() {
            Mapper.Reset();
		}

		[TestMethod]
		public void MapSimpleObject() {
			// create a manually mapping between FName of dto to FirstName of the entity.
            Mapper.CreateMap<Individual, IndividualDto>().ForMember(
				dest => dest.FName, 
				option => option.MapFrom(src => src.Name)
			);
            Mapper.AssertConfigurationIsValid();

			// fill entity with data that will be passed to dto.
            var contact = new Individual { Name = "Jorge", LastName = "Perez", Id = 1, Phones = new List<Phone> { new Phone { Id = 1, Number = "333-3333" }, new Phone { Id = 2, Number = "444-4444" } } };

			// copy values from entity to dto. this is achieved by the Map method of the Mapper class.
            var contactDto = Mapper.Map<Individual, IndividualDto>(contact);
			Assert.IsNotNull(contactDto);
			Assert.IsNotNull(contactDto.FName);
            Assert.IsNotNull(contactDto.LastName);
            Assert.AreEqual(contactDto.Phones.Count, 2);
		}

        [TestMethod]
        public void MapAsList() {
            // create a manually mapping between FName of dto to FirstName of the entity.
            Mapper.CreateMap<Individual, IndividualDto>().ForMember(
                dest => dest.FName,
                option => option.MapFrom(src => src.Name)
            );
            Mapper.AssertConfigurationIsValid();

            // fill entity with data that will be passed to dto.
            IList<Individual> contacts = new List<Individual>();
            var contact = new Individual { Name = "Jorge", LastName = "Perez", Id = 1 };
            var contact1 = new Individual { Name = "Jorge1", LastName = "Perez1", Id = 2 };
            contacts.Add(contact);
            contacts.Add(contact1);


            // copy values from entity to dto. this is achieved by the Map method of the Mapper class.
            var contactDtos = Mapper.Map<IList<Individual>, IList<IndividualDto>>(contacts);
            Assert.IsNotNull(contactDtos);
            Assert.AreNotEqual(contactDtos.Count, 0);
        }
        [TestMethod]
        public void MapChildObjects() {
            // create a manually mapping between FName of dto to FirstName of the entity.
            Mapper.CreateMap<Individual, IndividualDto>().ForMember(
                dest => dest.FName,
                option => option.MapFrom(src => src.Name)
            );
            Mapper.AssertConfigurationIsValid();

            // fill entity with data that will be passed to dto.
            IList<Individual> contacts = new List<Individual>();
            var contact = new Individual { Name = "Jorge", LastName = "Perez", Id = 1 };
            var contact1 = new Individual { Name = "Jorge1", LastName = "Perez1", Id = 2 };
            contacts.Add(contact);
            contacts.Add(contact1);


            // copy values from entity to dto. this is achieved by the Map method of the Mapper class.
            var contactDtos = Mapper.Map<IList<Individual>, IList<IndividualDto>>(contacts);
            Assert.IsNotNull(contactDtos);
            Assert.AreNotEqual(contactDtos.Count, 0);
        }

	}
}
