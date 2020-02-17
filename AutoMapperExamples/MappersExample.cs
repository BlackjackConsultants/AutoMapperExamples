using System;
using AutoMapper;
using AutoMapperExamples.AutoMapperProfiles;
using AutoMapperExamples.Dto;
using AutoMapperExamples.Entity;
using AutoMapperExamples.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoMapperExamples {

	[TestClass]
    public class MappersExample
    {
	    private ContactMapper contactMapper;

	    public ContactMapper ContactMapper {
	        get {
	            if (contactMapper == null) {
	                contactMapper = new ContactMapper();
	            }
	            return contactMapper;
	        }
	    }

        //[TestInitialize]
        //public void Setup() {
        //   Mapper.Reset();
        //   Mapper.Initialize(cfg => cfg.AddProfile<PhoneProfile>());
        //   Mapper.Initialize(cfg => cfg.AddProfile<EmailProfile>());
        //   Mapper.Initialize(cfg => cfg.AddProfile<ContactProfile>());
        //   Mapper.AssertConfigurationIsValid();
        //}

		[TestMethod]
		public void MapFromEntityToDto() {
            
			// fill entity with data that will be passed to dto.
			var contact = new Individual { Name = "Jorge", LastName = "Perez", Id = 1 };
			contact.Phones.Add(new Phone() { Id = 1, Number = "333-444-5555" });
			contact.Phones.Add(new Phone() { Id = 2, Number = "666-777-5555" });
			contact.Phones.Add(new Phone() { Id = 3, Number = "888-444-6666" });

		    var contactDto = ContactMapper.Map(contact);
            Assert.IsNotNull(contactDto);
            Assert.IsNotNull(contactDto.FName);
            Assert.IsNotNull(contactDto.LastName);
			Assert.IsTrue(contact.Phones.Count > 0);
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
