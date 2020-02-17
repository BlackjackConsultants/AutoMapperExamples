using System.Collections.Generic;
using AutoMapper;
using AutoMapperExamples.Dto;
using AutoMapperExamples.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoMapperExamples
{
    [TestClass]
    public class MappingToExistingDestination
    {
        [TestInitialize]
        public void Setup()
        {
            Mapper.Reset();
        }

        /// <summary>
        ///     this example shows how to copy an object to an existing object.
        /// </summary>
        [TestMethod]
        public void MapToExistingObject()
        {
            // create a manually mapping between FName of dto to FirstName of the entity.
            Mapper.CreateMap<Individual, IndividualDto>().ReverseMap();

            // fill entity with data that will be passed to dto.
            var contact = new Individual
            {
                FileAs = "Jorge",
                LastName = "Perez",
                Id = 1,
                Phones = new List<Phone>
                {
                    new Phone {Id = 1, Number = "333-3333"},
                    new Phone {Id = 2, Number = "444-4444"}
                }
            };

            // copy values from entity to dto. this is achieved by the Map method of the Mapper class.
            IndividualDto contactDto = Mapper.Map<Individual, IndividualDto>(contact);
            Assert.IsNotNull(contactDto);
            Assert.AreEqual(contactDto.FileAs, contact.FileAs);
            Assert.IsNotNull(contactDto.LastName, contact.LastName);
            Assert.AreEqual(contactDto.Phones.Count, 2);

            // change contact
            contactDto.Phones.RemoveAt(1);
            contactDto.LastName = "Gonzalez";

            // change existing contact
            Mapper.Map(contactDto, contact);

            // assert
            Assert.AreEqual(contact.LastName, "Gonzalez");
            Assert.AreEqual(contact.Phones.Count, 1);
        }
    }
}