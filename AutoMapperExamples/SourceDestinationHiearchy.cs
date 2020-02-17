using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapperExamples.AutoMapperProfiles;
using AutoMapperExamples.Dto;
using AutoMapperExamples.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoMapperExamples {
    [TestClass]
    public class SourceDestinationHiearchy {
		[TestInitialize]
		public void Setup() {
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
		public void MapContact() {
			// fill entity with data that will be passed to dto.
			var individual = new Individual { Name = "Jorge", LastName = "Perez", Id = 1 };
			individual.Phones.Add(new Phone() { Id = 1, Number = "333-444-5555" });
			individual.Phones.Add(new Phone() { Id = 2, Number = "666-777-5555" });
			individual.Phones.Add(new Phone() { Id = 3, Number = "888-444-6666" });
            var organization = new Organization { Name = "Sungard", Id = 2 };
            organization.Phones.Add(new Phone() { Id = 1, Number = "111-444-5555" });

            var contacts = new List<ContactBase>();
            contacts.Add(individual);
            contacts.Add(organization);

            var contactDto = Mapper.Map<ContactBase, ContactBaseDto>(contacts[0]);
            Assert.IsNotNull(contactDto);

			// copy values from entity to dto. this is achieved by the Map method of the Mapper class.
            var contactDtos = contacts.Select(c => Mapper.Map<ContactBase, ContactBaseDto>(c)).ToList(); // Mapper.Map<ContactBase, ContactBaseDto>(contacts);
            Assert.IsNotNull(contactDtos);
            Assert.AreEqual(contactDtos.Count(), 2);
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