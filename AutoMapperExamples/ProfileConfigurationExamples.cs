using System;
using AutoMapper;
using AutoMapper.Mappers;
using AutoMapperExamples.AutoMapperProfiles;
using AutoMapperExamples.Dto;
using AutoMapperExamples.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoMapperExamples {

	[TestClass]
	public class ProfileConfigurationExamples {
		[TestInitialize]
        public void Setup()
        {
            Mapper.Reset();
            //var configurationStore = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
            var contactProfile = new ContactProfile();
            var emailProfile = new EmailProfile();
            var phoneProfile = new PhoneProfile();
            Mapper.AddProfile(emailProfile);
            Mapper.AddProfile(phoneProfile);
            Mapper.AddProfile(contactProfile);
            Mapper.AssertConfigurationIsValid();
		}

        [TestMethod]
        public void SimpleMapFromEntityToDto()
        {
            // fill entity with data that will be passed to dto.
            var email = new Email { Address = "jorge@yahoo.com"};

            // copy values from entity to dto. this is achieved by the Map method of the Mapper class.
            var emailDto = Mapper.Map<Email, EmailDto>(email);
            Assert.IsNotNull(emailDto);
            Assert.IsNotNull(emailDto.Address);
        }


	    [TestMethod]
		public void MapFromEntityToDto() {
			// fill entity with data that will be passed to dto.
			var contact = new Individual { Name = "Jorge", LastName = "Perez", Id = 1 };
			contact.Phones.Add(new Phone() { Id = 1, Number = "333-444-5555" });
			contact.Phones.Add(new Phone() { Id = 2, Number = "666-777-5555" });
			contact.Phones.Add(new Phone() { Id = 3, Number = "888-444-6666" });

			// copy values from entity to dto. this is achieved by the Map method of the Mapper class.
            var contactDto = Mapper.Map<Individual, IndividualDto>(contact);
			Assert.IsNotNull(contactDto);
			Assert.IsNotNull(contactDto.FName);
			Assert.IsNotNull(contactDto.LastName);
			Assert.IsTrue(contactDto.Phones.Count > 0);
		}

		[TestMethod]
		public void MapFromDtoToEntity() {
			try {
				// fill entity with data that will be passed to dto.
				var contactDto = new IndividualDto { FName = "Jorge", LastName = "Perez", Id = 1 };

				// copy values from entity to dto. this is achieved by the Map method of the Mapper class.
                var contact = Mapper.Map<IndividualDto, Individual>(contactDto);
				Assert.IsNotNull(contact);
				Assert.IsNotNull(contact.Name);
				Assert.IsNotNull(contact.LastName);
			}
			catch (Exception exc) {
				System.Diagnostics.Debug.WriteLine(exc.Message);
				Assert.Fail(exc.Message);
			}
		}
	}
}
