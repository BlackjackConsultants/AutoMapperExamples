using System;
using AutoMapper;
using AutoMapper.Mappers;
using AutoMapperExamples.Dto;
using AutoMapperExamples.Entity;
using AutoMapperExamples.Resolvers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoMapperExamples {
    [TestClass]
    public class DynamicMapsExample {

        [TestInitialize]
        public void Setup() {
            Mapper.Reset();
        }

        [TestMethod]
        public void MapWithConfiguration(){
            Car c = new Car{
                Make = "camaro"
            };
            int test = 10;
            var cc = Mapper.DynamicMap<Car>(c);
            Assert.AreEqual(c.Make, cc.Make);
            var testcopy = Mapper.Map<int>(test);
            Assert.AreEqual(10, testcopy);
        }
    }
}